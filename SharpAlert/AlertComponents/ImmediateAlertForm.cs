using SharpAlert.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Linq;
using static SharpAlert.AudioManager;
//using GMap.NET;
//using GMap.NET.WindowsForms.Markers;
//using GMap.NET.WindowsForms;

namespace SharpAlert
{
    public partial class ImmediateAlertForm : Form
    {
        private string AlertSubtitleStr = string.Empty;
        private string AlertIntroTextStr = string.Empty;
        private string AlertTextStr = string.Empty;
        private string AlertUrlStr = string.Empty;
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

        public ImmediateAlertForm()
        {
            InitializeComponent();
            // We used all this fucking P/Invoke, just to make the taskbar icon flash red!?
            taskbarList = (ITaskbarList3)new CTaskbarList();
            taskbarList.HrInit();
            //ReplayModeText.Visible = replay;
            //ReplayMode = replay;
        }

        public void UpdateFields(string id, string alert, string intro, string text, string url, string type, double lat, double lng)
        {
            this.Text = $"SharpAlert - Immediate Panel";
            AlertSubtitleStr = alert;
            TitleText.Text = AlertSubtitleStr.ToUpperInvariant();
            AlertIntroTextStr = intro;
            AlertTextStr = text;
            AlertText.Text = $"{AlertIntroTextStr}\r\n\r\n{AlertTextStr}";
            //AlertText.Text = AlertTextStr;
            AlertUrlStr = url;
            AlertType = type;
            AlertText.SelectionStart = 0;
            //GMapPoint.Position = new PointLatLng(lat, lng);
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

            AlertText.HideSelection = false;

            GotHandle = this.Handle;

            UpdateTaskbarProgress(TaskbarProgressState.NoProgress, 0, 0);
            UnlockButtons(true);

            StopAllAudioSilently();

            if (AlertType != "cancel")
            {
                EarthquakeText = "EARTHQUAKE / TERREMOTO";
                PlayFromUnmanagedSource(Resources.ui_shakewarning_1);
            }
            else
            {
                EarthquakeText = "CANCELLED / CANCELADO";
                PlayFromUnmanagedSource(Resources.ui_cancellation_1);
            }

            AlertText.Focus();
            AlertText.SelectionLength = 0;

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

            //GMapPoint.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            //GMaps.Instance.Mode = AccessMode.ServerOnly;
            //GMapPoint.MinZoom = 1;
            //GMapPoint.MaxZoom = 20;

            //// Set zoom to cover ~250km area
            //GMapPoint.Zoom = 8; // Adjust as needed

            //// Overlay and red X marker
            //var overlay = new GMapOverlay("markers");

            //// "Red X" marker using custom bitmap (or use cross icon)
            //var marker = new GMarkerGoogle(new PointLatLng(lat, lng), GMarkerGoogleType.red_big_stop);
            //overlay.Markers.Add(marker);

            //GMapPoint.Overlays.Add(overlay);

            //SetWindowPos(GotHandle, (IntPtr)HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
            SetForegroundWindow(GotHandle);

            FlashTwo = false;
            WindowFlash.Start();

            ConsoleExt.WriteLine("[Alert GUI] Window shown.");
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!MainEntryPoint.AllowThreadRestarts) return;
            UnlockButtons(false);
            AutoExit.Stop();
            StopAllAudioSilently();
            PlayEndToneFile(false);
        }

        IntPtr GotHandle = IntPtr.Zero;

        private void AlertForm_FormClosed(object sender, FormClosedEventArgs e)
        {
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
        }
        
        //private void ShowButtons(bool shown)
        //{
        //    DismissButton.Visible = shown;
        //}

        private void AutoTTS_Tick(object sender, EventArgs e)
        {
            //if (ToneDone)
            //{
            //    AutoTTS.Stop();
            //    PlayFromTTSEngine(AlertIntroTextStr, false);
            //    PlayFromTTSEngine(AlertTextStr, false);
            //}
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

        private void AlertText_DoubleClick(object sender, EventArgs e)
        {
            AlertText.ScrollBars = ScrollBars.Both;
        }

        private void TerminateSelf_Tick(object sender, EventArgs e)
        {
            if (!MainEntryPoint.AllowThreadRestarts)
            {
                this.Close();
            }
        }

        private bool FlashTwo = false;

        private void WindowFlash_Tick(object sender, EventArgs e)
        {
            if (FlashTwo)
            {
                CycleOnce();
                TitleText.BackColor = Color.Red;
                LeftOutlinePanel.BackColor = Color.Red;
                RightOutlinePanel.BackColor = Color.Red;
                BottomOutlinePanel.BackColor = Color.Red;
                //SubtitlePanel.BackColor = Color.FromArgb(140, 0, 0);
            }
            else
            {
                TitleText.BackColor = Color.Maroon;
                LeftOutlinePanel.BackColor = Color.Maroon;
                RightOutlinePanel.BackColor = Color.Maroon;
                BottomOutlinePanel.BackColor = Color.Maroon;
                //SubtitlePanel.BackColor = Color.DarkSlateGray;
            }
            FlashTwo = !FlashTwo;
        }

        bool CycleOne = false;

        private void CycleOnce()
        {
            if (CycleOne)
            {
                CycleTwice();
            }
            else
            {
            }
            CycleOne = !CycleOne;
        }

        bool CycleTwo = false;

        private string EarthquakeText = string.Empty;

        private void CycleTwice()
        {
            if (CycleTwo)
            {
                TitleText.Text = AlertSubtitleStr.ToUpperInvariant();
            }
            else
            {
                TitleText.Text = EarthquakeText;
            }
            CycleTwo = !CycleTwo;
        }

        private void EnsureTopWindow_Tick(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
