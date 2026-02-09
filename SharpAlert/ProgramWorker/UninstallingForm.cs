using SharpAlert.AlertComponents;
using System;
using System.Windows.Forms;

namespace SharpAlert.ProgramWorker
{
    public partial class UninstallingForm : Form
    {
        public UninstallingForm()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DescriptionLinkText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HackyWorkarounds.OpenURL("https://bunnytub.com");
        }

        private void AutoClose_Tick(object sender, EventArgs e)
        {
            if (AutoCloseProgress.Value == 30)
            {
                AutoClose.Stop();
                this.Close();
                return;
            }

            AutoCloseProgress.Increment(1);
        }
    }
}

