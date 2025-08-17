using System;
using System.Linq;
using System.Windows.Forms;
using SharpAlert.ProgramWorker;
using SharpAlert.Properties;
using static SharpAlert.ProgramWorker.MainEntryPoint;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class StyleConfigurationForm : Form
    {
        public StyleConfigurationForm(bool ShowNextInsteadOfDone)
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

        private bool Initialized = false;

        private void ChooseRegionForm_Load(object sender, EventArgs e)
        {
            if (Initialized) return;
            Initialized = true;

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
                    // 3
                    FriendlyName = "Full scroll"
                },
                new ComboItem
                {
                    // 4
                    FriendlyName = "Full board"
                },
            };
            AlertFullscreenCombo.SelectedIndex = QuickSettings.Instance.alertDisplayType;
            AlertFullscreenCombo.SelectedIndexChanged += (a, b) => QuickSettings.Instance.alertDisplayType = (byte)((ComboBox)a).SelectedIndex;

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
            WindowLocationCombo.SelectedIndex = QuickSettings.Instance.WindowLocation;
            WindowLocationCombo.SelectedIndexChanged += (a, b) => QuickSettings.Instance.WindowLocation = (byte)((ComboBox)a).SelectedIndex;

            alertFullscreenWindowedBox.Checked = QuickSettings.Instance.alertTitlebarControls;
            alertFullscreenWindowedBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertTitlebarControls = ((CheckBox)a).Checked;

            alertTimeoutInput.Value = QuickSettings.Instance.alertTimeout;
            alertTimeoutInput.ValueChanged += (a, b) => QuickSettings.Instance.alertTimeout = (int)((NumericUpDown)a).Value;

            alertFullscreenIdleBox.Checked = QuickSettings.Instance.alertFullscreenIdle;
            alertFullscreenIdleBox.CheckedChanged += (a, b) =>
            {
                IdleWindowVisible = ((CheckBox)a).Checked;
                this.BringToFront();
            };

            statusWindowBox.Checked = QuickSettings.Instance.statusWindow;
            statusWindowBox.CheckedChanged += (a, b) =>
            {
                StatusWindowVisible = ((CheckBox)a).Checked;
                this.BringToFront();
            };

            alertTimeZoneUTCBox.Checked = QuickSettings.Instance.alertTimeZoneUTC;
            alertTimeZoneUTCBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertTimeZoneUTC = ((CheckBox)a).Checked;

            bool alertFullscreenDisplayIgnoreInput = false;
            alertFullscreenDisplayInput.Value = QuickSettings.Instance.alertFullscreenDisplay;
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
                        QuickSettings.Instance.alertFullscreenDisplay = (int)((NumericUpDown)a).Value;
                        //MonitorNonExistant = true;
                    }
                    else
                    {
                        alertFullscreenDisplayIgnoreInput = true;
                        ((NumericUpDown)a).Value = QuickSettings.Instance.alertFullscreenDisplay;
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
                        QuickSettings.Instance.alertFullscreenDisplay = (int)((NumericUpDown)a).Value;
                    }
                    else
                    {
                        alertFullscreenDisplayIgnoreInput = true;
                        ((NumericUpDown)a).Value = QuickSettings.Instance.alertFullscreenDisplay;
                        alertFullscreenDisplayIgnoreInput = false;
                        return;
                    }
                }
            };

            alertCompatibilityModeBox.Checked = QuickSettings.Instance.alertCompatibilityMode;
            alertCompatibilityModeBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertCompatibilityMode = ((CheckBox)a).Checked;

            alertTTSonlyBox.Checked = QuickSettings.Instance.alertTTSonly;
            alertTTSonlyBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertTTSonly = ((CheckBox)a).Checked;

            alertNoGUIBox.Checked = QuickSettings.Instance.alertNoGUI;
            alertNoGUIBox.CheckedChanged += (a, b) =>
            {
                QuickSettings.Instance.alertNoGUI = ((CheckBox)a).Checked;
                if (((CheckBox)a).Checked)
                {
                    MessageBox.Show("The console will now be opened.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    TuyeWorker.AllocateTerminal(false);
                }
                else
                {
                    MessageBox.Show("Restart the program to hide the console.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            };

            alertIncreaseSizeBox.Checked = QuickSettings.Instance.alertIncreaseSize;
            alertIncreaseSizeBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertIncreaseSize = ((CheckBox)a).Checked;

            alertPlayStartToneTwiceBox.Checked = QuickSettings.Instance.alertPlayStartToneTwice;
            alertPlayStartToneTwiceBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertPlayStartToneTwice = ((CheckBox)a).Checked;
            
            NoSystemSleepBox.Checked = QuickSettings.Instance.NoSystemSleep;
            NoSystemSleepBox.CheckedChanged += (a, b) => QuickSettings.Instance.NoSystemSleep = ((CheckBox)a).Checked;
            
            alertAutoPrintingEnabledBox.Checked = QuickSettings.Instance.alertAutoPrintingEnabled;
            alertAutoPrintingEnabledBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertAutoPrintingEnabled = ((CheckBox)a).Checked;
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

        private AlertTextConfigurationForm atcf = null;

        private void AlertTextButton_Click(object sender, EventArgs e)
        {
            if (atcf == null || atcf.IsDisposed) atcf = new AlertTextConfigurationForm(false);
            atcf.ShowDialog();
        }

        private void LogoBox_DoubleClick(object sender, EventArgs e)
        {
            PrinterController.Print("Test Message", $"This is a test to ensure the function of your printer and its current settings. {Resources.TestScript}");
        }
    }
}

