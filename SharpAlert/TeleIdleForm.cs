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

        private bool UseUTCTimeZone = false;

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
            if (Settings.Default.alertFullscreenIdleTimeZoneUTC) UseUTCTimeZone = true;
            if (Settings.Default.alertCompatibilityMode) InfoText.ScrollSpeed = 0;
            InfoText.Text = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} | Started operating: {startDT:f}";
            ClockSet_Tick(null, null);
            MovePreventBurnIn_Tick(null, null);
        }

        private void WindowClosingChecker_Tick(object sender, EventArgs e)
        {
            if (CloseIdleWindow) this.Close();
        }

        private void ClockSet_Tick(object sender, EventArgs e)
        {
            DateTime dt;
            if (UseUTCTimeZone) dt = DateTime.UtcNow;
            else dt = DateTime.Now;
            IdleText.Text = $"{dt:HH}:{dt:mm}\r\n{dt:MMMM} {dt:dd}";
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
        }

        private void TeleIdleForm_Shown(object sender, EventArgs e)
        {
        }

        private void IdleText_DoubleClick(object sender, EventArgs e)
        {
            MinimizeToTaskbar();
        }

        private void IdleContainer_DoubleClick(object sender, EventArgs e)
        {
            MinimizeToTaskbar();
        }

        private void MinimizeToTaskbar()
        {
            this.WindowState = FormWindowState.Minimized;
            notify.BalloonTipIcon = ToolTipIcon.Info;
            notify.BalloonTipTitle = "SharpAlert minimized";
            notify.BalloonTipText = "The idle window is on the taskbar, waiting for you to restore it anytime!";
            notify.ShowBalloonTip(5000);
            //notify.ContextMenuStrip.Show(Cursor.Position);
        }

        private readonly Random RandomMovement = new Random(DateTime.Now.Millisecond);

        private void MovePreventBurnIn_Tick(object sender, EventArgs e)
        {
            int Spacing = 15;

            int WidthCalculated = this.Size.Width - IdleText.Width - Spacing;
            int HeightCalculated = this.Size.Height - IdleText.Height - Spacing;

            if (WidthCalculated < Spacing || HeightCalculated < Spacing)
            {
                return;
            }
            else
            {
                try
                {
                    IdleText.Location = new Point(RandomMovement.Next(Spacing, WidthCalculated), RandomMovement.Next(Spacing, HeightCalculated));
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void TeleIdleForm_Resize(object sender, EventArgs e)
        {
            MovePreventBurnIn_Tick(null, null);
        }
    }
}
