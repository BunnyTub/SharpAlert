using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlertPluginBase.AlertContents;
using SharpAlert.ProgramWorker;
using SharpAlert.AlertComponents;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class AlertTableForm : Form
    {
        //private readonly ServerConfigurationForm scf = new ServerConfigurationForm();

        public AlertTableForm()
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

        private void RefreshAlertHistory()
        {
            if (SharpDataHistory.Count != 0)
            {
                string DataHistory = string.Empty;
                lock (SharpDataHistory)
                {
                    foreach (var item in SharpDataHistory)
                    {
                        listView1.Items.Add(item.Name);
                        //DataHistory = $"{item.Name}\r\n{DataHistory}";
                    }
                    //AlertHistoryText.Text = $"Count: {SharpDataHistory.Count} alert(s)";
                }
                DataHistory.Trim();
                //AlertHistoryOutput.Text = DataHistory;
            }
            else
            {
                //AlertHistoryText.Text = "There are no items in the history.";
                listView1.Items.Clear();
            }
        }

        private void AlertHistoryReplayRecentButton_Click(object sender, EventArgs e)
        {
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
                            foreach (var item in SharpDataHistory)
                            {
                                string name = item.Name;
                                // some names relayed love having illegal filepath characters
                                // this is the best fix I can think of, other than just using an MD5 of the data
                                name = string.Join("_", name.Split(Path.GetInvalidFileNameChars()));
                                File.WriteAllText(directory + "\\" + name + ".cap", item.Data);
                            }
                        }
                        else
                        {
                            if (result == DialogResult.No)
                            {
                                string FullData = "<SharpAlertMassImport>true</SharpAlertMassImport>\r\n";

                                foreach (var item in SharpDataHistory)
                                {
                                    FullData += $"{item.Data}";
                                }

                                File.WriteAllText(directory + $"\\Bundled_{DateTime.UtcNow.Ticks}.cap", FullData);
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

        private void ConfigurationForm_VisibleChanged(object sender, EventArgs e)
        {
        }

        private readonly AlertInfoForm aif = new AlertInfoForm();

        private void RevealRecentButton_Click(object sender, EventArgs e)
        {
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
        }

        private void ConfigurationPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

