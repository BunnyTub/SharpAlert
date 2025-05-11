using System;
using System.Windows.Forms;
using SharpAlert.Properties;

namespace SharpAlert
{
    public partial class ChooseRegionForm : Form
    {
        public ChooseRegionForm()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            bool AtLeastOneChecked = false;

            foreach (var control in this.Controls)
            {
                if (control is CheckBox box)
                {
                    if (box.Checked) AtLeastOneChecked = true;
                    break;
                }
            }

            if (AtLeastOneChecked)
            {
                Settings.Default.RegionShown = true;
                Settings.Default.Save();
                this.Close();
                return;
            }
            else
            {
                MessageBox.Show("Select at least one region.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }
        }
    }
}
