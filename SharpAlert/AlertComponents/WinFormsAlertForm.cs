using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using static SharpAlert.AudioManager;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.AlertComponents.AlertProcessor;
using static SharpAlert.AlertComponents.AlertDisplayer;

namespace SharpAlert.AlertComponents
{
    public partial class WinFormsAlertForm : Form
    {
        private string AlertIDStr = string.Empty;
        private string AlertSubtitleStr = string.Empty;
        private string AlertIntroTextStr = string.Empty;
        private string AlertTextStr = string.Empty;
        private string AlertUrlStr = string.Empty;
        private string AlertAudioUrlStr = string.Empty;
        private string AlertImageUrlStr = string.Empty;
        private string AlertType = string.Empty;
        private string AlertSeverity = string.Empty;

        public WinFormsAlertForm()
        {
            InitializeComponent();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            //int radius = 5;
            //using (GraphicsPath path = RoundedCorners.Create(
            //    new Rectangle(0, 0, this.Width, this.Height),
            //    radius,
            //    RoundedCorners.RectangleCorners.All
            //))
            //{
            //    this.Region = new Region(path);
            //}
        }

        public void UpdateFields(string id, string alert, string intro, string text, string url, string audio, string image, string type, string severity)
        {
            AlertIDStr = id;
            //this.Text = $"SharpAlert - {AlertIDStr}";
            AlertSubtitleStr = alert;
            SubtitleText.Text = AlertSubtitleStr;
            AlertIntroTextStr = intro;
            AlertTextStr = text;
            AlertText.Text = $"{AlertIntroTextStr}\r\n\r\n{AlertTextStr}";
            AlertUrlStr = url;
            AlertAudioUrlStr = audio;
            AlertImageUrlStr = image;
            AlertType = type;
            AlertSeverity = severity;
            AlertText.SelectionLength = 0;
            AlertText.SelectionStart = 0;

            if (string.IsNullOrWhiteSpace(AlertUrlStr))
            {
                AlertLinkText.Enabled = false;
                AlertLinkText.Text = string.Empty;
            }
            else
            {
                AlertLinkText.Enabled = true;
                AlertLinkText.Text = AlertUrlStr;
            }

            var message = GetTextFromMessageSeverityAndType(severity, type);
            TitleText.Text = message.text;
            ColorTitleAndBordersOne = message.MainColor;
            ColorSubtitleOnlyOne = message.SubColor;
        }

        private void AlertForm_Load(object sender, EventArgs e)
        {
        }

        private void AutoExit_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private Color ColorTitleAndBordersOne = Color.Red;
        private Color ColorSubtitleOnlyOne = Color.FromArgb(140, 0, 0);
        private readonly Color ColorTitleAndBordersTwo = Color.SlateGray;
        private readonly Color ColorSubtitleOnlyTwo = Color.DarkSlateGray;

        private void AlertForm_Shown(object sender, EventArgs e)
        {
            ExitToneCalled = false;

            AutoExit.Interval = QuickSettings.Instance.alertTimeout * 60000;
            AutoExit.Start();

            //this.Text = $"SharpAlert - {AlertSubtitleStr}";
            GotHandle = this.Handle;

            if (!QuickSettings.Instance.alertCompatibilityMode)
            {
                FadeInAnimation.Start();
                FlashTaskbarStatus.Start();
            }
            else
            {
                FlashTaskbarStatus.Stop();
                this.Opacity = 1;
                //UnlockButtons(true);
            }

            StopAllAudioSilently();

            //if (AlertType != "cancel")
            //{
            //    //PlayFromManagedSource(GenerateFSKStream($"{AlertIDStr}|{DateTime.UtcNow:s)}|{AlertType}|{AlertSubtitleStr.Replace("|", "_")}"));
            //    //PlayFromUnmanagedSource(Resources.ui_warning_1);
            //    PlayStartToneFile();
            //}
            //else
            //{
            //    //PlayFromUnmanagedSource(Resources.ui_cancellation_1);
            //}

            PlayStartToneFile(AlertSeverity);

            if (QuickSettings.Instance.alertTitlebarControls)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }

            int LocationMargin = 10;

            switch (QuickSettings.Instance.WindowLocation)
            {
                default:
                    if (!(QuickSettings.Instance.alertFullscreenDisplay >= Screen.AllScreens.Length))
                    {
                        this.Location = new Point(
                            (Screen.AllScreens[QuickSettings.Instance.alertFullscreenDisplay].WorkingArea.Width - this.Width) / 2,
                            (Screen.AllScreens[QuickSettings.Instance.alertFullscreenDisplay].WorkingArea.Height - this.Height) / 2
                        );
                    }
                    else
                    {
                        this.Location = new Point(
                            (Screen.PrimaryScreen.WorkingArea.Width - this.Width) / 2,
                            (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2
                        );
                    }
                    break;
                case 1:
                    if (!(QuickSettings.Instance.alertFullscreenDisplay >= Screen.AllScreens.Length))
                    {
                        this.Location = new Point(
                            Screen.AllScreens[QuickSettings.Instance.alertFullscreenDisplay].WorkingArea.Location.X + LocationMargin,
                            Screen.AllScreens[QuickSettings.Instance.alertFullscreenDisplay].WorkingArea.Location.Y + LocationMargin
                        );
                    }
                    else
                    {
                        this.Location = new Point(
                            LocationMargin,
                            LocationMargin
                        );
                    }
                    break;
                case 2:
                    // unfinished
                    this.Location = new Point(
                        Screen.PrimaryScreen.WorkingArea.Width - this.Width - LocationMargin,
                        LocationMargin
                    );
                    break;
                case 3:
                    // unfinished
                    this.Location = new Point(
                        LocationMargin,
                        Screen.PrimaryScreen.WorkingArea.Height - this.Height - LocationMargin
                    );
                    break;
                case 4:
                    // unfinished
                    this.Location = new Point(
                        Screen.PrimaryScreen.WorkingArea.Width - this.Width - LocationMargin,
                        Screen.PrimaryScreen.WorkingArea.Height - this.Height - LocationMargin
                    );
                    break;
            }

            if (QuickSettings.Instance.alertIncreaseSize)
            {
                AlertText.Font = new Font("Arial", 24F);
            }
            else
            {
                AlertText.Font = new Font("Arial", 18F);
            }

            FlashTwo = false;

            OutlineContainerPanel.BorderColor = ColorTitleAndBordersOne;
            TitleText.BackColor = ColorTitleAndBordersOne;
            AlertIcon.BackColor = ColorTitleAndBordersOne;
            SubtitlePanel.BackColor = ColorSubtitleOnlyOne;

            if (!QuickSettings.Instance.alertCompatibilityMode)
            {
                WindowFlash.Start();
            }

            if (!string.IsNullOrWhiteSpace(AlertImageUrlStr))
            {
                ShowImage();
            }

            Console.WriteLine("[Alert GUI] Window shown.");
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            SpeakingManager.DismissingWindow();
            this.Close();
        }

        private void SpeakerButton_Click(object sender, EventArgs e)
        {
            SpeakerButton.Enabled = false;
            PlayFromTTSEngine(AlertIntroTextStr, false);
            PlayWithFailoverToTTS(AlertAudioUrlStr, AlertTextStr);
        }

        private void UnlockButtons(bool unlocked)
        {
            DismissButton.Enabled = unlocked;
            SpeakerButton.Enabled = unlocked;
            AlertLinkText.Enabled = unlocked;
        }

        private bool ExitToneCalled = false;

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HideImage();
            if (!AllowThreadRestarts) return;
            //UnlockButtons(false);
            AutoExit.Stop();
            if (!QuickSettings.Instance.alertCompatibilityMode)
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
                if (!ExitToneCalled) PlayEndToneFile(false);
                ExitToneCalled = true;
            }
            else
            {
                WindowFlash.Stop();
                if (!ExitToneCalled) PlayEndToneFile(true);
                ExitToneCalled = true;
            }

        }

        private IntPtr GotHandle = IntPtr.Zero;

        private int EnsureForTick = 5;

        private void EnsureTopWindow_Tick(object sender, EventArgs e)
        {
            this.BringToFront();
            this.Activate();
            EnsureForTick--;

            if (EnsureForTick == 0)
            {
                EnsureTopWindow.Stop();
                return;
            }
        }

        private void LinkButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AlertUrlStr))
            {
                // let's assume this is a URL for now, we'll fix it later
                Process.Start(AlertUrlStr);
                this.Close();
            }
            else
            {
                MessageBox.Show("This alert has no accompanying website.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void AlertForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            FadeOutExitReady = false;
            this.Opacity = 0;
            Console.WriteLine("[Alert GUI] Window closed.");
        }

        private bool FlashOne = false;

        private void FlashTaskbarStatus_Tick(object sender, EventArgs e)
        {
            if (FlashOne)
            {
                // red
                //AlertIcon.Visible = true;
            }
            else
            {
                // green
                //AlertIcon.Visible = false;
            }
            FlashOne = !FlashOne;
        }

        private bool FadeOutExitReady = false;

        private void FadeInAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 1)
            {
                FadeInAnimation.Stop();
                //UnlockButtons(true);
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
                WindowFlash.Stop();
                this.Hide();
                this.Close();
            }
            else
            {
                FadeInAnimation.Stop();
                this.Opacity -= 0.01;
            }
        }

        private void TitleText_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("window movement is unavailable");
            //ReleaseCapture();
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void OutlineContainerPanel_Paint(object sender, PaintEventArgs e)
        {
        }

        private bool FlashTwo = false;

        private void WindowFlash_Tick(object sender, EventArgs e)
        {
            if (FlashTwo)
            {
                OutlineContainerPanel.BorderColor = ColorTitleAndBordersOne;
                TitleText.BackColor = ColorTitleAndBordersOne;
                AlertIcon.BackColor = ColorTitleAndBordersOne;
                SubtitlePanel.BackColor = ColorSubtitleOnlyOne;
                if (AlertsQueued != 0)
                {
                    DismissButton.Text = "Continue";
                }
            }
            else
            {
                OutlineContainerPanel.BorderColor = ColorTitleAndBordersTwo;
                TitleText.BackColor = ColorTitleAndBordersTwo;
                AlertIcon.BackColor = ColorTitleAndBordersTwo;
                SubtitlePanel.BackColor = ColorSubtitleOnlyTwo;
                if (AlertsQueued != 0)
                {
                    //DismissButton.Text = $"{AlertsQueued} remain";
                    DismissButton.Text = "Continue";
                }
                else
                {
                    DismissButton.Text = "Dismiss";
                }
            }
            FlashTwo = !FlashTwo;
        }

        private void TerminateSelf_Tick(object sender, EventArgs e)
        {
            if (!AllowThreadRestarts)
            {
                FadeOutExitReady = true;
                this.Close();
            }
        }

        private int BottomRightMx;
        private int BottomRightMy;
        private int BottomRightSw;
        private int BottomRightSh;
        private bool BottomRightMov;

        private void ResizableThingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            BottomRightMov = true;
            BottomRightMx = MousePosition.X;
            BottomRightMy = MousePosition.Y;
            BottomRightSw = Width;
            BottomRightSh = Height;
        }

        private void ResizableThingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (BottomRightMov)
            {
                Width = MousePosition.X - BottomRightMx + BottomRightSw;
                Height = MousePosition.Y - BottomRightMy + BottomRightSh;
            }
        }

        private void ResizableThingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            BottomRightMov = false;
        }

        private int BottomLeftMx;
        private int BottomLeftMy;
        private int BottomLeftSw;
        private int BottomLeftSh;
        private bool BottomLeftMov;

        private void ResizeBottomLeft_MouseDown(object sender, MouseEventArgs e)
        {
            BottomLeftMov = true;
            BottomLeftMx = MousePosition.X;
            BottomLeftMy = MousePosition.Y;
            BottomLeftSw = Width;
            BottomLeftSh = Height;
        }

        private void ResizeBottomLeft_MouseMove(object sender, MouseEventArgs e)
        {
            if (BottomLeftMov)
            {
                //SetDesktopLocation(MousePosition.X, Location.Y);
                Width = MousePosition.X - Width;
                Height = MousePosition.Y - BottomLeftMy + BottomLeftSh;
            }
        }

        private void ResizeBottomLeft_MouseUp(object sender, MouseEventArgs e)
        {
            BottomLeftMov = false;
        }

        private void AlertIcon_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine("window movement is unavailable");
            //ReleaseCapture();
            //SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AlertLinkText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AlertUrlStr))
            {
                // let's assume this is a URL for now, we'll fix it later
                Process.Start(AlertUrlStr);
                this.Close();
            }
            else
            {
                MessageBox.Show("This alert has no accompanying website.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
        }

        private readonly AlertFormImage afi = new();

        private void SubtitleText_DoubleClick(object sender, EventArgs e)
        {
            // Twitter Banner Resizing
            //this.Height = 240;
        }

        private void ShowImage()
        {
            afi.Show();
            try
            {
                afi.Location = new Point(this.Location.X + this.Size.Width + 5, this.Location.Y);
            }
            catch (Exception)
            {
            }
            afi.Text = $"SharpAlert - Attached Image | {AlertImageUrlStr}";
            afi.AttemptLoadImage(AlertImageUrlStr);
            //afi.AttemptLoadImage("https://cdn.discordapp.com/attachments/1199589026362052619/1366494987352801380/I_turned_into_a_dragon.jpg?ex=68112721&is=680fd5a1&hm=6a775bdbf87370da25bdf0ba71763d521b6183ecb4ce36d57ad88a2f867425ae&");
            afi.Opacity = 0.90;
            ChildFollowsParent.Start();
        }

        private void HideImage()
        {
            ChildFollowsParent.Stop();
            afi.Opacity = 0;
            afi.Hide();
        }

        private void ChildFollowsParent_Tick(object sender, EventArgs e)
        {
            try
            {
                afi.Location = new Point(this.Location.X + this.Size.Width + 5, this.Location.Y);
            }
            catch (Exception)
            {
            }
        }

        private void DismissAllAlertsFor30SecondsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeadTimeOverride = 30;
            this.Close();
        }

        private void AlertIcon_Click(object sender, EventArgs e)
        {
        }
    }
}

