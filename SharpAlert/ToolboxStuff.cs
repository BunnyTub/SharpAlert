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
            private readonly Timer blinkTimer;
            private int textPosition = 0;

            public int ScrollSpeed { get; set; } = 1;

            public MarqueeLabel()
            {
                scrollTimer = new Timer()
                {
                    Interval = 15
                };
                scrollTimer.Tick += new EventHandler(OnScrollTick);
                scrollTimer.Start();

                blinkTimer = new Timer()
                {
                    Interval = 500
                };
                //blinkTimer.Tick += new EventHandler(OnBlinkTick);
                //blinkTimer.Start();
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
                textPosition -= ScrollSpeed;
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

                    if (blinkTimer != null)
                    {
                        blinkTimer.Stop();
                        blinkTimer.Dispose();
                    }
                }

                base.Dispose(disposing);
            }
        }
    }
}
