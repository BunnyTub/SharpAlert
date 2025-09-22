using System;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.ProgramWorker.NotificationWorker;
using static SharpAlert.AlertComponents.AlertProcessor;
using System.Drawing;
using SharpAlert.ProgramWorker;

namespace SharpAlert.ConfigurationDialogs
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

            alertNoRelayBox.Checked = QuickSettings.Instance.alertNoRelay;
            alertNoRelayBox.CheckedChanged += (a, b) => QuickSettings.Instance.alertNoRelay = ((CheckBox)a).Checked;

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
            PreferCMAMTextWhereAvailableBox.Checked = QuickSettings.Instance.UseCMAMTextWhereAvailable;
            PreferCMAMTextWhereAvailableBox.CheckedChanged += (a, b) => QuickSettings.Instance.UseCMAMTextWhereAvailable = ((CheckBox)a).Checked;
            IgnoreKeepAliveBox.Checked = QuickSettings.Instance.IgnoreKeepAlive;
            IgnoreKeepAliveBox.CheckedChanged += (a, b) => QuickSettings.Instance.IgnoreKeepAlive = ((CheckBox)a).Checked;

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

            string Events = string.Empty;
            foreach (string SAME_event in QuickSettings.Instance.EnforceEventBlacklist) Events += SAME_event + "\r\n";
            Events = Events.Trim();
            EventBlacklistOutput.Text = Events;

            EventWhitelistModeBox.Checked = QuickSettings.Instance.EventWhitelistMode;
            EventWhitelistModeBox.CheckedChanged += (a, b) => QuickSettings.Instance.EventWhitelistMode = ((CheckBox)a).Checked;
        }

        private void EventAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EventBlacklistInput.Text))
            {
                if (QuickSettings.Instance.EnforceEventBlacklist.Contains(EventBlacklistInput.Text))
                {
                    var removal = MessageBox.Show("The event name is already in the list. Remove it?",
                        Text,
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
                    foreach (string area in QuickSettings.Instance.EnforceEventBlacklist)
                    {
                        EventBlacklistOutput.Text = $"{area}\r\n{EventBlacklistOutput.Text}";
                    }
                    EventBlacklistInput.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter an event name to add it.",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void EventClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear event blacklist data?",
                Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QuickSettings.Instance.EnforceEventBlacklist.Clear();
                EventBlacklistOutput.Text = string.Empty;
            }
        }

        private void ListAreaSAMEOutput_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = GetFriendlyNameFromSAMELocation((string)e.Value);
        }

        private void LanguageButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Languages are planned to be manageable in the future. Alerts currently will not be discarded for any reason based on language.",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            //DialogResult result = MessageBox.Show($"Choose YES to allow any language. Choose NO to only allow the English language. AllowNonEnglishLanguages is currently set to {QuickSettings.Instance.AllowNonEnglishAlerts}.",
            //    Text,
            //    MessageBoxButtons.YesNo,
            //    MessageBoxIcon.Question);

            //switch (result)
            //{
            //    case DialogResult.Yes:
            //        QuickSettings.Instance.AllowNonEnglishAlerts = true;
            //        break;
            //    case DialogResult.No:
            //        QuickSettings.Instance.AllowNonEnglishAlerts = false;
            //        break;
            //}
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

        private void AlertConfigurationForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("This area has controls for CAP filtering.\r\n" +
                "Uncheck a checkbox to deny all alerts with that parameter.\r\n\r\n" +
                "CAP filtering may not be applied to all alerts, especially alerts from external sources, such as plugins, or messages from pipes.",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            e.Cancel = true;
        }

        private void LocationsClearButton_Click(object sender, EventArgs e)
        {
            QuickSettings.Instance.AllowedSAMELocations_Geocodes.Clear();
            QuickSettings.Instance.AllowedCAPCPLocations_Geocodes.Clear();
            QuickSettings.Instance.AllowedCustomLocations_GeocodesList.Clear();
            MessageBox.Show("Cleared all locations.\r\n" +
                "Alerts from all locations are now allowed.",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private AlertListForm alf = null;

        private void AlertListButton_Click(object sender, EventArgs e)
        {
            if (alf == null || alf.IsDisposed) alf = new AlertListForm();
            alf.ShowDialog();
        }

        private EventsAdditionForm eaf = null;

        private void EventSelectButton_Click(object sender, EventArgs e)
        {
            if (eaf == null || eaf.IsDisposed) eaf = new EventsAdditionForm();
            var result = eaf.ShowDialog();
            if (result == DialogResult.OK)
            {
                EventBlacklistInput.Enabled = false;
                EventBlacklistInput.Text = eaf.SelectedEvent.Name;
                EventAddButton.PerformClick();
                EventBlacklistInput.Enabled = true;
            }
        }

        private void CategoryInfoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This area has controls for category filtering specifically.\r\n" +
                "Uncheck a checkbox to deny all alerts with that category.\r\n\r\n" +
                "Category may not be the best way to choose which alerts you receive, not all alert authorities use categories the same way.",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void BypassAlertFilteringButton_Click(object sender, EventArgs e)
        {
            QuickSettings.Instance.BypassAllFilters = !QuickSettings.Instance.BypassAllFilters;

            if (QuickSettings.Instance.BypassAllFilters)
            {
                BypassFilteringFlasher_Tick(null, null);
                BypassFilteringFlasher.Start();
                MessageBox.Show("The Alert Processor will now ignore alert filtering. This setting will be reverted the next time you open SharpAlert.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                BypassFilteringFlasher.Stop();
                BypassAlertFilteringButton.BackColor = Color.FromArgb(60, 60, 60);
                MessageBox.Show("The Alert Processor will no longer ignore alert filtering.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool FlashOne = true;

        private void BypassFilteringFlasher_Tick(object sender, EventArgs e)
        {
            if (FlashOne)
            {
                BypassAlertFilteringButton.BackColor = Color.DarkRed;
            }
            else
            {
                BypassAlertFilteringButton.BackColor = Color.Green;
            }

            FlashOne = !FlashOne;
        }

        private void NamedEventsInfoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If the event of the alert matches any blacklisted events, it will be discarded. (case-insensitive)\r\n\r\n" +
                "For example, if \"Practice\" is in the list, any event names with \"Practice\" inside are discarded.\r\n" +
                "Another example, is using \"Required Weekly Test\", NOT \"RWT\" (it will match words with \"RWT\" inside).\r\n\r\n" +
                "This feature was changed, because not all alerts will have the included SAME event codes required for matching to work properly.\r\n" +
                "It is more flexible to name events by their full name, as even without the SAME event codes included, events can be named.",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private ArchiveConfigurationForm acf = null;

        private void ArchiveSettingsButton_Click(object sender, EventArgs e)
        {
            if (acf == null || acf.IsDisposed) acf = new ArchiveConfigurationForm();
            acf.ShowDialog();
        }

        private double hue = 0;

        private void RainbowColoring_Tick(object sender, EventArgs e)
        {
            hue += 2;
            if (hue >= 360) hue = 0;

            RainbowText.ForeColor = ColorFromHSV(hue, 1.0, 1.0);
        }

        private static Color ColorFromHSV(double hue, double saturation, double value)
        {
            int hi = Convert.ToInt32(Math.Floor(hue / 60)) % 6;
            double f = hue / 60 - Math.Floor(hue / 60);

            value = value * 255;
            int v = (int)value;
            int p = (int)(value * (1 - saturation));
            int q = (int)(value * (1 - f * saturation));
            int t = (int)(value * (1 - (1 - f) * saturation));

            switch (hi)
            {
                case 0: return Color.FromArgb(255, v, t, p);
                case 1: return Color.FromArgb(255, q, v, p);
                case 2: return Color.FromArgb(255, p, v, t);
                case 3: return Color.FromArgb(255, p, q, v);
                case 4: return Color.FromArgb(255, t, p, v);
                default: return Color.FromArgb(255, v, p, q);
            }
        }
    }
}

