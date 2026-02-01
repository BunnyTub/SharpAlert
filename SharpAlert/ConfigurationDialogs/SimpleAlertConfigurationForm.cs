using System;
using System.Windows.Forms;
using static SharpAlert.AlertComponents.AlertProcessor;
using System.Drawing;
using SharpAlert.ProgramWorker;
using SharpAlert.AlertComponents;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class SimpleAlertConfigurationForm : Form
    {
        public SimpleAlertConfigurationForm()
        {
            InitializeComponent();
        }

        private bool Initialized = false;

        private void AlertConfigurationForm_Load(object sender, EventArgs e)
        {
            if (Initialized) return;
            Initialized = true;

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

            weaOnlyBox.Checked = QuickSettings.Instance.weaOnly;
            weaOnlyBox.CheckedChanged += (a, b) => QuickSettings.Instance.weaOnly = ((CheckBox)a).Checked;
            discardFirstAlertsBox.Checked = QuickSettings.Instance.discardFirstAlerts;
            discardFirstAlertsBox.CheckedChanged += (a, b) => QuickSettings.Instance.discardFirstAlerts = ((CheckBox)a).Checked;
            PreferCMAMTextWhereAvailableBox.Checked = QuickSettings.Instance.UseCMAMTextWhereAvailable;
            PreferCMAMTextWhereAvailableBox.CheckedChanged += (a, b) => QuickSettings.Instance.UseCMAMTextWhereAvailable = ((CheckBox)a).Checked;
            IgnoreKeepAliveBox.Checked = QuickSettings.Instance.IgnoreKeepAlive;
            IgnoreKeepAliveBox.CheckedChanged += (a, b) => QuickSettings.Instance.IgnoreKeepAlive = ((CheckBox)a).Checked;
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

        private void CategoryInfoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This area has controls for category filtering specifically.\r\n" +
                "Uncheck a checkbox to deny all alerts with that category.\r\n\r\n" +
                "Category may not be the best way to choose which alerts you receive, not all alert authorities use categories the same way.",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

            value *= 255;
            int v = (int)value;
            int p = (int)(value * (1 - saturation));
            int q = (int)(value * (1 - f * saturation));
            int t = (int)(value * (1 - (1 - f) * saturation));

            return hi switch
            {
                0 => Color.FromArgb(255, v, t, p),
                1 => Color.FromArgb(255, q, v, p),
                2 => Color.FromArgb(255, p, v, t),
                3 => Color.FromArgb(255, p, q, v),
                4 => Color.FromArgb(255, t, p, v),
                _ => Color.FromArgb(255, v, p, q),
            };
        }

        private void RainbowText_Click(object sender, EventArgs e)
        {
            HackyWorkarounds.OpenURL("https://bunnytub.com/SharpAlert");
        }

        private void SuperSecretEnabler_Tick(object sender, EventArgs e)
        {
            //if (Visible)
            //{
            //    if (MainEntryPoint.IsUserSuperSecretAccessor())
            //    {
            //        SuperSecretSettingsGroup.Visible = true;
            //    }
            //    else
            //    {
            //        SuperSecretSettingsGroup.Visible = false;
            //    }
            //}
        }

        private void FloodQueueButton_Click(object sender, EventArgs e)
        {
            lock (MainEntryPoint.SharpDataQueue)
            {
                lock (MainEntryPoint.SharpDataHistory)
                {
                    MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);

                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);

                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);

                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);

                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);

                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);

                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);

                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);

                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);

                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                    //MainEntryPoint.SharpDataQueue.AddRange(MainEntryPoint.SharpDataHistory);
                    //MainEntryPoint.SharpDataHistory.AddRange(MainEntryPoint.SharpDataQueue);
                }
            }

        }

        private EventConfigurationForm ecf = null;

        private void EventsButton_Click(object sender, EventArgs e)
        {
            if (ecf == null || ecf.IsDisposed) ecf = new EventConfigurationForm();
            ecf.ShowDialog();
        }

        private void PreferAllButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This action will clear your events. Continue?", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QuickSettings.Instance.statusActual = true;
                QuickSettings.Instance.statusExercise = true;
                QuickSettings.Instance.statusTest = true;

                QuickSettings.Instance.messageTypeAlert = true;
                QuickSettings.Instance.messageTypeUpdate = true;
                QuickSettings.Instance.messageTypeCancel = true;
                QuickSettings.Instance.messageTypeTest = true;

                QuickSettings.Instance.severityUnknown = true;
                QuickSettings.Instance.severityMinor = true;
                QuickSettings.Instance.severityModerate = true;
                QuickSettings.Instance.severitySevere = true;
                QuickSettings.Instance.severityExtreme = true;

                QuickSettings.Instance.urgencyFuture = true;
                QuickSettings.Instance.urgencyExpected = true;
                QuickSettings.Instance.urgencyImmediate = true;
                QuickSettings.Instance.urgencyPast = true;
                QuickSettings.Instance.urgencyUnknown = true;

                QuickSettings.Instance.EnforceEventBlacklist.Clear();
                QuickSettings.Instance.EnforceSAMEEventBlacklist.Clear();
                QuickSettings.Instance.EventWhitelistMode = false;

                MessageBox.Show("Your filters were adjusted.\r\nYou'll receive the widest range of messages.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void PreferSevereButton_Click(object sender, EventArgs e)
        {
            QuickSettings.Instance.statusActual = true;
            QuickSettings.Instance.statusExercise = false;
            QuickSettings.Instance.statusTest = false;

            QuickSettings.Instance.messageTypeAlert = true;
            QuickSettings.Instance.messageTypeUpdate = true;
            QuickSettings.Instance.messageTypeCancel = true;
            QuickSettings.Instance.messageTypeTest = false;

            QuickSettings.Instance.severityUnknown = false;
            QuickSettings.Instance.severityMinor = false;
            QuickSettings.Instance.severityModerate = false;
            QuickSettings.Instance.severitySevere = true;
            QuickSettings.Instance.severityExtreme = true;

            QuickSettings.Instance.urgencyFuture = true;
            QuickSettings.Instance.urgencyExpected = true;
            QuickSettings.Instance.urgencyImmediate = true;
            QuickSettings.Instance.urgencyPast = false;
            QuickSettings.Instance.urgencyUnknown = false;

            MessageBox.Show("Your filters were adjusted.\r\nYou'll receive only the most severe messages.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void PreferMinorButton_Click(object sender, EventArgs e)
        {
            QuickSettings.Instance.statusActual = true;
            QuickSettings.Instance.statusExercise = false;
            QuickSettings.Instance.statusTest = false;

            QuickSettings.Instance.messageTypeAlert = true;
            QuickSettings.Instance.messageTypeUpdate = true;
            QuickSettings.Instance.messageTypeCancel = true;
            QuickSettings.Instance.messageTypeTest = false;

            QuickSettings.Instance.severityUnknown = true;
            QuickSettings.Instance.severityMinor = true;
            QuickSettings.Instance.severityModerate = true;
            QuickSettings.Instance.severitySevere = true;
            QuickSettings.Instance.severityExtreme = true;

            QuickSettings.Instance.urgencyFuture = true;
            QuickSettings.Instance.urgencyExpected = true;
            QuickSettings.Instance.urgencyImmediate = true;
            QuickSettings.Instance.urgencyPast = false;
            QuickSettings.Instance.urgencyUnknown = true;
            MessageBox.Show("Your filters were adjusted.\r\nYou'll receive most minor and higher messages.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void ChangeToInfoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The large \"Change to...\" buttons will adjust your alert filters to a pre-defined set.",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void PreferMagicButton_Click(object sender, EventArgs e)
        {
            Enabled = false;
            MessageBox.Show("Could not find a compatible brain link device connected to the system. If it is connected, ensure that its data cable is properly seated on both ends.", Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Enabled = true;
            this.Close();
        }
    }
}

