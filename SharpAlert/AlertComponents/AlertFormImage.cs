using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using static SharpAlert.ProgramWorker.MainEntryPoint;

namespace SharpAlert.AlertComponents
{
    public partial class AlertFormImage : Form
    {
        public AlertFormImage()
        {
            InitializeComponent();
        }

        public void AttemptLoadImage(string URL)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(URL))
                {
                    AttachedImageBox.Load(URL);
                }
                else
                {
                    AttachedImageBox.Load("https://bunnytub.com/SharpAlert/fallback.png");
                }
            }
            catch (Exception)
            {
            }
        }
        
        public void AttemptLoadImage(Bitmap bitmap)
        {
            try
            {
                if (bitmap != null)
                {
                    AttachedImageBox.Image = bitmap;
                }
                else
                {
                    AttachedImageBox.Load("https://bunnytub.com/SharpAlert/fallback.png");
                }
            }
            catch (Exception)
            {
            }
        }

        private void AlertFormImage_Load(object sender, EventArgs e)
        {
        }

        private void AlertFormImage_Shown(object sender, EventArgs e)
        {
        }

        private void FollowParentTimer_Tick(object sender, EventArgs e)
        {
        }

        private void AlertFormImage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AllowThreadRestarts) e.Cancel = true;
        }

        private void AttachedImageBox_LoadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
        }
    }
}

