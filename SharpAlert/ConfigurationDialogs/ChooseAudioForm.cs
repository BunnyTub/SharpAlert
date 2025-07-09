using System;
using System.Diagnostics;
using System.Windows.Forms;
using static SharpAlert.AudioManager;

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

            if (Initialized) return;
            Initialized = true;

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
                    "The program will now close.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Environment.Exit(0);
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
                MessageBox.Show("You must choose an audio output.\r\n" +
                    "If you're having trouble, try the legacy audio player.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Cancel = true;
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
    }
}

