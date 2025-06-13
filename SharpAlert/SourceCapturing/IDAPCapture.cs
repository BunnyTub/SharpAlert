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
    public class IDAPCapture
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
                                    ConsoleExt.WriteLine($"[IDAP Feed Capture] Getting data from {server.ServerName}. URL -> {server.ServerPath}");
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
                                    ConsoleExt.WriteLine($"[IDAP Feed Capture] {ex.Message}");
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
                                ConsoleExt.WriteLine($"[IDAP Feed Capture] Fetched from all feeds successfully.");
                            }
                            else
                            {
                                ConsoleExt.WriteLine("[IDAP Feed Capture] Not all feeds were fetched from successfully.");
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
                    ConsoleExt.WriteLine($"[IDAP Feed Capture] Timed out.");
                    Thread.Sleep(15 * 1000);
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception e)
                {
                    ConsoleExt.WriteLine($"[IDAP Feed Capture] {e.Message}");
                    if (e.InnerException != null) ConsoleExt.WriteLine($"[IDAP Feed Capture] {e.InnerException.Message}");
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
                    int CheckInterval = QuickSettings.Instance.AlertCheckInterval;
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
                    ConsoleExt.WriteLine($"[IDAP Feed Capture] {e.StackTrace} {e.Message}");
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
                            //    ConsoleExt.WriteLine("[HTTP Feed Capture] Identifier not found. An MD5 value will be assigned to this alert instead.");
                            //    filename = CreateMD5(alert.Value);
                            //}

                            ConsoleExt.WriteLine($"[IDAP Feed Capture] {alertIndex} -> {filename}");

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

                            if (FirstRun && QuickSettings.Instance.discardFirstAlerts)
                            {
                                if (TryAddDataToHistory(item))
                                {
                                    ConsoleExt.WriteLine($"[IDAP Feed Capture] Alert {alertIndex} ({filename}) has been discarded (discard any alert on start).");
                                }
                            }
                            else
                            {
                                if (TryAddDataToQueue(item))
                                {
                                    ConsoleExt.WriteLine($"[IDAP Feed Capture] Alert {alertIndex} ({filename}) has been saved for processing.");
                                }
                                else
                                {
                                    ConsoleExt.WriteLine($"[IDAP Feed Capture] Alert {alertIndex} ({filename}) has been discarded (already in queue or history).");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            ConsoleExt.WriteLine($"[IDAP Feed Capture] Couldn't check the data for alert {alertIndex}. {ex.Message}");
                        }
                    }
                    if (alertIndex != 0) ConsoleExt.WriteLine($"[IDAP Feed Capture] {alertIndex} alert(s) checked.");
                    else ConsoleExt.WriteLine($"[IDAP Feed Capture] No alerts were checked.");
                }
                else
                {
                    ConsoleExt.WriteLine("[IDAP Feed Capture] There are no alerts to enroll.");
                }
            }
        }

        public bool TryAddDataToQueue(SharpDataItem item)
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
                        ConsoleExt.WriteLine($"[IDAP Feed Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }

        public bool TryAddDataToHistory(SharpDataItem item)
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
                        ConsoleExt.WriteLine($"[IDAP Feed Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }

        public bool TryRemoveDataFromHistory(SharpDataItem item)
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
                        ConsoleExt.WriteLine($"[IDAP Feed Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }
    }
}
