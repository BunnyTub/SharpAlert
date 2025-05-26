using System;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.RegexList;
using System.Linq;
using System.Threading;
using SharpAlert.Properties;
using System.Collections.Generic;

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
                    Thread.Sleep(100);

                    // Trim history for memory saving
                    if (SharpDataHistory.Count > Settings.Default.storedMaxSize)
                    {
                        // use first instead of last, otherwise, recent alerts will be forgotten
                        lock (SharpDataHistory) SharpDataHistory.Remove(SharpDataHistory.First());
                        Console.WriteLine($"[Data Processor] Trimmed data history.");
                    }

                    List<SharpDataItem> LocalDataQueue = new List<SharpDataItem>();

                    //SharpDataItem relayItem = null;

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
                                LocalDataQueue.AddRange(SharpDataQueue);
                                //relayItem = SharpDataQueue.First();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"[Data Processor] {ex.Message}");
                                continue;
                            }
                            //if (relayItem is null) continue;
                        }
                        else
                        {
                            //Console.WriteLine("[Data Processor] There are no items in the queue yet.");
                            continue;
                        }

                        lock (LocalDataQueue)
                        {
                            foreach (var relayItem in LocalDataQueue)
                            {
                                try
                                {
                                    Console.WriteLine($"[Data Processor] Processing queued item.");

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
                                        ThreadPool.QueueUserWorkItem(_ =>
                                        {
                                            //if (MessageBox.Show($"Process {relayItem.Name}?\r\n\r\n" +
                                            //    $"{relayItem.Data}",
                                            //    "SharpAlert",
                                            //    MessageBoxButtons.YesNo) == DialogResult.Yes)
                                            ap.ProcessAlertItem(relayItem, ReplayMode);
                                        });
                                        Console.WriteLine($"[Data Processor] The item is being processed by the Alert Processor.");
                                    }
                                    catch (NotSupportedException ex)
                                    {
                                        Console.WriteLine($"[Data Processor] The item couldn't be sent to the Alert Processor. {ex.Message}");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"[Data Processor] The item couldn't be processed. {ex.Message}");
                                }
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
