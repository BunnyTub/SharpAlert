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

namespace SharpAlert.ConfigurationDialogs.DiscordPanels
{
    public partial class DiscordRichPresenceUserControl : UserControl
    {
        public DiscordRichPresenceUserControl()
        {
            InitializeComponent();
        }

        private bool AllowNotifications = false;

        private void DiscordRichPresenceUserControl_Load(object sender, EventArgs e)
        {
            EnableDiscordRichPresenceBox.Checked = QuickSettings.Instance.AllowDiscordRichPresence;
            AllowNotifications = true;
        }

        private void EnableDiscordRichPresenceBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!AllowNotifications) return;

            if (EnableDiscordRichPresenceBox.Checked)
            {
                MessageBox.Show("SharpAlert will display an alert relay count on your profile, visible to any others who can see it. Restart the program to apply this change.",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("SharpAlert will no longer display an alert relay count on your profile. Restart the program to apply this change.",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            QuickSettings.Instance.AskedForDiscordRichPresence = true;
            QuickSettings.Instance.AllowDiscordRichPresence = EnableDiscordRichPresenceBox.Checked;
        }
    }
}
