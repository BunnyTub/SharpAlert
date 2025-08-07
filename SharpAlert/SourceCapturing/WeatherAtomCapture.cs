using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SharpAlert.ProgramWorker;
using static SharpAlert.ProgramWorker.IceBearWorker;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.RegexList;

namespace SharpAlert.SourceCapturing
{
    public class WeatherAtomCapture
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
        /// Starts the Atom Feed Capture service in the current thread as a client.
        /// </summary>
        /// <param name="useHTTPS">Use the secure version of Hypertext Transfer Protocol to connect to the target server.</param>
        public void ServiceRun(bool useHTTPS)
        {
            if (Stop) return;

            if (!servers.Any())
            {
                Console.WriteLine("[Atom Feed Capture] No servers found.");
                return;
            }

            while (true)
            {
                try
                {
                    string URLPrefix = useHTTPS ? "https" : "http";
                    bool AllConnectionsSuccessful = true;

                    if (Stop) return;

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
                                    Console.WriteLine($"[Atom Feed Capture] Getting data from {server.ServerName}. URL -> {server.ServerPath}");
                                    Task<HttpResponseMessage> message = client.GetAsync($"{URLPrefix}://{server.ServerPath}");
                                    message.Wait();
                                    message.Result.EnsureSuccessStatusCode();

                                    if (Calls >= 100000) Calls = 0;
                                    Calls++;
                                    // HEY YOU ABSOLUTE FUCKING IDIOT

                                    string Result = message.Result.Content.ReadAsStringAsync().Result;

                                    EnrollEntries(Result);
                                }
                                catch (Exception ex)
                                {
                                    count++;
                                    Console.WriteLine($"[Atom Feed Capture] {ex.GetBaseException().Message}");
                                    server.LastRunSuccess = false;
                                }
                            }

                            if (count >= servers.Count)
                            {
                                AllConnectionsSuccessful = false;
                            }
                            else
                            {
                                AllConnectionsSuccessful = true;
                            }

                            if (AllConnectionsSuccessful)
                            {
                                Console.WriteLine($"[Atom Feed Capture] Fetched from all feeds successfully.");
                            }
                            else
                            {
                                Console.WriteLine("[Atom Feed Capture] Not all feeds were fetched from successfully.");
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
                    Console.WriteLine($"[Atom Feed Capture] Timed out.");
                    Thread.Sleep(15 * 1000);
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[Atom Feed Capture] {e.Message}");
                    if (e.InnerException != null) Console.WriteLine($"[Atom Feed Capture] {e.InnerException.Message}");
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
                    Console.WriteLine($"[Atom Feed Capture] {e.StackTrace} {e.Message}");
                }
            }
        }

        private readonly object EnrollObject = new object();

        public void EnrollEntries(string data)
        {
            MatchCollection entries = EntryRegex.Matches(data);

            string AlertList = string.Empty;

            int EntriesIndex = 0;
            int EntriesDiscardCount = 0;

            Console.WriteLine($"[Atom Feed Capture] Processing {entries.Count} tag(s).");

            foreach (Match entry in entries)
            {
                if (Stop) return;

                EntriesIndex++;
                if (EntriesIndex.ToString().Last() == "0".ToCharArray()[0])
                {
                    Console.WriteLine($"[Atom Feed Capture] {EntriesIndex} tag(s) processed out of {entries.Count}.");
                }
                else
                {
                    if (entries.Count == EntriesIndex)
                    {
                        Console.WriteLine($"[Atom Feed Capture] Processing last tag.");
                    }
                    else
                    {
                        if (EntriesIndex == 1)
                        {
                            Console.WriteLine($"[Atom Feed Capture] Processing first tag.");
                        }
                    }
                }

                string EntryStr = entry.Groups[0].Value;

                EntryStr = $"<alert><info>{EntryStr}</info></alert>";
                EntryStr = EntryStr.Replace("<cap:", "<");
                EntryStr = EntryStr.Replace("</cap:", "</");
                EntryStr = EntryStr.Replace("<summary>", "<description>").Replace("</summary>", "</description>");
                
                if (QuickSettings.Instance.RemoveNWSDescCode)
                {
                    string desc = DescriptionRegex.MatchOrDefault(EntryStr).Trim();

                    if (desc.Length > 6)
                    {
                        string subDesc = desc.Substring(0, 6);

                        if (!subDesc.Contains('\x20') && !subDesc.Contains('\n'))
                        {
                            bool AllUpper = true;

                            foreach (char character in subDesc)
                            {
                                if (!char.IsLetter(character)) break;
                                if (!char.IsUpper(character))
                                {
                                    AllUpper = false;
                                    break;
                                }
                            }

                            if (AllUpper)
                            {
                                EntryStr = DescriptionRegex.Replace(EntryStr,
                                    $"<description>{desc.Substring(6).Trim()}</description>");
                            }
                        }
                    }
                }

                if (QuickSettings.Instance.RemoveNWSNewLines)
                {
                    EntryStr = DescriptionRegex.Replace(EntryStr,
                        $"<description>{DescriptionRegex.MatchOrDefault(EntryStr).Replace("\r", "").Replace("\n", " ").Trim()}</description>");
                }

                //Console.WriteLine($"[Atom Feed Capture] {EntriesCount} -> {CreateMD5(entry.Groups[1].Value)} (entry name is unused)");
                string Effective = AtomEffectiveRegex.MatchOrDefault(EntryStr, DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));
                //Console.WriteLine($"[Atom Feed Capture] Atom Effective: {Effective}");

                string Expiry = AtomExpiresRegex.MatchOrDefault(EntryStr, DateTime.UtcNow.AddHours(1).ToString("O", CultureInfo.InvariantCulture));
                //Console.WriteLine($"[Atom Feed Capture] Atom Expires: {Expiry}");

                try
                {
                    if (DateTime.Parse(Expiry, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal) <= DateTime.Now)
                    {
                        EntriesDiscardCount++;
                        //Console.WriteLine($"[Atom Feed Capture] Entry discarded because it has expired.");
                        continue;
                    }
                }
                catch (Exception)
                {
                    //Console.WriteLine($"[Atom Feed Capture] Expiry check skipped because it has failed. {ex.Message}");
                }

                AlertList += $"{EntryStr}\r\n";

                //string ReturnURL = EntryLinkRegex.MatchOrDefault(entry.Groups[1].Value);

                //if (string.IsNullOrWhiteSpace(ReturnURL))
                //{
                //    EntriesDiscardCount++;
                //    //Console.WriteLine($"[Atom Feed Capture] Entry discarded because a suitable XML link could not be found.");
                //    continue;
                //}

                //try
                //{
                //    HttpResponseMessage message = client.GetAsync(ReturnURL).Result;
                //    message.EnsureSuccessStatusCode();

                //    if (Calls >= 100000) Calls = 0;
                //    Calls++;

                //    string Result = message.Content.ReadAsStringAsync().Result;
                //    AlertList += $"{Result}\r\n";
                //    //Console.WriteLine($"[Atom Feed Capture] Entry saved for further processing.");
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine($"[Atom Feed Capture] Entry could not be saved. {ex.Message}");
                //}

                //Thread.Sleep(10); // we're gonna get rate limited. Awesome!
            }

            Console.WriteLine($"[Atom Feed Capture] {EntriesIndex} tag(s) saved, and {EntriesDiscardCount} tag(s) discarded. Tags remaining: {EntriesIndex - EntriesDiscardCount}");

            EnrollAlerts(AlertList);
        }

        public void EnrollAlerts(string data, bool reset = false)
        {
            lock (EnrollObject)
            {
                MatchCollection alertMatches = AlertRegex.Matches(data);
                int alertIndex = 0;
                int alertDiscardCount = 0;

                if (alertMatches != null || alertMatches.Count != 0)
                {
                    Console.WriteLine($"[Atom Feed Capture] Processing {alertMatches.Count} alert(s).");

                    foreach (Match alert in alertMatches)
                    {
                        try
                        {
                            alertIndex++;
                            if (alert.Value is null) continue;
                            if (alertIndex.ToString().Last() == "0".ToCharArray()[0])
                            {
                                Console.WriteLine($"[Atom Feed Capture] {alertIndex} alert(s) processed out of {alertMatches.Count}.");
                            }
                            else
                            {
                                if (alertMatches.Count == alertIndex)
                                {
                                    Console.WriteLine($"[Atom Feed Capture] Processing last alert.");
                                }
                                else
                                {
                                    if (alertIndex == 1)
                                    {
                                        Console.WriteLine($"[Atom Feed Capture] Processing first alert.");
                                    }
                                }
                            }

                            string filename = IdentifierRegex.MatchOrDefault(alert.Value, CreateMD5(alert.Value));

                            SharpDataItem item = new SharpDataItem(filename, alert.Value);

                            if (reset)
                            {
                                TryRemoveDataFromHistory(item);
                            }

                            if (FirstRun && QuickSettings.Instance.discardFirstAlerts)
                            {
                                if (TryAddDataToHistory(item))
                                {
                                    //Console.WriteLine($"[Atom Feed Capture] Alert {alertIndex} ({filename}) has been discarded (discard any alert on start).");
                                    alertDiscardCount++;
                                }
                            }
                            else
                            {
                                if (TryAddDataToQueue(item))
                                {
                                    //Console.WriteLine($"[Atom Feed Capture] Alert {alertIndex} ({filename}) has been saved for processing.");
                                }
                                else
                                {
                                    //Console.WriteLine($"[Atom Feed Capture] Alert {alertIndex} ({filename}) has been discarded (already in queue or history).");
                                    alertDiscardCount++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Atom Feed Capture] Couldn't check the data for alert {alertIndex}. {ex.Message}");
                        }
                    }
                    if (alertIndex != 0)
                    {
                        Console.WriteLine($"[Atom Feed Capture] {alertIndex} alert(s) checked, and {alertDiscardCount} alert(s) discarded. Alerts remaining: {alertIndex - alertDiscardCount}");
                    }
                    else Console.WriteLine($"[Atom Feed Capture] No alerts were checked.");
                }
                else
                {
                    Console.WriteLine("[Atom Feed Capture] There are no alerts to enroll.");
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
                        Console.WriteLine($"[Atom Feed Capture] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[Atom Feed Capture] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[Atom Feed Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }
    }
}

