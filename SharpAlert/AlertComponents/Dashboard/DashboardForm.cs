using SharpAlert.ProgramWorker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static SharpAlert.AlertComponents.AlertProcessor;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlertPluginBase.AlertContents;

namespace SharpAlert.AlertComponents.Dashboard
{
    public partial class DashboardForm : Form
    {
        private bool ExpiredAlertsOnly = false;

        public DashboardForm(bool expiredAlertsOnly)
        {
            InitializeComponent();
            DashboardManager.NewProcessedAlert += DashboardManager_NewProcessedAlert;
            ExpiredAlertsOnly = expiredAlertsOnly;
        }

        private readonly List<AlertInfo> AlertListQueue = [];

        private void DashboardManager_NewProcessedAlert(object sender, EventArgs e)
        {
            if (sender is AlertInfo info) AlertListQueue.Add(info);
        }

        private void UpdateGeneralInfoTextTimer_Tick(object sender, EventArgs e)
        {
            //ServerRequestsText.Text = FeedSuccessfulCalls.ToString();

            PrimaryGeneralInfoText.Text = $"Alert Queue: {AlertsQueued + SharpDataQueue.Count} | Alert History: {SharpDataHistory.Count}";
            PrimaryGeneralInfoText.Text = $"Alerts Relayed: {AlertsRelayed} | Alert Queue: {AlertsQueued} | CAP Queue: {SharpDataQueue.Count} | CAP History: {SharpDataHistory.Count}";
            GeneralInfoText.Text = $"{DateTimeOffset.Now:h:mm tt MM/dd/yyyy}";
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {
            DashboardPanel.AutoScroll = true;
            DashboardPanel.HorizontalScroll.Enabled = false;
            DashboardPanel.HorizontalScroll.Visible = false;
            DashboardPanel.HorizontalScroll.Maximum = 0;
            BrandText.Text = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}";
        }

        private void UpdateExpiryTimer_Tick(object sender, EventArgs e)
        {
            lock (DashboardPanel)
            {
                Text = "SharpAlert Dashboard (Checking timestamps)";

                // rewrote with for loop because foreach caused exceptions to occur while removing things
                for (int i = DashboardPanel.Controls.Count - 1; i >= 0; i--)
                {
                    var control = DashboardPanel.Controls[i];

                    if (control is DashboardListItem dli)
                    {
                        TimeSpan lifetime = DateTimeOffset.Now - dli.startOfExistenceDateTime;

                        if (lifetime.TotalHours >= 24)
                        {
                            DashboardPanel.Controls.RemoveAt(i);
                            dli.Dispose();
                            continue;
                        }

                        if (DateTimeOffset.TryParse(dli.alertInfo.AlertExpiryDate, out var dto2))
                        {
                            TimeSpan remaining = dto2 - DateTimeOffset.Now;

                            if (remaining.TotalSeconds <= 0)
                            {
                                int GracePeriod = 5;

                                if (ExpiredAlertsOnly)
                                {
                                    GracePeriod = 30;
                                }

                                TimeSpan grace = TimeSpan.FromMinutes(GracePeriod) + remaining;

                                if (grace.TotalSeconds <= 0)
                                {
                                    DashboardPanel.Controls.RemoveAt(i);
                                    dli.Dispose();
                                }
                                else
                                {
                                    dli.AlertExpiresInTitleText.Text = "Gone in:";
                                    dli.AlertExpiryText.Text = string.Format("{0:D2}m {1:D2}s",
                                        grace.Minutes, grace.Seconds);
                                    dli.ContainerPanel.BackColor = Color.FromArgb(50, 50, 50);

                                    if (ExpiredAlertsOnly)
                                    {
                                        dli.Show();
                                    }
                                }
                            }
                            else
                            {
                                dli.AlertExpiresInTitleText.Text = "Expires in:";
                                dli.AlertExpiryText.Text = string.Format("{0:D2}h {1:D2}m",
                                    remaining.Hours, remaining.Minutes);
                            }
                        }
                        else
                        {
                            DashboardPanel.Controls.RemoveAt(i);
                            dli.Dispose();
                        }
                    }
                }

                Text = "SharpAlert Dashboard";
            }
        }

        private bool OnClock = false;

        private void CycleBetweenInfoAndClockTimer_Tick(object sender, EventArgs e)
        {
            if (OnClock)
            {
                GeneralInfoText.Font = new Font("Segoe UI", 15.75f, FontStyle.Regular);
                UpdateGeneralInfoTextTimer_Tick(sender, EventArgs.Empty);
                UpdateGeneralInfoTextTimer.Start();
                OnClock = false;
            }
            else
            {

                UpdateGeneralInfoTextTimer.Stop();
                GeneralInfoText.Font = new Font("Segoe UI", 24f, FontStyle.Regular);
                GeneralInfoText.Text = DateTimeOffset.Now.ToString("h:mm tt MM/dd/yyyy");
                OnClock = true;
            }
        }

        private bool DisplayTrimNotification = true;

        private void DetectAlertActivity_Tick(object send, EventArgs e)
        {
            if (AlertListQueue.Count != 0)
            {
                DashboardPanel.SuspendLayout();

                //List<AlertInfo> AlertList = [.. AlertListQueue];

                //DashboardPanel.SuspendLayout();

                AlertInfo info = AlertListQueue.First();
                AlertListQueue.Remove(info);

                var (text, MainColor, SubColor) = GetTextFromMessageSeverityAndType(info.AlertSeverity, info.AlertMessageType);
                //TitleText.Text = message.text;

                DashboardListItem dli = new(info);
                dli.ContainerPanel.BackColor = MainColor;
                dli.AlertTitleText.Text = info.AlertEventType;

                string LocationsTrimmed = "Unknown Locations";

                if (info.AlertFriendlyLocations.Count == 1)
                {
                    LocationsTrimmed = info.AlertFriendlyLocations[0];
                }
                else
                {
                    if (info.AlertFriendlyLocations.Count != 0)
                    {
                        LocationsTrimmed = string.Empty;

                        foreach (string Location in info.AlertFriendlyLocations)
                        {
                            LocationsTrimmed += $"{Location};\x20";
                        }

                        LocationsTrimmed = LocationsTrimmed.Trim();
                    }
                }

                dli.AlertDescriptionText.Text = $"Issued by {info.AlertSender}. For the following areas, {LocationsTrimmed.TrimEnd(';').Replace("\x20\x20", "\x20")}.";

                if (DateTimeOffset.TryParse(info.AlertSentDate, out var dto1))
                {
                    dli.AlertIssuedTimeAndDateText.Text = $"Issued on {dto1.LocalDateTime:MMMM d, yyyy h:mm tt}";
                }
                else
                {
                    dli.AlertIssuedTimeAndDateText.Text = "Unknown Issuance Date";
                }

                // I have to look into DateTimeOffset, apparently DateTime is weird with timezones :)

                bool Expired = false;

                if (DateTimeOffset.TryParse(info.AlertExpiryDate, out var dto2))
                {
                    TimeSpan remaining = dto2 - DateTimeOffset.Now;

                    if (remaining.TotalSeconds <= 0)
                    {
                        dli.AlertExpiryText.Text = "EXPIRED";
                        Expired = true;
                    }
                    else
                    {
                        dli.AlertExpiryText.Text = string.Format("{0:D2}h {1:D2}m",
                            (int)remaining.TotalHours, remaining.Minutes);
                    }
                }
                else
                {
                    info.AlertExpiryDate = DateTime.UtcNow.ToString("s");
                    dli.AlertExpiryText.Text = "UNKNOWN";
                    Expired = true;
                }

                //AlertSource = "SASMEX",
                //AlertURL = "https://google.com",
                //AlertID = "ABCD123456-ABCDABCDABCDABCD",
                //AlertIntroText = "1. EARTHQUAKE. For the following, Bayamon Municipio, Puerto Rico; Catano Municipio, Puerto Rico; Guaynabo Municipio, Puerto Rico; San Juan Municipio, Puerto Rico; Trujillo Alto Municipio, Puerto Rico. This alert begins 01:43 PM EST, September 22, 2025, and ends at 03:45 PM EST, September 22, 2025. Issued by NWS San Juan PR. Sourced from FEMA IPAWS (WEA). \r\n\r\n2. Flash Flood Warning. For the following, Bayamon Municipio, Puerto Rico; Catano Municipio, Puerto Rico; Guaynabo Municipio, Puerto Rico; San Juan Municipio, Puerto Rico; Trujillo Alto Municipio, Puerto Rico. This alert begins 01:43 PM EST, September 22, 2025, and ends at 03:45 PM EST, September 22, 2025. Issued by NWS San Juan PR. Sourced from FEMA IPAWS (WEA).",
                //AlertBodyText = "1. NWS: EARTHQUAKE WARNING this area til 3:12:45 AM AST. Avoid flooded areas. National Weather Service: A FLASH FLOOD WARNING is in effect for this area until 3:12:45 AM AST. This is a dangerous and life-threatening situation. Do not attempt to travel unless you are fleeing an area subject to flooding or under an evacuation order.\r\n\r\n2. SNM: AVISO DE INUNDACIONES REPENTINAS hasta 3:12:45 AM AST. Evite areas inundadas. Servicio Nacional de Meteorologia: AVISO DE INUNDACIONES REPENTINAS en efecto para esta area hasta las 3:12:45 AM AST. Esta es una situacion peligrosa y amenaza la vida. No intente viajar a menos que sea para abandonar un area propensa a inundaciones o bajo una orden de desalojo.",
                //AlertMessageType = "update",
                //AlertSeverity = "minor",
                //AlertSentDate = $"{DateTime.UtcNow:s}",
                //AlertExpiryDate = $"{DateTime.UtcNow.AddSeconds(15):s}",
                //AlertFriendlyLocations =
                //[
                //    "Bayamon Municipio, Puerto Rico;",
                //    "Catano Municipio, Puerto Rico;",
                //    "Guaynabo Municipio, Puerto Rico;",
                //    "San Juan Municipio, Puerto Rico;",
                //    "Trujillo Alto Municipio, Puerto Rico"
                //],
                //AlertAudioURL = "https://bunnytub.com/media/AMERICA.mp3",
                //AlertImageURL = "https://bunnytub.com/media/uranium.png"

                dli.ToolTipInformation.SetToolTip(dli.AlertDescriptionText, info.AlertIntroText + "\r\n\r\nClick here for more information.");

                bool AlertsTrimmed = false;

                while (DashboardPanel.Controls.Count >= 500)
                {
                    DashboardPanel.Controls.RemoveAt(0);
                    AlertsTrimmed = true;
                }

                if (AlertsTrimmed)
                {
                    if (DisplayTrimNotification)
                    {
                        NotificationWorker.Notify.ShowNotification("To save resources, the alert list is limited to 500 alerts at a time. Older alerts are discarded in order.", "SharpAlert Dashboard trimmed", ToolTipIcon.Info);
                        DisplayTrimNotification = false;
                    }
                }

                DashboardPanel.Controls.Add(dli);
                dli.Dock = DockStyle.Top;

                if (ExpiredAlertsOnly)
                {
                    if (!Expired) dli.Hide();
                }

                AlertListQueue.Remove(info);

                //if (AutoScrollBox.Checked)
                //{
                //    TitlePanel.VerticalScroll.Value = 0;
                //    //DashboardPanel.PerformLayout(); // Refresh(); works here too I think
                //}

                //DashboardPanel.ResumeLayout();
                dli.Select();
                dli.AlertExpiryText.Select();

                DashboardPanel.ResumeLayout();

                HackyWorkarounds.FlashWindow(this, 1);
            }

            if (DashboardPanel.Controls.Count == 0)
            {
                ActiveAlertsText.Text = "\x20" + "crickets... ~w~";
                ActiveAlertsText.ForeColor = Color.Gray;
            }
            else
            {
                ActiveAlertsText.Text = "\x20" + $"Alerts ({DashboardPanel.Controls.Count})";
                ActiveAlertsText.ForeColor = Color.White;
            }
        }

        private void DashboardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            DashboardManager.NewProcessedAlert -= DashboardManager_NewProcessedAlert;
        }

        private void LogoBox_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("This feature is not yet available.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        private void ActiveAlertsText_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear the current alert list?\r\n" +
                "This will not clear your alert history.",
                Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DashboardPanel.Controls.Clear();
            }
        }
    }
}
