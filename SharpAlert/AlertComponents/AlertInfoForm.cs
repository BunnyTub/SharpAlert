using SharpAlert.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static SharpAlert.AlertProcessor;

namespace SharpAlert
{
    public partial class AlertInfoForm : Form
    {
        private string AlertIDStr = string.Empty;
        private string AlertSubtitleStr = string.Empty;
        private string AlertIntroTextStr = string.Empty;
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

        public AlertInfoForm()
        {
            InitializeComponent();
            // We used all this fucking P/Invoke, just to make the taskbar icon red!?
            taskbarList = (ITaskbarList3)new CTaskbarList();
            taskbarList.HrInit();
        }

        public void UpdateFields(string id, string alert, string intro, string text, string url, string audio, string image, string type)
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

            TitleText.Text = GetTextFromMessageType(type).text;
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
            if (Settings.Default.alertTitlebarControls)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
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

            if (Settings.Default.alertIncreaseSize)
            {
                AlertText.Font = new Font("Arial", 24F);
            }
            else
            {
                AlertText.Font = new Font("Arial", 18F);
            }

            //OutlineContainerPanel.BorderColor = ColorTitleAndBordersOne;
            //TitleText.BackColor = ColorTitleAndBordersOne;
            //AlertIcon.BackColor = ColorTitleAndBordersOne;
            //SubtitlePanel.BackColor = ColorSubtitleOnlyOne;

            if (!string.IsNullOrWhiteSpace(AlertImageUrlStr))
            {
                ShowImage();
            }

            ConsoleExt.WriteLine("[Alert GUI] Window shown.");
        }

        private void DismissButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AlertForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            HideImage();
            return;
        }

        private void AlertForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConsoleExt.WriteLine("[Alert GUI] Window closed.");
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void TitleText_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void OutlineContainerPanel_Paint(object sender, PaintEventArgs e)
        {
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

        private void AlertIcon_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void AlertLinkText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AlertUrlStr))
            {
                // let's assume this is a URL for now, we'll fix it later
                Process.Start(AlertUrlStr);
            }
            else
            {
                MessageBox.Show("This alert has no accompanying website.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private readonly AlertFormImage afi = new AlertFormImage();

        private void SubtitleText_DoubleClick(object sender, EventArgs e)
        {
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
    }
}
