using System;
using System.Drawing;
using System.Windows.Forms;
using SharpAlert.ProgramWorker;
using static SharpAlert.ProgramWorker.MainEntryPoint;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class ServerConfigurationForm : Form
    {
        public ServerConfigurationForm()
        {
            InitializeComponent();
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
            DisableDialogsBox.CheckedChanged += (a, b) =>
            {
                QuickSettings.Instance.DisableDialogs = ((CheckBox)a).Checked;
                if (((CheckBox)a).Checked) AwokenNotifier.ShowBasicText("Future alert dialogs will no longer be shown.");
                else AwokenNotifier.ShowBasicText("Future alert dialogs will now be shown.");
            };


            EnableServerBox.Checked = QuickSettings.Instance.EnableServer;
            EnableServerBox.CheckedChanged += (a, b) =>
            {
                QuickSettings.Instance.EnableServer = ((CheckBox)a).Checked;
                MessageBox.Show("This change requires a program restart.", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
        }

        private void ServerConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //QuickSettings.Instance.Save();
            //Environment.Exit(0);
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

        private bool UpDown = true;

        private void WindowShake_Tick(object sender, EventArgs e)
        {
            if (AprilFools.IsAprilFoolsNow)
            {
                if (UpDown)
                {
                    Location = new Point(Location.X, Location.Y + 10);
                }
                else
                {
                    Location = new Point(Location.X, Location.Y - 10);
                }

                UpDown = !UpDown;
            }
        }
    }
}

