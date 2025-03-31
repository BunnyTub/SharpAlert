using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace SharpAlert
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
#pragma warning restore IDE1006 // Naming Styles
    }
}
