using System;
using System.Windows.Forms;
using SharpAlert.Properties;
using static SharpAlert.AudioManager;

namespace SharpAlert
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

            AudioDeviceCombo.SelectedItem = Settings.Default.ProgramAudioOutput;

            if (Initialized) return;
            Initialized = true;

            volumeBar.Value = Settings.Default.alertVolume;
            volumeBar.Scroll += (a, b) => Settings.Default.alertVolume = ((TrackBar)a).Value;
            
            LegacyAudioPlayerBox.Checked = Settings.Default.LegacyAudioPlayer;
            LegacyAudioPlayerBox.CheckedChanged += (a, b) =>
            {
                Settings.Default.LegacyAudioPlayer = ((CheckBox)a).Checked;
                MessageBox.Show("This setting requires a program restart. You'll lose out on program volume, using a specific output device, remote audio, and the ability to customize alert tones.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                UsingLegacy = true;
                this.Close();
            };
        }

        private bool UsingLegacy = false;

        private void ChooseRegionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UsingLegacy)
            {
                return;
            }

            if (string.IsNullOrWhiteSpace(Settings.Default.ProgramAudioOutput))
            {
                MessageBox.Show("You must choose an audio output.",
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

                AudioDeviceCombo.SelectedItem = Settings.Default.ProgramAudioOutput;
            }
        }
    }
}
