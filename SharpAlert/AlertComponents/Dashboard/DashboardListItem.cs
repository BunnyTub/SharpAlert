using System;
using System.Drawing;
using System.Windows.Forms;
using static SharpAlertPluginBase.AlertContents;

namespace SharpAlert.AlertComponents.Dashboard
{
    public partial class DashboardListItem : UserControl
    {
        public readonly AlertInfo alertInfo;
        public readonly DateTimeOffset startOfExistenceDateTime = DateTimeOffset.UtcNow;

        //private int BorderSize = 0;
        //private int BorderRadius = 8;
        //private Color BorderColor = Color.White;

        public DashboardListItem(AlertInfo info)
        {
            InitializeComponent();
            DoubleBuffered = true;
            if (info != null) alertInfo = info;
            else alertInfo = new AlertInfo { AlertDiscardReason = "The alert information is null." };
        }

        //private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        //{
        //    GraphicsPath path = new();

        //    float CurveSize = radius * 2F;

        //    path.StartFigure();
        //    path.AddArc(rect.X, rect.Y, CurveSize, CurveSize, 180, 90);
        //    path.AddArc(rect.Right - CurveSize, rect.Y, CurveSize, CurveSize, 270, 90);
        //    path.AddArc(rect.Right - CurveSize, rect.Bottom - CurveSize, CurveSize, CurveSize, 0, 90);
        //    path.AddArc(rect.X, rect.Bottom - CurveSize, CurveSize, CurveSize, 90, 90);
        //    path.CloseFigure();

        //    return path;
        //}

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        //    Rectangle rectSurface = ClientRectangle;
        //    Rectangle rectBorder = Rectangle.Inflate(rectSurface, -BorderSize, -BorderSize);

        //    using (GraphicsPath pathSurface = GetFigurePath(rectSurface, BorderRadius))
        //    using (GraphicsPath pathBorder = GetFigurePath(rectBorder, BorderRadius - BorderSize))
        //    using (Pen penSurface = new Pen(Parent?.BackColor ?? Color.Black, BorderSize))
        //    using (Pen penBorder = new Pen(BorderColor, BorderSize))
        //    {
        //        Region = new Region(pathSurface);
        //        e.Graphics.DrawPath(penSurface, pathSurface);

        //        if (BorderSize > 0)
        //            e.Graphics.DrawPath(penBorder, pathBorder);
        //    }
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
                ContainerPanel.BackColor = Color.FromArgb(50, 50, 50);
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

        private void DashboardListItem_Resize(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
