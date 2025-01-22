using SharpAlert.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static SharpAlert.Program;

namespace SharpAlert
{
    public partial class TeleIdleForm : Form
    {
        public TeleIdleForm()
        {
            InitializeComponent();
        }

        private void TeleIdleForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            try
            {
                if (!(Settings.Default.alertFullscreenDisplay >= Screen.AllScreens.Count()))
                    this.Location = Screen.AllScreens[Settings.Default.alertFullscreenDisplay].WorkingArea.Location;
            }
            catch (Exception)
            {
            }
            this.WindowState = FormWindowState.Maximized;
            if (Settings.Default.alertCompatibilityMode) MouseMoving.Start();
            InfoText.Text = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} | Started operating: {startDT:f}";
        }

        private void WindowClosingChecker_Tick(object sender, EventArgs e)
        {
            if (CloseIdleWindow) this.Close();
        }

        private void ClockSet_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.UtcNow;
            IdleText.Text = $"{dt:t}\r\n{dt:d}";
        }

        private void TeleIdleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void TeleIdleForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!CloseIdleWindow)
            {
                e.Cancel = true;
                return;
            }
            CursorShown = true;
        }

        public Point cursorPosition = Cursor.Position;

        public delegate void IdlePanelMouse();
        public event IdlePanelMouse MouseTriggered;

        private bool _CursorShown = true;
        public bool CursorShown
        {
            get
            {
                return _CursorShown;
            }
            set
            {
                if (value == _CursorShown)
                {
                    return;
                }

                if (value)
                {
                    Cursor.Show();
                }
                else
                {
                    Cursor.Hide();
                }

                _CursorShown = value;
            }
        }

        private bool MediumState = true;

        private void MouseMoving_Tick(object sender, EventArgs e)
        {
            MediumState = !MediumState;

            if (Cursor.Position != cursorPosition)
            {
                MouseTriggered?.Invoke();
                if (MediumState) cursorPosition = Cursor.Position;
            }
        }

        private void TeleIdleForm_Shown(object sender, EventArgs e)
        {
            CursorShown = false;
        }

        private void IdleText_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
            notify.BalloonTipIcon = ToolTipIcon.Info;
            notify.BalloonTipTitle = "SharpAlert minimized";
            notify.BalloonTipText = "The idle window is on the taskbar, waiting for you to restore it anytime!";
            notify.ShowBalloonTip(5000);
            //notify.ContextMenuStrip.Show(Cursor.Position);
        }

        //public Point cursorPosition = Cursor.Position;

        //public void ShowCursor()
        //{
        //    Cursor.Show();
        //}

        //public void HideCursor()
        //{
        //    Cursor.Hide();
        //}

        //public Point GetCursorPos()
        //{
        //    return Cursor.Position;
        //}
    }
}
