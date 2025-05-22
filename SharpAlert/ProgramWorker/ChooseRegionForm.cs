using System;
using System.Windows.Forms;
using SharpAlert.Properties;

namespace SharpAlert
{
    public partial class ChooseRegionForm : Form
    {
        public ChooseRegionForm(bool ShowNextInsteadOfDone)
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
            RegionUnitedStatesBox.Checked = Settings.Default.RegionUnitedStates;
            RegionUnitedStatesBox.CheckedChanged += (a, b) => Settings.Default.RegionUnitedStates = ((CheckBox)a).Checked;
            RegionCanadaBox.Checked = Settings.Default.RegionCanada;
            RegionCanadaBox.CheckedChanged += (a, b) => Settings.Default.RegionCanada = ((CheckBox)a).Checked;
            RegionMexicoBox.Checked = Settings.Default.RegionMexico;
            RegionMexicoBox.CheckedChanged += (a, b) => Settings.Default.RegionMexico = ((CheckBox)a).Checked;
        }

        private void ChooseRegionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool AtLeastOneChecked = false;

            foreach (var control in this.Controls)
            {
                if (control is CheckBox box)
                {
                    if (box.Checked)
                    {
                        AtLeastOneChecked = true;
                        break;
                    }
                }
            }

            if (AtLeastOneChecked)
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                if (MessageBox.Show("There are no regions selected.\r\n" +
                    "Do you want to continue without alert polling?",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ChooseRegionForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Hover over the region boxes for their respective info.",
                "SharpAlert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            e.Cancel = true;
        }
    }
}
