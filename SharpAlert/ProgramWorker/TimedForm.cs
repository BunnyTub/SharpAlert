using System;
using System.Windows.Forms;

namespace SharpAlert
{
    public partial class TimedForm : Form
    {
        public TimedForm()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetupForm_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
        }
    }
}
