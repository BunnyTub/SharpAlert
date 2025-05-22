using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SharpAlert.Properties;
using static SharpAlert.MainEntryPoint;

namespace SharpAlert
{
    public partial class ChooseStyleForm : Form
    {
        public ChooseStyleForm(bool ShowNextInsteadOfDone)
        {
            InitializeComponent();
            if (ShowNextInsteadOfDone) DoneButton.Text = "Next";
            else DoneButton.Text = "Done";
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private class ComboItem
        {
            public override string ToString()
            {
                return FriendlyName;
            }

            public string FriendlyName { get; set; }
        }

        private void ChooseRegionForm_Load(object sender, EventArgs e)
        {
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
        }

        private void ChooseRegionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void ChooseRegionForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Hover over the options for their respective info.",
                "SharpAlert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            e.Cancel = true;
        }
    }
}
