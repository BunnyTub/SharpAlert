using SharpAlert.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;
using static SharpAlert.AudioManager;
using static SharpAlert.AlertProcessor;

namespace SharpAlert
{
    public partial class TeleAlertForm : Form
    {
        private string AlertSubtitleStr = string.Empty;
        private string AlertIntroTextStr = string.Empty;
        private string AlertTextStr = string.Empty;
        private string AlertUrlStr = string.Empty;
        private string AlertAudioUrlStr = string.Empty;
        private string AlertImageUrlStr = string.Empty;
        private string AlertType = string.Empty;

        //private const int HWND_TOPMOST = -1;
        //private const int SWP_NOMOVE = 0x0002;
        //private const int SWP_NOSIZE = 0x0001;
        //private const int SWP_SHOWWINDOW = 0x0040;

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

        public TeleAlertForm()
        {
            InitializeComponent();
            // We used all this fucking P/Invoke, just to make the taskbar icon flash red!?
            taskbarList = (ITaskbarList3)new CTaskbarList();
            taskbarList.HrInit();
            //ReplayModeText.Visible = replay;
            //ReplayMode = replay;
        }

        public void UpdateFields(string id, string alert, string intro, string text, string url, string audio, string image, string type)
        {
            //this.Text = $"SharpAlert - {id}";
            AlertSubtitleStr = alert;
            SubtitleText.Text = AlertSubtitleStr;
            AlertIntroTextStr = intro;
            AlertTextStr = text;
            AlertText.Text = $"{AlertIntroTextStr}\r\n\r\n{AlertTextStr}";
            AlertUrlStr = url;
            AlertAudioUrlStr = audio;
            AlertImageUrlStr = image;
            AlertType = type;
            AlertText.SelectionStart = 0;

            var message = GetTextFromMessageType(type);
            TitleText.Text = message.text;
            ColorTitleAndBordersOne = message.MainColor;
            ColorSubtitleOnlyOne = message.SubColor;

            //switch (type)
            //{
            //    case "alert":
            //        TitleText.BackColor = Color.Red;
            //        SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
            //        TitleText.Text = "EMERGENCY ALERT";
            //        break;
            //    case "update":
            //        TitleText.BackColor = Color.Red;
            //        SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
            //        TitleText.Text = "ALERT UPDATE";
            //        break;
            //    case "cancel":
            //        TitleText.BackColor = Color.FromArgb(0, 80, 200);
            //        SubtitlePanel.BackColor = Color.FromArgb(0, 50, 100);
            //        TitleText.Text = "ALERT CANCELLED";
            //        break;
            //    case "test":
            //        TitleText.BackColor = Color.Red;
            //        SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
            //        TitleText.Text = "ALERT TEST";
            //        break;
            //    default:
            //        TitleText.BackColor = Color.Red;
            //        SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
            //        TitleText.Text = "EMERGENCY ALERT";
            //        break;
            //}
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
        }

        private void AutoExit_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        public Point localCursorPosition = new Point();

        private void AlertForm_Shown(object sender, EventArgs e)
        {
            AutoExit.Interval = Settings.Default.alertTimeout * 60000;
            AutoExit.Start();

            AlertText.HideSelection = false;

            GotHandle = this.Handle;

            if (!Settings.Default.alertCompatibilityMode)
            {
                FadeInAnimation.Start();
                FlashTaskbarStatus.Start();
            }
            else
            {
                FlashTaskbarStatus.Stop();
                UpdateTaskbarProgress(TaskbarProgressState.NoProgress, 0, 0);
                this.Opacity = 1;
                UnlockButtons(true);
            }

            StopAllAudioSilently();

            //if (AlertType != "cancel")
            //{
            //    PlayStartToneFile(false);
            //}
            //else
            //{
            //    PlayFromUnmanagedSource(Resources.ui_cancellation_1);
            //}

            PlayStartToneFile();

            AutoTTS.Start();
            AlertText.Focus();
            AlertText.SelectionLength = 0;
            AutoScroller.Start();

            this.WindowState = FormWindowState.Normal;

            if (Settings.Default.alertTitlebarControls)
            {
                taskbarList.MarkFullscreenWindow(GotHandle, false);
                this.FormBorderStyle = FormBorderStyle.Sizable;
                if (!(Settings.Default.alertFullscreenDisplay >= Screen.AllScreens.Count()))
                {
                    this.Size = new Size(Screen.AllScreens[Settings.Default.alertFullscreenDisplay].Bounds.Width - 100,
                        Screen.AllScreens[Settings.Default.alertFullscreenDisplay].Bounds.Height - 100);
                }
                else
                {
                    this.Size = new Size(Screen.PrimaryScreen.Bounds.Width - 100,
                        Screen.PrimaryScreen.Bounds.Height - 100);
                }
                // fixme
                this.CenterToScreen();
            }
            else
            {
                taskbarList.MarkFullscreenWindow(GotHandle, true);
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
                this.FormBorderStyle = FormBorderStyle.None;
                this.WindowState = FormWindowState.Maximized;
            }

            if (Settings.Default.alertIncreaseSize)
            {
                AlertText.Font = new Font("Arial", 52F);
            }
            else
            {
                AlertText.Font = new Font("Arial", 34F);
            }

            //SetWindowPos(GotHandle, (IntPtr)HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
            SetForegroundWindow(GotHandle);

            localCursorPosition = Cursor.Position;
            MouseMoving.Start();

            FlashTwo = false;
            WindowFlash.Start();

            ConsoleExt.WriteLine("[Alert GUI] Window shown.");
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool FadeOutExitReady = false;

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!MainEntryPoint.AllowThreadRestarts) return;
            UnlockButtons(false);
            AutoExit.Stop();
            StopAllAudioSilently();
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
                PlayEndToneFile(false);
            }
            else
            {
                WindowFlash.Stop();
                PlayEndToneFile(true);
            }
        }

        IntPtr GotHandle = IntPtr.Zero;

        private void LinkButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AlertUrlStr))
            {
                // let's assume this is a URL for now, we'll fix it later
                Process.Start(AlertUrlStr);
                this.Close();
                // he said happily a few months ago
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
            ConsoleExt.WriteLine("[Alert GUI] Window closed.");
        }

        private bool FlashOne = false;

        private void FlashTaskbarStatus_Tick(object sender, EventArgs e)
        {
            if (FlashOne)
            {
                UpdateTaskbarProgress(TaskbarProgressState.Error, 100, 100);
                //AlertIcon.Visible = true;
            }
            else
            {
                UpdateTaskbarProgress(TaskbarProgressState.Normal, 100, 100);
                //AlertIcon.Visible = false;
            }
            FlashOne = !FlashOne;
        }

        private void UnlockButtons(bool unlocked)
        {
            DismissButton.Enabled = unlocked;
            ScreenshotButton.Enabled = unlocked;
            LinkButton.Enabled = unlocked;
        }
        
        private void ShowButtons(bool shown)
        {
            DismissButton.Visible = shown;
            ScreenshotButton.Visible = shown;
            LinkButton.Visible = shown;
        }

        private void AutoTTS_Tick(object sender, EventArgs e)
        {
            if (ToneDone)
            {
                AutoTTS.Stop();
                PlayFromTTSEngine(AlertIntroTextStr, false);
                PlayWithFailoverToTTS(AlertAudioUrlStr, AlertTextStr);
            }
        }

        private void FadeInAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 1)
            {
                FadeInAnimation.Stop();
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
                WindowFlash.Stop();
                this.Hide();
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
                ShowButtons(true);
                AutoHideButtons.Start();
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
        }

        private void AlertText_DoubleClick(object sender, EventArgs e)
        {
            AlertText.ScrollBars = ScrollBars.Both;
        }

        private void AutoHideButtons_Tick(object sender, EventArgs e)
        {
            AutoHideButtons.Stop();
            ShowButtons(false);
            localCursorPosition = Cursor.Position;
            MouseMoving.Start();
        }

        private void ScreenshotButton_Click(object sender, EventArgs e)
        {
            AutoExit.Stop();
            MouseMoving.Stop();
            AutoHideButtons.Stop();
            UnlockButtons(false);
            //AlertIcon.Visible = true;
            AlertText.SelectionStart = 0;
            AlertText.ScrollToCaret();
            try
            {
                Bitmap bitmap = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
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
                        string text = "SharpAlert | Safety is never a non-priority. | https://sharpalert.bunnytub.com/";
                        SizeF textSize = g.MeasureString(text, drawFont);
                        float x = (imageWidth - textSize.Width) / 2;
                        float y = imageHeight - barHeight + (barHeight - textSize.Height) / 2;
                        g.DrawString(text, drawFont, drawBrush, new PointF(x, y));
                    }
                }
                bitmap.Save($"SharpAlert-{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.bmp");
                bitmap.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SharpAlert");
            }
            this.Close();
        }

        private void TerminateSelf_Tick(object sender, EventArgs e)
        {
            if (!MainEntryPoint.AllowThreadRestarts)
            {
                FadeOutExitReady = true;
                this.Close();
            }
        }

        private Color ColorTitleAndBordersOne = Color.Red;
        private Color ColorSubtitleOnlyOne = Color.FromArgb(140, 0, 0);
        private readonly Color ColorTitleAndBordersTwo = Color.SlateGray;
        private readonly Color ColorSubtitleOnlyTwo = Color.DarkSlateGray;

        private bool FlashTwo = false;

        private void WindowFlash_Tick(object sender, EventArgs e)
        {
            if (FlashTwo)
            {
                TitleText.BackColor = ColorTitleAndBordersOne;
                LeftOutlinePanel.BackColor = ColorTitleAndBordersOne;
                RightOutlinePanel.BackColor = ColorTitleAndBordersOne;
                BottomOutlinePanel.BackColor = ColorTitleAndBordersOne;
                SubtitlePanel.BackColor = ColorSubtitleOnlyOne;
            }
            else
            {
                TitleText.BackColor = ColorTitleAndBordersTwo;
                LeftOutlinePanel.BackColor = ColorTitleAndBordersTwo;
                RightOutlinePanel.BackColor = ColorTitleAndBordersTwo;
                BottomOutlinePanel.BackColor = ColorTitleAndBordersTwo;
                SubtitlePanel.BackColor = ColorSubtitleOnlyTwo;
            }
            FlashTwo = !FlashTwo;
        }

        private void EnsureTopWindow_Tick(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
