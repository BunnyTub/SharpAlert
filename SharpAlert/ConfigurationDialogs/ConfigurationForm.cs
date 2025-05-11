using SharpAlert.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.IceBearWorker;
using System.Net.Http;

namespace SharpAlert
{
    public partial class ConfigurationForm : Form
    {
        //private readonly ServerConfigurationForm scf = new ServerConfigurationForm();
        private readonly AlertConfigurationForm acf = new AlertConfigurationForm();

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            DiscordWebhookURLInput.Text = Settings.Default.DiscordWebhook;
            DiscordWebhookAppendInput.Text = Settings.Default.DiscordWebhookAppend;

            if (string.IsNullOrWhiteSpace(DiscordWebhookURLInput.Text)) AlertAppearanceAndSoundsGroup.Enabled = true;
            else AlertAppearanceAndSoundsGroup.Enabled = false;

            //alertFullscreenBox.Checked = Settings.Default.alertDisplayType;
            //if (alertFullscreenBox.Checked)
            //{
            //    alertFullscreenIdleBox.Enabled = true;
            //    alertFullscreenDisplayInput.Enabled = true;
            //}
            //else
            //{
            //    alertFullscreenIdleBox.Enabled = false;
            //    alertFullscreenDisplayInput.Enabled = false;
            //}
            //alertFullscreenBox.CheckedChanged += (a, b) =>
            //{
            //    ((CheckBox)a).Enabled = false;
            //    Settings.Default.alertDisplayType = ((CheckBox)a).Checked;
            //    if (((CheckBox)a).Checked)
            //    {
            //        alertFullscreenIdleBox.Enabled = true;
            //        alertFullscreenDisplayInput.Enabled = true;
            //    }
            //    else
            //    {
            //        alertFullscreenIdleBox.Enabled = false;
            //        alertFullscreenIdleBox.Checked = false;
            //        alertFullscreenDisplayInput.Enabled = false;
            //    }
            //    Thread.Sleep(500);
            //    ((CheckBox)a).Enabled = true;
            //};

            AlertFullscreenCombo.DataSource = new ComboItem[] {
                new ComboItem
                {
                    // 0
                    FriendlyName = "Windowed",
                },
                new ComboItem
                {
                    // 1
                    FriendlyName = "Minified",
                },
                new ComboItem
                {
                    // 2
                    FriendlyName = "Full screen"
                },
                new ComboItem
                {
                    // 2
                    FriendlyName = "Full scroll"
                },
            };
            AlertFullscreenCombo.SelectedIndex = Settings.Default.alertDisplayType;
            AlertFullscreenCombo.SelectedIndexChanged += (a, b) => Settings.Default.alertDisplayType = (byte)((ComboBox)a).SelectedIndex;

            alertFullscreenWindowedBox.Checked = Settings.Default.alertTitlebarControls;
            alertFullscreenWindowedBox.CheckedChanged += (a, b) => Settings.Default.alertTitlebarControls = ((CheckBox)a).Checked;

            alertTimeoutInput.Value = Settings.Default.alertTimeout;
            alertTimeoutInput.ValueChanged += (a, b) => Settings.Default.alertTimeout = (int)((NumericUpDown)a).Value;

            alertFullscreenIdleBox.Checked = Settings.Default.alertFullscreenIdle;
            alertFullscreenIdleBox.CheckedChanged += (a, b) =>
            {
                ((CheckBox)a).Enabled = false;
                Settings.Default.alertFullscreenIdle = ((CheckBox)a).Checked;

                if (((CheckBox)a).Checked)
                {
                    CreateIdleWindow();
                }
                else
                {
                    DestroyIdleWindow();
                }

                Thread.Sleep(500);
                ((CheckBox)a).Enabled = true;

                this.BringToFront();
            };

            alertTimeZoneUTCBox.Checked = Settings.Default.alertTimeZoneUTC;
            alertTimeZoneUTCBox.CheckedChanged += (a, b) => Settings.Default.alertTimeZoneUTC = ((CheckBox)a).Checked;

            bool alertFullscreenDisplayIgnoreInput = false;
            alertFullscreenDisplayInput.Value = Settings.Default.alertFullscreenDisplay;
            alertFullscreenDisplayInput.ValueChanged += (a, b) =>
            {
                if (alertFullscreenDisplayIgnoreInput) return;

                //bool MonitorNonExistant = false

                if ((int)((NumericUpDown)a).Value >= Screen.AllScreens.Count())
                {
                    if (MessageBox.Show("The monitor you've chosen doesn't exist right now, and the idle and alert panels will be shown on the default monitor until it does exist. Do you want to use it anyway?",
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Settings.Default.alertFullscreenDisplay = (int)((NumericUpDown)a).Value;
                        //MonitorNonExistant = true;
                    }
                    else
                    {
                        alertFullscreenDisplayIgnoreInput = true;
                        ((NumericUpDown)a).Value = Settings.Default.alertFullscreenDisplay;
                        alertFullscreenDisplayIgnoreInput = false;
                        return;
                    }
                }
                else
                {
                    Screen screen = Screen.AllScreens[(int)((NumericUpDown)a).Value];

                    if (MessageBox.Show($"Use \"{screen.DeviceName}\" ({screen.Bounds.Width} x {screen.Bounds.Height})?",
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Settings.Default.alertFullscreenDisplay = (int)((NumericUpDown)a).Value;
                    }
                    else
                    {
                        alertFullscreenDisplayIgnoreInput = true;
                        ((NumericUpDown)a).Value = Settings.Default.alertFullscreenDisplay;
                        alertFullscreenDisplayIgnoreInput = false;
                        return;
                    }
                }
            };

            alertCompatibilityModeBox.Checked = Settings.Default.alertCompatibilityMode;
            alertCompatibilityModeBox.CheckedChanged += (a, b) => Settings.Default.alertCompatibilityMode = ((CheckBox)a).Checked;
            
            alertTTSonlyBox.Checked = Settings.Default.alertTTSonly;
            alertTTSonlyBox.CheckedChanged += (a, b) => Settings.Default.alertTTSonly = ((CheckBox)a).Checked;
            
            alertNoGUIBox.Checked = Settings.Default.alertNoGUI;
            alertNoGUIBox.CheckedChanged += (a, b) =>
            {
                Settings.Default.alertNoGUI = ((CheckBox)a).Checked;
                if (((CheckBox)a).Checked)
                {
                    MessageBox.Show("The console will now be opened.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                    IceBearWorker.AllocateTerminal(false);
                }
                else
                {
                    MessageBox.Show("Restart the program to hide the console.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            };

            alertIncreaseSizeBox.Checked = Settings.Default.alertIncreaseSize;
            alertIncreaseSizeBox.CheckedChanged += (a, b) => Settings.Default.alertIncreaseSize = ((CheckBox)a).Checked;

            alertNoRelayBox.Checked = Settings.Default.alertNoRelay;
            alertNoRelayBox.CheckedChanged += (a, b) => Settings.Default.alertNoRelay = ((CheckBox)a).Checked;
            
            alertPlayEndToneBox.Checked = Settings.Default.alertPlayEndTone;
            alertPlayEndToneBox.CheckedChanged += (a, b) => Settings.Default.alertPlayEndTone = ((CheckBox)a).Checked;
            
            WindowLocationCombo.DataSource = new ComboItem[] {
                new ComboItem
                {
                    // 0
                    FriendlyName = "Centered",
                },
                new ComboItem
                {
                    // 1
                    FriendlyName = "Top Left",
                },
                new ComboItem
                {
                    // 2
                    FriendlyName = "Top Right"
                },
                new ComboItem
                {
                    // 3
                    FriendlyName = "Bottom Left"
                },
                new ComboItem
                {
                    // 4
                    FriendlyName = "Bottom Right"
                },
            };
            WindowLocationCombo.SelectedIndex = Settings.Default.WindowLocation;
            WindowLocationCombo.SelectedIndexChanged += (a, b) => Settings.Default.WindowLocation = (byte)((ComboBox)a).SelectedIndex;

            volumeBar.Value = Settings.Default.alertVolume;
            volumeBar.Scroll += (a, b) => Settings.Default.alertVolume = ((TrackBar)a).Value;

            statusWindowBox.Checked = Settings.Default.statusWindow;
            statusWindowBox.CheckedChanged += (a, b) =>
            {
                ((CheckBox)a).Enabled = false;
                Settings.Default.statusWindow = ((CheckBox)a).Checked;

                if (((CheckBox)a).Checked)
                {
                    CreateStatusWindow();
                }
                else
                {
                    DestroyStatusWindow();
                }

                Thread.Sleep(500);
                ((CheckBox)a).Enabled = true;
            };

            RefreshAlertHistory();
        }

        class ComboItem
        {
            public override string ToString()
            {
                return FriendlyName;
            }

            public string FriendlyName { get; set; }
        }

        private void AlertHistoryClearButton_Click(object sender, EventArgs e)
        {
            ClearAlertHistory();
        }

        private void RefreshAlertHistory()
        {
            if (SharpDataHistory.Count != 0)
            {
                string DataHistory = string.Empty;
                foreach (var item in SharpDataHistory) DataHistory += "" + item.Name + "\r\n";
                DataHistory.Trim();
                AlertHistoryOutput.Text = DataHistory;
            }
            else
            {
                AlertHistoryOutput.Text = "There is no history available.";
            }
        }
        
        private void ClearAlertHistory()
        {
            RefreshAlertHistory();
            if (SharpDataHistory.Count != 0)
            {
                SharpDataHistory.Clear();
                SharpDataRelayedNamesHistory.Clear();
                AlertHistoryOutput.Text = "The history was cleared.";
                MessageBox.Show("The history has been cleared.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"There are no items in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void AlertHistoryRefreshButton_Click(object sender, EventArgs e)
        {
            RefreshAlertHistory();
        }

        private void AlertHistoryReplayRecentButton_Click(object sender, EventArgs e)
        {
            AlertHistoryReplayRecentButton.Enabled = false;
            Thread.Sleep(500);
            RefreshAlertHistory();
            if (SharpDataHistory.Count != 0)
            {
                var alert = SharpDataHistory.Last();
                SharpDataHistory.Remove(alert);
                if (alert.Data.Contains("<SharpAlertReplay>false</SharpAlertReplay>"))
                {
                    alert.Data = alert.Data.Replace("<SharpAlertReplay>false</SharpAlertReplay>", "<SharpAlertReplay>true</SharpAlertReplay>");
                }
                else
                {
                    alert.Data += "<SharpAlertReplay>true</SharpAlertReplay>";
                }
                SharpDataQueue.Add(alert);
            }
            else
            {
                MessageBox.Show($"There are no items in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            Thread.Sleep(500);
            AlertHistoryReplayRecentButton.Enabled = true;
        }

        private void NS_UnhideSecureBox_CheckedChanged(object sender, EventArgs e)
        {
            DiscordWebhookURLInput.UseSystemPasswordChar = ((CheckBox)sender).Checked;
            DiscordWebhookAppendInput.UseSystemPasswordChar = ((CheckBox)sender).Checked;
        }

        private void OpenCreditsButton_Click(object sender, EventArgs e)
        {
            new CreditsForm().ShowDialog();
        }

        private void SaveDiscordSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.Default.DiscordWebhook = DiscordWebhookURLInput.Text.Trim();
            Settings.Default.DiscordWebhookAppend = DiscordWebhookAppendInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(DiscordWebhookURLInput.Text)) AlertAppearanceAndSoundsGroup.Enabled = true;
            else AlertAppearanceAndSoundsGroup.Enabled = false;
        }

        private void CacheOperationButton_Click(object sender, EventArgs e)
        {
            cache.ServiceRun(false);
        }

        private void AlertHistoryDumpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SharpDataHistory.Count != 0)
            {
                string directory = AssemblyDirectory + "\\dump";
                Directory.CreateDirectory(directory);
                lock (SharpDataHistory) foreach (var item in SharpDataHistory) File.WriteAllText(directory + "\\" + item.Name + ".xml", item.Data);
                MessageBox.Show($"{SharpDataHistory.Count} item(s) saved to the dump directory.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Process.Start(AssemblyDirectory + "\\dump");
            }
            else
            {
                MessageBox.Show($"There are no items in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void BusyLock_Tick(object sender, EventArgs e)
        {
            if (AlertDisplaying)
            {
                ConfigurationPanel.Visible = false;
                BusyLockText.BringToFront();
            }
            else
            {
                ConfigurationPanel.Visible = true;
                BusyLockText.SendToBack();
            }
        }

        private void TTSButton_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Windows\\system32\\rundll32.exe", "shell32.dll,Control_RunDLL C:\\Windows\\system32\\speech\\speechux\\sapi.cpl");
            return;

            string IdentityURL = "https://bunnytub.com";
            string RemoteVersion = string.Empty;
            
            try
            {
                HttpResponseMessage latest = client.GetAsync($"{IdentityURL}/Maki/Maki.txt").Result;

                Console.WriteLine($"[Configuration Dialog | Version Request] The server responded with status code {latest.StatusCode}.");

                RemoteVersion = latest.Content.ReadAsStringAsync().Result.Trim();
                if (string.IsNullOrWhiteSpace(RemoteVersion) || RemoteVersion.Length == 0 || RemoteVersion.Length >= 10) RemoteVersion = "0";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Configuration Dialog] {ex.StackTrace} {ex.Message}");
                Console.WriteLine($"[Configuration Dialog] Couldn't work with the server.");
            }

            if (Settings.Default.MakiVersion == "0")
            {
                var result = MessageBox.Show("Maki TTS can help manage 32-bit TTS voices.\r\n" +
                "Do you want to use it when needed?",
                "SharpAlert - Download Request",
                MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        byte[] latest = client.GetByteArrayAsync($"{IdentityURL}/Maki/Maki.txt").Result;

                    }
                    catch (Exception)
                    {

                    }
                }
                //else
                //{
                //    Process.Start("C:\\Windows\\system32\\rundll32.exe", "shell32.dll,Control_RunDLL C:\\Windows\\system32\\speech\\speechux\\sapi.cpl");
                //}
            }
            else
            {
                if (RemoteVersion != "0")
                {

                }
            }

            //scf.ShowDialog();
        }

        private void AlertButton_Click(object sender, EventArgs e)
        {
            acf.ShowDialog();
        }
    }
}
