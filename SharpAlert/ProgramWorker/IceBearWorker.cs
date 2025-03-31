using Microsoft.Win32;
using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.ServiceThreads;

namespace SharpAlert
{
    public static class IceBearWorker
    {
        public static readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        public static bool ServiceRunnerScheduled { get; private set; }

        public static readonly string SelfUserAgent = "Mozilla/5.0 (compatible; SharpAlert)";

        /// <summary>
        /// Starts the Ice Bear Worker as a client.
        /// </summary>
        [MTAThread]
        public static void ServiceRun()
        {
            args = Environment.GetCommandLineArgs();

            if (args.Length == 2) if (args[1] == "--console") AllocateTerminal(false);
            //if (args.Length == 2) if (args[1] == "--finish-update") AllocateTerminal(false);

            Console.WriteLine($"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} | Safety is never a non-priority. | https://sharpalert.bunnytub.com/");

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

            if (!Settings.Default.DisclaimerShown)
            {
                MessageBox.Show("Just a reminder...\r\n" +
                    "SharpAlert is still in development! Expect bugs here and there.\r\n" +
                    "If you find any, please report them, so they can be fixed.\r\n\r\n" +
                    "Thanks for using SharpAlert!",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                Settings.Default.DisclaimerShown = true;
                Settings.Default.Save();
            }

            Thread startup = new Thread(() =>
            {
                StartupForm sf = new StartupForm();
                sf.ShowDialog();
                sf.Dispose();
            });

            startup.Start();

            string RemoteVersion = string.Empty;

            Console.WriteLine("[Ice Bear] Checking application version.");

            string IdentityURL = "https://bunnytub.com";

            try
            {
                HttpResponseMessage latest = client.GetAsync($"{IdentityURL}/SharpAlert/SharpAlert.txt").Result;

                Console.WriteLine($"[Ice Bear | Version Request] The server responded with status code {latest.StatusCode}.");

                RemoteVersion = latest.Content.ReadAsStringAsync().Result.Trim();
                if (string.IsNullOrWhiteSpace(RemoteVersion) || RemoteVersion.Length == 0 || RemoteVersion.Length >= 10) RemoteVersion = "0.0";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Ice Bear] {ex.StackTrace} {ex.Message}");
                Console.WriteLine($"[Ice Bear] Couldn't work with the server.");
            }

            Console.WriteLine("[Ice Bear] Initializing services.");

            feed = new FeedCapture();
            cache = new CacheCapture();
            dataproc = new DataProcessor();
            historyproc = new HistoryProcessor();
            engine = new SpeechSynthesizer();

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

            Console.WriteLine("[Ice Bear] Getting runner configuration.");

            bool UseHTTPS = true;

            switch (Settings.Default.RunnerType)
            {
                default:
                    Console.WriteLine("[Ice Bear] Runner type is Standard.");
                    feed.server = $"apps.fema.gov/IPAWSOPEN_EAS_SERVICE/rest/eas/recent/{DateTime.UtcNow.AddDays(-30):yyyy-MM-ddTHH:mm:ssZ}";
                    break;
                case 1:
                    Console.WriteLine("[Ice Bear] Runner type is Server.");
                    ServerServiceRun();
                    return;
                case 2:
                    Console.WriteLine("[Ice Bear] Runner type is Client.");
                    UseHTTPS = false;
                    feed.server = $"{Settings.Default.ClientServerURL}:{Settings.Default.ClientServerPort}/{DateTime.UtcNow.AddDays(-30):yyyy-MM-ddTHH:mm:ssZ}";
                    break;
            }

            notificationThread = ReturnThreadWithCatch(() =>
            {
                Application.EnableVisualStyles();
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
                                    DiscordWebhook.SendFormattedMessage($"The host is charging. ({(int)batteryLevel}%)", Settings.Default.DiscordWebhook, 60928);
                                }
                                else
                                {
                                    DiscordWebhook.SendFormattedMessage($"The host is discharging. ({(int)batteryLevel}%)", Settings.Default.DiscordWebhook, 39423);
                                }
                                break;
                        }
                    }
                };

                SystemEvents.SessionEnding += (a, b) =>
                {
                    if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhook))
                    {
                        switch (b.Reason)
                        {
                            case SessionEndReasons.SystemShutdown:
                                DiscordWebhook.SendFormattedMessage("The host is shutting down.", Settings.Default.DiscordWebhook);
                                break;
                            case SessionEndReasons.Logoff:
                                DiscordWebhook.SendFormattedMessage("The host is logging off.", Settings.Default.DiscordWebhook);
                                break;
                        }
                    }
                    SafeExit(0);
                };

                try
                {
                    CreateNotifyIcon(RemoteVersion);
                    Application.Run();
                }
                catch (Exception ex)
                {
                    UnsafeFault(ex, true);
                }
            }, false);
            //notificationThread.MonitorAndStart("Notification Tray");
            notificationThread.Start();

            while (notify == null) Thread.Sleep(100);

            Console.WriteLine("[Ice Bear] Starting services momentarily.");

            feedThread = ReturnThreadWithCatch(() => feed.ServiceRun(UseHTTPS), true);
            feedThread.SetApartmentState(ApartmentState.MTA);
            //feedThread.MonitorAndStart("Feed Capture");
            feedThread.Start();

            cacheThread = ReturnThreadWithCatch(() => cache.ServiceRun(true), true);
            cacheThread.SetApartmentState(ApartmentState.MTA);
            //cacheThread.MonitorAndStart("Cache Capture");
            cacheThread.Start();

            dataProcThread = ReturnThreadWithCatch(() => dataproc.ServiceRun(), true);
            dataProcThread.SetApartmentState(ApartmentState.MTA);
            //dataProcThread.MonitorAndStart("Data Processor");
            dataProcThread.Start();

            historyProcThread = ReturnThreadWithCatch(() => historyproc.ServiceRun(), true);
            historyProcThread.SetApartmentState(ApartmentState.MTA);
            //historyProcThread.MonitorAndStart("History Processor");
            historyProcThread.Start();

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
                if (DiscordWebhook.SendFormattedMessage("SharpAlert has started.", Settings.Default.DiscordWebhook))
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
                        DiscordWebhook.SendFormattedMessage($"The host is running critically low on battery power. ({(int)batteryLevel}%)\r\nPerformance may be impacted.", Settings.Default.DiscordWebhook, 16711680);
                    }
                    else
                    {
                        if (!batteryCharging && (int)batteryLevel < 20)
                        {
                            DiscordWebhook.SendFormattedMessage($"The host is running low on battery power. ({(int)batteryLevel}%)\r\nPerformance may be impacted.", Settings.Default.DiscordWebhook, 16776960);
                        }
                    }

                    Thread.Sleep(1000 * 60);
                }
            }).Start();
        }

        /// <summary>
        /// Starts the Ice Bear Worker as a server instead of a client.
        /// </summary>
        private static void ServerServiceRun()
        {
            AllocateTerminal(false);

            Thread.Sleep(1000);

            if (Control.ModifierKeys == Keys.Shift)
            {
                Console.WriteLine("[Ice Bear] Reverting runner configuration.");
                Settings.Default.RunnerType = 0;
                Settings.Default.Save();
                Console.WriteLine("[Ice Bear] The runner configuration has been reset.");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }

            Console.WriteLine("[Ice Bear] To stop operating in server mode, hold SHIFT when the program starts.");
            Console.WriteLine("[Ice Bear] Initializing internet services. (this may fail if you're not running this with admin privileges)");

            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://*:9792/");

            Console.WriteLine("[Ice Bear] Starting services momentarily.");

            Thread feedThread = ReturnThreadWithCatch(() => feed.ServerServiceRun(true), true);
            feedThread.SetApartmentState(ApartmentState.MTA);
            //feedThread.MonitorAndStart("Feed Capture");
            feedThread.Start();

            listener.Start();
            CreateStatusWindow();

            ServiceRunnerScheduled = true;

            Console.WriteLine("[Ice Bear] Listening for requests. (on port 9792)");

            while (true)
            {
                Console.WriteLine("[Ice Bear] Waiting for the next request.");
                HttpListenerContext context = listener.GetContext();

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    var request = context.Request;
                    Console.WriteLine($"[Ice Bear] Sending data ({request.UserAgent} | {request.RemoteEndPoint.Address}).");

                    if (request.HttpMethod.ToUpperInvariant() == "GET")
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                        context.Response.ContentType = "application/xml";
                        byte[] feed = Encoding.UTF8.GetBytes(FeedCapture.Result);
                        context.Response.OutputStream.Write(feed, 0, feed.Length);
                        context.Response.OutputStream.Close();
                        Console.WriteLine($"[Ice Bear] Sent the data successfully.");
                    }
                    else
                    {
                        Console.WriteLine($"[Ice Bear] Client did not send the request via GET.");
                        context.Response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                        context.Response.OutputStream.Close();
                    }
                });
            }
        }

        //private static void MonitorAndStart(this Thread thread, string FriendlyName)
        //{
        //    Thread sub = new Thread(() =>
        //    {
        //        while (AllowThreadRestarts)
        //        {
        //            thread.Start();
        //            Console.WriteLine($"[Ice Bear] {FriendlyName} started.");
        //            while (thread.IsAlive) Thread.Sleep(500);
        //            Console.WriteLine($"[Ice Bear] {FriendlyName} exited.");
        //            Thread.Sleep(300);
        //        }
        //        Console.WriteLine($"[Ice Bear] Thread handling for {FriendlyName} has stopped.");
        //    });
        //    sub.Start();
        //}

        private static readonly object ThreadErrorLockObject = new object();

        /// <summary>
        /// Acts as a layer for creating a Thread. The original intended code is run, but any exceptions are caught if they occur.
        /// </summary>
        /// <param name="action"></param>
        /// <returns>Try-catch Thread</returns>
        private static Thread ReturnThreadWithCatch(Action action, bool restartable)
        {
            Console.WriteLine($"[Ice Bear] Returning thread. (action = {action.Method.Name}, restartable = {restartable})");
            return new Thread(() =>
            {
                while (AllowThreadRestarts)
                {
                    try
                    {
                        action.Invoke();
                    }
                    catch (ThreadAbortException)
                    {
                        return;
                    }
                    catch (Exception ex)
                    {
                        UnsafeFault(ex, !restartable);
                    }
                }
            });
        }

        private static bool NotifyIconCalled = false;
        private static readonly List<string> ChangedPropertiesList = new List<string>();
        private static bool IgnoreRightClick = false;

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
                Icon = icon,
                Visible = true,
                Text = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}"
            };

            ContextMenuStrip contextMenu = new ContextMenuStrip();

            contextMenu.Opening += (a, b) =>
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    string ForceQuitMsg = "Click YES to immediately shutdown SharpAlert.\r\n" +
                        "You should only use this feature as a last resort.";

                    if (ChangedPropertiesList.Count != 0)
                    {
                        ForceQuitMsg += "\r\n\r\n" +
                        "You have unsaved changes that will be lost if you continue.";
                    }

                    if (MessageBox.Show(ForceQuitMsg,
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Environment.FailFast("An emergency shutdown was triggered manually.");
                    }

                    b.Cancel = true;
                    return;
                }

                if (Control.ModifierKeys == Keys.ShiftKey)
                {
                    IgnoreRightClick = false;
                }

                if (IgnoreRightClick)
                {
                    b.Cancel = true;
                    MessageBox.Show("Please close all windows before opening the menu.",
                        "SharpAlert",
                        MessageBoxButtons.OK);
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

            //contextMenu.Items.Add(new ToolStripMenuItem("Hide Console", null, (sender, arg) =>
            //{
            //    MessageBox.Show("Not Implemented", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    //DestroyTerminal();
            //}));

            contextMenu.Items.Add(new ToolStripSeparator());

            contextMenu.Items.Add(new ToolStripMenuItem("Import CAP Data", null, (sender, arg) =>
            {
                IgnoreRightClick = true;
                AddFileToQueue();
                IgnoreRightClick = false;
            }));
            
            contextMenu.Items.Add(new ToolStripMenuItem("Relay Local Test", null, (sender, arg) =>
            {
                IgnoreRightClick = true;
                dataproc?.ap?.ProcessAlertTest();
                IgnoreRightClick = false;
            }));

            contextMenu.Items.Add(new ToolStripSeparator());

            string[] RemoteVersionSplit = RemoteVersion.Split('.');
            bool UpdatesAvailable = false;

            if (RemoteVersionSplit.Length == 2)
            {
                if (RemoteVersionSplit[0] != VersionInfo.MajorVersion.ToString() ||
                    RemoteVersionSplit[1] != VersionInfo.MinorVersion.ToString())
                {
                    lock (notify)
                    {
                        notify.BalloonTipTitle = "SharpAlert is running";
                        notify.BalloonTipText = $"Updates are available! v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} -> v{RemoteVersionSplit[0]}.{RemoteVersionSplit[1]}";
                        //notify.BalloonTipText = $"You may be running an older version. v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} -> v{RemoteVersionSplit[0]}.{RemoteVersionSplit[1]}";
                        notify.BalloonTipIcon = ToolTipIcon.Info;
                        notify.ShowBalloonTip(5000);
                    }
                    UpdatesAvailable = true;
                }
                else
                {
                    lock (notify)
                    {
                        notify.BalloonTipTitle = "SharpAlert is running";
                        notify.BalloonTipText = "I'll just be waiting right over here in my tray icon. You're up to date.";
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
                ConfigurationForm cf = new ConfigurationForm();
                cf.ShowDialog();
                cf.Dispose();
                IgnoreRightClick = false;
            }));

            contextMenu.Items.Add(new ToolStripMenuItem("Save Settings", null, (sender, arg) =>
            {
                string SettingsChangedList = string.Empty;

                foreach (string SettingName in ChangedPropertiesList)
                {
                    SettingsChangedList += SettingName + "\r\n";
                }

                SettingsChangedList = SettingsChangedList.Trim();

                if (!string.IsNullOrWhiteSpace(SettingsChangedList))
                {
                    if (MessageBox.Show("Do you want to save the current configuration?\r\n\r\n" +
                        "The following settings were changed:\r\n" +
                        SettingsChangedList,
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Settings.Default.Save();
                    }
                }
                else
                {
                    MessageBox.Show("There are no pending changes to save.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }));

            contextMenu.Items.Add(new ToolStripMenuItem("Reset Settings", null, (sender, arg) =>
            {
                if (MessageBox.Show("Are you sure you want to reset all settings?\r\n" +
                    "SharpAlert will close if you continue.",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Settings.Default.Reset();
                    Settings.Default.Save();
                    SafeExit(0);
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
        }

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
                        try { cacheThread?.Abort(); } catch (Exception) { }
                        try { dataProcThread?.Abort(); } catch (Exception) { }
                        try { historyProcThread?.Abort(); } catch (Exception) { }
                        try { notificationThread?.Abort(); } catch (Exception) { }
                        ToppleForm tf = new ToppleForm(ExceptionCompiled);
                        tf.ShowDialog();
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

            using (EventLog log = new EventLog("Application"))
            {
                log.Source = "Application";
                log.WriteEntry(ExceptionCompiled, EventLogEntryType.Error);
            }

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

        public const int STD_OUTPUT_HANDLE = -11;
        public const uint GENERIC_WRITE = 0x40000000;
        public const uint OPEN_EXISTING = 3;
        public const uint WM_CLOSE = 0x0010;
        internal const uint ENABLE_QUICK_EDIT = 0x0040;
        internal const uint ENABLE_EXTENDED_FLAGS = 0x0080;
        public const int STD_INPUT_HANDLE = -10;

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
            if (AlertDisplaying)
            {
                MessageBox.Show("There is an alert in progress.\r\n" +
                    "Please let all alerts complete before quitting.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            switch (MessageBox.Show("Do you want to quit and save your settings?\r\n" +
                "You won't receive any alerts while the program is stopped.",
                "SharpAlert",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question))
            {
                case DialogResult.Yes:
                    Settings.Default.Save();
                    SafeExit(0);
                    break;
                case DialogResult.No:
                    SafeExit(0);
                    break;
                case DialogResult.Cancel:
                    return;
            }
        }

        public static void AllocateTerminal(bool Popups = true)
        {
            bool allocateSuccess = AllocConsole();

            if (!allocateSuccess)
            {
                if (Popups)
                    MessageBox.Show("The console could not be allocated. It may already be visible.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            else
            {
                Console.Title = "SharpAlert Console Window";
                IntPtr consoleHandle = CreateFile("CONOUT$", GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                if (consoleHandle == IntPtr.Zero)
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error());
                }

                if (!GetConsoleMode(GetStdHandle(STD_INPUT_HANDLE), out uint mode))
                {
                    //var MarshalException = new Win32Exception(unchecked(Marshal.GetLastWin32Error()));
                }

                mode &= ~ENABLE_QUICK_EDIT;
                mode |= ENABLE_EXTENDED_FLAGS;

                if (!SetConsoleMode(consoleHandle, mode))
                {
                    //var MarshalException = new Win32Exception(unchecked(Marshal.GetLastWin32Error()));
                }

                SetStdHandle(STD_OUTPUT_HANDLE, consoleHandle);
                var writer = new StreamWriter(Console.OpenStandardOutput())
                {
                    AutoFlush = true
                };
                Console.SetOut(writer);

                object LockObject = new object();

                //Console.CancelKeyPress += (a, b) => SafeExit(0);
                _handler += new ConsoleCtrlDelegate(_ => {
                    lock (LockObject)
                    {
                        SafeExit(0);
                        return true;
                    }
                });
                SetConsoleCtrlHandler(_handler, true);
                Console.Beep();
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
                    Console.WriteLine("Opening file picker.");

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
                        Console.WriteLine("No file chosen.");
                        return;
                    }

                    foreach (string selectedPath in fbd.FileNames)
                    {
                        try
                        {
                            string data = File.ReadAllText(selectedPath);
                            feed.EnrollAlerts(data);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
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
    }
}
