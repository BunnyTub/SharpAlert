using SharpAlert.Properties;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SharpAlert.IceBearWorker;
using static SharpAlert.Program;
using static SharpAlert.RegexList;

namespace SharpAlert
{
    public class FeedCapture
    {
        public string server = string.Empty;
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

        public static string Result { get; private set; } = string.Empty;
        public static int Calls { get; private set; } = 0;


        //apps.fema.gov/IPAWSOPEN_EAS_SERVICE/rest/PublicWEA/recent/{DateTime.UtcNow.AddMonths(-1):yyyy-MM-ddTHH:mm:ssZ}
        /// <summary>
        /// Starts the Feed Capture service in the current thread as a client.
        /// </summary>
        /// <param name="useHTTPS">Use the secure version of Hypertext Transfer Protocol to connect to the target server.</param>
        public void ServiceRun(bool useHTTPS)
        {
            if (Stop) return;

            string URLPrefix = useHTTPS ? "https" : "http";

            while (true)
            {
                try
                {
                    string filename;

                    Console.WriteLine($"[Feed Capture] Getting data from URL: {URLPrefix}://{server}");
                    Task<HttpResponseMessage> message = client.GetAsync($"{URLPrefix}://{server}");
                    if (!message.Wait(10000)) continue;
                    message.Result.EnsureSuccessStatusCode();
                    
                    if (Calls >= 100000) Calls = 0;
                    Calls++;

                    Result = message.Result.Content.ReadAsStringAsync().Result;

                    Console.WriteLine($"[Feed Capture] Grabbed data.");

                    MatchCollection alertMatches = AlertRegex.Matches(Result);
                    int alertIndex = 0;

                    if (alertMatches != null || alertMatches.Count != 0)
                    {
                        foreach (Match alert in alertMatches)
                        {
                            alertIndex++;
                            if (alert.Value is null) continue;

                            string alertValue = alert.Value + "<SharpAlertReplay>false</SharpAlertReplay>";
                            filename = CreateMD5(alert.Value);

                            Console.WriteLine($"[Feed Capture] {alertIndex} -> {filename}");

                            SharpDataItem item = new SharpDataItem(filename, alert.Value);

                            if (FirstRun && Settings.Default.discardFirstAlerts)
                            {
                                if (TryAddDataToHistory(item))
                                {
                                    Console.WriteLine($"[Feed Capture] Alert {alertIndex} has been discarded (first run).");
                                }
                            }
                            else
                            {
                                if (TryAddDataToQueue(item))
                                {
                                    Console.WriteLine($"[Feed Capture] Alert {alertIndex} has been saved for processing.");
                                }
                                else
                                {
                                    Console.WriteLine($"[Feed Capture] Alert {alertIndex} has been discarded (already queued or is in history).");
                                }
                            }
                        }
                        if (alertIndex != 0) Console.WriteLine($"[Feed Capture] {alertIndex} alert(s) checked.");
                        else Console.WriteLine($"[Feed Capture] No alerts to be checked.");
                    }
                    else
                    {
                        Console.WriteLine($"[Feed Capture] No alerts to be checked.");
                    }

                    // Do not show the user an alert for the first time opening the program
                    // Implement user entry for how long between each request/check
                }
                catch (SocketException e)
                {
                    Console.WriteLine($"[Feed Capture] {e.Message}");
                    Thread.Sleep(1000);
                }
                catch (TimeoutException)
                {
                    Console.WriteLine($"[Feed Capture] Timed out.");
                    lock (notify)
                    {
                        notify.BalloonTipTitle = "SharpAlert is having issues";
                        notify.BalloonTipText = "Couldn't connect to the server within a reasonable time. Check your internet connection!";
                        notify.BalloonTipIcon = ToolTipIcon.Warning;
                        notify.ShowBalloonTip(5000);
                    }
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"[Feed Capture] {e.StackTrace} {e.Message} {e.InnerException.Message}");
                    lock (notify)
                    {
                        notify.BalloonTipTitle = "SharpAlert is having issues";
                        notify.BalloonTipText = "There was an issue when trying to connect to the server. Check your internet connection!";
                        notify.BalloonTipIcon = ToolTipIcon.Warning;
                        notify.ShowBalloonTip(5000);
                    }
                }
                catch (AggregateException e)
                {
                    Console.WriteLine($"[Feed Capture] {e.StackTrace} {e.InnerExceptions.FirstOrDefault().Message}");
                    lock (notify)
                    {
                        notify.BalloonTipTitle = "SharpAlert is having issues";
                        notify.BalloonTipText = "There was an issue when trying to connect to the server. Check your internet connection!";
                        notify.BalloonTipIcon = ToolTipIcon.Warning;
                        notify.ShowBalloonTip(5000);
                    }
                }
                catch (TaskCanceledException)
                {
                    Console.WriteLine("[Feed Capture] The executing task was canceled.");
                }
                catch (ThreadAbortException)
                {
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine($"[Feed Capture] {e.StackTrace} {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[Feed Capture] {e.StackTrace} {e.Message}");
                }
                if (FirstRun) FirstRun = false;

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
        }

        /// <summary>
        /// Starts the Feed Capture service in the current thread as a server instead of a client.
        /// </summary>
        /// <param name="useHTTPS">Use the secure version of Hypertext Transfer Protocol to connect to the target server.</param>
        public void ServerServiceRun(bool useHTTPS)
        {
            if (Stop) return;

            string URLPrefix = useHTTPS ? "https" : "http";
            while (true)
            {
                try
                {
                    Console.WriteLine($"[Feed Capture] Getting data from the server.");
                    Task<HttpResponseMessage> message = client.GetAsync($"{URLPrefix}://{server}");
                    if (!message.Wait(10000)) continue;
                    message.Result.EnsureSuccessStatusCode();
                    
                    if (Calls > 100000) Calls = 0;
                    Calls++;

                    Result = message.Result.Content.ReadAsStringAsync().Result;

                    Console.WriteLine($"[Feed Capture] Grabbed data from the server.");

                    for (int i = 0; !(i >= 30);)
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
                }
                catch (TimeoutException)
                {
                    Console.WriteLine($"[Feed Capture] Timed out.");
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"[Feed Capture] {e.StackTrace} {e.Message} {e.InnerException.Message}");
                }
                catch (AggregateException e)
                {
                    Console.WriteLine($"[Feed Capture] {e.StackTrace} {e.InnerExceptions.FirstOrDefault().Message}");
                }
                catch (TaskCanceledException)
                {
                    Console.WriteLine("[Feed Capture] The executing task was canceled.");
                }
                catch (ThreadAbortException)
                {
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[Feed Capture] {e.StackTrace} {e.Message}");
                }
            }
        }

        public static bool TryAddDataToQueue(SharpDataItem item)
        {
            lock (SharpDataQueue)
            {
                lock (SharpDataHistory)
                {
                    try
                    {
                        if (SharpDataQueue.Any(x => x.Name == item.Name) || SharpDataHistory.Any(x => x.Name == item.Name))
                        {
                            return false;
                        }
                        else
                        {
                            SharpDataQueue.Add(item);
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"[Feed Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }

        public static bool TryAddDataToHistory(SharpDataItem item)
        {
            lock (SharpDataQueue)
            {
                lock (SharpDataHistory)
                {
                    try
                    {
                        if (SharpDataQueue.Any(x => x.Name == item.Name) || SharpDataHistory.Any(x => x.Name == item.Name))
                        {
                            return false;
                        }
                        else
                        {
                            SharpDataHistory.Add(item);
                            return true;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"[Feed Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
