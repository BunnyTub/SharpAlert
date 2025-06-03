using System;
using System.Windows.Forms;
using SharpAlert.Properties;
using static SharpAlert.IceBearWorker;

namespace SharpAlert
{
    public partial class QuickAccessForm : Form
    {
        public QuickAccessForm()
        {
            InitializeComponent();
        }

        private void HideWhenSettingsOpen_Tick(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                IgnoreRightClick = true;
            }
        }

        private bool Initialized = false;

        private void QuickAccessForm_Load(object sender, EventArgs e)
        {
            if (Initialized) return;
            Initialized = true;
            volumeBar.Value = Settings.Default.alertVolume;
            volumeBar.Scroll += (a, b) =>
            {
                Settings.Default.alertVolume = ((TrackBar)a).Value;
                AudioManager.PlayFromUnmanagedSource(Resources.ui_beep_1, true);
            };
        }

        protected override void WndProc(ref Message message)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MOVE = 0xF010;

            switch (message.Msg)
            {
                case WM_SYSCOMMAND:
                    int command = message.WParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                        return;
                    break;
            }

            base.WndProc(ref message);
        }

        private void QuickAccessForm_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //IgnoreRightClick = true;
            }
            else
            {
                IgnoreRightClick = false;
            }
        }

        private void QuickAccessForm_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
