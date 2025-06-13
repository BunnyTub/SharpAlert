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
            
            LegacyAudioPlayerBox.Checked = QuickSettings.Instance.LegacyAudioPlayer;
            LegacyAudioPlayerBox.CheckedChanged += (a, b) =>
            {
                QuickSettings.Instance.LegacyAudioPlayer = ((CheckBox)a).Checked;
                MessageBox.Show("The program will now close.\r\n" +
                    "Please open it again to complete the setup.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                QuickSettings.Instance.Save();
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
    }
}
