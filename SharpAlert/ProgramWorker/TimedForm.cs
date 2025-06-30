using System;
using System.Windows.Forms;

namespace SharpAlert
{
    public partial class TimedForm : Form
    {
        public TimedForm(bool OutOfDate)
        {
            InitializeComponent();

            if (OutOfDate)
            {
                label3.Text = "You are using a copy of SharpAlert that is intended for beta testing. You can still continue using this version, however, do not expect support or assistance.\r\n\r\n" +
                    "This dialog closes automatically after 15 seconds.";
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetupForm_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void AutoClose_Tick(object sender, EventArgs e)
        {
            AutoClose.Enabled = false;
            this.Close();
        }
    }
}
