using System;
using System.Windows.Forms;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class DoNotDisturbForm : Form
    {
        public int DNDTimeInMinutes { get; private set; } = 0;

        public DoNotDisturbForm()
        {
            InitializeComponent();
        }

        private void OneHourStopButton_Click(object sender, EventArgs e)
        {
            DNDTimeInMinutes = 60;
            DialogResult = DialogResult.Yes;
        }

        private void TwoHourStopButton_Click(object sender, EventArgs e)
        {
            DNDTimeInMinutes = 120;
            DialogResult = DialogResult.Yes;
        }

        private void OneDayStopButton_Click(object sender, EventArgs e)
        {
            DNDTimeInMinutes = 1440;
            DialogResult = DialogResult.Yes;
        }

        private void FiniteStopButton_Click(object sender, EventArgs e)
        {
            DNDTimeInMinutes = -1;
            DialogResult = DialogResult.Yes;
        }

        private void LogoBox_Click(object sender, EventArgs e)
        {
            DNDTimeInMinutes = 1;
            DialogResult = DialogResult.Yes;
        }

        private void DoNotDisturbForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Do Not Disturb (also abbreviated \"DND\") is a feature that stops/pauses alerts from being processed. DND is disabled automatically if SharpAlert closes for any reason, even a crash.", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
