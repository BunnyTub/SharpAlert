using System;
using System.Windows.Forms;
using SharpAlert.Languages;
using SharpAlert.ProgramWorker;
using SharpAlert.Properties;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class StyleConfigurationForm : Form
    {
        public StyleConfigurationForm(bool ShowNextInsteadOfDone)
        {
            InitializeComponent();
            if (ShowNextInsteadOfDone)
            {
                DoneButton.Text = Language.Get("Button_Next", "Next");
                TitleText.Text = "How do you want everything to look?";
            }
            else
            {
                DoneButton.Text = Language.Get("Button_Done", "Done");
                TitleText.Text = "Choose your style settings.";
            }
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
                new()
                {
                    // 0
                    FriendlyName = "Windowed",
                },
                new()
                {
                    // 1
                    FriendlyName = "Minified",
                },
                new()
                {
                    // 2
                    FriendlyName = "Full screen"
                },
                new()
                {
                    // 3
                    FriendlyName = "Full scroll"
                },
                new()
                {
                    // 4
                    FriendlyName = "Full board"
                },
            };

            AlertFullscreenCombo.SelectedIndex = QuickSettings.Instance.alertDisplayType;

            void ChangePreview()
            {
                switch (AlertFullscreenCombo.SelectedIndex)
                {
                    default:
                    case 0:
                        PreviewPicture.Image = Resources.StyleWindowed;
                        break;
                    case 1:
                        PreviewPicture.Image = Resources.StyleMinified;
                        break;
                    case 2:
                        PreviewPicture.Image = Resources.StyleFullscreen;
                        break;
                    case 3:
                        PreviewPicture.Image = Resources.StyleFullscroll;
                        break;
                    case 4:
                        PreviewPicture.Image = Resources.StyleFullboard;
                        break;
                }
            }

            ChangePreview();

            AlertFullscreenCombo.SelectedIndexChanged += (a, b) =>
            {
                QuickSettings.Instance.alertDisplayType = (byte)((ComboBox)a).SelectedIndex;
                ChangePreview();
            };

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

            bool alertFullscreenDisplayIgnoreInput = false;
            alertFullscreenDisplayInput.Value = QuickSettings.Instance.alertFullscreenDisplay + 1;
            alertFullscreenDisplayInput.ValueChanged += (a, b) =>
            {
                if (alertFullscreenDisplayIgnoreInput) return;

                //bool MonitorNonExistant = false

                if ((int)((NumericUpDown)a).Value > Screen.AllScreens.Length)
                {
                    if (MessageBox.Show("The monitor you've chosen doesn't exist right now, and the idle and alert panels will be shown on the default monitor until it does exist. Do you want to use it anyway?",
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        QuickSettings.Instance.alertFullscreenDisplay = (int)((NumericUpDown)a).Value - 1;
                        //MonitorNonExistant = true;
                    }
                    else
                    {
                        alertFullscreenDisplayIgnoreInput = true;
                        ((NumericUpDown)a).Value = QuickSettings.Instance.alertFullscreenDisplay + 1;
                        alertFullscreenDisplayIgnoreInput = false;
                        return;
                    }
                }
                else
                {
                    Screen screen = Screen.AllScreens[(int)((NumericUpDown)a).Value - 1];

                    if (MessageBox.Show($"Use \"{screen.DeviceName}\" ({screen.Bounds.Width} x {screen.Bounds.Height})?",
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        QuickSettings.Instance.alertFullscreenDisplay = (int)((NumericUpDown)a).Value - 1;
                    }
                    else
                    {
                        alertFullscreenDisplayIgnoreInput = true;
                        ((NumericUpDown)a).Value = QuickSettings.Instance.alertFullscreenDisplay + 1;
                        alertFullscreenDisplayIgnoreInput = false;
                        return;
                    }
                }
            };

            alertNoGUIBox.Checked = QuickSettings.Instance.alertNoGUI;
            alertNoGUIBox.CheckedChanged += (a, b) =>
            {
                QuickSettings.Instance.alertNoGUI = ((CheckBox)a).Checked;
                TextDisplayGroup.Enabled = !((CheckBox)a).Checked;
                if (((CheckBox)a).Checked)
                {
                    MessageBox.Show("The console will now be opened.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    HaidaWorker.AllocateTerminal(false);
                }
                else
                {
                    MessageBox.Show("Restart the program to hide the console.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            };
            TextDisplayGroup.Enabled = !alertNoGUIBox.Checked;

            alertIncreaseSizeBox.Checked = QuickSettings.Instance.alertIncreaseSize;
            alertIncreaseSizeBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertIncreaseSize = ((CheckBox)a).Checked;

            //alertAutoPrintingEnabledBox.Checked = QuickSettings.Instance.alertAutoPrintingEnabled;
            //alertAutoPrintingEnabledBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertAutoPrintingEnabled = ((CheckBox)a).Checked;

            QuickSettings.Instance.alertAutoPrintingEnabled = false;

            ScrollSpeedBar.Value = QuickSettings.Instance.ScrollSpeed;
            ScrollSpeedBar.ValueChanged += (a, b) => QuickSettings.Instance.ScrollSpeed = ((TrackBar)a).Value;

            alertFadeTimeBar.Value = QuickSettings.Instance.alertFadeTime;
            alertFadeTimeBar.ValueChanged += (a, b) => QuickSettings.Instance.alertFadeTime = ((TrackBar)a).Value;

            TryForceWindowFocusBox.Checked = QuickSettings.Instance.TryForceWindowFocus;
            TryForceWindowFocusBox.CheckedChanged += (a, b) => QuickSettings.Instance.TryForceWindowFocus = ((CheckBox)a).Checked;
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

        private void TitleText_Click(object sender, EventArgs e)
        {
            //throw new OutOfMemoryException();
        }

        private void DisplayStyleInfoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("These are the following display styles.\r\n\r\n" +
                "Windowed - Displays the alert in a window.\r\n" +
                "Minified - Displays the alert in a notification like window.\r\n" +
                "Full screen - Displays the alert in full screen, and TTS is spoken automatically.\r\n" +
                "Full scroll - Displays the alert in a scrolling bar, and TTS is spoken automatically.\r\n" +
                "Full board - Like full screen, but for digital signage. Instantly appears.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DisplayWhereInfoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This option changes where the window appears on the screen.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}

