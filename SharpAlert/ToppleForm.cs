using System;
using System.Diagnostics;
using System.Windows.Forms;
using SharpAlert.ProgramWorker;

namespace SharpAlert
{
    public partial class ToppleForm : Form
    {
        private readonly string ToppleReason = string.Empty;
        private readonly bool HostProcessOfSubProcess = false;

        public ToppleForm(string Reason, bool _HostProcessOfSubProcess)
        {
            InitializeComponent();
            ToppleReason = Reason;
            HostProcessOfSubProcess = _HostProcessOfSubProcess;
            //if (!HostProcessOfSubProcess)
            //{
            //    DebuggerButton.Enabled = false;
            //    DebuggerButton.Text = "Debugger Unavailable";
            //}
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

        private void TerminateButton_Click(object sender, EventArgs e)
        {
            Environment.Exit(-1);
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            QuickSettings.ReadOnlyMode = false;
            QuickSettings.Instance.Reset();
            QuickSettings.Instance.Save();
            MessageBox.Show("Settings reset. You'll need to reopen SharpAlert manually.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            Environment.Exit(-1);
        }

        private void DebuggerButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
    }
}

