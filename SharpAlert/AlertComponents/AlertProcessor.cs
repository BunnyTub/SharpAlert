using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static SharpAlert.RegexList;
using static SharpAlert.AlertComponents.AlertDisplayer;
using static SharpAlert.AlertComponents.AlertDetails;
using System.Drawing;
using SharpAlert.ProgramWorker;
using SharpAlert.SourceCapturing;
using System.Text.Json;
using System.Text;
using SharpAlert.Properties;
using System.Threading;

namespace SharpAlert.AlertComponents
{
    public class AlertProcessor
    {
        //private readonly object PingLock = new object();

        public AlertProcessor()
        {
            //ServiceRun();
            StartRelayCallLoop();
            StartAudioCallLoop();
            StartDisplayerCallLoop();
            StartShakeCallLoop();
            //StartRAFCallLoop();
            //StartTAFCallLoop();
            //StartMAFCallLoop();
            //StartSAFCallLoop();
        }

        public static readonly object AlertLock = new();

        public static int AlertsQueued
        {
            get;
            set;
        } = 0;
        
        public static int AlertsRelayed
        {
            get;
            set;
        } = 0;

        public enum SeverityLevel
        {
            Unknown,
            Minor,
            Moderate,
            Severe,
            Extreme
        }

        public class AlertTextClass
        {
            public string Intro { get; set; }
            public string Body { get; set; }
        }

        private int AlertsProcessedBeforeGC = 0;
        private int _AlertsProcessing = 0;
        public int AlertsProcessing
        {
            get
            {
                return _AlertsProcessing;
            }
            private set
            {
                if (value > _AlertsProcessing) AlertsProcessedBeforeGC++;
                _AlertsProcessing = value;

                if (AlertsProcessedBeforeGC >= 100)
                {
                    AlertsProcessedBeforeGC = 0;
                    ThreadDrool.StartAndForget(() =>
                    {
                        //Console.WriteLine("[Alert Processor] Collecting garbage globally.");
                        //GC.Collect();
                        //GC.WaitForPendingFinalizers();
                        //GC.WaitForFullGCComplete();
                    });
                }
            }
        }

        public bool AlertInProcessing { get; private set; } = false;

        //bool DoNotAddToCount
        public AlertInfo ProcessAlertItem(SharpDataItem relayItem, bool ReplayMode, bool IgnoreDiscards)
        {
            if (!QuickSettings.Instance.DisableAlertProcessing)
            {
                AlertInProcessing = true;
                Console.WriteLine($"[Alert Processor] Beginning processing -> {relayItem.Name}");
                //if (!DoNotAddToCount) AlertsProcessing++;
                AlertsProcessing++;
                AlertInfo info = SubProcessAlertItem(relayItem, ReplayMode, IgnoreDiscards);

                if (QuickSettings.Instance.IgnoreKeepAlive)
                {
                    if (relayItem.Name.ToLowerInvariant().Contains("keepalive"))
                    {
                        info = new AlertInfo { AlertDiscardReason = "The identifier contains \"KEEPALIVE\", so this alert has been discarded." };
                    }
                }

                //if (!DoNotAddToCount) AlertsProcessing--;
                AlertsProcessing--;
                Console.WriteLine($"[Alert Processor] Finished processing -> {relayItem.Name}");
                AlertInProcessing = false;
                return info;
            }
            else
            {
                Console.WriteLine($"[Alert Processor] Processing of alerts is currently disabled.");
                return new AlertInfo
                {
                    AlertDiscardReason = "Processing of alerts is currently disabled."
                };
            }
        }

        public class AlertInfo
        {
            public string AlertDiscardReason { get; set; } = string.Empty;
            public string AlertSource { get; set; } = string.Empty;
            public string AlertID { get; set; } = string.Empty;
            public string AlertSentDate { get; set; } = string.Empty;
            public string AlertExpiryDate { get; set; } = string.Empty;
            public List<string> AlertFriendlyLocations { get; set; } = [];
            public string AlertEventType { get; set; } = string.Empty;
            public string AlertMessageType { get; set; } = string.Empty;
            public string AlertSeverity { get; set; } = string.Empty;
            public string AlertIntroText { get; set; } = string.Empty;
            public string AlertBodyText { get; set; } = string.Empty;
            public string AlertURL { get; set; } = string.Empty;
            public string AlertAudioURL { get; set; } = string.Empty;
            public string AlertImageURL { get; set; } = string.Empty;
        }

        /// <summary>
        /// Processes and relays the alert item.
        /// </summary>
        /// <param name="relayItem">The item to be processed.</param>
        private AlertInfo SubProcessAlertItem(SharpDataItem relayItem, bool ReplayMode, bool IgnoreDiscards)
        {
            lock (AlertLock)
            {
                if (relayItem == null) return new AlertInfo { AlertDiscardReason = "No alert provided." };

                string alert = relayItem.Data;

                if (QuickSettings.Instance.BypassAllFilters) Console.WriteLine($"[Alert Processor] Due to BypassAllFilters being enabled, any alerts will pass/succeed (if valid), regardless of set filters.");

                //foreach (string alert in AlertList)
                {
                    //if (alertMatches.Count != 1)
                    //{
                    //    Console.WriteLine($"[Alert Processor] Cannot process multiple or zero alerts within the same call -> {relayItem.Name}");
                    //    return new AlertInfo[]
                    //    {
                    //        new AlertInfo
                    //        {
                    //            AlertDiscardReason = "The Alert Processor does not support processing multiple or zero alerts within a single call."
                    //        }
                    //    };
                    //}

                    //Console.WriteLine($"[Alert Processor] Processing alert -> {relayItem.Name}"); 

                    DateTime startProc = DateTime.UtcNow;

                    //DiscordWebhook.SendUnformattedMessage($"Processing incoming alert item. ({startProc:O} UTC)");

                    //bool AnyAlertRelayed = false;
                    //bool UsedDiscordHook = false;

                    string Sent = SentRegex.MatchOrDefault(alert, DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));

                    Console.WriteLine($"[Alert Processor] Sent: {Sent}");

                    string Status = StatusRegex.MatchOrDefault(alert, "actual");
                    Console.WriteLine($"[Alert Processor] Status: {Status}");

                    string MsgType = MessageTypeRegex.MatchOrDefault(alert, "alert");
                    Console.WriteLine($"[Alert Processor] Message Type: {MsgType}");

                    Console.WriteLine($"[Alert Processor] Replay (internal flag): {ReplayMode}");

                    MatchCollection infoMatches = InfoRegex.Matches(relayItem.Data);

                    if (!QuickSettings.Instance.BypassAllFilters)
                    {
                        bool AnyInfoTagsPass = false;

                        if (!ProcessAlertX(Status, MsgType))
                        {
                            Console.WriteLine($"[Alert Processor] Alert discarded due to status/message_type settings.");
                            //DiscordWebhook.SendUnformattedMessage($"The incoming alert was discarded. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");
                            if (!IgnoreDiscards)
                            {
                                return new AlertInfo { AlertDiscardReason = "The alert was blocked because of your status, or message type settings." };
                            }
                        }

                        for (int ii = 0; ii < infoMatches.Count; ii++)
                        {
                            try
                            {
                                if (ProcessInfoX(infoMatches[ii].Groups[1].Value))
                                {
                                    AnyInfoTagsPass = true;
                                    break;
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"[Alert Processor] An info tag couldn't processed. {ex.Message}");
                            }
                        }

                        if (!AnyInfoTagsPass)
                        {
                            Console.WriteLine($"[Alert Processor] Alert discarded due to location/urgency/category settings.");
                            //DiscordWebhook.SendUnformattedMessage($"The incoming alert was discarded. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");
                            if (!IgnoreDiscards)
                            {
                                return new AlertInfo { AlertDiscardReason = "The alert was blocked because of your location, urgency, or category settings." };
                            }
                        }
                    }

                    int infoProc = 0;

                    List<string> AllEvents = [];
                    List<string> AllLocations = [];
                    SeverityLevel MaxSeverity = SeverityLevel.Unknown;

                    List<string> AudioFiles = [];
                    List<string> DerefAudioFiles = [];
                    List<string> ImageFiles = [];
                    List<string> DerefImageFiles = [];
                    List<AlertTextClass> AlertTextList = [];
                    string Expiry = string.Empty;
                    string EventTypeFull = string.Empty;
                    string PrimaryURL = string.Empty;
                    string Source = string.Empty;

                    foreach (Match infoMatch in infoMatches)
                    {
                        infoProc++;
                        Console.WriteLine($"[Alert Processor] Processing {infoProc} of {infoMatches.Count}.");

                        string AlertInfo = $"{infoMatch.Groups[1].Value}";

                        Source = SourceRegex.MatchOrDefault(alert, "External Source");
                        Console.WriteLine($"[Alert Processor] Source (if any): {Source}");

                        string Effective = EffectiveRegex.MatchOrDefault(alert, DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));
                        Console.WriteLine($"[Alert Processor] Effective: {Effective}");

                        Expiry = ExpiresRegex.MatchOrDefault(alert, DateTime.UtcNow.AddHours(1).ToString("O", CultureInfo.InvariantCulture));
                        Console.WriteLine($"[Alert Processor] Expires: {Expiry}");

                        //https://www.iana.org/assignments/language-subtag-registry/language-subtag-registry
                        string BCP47Language = LanguageRegex.MatchOrDefault(AlertInfo, "en-US");
                        Console.WriteLine($"[Alert Processor] Language: {BCP47Language}");

                        string URL = WebRegex.MatchOrDefault(AlertInfo, string.Empty);
                        string Web = WebRegex.MatchOrDefault(AlertInfo, string.Empty);
                        Console.WriteLine($"[Alert Processor] Associated URL (if any): {URL}");
                        Console.WriteLine($"[Alert Processor] Associated Web (if any): {Web}");
                        if (string.IsNullOrWhiteSpace(PrimaryURL)) PrimaryURL = URL;
                        if (string.IsNullOrWhiteSpace(PrimaryURL)) PrimaryURL = Web;

                        string EventName = Regex.Replace(EventRegex.MatchOrDefault(AlertInfo, "Cautionary (Unknown Event)"), @"(^\w)|(\s\w)", m => m.Value.ToUpperInvariant());
                        Console.WriteLine($"[Alert Processor] Event Name: {EventName}");

                        string EventType = EventCodeRegex.MatchOrDefault(AlertInfo, "???");
                        var (EventTypeTranslated, TranslationSuccessful) = GetAlertNameFromSAME(EventType);
                        Console.WriteLine($"[Alert Processor] Event: {EventType}");
                        Console.WriteLine($"[Alert Processor] Event (SAME Translation): {EventTypeTranslated}");

                        if (TranslationSuccessful)
                        {
                            if (string.IsNullOrEmpty(EventTypeFull))
                            {
                                EventTypeFull = EventTypeTranslated;
                            }
                            else if (!EventTypeFull.Contains(EventTypeTranslated)) EventTypeFull += $"; {EventTypeTranslated}";
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(EventTypeFull))
                            {
                                EventTypeFull = EventName;
                            }
                            else if (!EventTypeFull.Contains(EventName)) EventTypeFull += $"; {EventName}";
                        }

                        string Urgency = UrgencyRegex.MatchOrDefault(AlertInfo, "Unknown");
                        Console.WriteLine($"[Alert Processor] Urgency: {Urgency}");

                        string Severity = SeverityRegex.MatchOrDefault(AlertInfo, "Unknown");
                        Console.WriteLine($"[Alert Processor] Severity: {Severity}");

                        int ResourceCount = 0;
                        MatchCollection MatchedResources = ResourceRegex.Matches(AlertInfo);
                        foreach (Match resource in MatchedResources)
                        {
                            ResourceCount++;
                            Console.WriteLine($"[Alert Processor] Resource {ResourceCount} Value: {resource.Groups[1].Value}");
                            var desc = ResourceDescRegex.MatchOrDefault(resource.Groups[1].Value);
                            Console.WriteLine($"[Alert Processor] Resource {ResourceCount} Description: {desc}");
                            var mime = MIMETypeRegex.MatchOrDefault(resource.Groups[1].Value);
                            Console.WriteLine($"[Alert Processor] Resource {ResourceCount} MIME Type: {mime}");
                            var size = SizeRegex.MatchOrDefault(resource.Groups[1].Value);
                            Console.WriteLine($"[Alert Processor] Resource {ResourceCount} Size (if any): {size}");
                            var uri = URIRegex.MatchOrDefault(resource.Groups[1].Value);
                            Console.WriteLine($"[Alert Processor] Resource {ResourceCount} URI (if any): {uri}");
                            var derefUri = DerefURIRegex.MatchOrDefault(resource.Groups[1].Value);
                            Console.WriteLine($"[Alert Processor] Resource {ResourceCount} Dereference URI (if any): {derefUri}");
                            var digest = DigestSecureHashAlgorithmOneRegex.MatchOrDefault(resource.Groups[1].Value);
                            Console.WriteLine($"[Alert Processor] Resource {ResourceCount} SHA-1 (if any | unused): {digest}");

                            void AddAudioToList()
                            {
                                if (!string.IsNullOrWhiteSpace(uri))
                                {
                                    //if (string.IsNullOrWhiteSpace(derefUri))
                                    {
                                        AudioFiles.Add(uri);
                                        Console.WriteLine($"[Alert Processor] Resource {ResourceCount} was added to the audio list.");
                                    }
                                    //else
                                    {
                                        // work on this
                                    }
                                }
                                else Console.WriteLine($"[Alert Processor] Resource {ResourceCount} has no URI.");
                            }

                            void AddImageToList()
                            {
                                if (!string.IsNullOrWhiteSpace(uri))
                                {
                                    ImageFiles.Add(uri);
                                    Console.WriteLine($"[Alert Processor] Resource {ResourceCount} was added to the image list.");
                                }
                                else Console.WriteLine($"[Alert Processor] Resource {ResourceCount} has no URI.");
                            }

                            if (!string.IsNullOrWhiteSpace(uri))
                            {
                                switch (mime)
                                {
                                    case "audio/ogg":
                                        AddAudioToList();
                                        break;
                                    case "audio/opus":
                                        AddAudioToList();
                                        break;
                                    case "audio/vorbis":
                                        AddAudioToList();
                                        break;
                                    case "audio/aac":
                                        AddAudioToList();
                                        break;
                                    case "audio/mpeg":
                                        AddAudioToList();
                                        break;
                                    case "audio/x-ipaws-audio-mp3":
                                        AddAudioToList();
                                        break;
                                    case "audio/x-ipaws-audio-wav":
                                        AddAudioToList();
                                        break;
                                    case "application/x-url":
                                        AddAudioToList();
                                        break;
                                    case "image/bmp":
                                        AddImageToList();
                                        break;
                                    case "image/gif":
                                        AddImageToList();
                                        break;
                                    case "image/jpeg":
                                        AddImageToList();
                                        break;
                                    case "image/png":
                                        AddImageToList();
                                        break;
                                    default:
                                        AddAudioToList();
                                        break;
                                }
                            }
                        }

                        //if (!IgnoreDiscards)
                        //{
                        //    if (!PrimaryURL.Contains("sasmex.net"))
                        //    {
                        //        if (!QuickSettings.Instance.AllowNonEnglishAlerts)
                        //        {
                        //            if (!BCP47Language.ToLowerInvariant().StartsWith("en-"))
                        //            {
                        //                Console.WriteLine("[Alert Processor] Info tag discarded because it does not contain English information.");
                        //                continue;
                        //            }
                        //        }
                        //    }
                        //}

                        if (!IgnoreDiscards)
                        {
                            if (!ReplayMode)
                            {
                                try
                                {
                                    if (DateTime.Parse(Expiry, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal) <= DateTime.Now)
                                    {
                                        Console.WriteLine($"[Alert Processor] Info tag discarded because it has expired.");
                                        continue;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine($"[Alert Processor] Expiry check skipped because it has failed. {ex.Message}");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"[Alert Processor] Expiry check skipped because the alert is being replayed.");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"[Alert Processor] Expiry check skipped because discards are being ignored.");
                        }

                        bool EventBlacklisted = false;

                        if (ProcessParameterX(AlertInfo) ||
                            BroadcastImmediatelyRegex.MatchOrDefault(AlertInfo, "no").ToLowerInvariant() == "yes" ||
                            IgnoreDiscards ||
                            QuickSettings.Instance.BypassAllFilters)
                        {
                            if (!QuickSettings.Instance.BypassAllFilters)
                            {
                                if (!IgnoreDiscards)
                                {
                                    string RemoveDiacritics(string input)
                                    {
                                        var normalized = input.Normalize(NormalizationForm.FormD);
                                        var builder = new StringBuilder();

                                        foreach (var c in normalized)
                                        {
                                            var category = CharUnicodeInfo.GetUnicodeCategory(c);
                                            if (category != UnicodeCategory.NonSpacingMark)
                                            {
                                                builder.Append(c);
                                            }
                                        }

                                        return builder.ToString().Normalize(NormalizationForm.FormC);
                                    }

                                    lock (QuickSettings.Instance.EnforceEventBlacklist)
                                    {
                                        foreach (string Event in QuickSettings.Instance.EnforceEventBlacklist)
                                        {
                                            if (RemoveDiacritics(EventName.ToLowerInvariant()).Contains(RemoveDiacritics(Event.ToLowerInvariant())))
                                            {
                                                EventBlacklisted = true;
                                                break;
                                            }
                                        }
                                    }

                                    //lock (QuickSettings.Instance.EnforceSAMEEventBlacklist)
                                    //{
                                    //    foreach (string SAMEEvent in QuickSettings.Instance.EnforceSAMEEventBlacklist)
                                    //    {
                                    //        if (EventType.ToLowerInvariant().Contains(SAMEEvent.ToLowerInvariant()))
                                    //        {
                                    //            EventBlacklisted = true;
                                    //            break;
                                    //        }
                                    //    }
                                    //}

                                    if (QuickSettings.Instance.EventWhitelistMode)
                                    {
                                        if (!EventBlacklisted)
                                        {
                                            Console.WriteLine($"[Alert Processor] Info tag discarded because the event is not on the whitelist.");
                                            continue;
                                        }
                                    }
                                    else
                                    {
                                        if (EventBlacklisted)
                                        {
                                            Console.WriteLine($"[Alert Processor] Info tag discarded because the event is on the blacklist.");
                                            continue;
                                        }
                                    }

                                }
                                else
                                {
                                    Console.WriteLine($"[Alert Processor] Blacklist/whitelist check skipped because discards are being ignored.");
                                }
                            }

                            // removal of replay boolean
                            var (Intro, Body) = CompiledBody(AlertInfo, MsgType, Sent, Source);

                            Console.WriteLine($"[Alert Processor] Intro: {Intro}");
                            Console.WriteLine($"[Alert Processor] Body: {Body}");

                            List<string> LocationsText = CompiledLocations(AlertInfo);

                            if (!AllEvents.Contains(EventName)) AllEvents.Add(EventName);
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

                            AlertTextClass text = new() { Intro = Intro, Body = Body };

                            bool MatchFound = false;

                            foreach (var kext in AlertTextList)
                            {
                                if (kext.Intro == Intro & kext.Body == Body)
                                {
                                    Console.WriteLine($"[Alert Processor] The contents of the current info tag match a previously processed tag.");
                                    MatchFound = true;
                                    continue;
                                }
                            }

                            if (!MatchFound)
                            {
                                AlertTextList.Add(text);
                                Console.WriteLine($"[Alert Processor] The contents of the current info tag have been added.");
                                continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"[Alert Processor] Alert discarded due to mobile alert settings, or other things.");
                        }
                    }

                    Console.WriteLine("[Alert Processor] There is no further data to process.");

                    string FullIntro = string.Empty;
                    string FullBody = string.Empty;

                    if (AlertTextList.Count == 0)
                    {
                        Console.WriteLine("[Alert Processor] There is no alert text to process.");
                        return new AlertInfo { AlertDiscardReason = "The alert cannot be processed because no alert text exists." };
                    }
                    else
                    {
                        int IncrementedList = 0;

                        if (AlertTextList.Count > 1)
                        {
                            foreach (var kext in AlertTextList)
                            {
                                IncrementedList++;
                                if (!string.IsNullOrWhiteSpace(kext.Intro)) FullIntro += $"\r\n\r\n{IncrementedList}.\x20" + kext.Intro;
                                if (!string.IsNullOrWhiteSpace(kext.Body)) FullBody += $"\r\n\r\n{IncrementedList}.\x20" + kext.Body;
                            }
                            FullIntro = FullIntro.Trim();
                            FullBody = FullBody.Trim();
                        }
                        else
                        {
                            foreach (var kext in AlertTextList)
                            {
                                if (!string.IsNullOrWhiteSpace(kext.Intro)) FullIntro += kext.Intro;
                                if (!string.IsNullOrWhiteSpace(kext.Body)) FullBody += kext.Body;
                            }
                            FullIntro = FullIntro.Trim();
                            FullBody = FullBody.Trim();
                        }

                        if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.StationIdentifier))
                        {
                            FullIntro = $"This message relays from {QuickSettings.Instance.StationIdentifier} ({QuickSettings.Instance.StationName}).\r\n\r\n{FullIntro}".Trim();
                        }

                        AlertTextClass _AlertText = new()
                        {
                            Intro = FullIntro,
                            Body = FullBody
                        };

                        if (!IgnoreDiscards)
                        {
                            // ???
                        }
                    }

                    //if (AnyAlertRelayed)
                    //{
                    AlertsRelayed++;
                    //}

                    Console.WriteLine($"[Alert Processor] Processed all available entries. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");

                    string AudioURL = AudioFiles.FirstOrDefault();
                    string ImageURL = ImageFiles.FirstOrDefault();

                    if (string.IsNullOrWhiteSpace(AudioURL)) AudioURL = string.Empty;
                    if (string.IsNullOrWhiteSpace(ImageURL)) ImageURL = string.Empty;

                    //MessageBox.Show(MaxSeverity.ToString());

                    return new AlertInfo
                    {
                        // do something about alert IDs
                        AlertSource = Source,
                        AlertID = relayItem.Name,
                        AlertSentDate = Sent,
                        AlertExpiryDate = Expiry,
                        AlertFriendlyLocations = AllLocations,
                        AlertEventType = EventTypeFull,
                        AlertMessageType = MsgType,
                        AlertSeverity = MaxSeverity.ToString(),
                        AlertIntroText = FullIntro.Trim(),
                        AlertBodyText = FullBody.Trim(),
                        AlertURL = PrimaryURL,
                        AlertAudioURL = AudioURL,
                        AlertImageURL = ImageURL
                    };
                }
            }
        }

        //private AlertInfo[] SubProcessMassAlertItem(SharpDataItem relayItem, bool ReplayMode, bool IgnoreDiscards)
        //{
        //    // support multi alerts inside the alert processor

        //    lock (AlertLock)
        //    {
        //        if (relayItem == null) return new AlertInfo[] { new AlertInfo { AlertDiscardReason = "No alert(s) provided." } };

        //        List<AlertInfo> AlertInfoList = new List<AlertInfo>();

        //        MatchCollection alertMatches = AlertRegex.Matches(relayItem.Name);
        //        List<string> AlertList = new List<string>();

        //        foreach (Match alertMatch in alertMatches)
        //        {
        //            AlertList.Add(alertMatch.Value);
        //        }

        //        Console.WriteLine($"[Alert Processor] Found {alertMatches.Count} alert(s).");
        //        if (alertMatches.Count == 0)
        //        {
        //            Console.WriteLine($"[Alert Processor] The provided data will be processed as one, because no alert tags were found.");
        //            AlertList.Add(relayItem.Data);
        //        }

        //        if (QuickSettings.Instance.BypassAllFilters) Console.WriteLine($"[Alert Processor] Due to BypassAllFilters being enabled, any alerts will pass/succeed (if valid), regardless of set filters.");

        //        foreach (string alert in AlertList)
        //        {
        //            //if (alertMatches.Count != 1)
        //            //{
        //            //    Console.WriteLine($"[Alert Processor] Cannot process multiple or zero alerts within the same call -> {relayItem.Name}");
        //            //    return new AlertInfo[]
        //            //    {
        //            //        new AlertInfo
        //            //        {
        //            //            AlertDiscardReason = "The Alert Processor does not support processing multiple or zero alerts within a single call."
        //            //        }
        //            //    };
        //            //}

        //            //Console.WriteLine($"[Alert Processor] Processing alert -> {relayItem.Name}"); 

        //            DateTime startProc = DateTime.UtcNow;

        //            //DiscordWebhook.SendUnformattedMessage($"Processing incoming alert item. ({startProc:O} UTC)");

        //            //bool AnyAlertRelayed = false;
        //            //bool UsedDiscordHook = false;

        //            string Sent = SentRegex.MatchOrDefault(alert, DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));

        //            Console.WriteLine($"[Alert Processor] Sent: {Sent}");

        //            string Status = StatusRegex.MatchOrDefault(alert, "actual");
        //            Console.WriteLine($"[Alert Processor] Status: {Status}");

        //            string MsgType = MessageTypeRegex.MatchOrDefault(alert, "alert");
        //            Console.WriteLine($"[Alert Processor] Message Type: {MsgType}");

        //            Console.WriteLine($"[Alert Processor] Replay (internal flag): {ReplayMode}");

        //            MatchCollection infoMatches = InfoRegex.Matches(relayItem.Data);

        //            bool AnyInfoTagsPass = false;

        //            if (!ProcessAlertX(Status, MsgType))
        //            {
        //                Console.WriteLine($"[Alert Processor] Alert discarded due to status/message_type settings.");
        //                //DiscordWebhook.SendUnformattedMessage($"The incoming alert was discarded. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");
        //                if (!IgnoreDiscards)
        //                {
        //                    AlertInfoList.Add(new AlertInfo { AlertDiscardReason = "The alert was blocked because of your status, or message type settings." });
        //                    continue;
        //                }
        //            }

        //            for (int ii = 0; ii < infoMatches.Count; ii++)
        //            {
        //                try
        //                {
        //                    if (ProcessInfoX(infoMatches[ii].Groups[1].Value))
        //                    {
        //                        AnyInfoTagsPass = true;
        //                        break;
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    Console.WriteLine($"[Alert Processor] An info tag couldn't processed. {ex.Message}");
        //                }
        //            }

        //            if (!AnyInfoTagsPass)
        //            {
        //                Console.WriteLine($"[Alert Processor] Alert discarded due to location/urgency/category settings.");
        //                //DiscordWebhook.SendUnformattedMessage($"The incoming alert was discarded. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");
        //                if (!IgnoreDiscards)
        //                {
        //                    AlertInfoList.Add(new AlertInfo { AlertDiscardReason = "The alert was blocked because of your location, urgency, or category settings." });
        //                    continue;
        //                }
        //            }

        //            int infoProc = 0;

        //            List<string> AllEvents = new List<string>();
        //            List<string> AllLocations = new List<string>();
        //            SeverityLevel MaxSeverity = SeverityLevel.Unknown;

        //            List<string> AudioFiles = new List<string>();
        //            List<string> DerefAudioFiles = new List<string>();
        //            List<string> ImageFiles = new List<string>();
        //            List<string> DerefImageFiles = new List<string>();
        //            List<AlertTextClass> AlertTextList = new List<AlertTextClass>();
        //            string Expiry = string.Empty;
        //            string EventTypeFull = string.Empty;
        //            string PrimaryURL = string.Empty;
        //            string Source = string.Empty;

        //            foreach (Match infoMatch in infoMatches)
        //            {
        //                infoProc++;
        //                Console.WriteLine($"[Alert Processor] Processing {infoProc} of {infoMatches.Count}.");

        //                string AlertInfo = $"{infoMatch.Groups[1].Value}";

        //                Source = SourceRegex.MatchOrDefault(alert, "External Source");
        //                Console.WriteLine($"[Alert Processor] Source (if any): {Source}");

        //                string Effective = EffectiveRegex.MatchOrDefault(alert, DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));
        //                Console.WriteLine($"[Alert Processor] Effective: {Effective}");

        //                Expiry = ExpiresRegex.MatchOrDefault(alert, DateTime.UtcNow.AddHours(1).ToString("O", CultureInfo.InvariantCulture));
        //                Console.WriteLine($"[Alert Processor] Expires: {Expiry}");

        //                //https://www.iana.org/assignments/language-subtag-registry/language-subtag-registry
        //                string BCP47Language = LanguageRegex.MatchOrDefault(AlertInfo, "en-US");
        //                Console.WriteLine($"[Alert Processor] Language: {BCP47Language}");

        //                string URL = WebRegex.MatchOrDefault(AlertInfo, string.Empty);
        //                string Web = WebRegex.MatchOrDefault(AlertInfo, string.Empty);
        //                Console.WriteLine($"[Alert Processor] Associated URL (if any): {URL}");
        //                Console.WriteLine($"[Alert Processor] Associated Web (if any): {Web}");
        //                if (string.IsNullOrWhiteSpace(PrimaryURL)) PrimaryURL = URL;
        //                if (string.IsNullOrWhiteSpace(PrimaryURL)) PrimaryURL = Web;

        //                string EventName = Regex.Replace(EventRegex.MatchOrDefault(AlertInfo, "Cautionary (Unknown Event)"), @"(^\w)|(\s\w)", m => m.Value.ToUpperInvariant());
        //                Console.WriteLine($"[Alert Processor] Event Name: {EventName}");

        //                string EventType = EventCodeRegex.MatchOrDefault(AlertInfo, "???");
        //                var (EventTypeTranslated, TranslationSuccessful) = GetAlertNameFromSAME(EventType);
        //                Console.WriteLine($"[Alert Processor] Event: {EventType}");
        //                Console.WriteLine($"[Alert Processor] Event (SAME Translation): {EventTypeTranslated}");

        //                if (TranslationSuccessful)
        //                {
        //                    if (string.IsNullOrEmpty(EventTypeFull))
        //                    {
        //                        EventTypeFull = EventTypeTranslated;
        //                    }
        //                    else if (!EventTypeFull.Contains(EventTypeTranslated)) EventTypeFull += $"; {EventTypeTranslated}";
        //                }
        //                else
        //                {
        //                    if (string.IsNullOrEmpty(EventTypeFull))
        //                    {
        //                        EventTypeFull = EventName;
        //                    }
        //                    else if (!EventTypeFull.Contains(EventName)) EventTypeFull += $"; {EventName}";
        //                }

        //                string Urgency = UrgencyRegex.MatchOrDefault(AlertInfo, "Unknown");
        //                Console.WriteLine($"[Alert Processor] Urgency: {Urgency}");

        //                string Severity = SeverityRegex.MatchOrDefault(AlertInfo, "Unknown");
        //                Console.WriteLine($"[Alert Processor] Severity: {Severity}");

        //                int ResourceCount = 0;
        //                MatchCollection MatchedResources = ResourceRegex.Matches(AlertInfo);
        //                foreach (Match resource in MatchedResources)
        //                {
        //                    ResourceCount++;
        //                    Console.WriteLine($"[Alert Processor] Resource {ResourceCount} Value: {resource.Groups[1].Value}");
        //                    var desc = ResourceDescRegex.MatchOrDefault(resource.Groups[1].Value);
        //                    Console.WriteLine($"[Alert Processor] Resource {ResourceCount} Description: {desc}");
        //                    var mime = MIMETypeRegex.MatchOrDefault(resource.Groups[1].Value);
        //                    Console.WriteLine($"[Alert Processor] Resource {ResourceCount} MIME Type: {mime}");
        //                    var size = SizeRegex.MatchOrDefault(resource.Groups[1].Value);
        //                    Console.WriteLine($"[Alert Processor] Resource {ResourceCount} Size (if any): {size}");
        //                    var uri = URIRegex.MatchOrDefault(resource.Groups[1].Value);
        //                    Console.WriteLine($"[Alert Processor] Resource {ResourceCount} URI (if any): {uri}");
        //                    var derefUri = DerefURIRegex.MatchOrDefault(resource.Groups[1].Value);
        //                    Console.WriteLine($"[Alert Processor] Resource {ResourceCount} Dereference URI (if any): {derefUri}");
        //                    var digest = DigestSecureHashAlgorithmOneRegex.MatchOrDefault(resource.Groups[1].Value);
        //                    Console.WriteLine($"[Alert Processor] Resource {ResourceCount} SHA-1 (if any | unused): {digest}");

        //                    void AddAudioToList()
        //                    {
        //                        if (!string.IsNullOrWhiteSpace(uri))
        //                        {
        //                            //if (string.IsNullOrWhiteSpace(derefUri))
        //                            {
        //                                AudioFiles.Add(uri);
        //                                Console.WriteLine($"[Alert Processor] Resource {ResourceCount} was added to the audio list.");
        //                            }
        //                            //else
        //                            {
        //                                // work on this
        //                            }
        //                        }
        //                        else Console.WriteLine($"[Alert Processor] Resource {ResourceCount} has no URI.");
        //                    }

        //                    void AddImageToList()
        //                    {
        //                        if (!string.IsNullOrWhiteSpace(uri))
        //                        {
        //                            ImageFiles.Add(uri);
        //                            Console.WriteLine($"[Alert Processor] Resource {ResourceCount} was added to the image list.");
        //                        }
        //                        else Console.WriteLine($"[Alert Processor] Resource {ResourceCount} has no URI.");
        //                    }

        //                    if (!string.IsNullOrWhiteSpace(uri))
        //                    {
        //                        switch (mime)
        //                        {
        //                            case "audio/ogg":
        //                                AddAudioToList();
        //                                break;
        //                            case "audio/opus":
        //                                AddAudioToList();
        //                                break;
        //                            case "audio/vorbis":
        //                                AddAudioToList();
        //                                break;
        //                            case "audio/aac":
        //                                AddAudioToList();
        //                                break;
        //                            case "audio/mpeg":
        //                                AddAudioToList();
        //                                break;
        //                            case "audio/x-ipaws-audio-mp3":
        //                                AddAudioToList();
        //                                break;
        //                            case "audio/x-ipaws-audio-wav":
        //                                AddAudioToList();
        //                                break;
        //                            case "application/x-url":
        //                                AddAudioToList();
        //                                break;
        //                            case "image/bmp":
        //                                AddImageToList();
        //                                break;
        //                            case "image/gif":
        //                                AddImageToList();
        //                                break;
        //                            case "image/jpeg":
        //                                AddImageToList();
        //                                break;
        //                            case "image/png":
        //                                AddImageToList();
        //                                break;
        //                            default:
        //                                AddAudioToList();
        //                                break;
        //                        }
        //                    }
        //                }

        //                if (!IgnoreDiscards)
        //                {
        //                    if (!PrimaryURL.Contains("sasmex.net"))
        //                    {
        //                        if (!QuickSettings.Instance.AllowNonEnglishAlerts)
        //                        {
        //                            if (!BCP47Language.ToLowerInvariant().StartsWith("en-"))
        //                            {
        //                                Console.WriteLine("[Alert Processor] Info tag discarded because it does not contain English information.");
        //                                continue;
        //                            }
        //                        }
        //                    }
        //                }

        //                if (!IgnoreDiscards)
        //                {
        //                    if (!ReplayMode)
        //                    {
        //                        try
        //                        {
        //                            if (DateTime.Parse(Expiry, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal) <= DateTime.Now)
        //                            {
        //                                Console.WriteLine($"[Alert Processor] Info tag discarded because it has expired.");
        //                                continue;
        //                            }
        //                        }
        //                        catch (Exception ex)
        //                        {
        //                            Console.WriteLine($"[Alert Processor] Expiry check skipped because it has failed. {ex.Message}");
        //                        }
        //                    }
        //                    else
        //                    {
        //                        Console.WriteLine($"[Alert Processor] Expiry check skipped because the alert is being replayed.");
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"[Alert Processor] Expiry check skipped because discards are being ignored.");
        //                }

        //                bool EventBlacklisted = false;

        //                if (ProcessParameterX(AlertInfo) ||
        //                    BroadcastImmediatelyRegex.MatchOrDefault(AlertInfo, "no").ToLowerInvariant() == "yes" ||
        //                    IgnoreDiscards ||
        //                    QuickSettings.Instance.BypassAllFilters)
        //                {
        //                    if (!QuickSettings.Instance.BypassAllFilters)
        //                    {
        //                        if (!IgnoreDiscards)
        //                        {
        //                            string RemoveDiacritics(string input)
        //                            {
        //                                var normalized = input.Normalize(NormalizationForm.FormD);
        //                                var builder = new StringBuilder();

        //                                foreach (var c in normalized)
        //                                {
        //                                    var category = CharUnicodeInfo.GetUnicodeCategory(c);
        //                                    if (category != UnicodeCategory.NonSpacingMark)
        //                                    {
        //                                        builder.Append(c);
        //                                    }
        //                                }

        //                                return builder.ToString().Normalize(NormalizationForm.FormC);
        //                            }

        //                            lock (QuickSettings.Instance.EnforceEventBlacklist)
        //                            {
        //                                foreach (string Event in QuickSettings.Instance.EnforceEventBlacklist)
        //                                {
        //                                    if (RemoveDiacritics(EventName.ToLowerInvariant()).Contains(RemoveDiacritics(Event.ToLowerInvariant())))
        //                                    {
        //                                        EventBlacklisted = true;
        //                                        break;
        //                                    }
        //                                }
        //                            }

        //                            //lock (QuickSettings.Instance.EnforceSAMEEventBlacklist)
        //                            //{
        //                            //    foreach (string SAMEEvent in QuickSettings.Instance.EnforceSAMEEventBlacklist)
        //                            //    {
        //                            //        if (EventType.ToLowerInvariant().Contains(SAMEEvent.ToLowerInvariant()))
        //                            //        {
        //                            //            EventBlacklisted = true;
        //                            //            break;
        //                            //        }
        //                            //    }
        //                            //}

        //                            if (QuickSettings.Instance.EventWhitelistMode)
        //                            {
        //                                if (!EventBlacklisted)
        //                                {
        //                                    Console.WriteLine($"[Alert Processor] Info tag discarded because the event is not on the whitelist.");
        //                                    continue;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                if (EventBlacklisted)
        //                                {
        //                                    Console.WriteLine($"[Alert Processor] Info tag discarded because the event is on the blacklist.");
        //                                    continue;
        //                                }
        //                            }

        //                        }
        //                        else
        //                        {
        //                            Console.WriteLine($"[Alert Processor] Blacklist/whitelist check skipped because discards are being ignored.");
        //                        }
        //                    }


        //                    // removal of replay boolean
        //                    var (Intro, Body) = CompiledBody(AlertInfo, MsgType, Sent, Source);

        //                    Console.WriteLine($"[Alert Processor] Intro: {Intro}");
        //                    Console.WriteLine($"[Alert Processor] Body: {Body}");

        //                    List<string> LocationsText = CompiledLocations(AlertInfo);

        //                    if (!AllEvents.Contains(EventName)) AllEvents.Add(EventName);
        //                    foreach (string location in LocationsText)
        //                    {
        //                        if (!AllLocations.Contains(location)) AllLocations.Add(location);
        //                    }

        //                    if (Enum.TryParse<SeverityLevel>(Severity, out var newSeverity))
        //                    {
        //                        if (newSeverity > MaxSeverity)
        //                        {
        //                            MaxSeverity = newSeverity;
        //                        }
        //                    }

        //                    AlertTextClass text = new AlertTextClass { Intro = Intro, Body = Body };

        //                    bool MatchFound = false;

        //                    foreach (var kext in AlertTextList)
        //                    {
        //                        if (kext.Intro == Intro & kext.Body == Body)
        //                        {
        //                            Console.WriteLine($"[Alert Processor] The contents of the current info tag match a previously processed tag.");
        //                            MatchFound = true;
        //                            continue;
        //                        }
        //                    }

        //                    if (!MatchFound)
        //                    {
        //                        AlertTextList.Add(text);
        //                        Console.WriteLine($"[Alert Processor] The contents of the current info tag have been added.");
        //                        continue;
        //                    }
        //                }
        //                else
        //                {
        //                    Console.WriteLine($"[Alert Processor] Alert discarded due to mobile alert settings, or other things.");
        //                }
        //            }

        //            Console.WriteLine("[Alert Processor] There is no further data to process.");

        //            string FullIntro = string.Empty;
        //            string FullBody = string.Empty;

        //            if (AlertTextList.Count == 0)
        //            {
        //                Console.WriteLine("[Alert Processor] There is no alert text to process.");
        //                AlertInfoList.Add(new AlertInfo { AlertDiscardReason = "The alert cannot be processed because no alert text exists." });
        //                continue;
        //            }
        //            else
        //            {
        //                int IncrementedList = 0;

        //                if (AlertTextList.Count > 1)
        //                {
        //                    foreach (var kext in AlertTextList)
        //                    {
        //                        IncrementedList++;
        //                        if (!string.IsNullOrWhiteSpace(kext.Intro)) FullIntro += $"\r\n\r\n{IncrementedList}.\x20" + kext.Intro;
        //                        if (!string.IsNullOrWhiteSpace(kext.Body)) FullBody += $"\r\n\r\n{IncrementedList}.\x20" + kext.Body;
        //                    }
        //                    FullIntro = FullIntro.Trim();
        //                    FullBody = FullBody.Trim();
        //                }
        //                else
        //                {
        //                    foreach (var kext in AlertTextList)
        //                    {
        //                        if (!string.IsNullOrWhiteSpace(kext.Intro)) FullIntro += kext.Intro;
        //                        if (!string.IsNullOrWhiteSpace(kext.Body)) FullBody += kext.Body;
        //                    }
        //                    FullIntro = FullIntro.Trim();
        //                    FullBody = FullBody.Trim();
        //                }

        //                if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.StationIdentifier))
        //                {
        //                    FullIntro = $"This message originates from {QuickSettings.Instance.StationIdentifier} ({QuickSettings.Instance.StationName}).\r\n\r\n{FullIntro}".Trim();
        //                }

        //                AlertTextClass _AlertText = new AlertTextClass
        //                {
        //                    Intro = FullIntro,
        //                    Body = FullBody
        //                };

        //                if (!IgnoreDiscards)
        //                {
        //                    // ???
        //                }
        //            }

        //            //if (AnyAlertRelayed)
        //            //{
        //            AlertsRelayed++;
        //            //}

        //            Console.WriteLine($"[Alert Processor] Processed all available entries. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");

        //            string AudioURL = AudioFiles.FirstOrDefault();
        //            string ImageURL = ImageFiles.FirstOrDefault();

        //            if (string.IsNullOrWhiteSpace(AudioURL)) AudioURL = string.Empty;
        //            if (string.IsNullOrWhiteSpace(ImageURL)) ImageURL = string.Empty;

        //            //MessageBox.Show(MaxSeverity.ToString());

        //            AlertInfoList.Add(new AlertInfo
        //            {
        //                // do something about alert IDs
        //                AlertSource = Source,
        //                AlertID = relayItem.Name,
        //                AlertSentDate = Sent,
        //                AlertExpiryDate = Expiry,
        //                AlertFriendlyLocations = AllLocations,
        //                AlertEventType = EventTypeFull,
        //                AlertMessageType = MsgType,
        //                AlertSeverity = MaxSeverity.ToString(),
        //                AlertIntroText = FullIntro.Trim(),
        //                AlertBodyText = FullBody.Trim(),
        //                AlertURL = PrimaryURL,
        //                AlertAudioURL = AudioURL,
        //                AlertImageURL = ImageURL
        //            });

        //            continue;
        //        }

        //        return AlertInfoList.ToArray();
        //    }
        //}

        //    AlertIDStr = id;
        //    this.Text = $"SharpAlert - {AlertIDStr}";
        //    AlertSubtitleStr = alert;
        //    SubtitleText.Text = AlertSubtitleStr;
        //    AlertIntroTextStr = intro;
        //    AlertTextStr = text;
        //    AlertText.Text = $"{AlertIntroTextStr}\r\n\r\n{AlertTextStr}";
        //    AlertUrlStr = url;
        //    AlertAudioUrlStr = audio;
        //    AlertImageUrlStr = image;
        //    AlertType = type;
        //    AlertText.SelectionLength = 0;
        //    AlertText.SelectionStart = 0;

        public static void ProcessExternalAlert(string AlertEvent, string AlertIntro, string AlertBody)
        {
            try
            {
                ThreadDrool.StartAndForget(() =>
                {
                    RelayWindow($"EXTERNAL_EVENT_{DateTime.UtcNow.Ticks}",
                        AlertEvent,
                        new AlertTextClass
                        { Intro = $"{AlertIntro}".Trim(), Body = $"{AlertBody}".Trim() },
                        string.Empty,
                        "alert",
                        "minor",
                        [""],
                        [""]);
                    //kill @e[type=!player,distance=..10]
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Alert Processor] Couldn't process an external alert. {ex.Message}");
            }
            finally
            {
                Console.WriteLine($"[Alert Processor] Finished processing an external alert.");
            }
        }
        
        public static void ProcessAlertTest(bool AutoFillInfo = false)
        {
            try
            {
                if (AutoFillInfo)
                {
                    string TestIdentifier = $"TEST_{DateTime.UtcNow.Ticks}";

                    string CompiledMessage = $"Test Alert | Location(s): Test Location"; // \r\n-# Process Time: {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms
                    if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhookAppend)) CompiledMessage += "\r\n" + QuickSettings.Instance.DiscordWebhookAppend;

                    DiscordWebhook.SendEmbeddedMessage(string.Empty,
                        CompiledMessage,
                        "Test Message",
                        "Test. Test. Test.",
                        Resources.TestScript,
                        "https://bunnytub.com/SharpAlert",
                        TestIdentifier,
                        [""],
                        [""]);

                    RelayWindow(TestIdentifier,
                        "Standard Test",
                        new AlertTextClass
                        { Intro = "Test. Test. Test.", Body = Resources.TestScript },
                        "https://bunnytub.com/SharpAlert",
                        "alert",
                        "severe",
                        [""],
                        [""]);
                }
                else
                {
                    ChooseTestForm ctf = new(false);
                    var result = ctf.ShowDialog();

                    if (result == DialogResult.Yes) ThreadDrool.StartAndForget(() =>
                    {
                        string Severity = "severe";

                        if (ctf.MarkAlertAsModerateInsteadOfSevereBox.Checked)
                        {
                            Severity = "moderate";
                        }

                        string TestIdentifier = $"TEST_{DateTime.UtcNow.Ticks}";

                        string CompiledMessage = $"{ctf.EventType} | Location(s): Test Location"; // \r\n-# Process Time: {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms
                        if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhookAppend)) CompiledMessage += "\r\n" + QuickSettings.Instance.DiscordWebhookAppend;

                        DiscordWebhook.SendEmbeddedMessage(string.Empty,
                            CompiledMessage,
                            "Test Message",
                            "Test. Test. Test.",
                            ctf.EventDescription,
                            ctf.EventURL,
                            TestIdentifier,
                            [""],
                            [""]);

                        RelayWindow(TestIdentifier,
                            ctf.EventType,
                            new AlertTextClass
                            { Intro = "Test. Test. Test.", Body = $"{ctf.EventDescription}" },
                            ctf.EventURL,
                            "alert",
                            Severity,
                            [""],
                            [""]);
                    });

                    ctf.Dispose();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Alert Processor] Couldn't test. {ex.Message}");
            }
            finally
            {
                Console.WriteLine($"[Alert Processor] Finished test.");
            }
        }

        public static (string, bool) GetAlertNameFromSAME(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return ("Cautionary (Unknown Event)", false);
            try
            {
                var alertEvent = SAME_AlertCodes.DefaultIfEmpty(cautionary);
                var alertInfo = alertEvent.FirstOrDefault(y => y.ID == code.ToUpperInvariant());

                if (alertInfo != null) return (alertInfo.Name, true);
                else return ("Cautionary (Unknown Event)", false);
            }
            catch (Exception)
            {
                //Console.WriteLine($"[Alert Processor] {ex.Message}");
                return ("Cautionary (Unknown Event)", false);
            }
        }

        // Checks severity, urgency, categories.
        // checks against the user settings, then returns true if all checks pass successfully. hopefully.
        public static bool ProcessInfoX(string InfoX)
        {
            Console.WriteLine("Processing InfoX.");
            bool Final = false;

            try
            {
                string Severity = SeverityRegex.MatchOrDefault(InfoX, "moderate").ToLowerInvariant();
                string Urgency = UrgencyRegex.MatchOrDefault(InfoX, "immediate").ToLowerInvariant();

                // Canadians have multiple categories, it's actually useful
                // it's not really useful

                MatchCollection Categories = CategoryRegex.Matches(InfoX);
                //string Category = CategoryRegex.MatchOrDefault(InfoX, "other").ToLowerInvariant();

                bool SeverityValue = false;
                bool UrgencyValue = false;
                bool CategoryValue = false;

                // got rid of this var123 nonsense, I hated that

                SeverityValue = Severity switch
                {
                    "extreme" => QuickSettings.Instance.severityExtreme,
                    "severe" => QuickSettings.Instance.severitySevere,
                    "moderate" => QuickSettings.Instance.severityModerate,
                    "minor" => QuickSettings.Instance.severityMinor,
                    "unknown" => QuickSettings.Instance.severityUnknown,
                    _ => QuickSettings.Instance.severityUnknown,
                };

                UrgencyValue = Urgency switch
                {
                    "immediate" => QuickSettings.Instance.urgencyImmediate,
                    "expected" => QuickSettings.Instance.urgencyExpected,
                    "future" => QuickSettings.Instance.urgencyFuture,
                    "past" => QuickSettings.Instance.urgencyPast,
                    "unknown" => QuickSettings.Instance.urgencyUnknown,
                    _ => QuickSettings.Instance.urgencyUnknown,
                };

                foreach (Match Category in Categories)
                {
                    CategoryValue = Category.Groups[1].Value switch
                    {
                        "geo" => QuickSettings.Instance.categoryGeophysical,
                        "met" => QuickSettings.Instance.categoryMeterological,
                        "safety" => QuickSettings.Instance.categoryGeneralSafety,
                        "security" => QuickSettings.Instance.categorySecurity,
                        "rescue" => QuickSettings.Instance.categoryRescue,
                        "fire" => QuickSettings.Instance.categoryFire,
                        "health" => QuickSettings.Instance.categoryMedical,
                        "env" => QuickSettings.Instance.categoryEnvironmental,
                        "transport" => QuickSettings.Instance.categoryTransportation,
                        "infra" => QuickSettings.Instance.categoryUtilities,
                        "cbrne" => QuickSettings.Instance.categoryToxicThreat,
                        "other" => QuickSettings.Instance.categoryOtherUnknown,
                        _ => QuickSettings.Instance.categoryOtherUnknown,
                    };

                    if (CategoryValue) break;
                }

                if (SeverityValue && UrgencyValue && CategoryValue)
                {
                    Final = true;
                    Console.WriteLine("[Alert Processor] Severity, urgency, and category, passed all checks.");
                }
                else
                {
                    Console.WriteLine($"[Alert Processor] Severity ({SeverityValue}) | Urgency ({UrgencyValue}) | Category ({CategoryValue}). Checks were not passed.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Alert Processor] Severity, urgency, and category checks couldn't complete. {ex.Message}");
                Final = false;
            }

            // do something with LanguageRegex
            // but he never did.

            if (Final)
            {
                bool LocationsMatch = false;

                if (QuickSettings.Instance.AllowedSAMELocations_Geocodes.Count == 0 &&
                    QuickSettings.Instance.AllowedCAPCPLocations_Geocodes.Count == 0 &&
                    QuickSettings.Instance.AllowedCustomLocations_GeocodesList.Count == 0)
                {
                    // if no locations are found, assume all locations are valid
                    Console.WriteLine("[Alert Processor] Any locations are allowed, because the configuration does not specify any.");   
                    return true;
                }

                // I don't even know how this works anymore
                // nvm figured it out

                // SAME
                if (QuickSettings.Instance.AllowedSAMELocations_Geocodes.Count != 0)
                {
                    StringCollection locations = [];
                    lock (QuickSettings.Instance.AllowedSAMELocations_Geocodes)
                    {
                        foreach (string location in QuickSettings.Instance.AllowedSAMELocations_Geocodes)
                        {
                            string loc = location;
                            if (loc.Length == 6) loc = loc[1..];
                            if (loc.Length != 5)
                            {
                                Console.WriteLine($"[Alert Processor] \"{loc}\" (from local) may not be a valid SAME code.");

                                // not returning?
                            }

                            if (!locations.Contains(loc))
                            {
                                locations.Add(loc);
                            }

                            // remove last three characters, replace with zeros, because it means that it is all locations
                            //string StatewideOnlyLocation = loc.Substring(0, loc.Length - 3) + "000";
                            //string AnyCountyLocation = loc.Substring(0, loc.Length - 3) + "***";

                            //if (!locations.Contains(StatewideOnlyLocation))
                            //{
                            //    locations.Add(StatewideOnlyLocation);
                            //}
                            
                            //if (!locations.Contains(AnyCountyLocation))
                            //{
                            //    locations.Add(AnyCountyLocation);
                            //}
                        }
                    }

                    try
                    {
                        MatchCollection matches = GeocodeSpecificAreaMessageEncodingRegex.Matches(InfoX);
                        bool GeoMatch = false;
                        foreach (Match match in matches)
                        {
                            string geocode = match.Groups[1].Value;

                            if (geocode.Length == 6) geocode = geocode[1..];
                            if (geocode.Length != 5)
                            {
                                Console.WriteLine($"[Alert Processor] \"{geocode}\" (from alert) may not be a valid SAME code.");
                            }

                            if (locations.Contains(geocode) || locations.Contains(string.Concat(geocode.AsSpan(0, 2), "***")))
                            {
                                GeoMatch = true;
                                Console.WriteLine($"[Alert Processor] \"{geocode}\" (from alert) matched one of the local SAME locations.");
                                break;
                            }
                            else
                            {
                                Console.WriteLine($"[Alert Processor] \"{geocode}\" (from alert) did not match any local SAME locations.");
                            }
                        }

                        if (GeoMatch)
                        {
                            LocationsMatch = true;
                            Console.WriteLine("[Alert Processor] One or more SAME locations were matched.");
                        }
                        else
                        {
                            Console.WriteLine("[Alert Processor] No SAME locations in the alert (including statewide codes) matched the local SAME locations.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Alert Processor] An unknown amount of locations were matched. {ex.Message}");
                    }
                }
                
                // CAP-CP
                if (QuickSettings.Instance.AllowedCAPCPLocations_Geocodes.Count != 0)
                {
                    try
                    {
                        //<geocode>
                        //  <valueName>profile:CAP-CP:Location:0.3</valueName>
                        //  <value>4718808</value>
                        //</geocode>

                        MatchCollection matches = GeocodeCommonAlertingProtocolCanadaLocationCodeRegex.Matches(InfoX);
                        bool GeoMatch = false;
                        foreach (Match match in matches)
                        {
                            string geocode = match.Groups[1].Value;
                            if (QuickSettings.Instance.AllowedCAPCPLocations_Geocodes.Contains(geocode))
                            {
                                GeoMatch = true;
                                break;
                            }
                        }

                        if (GeoMatch)
                        {
                            LocationsMatch = true;
                            Console.WriteLine("[Alert Processor] One or more CAP-CP locations were matched.");
                        }
                        else
                        {
                            Console.WriteLine("[Alert Processor] No locations matched the CAP-CP list.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Alert Processor] An unknown amount of locations were matched. {ex.Message}");
                    }
                }

                // CUSTOM
                if (QuickSettings.Instance.AllowedCustomLocations_GeocodesList.Count != 0)
                {
                    try
                    {
                        MatchCollection matches = GeocodeRegex.Matches(InfoX);
                        bool GeoMatch = false;
                        foreach (Match match in matches)
                        {
                            string GeocodeFull = match.Groups[1].Value.Trim();
                            string valueName = ValueNameRegex.MatchOrDefault(GeocodeFull).Trim();
                            string value = ValueRegex.MatchOrDefault(GeocodeFull).Trim();

                            foreach (var location in QuickSettings.Instance.AllowedCustomLocations_GeocodesList)
                            {
                                if (location.ValueName == valueName)
                                {
                                    if (location.Value.ToLowerInvariant() == value.ToLowerInvariant())
                                    {
                                        GeoMatch = true;
                                        break;
                                    }
                                }
                            }

                            if (GeoMatch) break;
                        }

                        if (GeoMatch)
                        {
                            LocationsMatch = true;
                            Console.WriteLine("[Alert Processor] One or more custom locations were matched.");
                        }
                        else
                        {
                            Console.WriteLine("[Alert Processor] No locations matched the custom list.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Alert Processor] An unknown amount of locations were matched. {ex.Message}");
                    }
                }

                if (!LocationsMatch)
                {
                    Console.WriteLine("[Alert Processor] No locations matched.");
                }
                else
                {
                    Console.WriteLine("[Alert Processor] Locations matched.");
                }

                return LocationsMatch;
            }
            else return false;
        }

        public static bool ProcessParameterX(string ParameterX)
        {
            Console.WriteLine("[Alert Processor] Processing ParemeterX.");

            if (QuickSettings.Instance.weaOnly)
            {
                if (WEAHandlingRegex.MatchOrDefault(ParameterX).ToLowerInvariant() == "imminent threat")
                {
                    return true;
                }

                if (WirelessImmediateRegex.MatchOrDefault(ParameterX).ToLowerInvariant() == "yes")
                {
                    return true;
                }
                
                return false;
            }
            else return true;
        }
        
        public static bool ProcessAlertX(string Status, string MsgType)
        {
            Console.WriteLine("[Alert Processor] Processing AlertX.");

            bool Final = false;

            // Status:
            // Actual
            // Exercise
            // Test

            switch (Status.ToLowerInvariant())
            {
                case "actual":
                    if (!QuickSettings.Instance.statusActual) return false;
                    break;
                case "exercise":
                    if (!QuickSettings.Instance.statusExercise) return false;
                    break;
                case "test":
                    if (!QuickSettings.Instance.statusTest) return false;
                    break;
                default:
                    break;
            }

            // MsgType:
            // Alert
            // Update
            // Cancel

            try
            {
                var MessageTypeValue = MsgType.ToLowerInvariant() switch
                {
                    "alert" => QuickSettings.Instance.messageTypeAlert,
                    "update" => QuickSettings.Instance.messageTypeUpdate,
                    "cancel" => QuickSettings.Instance.messageTypeCancel,
                    _ => QuickSettings.Instance.messageTypeAlert,
                };

                if (MessageTypeValue)
                {
                    Final = true;
                }
            }
            catch (Exception)
            {
                Final = false;
            }

            // do something with LanguageRegex

            if (Final)
            {
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
        public static (string Intro, string Body) CompiledBody(string InfoData, string MsgType, string Sent, string Source)
        {
            Console.WriteLine("[Alert Processor] Compiling body text.");
            string BroadcastText = string.Empty;

            //if (Replay)
            //{
            //    BroadcastText += $"This is a replay of the most recent alert.\x20";
            //}

            Console.WriteLine("[Alert Processor] Parsing message type.");

            string MsgPrefix = MsgType.ToLowerInvariant() switch
            {
                "alert" => string.Empty,
                "update" => "This alert has been updated.",
                "cancel" => "This alert has been cancelled.",
                _ => string.Empty,
            };

            Console.WriteLine("[Alert Processor] Parsing sent date.");

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

            Console.WriteLine("[Alert Processor] Parsing effective date.");

            DateTime effectiveDate;
            try
            {
                string effective = EffectiveRegex.MatchOrDefault(InfoData);
                if (QuickSettings.Instance.alertTimeZoneUTC)
                {
                    effectiveDate = DateTime.Parse(effective, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                }
                else
                {
                    effectiveDate = DateTime.Parse(effective, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal).ToLocalTime();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    if (QuickSettings.Instance.alertTimeZoneUTC)
                    {
                        effectiveDate = DateTime.Parse(Sent, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                    }
                    else
                    {
                        effectiveDate = DateTime.Parse(Sent, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal).ToLocalTime();
                    }
                }
                catch (Exception exx)
                {
                    Console.WriteLine(exx.Message);
                    effectiveDate = DateTime.UtcNow;
                }
            }

            Console.WriteLine("[Alert Processor] Parsing expiration date.");

            DateTime expiryDate;
            try
            {
                string expires = ExpiresRegex.MatchOrDefault(InfoData);
                if (QuickSettings.Instance.alertTimeZoneUTC)
                {
                    expiryDate = DateTime.Parse(expires, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                }
                else
                {
                    expiryDate = DateTime.Parse(expires, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal).ToLocalTime();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                if (QuickSettings.Instance.alertTimeZoneUTC)
                {
                    expiryDate = DateTime.UtcNow.AddHours(1);
                }
                else
                {
                    expiryDate = DateTime.UtcNow.AddHours(1).ToLocalTime();
                }
            }

            Console.WriteLine("[Alert Processor] Parsing time.");

            string TimeFormat = QuickSettings.Instance.Use24HrTime ? "HH:mm" : "hh:mm tt";
            string TimeZoneName = "Unknown TZ";

            if (QuickSettings.Instance.alertTimeZoneUTC) TimeZoneName = "UTC";
            else TimeZoneName = LocalTimeAbbreviation();

            string SentFormatted = $"{sentDate.ToString(TimeFormat)} {TimeZoneName}, {sentDate:MMMM dd}, {sentDate:yyyy}";
            string BeginFormatted = $"{effectiveDate.ToString(TimeFormat)} {TimeZoneName}, {effectiveDate:MMMM dd}, {effectiveDate:yyyy}";
            string EndFormatted = $"{expiryDate.ToString(TimeFormat)} {TimeZoneName}, {expiryDate:MMMM dd}, {expiryDate:yyyy}";

            Console.WriteLine("[Alert Processor] Parsing event type.");

            string EventType;
            try
            {
                EventType = EventRegex.Match(InfoData).Groups[1].Value;
                EventType = Regex.Replace(EventType.ToLowerInvariant(), @"(^\w)|(\s\w)", m => m.Value.ToUpperInvariant());
                EventType = $"{EventType}";
            }
            catch (Exception)
            {
                EventType = $"Cautionary (Unknown Event)";
            }

            Console.WriteLine("[Alert Processor] Parsing locations.");

            string AreaDesc = "Unspecified localities";

            try
            {
                var AreaDescription = AreaDescriptionRegex.Matches(InfoData);

                if (AreaDescription.Count != 0)
                {
                    Console.WriteLine("[Alert Processor] Parsing locations as SAME.");
                    string AppendedAreas = string.Empty;
                    string AppendedCodeAreas = string.Empty;

                    foreach (Match area in AreaDescription)
                    {
                        //AppendedAreas += area.Groups[1].Value.Replace(";", ",") + "\x20";
                        AppendedAreas += area.Groups[1].Value + "\x20";
                    }

                    AppendedAreas = AppendedAreas.Trim();
                    // Commenting out UGC for now, since we have no way to convert them to their friendly names at the moment.

                    var GeocodeSAMEAreas = GeocodeSpecificAreaMessageEncodingRegex.Matches(InfoData);
                    //var GeocodeUGCAreas = GeocodeUniversalGeographicCodeRegex.Matches(InfoData);

                    foreach (Match code in GeocodeSAMEAreas)
                    {
                        AppendedCodeAreas += $"{GetFriendlyNameFromSAMELocation(code.Groups[1].Value[1..])};\x20";
                    }

                    //foreach (Match code in GeocodeUGCAreas)
                    //{
                    //    AppendedCodeAreas += $"UGC geocode {code.Groups[1].Value},\x20";
                    //}

                    //if (AppendedCodeAreas.Split(',').Length > AppendedAreas.Split(',').Length)
                    {
                        if (!string.IsNullOrWhiteSpace(AppendedCodeAreas))
                        {
                            AreaDesc = SentenceAppendEnd(SentencePuncuationCorrection(AppendedCodeAreas.Trim()));
                            if (AreaDesc.EndsWith(";."))
                            {
                                AreaDesc = SentenceAppendEnd(AreaDesc[..^2]);
                            }
                        }
                        else
                        {
                            AreaDesc = AppendedAreas + ".";
                        }
                    }
                    //else
                    //{
                    //    AreaDesc = AppendedAreas + ".";
                    //}

                    //string[] areaDescMatches = AreaDescription
                    //.Cast<Match>()
                    //.Select(m => m.Groups[1].Value)
                    //.ToArray();

                    //AreaDesc = string.Join(", ", areaDescMatches) + ".";

                    // "For: FIPS" / "For: AffectedArea" problem
                }
                else
                {
                    Console.WriteLine("[Alert Processor] Parsing locations as raw data.");
                }
            }
            catch (Exception)
            {
            }

            Console.WriteLine("[Alert Processor] Parsing sender name.");

            string SenderName;

            try
            {
                //MatchCollection SenderNames = SenderNameRegex.Matches(InfoData);
                //string UnfilteredSenderNames = string.Empty;

                //foreach (Match match in SenderNames)
                //{
                //    UnfilteredSenderNames += $"{match.Groups[1].Value}\x20";
                //}

                SenderName = SenderNameRegex.MatchOrDefault(InfoData).Replace(",", ",\x20");

                if (string.IsNullOrWhiteSpace(SenderName))
                {
                    SenderName = AuthorNameRegex.MatchOrDefault(InfoData).Replace(",", ",\x20");
                }

                if (string.IsNullOrWhiteSpace(SenderName))
                {
                    SenderName = "Governing Entity (Unknown Sender)";
                }
                else
                {
                    // only split when needed, such as when there might be multiple senders?
                    // why can't those agencies just use separate sender tags? why must we do this?
                    
                    if (SenderName.Contains(','))
                    {
                        string[] senders = SenderName.Split(',');
                        List<string> uniqueSenders = [];

                        foreach (string sender in senders)
                        {
                            string trimmed = sender.Trim();
                            bool alreadyExists = uniqueSenders.Exists(s =>
                                s.Equals(trimmed, StringComparison.InvariantCultureIgnoreCase));

                            if (!alreadyExists)
                            {
                                uniqueSenders.Add(trimmed);
                            }
                        }

                        SenderName = string.Join("; ", uniqueSenders);
                    }

                    // finally fixed that stupid name duplication bug. Thank you Stack Overflow.
                }
            }
            catch (Exception)
            {
                SenderName = "Governing Entity (Unknown Sender)";
            }

            Console.WriteLine("[Alert Processor] Parsing description text.");

            string Description;

            try
            {
                //Description = SentenceAppendEnd(DescriptionRegex.Match(InfoData).Groups[1].Value.Replace("\r\n", " ").Replace("\n", " "));
                Description = SentenceAppendEnd(DescriptionRegex.MatchOrDefault(InfoData));
            }
            catch (Exception)
            {
                Description = "";
            }

            Console.WriteLine("[Alert Processor] Parsing instruction text.");

            string Instruction;

            try
            {
                //Instruction = SentenceAppendEnd(InstructionRegex.Match(InfoData).Groups[1].Value.Replace("\r\n", " ").Replace("\n", " "));
                Instruction = SentenceAppendEnd(InstructionRegex.MatchOrDefault(InfoData));
            }
            catch (Exception)
            {
                Instruction = "";
            }

            Console.WriteLine("[Alert Processor] Parsing mobile broadcast text.");

            string SOREM_BroadcastText = BroadcastTextRegex.MatchOrDefault(InfoData);

            if (string.IsNullOrWhiteSpace(SOREM_BroadcastText))
            {
                if (string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(Instruction) || QuickSettings.Instance.UseCMAMTextWhereAvailable)
                {
                    try
                    {
                        string cmam = CMAMRegex.MatchOrDefault(InfoData);
                        if (!string.IsNullOrWhiteSpace(cmam))
                        {
                            Description = cmam;
                        }
                        
                        string cmamLong = CMAMLongRegex.MatchOrDefault(InfoData);
                        if (!string.IsNullOrWhiteSpace(cmamLong))
                        {
                            Instruction = cmamLong;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(Instruction) || QuickSettings.Instance.UseCMAMTextWhereAvailable)
                {
                    try
                    {
                        string wirelessText = WirelessTextRegex.MatchOrDefault(InfoData);
                        if (!string.IsNullOrWhiteSpace(wirelessText))
                        {
                            Description = wirelessText;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }

                //if (string.IsNullOrWhiteSpace(Instruction))
                //{
                //    try
                //    {
                //        string wirelessText = WirelessTextRegex.MatchOrDefault(InfoData);
                //        if (!string.IsNullOrWhiteSpace(wirelessText))
                //        {
                //            Instruction = wirelessText;
                //        }
                //    }
                //    catch (Exception)
                //    {
                //        Instruction = string.Empty;
                //    }
                //}
            }

            if (string.IsNullOrWhiteSpace(Description) & string.IsNullOrWhiteSpace(Instruction))
            {
                Console.WriteLine("[Alert Processor] No description and instruction set.");
                Description = "The alert information is limited or unavailable at the moment.";
                Instruction = string.Empty;
            }

            Console.WriteLine("[Alert Processor] Compiling intro text.");

            string IntroText = string.Empty;

            if (QuickSettings.Instance.AddIntroText)
            {
                //if (true)
                //{
                    if (QuickSettings.Instance.AddEventName) IntroText += $"{EventType}." + "\x20";
                    IntroText += $"{MsgPrefix} For the following, {SentenceAppendEnd(AreaDesc)}".Replace("\x20\x20", "\x20").Trim() + "\x20";
                    if (QuickSettings.Instance.AddAlertEffectiveAndEndingTimes) IntroText += $"This alert begins {BeginFormatted}, and ends at {EndFormatted}." + "\x20";
                    if (QuickSettings.Instance.AddAlertIssuer) IntroText += $"Issued by {SenderName}." + "\x20";
                    if (QuickSettings.Instance.AddSourcedFrom) IntroText += $"Sourced from {Source}." + "\x20";
                    IntroText = IntroText.Replace("\r\n", "\n").Replace("\n", "\r\n");
                //}
                //else
                //{
                //    // AN EAS PARTICIPANT HAS ISSUED A PRACTICE/DEMO WARNING
                //    // FOR THE FOLLOWING COUNTIES/AREAS: Apathy, AZ; Orange, FL; Volusia, FL.
                //    // At 08:17 AM, September 05, 2025. Effective until 08:30 PM. Message from LocalSender.

                //    if (QuickSettings.Instance.AddAlertIssuer) IntroText += $"Issued by {SenderName}." + "\x20";
                //    if (QuickSettings.Instance.AddAlertEffectiveAndEndingTimes) IntroText += $"This alert starts {BeginFormatted}, and ends at {EndFormatted}." + "\x20";
                //    if (QuickSettings.Instance.AddSourcedFrom) IntroText += $"Sourced from {Source}." + "\x20";
                //    if (QuickSettings.Instance.AddEventName) IntroText += $"Event type is {EventType}." + "\x20";
                //    IntroText += $"{MsgPrefix} For the following areas, {SentenceAppendEnd(AreaDesc)}".Replace("\x20\x20", "\x20");
                //    IntroText = IntroText.Replace("\r\n", "\n").Replace("\n", "\r\n"); // fix mixed newline problems hopefully
                //}
            }
            else
            {
                IntroText = "...";
            }

            Console.WriteLine("[Alert Processor] Finished compiling intro text.");

            BroadcastText += SentenceAppendEnd(Description) + "\x20";
            if (Description != Instruction) BroadcastText += SentenceAppendEnd(Instruction) + "\x20";
            BroadcastText = BroadcastText.Replace("###", string.Empty);
            //BroadcastText = BroadcastText.Replace(" E A S ", " EAS ");
            //BroadcastText = BroadcastText.Replace(" 9 1 1 ", " 9-1-1 ");
            BroadcastText = SentencePuncuationCorrection(BroadcastText).Replace(",", ",\x20");
            BroadcastText = BroadcastText.Replace("\r\n", "\n").Replace("\n", "\r\n"); // fix mixed newline problems hopefully
            BroadcastText = BroadcastText.Replace("\r\n\r\n\r\n\r\n", "\r\n\r\n").Replace("\r\n\r\n\r\n", "\r\n\r\n"); // fix spacing
            BroadcastText = SentenceAppendEnd(BroadcastText);
            BroadcastText = TimeCorrection(BroadcastText);
            BroadcastText = BroadcastText.TrimStart('.').TrimStart(',');
            BroadcastText = string.Join(" ", BroadcastText.Split([" "], StringSplitOptions.RemoveEmptyEntries)).Trim();

            // It should not be this painful to fix text formatting.

            Console.WriteLine("[Alert Processor] Finished compiling body text.");
            return (IntroText, BroadcastText);
        }
        
        public static List<string> CompiledLocations(string InfoData)
        {
            try
            {
                var AreaDescription = AreaDescriptionRegex.Matches(InfoData);

                if (AreaDescription.Count != 0)
                {
                    string AppendedAreas = string.Empty;
                    string AppendedCodeAreas = string.Empty;

                    foreach (Match area in AreaDescription)
                    {
                        //AppendedAreas += area.Groups[1].Value.Replace(";", ",") + "\x20";
                        AppendedAreas += area.Groups[1].Value + "\x20";
                    }

                    AppendedAreas = AppendedAreas.Trim();
                    // Commenting out UGC for now, since we have no way to convert them to their friendly names at the moment.

                    var GeocodeSAMEAreas = GeocodeSpecificAreaMessageEncodingRegex.Matches(InfoData);
                    //var GeocodeUGCAreas = GeocodeUniversalGeographicCodeRegex.Matches(InfoData);

                    foreach (Match code in GeocodeSAMEAreas)
                    {
                        AppendedCodeAreas += $"{GetFriendlyNameFromSAMELocation(code.Groups[1].Value[1..])};\x20";
                    }

                    //foreach (Match code in GeocodeUGCAreas)
                    //{
                    //    AppendedCodeAreas += $"UGC geocode {code.Groups[1].Value},\x20";
                    //}

                    string AreaDesc = string.Empty;

                    //if (AppendedCodeAreas.Split(',').Length > AppendedAreas.Split(',').Length)
                    {
                        if (!string.IsNullOrWhiteSpace(AppendedCodeAreas))
                        {
                            //AreaDesc = SentenceAppendEnd(SentencePuncuationCorrection(AppendedCodeAreas.Trim()));
                            AreaDesc = SentencePuncuationRemoval(AppendedCodeAreas.Trim());
                            if (AreaDesc.EndsWith(""))
                            {
                                //AreaDesc = SentenceAppendEnd(AreaDesc.Substring(0, AreaDesc.Length - 2));
                                //AreaDesc = AreaDesc.Substring(0, AreaDesc.Length - 2);
                            }
                        }
                        else
                        {
                            //AreaDesc = AppendedAreas + ".";
                            AreaDesc = AppendedAreas;
                        }
                    }
                    //else
                    //{
                    //    AreaDesc = AppendedAreas + ".";
                    //}

                    //string[] areaDescMatches = AreaDescription
                    //.Cast<Match>()
                    //.Select(m => m.Groups[1].Value)
                    //.ToArray();

                    //AreaDesc = string.Join(", ", areaDescMatches) + ".";

                    // "For: FIPS" / "For: AffectedArea" problem
                    return [.. AreaDesc.Split(';')];
                }
                return ["Unparsable Location(s)"];
            }
            catch (Exception)
            {
                return ["Unknown Location(s)"];
            }
        }

        public static string StringIntoTTSFriendly(string Data)
        {
            string FriendlyData = Data;
            //FriendlyData = FriendlyData.Replace("\r", string.Empty).Replace("\n", ".");
            FriendlyData = FriendlyData.Replace(" EAS ", " Emergency Alert System ");
            FriendlyData = FriendlyData.Replace(" 911 ", " 9 1 1 ")
                .Replace(" 9-1-1 ", " 9 1 1 ")
                .Replace(" WEA ", " W E A ")
                .Replace(" NWS ", " N W S ")
                .Replace(" NOAA ", " N O A A ");
                //.Replace("WEA", "Wireless Emergency Alerts")
                //.Replace("NWS", "National Weather Service")
                //.Replace("NOAA", "National Oceanic and Atmospheric Administration");
            return FriendlyData;
        }

        public static string GetFriendlyNameFromSAMELocation(string code)
        {
            // stop reliance on external sources for retriving locations
            // and as a benefit, we can finally get full state names
            var codeValue = GetFriendlyNameFromSAMELocationLocally(code);

            if (codeValue.Item2)
            {
                return codeValue.Item1;
            }

            try
            {
                //if (string.IsNullOrWhiteSpace(CacheCapture.SAME_US_JSON)) MainEntryPoint.cache.ServiceRun(false);
                if (!string.IsNullOrWhiteSpace(CacheCapture.SAME_US_JSON))
                {
                    using JsonDocument doc = JsonDocument.Parse(CacheCapture.SAME_US_JSON);
                    JsonElement root = doc.RootElement;
                    JsonElement same = root.GetProperty("SAME");

                    if (same.TryGetProperty(code, out JsonElement hereSAME))
                    {
                        return hereSAME.GetString();
                    }
                    else
                    {
                        if (code.Length == 6)
                        {
                            if (same.TryGetProperty(code.AsSpan(1), out JsonElement subSAME))
                            {
                                return subSAME.GetString();
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("[Alert Processor] The SAME location cache is unavailable.");
                    return $"{code} (Cache Unavailable)";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Alert Processor] {ex.Message}");
                return $"{code} (Unavailable For Translation)";
            }

            return $"{code} (Unknown Location)";
        }

        public static (string, bool) GetFriendlyNameFromSAMELocationLocally(string code)
        {
            if (string.IsNullOrWhiteSpace(code))
            {
                return ("??? (Empty Location)", false);
            }

            code = code.Trim();

            string UnknownLocation = $"{code} (Unknown Location)";
            string InvalidLocation = $"{code} (Invalid Location)";
            string NonIntegerLocation = $"{code} (Non-Integer Location)";

            if (!int.TryParse(code, out int _))
            {
                Console.WriteLine($"[Alert Processor] The SAME location code \"{code}\" is not an integer.");
                return (NonIntegerLocation, false);
            }

            try
            {
                // PSSCCC

                // two digit state code comes first, then three digit county code

                if (code.Length != 5)
                {
                    if (code.Length == 6)
                    {
                        code = code[1..];
                    }
                    else
                    {
                        Console.WriteLine($"[Alert Processor] The SAME location code \"{code}\" is not within a correct length (5-6).");
                        return (InvalidLocation, false);
                    }
                }

                Console.WriteLine($"[Alert Processor] The SAME location code \"{code}\" is being processed.");

                // This might be inefficient, but we're not running this software on fucking a Pentium II.
                // Save the optimization tricks for a rainy day.

                // P
                //unused

                // SS
                int StateCode = int.Parse(code[..2]);
                SAME_StateCode SavedState = null;

                foreach (var state in States)
                {
                    if (state.Id == StateCode)
                    {
                        Console.WriteLine($"[Alert Processor] State detected from \"{code}\" SAME location code as {state.Name}.");
                        SavedState = state;
                        break;
                    }
                }

                if (SavedState == null)
                {
                    return (UnknownLocation, false);
                }

                // we found a state, wow!

                // CCC
                int CountyCode = int.Parse(code[2..]);
                int SavedCountyCode = -1;
                SAME_CountyCode SavedCounty = null;

                foreach (var county in Counties)
                {
                    if (county.State.Id == SavedState.Id)
                    {
                        if (county.Id == CountyCode)
                        {
                            Console.WriteLine($"[Alert Processor] County detected from \"{code}\" SAME location code as {county.Name}.");
                            SavedCountyCode = county.Id;
                            SavedCounty = county;
                            break;
                        }
                    }
                }

                if (SavedCounty == null)
                {
                    // we only found a state

                    // do we return true for partial matches? or return false?
                    return ($"{CountyCode}, {SavedState.Name} (Unknown County)", true);
                }

                return ($"{SavedCounty.Name}, {SavedCounty.State.Name}", true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Alert Processor] Processing of the SAME location failed. {ex.Message}");
                //IceBearWorker.UnsafeFault(ex, false);
                return ($"{code} (Unknown Location)", false);
            }
        }

        static string SentenceAppendEnd(string value)
        {
            value = value.Trim();

            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return value.EndsWith('.') || value.EndsWith('!') || value.EndsWith(',') ? string.Concat(value.AsSpan(0, value.Length - 1), ".") : (value += ".");
        }

        static string SentencePuncuationCorrection(string value)
        {
            value = value.Trim();
            while (value.EndsWith("\x20.") || value.EndsWith("\x20!") || value.EndsWith("\x20,"))
            {
                value = value[..^1];
            }
            value = value.Replace("...", ",").Replace("..", ".");
            return SentenceAppendEnd(value[..^1]);
        }
        
        static string SentencePuncuationRemoval(string value)
        {
            value = value.Trim();
            while (value.EndsWith('.') || value.EndsWith('!') || value.EndsWith(','))
            {
                value = value[..^1];
            }
            return value;
        }

        static string TimeCorrection(string value)
        {
            //Regex TimeCorrectionRegex = new Regex(@"\b(\d{1,4})\s*(AM|PM)\b", RegexOptions.IgnoreCase);

            return TimeCorrectionRegex.Replace(value, timeMatch =>
            {
                string timePart = timeMatch.Groups[1].Value.PadLeft(4, '0');
                string meridian = timeMatch.Groups[2].Value.ToUpperInvariant();

                return DateTime.ParseExact(timePart, "hhmm", CultureInfo.InvariantCulture)
                .ToString("hh:mm tt", CultureInfo.InvariantCulture);
            });
        }

        private static string LocalTimeAbbreviation()
        {
            return string.Concat(TimeZoneInfo.Local.StandardName.Split(' ').Select(word => word[..1]));

            //var localTimeZone = TimeZoneInfo.Local;
            //var isDaylight = localTimeZone.IsDaylightSavingTime(DateTime.Now);

            //if (isDaylight)
            //    return localTimeZone.DaylightName.Substring(0, 3);
            //else
            //    return localTimeZone.StandardName.Substring(0, 3);
        }

        public static (string text, Color MainColor, Color SubColor) GetTextFromMessageSeverityAndType(string severity, string type)
        {
            if (type.ToLowerInvariant() == "cancel")
            {
                return ("ALERT CANCELLED", Color.FromArgb(0, 80, 200), Color.FromArgb(0, 50, 100));
            }

            //switch (type.ToLower())
            //{
            //    case "bulletin":
            //        return ("SYSTEM BULLETIN", Color.Red, Color.FromArgb(160, 0, 0));
            //    case "update":
            //        return ("ALERT UPDATE", Color.FromArgb(255, 112, 0), Color.FromArgb(200, 82, 80));
            //    case "cancel":
            //        return ("ALERT CANCELLED", Color.FromArgb(0, 80, 200), Color.FromArgb(0, 50, 100));
            //    case "test":
            //        return ("TEST MESSAGE", Color.Gray, Color.LightGray);
            //    case "alert":
            //    default:
            //        return ("EMERGENCY ALERT", Color.Red, Color.FromArgb(160, 0, 0));
            //}

            switch (severity.ToLowerInvariant())
            {
                case "extreme":
                    return ("EXTREME ALERT", Color.MediumOrchid, Color.Purple);
                case "severe":
                    return ("SEVERE ALERT", Color.Red, Color.FromArgb(160, 0, 0));
                case "moderate":
                    return ("MODERATE ALERT", Color.FromArgb(255, 112, 0), Color.FromArgb(200, 82, 80));
                case "minor":
                    return ("MINOR ALERT", Color.Green, Color.FromArgb(0, 80, 80));
                case "unknown":
                default:
                    return ("UNKNOWN ALERT", Color.FromArgb(255, 112, 0), Color.FromArgb(200, 82, 80));
            }
        }
    }
}

