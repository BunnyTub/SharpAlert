using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using SharpAlert.ConfigurationDialogs;
using SharpAlert.Properties;
using static SharpAlert.ProgramWorker.IceBearWorker;
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
        private static bool NotifyIconCalled = false;
        //private static readonly List<string> ChangedPropertiesList = new List<string>();
        public static bool IgnoreRightClick = false;

        /// <summary>
        /// Creates a tray icon. Throws NotSupportedException if called more than once.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        public static void CreateNotifyIcon(string RemoteVersion)
        {
            if (NotifyIconCalled) throw new NotSupportedException("You cannot create more than one instance at any given point.");
            NotifyIconCalled = true;

            Notify = new NotifyIcon
            {
                Icon = Resources.TrayLightIcon,
                Visible = true,
                Text = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}"
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
                    MessageBox.Show("Please close all windows before opening the menu.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    if (b.Cancel) return;
                }
            };

            contextMenu.Items.Add(new ToolStripMenuItem("Show Console", null, (sender, arg) =>
            {
                IgnoreRightClick = true;
                if (MessageBox.Show("Do you want to show the console?\r\n" +
                    "Closing the console will terminate the program.",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AllocateTerminal();
                }
                IgnoreRightClick = false;
            }));

            contextMenu.Items.Add(new ToolStripMenuItem("Reset Cache", null, (sender, arg) =>
            {
                IgnoreRightClick = true;
                if (MessageBox.Show("Forcefully reset the cache?",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cache.ServiceRun(false);
                }
                IgnoreRightClick = false;
            }));

            //IgnoreRightClick = true;
            //IgnoreRightClick = false;

            contextMenu.Items.Add(new ToolStripSeparator());

            bool UpdatesAvailable = false;

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
                            UpdatesAvailable = true;
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

            string home = "https://bunnytub.com/SharpAlert.html";
            string update = "https://bunnytub.com/SharpAlert.html?update=1";

            contextMenu.Items.Add(new ToolStripLabel($"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}",
                Resources.AlertIcon, true, (obj, args) =>
                {
                    try
                    {
                        Process.Start(home);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Enter the following URL in your browser:\r\n" +
                            $"{home}\r\n\r\n" +
                            "The link couldn't be opened.",
                            "SharpAlert",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                    }
                })
            {
                ToolTipText = "Very mindful, very demure."
            });

            if (UpdatesAvailable)
            {
                contextMenu.Items.Add(new ToolStripLabel($"Click here to update!",
                    null, true, (obj, args) =>
                    {
                        try
                        {
                            Process.Start(update);
                        }
                        catch (Exception)
                        {
                            MessageBox.Show("Enter the following URL in your browser:\r\n" +
                                $"{home}\r\n\r\n" +
                                "The link couldn't be opened.",
                                "SharpAlert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                        }
                    })
                {
                    ToolTipText = "There's an update available for you to download."
                });
            }

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
                    "SharpAlert will close if you continue.",
                    "SharpAlert",
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

            contextMenu.Items.Add(new ToolStripMenuItem("Export Logs", null, (sender, arg) =>
            {
                string filepath = Path.GetTempFileName();
                File.WriteAllText(filepath, $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}\r\n\r\n{NotificationHistory}");
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
                    SafeExit();
                }
            }));

            Notify.ContextMenuStrip = contextMenu;
            Notify.BalloonTipClicked += Notify_BalloonTipClicked;
        }

        private static void Notify_BalloonTipClicked(object sender, EventArgs e)
        {
            //if (!LogAvailable)
            //{
            //    return;
            //}

            Notify.ContextMenuStrip.Show(Cursor.Position);
        }

        private static string NotificationHistory = string.Empty;
        private static string PreviousNotification = string.Empty;
        private static int PreviousCount = 0;

        public static void ShowNotification(this NotifyIcon notify, string text, string title, ToolTipIcon icon)
        {
            if (notify != null)
            {
                lock (notify)
                {
                    if (PreviousNotification == text.Trim())
                    {
                        PreviousCount++;
                    }
                    else
                    {
                        PreviousCount = 0;
                    }

                    NotificationHistory += $"[{DateTime.UtcNow:R}]\r\nIcon: {icon}\r\nTitle: {title.Trim()}\r\nText: {text.Trim()}\r\n\r\n";

                    if (PreviousCount >= 3)
                    {
                        notify.BalloonTipText = "Subsequent similar notifications have been logged.";
                        notify.BalloonTipTitle = "SharpAlert hid this one";
                        notify.BalloonTipIcon = icon;
                    }
                    else
                    {
                        PreviousNotification = text.Trim();
                        notify.BalloonTipText = text;
                        notify.BalloonTipTitle = title;
                        notify.BalloonTipIcon = icon;
                    }

                    notify.ShowBalloonTip(10000);
                }
            }
        }
    }
}