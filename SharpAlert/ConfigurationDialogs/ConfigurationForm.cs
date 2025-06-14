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
using static SharpAlert.AlertProcessor;
using System.Xml.Linq;

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
            RefreshAlertHistory();

            if (Initialized) return;
            Initialized = true;

            lock (notify)
            {
                notify.BalloonTipTitle = "SharpAlert is initializing Settings";
                notify.BalloonTipText = "Settings is getting ready to be shown. This may take a few moments.";
                notify.BalloonTipIcon = ToolTipIcon.Info;
                notify.ShowBalloonTip(5000);
            }

            DiscordWebhookURLInput.Text = QuickSettings.Instance.DiscordWebhook;
            DiscordWebhookAppendInput.Text = QuickSettings.Instance.DiscordWebhookAppend;
            DiscordWebhookConfirmAlertsBox.Checked = QuickSettings.Instance.DiscordWebhookConfirmAlerts;
            DiscordWebhookConfirmAlertsBox.CheckedChanged += (a, b) => QuickSettings.Instance.DiscordWebhookConfirmAlerts = ((CheckBox)a).Checked;
            DiscordWebhookRelayLocallyBox.Checked = QuickSettings.Instance.DiscordWebhookRelayLocally;
            DiscordWebhookRelayLocallyBox.CheckedChanged += (a, b) =>
            {
                QuickSettings.Instance.DiscordWebhookRelayLocally = ((CheckBox)a).Checked;
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

            //alertFullscreenBox.Checked = QuickSettings.Instance.alertDisplayType;
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
            //    QuickSettings.Instance.alertDisplayType = ((CheckBox)a).Checked;
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

            alertNoRelayBox.Checked = QuickSettings.Instance.alertNoRelay;
            alertNoRelayBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertNoRelay = ((CheckBox)a).Checked;
            
            alertPlayEndToneBox.Checked = QuickSettings.Instance.alertPlayEndTone;
            alertPlayEndToneBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertPlayEndTone = ((CheckBox)a).Checked;
            
            volumeBar.Value = QuickSettings.Instance.alertVolume;
            volumeBar.Scroll += (a, b) => QuickSettings.Instance.alertVolume = ((TrackBar)a).Value;

            LegacyAudioPlayerBox.Checked = QuickSettings.Instance.LegacyAudioPlayer;
            AdvancedAudioGroup.Enabled = !LegacyAudioPlayerBox.Checked;
            LegacyAudioPlayerBox.CheckedChanged += (a, b) =>
            {
                QuickSettings.Instance.LegacyAudioPlayer = ((CheckBox)a).Checked;
                //AdvancedAudioGroup.Enabled = !LegacyAudioPlayerBox.Checked;
                if (((CheckBox)a).Checked)
                {
                    MessageBox.Show("This setting requires a program restart. You'll lose out on program volume, using a specific output device, remote audio, and the ability to customize alert tones if this is enabled. Works better on low-end systems.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    MessageBox.Show("This setting requires a program restart.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            };

            statusWindowBox.Checked = QuickSettings.Instance.statusWindow;
            statusWindowBox.CheckedChanged += (a, b) =>
            {
                ((CheckBox)a).Enabled = false;
                QuickSettings.Instance.statusWindow = ((CheckBox)a).Checked;

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

            AudioDeviceCombo.SelectedItem = QuickSettings.Instance.ProgramAudioOutput;

            //QuickSettings.Instance.PropertyChanged += (a, b) =>
            //{
            //    SaveAllSettingsButton.BackColor = Color.FromArgb(200, 60, 60);
            //    //ToolTipInformation.Hide(this);
            //    //ToolTipInformation.Show("You have unsaved changes.", this, 0, 0, 1000);
            //};

            RefreshAlertHistory();
        }

        //class ComboItem
        //{
        //    public override string ToString()
        //    {
        //        return FriendlyName;
        //    }

        //    public string FriendlyName { get; set; }
        //}

        private void AlertHistoryClearButton_Click(object sender, EventArgs e)
        {
            ClearAlertHistory();
        }

        private void RefreshAlertHistory()
        {
            if (SharpDataHistory.Count != 0)
            {
                string DataHistory = string.Empty;
                lock (SharpDataHistory)
                {
                    foreach (var item in SharpDataHistory)
                    {
                        DataHistory = $"{item.Name}\r\n{DataHistory}";
                    }
                    AlertHistoryText.Text = $"Count: {SharpDataHistory.Count} alert(s)";

                    LastKnownHistoryCount = SharpDataHistory.Count;
                }
                DataHistory.Trim();
                AlertHistoryOutput.Text = DataHistory;
            }
            else
            {
                AlertHistoryText.Text = "There are no items in the history.";
                AlertHistoryOutput.Clear();
            }
        }
        
        private void ClearAlertHistory()
        {
            RefreshAlertHistory();
            if (SharpDataHistory.Count != 0)
            {
                SharpDataHistory.Clear();
                SharpDataRelayedNamesHistory.Clear();
                AlertHistoryText.Text = "The history was cleared.";
                AlertHistoryOutput.Clear();
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
            AlertHistoryRefreshButton.BackColor = Color.FromArgb(60, 60, 60);
            RefreshAlertHistory();
        }

        private void AlertHistoryReplayRecentButton_Click(object sender, EventArgs e)
        {
            PastAlertsGroup.Enabled = false;
            Thread.Sleep(500);
            try
            {
                RefreshAlertHistory();
                if (SharpDataHistory.Count != 0)
                {
                    lock (SharpDataQueue)
                    {
                        lock (SharpDataHistory)
                        {
                            var alert = SharpDataHistory.Last();
                            //SharpDataHistory.Remove(alert);
                            if (alert.Data.Contains("<SharpAlertReplay>false</SharpAlertReplay>"))
                            {
                                alert.Data = alert.Data.Replace("<SharpAlertReplay>false</SharpAlertReplay>", "<SharpAlertReplay>true</SharpAlertReplay>");
                            }
                            else
                            {
                                alert.Data += "<SharpAlertReplay>true</SharpAlertReplay>";
                            }

                            AlertInfo alertInfo = dataproc.ap.ProcessAlertItem(alert, true, false);

                            if (alertInfo == null)
                            {
                                MessageBox.Show("The alert does not meet the requirements you've set, so it has not been relayed.",
                                    "SharpAlert",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation);
                            }
                            else
                            {
                                if (!string.IsNullOrWhiteSpace(alertInfo.AlertDiscardReason))
                                {
                                    MessageBox.Show($"{alertInfo.AlertDiscardReason}",
                                        "SharpAlert",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Exclamation);
                                }
                            }
                            //SharpDataQueue.Add(alert);
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"There are no items in the history.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }

            Thread.Sleep(500);
            PastAlertsGroup.Enabled = true;
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

            QuickSettings.Instance.DiscordWebhook = DiscordWebhookURLInput.Text.Trim();
            QuickSettings.Instance.DiscordWebhookAppend = DiscordWebhookAppendInput.Text.Trim();

            if (!QuickSettings.Instance.DiscordWebhookRelayLocally)
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
            DialogResult result = MessageBox.Show("Export all alerts separately?\r\n" +
                "Choosing NO will bundle all alerts into one file.",
                "SharpAlert",
                MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Cancel) return;

            if (SharpDataHistory.Count != 0)
            {
                try
                {
                    string directory = QuickSettings.ConfigDirPath + "\\Exports";

                    Directory.CreateDirectory(directory);
                    lock (SharpDataHistory)
                    {
                        //BundledAlerts_Timestamp.cap
                        if (result == DialogResult.Yes)
                        {
                            foreach (var item in SharpDataHistory)
                            {
                                string name = item.Name;
                                // some names relayed love having illegal filepath characters
                                // this is the best fix I can think of, other than just using an MD5 of the data
                                name = string.Join("_", name.Split(Path.GetInvalidFileNameChars()));
                                File.WriteAllText(directory + "\\" + name + ".cap", item.Data);
                            }
                        }
                        else
                        {
                            if (result == DialogResult.No)
                            {
                                string FullData = "<SharpAlertMassImport>true</SharpAlertMassImport>\r\n";

                                foreach (var item in SharpDataHistory)
                                {
                                    FullData += $"{item.Data}";
                                }

                                File.WriteAllText(directory + $"\\Bundled_{DateTime.UtcNow.Ticks}.cap", FullData);
                            }
                        }
                    }

                    MessageBox.Show($"{SharpDataHistory.Count} alert(s) have been exported.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Process.Start("explorer.exe", $"{directory}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"There are no alerts in the history.",
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

            //    ConsoleExt.WriteLine($"[Configuration Dialog | Version Request] The server responded with status code {latest.StatusCode}.");

            //    RemoteVersion = latest.Content.ReadAsStringAsync().Result.Trim();
            //    if (string.IsNullOrWhiteSpace(RemoteVersion) || RemoteVersion.Length == 0 || RemoteVersion.Length >= 10) RemoteVersion = "0";
            //}
            //catch (Exception ex)
            //{
            //    ConsoleExt.WriteLine($"[Configuration Dialog] {ex.StackTrace} {ex.Message}");
            //    ConsoleExt.WriteLine($"[Configuration Dialog] Couldn't work with the server.");
            //}

            //if (QuickSettings.Instance.MakiVersion == "0")
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
            //ToolTipInformation.Hide(this);
            //ToolTipInformation.Show("You have modified webhook related fields. Click here to apply them.", this, 409, 58, 1000);
        }

        private void DiscordWebhookAppendInput_KeyDown(object sender, KeyEventArgs e)
        {
            SaveDiscordSettingsButton.BackColor = Color.FromArgb(200, 60, 60);
            //ToolTipInformation.Hide(this);
            //ToolTipInformation.Show("You have modified webhook related fields. Click here to apply them.", this, 409, 58, 1000);
        }

        int LastKnownHistoryCount = 0;

        private void AlertListRefresher_Tick(object sender, EventArgs e)
        {
            if (SharpDataHistory.Count != LastKnownHistoryCount)
            {
                AlertHistoryRefreshButton.BackColor = Color.FromArgb(200, 60, 60);
                AlertHistoryText.Text = $"Count: {SharpDataHistory.Count} alert(s) - Click refresh to update the list";
            }
            //RefreshAlertHistory();
        }

        private void RefreshOutputsButton_Click(object sender, EventArgs e)
        {
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

                AudioDeviceCombo.SelectedItem = QuickSettings.Instance.ProgramAudioOutput;
            }
        }

        private void AudioDeviceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AudioDeviceCombo.SelectedIndex == -1) return;

            string adc = AudioDeviceCombo.Text;
            ThreadDrool.StartAndForget(() =>
            {
                lock (AudioDevicesList)
                {
                    foreach (var device in AudioDevicesList)
                    {
                        if (device.FriendlyName.ToLowerInvariant() == adc.ToLowerInvariant())
                        {
                            CurrentAudioDevice = device;
                            QuickSettings.Instance.ProgramAudioOutput = device.FriendlyName;
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
                if (string.IsNullOrWhiteSpace(QuickSettings.Instance.ProgramAudioOutput))
                {
                    AudioOutputLabel.BackColor = Color.FromArgb(200, 60, 60);
                    ToolTipInformation.SetToolTip(AudioOutputLabel,
                        "The default audio device is being used.\r\n" +
                        "It is recommended to set a specific audio device.");
                }
                else
                {
                    AudioOutputLabel.BackColor = this.BackColor;
                    ToolTipInformation.SetToolTip(AudioOutputLabel, string.Empty);
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

        private void RevealButton_Click(object sender, EventArgs e)
        {
            PastAlertsGroup.Enabled = false;
            Thread.Sleep(500);
            RefreshAlertHistory();
            if (SharpDataHistory.Count != 0)
            {
                SharpDataItem alert = null;

                lock (SharpDataHistory)
                {
                    string input = RevealAlertIdentifierInput.Text;

                    alert = SharpDataHistory.FirstOrDefault(item =>
                        string.Equals(item.Name, input, StringComparison.OrdinalIgnoreCase));

                    if (alert == null)
                    {
                        MessageBox.Show("The alert identifier doesn't exist here.\r\nCheck it again, or try another!", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        PastAlertsGroup.Enabled = true;
                        return;
                    }
                    else
                    {
                        RevealAlertIdentifierInput.Clear();
                    }
                }

                AlertInfo info = dataproc.ap.ProcessAlertItem(alert, false, true);
                aif.UpdateFields(info.AlertID,
                    info.AlertEventType,
                    info.AlertIntroText,
                    info.AlertBodyText,
                    info.AlertURL,
                    info.AlertAudioURL,
                    info.AlertImageURL,
                    info.AlertMessageType);
                aif.ShowDialog();
            }
            else
            {
                MessageBox.Show($"There are no items in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            Thread.Sleep(500);
            PastAlertsGroup.Enabled = true;
        }

        private readonly AlertInfoForm aif = new AlertInfoForm();

        private void RevealRecentButton_Click(object sender, EventArgs e)
        {
            PastAlertsGroup.Enabled = false;
            Thread.Sleep(500);
            RefreshAlertHistory();
            if (SharpDataHistory.Count != 0)
            {
                var alert = SharpDataHistory.Last();
                AlertInfo info = dataproc.ap.ProcessAlertItem(alert, false, true);
                aif.UpdateFields(info.AlertID,
                    info.AlertEventType,
                    info.AlertIntroText,
                    info.AlertBodyText,
                    info.AlertURL,
                    info.AlertAudioURL,
                    info.AlertImageURL,
                    info.AlertMessageType);
                aif.ShowDialog();
            }
            else
            {
                MessageBox.Show($"There are no items in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            Thread.Sleep(500);
            PastAlertsGroup.Enabled = true;
        }

        private void AudioOutputClearLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Use the default audio device?\r\n" +
                "It's better to use a specific audio device.",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                AudioDeviceCombo.SelectedIndex = -1;
                QuickSettings.Instance.ProgramAudioOutput = string.Empty;
            }
        }

        private void SaveAllSettingsButton_Click(object sender, EventArgs e)
        {
            QuickSettings.Instance.Save();
        }

        private void DebuggerChecker_Tick(object sender, EventArgs e)
        {
        }

        private void RawSettingsButton_Click(object sender, EventArgs e)
        {
            Migrate();
        }

        private void Migrate()
        {
            if ((ModifierKeys & Keys.Shift) != Keys.Shift)
            {
                if (QuickSettings.Instance.MigrationOccurred)
                {
                    MessageBox.Show("You have already migrated your settings.\r\n" +
                        "Hold SHIFT while clicking the button to migrate anyway.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DialogResult result = MessageBox.Show("Start migration from old settings?\r\n" +
                "The program will immediately close after it's successful, and all of your current new settings will be overwritten by your old settings.",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var old = Settings.Default;
                    var sharp = QuickSettings.Instance;

                    var oldProps = old.GetType().GetProperties();
                    var newProps = typeof(QuickSettings).GetProperties();

                    foreach (var oldProp in oldProps)
                    {
                        var newProp = newProps.FirstOrDefault(p => p.Name == oldProp.Name &&
                                                                   p.PropertyType == oldProp.PropertyType);
                        if (newProp != null && newProp.CanWrite)
                        {
                            var value = oldProp.GetValue(old);
                            newProp.SetValue(sharp, value);
                        }
                    }

                    sharp.MigrationOccurred = true;
                    sharp.Save();
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Exception exception = new Exception($"Migration from old settings to new settings failed.\r\n{ex.Message}");
                    UnsafeFault(exception, true);
                    //MessageBox.Show($"Migration has failed. {ex.Message}",
                    //    "SharpAlert",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Error);
                }
            }
        }

        private ServerConfigurationForm scf = null;

        private void ServerButton_Click(object sender, EventArgs e)
        {
            if (scf == null || scf.IsDisposed) scf = new ServerConfigurationForm();
            scf.ShowDialog();
        }
    }
}
