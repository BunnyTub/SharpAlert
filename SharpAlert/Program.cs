using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Diagnostics;
using System.Security.Cryptography;

namespace SharpAlert
{
    internal static class VersionInfo
    {
        public static readonly int MajorVersion = 4;
        public static readonly int MinorVersion = 0;
    }

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

    internal static class Program
    {
        public static readonly DateTime startDT = DateTime.UtcNow;
        public static bool AllowThreadRestarts = true;
        public static FeedCapture feed;
        public static CacheCapture cache;
        public static DataProcessor processor;
        public static SoundPlayer sound;
        public static SoundPlayer soundCancellation;
        public static SoundPlayer soundFinish;
        public static TeleIdleForm idle;
        public static StatusForm status;
        public static bool CloseIdleWindow = false;
        public static bool CloseStatusWindow = false;
        public static object IdleWindowLock = new object();
        public static object StatusWindowLock = new object();
        public static NotifyIcon notify;
        public static SpeechSynthesizer engine;
        public static object AlertValuesLock = new object();
        public static bool AlertDisplaying = false;

        public static List<SharpDataItem> SharpDataQueue = new List<SharpDataItem>();
        public static List<SharpDataItem> SharpDataHistory = new List<SharpDataItem>();

        
        public static readonly string AssemblyFile = Process.GetCurrentProcess().MainModule.FileName;
        public static readonly string AssemblyDirectory = Path.GetDirectoryName(AssemblyFile);

        public static string[] args;
        public static Icon icon = SystemIcons.Information;

        /// <summary>
        /// Stops everything safely.
        /// </summary>
        public static void SafeExit(int exitCode)
        {
            AllowThreadRestarts = false;
            Thread.Sleep(500);
            Console.WriteLine("Feed Capture is shutting down.");
            feed?.ServiceStop();
            Console.WriteLine("Cache Capture is shutting down.");
            cache?.ServiceStop();
            Console.WriteLine("Data Processor is shutting down.");
            processor?.ServiceStop();
            Console.WriteLine("Alert Processor is shutting down.");
            lock (AlertProcessor.AlertLock)
            {
            }
            Console.WriteLine("Idle Window is shutting down.");
            if (idle != null) DestroyIdleWindow();
            Console.WriteLine("Status Window is shutting down.");
            if (status != null) DestroyStatusWindow();
            Console.WriteLine("Stopping sounds.");
            sound?.Stop();
            soundCancellation?.Stop();
            soundFinish?.Stop();
            Console.WriteLine("Stopping TTS.");
            engine?.SpeakAsyncCancelAll();
            Console.WriteLine("All operations finished. Thank Ice Bear for his hard work... -w-");
            if (notify != null)
            {
                notify.BalloonTipTitle = "SharpAlert has stopped";
                notify.BalloonTipText = "Shutdown was successful. Say thanks to Ice Bear for his hard work... -w-";
                notify.BalloonTipIcon = ToolTipIcon.Info;
                notify.ShowBalloonTip(5000);
                Thread.Sleep(5000);
                notify.Visible = false;
            } else Thread.Sleep(1000);
            Environment.Exit(exitCode);
        } 

        /// <summary>
        /// Starts everything.
        /// </summary>
        [MTAThread]
        private static void Main()
        {
            try
            {
                IceBearWorker.ServiceRun();
            }
            catch (Exception ex)
            {
                MessageBox.Show("SharpAlert failed to start!\r\n" +
                    $"{ex.StackTrace}\r\n" +
                    $"{ex.Message}",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Environment.FailFast("SharpAlert failed to start!\r\n" +
                    $"{ex.StackTrace}\r\n" +
                    $"{ex.Message}");
            }
        }

        /// <summary>
        /// Returns an MD5 value of the input string.
        /// </summary>
        /// <param name="input">The string to produce an MD5 from.</param>
        /// <returns></returns>
        public static string CreateMD5(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public static void CreateIdleWindow()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                CloseIdleWindow = true;
                lock (IdleWindowLock)
                {
                    CloseIdleWindow = false;
                    idle = new TeleIdleForm();
                    while (!CloseIdleWindow) idle.ShowDialog(null);
                    idle.Dispose();
                    idle = null;
                }
            });
        }
        
        public static void CreateStatusWindow()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                CloseStatusWindow = true;
                lock (StatusWindowLock)
                {
                    CloseStatusWindow = false;
                    status = new StatusForm();
                    while (!CloseStatusWindow) status.ShowDialog(null);
                    status.Dispose();
                    status = null;
                }
            });
        }
        
        public static void DestroyIdleWindow()
        {
            CloseIdleWindow = true;
            lock (IdleWindowLock)
            {
                while (idle != null)
                {
                    while (CloseIdleWindow)
                    {
                        Thread.Sleep(100);
                    }
                    idle.Dispose();
                    idle = null;
                }
                CloseIdleWindow = false;
            }
        }
        
        public static void DestroyStatusWindow()
        {
            CloseStatusWindow = true;
            lock (StatusWindowLock)
            {
                while (status != null)
                {
                    while (CloseStatusWindow)
                    {
                        Thread.Sleep(100);
                    }
                    status.Dispose();
                    status = null;
                }
                CloseStatusWindow = false;
            }
        }
    }
}
