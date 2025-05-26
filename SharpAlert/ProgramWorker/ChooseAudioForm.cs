using System;
using System.Windows.Forms;

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

        private void ChooseRegionForm_Load(object sender, EventArgs e)
        {
            // executes multiple times
        }

        private void ChooseRegionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void ChooseRegionForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //MessageBox.Show("Hover over the region boxes for their respective info.",
            //    "SharpAlert",
            //    MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);
            e.Cancel = true;
        }
    }
}
