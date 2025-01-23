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
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.RegexList;
using Amazon.Polly;
using Amazon.Polly.Model;
using System.Speech.Synthesis;

namespace SharpAlert
{
    internal static class VersionInfo
    {
        public static readonly int MajorVersion = 2;
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
        public static FeedCapture feed;
        public static CacheCapture cache;
        public static DataProcessor processor;
        public static SoundPlayer sound;
        public static SoundPlayer soundFinish;
        public static TeleIdleForm idle;
        public static bool CloseIdleWindow = false;
        public static object IdleWindowLock = new object();
        //public static UnmanagedMemoryStream unmanagedAudioStream;
        //public static MemoryStream memoryAudioStream;
        //public static WaveStream wav;
        public static NotifyIcon notify;
        public static SpeechSynthesizer engine;
        public static object AlertValuesLock = new object();
        public static bool AlertDisplaying = false;

        public static List<SharpDataItem> SharpDataQueue = new List<SharpDataItem>();
        public static List<SharpDataItem> SharpDataHistory = new List<SharpDataItem>();

        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return Path.GetDirectoryName(path);
            }
        }
        
        public static string AssemblyFile
        {
            get
            {
                return Assembly.GetExecutingAssembly().Location;
            }
        }

        public static string[] args;
        public static Icon icon = SystemIcons.Information;

        /// <summary>
        /// Closes everything safely.
        /// </summary>
        public static void SafeExit(int exitCode)
        {
            //if (notify != null)
            //{
            //    ContextMenuStrip messageStrip = new ContextMenuStrip();
            //    messageStrip.Items.Add(new ToolStripLabel($"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}",
            //    Resources.AlertIcon));
            //    messageStrip.Items.Add(new ToolStripMenuItem("Emergency Quit", null, (sender, arg) =>
            //    {
            //        Environment.FailFast("The user forcefully quit the program.");
            //    }));
            //    notify.ContextMenuStrip = messageStrip;
            //}
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
            Console.WriteLine("Stopping sounds.");
            sound?.Stop();
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
            } else Thread.Sleep(5000);
            Environment.Exit(exitCode);
        }

        /// <summary>
        /// Starts everything.
        /// </summary>
        [MTAThread]
        public static void Main()
        {
            args = Environment.GetCommandLineArgs();
            Application.EnableVisualStyles();

            if (args.Length == 2)
            {
                if (args[1] == "--console")
                {
                    AllocateTerminal(false);
                }
            }

            Console.WriteLine($"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MajorVersion}");

            try
            {
                icon = Icon.ExtractAssociatedIcon(AssemblyFile);
            }
            catch (Exception)
            {
            }
            
            Console.WriteLine("Ice Bear is initializing services.");

            feed = new FeedCapture();
            cache = new CacheCapture();
            processor = new DataProcessor();
            sound = new SoundPlayer(Resources.ui_warning);
            soundFinish = new SoundPlayer(Resources.ui_end);
            engine = new SpeechSynthesizer()
            {
                //Volume = 80
                Volume = 80
            };

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

            Console.WriteLine("Ice Bear will be starting services momentarily.");

            Thread feedThread = new Thread(() => feed.ServiceRun(true));
            feedThread.SetApartmentState(ApartmentState.MTA);
            //feed.server = $"apps.fema.gov/IPAWSOPEN_EAS_SERVICE/rest/PublicWEA/recent/{DateTime.UtcNow.AddMonths(-1):yyyy-MM-ddTHH:mm:ssZ}";
            feed.server = $"apps.fema.gov/IPAWSOPEN_EAS_SERVICE/rest/eas/recent/{DateTime.UtcNow.AddDays(-1):yyyy-MM-ddTHH:mm:ssZ}";
            feedThread.Start();
            
            Thread cacheThread = new Thread(() => cache.ServiceRun(true));
            cacheThread.SetApartmentState(ApartmentState.MTA);
            cacheThread.Start();

            Thread processorThread = new Thread(() => processor.ServiceRun());
            processorThread.SetApartmentState(ApartmentState.MTA);
            processorThread.Start();

            // Keyboard Processor will not be available any further due to stopping problems.
            //Thread keyboardThread = new Thread(() => KeyboardProcessor.ServiceRun());
            //keyboardThread.SetApartmentState(ApartmentState.MTA);
            //keyboardThread.Start();

            if (Settings.Default.alertFullscreenIdle)
            {
                CreateIdleWindow();
            }

            CreateNotifyIcon();
            Application.Run();
        }

        public static bool NotifyIconCalled { get; private set; }
        public static List<string> ChangedPropertiesList = new List<string>();
        public static bool IgnoreRightClick = false;

        /// <summary>
        /// Creates a tray icon. Throws NotSupportedException if called more than once.
        /// </summary>
        /// <exception cref="NotSupportedException"></exception>
        private static void CreateNotifyIcon()
        {
            if (NotifyIconCalled) throw new NotSupportedException();
            NotifyIconCalled = true;

            if (args.Length == 2)
            {
                if (args[1] == "--no-tray")
                {
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        AltTrayForm tray = new AltTrayForm();
                        tray.ShowDialog();
                        Environment.Exit(0);
                    });
                    return;
                }
            }

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
                        "Only ever use this feature as a last resort.";

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

                if (IgnoreRightClick)
                {
                    b.Cancel = true;
                    while (MessageBox.Show("Please close all windows before trying again.\r\n" +
                        "If there are none open, hold SHIFT before right-clicking.",
                        "SharpAlert",
                        MessageBoxButtons.RetryCancel) == DialogResult.Retry)
                    {
                        if (!IgnoreRightClick)
                        {
                            b.Cancel = false;
                            break;
                        }
                    }
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

            StatusForm sf = null;

            contextMenu.Items.Add(new ToolStripMenuItem("Open Status", null, (sender, arg) =>
            {
                if (sf != null)
                {
                    if (!sf.IsDisposed)
                    {
                        sf.Close();
                    }
                }
                else
                {
                    ThreadPool.QueueUserWorkItem(_ =>
                    {
                        sf = new StatusForm();
                        sf.ShowDialog();
                    });
                }
            }));

            contextMenu.Items.Add(new ToolStripSeparator());

            contextMenu.Items.Add(new ToolStripMenuItem("Quit", null, (sender, arg) =>
            {
                if (AlertDisplaying)
                {
                    MessageBox.Show("There is an alert in progress.\r\n" +
                        "Please let all alerts finish before trying again.\r\n\r\n" +
                        "If you want to bypass this, hold SHIFT before opening the tray icon.");
                    return;
                }

                if (MessageBox.Show("Do you want to quit?\r\n" +
                    "You won't receive any alerts while the program is stopped.\r\n\r\n" +
                    "Your settings will be automatically saved.",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Settings.Default.Save();
                    SafeExit(0);
                }
            }));

            notify.ContextMenuStrip = contextMenu;
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

        /// <summary>
        /// Returns an MD5 value of the input string.
        /// </summary>
        /// <param name="input">The string to produce an MD5 from.</param>
        /// <returns></returns>
        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
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
    }
}
