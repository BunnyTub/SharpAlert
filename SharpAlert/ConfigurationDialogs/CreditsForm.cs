using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
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
            Process.Start("https://discord.com/users/637078631943897103");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.youtube.com/channel/UCyEsuDNsAPqMAGMtxL8V1Vw?feature=applinks");
        }

        private void label5_DoubleClick(object sender, EventArgs e)
        {
            Process.Start("https://www.youtube.com/watch?v=1KC-2_DnhQg");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://youtube.com/@ItsBunnyTub");
        }

        private void CreditsForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }
#pragma warning restore IDE1006 // Naming Styles
    }
}

