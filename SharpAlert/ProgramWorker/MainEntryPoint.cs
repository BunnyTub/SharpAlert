using SharpAlert.AlertComponents;
using SharpAlert.DataProcessing;
using SharpAlert.DisplayDialogs;
using SharpAlert.SourceCapturing;
using SharpAlert.SourceCapturing.SystemSpecific;
using SharpAlert.WebServer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.AudioManager;
using static SharpAlert.ProgramWorker.HaidaWorker;
using static SharpAlert.ProgramWorker.NotificationWorker;

namespace SharpAlert.ProgramWorker
{
    public class SharpDataItem(string name, string data)
    {
        // public string FriendlyName { get; set; }
        public string Name { get; set; } = name;
        public string Data { get; set; } = data;
    }

    internal static class MainEntryPoint
    {
        public static readonly DateTime startDT = DateTime.UtcNow;
        public static bool AllowThreadRestarts = true;
        private static int FeedSuccessfulCalls_ = 0;
        public static int FeedSuccessfulCalls
        {
            get => FeedSuccessfulCalls_;
            set
            {
                FeedSuccessfulCalls_ = value;
                if (FeedSuccessfulCalls_ >= 10000000)
                {
                    FeedSuccessfulCalls_ = 0;
                }
            }
        }

        public static FeedCapture feed;
        public static WeatherAtomCapture atomfeed;
        public static DirectFeedCapture directfeed;
        public static IDAPFeedCapture idapfeed;
        public static CacheCapture cache;
        public static DataProcessor dataproc;
        public static HistoryProcessor historyproc;
        public static TeleIdleForm idle;
        public static StatusForm status;
        public static bool CloseIdleWindow = false;
        public static bool CloseStatusWindow = false;
        public static object IdleWindowLock = new();
        public static object StatusWindowLock = new();
        public static object AudioOutputLock = new();
        public static HyperServer hyper;
        public static object AlertValuesLock = new();
        private static bool _AlertDisplaying = false;
        public static DateTime AlertDisplayingBeginTime { get; private set; } = DateTime.MinValue;

        public static bool AlertDisplaying
        {
            get
            {
                return _AlertDisplaying;
            }
            set
            {
                _AlertDisplaying = value;
                AlertDisplayingBeginTime = DateTime.UtcNow;
            }
        }

        public static Icon icon = SystemIcons.Information;

        public static List<SharpDataItem> SharpDataQueue { get; } = [];
        public static List<SharpDataItem> SharpDataHistory { get; } = [];
        public static List<string> SharpDataRelayedNamesHistory { get; } = [];
        
        public static readonly string AssemblyFile = Environment.ProcessPath;
        public static readonly string AssemblyDirectory = Path.GetDirectoryName(AssemblyFile);

        public static readonly string CustomURLsFileName = "feeds.txt";

        /// <summary>
        /// Stops everything safely. Hopefully.
        /// </summary>
        public static void SafeExit(bool restart = false)
        {
            AllowThreadRestarts = false;

            DiscordWebhook.SendFormattedMessage($"SharpAlert is stopping.");

            Notify.ShowNotification("Closing everything down now.",
                "SharpAlert is stopping.",
                ToolTipIcon.Info);


            Thread.Sleep(5000);

            if (restart) Environment.Exit(100);
            else Environment.Exit(0);

            // we should never be going beyond this point, but just in case lol
            return;

            //Notify.ShowNotification($"Haida is working to get everything shutdown. This may take a few moments.",
            //        "SharpAlert is stopping",
            //        ToolTipIcon.Info);

            //Console.WriteLine("Preparing for termination.");
            //AllowThreadRestarts = false;
            //Thread.Sleep(500);

            //bool Finished = false;
            //new Thread(() =>
            //{
            //    try
            //    {
            //        while (!ServiceRunnerScheduled)
            //        {
            //            LogFault(new Exception("The program cannot exit safely, because the service runner hasn't indicated a successful startup."));
            //            Thread.Sleep(2500);
            //            Finished = true;
            //            return;
            //        }

            //        //if (ServiceRunnerScheduled)
            //        {
            //            Console.WriteLine("Hyper Server is shutting down.");
            //            hyper?.ServiceStop();
            //            QuickSettings.Instance.DisableAlertProcessing = true;
            //            QuickSettings.Instance.PauseDataProcessing = true;
            //            //Console.WriteLine("Feed Capture is shutting down.");
            //            //feed?.ServiceStop();
            //            //Console.WriteLine("Direct Feed Capture is shutting down.");
            //            //directfeed?.ServiceStop();
            //            Console.WriteLine("Cache Capture is shutting down.");
            //            cache?.ServiceStop();
            //            Console.WriteLine("Data Processor is shutting down.");
            //            dataproc?.ServiceStop();
            //            Console.WriteLine("Idle Window is shutting down.");
            //            if (idle != null) IdleWindowVisible = false;
            //            Console.WriteLine("Status Window is shutting down.");
            //            if (status != null) StatusWindowVisible = false;
            //            Console.WriteLine("Stopping all sounds.");
            //            try
            //            {
            //                StopAllAudioSilently();
            //            }
            //            catch (Exception)
            //            {
            //                Console.WriteLine("Cannot stop some sounds.");
            //            }
            //            if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
            //            {
            //                DiscordWebhook.SendFormattedMessage("SharpAlert has stopped.");
            //            }
            //        }
            //    }
            //    catch (Exception)
            //    {
            //    }
            //    Finished = true;
            //}).Start();

            //static void Restart()
            //{
            //    // Only restarts if the watchdog is running, maybe we need to do something to avoid this, or not.
            //    Environment.Exit(100);
            //}

            //// The shutdown messages are just for fun lol

            //for (int i = 0; !(i >= 15);)
            //{
            //    if (Finished)
            //    {
            //        Console.WriteLine("Shutdown was successful. Say thanks to Haida for his hard work... -w-");
            //        Notify.ShowNotification($"Shutdown was successful. Say thanks to Haida for his hard work... -w-",
            //            "SharpAlert has stopped",
            //            ToolTipIcon.Info);

            //        if (restart) Restart();
            //        else Environment.Exit(0);
            //        return;
            //    }
            //    Thread.Sleep(1000);
            //    i++;
            //}

            //Console.WriteLine("Shutdown timed out. Say thanks to Haida for his hard work... -w-");
            //Notify.ShowNotification($"Shutdown timed out. Say thanks to Haida for his hard work... -w-",
            //    "SharpAlert has stopped",
            //    ToolTipIcon.Info);
            
            //if (restart) Restart();
            //else Environment.Exit(0);

            //return;
        }

        public static bool IsAdministrator => new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
        public static bool ServiceMode { get; private set; } = false;
        public static List<string> Args { get; private set; } = null;
        // --alt-config-1/2/3/4

        private static bool Secret = false;
        public static bool IsUserSuperSecretAccessor()
        {
            try
            {
                string userIDs = client.GetStringAsync("https://bunnytub.com/SharpAlert/SharpAlert.shfile").Result;
                foreach (string userID in userIDs.Split())
                {
                    if (userID.Contains(InternalUserID.ToString()))
                    {
                        Secret = true;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return Secret;
            }
        }

        private static bool Locked = false;
        public static bool IsUserLocked()
        {
            try
            {
                string userIDs = client.GetStringAsync("https://bunnytub.com/SharpAlert/SharpAlert.lkfile").Result;
                foreach (string userID in userIDs.Split())
                {
                    if (userID.Contains(InternalUserID.ToString()))
                    {
                        Locked = true;
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return Locked;
            }
        }

        public static ulong InternalUserID
        {
            get;
            set;
        } = 0;

        /// <summary>
        /// Starts everything.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //watchdog self-child process
            Args = [.. Environment.GetCommandLineArgs()];
            QuickSettings.Reload();
            Application.EnableVisualStyles();
            //System.Windows.Forms.Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (a, b) =>
            {
                UnsafeFault(b.Exception, true);
            };
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //ThreadDrool.StartAndForget(() =>
            //{
            //    AlertInfo info1 = new()
            //    {
            //        AlertSource = "NAADS Primary",
            //        AlertURL = "https://google.com",
            //        AlertID = "ABCD123456-ABCDABCDABCDABCD",
            //        AlertIntroText = "1. Flash Flood Warning. For the following, Bayamon Municipio, Puerto Rico; Catano Municipio, Puerto Rico; Guaynabo Municipio, Puerto Rico; San Juan Municipio, Puerto Rico; Trujillo Alto Municipio, Puerto Rico. This alert begins 01:43 PM EST, September 22, 2025, and ends at 03:45 PM EST, September 22, 2025. Issued by NWS San Juan PR. Sourced from FEMA IPAWS (WEA). \r\n\r\n2. Flash Flood Warning. For the following, Bayamon Municipio, Puerto Rico; Catano Municipio, Puerto Rico; Guaynabo Municipio, Puerto Rico; San Juan Municipio, Puerto Rico; Trujillo Alto Municipio, Puerto Rico. This alert begins 01:43 PM EST, September 22, 2025, and ends at 03:45 PM EST, September 22, 2025. Issued by NWS San Juan PR. Sourced from FEMA IPAWS (WEA).",
            //        AlertBodyText = "1. NWS: FLASH FLOOD WARNING this area til 3:12:45 AM AST. Avoid flooded areas. National Weather Service: A FLASH FLOOD WARNING is in effect for this area until 3:12:45 AM AST. This is a dangerous and life-threatening situation. Do not attempt to travel unless you are fleeing an area subject to flooding or under an evacuation order.\r\n\r\n2. SNM: AVISO DE INUNDACIONES REPENTINAS hasta 3:12:45 AM AST. Evite areas inundadas. Servicio Nacional de Meteorologia: AVISO DE INUNDACIONES REPENTINAS en efecto para esta area hasta las 3:12:45 AM AST. Esta es una situacion peligrosa y amenaza la vida. No intente viajar a menos que sea para abandonar un area propensa a inundaciones o bajo una orden de desalojo.",
            //        AlertMessageType = "alert",
            //        AlertSeverity = "severe",
            //        AlertSentDate = $"{DateTime.UtcNow:s}",
            //        AlertExpiryDate = $"{DateTime.UtcNow.AddSeconds(15):s}",
            //        AlertFriendlyLocations =
            //        [
            //            "Bayamon Municipio, Puerto Rico;",
            //            "Catano Municipio, Puerto Rico;",
            //            "Guaynabo Municipio, Puerto Rico;",
            //            "San Juan Municipio, Puerto Rico;",
            //            "Trujillo Alto Municipio, Puerto Rico"
            //        ],
            //        AlertAudioURL = "https://bunnytub.com/media/AMERICA.mp3",
            //        AlertImageURL = "https://bunnytub.com/media/uranium.png"
            //    };
                
            //    AlertInfo info2 = new()
            //    {
            //        AlertSource = "SASMEX",
            //        AlertURL = "https://google.com",
            //        AlertID = "ABCD123456-ABCDABCDABCDABCD",
            //        AlertIntroText = "1. EARTHQUAKE. For the following, Bayamon Municipio, Puerto Rico; Catano Municipio, Puerto Rico; Guaynabo Municipio, Puerto Rico; San Juan Municipio, Puerto Rico; Trujillo Alto Municipio, Puerto Rico. This alert begins 01:43 PM EST, September 22, 2025, and ends at 03:45 PM EST, September 22, 2025. Issued by NWS San Juan PR. Sourced from FEMA IPAWS (WEA). \r\n\r\n2. Flash Flood Warning. For the following, Bayamon Municipio, Puerto Rico; Catano Municipio, Puerto Rico; Guaynabo Municipio, Puerto Rico; San Juan Municipio, Puerto Rico; Trujillo Alto Municipio, Puerto Rico. This alert begins 01:43 PM EST, September 22, 2025, and ends at 03:45 PM EST, September 22, 2025. Issued by NWS San Juan PR. Sourced from FEMA IPAWS (WEA).",
            //        AlertBodyText = "1. NWS: EARTHQUAKE WARNING this area til 3:12:45 AM AST. Avoid flooded areas. National Weather Service: A FLASH FLOOD WARNING is in effect for this area until 3:12:45 AM AST. This is a dangerous and life-threatening situation. Do not attempt to travel unless you are fleeing an area subject to flooding or under an evacuation order.\r\n\r\n2. SNM: AVISO DE INUNDACIONES REPENTINAS hasta 3:12:45 AM AST. Evite areas inundadas. Servicio Nacional de Meteorologia: AVISO DE INUNDACIONES REPENTINAS en efecto para esta area hasta las 3:12:45 AM AST. Esta es una situacion peligrosa y amenaza la vida. No intente viajar a menos que sea para abandonar un area propensa a inundaciones o bajo una orden de desalojo.",
            //        AlertMessageType = "update",
            //        AlertSeverity = "minor",
            //        AlertSentDate = $"{DateTime.UtcNow:s}",
            //        AlertExpiryDate = $"{DateTime.UtcNow.AddSeconds(15):s}",
            //        AlertFriendlyLocations =
            //        [
            //            "Bayamon Municipio, Puerto Rico;",
            //            "Catano Municipio, Puerto Rico;",
            //            "Guaynabo Municipio, Puerto Rico;",
            //            "San Juan Municipio, Puerto Rico;",
            //            "Trujillo Alto Municipio, Puerto Rico"
            //        ],
            //        AlertAudioURL = "https://bunnytub.com/media/AMERICA.mp3",
            //        AlertImageURL = "https://bunnytub.com/media/uranium.png"
            //    };

            //    while (true)
            //    {
            //        Thread.Sleep(5000);
            //        DashboardManager.AddNewAlertToDashboard(info1);
            //        Thread.Sleep(5000);
            //        DashboardManager.AddNewAlertToDashboard(info2);
            //    }
            //});

            //return;

            //ThreadDrool.StartAndForget(() => { while (true) new AlertTableForm().ShowDialog(); });

            // Registry code for detecting .NET Framework is not even needed anymore, because .NET detects itself without any real work

            if (Args.Count >= 2)
            {
                if (Args.Contains("--wait-until-parent-closes"))
                {
                    try
                    {
                        GetParentProcess().WaitForExit(10000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Couldn't identify the parent process to wait for it to exit. It may have already exited. {ex.Message}");
                        Thread.Sleep(5000);
                    }

                    // remove the wait argument, so it doesn't accidentally get parsed by a child process under watchdog
                    Args.RemoveAll(delegate (string str) {
                        return str == "--wait-until-parent-closes";
                    });
                }

                if (Args.Contains("--internal-remove-old"))
                {
                    try
                    {
                        if (File.Exists(AssemblyFile + "_"))
                        {
                            File.Delete(AssemblyFile + "_");
                        }
                    }
                    catch (Exception)
                    {
                    }

                    Args.RemoveAll(delegate (string str) {
                        return str == "--internal-remove-old";
                    });
                }

                if (Args.Contains("--service-mode"))
                {
                    AllocateTerminal(false);
                    Console.WriteLine("SERVICE MODE ACTIVE --- PERFORMANCE MAY BE IMPACTED --- THIS IS FOR TESTING PURPOSES");
                    ServiceMode = true;
                    new Thread(() => { new ServiceMonitorForm().ShowDialog(); }).Start();
                }
                else
                {
                    if (Args.Contains("--console"))
                    {
                        AllocateTerminal(false);
                    }
                }

                if (Args.Contains("--update"))
                {
                    UpdateWorker.TryUpdate(UpdateWorker.TryGetRemoteVersion(), true);
                    return;
                }

                if (Args.Contains("--monitored") || ServiceMode)
                {
                    Mutex mutex = new(false, "BUNNYTUB_EASCULTURE_SharpAlert_ProtectEZ");

                    try
                    {
                        if (!ServiceMode)
                        {
                            if (!Args.Contains("--ignore-duplicates"))
                            {
                                if (!mutex.WaitOne(0, false))
                                {
                                    new Thread(() =>
                                    {
                                        Thread.Sleep(1000 * 15);
                                        Environment.Exit(0);
                                    }).Start();
                                    MessageBox.Show("SharpAlert is already running.\r\nCheck the notification tray area on the taskbar!",
                                        "SharpAlert",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                                    Environment.Exit(0);
                                }
                            }
                        }

                        new Thread(() => ServiceRun()).Start();

                        if (!ServiceMode)
                        {
                            try
                            {
                                Process parentProc = GetParentProcess();

                                if (parentProc.MainModule.FileName.ToLowerInvariant() == AssemblyFile.ToLowerInvariant())
                                {
                                    parentProc.WaitForExit();
                                    QuickSettings.Instance.Save();
                                    SafeExit();
                                }
                            }
                            catch (Exception)
                            {
                                //LogFault(new Exception("Couldn't identify the parent process. This may limit the ability for SharpAlert to recover from a problem.", ex));
                            }
                        }
                        else
                        {
                            mutex?.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"SharpAlert failed to start! ServiceMode = {ServiceMode}\r\n" +
                            $"{ex.StackTrace}\r\n" +
                            $"{ex.Message}\r\n" +
                            $"Please report this.\r\n" +
                            $"If this is your first time running SharpAlert,\r\n" +
                            $"make sure your operating system is officialy supported.\r\n" +
                            $"Make sure no compatibility options are enabled.",
                            "SharpAlert",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        LogFault(ex);
                        try { Environment.Exit(unchecked(ex.HResult)); } catch (Exception) { Environment.Exit(1); }
                    }
                    finally
                    {
                        mutex?.Close();
                    }
                    return;
                }
            }

            bool restartable = true;
            bool debuggable = false;
            bool forceNewWatchdogProcess = false;

            // prevent writing to the config if this is the monitoring process, just in case
            QuickSettings.ReadOnlyMode = true;

            while (restartable)
            {
                ProcessStartInfo self = new()
                {
                    FileName = AssemblyFile,
                    ErrorDialog = false
                };

                if (!forceNewWatchdogProcess)
                {
                    string arguments = "--monitored";
                    foreach (string arg in Args)
                    {
                        arguments += $"\x20{arg}";
                    }

                    if (debuggable)
                    {
                        arguments += $"\x20--call-debugger";
                        debuggable = false;
                    }

                    self.Arguments = arguments;
                }
                else
                {
                    self.Arguments = "--wait-until-parent-closes";
                }

#pragma warning disable CA2000
                Process monitorSelf = new()
                {
                    StartInfo = self
                };

                monitorSelf.Start();

                if (forceNewWatchdogProcess)
                {
                    Environment.Exit(0);
                    return;
                }
#pragma warning restore CA2000

                monitorSelf.WaitForExit();
            
                switch (unchecked(monitorSelf.ExitCode))
                {
                    case 0:
                        restartable = false;
                        //DiscordWebhook.SendFormattedMessage($"SharpAlert has stopped.");
                        Environment.Exit(0);
                        return;
                    case -1073741510:
                        restartable = false;
                        Environment.Exit(0);
                        return;
                    case 100:
                        restartable = true;
                        QuickSettings.Reload();
                        if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                        {
                            DiscordWebhook.SendFormattedMessage($"SharpAlert is restarting.");
                        }
                        break;
                    default:
                        restartable = true;
                        QuickSettings.Reload();
                        if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                        {
                            switch (unchecked(monitorSelf.ExitCode))
                            {
                                case 1073807364:
                                    DiscordWebhook.SendFormattedMessage($"SharpAlert has stopped because the host is shutting down.");
                                    Thread.Sleep(5000);
                                    Environment.Exit(0);
                                    break;
                                case -1073741571:
                                    DiscordWebhook.SendFormattedMessage($"SharpAlert has stopped abruptly due to a recursion problem.");
                                    break;
                                case -1073741819:
                                case -1073740791:
                                case -1073740940:
                                case -1073741553:
                                case -1073741800:
                                case -1073740988:
                                    DiscordWebhook.SendFormattedMessage($"SharpAlert has stopped abruptly due to a security problem.");
                                    break;
                                default:
                                    DiscordWebhook.SendFormattedMessage($"SharpAlert has stopped abruptly. ({monitorSelf.ExitCode})");
                                    break;
                            }
                        }

                        string Details = $"SharpAlert closed with a non-zero exit code. ({unchecked(monitorSelf.ExitCode)})\r\n" +
                            $"{new Win32Exception(unchecked(monitorSelf.ExitCode)).Message}";
                        LogFault(new Exception(Details));
                        ToppleForm tf = new(Details, true);
                        tf.ShowDialog();
                        if (tf.DialogResult == DialogResult.Yes) debuggable = true;
                        else debuggable = false;
                        tf.Dispose();
                        break;
                }

                monitorSelf.Dispose();
            }
        }

        private static Process GetParentProcess()
        {
            int iParentPid = 0;
            int iCurrentPid = Environment.ProcessId;

            IntPtr oHnd = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

            if (oHnd == IntPtr.Zero)
                return null;

            PROCESSENTRY32 oProcInfo = new()
            {
                dwSize =
                (uint)Marshal.SizeOf(typeof(PROCESSENTRY32))
            };

            if (Process32First(oHnd, ref oProcInfo) == false)
                return null;

            do
            {
                if (iCurrentPid == oProcInfo.th32ProcessID)
                    iParentPid = (int)oProcInfo.th32ParentProcessID;
            }
            while (iParentPid == 0 && Process32Next(oHnd, ref oProcInfo));

            if (iParentPid > 0)
                return Process.GetProcessById(iParentPid);
            else
                return null;
        }

        private static readonly uint TH32CS_SNAPPROCESS = 2;

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESSENTRY32
        {
            public uint dwSize;
            public uint cntUsage;
            public uint th32ProcessID;
            public IntPtr th32DefaultHeapID;
            public uint th32ModuleID;
            public uint cntThreads;
            public uint th32ParentProcessID;
            public int pcPriClassBase;
            public uint dwFlags;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szExeFile;
        };

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

        [DllImport("kernel32.dll")]
        static extern bool Process32First(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        [DllImport("kernel32.dll")]
        static extern bool Process32Next(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

        /// <summary>
        /// Returns an MD5 value of the input string.
        /// </summary>
        /// <param name="input">The string to produce an MD5 from.</param>
        /// <returns></returns>
        public static string CreateMD5(string input)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = MD5.HashData(inputBytes);

            StringBuilder sb = new();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }

        private static object IdleWindowVisible_ = false;
        public static bool IdleWindowVisible
        {
            get => (bool)IdleWindowVisible_;
            set
            {
                lock (IdleWindowVisible_)
                {
                    if (value)
                    {
                        ThreadDrool.StartAndForget(() =>
                        {
                            if (idle != null && !idle.IsDisposed)
                            {
                                idle.Invoke(new MethodInvoker(() => idle.Dispose()));
                            }
                            else
                            {
                                idle = new TeleIdleForm();
                            }
                            idle?.ShowDialog();
                        });
                    }
                    else
                    {
                        if (idle != null && !idle.IsDisposed)
                        {
                            idle.Invoke(new MethodInvoker(() => idle.Dispose()));
                        }
                    }

                    IdleWindowVisible_ = value;
                }
            }
        }

        private static object StatusWindowVisible_ = false;
        public static bool StatusWindowVisible
        {
            get => (bool)StatusWindowVisible_;
            set
            {
                lock (StatusWindowVisible_)
                {
                    if (value)
                    {
                        ThreadDrool.StartAndForget(() =>
                        {
                            if (status != null && !status.IsDisposed)
                            {
                                status.Invoke(new MethodInvoker(() => status.Dispose()));
                            }
                            else
                            {
                                status = new StatusForm();
                            }
                            status?.ShowDialog();
                        });
                    }
                    else
                    {
                        if (status != null && !status.IsDisposed)
                        {
                            status.Invoke(new MethodInvoker(() => status.Dispose()));
                        }
                    }

                    StatusWindowVisible_ = value;
                }
            }
        }
    }
}

