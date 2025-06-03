using SharpAlert.Properties;
using System;
using System.Windows.Forms;
using System.Linq;

namespace SharpAlert
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void AlertForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            try
            {
                if (!(Settings.Default.alertFullscreenDisplay >= Screen.AllScreens.Count()))
                {
                    this.Location = Screen.AllScreens[Settings.Default.alertFullscreenDisplay].Bounds.Location;
                }
                else
                {
                    this.Location = Screen.PrimaryScreen.Bounds.Location;
                }
            }
            catch (Exception)
            {
            }
            this.WindowState = FormWindowState.Maximized;
        }

        private void AutoExit_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        public void UpdateFields(string text)
        {
            SubtitleText.Text = text;
        }

        private void AlertForm_Shown(object sender, EventArgs e)
        {
            AutoExit.Start();

            if (!Settings.Default.alertCompatibilityMode)
            {
                FadeInAnimation.Start();
            }
            else
            {
                this.Opacity = 0.8;
                UnlockButtons(true);
            }

            ConsoleExt.WriteLine("[Alert GUI] Window shown.");
        }

        private void UnlockButtons(bool unlocked)
        {
            DismissButton.Enabled = unlocked;
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnlockButtons(false);
            AutoExit.Stop();
            if (!Settings.Default.alertCompatibilityMode)
            {
                if (FadeOutExitReady)
                {
                    return;
                }
                else
                {
                    e.Cancel = true;
                    FadeOutAnimation.Start();
                }
            }
        }

        private int EnsureForTick = 5;

        private void EnsureTopWindow_Tick(object sender, EventArgs e)
        {
            EnsureForTick--;

            if (EnsureForTick == 0)
            {
                EnsureTopWindow.Stop();
                return;
            }
        }

        private void AlertForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FadeOutExitReady = false;
            this.Opacity = 0;
            ConsoleExt.WriteLine("[Alert GUI] Window closed.");
        }

        private bool FadeOutExitReady = false;

        private void FadeInAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Opacity > 0.8)
            {
                FadeInAnimation.Stop();
                this.Opacity = 0.8;
                UnlockButtons(true);
                return;
            }
            else
            {
                this.Opacity += 0.01;
            }
        }

        private void FadeOutAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 0)
            {
                FadeOutAnimation.Stop();
                FadeOutExitReady = true;
                this.Hide();
                this.Close();
            }
            else
            {
                FadeInAnimation.Stop();
                this.Opacity -= 0.01;
            }
        }
    }
}
