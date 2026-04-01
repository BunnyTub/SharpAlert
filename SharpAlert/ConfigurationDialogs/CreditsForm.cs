using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SharpAlert.AlertComponents;
using SharpAlert.Properties;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class CreditsForm : Form
    {
        public CreditsForm()
        {
            InitializeComponent();
        }

        private void CreditsForm_Load(object sender, EventArgs e)
        {
        }

#pragma warning disable IDE1006 // Naming Styles
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HackyWorkarounds.OpenURL("https://discord.com/users/637078631943897103");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HackyWorkarounds.OpenURL("https://www.youtube.com/channel/UCyEsuDNsAPqMAGMtxL8V1Vw?feature=applinks");
        }

        private void label5_DoubleClick(object sender, EventArgs e)
        {
            HackyWorkarounds.OpenURL("https://www.youtube.com/watch?v=1KC-2_DnhQg");
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HackyWorkarounds.OpenURL("https://youtube.com/@ItsBunnyTub");
        }

        private void CreditsForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        private void label1_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("OwO", "OwO");
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

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
#pragma warning restore IDE1006 // Naming Styles
    }
}

