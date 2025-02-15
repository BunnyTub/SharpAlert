using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SharpAlert
{
    public partial class ToppleForm : Form
    {
        private readonly string ToppleReason = string.Empty;

        public ToppleForm(string Reason)
        {
            InitializeComponent();
            ToppleReason = Reason;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ToppleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void ToppleForm_Shown(object sender, EventArgs e)
        {
            ProblemDetailsText.Text = ToppleReason;
            label1.Text = $"{AutoCloseTime}s";
            this.BringToFront();
        }

        private void ReportButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You will be taken to the GitHub website to report this issue. Please explain in detail about what happened as much as you can.",
                "SharpAlert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Process.Start("https://github.com/BunnyTub/SharpAlert-issues/issues/new");
        }

        private int AutoCloseTime = 90;

        private void AutoTerminate_Tick(object sender, EventArgs e)
        {
            if (AutoCloseTime <= 0) this.Close();
            else
            {
                AutoCloseTime--;
                label1.Text = $"{AutoCloseTime}s";
            }
        }

        private void ToppleForm_Load(object sender, EventArgs e)
        {
        }
    }
}
