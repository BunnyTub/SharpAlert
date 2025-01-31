using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static SharpAlert.Program;
using SharpAlert.Properties;
using System.Drawing;
using System.Linq;
using System.Threading;

namespace SharpAlert
{
    public partial class TeleAlertForm : Form
    {
        readonly string AlertTextStr;
        readonly string AlertUrlStr;

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

        //[DllImport("user32.dll", SetLastError = true)]
        //private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        //private const byte VK_MEDIA_PLAY_PAUSE = 0xB3;
        //private const uint KEYEVENTF_KEYDOWN = 0x0000;
        //private const uint KEYEVENTF_KEYUP = 0x0002;

        private readonly bool ReplayMode = false;

        //Cursor cursor = Cursor.Current;

        public TeleAlertForm(string alert, string text, string url, bool replay)
        {
            InitializeComponent();
            // We used all this fucking P/Invoke, just to make the taskbar icon flash red!?
            taskbarList = (ITaskbarList3)new CTaskbarList();
            taskbarList.HrInit();
            AlertTextStr = text;
            SubtitleText.Text = alert;
            // Padding to prevent immediate wrap around when scrolling automatically
            AlertText.Text = text +
                "\r\n".PadRight(35) +
                "\r\n".PadRight(35) +
                "\r\n".PadRight(35) +
                "\r\n".PadRight(35) +
                "\r\n".PadRight(35);
            AlertText.SelectionStart = 0;
            ReplayModeText.Visible = replay;
            ReplayMode = replay;
            if (!string.IsNullOrWhiteSpace(url))
            {
                AlertUrlStr = url;
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

        bool ShowAndWaitCall = false;

        public void ShowAndWait()
        {
            ShowAndWaitCall = true;
            idle.IdleContainer.Invoke(new MethodInvoker(delegate { this.Show(); this.BringToFront(); this.Focus(); }));
            while (!FadeOutExitReady) Thread.Sleep(100);
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
            }
            else
            {
                this.Opacity = 1;
                if (ShowAndWaitCall) idle.MouseTriggered += ShowAndEnableButtons;
            }

            if (ReplayMode)
            {
                FlashReplayStatus.Start();
            }
            else
            {
                FlashTaskbarStatus.Start();
            }

            if (!ShowAndWaitCall)
            {
                localCursorPosition = Cursor.Position;
                Cursor.Hide();
            }
            else
            {
                idle.CursorShown = false;
            }

            //if (!ShowAndWaitCall)
            {
                sound.Play();
                engine.SetOutputToDefaultAudioDevice();
            }

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
            if (ShowAndWaitCall)
            {
                FadeOutExitReady = true;
                if (ShowAndWaitCall)
                {
                    idle.MouseTriggered -= ShowAndEnableButtons;
                    idle.CursorShown = false;
                }
            }
            else
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
            sound.Stop();
            engine.SpeakAsyncCancelAll();
            soundFinish.Stop();
        }

        private void ShowAndEnableButtons()
        {
            idle.MouseTriggered -= ShowAndEnableButtons;
            idle.CursorShown = true;
            this.Invoke(new Action(() =>
            {
                DismissButton.Enabled = true;
                LinkButton.Enabled = true;
                DismissButton.Visible = true;
                LinkButton.Visible = true;
            }));
        }

        IntPtr GotHandle = IntPtr.Zero;

        // unused
        private void EnsureTopWindow_Tick(object sender, EventArgs e)
        {
            EnsureTopWindow.Stop();
        }

        private void LinkButton_Click(object sender, EventArgs e)
        {
            if (AlertUrlStr != null)
            {
                // this is so fucking bad lmao
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
            Console.WriteLine("[Alert GUI] Window closed.");
            this.Dispose(true);
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
            if (!ShowAndWaitCall) engine.SpeakAsync(AlertTextStr);
        }

        private void FadeInAnimation_Tick(object sender, EventArgs e)
        {
            if (this.Opacity == 1)
            {
                FadeInAnimation.Stop();
                DismissButton.Enabled = true;
                LinkButton.Enabled = true;
                return;
            }
            else
            {
                this.Opacity += 0.01;
            }
        }

        private void FadeOutAnimation_Tick(object sender, EventArgs e)
        {
            if (ShowAndWaitCall)
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
            if (!ShowAndWaitCall)
            {
                if (Cursor.Position != localCursorPosition)
                {
                    MouseMoving.Stop();
                    AutoScroller.Stop();
                    AlertText.SelectionStart = 0;
                    DismissButton.Visible = true;
                    LinkButton.Visible = true;
                    Cursor.Show();
                    AutoHideButtons.Enabled = true;
                }
            }
            else
            {
                MouseMoving.Stop();
                //if (idle.cursorPosition != localCursorPosition)
                //{
                //    MouseMoving.Stop();
                //    AutoScroller.Stop();
                //    AlertText.SelectionStart = 0;
                //    DismissButton.Visible = true;
                //    LinkButton.Visible = true;
                //    Cursor.Show();
                //}
            }
        }

        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);

        private void AutoScroll_Tick(object sender, EventArgs e)
        {
            //AlertText.SelectionLength = 0;
            if (AlertText.Text.Length > AlertText.SelectionStart)
            {
                AlertText.SelectionStart++;
            }
            else
            {
                AlertText.SelectionStart = 0;
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
            DismissButton.Visible = false;
            LinkButton.Visible = false;
        }
    }
}
