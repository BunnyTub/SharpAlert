using System;
using System.Windows.Forms;
using SharpAlert.Properties;
using SharpAlert.Languages;

namespace SharpAlert.ProgramWorker
{
    public partial class SetupForm : Form
    {
        public SetupForm()
        {
            InitializeComponent();
            Text = $"SharpAlert - {Language.Get("WindowTitle_Setup", "Setup")}";
            TitleText.Text = Language.Get("SetupWelcome_Title", "Welcome to SharpAlert!");
            DescriptionText.Text = Language.Get("SetupWelcome_Description", "Get alerts easily with SharpAlert.\r\n\r\nThis setup will guide you through quickly setting up the program. You can find more customization options by right-clicking the notification icon, and clicking the \"Open Settings\" button.");
            SkipButton.Text = Language.Get("SetupButton_Skip", "Skip");
            DoneButton.Text = Language.Get("SetupButton_Next", "Next");
            BottomText.Text = Language.Get("SetupWelcome_BottomText", "To go through the setup more than once, reset the program.\r\nCreated by BunnyTub. More credits can be found in Settings.");
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

        private readonly object FadeObject = new();

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
            if (MessageBox.Show(Language.Get("SetupWelcome_SkipQuestion", "Do you want to skip the setup wizard and start using SharpAlert with no additional questions?"),
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