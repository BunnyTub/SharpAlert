using SharpAlert.Properties;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using static SharpAlert.Program;
using static SharpAlert.RegexList;

namespace SharpAlert
{
    public class FeedCapture
    {
        public string server = string.Empty;

        private readonly HttpClient client;

        public FeedCapture()
        {
            client = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
            client.DefaultRequestHeaders.UserAgent.ParseAdd($"Mozilla/5.0 (compatible; SharpAlert)");
        }

        private bool FirstRun = true;
        private bool Stop = false;
        private bool StopCalled = false;

        public void ServiceStop()
        {
            if (StopCalled)
            {
                throw new Exception("ServiceStop was already called. If you intended to run the service multiple times, please create a new object.");
            }
            StopCalled = true;
            Stop = true;
            while (Stop) Thread.Sleep(100);
        }

        //apps.fema.gov/IPAWSOPEN_EAS_SERVICE/rest/PublicWEA/recent/{DateTime.UtcNow.AddMonths(-1):yyyy-MM-ddTHH:mm:ssZ}
        /// <summary>
        /// Starts the Feed Capture service in the current thread.
        /// </summary>
        /// <param name="useHTTPS">Uses the secure version of Hypertext Transfer Protocol to connect to the target server.</param>
        public void ServiceRun(bool useHTTPS)
        {
            if (Stop) return;

            string URLPrefix = useHTTPS ? "https" : "http";
            while (true)
            {
                try
                {
                    string filename;
                    string result = client.GetStringAsync($"{URLPrefix}://{server}").Result;

                    Console.WriteLine($"[Feed Capture] Grabbed data from the server.");

                    MatchCollection alertMatches = AlertRegex.Matches(result);
                    int alertIndex = 0;

                    foreach (Match alert in alertMatches)
                    {
                        alertIndex++;

                        string alertValue = alert.Value + "<SharpAlertReplay>false</SharpAlertReplay>";
                        filename = CreateMD5(alert.Value);

                        Console.WriteLine($"[Feed Capture] {alertIndex} -> {filename}");

                        SharpDataItem item = new SharpDataItem(filename, alert.Value);

                        lock (SharpDataQueue)
                        {
                            lock (SharpDataHistory)
                            {
                                if (SharpDataQueue.Contains(item) || SharpDataHistory.Contains(item) || (FirstRun && Settings.Default.discardFirstAlerts))
                                {
                                    Console.WriteLine($"[Feed Capture] Alert {alertIndex} has been discarded (already queued or is in history).");
                                }
                                else
                                {
                                    SharpDataQueue.Add(new SharpDataItem(filename, alert.Value));
                                    Console.WriteLine($"[Feed Capture] Alert {alertIndex} has been saved for processing.");
                                }
                            }
                        }
                    }

                    Console.WriteLine($"[Feed Capture] {alertIndex} alert(s) checked.");

                    // Do not show the user an alert for the first time opening the program
                    // Implement user entry for how long between each request/check

                    for (int i = 0; !(i >= Settings.Default.AlertCheckInterval);)
                    {
                        if (Stop)
                        {
                            Stop = false;
                            return;
                        }
                        Thread.Sleep(1000);
                        i++;
                    }
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"[Feed Capture] {e.Message}");
                    Thread.Sleep(1000);
                    return;
                }
                catch (TimeoutException)
                {
                    Console.WriteLine($"[Feed Capture] Timed out.");
                    return;
                }
                catch (AggregateException e)
                {
                    Console.WriteLine($"[Feed Capture] {e.StackTrace} {e.InnerExceptions.FirstOrDefault().Message}");
                    return;
                }
                catch (TaskCanceledException)
                {
                    Console.WriteLine("[Feed Capture] The executing task was canceled.");
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception)
                {
                    Console.WriteLine("");
                    return;
                }
                if (FirstRun) FirstRun = false;
            }
        }
    }
}
