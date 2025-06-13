using System;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.AlertProcessor;

namespace SharpAlert
{
    public partial class AlertConfigurationForm : Form
    {
        public AlertConfigurationForm()
        {
            InitializeComponent();
        }

        private bool Initialized = false;

        private void AlertConfigurationForm_Load(object sender, EventArgs e)
        {
            if (Initialized) return;
            Initialized = true;

            AudioTinkeringFileDialog.Filter = "Audio Files (*.mp3, *.wav)|*.mp3;*.wav";
            AudioTinkeringFileDialog.FilterIndex = 0;
            AudioTinkeringFileDialog.CheckFileExists = true;
            AudioTinkeringFileDialog.Multiselect = false;
            AudioTinkeringFileDialog.Title = "SharpAlert - Audio Selection";

            statusActualBox.Checked = QuickSettings.Instance.statusActual;
            statusActualBox.CheckedChanged += (a, b) => QuickSettings.Instance.statusActual = ((CheckBox)a).Checked;
            statusExerciseBox.Checked = QuickSettings.Instance.statusExercise;
            statusExerciseBox.CheckedChanged += (a, b) => QuickSettings.Instance.statusExercise = ((CheckBox)a).Checked;
            statusTestBox.Checked = QuickSettings.Instance.statusTest;
            statusTestBox.CheckedChanged += (a, b) => QuickSettings.Instance.statusTest = ((CheckBox)a).Checked;

            messageTypeAlertBox.Checked = QuickSettings.Instance.messageTypeAlert;
            messageTypeAlertBox.CheckedChanged += (a, b) => QuickSettings.Instance.messageTypeAlert = ((CheckBox)a).Checked;
            messageTypeUpdateBox.Checked = QuickSettings.Instance.messageTypeUpdate;
            messageTypeUpdateBox.CheckedChanged += (a, b) => QuickSettings.Instance.messageTypeUpdate = ((CheckBox)a).Checked;
            messageTypeCancelBox.Checked = QuickSettings.Instance.messageTypeCancel;
            messageTypeCancelBox.CheckedChanged += (a, b) => QuickSettings.Instance.messageTypeCancel = ((CheckBox)a).Checked;
            messageTypeTestBox.Checked = QuickSettings.Instance.messageTypeTest;
            messageTypeTestBox.CheckedChanged += (a, b) => QuickSettings.Instance.messageTypeTest = ((CheckBox)a).Checked;

            severityExtremeBox.Checked = QuickSettings.Instance.severityExtreme;
            severityExtremeBox.CheckedChanged += (a, b) => QuickSettings.Instance.severityExtreme = ((CheckBox)a).Checked;
            severitySevereBox.Checked = QuickSettings.Instance.severitySevere;
            severitySevereBox.CheckedChanged += (a, b) => QuickSettings.Instance.severitySevere = ((CheckBox)a).Checked;
            severityModerateBox.Checked = QuickSettings.Instance.severityModerate;
            severityModerateBox.CheckedChanged += (a, b) => QuickSettings.Instance.severityModerate = ((CheckBox)a).Checked;
            severityMinorBox.Checked = QuickSettings.Instance.severityMinor;
            severityMinorBox.CheckedChanged += (a, b) => QuickSettings.Instance.severityMinor = ((CheckBox)a).Checked;
            severityUnknownBox.Checked = QuickSettings.Instance.severityUnknown;
            severityUnknownBox.CheckedChanged += (a, b) => QuickSettings.Instance.severityUnknown = ((CheckBox)a).Checked;

            urgencyImmediateBox.Checked = QuickSettings.Instance.urgencyImmediate;
            urgencyImmediateBox.CheckedChanged += (a, b) => QuickSettings.Instance.urgencyImmediate = ((CheckBox)a).Checked;
            urgencyExpectedBox.Checked = QuickSettings.Instance.urgencyExpected;
            urgencyExpectedBox.CheckedChanged += (a, b) => QuickSettings.Instance.urgencyExpected = ((CheckBox)a).Checked;
            urgencyFutureBox.Checked = QuickSettings.Instance.urgencyFuture;
            urgencyFutureBox.CheckedChanged += (a, b) => QuickSettings.Instance.urgencyFuture = ((CheckBox)a).Checked;
            urgencyPastBox.Checked = QuickSettings.Instance.urgencyPast;
            urgencyPastBox.CheckedChanged += (a, b) => QuickSettings.Instance.urgencyPast = ((CheckBox)a).Checked;
            urgencyUnknownBox.Checked = QuickSettings.Instance.urgencyUnknown;
            urgencyUnknownBox.CheckedChanged += (a, b) => QuickSettings.Instance.urgencyUnknown = ((CheckBox)a).Checked;

            if (AlertCheckIntervalInput.Value < 5)
            {
                AlertCheckIntervalInput.Enabled = false;
            }
            else
            {
                AlertCheckIntervalInput.Value = QuickSettings.Instance.AlertCheckInterval;
            }
            AlertCheckIntervalInput.ValueChanged += (a, b) => QuickSettings.Instance.AlertCheckInterval = (int)((NumericUpDown)a).Value;

            AlertDeadIntervalInput.Value = QuickSettings.Instance.AlertDeadInterval;
            AlertDeadIntervalInput.ValueChanged += (a, b) => QuickSettings.Instance.AlertDeadInterval = (int)((NumericUpDown)a).Value;

            weaOnlyBox.Checked = QuickSettings.Instance.weaOnly;
            weaOnlyBox.CheckedChanged += (a, b) => QuickSettings.Instance.weaOnly = ((CheckBox)a).Checked;
            discardFirstAlertsBox.Checked = QuickSettings.Instance.discardFirstAlerts;
            discardFirstAlertsBox.CheckedChanged += (a, b) => QuickSettings.Instance.discardFirstAlerts = ((CheckBox)a).Checked;
            
            categoryGeoBox.Checked = QuickSettings.Instance.categoryGeophysical;
            categoryGeoBox.CheckedChanged += (a, b) => QuickSettings.Instance.categoryGeophysical = ((CheckBox)a).Checked;
            categorySecurityBox.Checked = QuickSettings.Instance.categorySecurity;
            categorySecurityBox.CheckedChanged += (a, b) => QuickSettings.Instance.categorySecurity = ((CheckBox)a).Checked;
            categoryHealthBox.Checked = QuickSettings.Instance.categoryMedical;
            categoryHealthBox.CheckedChanged += (a, b) => QuickSettings.Instance.categoryMedical = ((CheckBox)a).Checked;
            categoryInfraBox.Checked = QuickSettings.Instance.categoryUtilities;
            categoryInfraBox.CheckedChanged += (a, b) => QuickSettings.Instance.categoryUtilities = ((CheckBox)a).Checked;
            categoryMetBox.Checked = QuickSettings.Instance.categoryMeterological;
            categoryMetBox.CheckedChanged += (a, b) => QuickSettings.Instance.categoryMeterological = ((CheckBox)a).Checked;
            categoryRescueBox.Checked = QuickSettings.Instance.categoryRescue;
            categoryRescueBox.CheckedChanged += (a, b) => QuickSettings.Instance.categoryRescue = ((CheckBox)a).Checked;
            categoryEnvBox.Checked = QuickSettings.Instance.categoryEnvironmental;
            categoryEnvBox.CheckedChanged += (a, b) => QuickSettings.Instance.categoryEnvironmental = ((CheckBox)a).Checked;
            categoryCBRNEBox.Checked = QuickSettings.Instance.categoryToxicThreat;
            categoryCBRNEBox.CheckedChanged += (a, b) => QuickSettings.Instance.categoryToxicThreat = ((CheckBox)a).Checked;
            categorySafetyBox.Checked = QuickSettings.Instance.categoryGeneralSafety;
            categorySafetyBox.CheckedChanged += (a, b) => QuickSettings.Instance.categoryGeneralSafety = ((CheckBox)a).Checked;
            categoryFireBox.Checked = QuickSettings.Instance.categoryFire;
            categoryFireBox.CheckedChanged += (a, b) => QuickSettings.Instance.categoryFire = ((CheckBox)a).Checked;
            categoryTransportBox.Checked = QuickSettings.Instance.categoryTransportation;
            categoryTransportBox.CheckedChanged += (a, b) => QuickSettings.Instance.categoryTransportation = ((CheckBox)a).Checked;
            categoryOtherBox.Checked = QuickSettings.Instance.categoryOtherUnknown;
            categoryOtherBox.CheckedChanged += (a, b) => QuickSettings.Instance.categoryOtherUnknown = ((CheckBox)a).Checked;

            storedMaxSizeInput.Value = QuickSettings.Instance.storedMaxSize;
            storedMaxSizeInput.ValueChanged += (a, b) => QuickSettings.Instance.storedMaxSize = (int)((NumericUpDown)a).Value;
            showExpiryMessagesBox.Checked = QuickSettings.Instance.showExpiryMessages;
            showExpiryMessagesBox.CheckedChanged += (a, b) => QuickSettings.Instance.showExpiryMessages = ((CheckBox)a).Checked;

            string Events = string.Empty;
            foreach (string SAME_event in QuickSettings.Instance.EnforceEventBlacklist) Events += SAME_event + "\r\n";
            Events = Events.Trim();
            EventBlacklistOutput.Text = Events;
        }

        private void EventAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EventBlacklistInput.Text))
            {
                if (QuickSettings.Instance.EnforceEventBlacklist.Contains(EventBlacklistInput.Text))
                {
                    var removal = MessageBox.Show("The event name is already in the list. Remove it?",
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (removal == DialogResult.Yes) QuickSettings.Instance.EnforceEventBlacklist.Remove(EventBlacklistInput.Text);
                    EventBlacklistOutput.Clear();
                    foreach (string area in QuickSettings.Instance.EnforceEventBlacklist)
                    {
                        EventBlacklistOutput.Text = $"{area}\r\n{EventBlacklistOutput.Text}";
                    }
                    EventBlacklistInput.Clear();
                    return;
                }
                else
                {
                    QuickSettings.Instance.EnforceEventBlacklist.Add(EventBlacklistInput.Text);
                    EventBlacklistOutput.Clear();
                    foreach (string area in QuickSettings.Instance.AllowedCAPCPLocations_Geocodes)
                    {
                        EventBlacklistOutput.Text = $"{area}\r\n{EventBlacklistOutput.Text}";
                    }
                    EventBlacklistInput.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter an event name to add it.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void EventClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear event blacklist data?",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QuickSettings.Instance.EnforceEventBlacklist.Clear();
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

        private void ChangeStartButton_Click(object sender, EventArgs e)
        {
            Thread staThread = new Thread(() =>
            {
                try
                {
                    lock (AudioTinkeringFileDialog)
                    {
                        if (AudioTinkeringFileDialog.ShowDialog() != DialogResult.OK)
                        {
                            QuickSettings.Instance.StartToneLocation = string.Empty;
                            lock (notify)
                            {
                                notify.BalloonTipTitle = "SharpAlert has audio changes";
                                notify.BalloonTipText = "Reverted to default audio.";
                                notify.BalloonTipIcon = ToolTipIcon.Info;
                                notify.ShowBalloonTip(5000);
                            }
                            return;
                        }
                        QuickSettings.Instance.StartToneLocation = AudioTinkeringFileDialog.FileName;
                        lock (notify)
                        {
                            notify.BalloonTipTitle = "SharpAlert has audio changes";
                            notify.BalloonTipText = "Using linked audio.";
                            notify.BalloonTipIcon = ToolTipIcon.Info;
                            notify.ShowBalloonTip(5000);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.StackTrace} {ex.Message}",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
        }

        private void ChangeEndButton_Click(object sender, EventArgs e)
        {
            Thread staThread = new Thread(() =>
            {
                try
                {
                    lock (AudioTinkeringFileDialog)
                    {
                        if (AudioTinkeringFileDialog.ShowDialog() != DialogResult.OK)
                        {
                            QuickSettings.Instance.EndToneLocation = string.Empty;
                            lock (notify)
                            {
                                notify.BalloonTipTitle = "SharpAlert has audio changes";
                                notify.BalloonTipText = "Reverted to default audio.";
                                notify.BalloonTipIcon = ToolTipIcon.Info;
                                notify.ShowBalloonTip(5000);
                            }
                            return;
                        }
                        QuickSettings.Instance.EndToneLocation = AudioTinkeringFileDialog.FileName;
                        lock (notify)
                        {
                            notify.BalloonTipTitle = "SharpAlert has audio changes";
                            notify.BalloonTipText = "Using linked audio.";
                            notify.BalloonTipIcon = ToolTipIcon.Info;
                            notify.ShowBalloonTip(5000);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.StackTrace} {ex.Message}",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            });
            staThread.SetApartmentState(ApartmentState.STA);
            staThread.Start();
        }

        private void AlertCheckIntervalLabel_Click(object sender, EventArgs e)
        {
        }

        //int[] states = (AlertDetails.States.OrderBy(x => x.Id).Select(x => x.Id).ToArray());

        private void ListAreaSAMEOutput_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = GetFriendlyNameFromSAMELocation((string)e.Value);
        }

        private void LanguageButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("By default, alerts are only shown if they have English text.\r\n" +
                "Do you want to allow alerts of all languages to be relayed?\r\n\r\n" +
                $"AllowNonEnglishLanguages is currently set to {QuickSettings.Instance.AllowNonEnglishAlerts}.\r\nThis setting is always ignored for SASMEX alerts.",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    QuickSettings.Instance.AllowNonEnglishAlerts = true;
                    break;
                case DialogResult.No:
                    QuickSettings.Instance.AllowNonEnglishAlerts = false;
                    break;
            }
        }

        private ChooseOwnershipForm cof = null;

        private void StationButton_Click(object sender, EventArgs e)
        {
            if (cof == null || cof.IsDisposed) cof = new ChooseOwnershipForm(false);
            cof.ShowDialog();
        }

        private ChooseLocationForm clf = null;

        private void LocationsButton_Click(object sender, EventArgs e)
        {
            if (clf == null || clf.IsDisposed) clf = new ChooseLocationForm(false);
            clf.ShowDialog();
        }
    }
}
