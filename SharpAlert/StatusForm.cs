using System;
using System.Windows.Forms;
using static SharpAlert.Program;

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
        }

        private void StatusForm_Load(object sender, EventArgs e)
        {
        }
    }
}
