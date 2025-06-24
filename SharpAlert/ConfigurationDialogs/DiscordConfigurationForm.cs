using System;
using System.Drawing;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;

namespace SharpAlert
{
    public partial class DiscordConfigurationForm : Form
    {
        public DiscordConfigurationForm()
        {
            InitializeComponent();
        }

        private bool Initialized = false;

        private void ServerConfigurationForm_Load(object sender, EventArgs e)
        {
            if (Initialized) return;
            Initialized = true;

            DiscordWebhookURLInput.Text = QuickSettings.Instance.DiscordWebhook;
            DiscordWebhookAppendInput.Text = QuickSettings.Instance.DiscordWebhookAppend;

            DiscordWebhookConfirmAlertsBox.Checked = QuickSettings.Instance.DiscordWebhookConfirmAlerts;
            DiscordWebhookConfirmAlertsBox.CheckedChanged += (a, b) => QuickSettings.Instance.DiscordWebhookConfirmAlerts = ((CheckBox)a).Checked;
            
            DisableHeartbeatBox.Checked = QuickSettings.Instance.DiscordWebhookDisableHeartbeat;
            DisableHeartbeatBox.CheckedChanged += (a, b) => QuickSettings.Instance.DiscordWebhookDisableHeartbeat = ((CheckBox)a).Checked;

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
        }

        private void ServerConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //QuickSettings.Instance.Save();
            //Environment.Exit(0);
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

        private void SaveDiscordSettingsButton_Click(object sender, EventArgs e)
        {
            SaveDiscordSettingsButton.BackColor = Color.FromArgb(60, 60, 60);

            QuickSettings.Instance.DiscordWebhook = DiscordWebhookURLInput.Text.Trim();
            QuickSettings.Instance.DiscordWebhookAppend = DiscordWebhookAppendInput.Text.Trim();
        }

        private void NS_UnhideSecureBox_CheckedChanged(object sender, EventArgs e)
        {
            DiscordWebhookURLInput.UseSystemPasswordChar = ((CheckBox)sender).Checked;
            DiscordWebhookAppendInput.UseSystemPasswordChar = ((CheckBox)sender).Checked;
        }

        private void DiscordWebhookURLInput_TextChanged(object sender, EventArgs e)
        {
            SaveDiscordSettingsButton.BackColor = Color.FromArgb(200, 60, 60);
        }

        private void DiscordWebhookAppendInput_TextChanged(object sender, EventArgs e)
        {
            SaveDiscordSettingsButton.BackColor = Color.FromArgb(200, 60, 60);
        }
    }
}
