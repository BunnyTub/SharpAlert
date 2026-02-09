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
using static SharpAlertPluginBase.AlertContents;
using SharpAlert.ProgramWorker;
using SharpAlert.AlertComponents;
using System.Collections.Generic;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class AlertListForm : Form
    {
        //private readonly ServerConfigurationForm scf = new ServerConfigurationForm();

        public AlertListForm()
        {
            InitializeComponent();
        }

        private bool Initialized = false;

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            RefreshAlertHistory();

            if (Initialized) return;
            Initialized = true;

            //lock (notify)
            //{
            //    notify.BalloonTipTitle = "SharpAlert is initializing Settings";
            //    notify.BalloonTipText = "Settings is getting ready to be shown. This may take a few moments.";
            //    notify.BalloonTipIcon = ToolTipIcon.Info;
            //    notify.ShowBalloonTip(5000);
            //}

            RefreshAlertHistory();
        }

        private void AlertHistoryClearButton_Click(object sender, EventArgs e)
        {
            ClearAlertHistory();
        }

        private void RefreshAlertHistory()
        {
            LastKnownHistoryCount = SharpDataHistory.Count;

            if (SharpDataHistory.Count != 0)
            {
                string DataHistory = string.Empty;
                lock (SharpDataHistory)
                {
                    foreach (var item in SharpDataHistory)
                    {
                        DataHistory = $"{item.Name}\r\n{DataHistory}";
                    }
                    AlertHistoryText.Text = $"Count: {SharpDataHistory.Count} alert(s)";
                }
                DataHistory.Trim();
                AlertHistoryOutput.Text = DataHistory;
            }
            else
            {
                AlertHistoryText.Text = "There are no items in the history.";
                AlertHistoryOutput.Clear();
            }
        }
        
        private void ClearAlertHistory()
        {
            RefreshAlertHistory();
            if (SharpDataHistory.Count != 0)
            {
                SharpDataHistory.Clear();
                SharpDataRelayedNamesHistory.Clear();
                AlertHistoryText.Text = "The history was cleared.";
                AlertHistoryOutput.Clear();
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
            AlertHistoryRefreshButton.BackColor = Color.FromArgb(60, 60, 60);
            RefreshAlertHistory();
        }

        private void AlertHistoryReplayRecentButton_Click(object sender, EventArgs e)
        {
            PastAlertsGroup.Enabled = false;
            Thread.Sleep(500);
            try
            {
                RefreshAlertHistory();
                if (SharpDataHistory.Count != 0)
                {
                    lock (SharpDataQueue)
                    {
                        lock (SharpDataHistory)
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

                            //AlertInfo alertInfo = dataproc.ap.ProcessAlertItem(alert, true, false);

                            //if (alertInfo == null)
                            //{
                            //    MessageBox.Show("The alert does not meet the requirements you've set, so it has not been relayed.",
                            //        "SharpAlert",
                            //        MessageBoxButtons.OK,
                            //        MessageBoxIcon.Exclamation);
                            //}
                            //else
                            //{
                            //    if (!string.IsNullOrWhiteSpace(alertInfo.AlertDiscardReason))
                            //    {
                            //        MessageBox.Show($"{alertInfo.AlertDiscardReason}",
                            //            "SharpAlert",
                            //            MessageBoxButtons.OK,
                            //            MessageBoxIcon.Exclamation);
                            //    }
                            //}
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"There are no items in the history.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
            }

            Thread.Sleep(500);
            PastAlertsGroup.Enabled = true;
        }

        private void AlertHistoryReplayAllButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to process all alerts again?\r\nThis may take some time.", "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
            {
                return;
            }

            PastAlertsGroup.Enabled = false;
            Thread.Sleep(500);
            try
            {
                RefreshAlertHistory();
                if (SharpDataHistory.Count != 0)
                {
                    lock (SharpDataQueue)
                    {
                        lock (SharpDataHistory)
                        {
                            List<SharpDataItem> DataItems = new List<SharpDataItem>();
                            DataItems.AddRange(SharpDataHistory);
                            SharpDataHistory.Clear();
                            SharpDataQueue.AddRange(DataItems);

                            //if (alert.Data.Contains("<SharpAlertReplay>false</SharpAlertReplay>"))
                            //{
                            //    alert.Data = alert.Data.Replace("<SharpAlertReplay>false</SharpAlertReplay>", "<SharpAlertReplay>true</SharpAlertReplay>");
                            //}
                            //else
                            //{
                            //    alert.Data += "<SharpAlertReplay>true</SharpAlertReplay>";
                            //}

                            //AlertInfo alertInfo = dataproc.ap.ProcessAlertItem(alert, true, false);

                            //if (alertInfo == null)
                            //{
                            //    MessageBox.Show("The alert does not meet the requirements you've set, so it has not been relayed.",
                            //        "SharpAlert",
                            //        MessageBoxButtons.OK,
                            //        MessageBoxIcon.Exclamation);
                            //}
                            //else
                            //{
                            //    if (!string.IsNullOrWhiteSpace(alertInfo.AlertDiscardReason))
                            //    {
                            //        MessageBox.Show($"{alertInfo.AlertDiscardReason}",
                            //            "SharpAlert",
                            //            MessageBoxButtons.OK,
                            //            MessageBoxIcon.Exclamation);
                            //    }
                            //}
                        }
                    }
                }
                else
                {
                    MessageBox.Show($"There are no items in the history.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            Thread.Sleep(500);
            PastAlertsGroup.Enabled = true;
        }
        private void AlertHistoryDumpLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Export all alerts separately?\r\n" +
                "Choosing NO will bundle all alerts into one file.",
                "SharpAlert",
                MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Cancel) return;

            if (SharpDataHistory.Count != 0)
            {
                try
                {
                    string directory = QuickSettings.ConfigDirPath + "\\Exports";

                    Directory.CreateDirectory(directory);
                    lock (SharpDataHistory)
                    {
                        //BundledAlerts_Timestamp.cap
                        if (result == DialogResult.Yes)
                        {
                            char[] invalidChars = Path.GetInvalidFileNameChars();

                            foreach (var item in SharpDataHistory)
                            {
                                string name = item.Name;

                                foreach (char character in name)
                                {
                                    if (invalidChars.Contains(character))
                                    {
                                        name = name.Replace(character, '_');
                                    }
                                }

                                File.WriteAllText(directory + "\\" + name + ".xml", item.Data);
                            }
                        }
                        else
                        {
                            if (result == DialogResult.No)
                            {
                                //string FullData = "<SharpAlertMassImport>true</SharpAlertMassImport>\r\n";

                                string FullData = string.Empty;

                                foreach (var item in SharpDataHistory)
                                {
                                    FullData += $"{item.Data}";
                                }

                                File.WriteAllText(directory + $"\\Bundled_{DateTime.UtcNow.Ticks}.xml", FullData);
                            }
                        }
                    }

                    MessageBox.Show($"{SharpDataHistory.Count} alert(s) have been exported.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    Process.Start("explorer.exe", $"{directory}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show($"There are no alerts in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void PlayTestButton_Click(object sender, EventArgs e)
        {
            ProcessAlertTest();
        }

        private void ImportFileButton_Click(object sender, EventArgs e)
        {
            AddFileToQueue();
        }

        int LastKnownHistoryCount = 0;

        private void AlertListRefresher_Tick(object sender, EventArgs e)
        {
            if (SharpDataHistory.Count != LastKnownHistoryCount)
            {
                AlertHistoryRefreshButton.BackColor = Color.FromArgb(200, 60, 60);
                AlertHistoryText.Text = $"Count: {SharpDataHistory.Count} alert(s) - Click refresh to update the list";
            }
            //RefreshAlertHistory();
        }

        private void ConfigurationForm_VisibleChanged(object sender, EventArgs e)
        {
        }

        private void RevealButton_Click(object sender, EventArgs e)
        {
            PastAlertsGroup.Enabled = false;
            Thread.Sleep(500);
            RefreshAlertHistory();
            if (SharpDataHistory.Count != 0)
            {
                SharpDataItem alert = null;

                lock (SharpDataHistory)
                {
                    string input = RevealAlertIdentifierInput.Text;

                    alert = SharpDataHistory.FirstOrDefault(item =>
                        string.Equals(item.Name, input, StringComparison.OrdinalIgnoreCase));

                    if (alert == null)
                    {
                        MessageBox.Show("The alert identifier doesn't exist here.\r\nCheck it again, or try another!", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        PastAlertsGroup.Enabled = true;
                        return;
                    }
                    else
                    {
                        RevealAlertIdentifierInput.Clear();
                    }
                }

                AlertInfo info = dataproc.ap.ProcessAlertItem(alert, false, true);
                aif.UpdateFields(info.AlertID,
                    info.AlertEventType,
                    info.AlertIntroText,
                    info.AlertBodyText,
                    info.AlertURL,
                    info.AlertAudioURL,
                    info.AlertImageURL,
                    info.AlertMessageType);
                aif.ShowDialog();
            }
            else
            {
                MessageBox.Show($"There are no items in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            Thread.Sleep(500);
            PastAlertsGroup.Enabled = true;
        }

        private readonly AlertInfoForm aif = new AlertInfoForm();

        private void RevealRecentButton_Click(object sender, EventArgs e)
        {
            PastAlertsGroup.Enabled = false;
            Thread.Sleep(500);
            RefreshAlertHistory();
            if (SharpDataHistory.Count != 0)
            {
                var alert = SharpDataHistory.Last();
                AlertInfo info = dataproc.ap.ProcessAlertItem(alert, false, true);
                aif.UpdateFields(info.AlertID,
                    info.AlertEventType,
                    info.AlertIntroText,
                    info.AlertBodyText,
                    info.AlertURL,
                    info.AlertAudioURL,
                    info.AlertImageURL,
                    info.AlertMessageType);
                aif.ShowDialog();
            }
            else
            {
                MessageBox.Show($"There are no items in the history.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
            Thread.Sleep(500);
            PastAlertsGroup.Enabled = true;
        }
    }
}

