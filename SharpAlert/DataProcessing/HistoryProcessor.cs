using System;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.RegexList;
using System.Linq;
using System.Threading;
using static SharpAlert.AlertComponents.AlertProcessor;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using SharpAlert.ProgramWorker;
using SharpAlert.AlertComponents;

namespace SharpAlert.DataProcessing
{
    internal class HistoryProcessor
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
            while (true)
            {
                try
                {
                    for (int i = 0; i < 60; i++)
                    {
                        if (Stop)
                        {
                            Stop = false;
                            return;
                        }
                        Thread.Sleep(1 * 1000);
                    }


                    if (SharpDataRelayedNamesHistory.Count > QuickSettings.Instance.storedMaxSize)
                    {
                        // use first instead of last, otherwise, recent alerts will be forgotten
                        lock (SharpDataRelayedNamesHistory) SharpDataRelayedNamesHistory.Remove(SharpDataRelayedNamesHistory.First());
                        Console.WriteLine($"[History Processor] Trimmed data history.");
                    }

                    if (Stop)
                    {
                        Stop = false;
                        return;
                    }

                    //if (QuickSettings.Instance.alertNoGUI) continue;

                    int alertIndex = 0;

                    lock (SharpDataRelayedNamesHistory)
                    {
                        lock (SharpDataHistory)
                        {
                            Console.WriteLine("[History Processor] Checking timestamps.");
                            string CompiledString = string.Empty;
                            bool Expired = false;
                            List<string> Names = new List<string>();
                            List<string> ExpiredNames = new List<string>();

                            lock (SharpDataRelayedNamesHistory)
                            {
                                foreach (string name in SharpDataRelayedNamesHistory)
                                {
                                    Names.Add(name);
                                }
                            }

                            foreach (string name in Names)
                            {
                                alertIndex++;
                                //Console.WriteLine($"[History Processor] {alertIndex} -> {name}");
                                try
                                {
                                    if (SharpDataHistory.Any(x => x.Name == name))
                                    {
                                        var historicItem = SharpDataHistory.FirstOrDefault(x => x.Name == name);
                                        if (historicItem == null)
                                        {
                                            SharpDataRelayedNamesHistory.Remove(name);
                                            continue;
                                        }

                                        var historicResult = ProcessHistoricItem(historicItem);
                                        if (historicResult.Item1)
                                        {
                                            SharpDataRelayedNamesHistory.Remove(name);
                                            ExpiredNames.Add(name);
                                            Console.WriteLine($"[History Processor] Alert {alertIndex} ({historicItem.Name}) is expired.");
                                            //expired,type,sent,effective,expiry,source
                                            DiscordWebhook.SendFormattedMessage(historicResult.Item6, $"Event type of {historicResult.Item2}, effective {historicResult.Item3}, has recently expired at {historicResult.Item5}.",
                                                "Expiry may not mean that the event is over completely.",
                                                $"-# Identifier(s): {historicItem.Name}");
                                            //CompiledString += $"Event type of {historicResult.Item2}, effective {historicResult.Item3}, has recently expired at {historicResult.Item4}.\x20";
                                            Expired = true;
                                        }
                                        else
                                        {
                                            //Console.WriteLine($"[History Processor] Alert {alertIndex} is not expired.");
                                        }
                                    }
                                    else
                                    {
                                        SharpDataRelayedNamesHistory.Remove(name);
                                        Console.WriteLine($"[History Processor] Alert {alertIndex} has been removed from the history.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"[History Processor] {ex.StackTrace} {ex.Message}");
                                }
                            }

                            if (Expired)
                            {
                                //CompiledString = CompiledString.Trim();
                                //if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                                //{
                                //    string FullNames = string.Empty;
                                    
                                //    foreach (string name in ExpiredNames)
                                //    {
                                //        FullNames += $"{name};\x20";
                                //    }

                                //    FullNames = FullNames.Trim().Substring(0, FullNames.Length - 1);
                                //    FullNames = FullNames.Substring(0, FullNames.Length - 1);

                                //    //DiscordWebhook.SendFormattedMessage(CompiledString,
                                //    //    "Expiry may not mean that the event is over completely.",
                                //    //    $"-# Identifier(s): {FullNames}");

                                //    //if (DiscordWebhook.SendFormattedMessage(CompiledString,
                                //    //    "Expiry may not mean that the event is over completely.",
                                //    //    $"-# Identifier(s): {FullNames}"))
                                //    //{
                                //    //    Notify.ShowNotification($"One or more alerts expired.",
                                //    //        "SharpAlert found expired alerts",
                                //    //        ToolTipIcon.Warning);
                                //    //    //AnyAlertRelayed = true;
                                //    //    //UsedDiscordHook = true;
                                //    //}
                                //    //else
                                //    //{
                                //    //    Notify.ShowNotification($"One or more alerts expired, but we couldn't say that through Discord.",
                                //    //        "SharpAlert found expired alerts",
                                //    //        ToolTipIcon.Warning);
                                //    //}
                                //}
                                //else
                                //{
                                //    //if (QuickSettings.Instance.alertNoGUI) continue;
                                //    //else
                                //    //{
                                //    //    if (!QuickSettings.Instance.showExpiryMessages) continue;
                                //    //    else
                                //    //    {
                                            
                                //    //    }
                                //    //}
                                //}
                            }
                            else
                            {
                                Console.WriteLine("[History Processor] No alerts are expired.");
                            }
                        }
                    }
                }
                catch (ThreadAbortException)
                {
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[History Processor] {ex.StackTrace} {ex.Message}");
                    //new ToppleForm($"{ex.Message} {ex.StackTrace}").ShowDialog();
                }
            }
        }

        /// <summary>
        /// Tests the input for expiry.
        /// </summary>
        /// <param name="relayItem"></param>
        /// <returns>True if the alert provided is expired. Also provides the alert type.</returns>
        public (bool, string, string, string, string, string) ProcessHistoricItem(SharpDataItem relayItem)
        {
            lock (AlertLock)
            {
                string Source = SourceRegex.Match(relayItem.Data).Groups[1].Value;
                Console.WriteLine($"[History Processor] Source: {Source}");

                string Sent = SentRegex.Match(relayItem.Data).Groups[1].Value;
                Console.WriteLine($"[History Processor] Sent: {Sent}");

                string Status = StatusRegex.Match(relayItem.Data).Groups[1].Value;
                Console.WriteLine($"[History Processor] Status: {Status}");

                string MsgType = MessageTypeRegex.Match(relayItem.Data).Groups[1].Value;
                Console.WriteLine($"[History Processor] Message Type: {MsgType}");

                MatchCollection infoMatches = InfoRegex.Matches(relayItem.Data);

                int infoProc = 0;

                foreach (Match infoMatch in infoMatches)
                {
                    infoProc++;
                    Console.WriteLine($"[History Processor] Processing info tag.");

                    try
                    {
                        string AlertInfo = $"{infoMatch.Groups[1].Value}";

                        string Effective = EffectiveRegex.MatchOrDefault(relayItem.Data, $"{DateTime.UtcNow.AddHours(-1):f}");
                        Console.WriteLine($"[History Processor] Effective: {Effective}");

                        string Expiry = ExpiresRegex.MatchOrDefault(relayItem.Data, $"Unknown Date Time");
                        Console.WriteLine($"[History Processor] Expires: {Expiry}");

                        string EventType = EventRegex.MatchOrDefault(AlertInfo, "Cautionary (Unknown Event)");
                        Console.WriteLine($"[History Processor] Event Type: {EventType}");

                        if (DateTime.Parse(Expiry, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal) <= DateTime.Now)
                        {
                            return (true,
                                EventType,
                                Sent,
                                Effective,
                                Expiry,
                                Source);
                        }
                        else
                        {
                            return (false,
                                EventType,
                                Sent,
                                Effective,
                                Expiry,
                                Source);
                        }
                    }
                    catch (Exception ex)
                    {
                        HaidaWorker.LogFault(ex);
                    }
                }

                return (true,
                    "Cautionary (Unknown Event)",
                    "Unknown Date Time",
                    "Unknown Date Time",
                    "Unknown Date Time",
                    string.Empty);
            }
        }
    }
}

