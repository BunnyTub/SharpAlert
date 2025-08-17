using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Cryptography;
using static SharpAlert.AudioManager;
using static SharpAlert.ProgramWorker.TuyeWorker;
using SharpAlert.SourceCapturing;
using System.Linq;
using System.Runtime.InteropServices;
using System.ComponentModel;
using SharpAlert.DataProcessing;
using SharpAlert.DisplayDialogs;
using SharpAlert.WebServer;
using SharpAlert.AlertComponents;
using SharpAlert.SourceCapturing.SystemSpecific;
using static SharpAlert.ProgramWorker.NotificationWorker;
using SharpAlert.ConfigurationDialogs;
using Microsoft.Win32;

namespace SharpAlert.ProgramWorker
{
    public class SharpDataItem
    {
        // public string FriendlyName { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }

        public SharpDataItem(string name, string data)
        {
            Name = name;
            Data = data;
        }
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
        public static object IdleWindowLock = new object();
        public static object StatusWindowLock = new object();
        public static object AudioOutputLock = new object();
        public static HyperServer hyper;
        public static object AlertValuesLock = new object();
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

        public static List<SharpDataItem> SharpDataQueue = new List<SharpDataItem>();
        public static List<SharpDataItem> SharpDataHistory = new List<SharpDataItem>();
        public static List<string> SharpDataRelayedNamesHistory = new List<string>();
        
        public static readonly string AssemblyFile = Process.GetCurrentProcess().MainModule.FileName;
        public static readonly string AssemblyDirectory = Path.GetDirectoryName(AssemblyFile);

        public static readonly string CustomURLsFileName = "feeds.txt";

        /// <summary>
        /// Stops everything safely. Hopefully.
        /// </summary>
        public static void SafeExit()
        {
            Notify.ShowNotification($"Tuye is working to get everything shutdown. This may take a few moments.",
                "SharpAlert is stopping",
                ToolTipIcon.Info);

            Console.WriteLine("Preparing for termination.");
            AllowThreadRestarts = false;
            Thread.Sleep(500);

            bool Finished = false;
            new Thread(() =>
            {
                try
                {
                    while (!ServiceRunnerScheduled)
                    {
                        LogFault(new Exception("The program cannot exit safely, because the service runner hasn't indicated a successful startup."));
                        Thread.Sleep(2500);
                        Finished = true;
                        return;
                    }

                    //if (ServiceRunnerScheduled)
                    {
                        Console.WriteLine("Hyper Server is shutting down.");
                        hyper?.ServiceStop();
                        QuickSettings.Instance.DisableAlertProcessing = true;
                        QuickSettings.Instance.PauseDataProcessing = true;
                        //Console.WriteLine("Feed Capture is shutting down.");
                        //feed?.ServiceStop();
                        //Console.WriteLine("Direct Feed Capture is shutting down.");
                        //directfeed?.ServiceStop();
                        Console.WriteLine("Cache Capture is shutting down.");
                        cache?.ServiceStop();
                        Console.WriteLine("Data Processor is shutting down.");
                        dataproc?.ServiceStop();
                        Console.WriteLine("Alert Processor is shutting down.");
                        lock (AlertProcessor.AlertLock)
                        {
                        }
                        Console.WriteLine("Idle Window is shutting down.");
                        if (idle != null) IdleWindowVisible = false;
                        Console.WriteLine("Status Window is shutting down.");
                        if (status != null) StatusWindowVisible = false;
                        Console.WriteLine("Stopping all sounds.");
                        try
                        {
                            StopAllAudioSilently();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Cannot stop some sounds.");
                        }
                        if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                        {
                            DiscordWebhook.SendFormattedMessage("SharpAlert has stopped.");
                        }
                    }
                }
                catch (Exception)
                {
                }
                Finished = true;
            }).Start();

            for (int i = 0; !(i >= 15);)
            {
                if (Finished)
                {
                    Console.WriteLine("Shutdown was successful. Say thanks to Tuye for his hard work... -w-");
                    Notify.ShowNotification($"Shutdown was successful. Say thanks to Tuye for his hard work... -w-",
                        "SharpAlert has stopped",
                        ToolTipIcon.Info);

                    Environment.Exit(0);
                }
                Thread.Sleep(1000);
                i++;
            }

            Console.WriteLine("Shutdown timed out. Say thanks to Tuye for his hard work... -w-");
            Notify.ShowNotification($"Shutdown timed out. Say thanks to Tuye for his hard work... -w-",
                "SharpAlert has stopped",
                ToolTipIcon.Info);
            Environment.Exit(0);
        }

        public static bool ServiceMode { get; private set; } = false;
        public static List<string> Args { get; private set; } = null;
        // --alt-config-1/2/3/4

        /// <summary>
        /// Starts everything.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //watchdog self-child process
            Args = Environment.GetCommandLineArgs().ToList();
            Application.EnableVisualStyles();
            //Application.VisualStyleState = System.Windows.Forms.VisualStyles.VisualStyleState.NoneEnabled;
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (a, b) =>
            {
                UnsafeFault(b.Exception, true);
            };
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            //ThreadDrool.StartAndForget(() => { while (true) new AlertTableForm().ShowDialog(); });

            // Thank you Microsoft

            (string, bool) CheckFor45PlusVersion(int? releaseKey)
            {
                if (releaseKey == null) return ("Unknown", false);
                if (releaseKey >= 533320) return ("4.8.1 or later", true);
                if (releaseKey >= 528040) return ("4.8", true);
                if (releaseKey >= 461808) return ("4.7.2", false);
                if (releaseKey >= 461308) return ("4.7.1", false);
                if (releaseKey >= 460798) return ("4.7", false);
                if (releaseKey >= 394802) return ("4.6.2", false);
                if (releaseKey >= 394254) return ("4.6.1", false);
                if (releaseKey >= 393295) return ("4.6", false);
                if (releaseKey >= 379893) return ("4.5.2", false);
                if (releaseKey >= 378675) return ("4.5.1", false);
                if (releaseKey >= 378389) return ("4.5", false);

                return ("Unknown", false);
            }

            string SubKey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";

            using (RegistryKey baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
            using (RegistryKey ndpKey = baseKey.OpenSubKey(SubKey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    var Version = CheckFor45PlusVersion((int)ndpKey.GetValue("Release"));
                    if (!Version.Item2)
                    {
                        MessageBox.Show($"You're running .NET Framework {Version.Item1}, which is not supported by SharpAlert. Please update to .NET Framework 4.8 or higher. https://dotnet.microsoft.com/en-us/download/dotnet-framework/thank-you/net48-offline-installer",
                            "SharpAlert - Unsupported .NET Framework Version",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        Environment.Exit(8008); // equivalent to NOT FOUND %ERRORLEVEL% in Command Prompt
                        return;
                    }
                }
            }

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
                        LogFault(new Exception("Couldn't identify the parent process to wait for it to exit. It may have already exited.", ex));
                        Thread.Sleep(1000);
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
                }

                if (Args.Contains("--service-mode"))
                {
                    AllocateTerminal(false);
                    Console.WriteLine("SERVICE MODE ACTIVE --- PERFORMANCE MAY BE IMPACTED --- THIS IS FOR TESTING PURPOSES");
                    ServiceMode = true;
                    new Thread(() => { while (true) new ServiceMonitorForm().ShowDialog(); }).Start();
                }
                else
                {
                    if (Args.Contains("--console"))
                    {
                        AllocateTerminal(false);
                    }
                }

                if (Args.Contains("--monitored") || ServiceMode)
                {
                    Mutex mutex = new Mutex(false, "BUNNYTUB_EASCULTURE_SharpAlert_ProtectEZ");

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
                            catch (Exception ex)
                            {
                                LogFault(new Exception("Couldn't identify the parent process. This may limit the ability for SharpAlert to recover from a problem.", ex));
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
                            $"check that you have .NET Framework 4.8+ installed.\r\n" +
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
                ProcessStartInfo self = new ProcessStartInfo
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

                Process monitorSelf = new Process
                {
                    StartInfo = self
                };

                monitorSelf.Start();

                if (forceNewWatchdogProcess)
                {
                    Environment.Exit(0);
                    return;
                }
                
                monitorSelf.WaitForExit();
            
                switch (unchecked(monitorSelf.ExitCode))
                {
                    case 0:
                        restartable = false;
                        Environment.Exit(0);
                        return;
                    case -1073741510:
                        restartable = false;
                        Environment.Exit(0);
                        return;
                    case 100:
                        restartable = true;
                        QuickSettings.Instance.Reload();
                        if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                        {
                            DiscordWebhook.SendFormattedMessage($"SharpAlert is restarting.");
                        }

                        break;
                    default:
                        restartable = true;
                        QuickSettings.Instance.Reload();
                        if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                        {
                            switch (unchecked(monitorSelf.ExitCode))
                            {
                                case 1073807364:
                                    DiscordWebhook.SendFormattedMessage($"SharpAlert has stopped abruptly because the system is shutting down.");
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
                                    DiscordWebhook.SendFormattedMessage($"SharpAlert has terminated unexpectedly. ({monitorSelf.ExitCode})");
                                    break;
                            }
                        }
                        string Details = $"SharpAlert closed with a non-zero exit code. ({unchecked(monitorSelf.ExitCode)})\r\n" +
                            $"{new Win32Exception(unchecked(monitorSelf.ExitCode)).Message}";
                        LogFault(new Exception(Details));
                        ToppleForm tf = new ToppleForm(Details, true);
                        tf.ShowDialog();
                        if (tf.DialogResult == DialogResult.Yes) debuggable = true;
                        else debuggable = false;
                        break;
                }

                monitorSelf.Dispose();
            }
        }

        private static Process GetParentProcess()
        {
            int iParentPid = 0;
            int iCurrentPid = Process.GetCurrentProcess().Id;

            IntPtr oHnd = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

            if (oHnd == IntPtr.Zero)
                return null;

            PROCESSENTRY32 oProcInfo = new PROCESSENTRY32
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
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
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
                        if (idle != null && !idle.IsDisposed)
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

