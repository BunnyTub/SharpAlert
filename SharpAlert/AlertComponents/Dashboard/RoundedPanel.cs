using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace SharpAlert.AlertComponents.Dashboard
{
    public class RoundedPanel : Panel
    {
        private readonly int BorderRadius = 8;

        public RoundedPanel()
        {
            BorderStyle = BorderStyle.None;
            DoubleBuffered = true;
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new();

            float CurveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, CurveSize, CurveSize, 180, 90);
            path.AddArc(rect.Right - CurveSize, rect.Y, CurveSize, CurveSize, 270, 90);
            path.AddArc(rect.Right - CurveSize, rect.Bottom - CurveSize, CurveSize, CurveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - CurveSize, CurveSize, CurveSize, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Parent?.BackColor ?? Color.Black);

            Rectangle rectSurface = new(0, 0, Width - 1, Height - 1);

            using (GraphicsPath pathSurface = GetFigurePath(rectSurface, BorderRadius))
            using (SolidBrush brush = new(BackColor))
            {
                e.Graphics.FillPath(brush, pathSurface);
            }
        }

    }
}
