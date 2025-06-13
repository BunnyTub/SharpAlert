using System;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.RegexList;
using System.Linq;
using System.Threading;
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
                    if (SharpDataHistory.Count > QuickSettings.Instance.storedMaxSize)
                    {
                        // use first instead of last, otherwise, recent alerts will be forgotten
                        lock (SharpDataHistory) SharpDataHistory.Remove(SharpDataHistory.First());
                        ConsoleExt.WriteLine($"[Data Processor] Trimmed data history.");
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
                                ConsoleExt.WriteLine($"[Data Processor] {ex.Message}");
                                continue;
                            }
                            //if (relayItem is null) continue;
                        }
                        else
                        {
                            //ConsoleExt.WriteLine("[Data Processor] There are no items in the queue yet.");
                            continue;
                        }

                        lock (LocalDataQueue)
                        {
                            foreach (var relayItem in LocalDataQueue)
                            {
                                try
                                {
                                    if (Stop)
                                    {
                                        Stop = false;
                                        return;
                                    }

                                    ConsoleExt.WriteLine($"[Data Processor] Preparing to process -> {relayItem.Name}");

                                    string Replay = ReplayedAlertRegex.MatchOrDefault(relayItem.Data, "false");
                                    bool ReplayMode = false;

                                    if (Replay.ToLowerInvariant() == "true")
                                    {
                                        ConsoleExt.WriteLine("[Data Processor] Detected an alert in replay mode.");
                                        ReplayMode = true;
                                        relayItem.Data = relayItem.Data.Replace("<SharpAlertReplay>true</SharpAlertReplay>", "<SharpAlertReplay>false</SharpAlertReplay>");
                                    }

                                    lock (SharpDataHistory) SharpDataHistory.Add(relayItem);
                                    SharpDataQueue.Remove(relayItem);

                                    try
                                    {
                                        int Limit = 10;
                                        if (ap.AlertsProcessing >= Limit)
                                        {
                                            ConsoleExt.WriteLine($"[Data Processor] Processing limit reached. Waiting until the amount of alerts processing is under {Limit}.");
                                            while (ap.AlertsProcessing >= Limit)
                                            {
                                                Thread.Sleep(100);
                                            }
                                            ConsoleExt.WriteLine($"[Data Processor] The amount of alerts processing is now under {Limit}. Continuing work in progress.");
                                        }

                                        ThreadDrool.StartAndForget(() =>
                                        {
                                            //if (MessageBox.Show($"Process {relayItem.Name}?\r\n\r\n" +
                                            //    $"{relayItem.Data}",
                                            //    "SharpAlert",
                                            //    MessageBoxButtons.YesNo) == DialogResult.Yes)
                                            ConsoleExt.WriteLine($"[Data Processor] Waiting for processing -> {relayItem.Name}");
                                            ap.ProcessAlertItem(relayItem, ReplayMode, false);
                                        });

                                    }
                                    catch (NotSupportedException ex)
                                    {
                                        ConsoleExt.WriteLine($"[Data Processor] Failed ({ex.Message}) -> {relayItem.Name}");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    ConsoleExt.WriteLine($"[Data Processor] Failed ({ex.Message}) -> {relayItem.Name}");
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
                    ConsoleExt.WriteLine($"[Data Processor] {e.StackTrace} {e.Message}");
                }
            }
        }
    }
}
