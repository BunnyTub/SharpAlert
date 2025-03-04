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
#pragma warning restore IDE1006 // Naming Styles
        {
            Process.Start("https://discord.com/users/637078631943897103");
        }
    }
}
