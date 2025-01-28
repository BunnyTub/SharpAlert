using SharpAlert.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.Program;

namespace SharpAlert
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
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

            DiscordWebhookURLInput.Text = Settings.Default.DiscordWebhook;
            DiscordWebhookAppendInput.Text = Settings.Default.DiscordWebhookAppend;

            if (string.IsNullOrWhiteSpace(DiscordWebhookURLInput.Text)) AlertAppearanceGroup.Enabled = true;
            else AlertAppearanceGroup.Enabled = false;

            alertFullscreenBox.Checked = Settings.Default.alertFullscreen;
            if (alertFullscreenBox.Checked)
            {
                alertFullscreenIdleBox.Enabled = true;
                alertFullscreenDisplayInput.Enabled = true;
            }
            else
            {
                alertFullscreenIdleBox.Enabled = false;
                alertFullscreenDisplayInput.Enabled = false;
            }
            alertFullscreenBox.CheckedChanged += (a, b) =>
            {
                ((CheckBox)a).Enabled = false;
                Settings.Default.alertFullscreen = ((CheckBox)a).Checked;
                if (((CheckBox)a).Checked)
                {
                    alertFullscreenIdleBox.Enabled = true;
                    alertFullscreenDisplayInput.Enabled = true;
                }
                else
                {
                    alertFullscreenIdleBox.Enabled = false;
                    alertFullscreenIdleBox.Checked = false;
                    alertFullscreenDisplayInput.Enabled = false;
                }
                Thread.Sleep(500);
                ((CheckBox)a).Enabled = true;
            };

            alertTimeoutInput.Value = Settings.Default.alertTimeout;
            alertTimeoutInput.ValueChanged += (a, b) => Settings.Default.alertTimeout = (int)((NumericUpDown)a).Value;

            alertFullscreenIdleBox.Checked = Settings.Default.alertFullscreenIdle;
            alertFullscreenIdleBox.CheckedChanged += (a, b) =>
            {
                ((CheckBox)a).Enabled = false;
                Settings.Default.alertFullscreenIdle = ((CheckBox)a).Checked;

                if (((CheckBox)a).Checked)
                {
                    CreateIdleWindow();
                }
                else
                {
                    DestroyIdleWindow();
                }

                Thread.Sleep(500);
                ((CheckBox)a).Enabled = true;

                this.BringToFront();
            };

            alertFullscreenIdleTimeZoneUTCBox.Checked = Settings.Default.alertFullscreenIdleTimeZoneUTC;
            alertFullscreenIdleTimeZoneUTCBox.CheckedChanged += (a, b) => Settings.Default.alertFullscreenIdleTimeZoneUTC = ((CheckBox)a).Checked;

            bool alertFullscreenDisplayIgnoreInput = false;
            alertFullscreenDisplayInput.Value = Settings.Default.alertFullscreenDisplay;
            alertFullscreenDisplayInput.ValueChanged += (a, b) =>
            {
                if (alertFullscreenDisplayIgnoreInput) return;

                //bool MonitorNonExistant = false

                if ((int)((NumericUpDown)a).Value >= Screen.AllScreens.Count())
                {
                    if (MessageBox.Show("The monitor you've chosen doesn't exist right now, and the idle and alert panels will be shown on the default monitor until it does exist. Do you want to use it anyway?",
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        Settings.Default.alertFullscreenDisplay = (int)((NumericUpDown)a).Value;
                        //MonitorNonExistant = true;
                    }
                    else
                    {
                        alertFullscreenDisplayIgnoreInput = true;
                        ((NumericUpDown)a).Value = Settings.Default.alertFullscreenDisplay;
                        alertFullscreenDisplayIgnoreInput = false;
                        return;
                    }
                }
                else
                {
                    Screen screen = Screen.AllScreens[(int)((NumericUpDown)a).Value];

                    if (MessageBox.Show($"Use \"{screen.DeviceName}\" ({screen.Bounds.Width} x {screen.Bounds.Height})?",
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Settings.Default.alertFullscreenDisplay = (int)((NumericUpDown)a).Value;
                    }
                    else
                    {
                        alertFullscreenDisplayIgnoreInput = true;
                        ((NumericUpDown)a).Value = Settings.Default.alertFullscreenDisplay;
                        alertFullscreenDisplayIgnoreInput = false;
                        return;
                    }
                }
            };

            alertCompatibilityModeBox.Checked = Settings.Default.alertCompatibilityMode;
            alertCompatibilityModeBox.CheckedChanged += (a, b) => Settings.Default.alertCompatibilityMode = ((CheckBox)a).Checked;

            statusWindowBox.Checked = Settings.Default.statusWindow;
            statusWindowBox.CheckedChanged += (a, b) =>
            {
                ((CheckBox)a).Enabled = false;

                if (((CheckBox)a).Checked)
                {
                    CreateStatusWindow();
                }
                else
                {
                    DestroyStatusWindow();
                }

                Thread.Sleep(500);
                ((CheckBox)a).Enabled = true;
            };

            string SAME_Areas = string.Empty;
            foreach (string area in Settings.Default.AllowedSAMELocations_Geocodes) SAME_Areas += area + "\r\n";
            SAME_Areas = SAME_Areas.Trim();
            AreaSAMEOutput.Text = SAME_Areas;

            string UGC_Areas = string.Empty;
            foreach (string area in Settings.Default.AllowedUGCLocations_Geocodes) UGC_Areas += area + "\r\n";
            UGC_Areas = UGC_Areas.Trim();
            AreaUGCOutput.Text = UGC_Areas;

            RefreshAlertHistory();
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

        private void EventClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear SAME event blacklist data?", "SharpAlert", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Settings.Default.EnforceEventBlacklist.Clear();
                EventBlacklistOutput.Text = string.Empty;
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

        private void AlertHistoryClearButton_Click(object sender, EventArgs e)
        {
            ClearAlertHistory();
        }

        private void RefreshAlertHistory()
        {
            if (SharpDataHistory.Count != 0)
            {
                string DataHistory = string.Empty;
                foreach (var item in SharpDataHistory) DataHistory += "(MD5)\x20" + item.Name + "\r\n";
                DataHistory.Trim();
                AlertHistoryOutput.Text = DataHistory;
            }
            else
            {
                AlertHistoryOutput.Text = "There is no history available.";
            }
        }
        
        private void ClearAlertHistory()
        {
            RefreshAlertHistory();
            if (SharpDataHistory.Count != 0)
            {
                SharpDataHistory.Clear();
                AlertHistoryOutput.Text = "The history was cleared just now.";
                MessageBox.Show("The history has been cleared.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"There are no items in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void AlertHistoryRefreshButton_Click(object sender, EventArgs e)
        {
            RefreshAlertHistory();
        }

        private void AlertHistoryReplayRecentButton_Click(object sender, EventArgs e)
        {
            RefreshAlertHistory();
            if (SharpDataHistory.Count != 0)
            {
                var alert = SharpDataHistory.Last();
                SharpDataHistory.Remove(alert);
                if (alert.Data.Contains("<SharpAlertReplay>false</SharpAlertReplay>"))
                {
                    alert.Data = alert.Data.Replace("<SharpAlertReplay>false</SharpAlertReplay>", "<SharpAlertReplay>true</SharpAlertReplay>");
                }
                else
                {
                    alert.Data += "<SharpAlertReplay>true</SharpAlertReplay>";
                }
                SharpDataQueue.Add(alert);
            }
            else
            {
                MessageBox.Show($"There are no items in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void NS_UnhideSecureBox_CheckedChanged(object sender, EventArgs e)
        {
            DiscordWebhookURLInput.UseSystemPasswordChar = ((CheckBox)sender).Checked;
            DiscordWebhookAppendInput.UseSystemPasswordChar = ((CheckBox)sender).Checked;
        }

        private void OpenCreditsButton_Click(object sender, EventArgs e)
        {
            new CreditsForm().ShowDialog();
        }

        private void SaveDiscordSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.Default.DiscordWebhook = DiscordWebhookURLInput.Text.Trim();
            Settings.Default.DiscordWebhookAppend = DiscordWebhookAppendInput.Text.Trim();

            if (string.IsNullOrWhiteSpace(DiscordWebhookURLInput.Text)) AlertAppearanceGroup.Enabled = true;
            else AlertAppearanceGroup.Enabled = false;
        }

        private void CacheOperationButton_Click(object sender, EventArgs e)
        {
            cache.ServiceRun(false);
        }

        private void AlertHistoryDumpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (SharpDataHistory.Count != 0)
            {
                string directory = AssemblyDirectory + "\\dump";
                Directory.CreateDirectory(directory);
                lock (SharpDataHistory) foreach (var item in Program.SharpDataHistory) File.WriteAllText(directory + "\\" + item.Name + ".xml", item.Data);
                MessageBox.Show($"{SharpDataHistory.Count} item(s) saved to the dump directory.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Process.Start(AssemblyDirectory + "\\dump");
            }
            else
            {
                MessageBox.Show($"There are no items in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
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
