using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Speech.Synthesis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SharpAlert.Program;
using static SharpAlert.RegexList;

namespace SharpAlert
{
    public static class IceBearWorker
    {
        private static readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(15)
        };

        /// <summary>
        /// Starts the Ice Bear Worker as a client.
        /// </summary>
        [MTAThread]
        public static void ServiceRun()
        {
            args = Environment.GetCommandLineArgs();

            if (args.Length == 2) if (args[1] == "--console") AllocateTerminal(false);

            Console.WriteLine($"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} | Safety is never a non-priority. | https://sharpalert.bunnytub.com/");

            client.DefaultRequestHeaders.UserAgent.ParseAdd($"Mozilla/5.0 (compatible; SharpAlert)");
            Application.EnableVisualStyles();

            try
            {
                icon = Icon.ExtractAssociatedIcon(AssemblyFile);
            }
            catch (Exception)
            {
            }

            string CreateMD5FromCurrent()
            {
                MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
                FileStream stream = new FileStream(AssemblyFile, FileMode.Open, FileAccess.Read);

                md5.ComputeHash(stream);

                stream.Close();

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < md5.Hash.Length; i++)
                    sb.Append(md5.Hash[i].ToString("x2"));

                return sb.ToString().ToUpperInvariant();
            }

            Console.WriteLine("[Ice Bear] Checking application identity.");

            string IdentityURL = "https://bunnytub.com";

            try
            {
                string LocalMD5 = CreateMD5FromCurrent();
                Console.WriteLine($"[Ice Bear] MD5 (local): {LocalMD5}");
                
                Task<HttpResponseMessage> message = client.GetAsync($"{IdentityURL}/SharpAlert/Releases/v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}/MD5.txt");
                if (!message.Wait(10000))
                {
                    throw new TimeoutException();
                }
                
                Console.WriteLine($"[Ice Bear | MD5 Request] The identity server responded with status code {message.Result.StatusCode}.");

                Task<HttpResponseMessage> latest = client.GetAsync($"{IdentityURL}/SharpAlert/SharpAlert.txt");
                if (!latest.Wait(10000))
                {
                    throw new TimeoutException();
                }

                Console.WriteLine($"[Ice Bear | Version Request] The identity server responded with status code {latest.Result.StatusCode}.");

                string RemoteMD5 = string.Empty;
                RemoteMD5 = message.Result.Content.ReadAsStringAsync().Result.Trim().ToUpperInvariant();
                if (string.IsNullOrWhiteSpace(RemoteMD5) || RemoteMD5.Length == 0 || RemoteMD5.Length >= 100) RemoteMD5 = "UNKNOWN";
                
                string RemoteVersion = string.Empty;
                RemoteVersion = latest.Result.Content.ReadAsStringAsync().Result.Trim();
                if (string.IsNullOrWhiteSpace(RemoteVersion) || RemoteVersion.Length == 0 || RemoteVersion.Length >= 10) RemoteVersion = "0.0";

                // implement auto-update

                if (LocalMD5 == RemoteMD5)
                {
                    Console.WriteLine("[Ice Bear] You are using the latest version of SharpAlert.");
                }
                else
                {
                    Console.WriteLine($"[Ice Bear] You may be using an older (or modified) version of SharpAlert. v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} =< v{RemoteVersion}");
                    Console.WriteLine($"[Ice Bear] See https://sharpalert.bunnytub.com/ for downloads.");
                }

                Console.WriteLine($"[Ice Bear] MD5 (remote): {RemoteMD5}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Ice Bear] {ex.StackTrace} {ex.Message}");
                Console.WriteLine($"[Ice Bear] Couldn't work with the identity server.");
            }

            Console.WriteLine("[Ice Bear] Initializing services.");

            feed = new FeedCapture();
            cache = new CacheCapture();
            processor = new DataProcessor();
            sound = new SoundPlayer(Resources.ui_warning);
            soundCancellation = new SoundPlayer(Resources.ui_cancellation);
            soundFinish = new SoundPlayer(Resources.ui_end);
            engine = new SpeechSynthesizer();

            engine.SpeakCompleted += (objective, eventArgs) =>
            {
                soundFinish.Play();
            };

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
                    Console.WriteLine("[Ice Bear] Runner type is \"Standard\".");
                    feed.server = $"apps.fema.gov/IPAWSOPEN_EAS_SERVICE/rest/eas/recent/{DateTime.UtcNow.AddDays(-30):yyyy-MM-ddTHH:mm:ssZ}";
                    break;
                case 1:
                    Console.WriteLine("[Ice Bear] Runner type is \"Server\".");
                    ServerServiceRun();
                    return;
                case 2:
                    Console.WriteLine("[Ice Bear] Runner type is \"Client\".");
                    UseHTTPS = false;
                    feed.server = $"{Settings.Default.ClientServerURL}:9792{DateTime.UtcNow.AddDays(-1):yyyy-MM-ddTHH:mm:ssZ}";
                    break;
            }

            Console.WriteLine("[Ice Bear] Starting services momentarily.");

            //if (args.Length == 3)
            //{
            //    if (args[1] == "--host")
            //    {
            //        feed.server = $"{args[2]}:9792";
            //        UseHTTPS = false;
            //    }
            //}
            //else
            //{
            //    feed.server = $"apps.fema.gov/IPAWSOPEN_EAS_SERVICE/rest/eas/recent/{DateTime.UtcNow.AddDays(-1):yyyy-MM-ddTHH:mm:ssZ}";
            //}

            Thread feedThread = ReturnThreadWithCatch(() => feed.ServiceRun(UseHTTPS));
            feedThread.SetApartmentState(ApartmentState.MTA);
            //feed.server = $"apps.fema.gov/IPAWSOPEN_EAS_SERVICE/rest/PublicWEA/recent/{DateTime.UtcNow.AddMonths(-1):yyyy-MM-ddTHH:mm:ssZ}";
            feedThread.MonitorAndStart("Feed Capture");

            Thread cacheThread = ReturnThreadWithCatch(() => cache.ServiceRun(true));
            cacheThread.SetApartmentState(ApartmentState.MTA);
            cacheThread.MonitorAndStart("Cache Capture");

            Thread processorThread = ReturnThreadWithCatch(() => processor.ServiceRun());
            processorThread.SetApartmentState(ApartmentState.MTA);
            processorThread.MonitorAndStart("Data Processor");

            if (Settings.Default.statusWindow)
            {
                CreateStatusWindow();
            }

            if (Settings.Default.alertFullscreenIdle)
            {
                CreateIdleWindow();
            }

            Thread notificationThread = ReturnThreadWithCatch(() =>
            {
                CreateNotifyIcon();
                Application.Run();
            });
            notificationThread.MonitorAndStart("Notification Tray");
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

            Thread feedThread = ReturnThreadWithCatch(() => feed.ServerServiceRun(true));
            feedThread.SetApartmentState(ApartmentState.MTA);
            feedThread.MonitorAndStart("Feed Capture");

            listener.Start();
            CreateStatusWindow();

            Console.WriteLine("[Ice Bear] Listening for requests.");

            while (true)
            {
                Console.WriteLine("[Ice Bear] Waiting for the next request.");
                HttpListenerContext context = listener.GetContext();

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    var request = context.Request;
                    Console.WriteLine($"[Ice Bear] Sending data ({request.UserAgent} | {request.RemoteEndPoint.Address}).");

                    if (request.HttpMethod.ToUpper() == "GET")
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

        private static void MonitorAndStart(this Thread thread, string FriendlyName)
        {
            Thread sub = new Thread(() =>
            {
                while (AllowThreadRestarts)
                {
                    thread.Start();
                    Console.WriteLine($"[Ice Bear] {FriendlyName} started.");
                    while (thread.IsAlive) Thread.Sleep(500);
                    Console.WriteLine($"[Ice Bear] {FriendlyName} exited.");
                    Thread.Sleep(500);
                }
                Console.WriteLine($"[Ice Bear] Thread handling for {FriendlyName} is stopping.");
            });
            sub.Start();
        }

        /// <summary>
        /// Acts as a layer for creating a Thread. The original intended code is run, but any exceptions are caught if they occur.
        /// </summary>
        /// <param name="action"></param>
        /// <returns>Try-catch Thread</returns>
        private static Thread ReturnThreadWithCatch(Action action)
        {
            return new Thread(() =>
            {
                try
                {
                    action.Invoke();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("SharpAlert has crashed!\r\n" +
                        $"{ex.StackTrace}\r\n" +
                        $"{ex.Message}",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    Environment.FailFast("SharpAlert has crashed!\r\n" +
                        $"{ex.StackTrace}\r\n" +
                        $"{ex.Message}");
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
        private static void CreateNotifyIcon()
        {
            if (NotifyIconCalled) throw new NotSupportedException();
            NotifyIconCalled = true;

            notify = new NotifyIcon
            {
                Icon = Icon.ExtractAssociatedIcon(AssemblyFile),
                Visible = true,
                Text = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}"
            };

            //Settings.Default.PropertyChanged

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

                if (Control.ModifierKeys == Keys.ControlKey)
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

            //new ToolStripMenuItem("[Advanced] Force Quit", null, (sender, arg) =>
            //{
            //    // hide via name iteration

            //    string ForceQuitMsg;

            //    if (ChangedPropertiesList.Count == 0)
            //    {
            //        ForceQuitMsg = "Are you sure you want to force quit?\r\n" +
            //        "You won't receive any alerts while the program is stopped.\r\n";
            //    }
            //    else
            //    {
            //        ForceQuitMsg = "Are you sure you want to force quit?\r\n" +
            //        "You won't receive any alerts while the program is stopped.\r\n\r\n" +
            //        "You have unsaved changes that will be lost if you continue.";
            //    }

            //    if (MessageBox.Show(ForceQuitMsg,
            //        "SharpAlert",
            //        MessageBoxButtons.YesNo,
            //        MessageBoxIcon.Warning) == DialogResult.Yes)
            //    {
            //        Environment.Exit(0);
            //    }
            //});

            //var boolProperties = typeof(Settings).GetProperties()
            //    .Where(p => p.PropertyType == typeof(bool));

            //foreach (var property in boolProperties)
            //{
            //    if (property.Name != "IsSynchronized")
            //    {
            //        DescriptionAttribute descriptionAttribute = property.GetCustomAttribute<DescriptionAttribute>();
            //        string description = descriptionAttribute?.Description ?? "The description is unavailable for this item.";
            //        contextMenu.Items.Add(CreateBoolMenuItem(property, description));
            //    }
            //}

            //var stringProperties = typeof(Settings).GetProperties()
            //    .Where(p => p.PropertyType == typeof(string));

            //foreach (var property in stringProperties)
            //{
            //    if (property.Name != "SettingsKey")
            //    {
            //        DescriptionAttribute descriptionAttribute = property.GetCustomAttribute<DescriptionAttribute>();
            //        string description = descriptionAttribute?.Description ?? "The description is unavailable for this item.";
            //        contextMenu.Items.Add(new ToolStripLabel($"{property.Name} (No ENTER needed):")
            //        {
            //            ToolTipText = description,
            //            AutoToolTip = false
            //        });
            //        contextMenu.Items.Add(CreateStringMenuItem(property, description));
            //    }
            //}

            //var stringCollectionProperties = typeof(Settings).GetProperties()
            //    .Where(p => p.PropertyType == typeof(StringCollection));

            //foreach (var property in stringCollectionProperties)
            //{
            //    DescriptionAttribute descriptionAttribute = property.GetCustomAttribute<DescriptionAttribute>();
            //    string description = descriptionAttribute?.Description ?? "The description is unavailable for this item.";
            //    contextMenu.Items.Add(new ToolStripLabel($"{property.Name} (ENTER to separate):")
            //    {
            //        ToolTipText = description,
            //        AutoToolTip = false
            //    });
            //    contextMenu.Items.Add(CreateStringCollectionMenuItem(property, description));
            //}

            //var integerProperties = typeof(Settings).GetProperties()
            //    .Where(p => p.PropertyType == typeof(int));

            //foreach (var property in integerProperties)
            //{
            //    DescriptionAttribute descriptionAttribute = property.GetCustomAttribute<DescriptionAttribute>();
            //    string description = descriptionAttribute?.Description ?? "The description is unavailable for this item.";
            //    contextMenu.Items.Add(new ToolStripLabel($"{property.Name}:")
            //    {
            //        ToolTipText = description,
            //        AutoToolTip = false
            //    });
            //    contextMenu.Items.Add(CreateIntegerMenuItem(property, description));
            //}

            //contextMenu.Items.Add(new ToolStripSeparator());

            contextMenu.Items.Add(new ToolStripMenuItem("Show Console", null, (sender, arg) =>
            {
                IgnoreRightClick = true;
                if (MessageBox.Show("Are you sure you want to show the console?\r\n" +
                    "Closing the console will terminate the program.",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
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

            contextMenu.Items.Add(new ToolStripSeparator());

            contextMenu.Items.Add(new ToolStripLabel($"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}",
                Resources.AlertIcon, true, (obj, args) =>
                {
                    Process.Start("https://github.com/BunnyTub");
                })
            {
                ToolTipText = "Very mindful, very demure."
            });

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
                    "SharpAlert will start shutting down now if you continue.",
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

            //StatusForm sf = null;

            //contextMenu.Items.Add(new ToolStripMenuItem("Open Status", null, (sender, arg) =>
            //{
            //    if (sf != null)
            //    {
            //        if (!sf.IsDisposed)
            //        {
            //            sf.Close();
            //        }
            //    }

            //    ThreadPool.QueueUserWorkItem(_ =>
            //    {
            //        sf = new StatusForm();
            //        sf.ShowDialog();
            //    });
            //}));

            //contextMenu.Items.Add(new ToolStripSeparator());

            contextMenu.Items.Add(new ToolStripMenuItem("Quit", null, (sender, arg) =>
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

                if (MessageBox.Show("Do you want to quit?\r\n" +
                    "You won't receive any alerts while the program is stopped.\r\n\r\n" +
                    "Your settings will be saved automatically.",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Settings.Default.Save();
                    SafeExit(0);
                }
            }));

            notify.ContextMenuStrip = contextMenu;

            notify.BalloonTipTitle = "SharpAlert is running";
            notify.BalloonTipText = "I'll be down in my tray, waiting for alerts!";
            notify.BalloonTipIcon = ToolTipIcon.Info;
            notify.ShowBalloonTip(5000);
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

        public static void AllocateTerminal(bool Popups = true)
        {
            if (!AllocConsole())
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

                SetStdHandle(STD_OUTPUT_HANDLE, consoleHandle);
                var writer = new StreamWriter(Console.OpenStandardOutput())
                {
                    AutoFlush = true
                };
                Console.SetOut(writer);
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
        /// ("The CLR has been unable to transition" is just a debugger warning!)
        /// </summary>
        public static void AddFileToQueue()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Thread staThread = new Thread(() =>
                {
                    try
                    {
                        Console.WriteLine("Opening file picker.");

                        string selectedPath = string.Empty;
                        string selectedSafePath = string.Empty;

                        OpenFileDialog fbd = new OpenFileDialog
                        {
                            Filter = "Common Alerting Protocol files (*.xml, *.cap)|*.xml;*.cap",
                            FilterIndex = 0,
                            CheckFileExists = true,
                            Multiselect = false
                        };

                        if (fbd.ShowDialog() != DialogResult.OK)
                        {
                            Console.WriteLine("No file chosen.");
                            return;
                        }

                        selectedPath = fbd.FileName;
                        selectedSafePath = fbd.SafeFileName;
                        fbd.Dispose();

                        if (string.IsNullOrEmpty(selectedPath)) return;

                        try
                        {
                            string data = File.ReadAllText(selectedPath);

                            MatchCollection alertMatches = AlertRegex.Matches(data);
                            int alertIndex = 0;

                            foreach (Match alert in alertMatches)
                            {
                                alertIndex++;

                                string filename = CreateMD5(alert.Value);

                                Console.WriteLine($"[File Picker] {alertIndex} -> {filename}");

                                if (SharpDataQueue.Any(x => x.Name == filename) || SharpDataHistory.Any(x => x.Name == filename))
                                {
                                    Console.WriteLine($"[File Picker] Alert {alertIndex} has been discarded (already queued or is in history).");
                                }
                                else
                                {
                                    lock (SharpDataQueue) SharpDataQueue.Add(new SharpDataItem(filename, alert.Value));
                                    Console.WriteLine($"[File Picker] Alert {alertIndex} has been saved for processing.");
                                }
                            }

                            Console.WriteLine($"[File Picker] {alertIndex} alert(s) checked.");
                            Console.WriteLine("Added file to queue.");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
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
            });
        }

#pragma warning disable IDE0051 // Remove unused private members
        private static ToolStripMenuItem CreateBoolMenuItem(PropertyInfo property, string description)
        {
            string propertyName = property.Name;

            ToolStripMenuItem menuItem = new ToolStripMenuItem(propertyName)
            {
                CheckOnClick = true,
                Checked = (bool)property.GetValue(Settings.Default),
                ToolTipText = description,
                AutoToolTip = false
            };

            menuItem.CheckedChanged += (sender, args) =>
            {
                if (sender is ToolStripMenuItem item)
                {
                    bool isChecked = item.Checked;
                    property.SetValue(Settings.Default, isChecked);
                    //Settings.Default.Save();
                    Console.WriteLine($"{propertyName} set to {isChecked}");
                }
            };

            menuItem.Tag = "config";
            return menuItem;
        }

        private static ToolStripTextBox CreateStringMenuItem(PropertyInfo property, string description)
        {
            string propertyName = property.Name;

            ToolStripTextBox menuItem = new ToolStripTextBox(propertyName)
            {
                Text = (string)property.GetValue(Settings.Default),
                ToolTipText = description,
                BorderStyle = BorderStyle.FixedSingle
            };

            menuItem.TextChanged += (sender, args) =>
            {
                if (sender is ToolStripTextBox item)
                {
                    string setString = item.Text;
                    property.SetValue(Settings.Default, setString);
                    //Settings.Default.Save();
                    Console.WriteLine($"{propertyName} set to {setString}");
                }
            };

            menuItem.Tag = "config";
            return menuItem;
        }

        private static ToolStripTextBox CreateStringCollectionMenuItem(PropertyInfo property, string description)
        {
            string propertyName = property.Name;
            string propertyValue = string.Empty;

            foreach (string strItem in (StringCollection)property.GetValue(Settings.Default))
            {
                propertyValue += strItem + "\n";
            }

            ToolStripTextBox menuItem = new ToolStripTextBox(propertyName)
            {
                Text = propertyValue,
                ToolTipText = description,
                AcceptsReturn = true,
                AcceptsTab = false,
                BorderStyle = BorderStyle.FixedSingle
            };

            menuItem.TextChanged += (sender, args) =>
            {
                if (sender is ToolStripTextBox item)
                {
                    StringCollection setString = new StringCollection();
                    if (!string.IsNullOrWhiteSpace(item.Text))
                        setString.AddRange(item.Text.Replace("\r", string.Empty).Split('\n'));
                    else setString.Clear();

                    property.SetValue(Settings.Default, setString);
                    //Settings.Default.Save();
                    Console.WriteLine($"{propertyName} set to {setString}");
                }
            };

            menuItem.Tag = "config";
            return menuItem;
        }

        private static ToolStripControlHost CreateIntegerMenuItem(PropertyInfo property, string description)
        {
            string propertyName = property.Name;
            int propertyValue = (int)property.GetValue(Settings.Default);

            NumericUpDown numericUpDown = new NumericUpDown
            {
                Value = propertyValue,
                Minimum = 10,
                Maximum = 300,
                DecimalPlaces = 0,
                Increment = 5,
            };

            numericUpDown.ValueChanged += (sender, args) =>
            {
                if (sender is NumericUpDown control)
                {
                    int newValue = (int)control.Value;
                    property.SetValue(Settings.Default, newValue);
                    //Settings.Default.Save();
                    Console.WriteLine($"{propertyName} set to {newValue}");
                }
            };

            ToolStripControlHost menuItem = new ToolStripControlHost(numericUpDown)
            {
                ToolTipText = description,
                Tag = "config"
            };

            return menuItem;
        }
#pragma warning restore IDE0051 // Remove unused private members
    }
}
