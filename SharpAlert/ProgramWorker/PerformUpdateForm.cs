using System;
using System.Media;
using System.Windows.Forms;

namespace SharpAlert.ProgramWorker
{
    public partial class PerformUpdateForm : Form
    {
        public PerformUpdateForm()
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
            //e.Cancel = true;
        }

        private void CheckTimeUntilAutoInstall_Tick(object sender, EventArgs e)
        {
            string DescText = "SharpAlert will install updates automatically in:\r\n%t";

            TimeSpan Remaining = UpdateWorker.TimeUntilUpdate - DateTime.UtcNow;

            DescriptionText.Text = DescText.Replace("%t", $"{(int)Remaining.TotalMinutes} minutes, {Remaining.Seconds} seconds");

            if (Remaining.TotalSeconds <= 0)
            {
                CheckTimeUntilAutoInstall.Stop();
                DescriptionText.Text = "Preparing to install updates.";
                InstallButton.PerformClick();
            }
        }

        private void InstallButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void RemindMeLaterButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            this.Close();
        }
    }
}

