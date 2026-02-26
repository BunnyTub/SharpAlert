using SharpAlert.ProgramWorker;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpAlert.AlertComponents
{
    internal static class MonitorWindowAligner
    {
        public static void AlignWindow(Form form)
        {
            Screen screen = Screen.PrimaryScreen;

            if (screen == null) return;

            if (!(QuickSettings.Instance.alertFullscreenDisplay >= Screen.AllScreens.Length))
            {
                screen = Screen.AllScreens[QuickSettings.Instance.alertFullscreenDisplay];
            }

            int LocationMargin = 10;

            switch (QuickSettings.Instance.WindowLocation)
            {
                default:
                    form.Location = new Point((screen.WorkingArea.Width - form.Width) / 2 + screen.WorkingArea.X, (screen.WorkingArea.Height - form.Height) / 2 + screen.WorkingArea.Y);
                    break;
                case 1:
                    form.Location = new Point(screen.WorkingArea.Location.X + LocationMargin + screen.WorkingArea.X, screen.WorkingArea.Location.Y + LocationMargin + screen.WorkingArea.Y);
                    break;
                case 2:
                    form.Location = new Point(screen.WorkingArea.Width - form.Width - LocationMargin + screen.WorkingArea.X, LocationMargin + screen.WorkingArea.Y);
                    break;
                case 3:
                    form.Location = new Point(LocationMargin + screen.WorkingArea.X, screen.WorkingArea.Height - form.Height - LocationMargin + screen.WorkingArea.Y);
                    break;
                case 4:
                    form.Location = new Point(screen.WorkingArea.Width - form.Width - LocationMargin + screen.WorkingArea.X, screen.WorkingArea.Height - form.Height - LocationMargin + screen.WorkingArea.Y);
                    break;
            }
        }

        public static void AlignWindowNoCornerLocation(Form form)
        {
            Screen screen = Screen.PrimaryScreen;

            if (screen == null) return;

            if (!(QuickSettings.Instance.alertFullscreenDisplay >= Screen.AllScreens.Length))
            {
                screen = Screen.AllScreens[QuickSettings.Instance.alertFullscreenDisplay];
            }

            bool WasMaximized = false;

            if (form.WindowState == FormWindowState.Maximized)
            {
                form.WindowState = FormWindowState.Normal;
                WasMaximized = true;
            }

            form.Location = new Point(screen.WorkingArea.X, screen.WorkingArea.Y);

            if (WasMaximized) form.WindowState = FormWindowState.Maximized;
        }
    }
}
