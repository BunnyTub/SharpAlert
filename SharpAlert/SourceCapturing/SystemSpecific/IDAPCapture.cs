using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using SharpAlert.ProgramWorker;
using static SharpAlert.ProgramWorker.IceBearWorker;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.RegexList;

namespace SharpAlert.SourceCapturing.SystemSpecific
{
    public class IDAPCapture
    {
        private bool FirstRun = true;
        private bool Stop = false;
        private bool StopCalled = false;

        private static readonly WebClient idapclient = new WebClient();

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

        public static int Calls { get; private set; } = 0;

        private static readonly string serverPath = "idapcap.mdr.gov.br";

        /// <summary>
        /// Starts the IDAP Capture service in the current thread as a client.
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
                        Console.WriteLine($"[IDAP Capture] Getting data from IDAP. URL -> {serverPath}");

                        string Result = idapclient.DownloadString($"{URLPrefix}://{serverPath}");
                        
                        if (Calls >= 100000) Calls = 0;
                        Calls++;
                        // HEY YOU ABSOLUTE FUCKING IDIOT

                        EnrollEntries(Result);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[IDAP Capture] {ex.GetBaseException().Message}");
                    }
                }
                catch (TimeoutException)
                {
                    Console.WriteLine($"[IDAP Capture] Timed out.");
                    Thread.Sleep(15 * 1000);
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[IDAP Capture] {e.Message}");
                    if (e.InnerException != null) Console.WriteLine($"[IDAP Capture] {e.InnerException.Message}");
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
                    Console.WriteLine($"[IDAP Capture] {e.StackTrace} {e.Message}");
                }
            }
        }

        private readonly object EnrollObject = new object();

        public void EnrollEntries(string data)
        {
            MatchCollection entries = HrefRegex.Matches(data);

            string AlertList = string.Empty;

            int EntriesIndex = 0;
            int EntriesDiscardCount = 0;
            int AlertCount = 0;

            Console.WriteLine($"[IDAP Capture] Processing {entries.Count} tag(s).");

            int ThreadsRunning = 0;

            foreach (Match entry in entries)
            {
                if (AlertCount >= 10)
                {
                    //Console.WriteLine($"[IDAP Capture] Give up.");
                    EnrollAlerts(AlertList);
                    AlertCount = 0;
                    AlertList = string.Empty;
                    break;
                }

                if (Stop) return;

                EntriesIndex++;
                AlertCount++;
                if (EntriesIndex.ToString().Last() == "0".ToCharArray()[0])
                {
                    Console.WriteLine($"[IDAP Capture] {EntriesIndex} links(s) processed out of {entries.Count}. {ThreadsRunning} threads working.");
                }
                else
                {
                    if (entries.Count == EntriesIndex)
                    {
                        Console.WriteLine($"[IDAP Capture] Processing last link.");
                    }
                    else
                    {
                        if (EntriesIndex == 1)
                        {
                            Console.WriteLine($"[IDAP Capture] Processing first link.");
                        }
                    }
                }

                string EntryStr = entry.Groups[1].Value;

                if (EntryStr.StartsWith(".")) continue;

                try
                {
                    Console.WriteLine($"[IDAP Capture] Getting additional data from IDAP. URL -> {serverPath}/{EntryStr}");
                    HttpResponseMessage message = client.GetAsync($"https://{serverPath}/{EntryStr}").Result;
                    message.EnsureSuccessStatusCode();
                    Task<string> value = message.Content.ReadAsStringAsync();
                    value.Wait(30000);
                    AlertList += $"{value.Result}\r\n";
                }
                catch (Exception ex)
                {
                    EntriesDiscardCount++;
                    Console.WriteLine($"[IDAP Capture] Couldn't get data for an IDAP alert. {ex.GetBaseException().Message}");
                }
            }

            while (ThreadsRunning != 0) Thread.Sleep(50);

            Console.WriteLine($"[IDAP Capture] {EntriesIndex} tag(s) saved, and {EntriesDiscardCount} tag(s) discarded. Tags remaining: {EntriesIndex - EntriesDiscardCount}");
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
                    Console.WriteLine($"[IDAP Capture] Processing {alertMatches.Count} alert(s).");

                    foreach (Match alert in alertMatches)
                    {
                        try
                        {
                            alertIndex++;
                            if (alert.Value is null) continue;
                            if (alertIndex.ToString().Last() == "0".ToCharArray()[0])
                            {
                                Console.WriteLine($"[IDAP Capture] {alertIndex} alert(s) processed out of {alertMatches.Count}.");
                            }
                            else
                            {
                                if (alertMatches.Count == alertIndex)
                                {
                                    Console.WriteLine($"[IDAP Capture] Processing last alert.");
                                }
                                else
                                {
                                    if (alertIndex == 1)
                                    {
                                        Console.WriteLine($"[IDAP Capture] Processing first alert.");
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
                                    //Console.WriteLine($"[IDAP Capture] Alert {alertIndex} ({filename}) has been discarded (discard any alert on start).");
                                    alertDiscardCount++;
                                }
                            }
                            else
                            {
                                if (TryAddDataToQueue(item))
                                {
                                    //Console.WriteLine($"[IDAP Capture] Alert {alertIndex} ({filename}) has been saved for processing.");
                                }
                                else
                                {
                                    //Console.WriteLine($"[IDAP Capture] Alert {alertIndex} ({filename}) has been discarded (already in queue or history).");
                                    alertDiscardCount++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[IDAP Capture] Couldn't check the data for alert {alertIndex}. {ex.Message}");
                        }
                    }
                    if (alertIndex != 0)
                    {
                        Console.WriteLine($"[IDAP Capture] {alertIndex} alert(s) checked, and {alertDiscardCount} alert(s) discarded. Alerts remaining: {alertIndex - alertDiscardCount}");
                    }
                    else Console.WriteLine($"[IDAP Capture] No alerts were checked.");
                }
                else
                {
                    Console.WriteLine("[IDAP Capture] There are no alerts to enroll.");
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
                        Console.WriteLine($"[IDAP Capture] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[IDAP Capture] {e.StackTrace} {e.Message}");
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
                        Console.WriteLine($"[IDAP Capture] {e.StackTrace} {e.Message}");
                        return false;
                    }
                }
            }
        }
    }
}

