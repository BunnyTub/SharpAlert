using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using static SharpAlert.IceBearWorker;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.RegexList;

namespace SharpAlert
{
    public class FeedCapture
    {
        public class ServerInfo
        {
            public string ServerName { get; set; }
            public string ServerPath { get; set; }

            /// <summary>
            /// Arbitrary boolean. It should be set to true if the last usage of the class was successful.
            /// </summary>
            public bool LastRunSuccess { get; set; }
        }

        public List<ServerInfo> servers = new List<ServerInfo>();
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

        public static int Calls { get; private set; } = 0;

        /// <summary>
        /// Starts the HTTP Feed Capture service in the current thread as a client.
        /// </summary>
        /// <param name="useHTTPS">Use the secure version of Hypertext Transfer Protocol to connect to the target server.</param>
        public void ServiceRun(bool useHTTPS)
        {
            if (Stop) return;

            while (true)
            {
                try
                {
                    string URLPrefix = useHTTPS ? "https" : "http";
                    bool AllConnectionsSuccessful = true;

                    lock (servers)
                    {
                        if (servers.Any())
                        {
                            int count = servers.Count;
                            foreach (ServerInfo server in servers)
                            {
                                try
                                {
                                    count--;
                                    Console.WriteLine($"[HTTP Feed Capture] Getting data from {server.ServerName}. URL -> {server.ServerPath}");
                                    HttpResponseMessage message = client.GetAsync($"{URLPrefix}://{server.ServerPath}").Result;
                                    message.EnsureSuccessStatusCode();

                                    if (Calls >= 100000) Calls = 0;
                                    Calls++;

                                    string Result = message.Content.ReadAsStringAsync().Result;
                                    EnrollAlerts(Result);
                                }
                                catch (Exception ex)
                                {
                                    count++;
                                    Console.WriteLine($"[HTTP Feed Capture] {ex.Message}");
                                    AllConnectionsSuccessful = false;
                                    server.LastRunSuccess = false;
                                }
                            }

                            if (count >= servers.Count)
                            {
                                AllConnectionsSuccessful = true;
                            }

                            if (AllConnectionsSuccessful)
                            {
                                Console.WriteLine($"[HTTP Feed Capture] Fetched from all feeds successfully.");
                            }
                            else
                            {
                                Console.WriteLine("[HTTP Feed Capture] Not all feeds were fetched from successfully.");
                            }
                        }
                    }

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
                    Console.WriteLine($"[HTTP Feed Capture] Timed out.");
                    Thread.Sleep(15 * 1000);
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[HTTP HTTP Feed Capture] {e.Message}");
                    if (e.InnerException != null) Console.WriteLine($"[HTTP Feed Capture] {e.InnerException.Message}");
                    //if (LastConnectionSuccessful)
                    //{
                    //    lock (notify)
                    //    {
                    //        notify.BalloonTipTitle = "SharpAlert is having issues";
                    //        notify.BalloonTipText = "There was an issue when trying to connect to the server. Check your internet connection!";
                    //        notify.BalloonTipIcon = ToolTipIcon.Warning;
                    //        notify.ShowBalloonTip(5000);
                    //    }
                    //}
                    //LastConnectionSuccessful = false;
                    Thread.Sleep(15 * 1000);
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
                    Console.WriteLine($"[HTTP Feed Capture] {e.StackTrace} {e.Message}");
                }
            }
        }

        private readonly object EnrollObject = new object();

        public void EnrollAlerts(string data, bool reset = false)
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
                            //    Console.WriteLine("[HTTP Feed Capture] Identifier not found. An MD5 value will be assigned to this alert instead.");
                            //    filename = CreateMD5(alert.Value);
                            //}

                            Console.WriteLine($"[HTTP Feed Capture] {alertIndex} -> {filename}");

                            //string StartingSharpAlertReplay = "<SharpAlertReplay>";
                            //string EndingSharpAlertReplay = "<SharpAlertReplay>";
                            //if (!alert.Value.Contains($"{StartingSharpAlertReplay}") || !alert.Value.Contains($"{EndingSharpAlertReplay}"))
                            //{
                            //    string alertReplayValue = alert.Value + "<SharpAlertReplay>false</SharpAlertReplay>";
                            //}

                            SharpDataItem item = new SharpDataItem(filename, alert.Value);

                            if (reset)
                            {
                                TryRemoveDataFromHistory(item);
                            }

                            if (FirstRun && Settings.Default.discardFirstAlerts)
                            {
                                if (TryAddDataToHistory(item))
                                {
                                    Console.WriteLine($"[HTTP Feed Capture] Alert {alertIndex} ({filename}) has been discarded (discard any alert on start).");
                                }
                            }
                            else
                            {
                                if (TryAddDataToQueue(item))
                                {
                                    Console.WriteLine($"[HTTP Feed Capture] Alert {alertIndex} ({filename}) has been saved for processing.");
                                }
                                else
                                {
                                    Console.WriteLine($"[HTTP Feed Capture] Alert {alertIndex} ({filename}) has been discarded (already in queue or history).");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[HTTP Feed Capture] Couldn't check the data for alert {alertIndex}. {ex.Message}");
                        }
                    }
                    if (alertIndex != 0) Console.WriteLine($"[HTTP Feed Capture] {alertIndex} alert(s) checked.");
                    else Console.WriteLine($"[HTTP Feed Capture] No alerts were checked.");
                }
                else
                {
                    Console.WriteLine("[HTTP Feed Capture] There are no alerts to enroll.");
                }
            }
        }

        /// <summary>
        /// Starts the HTTP Feed Capture service in the current thread as a server instead of a client.
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
        //            Console.WriteLine($"[HTTP Feed Capture] Getting data from the server.");
        //            Task<HttpResponseMessage> message = client.GetAsync($"{URLPrefix}://{server}");
        //            if (!message.Wait(10000)) continue;
        //            message.Result.EnsureSuccessStatusCode();

        //            if (Calls > 100000) Calls = 0;
        //            Calls++;

        //            Result = message.Result.Content.ReadAsStringAsync().Result;

        //            Console.WriteLine($"[HTTP Feed Capture] Grabbed data from the server.");

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
        //            Console.WriteLine($"[HTTP Feed Capture] {e.Message}");
        //            Thread.Sleep(1000);
        //        }
        //        catch (TimeoutException)
        //        {
        //            Console.WriteLine($"[HTTP Feed Capture] Timed out.");
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            Console.WriteLine($"[HTTP Feed Capture] {e.StackTrace} {e.Message} {e.Message}");
        //        }
        //        catch (AggregateException e)
        //        {
        //            Console.WriteLine($"[HTTP Feed Capture] {e.StackTrace} {e.Message}");
        //        }
        //        catch (TaskCanceledException)
        //        {
        //            Console.WriteLine("[HTTP Feed Capture] The executing task was canceled.");
        //        }
        //        catch (ThreadAbortException)
        //        {
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine($"[HTTP Feed Capture] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[HTTP Feed Capture] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[HTTP Feed Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }

        public static bool TryRemoveDataFromHistory(SharpDataItem item)
        {
            lock (SharpDataQueue)
            {
                lock (SharpDataHistory)
                {
                    try
                    {
                        if (SharpDataHistory.Any(x => x.Name == item.Name))
                        {
                            return SharpDataHistory.Remove(item);
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"[HTTP Feed Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
