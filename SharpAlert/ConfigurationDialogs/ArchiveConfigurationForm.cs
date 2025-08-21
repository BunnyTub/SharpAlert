using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.ProgramWorker.HaidaWorker;
using static SharpAlert.AlertComponents.AlertProcessor;
using SharpAlert.ProgramWorker;
using SharpAlert.AlertComponents;
using System.Collections.Generic;

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
    }
}

