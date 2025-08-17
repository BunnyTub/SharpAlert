using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SharpAlert.ProgramWorker;

namespace SharpAlert.DisplayDialogs
{
    public partial class StartupForm : Form
    {
        const byte AC_SRC_ALPHA = 1;
        const int ULW_ALPHA = 2;
        const int WM_NCHIT = 0x84;
        const int HTCAPTION = 2;
        const int WS_EX_LAYERED = 0x00080000;

        [StructLayout(LayoutKind.Sequential)]
#pragma warning disable IDE1006 // Naming Styles
        private struct _Size
#pragma warning restore IDE1006 // Naming Styles
        {
            internal int cx;
            internal int cy;
        }

        [StructLayout(LayoutKind.Sequential)]
#pragma warning disable IDE1006 // Naming Styles
        private struct _Point
#pragma warning restore IDE1006 // Naming Styles
        {
            internal int x;
            internal int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct BLENDFUNCTION
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;

            public BLENDFUNCTION(byte op, byte flags, byte alpha, byte format)
            {
                BlendOp = op;
                BlendFlags = flags;
                SourceConstantAlpha = alpha;
                AlphaFormat = format;
            }
        }

        [DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
        static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst,
           ref _Point pptDst, ref _Size psize, IntPtr hdcSrc, ref _Point pptSrc, uint crKey,
           [In] ref BLENDFUNCTION pblend, uint dwFlags);

        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        static extern IntPtr CreateCompatibleDC([In] IntPtr hdc);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("gdi32.dll", EntryPoint = "SelectObject")]
        public static extern IntPtr SelectObject([In] IntPtr hdc, [In] IntPtr hgdiobj);

        [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DeleteObject([In] IntPtr hObject);

        [DllImport("gdi32.dll", EntryPoint = "DeleteDC")]
        public static extern bool DeleteDC([In] IntPtr hdc);

        [DllImport("user32.dll")]
        private static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        private readonly Bitmap bitsOfMap = null;

        public StartupForm(Bitmap bitmap)
        {
            InitializeComponent();
            bitsOfMap = bitmap;
            //this.BackColor = Color.Red;
        }

        private void StartupForm_Load(object sender, EventArgs e)
        {
        }

        private byte newOpacity;

        private void SetAlphaBitmap(byte opacity = 255)
        {
            newOpacity = opacity;
            IntPtr ScreenDC = GetDC(IntPtr.Zero);
            IntPtr mDC = CreateCompatibleDC(ScreenDC);
            IntPtr hBmp = IntPtr.Zero, hOldBmp = IntPtr.Zero;
            try
            {
                hBmp = bitsOfMap.GetHbitmap(Color.FromArgb(0));
                hOldBmp = SelectObject(mDC, hBmp);
                _Size s = new _Size() { cx = bitsOfMap.Width, cy = bitsOfMap.Height };
                _Point srcLocation = new _Point() { x = 0, y = 0 };
                _Point newLoc = new _Point() { x = Left, y = Top };
                BLENDFUNCTION blend = new BLENDFUNCTION
                {
                    BlendOp = 0,
                    BlendFlags = 0,
                    SourceConstantAlpha = opacity,
                    AlphaFormat = AC_SRC_ALPHA
                };
                UpdateLayeredWindow(Handle, ScreenDC, ref newLoc, ref s, mDC, ref srcLocation, 0, ref blend, ULW_ALPHA);
            }
            finally
            {
                if (hBmp != IntPtr.Zero)
                {
                    SelectObject(mDC, hOldBmp);
                    DeleteObject(hBmp);
                }
                if (mDC != IntPtr.Zero)
                {
                    DeleteDC(mDC);
                }
                if (ScreenDC != IntPtr.Zero)
                {
                    ReleaseDC(IntPtr.Zero, ScreenDC);
                }
            }

        }

        protected override CreateParams CreateParams
        {
            get
            {
                var resultparams = base.CreateParams;
                resultparams.ExStyle |= WS_EX_LAYERED;
                return resultparams;
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_NCHIT)
            {
                m.Result = (IntPtr)HTCAPTION;
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        private void AutoClose_Tick(object sender, EventArgs e)
        {
            if (TuyeWorker.ServiceRunnerScheduled)
            {
                // introduce fade-in and fade-out animation if I ever figure out how to use the Windows API
                this.Close();
            }
        }

        private bool AllowClose = false;

        private void StartupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = !AllowClose;
            if (!AllowClose) FadeOutAnimation.Enabled = true;
        }

        private void IconBox_Click(object sender, EventArgs e)
        {
            TuyeWorker.UnsafeFault(new Exception("User initiated failure manually."), true);
        }

        private void StartupForm_Shown(object sender, EventArgs e)
        {
            this.Size = bitsOfMap.Size;
            this.CenterToScreen();
            this.BackColor = Color.Red;
            SetAlphaBitmap(0);
            FadeInAnimation.Enabled = true;
        }

        private readonly object FadeObject = new object();

        private void FadeInAnimation_Tick(object sender, EventArgs e)
        {
            lock (FadeObject)
            {
                if (newOpacity >= 255)
                {
                    FadeInAnimation.Enabled = false;
                    AutoClose.Enabled = true;
                    return;
                }
                newOpacity += 5;
                SetAlphaBitmap(newOpacity);
            }
        }

        private void FadeOutAnimation_Tick(object sender, EventArgs e)
        {
            lock (FadeObject)
            {
                if (newOpacity == 0)
                {
                    FadeInAnimation.Stop();
                    AllowClose = true;
                    this.Close();
                    return;
                }
                newOpacity -= 5;
                SetAlphaBitmap(newOpacity);
            }
        }
    }
}

