using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SharpAlert.ProgramWorker;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.ProgramWorker.NotificationWorker;

namespace SharpAlert.DisplayDialogs
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
                if (!(QuickSettings.Instance.alertFullscreenDisplay >= Screen.AllScreens.Count()))
                    this.Location = Screen.AllScreens[QuickSettings.Instance.alertFullscreenDisplay].WorkingArea.Location;
            }
            catch (Exception)
            {
            }
            this.WindowState = FormWindowState.Maximized;
            if (QuickSettings.Instance.alertTimeZoneUTC) UseUTCTimeZone = true;
            if (QuickSettings.Instance.alertCompatibilityMode)
            {
                InfoText.ScrollSpeed = 0;
                IdleText.Dock = DockStyle.Fill;
            }
            else
            {
                MovePreventBurnIn_Tick(null, null);
            }
            ClockSet_Tick(null, null);
            InfoText.Text = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion} | Safety is never a non-priority. | Started operating: {startDT:f}";
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
            Notify.ShowNotification($"The idle window is on the taskbar, waiting for you to restore it anytime!",
                "SharpAlert is minimized",
                ToolTipIcon.Warning);
            //notify.ContextMenuStrip.Show(Cursor.Position);
        }

        private readonly Random RandomMovement = new Random(DateTime.Now.Millisecond);
        private int ColorCounter = 0;

        private void MovePreventBurnIn_Tick(object sender, EventArgs e)
        {
            try
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
                        switch (ColorCounter)
                        {
                            case 0:
                                IdleText.ForeColor = Color.Red;
                                break;
                            case 1:
                                IdleText.ForeColor = Color.Lime;
                                break;
                            case 2:
                                IdleText.ForeColor = Color.Blue;
                                break;
                        }
                        ColorCounter = (ColorCounter + 1) % 3;
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private void TeleIdleForm_Resize(object sender, EventArgs e)
        {
            //MovePreventBurnIn_Tick(null, null);
        }
    }
}

