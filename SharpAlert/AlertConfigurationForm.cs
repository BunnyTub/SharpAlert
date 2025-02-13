using SharpAlert.Properties;
using System;
using System.Windows.Forms;
using static SharpAlert.Program;

namespace SharpAlert
{
    public partial class AlertConfigurationForm : Form
    {
        public AlertConfigurationForm()
        {
            InitializeComponent();
        }

        private void AlertConfigurationForm_Load(object sender, EventArgs e)
        {
            statusTestBox.Checked = Settings.Default.statusTest;
            statusTestBox.CheckedChanged += (a, b) => Settings.Default.statusTest = ((CheckBox)a).Checked;
            statusActualBox.Checked = Settings.Default.statusActual;
            statusActualBox.CheckedChanged += (a, b) => Settings.Default.statusActual = ((CheckBox)a).Checked;

            messageTypeAlertBox.Checked = Settings.Default.messageTypeAlert;
            messageTypeAlertBox.CheckedChanged += (a, b) => Settings.Default.messageTypeAlert = ((CheckBox)a).Checked;
            messageTypeUpdateBox.Checked = Settings.Default.messageTypeUpdate;
            messageTypeUpdateBox.CheckedChanged += (a, b) => Settings.Default.messageTypeUpdate = ((CheckBox)a).Checked;
            messageTypeCancelBox.Checked = Settings.Default.messageTypeCancel;
            messageTypeCancelBox.CheckedChanged += (a, b) => Settings.Default.messageTypeCancel = ((CheckBox)a).Checked;
            messageTypeTestBox.Checked = Settings.Default.messageTypeTest;
            messageTypeTestBox.CheckedChanged += (a, b) => Settings.Default.messageTypeTest = ((CheckBox)a).Checked;

            severityExtremeBox.Checked = Settings.Default.severityExtreme;
            severityExtremeBox.CheckedChanged += (a, b) => Settings.Default.severityExtreme = ((CheckBox)a).Checked;
            severitySevereBox.Checked = Settings.Default.severitySevere;
            severitySevereBox.CheckedChanged += (a, b) => Settings.Default.severitySevere = ((CheckBox)a).Checked;
            severityModerateBox.Checked = Settings.Default.severityModerate;
            severityModerateBox.CheckedChanged += (a, b) => Settings.Default.severityModerate = ((CheckBox)a).Checked;
            severityMinorBox.Checked = Settings.Default.severityMinor;
            severityMinorBox.CheckedChanged += (a, b) => Settings.Default.severityMinor = ((CheckBox)a).Checked;
            severityUnknownBox.Checked = Settings.Default.severityUnknown;
            severityUnknownBox.CheckedChanged += (a, b) => Settings.Default.severityUnknown = ((CheckBox)a).Checked;

            urgencyImmediateBox.Checked = Settings.Default.urgencyImmediate;
            urgencyImmediateBox.CheckedChanged += (a, b) => Settings.Default.urgencyImmediate = ((CheckBox)a).Checked;
            urgencyExpectedBox.Checked = Settings.Default.urgencyExpected;
            urgencyExpectedBox.CheckedChanged += (a, b) => Settings.Default.urgencyExpected = ((CheckBox)a).Checked;
            urgencyFutureBox.Checked = Settings.Default.urgencyFuture;
            urgencyFutureBox.CheckedChanged += (a, b) => Settings.Default.urgencyFuture = ((CheckBox)a).Checked;
            urgencyPastBox.Checked = Settings.Default.urgencyPast;
            urgencyPastBox.CheckedChanged += (a, b) => Settings.Default.urgencyPast = ((CheckBox)a).Checked;
            urgencyUnknownBox.Checked = Settings.Default.urgencyUnknown;
            urgencyUnknownBox.CheckedChanged += (a, b) => Settings.Default.urgencyUnknown = ((CheckBox)a).Checked;

            AlertCheckIntervalInput.Value = Settings.Default.AlertCheckInterval;
            AlertCheckIntervalInput.ValueChanged += (a, b) => Settings.Default.AlertCheckInterval = (int)((NumericUpDown)a).Value;

            weaOnlyBox.Checked = Settings.Default.weaOnly;
            weaOnlyBox.CheckedChanged += (a, b) => Settings.Default.weaOnly = ((CheckBox)a).Checked;
            discardFirstAlertsBox.Checked = Settings.Default.discardFirstAlerts;
            discardFirstAlertsBox.CheckedChanged += (a, b) => Settings.Default.discardFirstAlerts = ((CheckBox)a).Checked;

            string SAME_Areas = string.Empty;
            foreach (string area in Settings.Default.AllowedSAMELocations_Geocodes) SAME_Areas += area + "\r\n";
            SAME_Areas = SAME_Areas.Trim();
            AreaSAMEOutput.Text = SAME_Areas;

            string UGC_Areas = string.Empty;
            foreach (string area in Settings.Default.AllowedUGCLocations_Geocodes) UGC_Areas += area + "\r\n";
            UGC_Areas = UGC_Areas.Trim();
            AreaUGCOutput.Text = UGC_Areas;
        }

        private void SAMEAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AreaSAMEInput.Text))
            {
                Settings.Default.AllowedSAMELocations_Geocodes.Add(AreaSAMEInput.Text);
                string SAME_Areas = string.Empty;
                foreach (string area in Settings.Default.AllowedSAMELocations_Geocodes) SAME_Areas += area + "\r\n";
                SAME_Areas = SAME_Areas.Trim();
                AreaSAMEOutput.Text = SAME_Areas;
                AreaSAMEInput.Clear();
            }
            else
            {
                MessageBox.Show("Enter a SAME location value to add it.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void UGCAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AreaUGCInput.Text))
            {
                Settings.Default.AllowedSAMELocations_Geocodes.Add(AreaUGCInput.Text);
                string UGC_Areas = string.Empty;
                foreach (string area in Settings.Default.AllowedUGCLocations_Geocodes) UGC_Areas += area + "\r\n";
                UGC_Areas = UGC_Areas.Trim();
                AreaUGCOutput.Text = UGC_Areas;
                AreaUGCInput.Clear();
            }
            else
            {
                MessageBox.Show("Enter a UGC location value to add it.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void EventAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EventBlacklistInput.Text))
            {
                Settings.Default.EnforceEventBlacklist.Add(EventBlacklistInput.Text);
                string Events = string.Empty;
                foreach (string SAME_event in Settings.Default.EnforceEventBlacklist) Events += SAME_event + "\r\n";
                Events = Events.Trim();
                EventBlacklistOutput.Text = Events;
                EventBlacklistInput.Clear();
            }
            else
            {
                MessageBox.Show("Enter a SAME event value to add it.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void SAMEClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear SAME location data?", "SharpAlert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Settings.Default.AllowedSAMELocations_Geocodes.Clear();
                AreaSAMEOutput.Text = string.Empty;
            }
        }

        private void UGCClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear UGC location data?", "SharpAlert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Settings.Default.AllowedUGCLocations_Geocodes.Clear();
                AreaUGCOutput.Text = string.Empty;
            }
        }

        private void EventClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear SAME event blacklist data?", "SharpAlert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Settings.Default.EnforceEventBlacklist.Clear();
                EventBlacklistOutput.Text = string.Empty;
            }
        }

        private void BusyLock_Tick(object sender, EventArgs e)
        {
            if (AlertDisplaying)
            {
                ConfigurationPanel.Visible = false;
                BusyLockText.BringToFront();
            }
            else
            {
                ConfigurationPanel.Visible = true;
                BusyLockText.SendToBack();
            }
        }
    }
}
