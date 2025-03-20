using SharpAlert.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static SharpAlert.AudioManager;

namespace SharpAlert
{
    public partial class AlertForm : Form
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

        public AlertForm()
        {
            InitializeComponent();
            // We used all this fucking P/Invoke, just to make the taskbar icon red!?
            taskbarList = (ITaskbarList3)new CTaskbarList();
            taskbarList.HrInit();
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
            AlertType = type;
            AlertText.SelectionStart = 0;

            switch (type)
            {
                case "alert":
                    TitlePanel.BackColor = Color.Red;
                    SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
                    SpacerPanel.BackColor = Color.DarkOrange;
                    TitleText.Text = "EMERGENCY ALERT";
                    break;
                case "update":
                    TitlePanel.BackColor = Color.Red;
                    SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
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
                    SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
                    SpacerPanel.BackColor = Color.DarkOrange;
                    TitleText.Text = "ALERT TEST";
                    break;
                default:
                    TitlePanel.BackColor = Color.Red;
                    SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
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
        }

        private void AutoExit_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlertForm_Shown(object sender, EventArgs e)
        {
            AutoExit.Interval = Settings.Default.alertTimeout * 60000;
            AutoExit.Start();

            this.Text = $"SharpAlert - {DateTime.Now:f}";
            UpdateTaskbarProgress(TaskbarProgressState.Error, 100, 100);
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

            if (AlertType != "cancel")
            {
                PlayFromUnmanagedSource(Resources.ui_warning_1);
            }
            else
            {
                PlayFromUnmanagedSource(Resources.ui_cancellation_1);
            }

            int LocationMargin = 10;

            switch (Settings.Default.WindowLocation)
            {
                default:
                    if (!(Settings.Default.alertFullscreenDisplay >= Screen.AllScreens.Count()))
                    {
                        this.Location = new Point(
                            (Screen.AllScreens[Settings.Default.alertFullscreenDisplay].WorkingArea.Width - this.Width) / 2,
                            (Screen.AllScreens[Settings.Default.alertFullscreenDisplay].WorkingArea.Height - this.Height) / 2
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
                    if (!(Settings.Default.alertFullscreenDisplay >= Screen.AllScreens.Count()))
                    {
                        this.Location = new Point(
                            Screen.AllScreens[Settings.Default.alertFullscreenDisplay].WorkingArea.Location.X + LocationMargin,
                            Screen.AllScreens[Settings.Default.alertFullscreenDisplay].WorkingArea.Location.Y + LocationMargin
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

            Console.WriteLine("[Alert GUI] Window shown.");
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SpeakerButton_Click(object sender, EventArgs e)
        {
            SpeakerButton.Enabled = false;
            PlayWithFailoverToTTS(AlertAudioUrlStr, AlertTextStr);
        }

        private void UnlockButtons(bool unlocked)
        {
            DismissButton.Enabled = unlocked;
            SpeakerButton.Enabled = unlocked;
            LinkButton.Enabled = unlocked;
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
            StopAllAudioSilently();
            PlayFromUnmanagedSourceAndWait(Resources.ui_end_1);
        }

        IntPtr GotHandle = IntPtr.Zero;

        private int EnsureForTick = 5;

        private void EnsureTopWindow_Tick(object sender, EventArgs e)
        {
            SetWindowPos(GotHandle, (IntPtr)HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
            SetForegroundWindow(GotHandle);
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

        private void AutoTTS_Tick(object sender, EventArgs e)
        {
            AutoTTS.Stop();
        }

        private bool FadeOutExitReady = false;

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
