using System;
using System.Windows.Forms;

namespace SharpAlert.ProgramWorker
{
    public partial class SetupForm : Form
    {
        public SetupForm()
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
            FadeInAnimation.Enabled = true;
        }

        private readonly object FadeObject = new object();

        private void FadeInAnimation_Tick(object sender, EventArgs e)
        {
            lock (FadeObject)
            {
                if (this.Opacity >= 1.0)
                {
                    FadeInAnimation.Enabled = false;
                    return;
                }
                this.Opacity += 0.01;
            }
        }
    }
}

