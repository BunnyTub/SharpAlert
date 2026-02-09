using System.Drawing;
using System.Drawing.Printing;

namespace SharpAlert.PrinterStuff
{
    public class PrinterController
    {
        public static void Print(string alert, string text)
        {
            PrintDocument doc = new();

            var printData = new PrintData
            {
                Title = alert,
                Body = text
            };

            doc.PrintPage += (sender, e) => PrintPageHandler(e, printData);

            doc.PrinterSettings.PrintToFile = true;

            //PrintDialog dlg = new PrintDialog
            //{
            //    Document = doc
            //};

            //if (dlg.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }

            doc.Dispose();
        }

        private static void PrintPageHandler(PrintPageEventArgs e, PrintData data)
        {
            Graphics g = e.Graphics;
            Rectangle pageBounds = e.MarginBounds;

            Font headerFont = new("Arial", 22, FontStyle.Bold);
            Font bodyFont = new("Arial", 14);
            Brush redBrush = Brushes.Red;
            Brush blackBrush = Brushes.Black;

            SizeF headerSize = g.MeasureString(data.Title, headerFont);
            float headerX = pageBounds.Left + (pageBounds.Width - headerSize.Width) / 2;
            float headerY = pageBounds.Top;
            g.DrawString(data.Title, headerFont, redBrush, headerX, headerY);

            float bodyY = headerY + headerSize.Height + 20;
            g.DrawString(data.Body, bodyFont, blackBrush, new RectangleF(pageBounds.Left, bodyY, pageBounds.Width, pageBounds.Height - bodyY));

            headerFont.Dispose();
            bodyFont.Dispose();
        }

        private class PrintData
        {
            public string Title { get; set; }
            public string Body { get; set; }
        }
    }
}
