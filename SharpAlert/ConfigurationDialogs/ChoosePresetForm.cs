using System;
using System.Windows.Forms;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class ChoosePresetForm : Form
    {
        public ChoosePresetForm()
        {
            InitializeComponent();
        }

        private void PreferMinorButton_Click(object sender, EventArgs e)
        {
            QuickSettings.Instance.statusActual = true;
            QuickSettings.Instance.statusExercise = false;
            QuickSettings.Instance.statusTest = false;

            QuickSettings.Instance.messageTypeAlert = true;
            QuickSettings.Instance.messageTypeUpdate = true;
            QuickSettings.Instance.messageTypeCancel = true;
            QuickSettings.Instance.messageTypeTest = false;

            QuickSettings.Instance.severityUnknown = true;
            QuickSettings.Instance.severityMinor = true;
            QuickSettings.Instance.severityModerate = true;
            QuickSettings.Instance.severitySevere = true;
            QuickSettings.Instance.severityExtreme = true;

            QuickSettings.Instance.urgencyFuture = true;
            QuickSettings.Instance.urgencyExpected = true;
            QuickSettings.Instance.urgencyImmediate = true;
            QuickSettings.Instance.urgencyPast = false;
            QuickSettings.Instance.urgencyUnknown = true;

            this.Close();
        }

        private void PreferSevereButton_Click(object sender, EventArgs e)
        {
            QuickSettings.Instance.statusActual = true;
            QuickSettings.Instance.statusExercise = false;
            QuickSettings.Instance.statusTest = false;

            QuickSettings.Instance.messageTypeAlert = true;
            QuickSettings.Instance.messageTypeUpdate = true;
            QuickSettings.Instance.messageTypeCancel = true;
            QuickSettings.Instance.messageTypeTest = false;

            QuickSettings.Instance.severityUnknown = false;
            QuickSettings.Instance.severityMinor = false;
            QuickSettings.Instance.severityModerate = false;
            QuickSettings.Instance.severitySevere = true;
            QuickSettings.Instance.severityExtreme = true;

            QuickSettings.Instance.urgencyFuture = true;
            QuickSettings.Instance.urgencyExpected = true;
            QuickSettings.Instance.urgencyImmediate = true;
            QuickSettings.Instance.urgencyPast = false;
            QuickSettings.Instance.urgencyUnknown = false;

            this.Close();
        }

        private void PreferAllButton_Click(object sender, EventArgs e)
        {
            QuickSettings.Instance.statusActual = true;
            QuickSettings.Instance.statusExercise = true;
            QuickSettings.Instance.statusTest = true;

            QuickSettings.Instance.messageTypeAlert = true;
            QuickSettings.Instance.messageTypeUpdate = true;
            QuickSettings.Instance.messageTypeCancel = true;
            QuickSettings.Instance.messageTypeTest = true;

            QuickSettings.Instance.severityUnknown = true;
            QuickSettings.Instance.severityMinor = true;
            QuickSettings.Instance.severityModerate = true;
            QuickSettings.Instance.severitySevere = true;
            QuickSettings.Instance.severityExtreme = true;

            QuickSettings.Instance.urgencyFuture = true;
            QuickSettings.Instance.urgencyExpected = true;
            QuickSettings.Instance.urgencyImmediate = true;
            QuickSettings.Instance.urgencyPast = true;
            QuickSettings.Instance.urgencyUnknown = true;

            this.Close();
        }

        private void SkipButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You can change individual options in CAP Settings later.",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            this.Close();
        }
    }
}
