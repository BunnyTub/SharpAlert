using System;
using System.Windows.Forms;

namespace SharpAlert
{
    public partial class StartupForm : Form
    {
        public StartupForm()
        {
            InitializeComponent();
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
        }

        private void AutoClose_Tick(object sender, EventArgs e)
        {
            if (IceBearWorker.ServiceRunnerScheduled)
            {
                AllowClose = true;
                this.Close();
            }
        }

        private bool AllowClose = false;

        private void StartupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !AllowClose;
        }
    }
}
