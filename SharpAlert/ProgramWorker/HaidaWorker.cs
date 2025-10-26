using DiscordRPC;
using Microsoft.Win32;
using SharpAlert.AlertComponents;
using SharpAlert.ConfigurationDialogs;
using SharpAlert.DataProcessing;
using SharpAlert.DisplayDialogs;
using SharpAlert.Properties;
using SharpAlert.SourceCapturing;
using SharpAlert.SourceCapturing.SystemSpecific;
using SharpAlert.WebServer;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.AudioManager;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.ProgramWorker.NotificationWorker;
using static SharpAlert.ProgramWorker.ServiceThreads;
using static SharpAlert.RegexList;
using static SharpAlert.ThreadDrool;
using OpenFileDialog = System.Windows.Forms.OpenFileDialog;

namespace SharpAlert.ProgramWorker
{
    public static class HaidaWorker
    {
        public static readonly HttpClient client = new()
        {
            Timeout = TimeSpan.FromMinutes(1)
        };

        public static readonly string SelfUserAgent = $"Mozilla/5.0 (compatible; SharpAlert/" +
            $"{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}; bunnytub@bunnytub.com)";

        public static bool ServiceRunnerScheduled { get; private set; } = false;

        /// <summary>
        /// Starts the Haida Worker as a client.
        /// </summary>
        [MTAThread]
        public static void ServiceRun()
        {
            if (QuickSettings.Instance.alertNoGUI) AllocateTerminal(false);

            Console.WriteLine($"{VersionInfo.LongFriendlyVersion}\r\n" +
                $"https://bunnytub.com/SharpAlert");
            if (ServiceMode) Console.WriteLine($"Running under Service Mode.");

            // force instance reload here
            QuickSettings.Instance.DisableAlertProcessing = false;
            QuickSettings.Instance.PauseDataProcessing = false;
            QuickSettings.Instance.BypassAllFilters = false;

            client.DefaultRequestHeaders.UserAgent.ParseAdd(SelfUserAgent);

            try
            {
                icon = Icon.ExtractAssociatedIcon(AssemblyFile);
            }
            catch (Exception)
            {
                icon = SystemIcons.Application;
            }

            //double Scaling = GetWindowsScreenScalingFactor();

            // this code is so ass, but I don't want to deal with scaling right now

            //if (Scaling > 100)
            //{
            //    try
            //    {
            //        string SubKey = @"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers";

            //        RegistryKey key = Registry.CurrentUser.CreateSubKey(SubKey) ?? throw new Exception("Cannot create compatibility key.");
            //        object value = key.GetValue(AssemblyFile);
            //        bool valid = false;

            //        //string DPIScalingUnderCompatibilityOptions = "~ GDIDPISCALING DPIUNAWARE";
            //        string DPIScalingUnderCompatibilityOptions = "~ DPIUNAWARE";

            //        if (value != null)
            //        {
            //            string valueString = (string)value;
            //            if (valueString == DPIScalingUnderCompatibilityOptions)
            //            {
            //                valid = true;
            //            }
            //            else
            //            {
            //                if (Scaling > 100)
            //                {
            //                    Console.WriteLine($"[Haida] The system DPI is larger than 100%.");
            //                    MessageBox.Show($"Your display scaling of {Math.Floor(Scaling)}% may cause panels to display incorrectly. SharpAlert will attempt to correct this behavior, and then automatically restart.",
            //                        "SharpAlert - DPI Scaling Warning",
            //                        MessageBoxButtons.OK,
            //                        MessageBoxIcon.Warning);
            //                }
            //                else
            //                {
            //                    Console.WriteLine($"[Haida] The compatibility settings have been modified, which may cause problems.");
            //                    MessageBox.Show($"There are currently unsupported compatibility settings enabled for this program. SharpAlert will attempt to correct your settings, and then automatically restart.",
            //                        "SharpAlert - Compatibility Settings Warning",
            //                        MessageBoxButtons.OK,
            //                        MessageBoxIcon.Warning);
            //                }
            //            }
            //        }

            //        if (!valid)
            //        {
            //            key.SetValue(AssemblyFile, DPIScalingUnderCompatibilityOptions, RegistryValueKind.String);
            //            key.Close();
            //            key.Dispose();

            //            Console.WriteLine($"[Haida] Adjusted the program compatibility settings.");
            //            Environment.Exit(100);
            //            return;
            //        }
            //        else
            //        {
            //            //Console.WriteLine($"[Haida] The scaling issues have previously been already corrected.");
            //        }

            //        key.Close();
            //        key.Dispose();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine($"[Haida] Cannot adjust program DPI settings. {ex.Message}");
            //    }
            //}

            string RemoteVersion = UpdateWorker.TryGetRemoteVersion();

            if (!ServiceMode)
            {
                if (VersionInfo.IsBetaVersion)
                {
                    // oh my god I can integrate if statements into things like this
                    // that's kinda cool
                    TimedForm tf = new(DateTime.UtcNow >= VersionInfo.BetaTimeEnd);
                    tf.ShowDialog();
                    tf.Dispose();
                }
            }
            else
            {
                RemoteVersion = "service";
            }

            Console.WriteLine("[Haida] Initializing services.");
            // use threads you moron
            // I AM YOU BICH

            Console.WriteLine("[Haida] Initializing Feed Capture.");
            feed = new FeedCapture(); // FEED

            Console.WriteLine("[Haida] Initializing Atom Feed Capture.");
            atomfeed = new WeatherAtomCapture(); // FEED

            Console.WriteLine("[Haida] Initializing Direct Feed Capture.");
            directfeed = new DirectFeedCapture(); // FEED

            Console.WriteLine("[Haida] Initializing IDAP Capture.");
            idapfeed = new IDAPFeedCapture(); // FEED

            Console.WriteLine("[Haida] Initializing Cache Capture.");
            cache = new CacheCapture(); // TECHNICALLY FEED

            Console.WriteLine("[Haida] Initializing Data Processor.");
            dataproc = new DataProcessor();

            Console.WriteLine("[Haida] Initializing History Processor.");
            historyproc = new HistoryProcessor();

            Console.WriteLine("[Haida] Initializing Hyper Server.");
            hyper = new HyperServer();
                
            Console.WriteLine("[Haida] Starting services momentarily.");

            bool AnyFeedAvailable = false;
            bool SetupExperienceOccurred = false;

            if (!QuickSettings.Instance.SetupExperienceComplete)
            {
                Console.WriteLine("[Haida] Starting program setup experience.");

                SetupForm sf = new();
                sf.ShowDialog();
                sf.Dispose();

                if (!QuickSettings.Instance.SetupExperienceComplete)
                {
                    ChooseRegionForm crf = new(true);
                    crf.ShowDialog();
                    crf.Dispose();

                    ChooseLocationForm clf = new(true);
                    clf.ShowDialog();
                    clf.Dispose();

                    ChoosePresetForm cpf = new();
                    cpf.ShowDialog();
                    cpf.Dispose();

                    StyleConfigurationForm csf = new(true);
                    csf.ShowDialog();
                    csf.Dispose();

                    ChooseAudioForm caf = new(true);
                    caf.ShowDialog();
                    caf.Dispose();

                    ChooseOwnershipForm cof = new(true);
                    cof.ShowDialog();
                    cof.Dispose();

                    SetupDoneForm sdf = new();
                    sdf.ShowDialog();
                    sdf.Dispose();

                    QuickSettings.Instance.SetupExperienceComplete = true;
                }

                QuickSettings.Instance.Save();

                SetupExperienceOccurred = true;
            }

            //Thread.Sleep(10000);

            notificationThread = StartCatchAllThread("Notifications", () =>
            {
                SystemEvents.PowerModeChanged += (a, b) =>
                {
                    if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                    {
                        switch (b.Mode)
                        {
                            //case PowerModes.Resume:
                            //    DiscordWebhook.SendFormattedMessage("The host is resuming from sleep.", QuickSettings.Instance.DiscordWebhook);
                            //    break;
                            //case PowerModes.Suspend:
                            //    DiscordWebhook.SendFormattedMessage("The host is entering into sleep.", QuickSettings.Instance.DiscordWebhook);
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

                // detect network outage at some point and notify the user

                //SystemEvents.SessionEnding += (a, b) =>
                //{
                //    if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
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

                void CreateIcon()
                {
                    CreateNotifyIcon(RemoteVersion);
                }

                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += (a, b) =>
                {
                    MessageBox.Show($"An error has occurred. If the problem is related to settings, you should reset them and start over. {b.Exception.GetBaseException().Message}", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CreateIcon();
                };

                CreateIcon();

                Application.Run();
            }, false);

            while (NotifyIconIsNull()) Thread.Sleep(100);

            // migrate users upwards from the minimum limit
            if (QuickSettings.Instance.storedMaxSize < 100) QuickSettings.Instance.storedMaxSize = 500;

            bool AnyCustomServers()
            {
                try
                {
                    if (File.Exists($"{AssemblyDirectory}\\{CustomURLsFileName}"))
                    {
                        string[] ServerList = File.ReadAllLines($"{AssemblyDirectory}\\{CustomURLsFileName}");
                        int LineNumber = 0;
                        bool FoundValidServer = false;

                        Console.WriteLine($"[Haida] Checking \"{CustomURLsFileName}\" for server candidates.");

                        foreach (string raw in ServerList)
                        {
                            string server = raw.Trim();

                            LineNumber++;
                            if (server.StartsWith('#'))
                            {
                                Console.WriteLine($"[Haida] Comment skipped on line {LineNumber}.");
                                continue;
                            }
                            else
                            {
                                if (server.StartsWith("http://") || server.StartsWith("https://"))
                                {
                                    server = server.Replace("http://", string.Empty).Replace("https://", string.Empty);
                                    Console.WriteLine($"[Haida] Adding server \"{server}\" on line {LineNumber}.");
                                    var VisualServer = new FeedCapture.ServerInfo { ServerName = $"{CustomURLsFileName} | Line {LineNumber}", ServerPath = $"{server}" };
                                    feed.servers.Add(VisualServer);
                                    FoundValidServer = true;
                                    continue;
                                }
                                else
                                {
                                    if (string.IsNullOrWhiteSpace(server))
                                    {
                                        Console.WriteLine($"[Haida] Whitespace skipped on line {LineNumber}.");
                                    }
                                    else
                                    {
                                        Console.WriteLine($"[Haida] Invalid server skipped on line {LineNumber}.");
                                    }
                                    continue;
                                }
                            }
                        }

                        return FoundValidServer;
                    }
                    else
                    {
                        Console.WriteLine($"[Haida] No custom server file found named \"{CustomURLsFileName}\".");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Haida] Couldn't get custom servers. {ex.Message}");
                }
                return false;
            }

            bool CustomServersAvailable = AnyCustomServers();

            if (CustomServersAvailable ||
                QuickSettings.Instance.RegionUnitedStates ||
                QuickSettings.Instance.RegionUnitedStatesNWS ||
                QuickSettings.Instance.RegionCanada ||
                QuickSettings.Instance.RegionMexico ||
                QuickSettings.Instance.RegionBrazil) AnyFeedAvailable = true;

            if (!AnyFeedAvailable && !SetupExperienceOccurred)
            {
                //lock (notify)
                //{
                //    notify.BalloonTipIcon = ToolTipIcon.Info;
                //    notify.BalloonTipTitle = $"No feeds enabled";
                //    notify.BalloonTipText = "There are currently no feeds enabled.";
                //    notify.ShowBalloonTip(5000);
                //}
                //Console.WriteLine("[Haida] Prompting user for region information.");
                //ChooseRegionForm crf = new ChooseRegionForm(false);
                //crf.ShowDialog();
            }

            StartAndForget(() =>
            {
                if (VersionInfo.IsBetaVersion) SpeakingManager.BetaVersionInUse();
                StartupForm sf = new(Resources.WarningApp_Splash);
                sf.ShowDialog();
                sf.Dispose();
                if (!QuickSettings.Instance.DisclaimerShown)
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
                    QuickSettings.Instance.DisclaimerShown = true;
                    QuickSettings.Instance.Save();
                }
            });

            cacheThread = StartCatchAllThread("Cache Capture", () => cache.ServiceRun(true), true);
            dataProcThread = StartCatchAllThread("Data Processor", () => dataproc.ServiceRun(), true);
            historyProcThread = StartCatchAllThread("History Processor", () => historyproc.ServiceRun(), true);
            serverThread = StartCatchAllThread("Hyper Server", () => hyper.ServiceRun(), true);

            RefreshAudioDevices();

            var IPAWSMain = new FeedCapture.ServerInfo { ServerName = "FEMA IPAWS (EAS)", ServerPath = $"apps.fema.gov/IPAWSOPEN_EAS_SERVICE/rest/eas/recent/{DateTime.UtcNow.AddDays(-30):yyyy-MM-ddTHH:mm:ssZ}" };
            var IPAWSWireless = new FeedCapture.ServerInfo { ServerName = "FEMA IPAWS (WEA)", ServerPath = $"apps.fema.gov/IPAWSOPEN_EAS_SERVICE/rest/PublicWEA/recent/{DateTime.UtcNow.AddDays(-30):yyyy-MM-ddTHH:mm:ssZ}" };

            bool IPAWSOrSASMEXAvailable = false;

            if (QuickSettings.Instance.RegionUnitedStates)
            {
                feed.servers.Add(IPAWSMain);
                feed.servers.Add(IPAWSWireless);
                IPAWSOrSASMEXAvailable = true;
            }

            var SASMEXMain = new FeedCapture.ServerInfo { ServerName = "SASMEX", ServerPath = $"sasmex.net/rss/sasmex.xml" };

            if (QuickSettings.Instance.RegionMexico)
            {
                feed.servers.Add(SASMEXMain);
                IPAWSOrSASMEXAvailable = true;
            }

            if (IPAWSOrSASMEXAvailable || CustomServersAvailable)
            {
                feedThread = StartCatchAllThread("Feed Capture", () => feed.ServiceRun(true), false);
            }

            var NWSAtom = new WeatherAtomCapture.ServerInfo { ServerName = "NWS Atom", ServerPath = $"api.weather.gov/alerts/active.atom" };

            if (QuickSettings.Instance.RegionUnitedStatesNWS)
            {
                atomfeed.servers.Add(NWSAtom);
                atomfeedThread = StartCatchAllThread("Atom Feed Capture", () => atomfeed.ServiceRun(true), false);
            }

            var NAADSPrimary = new DirectFeedCapture.TCPServerInfo { ServerName = "NAADS Primary", ServerAddress = "streaming1.naad-adna.pelmorex.com", ServerPort = 8080 };
            var NAADSBackup = new DirectFeedCapture.TCPServerInfo { ServerName = "NAADS Backup", ServerAddress = "streaming2.naad-adna.pelmorex.com", ServerPort = 8080 };

            if (QuickSettings.Instance.RegionCanada)
            {
                directfeed.servers.Add(NAADSPrimary);
                directfeed.servers.Add(NAADSBackup);
                directfeedThread = StartCatchAllThread("Direct Feed Capture", () => directfeed.ServiceRun(), false);
            }

            if (QuickSettings.Instance.RegionBrazil)
            {
                //Console.WriteLine("[Haida] Capturing from Brazil (IDAP) is unavailable.");
                StartAndForget(() =>
                {
                    new IDAPNoticeForm().ShowDialog();
                });
                idapfeedThread = StartCatchAllThread("IDAP Feed Capture", () => idapfeed.ServiceRun(true), false);
                // removed Brazil IDAP from being able to be used for now
            }

            // just assign statusWindow to the boolean... dumb fuck

            StatusWindowVisible = QuickSettings.Instance.statusWindow;
            IdleWindowVisible = QuickSettings.Instance.alertFullscreenIdle;

            heartbeatThread = StartCatchAllThread("Heartbeat Worker", () => HeartbeatWorker.ServiceRun(), true);
            DiscordWebhook.SendFormattedMessage("SharpAlert has started.");
            
            ServiceRunnerScheduled = true;

            StartCatchAllThread("Battery Manager", () =>
            {
                while (AllowThreadRestarts)
                {
                    var powerStatus = SystemInformation.PowerStatus;

                    if (powerStatus.BatteryLifePercent == -1)
                    {
                        // if no battery, we should probably exit, lol, not like the battery is gonna reappear or something...
                        // ...? hopefully not.
                        return;
                    }

                    float batteryLevel = powerStatus.BatteryLifePercent * 100;
                    bool batteryCharging = powerStatus.PowerLineStatus == PowerLineStatus.Online;

                    // unused
                    LowPower = QuickSettings.Instance.BatteryReportingCautionLevel;
                    CriticalPower = QuickSettings.Instance.BatteryReportingCriticalLevel;

                    if (!batteryCharging && (int)batteryLevel <= CriticalPower)
                    {
                        DiscordWebhook.SendFormattedMessage($"The host is running critically low on battery power. ({(int)batteryLevel}%)\r\nPerformance may be impacted.", 16711680);
                    }
                    else
                    {
                        if (!batteryCharging && (int)batteryLevel <= LowPower)
                        {
                            DiscordWebhook.SendFormattedMessage($"The host is running low on battery power. ({(int)batteryLevel}%)", 16776960);
                        }
                    }

                    Thread.Sleep(1000 * 120);
                }
            }, true);

            StartCatchAllThread("Sleep Manager", () =>
            {
                while (AllowThreadRestarts)
                {
                    if (QuickSettings.Instance.NoSystemSleep)
                    {
                        _ = SetThreadExecutionState(ES_CONTINUOUS | ES_SYSTEM_REQUIRED | ES_DISPLAY_REQUIRED);
                    }
                    else
                    {
                        _ = SetThreadExecutionState(ES_CONTINUOUS);
                    }
                    Thread.Sleep(1000);
                }
            }, true);

            //StartCatchAllThread("Hour Counter", () =>
            //{
            //    // The top of the hour sound plays when Basic Speaking is enabled.
            //    // Checks are made every 5 seconds, then the loop should stop for a little bit before checking again if it is top of the hour.

            //    DateTime dt = DateTime.Now;

            //    while (AllowThreadRestarts)
            //    {
            //        if (QuickSettings.Instance.alertTimeZoneUTC) dt = DateTime.UtcNow;
            //        else dt = DateTime.Now;

            //        if (dt.Minute == 0)
            //        {
            //            SpeakingManager.TopOfTheHour();
            //            Thread.Sleep(1000 * 300);
            //        }

            //        Thread.Sleep(5000);
            //    }
            //}, true);

            //StartCatchAllThread("Hotkey Detector", () =>
            //{
            //    Application.Run(new MessageWindow());
            //}, true);

            StartCatchAllThread("Discord Rich Presence", () =>
            {
                if (!QuickSettings.Instance.AllowDiscordRichPresence)
                {
                    Console.WriteLine($"[Discord Rich Presence] Discord Rich Presence is disabled.");
                    throw new NonRestartableException();
                }

                Console.WriteLine($"[Discord Rich Presence] Setting up Discord RPC.");

                var client = new DiscordRpcClient("1184397437985620028")
                {
                    Logger = new DiscordRPC.Logging.ConsoleLogger(DiscordRPC.Logging.LogLevel.Warning, false)
                };

                client.OnReady += (sender, e) =>
                {
                    Console.WriteLine($"[Discord Rich Presence] Ready: {e.User.ID}");
                    InternalUserID = e.User.ID;
                };
                
                client.OnConnectionEstablished += (sender, e) =>
                {
                    Console.WriteLine($"[Discord Rich Presence] Connection established: {e.TimeCreated}");
                };

                client.OnConnectionFailed += (sender, e) =>
                {
                    Console.WriteLine($"[Discord Rich Presence] Connection failed: {e.FailedPipe}");
                };

                client.Initialize();

                client.SetPresence(new RichPresence()
                {
                    Details = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}",
                    DetailsUrl = "https://bunnytub.com/SharpAlert",
                    State = $"Relayed {AlertProcessor.AlertsRelayed} alert(s).",
                    Type = ActivityType.Watching,
                    Assets = new Assets()
                    {
                        LargeImageKey = "sharpalert_squaredicon",
                        LargeImageText = "SharpAlert"
                    },
                    StatusDisplay = StatusDisplayType.Details,
                    //Buttons =
                    //[
                    //    new DiscordRPC.Button { Label = "Get SharpAlert", Url = "https://bunnytub.com/SharpAlert" }
                    //]
                });

                while (AllowThreadRestarts)
                {
                    Thread.Sleep(5000);
                    client.UpdateState($"Relayed {AlertProcessor.AlertsRelayed} alert(s).");
                    Console.WriteLine("[Discord Rich Presence] Updated state.");
                    //client.UpdateClearTime();
                    ///client.SetButton(new DiscordRPC.Button { Label = "Download SharpAlert", Url = "https://bunnytub.com/SharpAlert" });
                }

                //client.ShutdownOnly = true;
                client.Deinitialize();
            }, true);

            StartCatchAllThread("Update Worker", () =>
            {
                Thread.Sleep(1000 * 10);

                while (AllowThreadRestarts)
                {
                    if (QuickSettings.Instance.AllowPerformingUpdates)
                    {
                        string SubRemoteVersion = UpdateWorker.TryGetRemoteVersion();
                        if (SubRemoteVersion != $"{VersionInfo.MajorVersion}.{VersionInfo.MajorVersion}")
                        {
                            UpdateWorker.TryUpdate(SubRemoteVersion, false);
                        }
                    }

                    Thread.Sleep(1000 * 45);
                }
            }, true);

            StartCatchAllThread("Pipe Worker", () => PipeWorker.ServerServiceRun(), false, false);
        }

        //[DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        //private static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

        //public enum DeviceCap
        //{
        //    VERTRES = 10,
        //    DESKTOPVERTRES = 117
        //}

        // Taken from this: https://stackoverflow.com/a/63229584

        //public static double GetWindowsScreenScalingFactor()
        //{
        //    try
        //    {
        //        Graphics GraphicsObject = Graphics.FromHwnd(IntPtr.Zero);
        //        IntPtr DeviceContextHandle = GraphicsObject.GetHdc();
        //        double LogicalScreenHeight = GetDeviceCaps(DeviceContextHandle, (int)DeviceCap.VERTRES);
        //        double PhysicalScreenHeight = GetDeviceCaps(DeviceContextHandle, (int)DeviceCap.DESKTOPVERTRES);
        //        double ScreenScalingFactor = Math.Round(PhysicalScreenHeight / LogicalScreenHeight, 2);
        //        ScreenScalingFactor *= 100.0;
        //        GraphicsObject.ReleaseHdc(DeviceContextHandle);
        //        GraphicsObject.Dispose();
        //        return ScreenScalingFactor;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"[Haida] Unable to retrieve the DPI settings. {ex.Message}");
        //        return 100;
        //    }
        //}

        public static int LowPower = 20;
        public static int CriticalPower = 20;

        [DllImport("kernel32.dll")]
        static extern uint SetThreadExecutionState(uint esFlags);

        const uint ES_CONTINUOUS = 0x80000000;
        const uint ES_SYSTEM_REQUIRED = 0x00000001;
        const uint ES_DISPLAY_REQUIRED = 0x00000002;

        private static readonly object ThreadErrorLockObject = new();

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
                        //try { feedThread?.Abort(); } catch (Exception) { }
                        //try { atomfeedThread?.Abort(); } catch (Exception) { }
                        //try { directfeedThread?.Abort(); } catch (Exception) { }
                        //try { cacheThread?.Abort(); } catch (Exception) { }
                        //try { dataProcThread?.Abort(); } catch (Exception) { }
                        //try { historyProcThread?.Abort(); } catch (Exception) { }
                        //try { notificationThread?.Abort(); } catch (Exception) { }
                        ToppleForm tf = new(ExceptionCompiled, false);
                        tf.ShowDialog();
                        //new Thread(() => SafeExit(0)).Start();
                        //Thread.Sleep(5000);
                        Environment.Exit(exception.HResult);
                        return;
                    }
                    else
                    {
                        Notify.ShowNotification($"The problem has been logged. Check the event log for more information!",
                            "SharpAlert is having issues",
                            ToolTipIcon.Error);
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
                using EventLog log = new("Application");
                log.Source = "Application";
                log.WriteEntry(ExceptionCompiled, EventLogEntryType.Error);
            }
            catch (Exception)
            {
            }

            try
            {
                if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                {
                    DiscordWebhook.SendUnformattedMessage(ExceptionCompiled + "\r\n\r\nPlease report this issue to my owner!\r\nIf you are the owner, contact <@603429346736341013> (https://bunnytub.com/SharpAlert | bunnytub@bunnytub.com) for help.");
                }
            }
            catch (Exception)
            {
            }

            Console.WriteLine(ExceptionCompiled);

            return ExceptionCompiled;
            //#if DEBUG
            //            //Debugger.Break();
            //            throw ex;
            //#else
            //            return ExceptionCompiled;
            //#endif
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
        private static extern IntPtr CreateFile(
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
                Console.Title = $"{VersionInfo.ShortFriendlyVersion}";
                IntPtr consoleHandle = CreateFile("CONOUT$", GENERIC_WRITE, 0, IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
                
                if (consoleHandle == IntPtr.Zero)
                {
                    //throw new Win32Exception(Marshal.GetLastWin32Error());
                    return;
                }

                //if (!GetConsoleMode(GetStdHandle(STD_INPUT_HANDLE), out uint mode))
                //{
                //    Console.WriteLine("[Haida] Couldn't get console mode.");
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
                //    Console.WriteLine("[Haida] Failed to get stdin handle.");
                //}
                //else
                //{
                //    Console.WriteLine("[Haida] Got stdin handle.");
                //}

                //if (!GetConsoleMode(stdinHandle, out uint stdInMode))
                //{
                //    Console.WriteLine("[Haida] Failed to get console mode.");
                //    return;
                //}

                //// Disable echo and line input
                //stdInMode &= ~ENABLE_ECHO_INPUT;
                //stdInMode &= ~ENABLE_LINE_INPUT;

                //if (!SetConsoleMode(stdinHandle, stdInMode))
                //{
                //    Console.WriteLine("[Haida] Failed to set console mode.");
                //}

                object LockObject = new();

                //Console.CancelKeyPress += (a, b) => SafeExit(0);
                _handler += new ConsoleCtrlDelegate(_ => {
                    lock (LockObject)
                    {
                        QuickSettings.Instance.Save();
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
            Thread staThread = new(() =>
            {
                try
                {
                    Console.WriteLine("[Haida] Opening the file picker.");

                    string selectedSafePath = string.Empty;

                    OpenFileDialog fbd = new()
                    {
                        Filter = "Common Alerting Protocol files (*.xml, *.cap)|*.xml;*.cap",
                        FilterIndex = 0,
                        CheckFileExists = true,
                        Multiselect = true,
                        Title = "SharpAlert - Alert Importing"
                    };

                    if (fbd.ShowDialog() != DialogResult.OK)
                    {
                        Console.WriteLine("[Haida] No file chosen from the file picker.");
                        return;
                    }

                    Console.WriteLine("[Haida] Processing chosen file(s).");

                    foreach (string selectedPath in fbd.FileNames)
                    {
                        try
                        {
                            string data = File.ReadAllText(selectedPath);
                            if (data.Contains("<SharpAlertMassImport>true</SharpAlertMassImport>"))
                            {
                                MessageBox.Show("You are importing a mass amount of alerts. Proceed with caution.",
                                    "SharpAlert",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            }
                            EnrollAlerts(data, true);
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

        private static readonly object EnrollObject = new();

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
                            //    Console.WriteLine("[HTTP Feed Capture] Identifier not found. An MD5 value will be assigned to this alert instead.");
                            //    filename = CreateMD5(alert.Value);
                            //}

                            Console.WriteLine($"[File Capture] {alertIndex} -> {filename}");

                            //string StartingSharpAlertReplay = "<SharpAlertReplay>";
                            //string EndingSharpAlertReplay = "<SharpAlertReplay>";
                            //if (!alert.Value.Contains($"{StartingSharpAlertReplay}") || !alert.Value.Contains($"{EndingSharpAlertReplay}"))
                            //{
                            //    string alertReplayValue = alert.Value + "<SharpAlertReplay>false</SharpAlertReplay>";
                            //}

                            SharpDataItem item = new(filename, alert.Value);

                            if (reset)
                            {
                                TryRemoveDataFromHistory(item);
                            }

                            if (TryAddDataToQueue(item))
                            {
                                Console.WriteLine($"[File Capture] Alert {alertIndex} ({filename}) has been saved for processing.");
                            }
                            else
                            {
                                Console.WriteLine($"[File Capture] Alert {alertIndex} ({filename}) has been discarded (already queued or is in history).");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[File Capture] Couldn't check the data for alert {alertIndex}. {ex.Message}");
                        }
                    }
                    if (alertIndex != 0) Console.WriteLine($"[File Capture] {alertIndex} alert(s) checked.");
                    else Console.WriteLine($"[File Capture] No alerts were checked.");
                }
                else
                {
                    Console.WriteLine("[File Capture] There are no alerts to enroll.");
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
                        Console.WriteLine($"[File Capture] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[File Capture] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[File Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }
    }
}

