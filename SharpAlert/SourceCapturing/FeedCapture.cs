using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using SharpAlert.ProgramWorker;
using static SharpAlert.ProgramWorker.HaidaWorker;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.ProgramWorker.NotificationWorker;
using static SharpAlert.RegexList;

namespace SharpAlert.SourceCapturing
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

        /// <summary>
        /// Starts the HTTP Feed Capture service in the current thread as a client.
        /// </summary>
        /// <param name="useHTTPS">Use the secure version of Hypertext Transfer Protocol to connect to the target server.</param>
        public void ServiceRun(bool useHTTPS)
        {
            if (Stop) return;

            if (servers.Count == 0)
            {
                Console.WriteLine("[HTTP Feed Capture] No servers found.");
                return;
            }

            while (true)
            {
                try
                {
                    string URLPrefix = useHTTPS ? "https" : "http";

                    lock (servers)
                    {
                        if (servers.Count != 0)
                        {
                            int count = servers.Count;

                            List<ServerInfo> localServers = new List<ServerInfo>();

                            lock (servers)
                            {
                                localServers = [.. servers];
                            }

                            foreach (ServerInfo server in localServers)
                            {
                                try
                                {
                                    count--;
                                    Console.WriteLine($"[HTTP Feed Capture] Getting data from {server.ServerName}. URL -> {server.ServerPath}");
                                    HttpResponseMessage message = Client.GetAsync($"{URLPrefix}://{server.ServerPath}").Result;

                                    //if (message.StatusCode == System.Net.HttpStatusCode.PermanentRedirect || message.StatusCode == System.Net.HttpStatusCode.TemporaryRedirect)
                                    //{
                                    //    Console.WriteLine($"[HTTP Feed Capture] Getting data from {server.ServerName}. URL (Redirected) -> {message.RequestMessage.RequestUri}");
                                    //}
                                    //else
                                    //{
                                    //}

                                    message.EnsureSuccessStatusCode();
                                    FeedSuccessfulCalls++;

                                    string Result = message.Content.ReadAsStringAsync().Result;

                                    EnrollAlerts(Result, server.ServerName);
                                    server.LastRunSuccess = true;
                                }
                                catch (Exception ex)
                                {
                                    count++;
                                    Console.WriteLine($"[HTTP Feed Capture] {ex.Message}");
                                    NetFailureCount++;
                                    server.LastRunSuccess = false;
                                    if (!QuickSettings.Instance.HideNetworkErrors) Notify.ShowNotification($"Network error occurred. Timed out from the feed.",
                                        "SharpAlert source timed out",
                                        ToolTipIcon.Warning);
                                }
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
                    if (!QuickSettings.Instance.HideNetworkErrors) Notify.ShowNotification($"Network error occurred. Timed out from the feed.",
                        "SharpAlert source timed out",
                        ToolTipIcon.Warning);
                    NetFailureCount++;
                    Thread.Sleep(15 * 1000);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[HTTP Feed Capture] {ex.GetBaseException().Message}");
                    if (!QuickSettings.Instance.HideNetworkErrors) Notify.ShowNotification($"Network error occurred. {ex.GetBaseException().Message}",
                        "SharpAlert source problem",
                        ToolTipIcon.Warning);
                    NetFailureCount++;
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
                    Console.WriteLine($"[HTTP Feed Capture] {e.StackTrace} {e.Message}");
                }
            }
        }

        private readonly object EnrollObject = new object();

        public void EnrollAlerts(string data, string name)
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

                            string CombinedAlertValue = $"<SharpAlertSource>{name}</SharpAlertSource>{alert.Value}";

                            SharpDataItem item = new SharpDataItem(filename, CombinedAlertValue);

                            //if (reset)
                            //{
                            //    TryRemoveDataFromHistory(item);
                            //}

                            if (FirstRun && QuickSettings.Instance.discardFirstAlerts)
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
                        Console.WriteLine($"[HTTP Feed Capture] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[HTTP Feed Capture] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[HTTP Feed Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }
    }
}

