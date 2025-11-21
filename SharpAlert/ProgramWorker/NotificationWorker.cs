using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SharpAlert.AlertComponents;
using SharpAlert.AlertComponents.Dashboard;
using SharpAlert.ConfigurationDialogs;
using SharpAlert.Properties;
using static SharpAlert.ProgramWorker.HaidaWorker;
using static SharpAlert.ProgramWorker.MainEntryPoint;

namespace SharpAlert.ProgramWorker
{
    public static class NotificationWorker
    {
        public static bool NotifyIconIsNull()
        {
            if (Notify == null) return true;
            else return false;
        }

        public static NotifyIcon Notify = null;
        private static ConfigurationForm mf = null;
        //private static bool NotifyIconCalled = false;
        public static bool IgnoreRightClick = false;

        /// <summary>
        /// Creates a tray icon. Throws NotSupportedException if called more than once.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        public static void CreateNotifyIcon(string RemoteVersion)
        {
            //if (NotifyIconCalled) throw new NotSupportedException("You cannot create more than one instance at any given point.");
            //NotifyIconCalled = true;

            Notify?.Dispose();

            Notify = new NotifyIcon
            {
                Icon = Resources.TrayLightIcon,
                Visible = true,
                Text = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}" // We can't use the friendly version here, it is too long
                //Text = $"{VersionInfo.FriendlyVersion}"
            };

            ContextMenuStrip contextMenu = new ContextMenuStrip();

            contextMenu.Opening += (a, b) =>
            {
                mf?.Hide();

                if (Control.ModifierKeys == Keys.Shift)
                {
                    string ForceQuitMsg = "Click YES to immediately shutdown SharpAlert.\r\n" +
                        "You should only use this feature as a last resort.";

                    //if (ChangedPropertiesList.Count != 0)
                    //{
                    //    ForceQuitMsg += "\r\n\r\n" +
                    //    "You have unsaved changes that will be lost if you continue.";
                    //}

                    if (MessageBox.Show(ForceQuitMsg,
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        Environment.Exit(0);
                    }

                    b.Cancel = true;
                    return;
                }

                //if (Control.ModifierKeys == Keys.ShiftKey)
                //{
                //    IgnoreRightClick = false;
                //}

                if (IgnoreRightClick)
                {
                    b.Cancel = true;
                    Notify.ShowNotification("Please close open windows before opening the tray menu again. Try using ALT+TAB to find them!",
                        "Before you right-click again...", ToolTipIcon.Info);

                    FormCollection fc = Application.OpenForms;

                    try
                    {
                        fc[0].BringToFront();
                        fc[0].Activate();
                    }
                    catch (Exception) { }
                    //MessageBox.Show("Please close all windows before opening the menu.",
                    //    "SharpAlert",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Information);
                    if (b.Cancel) return;
                }
            };

            contextMenu.Items.Add(new ToolStripMenuItem("Show Console", null, (sender, arg) =>
            {
                IgnoreRightClick = true;
                if (MessageBox.Show("Do you want to show the console?\r\n" +
                    "Closing the console may terminate the program.",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AllocateTerminal();
                }
                IgnoreRightClick = false;
            }));

            contextMenu.Items.Add(new ToolStripSeparator());

            contextMenu.Items.Add(new ToolStripLabel($"Using {Path.GetFileName(QuickSettings.ConfigPath)}"));
            
            contextMenu.Items.Add(new ToolStripMenuItem("Clear Cache", null, (sender, arg) =>
            {
                IgnoreRightClick = true;
                if (MessageBox.Show("Forcefully clear (and reset) the cache?\r\n" +
                    "This may take a few seconds.",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cache.ServiceRun(false);
                }
                IgnoreRightClick = false;
            }));
            
            contextMenu.Items.Add(new ToolStripMenuItem("Clear Garbage", null, (sender, arg) =>
            {
                IgnoreRightClick = true;
                if (MessageBox.Show("Forcefully clear garbage (by calling the Garbage Collector)?",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GC.Collect();
                }
                IgnoreRightClick = false;
            }));

            //IgnoreRightClick = true;
            //IgnoreRightClick = false;

            contextMenu.Items.Add(new ToolStripSeparator());

            //bool UpdatesAvailable = false;

            SpeakingManager.ProgramRunning();

            if (RemoteVersion == "service")
            {
                Notify.ShowNotification("I'll just be waiting right over here in my tray icon. Service mode active.",
                    "SharpAlert is running",
                    ToolTipIcon.Info);
            }
            else
            {
                string[] RemoteVersionSplit = RemoteVersion.Split('.');

                if (RemoteVersionSplit.Length == 2)
                {
                    try
                    {
                        if (int.Parse(RemoteVersionSplit[0]) > VersionInfo.MajorVersion ||
                            int.Parse(RemoteVersionSplit[1]) > VersionInfo.MinorVersion)
                        {
                            Notify.ShowNotification($"Update available! v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} -> v{RemoteVersionSplit[0]}.{RemoteVersionSplit[1]}",
                                "SharpAlert found updates",
                                ToolTipIcon.Info);

                            //UpdateWorker.TryUpdate($"{RemoteVersionSplit[0]}.{RemoteVersionSplit[1]}");
                            //UpdatesAvailable = true;
                        }
                        else
                        {
                            if (int.Parse(RemoteVersionSplit[0]) < VersionInfo.MajorVersion ||
                                int.Parse(RemoteVersionSplit[1]) < VersionInfo.MinorVersion)
                            {
                                Notify.ShowNotification($"Downgrade available! v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} -> v{RemoteVersionSplit[0]}.{RemoteVersionSplit[1]}",
                                    "SharpAlert found updates",
                                    ToolTipIcon.Info);
                            }
                            else
                            {
                                Notify.ShowNotification($"I'll just be waiting right over here in my tray icon. You're up to date.",
                                    "SharpAlert is running",
                                    ToolTipIcon.Info);
                            }
                        }
                    }
                    catch (Exception)
                    {
                        Notify.ShowNotification($"I'll just be waiting right over here in my tray icon. Couldn't check for updates.",
                            "SharpAlert is running",
                            ToolTipIcon.Info);
                    }
                }
                else
                {
                    Notify.ShowNotification($"I'll just be waiting right over here in my tray icon. Couldn't check for updates.",
                        "SharpAlert is running",
                        ToolTipIcon.Info);
                }
            }

            string home = "https://bunnytub.com/SharpAlert";
            //string update = "https://bunnytub.com/SharpAlert?update=1";

            contextMenu.Items.Add(new ToolStripLabel($"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}",
                Resources.AlertIcon, true, (obj, args) =>
                {
                    HackyWorkarounds.OpenURL(home);
                })
            {
                ToolTipText = "Very mindful, very demure."
            });

            //if (UpdatesAvailable)
            //{
            //    contextMenu.Items.Add(new ToolStripLabel($"Click here to update!",
            //        null, true, (obj, args) =>
            //        {
            //            HackyWorkarounds.OpenURL(update);
            //        })
            //    {
            //        ToolTipText = "There's an update available for you to download."
            //    });
            //}

            if (QuickSettings.Instance.OpenDashboardAutomatically)
            {
                ThreadDrool.StartAndForget(() => new DashboardForm(false).ShowDialog());
            }

            contextMenu.Items.Add(new ToolStripMenuItem("Open Dashboard", null, (sender, arg) =>
            {
                //MessageBox.Show("The dashboard lists recently relayed alerts. If you close and re-open the dashboard, the list will start from scratch!");
                ThreadDrool.StartAndForget(() => new DashboardForm(false).ShowDialog());
            }));
            
            contextMenu.Items.Add(new ToolStripMenuItem("Open Settings", null, (sender, arg) =>
            {
                IgnoreRightClick = true;
                if (mf == null || mf.IsDisposed) mf = new ConfigurationForm();
                mf.ShowDialog();
                IgnoreRightClick = false;
            }));

            contextMenu.Items.Add(new ToolStripMenuItem("Reset Settings", null, (sender, arg) =>
            {
                if (MessageBox.Show("Reset everything to factory defaults now?\r\n" +
                    "SharpAlert will immediately close if you continue.",
                    "SharpAlert - Reset Settings",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    QuickSettings.Instance.Reset();
                    QuickSettings.Instance.Save();
                    Environment.Exit(0);
                }
            }));

            contextMenu.Items.Add(new ToolStripSeparator());

//#if DEBUG
//            contextMenu.Items.Add(new ToolStripMenuItem("Trigger Intentional Exception", null, (sender, arg) =>
//            {
//                string[] StringOfStrings = { "0", "1" };
//                string StringNumberTwo = StringOfStrings[2].Trim();
//            }));
//#endif

            //contextMenu.Items.Add(new ToolStripMenuItem("Export Logs", null, (sender, arg) =>
            //{
            //    string filepath = Path.GetTempFileName();
            //    File.WriteAllText(filepath, $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}\r\n\r\n{NotificationHistory}");
            //}));
            
            contextMenu.Items.Add(new ToolStripMenuItem("Do Not Disturb", null, (sender, arg) =>
            {
                IgnoreRightClick = true;
                if (QuickSettings.Instance.DisableAlertProcessing)
                {
                    if (MessageBox.Show("Do you want to disable Do Not Disturb?\r\n" +
                        "Alerts will be relayed until it becomes enabled.",
                        "SharpAlert - Do Not Disturb",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        DoNotDisturbMode.StopDND();
                    }
                }
                else
                {
                    DoNotDisturbForm dndf = new();

                    DialogResult result = dndf.ShowDialog();

                    //MessageBox.Show("Do you want to enable Do Not Disturb?\r\n" +
                    //    "Alerts will not be relayed until it becomes disabled.\r\n\r\n" +
                    //    "This will be disabled next time you start SharpAlert.",
                    //    "SharpAlert - Do Not Disturb",
                    //    MessageBoxButtons.YesNo,
                    //    MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        DoNotDisturbMode.StartDND(dndf.DNDTimeInMinutes, dndf.RelayIgnoredAlertsAfterDND.Checked);
                    }
                }

                ((ToolStripMenuItem)sender).Checked = QuickSettings.Instance.DisableAlertProcessing;

                IgnoreRightClick = false;
            }));
            
            contextMenu.Items.Add(new ToolStripMenuItem("Quit", null, (sender, arg) =>
            {
                DialogResult result = MessageBox.Show("Are you sure you want to quit?",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    QuickSettings.Instance.Save();
                    new Thread(() => SafeExit()).Start();
                }
            }));

            Notify.ContextMenuStrip = contextMenu;
            Notify.BalloonTipClicked += Notify_BalloonTipClicked;

            if (!QuickSettings.Instance.AskedForAutomaticUpdates)
            {
                DialogResult result = MessageBox.Show("Do you want to enable automatic updates in SharpAlert? This keeps the program up-to-date, and allows patches and bug fixes to be installed automatically.",
                    "SharpAlert - Automatic Updates",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    QuickSettings.Instance.AllowPerformingUpdates = true;
                }
                else
                {
                    QuickSettings.Instance.AllowPerformingUpdates = false;
                }

                QuickSettings.Instance.AskedForAutomaticUpdates = true;
            }
            
            if (!QuickSettings.Instance.AskedForDiscordRichPresence)
            {
                DialogResult result = MessageBox.Show("Do you want to enable Discord Rich Presence? People on Discord will be able to view basic info about your SharpAlert session directly on your profile.\r\n\r\n(Restart the program to fully enable this!)",
                    "SharpAlert - Discord Rich Presence",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    QuickSettings.Instance.AllowDiscordRichPresence = true;
                }
                else
                {
                    QuickSettings.Instance.AllowDiscordRichPresence = false;
                }

                QuickSettings.Instance.AskedForDiscordRichPresence = true;
            }

            QuickSettings.Instance.LastVersionOpened = $"{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}";
            QuickSettings.Instance.Save();
        }

        private static void Notify_BalloonTipClicked(object sender, EventArgs e)
        {
            //if (!LogAvailable)
            //{
            //    return;
            //}

            //Notify.ContextMenuStrip.Show(Cursor.Position);
        }

        //private static string NotificationHistory = string.Empty;
        private static string PreviousNotification = string.Empty;
        private static int PreviousCount = 0;

        public static void ShowNotification(this NotifyIcon notify, string text, string title, ToolTipIcon icon)
        {
            if (notify != null)
            {
                lock (notify)
                {
                    if (PreviousNotification.Contains(text))
                    {
                        PreviousCount++;
                    }
                    else
                    {
                        PreviousCount = 0;
                    }

                    //NotificationHistory += $"[{DateTime.UtcNow:R}]\r\nIcon: {icon}\r\nTitle: {title.Trim()}\r\nText: {text.Trim()}\r\n\r\n";

                    //if (PreviousCount >= 2)
                    //{
                    //    notify.BalloonTipText = "Subsequent similar notifications have been logged.";
                    //    notify.BalloonTipTitle = "SharpAlert hid this one";
                    //    notify.BalloonTipIcon = icon;
                    //}
                    //else
                    //{
                    PreviousNotification = text;
                    notify.BalloonTipText = text;
                    notify.BalloonTipTitle = title;
                    notify.BalloonTipIcon = icon;
                    //}

                    if (!(PreviousCount > 2)) notify.ShowBalloonTip(15000);
                }
            }
        }
    }
}