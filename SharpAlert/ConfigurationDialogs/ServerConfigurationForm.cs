using SharpAlert.Properties;
using System;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;

namespace SharpAlert
{
    public partial class ServerConfigurationForm : Form
    {
        public ServerConfigurationForm()
        {
            InitializeComponent();
            AppTypeCombo.DataSource = new ComboItem[] {
                new ComboItem
                {
                    // 1
                    FriendlyName = "Standard",
                },
                new ComboItem
                {
                    // 2
                    FriendlyName = "Server"
                },
                new ComboItem
                {
                    // 3
                    FriendlyName = "Client"
                }
            };
        }

        class ComboItem
        {
            public override string ToString()
            {
                return FriendlyName;
            }

            public string FriendlyName { get; set; }
        }

        private void ServerConfigurationForm_Load(object sender, EventArgs e)
        {
            //AppTypeCombo.SelectedIndex = Settings.Default.RunnerType;
            //AppTypeCombo.SelectedIndexChanged += (a, b) => Settings.Default.RunnerType = (byte)((ComboBox)a).SelectedIndex;
            //ClientServerURLInput.Text = Settings.Default.ClientServerURL;
            //ClientServerURLInput.TextChanged += (a, b) => Settings.Default.ClientServerURL = ((TextBox)a).Text.Trim();
            //ClientServerPortInput.Text = Settings.Default.ClientServerPort;
            //ClientServerPortInput.TextChanged += (a, b) => Settings.Default.ClientServerPort = ((TextBox)a).Text.Trim();
            this.Close();
        }

        private void ServerConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Server settings have been deprecated.",
                "SharpAlert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
            //Settings.Default.Save();
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
    }
}
