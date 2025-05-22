using SharpAlert.Properties;
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

        private void AlertConfigurationForm_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            AudioTinkeringFileDialog.Filter = "Audio Files (*.mp3, *.wav)|*.mp3;*.wav";
            AudioTinkeringFileDialog.FilterIndex = 0;
            AudioTinkeringFileDialog.CheckFileExists = true;
            AudioTinkeringFileDialog.Multiselect = false;
            AudioTinkeringFileDialog.Title = "SharpAlert - Audio Selection";

            statusActualBox.Checked = Settings.Default.statusActual;
            statusActualBox.CheckedChanged += (a, b) => Settings.Default.statusActual = ((CheckBox)a).Checked;
            statusExerciseBox.Checked = Settings.Default.statusExercise;
            statusExerciseBox.CheckedChanged += (a, b) => Settings.Default.statusExercise = ((CheckBox)a).Checked;
            statusTestBox.Checked = Settings.Default.statusTest;
            statusTestBox.CheckedChanged += (a, b) => Settings.Default.statusTest = ((CheckBox)a).Checked;

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

            if (AlertCheckIntervalInput.Value < 5)
            {
                AlertCheckIntervalInput.Enabled = false;
            }
            else
            {
                AlertCheckIntervalInput.Value = Settings.Default.AlertCheckInterval;
            }
            AlertCheckIntervalInput.ValueChanged += (a, b) => Settings.Default.AlertCheckInterval = (int)((NumericUpDown)a).Value;

            AlertDeadIntervalInput.Value = Settings.Default.AlertDeadInterval;
            AlertDeadIntervalInput.ValueChanged += (a, b) => Settings.Default.AlertDeadInterval = (int)((NumericUpDown)a).Value;

            weaOnlyBox.Checked = Settings.Default.weaOnly;
            weaOnlyBox.CheckedChanged += (a, b) => Settings.Default.weaOnly = ((CheckBox)a).Checked;
            discardFirstAlertsBox.Checked = Settings.Default.discardFirstAlerts;
            discardFirstAlertsBox.CheckedChanged += (a, b) => Settings.Default.discardFirstAlerts = ((CheckBox)a).Checked;
            
            categoryGeoBox.Checked = Settings.Default.categoryGeophysical;
            categoryGeoBox.CheckedChanged += (a, b) => Settings.Default.categoryGeophysical = ((CheckBox)a).Checked;
            categorySecurityBox.Checked = Settings.Default.categorySecurity;
            categorySecurityBox.CheckedChanged += (a, b) => Settings.Default.categorySecurity = ((CheckBox)a).Checked;
            categoryHealthBox.Checked = Settings.Default.categoryMedical;
            categoryHealthBox.CheckedChanged += (a, b) => Settings.Default.categoryMedical = ((CheckBox)a).Checked;
            categoryInfraBox.Checked = Settings.Default.categoryUtilities;
            categoryInfraBox.CheckedChanged += (a, b) => Settings.Default.categoryUtilities = ((CheckBox)a).Checked;
            categoryMetBox.Checked = Settings.Default.categoryMeterological;
            categoryMetBox.CheckedChanged += (a, b) => Settings.Default.categoryMeterological = ((CheckBox)a).Checked;
            categoryRescueBox.Checked = Settings.Default.categoryRescue;
            categoryRescueBox.CheckedChanged += (a, b) => Settings.Default.categoryRescue = ((CheckBox)a).Checked;
            categoryEnvBox.Checked = Settings.Default.categoryEnvironmental;
            categoryEnvBox.CheckedChanged += (a, b) => Settings.Default.categoryEnvironmental = ((CheckBox)a).Checked;
            categoryCBRNEBox.Checked = Settings.Default.categoryToxicThreat;
            categoryCBRNEBox.CheckedChanged += (a, b) => Settings.Default.categoryToxicThreat = ((CheckBox)a).Checked;
            categorySafetyBox.Checked = Settings.Default.categoryGeneralSafety;
            categorySafetyBox.CheckedChanged += (a, b) => Settings.Default.categoryGeneralSafety = ((CheckBox)a).Checked;
            categoryFireBox.Checked = Settings.Default.categoryFire;
            categoryFireBox.CheckedChanged += (a, b) => Settings.Default.categoryFire = ((CheckBox)a).Checked;
            categoryTransportBox.Checked = Settings.Default.categoryTransportation;
            categoryTransportBox.CheckedChanged += (a, b) => Settings.Default.categoryTransportation = ((CheckBox)a).Checked;
            categoryOtherBox.Checked = Settings.Default.categoryOtherUnknown;
            categoryOtherBox.CheckedChanged += (a, b) => Settings.Default.categoryOtherUnknown = ((CheckBox)a).Checked;

            storedMaxSizeInput.Value = Settings.Default.storedMaxSize;
            storedMaxSizeInput.ValueChanged += (a, b) => Settings.Default.storedMaxSize = (int)((NumericUpDown)a).Value;
            showExpiryMessagesBox.Checked = Settings.Default.showExpiryMessages;
            showExpiryMessagesBox.CheckedChanged += (a, b) => Settings.Default.showExpiryMessages = ((CheckBox)a).Checked;

            ListAreaSAMEOutput.Items.Clear();
            foreach (string area in Settings.Default.AllowedSAMELocations_Geocodes)
            {
                ListAreaSAMEOutput.Items.Add(area, true);
            }

            ListAreaCAPCPOutput.Items.Clear();
            foreach (string area in Settings.Default.AllowedCAPCPLocations_Geocodes)
            {
                ListAreaCAPCPOutput.Items.Add(area, true);
            }

            string Events = string.Empty;
            foreach (string SAME_event in Settings.Default.EnforceEventBlacklist) Events += SAME_event + "\r\n";
            Events = Events.Trim();
            EventBlacklistOutput.Text = Events;
        }

        private void SAMEAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AreaSAMEInput.Text))
            {
                if (!(AreaSAMEInput.Text.Length >= 5))
                {
                    MessageBox.Show("The SAME location must be at least 5-6 characters.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    AreaSAMEInput.Clear();
                    return;
                }

                if (Settings.Default.AllowedSAMELocations_Geocodes.Contains(AreaSAMEInput.Text))
                {
                    var removal = MessageBox.Show("The SAME location is already in the list. Remove it?",
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (removal == DialogResult.Yes) Settings.Default.AllowedSAMELocations_Geocodes.Remove(AreaSAMEInput.Text);
                    ListAreaSAMEOutput.Items.Clear();
                    foreach (string area in Settings.Default.AllowedSAMELocations_Geocodes)
                    {
                        ListAreaSAMEOutput.Items.Add(area);
                    }
                    AreaSAMEInput.Clear();
                    return;
                }
                else
                {
                    Settings.Default.AllowedSAMELocations_Geocodes.Add(AreaSAMEInput.Text);
                    ListAreaSAMEOutput.Items.Clear();
                    foreach (string area in Settings.Default.AllowedSAMELocations_Geocodes)
                    {
                        ListAreaSAMEOutput.Items.Add(area);
                    }
                    AreaSAMEInput.Clear();
                }
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
            if (!string.IsNullOrWhiteSpace(AreaCAPCPInput.Text))
            {
                if (!(AreaCAPCPInput.Text.Length >= 5))
                {
                    MessageBox.Show("The CAP-CP location must be at least 5-6 characters.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    AreaCAPCPInput.Clear();
                    return;
                }

                if (Settings.Default.AllowedCAPCPLocations_Geocodes.Contains(AreaCAPCPInput.Text))
                {
                    var removal = MessageBox.Show("The CAP-CP location is already in the list. Remove it?",
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (removal == DialogResult.Yes) Settings.Default.AllowedCAPCPLocations_Geocodes.Remove(AreaCAPCPInput.Text);
                    ListAreaCAPCPOutput.Items.Clear();
                    foreach (string area in Settings.Default.AllowedCAPCPLocations_Geocodes)
                    {
                        ListAreaSAMEOutput.Items.Add(area);
                    }
                    AreaCAPCPInput.Clear();
                    return;
                }
                else
                {
                    Settings.Default.AllowedCAPCPLocations_Geocodes.Add(AreaCAPCPInput.Text);
                    ListAreaCAPCPOutput.Items.Clear();
                    foreach (string area in Settings.Default.AllowedCAPCPLocations_Geocodes)
                    {
                        ListAreaCAPCPOutput.Items.Add(area);
                    }
                    AreaCAPCPInput.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter a CAP-CP location value to add it.",
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
                MessageBox.Show("Enter an event value to add it.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void SAMEClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear SAME location data?",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Settings.Default.AllowedSAMELocations_Geocodes.Clear();
                ListAreaSAMEOutput.Items.Clear();
            }
        }

        private void UGCClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear CAP-CP location data?",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Settings.Default.AllowedCAPCPLocations_Geocodes.Clear();
                ListAreaCAPCPOutput.Items.Clear();
            }
        }

        private void EventClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear event blacklist data?",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
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
                            Settings.Default.StartToneLocation = string.Empty;
                            MessageBox.Show(this,
                                "Reverted to default audio.",
                                "SharpAlert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }
                        Settings.Default.StartToneLocation = AudioTinkeringFileDialog.FileName;
                        MessageBox.Show(this, "Using linked audio.",
                                "SharpAlert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                        $"{ex.StackTrace} {ex.Message}",
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
                            Settings.Default.EndToneLocation = string.Empty;
                            MessageBox.Show(this,
                                "Reverted to default audio.",
                                "SharpAlert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                            return;
                        }
                        Settings.Default.EndToneLocation = AudioTinkeringFileDialog.FileName;
                        MessageBox.Show(this,
                                "Using linked audio.",
                                "SharpAlert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this,
                        $"{ex.StackTrace} {ex.Message}",
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

        //Double-click to toggle 5 second polling. This is not recommended on lower end hardware, or networks with bad/unstable connections.
        private void AlertCheckIntervalLabel_DoubleClick(object sender, EventArgs e)
        {
            //if (AlertCheckIntervalInput.Enabled)
            //{
            //    AlertCheckIntervalInput.Enabled = false;
            //    Settings.Default.AlertCheckInterval = 5;
            //}
            //else
            //{
            //    AlertCheckIntervalInput.Enabled = true;
            //    AlertCheckIntervalInput.Value = 30;
            //}
        }

        private readonly LocationsAdditionForm laf = new LocationsAdditionForm();

        private void SAMESelectButton_Click(object sender, EventArgs e)
        {
            var result = laf.ShowDialog();
            if (result == DialogResult.OK)
            {
                string lefted = $"{laf.SelectedState.Id.ToString().PadLeft(3, '0')}";
                string righted = $"{laf.SelectedCounty.Id.ToString().PadLeft(3, '0')}";
                AreaSAMEInput.Enabled = false;
                AreaSAMEInput.Text = lefted + righted;
                SAMEAddButton.PerformClick();
                AreaSAMEInput.Enabled = true;
            }
        }

        private readonly EventsAdditionForm eaf = new EventsAdditionForm();

        private void EventSelectButton_Click(object sender, EventArgs e)
        {
            var result = eaf.ShowDialog();
            if (result == DialogResult.OK)
            {
                string lefted = $"{eaf.SelectedState.Id.ToString().PadLeft(3, '0')}";
                string righted = $"{eaf.SelectedCounty.Id.ToString().PadLeft(3, '0')}";
                EventBlacklistInput.Enabled = false;
                EventBlacklistInput.Text = lefted + righted;
                EventAddButton.PerformClick();
                EventBlacklistInput.Enabled = true;
            }
        }

        private void ListAreaSAMEOutput_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked) return;

            if (MessageBox.Show("Remove this location from the SAME location list?",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Settings.Default.AllowedSAMELocations_Geocodes.RemoveAt(e.Index);
                ListAreaSAMEOutput.Items.Clear();
                foreach (string area in Settings.Default.AllowedSAMELocations_Geocodes)
                {
                    ListAreaSAMEOutput.Items.Add(area);
                }
            }

            e.NewValue = CheckState.Checked;
        }

        //int[] states = (AlertDetails.States.OrderBy(x => x.Id).Select(x => x.Id).ToArray());

        private void ListAreaSAMEOutput_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = GetFriendlyNameFromSAMELocation((string)e.Value);
        }

        private void ListAreaCAPCPOutput_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked) return;

            if (MessageBox.Show("Remove this location from the CAP-CP location list?",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Settings.Default.AllowedCAPCPLocations_Geocodes.RemoveAt(e.Index);
                ListAreaCAPCPOutput.Items.Clear();
                foreach (string area in Settings.Default.AllowedCAPCPLocations_Geocodes)
                {
                    ListAreaCAPCPOutput.Items.Add(area);
                }
            }

            e.NewValue = CheckState.Checked;
        }

        private void LanguageButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("By default, alerts are only relayed if they have an English version.\r\n" +
                "Do you want to allow alerts of all languages to be relayed?\r\n\r\n" +
                $"AllowNonEnglishLanguages is currently set to {Settings.Default.AllowNonEnglishAlerts}.",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            switch (result)
            {
                case DialogResult.Yes:
                    Settings.Default.AllowNonEnglishAlerts = true;
                    break;
                case DialogResult.No:
                    Settings.Default.AllowNonEnglishAlerts = false;
                    break;
            }
        }

        private ChooseOwnershipForm cof = null;

        private void StationButton_Click(object sender, EventArgs e)
        {
            if (cof == null || cof.IsDisposed) cof = new ChooseOwnershipForm(false);
            cof.ShowDialog();
        }
    }
}
