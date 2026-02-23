using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpAlert
{
    public partial class BadgeVerifyForm : Form
    {
        public BadgeVerifyForm()
        {
            InitializeComponent();
        }

        private void BadgeVerifyForm_Load(object sender, EventArgs e)
        {
            Bitmap pic = new(IDIconBox.Image);
            for (int y = 0; (y <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x <= (pic.Width - 1)); x++)
                {
                    Color inv = pic.GetPixel(x, y);
                    inv = Color.FromArgb(inv.A, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    pic.SetPixel(x, y, inv);
                }
            }
            IDIconBox.Image = pic;
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
