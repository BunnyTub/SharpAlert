using SharpAlert.ProgramWorker;
using System;
using System.Windows.Forms;

namespace SharpAlert.ConfigurationDialogs.DiscordPanels
{
    public partial class DiscordWebhookUserControl : UserControl
    {
        public DiscordWebhookUserControl()
        {
            InitializeComponent();
        }

        private bool Initialized = false;

        private void DiscordWebhookUserControl_Load(object sender, EventArgs e)
        {
            DropChangesButton.PerformClick();

            if (Initialized) return;
            Initialized = true;

            //DiscordWebhookURLInput.Text = QuickSettings.Instance.DiscordWebhook;
            //DiscordWebhookAppendInput.Text = QuickSettings.Instance.DiscordWebhookAppend;

            DiscordWebhookConfirmAlertsBox.Checked = QuickSettings.Instance.DiscordWebhookConfirmAlerts;
            DiscordWebhookConfirmAlertsBox.CheckedChanged += (a, b) => QuickSettings.Instance.DiscordWebhookConfirmAlerts = ((CheckBox)a).Checked;

            DisableHeartbeatBox.Checked = QuickSettings.Instance.DiscordWebhookDisableHeartbeat;
            DisableHeartbeatBox.CheckedChanged += (a, b) => QuickSettings.Instance.DiscordWebhookDisableHeartbeat = ((CheckBox)a).Checked;

            DiscordWebhookNotificationsBox.Checked = QuickSettings.Instance.DiscordWebhookNotifications;
            DiscordWebhookNotificationsBox.CheckedChanged += (a, b) => QuickSettings.Instance.DiscordWebhookNotifications = ((CheckBox)a).Checked;

            DiscordWebhookRelayLocallyBox.Checked = QuickSettings.Instance.DiscordWebhookRelayLocally;
            DiscordWebhookRelayLocallyBox.CheckedChanged += (a, b) =>
            {
                QuickSettings.Instance.DiscordWebhookRelayLocally = ((CheckBox)a).Checked;
                if (!((CheckBox)a).Checked)
                {
                    //if (string.IsNullOrWhiteSpace(DiscordWebhookURLInput.Text)) AlertAppearanceAndSoundsGroup.Enabled = true;
                    //else AlertAppearanceAndSoundsGroup.Enabled = false;
                }
                else
                {
                    //AlertAppearanceAndSoundsGroup.Enabled = true;
                }
            };

            //DiscordWebhookCombo.SelectedIndexChanged += (a, b) =>
            //{
            //    while (DiscordGroup.Controls.Count > 0)
            //    {
            //        DiscordGroup.Controls[0].Dispose();
            //        //DiscordGroup.Controls.RemoveAt(0);
            //    }

            //    DiscordSubConfigurationForm sub = new DiscordSubConfigurationForm
            //    {
            //        TopLevel = false
            //    };
            //    DiscordGroup.Controls.Add(sub);
            //    sub.Dock = DockStyle.Fill;
            //    sub.Show();
            //};

            BatteryReportingCautionLevelInput.Value = QuickSettings.Instance.BatteryReportingCautionLevel;
            BatteryReportingCautionLevelInput.ValueChanged += (a, b) => QuickSettings.Instance.BatteryReportingCautionLevel = (int)((NumericUpDown)a).Value;
            BatteryReportingCriticalLevelInput.Value = QuickSettings.Instance.BatteryReportingCriticalLevel;
            BatteryReportingCriticalLevelInput.ValueChanged += (a, b) => QuickSettings.Instance.BatteryReportingCriticalLevel = (int)((NumericUpDown)a).Value;
        }

        private void SaveDiscordSettingsButton_Click(object sender, EventArgs e)
        {
            QuickSettings.Instance.DiscordWebhook = DefaultURLInput.Text;
            QuickSettings.Instance.DiscordWebhookAppend = DefaultAppendInput.Text;

            QuickSettings.Instance.DiscordWebhook_FEMA_IPAWS_EAS = EASURLInput.Text;
            QuickSettings.Instance.DiscordWebhookAppend_FEMA_IPAWS_EAS = EASAppendInput.Text;

            QuickSettings.Instance.DiscordWebhook_FEMA_IPAWS_WEA = WEAURLInput.Text;
            QuickSettings.Instance.DiscordWebhookAppend_FEMA_IPAWS_WEA = WEAAppendInput.Text;

            QuickSettings.Instance.DiscordWebhook_NWS_ATOM = NWSAtomURLInput.Text;
            QuickSettings.Instance.DiscordWebhookAppend_NWS_ATOM = NWSAtomAppendInput.Text;

            QuickSettings.Instance.DiscordWebhook_NAADS_PRIMARY = NAADSPrimaryURLInput.Text;
            QuickSettings.Instance.DiscordWebhookAppend_NAADS_PRIMARY = NAADSPrimaryAppendInput.Text;

            QuickSettings.Instance.DiscordWebhook_NAADS_BACKUP = NAADSBackupURLInput.Text;
            QuickSettings.Instance.DiscordWebhookAppend_NAADS_BACKUP = NAADSBackupAppendInput.Text;

            QuickSettings.Instance.DiscordWebhook_SASMEX = SASMEXURLInput.Text;
            QuickSettings.Instance.DiscordWebhookAppend_SASMEX = SASMEXAppendInput.Text;

            QuickSettings.Instance.DiscordWebhook_IDAP = IDAPURLInput.Text;
            QuickSettings.Instance.DiscordWebhookAppend_IDAP = IDAPAppendInput.Text;
        }

        private void DropChangesButton_Click(object sender, EventArgs e)
        {
            DefaultURLInput.Text = QuickSettings.Instance.DiscordWebhook;
            DefaultAppendInput.Text = QuickSettings.Instance.DiscordWebhookAppend;

            EASURLInput.Text = QuickSettings.Instance.DiscordWebhook_FEMA_IPAWS_EAS;
            EASAppendInput.Text = QuickSettings.Instance.DiscordWebhookAppend_FEMA_IPAWS_EAS;

            WEAURLInput.Text = QuickSettings.Instance.DiscordWebhook_FEMA_IPAWS_WEA;
            WEAAppendInput.Text = QuickSettings.Instance.DiscordWebhookAppend_FEMA_IPAWS_WEA;

            NWSAtomURLInput.Text = QuickSettings.Instance.DiscordWebhook_NWS_ATOM;
            NWSAtomAppendInput.Text = QuickSettings.Instance.DiscordWebhookAppend_NWS_ATOM;

            NAADSPrimaryURLInput.Text = QuickSettings.Instance.DiscordWebhook_NAADS_PRIMARY;
            NAADSPrimaryAppendInput.Text = QuickSettings.Instance.DiscordWebhookAppend_NAADS_PRIMARY;

            NAADSBackupURLInput.Text = QuickSettings.Instance.DiscordWebhook_NAADS_BACKUP;
            NAADSBackupAppendInput.Text = QuickSettings.Instance.DiscordWebhookAppend_NAADS_BACKUP;

            SASMEXURLInput.Text = QuickSettings.Instance.DiscordWebhook_SASMEX;
            SASMEXAppendInput.Text = QuickSettings.Instance.DiscordWebhookAppend_SASMEX;

            IDAPURLInput.Text = QuickSettings.Instance.DiscordWebhook_IDAP;
            IDAPAppendInput.Text = QuickSettings.Instance.DiscordWebhookAppend_IDAP;
        }
    }
}
