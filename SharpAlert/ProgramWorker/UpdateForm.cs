using System;
using System.Media;
using System.Windows.Forms;

namespace SharpAlert.ProgramWorker
{
    public partial class UpdateForm : Form
    {
        public UpdateForm()
        {
            InitializeComponent();
        }

        private void SetupForm_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            SystemSounds.Asterisk.Play();
        }

        private void UpdateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private bool PleaseWaitTextBlink = false;

        private void TextUpdater_Tick(object sender, EventArgs e)
        {
            if (PleaseWaitTextBlink)
            {
                this.Text = "SharpAlert - Updating (please wait...)";
            }
            else
            {
                this.Text = "SharpAlert - Updating";
            }

            PleaseWaitTextBlink = !PleaseWaitTextBlink;
        }
    }
}

