using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;
using static SharpAlert.RegexList;
using static SharpAlert.AlertDisplayer;
using System.Drawing;

namespace SharpAlert
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
            StartRAFCallLoop();
            StartTAFCallLoop();
            StartMAFCallLoop();
            StartSAFCallLoop();
        }

        public static readonly object AlertLock = new object();

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

                if (AlertsProcessedBeforeGC >= 50)
                {
                    AlertsProcessedBeforeGC = 0;
                    ThreadDrool.StartAndForget(() =>
                    {
                        Console.WriteLine("[Alert Processor] Collecting garbage globally.");
                        GC.Collect();
                    });
                }
            }
        }
        public bool AlertInProcessing { get; private set; } = false;

        //bool DoNotAddToCount
        public AlertInfo ProcessAlertItem(SharpDataItem relayItem, bool ReplayMode, bool IgnoreDiscards)
        {
            AlertInProcessing = true;
            ConsoleExt.WriteLine($"[Alert Processor] Beginning processing -> {relayItem.Name}");
            //if (!DoNotAddToCount) AlertsProcessing++;
            AlertsProcessing++;
            var info = SubProcessAlertItem(relayItem, ReplayMode, IgnoreDiscards);
            //if (!DoNotAddToCount) AlertsProcessing--;
            AlertsProcessing--;
            ConsoleExt.WriteLine($"[Alert Processor] Finished processing -> {relayItem.Name}");
            AlertInProcessing = false;
            return info;
        }

        public class AlertInfo
        {
            public string AlertDiscardReason { get; set; } = string.Empty;
            public string AlertID { get; set; } = string.Empty;
            public string AlertEventType { get; set; } = string.Empty;
            public string AlertMessageType { get; set; } = string.Empty;
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
                DateTime startProc = DateTime.UtcNow;

                //DiscordWebhook.SendUnformattedMessage($"Processing incoming alert item. ({startProc:O} UTC)");

                bool AnyAlertRelayed = false;
                bool UsedDiscordHook = false;

                string Sent = SentRegex.MatchOrDefault(relayItem.Data, DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));

                ConsoleExt.WriteLine($"[Alert Processor] Sent: {Sent}");

                string Status = StatusRegex.MatchOrDefault(relayItem.Data, "actual");
                ConsoleExt.WriteLine($"[Alert Processor] Status: {Status}");

                string MsgType = MessageTypeRegex.MatchOrDefault(relayItem.Data, "alert");
                ConsoleExt.WriteLine($"[Alert Processor] Message Type: {MsgType}");

                ConsoleExt.WriteLine($"[Alert Processor] Replay (internal flag): {ReplayMode}");

                MatchCollection infoMatches = InfoRegex.Matches(relayItem.Data);
                bool final = false;

                if (!ProcessAlertX(Status, MsgType))
                {
                    ConsoleExt.WriteLine($"[Alert Processor] Alert discarded due to status/message_type settings.");
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
                            final = true;
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                        ConsoleExt.WriteLine($"[Alert Processor] An info tag couldn't processed. {ex.Message}");
                    }
                }

                if (!final)
                {
                    ConsoleExt.WriteLine($"[Alert Processor] Alert discarded due to urgency/category settings.");
                    //DiscordWebhook.SendUnformattedMessage($"The incoming alert was discarded. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");
                    if (!IgnoreDiscards)
                    {
                        return new AlertInfo { AlertDiscardReason = "The alert was blocked because of your urgency, or category settings." };
                    }
                }

                int infoProc = 0;

                List<string> AllEvents = new List<string>();
                List<string> AllLocations = new List<string>();
                SeverityLevel MaxSeverity = SeverityLevel.Unknown;

                List<string> AudioFiles = new List<string>();
                List<string> DerefAudioFiles = new List<string>();
                List<string> ImageFiles = new List<string>();
                List<string> DerefImageFiles = new List<string>();
                List<AlertTextClass> AlertTextList = new List<AlertTextClass>();
                string Expiry = string.Empty;
                string EventTypeFull = string.Empty;
                string PrimaryURL = string.Empty;

                foreach (Match infoMatch in infoMatches)
                {
                    infoProc++;
                    ConsoleExt.WriteLine($"[Alert Processor] Processing {infoProc} of {infoMatches.Count}.");

                    string AlertInfo = $"{infoMatch.Groups[1].Value}";

                    string Effective = EffectiveRegex.MatchOrDefault(relayItem.Data, DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));
                    ConsoleExt.WriteLine($"[Alert Processor] Effective: {Effective}");

                    Expiry = ExpiresRegex.MatchOrDefault(relayItem.Data, DateTime.UtcNow.AddHours(1).ToString("O", CultureInfo.InvariantCulture));
                    ConsoleExt.WriteLine($"[Alert Processor] Expires: {Expiry}");

                    //https://www.iana.org/assignments/language-subtag-registry/language-subtag-registry
                    string BCP47Language = LanguageRegex.MatchOrDefault(AlertInfo, "en-US");
                    ConsoleExt.WriteLine($"[Alert Processor] Language: {BCP47Language}");

                    string URL = WebRegex.MatchOrDefault(AlertInfo, string.Empty);
                    string Web = WebRegex.MatchOrDefault(AlertInfo, string.Empty);
                    ConsoleExt.WriteLine($"[Alert Processor] Associated URL (if any): {URL}");
                    ConsoleExt.WriteLine($"[Alert Processor] Associated Web (if any): {Web}");
                    if (string.IsNullOrWhiteSpace(PrimaryURL)) PrimaryURL = URL;
                    if (string.IsNullOrWhiteSpace(PrimaryURL)) PrimaryURL = Web;

                    string EventName = Regex.Replace(EventRegex.MatchOrDefault(AlertInfo, "Cautionary (Unknown Event)"), @"(^\w)|(\s\w)", m => m.Value.ToUpperInvariant());
                    ConsoleExt.WriteLine($"[Alert Processor] Event Name: {EventName}");

                    string EventType = EventCodeRegex.MatchOrDefault(AlertInfo, "???");
                    var (EventTypeTranslated, TranslationSuccessful) = GetAlertNameFromSAME(EventType);
                    ConsoleExt.WriteLine($"[Alert Processor] Event: {EventType}");
                    ConsoleExt.WriteLine($"[Alert Processor] Event (SAME Translation): {EventTypeTranslated}");

                    if (!IgnoreDiscards)
                    {
                        if (!PrimaryURL.Contains("sasmex.net"))
                        {
                            if (!QuickSettings.Instance.AllowNonEnglishAlerts)
                            {
                                if (!BCP47Language.ToLowerInvariant().StartsWith("en-"))
                                {
                                    ConsoleExt.WriteLine("[Alert Processor] Info tag discarded because it does not contain English information.");
                                    continue;
                                }
                            }
                        }
                    }

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
                    ConsoleExt.WriteLine($"[Alert Processor] Urgency: {Urgency}");

                    string Severity = SeverityRegex.MatchOrDefault(AlertInfo, "Unknown");
                    ConsoleExt.WriteLine($"[Alert Processor] Severity: {Severity}");

                    int ResourceCount = 0;
                    MatchCollection MatchedResources = ResourceRegex.Matches(AlertInfo);
                    foreach (Match resource in MatchedResources)
                    {
                        ResourceCount++;
                        ConsoleExt.WriteLine($"[Alert Processor] Resource {ResourceCount} Value: {resource.Groups[1].Value}");
                        var desc = ResourceDescRegex.MatchOrDefault(resource.Groups[1].Value);
                        ConsoleExt.WriteLine($"[Alert Processor] Resource {ResourceCount} Description: {desc}");
                        var mime = MIMETypeRegex.MatchOrDefault(resource.Groups[1].Value);
                        ConsoleExt.WriteLine($"[Alert Processor] Resource {ResourceCount} MIME Type: {mime}");
                        var size = SizeRegex.MatchOrDefault(resource.Groups[1].Value);
                        ConsoleExt.WriteLine($"[Alert Processor] Resource {ResourceCount} Size (if any): {size}");
                        var uri = URIRegex.MatchOrDefault(resource.Groups[1].Value);
                        ConsoleExt.WriteLine($"[Alert Processor] Resource {ResourceCount} URI (if any): {uri}");
                        var derefUri = DerefURIRegex.MatchOrDefault(resource.Groups[1].Value);
                        ConsoleExt.WriteLine($"[Alert Processor] Resource {ResourceCount} Dereference URI (if any): {derefUri}");
                        var digest = DigestSecureHashAlgorithmOneRegex.MatchOrDefault(resource.Groups[1].Value);
                        ConsoleExt.WriteLine($"[Alert Processor] Resource {ResourceCount} SHA-1 (if any | unused): {digest}");

                        void AddAudioToList()
                        {
                            if (!string.IsNullOrWhiteSpace(uri))
                            {
                                //if (string.IsNullOrWhiteSpace(derefUri))
                                {
                                    AudioFiles.Add(uri);
                                    ConsoleExt.WriteLine($"[Alert Processor] Resource {ResourceCount} was added to the audio list.");
                                }
                                //else
                                {
                                    // work on this
                                }
                            }
                            else ConsoleExt.WriteLine($"[Alert Processor] Resource {ResourceCount} has no URI.");
                        }
                        
                        void AddImageToList()
                        {
                            if (!string.IsNullOrWhiteSpace(uri))
                            {
                                ImageFiles.Add(uri);
                                ConsoleExt.WriteLine($"[Alert Processor] Resource {ResourceCount} was added to the image list.");
                            }
                            else ConsoleExt.WriteLine($"[Alert Processor] Resource {ResourceCount} has no URI.");
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

                    if (!IgnoreDiscards)
                    {
                        if (!ReplayMode)
                        {
                            try
                            {
                                if (DateTime.Parse(Expiry, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal) <= DateTime.Now)
                                {
                                    ConsoleExt.WriteLine($"[Alert Processor] Info tag discarded because it has expired.");
                                    continue;
                                }
                            }
                            catch (Exception ex)
                            {
                                ConsoleExt.WriteLine($"[Alert Processor] Expiry check skipped because it has failed. {ex.Message}");
                            }
                        }
                        else
                        {
                            ConsoleExt.WriteLine($"[Alert Processor] Expiry check skipped because the alert is being replayed.");
                        }
                    }
                    else
                    {
                        ConsoleExt.WriteLine($"[Alert Processor] Expiry check skipped because discards are being ignored.");
                    }

                    bool EventBlacklisted = false;

                    if (ProcessParameterX(AlertInfo) ||
                        BroadcastImmediatelyRegex.MatchOrDefault(AlertInfo, "no").ToLowerInvariant() == "yes" || IgnoreDiscards)
                    {
                        if (!IgnoreDiscards)
                        {
                            foreach (string Event in QuickSettings.Instance.EnforceEventBlacklist)
                            {
                                if (EventName.ToLowerInvariant().Contains(Event.ToLowerInvariant()))
                                {
                                    EventBlacklisted = true;
                                    break;
                                }
                            }

                            foreach (string SAMEEvent in QuickSettings.Instance.EnforceSAMEEventBlacklist)
                            {
                                if (EventType.ToLowerInvariant().Contains(SAMEEvent.ToLowerInvariant()))
                                {
                                    EventBlacklisted = true;
                                    break;
                                }
                            }

                            if (EventBlacklisted)
                            {
                                ConsoleExt.WriteLine($"[Alert Processor] Info tag discarded due to one or more blacklisted items.");
                                continue;
                            }
                        }
                        else
                        {
                            ConsoleExt.WriteLine($"[Alert Processor] Blacklist check skipped because discards are being ignored.");
                        }

                        // removal of replay boolean
                        var (Intro, Body) = CompiledBody(AlertInfo, MsgType, Sent);

                        ConsoleExt.WriteLine($"[Alert Processor] Intro: {Intro}");
                        ConsoleExt.WriteLine($"[Alert Processor] Body: {Body}");

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

                        AlertTextClass text = new AlertTextClass { Intro = Intro, Body = Body };

                        bool MatchFound = false;

                        foreach (var kext in AlertTextList)
                        {
                            if (kext.Intro == Intro & kext.Body == Body)
                            {
                                ConsoleExt.WriteLine($"[Alert Processor] The contents of the current info tag match a previously processed tag.");
                                MatchFound = true;
                                continue;
                            }
                        }

                        if (!MatchFound)
                        {
                            AlertTextList.Add(text);
                            ConsoleExt.WriteLine($"[Alert Processor] The contents of the current info tag have been added.");
                            continue;
                        }
                    }
                    else
                    {
                        ConsoleExt.WriteLine($"[Alert Processor] Alert discarded due to mobile alert settings, or other things.");
                    }
                }

                ConsoleExt.WriteLine("[Alert Processor] There is no further data to process.");

                string FullIntro = string.Empty;
                string FullBody = string.Empty;

                if (AlertTextList.Count == 0)
                {
                    ConsoleExt.WriteLine("[Alert Processor] There is no alert text to process.");
                    return new AlertInfo { AlertDiscardReason = "The alert cannot be processed because no alert text exists (somehow)." };
                }
                else
                {
                    int IncrementedList = 0;

                    if (AlertTextList.Count > 1)
                    {
                        IncrementedList++;
                        foreach (var kext in AlertTextList)
                        {
                            FullIntro += $"\x20{IncrementedList}.\x20" + kext.Intro;
                            FullBody += $"\x20{IncrementedList}.\x20" + kext.Body;
                        }
                        FullIntro = FullIntro.Trim();
                        FullBody = FullBody.Trim();
                    }
                    else
                    {
                        foreach (var kext in AlertTextList)
                        {
                            FullIntro += kext.Intro;
                            FullBody += kext.Body;
                        }
                        FullIntro = FullIntro.Trim();
                        FullBody = FullBody.Trim();
                    }

                    //Debugger.Break();

                    if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.StationIdentifier))
                    {
                        FullIntro = $"This message originates from {QuickSettings.Instance.StationIdentifier} ({QuickSettings.Instance.StationName}). {FullIntro}";
                    }

                    AlertTextClass _AlertText = new AlertTextClass
                    {
                        Intro = FullIntro,
                        Body = FullBody
                    };

                    if (!IgnoreDiscards)
                    {
                        try
                        {
                            if (ReplayMode)
                            {
                                lock (notify)
                                {
                                    notify.BalloonTipIcon = ToolTipIcon.Info;
                                    notify.BalloonTipTitle = $"{EventTypeFull}";
                                    notify.BalloonTipText = $"The alert has been sent again via replay mode.";
                                    notify.ShowBalloonTip(5000);
                                }
                            }

                            bool CalledWebhookFunction = false;
                            bool DialogCanAppear = true;
                        
                            if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                            {
                                CalledWebhookFunction = true;

                                DialogResult result = DialogResult.Yes;

                                if (QuickSettings.Instance.DiscordWebhookConfirmAlerts)
                                {
                                    ManualAlertRelayForm mar = new ManualAlertRelayForm();
                                    mar.UpdateFields(relayItem.Name, EventTypeFull, _AlertText.Intro, _AlertText.Body, PrimaryURL, string.Empty, string.Empty, string.Empty);
                                    mar.ShowDialog();
                                    result = mar.DialogResult;
                                    mar.Dispose();
                                }

                                if (result != DialogResult.No)
                                {
                                    DateTime sentDate;
                                    try
                                    {
                                        sentDate = DateTime.Parse(Sent, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                                    }
                                    catch (Exception ex)
                                    {
                                        ConsoleExt.WriteLine(ex.Message);
                                        sentDate = DateTime.Now;
                                    }

                                    DateTime expiresDate;
                                    try
                                    {
                                        expiresDate = DateTime.Parse(Expiry, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                                    }
                                    catch (Exception ex)
                                    {
                                        ConsoleExt.WriteLine(ex.Message);
                                        expiresDate = DateTime.Now.AddHours(1);
                                    }

                                    int color = 16777215;

                                    switch (MsgType.ToLowerInvariant())
                                    {
                                        case "alert":
                                            color = 16711680;
                                            break;
                                        case "update":
                                            color = 16711935;
                                            break;
                                        case "cancel":
                                            color = 10079487;
                                            break;
                                    }

                                    string LocationList = string.Empty;
                                    foreach (string Location in AllLocations)
                                    {
                                        foreach (string loc in Location.Split(';')) LocationList += $"{loc.Trim()}; ";
                                    }

                                    //string EventsList = string.Empty;
                                    //foreach (string Event in AllEvents)
                                    //{
                                    //    EventsList += $"{Regex.Replace(Event.ToLowerInvariant(), @"(^\w)|(\s\w)", m => m.Value.ToUpperInvariant())}, ";
                                    //}
                                    //EventsList = EventsList.Substring(0, EventsList.Length - 2);

                                    string ProcessedEvent = $"{Regex.Replace(EventTypeFull.ToLowerInvariant(), @"(^\w)|(\s\w)", m => m.Value.ToUpperInvariant())}";

                                    LocationList = LocationList.Trim().Substring(0, LocationList.Length - 2).Trim();
                                    if (LocationList.EndsWith(";")) LocationList = LocationList.Substring(0, LocationList.Length - 1);

                                    string CompiledMessage = $"{ProcessedEvent} | Location(s): {LocationList}\r\n-# Identifier: {relayItem.Name}"; // \r\n-# Process Time: {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms
                                    if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhookAppend)) CompiledMessage += "\r\n" + QuickSettings.Instance.DiscordWebhookAppend;
                                    //DiscordWebhook.SendUnformattedMessage(CompiledMessage);

                                    if (DiscordWebhook.SendEmbeddedMessage(CompiledMessage, $"{MaxSeverity} Emergency {MsgType.First().ToString().ToUpper() + MsgType.Substring(1)}",
                                        _AlertText.Intro, _AlertText.Body + $"\r\n\r\n||${LocationList}$||",
                                        relayItem,
                                        AudioFiles,
                                        ImageFiles,
                                        color))
                                    {
                                        lock (notify)
                                        {
                                            notify.BalloonTipIcon = ToolTipIcon.Info;
                                            notify.BalloonTipTitle = $"{EventTypeFull}";
                                            notify.BalloonTipText = $"The alert was sent {sentDate:g}. The alert expires {expiresDate:g}.";
                                            notify.ShowBalloonTip(5000);
                                        }
                                        AnyAlertRelayed = true;
                                        UsedDiscordHook = true;
                                    }
                                    else
                                    {
                                        lock (notify)
                                        {
                                            notify.BalloonTipIcon = ToolTipIcon.Warning;
                                            notify.BalloonTipTitle = $"{EventTypeFull}";
                                            notify.BalloonTipText = $"The alert was sent {sentDate:g}. The alert expires {expiresDate:g}. The alert failed to relay through the webhook.";
                                            notify.ShowBalloonTip(5000);
                                        }
                                    }

                                    // Delay to prevent the webhook from being rate limited
                                    Thread.Sleep(100);
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
                                    RelayWindow(relayItem.Name, EventTypeFull, _AlertText, PrimaryURL, MsgType, AudioFiles, ImageFiles);
                                });
                            }

                            AnyAlertRelayed = true;
                            SharpDataRelayedNamesHistory.Add(relayItem.Name);
                        }
                        catch (NotSupportedException ex)
                        {
                            ConsoleExt.WriteLine($"[Alert Processor] Couldn't relay. {ex.Message}");
                        }
                        catch (Exception ex)
                        {
                            ConsoleExt.WriteLine($"[Alert Processor] Couldn't relay. {ex.Message}");
                        }
                        finally
                        {
                            ConsoleExt.WriteLine($"[Alert Processor] Finished relaying.");
                        }
                    }
                }

                if (AnyAlertRelayed)
                {
                    AlertsRelayed++;

                    if (UsedDiscordHook)
                    {
                        //string EventsList = string.Empty;
                        //foreach (string Event in AllEvents)
                        //{
                        //    EventsList += $"{Regex.Replace(Event.ToLowerInvariant(), @"(^\w)|(\s\w)", m => m.Value.ToUpperInvariant())}, ";
                        //}
                        //EventsList = EventsList.Substring(0, EventsList.Length - 2);

                        //string LocationList = string.Empty;
                        //foreach (string Location in AllLocations)
                        //{
                        //    foreach (string loc in Location.Split(';')) LocationList += $"{loc.Trim()}; ";
                        //}

                        //LocationList = LocationList.Trim().Substring(0, LocationList.Length - 2).Trim();
                        //if (LocationList.EndsWith(";")) LocationList = LocationList.Substring(0, LocationList.Length - 1);

                        //string CompiledMessage = $"{EventsList} | Location(s): {LocationList}\r\n-# Identifier: {relayItem.Name}\r\n-# Process Time: {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms";
                        //if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhookAppend)) CompiledMessage += "\r\n" + QuickSettings.Instance.DiscordWebhookAppend;
                        //DiscordWebhook.SendUnformattedMessage(CompiledMessage);

                        //ConsoleExt.WriteLine("[Alert Processor] Sent finalizing text to the Discord webhook.");
                    }
                }
                else
                {
                    //DiscordWebhook.SendUnformattedMessage($"The incoming alert was discarded. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");
                }

                ConsoleExt.WriteLine($"[Alert Processor] Processed all available entries. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");

                string AudioURL = AudioFiles.FirstOrDefault();
                string ImageURL = ImageFiles.FirstOrDefault();

                if (string.IsNullOrWhiteSpace(AudioURL)) AudioURL = string.Empty;
                if (string.IsNullOrWhiteSpace(ImageURL)) ImageURL = string.Empty;

                return new AlertInfo
                {
                    AlertID = relayItem.Name,
                    AlertEventType = EventTypeFull,
                    AlertMessageType = MsgType,
                    AlertIntroText = FullIntro,
                    AlertBodyText = FullBody,
                    AlertURL = PrimaryURL,
                    AlertAudioURL = AudioURL,
                    AlertImageURL = ImageURL
                };
            }
        }

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

        public void ProcessExternalAlert(string AlertEvent, string AlertIntro, string AlertBody)
        {
            try
            {
                ThreadDrool.StartAndForget(() =>
                {
                    RelayWindow($"EXTERNAL_EVENT_{DateTime.UtcNow.Ticks}",
                            AlertEvent,
                            new AlertTextClass
                            { Intro = $"This alert has been relayed from an external source. {AlertIntro}".Trim(), Body = $"{AlertBody}".Trim() },
                            string.Empty,
                            "alert",
                            new List<string>() { "" },
                            new List<string>() { "" });
                });
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Alert Processor] Couldn't process an external alert. {ex.Message}");
            }
            finally
            {
                ConsoleExt.WriteLine($"[Alert Processor] Finished processing an external alert.");
            }
        }
        
        public void ProcessAlertTest()
        {
            try
            {
                ChooseTestForm ctf = new ChooseTestForm(false);
                var result = ctf.ShowDialog();

                ThreadDrool.StartAndForget(() =>
                {
                    if (result == DialogResult.Yes)
                    {
                        // https://sasmex.net
                        RelayWindow("TEST",
                            ctf.EventType,
                            new AlertTextClass
                            { Intro = "Test. Test. Test.", Body = $"{ctf.EventDescription}" },
                            ctf.EventURL,
                            "alert",
                            new List<string>() { "" },
                            new List<string>() { "" });
                    }
                });

                ctf.Dispose();
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Alert Processor] Couldn't test. {ex.Message}");
            }
            finally
            {
                ConsoleExt.WriteLine($"[Alert Processor] Finished test.");
            }
        }

        public static (string, bool) GetAlertNameFromSAME(string code)
        {
            if (string.IsNullOrWhiteSpace(code)) return ("Cautionary (Unknown Event)", false);
            try
            {
                var alertEvent = AlertDetails.AlertCodes.DefaultIfEmpty(AlertDetails.cautionary);
                var alertInfo = alertEvent.FirstOrDefault(y => y.ID == code.ToUpperInvariant());

                if (alertInfo != null) return (alertInfo.Name, true);
                else return ("Cautionary (Unknown Event)", false);
            }
            catch (Exception)
            {
                //ConsoleExt.WriteLine($"[Alert Processor] {ex.Message}");
                return ("Cautionary (Unknown Event)", false);
            }
        }

        // Checks severity, urgency, categories.
        // checks against the user settings, then returns true if all checks pass successfully. hopefully.
        public static bool ProcessInfoX(string InfoX)
        {
            ConsoleExt.WriteLine("Processing InfoX.");
            bool Final = false;

            // MsgType:
            // Alert
            // Update
            // Cancel

            try
            {
                string Severity = SeverityRegex.MatchOrDefault(InfoX, "moderate").ToLowerInvariant();
                string Urgency = UrgencyRegex.MatchOrDefault(InfoX, "immediate").ToLowerInvariant();

                // Canadians have multiple categories, it's actually useful

                MatchCollection Categories = CategoryRegex.Matches(InfoX);
                //string Category = CategoryRegex.MatchOrDefault(InfoX, "other").ToLowerInvariant();

                bool SeverityValue = false;
                bool UrgencyValue = false;
                bool CategoryValue = false;

                // got rid of this var123 nonsense, I hated that

                switch (Severity)
                {
                    case "extreme":
                        SeverityValue = QuickSettings.Instance.severityExtreme;
                        break;
                    case "severe":
                        SeverityValue = QuickSettings.Instance.severitySevere;
                        break;
                    case "moderate":
                        SeverityValue = QuickSettings.Instance.severityModerate;
                        break;
                    case "minor":
                        SeverityValue = QuickSettings.Instance.severityMinor;
                        break;
                    case "unknown":
                        SeverityValue = QuickSettings.Instance.severityUnknown;
                        break;
                    default:
                        SeverityValue = QuickSettings.Instance.severityUnknown;
                        break;
                }

                switch (Urgency)
                {
                    case "immediate":
                        UrgencyValue = QuickSettings.Instance.urgencyImmediate;
                        break;
                    case "expected":
                        UrgencyValue = QuickSettings.Instance.urgencyExpected;
                        break;
                    case "future":
                        UrgencyValue = QuickSettings.Instance.urgencyFuture;
                        break;
                    case "past":
                        UrgencyValue = QuickSettings.Instance.urgencyPast;
                        break;
                    case "unknown":
                        UrgencyValue = QuickSettings.Instance.urgencyUnknown;
                        break;
                    default:
                        UrgencyValue = QuickSettings.Instance.urgencyUnknown;
                        break;
                }

                foreach (Match Category in Categories)
                {
                    switch (Category.Groups[1].Value)
                    {
                        case "geo":
                            CategoryValue = QuickSettings.Instance.categoryGeophysical;
                            break;
                        case "met":
                            CategoryValue = QuickSettings.Instance.categoryMeterological;
                            break;
                        case "safety":
                            CategoryValue = QuickSettings.Instance.categoryGeneralSafety;
                            break;
                        case "security":
                            CategoryValue = QuickSettings.Instance.categorySecurity;
                            break;
                        case "rescue":
                            CategoryValue = QuickSettings.Instance.categoryRescue;
                            break;
                        case "fire":
                            CategoryValue = QuickSettings.Instance.categoryFire;
                            break;
                        case "health":
                            CategoryValue = QuickSettings.Instance.categoryMedical;
                            break;
                        case "env":
                            CategoryValue = QuickSettings.Instance.categoryEnvironmental;
                            break;
                        case "transport":
                            CategoryValue = QuickSettings.Instance.categoryTransportation;
                            break;
                        case "infra":
                            CategoryValue = QuickSettings.Instance.categoryUtilities;
                            break;
                        case "cbrne":
                            CategoryValue = QuickSettings.Instance.categoryToxicThreat;
                            break;
                        case "other":
                            CategoryValue = QuickSettings.Instance.categoryOtherUnknown;
                            break;
                        default:
                            CategoryValue = QuickSettings.Instance.categoryOtherUnknown;
                            break;
                    }

                    if (CategoryValue) break;
                }

                if (SeverityValue && UrgencyValue && CategoryValue)
                {
                    Final = true;
                    ConsoleExt.WriteLine("[Alert Processor] Severity, urgency, and category, passed all checks.");
                }
                else
                {
                    ConsoleExt.WriteLine($"[Alert Processor] Severity ({SeverityValue}) | Urgency ({UrgencyValue}) | Category ({CategoryValue}). Checks were not passed.\r\n");
                }
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Alert Processor] Severity, urgency, and category checks couldn't complete. {ex.Message}");
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
                    ConsoleExt.WriteLine("[Alert Processor] Any locations are allowed, because the configuration does not specify any.");   
                    return true;
                }

                // I don't even know how this works anymore

                // SAME
                if (QuickSettings.Instance.AllowedSAMELocations_Geocodes.Count != 0)
                {
                    StringCollection locations = new StringCollection();
                    lock (QuickSettings.Instance.AllowedSAMELocations_Geocodes)
                    {
                        foreach (string location in QuickSettings.Instance.AllowedSAMELocations_Geocodes)
                        {
                            if (!locations.Contains(location))
                            {
                                locations.Add(location);
                            }

                            string AllAboveLocation = location.Substring(0, location.Length - 3) + "000";

                            if (!locations.Contains(AllAboveLocation))
                            {
                                locations.Add(AllAboveLocation);
                            }
                        }
                    }

                    try
                    {
                        MatchCollection matches = GeocodeSpecificAreaMessageEncodingRegex.Matches(InfoX);
                        bool GeoMatch = false;
                        foreach (Match match in matches)
                        {
                            string geocode = match.Groups[1].Value;
                            if (locations.Contains(geocode))
                            {
                                GeoMatch = true;
                                break;
                            }
                        }

                        if (GeoMatch)
                        {
                            LocationsMatch = true;
                            ConsoleExt.WriteLine("[Alert Processor] One or more SAME locations were matched.");
                        }
                        else
                        {
                            ConsoleExt.WriteLine("[Alert Processor] No locations matched the SAME list.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ConsoleExt.WriteLine($"[Alert Processor] An unknown amount of locations were matched. {ex.Message}");
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

                        MatchCollection matches = GeocodeCommonAlertingProtocolCanadaCodeRegex.Matches(InfoX);
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
                            ConsoleExt.WriteLine("[Alert Processor] One or more CAP-CP locations were matched.");
                        }
                        else
                        {
                            ConsoleExt.WriteLine("[Alert Processor] No locations matched the CAP-CP list.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ConsoleExt.WriteLine($"[Alert Processor] An unknown amount of locations were matched. {ex.Message}");
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
                            ConsoleExt.WriteLine("[Alert Processor] One or more custom locations were matched.");
                        }
                        else
                        {
                            ConsoleExt.WriteLine("[Alert Processor] No locations matched the custom list.");
                        }
                    }
                    catch (Exception ex)
                    {
                        ConsoleExt.WriteLine($"[Alert Processor] An unknown amount of locations were matched. {ex.Message}");
                    }
                }

                if (!LocationsMatch)
                {
                    ConsoleExt.WriteLine("[Alert Processor] No locations matched.");
                }
                else
                {
                    ConsoleExt.WriteLine("[Alert Processor] Locations matched.");
                }

                return LocationsMatch;
            }
            else return false;
        }

        public bool ProcessParameterX(string ParameterX)
        {
            ConsoleExt.WriteLine("[Alert Processor] Processing ParemeterX.");

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
        
        public bool ProcessAlertX(string Status, string MsgType)
        {
            ConsoleExt.WriteLine("[Alert Processor] Processing AlertX.");

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
                bool MessageTypeValue; // MsgType

                switch (MsgType.ToLowerInvariant())
                {
                    case "alert":
                        MessageTypeValue = QuickSettings.Instance.messageTypeAlert;
                        break;
                    case "update":
                        MessageTypeValue = QuickSettings.Instance.messageTypeUpdate;
                        break;
                    case "cancel":
                        MessageTypeValue = QuickSettings.Instance.messageTypeCancel;
                        break;
                    default:
                        MessageTypeValue = QuickSettings.Instance.messageTypeAlert;
                        break;
                }

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
        public (string Intro, string Body) CompiledBody(string InfoData, string MsgType, string Sent)
        {
            ConsoleExt.WriteLine("[Alert Processor] Compiling body text.");
            string BroadcastText = string.Empty;

            //if (Replay)
            //{
            //    BroadcastText += $"This is a replay of the most recent alert.\x20";
            //}

            ConsoleExt.WriteLine("[Alert Processor] Parsing message type.");

            string MsgPrefix;

            switch (MsgType.ToLowerInvariant())
            {
                case "alert":
                    MsgPrefix = string.Empty;
                    break;
                case "update":
                    MsgPrefix = "This alert has been updated.";
                    break;
                case "cancel":
                    MsgPrefix = "This alert has been cancelled.";
                    break;
                default:
                    MsgPrefix = string.Empty;
                    break;
            }

            ConsoleExt.WriteLine("[Alert Processor] Parsing sent date.");

            DateTime sentDate;
            try
            {
                sentDate = DateTime.Parse(Sent, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            }
            catch (Exception e)
            {
                ConsoleExt.WriteLine(e.Message);
                sentDate = DateTime.UtcNow;
            }

            ConsoleExt.WriteLine("[Alert Processor] Parsing effective date.");

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
                ConsoleExt.WriteLine(ex.Message);
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
                    ConsoleExt.WriteLine(exx.Message);
                    effectiveDate = DateTime.UtcNow;
                }
            }

            ConsoleExt.WriteLine("[Alert Processor] Parsing expiration date.");

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
                ConsoleExt.WriteLine(ex.Message);
                if (QuickSettings.Instance.alertTimeZoneUTC)
                {
                    expiryDate = DateTime.UtcNow.AddHours(1);
                }
                else
                {
                    expiryDate = DateTime.UtcNow.AddHours(1).ToLocalTime();
                }
            }

            ConsoleExt.WriteLine("[Alert Processor] Parsing time zone.");

            string TimeZoneName = "Unknown TZ";
            if (QuickSettings.Instance.alertTimeZoneUTC) TimeZoneName = "UTC";
            else TimeZoneName = LocalTimeAbbreviation();

            string SentFormatted = $"{sentDate:HH:mm} {TimeZoneName}, {sentDate:MMMM dd}, {sentDate:yyyy}";
            string BeginFormatted = $"{effectiveDate:HH:mm} {TimeZoneName}, {effectiveDate:MMMM dd}, {effectiveDate:yyyy}";
            string EndFormatted = $"{expiryDate:HH:mm} {TimeZoneName}, {expiryDate:MMMM dd}, {expiryDate:yyyy}";

            ConsoleExt.WriteLine("[Alert Processor] Parsing event type.");

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

            ConsoleExt.WriteLine("[Alert Processor] Parsing locations.");

            string AreaDesc = "Unspecified localities";

            try
            {
                var AreaDescription = AreaDescriptionRegex.Matches(InfoData);

                if (AreaDescription.Count != 0)
                {
                    ConsoleExt.WriteLine("[Alert Processor] Parsing locations as SAME.");
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
                        AppendedCodeAreas += $"{GetFriendlyNameFromSAMELocation(code.Groups[1].Value.Substring(1))};\x20";
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
                                AreaDesc = SentenceAppendEnd(AreaDesc.Substring(0, AreaDesc.Length - 2));
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
                    ConsoleExt.WriteLine("[Alert Processor] Parsing locations as raw data.");
                }
            }
            catch (Exception)
            {
            }

            ConsoleExt.WriteLine("[Alert Processor] Parsing sender name.");

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
                    
                    if (SenderName.Contains(","))
                    {
                        string[] senders = SenderName.Split(',');
                        List<string> uniqueSenders = new List<string>();

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

            ConsoleExt.WriteLine("[Alert Processor] Parsing description text.");

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

            ConsoleExt.WriteLine("[Alert Processor] Parsing instruction text.");

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

            ConsoleExt.WriteLine("[Alert Processor] Parsing mobile broadcast text.");

            string SOREM_BroadcastText = BroadcastTextRegex.MatchOrDefault(InfoData);

            if (string.IsNullOrWhiteSpace(SOREM_BroadcastText))
            {
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
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Description))
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
                        Description = string.Empty;
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
                ConsoleExt.WriteLine("[Alert Processor] No description and instruction set.");
                Description = "The alert information is limited or unavailable at the moment.";
                Instruction = string.Empty;
            }

            ConsoleExt.WriteLine("[Alert Processor] Compiling intro text.");

            string IntroText = string.Empty;

            IntroText += SentenceAppendSpace($"This alert goes into effect starting {BeginFormatted}, and ending at {EndFormatted}.");
            IntroText += $"Issued by {SenderName}. Event type is {EventType}. {MsgPrefix} For the following areas, {SentenceAppendEnd(AreaDesc)}".Replace("\x20\x20", "\x20");
            IntroText = IntroText.Replace("\r\n", "\n").Replace("\n", "\r\n"); // fix mixed newline problems hopefully

            ConsoleExt.WriteLine("[Alert Processor] Finished compiling intro text.");

            BroadcastText += SentenceAppendSpace(SentenceAppendEnd(Description));
            if (Description != Instruction) BroadcastText += SentenceAppendSpace(SentenceAppendEnd(Instruction));
            BroadcastText = BroadcastText.Replace("###", string.Empty);
            BroadcastText = BroadcastText.Replace(" E A S ", " EAS ");
            BroadcastText = BroadcastText.Replace(" 9 1 1 ", " 9-1-1 ");
            BroadcastText = SentencePuncuationCorrection(BroadcastText).Replace(",", ",\x20");
            BroadcastText = BroadcastText.Replace("\r\n", "\n").Replace("\n", "\r\n"); // fix mixed newline problems hopefully
            BroadcastText = BroadcastText.Replace("\r\n\r\n\r\n\r\n", "\r\n\r\n").Replace("\r\n\r\n\r\n", "\r\n\r\n"); // fix spacing
            BroadcastText = SentenceAppendEnd(BroadcastText);
            BroadcastText = TimeCorrection(BroadcastText);
            BroadcastText = BroadcastText.TrimStart('.').TrimStart(',');
            BroadcastText = string.Join(" ", BroadcastText.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)).Trim();

            // It should not be this painful to fix text formatting.

            ConsoleExt.WriteLine("[Alert Processor] Finished compiling body text.");
            return (IntroText, BroadcastText);
        }
        
        /// <summary>
        /// Processes the info tag, then returns a message body.
        /// </summary>
        /// <param name="InfoData">The info XML data to process.</param>
        /// <returns>Returns a compiled message body.</returns>
        public List<string> CompiledLocations(string InfoData)
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
                        AppendedCodeAreas += $"{GetFriendlyNameFromSAMELocation(code.Groups[1].Value.Substring(1))};\x20";
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
                    return AreaDesc.Split(';').ToList();
                }
                return new List<string> { "Unparsable Location(s)" };
            }
            catch (Exception)
            {
                return new List<string> { "Unknown Location(s)" };
            }
        }

        /// <summary>
        /// Processes the data string for TTS friendlyness.
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets the friendly name of the area specified.
        /// </summary>
        /// <param name="code">The code of which to get the friendly name from.</param>
        /// <returns></returns>
        public static string GetFriendlyNameFromSAMELocation(string code)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(CacheCapture.SAME_US_JSON)) cache.ServiceRun(false);
                if (!string.IsNullOrWhiteSpace(CacheCapture.SAME_US_JSON))
                {
                    using (JsonDocument doc = JsonDocument.Parse(CacheCapture.SAME_US_JSON))
                    {
                        JsonElement root = doc.RootElement;
                        JsonElement same = root.GetProperty("SAME");

                        if (same.TryGetProperty(code, out JsonElement rawSAME))
                        {
                            return rawSAME.GetString();
                        }
                        else
                        {
                            if (code.Length == 6)
                            {
                                if (same.TryGetProperty(code.Substring(1), out JsonElement subSAME))
                                {
                                    return subSAME.GetString();
                                }
                            }
                        }
                    }
                }
                else
                {
                    ConsoleExt.WriteLine("[Alert Processor] The cache is unavailable.");
                }
            }
            catch (Exception ex)
            {
                ConsoleExt.WriteLine($"[Alert Processor] {ex.Message}");
            }

            return $"{code} (Cache Unavailable)";
        }

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
            return SentenceAppendEnd(value.Substring(0, value.Length - 1));
        }
        
        string SentencePuncuationRemoval(string value)
        {
            value = value.Trim();
            while (value.EndsWith(".") || value.EndsWith("!") || value.EndsWith(","))
            {
                value = value.Substring(0, value.Length - 1);
            }
            return value;
        }

        string TimeCorrection(string value)
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

        string LocalTimeAbbreviation()
        {
            return string.Concat(TimeZoneInfo.Local.StandardName.Split(' ').Select(word => word.Substring(0, 1)));

            //var localTimeZone = TimeZoneInfo.Local;
            //var isDaylight = localTimeZone.IsDaylightSavingTime(DateTime.Now);

            //if (isDaylight)
            //    return localTimeZone.DaylightName.Substring(0, 3);
            //else
            //    return localTimeZone.StandardName.Substring(0, 3);
        }

        public static (string text, Color MainColor, Color SubColor) GetTextFromMessageType(string type)
        {
            switch (type)
            {
                case "bulletin":
                    return ("SYSTEM BULLETIN", Color.Red, Color.FromArgb(160, 0, 0));
                case "update":
                    return ("ALERT UPDATE", Color.FromArgb(255, 112, 0), Color.FromArgb(200, 82, 80));
                case "cancel":
                    return ("ALERT CANCELLED", Color.FromArgb(0, 80, 200), Color.FromArgb(0, 50, 100));
                case "test":
                    return ("TEST MESSAGE", Color.Gray, Color.LightGray);
                case "alert":
                default:
                    return ("EMERGENCY ALERT", Color.Red, Color.FromArgb(160, 0, 0));
            }
            //switch (type)
            //{
            //    case "alert":
            //        TitleText.BackColor = Color.Red;
            //        OutlineContainerPanel.BorderColor = Color.Red;
            //        SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
            //        TitleText.Text = "EMERGENCY ALERT";
            //        break;
            //    case "update":
            //        TitleText.BackColor = Color.Red;
            //        OutlineContainerPanel.BorderColor = Color.Red;
            //        SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
            //        TitleText.Text = "ALERT UPDATE";
            //        break;
            //    case "cancel":
            //        TitleText.BackColor = Color.FromArgb(0, 80, 200);
            //        OutlineContainerPanel.BorderColor = Color.FromArgb(0, 80, 200);
            //        SubtitlePanel.BackColor = Color.FromArgb(0, 50, 100);
            //        TitleText.Text = "ALERT CANCELLED";
            //        break;
            //    case "test":
            //        TitleText.BackColor = Color.Red;
            //        OutlineContainerPanel.BorderColor = Color.Red;
            //        SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
            //        TitleText.Text = "ALERT TEST";
            //        break;
            //    default:
            //        TitleText.BackColor = Color.Red;
            //        OutlineContainerPanel.BorderColor = Color.Red;
            //        SubtitlePanel.BackColor = Color.FromArgb(160, 0, 0);
            //        TitleText.Text = "EMERGENCY ALERT";
            //        break;
            //}
        }
    }
}
