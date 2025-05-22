using System;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SharpAlert.Properties;

namespace SharpAlert.AlertComponents
{
    public partial class ManualAlertRelayForm : Form
    {
        private string AlertIDStr = string.Empty;
        private string AlertSubtitleStr = string.Empty;
        private string AlertIntroTextStr = string.Empty;
        private string AlertTextStr = string.Empty;
        private string AlertUrlStr = string.Empty;
        private string AlertAudioUrlStr = string.Empty;
        private string AlertImageUrlStr = string.Empty;
        private string AlertType = string.Empty;

        public ManualAlertRelayForm()
        {
            InitializeComponent();
        }

        public void UpdateFields(string id, string alert, string intro, string text, string url, string audio, string image, string type)
        {
            AlertIDStr = id;
            this.Text = $"SharpAlert - {AlertIDStr}";
            AlertSubtitleStr = alert;
            SubtitleText.Text = AlertSubtitleStr;
            AlertIntroTextStr = intro;
            AlertTextStr = text;
            AlertText.Text = $"{AlertIntroTextStr}\r\n\r\n{AlertTextStr}";
            AlertUrlStr = url;
            AlertAudioUrlStr = audio;
            AlertImageUrlStr = image;
            AlertType = type;
            AlertText.SelectionLength = 0;
            AlertText.SelectionStart = 0;

            //if (string.IsNullOrWhiteSpace(AlertUrlStr))
            //{
            //    AlertLinkText.Enabled = false;
            //    AlertLinkText.Text = string.Empty;
            //}
            //else
            //{
            //    AlertLinkText.Enabled = true;
            //    AlertLinkText.Text = AlertUrlStr;
            //}

            //if (!string.IsNullOrWhiteSpace(AlertImageUrlStr))
            //{

            //}

            //switch (type)
            //{
            //    case "alert":
            //        TitleText.BackColor = Color.Red;
            //        OutlineContainerPanel.BorderColor = Color.Red;
            //        SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
            //        TitleText.Text = "EMERGENCY ALERT";
            //        break;
            //    case "update":
            //        TitleText.BackColor = Color.Red;
            //        OutlineContainerPanel.BorderColor = Color.Red;
            //        SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
            //        TitleText.Text = "ALERT UPDATE";
            //        break;
            //    case "cancel":
            //        TitleText.BackColor = Color.FromArgb(0, 80, 200);
            //        OutlineContainerPanel.BorderColor = Color.FromArgb(0, 80, 200);
            //        SubtitlePanel.BackColor = Color.FromArgb(0, 50, 100);
            //        TitleText.Text = "ALERT CANCELLED";
            //        break;
            //    case "test":
            //        TitleText.BackColor = Color.Red;
            //        OutlineContainerPanel.BorderColor = Color.Red;
            //        SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
            //        TitleText.Text = "ALERT TEST";
            //        break;
            //    default:
            //        TitleText.BackColor = Color.Red;
            //        OutlineContainerPanel.BorderColor = Color.Red;
            //        SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
            //        TitleText.Text = "EMERGENCY ALERT";
            //        break;
            //}
        }

        private void ManualAlertRelay_Load(object sender, EventArgs e)
        {
        }

        private int TimeRemainingMax = 8;
        private int _TimeRemaining = 0;

        private readonly object AutoLock = new object();

        private void AutoRelayTimer_Tick(object sender, EventArgs e)
        {
            lock (AutoLock)
            {
                if (_TimeRemaining >= TimeRemainingMax)
                {
                    AutoRelayTimer.Enabled = false;
                    _TimeRemaining = TimeRemainingMax;
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                    return;
                }
                _TimeRemaining++;
                if (_TimeRemaining > TimeRemainingMax)
                {
                    _TimeRemaining = AutomaticRelayProgressBar.Maximum;
                    return;
                }
                AutomaticRelayProgressBar.Maximum = TimeRemainingMax;
                AutomaticRelayProgressBar.Value = _TimeRemaining;
            }
        }

        private void ManualAlertRelay_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible) AutoRelayTimer.Enabled = true;
        }

        private void AllowButton_Click(object sender, EventArgs e)
        {
            _TimeRemaining = TimeRemainingMax;
            AllowButton.Enabled = false;
            DenyButton.Enabled = false;
        }

        private const int HWND_TOPMOST = -1;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_SHOWWINDOW = 0x0040;

        private IntPtr GotHandle = IntPtr.Zero;

        private int EnsureForTick = 5;

        private void EnsureTopWindow_Tick(object sender, EventArgs e)
        {
            SetWindowPos(GotHandle, (IntPtr)HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_SHOWWINDOW);
            SetForegroundWindow(GotHandle);
            EnsureForTick--;

            if (EnsureForTick == 0)
            {
                EnsureTopWindow.Stop();
                return;
            }
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private void ManualAlertRelay_Shown(object sender, EventArgs e)
        {
            GotHandle = this.Handle;
            SystemSounds.Asterisk.Play();
        }

        private void DenyButton_Click(object sender, EventArgs e)
        {
            AllowButton.Enabled = false;
            DenyButton.Enabled = false;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            lock (AutoLock)
            {
                AutoRelayTimer.Enabled = false;
                TimeRemainingMax = 60;
                _TimeRemaining = 0;
                AutomaticRelayProgressBar.Maximum = TimeRemainingMax;
                AutomaticRelayProgressBar.Value = 0;
                AutoRelayTimer.Enabled = true;
            }
        }
    }
}
