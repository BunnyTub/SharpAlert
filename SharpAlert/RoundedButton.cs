//using System.Drawing.Drawing2D;
//using System.Drawing;
//using System.Windows.Forms;

//namespace SharpAlert
//{
//    //public class RoundedButton : Button
//    //{
//    //    private int cornerRadius = 10; // Change this value to adjust the curve radius

//    //    protected override void OnPaint(PaintEventArgs pevent)
//    //    {
//    //        base.OnPaint(pevent);

//    //        // Create a GraphicsPath for the rounded rectangle
//    //        GraphicsPath path = new GraphicsPath();
//    //        float arcWidth = cornerRadius * 2;
//    //        float arcHeight = cornerRadius * 2;

//    //        // Top-left arc
//    //        path.AddArc(0, 0, arcWidth, arcHeight, 180, 90);
//    //        // Top-right arc
//    //        path.AddArc(Width - arcWidth, 0, arcWidth, arcHeight, 270, 90);
//    //        // Bottom-right arc
//    //        path.AddArc(Width - arcWidth, Height - arcHeight, arcWidth, arcHeight, 0, 90);
//    //        // Bottom-left arc
//    //        path.AddArc(0, Height - arcHeight, arcWidth, arcHeight, 90, 90);
//    //        path.CloseFigure();

//    //        // Apply the GraphicsPath as the Region of the button
//    //        this.Region = new Region(path);

//    //        // Optionally draw the border
//    //        using (Pen borderPen = new Pen(ForeColor, 2)) // Adjust border width as needed
//    //        {
//    //            pevent.Graphics.DrawPath(borderPen, path);
//    //        }
//    //    }
//    //}
//}
