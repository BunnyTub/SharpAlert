using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharpAlert
{
    public static class ToolboxStuff
    {
        public class MarqueeLabel : Label
        {
            private readonly Timer scrollTimer;
            private float textPosition = 0;

            public float ScrollSpeed { get; set; } = 1.5f;

            public MarqueeLabel()
            {
                scrollTimer = new Timer()
                {
                    Interval = 1
                };
                scrollTimer.Tick += new EventHandler(OnScrollTick);
                scrollTimer.Start();
            }

            private bool Started = false;

            protected override void OnPaint(PaintEventArgs e)
            {
                if (!Started)
                {
                    textPosition = this.Width;
                    Started = true;
                    return;
                }

                if (this.Text.Length == 0) return;

                SizeF textSize = e.Graphics.MeasureString(this.Text, this.Font);

                RectangleF textRect;

                switch (base.TextAlign)
                {
                    case ContentAlignment.TopLeft:
                        textRect = new RectangleF((this.DesignMode || ScrollSpeed == 0) ? 0 : textPosition, 0, textSize.Width, this.Height);
                        e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect);
                        break;
                    case ContentAlignment.MiddleLeft:
                        textRect = new RectangleF((this.DesignMode || ScrollSpeed == 0) ? 0 : textPosition, (this.Height - textSize.Height) / 2, textSize.Width, this.Height);
                        e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect);
                        break;
                    case ContentAlignment.BottomLeft:
                        textRect = new RectangleF((this.DesignMode || ScrollSpeed == 0) ? 0 : textPosition, this.Height - textSize.Height, textSize.Width, this.Height);
                        e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect);
                        break;
                    default:
                        textRect = new RectangleF((this.DesignMode || ScrollSpeed == 0) ? 0 : textPosition, 0, textSize.Width, this.Height);
                        e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect);
                        break;
                }

                if (textPosition < -textSize.Width)
                {
                    // TODO
                    // Raise event here when the scroll finishes
                    textPosition = this.Width;
                }
            }

            public new string Text
            {
                get
                {
                    return base.Text;
                }
                set
                {
                    SetText(value);
                }
            }

            public void SetText(string text)
            {
                if (text.Length == base.Text.Length)
                {
                    base.Text = text;
                }
                else
                {
                    base.Text = text;
                    Started = false;
                    this.Invalidate();
                }
            }

            protected override void OnTextChanged(EventArgs e)
            {
                base.OnTextChanged(e);
                //Started = false;
                //this.Invalidate();
                //base.OnTextChanged(e);
            }

            protected override void OnSizeChanged(EventArgs e)
            {
                Started = false;
                this.Invalidate();
                base.OnSizeChanged(e);
            }

            private void OnScrollTick(object sender, EventArgs e)
            {
                textPosition -= ScrollSpeed / 2f;
                this.Invalidate();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    if (scrollTimer != null)
                    {
                        scrollTimer.Stop();
                        scrollTimer.Dispose();
                    }
                }

                base.Dispose(disposing);
            }
        }

        public class BorderPanel : Panel
        {
            private Color _BorderColor = Color.Black;

            public Color BorderColor
            {
                get
                {
                    return _BorderColor;
                }
                set
                {
                    _BorderColor = value;
                    this.Invalidate();
                }
            }

            public int BorderThickness { get; set; } = 2;

            public BorderPanel()
            {
                // Redraw when resized or repainted
                this.DoubleBuffered = true;
                this.ResizeRedraw = true;
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                using (var pen = new Pen(_BorderColor, BorderThickness))
                {
                    pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Outset;
                    int offset = BorderThickness / 2;
                    var rect = new Rectangle(
                        offset,
                        offset,
                        this.Width - BorderThickness,
                        this.Height - BorderThickness);
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }
    }
}
