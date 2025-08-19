using SharpAlert.ProgramWorker;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static SharpAlert.AudioManager;

namespace SharpAlert.AlertComponents
{
    public partial class MiniAlertForm : Form
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

        public MiniAlertForm()
        {
            InitializeComponent();
            // We used all this fucking P/Invoke, just to make the taskbar icon red!?
            taskbarList = (ITaskbarList3)new CTaskbarList();
            taskbarList.HrInit();
        }

        public void UpdateFields(string id, string alert, string intro, string text, string url, string audio, string image, string type, string severity)
        {
            AlertIDStr = id;
            this.Text = $"SharpAlert - {AlertIDStr}";
            AlertSubtitleStr = alert;
            AlertText.Text = AlertSubtitleStr;
            AlertIntroTextStr = intro;
            AlertTextStr = text;
            //AlertText.Text += $"\x20| {AlertIntroTextStr} {AlertTextStr}";
            AlertText.Text += $"\x20| {AlertIntroTextStr.Replace("\r\n", "\x20".Trim())} {AlertTextStr.Replace("\r\n", "\x20".Trim())}";
            AlertUrlStr = url;
            AlertAudioUrlStr = audio;
            AlertImageUrlStr = image;
            AlertType = type;
            AlertSeverity = severity;

            switch (type)
            {
                case "alert":
                    TitlePanel.BackColor = Color.Red;
                    OutlineContainerPanel.BorderColor = Color.Red;
                    SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
                    TitleText.Text = "EMERGENCY ALERT";
                    break;
                case "update":
                    TitlePanel.BackColor = Color.Red;
                    OutlineContainerPanel.BorderColor = Color.Red;
                    SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
                    TitleText.Text = "ALERT UPDATE";
                    break;
                case "cancel":
                    TitlePanel.BackColor = Color.FromArgb(0, 80, 200);
                    OutlineContainerPanel.BorderColor = Color.FromArgb(0, 80, 200);
                    SubtitlePanel.BackColor = Color.FromArgb(0, 50, 100);
                    TitleText.Text = "ALERT CANCELLED";
                    break;
                case "test":
                    TitlePanel.BackColor = Color.Red;
                    OutlineContainerPanel.BorderColor = Color.Red;
                    SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
                    TitleText.Text = "ALERT TEST";
                    break;
                default:
                    TitlePanel.BackColor = Color.Red;
                    OutlineContainerPanel.BorderColor = Color.Red;
                    SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
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
            AutoExit.Interval = QuickSettings.Instance.alertTimeout * 60000;
            AutoExit.Start();

            this.Text = $"SharpAlert - Emergency Alert";
            UpdateTaskbarProgress(TaskbarProgressState.Error, 100, 100);
            GotHandle = this.Handle;

            if (!QuickSettings.Instance.alertCompatibilityMode)
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

            //if (AlertType != "cancel")
            //{
            //    //PlayFromManagedSource(GenerateFSKStream($"{AlertIDStr}|{DateTime.UtcNow:s)}|{AlertType}|{AlertSubtitleStr.Replace("|", "_")}"));
            //    //PlayFromUnmanagedSource(Resources.ui_warning_1);
            //    PlayStartToneFile();
            //}
            //else
            //{
            //    PlayFromUnmanagedSource(Resources.ui_cancellation_1);
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

            this.Location = new Point(
                Screen.PrimaryScreen.WorkingArea.Width - this.Width - LocationMargin,
                Screen.PrimaryScreen.WorkingArea.Height - this.Height - LocationMargin
            );

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
            LinkButton.Enabled = unlocked;
        }

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!MainEntryPoint.AllowThreadRestarts) return;
            UnlockButtons(false);
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
                PlayEndToneFile(false);
            }
            else
            {
                PlayEndToneFile(true);
            }
        }

        IntPtr GotHandle = IntPtr.Zero;

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
                UpdateTaskbarProgress(TaskbarProgressState.Error, 100, 100);
            }
            else
            {
                UpdateTaskbarProgress(TaskbarProgressState.Normal, 100, 100);
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

        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        
        private void TitleText_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void MiniAlertForm_Paint(object sender, PaintEventArgs e)
        {
        }

        private void TitleText_Click(object sender, EventArgs e)
        {

        }

        private void AlertText_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"The current time is {DateTime.UtcNow.ToLocalTime():t}. {AlertIntroTextStr} {AlertTextStr}",
                "SharpAlert - Emergency Alert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void TerminateSelf_Tick(object sender, EventArgs e)
        {
            if (!MainEntryPoint.AllowThreadRestarts)
            {
                FadeOutExitReady = true;
                this.Close();
            }
        }
    }
}

