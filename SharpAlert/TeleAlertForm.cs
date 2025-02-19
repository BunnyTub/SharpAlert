using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static SharpAlert.Program;
using SharpAlert.Properties;
using System.Drawing;
using System.Linq;
using NAudio.Wave;

namespace SharpAlert
{
    public partial class TeleAlertForm : Form
    {
        private string AlertSubtitleStr = string.Empty;
        private string AlertTextStr = string.Empty;
        private string AlertUrlStr = string.Empty;
        private string AlertAudioUrlStr = string.Empty;
        private string AlertImageUrlStr = string.Empty;
        private string AlertType = string.Empty;

        private const int HWND_TOPMOST = -1;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_SHOWWINDOW = 0x0040;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private enum TaskbarProgressState
        {
            NoProgress = 0,
            Indeterminate = 1,
            Normal = 2,
            Error = 4,
            Paused = 8
        }

        [ComImport]
        [Guid("ea1afb91-9e28-4b86-90e9-9e9f8a5eefaf")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        private interface ITaskbarList3
        {
            [PreserveSig]
            void HrInit();
            [PreserveSig]
            void AddTab(IntPtr hwnd);
            [PreserveSig]
            void DeleteTab(IntPtr hwnd);
            [PreserveSig]
            void ActivateTab(IntPtr hwnd);
            [PreserveSig]
            void SetActiveAlt(IntPtr hwnd);
            [PreserveSig]
            void MarkFullscreenWindow(IntPtr hwnd, [MarshalAs(UnmanagedType.Bool)] bool fFullscreen);
            [PreserveSig]
            void SetProgressValue(IntPtr hwnd, ulong completed, ulong total);
            [PreserveSig]
            void SetProgressState(IntPtr hwnd, TaskbarProgressState state);
        }

        [ComImport]
        [Guid("56FDF344-FD6D-11D0-958A-006097C9A090")]
        [ClassInterface(ClassInterfaceType.None)]
        private class CTaskbarList { }

        private readonly ITaskbarList3 taskbarList;

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint ucount;
            public uint dwTimeout;
        }

        private readonly bool ReplayMode = false;

        public TeleAlertForm()
        {
            InitializeComponent();
            // We used all this fucking P/Invoke, just to make the taskbar icon flash red!?
            taskbarList = (ITaskbarList3)new CTaskbarList();
            taskbarList.HrInit();
            //ReplayModeText.Visible = replay;
            //ReplayMode = replay;
        }

        public void UpdateFields(string alert, string text, string url, string audio, string image, string type)
        {
            AlertSubtitleStr = alert;
            SubtitleText.Text = AlertSubtitleStr;
            AlertTextStr = text;
            AlertText.Text = AlertTextStr;
            AlertUrlStr = url;
            AlertAudioUrlStr = audio;
            AlertImageUrlStr = image;
            AlertText.SelectionStart = 0;

            switch (type)
            {
                case "alert":
                    TitlePanel.BackColor = Color.Red;
                    SubtitlePanel.BackColor = Color.FromArgb(140, 0, 0);
                    SpacerPanel.BackColor = Color.DarkOrange;
                    TitleText.Text = "EMERGENCY ALERT";
                    break;
                case "update":
                    TitlePanel.BackColor = Color.Red;
                    SubtitlePanel.BackColor = Color.FromArgb(140, 0, 0);
                    SpacerPanel.BackColor = Color.DarkOrange;
                    TitleText.Text = "ALERT UPDATE";
                    break;
                case "cancel":
                    TitlePanel.BackColor = Color.FromArgb(0, 80, 200);
                    SubtitlePanel.BackColor = Color.FromArgb(0, 50, 100);
                    SpacerPanel.BackColor = Color.FromArgb(200, 200, 200);
                    TitleText.Text = "ALERT CANCELLED";
                    break;
                case "test":
                    TitlePanel.BackColor = Color.Red;
                    SubtitlePanel.BackColor = Color.FromArgb(140, 0, 0);
                    SpacerPanel.BackColor = Color.DarkOrange;
                    TitleText.Text = "ALERT TEST";
                    break;
                default:
                    TitlePanel.BackColor = Color.Red;
                    SubtitlePanel.BackColor = Color.FromArgb(140, 0, 0);
                    SpacerPanel.BackColor = Color.DarkOrange;
                    TitleText.Text = "EMERGENCY ALERT";
                    break;
            }
        }

        private void UpdateTaskbarProgress(TaskbarProgressState state, ulong completed, ulong total)
        {
            if (GotHandle != null || GotHandle == IntPtr.Zero)
            {
                taskbarList.SetProgressState(GotHandle, state);

                if (state == TaskbarProgressState.Normal || state == TaskbarProgressState.Error || state == TaskbarProgressState.Paused)
                {
                    taskbarList.SetProgressValue(GotHandle, completed, total);
                }
            }
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

        public Point localCursorPosition = Cursor.Position;

        private void AlertForm_Shown(object sender, EventArgs e)
        {
            AutoExit.Interval = Settings.Default.alertTimeout * 60000;
            AutoExit.Start();

            AlertText.HideSelection = false;

            GotHandle = this.Handle;

            if (!Settings.Default.alertCompatibilityMode)
            {
                FadeInAnimation.Start();
            }
            else
            {
                this.Opacity = 1;
            }

            if (ReplayMode)
            {
                FlashReplayStatus.Start();
            }
            else
            {
                FlashTaskbarStatus.Start();
            }

            if (AlertType != "cancel")
            {
                sound.Play();
            }
            else
            {
                soundCancellation.Play();
            }

            engine.SetOutputToDefaultAudioDevice();
            AutoTTS.Start();

            AlertText.Focus();
            AlertText.SelectionLength = 0;
            AutoScroller.Start();

            SetWindowPos(GotHandle, (IntPtr)HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
            SetForegroundWindow(GotHandle);

            Console.WriteLine("[Alert GUI] Window shown.");
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool FadeOutExitReady = false;

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AutoExit.Stop();
            AutoScroller.Stop();
            if (FadeOutExitReady)
            {
                return;
            }
            else
            {
                e.Cancel = true;
                FadeOutAnimation.Start();
            }
            sound.Stop();
            engine.SpeakAsyncCancelAll();
            soundFinish.Stop();
        }

        IntPtr GotHandle = IntPtr.Zero;

        // unused
        private void EnsureTopWindow_Tick(object sender, EventArgs e)
        {
            EnsureTopWindow.Stop();
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
                UpdateTaskbarProgress(TaskbarProgressState.Error, 100, 100);
                AlertIcon.Visible = true;
            }
            else
            {
                UpdateTaskbarProgress(TaskbarProgressState.Normal, 100, 100);
                AlertIcon.Visible = false;
            }
            FlashOne = !FlashOne;
        }

        private void FlashReplayStatus_Tick(object sender, EventArgs e)
        {
            if (FlashOne)
            {
                AlertIcon.Visible = true;
                ReplayModeText.Visible = true;
            }
            else
            {
                AlertIcon.Visible = false;
                ReplayModeText.Visible = false;
            }
            FlashOne = !FlashOne;
        }

        private void AutoTTS_Tick(object sender, EventArgs e)
        {
            AutoTTS.Stop();

            if (!string.IsNullOrWhiteSpace(AlertAudioUrlStr))
            {
                try
                {
                    using (var mf = new MediaFoundationReader(AlertAudioUrlStr))
                    {
                        AudioOutput.Init(mf);
                        AudioOutput.Play();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Alert GUI] Failed to play remote audio. TTS will be played instead. {ex.Message}");
                    engine.SpeakAsync(AlertProcessor.StringIntoTTSFriendly(AlertTextStr));
                }
            }
            else
            {
                engine.SpeakAsync(AlertProcessor.StringIntoTTSFriendly(AlertTextStr));
            }
        }

        private void FadeInAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 1)
            {
                FadeInAnimation.Stop();
                DismissButton.Enabled = true;
                LinkButton.Enabled = true;
                ScreenshotButton.Enabled = true;
                return;
            }
            else
            {
                this.Opacity += 0.01;
            }
        }

        private void FadeOutAnimation_Tick(object sender, EventArgs e)
        {
            if (Settings.Default.alertCompatibilityMode)
            {
                FadeOutAnimation.Stop();
                FadeOutExitReady = true;
                this.Close();
            }

            if (this.Opacity == 0)
            {
                FadeOutAnimation.Stop();
                FadeOutExitReady = true;
                this.Hide();
                engine.SpeakAsyncCancelAll();
                this.Close();
            }
            else
            {
                this.Opacity -= 0.01;
            }
        }

        private void MouseMoving_Tick(object sender, EventArgs e)
        {
            if (Cursor.Position != localCursorPosition)
            {
                MouseMoving.Stop();
                AutoScroller.Stop();
                AlertText.SelectionStart = 0;
                DismissButton.Visible = true;
                LinkButton.Visible = true;
                ScreenshotButton.Visible = true;
                AutoHideButtons.Enabled = true;
            }
        }

        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        private int PauseScroll = 0;

        private void AutoScroll_Tick(object sender, EventArgs e)
        {
            //AlertText.SelectionLength = 0;
            if (AlertText.Text.Length >= AlertText.SelectionStart & PauseScroll > 0)
            {
                AlertText.SelectionStart++;
                HideCaret(AlertText.Handle);
            }
            else
            {
                AlertText.SelectionStart = 0;
                HideCaret(AlertText.Handle);
                if (PauseScroll <= 0) PauseScroll = 35;
                PauseScroll--;
            }
            AlertText.ScrollToCaret();
            HideCaret(AlertText.Handle);
        }

        private void AlertIcon_Click(object sender, EventArgs e)
        {
            if (DismissButton.Enabled)
            {
                this.Close();
            }
        }

        private void AlertText_TextChanged(object sender, EventArgs e)
        {
            HideCaret(AlertText.Handle);
        }

        private void AlertText_Enter(object sender, EventArgs e)
        {
            HideCaret(AlertText.Handle);
        }

        private void TitleText_DoubleClick(object sender, EventArgs e)
        {
            AlertText.Font = new Font("Arial", 56F);
        }

        private void AlertText_DoubleClick(object sender, EventArgs e)
        {
            AlertText.ScrollBars = ScrollBars.Both;
        }

        private void AutoHideButtons_Tick(object sender, EventArgs e)
        {
            AutoHideButtons.Enabled = false;
            DismissButton.Visible = true;
            LinkButton.Visible = true;
            ScreenshotButton.Visible = true;
            localCursorPosition = Cursor.Position;
            MouseMoving.Start();
        }

        private void ScreenshotButton_Click(object sender, EventArgs e)
        {
            AutoExit.Stop();
            FlashTaskbarStatus.Stop();
            MouseMoving.Stop();
            AutoHideButtons.Enabled = false;
            DismissButton.Visible = false;
            LinkButton.Visible = false;
            ScreenshotButton.Visible = false;
            AlertIcon.Visible = true;
            AlertText.SelectionStart = 0;
            AlertText.ScrollToCaret();
            Bitmap bitmap = new Bitmap(Bounds.Width, Bounds.Height);
            this.DrawToBitmap(bitmap, Bounds);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                int barHeight = 30;
                int imageWidth = bitmap.Width;
                int imageHeight = bitmap.Height;

                using (SolidBrush coolTransparency = new SolidBrush(Color.FromArgb(140, 255, 0, 0)))
                {
                    g.FillRectangle(coolTransparency, new Rectangle(0, imageHeight - barHeight, imageWidth, barHeight));
                }

                using (Font drawFont = new Font("Arial", 12, FontStyle.Bold))
                using (SolidBrush drawBrush = new SolidBrush(Color.White))
                {
                    string text = "SharpAlert | Safety is never a non-priority.";
                    SizeF textSize = g.MeasureString(text, drawFont);
                    float x = (imageWidth - textSize.Width) / 2;
                    float y = imageHeight - barHeight + (barHeight - textSize.Height) / 2;
                    g.DrawString(text, drawFont, drawBrush, new PointF(x, y));
                }
            }
            bitmap.Save($"SharpAlert-{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.bmp");
            bitmap.Dispose();
            this.Close();
        }
    }
}
