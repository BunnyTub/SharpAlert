using System;
using System.Drawing;
using System.Windows.Forms;
using SharpAlert.ConfigurationDialogs.DiscordPanels;
using SharpAlert.ProgramWorker;

namespace SharpAlert.ConfigurationDialogs
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
            SwapToRPCButton.PerformClick();

            if (Initialized) return;
            Initialized = true;
        }

        private void ServerConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //QuickSettings.Instance.Save();
            //Environment.Exit(0);
        }

        private void SwapTabs(object sender, UserControl panel)
        {
            SwappingText.BringToFront();

            foreach (Control control in TabPanel.Controls)
            {
                if (control is Label label) if (label == SwappingText) continue;
                control.Hide();
                control.Dispose();
            }

            panel.Dock = DockStyle.Fill;
            TabPanel.Controls.Add(panel);

            foreach (Control control in Controls)
            {
                if (control.Tag is string tag)
                {
                    if (tag.Contains("SwapTabButton"))
                    {
                        if (control is Button u)
                        {
                            u.FlatAppearance.BorderColor = Color.White;
                        }
                    }
                }
            }

            SwappingText.SendToBack();
            if (sender is Button b) b.FlatAppearance.BorderColor = Color.Green;
        }

        private void SwapToRPCButton_Click(object sender, EventArgs e)
        {
            SwapTabs(sender, new DiscordRichPresenceUserControl());
        }

        private void SwapToDiscordWebhooksButton_Click(object sender, EventArgs e)
        {
            SwapTabs(sender, new DiscordWebhookUserControl());
        }
    }
}

