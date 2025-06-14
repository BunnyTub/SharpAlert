using System;
using System.Windows.Forms;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class ManagementForm : Form
    {
        public ManagementForm()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
