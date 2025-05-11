using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SharpAlert.IceBearWorker;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.RegexList;

namespace SharpAlert
{
    public class FeedCapture
    {
        public List<string> servers = new List<string>();
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

            for (int i = 0; i < 5; i++)
            {
                if (!Stop) return;
                Thread.Sleep(1000);
            }

            //while (Stop)
            //{
            //    Thread.Sleep(500);
            //}
        }

        public static string Result { get; private set; } = string.Empty;
        public static int Calls { get; private set; } = 0;

        /// <summary>
        /// Starts the Feed Capture service in the current thread as a client.
        /// </summary>
        /// <param name="useHTTPS">Use the secure version of Hypertext Transfer Protocol to connect to the target server.</param>
        public void ServiceRun(bool useHTTPS)
        {
            if (Stop) return;

            bool LastConnectionSuccessful = true;
            bool AllConnectionsSuccessful = true;

            while (true)
            {
                try
                {
                    string URLPrefix = useHTTPS ? "https" : "http";
                    lock (servers)
                    {
                        int count = servers.Count;
                        foreach (string server in servers)
                        {
                            try
                            {
                                count--;
                                Console.WriteLine($"[Feed Capture | IPAWS] Getting data from URL: {URLPrefix}://{server}");
                                HttpResponseMessage message = client.GetAsync($"{URLPrefix}://{server}").Result;
                                message.EnsureSuccessStatusCode();

                                if (Calls >= 100000) Calls = 0;
                                Calls++;

                                Result = message.Content.ReadAsStringAsync().Result;

                                EnrollAlerts(Result);
                            }
                            catch (Exception ex)
                            {
                                count++;
                                AllConnectionsSuccessful = false;
                                Console.WriteLine($"[Feed Capture | IPAWS] {ex.Message}");
                            }
                        }

                        if (count == servers.Count)
                        {
                            LastConnectionSuccessful = false;
                        }
                    }

                    if (AllConnectionsSuccessful) Console.WriteLine($"[Feed Capture | IPAWS] Fetched from all feeds successfully.");
                    else Console.WriteLine("[Feed Capture | IPAWS] Not all feeds were fetched from successfully.");

                    //if (LastConnectionSuccessful)
                    //{
                    //    lock (notify)
                    //    {
                    //        notify.BalloonTipTitle = "SharpAlert has reconnected";
                    //        notify.BalloonTipText = "Successfully reconnected to the server after an ongoing connection disruption or problem.";
                    //        notify.BalloonTipIcon = ToolTipIcon.Info;
                    //        notify.ShowBalloonTip(5000);
                    //    }
                    //    LastConnectionSuccessful = true;
                    //}
                }
                catch (TimeoutException)
                {
                    Console.WriteLine($"[Feed Capture | IPAWS] Timed out.");
                    if (LastConnectionSuccessful)
                    {
                        lock (notify)
                        {
                            notify.BalloonTipTitle = "SharpAlert is having issues";
                            notify.BalloonTipText = "Couldn't connect to the server within a reasonable time. Check your internet connection!";
                            notify.BalloonTipIcon = ToolTipIcon.Warning;
                            notify.ShowBalloonTip(5000);
                        }
                    }
                    Thread.Sleep(30000);
                    LastConnectionSuccessful = false;
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[Feed Capture | IPAWS] {e.Message}");
                    if (e.InnerException != null) Console.WriteLine($"[Feed Capture | IPAWS] {e.InnerException.Message}");
                    if (LastConnectionSuccessful)
                    {
                        lock (notify)
                        {
                            notify.BalloonTipTitle = "SharpAlert is having issues";
                            notify.BalloonTipText = "There was an issue when trying to connect to the server. Check your internet connection!";
                            notify.BalloonTipIcon = ToolTipIcon.Warning;
                            notify.ShowBalloonTip(5000);
                        }
                    }
                    //LastConnectionSuccessful = false;
                    Thread.Sleep(30000);
                }
                if (FirstRun) FirstRun = false;

                try
                {
                    int CheckInterval = Settings.Default.AlertCheckInterval;
                    for (int i = 0; !(i >= CheckInterval);)
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
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[Feed Capture | IPAWS] {e.StackTrace} {e.Message}");
                }
            }
        }

        private readonly object EnrollObject = new object();

        public void EnrollAlerts(string data)
        {
            lock (EnrollObject)
            {
                MatchCollection alertMatches = AlertRegex.Matches(data);
                int alertIndex = 0;

                if (alertMatches != null || alertMatches.Count != 0)
                {
                    foreach (Match alert in alertMatches)
                    {
                        try
                        {
                            alertIndex++;
                            if (alert.Value is null) continue;

                            string filename = IdentifierRegex.MatchOrDefault(alert.Value, CreateMD5(alert.Value));

                            //if (string.IsNullOrWhiteSpace(filename))
                            //{
                            //    Console.WriteLine("[Feed Capture | IPAWS] Identifier not found. An MD5 value will be assigned to this alert instead.");
                            //    filename = CreateMD5(alert.Value);
                            //}

                            Console.WriteLine($"[Feed Capture | IPAWS] {alertIndex} -> {filename}");
                            string alertReplayValue = alert.Value + "<SharpAlertReplay>false</SharpAlertReplay>";
                            SharpDataItem item = new SharpDataItem(filename, alert.Value);

                            if (FirstRun && Settings.Default.discardFirstAlerts)
                            {
                                if (TryAddDataToHistory(item))
                                {
                                    Console.WriteLine($"[Feed Capture | IPAWS] Alert {alertIndex} ({filename}) has been discarded (discard any alert on start).");
                                }
                            }
                            else
                            {
                                if (TryAddDataToQueue(item))
                                {
                                    Console.WriteLine($"[Feed Capture | IPAWS] Alert {alertIndex} ({filename}) has been saved for processing.");
                                }
                                else
                                {
                                    Console.WriteLine($"[Feed Capture | IPAWS] Alert {alertIndex} ({filename}) has been discarded (already queued or is in history).");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Feed Capture | IPAWS] Couldn't check the data for alert {alertIndex}. {ex.Message}");
                        }
                    }
                    if (alertIndex != 0) Console.WriteLine($"[Feed Capture | IPAWS] {alertIndex} alert(s) checked.");
                    else Console.WriteLine($"[Feed Capture | IPAWS] No alerts were checked.");
                }
                else
                {
                    Console.WriteLine("[Feed Capture | IPAWS] There are no alerts to enroll.");
                }
            }
        }

        /// <summary>
        /// Starts the Feed Capture service in the current thread as a server instead of a client.
        /// </summary>
        /// <param name="useHTTPS">Use the secure version of Hypertext Transfer Protocol to connect to the target server.</param>
        //public void ServerServiceRun(bool useHTTPS)
        //{
        //    if (Stop) return;

        //    string URLPrefix = useHTTPS ? "https" : "http";
        //    while (true)
        //    {
        //        try
        //        {
        //            Console.WriteLine($"[Feed Capture | IPAWS] Getting data from the server.");
        //            Task<HttpResponseMessage> message = client.GetAsync($"{URLPrefix}://{server}");
        //            if (!message.Wait(10000)) continue;
        //            message.Result.EnsureSuccessStatusCode();

        //            if (Calls > 100000) Calls = 0;
        //            Calls++;

        //            Result = message.Result.Content.ReadAsStringAsync().Result;

        //            Console.WriteLine($"[Feed Capture | IPAWS] Grabbed data from the server.");

        //            for (int i = 0; !(i >= 30);)
        //            {
        //                if (Stop)
        //                {
        //                    Stop = false;
        //                    return;
        //                }
        //                Thread.Sleep(1000);
        //                i++;
        //            }
        //        }
        //        catch (SocketException e)
        //        {
        //            Console.WriteLine($"[Feed Capture | IPAWS] {e.Message}");
        //            Thread.Sleep(1000);
        //        }
        //        catch (TimeoutException)
        //        {
        //            Console.WriteLine($"[Feed Capture | IPAWS] Timed out.");
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            Console.WriteLine($"[Feed Capture | IPAWS] {e.StackTrace} {e.Message} {e.Message}");
        //        }
        //        catch (AggregateException e)
        //        {
        //            Console.WriteLine($"[Feed Capture | IPAWS] {e.StackTrace} {e.Message}");
        //        }
        //        catch (TaskCanceledException)
        //        {
        //            Console.WriteLine("[Feed Capture | IPAWS] The executing task was canceled.");
        //        }
        //        catch (ThreadAbortException)
        //        {
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine($"[Feed Capture | IPAWS] {e.StackTrace} {e.Message}");
        //        }
        //    }
        //}

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
                        Console.WriteLine($"[Feed Capture | IPAWS] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[Feed Capture | IPAWS] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
