using System;
using System.Windows.Forms;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class AlertTextConfigurationForm : Form
    {
        public AlertTextConfigurationForm(bool ShowNextInsteadOfDone)
        {
            InitializeComponent();
            if (ShowNextInsteadOfDone) DoneButton.Text = "Next";
            else DoneButton.Text = "Done";
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private class ComboItem
        {
            public override string ToString()
            {
                return FriendlyName;
            }

            public string FriendlyName { get; set; }
        }

        private bool Initialized = false;

        private void ChooseRegionForm_Load(object sender, EventArgs e)
        {
            if (Initialized) return;
            Initialized = true;

            AddIntroTextBox.Checked = QuickSettings.Instance.AddIntroText;
            AddIntroTextBox.CheckedChanged += (a, b) => QuickSettings.Instance.AddIntroText = ((CheckBox)a).Checked;
            
            AddAlertEffectiveAndEndingTimesBox.Checked = QuickSettings.Instance.AddAlertEffectiveAndEndingTimes;
            AddAlertEffectiveAndEndingTimesBox.CheckedChanged += (a, b) => QuickSettings.Instance.AddAlertEffectiveAndEndingTimes = ((CheckBox)a).Checked;

            AddAlertIssuerBox.Checked = QuickSettings.Instance.AddAlertIssuer;
            AddAlertIssuerBox.CheckedChanged += (a, b) => QuickSettings.Instance.AddAlertIssuer = ((CheckBox)a).Checked;
            
            AddSourcedFromBox.Checked = QuickSettings.Instance.AddSourcedFrom;
            AddSourcedFromBox.CheckedChanged += (a, b) => QuickSettings.Instance.AddSourcedFrom = ((CheckBox)a).Checked;
            
            AddEventNameBox.Checked = QuickSettings.Instance.AddEventName;
            AddEventNameBox.CheckedChanged += (a, b) => QuickSettings.Instance.AddEventName = ((CheckBox)a).Checked;

            Use24HrTimeBox.Checked = QuickSettings.Instance.Use24HrTime;
            Use24HrTimeBox.CheckedChanged += (a, b) => QuickSettings.Instance.Use24HrTime = ((CheckBox)a).Checked;
        }

        private void ChooseRegionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void ChooseRegionForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("You can change certain parts of the alert text.",
                "SharpAlert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            e.Cancel = true;
        }

        private void UpdateTextField_Tick(object sender, EventArgs e)
        {

        }
    }
}

