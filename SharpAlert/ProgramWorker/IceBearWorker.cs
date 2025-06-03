using Microsoft.Win32;
using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.ServiceThreads;
using static SharpAlert.RegexList;
using static SharpAlert.AudioManager;
using static SharpAlert.ThreadDrool;

namespace SharpAlert
{
    public static class IceBearWorker
    {
        public static readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        public static bool ServiceRunnerScheduled { get; private set; }

        public static readonly string SelfUserAgent = "Mozilla/5.0 (compatible; SharpAlert; bunnytub@bunnytub.com)";

        /// <summary>
        /// Starts the Ice Bear Worker as a client.
        /// </summary>
        [MTAThread]
        public static void ServiceRun()
        {
            args = Environment.GetCommandLineArgs();

            if (args.Length >= 2) if (args.Contains("--console")) AllocateTerminal(false);
            if (Settings.Default.alertNoGUI) AllocateTerminal(false);

            ConsoleExt.WriteLine($"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} | IsBeta = {VersionInfo.BetaVersion} | Safety is never a non-priority. | https://sharpalert.bunnytub.com/");

            client.DefaultRequestHeaders.UserAgent.ParseAdd(SelfUserAgent);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                icon = Icon.ExtractAssociatedIcon(AssemblyFile);
            }
            catch (Exception)
            {
                icon = SystemIcons.Application;
            }

            string RemoteVersion = string.Empty;

            ConsoleExt.WriteLine("[Ice Bear] Checking application version.");

            string IdentityURL = "https://bunnytub.com";

            try
            {
                HttpResponseMessage latest = client.GetAsync($"{IdentityURL}/SharpAlert/SharpAlert.txt").Result;

                ConsoleExt.WriteLine($"[Ice Bear] The server responded with status code {latest.StatusCode}.");

                RemoteVersion = latest.Content.ReadAsStringAsync().Result.Trim();
                if (string.IsNullOrWhiteSpace(RemoteVersion) || RemoteVersion.Length == 0 || RemoteVersion.Length >= 10) RemoteVersion = "0.0";
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Ice Bear] {ex.StackTrace} {ex.Message}");
                ConsoleExt.WriteLine($"[Ice Bear] Couldn't work with the server.");
            }

            if (VersionInfo.BetaVersion)
            {
                if (DateTime.UtcNow >= VersionInfo.BetaTimeEnd)
                {
                    TimedForm tf = new TimedForm();
                    tf.ShowDialog();
                    tf.Dispose();
                }
            }

            ConsoleExt.WriteLine("[Ice Bear] Initializing services.");
            // use threads you moron
            ConsoleExt.WriteLine("[Ice Bear] Initializing Feed Capture.");
            feed = new FeedCapture();
            ConsoleExt.WriteLine("[Ice Bear] Initializing Atom Feed Capture.");
            atomfeed = new WeatherAtomCapture();
            ConsoleExt.WriteLine("[Ice Bear] Initializing Direct Feed Capture.");
            directfeed = new DirectFeedCapture();
            ConsoleExt.WriteLine("[Ice Bear] Initializing Cache Capture.");
            cache = new CacheCapture();
            ConsoleExt.WriteLine("[Ice Bear] Initializing Data Processor.");
            dataproc = new DataProcessor();
            ConsoleExt.WriteLine("[Ice Bear] Initializing History Processor.");
            historyproc = new HistoryProcessor();
            ConsoleExt.WriteLine("[Ice Bear] Initializing Hyper Server.");
            hyper = new HyperServer();

            Settings.Default.PropertyChanged += (objective, eventArgs) =>
            {
                lock (ChangedPropertiesList)
                {
                    if (!ChangedPropertiesList.Contains(eventArgs.PropertyName))
                        ChangedPropertiesList.Add(eventArgs.PropertyName);
                }
            };

            Settings.Default.SettingsSaving += (objective, eventArgs) =>
            {
                lock (ChangedPropertiesList) ChangedPropertiesList.Clear();
            };
                
            ConsoleExt.WriteLine("[Ice Bear] Starting services momentarily.");

            bool AnyFeedAvailable = false;
            bool SetupExperienceOccurred = false;

            if (!Settings.Default.SetupExperienceComplete)
            {
                ConsoleExt.WriteLine("[Ice Bear] Starting program setup experience.");

                SetupForm sf = new SetupForm();
                sf.ShowDialog();
                sf.Dispose();
                ChooseRegionForm crf = new ChooseRegionForm(true);
                crf.ShowDialog();
                crf.Dispose();
                ChooseStyleForm csf = new ChooseStyleForm(true);
                csf.ShowDialog();
                csf.Dispose();
                ChooseAudioForm caf = new ChooseAudioForm(true);
                caf.ShowDialog();
                caf.Dispose();
                ChooseOwnershipForm cof = new ChooseOwnershipForm(true);
                cof.ShowDialog();
                cof.Dispose();
                SetupDoneForm sdf = new SetupDoneForm();
                sdf.ShowDialog();
                sdf.Dispose();

                Settings.Default.SetupExperienceComplete = true;
                Settings.Default.Save();

                SetupExperienceOccurred = true;
            }

            notificationThread = StartCatchAllThread(() =>
            {
                SystemEvents.PowerModeChanged += (a, b) =>
                {
                    if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhook))
                    {
                        switch (b.Mode)
                        {
                            //case PowerModes.Resume:
                            //    DiscordWebhook.SendFormattedMessage("The host is resuming from sleep.", Settings.Default.DiscordWebhook);
                            //    break;
                            //case PowerModes.Suspend:
                            //    DiscordWebhook.SendFormattedMessage("The host is entering into sleep.", Settings.Default.DiscordWebhook);
                            //    break;
                            case PowerModes.StatusChange:
                                var powerStatus = SystemInformation.PowerStatus;

                                if (powerStatus.BatteryLifePercent == -1)
                                {
                                    return;
                                }

                                float batteryLevel = powerStatus.BatteryLifePercent * 100;
                                bool batteryCharging = powerStatus.PowerLineStatus == PowerLineStatus.Online;

                                if (batteryCharging)
                                {
                                    DiscordWebhook.SendFormattedMessage($"The host is charging. ({(int)batteryLevel}%)", 60928);
                                }
                                else
                                {
                                    DiscordWebhook.SendFormattedMessage($"The host is discharging. ({(int)batteryLevel}%)", 39423);
                                }
                                break;
                        }
                    }
                };

                //SystemEvents.SessionEnding += (a, b) =>
                //{
                //    if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhook))
                //    {
                //        switch (b.Reason)
                //        {
                //            case SessionEndReasons.SystemShutdown:
                //                DiscordWebhook.SendFormattedMessage("The host is shutting down.");
                //                break;
                //            case SessionEndReasons.Logoff:
                //                DiscordWebhook.SendFormattedMessage("The host is logging off.");
                //                break;
                //        }
                //    }
                //    SafeExit();
                //};

                CreateNotifyIcon(RemoteVersion);
                Application.Run();
            }, false);

            while (notify == null) Thread.Sleep(100);

            // migrate users upwards from the minimum limit
            if (Settings.Default.storedMaxSize < 100) Settings.Default.storedMaxSize = 500;

            bool AnyCustomServers()
            {
                try
                {
                    if (File.Exists($"{AssemblyDirectory}\\{CustomURLsFileName}"))
                    {
                        string[] ServerList = File.ReadAllLines($"{AssemblyDirectory}\\{CustomURLsFileName}");
                        int LineNumber = 0;
                        bool FoundValidServer = false;

                        ConsoleExt.WriteLine($"[Ice Bear] Checking \"{CustomURLsFileName}\" for server candidates.");

                        foreach (string raw in ServerList)
                        {
                            string server = raw.Trim();

                            LineNumber++;
                            if (server.StartsWith("#"))
                            {
                                ConsoleExt.WriteLine($"[Ice Bear] Comment skipped on line {LineNumber}.");
                                continue;
                            }
                            else
                            {
                                if (server.StartsWith("http://") || server.StartsWith("https://"))
                                {
                                    server = server.Replace("http://", string.Empty).Replace("https://", string.Empty);
                                    ConsoleExt.WriteLine($"[Ice Bear] Adding server \"{server}\" on line {LineNumber}.");
                                    var VisualServer = new FeedCapture.ServerInfo { ServerName = $"{CustomURLsFileName} | Line {LineNumber}", ServerPath = $"{server}" };
                                    feed.servers.Add(VisualServer);
                                    FoundValidServer = true;
                                    continue;
                                }
                                else
                                {
                                    if (string.IsNullOrWhiteSpace(server))
                                    {
                                        ConsoleExt.WriteLine($"[Ice Bear] Whitespace skipped on line {LineNumber}.");
                                    }
                                    else
                                    {
                                        ConsoleExt.WriteLine($"[Ice Bear] Invalid server skipped on line {LineNumber}.");
                                    }
                                    continue;
                                }
                            }
                        }

                        return FoundValidServer;
                    }
                    else
                    {
                        ConsoleExt.WriteLine($"[Ice Bear] No custom server file found named \"{CustomURLsFileName}\".");
                    }
                }
                catch (Exception ex)
                {
                    ConsoleExt.WriteLine($"[Ice Bear] Couldn't get custom servers. {ex.Message}");
                }
                return false;
            }

            bool CustomServersAvailable = AnyCustomServers();

            if (CustomServersAvailable ||
                Settings.Default.RegionUnitedStates ||
                Settings.Default.RegionUnitedStatesNWS ||
                Settings.Default.RegionCanada ||
                Settings.Default.RegionMexico) AnyFeedAvailable = true;

            if (!AnyFeedAvailable && !SetupExperienceOccurred)
            {
                ConsoleExt.WriteLine("[Ice Bear] Prompting user for region information.");
                ChooseRegionForm crf = new ChooseRegionForm(false);
                crf.ShowDialog();
            }

            Thread startup = new Thread(() =>
            {
                StartupForm sf = new StartupForm(Resources.WarningApp_Splash);
                sf.ShowDialog();
                sf.Dispose();
                if (!Settings.Default.DisclaimerShown)
                {
                    //MessageBox.Show("Just a reminder...\r\n\r\n" +
                    //    "SharpAlert is still in development! Expect bugs here and there.\r\n" +
                    //    "If you find any, please report them, so they can be fixed.\r\n" +
                    //    "Please do not use this app as your only alert source.\r\n" +
                    //    "Remember to check other sources such as local media.\r\n\r\n" +
                    //    "Thanks for downloading SharpAlert!",
                    //    "SharpAlert",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Exclamation);
                    Settings.Default.DisclaimerShown = true;
                    Settings.Default.Save();
                }
            });

            startup.Start();

            RefreshAudioDevices();

            var IPAWSMain = new FeedCapture.ServerInfo { ServerName = "FEMA IPAWS", ServerPath = $"apps.fema.gov/IPAWSOPEN_EAS_SERVICE/rest/eas/recent/{DateTime.UtcNow.AddDays(-30):yyyy-MM-ddTHH:mm:ssZ}" };
            var IPAWSWireless = new FeedCapture.ServerInfo { ServerName = "FEMA IPAWS (WEA)", ServerPath = $"apps.fema.gov/IPAWSOPEN_EAS_SERVICE/rest/eas/recent/{DateTime.UtcNow.AddDays(-30):yyyy-MM-ddTHH:mm:ssZ}" };

            if (Settings.Default.RegionUnitedStates)
            {
                feed.servers.Add(IPAWSMain);
                feed.servers.Add(IPAWSWireless);
            }

            var NWSAtom = new WeatherAtomCapture.ServerInfo { ServerName = "NWS Atom", ServerPath = $"api.weather.gov/alerts/active.atom" };

            if (Settings.Default.RegionUnitedStatesNWS)
            {
                atomfeed.servers.Add(NWSAtom);
            }

            var NAADSPrimary = new DirectFeedCapture.TCPServerInfo { ServerName = "NAADS Primary", ServerAddress = "streaming1.naad-adna.pelmorex.com", ServerPort = 8080 };
            var NAADSBackup = new DirectFeedCapture.TCPServerInfo { ServerName = "NAADS Backup", ServerAddress = "streaming2.naad-adna.pelmorex.com", ServerPort = 8080 };

            if (Settings.Default.RegionCanada)
            {
                directfeed.servers.Add(NAADSPrimary);
                directfeed.servers.Add(NAADSBackup);
            }

            var SASMEXMain = new FeedCapture.ServerInfo { ServerName = "SASMEX", ServerPath = $"sasmex.net/rss/sasmex.xml" };

            if (Settings.Default.RegionMexico)
            {
                feed.servers.Add(SASMEXMain);
            }

            feedThread = StartCatchAllThread(() => feed.ServiceRun(true), false);
            atomfeedThread = StartCatchAllThread(() => atomfeed.ServiceRun(true), false);
            directfeedThread = StartCatchAllThread(() => directfeed.ServiceRun(), false);
            cacheThread = StartCatchAllThread(() => cache.ServiceRun(true), true);
            dataProcThread = StartCatchAllThread(() => dataproc.ServiceRun(), true);
            historyProcThread = StartCatchAllThread(() => historyproc.ServiceRun(), true);
            serverThread = StartCatchAllThread(async () => await hyper.ServiceRun(), true);

            if (Settings.Default.statusWindow)
            {
                CreateStatusWindow();
            }

            if (Settings.Default.alertFullscreenIdle)
            {
                CreateIdleWindow();
            }

            if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhook))
            {
                if (DiscordWebhook.SendFormattedMessage("SharpAlert has started."))
                {
                    lock (notify)
                    {
                        notify.BalloonTipIcon = ToolTipIcon.Info;
                        notify.BalloonTipTitle = $"SharpAlert says hello";
                        notify.BalloonTipText = "Sent a start message to the webhook.";
                        notify.ShowBalloonTip(5000);
                    }
                }
                else
                {
                    lock (notify)
                    {
                        notify.BalloonTipIcon = ToolTipIcon.Warning;
                        notify.BalloonTipTitle = $"SharpAlert says hello";
                        notify.BalloonTipText = "Couldn't send a message to the webhook.";
                        notify.ShowBalloonTip(5000);
                    }
                }
            }

            heartbeatThread = StartCatchAllThread(() => HeartbeatWorker.ServiceRun(), true);

            ServiceRunnerScheduled = true;

            new Thread(() =>
            {
                while (AllowThreadRestarts)
                {
                    var powerStatus = SystemInformation.PowerStatus;

                    if (powerStatus.BatteryLifePercent == -1)
                    {
                        return;
                    }

                    float batteryLevel = powerStatus.BatteryLifePercent * 100;
                    bool batteryCharging = powerStatus.PowerLineStatus == PowerLineStatus.Online;

                    if (!batteryCharging && (int)batteryLevel < 10)
                    {
                        DiscordWebhook.SendFormattedMessage($"The host is running critically low on battery power. ({(int)batteryLevel}%)\r\nPerformance may be impacted.", 16711680);
                    }
                    else
                    {
                        if (!batteryCharging && (int)batteryLevel < 20)
                        {
                            DiscordWebhook.SendFormattedMessage($"The host is running low on battery power. ({(int)batteryLevel}%)", 16776960);
                        }
                    }

                    Thread.Sleep(1000 * 60);
                }
            }).Start();
        }

        private static readonly object ThreadErrorLockObject = new object();

        private static bool NotifyIconCalled = false;
        private static readonly List<string> ChangedPropertiesList = new List<string>();
        public static bool IgnoreRightClick = false;

        /// <summary>
        /// Creates a tray icon. Throws NotSupportedException if called more than once.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        private static void CreateNotifyIcon(string RemoteVersion)
        {
            if (NotifyIconCalled) throw new NotSupportedException();
            NotifyIconCalled = true;

            notify = new NotifyIcon
            {
                Icon = Resources.TrayLightIcon,
                Visible = true,
                Text = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}"
            };

            ContextMenuStrip contextMenu = new ContextMenuStrip();

            contextMenu.Opening += (a, b) =>
            {
                qaf?.Hide();

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

            //IgnoreRightClick = true;
            //IgnoreRightClick = false;

            contextMenu.Items.Add(new ToolStripSeparator());

            string[] RemoteVersionSplit = RemoteVersion.Split('.');
            bool UpdatesAvailable = false;

            if (RemoteVersionSplit.Length == 2)
            {
                try
                {
                    if (int.Parse(RemoteVersionSplit[0]) > VersionInfo.MajorVersion ||
                        int.Parse(RemoteVersionSplit[1]) > VersionInfo.MinorVersion)
                    {
                        lock (notify)
                        {
                            notify.BalloonTipTitle = "SharpAlert is running";
                            notify.BalloonTipText = $"Update available! v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} -> v{RemoteVersionSplit[0]}.{RemoteVersionSplit[1]}";
                            //notify.BalloonTipText = $"You may be running an older version. v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} -> v{RemoteVersionSplit[0]}.{RemoteVersionSplit[1]}";
                            notify.BalloonTipIcon = ToolTipIcon.Info;
                            notify.ShowBalloonTip(5000);
                        }
                        UpdatesAvailable = true;
                    }
                    else
                    {
                        if (int.Parse(RemoteVersionSplit[0]) < VersionInfo.MajorVersion ||
                            int.Parse(RemoteVersionSplit[1]) < VersionInfo.MinorVersion)
                        {
                            lock (notify)
                            {
                                notify.BalloonTipTitle = "SharpAlert is running";
                                notify.BalloonTipText = $"Downgrade available! v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} -> v{RemoteVersionSplit[0]}.{RemoteVersionSplit[1]}";
                                notify.BalloonTipIcon = ToolTipIcon.Info;
                                notify.ShowBalloonTip(5000);
                            }
                        }
                        else
                        {
                            lock (notify)
                            {
                                notify.BalloonTipTitle = "SharpAlert is running";
                                notify.BalloonTipText = $"I'll just be waiting right over here in my tray icon. You're up to date.";
                                notify.BalloonTipIcon = ToolTipIcon.Info;
                                notify.ShowBalloonTip(5000);
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    lock (notify)
                    {
                        notify.BalloonTipTitle = "SharpAlert is running";
                        notify.BalloonTipText = "I'll just be waiting right over here in my tray icon. Couldn't check for updates.";
                        notify.BalloonTipIcon = ToolTipIcon.Info;
                        notify.ShowBalloonTip(5000);
                    }
                }
            }
            else
            {
                lock (notify)
                {
                    notify.BalloonTipTitle = "SharpAlert is running";
                    notify.BalloonTipText = "I'll just be waiting right over here in my tray icon. Couldn't check for updates.";
                    notify.BalloonTipIcon = ToolTipIcon.Info;
                    notify.ShowBalloonTip(5000);
                }
            }

            string home = "https://sharpalert.bunnytub.com";

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
                contextMenu.Items.Add(new ToolStripLabel($"Click above to update!")
                {
                    ToolTipText = "There's an update available for you to download."
                });
            }

            contextMenu.Items.Add(new ToolStripMenuItem("Open Settings", null, (sender, arg) =>
            {
                IgnoreRightClick = true;
                if (cf == null || cf.IsDisposed) cf = new ConfigurationForm();
                cf.ShowDialog();
                IgnoreRightClick = false;
            }));

            contextMenu.Items.Add(new ToolStripMenuItem("Save Settings", null, (sender, arg) =>
            {
                Settings.Default.Save();
                //string SettingsChangedList = string.Empty;

                //foreach (string SettingName in ChangedPropertiesList)
                //{
                //    SettingsChangedList += SettingName + "\r\n";
                //}

                //SettingsChangedList = SettingsChangedList.Trim();

                //if (!string.IsNullOrWhiteSpace(SettingsChangedList))
                //{
                //    if (MessageBox.Show("Do you want to save the current configuration?\r\n\r\n" +
                //        "The following settings were changed:\r\n" +
                //        SettingsChangedList,
                //        "SharpAlert",
                //        MessageBoxButtons.YesNo,
                //        MessageBoxIcon.Question) == DialogResult.Yes)
                //    {
                //        Settings.Default.Save();
                //    }
                //}
                //else
                //{
                //    MessageBox.Show("There are no pending changes to save.",
                //        "SharpAlert",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Information);
                //}
            }));

            contextMenu.Items.Add(new ToolStripMenuItem("Reset Settings", null, (sender, arg) =>
            {
                if (MessageBox.Show("Reset everything to factory defaults now?\r\n" +
                    "SharpAlert will close if you continue.",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Settings.Default.Reset();
                    Settings.Default.Save();
                    Environment.Exit(0);
                }
            }));

            contextMenu.Items.Add(new ToolStripSeparator());

#if DEBUG
            contextMenu.Items.Add(new ToolStripMenuItem("Trigger Intentional Exception", null, (sender, arg) =>
            {
                string[] StringOfStrings = { "0", "1" };
                string StringNumberTwo = StringOfStrings[2].Trim();
            }));
#endif   
            
            contextMenu.Items.Add(new ToolStripMenuItem("Quit", null, (sender, arg) =>
            {
                TryExit();
            }));

            notify.ContextMenuStrip = contextMenu;
            notify.MouseClick += (a, b) =>
            {
                switch (b.Button)
                {
                    case MouseButtons.Left:
                        if (IgnoreRightClick) return;
                        IgnoreRightClick = true;
                        if (qaf == null || qaf.IsDisposed) qaf = new QuickAccessForm();
                        qaf.Hide();
                        //var rect = GetIconRectangle(notify
                        //qaf.DesktopLocation = new Point(rect.X - (qaf.Width / 2), rect.Y - qaf.Height);
                        Screen screen = Screen.PrimaryScreen;
                        qaf.Location = new Point(screen.WorkingArea.Width - qaf.Width - 5, screen.WorkingArea.Height - qaf.Height - 5);
                        qaf.Show();
                        break;
                }

            };
        }

        private static ConfigurationForm cf = null;
        private static QuickAccessForm qaf = null;

        //[DllImport("user32.dll")]
        //private static extern IntPtr WindowFromPoint(Point Point);

        //private static Rectangle GetIconRectangle(NotifyIcon notifyIcon)
        //{
        //    var id = GetFieldValue<int>(notifyIcon, "id");
        //    var window = GetFieldValue<NativeWindow>(notifyIcon, "window");
        //    var identifier = new NOTIFYICONIDENTIFIER
        //    {
        //        cbSize = Marshal.SizeOf(typeof(NOTIFYICONIDENTIFIER)),
        //        hWnd = window.Handle,
        //        uID = id,
        //        guidItem = Guid.Empty
        //    };
        //    Shell_NotifyIconGetRect(ref identifier, out RECT rc);
        //    return Rectangle.FromLTRB(rc.Left, rc.Top, rc.Right, rc.Bottom);
        //}

        //private static TValue GetFieldValue<TValue>(object target, string fieldName)
        //{
        //    var fi = target.GetType().GetField(fieldName,
        //            BindingFlags.NonPublic | BindingFlags.Instance);
        //    return (TValue)fi.GetValue(target);
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //private struct RECT
        //{
        //    public int Left;
        //    public int Top;
        //    public int Right;
        //    public int Bottom;
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //private struct NOTIFYICONIDENTIFIER
        //{
        //    public int cbSize;
        //    public IntPtr hWnd;
        //    public int uID;
        //    public Guid guidItem;
        //}

        //[DllImport("shell32.dll")]
        //private static extern int Shell_NotifyIconGetRect(ref NOTIFYICONIDENTIFIER identifier, out RECT iconLocation);

        public static void UnsafeFault(Exception exception, bool terminate)
        {
            new Thread(() =>
            {
                lock (ThreadErrorLockObject)
                {
                    string ExceptionCompiled = LogFault(exception);

                    if (terminate)
                    {
                        AllowThreadRestarts = false;
                        try { feedThread?.Abort(); } catch (Exception) { }
                        try { atomfeedThread?.Abort(); } catch (Exception) { }
                        try { directfeedThread?.Abort(); } catch (Exception) { }
                        try { cacheThread?.Abort(); } catch (Exception) { }
                        try { dataProcThread?.Abort(); } catch (Exception) { }
                        try { historyProcThread?.Abort(); } catch (Exception) { }
                        try { notificationThread?.Abort(); } catch (Exception) { }
                        ToppleForm tf = new ToppleForm(ExceptionCompiled, false);
                        //new Thread(() => SafeExit(0)).Start();
                        //Thread.Sleep(5000);
                        Environment.Exit(0);
                        return;
                    }
                    else
                    {
                        if (notify != null)
                        {
                            lock (notify)
                            {
                                notify.BalloonTipTitle = "SharpAlert is having issues";
                                notify.BalloonTipText = "The problem has been logged. Check the event log for more information!";
                                notify.BalloonTipIcon = ToolTipIcon.Error;
                                notify.ShowBalloonTip(5000);
                            }
                        }
                    }
                }
            }).Start();
        }

        public static string LogFault(Exception ex)
        {
            string ExceptionCompiled = $"SharpAlert encountered an exception. {DateTime.UtcNow:s}\r\n" +
                    $"{ex.Message}\r\n" +
                    $"{ex.TargetSite}\r\n" +
                    $"{ex.StackTrace}";
            
            try
            {
                using (EventLog log = new EventLog("Application"))
                {
                    log.Source = "Application";
                    log.WriteEntry(ExceptionCompiled, EventLogEntryType.Error);
                }
            }
            catch (Exception)
            {
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhook))
                {
                    DiscordWebhook.SendUnformattedMessage(ExceptionCompiled + "\r\n\r\nPlease report this issue to my owner!\r\nIf you are the owner, contact <@603429346736341013> (https://bunnytub.com/SharpAlert.html | bunnytub@bunnytub.com) for help.");
                }
            }
            catch (Exception)
            {
            }

            ConsoleExt.WriteLine(ExceptionCompiled);

#if DEBUG
            Debugger.Break();
#endif

            return ExceptionCompiled;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool AllocConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FreeConsole();

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetStdHandle(int nStdHandle, IntPtr hHandle);

        //[DllImport("kernel32.dll", SetLastError = true)]
        //public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateFile(
            string lpFileName,
            uint dwDesiredAccess,
            uint dwShareMode,
            IntPtr lpSecurityAttributes,
            uint dwCreationDisposition,
            uint dwFlagsAndAttributes,
            IntPtr hTemplateFile);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        internal const int STD_OUTPUT_HANDLE = -11;
        internal const uint GENERIC_WRITE = 0x40000000;
        internal const uint OPEN_EXISTING = 3;
        internal const uint WM_CLOSE = 0x0010;
        internal const uint ENABLE_QUICK_EDIT = 0x0040;
        internal const uint ENABLE_EXTENDED_FLAGS = 0x0080;
        internal const uint ENABLE_VIRTUAL_TERMINAL_PROCESSING = 0x0004;
        internal const uint ENABLE_ECHO_INPUT = 0x0004;
        internal const uint ENABLE_LINE_INPUT = 0x0002;
        internal const int STD_INPUT_HANDLE = -10;

        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll")]
        internal static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);

        [DllImport("kernel32.dll")]
        internal static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        private delegate bool ConsoleCtrlDelegate(CtrlTypes ctrlType);

        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(ConsoleCtrlDelegate handler, bool add);

        private static ConsoleCtrlDelegate _handler;

        private enum CtrlTypes
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        public static void TryExit()
        {
            //if (AlertDisplaying)
            //{
            //    MessageBox.Show("There is an alert in progress.\r\n" +
            //        "Please let all alerts complete before quitting.",
            //        "SharpAlert",
            //        MessageBoxButtons.OK,
            //        MessageBoxIcon.Exclamation);
            //    return;
            //}

            Settings.Default.Save();
            SafeExit();
        }

        public static void AllocateTerminal(bool Popups = true)
        {
            bool allocateSuccess = AllocConsole();

            if (!allocateSuccess)
            {
                if (Popups)
                {
                    MessageBox.Show("The console could not be allocated. It may already be visible.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                Console.Title = "SharpAlert Console Window";
                IntPtr consoleHandle = CreateFile("CONOUT$", GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                
                if (consoleHandle == IntPtr.Zero)
                {
                    //throw new Win32Exception(Marshal.GetLastWin32Error());
                    return;
                }

                //if (!GetConsoleMode(GetStdHandle(STD_INPUT_HANDLE), out uint mode))
                //{
                //    ConsoleExt.WriteLine("[Ice Bear] Couldn't get console mode.");
                //    //var MarshalException = new Win32Exception(unchecked(Marshal.GetLastWin32Error()));
                //}

                //mode &= ~ENABLE_QUICK_EDIT; // Disable Quick Edit
                //mode |= ENABLE_VIRTUAL_TERMINAL_PROCESSING; // Enable ANSI
                //mode |= ENABLE_EXTENDED_FLAGS;

                //if (!SetConsoleMode(consoleHandle, mode))
                //{
                //    //var MarshalException = new Win32Exception(unchecked(Marshal.GetLastWin32Error()));
                //}

                SetStdHandle(STD_OUTPUT_HANDLE, consoleHandle);
                var writer = new StreamWriter(Console.OpenStandardOutput())
                {
                    AutoFlush = true,
                    //NewLine = " DEMO VERSION (SHARPALERT v9.0 --- TO REMOVE THIS MESSAGE, VISIT STORE.SHARPALERT.COM)"
                };
                Console.SetOut(writer);

                //const int STD_INPUT_HANDLE = -10;
                //IntPtr stdinHandle = GetStdHandle(STD_INPUT_HANDLE);

                //if (stdinHandle == IntPtr.Zero || stdinHandle == new IntPtr(-1))
                //{
                //    ConsoleExt.WriteLine("[Ice Bear] Failed to get stdin handle.");
                //}
                //else
                //{
                //    ConsoleExt.WriteLine("[Ice Bear] Got stdin handle.");
                //}

                //if (!GetConsoleMode(stdinHandle, out uint stdInMode))
                //{
                //    Console.WriteLine("[Ice Bear] Failed to get console mode.");
                //    return;
                //}

                //// Disable echo and line input
                //stdInMode &= ~ENABLE_ECHO_INPUT;
                //stdInMode &= ~ENABLE_LINE_INPUT;

                //if (!SetConsoleMode(stdinHandle, stdInMode))
                //{
                //    Console.WriteLine("[Ice Bear] Failed to set console mode.");
                //}

                object LockObject = new object();

                //Console.CancelKeyPress += (a, b) => SafeExit(0);
                _handler += new ConsoleCtrlDelegate(_ => {
                    lock (LockObject)
                    {
                        Settings.Default.Save();
                        SafeExit();
                        return true;
                    }
                });
                SetConsoleCtrlHandler(_handler, true);

                //new Thread(() =>
                //{
                //    var colors = (ConsoleColor[])Enum.GetValues(typeof(ConsoleColor));
                //    var rand = new Random();

                //    while (true)
                //    {
                //        Console.BackgroundColor = colors[rand.Next(colors.Length)];
                //        Console.ForegroundColor = colors[rand.Next(colors.Length)];
                //        Thread.Sleep(50);
                //    }
                //}).Start();

                new Thread(() => ConsoleExt.ServiceRun()).Start();

                Console.Beep(1000, 200);
            }
        }

        // broken
        public static void DestroyTerminal()
        {
            if (!FreeConsole())
            {
                MessageBox.Show("The console could not be unallocated. It may already be freed.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                IntPtr consoleWindowHandle = GetConsoleWindow();
                if (consoleWindowHandle != IntPtr.Zero)
                {
                    PostMessage(consoleWindowHandle, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                }

                var defaultOutput = new StreamWriter(Console.OpenStandardOutput())
                {
                    AutoFlush = true
                };
                Console.SetOut(defaultOutput);
            }
        }

        /// <summary>
        /// Calls the file manager and requests for a file to be added to the queue.
        /// ("The CLR has been unable to transition" is just a debugger warning, not a fault!)
        /// </summary>
        public static void AddFileToQueue()
        {
            Thread staThread = new Thread(() =>
            {
                try
                {
                    ConsoleExt.WriteLine("[Ice Bear] Opening the file picker.");

                    string selectedSafePath = string.Empty;

                    OpenFileDialog fbd = new OpenFileDialog
                    {
                        Filter = "Common Alerting Protocol files (*.xml, *.cap)|*.xml;*.cap",
                        FilterIndex = 0,
                        CheckFileExists = true,
                        Multiselect = true,
                        Title = "SharpAlert - Alert Importing"
                    };

                    if (fbd.ShowDialog() != DialogResult.OK)
                    {
                        ConsoleExt.WriteLine("[Ice Bear] No file chosen from the file picker.");
                        return;
                    }

                    ConsoleExt.WriteLine("[Ice Bear] Processing chosen file(s).");

                    foreach (string selectedPath in fbd.FileNames)
                    {
                        try
                        {
                            string data = File.ReadAllText(selectedPath);
                            EnrollAlerts(data, true);
                        }
                        catch (Exception ex)
                        {
                            ConsoleExt.WriteLine(ex.Message);
                        }
                    }

                    fbd.Dispose();
                }
                catch (Exception e)
                {
                    MessageBox.Show($"{e.StackTrace} {e.Message}",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
        }

        private static readonly object EnrollObject = new object();

        private static void EnrollAlerts(string data, bool reset = false)
        {
            lock (EnrollObject)
            {
                MatchCollection alertMatches = AlertRegex.Matches(data);
                int alertIndex = 0;

                if (alertMatches != null || alertMatches.Count != 0)
                {
                    foreach (Match alert in alertMatches)
                    {
                        try
                        {
                            alertIndex++;
                            if (alert.Value is null) continue;

                            string filename = IdentifierRegex.MatchOrDefault(alert.Value, CreateMD5(alert.Value));

                            //if (string.IsNullOrWhiteSpace(filename))
                            //{
                            //    ConsoleExt.WriteLine("[HTTP Feed Capture] Identifier not found. An MD5 value will be assigned to this alert instead.");
                            //    filename = CreateMD5(alert.Value);
                            //}

                            ConsoleExt.WriteLine($"[File Capture] {alertIndex} -> {filename}");

                            //string StartingSharpAlertReplay = "<SharpAlertReplay>";
                            //string EndingSharpAlertReplay = "<SharpAlertReplay>";
                            //if (!alert.Value.Contains($"{StartingSharpAlertReplay}") || !alert.Value.Contains($"{EndingSharpAlertReplay}"))
                            //{
                            //    string alertReplayValue = alert.Value + "<SharpAlertReplay>false</SharpAlertReplay>";
                            //}

                            SharpDataItem item = new SharpDataItem(filename, alert.Value);

                            if (reset)
                            {
                                TryRemoveDataFromHistory(item);
                            }

                            if (TryAddDataToQueue(item))
                            {
                                ConsoleExt.WriteLine($"[File Capture] Alert {alertIndex} ({filename}) has been saved for processing.");
                            }
                            else
                            {
                                ConsoleExt.WriteLine($"[File Capture] Alert {alertIndex} ({filename}) has been discarded (already queued or is in history).");
                            }
                        }
                        catch (Exception ex)
                        {
                            ConsoleExt.WriteLine($"[File Capture] Couldn't check the data for alert {alertIndex}. {ex.Message}");
                        }
                    }
                    if (alertIndex != 0) ConsoleExt.WriteLine($"[File Capture] {alertIndex} alert(s) checked.");
                    else ConsoleExt.WriteLine($"[File Capture] No alerts were checked.");
                }
                else
                {
                    ConsoleExt.WriteLine("[File Capture] There are no alerts to enroll.");
                }
            }
        }

        public static bool TryAddDataToQueue(SharpDataItem item)
        {
            lock (SharpDataQueue)
            {
                lock (SharpDataHistory)
                {
                    try
                    {
                        if (SharpDataQueue.Any(x => x.Name == item.Name) || SharpDataHistory.Any(x => x.Name == item.Name))
                        {
                            return false;
                        }
                        else
                        {
                            SharpDataQueue.Add(item);
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        ConsoleExt.WriteLine($"[File Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }

        public static bool TryAddDataToHistory(SharpDataItem item)
        {
            lock (SharpDataQueue)
            {
                lock (SharpDataHistory)
                {
                    try
                    {
                        if (SharpDataQueue.Any(x => x.Name == item.Name) || SharpDataHistory.Any(x => x.Name == item.Name))
                        {
                            return false;
                        }
                        else
                        {
                            SharpDataHistory.Add(item);
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        ConsoleExt.WriteLine($"[File Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }

        public static bool TryRemoveDataFromHistory(SharpDataItem item)
        {
            lock (SharpDataQueue)
            {
                lock (SharpDataHistory)
                {
                    try
                    {
                        if (SharpDataHistory.Any(x => x.Name == item.Name))
                        {
                            return SharpDataHistory.Remove(item);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        ConsoleExt.WriteLine($"[File Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
