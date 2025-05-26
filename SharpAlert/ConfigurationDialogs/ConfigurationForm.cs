using SharpAlert.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.IceBearWorker;
using static SharpAlert.AudioManager;
using System.Drawing;

namespace SharpAlert
{
    public partial class ConfigurationForm : Form
    {
        //private readonly ServerConfigurationForm scf = new ServerConfigurationForm();

        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private bool Initialized = false;

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            if (Initialized) return;
            Initialized = true;

            lock (notify)
            {
                notify.BalloonTipTitle = "SharpAlert is initializing Settings";
                notify.BalloonTipText = "Settings is getting ready to be shown. This may take a few moments.";
                notify.BalloonTipIcon = ToolTipIcon.Info;
                notify.ShowBalloonTip(5000);
            }

            DiscordWebhookURLInput.Text = Settings.Default.DiscordWebhook;
            DiscordWebhookAppendInput.Text = Settings.Default.DiscordWebhookAppend;
            DiscordWebhookConfirmAlertsBox.Checked = Settings.Default.DiscordWebhookConfirmAlerts;
            DiscordWebhookConfirmAlertsBox.CheckedChanged += (a, b) => Settings.Default.DiscordWebhookConfirmAlerts = ((CheckBox)a).Checked;
            DiscordWebhookRelayLocallyBox.Checked = Settings.Default.DiscordWebhookRelayLocally;
            DiscordWebhookRelayLocallyBox.CheckedChanged += (a, b) =>
            {
                Settings.Default.DiscordWebhookRelayLocally = ((CheckBox)a).Checked;
                if (!((CheckBox)a).Checked)
                {
                    if (string.IsNullOrWhiteSpace(DiscordWebhookURLInput.Text)) AlertAppearanceAndSoundsGroup.Enabled = true;
                    else AlertAppearanceAndSoundsGroup.Enabled = false;
                }
                else
                {
                    AlertAppearanceAndSoundsGroup.Enabled = true;
                }
            };

            if (!DiscordWebhookRelayLocallyBox.Checked)
            {
                if (string.IsNullOrWhiteSpace(DiscordWebhookURLInput.Text)) AlertAppearanceAndSoundsGroup.Enabled = true;
                else AlertAppearanceAndSoundsGroup.Enabled = false;
            }

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

            DisableDialogsBox.Checked = Settings.Default.DisableDialogs;
            DisableDialogsBox.CheckedChanged += (a, b) => Settings.Default.DisableDialogs = ((CheckBox)a).Checked;
            
            alertNoRelayBox.Checked = Settings.Default.alertNoRelay;
            alertNoRelayBox.CheckedChanged += (a, b) => Settings.Default.alertNoRelay = ((CheckBox)a).Checked;
            
            alertPlayEndToneBox.Checked = Settings.Default.alertPlayEndTone;
            alertPlayEndToneBox.CheckedChanged += (a, b) => Settings.Default.alertPlayEndTone = ((CheckBox)a).Checked;

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

            AudioDeviceCombo.Items.Clear();

            lock (AudioDevicesList)
            {
                foreach (var device in AudioDevicesList)
                {
                    AudioDeviceCombo.Items.Add(device.FriendlyName);
                }
            }

            AudioDeviceCombo.SelectedItem = Settings.Default.ProgramAudioOutput;

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
                foreach (var item in SharpDataHistory)
                {
                    DataHistory = $"{item.Name}\r\n{DataHistory}";
                }
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
            SaveDiscordSettingsButton.BackColor = Color.FromArgb(60, 60, 60);

            Settings.Default.DiscordWebhook = DiscordWebhookURLInput.Text.Trim();
            Settings.Default.DiscordWebhookAppend = DiscordWebhookAppendInput.Text.Trim();

            if (!Settings.Default.DiscordWebhookRelayLocally)
            {
                if (string.IsNullOrWhiteSpace(DiscordWebhookURLInput.Text)) AlertAppearanceAndSoundsGroup.Enabled = true;
                else AlertAppearanceAndSoundsGroup.Enabled = false;
            }
            else
            {
                AlertAppearanceAndSoundsGroup.Enabled = true;
            }
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
                lock (SharpDataHistory)
                {
                    foreach (var item in SharpDataHistory)
                    {
                        string name = item.Name;
                        // some names relayed love having illegal filepath characters
                        // this is the best fix I can think of, other than just using an MD5 of the data
                        name = string.Join("_", name.Split(Path.GetInvalidFileNameChars()));
                        File.WriteAllText(directory + "\\" + name + ".xml", item.Data);
                    }
                }
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

            // This will not be ready for production. I don't think I'm even gonna keep working on Maki for now.

            //string IdentityURL = "https://bunnytub.com";
            //string RemoteVersion = string.Empty;
            
            //try
            //{
            //    HttpResponseMessage latest = client.GetAsync($"{IdentityURL}/Maki/Maki.txt").Result;

            //    Console.WriteLine($"[Configuration Dialog | Version Request] The server responded with status code {latest.StatusCode}.");

            //    RemoteVersion = latest.Content.ReadAsStringAsync().Result.Trim();
            //    if (string.IsNullOrWhiteSpace(RemoteVersion) || RemoteVersion.Length == 0 || RemoteVersion.Length >= 10) RemoteVersion = "0";
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"[Configuration Dialog] {ex.StackTrace} {ex.Message}");
            //    Console.WriteLine($"[Configuration Dialog] Couldn't work with the server.");
            //}

            //if (Settings.Default.MakiVersion == "0")
            //{
            //    var result = MessageBox.Show("Maki TTS can help manage 32-bit TTS voices.\r\n" +
            //    "Do you want to use it when needed?",
            //    "SharpAlert - Download Request",
            //    MessageBoxButtons.YesNo);

            //    if (result == DialogResult.Yes)
            //    {
            //        try
            //        {
            //            byte[] latest = client.GetByteArrayAsync($"{IdentityURL}/Maki/Maki.txt").Result;

            //        }
            //        catch (Exception)
            //        {

            //        }
            //    }
            //    //else
            //    //{
            //    //    Process.Start("C:\\Windows\\system32\\rundll32.exe", "shell32.dll,Control_RunDLL C:\\Windows\\system32\\speech\\speechux\\sapi.cpl");
            //    //}
            //}
            //else
            //{
            //    if (RemoteVersion != "0")
            //    {

            //    }
            //}

            //scf.ShowDialog();
        }


        private void PlayTestButton_Click(object sender, EventArgs e)
        {
            dataproc?.ap?.ProcessAlertTest();
        }

        private void ImportFileButton_Click(object sender, EventArgs e)
        {
            AddFileToQueue();
        }

        private AlertConfigurationForm acf = null;

        private void AlertButton_Click(object sender, EventArgs e)
        {
            if (acf == null || acf.IsDisposed) acf = new AlertConfigurationForm();
            acf.ShowDialog();
        }

        private ChooseRegionForm crf = null;

        private void RegionButton_Click(object sender, EventArgs e)
        {
            if (crf == null || crf.IsDisposed) crf = new ChooseRegionForm(false);
            crf.ShowDialog();
            MessageBox.Show("Restart the program to apply region changes.",
                "SharpAlert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        ChooseStyleForm csf = null;

        private void StyleButton_Click(object sender, EventArgs e)
        {
            if (csf == null || csf.IsDisposed) csf = new ChooseStyleForm(false);
            csf.ShowDialog();
        }

        private void DiscordWebhookURLInput_KeyDown(object sender, KeyEventArgs e)
        {
            SaveDiscordSettingsButton.BackColor = Color.FromArgb(200, 60, 60);
            ToolTipInformation.Hide(this);
            ToolTipInformation.Show("You have unsaved changes. Click here to save them.", this, 409, 58, 1000);
        }

        private void DiscordWebhookAppendInput_KeyDown(object sender, KeyEventArgs e)
        {
            SaveDiscordSettingsButton.BackColor = Color.FromArgb(200, 60, 60);
            ToolTipInformation.Hide(this);
            ToolTipInformation.Show("You have unsaved changes. Click here to save them.", this, 409, 58, 1000);
        }

        private void AlertListRefresher_Tick(object sender, EventArgs e)
        {
            RefreshAlertHistory();
        }

        private void RefreshOutputsButton_Click(object sender, EventArgs e)
        {
            AlertAppearanceAndSoundsGroup.Enabled = false;
            var result = MessageBox.Show("Refresh audio outputs?\r\nThe window may freeze for a few moments.",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                var devices = RefreshAudioDevices();
                AudioDeviceCombo.Items.Clear();

                foreach (var device in devices)
                {
                    AudioDeviceCombo.Items.Add(device.FriendlyName);
                }

                AudioDeviceCombo.SelectedItem = Settings.Default.ProgramAudioOutput;
            }
            AlertAppearanceAndSoundsGroup.Enabled = true;
        }

        private void AudioDeviceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string adc = AudioDeviceCombo.Text;
            ThreadPool.QueueUserWorkItem(_ =>
            {
                lock (AudioDevicesList)
                {
                    foreach (var device in AudioDevicesList)
                    {
                        if (device.FriendlyName.ToLowerInvariant() == adc.ToLowerInvariant())
                        {
                            CurrentAudioDevice = device;
                            Settings.Default.ProgramAudioOutput = device.FriendlyName;
                            //MessageBox.Show("Audio device get/set successfully.",
                            //    "SharpAlert",
                            //    MessageBoxButtons.OK,
                            //    MessageBoxIcon.Information);
                            break;
                        }
                    }
                }
            });
        }

        private void ConfigurationForm_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void AudioDeviceMessage_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //AudioDeviceMessage.Stop();
                if (string.IsNullOrWhiteSpace(Settings.Default.ProgramAudioOutput))
                {
                    AudioOutputLabel.BackColor = Color.FromArgb(200, 60, 60);
                    this.ToolTipInformation.SetToolTip(this.AudioOutputLabel,
                        "The default audio device is being used.\r\n" +
                        "It is recommended to set a specific audio device.");
                }
                else
                {
                    AudioOutputLabel.BackColor = this.BackColor;
                    this.ToolTipInformation.SetToolTip(this.AudioOutputLabel, string.Empty);
                }
            }
        }

        private void AppliedLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("All settings (except select few) are applied immediately.\r\n" +
                "You'll be notified if a setting requires a restart.\r\n\r\n" +
                "Your changes are saved upon exiting the program.",
                "SharpAlert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}
