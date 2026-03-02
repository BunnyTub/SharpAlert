using System;
using System.Windows.Forms;
using SharpAlert.Languages;
using SharpAlert.ProgramWorker;
using static SharpAlert.ProgramWorker.MainEntryPoint;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class ExtraConfigurationForm : Form
    {
        public ExtraConfigurationForm(bool ShowNextInsteadOfDone)
        {
            InitializeComponent();

            Language.ApplyFont(this);

            Text = $"SharpAlert - {Language.Get("WindowTitle_ExtraSettings", "Extra Settings")}";

            ChangeLaterText.Text = Language.Get("GoToSettings", "To change these options later, go to Settings.");
            SaveSlotsButton.Text = Language.Get("SettingsButton_SaveSlots", "Save Slots");

            if (ShowNextInsteadOfDone)
            {
                DoneButton.Text = Language.Get("Button_Next", "Next");
                TitleText.Text = "Anything else you want to change?";
            }
            else
            {
                DoneButton.Text = Language.Get("Button_Done", "Done");
                TitleText.Text = "Choose your extra settings.";
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

            if (QuickSettings.Instance.alertFullscreenIdle)
            {
                QuickSettings.Instance.alertFullscreenIdle = false;
                MessageBox.Show("The idle panel has been deprecated.\r\nConsider using the new dashboard!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
            if (QuickSettings.Instance.statusWindow)
            {
                QuickSettings.Instance.statusWindow = false;
                MessageBox.Show("The status panel has been deprecated.\r\nConsider using the new dashboard!", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            alertFullscreenIdleBox.Checked = false;
            alertFullscreenIdleBox.Enabled = false;

            statusWindowBox.Checked = false;
            statusWindowBox.Enabled = false;

            OpenDashboardAutomaticallyBox.Checked = QuickSettings.Instance.OpenDashboardAutomatically;
            OpenDashboardAutomaticallyBox.CheckedChanged += (a, b) => QuickSettings.Instance.OpenDashboardAutomatically = ((CheckBox)a).Checked;

            alertCompatibilityModeBox.Checked = QuickSettings.Instance.alertCompatibilityMode;
            alertCompatibilityModeBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertCompatibilityMode = ((CheckBox)a).Checked;

            NoSystemSleepBox.Checked = QuickSettings.Instance.NoSystemSleep;
            NoSystemSleepBox.CheckedChanged += (a, b) => QuickSettings.Instance.NoSystemSleep = ((CheckBox)a).Checked;

            HideNetworkErrorsBox.Checked = QuickSettings.Instance.HideNetworkErrors;
            HideNetworkErrorsBox.CheckedChanged += (a, b) => QuickSettings.Instance.HideNetworkErrors = ((CheckBox)a).Checked;

            PlayChimeOnRunBox.Checked = QuickSettings.Instance.PlayChimeOnRun;
            PlayChimeOnRunBox.CheckedChanged += (a, b) => QuickSettings.Instance.PlayChimeOnRun = ((CheckBox)a).Checked;
        }

        private void ChooseRegionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            slots?.Close();
        }

        private void ChooseRegionForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Hover over the options for their respective info.",
                "SharpAlert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            e.Cancel = true;
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

        private SaveSlotsConfigurationForm slots = null;

        private void SaveSlotsButton_Click(object sender, EventArgs e)
        {
            if (slots == null || slots.IsDisposed) slots = new SaveSlotsConfigurationForm();
            slots.Show();
            slots.Activate();
        }
    }
}

