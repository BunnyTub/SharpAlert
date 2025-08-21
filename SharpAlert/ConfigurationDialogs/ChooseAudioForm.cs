using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.AudioManager;
using static SharpAlert.ProgramWorker.NotificationWorker;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class ChooseAudioForm : Form
    {
        public ChooseAudioForm(bool ShowNextInsteadOfDone)
        {
            InitializeComponent();
            if (ShowNextInsteadOfDone) DoneButton.Text = "Next";
            else DoneButton.Text = "Done";
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Initialized = false;

        private void ChooseRegionForm_Load(object sender, EventArgs e)
        {
            AudioDeviceCombo.Items.Clear();

            lock (AudioDevicesList)
            {
                foreach (var device in AudioDevicesList)
                {
                    AudioDeviceCombo.Items.Add(device.FriendlyName);
                }
            }

            AudioDeviceCombo.SelectedItem = QuickSettings.Instance.ProgramAudioOutput;

            ShowRefreshTip.Start();

            if (Initialized) return;
            Initialized = true;

            AudioTinkeringFileDialog.Filter = "Audio Files (*.mp3, *.wav)|*.mp3;*.wav";
            AudioTinkeringFileDialog.FilterIndex = 0;
            AudioTinkeringFileDialog.CheckFileExists = true;
            AudioTinkeringFileDialog.Multiselect = false;
            AudioTinkeringFileDialog.Title = "SharpAlert - Audio Selection";

            volumeBar.Value = QuickSettings.Instance.alertVolume;
            volumeBar.Scroll += (a, b) =>
            {
                if (LegacyAudioPlayerBox.Checked)
                {
                    MessageBox.Show("You cannot use this feature with the legacy audio player.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }

                QuickSettings.Instance.alertVolume = ((TrackBar)a).Value;
            };

            alertPlayEndToneBox.Checked = QuickSettings.Instance.alertPlayEndTone;
            alertPlayEndToneBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertPlayEndTone = ((CheckBox)a).Checked;

            LegacyAudioPlayerBox.Checked = QuickSettings.Instance.LegacyAudioPlayer;
            LegacyAudioPlayerBox.CheckedChanged += (a, b) =>
            {
                QuickSettings.Instance.LegacyAudioPlayer = ((CheckBox)a).Checked;
                QuickSettings.Instance.Save();
                MessageBox.Show("Your settings have been saved.\r\n" +
                    "Closing now to use the new sound subsystem.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Environment.Exit(0);
            };
            
            EnableBasicSpeakingBox.Checked = QuickSettings.Instance.EnableBasicSpeaking;
            EnableBasicSpeakingBox.CheckedChanged += (a, b) =>
            {
                if (((CheckBox)a).Checked)
                {
                    MessageBox.Show("Please take note!\r\n" +
                        "Basic Speaking will always use the default sound device regardless of your audio settings.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    SpeakingManager.EnabledBasicSpeaking();
                }
                else
                {
                    SpeakingManager.DisabledBasicSpeaking();
                }

                QuickSettings.Instance.EnableBasicSpeaking = ((CheckBox)a).Checked;
            };
        }

        private void ChooseRegionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (LegacyAudioPlayerBox.Checked)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(QuickSettings.Instance.ProgramAudioOutput))
            {
                //MessageBox.Show("You must choose an audio output.\r\n" +
                //    "If you're having trouble, try the legacy audio player.",
                //    "SharpAlert",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Exclamation);
                //e.Cancel = true;

                CurrentAudioDevice = null;
                QuickSettings.Instance.ProgramAudioOutput = string.Empty;

                return;
            }
        }

        private void ChooseRegionForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MessageBox.Show("Hover over the region boxes for their respective info.",
            //    "SharpAlert",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);
            e.Cancel = true;
        }

        private void AudioDeviceCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void RefreshOutputsButton_Click(object sender, EventArgs e)
        {
            if (LegacyAudioPlayerBox.Checked)
            {
                MessageBox.Show("You cannot use this feature with the legacy audio player.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

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

        private void AudioOutputClearLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (LegacyAudioPlayerBox.Checked)
            {
                MessageBox.Show("You cannot use this feature with the legacy audio player.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

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

        private void TTSButton_Click(object sender, EventArgs e)
        {
            Process.Start("C:\\Windows\\system32\\rundll32.exe", "shell32.dll,Control_RunDLL C:\\Windows\\system32\\speech\\speechux\\sapi.cpl");
            return;
        }

        private void SupportedLinesButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Supported Voice Lines --- (must be *.wav)" +
                "\r\n\r\n" +
                "EnabledBasicSpeaking.wav - Called when Basic Speaking is enabled.\r\n" +
                "DisabledBasicSpeaking.wav - Called when Basic Speaking is disabled.\r\n" +
                "DismissedWindow.wav - Called when an alert window is dismissed.\r\n" +
                "ForwardThisMessageToDiscord.wav - Called when asking for consent.\r\n" +
                "FullDaySinceQueuedAlert.wav - Called when it has been 24 hours since the last alert.\r\n" +
                "HalfDaySinceQueuedAlert.wav - Called when it has been 12 hours since the last alert.\r\n" +
                "ModerateOrLower.wav - Called when an alert is issued with a severity that is moderate or lower.\r\n" +
                "SevereOrHigher.wav - Called when an alert is issued with a severity that is severe or higher.\r\n" +
                "TopOfTheHour.wav - Called when the clock minute resets to zero.\r\n" +
                "UpdatesFound.wav - Called on startup if updates are found.\r\n" +
                "SettingsSaved.wav - Called when settings are saved.\r\n" +
                "ProgramRunning.wav - Called when the program starts.\r\n" +
                "SetupComplete.wav - Called when the user completes setup.\r\n" +
                "BetaVersionInUse.wav - Called when running a beta version." +
                "\r\n\r\n" +
                "Place these files in the executable directory to override the built-in sound files!", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChangeStartButton_Click(object sender, EventArgs e)
        {
            Thread staThread = new Thread(() =>
            {
                try
                {
                    lock (AudioTinkeringFileDialog)
                    {
                        if (AudioTinkeringFileDialog.ShowDialog() != DialogResult.OK)
                        {
                            QuickSettings.Instance.StartToneLocation = string.Empty;
                            Notify.ShowNotification($"Reverted to default audio.",
                                "SharpAlert audio changed",
                                ToolTipIcon.Warning);
                            return;
                        }

                        QuickSettings.Instance.StartToneLocation = AudioTinkeringFileDialog.FileName;

                        Notify.ShowNotification($"Using linked audio.",
                            "SharpAlert audio changed",
                            ToolTipIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.StackTrace} {ex.Message}",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
        }

        private void ChangeEndButton_Click(object sender, EventArgs e)
        {
            Thread staThread = new Thread(() =>
            {
                try
                {
                    lock (AudioTinkeringFileDialog)
                    {
                        if (AudioTinkeringFileDialog.ShowDialog() != DialogResult.OK)
                        {
                            QuickSettings.Instance.EndToneLocation = string.Empty;
                            Notify.ShowNotification($"Reverted to default audio.",
                                "SharpAlert audio changed",
                                ToolTipIcon.Warning);
                            return;
                        }
                        QuickSettings.Instance.EndToneLocation = AudioTinkeringFileDialog.FileName;

                        Notify.ShowNotification($"Using linked audio.",
                            "Reverted to default audio.",
                            ToolTipIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.StackTrace} {ex.Message}",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
        }

        private void ShowRefreshTip_Tick(object sender, EventArgs e)
        {
            ShowRefreshTip.Stop();
            //ToolTipInformation.Show("Click here to repopulate the audio outputs list.", this, 5000, 552, 57);
        }
    }
}

