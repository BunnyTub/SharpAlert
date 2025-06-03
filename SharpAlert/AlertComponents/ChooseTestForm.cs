using System;
using System.Windows.Forms;
using SharpAlert.Properties;

namespace SharpAlert
{
    public partial class ChooseTestForm : Form
    {
        public ChooseTestForm(bool ShowNextInsteadOfDone)
        {
            InitializeComponent();
            if (ShowNextInsteadOfDone) DoneButton.Text = "Next";
            else DoneButton.Text = "Done";
        }

        public string EventType = string.Empty;
        public string EventDescription = string.Empty;
        public string EventURL = string.Empty;

        private void DoneButton_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(AlertTypeInput.Text) &&
                string.IsNullOrEmpty(AlertDescriptionInput.Text)))
            {
                EventType = AlertTypeInput.Text;
                EventDescription = AlertDescriptionInput.Text;
            }

            if (EarthquakeAlertBox.Checked) EventURL = "https://sasmex.net";

            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void ChooseRegionForm_Load(object sender, EventArgs e)
        {
            // reset to defaults every time
            EventType = "Standard Test";
            EventDescription = Resources.TestScript;
            EventURL = "https://sharpalert.bunnytub.com";
        }

        private void ChooseRegionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (string.IsNullOrEmpty(AlertTypeInput.Text) &&
                string.IsNullOrEmpty(AlertDescriptionInput.Text))
            {
                return;
            }

            if (string.IsNullOrEmpty(AlertTypeInput.Text) ||
                string.IsNullOrEmpty(AlertDescriptionInput.Text))
            {
                MessageBox.Show("You must enter all values if you want to use custom data.\r\n" +
                    "If you do not want this feature, leave all fields blank.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                e.Cancel = true;
                return;
            }


        }

        private void ChooseRegionForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
    }
}
