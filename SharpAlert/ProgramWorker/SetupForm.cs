using System;
using System.Windows.Forms;
using SharpAlert.Properties;

namespace SharpAlert.ProgramWorker
{
    public partial class SetupForm : Form
    {
        public SetupForm()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetupForm_Shown(object sender, EventArgs e)
        {
            this.BringToFront();
            FadeInAnimation.Enabled = true;
        }

        private readonly object FadeObject = new object();

        private void FadeInAnimation_Tick(object sender, EventArgs e)
        {
            lock (FadeObject)
            {
                if (this.Opacity >= 1.0)
                {
                    FadeInAnimation.Enabled = false;
                    return;
                }
                this.Opacity += 0.02;
            }
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            //if (!MainEntryPoint.Args.Contains("--show-art"))
            //{
                LogoBox.Visible = false;
                SideLogoBox.Image = Resources.WarningApp;
            //}
        }

        private void SideLogoBox_Click(object sender, EventArgs e)
        {
            LogoBox.Visible = true;
            SideLogoBox.Image = Resources.V_Sign;
            TitleText.Text = "Welcome to SharpAlert~ x3";
        }

        private void SkipButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to skip the setup wizard and start using SharpAlert with no additional questions?",
                this.Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QuickSettings.Instance.SetupExperienceComplete = true;
                this.Close();
            }
        }
    }
}