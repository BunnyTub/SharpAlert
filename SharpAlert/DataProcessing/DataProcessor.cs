using System;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.RegexList;
using System.Linq;
using System.Threading;
using SharpAlert.Properties;

namespace SharpAlert
{
    public class DataProcessor
    {
        private bool Stop = false;
        private bool StopCalled = false;

        public AlertProcessor ap = new AlertProcessor();

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

        public void ServiceRun()
        {
            while (true)
            {
                try
                {
                    Thread.Sleep(1000);

                    // Trim history for memory saving
                    if (SharpDataHistory.Count > Settings.Default.storedMaxSize)
                    {
                        // use first instead of last, otherwise, recent alerts will be forgotten
                        lock (SharpDataHistory) SharpDataHistory.Remove(SharpDataHistory.First());
                        Console.WriteLine($"[Data Processor] Trimmed data history.");
                    }

                    SharpDataItem relayItem = null;

                    if (Stop)
                    {
                        Stop = false;
                        return;
                    }

                    lock (SharpDataQueue)
                    {
                        if (SharpDataQueue.Any())
                        {
                            try
                            {
                                relayItem = SharpDataQueue.First();
                            }
                            catch (InvalidOperationException)
                            {
                                Console.WriteLine("[Data Processor] The request to the queue failed. Possible race condition?");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"[Data Processor] The request to the queue failed. {ex.Message}");
                            }
                            if (relayItem is null) continue;
                        }
                        else continue;

                        if (!SharpDataQueue.Contains(relayItem)) continue;
                        else
                        {
                            Console.WriteLine($"[Data Processor] Processing data queue.");

                            string Replay = ReplayedAlertRegex.MatchOrDefault(relayItem.Data, "false");
                            bool ReplayMode = false;

                            if (Replay.ToLowerInvariant() == "true")
                            {
                                Console.WriteLine("[Data Processor] Detected an alert in replay mode.");
                                ReplayMode = true;
                                relayItem.Data = relayItem.Data.Replace("<SharpAlertReplay>true</SharpAlertReplay>", "<SharpAlertReplay>false</SharpAlertReplay>");
                            }

                            lock (SharpDataHistory) SharpDataHistory.Add(relayItem);
                            SharpDataQueue.Remove(relayItem);

                            try
                            {
                                Console.WriteLine($"[Data Processor] Adding alert to queue.");
                                ThreadPool.QueueUserWorkItem(_ =>
                                {
                                    ap.ProcessAlertItem(relayItem, ReplayMode);
                                });
                                Console.WriteLine($"[Data Processor] Added alert to queue.");
                            }
                            catch (NotSupportedException ex)
                            {
                                Console.WriteLine($"[Alert Processor] Couldn't queue alert. {ex.Message}");
                            }
                        }   
                    }
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"[Data Processor] {e.StackTrace} {e.Message}");
                }
            }
        }
    }
}
