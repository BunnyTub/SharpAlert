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
            
            RemoveNWSDescCodeBox.Checked = QuickSettings.Instance.RemoveNWSDescCode;
            RemoveNWSDescCodeBox.CheckedChanged += (a, b) => QuickSettings.Instance.RemoveNWSDescCode = ((CheckBox)a).Checked;

            RemoveNWSNewLinesBox.Checked = QuickSettings.Instance.RemoveNWSNewLines;
            RemoveNWSNewLinesBox.CheckedChanged += (a, b) => QuickSettings.Instance.RemoveNWSNewLines = ((CheckBox)a).Checked;
        }

        private void ChooseRegionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void ChooseRegionForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("You can enable/disable certain parts of the alert text.",
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

