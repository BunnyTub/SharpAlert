using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SharpAlert.AlertComponents
{
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
    }
}
