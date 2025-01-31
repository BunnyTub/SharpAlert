using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.Program;
using static SharpAlert.RegexList;

namespace SharpAlert
{
    public static class AlertProcessor
    {
        public static readonly object AlertLock = new object();
        public static int AlertsQueued
        {
            get;
            private set;
        } = 0;
        
        public static int AlertsRelayed
        {
            get;
            private set;
        } = 0;

        public enum SeverityLevel
        {
            Unknown,
            Minor,
            Moderate,
            Severe,
            Extreme
        }

        /// <summary>
        /// Processes and relays the alert item.
        /// </summary>
        /// <param name="relayItem">The item to be processed.</param>
        public static void ProcessAlertItem(SharpDataItem relayItem, bool ReplayMode)
        {
            lock (AlertLock)
            {
                //MatchCollection alertMatches = AlertRegex.Matches(relayItem.Data);

                bool AnyAlertRelayed = false;
                bool UsedDiscordHook = false;

                string Sent = SentRegex.Match(relayItem.Data).Groups[1].Value;
                Console.WriteLine($"Sent: {Sent}");

                string Status = StatusRegex.Match(relayItem.Data).Groups[1].Value;
                Console.WriteLine($"Status: {Status}");

                string MsgType = MessageTypeRegex.Match(relayItem.Data).Groups[1].Value;
                Console.WriteLine($"Message Type: {MsgType}");

                Console.WriteLine($"Replay (internal flag | if any): {ReplayMode}");

                MatchCollection urgencyMatches = UrgencyRegex.Matches(relayItem.Data);
                MatchCollection infoMatches = InfoRegex.Matches(relayItem.Data);
                bool final = false;

                for (int ii = 0; ii < infoMatches.Count; ii++)
                {
                    try
                    {
                        if (ProcessInfoX(relayItem.Data, MsgType, infoMatches[ii].Groups[1].Value, urgencyMatches[ii].Groups[1].Value))
                        {
                            final = true;
                            break;
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"[Alert Processor] An incompatible or damaged XML was read, and can't be processed further. {e.Message}");
                    }
                }

                if (!final)
                {
                    Console.WriteLine($"[Alert Processor] Alert discarded due to user preferences or invalidity.");
                    return;
                }

                int infoProc = 0;

                List<string> AllEvents = new List<string>();
                List<string> AllLocations = new List<string>();
                SeverityLevel MaxSeverity = SeverityLevel.Unknown;

                foreach (Match infoMatch in infoMatches)
                {
                    infoProc++;
                    Console.WriteLine($"[Alert Processor] Processing {infoProc} of {infoMatches.Count}");

                    //string AlertInfo = $"<info>{infoMatch.Groups[1].Value}</info>";
                    string AlertInfo = $"{infoMatch.Groups[1].Value}";

                    string Effective = EffectiveRegex.Match(relayItem.Data).Groups[1].Value;
                    Console.WriteLine($"Effective: {Effective}");

                    string Expiry = ExpiresRegex.Match(relayItem.Data).Groups[1].Value;
                    Console.WriteLine($"Expires: {Expiry}");

                    string EventType = EventRegex.Match(AlertInfo).Groups[1].Value;
                    Console.WriteLine($"Event Type: {EventType}");

                    string Urgency = UrgencyRegex.Match(AlertInfo).Groups[1].Value;
                    Console.WriteLine($"Urgency: {Urgency}");

                    string Severity = SeverityRegex.Match(AlertInfo).Groups[1].Value;
                    Console.WriteLine($"Severity: {Severity}");

                    string URL = WebRegex.Match(AlertInfo).Groups[1].Value;
                    if (string.IsNullOrWhiteSpace(URL)) URL = string.Empty;
                    Console.WriteLine($"Associated URL (if any): {URL}");

                    if (!ReplayMode)
                    {
                        if (DateTime.Parse(Expiry, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal) <= DateTime.Now)
                        {
                            Console.WriteLine($"[Alert Processor] Alert discarded because it has expired.");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"[Alert Processor] Expiry check skipped due to replay mode.");
                    }

                    bool EventBlacklisted = false;

                    if (ProcessParameterX(AlertInfo) &&
                        ProcessAlertX(Status, MsgType, Severity))
                    {
                        foreach (string EventName in Settings.Default.EnforceEventBlacklist)
                        {
                            if (EventType.ToLower() == EventName.ToLower())
                            {
                                EventBlacklisted = true;
                                break;
                            }
                        }

                        if (EventBlacklisted)
                        {
                            Console.WriteLine($"[Alert Processor] Alert discarded due to blacklist (event).");
                            continue;
                        }

                        // all checks passed

                        string AlertText = BroadcastInfo(AlertInfo, MsgType, Sent, ReplayMode);
                        List<string> LocationsText = CompiledLocations(AlertInfo);

                        if (!AllEvents.Contains(EventType)) AllEvents.Add(EventType);
                        foreach (string location in LocationsText)
                        {
                            if (!AllLocations.Contains(location)) AllLocations.Add(location);
                        }

                        if (Enum.TryParse<SeverityLevel>(Severity, out var newSeverity))
                        {
                            if (newSeverity > MaxSeverity)
                            {
                                MaxSeverity = newSeverity;
                            }
                        }

                        try
                        {
                            if (ReplayMode)
                            {
                                notify.BalloonTipIcon = ToolTipIcon.Info;
                                notify.BalloonTipTitle = $"{Sent}";
                                notify.BalloonTipText = $"An alert with the event {EventType} was sent in replay mode.";
                                notify.ShowBalloonTip(5000);
                            }

                            //USE NOTIFYICON IF NOT QUEUEING DIALOG
                            if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhook))
                            {
                                UsedDiscordHook = true;

                                DateTime sentDate;
                                try
                                {
                                    sentDate = DateTime.Parse(Sent, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    sentDate = DateTime.Now;
                                }

                                DateTime expiresDate;
                                try
                                {
                                    expiresDate = DateTime.Parse(Expiry, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                                }
                                catch (Exception e)
                                {
                                    Console.WriteLine(e.Message);
                                    expiresDate = DateTime.Now.AddHours(1);
                                }

                                string AlertCompiled;
                                if (Settings.Default.weaOnly) AlertCompiled = "## WIRELESS EMERGENCY ALERT\r\n";
                                else AlertCompiled = "# EMERGENCY ALERT\r\n";
                                AlertCompiled += $"**This {EventType} was sent on {sentDate:f}. It will expire on {expiresDate:f}.**\r\n\r\n" +
                                    "## Alert Message\r\n" +
                                    $"{AlertText}";

                                //if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhookAppend))
                                //{
                                //    AlertCompiled += $"\r\n\r\n{Settings.Default.DiscordWebhookAppend}";
                                //}

                                if (AlertToWebhook.SendUnformattedMessage(AlertCompiled, Settings.Default.DiscordWebhook))
                                {
                                    notify.BalloonTipIcon = ToolTipIcon.Info;
                                    notify.BalloonTipTitle = $"{Sent}";
                                    notify.BalloonTipText = $"An alert with the event {EventType} was issued.";
                                    notify.ShowBalloonTip(5000);
                                    AnyAlertRelayed = true;
                                }
                                else
                                {
                                    notify.BalloonTipIcon = ToolTipIcon.Warning;
                                    notify.BalloonTipTitle = $"{Sent}";
                                    notify.BalloonTipText = $"An alert with the event {EventType} was issued, but it couldn't be sent through the webhook.";
                                    notify.ShowBalloonTip(5000);
                                }

                                // Delay to prevent the webhook from being rate limited
                                Thread.Sleep(2000);
                            }
                            else
                            {
                                ThreadPool.QueueUserWorkItem(_ =>
                                {
                                    AlertsQueued++;

                                    Console.WriteLine("[Alert Processor] Dialog queued.");

                                    lock (AlertValuesLock)
                                    {
                                        Console.WriteLine("[Alert Processor] Dialog queue locked.");
                                        while (AlertDisplaying)
                                        {
                                            Monitor.Wait(AlertValuesLock);
                                        }
                                        Console.WriteLine("[Alert Processor] Dialog queue unlocked.");
                                    }

                                    AlertDisplaying = true;

                                    AlertsQueued--;

                                    if (Settings.Default.alertFullscreen)
                                    {
                                        // attaches to the idle window if compatibility mode is enabled.
                                        if (Settings.Default.alertFullscreenIdle & idle != null & Settings.Default.alertCompatibilityMode)
                                        {
                                            //bool AlertFinished = false;

                                            // invoke IdleContainer to use, otherwise, you'll get an InvalidOperationException.
                                            TeleAlertForm af = null;

                                            idle.IdleContainer.Invoke(new MethodInvoker(delegate
                                            {
                                                af = new TeleAlertForm(EventType, AlertText, URL, ReplayMode)
                                                {
                                                    TopLevel = false
                                                };

                                                idle.IdleContainer.Controls.Add(af);
                                                Console.WriteLine("[Alert Processor] Added dialog to idle window.");
                                                //AlertFinished = true;
                                            }));
                                            
                                            af.ShowAndWait();
                                            
                                            idle.IdleContainer.Invoke(new MethodInvoker(delegate
                                            {
                                                idle.IdleContainer.Controls.Remove(af);
                                                Console.WriteLine("[Alert Processor] Removed dialog from idle window.");
                                            }));

                                            //while (!AlertFinished)
                                            //{
                                            //    Thread.Sleep(100);
                                            //}
                                        }
                                        else
                                        {
                                            using (TeleAlertForm af = new TeleAlertForm(EventType, AlertText, URL, ReplayMode))
                                            {
                                                af.ShowDialog();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        using (AlertForm af = new AlertForm(EventType, AlertText, URL))
                                        {
                                            af.ShowDialog();
                                        }
                                    }

                                    sound.Stop();
                                    engine.SpeakAsyncCancelAll();

                                    lock (AlertValuesLock)
                                    {
                                        AlertDisplaying = false;
                                        Monitor.PulseAll(AlertValuesLock);
                                    }

                                    Console.WriteLine("[Alert Processor] Dialog released.");
                                });
                            }

                            AnyAlertRelayed = true;
                        }
                        catch (NotSupportedException ex)
                        {
                            Console.WriteLine($"[Alert Processor] Couldn't queue dialog. {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"[Alert Processor] Couldn't relay alert. {ex.Message}");
                        }

                        if (AnyAlertRelayed) AlertsRelayed++;
                    }
                    else
                    {
                        Console.WriteLine($"[Alert Processor] Alert discarded either due to user preferences or invalidity.");
                    }
                }

                if (AnyAlertRelayed & UsedDiscordHook)
                {
                    if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhookAppend))
                    {
                        string EventsList = string.Empty;
                        foreach (string Event in AllEvents)
                        {
                            EventsList += $"{Regex.Replace(Event.ToLower(), @"(^\w)|(\s\w)", m => m.Value.ToUpper())}, ";
                        }
                        EventsList = EventsList.Substring(0, EventsList.Length - 2) + ".";
                        
                        string LocationList = string.Empty;
                        foreach (string Location in AllLocations)
                        {
                            LocationList += $"{Location}, ";
                        }
                        LocationList = LocationList.Substring(0, LocationList.Length - 2) + ".";
                        AlertToWebhook.SendUnformattedMessage($"{MaxSeverity} Emergency Alert | Event(s): {EventsList} | Location(s): {LocationList}\r\n" + Settings.Default.DiscordWebhookAppend, Settings.Default.DiscordWebhook);
                        Console.WriteLine("[Alert Processor] Appended to Discord webhook text.");
                    }
                }

                Console.WriteLine("[Alert Processor] Processed all available entries.");
            }
        }

        /// <summary>
        /// Processes the info tag, then returns a boolean depending on the configuration.
        /// </summary>
        /// <param name="InfoX">The info XML data to process.</param>
        /// <param name="MsgType">The type of message.</param>
        /// <param name="Severity">The severity of the message.</param>
        /// <param name="Urgency">The urgency of the message.</param>
        /// <returns>Returns True if the caller should continue.</returns>
        public static bool ProcessInfoX(string InfoX, string MsgType, string Severity, string Urgency)
        {
            Console.WriteLine("Processing InfoX.");
            bool Final = false;

            // MsgType:
            // Alert
            // Update
            // Cancel

            try
            {
                bool var1; // Severity
                bool var2; // Urgency
                bool var3; // MsgType

                switch (Severity.ToLower())
                {
                    case "extreme":
                        var1 = Settings.Default.severityExtreme;
                        break;
                    case "severe":
                        var1 = Settings.Default.severitySevere;
                        break;
                    case "moderate":
                        var1 = Settings.Default.severityModerate;
                        break;
                    case "minor":
                        var1 = Settings.Default.severityMinor;
                        break;
                    case "unknown":
                        var1 = Settings.Default.severityUnknown;
                        break;
                    default:
                        var1 = Settings.Default.severityUnknown;
                        break;
                }

                switch (Urgency.ToLower())
                {
                    case "immediate":
                        var2 = Settings.Default.urgencyImmediate;
                        break;
                    case "expected":
                        var2 = Settings.Default.urgencyExpected;
                        break;
                    case "future":
                        var2 = Settings.Default.urgencyFuture;
                        break;
                    case "past":
                        var2 = Settings.Default.urgencyPast;
                        break;
                    case "unknown":
                        var2 = Settings.Default.urgencyUnknown;
                        break;
                    default:
                        var2 = false;
                        break;
                }

                switch (MsgType.ToLower())
                {
                    case "alert":
                        var3 = Settings.Default.messageTypeAlert;
                        break;
                    case "update":
                        var3 = Settings.Default.messageTypeUpdate;
                        break;
                    case "cancel":
                        var3 = Settings.Default.messageTypeCancel;
                        break;
                    case "test":
                        var3 = Settings.Default.messageTypeTest;
                        break;
                    default:
                        var3 = false;
                        break;

                }

                if (var1 && var2 && var3)
                {
                    Final = true;
                    Console.WriteLine("Severity, urgency, and message type, passed all checks.");
                }
                else
                {
                    Console.WriteLine("Severity, urgency, and message type, did not pass all checks.\r\n" +
                        $"Severity = {var1}\r\n" +
                        $"Urgency = {var2}\r\n" +
                        $"MsgType = {var3}");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Severity, urgency, and message type, did not pass all checks, and completed with one or more errors.");
                Final = false;
            }

            // do something with LanguageRegex

            if (Final)
            {
                bool LocationsMatch = false;

                if (Settings.Default.AllowedSAMELocations_Geocodes.Count == 0 &&
                    Settings.Default.AllowedUGCLocations_Geocodes.Count == 0)
                {
                    // if no locations are found, assume all locations are valid
                    Console.WriteLine("Any locations are allowed.");
                    return true;
                }

                // SAME
                if (Settings.Default.AllowedSAMELocations_Geocodes.Count != 0)
                {
                    try
                    {
                        MatchCollection matches = GeocodeSpecificAreaMessageEncodingRegex.Matches(InfoX);
                        bool GeoMatch = false;
                        foreach (Match match in matches)
                        {
                            string geocode = match.Groups[1].Value;
                            if (Settings.Default.AllowedSAMELocations_Geocodes.Contains(geocode))
                            {
                                GeoMatch = true;
                                break;
                            }
                        }

                        if (GeoMatch)
                        {
                            LocationsMatch = true;
                            Console.WriteLine("One or more SAME locations were matched.");
                        }
                        else
                        {
                            Console.WriteLine("No locations matched the SAME list.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Data Processor] {ex.Message}");
                    }
                }
                
                // UGC
                if (Settings.Default.AllowedUGCLocations_Geocodes.Count != 0)
                {
                    try
                    {
                        MatchCollection matches = GeocodeUniversalGeographicCodeRegex.Matches(InfoX);
                        bool GeoMatch = false;
                        foreach (Match match in matches)
                        {
                            string geocode = match.Groups[1].Value;
                            if (Settings.Default.AllowedUGCLocations_Geocodes.Contains(geocode))
                            {
                                GeoMatch = true;
                                break;
                            }
                        }

                        if (GeoMatch)
                        {
                            LocationsMatch = true;
                            Console.WriteLine("One or more UGC locations were matched.");
                        }
                        else
                        {
                            Console.WriteLine("No locations matched the UGC list.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Data Processor] {ex.Message}");
                    }
                }

                if (!LocationsMatch)
                {
                    Console.WriteLine("No locations matched.");
                }

                return LocationsMatch;
            }
            else return false;
        }

        /// <summary>
        /// Processes the parameter tag, then returns a boolean depending on the configuration.
        /// </summary>
        /// <param name="ParameterX">The parameter XML data to process.</param>
        /// <returns>Returns True if the caller should continue.</returns>
        public static bool ProcessParameterX(string ParameterX)
        {
            Console.WriteLine("Processing ParemeterX.");

            if (Settings.Default.weaOnly)
            {
                var WEAHandle = WEAHandlingRegex.Match(ParameterX);

                if (WEAHandle.Success)
                {
                    switch (WEAHandle.Value)
                    {
                        case "Imminent Threat":
                            return true;
                        default:
                            return false;
                    }
                }
                else return false;
            }
            else return true;
        }

        /// <summary>
        /// Processes the alert tag, then returns a boolean depending on the configuration.
        /// </summary>
        /// <param name="Status">The status of the message.</param>
        /// <param name="MsgType">The overall message type.</param>
        /// <param name="Severity">The severity of the message.</param>
        /// <returns>Returns True if the caller should continue.</returns>
        public static bool ProcessAlertX(string Status, string MsgType, string Severity)
        {
            Console.WriteLine("Processing AlertX.");

            bool Final = false;

            // Status:
            // Test
            // Actual

            switch (Status.ToLower())
            {
                case "test":
                    if (!Settings.Default.statusTest) return false;
                    break;
                case "actual":
                    if (!Settings.Default.statusActual) return false;
                    break;
                default:
                    break;
            }

            // Severity:
            // Extreme
            // Severe
            // Moderate
            // Minor
            // Unknown

            // MsgType:
            // Alert
            // Update
            // Cancel

            {
                try
                {
                    bool var1; // Severity
                    bool var2; // MsgType

                    switch (Severity.ToLower())
                    {
                        case "extreme":
                            var1 = Settings.Default.severityExtreme;
                            break;
                        case "severe":
                            var1 = Settings.Default.severitySevere;
                            break;
                        case "moderate":
                            var1 = Settings.Default.severityModerate;
                            break;
                        case "minor":
                            var1 = Settings.Default.severityMinor;
                            break;
                        case "unknown":
                            var1 = Settings.Default.severityUnknown;
                            break;
                        default:
                            var1 = Settings.Default.severityUnknown;
                            break;
                    }

                    switch (MsgType.ToLower())
                    {
                        case "alert":
                            var2 = Settings.Default.messageTypeAlert;
                            break;
                        case "update":
                            var2 = Settings.Default.messageTypeUpdate;
                            break;
                        case "cancel":
                            var2 = Settings.Default.messageTypeCancel;
                            break;
                        case "test":
                            var2 = Settings.Default.messageTypeTest;
                            break;
                        default:
                            var2 = false;
                            break;
                    }

                    if (var1 && var2)
                    {
                        Final = true;
                    }
                }
                catch (Exception)
                {
                    Final = false;
                }
            }

            // do something with LanguageRegex

            if (Final)
            {
                //var WEAHandle = WEAHandlingRegex.Match(AlertX);

                //if (WEAHandle.Success)
                //{
                //    switch (WEAHandle.Value)
                //    {
                //        case "Imminent Threat":
                //            break;
                //        default:
                //            return false;
                //    }
                //}
                return true;
            }
            else return false;
        }

        /// <summary>
        /// Processes the info tag, then returns a message body.
        /// </summary>
        /// <param name="InfoData">The info XML data to process.</param>
        /// <param name="MsgType">The overall message type.</param>
        /// <param name="Sent">The date and time the message was sent.</param>
        /// <returns>Returns a compiled message body.</returns>
        public static string BroadcastInfo(string InfoData, string MsgType, string Sent, bool Replay)
        {
            string BroadcastText = string.Empty;

            string SentenceAppendEnd(string value)
            {
                value = value.Trim();

                if (string.IsNullOrEmpty(value))
                {
                    return string.Empty;
                }

                if (value.EndsWith(".") || value.EndsWith("!") || value.EndsWith(","))
                {
                    return value.Substring(0, value.Length - 1) + ".";
                }
                else return value += ".";
            }

            string SentenceAppendSpace(string value)
            {
                value = value.Trim();
                if (string.IsNullOrWhiteSpace(value)) return string.Empty;
                else return value += "\x20";
            }

            string SentencePuncuationCorrection(string value)
            {
                value = value.Trim();
                while (value.EndsWith("\x20.") || value.EndsWith("\x20!") || value.EndsWith("\x20,"))
                {
                    value = value.Substring(0, value.Length - 1);
                }
                value = value.Replace("...", ",").Replace("..", ".");
                return value = SentenceAppendEnd(value.Substring(0, value.Length - 1));
            }

            string TimeCorrection(string value)
            {
                //Regex TimeCorrectionRegex = new Regex(@"\b(\d{1,4})\s*(AM|PM)\b", RegexOptions.IgnoreCase);

                return TimeCorrectionRegex.Replace(value, timeMatch =>
                {
                    string timePart = timeMatch.Groups[1].Value.PadLeft(4, '0');
                    string meridian = timeMatch.Groups[2].Value.ToUpper();

                    return DateTime.ParseExact(timePart, "hhmm", CultureInfo.InvariantCulture)
                    .ToString("hh:mm tt", CultureInfo.InvariantCulture);
                });
            }

            if (Replay) BroadcastText += SentenceAppendSpace($"This alert was sent in replay mode by SharpAlert, on {DateTime.UtcNow:f} Coordinated Universal Time.");

            string issue = "issued";
            string update = "updated";
            string cancel = "cancelled";

            string MsgPrefix;
            switch (MsgType.ToLower())
            {
                case "alert":
                    MsgPrefix = issue;
                    break;
                case "update":
                    MsgPrefix = update;
                    break;
                case "cancel":
                    MsgPrefix = cancel;
                    break;
                default:
                    MsgPrefix = "issued";
                    break;
            }

            DateTime sentDate;
            try
            {
                sentDate = DateTime.Parse(Sent, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                sentDate = DateTime.UtcNow;
            }

            DateTime effectiveDate;
            try
            {
                effectiveDate = DateTime.Parse(Sent, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                effectiveDate = DateTime.UtcNow;
            }

            DateTime expiryDate;
            try
            {
                expiryDate = DateTime.Parse(Sent, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                expiryDate = DateTime.UtcNow.AddHours(1);
            }

            //DateTime sentDate = DateTime.Parse(Sent, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal).ToUniversalTime();

            string TimeZoneName = "Unknown Time Zone";
            TimeZoneName = "Coordinated Universal Time";

            string SentFormatted = $"{sentDate:HH:mm} {TimeZoneName}, {sentDate:MMMM dd}, {sentDate:yyyy}";
            string BeginFormatted = $"{effectiveDate:HH:mm} {TimeZoneName}, {effectiveDate:MMMM dd}, {effectiveDate:yyyy}";
            string EndFormatted = $"{expiryDate:HH:mm} {TimeZoneName}, {expiryDate:MMMM dd}, {expiryDate:yyyy}";

            string EventType;
            try
            {
                EventType = EventRegex.Match(InfoData).Groups[1].Value;
                EventType = Regex.Replace(EventType.ToLower(), @"(^\w)|(\s\w)", m => m.Value.ToUpper());
                EventType = $"Event type is {EventType}.";
            }
            catch (Exception)
            {
                EventType = $"Event type is not known.";
            }

            string Coverage = "For:";
            string AreaDesc = "Unspecified area(s)";

            try
            {
                var AreaDescription = AreaDescriptionRegex.Matches(InfoData);

                if (AreaDescription.Count != 0)
                {
                    string AppendedAreas = string.Empty;
                    string AppendedCodeAreas = string.Empty;

                    foreach (Match area in AreaDescription)
                    {
                        AppendedAreas += area.Groups[1].Value.Replace(";", ",") + "\x20";
                    }

                    var GeocodeSAMEAreas = GeocodeSpecificAreaMessageEncodingRegex.Matches(InfoData);
                    var GeocodeUGCAreas = GeocodeUniversalGeographicCodeRegex.Matches(InfoData);

                    foreach (Match code in GeocodeSAMEAreas)
                    {
                        AppendedCodeAreas += $"{GetFriendlyNameFromSAMELocation(code.Groups[1].Value.Substring(1))},\x20";
                    }

                    foreach (Match code in GeocodeUGCAreas)
                    {
                        AppendedCodeAreas += $"UGC geocode {code.Groups[1].Value},\x20";
                    }

                    if (AppendedCodeAreas.Split(',').Length > AppendedAreas.Split(',').Length)
                    {
                        AreaDesc = SentencePuncuationCorrection(AppendedCodeAreas.Trim() + ".");
                    }
                    else
                    {
                        AreaDesc = AppendedAreas + ".";
                    }

                    //string[] areaDescMatches = AreaDescription
                    //.Cast<Match>()
                    //.Select(m => m.Groups[1].Value)
                    //.ToArray();

                    //AreaDesc = string.Join(", ", areaDescMatches) + ".";

                    // "For: FIPS" / "For: AffectedArea" problem
                }
            }
            catch (Exception)
            {
            }

            string SenderName;

            try
            {
                SenderName = SenderNameRegex.Match(InfoData).Groups[1].Value;
            }
            catch (Exception)
            {
                SenderName = "an unknown issuer";
            }

            string Description;

            try
            {
                Description = SentenceAppendEnd(DescriptionRegex.Match(InfoData).Groups[1].Value.Replace("\r\n", " ").Replace("\n", " "));
            }
            catch (Exception)
            {
                Description = "";
            }

            string Instruction;

            try
            {
                Instruction = SentenceAppendEnd(InstructionRegex.Match(InfoData).Groups[1].Value.Replace("\r\n", " ").Replace("\n", " "));
            }
            catch (Exception)
            {
                Instruction = "";
            }

            if (string.IsNullOrWhiteSpace(Description))
            {
                try
                {
                    Match cmamLong = CMAMLongRegex.Match(InfoData);
                    if (cmamLong.Success)
                    {
                        Description = cmamLong.Groups[1].Value;
                    }

                }
                catch (Exception)
                {
                    Description = string.Empty;
                }
            }
            
            if (string.IsNullOrWhiteSpace(Instruction))
            {
                try
                {
                    Match cmamShort = CMAMShortRegex.Match(InfoData);
                    if (cmamShort.Success)
                    {
                        Instruction = cmamShort.Groups[1].Value;
                    }
                }
                catch (Exception)
                {
                    Instruction = string.Empty;
                }
            }

            if (string.IsNullOrWhiteSpace(Description) & string.IsNullOrWhiteSpace(Instruction))
            {
                Description = "The alert information is limited or unavailable.";
                Instruction = string.Empty;
            }

            string Effective;

            try
            {
                Effective = effectiveDate.ToString();
            }
            catch (Exception)
            {
                Effective = "currently";
            }

            string Expiry;

            try
            {
                Expiry = expiryDate.ToString();
            }
            catch (Exception)
            {
                Expiry = "soon";
            }

            // Effective {Effective}, and expiring {Expires}.

            BroadcastText += SentenceAppendSpace(EventType);
            BroadcastText += SentenceAppendSpace(Coverage);
            BroadcastText += SentenceAppendSpace(SentenceAppendEnd(AreaDesc));

            if (BeginFormatted != EndFormatted)
            {
                BroadcastText += SentenceAppendSpace($"This alert takes effect on {BeginFormatted}, and expires on {EndFormatted}.");
            }
            else
            {
                BroadcastText += SentenceAppendSpace($"This alert takes effect starting {BeginFormatted}.");
            }

            BroadcastText += SentenceAppendSpace(SentenceAppendEnd(Description));
            if (Description != Instruction) BroadcastText += SentenceAppendSpace(SentenceAppendEnd(Instruction));

            //Match match = BroadcastTextRegex.Match(InfoData);

            //if (match.Success)
            //{
            //    BroadcastText += match.Groups[1].Value.Replace("\r\n", "\x20").Replace("\n", "\x20").Replace("\x20\x20\x20", "\x20").Replace("\x20\x20", "\x20").Trim();
            //}

            BroadcastText = BroadcastText.Replace("###", string.Empty).Trim();
            BroadcastText = BroadcastText.Replace("E A S", "EAS").Trim();
            BroadcastText = SentencePuncuationCorrection(BroadcastText)
                .Replace("* WHAT,", string.Empty)
                .Replace("* WHERE,", string.Empty)
                .Replace("* WHEN,", string.Empty)
                .Replace("* IMPACTS,", string.Empty);
            BroadcastText = SentenceAppendEnd(BroadcastText);
            BroadcastText = TimeCorrection(BroadcastText);
            BroadcastText = BroadcastText.Replace(@"\r", "").Replace(@"\n", " ");
            BroadcastText = BroadcastText.Replace("\r", "").Replace("\n", " ");
            BroadcastText = string.Join(" ", BroadcastText.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            return BroadcastText;
        }
        
        /// <summary>
        /// Processes the info tag, then returns a message body.
        /// </summary>
        /// <param name="InfoData">The info XML data to process.</param>
        /// <returns>Returns a compiled message body.</returns>
        public static List<string> CompiledLocations(string InfoData)
        {
            try
            {
                var AreaDescription = AreaDescriptionRegex.Matches(InfoData);

                if (AreaDescription.Count != 0)
                {
                    List<string> AppendedAreas = new List<string>();
                    List<string> AppendedCodeAreas = new List<string>();

                    foreach (Match area in AreaDescription)
                    {
                        foreach (string areaFull in area.Groups[1].Value.Replace(";", string.Empty)
                            .Replace(",", string.Empty).Split('\x20'))
                        {
                            AppendedAreas.Add(areaFull);
                        }

                    }

                    var GeocodeSAMEAreas = GeocodeSpecificAreaMessageEncodingRegex.Matches(InfoData);
                    var GeocodeUGCAreas = GeocodeUniversalGeographicCodeRegex.Matches(InfoData);

                    foreach (Match code in GeocodeSAMEAreas)
                    {
                        AppendedCodeAreas.Add($"{GetFriendlyNameFromSAMELocation(code.Groups[1].Value.Substring(1))}");
                    }

                    foreach (Match code in GeocodeUGCAreas)
                    {
                        AppendedCodeAreas.Add($"UGC area ({code.Groups[1].Value})");
                    }

                    if (AppendedAreas.Count <= AppendedCodeAreas.Count) return AppendedCodeAreas;
                    else return AppendedAreas;
                }

                return new List<string> { "Unparsable Location(s)" };
            }
            catch (Exception)
            {
                return new List<string> { "Unknown Location(s)" };
            }
        }

        /// <summary>
        /// Processes the data string for TTS friendlyness. (e.g. EST => Eastern Standard Time)
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        public static string StringIntoTTSFriendly(string Data)
        {
            string FriendlyData = Data;
            FriendlyData = FriendlyData.Replace("EAS", "E A S").Replace("911", "9 1 1").Replace("9-1-1", "9 1 1");
            FriendlyData = FriendlyData.Replace("WEA", "We a");
            return FriendlyData;
        }

        /// <summary>
        /// Gets the friendly name of the area specified.
        /// </summary>
        /// <param name="code">The code of which to get the friendly name from.</param>
        /// <returns></returns>
        public static string GetFriendlyNameFromSAMELocation(string code)
        {
            try
            {
                using (JsonDocument doc = JsonDocument.Parse(CacheCapture.SAME_US_JSON))
                {
                    JsonElement root = doc.RootElement;
                    JsonElement same = root.GetProperty("SAME");

                    if (same.TryGetProperty(code, out JsonElement value))
                    {
                        return value.GetString();
                    }
                }
            }
            catch (Exception)
            {
                return $"Unparsable Location ({code})";
            }

            return $"Unknown Location ({code})";
        }
    }
}
