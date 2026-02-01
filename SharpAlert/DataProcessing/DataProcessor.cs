using SharpAlert.AlertComponents;
using SharpAlert.AlertComponents.Dashboard;
using SharpAlert.ProgramWorker;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TinyJson;
using static SharpAlert.AlertComponents.AlertDisplayer;
using static SharpAlert.AlertComponents.AlertProcessor;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.ProgramWorker.NotificationWorker;
using static SharpAlert.RegexList;
using static SharpAlertPluginBase.AlertContents;

namespace SharpAlert.DataProcessing
{
    public partial class DataProcessor
    {
        private bool Stop = false;
        private bool StopCalled = false;

        public AlertProcessor ap = new();

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

        private static readonly object DiscordConfirmLockObject = new();
        public static readonly string ArchivePath = QuickSettings.ConfigDirPath + "\\Archive";

        internal static (AlertInfo info, DateTimeOffset date) LastAlertToBeRelayed = (new AlertInfo(), DateTimeOffset.MinValue);

        public void ServiceRun()
        {
            while (AllowThreadRestarts)
            {
                try
                {
                    if (QuickSettings.Instance.ArchivingSaveAllAlerts)
                    {
                        Thread.Sleep(100);

                        try
                        {
                            Directory.CreateDirectory(ArchivePath);

                            string[] files = Directory.GetFiles(ArchivePath);

                            foreach (string file in files)
                            {
                                try
                                {
                                    DateTime dt = File.GetCreationTimeUtc(file);

                                    if (DateTime.UtcNow - dt > TimeSpan.FromHours(48))
                                    {
                                        if (Path.HasExtension(file))
                                        {
                                            string extension = Path.GetExtension(file);

                                            if (extension != null)
                                            {
                                                if (extension == ".xml")
                                                {
                                                    File.Delete(file);
                                                    Console.WriteLine($"[Data Processor] Deleted old file from archive -> {Path.GetFileName(file)}");
                                                    if (!QuickSettings.Instance.ArchivingAggressiveProcessing) Thread.Sleep(50);
                                                }
                                            }
                                        }
                                    }
                                    else continue;
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"[Data Processor] Could not delete an alert from disk. {ex.Message}");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Data Processor] {ex.Message}");
                        }

                        lock (SharpDataHistory)
                        {
                            if (SharpDataHistory.Count != 0)
                            {
                                foreach (SharpDataItem item in SharpDataHistory)
                                {
                                    string ItemName = string.Join("_", item.Name.Split(Path.GetInvalidFileNameChars()));

                                    try
                                    {
                                        string AlertPath = $"{ArchivePath}\\{ItemName}.xml";
                                        if (File.Exists(AlertPath)) continue;
                                        File.WriteAllText(AlertPath, item.Data);

                                        Console.WriteLine($"[Data Processor] Wrote alert to file on disk -> {Path.GetFileName(AlertPath)}");
                                        if (!QuickSettings.Instance.ArchivingAggressiveProcessing) Thread.Sleep(100);
                                    }
                                    catch (Exception ex)
                                    {
                                        Console.WriteLine($"[Data Processor] Could not read/write an alert to disk. {ex.Message}");
                                    }
                                }
                            }
                        }

                        if (!QuickSettings.Instance.ArchivingAggressiveProcessing) Thread.Sleep(1000);
                    }
                    else Thread.Sleep(500);

                    // Trim history for memory saving
                    if (SharpDataHistory.Count > QuickSettings.Instance.storedMaxSize)
                    {
                        // use first instead of last, otherwise, recent alerts will be forgotten
                        lock (SharpDataHistory) SharpDataHistory.Remove(SharpDataHistory.First());
                        Console.WriteLine($"[Data Processor] Trimmed data history.");
                    }

                    List<SharpDataItem> LocalDataQueue = [];

                    //SharpDataItem relayItem = null;

                    if (Stop)
                    {
                        Stop = false;
                        return;
                    }

                    if (QuickSettings.Instance.PauseDataProcessing) continue;

                    lock (SharpDataQueue)
                    {
                        if (SharpDataQueue.Count != 0)
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
                                    if (Stop)
                                    {
                                        Stop = false;
                                        return;
                                    }

                                    Console.WriteLine($"[Data Processor] Preparing to process -> {relayItem.Name}");

                                    string Replay = ReplayedAlertRegex.MatchOrDefault(relayItem.Data, "false");
                                    bool ReplayMode = false;

                                    if (Replay.Equals("true", StringComparison.InvariantCultureIgnoreCase))
                                    {
                                        Console.WriteLine("[Data Processor] Detected an alert in replay mode.");
                                        ReplayMode = true;
                                        relayItem.Data = relayItem.Data.Replace("<SharpAlertReplay>true</SharpAlertReplay>", "<SharpAlertReplay>false</SharpAlertReplay>");
                                    }

                                    lock (SharpDataHistory) SharpDataHistory.Add(relayItem);
                                    SharpDataQueue.Remove(relayItem);

                                    try
                                    {
                                        int Limit = 15;
                                        if (ap.AlertsProcessing >= Limit)
                                        {
                                            Console.WriteLine($"[Data Processor] Processing limit reached. Waiting until the amount of alerts processing is under {Limit}.");
                                            while (ap.AlertsProcessing >= Limit)
                                            {
                                                Thread.Sleep(50);
                                            }
                                            Console.WriteLine($"[Data Processor] The amount of alerts processing is now under {Limit}. Continuing work in progress.");
                                        }

                                        ThreadDrool.StartAndForget(() =>
                                        {
                                            //if (MessageBox.Show($"Process {relayItem.Name}?\r\n\r\n" +
                                            //    $"{relayItem.Data}",
                                            //    "SharpAlert",
                                            //    MessageBoxButtons.YesNo) == DialogResult.Yes)
                                            Console.WriteLine($"[Data Processor] Waiting for processing -> {relayItem.Name}");
                                            AlertInfo info = ap.ProcessAlertItem(relayItem, ReplayMode, false);
                                            Console.WriteLine($"[Data Processor] Finished processing -> {relayItem.Name}");

                                            if (string.IsNullOrWhiteSpace(info.AlertDiscardReason))
                                            {
                                                try
                                                {
                                                    Console.WriteLine($"[Data Processor] To be relayed -> {relayItem.Name}");

                                                    bool CalledWebhookFunction = false;
                                                    bool DialogCanAppear = true;

                                                    foreach (var plug in PluginManager.Plugins)
                                                    {
                                                        if (!plug.AlertTBR(info.ToJson()))
                                                        {
                                                            throw new Exception($"The plugin \"{plug.FriendlyName}\" declined the relay request for \"{relayItem.Name}\".");
                                                        }
                                                    }

                                                    LastAlertToBeRelayed = (info, DateTimeOffset.UtcNow);

                                                    DashboardManager.AddNewAlertToDashboard(info);

                                                    CallManager.MakeAlertCall(info);

                                                    if (ReplayMode)
                                                    {
                                                        Notify.ShowNotification("This alert has been sent again via replay mode.",
                                                            info.AlertEventType,
                                                            ToolTipIcon.Info);
                                                    }

                                                    if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                                                    {
                                                        CalledWebhookFunction = true;

                                                        DialogResult result = DialogResult.Yes;

                                                        if (QuickSettings.Instance.DiscordWebhookConfirmAlerts)
                                                        {
                                                            lock (DiscordConfirmLockObject)
                                                            {
                                                                ManualAlertRelayForm mar = new();
                                                                mar.UpdateFields(relayItem.Name, info.AlertEventType, info.AlertIntroText, info.AlertBodyText, info.AlertURL, string.Empty, string.Empty, info.AlertMessageType);
                                                                mar.ShowDialog();
                                                                result = mar.DialogResult;
                                                                mar.Dispose();
                                                            }
                                                        }

                                                        if (result != DialogResult.No)
                                                        {
                                                            DateTime sentDate;
                                                            try
                                                            {
                                                                sentDate = DateTime.Parse(info.AlertSentDate, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                                sentDate = DateTime.UtcNow;
                                                            }

                                                            DateTime expiresDate;
                                                            try
                                                            {
                                                                expiresDate = DateTime.Parse(info.AlertExpiryDate, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                                                            }
                                                            catch (Exception ex)
                                                            {
                                                                Console.WriteLine(ex.Message);
                                                                expiresDate = DateTime.UtcNow.AddHours(1);
                                                            }

                                                            int color = 16777215;

                                                            if (info.AlertMessageType.ToLowerInvariant().Contains("cancel"))
                                                            {
                                                                color = 32767;
                                                            }
                                                            else
                                                            {
                                                                switch (info.AlertSeverity.ToLowerInvariant())
                                                                {
                                                                    case "extreme":
                                                                    case "severe":
                                                                        color = 16711680;
                                                                        break;
                                                                    case "moderate":
                                                                    case "minor":
                                                                        color = 16744192;
                                                                        break;
                                                                }
                                                            }

                                                            string LocationList = string.Empty;
                                                            foreach (string Location in info.AlertFriendlyLocations)
                                                            {
                                                                foreach (string loc in Location.Split(';')) LocationList += $"{loc.Trim()}; ";
                                                            }

                                                            //string EventsList = string.Empty;
                                                            //foreach (string Event in AllEvents)
                                                            //{
                                                            //    EventsList += $"{Regex.Replace(Event.ToLowerInvariant(), @"(^\w)|(\s\w)", m => m.Value.ToUpperInvariant())}, ";
                                                            //}
                                                            //EventsList = EventsList.Substring(0, EventsList.Length - 2);

                                                            string ProcessedEvent = $"{UpperFirstRegex().Replace(info.AlertEventType, m => m.Value.ToUpperInvariant())}";

                                                            LocationList = LocationList.Trim().Substring(0, LocationList.Length - 2).Trim();
                                                            if (LocationList.EndsWith(';')) LocationList = LocationList.Substring(0, LocationList.Length - 1);

                                                            string CompiledMessage = $"{ProcessedEvent} | Location(s): {LocationList}"; // \r\n-# Process Time: {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms
                                                            if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhookAppend)) CompiledMessage += "\r\n" + $"{DiscordWebhook.GetDiscordWebhookURLFromSourceName(info.AlertSource).Append}";
                                                            //DiscordWebhook.SendUnformattedMessage(CompiledMessage);

                                                            //DiscordWebhook.SendEmbeddedMessage(info.AlertSource,
                                                            //    CompiledMessage,
                                                            //    $"{info.AlertSeverity} Emergency {info.AlertMessageType.First().ToString().ToUpper() + info.AlertMessageType.Substring(1)}",
                                                            //    info.AlertIntroText,
                                                            //    info.AlertBodyText, //+ $"\r\n\r\n||${LocationList}$||",
                                                            //    info.AlertURL,
                                                            //    relayItem.Name,
                                                            //    new List<string> { info.AlertAudioURL },
                                                            //    new List<string> { info.AlertImageURL },
                                                            //    color);

                                                            DiscordWebhook.SendEmbeddedMessage(info.AlertSource,
                                                                CompiledMessage,
                                                                ProcessedEvent,
                                                                info.AlertIntroText,
                                                                info.AlertBodyText, //+ $"\r\n\r\n||${LocationList}$||",
                                                                info.AlertURL,
                                                                relayItem.Name,
                                                                [info.AlertAudioURL],
                                                                [info.AlertAudioDeref],
                                                                [info.AlertImageURL],
                                                                color);

                                                            Notify.ShowNotification($"The alert was sent {sentDate:g}. The alert expires {expiresDate:g}.",
                                                                info.AlertEventType,
                                                                ToolTipIcon.Info);

                                                            //if (DiscordWebhook.SendEmbeddedMessage(CompiledMessage,
                                                            //    $"{info.AlertSeverity} Emergency {info.AlertMessageType.First().ToString().ToUpper() + info.AlertMessageType.Substring(1)}",
                                                            //    info.AlertIntroText,
                                                            //    info.AlertBodyText + $"\r\n\r\n||${LocationList}$||",
                                                            //    info.AlertURL,
                                                            //    new List<string> { info.AlertAudioURL },
                                                            //    new List<string> { info.AlertImageURL },
                                                            //    color))
                                                            //{
                                                            //    Notify.ShowNotification($"The alert was sent {sentDate:g}. The alert expires {expiresDate:g}.",
                                                            //        info.AlertEventType,
                                                            //        ToolTipIcon.Info);
                                                            //    //AnyAlertRelayed = true;
                                                            //    //UsedDiscordHook = true;
                                                            //}
                                                            //else
                                                            //{
                                                            //    Notify.ShowNotification($"The alert was unable to be relayed to Discord.",
                                                            //        info.AlertEventType,
                                                            //        ToolTipIcon.Warning);
                                                            //    //AnyAlertRelayed = true;
                                                            //    //UsedDiscordHook = true;
                                                            //}
                                                        }
                                                    }

                                                    if (CalledWebhookFunction)
                                                    {
                                                        if (!QuickSettings.Instance.DiscordWebhookRelayLocally) DialogCanAppear = false;
                                                    }

                                                    if (DialogCanAppear)
                                                    {
                                                        ThreadDrool.StartAndForget(() =>
                                                        {
                                                            RelayWindow(relayItem.Name, info.AlertEventType,
                                                                new AlertTextClass
                                                                {
                                                                    Intro = info.AlertIntroText,
                                                                    Body = info.AlertBodyText
                                                                }, info.AlertURL, info.AlertMessageType, info.AlertSeverity, [info.AlertAudioURL], [info.AlertAudioDeref], [info.AlertImageURL]);
                                                        });
                                                    }

                                                    //AnyAlertRelayed = true;
                                                    SharpDataRelayedNamesHistory.Add(relayItem.Name);
                                                }
                                                catch (Exception ex)
                                                {
                                                    Console.WriteLine($"[Data Processor] Couldn't relay. {ex.Message}");
                                                }
                                                finally
                                                {
                                                    Console.WriteLine($"[Data Processor] Finished relaying.");
                                                }
                                            }
                                            else
                                            {
                                                Console.WriteLine($"[Data Processor] \"{relayItem.Name}\" was discarded. {info.AlertDiscardReason}");
                                            }
                                        });

                                    }
                                    catch (NotSupportedException ex)
                                    {
                                        Console.WriteLine($"[Data Processor] Failed ({ex.Message}) -> {relayItem.Name}");
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"[Data Processor] Failed ({ex.Message}) -> {relayItem.Name}");
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

        [GeneratedRegex(@"(^\w)|(\s\w)")]
        private static partial Regex UpperFirstRegex();
    }
}

