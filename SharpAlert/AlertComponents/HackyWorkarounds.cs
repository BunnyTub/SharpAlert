using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SharpAlert.AlertComponents
{
    // Linux support when??

    /// <summary>
    /// Gotta love .NET migration.
    /// </summary>
    public static class HackyWorkarounds
    {
        /// <summary>
        /// https://github.com/dotnet/runtime/issues/17938
        /// </summary>
        /// <param name="URL">The URL to open in the system's default web browser.</param>
        public static void OpenURL(string URL)
        {
            try
            {
                Process.Start(new ProcessStartInfo { FileName = URL, UseShellExecute = true });
            }
            catch (Exception)
            {
                try
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        URL = URL.Replace("&", "^&");
                        Process.Start(new ProcessStartInfo("cmd", $"/c start {URL}") { CreateNoWindow = true });
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                    {
                        Process.Start("xdg-open", URL);
                    }
                    else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        Process.Start("open", URL);
                    }
                    else
                    {
                        MessageBox.Show("Unable to open the browser.\r\n" +
                            "Your system may not support the methods used.\r\n" +
                            "Here's the URL:\r\n" +
                            $"{URL}");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Unable to open the web browser.\r\n" +
                        "Here's the URL:\r\n" +
                        $"{URL}");
                }
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {
            public uint cbSize;
            public IntPtr hwnd;
            public uint dwFlags;
            public uint uCount;
            public uint dwTimeout;
        }

        //private const uint FLASHW_STOP = 0;
        private const uint FLASHW_CAPTION = 1;
        private const uint FLASHW_TRAY = 2;
        private const uint FLASHW_ALL = FLASHW_CAPTION | FLASHW_TRAY;
        //private const uint FLASHW_TIMER = 4;
        //private const uint FLASHW_TIMERNOFG = 12;

        [DllImport("user32.dll")]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        public static void FlashWindow(Form form, uint count = 5)
        {
            var fInfo = new FLASHWINFO
            {
                cbSize = (uint)Marshal.SizeOf(typeof(FLASHWINFO)),
                hwnd = form.Handle,
                dwFlags = FLASHW_ALL,
                uCount = count,
                dwTimeout = 0
            };
            FlashWindowEx(ref fInfo);
        }

        //public static void Stop(Form form)
        //{
        //    var fInfo = new FLASHWINFO
        //    {
        //        cbSize = (uint)Marshal.SizeOf(typeof(FLASHWINFO)),
        //        hwnd = form.Handle,
        //        dwFlags = FLASHW_STOP,
        //        uCount = 0,
        //        dwTimeout = 0
        //    };
        //    FlashWindowEx(ref fInfo);
        //}
    }
}
