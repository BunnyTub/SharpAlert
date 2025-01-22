using System;
using static SharpAlert.Program;
using static SharpAlert.RegexList;
using System.Linq;
using System.Threading;

namespace SharpAlert
{
    public class DataProcessor
    {
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

        public void ServiceRun()
        {
            //try
            {
                while (true)
                {
                    SharpDataItem relayItem;

                    while (true)
                    {
                        if (Stop)
                        {
                            Stop = false;
                            return;
                        }

                        if (SharpDataQueue.Count != 0)
                        {
                            lock (SharpDataQueue)
                            {
                                relayItem = SharpDataQueue.First();
                                break;
                            }
                        }
                        Thread.Sleep(100);
                    }

                    if (relayItem == null) continue;

                    Console.WriteLine($"[Data Processor] Processing data queue.");

                    string Replay = ReplayedAlertRegex.Match(relayItem.Data).Groups[1].Value;
                    bool ReplayMode = false;

                    if (Replay.ToLower() == "true")
                    {
                        Console.WriteLine("[Data Processor] Detected an alert in replay mode.");
                        ReplayMode = true;
                        relayItem.Data = relayItem.Data.Replace("<SharpAlertReplay>true</SharpAlertReplay>", "<SharpAlertReplay>false</SharpAlertReplay>");
                    }

                    lock (SharpDataHistory) SharpDataHistory.Add(relayItem);
                    lock (SharpDataQueue) SharpDataQueue.Remove(relayItem);

                    // trim history for memory saving
                    if (SharpDataHistory.Count > 20)
                    {
                        lock (SharpDataHistory) SharpDataHistory.Remove(SharpDataHistory.First());
                        Console.WriteLine($"[Data Processor] Trimmed data history.");
                    }

                    try
                    {
                        ThreadPool.QueueUserWorkItem(_ =>
                        {
                            AlertProcessor.ProcessAlertItem(relayItem, ReplayMode);
                        });
                        Console.WriteLine($"[Data Processor] Alert queued.");
                    }
                    catch (NotSupportedException ex)
                    {
                        Console.WriteLine($"[Alert Processor] Couldn't queue alert. {ex.Message}");
                    }
                }
            }
        }
    }
}
