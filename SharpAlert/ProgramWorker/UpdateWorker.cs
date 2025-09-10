using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpAlert.AlertComponents;
using static SharpAlert.ProgramWorker.MainEntryPoint;

namespace SharpAlert.ProgramWorker
{
    public static class UpdateWorker
    {
        public static readonly string IdentityURL = "https://bunnytub.com/SharpAlert";

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
        /// Tries to get the latest version of the program. If there is an issue, this method will return the current version.
        /// </summary>
        public static string TryGetRemoteVersion()
        {
            string RemoteVersion = $"{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}";
            Console.WriteLine("[Update Worker] Checking application version.");

            try
            {
                HttpResponseMessage latest = UpdateClient.GetAsync($"{IdentityURL}/SharpAlert.txt").Result;

                Console.WriteLine($"[Update Worker] The server responded with status code {latest.StatusCode}.");

                RemoteVersion = latest.Content.ReadAsStringAsync().Result.Trim();
                if (string.IsNullOrWhiteSpace(RemoteVersion) || RemoteVersion.Length == 0 || RemoteVersion.Length >= 10) RemoteVersion = "0.0";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Update Worker] {ex.StackTrace} {ex.Message}");
                Console.WriteLine($"[Update Worker] Couldn't work with the server.");
            }

            return RemoteVersion;
        }

        private static readonly object TryUpdateObject = new object();
        public static DateTime TimeUntilUpdate = DateTime.MaxValue;

        /// <summary>
        /// Tries to update the program.
        /// </summary>
        /// <param name="UpdateToVersion">The version to update to excluding the "v", but including the "." between the major and minor version.</param>
        public static bool TryUpdate(string UpdateToVersion, bool UpdateImmediately)
        {
            // I don't want to add this yet
            return true;

            lock (TryUpdateObject)
            {
                if (!UpdateImmediately)
                {
                    if (VersionInfo.IsBetaVersion)
                    {
                        Console.WriteLine("[Update Worker] Updates will not occur in a beta version.");
                        return false;
                    }
                    else
                    {
                        if (Debugger.IsAttached)
                        {
                            Console.WriteLine("[Update Worker] Updates will not occur while debugging.");
                            return false;
                        }
                        else
                        {
                            if (!QuickSettings.Instance.AllowPerformingUpdates)
                            {
                                Console.WriteLine("[Update Worker] Updates are disabled.");
                                return false;
                            }
                        }
                    }
                }

                Console.WriteLine("[Update Worker] Performing an application update.");

                if ($"{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}" == UpdateToVersion)
                {
                    Console.WriteLine("[Update Worker] Currently up to date.");
                    return true;
                }
                else
                {
                    SpeakingManager.UpdatesFound();

                    DialogResult result = DialogResult.None;

                    TimeUntilUpdate = DateTime.UtcNow.AddMinutes(5);

                    if (!UpdateImmediately)
                    {
                        PerformUpdateForm puf = new PerformUpdateForm();
                        puf.ShowDialog();
                        result = puf.DialogResult;
                    }
                    else
                    {
                        result = DialogResult.Yes;
                    }

                    // save settings before continuing
                    QuickSettings.Instance.Save();

                    if (result == DialogResult.Yes)
                    {
                        Thread thread = new Thread(() =>
                        {
                            try
                            {
                                while (true) new UpdateForm().ShowDialog();
                            }
                            catch (Exception)
                            {
                            }
                        });

                        // I used to work at Blizzard for 10 years moment

                        thread.Start();

                        Console.WriteLine("[Update Worker] DO NOT CLOSE THE PROGRAM DURING THE UPDATE.");

                        try
                        {
                            if (!IsAdministrator)
                            {
                                Process proc = new Process();
                                proc.StartInfo.FileName = AssemblyFile;
                                proc.StartInfo.Arguments = "--update --wait-until-parent-closes";
                                //proc.StartInfo.UseShellExecute = true;
                                proc.StartInfo.Verb = "runas";
                                proc.Start();

                                Environment.Exit(0);
                            }
                            else
                            {
                                Process[] processes = Process.GetProcessesByName($"{Path.GetFileNameWithoutExtension(AssemblyFile)}");

                                bool CanContinue = true;

                                if (processes.Count() > 2)
                                {
                                    if (Args.Contains("--monitored"))
                                    {
                                        CanContinue = true;
                                    }
                                    else
                                    {
                                        CanContinue = false;
                                    }
                                }

                                if (!CanContinue)
                                {
                                    throw new Exception("There are multiple SharpAlert instances running. Close them before trying to update again.");
                                }

                                DiscordWebhook.SendFormattedMessage("Currently downloading the latest version of SharpAlert.");

                                Task<HttpResponseMessage> resultOutput = UpdateClient.GetAsync($"{IdentityURL}/Releases/v{UpdateToVersion}/SharpAlert.exe");
                                Console.WriteLine($"[Update Worker] SharpAlert v{UpdateToVersion} executable is downloading.");
                                resultOutput.Wait();
                                resultOutput.Result.EnsureSuccessStatusCode();

                                Task<byte[]> output = resultOutput.Result.Content.ReadAsByteArrayAsync();
                                output.Wait();

                                bool IsValidExecutable(byte[] fileBytes)
                                {
                                    // File length check
                                    if (fileBytes.Length < 512)
                                    {
                                        return false;
                                    }

                                    // DOS header check
                                    if (fileBytes[0] != 'M' || fileBytes[1] != 'Z')
                                    {
                                        return false;
                                    }

                                    // PE header check
                                    int peHeaderOffset = BitConverter.ToInt32(fileBytes, 0x3C);
                                    if (peHeaderOffset <= 0 || peHeaderOffset > fileBytes.Length - 4)
                                    {
                                        return false;
                                    }

                                    // PE signature check
                                    if (!(fileBytes[peHeaderOffset] == 'P' &&
                                          fileBytes[peHeaderOffset + 1] == 'E' &&
                                          fileBytes[peHeaderOffset + 2] == 0 &&
                                          fileBytes[peHeaderOffset + 3] == 0))
                                    {
                                        return false;
                                    }

                                    // SharpAlert string check
                                    string exeContent = Encoding.ASCII.GetString(fileBytes);
                                    if (!exeContent.Contains("SharpAlert"))
                                    {
                                        return false;
                                    }

                                    return true;
                                }

                                if (!IsValidExecutable(output.Result))
                                {
                                    throw new Exception("The downloaded executable did not pass checks for validity.");
                                }

                                DiscordWebhook.SendFormattedMessage("Currently installing the latest version of SharpAlert.");

                                if (File.Exists(AssemblyFile + "_")) File.Delete(AssemblyFile + "_");
                                Console.WriteLine($"[Update Worker] Attempted to delete unused old executable.");
                                File.Move(AssemblyFile, AssemblyFile + "_");
                                Console.WriteLine($"[Update Worker] Renamed current (old) executable.");
                                File.WriteAllBytes(AssemblyFile, output.Result);
                                Console.WriteLine($"[Update Worker] Wrote downloaded (new) executable.");

                                DiscordWebhook.SendFormattedMessage("Restarting in a few moments to complete the update.");

                                //new Thread(() => {
                                //    MessageBox.Show($"Update completed, restarting automatically in 5 seconds.", "SharpAlert - Update Worker",
                                //        MessageBoxButtons.OK, MessageBoxIcon.Information);
                                //}).Start();

                                Thread.Sleep(5000);

                                Process.Start(AssemblyFile, "--internal-remove-old --wait-until-parent-closes");
                                Environment.Exit(0);
                            }
                            return true;
                        }
                        catch (Exception ex)
                        {
                            DiscordWebhook.SendFormattedMessage("Updating SharpAlert failed!");
                            MessageBox.Show($"Update failed!\r\n\r\n" +
                                $"{ex.GetBaseException().Message}", "SharpAlert - Update Worker",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                        finally
                        {
                            try
                            {
                                thread.Abort();
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }
                    else
                    {
                        while (AllowThreadRestarts)
                        {
                            TimeSpan Remaining = TimeUntilUpdate - DateTime.UtcNow;

                            if (Remaining.TotalSeconds <= 0)
                            {
                                return TryUpdate(UpdateToVersion, true);
                            }
                        }
                        return false;
                    }
                }
            }
        }
    }
}
