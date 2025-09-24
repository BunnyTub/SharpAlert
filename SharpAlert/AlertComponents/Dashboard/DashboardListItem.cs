using System;
using System.Drawing;
using System.Windows.Forms;
using static SharpAlert.AlertComponents.AlertProcessor;

namespace SharpAlert.AlertComponents.Dashboard
{
    public partial class DashboardListItem : UserControl
    {
        public readonly AlertInfo alertInfo;

        public DashboardListItem(AlertInfo info)
        {
            InitializeComponent();
            if (info != null) alertInfo = info;
            else alertInfo = new AlertInfo { AlertDiscardReason = "The alert information is null." };
        }

        //public Color OutlineColor { get; set; } = Color.Pink;
        //public int OutlineThickness { get; set; } = 2;

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);

        //    using Pen pen = new(OutlineColor, OutlineThickness);

        //    int halfThickness = OutlineThickness / 2;
        //    e.Graphics.DrawRectangle(
        //        pen,
        //        new Rectangle(
        //            halfThickness,
        //            halfThickness,
        //            this.ClientSize.Width - OutlineThickness,
        //            this.ClientSize.Height - OutlineThickness
        //        )
        //    );
        //}

        private void DashboardListItem_Load(object sender, EventArgs e)
        {
            //BackColor = Color.White;
        }

        private void AlertDescriptionText_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"{alertInfo.AlertIntroText}", "SharpAlert - Current Alert Description");
            MessageBox.Show($"{alertInfo.AlertBodyText}", "SharpAlert - Current Alert Description");
        }

        private bool ForcedExpiry = false;

        private void AlertExpiryText_Click(object sender, EventArgs e)
        {
            if (ForcedExpiry)
            {
                MessageBox.Show("You cannot forcefully expire an alert twice.",
                    "SharpAlert - Expire Alert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }

            if (MessageBox.Show("Force this alert into expiry?",
                "SharpAlert - Expire Alert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                alertInfo.AlertExpiryDate = DateTime.UtcNow.AddDays(-1).ToString("s");
                ContainerPanel.BackColor = Color.Gray;
                AlertExpiryText.Text = "EXPIRED";
            }
        }

        private int BackCount = 0;
        private readonly Color Color1 = Color.White;
        private readonly Color FinalColor = Color.FromArgb(20, 20, 20);

        private void ChangeBackgroundColorTimer_Tick(object sender, EventArgs e)
        {
            BackCount++;

            if (BackCount < 8)
            {
                BackColor = (BackCount % 2 == 1) ? Color1 : FinalColor;
            }
            else
            {
                BackColor = FinalColor;
                ChangeBackgroundColorTimer.Stop();
            }
        }
    }
}
