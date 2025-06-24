using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;

namespace SharpAlert
{
    public partial class StatusForm : Form
    {
        public StatusForm()
        {
            InitializeComponent();
        }

        private void RefreshData_Tick(object sender, EventArgs e)
        {
            if (CloseStatusWindow) this.Close();

            DateTime now = DateTime.UtcNow;

            UptimeMeterText.Text = $"{(int)(now - startDT).TotalHours} hour(s), " +
                $"{(now - startDT).Minutes} minute(s), " +
                $"{(now - startDT).Seconds} second(s)";
            CAPQueueCountText.Text = SharpDataQueue.Count.ToString();
            CAPHistoryCountText.Text = SharpDataHistory.Count.ToString();
            AlertQueueCountText.Text = AlertProcessor.AlertsQueued.ToString();
            AlertsRelayedText.Text = AlertProcessor.AlertsRelayed.ToString();
            ServerRequestsText.Text = FeedSuccessfulCalls.ToString();
        }

        private const int MF_BYPOSITION = 0x400;
        [DllImport("user32.dll")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32.dll")]
        private static extern int GetMenuItemCount(IntPtr hWnd);

        private void StatusForm_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int menuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, menuItemCount - 1, MF_BYPOSITION);
        }
    }
}
