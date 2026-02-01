using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using SharpAlert.ProgramWorker;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.ProgramWorker.HaidaWorker;
using static SharpAlert.ProgramWorker.NotificationWorker;
using static SharpAlert.RegexList;

namespace SharpAlert.SourceCapturing.SystemSpecific
{
    public partial class IDAPFeedCapture
    {
        private bool FirstRun = true;
        private bool Stop = false;
        private bool StopCalled = false;

        public static readonly WebClient idapclient = new();

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
        }


        public static readonly string serverPath = "idapcap.mdr.gov.br";

        /// <summary>
        /// Starts the IDAP Feed Capture service in the current thread as a client.
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

                    if (Stop) return;

                    try
                    {
                        Console.WriteLine($"[IDAP Feed Capture] Getting data from IDAP. URL -> {serverPath}");

                        string Result = idapclient.DownloadString($"{URLPrefix}://{serverPath}");

                        // DO NOT TRIM RESULT

                        FeedSuccessfulCalls++;

                        EnrollEntries(Result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[IDAP Feed Capture] {ex.GetBaseException().Message}");
                    }
                }
                catch (TimeoutException)
                {
                    Console.WriteLine($"[IDAP Feed Capture] Timed out.");
                    if (!QuickSettings.Instance.HideNetworkErrors) Notify.ShowNotification($"Network error occurred. Timed out from IDAP.",
                        "SharpAlert source failed",
                        ToolTipIcon.Warning);
                    NetFailureCount++;
                    Thread.Sleep(15 * 1000);
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[IDAP Feed Capture] {ex.Message}");
                    if (!QuickSettings.Instance.HideNetworkErrors) Notify.ShowNotification($"Network error occurred. {ex.Message}",
                        "SharpAlert source failed",
                        ToolTipIcon.Warning);
                    NetFailureCount++;
                    Thread.Sleep(15 * 1000);
                }
                if (FirstRun) FirstRun = false;

                try
                {
                    int CheckInterval = QuickSettings.Instance.AlertCheckInterval;
                    //int CheckInterval = 60;
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
                    Console.WriteLine($"[IDAP Feed Capture] {e.StackTrace} {e.Message}");
                }
            }
        }

        private readonly object EnrollObject = new();

        public void EnrollEntries(string data)
        {
            int EntriesIndex = 0;
            int EntriesDiscardCount = 0;
            int AlertCount = 0;

            string[] DataSplit = data.Split('\n');
            string AlertList = string.Empty;

            Console.WriteLine($"[IDAP Feed Capture] Processing {DataSplit.Length} lines.");

            foreach (string line in DataSplit)
            {
                //<a href="10000020122022-PR.xml">10000020122022-PR.xml</a> 20-Dec-2022 15:47 74861
                string line_ = SpaceRegex().Replace(line, " ");
                MatchCollection entries = HrefRegex.Matches(line_);
                if (entries.Count == 0) continue;
                
                // I stole this regex from somewhere lol
                Match dateMatch = DateTimeRegex().Match(line_);
                if (dateMatch.Success)
                {
                    DateTime parsedDate = DateTime.ParseExact(
                        dateMatch.Value,
                        "dd-MMM-yyyy HH:mm",
                        CultureInfo.InvariantCulture
                    );

                    double totalDays = (DateTime.UtcNow - parsedDate).TotalDays;

                    if ((int)totalDays > 15)
                    {
                        //Console.WriteLine($"[IDAP Feed Capture] The current alert is {(int)totalDays} day(s) old, so it will be discarded.");
                        continue;
                    }
                    else
                    {
                        foreach (Match entry in entries)
                        {
                            //if (AlertCount >= 10)
                            //{
                            //    //Console.WriteLine($"[IDAP Feed Capture] Give up.");
                            //    EnrollAlerts(AlertList);
                            //    AlertCount = 0;
                            //    AlertList = string.Empty;
                            //    break;
                            //}

                            if (Stop) return;

                            EntriesIndex++;
                            AlertCount++;

                            Console.WriteLine($"[IDAP Feed Capture] {EntriesIndex} links(s) processed out of (maybe) {DataSplit.Length}.");

                            string EntryStr = entry.Groups[1].Value;

                            if (EntryStr.StartsWith('.')) continue;

                            try
                            {
                                Console.WriteLine($"[IDAP Feed Capture] Getting additional data from IDAP. URL -> {serverPath}/{EntryStr}");
                                // This should help with accented characters hopefully
                                string value = Encoding.UTF8.GetString(idapclient.DownloadData($"https://{serverPath}/{EntryStr}"));
                                AlertList += $"{value}\r\n";
                            }
                            catch (Exception ex)
                            {
                                EntriesDiscardCount++;
                                Console.WriteLine($"[IDAP Feed Capture] Couldn't get data for an IDAP alert. {ex.GetBaseException().Message}");
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("[IDAP Feed Capture] No date and time found.");
                }
            }

            Console.WriteLine($"[IDAP Feed Capture] {EntriesIndex} tag(s) saved, and {EntriesDiscardCount} tag(s) discarded. Tags remaining: {EntriesIndex - EntriesDiscardCount}");
            EnrollAlerts(AlertList);
        }
        
        public void LegacyEnrollEntries(string data)
        {
            MatchCollection entries = HrefRegex.Matches(data);

            string AlertList = string.Empty;

            int EntriesIndex = 0;
            int EntriesDiscardCount = 0;
            int AlertCount = 0;

            Console.WriteLine($"[IDAP Feed Capture] Processing {entries.Count} tag(s).");

            int ThreadsRunning = 0;

            foreach (Match entry in entries)
            {
                //if (AlertCount >= 10)
                //{
                //    //Console.WriteLine($"[IDAP Feed Capture] Give up.");
                //    EnrollAlerts(AlertList);
                //    AlertCount = 0;
                //    AlertList = string.Empty;
                //    break;
                //}

                if (Stop) return;

                EntriesIndex++;
                AlertCount++;
                if (EntriesIndex.ToString().Last() == "0".ToCharArray()[0])
                {
                    Console.WriteLine($"[IDAP Feed Capture] {EntriesIndex} links(s) processed out of {entries.Count}. {ThreadsRunning} threads working.");
                }
                else
                {
                    if (entries.Count == EntriesIndex)
                    {
                        Console.WriteLine($"[IDAP Feed Capture] Processing last link.");
                    }
                    else
                    {
                        if (EntriesIndex == 1)
                        {
                            Console.WriteLine($"[IDAP Feed Capture] Processing first link.");
                        }
                    }
                }

                string EntryStr = entry.Groups[1].Value;

                if (EntryStr.StartsWith('.')) continue;

                try
                {
                    Console.WriteLine($"[IDAP Feed Capture] Getting additional data from IDAP. URL -> {serverPath}/{EntryStr}");
                    string value = idapclient.DownloadString($"https://{serverPath}/{EntryStr}");
                    AlertList += $"{value}\r\n";
                }
                catch (Exception ex)
                {
                    EntriesDiscardCount++;
                    Console.WriteLine($"[IDAP Feed Capture] Couldn't get data for an IDAP alert. {ex.GetBaseException().Message}");
                }
            }

            while (ThreadsRunning != 0) Thread.Sleep(50);

            Console.WriteLine($"[IDAP Feed Capture] {EntriesIndex} tag(s) saved, and {EntriesDiscardCount} tag(s) discarded. Tags remaining: {EntriesIndex - EntriesDiscardCount}");
        }

        public void EnrollAlerts(string data)
        {
            lock (EnrollObject)
            {
                MatchCollection alertMatches = AlertRegex.Matches(data);
                int alertIndex = 0;
                int alertDiscardCount = 0;

                if (alertMatches != null || alertMatches.Count != 0)
                {
                    Console.WriteLine($"[IDAP Feed Capture] Processing {alertMatches.Count} alert(s).");

                    foreach (Match alert in alertMatches)
                    {
                        try
                        {
                            alertIndex++;
                            if (alert.Value is null) continue;
                            if (alertIndex.ToString().Last() == "0".ToCharArray()[0])
                            {
                                Console.WriteLine($"[IDAP Feed Capture] {alertIndex} alert(s) processed out of {alertMatches.Count}.");
                            }
                            else
                            {
                                if (alertMatches.Count == alertIndex)
                                {
                                    Console.WriteLine($"[IDAP Feed Capture] Processing last alert.");
                                }
                                else
                                {
                                    if (alertIndex == 1)
                                    {
                                        Console.WriteLine($"[IDAP Feed Capture] Processing first alert.");
                                    }
                                }
                            }

                            string filename = IdentifierRegex.MatchOrDefault(alert.Value, CreateMD5(alert.Value));

                            string CombinedAlertValue = $"<SharpAlertSource>IDAP</SharpAlertSource>{alert.Value}";

                            SharpDataItem item = new(filename, CombinedAlertValue);

                            if (FirstRun && QuickSettings.Instance.discardFirstAlerts)
                            {
                                if (TryAddDataToHistory(item))
                                {
                                    //Console.WriteLine($"[IDAP Feed Capture] Alert {alertIndex} ({filename}) has been discarded (discard any alert on start).");
                                    alertDiscardCount++;
                                }
                            }
                            else
                            {
                                if (TryAddDataToQueue(item))
                                {
                                    //Console.WriteLine($"[IDAP Feed Capture] Alert {alertIndex} ({filename}) has been saved for processing.");
                                }
                                else
                                {
                                    //Console.WriteLine($"[IDAP Feed Capture] Alert {alertIndex} ({filename}) has been discarded (already in queue or history).");
                                    alertDiscardCount++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[IDAP Feed Capture] Couldn't check the data for alert {alertIndex}. {ex.Message}");
                        }
                    }
                    if (alertIndex != 0)
                    {
                        Console.WriteLine($"[IDAP Feed Capture] {alertIndex} alert(s) checked, and {alertDiscardCount} alert(s) discarded. Alerts remaining: {alertIndex - alertDiscardCount}");
                    }
                    else Console.WriteLine($"[IDAP Feed Capture] No alerts were checked.");
                }
                else
                {
                    Console.WriteLine("[IDAP Feed Capture] There are no alerts to enroll.");
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
                        Console.WriteLine($"[IDAP Feed Capture] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[IDAP Feed Capture] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[IDAP Feed Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }

        [GeneratedRegex(@"\s{2,}")]
        private static partial Regex SpaceRegex();

        [GeneratedRegex(@"\d{2}-[A-Za-z]{3}-\d{4} \d{2}:\d{2}")]
        private static partial Regex DateTimeRegex();
    }
}

