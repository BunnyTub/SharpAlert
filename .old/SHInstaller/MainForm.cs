using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SHInstaller
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        public static string AppExePath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "SharpAlert\\SharpAlert.exe");


        //C:\Users\rivera\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\SharpAlert
        public static string ShortcutDirPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Programs),
            "SharpAlert");
        
        public static string StartupShortcutDirPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup));

        private void InstallButton_Click(object sender, EventArgs e)
        {
            Enabled = false;

            bool CanInstall = false;

            using (var baseKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32))
            {
                using (var key = baseKey.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall\SharpAlert", true))
                {
                    if (key != null)
                    {
                        DialogResult result = MessageBox.Show("You have a version of SharpAlert installed on the system using the deprecated installer. You'll need to uninstall it.\r\n\r\n" +
                            "Do you want to uninstall the old version to continue?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            string Operations = string.Empty;

                            CanInstall = true;

                            try
                            {
                                File.Delete(ShortcutDirPath + "\\SharpAlert.lnk");
                            }
                            catch (Exception ex)
                            {
                                Operations += $"\r\nCouldn't remove the startup file. {ex.Message} (Ignore if you didn't have one!)";
                            }
                            
                            try
                            {
                                Directory.Delete("C:\\Program Files (x86)\\SharpAlert", true);
                            }
                            catch (Exception ex)
                            {
                                Operations += $"\r\nCouldn't remove the SharpAlert folder. {ex.Message}";
                            }
                            
                            try
                            {
                                using (var parent = baseKey.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall", true))
                                {
                                    parent?.DeleteSubKeyTree("SharpAlert", throwOnMissingSubKey: false);
                                }
                            }
                            catch (Exception ex)
                            {
                                Operations += $"\r\nCouldn't remove the SharpAlert registry data. {ex.Message}";
                            }
                            // remove program files link, and remove shortcut on startup

                            MessageBox.Show($"Tried uninstalling the old version.{Operations}", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else CanInstall = true;
                }
            }

            if (!CanInstall)
            {
                MessageBox.Show("You must uninstall the older version to continue.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Environment.Exit(0);
            }

            Directory.CreateDirectory(Path.GetDirectoryName(AppExePath));

            File.WriteAllBytes(AppExePath, Properties.Resources.SharpAlert);

            //if (!Directory.Exists(linkPath))
            //    Directory.CreateDirectory(linkPath);

            //string linkName = Path.ChangeExtension(Path.GetFileName(filename), ".lnk");

            IWshRuntimeLibrary.WshShell shell = new IWshRuntimeLibrary.WshShell();
            IWshRuntimeLibrary.IWshShortcut sc = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(ShortcutDirPath + "\\SharpAlert.lnk");
            sc.Description = "Get alerts easy.";
            //shortcut.IconLocation = @"C:\..."; 
            sc.TargetPath = AppExePath;
            sc.RelativePath = "SharpAlert";
            sc.Save();

            if (RunAtStartupBox.Checked)
            {
                IWshRuntimeLibrary.IWshShortcut ssc = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(StartupShortcutDirPath + "\\SharpAlert.lnk");
                ssc.Description = "Get alerts easy.";
                //shortcut.IconLocation = @"C:\..."; 
                ssc.TargetPath = AppExePath;
                ssc.RelativePath = "SharpAlert";
                ssc.Save();
            }

            //Properties.Resources.SharpAlert = AppDirPath;

            MessageBox.Show("Installed.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(AppExePath);
            Environment.Exit(0);

            Enabled = true;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void UninstallButton_Click(object sender, EventArgs e)
        {
            foreach (Process process in Process.GetProcessesByName("SharpAlert"))
            {
                process.Kill();
            }

            string Operations = string.Empty;

            try
            {
                File.Delete(ShortcutDirPath + "\\SharpAlert.lnk");
            }
            catch (Exception ex)
            {
                Operations += $"\r\nCouldn't remove the shortcut file. {ex.Message}";
            }
            
            try
            {
                File.Delete(StartupShortcutDirPath + "\\SharpAlert.lnk");
            }
            catch (Exception ex)
            {
                Operations += $"\r\nCouldn't remove the startup file. {ex.Message} (Ignore if you didn't have one!)";
            }

            try
            {
                Directory.Delete(Path.GetDirectoryName(AppExePath), true);
            }
            catch (DirectoryNotFoundException ex)
            {
                Operations += $"\r\nTo the contrary, it doesn't seem like SharpAlert was ever installed (properly) in the first place... {ex.Message}";
            }
            catch (Exception ex)
            {
                Operations += $"\r\nCouldn't remove the SharpAlert folder. {ex.Message}";
            }

            MessageBox.Show($"Uninstalled.{Operations}", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
