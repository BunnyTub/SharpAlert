using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpAlert.ProgramWorker
{
    public static class UpdateWorker
    {
        private static HttpClient UpdateClient_ = null;
        private static HttpClient UpdateClient
        {
            get
            {
                if (UpdateClient_ == null)
                {
                    UpdateClient_ = new HttpClient
                    {
                        Timeout = TimeSpan.FromMinutes(5)
                    };

                    UpdateClient_.DefaultRequestHeaders.UserAgent.ParseAdd(HaidaWorker.SelfUserAgent);
                }

                return UpdateClient_;
            }
        }

        /// <summary>
        /// Tries to update the program.
        /// </summary>
        /// <param name="UpdateToVersion">The version to update to excluding the "v", but including the "." between the major and minor version.</param>
        public static void TryUpdate(string UpdateToVersion)
        {
            Console.WriteLine("[Update Worker] For future use.");
            return;

            if (MessageBox.Show($"Do you want to update to v{UpdateToVersion}? This action will occur in the background, and the program will restart automatically to finish up.", "SharpAlert - Update Worker",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            Console.WriteLine("[Update Worker] Performing an application update.");

            try
            {
                Task<byte[]> result = UpdateClient.GetByteArrayAsync(HaidaWorker.IdentityURL + $"/Releases/v{UpdateToVersion}/SharpAlert.exe");
                Console.WriteLine($"[Update Worker] SharpAlert v{UpdateToVersion} executable is downloading.");
                result.Wait();
                if (File.Exists(MainEntryPoint.AssemblyFile + "_")) File.Delete(MainEntryPoint.AssemblyFile + "_");
                Console.WriteLine($"[Update Worker] Attempted to delete unused old executable.");
                File.Move(MainEntryPoint.AssemblyFile, MainEntryPoint.AssemblyFile + "_");
                Console.WriteLine($"[Update Worker] Renamed current (old) executable.");
                File.WriteAllBytes(MainEntryPoint.AssemblyFile, result.Result);
                Console.WriteLine($"[Update Worker] Wrote downloaded (new) executable.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Update failed!\r\nEnsure your internet is working before trying again.\r\n\r\n" +
                    $"{ex.GetBaseException().Message}", "SharpAlert - Update Worker",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            new Thread(() => {
                MessageBox.Show($"Update completed, restarting automatically in 5 seconds.", "SharpAlert - Update Worker",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }).Start();

            Thread.Sleep(5000);

            Process.Start(MainEntryPoint.AssemblyFile, "--internal-remove-old");
            Environment.Exit(0);
        }
    }
}
