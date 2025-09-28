using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SharpAlert.DataProcessing;
using SharpAlert.ProgramWorker;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class ArchiveConfigurationForm : Form
    {
        //private readonly ServerConfigurationForm scf = new ServerConfigurationForm();

        public ArchiveConfigurationForm()
        {
            InitializeComponent();
        }

        private bool Initialized = false;

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            if (Initialized) return;
            Initialized = true;

            ArchivingSaveAllAlertsBox.Checked = QuickSettings.Instance.ArchivingSaveAllAlerts;
            ArchivingSaveAllAlertsBox.CheckedChanged += (a, b) => QuickSettings.Instance.ArchivingSaveAllAlerts = ((CheckBox)a).Checked;
            ArchivingDeleteOldAlertsOver48hBox.Checked = QuickSettings.Instance.ArchivingDeleteOldAlertsOver48h;
            ArchivingDeleteOldAlertsOver48hBox.CheckedChanged += (a, b) =>
            {
                if (!((CheckBox)a).Checked)
                {
                    if (MessageBox.Show("Alerts can quickly fill the disk if left unattended without being cleared. Do you want to disable this option anyway?",
                        Text,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        QuickSettings.Instance.ArchivingDeleteOldAlertsOver48h = ((CheckBox)a).Checked;
                    }
                    else
                    {
                        ((CheckBox)a).Checked = true;
                    }
                }
            };
            ArchivingAggressiveProcessingBox.Checked = QuickSettings.Instance.ArchivingAggressiveProcessing;
            ArchivingAggressiveProcessingBox.CheckedChanged += (a, b) => QuickSettings.Instance.ArchivingAggressiveProcessing = ((CheckBox)a).Checked;

            //lock (notify)
            //{
            //    notify.BalloonTipTitle = "SharpAlert is initializing Settings";
            //    notify.BalloonTipText = "Settings is getting ready to be shown. This may take a few moments.";
            //    notify.BalloonTipIcon = ToolTipIcon.Info;
            //    notify.ShowBalloonTip(5000);
            //}

        }

        private void ConfigurationForm_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void DeleteArchiveButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete the archive?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            UseWaitCursor = true;

            QuickSettings.Instance.ArchivingSaveAllAlerts = false;

            Thread.Sleep(1000);

            Directory.CreateDirectory(DataProcessor.ArchivePath);

            string[] files = Directory.GetFiles(DataProcessor.ArchivePath);

            foreach (string file in files)
            {
                try
                {
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Unable to delete a file. {ex.Message}", Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            UseWaitCursor = false;

            MessageBox.Show("Finished deleting the archive. You'll need to enable \"Save all alerts to disk\" to start archiving alerts again.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ArchivingSaveAllAlertsBox.Checked = false;
        }

        private void OpenArchiveButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", DataProcessor.ArchivePath);
        }
    }
}

