using SharpAlert.ProgramWorker;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class SecretConfigurationForm : Form
    {
        public SecretConfigurationForm()
        {
            InitializeComponent();
        }

        private void ForceUpdateButton_Click(object sender, EventArgs e)
        {
            UpdateWorker.TryUpdate(UpdateWorker.TryGetRemoteVersion(), true);
        }

        private void SoftUpdateButton_Click(object sender, EventArgs e)
        {
            UpdateWorker.TryUpdate(UpdateWorker.TryGetRemoteVersion(), false);
        }

        private void BrokenUpdateButton_Click(object sender, EventArgs e)
        {
            UpdateWorker.TryUpdate(Path.GetInvalidFileNameChars().ToString() + Path.GetInvalidPathChars().ToString(), false);
        }

        private void CheckForDebugger_Tick(object sender, EventArgs e)
        {
            if (Debugger.IsAttached || MainEntryPoint.ServiceMode)
            {
                DebuggerText.Text = "Currently being debugged, and/or in service mode.\r\nSome features like updating may be unavailable.\r\n";
            }
            else
            {
                DebuggerText.Text = "The program is currently running normally.\r\nPlease report any issues that occur in normal operation.";
            }
        }
    }
}
