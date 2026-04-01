using System;
using System.Drawing;
using System.Windows.Forms;

namespace SharpAlert
{
    public partial class DeveloperMessageForm : Form
    {
        //private readonly SoundPlayer snd = new(Resources.despacito);

        public DeveloperMessageForm()
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
            //snd.Play();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            //snd.Stop();
            Close();
        }

        private bool UpDown = true;

        private void WindowShake_Tick(object sender, EventArgs e)
        {
            if (AprilFools.IsAprilFoolsNow)
            {
                if (UpDown)
                {
                    Location = new Point(Location.X, Location.Y + 10);
                }
                else
                {
                    Location = new Point(Location.X, Location.Y - 10);
                }

                UpDown = !UpDown;
            }
        }
    }
}
