using System;
using System.Windows.Forms;
using SharpAlert.Properties;

namespace SharpAlert
{
    public partial class ChooseOwnershipForm : Form
    {
        public ChooseOwnershipForm(bool ShowNextInsteadOfDone)
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
            if (Initialized) return;
            Initialized = true;

            StationIdentifierInput.Text = Settings.Default.StationIdentifier;
            StationNameInput.Text = Settings.Default.StationName;
        }

        private void ChooseRegionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(StationIdentifierInput.Text) &&
                string.IsNullOrEmpty(StationNameInput.Text))
            {
                return;
            }

            if (string.IsNullOrEmpty(StationIdentifierInput.Text) ||
                string.IsNullOrEmpty(StationNameInput.Text))
            {
                MessageBox.Show("You must enter all values if you want to use station info.\r\n" +
                    "If you do not want this feature, leave all fields blank.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }

            Settings.Default.StationIdentifier = StationIdentifierInput.Text;
            Settings.Default.StationName = StationNameInput.Text;
        }

        private void ChooseRegionForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Hover over the options for their respective info.\r\n" +
                "This information is used to stylize alerts.\r\n" +
                "It is completely optional.",
                "SharpAlert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            e.Cancel = true;
        }
    }
}
