using SharpAlert.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static SharpAlert.Program;

namespace SharpAlert
{
    public partial class AlertForm : Form
    {
        private string AlertTextStr = string.Empty;
        private string AlertUrlStr = string.Empty;
        private bool AlertCancelled = false;

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

        public void UpdateFields(string alert, string text, string url, bool cancellation)
        {
            AlertTextStr = text;
            SubtitleText.Text = alert;
            AlertText.Text = text;
            AlertText.SelectionStart = 0;
            if (!string.IsNullOrWhiteSpace(url))
            {
                AlertUrlStr = url;
            }
            AlertCancelled = cancellation;
            if (!cancellation)
            {
                TitlePanel.BackColor = Color.Red;
                SubtitlePanel.BackColor = Color.FromArgb(180, 0, 0);
                SpacerPanel.BackColor = Color.DarkOrange;
                TitleText.Text = "EMERGENCY ALERT";
            }
            else
            {
                TitlePanel.BackColor = Color.FromArgb(0, 80, 200);
                SubtitlePanel.BackColor = Color.FromArgb(0, 50, 100);
                SpacerPanel.BackColor = Color.FromArgb(200, 200, 200);
                TitleText.Text = "ALERT CANCELLED";
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
            }
            else
            {
                this.Opacity = 1;
                DismissButton.Enabled = true;
                SpeakerButton.Enabled = true;
                LinkButton.Enabled = true;
            }

            if (!AlertCancelled)
            {
                sound.Play();
            }
            else
            {
                soundCancellation.Play();
            }
            engine.SetOutputToDefaultAudioDevice();

            Console.WriteLine("[Alert GUI] Window shown.");
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SpeakerButton_Click(object sender, EventArgs e)
        {
            //foreach (var voice in Program.engine.GetInstalledVoices())
            //{
            //    //ConsoleExt.WriteLine(voice.VoiceInfo.Culture.TwoLetterISOLanguageName.ToLowerInvariant());
            //    if (voice.VoiceInfo.Name.Contains(Settings.Default.SpeechVoice) && voice.VoiceInfo.Culture.TwoLetterISOLanguageName.ToLowerInvariant() == lang)
            //    {
            //        //ConsoleExt.WriteLine(voice.VoiceInfo.Name, ConsoleColor.Magenta);
            //        engine.SelectVoice(voice.VoiceInfo.Name);
            //        break;
            //    }
            //}

            SpeakerButton.Enabled = false;
            engine.SpeakAsync(AlertTextStr);
        }

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            sound.Stop();
            engine.SpeakAsyncCancelAll();
            soundFinish.Stop();
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
            if (AlertUrlStr != null)
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
            if (FlashOne) UpdateTaskbarProgress(TaskbarProgressState.Error, 100, 100);
            else UpdateTaskbarProgress(TaskbarProgressState.Normal, 100, 100);
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
                DismissButton.Enabled = true;
                SpeakerButton.Enabled = true;
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
                FadeInAnimation.Stop();
                this.Opacity -= 0.01;
            }
        }
    }
}
