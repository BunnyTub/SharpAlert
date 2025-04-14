using System;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.RegexList;
using System.Linq;
using System.Threading;
using static SharpAlert.AlertProcessor;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using SharpAlert.Properties;
using System.Windows.Forms;

namespace SharpAlert
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

        private InfoForm info;

        public void ServiceRun()
        {
            info = new InfoForm();
            while (true)
            {
                try
                {
                    Thread.Sleep(60 * 1000);

                    if (SharpDataRelayedNamesHistory.Count > Settings.Default.storedMaxSize)
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

                    //if (Settings.Default.alertNoGUI) continue;

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
                                Console.WriteLine($"[History Processor] {alertIndex} -> {name}");
                                try
                                {
                                    if (SharpDataHistory.Any(x => x.Name == name))
                                    {
                                        var historicItem = SharpDataHistory.FirstOrDefault(x => x.Name == name);
                                        if (historicItem == null) continue;

                                        var historicResult = ProcessHistoricItem(historicItem);
                                        if (historicResult.Item1)
                                        {
                                            SharpDataRelayedNamesHistory.Remove(name);
                                            ExpiredNames.Add(name);
                                            Console.WriteLine($"[History Processor] Alert {alertIndex} ({historicItem.Name}) is expired.");
                                            //expired,type,sent,effective,expiry
                                            CompiledString += $"The alert {historicResult.Item2}, effective {historicResult.Item3}, has recently expired at {historicResult.Item4}.\x20";
                                            Expired = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"[History Processor] Alert {alertIndex} is not expired.");
                                        }
                                    }
                                    else
                                    {
                                        SharpDataRelayedNamesHistory.Remove(name);
                                        Console.WriteLine($"[History Processor] Alert {alertIndex} is no longer in the history.");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"[History Processor] {ex.StackTrace} {ex.Message}");
                                }
                            }

                            if (Expired)
                            {
                                CompiledString = CompiledString.Trim();
                                if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhook))
                                {
                                    string FullNames = string.Empty;
                                    
                                    foreach (string name in ExpiredNames)
                                    {
                                        FullNames += $"{name};\x20";
                                    }

                                    FullNames = FullNames.Trim().Substring(0, FullNames.Length - 1);
                                    FullNames = FullNames.Substring(0, FullNames.Length - 1);

                                    if (DiscordWebhook.SendFormattedMessage(CompiledString,
                                        "An alert expiring sometimes doesn't mean an alert is finished completely.",
                                        $"-# Identifier(s): {FullNames}"))
                                    {
                                        lock (notify)
                                        {
                                            notify.BalloonTipIcon = ToolTipIcon.Info;
                                            notify.BalloonTipTitle = $"SharpAlert found expired alerts";
                                            notify.BalloonTipText = "One or more alerts expired.";
                                            notify.ShowBalloonTip(5000);
                                        }
                                    }
                                    else
                                    {
                                        lock (notify)
                                        {
                                            notify.BalloonTipIcon = ToolTipIcon.Warning;
                                            notify.BalloonTipTitle = $"SharpAlert found expired alerts";
                                            notify.BalloonTipText = "One or more alerts expired, but it couldn't be sent through the webhook.";
                                            notify.ShowBalloonTip(5000);
                                        }
                                    }

                                    // Delay to prevent the webhook from being rate limited
                                    Thread.Sleep(2000);
                                }
                                else
                                {
                                    if (Settings.Default.alertNoGUI) continue;
                                    else
                                    {
                                        info.UpdateFields(CompiledString);
                                        info.ShowDialog();
                                    }
                                }
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
        public (bool, string, string, string, string) ProcessHistoricItem(SharpDataItem relayItem)
        {
            lock (AlertLock)
            {
                string Sent = SentRegex.Match(relayItem.Data).Groups[1].Value;

                Console.WriteLine($"Sent: {Sent}");

                string Status = StatusRegex.Match(relayItem.Data).Groups[1].Value;
                Console.WriteLine($"Status: {Status}");

                string MsgType = MessageTypeRegex.Match(relayItem.Data).Groups[1].Value;
                Console.WriteLine($"Message Type: {MsgType}");

                MatchCollection infoMatches = InfoRegex.Matches(relayItem.Data);

                int infoProc = 0;

                foreach (Match infoMatch in infoMatches)
                {
                    infoProc++;
                    Console.WriteLine($"[History Processor] Processing {infoProc} of {infoMatches.Count}.");

                    string AlertInfo = $"{infoMatch.Groups[1].Value}";

                    string Effective = EffectiveRegex.Match(relayItem.Data).Groups[1].Value;
                    Console.WriteLine($"Effective: {Effective}");

                    string Expiry = ExpiresRegex.Match(relayItem.Data).Groups[1].Value;
                    Console.WriteLine($"Expires: {Expiry}");

                    string EventType = EventRegex.Match(AlertInfo).Groups[1].Value;
                    Console.WriteLine($"Event Type: {EventType}");

                    if (DateTime.Parse(Expiry, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal) <= DateTime.Now)
                    {
                        return (true,
                            EventType,
                            Sent,
                            Effective,
                            Expiry);
                    }
                    else
                    {
                        return (false,
                            EventType,
                            Sent,
                            Effective,
                            Expiry);
                    }
                }

                return (true,
                    "Cautionary (Unknown Event)",
                    "Unknown Date Time",
                    "Unknown Date Time",
                    "Unknown Date Time");
            }
        }
    }
}
