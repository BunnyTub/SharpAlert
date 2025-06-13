using System;
using System.Drawing;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;

namespace SharpAlert
{
    public partial class ServerConfigurationForm : Form
    {
        public ServerConfigurationForm()
        {
            InitializeComponent();
        }

        class ComboItem
        {
            public override string ToString()
            {
                return FriendlyName;
            }

            public string FriendlyName { get; set; }
        }

        private bool Initialized = false;

        private void ServerConfigurationForm_Load(object sender, EventArgs e)
        {
            if (Initialized) return;
            Initialized = true;
            WebServerUsernameInput.Text = QuickSettings.Instance.ServerUsername;
            WebServerUsernameInput.TextChanged += (a, b) => QuickSettings.Instance.ServerUsername = ((TextBox)a).Text.Trim();
            WebServerPasswordInput.Text = QuickSettings.Instance.ServerPassword;
            WebServerPasswordInput.TextChanged += (a, b) => QuickSettings.Instance.ServerPassword = ((TextBox)a).Text.Trim();
            DisableDialogsBox.Checked = QuickSettings.Instance.DisableDialogs;
            DisableDialogsBox.CheckedChanged += (a, b) => QuickSettings.Instance.DisableDialogs = ((CheckBox)a).Checked;
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

        private void SaveServerSettingsButton_Click(object sender, EventArgs e)
        {
            SaveServerSettingsButton.BackColor = Color.FromArgb(60, 60, 60);

            QuickSettings.Instance.ServerUsername = WebServerUsernameInput.Text.Trim();
            QuickSettings.Instance.ServerPassword = WebServerPasswordInput.Text.Trim();
        }

        private void WebServerUsernameInput_KeyDown(object sender, KeyEventArgs e)
        {
            SaveServerSettingsButton.BackColor = Color.FromArgb(200, 60, 60);
        }

        private void WebServerPasswordInput_KeyDown(object sender, KeyEventArgs e)
        {
            SaveServerSettingsButton.BackColor = Color.FromArgb(200, 60, 60);
        }
    }
}
