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

        public int AlertsProcessing { get; private set; } = 0;

        //bool DoNotAddToCount
        public AlertInfo ProcessAlertItem(SharpDataItem relayItem, bool ReplayMode, bool IgnoreDiscards)
        {
            ConsoleExt.WriteLine($"[Alert Processor] Beginning processing -> {relayItem.Name}");
            //if (!DoNotAddToCount) AlertsProcessing++;
            AlertsProcessing++;
            var info = SubProcessAlertItem(relayItem, ReplayMode, IgnoreDiscards);
            //if (!DoNotAddToCount) AlertsProcessing--;
            AlertsProcessing--;
            ConsoleExt.WriteLine($"[Alert Processor] Finished processing -> {relayItem.Name}");
            return info;
        }

        public class AlertInfo
        {
            //public bool AlertRelayable { get; set; } = false;
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
                    ConsoleExt.WriteLine($"[Alert Processor] Alert discarded due to user preferences or invalidity.");
                    //DiscordWebhook.SendUnformattedMessage($"The incoming alert was discarded. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");
                    if (!IgnoreDiscards) return null;
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
                            if (!Settings.Default.AllowNonEnglishAlerts)
                            {
                                if (!BCP47Language.ToLowerInvariant().StartsWith("en-"))
                                {
                                    ConsoleExt.WriteLine("[Alert Processor] Info tag discarded because it does not contain English information.");
                                    break;
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

                    if ((ProcessParameterX(AlertInfo) && ProcessAlertX(Status, MsgType, Severity)) ||
                        BroadcastImmediatelyRegex.MatchOrDefault(AlertInfo, "no").ToLowerInvariant() == "yes" || IgnoreDiscards)
                    {
                        foreach (string Event in Settings.Default.EnforceEventBlacklist)
                        {
                            if (EventName.ToLowerInvariant().Contains(Event.ToLowerInvariant()))
                            {
                                EventBlacklisted = true;
                                break;
                            }
                        }
                       

                        if (!IgnoreDiscards)
                        {
                            foreach (string Event in Settings.Default.EnforceSAMEEventBlacklist)
                            {
                                if (EventType.ToLowerInvariant().Contains(Event.ToLowerInvariant()))
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
                                break;
                            }
                        }

                        if (!MatchFound)
                        {
                            AlertTextList.Add(text);
                            ConsoleExt.WriteLine($"[Alert Processor] The contents of the current info tag have been added.");
                            break;
                        }
                    }
                    else
                    {
                        ConsoleExt.WriteLine($"[Alert Processor] Alert discarded either due to user preferences or invalidity.");
                    }
                }

                ConsoleExt.WriteLine("[Alert Processor] There is no further data to process.");

                string FullIntro = string.Empty;
                string FullBody = string.Empty;

                if (AlertTextList.Count == 0)
                {
                    ConsoleExt.WriteLine("[Alert Processor] There is no alert text to process.");
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

                    if (!string.IsNullOrWhiteSpace(Settings.Default.StationIdentifier))
                    {
                        FullIntro = $"This message originates from {Settings.Default.StationIdentifier} ({Settings.Default.StationName}). {FullIntro}";
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
                        
                            if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhook))
                            {
                                CalledWebhookFunction = true;

                                DialogResult result = DialogResult.Yes;

                                if (Settings.Default.DiscordWebhookConfirmAlerts)
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
                                    if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhookAppend)) CompiledMessage += "\r\n" + Settings.Default.DiscordWebhookAppend;
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
                                if (!Settings.Default.DiscordWebhookRelayLocally) DialogCanAppear = false;
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
                        //if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhookAppend)) CompiledMessage += "\r\n" + Settings.Default.DiscordWebhookAppend;
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

        /// <summary>
        /// Processes the info tag, then returns a boolean depending on the configuration.
        /// </summary>
        /// <param name="InfoX">The info XML data to process.</param>
        /// <param name="MsgType">The type of message.</param>
        /// <param name="Severity">The severity of the message.</param>
        /// <param name="Urgency">The urgency of the message.</param>
        /// <returns>Returns True if the caller should continue.</returns>
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
                        SeverityValue = Settings.Default.severityExtreme;
                        break;
                    case "severe":
                        SeverityValue = Settings.Default.severitySevere;
                        break;
                    case "moderate":
                        SeverityValue = Settings.Default.severityModerate;
                        break;
                    case "minor":
                        SeverityValue = Settings.Default.severityMinor;
                        break;
                    case "unknown":
                        SeverityValue = Settings.Default.severityUnknown;
                        break;
                    default:
                        SeverityValue = Settings.Default.severityUnknown;
                        break;
                }

                switch (Urgency)
                {
                    case "immediate":
                        UrgencyValue = Settings.Default.urgencyImmediate;
                        break;
                    case "expected":
                        UrgencyValue = Settings.Default.urgencyExpected;
                        break;
                    case "future":
                        UrgencyValue = Settings.Default.urgencyFuture;
                        break;
                    case "past":
                        UrgencyValue = Settings.Default.urgencyPast;
                        break;
                    case "unknown":
                        UrgencyValue = Settings.Default.urgencyUnknown;
                        break;
                    default:
                        UrgencyValue = Settings.Default.urgencyUnknown;
                        break;
                }

                foreach (Match Category in Categories)
                {
                    switch (Category.Groups[1].Value)
                    {
                        case "geo":
                            CategoryValue = Settings.Default.categoryGeophysical;
                            break;
                        case "met":
                            CategoryValue = Settings.Default.categoryMeterological;
                            break;
                        case "safety":
                            CategoryValue = Settings.Default.categoryGeneralSafety;
                            break;
                        case "security":
                            CategoryValue = Settings.Default.categorySecurity;
                            break;
                        case "rescue":
                            CategoryValue = Settings.Default.categoryRescue;
                            break;
                        case "fire":
                            CategoryValue = Settings.Default.categoryFire;
                            break;
                        case "health":
                            CategoryValue = Settings.Default.categoryMedical;
                            break;
                        case "env":
                            CategoryValue = Settings.Default.categoryEnvironmental;
                            break;
                        case "transport":
                            CategoryValue = Settings.Default.categoryTransportation;
                            break;
                        case "infra":
                            CategoryValue = Settings.Default.categoryUtilities;
                            break;
                        case "cbrne":
                            CategoryValue = Settings.Default.categoryToxicThreat;
                            break;
                        case "other":
                            CategoryValue = Settings.Default.categoryOtherUnknown;
                            break;
                        default:
                            CategoryValue = Settings.Default.categoryOtherUnknown;
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

            if (Final)
            {
                bool LocationsMatch = false;

                if (Settings.Default.AllowedSAMELocations_Geocodes.Count == 0 &&
                    Settings.Default.AllowedCAPCPLocations_Geocodes.Count == 0)
                {
                    // if no locations are found, assume all locations are valid
                    ConsoleExt.WriteLine("[Alert Processor] Any locations are allowed, because the configuration does not specify any.");   
                    return true;
                }

                // SAME
                if (Settings.Default.AllowedSAMELocations_Geocodes.Count != 0)
                {
                    // adds the locations for us to use
                    StringCollection locations = new StringCollection();
                    lock (Settings.Default.AllowedSAMELocations_Geocodes)
                    {
                        foreach (string location in Settings.Default.AllowedSAMELocations_Geocodes)
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

                    // tries to verify locations
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
                if (Settings.Default.AllowedCAPCPLocations_Geocodes.Count != 0)
                {
                    try
                    {
                        MatchCollection matches = GeocodeUniversalGeographicCodeRegex.Matches(InfoX);
                        bool GeoMatch = false;
                        foreach (Match match in matches)
                        {
                            string geocode = match.Groups[1].Value;
                            if (Settings.Default.AllowedCAPCPLocations_Geocodes.Contains(geocode))
                            {
                                GeoMatch = true;
                                break;
                            }
                        }

                        if (GeoMatch)
                        {
                            LocationsMatch = true;
                            ConsoleExt.WriteLine("[Alert Processor] One or more UGC locations were matched.");
                        }
                        else
                        {
                            ConsoleExt.WriteLine("[Alert Processor] No locations matched the UGC list.");
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

                return LocationsMatch;
            }
            else return false;
        }

        /// <summary>
        /// Processes the parameter tag, then returns a boolean depending on the configuration.
        /// </summary>
        /// <param name="ParameterX">The parameter XML data to process.</param>
        /// <returns>Returns True if the caller should continue.</returns>
        public bool ProcessParameterX(string ParameterX)
        {
            ConsoleExt.WriteLine("[Alert Processor] Processing ParemeterX.");

            if (Settings.Default.weaOnly)
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

        /// <summary>
        /// Processes the alert tag, then returns a boolean depending on the configuration.
        /// </summary>
        /// <param name="Status">The status of the message.</param>
        /// <param name="MsgType">The overall message type.</param>
        /// <param name="Severity">The severity of the message.</param>
        /// <returns>Returns True if the caller should continue.</returns>
        public bool ProcessAlertX(string Status, string MsgType, string Severity)
        {
            ConsoleExt.WriteLine("[Alert Processor] Processing AlertX.");

            bool Final = false;

            // Status:
            // Test
            // Actual

            switch (Status.ToLowerInvariant())
            {
                case "actual":
                    if (!Settings.Default.statusActual) return false;
                    break;
                case "exercise":
                    if (!Settings.Default.statusExercise) return false;
                    break;
                case "test":
                    if (!Settings.Default.statusTest) return false;
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

                    switch (Severity.ToLowerInvariant())
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

                    switch (MsgType.ToLowerInvariant())
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
                if (Settings.Default.alertTimeZoneUTC)
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
                    if (Settings.Default.alertTimeZoneUTC)
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
                if (Settings.Default.alertTimeZoneUTC)
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
                if (Settings.Default.alertTimeZoneUTC)
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
            if (Settings.Default.alertTimeZoneUTC) TimeZoneName = "UTC";
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
