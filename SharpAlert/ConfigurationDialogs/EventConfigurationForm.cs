using SharpAlert.ProgramWorker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class EventConfigurationForm : Form
    {
        public EventConfigurationForm()
        {
            InitializeComponent();
        }

        private bool Initialized = false;

        private void EventConfigurationForm_Load(object sender, EventArgs e)
        {
            if (Initialized) return;
            Initialized = true;

            string Events = string.Empty;
            foreach (string _event in QuickSettings.Instance.EnforceEventBlacklist) Events += _event + "\r\n";
            Events = Events.Trim();
            EventBlacklistOutput.Text = Events;

            string SAMEEvents = string.Empty;
            foreach (string SAME_event in QuickSettings.Instance.EnforceSAMEEventBlacklist) SAMEEvents += SAME_event + "\r\n";
            SAMEEvents = SAMEEvents.Trim();
            EventSAMEBlacklistOutput.Text = SAMEEvents;

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

        private void EventSAMEAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(EventSAMEBlacklistInput.Text))
            {
                if (QuickSettings.Instance.EnforceSAMEEventBlacklist.Contains(EventSAMEBlacklistInput.Text))
                {
                    var removal = MessageBox.Show("The event name is already in the list. Remove it?",
                        Text,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (removal == DialogResult.Yes) QuickSettings.Instance.EnforceSAMEEventBlacklist.Remove(EventSAMEBlacklistInput.Text);
                    EventSAMEBlacklistOutput.Clear();
                    foreach (string area in QuickSettings.Instance.EnforceSAMEEventBlacklist)
                    {
                        EventSAMEBlacklistOutput.Text = $"{area}\r\n{EventSAMEBlacklistOutput.Text}";
                    }
                    EventSAMEBlacklistInput.Clear();
                    return;
                }
                else
                {
                    QuickSettings.Instance.EnforceSAMEEventBlacklist.Add(EventSAMEBlacklistInput.Text);
                    EventSAMEBlacklistOutput.Clear();
                    foreach (string area in QuickSettings.Instance.EnforceSAMEEventBlacklist)
                    {
                        EventSAMEBlacklistOutput.Text = $"{area}\r\n{EventSAMEBlacklistOutput.Text}";
                    }
                    EventSAMEBlacklistInput.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter a 3 character event code to add it.",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void EventSAMEClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear SAME event blacklist data?",
                Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QuickSettings.Instance.EnforceSAMEEventBlacklist.Clear();
                EventSAMEBlacklistOutput.Text = string.Empty;
            }
        }

        private void EventSAMESelectButton_Click(object sender, EventArgs e)
        {
            if (eaf == null || eaf.IsDisposed) eaf = new EventsAdditionForm();
            var result = eaf.ShowDialog();
            if (result == DialogResult.OK)
            {
                EventSAMEBlacklistInput.Enabled = false;
                EventSAMEBlacklistInput.Text = eaf.SelectedEvent.ID;
                EventSAMEAddButton.PerformClick();
                EventSAMEBlacklistInput.Enabled = true;
            }
        }

        private void SAMEEventsInfoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If the event of the alert matches any blacklisted SAME events, it will be discarded.",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void EventWhitelistModeBox_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Your lists are now inverted in function.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
