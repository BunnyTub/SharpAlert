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
using static SharpAlert.AudioManager;
using SharpAlert.AlertComponents;

namespace SharpAlert
{
    public class AlertProcessor
    {
        //private readonly object PingLock = new object();

        public string DialogAlertID = string.Empty;
        public string DialogAlertTitle = string.Empty;
        public (string Intro, string Body) DialogAlertText = (string.Empty, string.Empty);
        public string DialogAlertURL = string.Empty;
        public string DialogAlertAudioURL = string.Empty;
        public string DialogAlertImageURL = string.Empty;
        public string DialogAlertType = string.Empty;

        public AlertProcessor()
        {
            //ServiceRun();
            StartRelayCallLoop();
            StartAudioCallLoop();
            StartShakeCallLoop();
            StartRAFCallLoop();
            StartTAFCallLoop();
            StartMAFCallLoop();
            StartSAFCallLoop();
        }

        //private void ServiceRun()
        //{
        //    while (true)
        //    {
        //        try
        //        {

        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"[Alert Processor] {ex.Message}");
        //        }
        //    }
        //}

        private RelayController relay = null;
        private bool relayPing = false;

        private void StartRelayCallLoop()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                relay = new RelayController();
                Console.WriteLine("[Relay Ping] Getting HID USB relay.");
                if (relay.GetHidUSBRelay())
                {
                    Console.WriteLine("[Relay Ping] HID USB relay connected.");
                }
                else
                {
                    Console.WriteLine("[Relay Ping] No HID USB relay is connected.");
                }
                while (true)
                {
                    if (relayPing)
                    {
                        relayPing = false;

                        if (Settings.Default.alertNoRelay) continue;

                        Thread.Sleep(1000);

                        Console.WriteLine("[Relay Ping] Triggering relay.");

                        if (!relay.OffAll())
                        {
                            if (relay.GetHidUSBRelay())
                            {
                                Console.WriteLine("[Relay Ping] Device connected.");
                            }
                            else
                            {
                                Console.WriteLine("[Relay Ping] Device not connected.");
                                continue;
                            }
                        }

                        Thread.Sleep(500);

                        for (int i = 0; i < 8; i++)
                        {
                            relay.OnAll();
                            Thread.Sleep(500);
                            relay.OffAll();
                            Thread.Sleep(500);
                        }
                    }
                    Thread.Sleep(10);
                }
            });
        }
        
        private void StartAudioCallLoop()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                while (true)
                {
                    while (!AlertDisplaying)
                    {
                        //StopAllAudioSilently();
                        StopTTSAudioSilently();
                        Thread.Sleep(50);
                    }
                    Thread.Sleep(10);
                }
            });
        }

        private readonly object PopupLock = new object();

        public void ShowPopup()
        {
            lock (PopupLock)
            {
                if (!AllowThreadRestarts) return;

                // determine the dialog to use

                if (DialogAlertURL.Contains("sasmex.net"))
                {
                    Console.WriteLine("[Alert Processor] Earthquake alert detected.");
                    if (shkPing)
                    {
                        try
                        {
                            shk.Invoke((Action)delegate
                            {
                                shk.UpdateFields(DialogAlertID, DialogAlertTitle, DialogAlertText.Intro, DialogAlertText.Body, DialogAlertURL, DialogAlertType, 16.74151, -95.09448);
                            });
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                    else shkPing = true;
                }
                else
                {
                    AlertDisplaying = true;

                    switch (Settings.Default.alertDisplayType)
                    {
                        default:
                        case 0:
                            rafPing = true;
                            while (rafPing) Thread.Sleep(500);
                            break;
                        case 1:
                            mafPing = true;
                            while (mafPing) Thread.Sleep(500);
                            break;
                        case 2:
                            tafPing = true;
                            while (tafPing) Thread.Sleep(500);
                            break;
                        case 3:
                            safPing = true;
                            while (safPing) Thread.Sleep(500);
                            break;
                    }

                    AlertDisplaying = false;

                    int DeadTime = Settings.Default.AlertDeadInterval;
                    if (DeadTime != 0)
                    {
                        Console.WriteLine($"[Alert Processor] Pausing alerts for {DeadTime} second(s) to fill dead time.");
                        Thread.Sleep(DeadTime * 1000);
                    }
                    else Thread.Sleep(100);
                }
            }
        }

        private ImmediateAlertForm shk = null;
        private bool shkPing = false;

        private void StartShakeCallLoop()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine($"[SHK Loop] Initializing call loop.");
                Application.EnableVisualStyles();
                shk = new ImmediateAlertForm();
                while (true)
                {
                    Console.WriteLine($"[SHK Loop] Waiting for the next ping.");
                    try
                    {
                        while (!shkPing) Thread.Sleep(100);
                        if (shk == null || shk.IsDisposed) shk = new ImmediateAlertForm();
                        shk.UpdateFields(DialogAlertID, DialogAlertTitle, DialogAlertText.Intro, DialogAlertText.Body, DialogAlertURL, DialogAlertType, 16.74151, -95.09448);
                        relayPing = true;
                        notify.Icon = Resources.TrayAlertIcon;
                        shk.ShowDialog();
                        shkPing = false;
                        notify.Icon = Resources.TrayLightIcon;
                    }
                    catch (Exception ex)
                    {
                        shkPing = false;
                        Console.WriteLine($"[SHK Loop] {ex.Message}");
                    }
                }
            });
        }

        private AlertForm raf = null;
        private bool rafPing = false;

        private void StartRAFCallLoop()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine($"[RAF Loop] Initializing call loop.");
                Application.EnableVisualStyles();
                raf = new AlertForm();
                while (true)
                {
                    Console.WriteLine($"[RAF Loop] Waiting for the next ping.");
                    try
                    {
                        while (!rafPing) Thread.Sleep(500);
                        if (raf == null || raf.IsDisposed) raf = new AlertForm();
                        raf.UpdateFields(DialogAlertID, DialogAlertTitle, DialogAlertText.Intro, DialogAlertText.Body, DialogAlertURL, DialogAlertAudioURL, DialogAlertImageURL, DialogAlertType);
                        relayPing = true;
                        notify.Icon = Resources.TrayAlertIcon;
                        raf.ShowDialog();
                        rafPing = false;
                        notify.Icon = Resources.TrayLightIcon;
                    }
                    catch (Exception ex)
                    {
                        rafPing = false;
                        Console.WriteLine($"[RAF Loop] {ex.Message}");
                    }
                }
            });
        }

        private TeleAlertForm taf = null;
        private bool tafPing = false;

        private void StartTAFCallLoop()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine($"[TAF Loop] Initializing call loop.");
                Application.EnableVisualStyles();
                while (true)
                {
                    Console.WriteLine($"[TAF Loop] Waiting for the next ping.");
                    try
                    {
                        while (!tafPing) Thread.Sleep(500);
                        if (taf == null || taf.IsDisposed) taf = new TeleAlertForm();
                        taf.UpdateFields(DialogAlertID, DialogAlertTitle, DialogAlertText.Intro, DialogAlertText.Body, DialogAlertURL, DialogAlertAudioURL, DialogAlertImageURL, DialogAlertType);
                        relayPing = true;
                        notify.Icon = Resources.TrayAlertIcon;
                        taf.ShowDialog();
                        tafPing = false;
                        notify.Icon = Resources.TrayLightIcon;
                    }
                    catch (Exception ex)
                    {
                        tafPing = false;
                        Console.WriteLine($"[TAF Loop] {ex.Message}");
                    }
                }
            });
        }

        private MiniAlertForm maf = null;
        private bool mafPing = false;

        private void StartMAFCallLoop()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine($"[MAF Loop] Initializing call loop.");
                Application.EnableVisualStyles();
                while (true)
                {
                    Console.WriteLine($"[MAF Loop] Waiting for the next ping.");
                    try
                    {
                        while (!mafPing) Thread.Sleep(500);
                        if (maf == null || maf.IsDisposed) maf = new MiniAlertForm();
                        maf.UpdateFields(DialogAlertID, DialogAlertTitle, DialogAlertText.Intro, DialogAlertText.Body, DialogAlertURL, DialogAlertAudioURL, DialogAlertImageURL, DialogAlertType);
                        relayPing = true;
                        notify.Icon = Resources.TrayAlertIcon;
                        maf.ShowDialog();
                        mafPing = false;
                        notify.Icon = Resources.TrayLightIcon;
                    }
                    catch (Exception ex)
                    {
                        mafPing = false;
                        Console.WriteLine($"[MAF Loop] {ex.Message}");
                    }
                }
            });
        }

        private ScrollAlertForm saf = null;
        private bool safPing = false;

        private void StartSAFCallLoop()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine($"[SAF Loop] Initializing call loop.");
                Application.EnableVisualStyles();
                while (true)
                {
                    Console.WriteLine($"[SAF Loop] Waiting for the next ping.");
                    try
                    {
                        while (!safPing) Thread.Sleep(500);
                        if (saf == null || saf.IsDisposed) saf = new ScrollAlertForm();
                        saf.UpdateFields(DialogAlertID, DialogAlertTitle, DialogAlertText.Intro, DialogAlertText.Body, DialogAlertURL, DialogAlertAudioURL, DialogAlertImageURL, DialogAlertType);
                        relayPing = true;
                        notify.Icon = Resources.TrayAlertIcon;
                        saf.ShowDialog();
                        safPing = false;
                        notify.Icon = Resources.TrayLightIcon;
                    }
                    catch (Exception ex)
                    {
                        safPing = false;
                        Console.WriteLine($"[SAF Loop] {ex.Message}");
                        
                    }
                }
            });
        }

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

        public class AlertTextClass
        {
            public string Intro { get; set; }
            public string Body { get; set; }
        }

        /// <summary>
        /// Processes and relays the alert item.
        /// </summary>
        /// <param name="relayItem">The item to be processed.</param>
        public void ProcessAlertItem(SharpDataItem relayItem, bool ReplayMode)
        {
            lock (AlertLock)
            {
                DateTime startProc = DateTime.UtcNow;

                //DiscordWebhook.SendUnformattedMessage($"Processing incoming alert item. ({startProc:O} UTC)");

                bool AnyAlertRelayed = false;
                bool UsedDiscordHook = false;

                string Sent = SentRegex.MatchOrDefault(relayItem.Data, DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));

                Console.WriteLine($"Sent: {Sent}");

                string Status = StatusRegex.MatchOrDefault(relayItem.Data, "actual");
                Console.WriteLine($"Status: {Status}");

                string MsgType = MessageTypeRegex.MatchOrDefault(relayItem.Data, "alert");
                Console.WriteLine($"Message Type: {MsgType}");

                Console.WriteLine($"Replay (internal flag): {ReplayMode}");

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
                        Console.WriteLine($"[Alert Processor] An info tag couldn't processed. {ex.Message}");
                    }
                }

                if (!final)
                {
                    Console.WriteLine($"[Alert Processor] Alert discarded due to user preferences or invalidity.");
                    //DiscordWebhook.SendUnformattedMessage($"The incoming alert was discarded. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");
                    return;
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
                    Console.WriteLine($"[Alert Processor] Processing {infoProc} of {infoMatches.Count}.");

                    string AlertInfo = $"{infoMatch.Groups[1].Value}";

                    string Effective = EffectiveRegex.MatchOrDefault(relayItem.Data, DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));
                    Console.WriteLine($"Effective: {Effective}");

                    Expiry = ExpiresRegex.MatchOrDefault(relayItem.Data, DateTime.UtcNow.AddHours(1).ToString("O", CultureInfo.InvariantCulture));
                    Console.WriteLine($"Expires: {Expiry}");

                    //https://www.iana.org/assignments/language-subtag-registry/language-subtag-registry
                    string BCP47Language = LanguageRegex.MatchOrDefault(AlertInfo, "en-US");
                    Console.WriteLine($"Language: {BCP47Language}");

                    string URL = WebRegex.MatchOrDefault(AlertInfo, string.Empty);
                    string Web = WebRegex.MatchOrDefault(AlertInfo, string.Empty);
                    Console.WriteLine($"Associated URL (if any): {URL}");
                    Console.WriteLine($"Associated Web (if any): {Web}");
                    if (string.IsNullOrWhiteSpace(PrimaryURL)) PrimaryURL = URL;
                    if (string.IsNullOrWhiteSpace(PrimaryURL)) PrimaryURL = Web;

                    string EventName = Regex.Replace(EventRegex.MatchOrDefault(AlertInfo, "Cautionary (Unknown Event)"), @"(^\w)|(\s\w)", m => m.Value.ToUpperInvariant());
                    Console.WriteLine($"Event Name: {EventName}");

                    string EventType = EventCodeRegex.MatchOrDefault(AlertInfo, "???");
                    var (EventTypeTranslated, TranslationSuccessful) = GetAlertNameFromSAME(EventType);
                    Console.WriteLine($"Event: {EventType}");
                    Console.WriteLine($"Event (SAME Translation): {EventTypeTranslated}");

                    if (!PrimaryURL.Contains("sasmex.net"))
                    {
                        if (!Settings.Default.AllowNonEnglishAlerts)
                        {
                            if (!BCP47Language.ToLowerInvariant().StartsWith("en-"))
                            {
                                Console.WriteLine("[Alert Processor] Info tag discarded because it does not contain English information.");
                                break;
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
                    Console.WriteLine($"Urgency: {Urgency}");

                    string Severity = SeverityRegex.MatchOrDefault(AlertInfo, "Unknown");
                    Console.WriteLine($"Severity: {Severity}");

                    int ResourceCount = 0;
                    MatchCollection MatchedResources = ResourceRegex.Matches(AlertInfo);
                    foreach (Match resource in MatchedResources)
                    {
                        ResourceCount++;
                        Console.WriteLine($"Resource {ResourceCount} Value: {resource.Groups[1].Value}");
                        var desc = ResourceDescRegex.MatchOrDefault(resource.Groups[1].Value);
                        Console.WriteLine($"Resource {ResourceCount} Description: {desc}");
                        var mime = MIMETypeRegex.MatchOrDefault(resource.Groups[1].Value);
                        Console.WriteLine($"Resource {ResourceCount} MIME Type: {mime}");
                        var size = SizeRegex.MatchOrDefault(resource.Groups[1].Value);
                        Console.WriteLine($"Resource {ResourceCount} Size (if any): {size}");
                        var uri = URIRegex.MatchOrDefault(resource.Groups[1].Value);
                        Console.WriteLine($"Resource {ResourceCount} URI (if any): {uri}");
                        var derefUri = DerefURIRegex.MatchOrDefault(resource.Groups[1].Value);
                        Console.WriteLine($"Resource {ResourceCount} Dereference URI (if any): {derefUri}");
                        var digest = DigestSecureHashAlgorithmOneRegex.MatchOrDefault(resource.Groups[1].Value);
                        Console.WriteLine($"Resource {ResourceCount} SHA-1 (if any | unused): {digest}");

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

                    if (!ReplayMode)
                    {
                        if (DateTime.Parse(Expiry, CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal) <= DateTime.Now)
                        {
                            Console.WriteLine($"[Alert Processor] Info tag discarded because it has expired.");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"[Alert Processor] Expiry check skipped because the alert is being replayed.");
                    }

                    bool EventBlacklisted = false;

                    if ((ProcessParameterX(AlertInfo) && ProcessAlertX(Status, MsgType, Severity)) ||
                        BroadcastImmediatelyRegex.MatchOrDefault(AlertInfo, "no").ToLowerInvariant() == "yes")
                    {
                        foreach (string Event in Settings.Default.EnforceEventBlacklist)
                        {
                            if (EventName.ToLowerInvariant().Contains(Event.ToLowerInvariant()))
                            {
                                EventBlacklisted = true;
                                break;
                            }
                        }
                        
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
                            Console.WriteLine($"[Alert Processor] Info tag discarded due to one or more blacklisted items.");
                            continue;
                        }

                        // removal of replay boolean
                        var (Intro, Body) = CompiledBody(AlertInfo, MsgType, Sent);

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

                        AlertTextClass text = new AlertTextClass { Intro = Intro, Body = Body };

                        bool MatchFound = false;

                        foreach (var kext in AlertTextList)
                        {
                            if (kext.Intro == Intro & kext.Body == Body)
                            {
                                Console.WriteLine($"[Alert Processor] The contents of the current info tag match a previously processed tag.");
                                MatchFound = true;
                                break;
                            }
                        }

                        if (!MatchFound)
                        {
                            AlertTextList.Add(text);
                            Console.WriteLine($"[Alert Processor] The contents of the current info tag have been added.");
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"[Alert Processor] Alert discarded either due to user preferences or invalidity.");
                    }
                }

                Console.WriteLine("[Alert Processor] There is no further data to process.");

                if (AlertTextList.Count == 0)
                {
                    Console.WriteLine("[Alert Processor] There is no alert text to process.");
                }
                else
                {
                    string FullIntro = string.Empty;
                    string FullBody = string.Empty;

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

                    try
                    {
                        if (ReplayMode)
                        {
                            lock (notify)
                            {
                                notify.BalloonTipIcon = ToolTipIcon.Info;
                                notify.BalloonTipTitle = $"{Sent}";
                                notify.BalloonTipText = $"An alert with the event {EventTypeFull} was sent in replay mode.";
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

                                //if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhookAppend))
                                //{
                                //    AlertCompiled += $"\r\n\r\n{Settings.Default.DiscordWebhookAppend}";
                                //}

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
                                        notify.BalloonTipTitle = $"{Sent}";
                                        notify.BalloonTipText = $"An alert with the event {EventTypeFull} was issued.";
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
                                        notify.BalloonTipTitle = $"{Sent}";
                                        notify.BalloonTipText = $"An alert with the event {EventTypeFull} was issued, but it couldn't be sent through the webhook.";
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
                            ThreadPool.QueueUserWorkItem(_ =>
                            {
                                RelayWindow(relayItem.Name, EventTypeFull, _AlertText, PrimaryURL, MsgType, AudioFiles, ImageFiles);
                            });
                        }

                        AnyAlertRelayed = true;
                        SharpDataRelayedNamesHistory.Add(relayItem.Name);
                    }
                    catch (NotSupportedException ex)
                    {
                        Console.WriteLine($"[Alert Processor] Couldn't relay. {ex.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Alert Processor] Couldn't relay. {ex.Message}");
                    }
                    finally
                    {
                        Console.WriteLine($"[Alert Processor] Finished relaying.");
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

                        //Console.WriteLine("[Alert Processor] Sent finalizing text to the Discord webhook.");
                    }
                }
                else
                {
                    //DiscordWebhook.SendUnformattedMessage($"The incoming alert was discarded. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");
                }

                Console.WriteLine($"[Alert Processor] Processed all available entries. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");
            }
        }

        public void RelayWindow(string identifier, string EventTypeFull, AlertTextClass _AlertText, string PrimaryURL, string MsgType, List<string> AudioFiles, List<string> ImageFiles)
        {
            if (Settings.Default.DisableDialogs)
            {
                Console.WriteLine("[Alert Processor] Relay dialogs are disabled.");
                return;
            }

            Console.WriteLine("[Alert Processor] Relay queued.");

            lock (AlertValuesLock)
            {
                Console.WriteLine("[Alert Processor] Relay queue locked.");
                AlertsQueued++;
                while (AlertDisplaying)
                {
                    Monitor.Wait(AlertValuesLock);
                }
                Console.WriteLine("[Alert Processor] Relay queue unlocked.");
            }

            //if (MsgType.ToLowerInvariant() == "cancel")
            //{
            //}

            AlertsQueued--;

            if (Settings.Default.alertNoGUI)
            {
                AlertDisplaying = true;

                Console.WriteLine("[Alert Processor] Beginning alert.");

                DialogAlertID = identifier;
                DialogAlertTitle = EventTypeFull;
                DialogAlertText = (_AlertText.Intro, _AlertText.Body);
                DialogAlertType = MsgType.ToLowerInvariant();
                DialogAlertURL = PrimaryURL;

                notify.Icon = Resources.TrayAlertIcon;

                Console.WriteLine("[Alert Processor] Beginning playback of start tone.");
                PlayStartToneFile(true);
                Console.WriteLine("[Alert Processor] Beginning TTS playback of the intro text.");
                PlayFromTTSEngine(DialogAlertText.Intro, true);
                Console.WriteLine("[Alert Processor] Beginning TTS playback of the body text.");
                PlayFromTTSEngine(DialogAlertText.Body, true);
                Console.WriteLine("[Alert Processor] Beginning playback of end tone.");
                PlayEndToneFile(true);
                //PlayFromManagedSource(GenerateHeaderStream("NNNN"));

                notify.Icon = Resources.TrayLightIcon;

                Console.WriteLine("[Alert Processor] Ending alert.");

                lock (AlertValuesLock)
                {
                    AlertDisplaying = false;
                    Monitor.PulseAll(AlertValuesLock);
                }
            }
            else
            {
                AlertDisplaying = true;

                DialogAlertID = identifier;
                DialogAlertTitle = EventTypeFull;
                DialogAlertText = (_AlertText.Intro, _AlertText.Body);
                DialogAlertType = MsgType.ToLowerInvariant();
                DialogAlertURL = PrimaryURL;

                if (AudioFiles.Count != 0)
                {
                    DialogAlertAudioURL = AudioFiles[0];
                    Console.WriteLine("[Alert Processor] Using attached alert audio.");
                }
                else DialogAlertAudioURL = string.Empty;

                if (ImageFiles.Count != 0)
                {
                    Console.WriteLine("[Alert Processor] Using attached alert image.");
                    // In the future, I'd like to implement some sort of image slideshow is there are multiple.
                    DialogAlertImageURL = ImageFiles[0];
                }
                else DialogAlertImageURL = string.Empty;

                AudioFiles.Clear();
                ImageFiles.Clear();

                ShowPopup();

                lock (AlertValuesLock)
                {
                    AlertDisplaying = false;
                    Monitor.PulseAll(AlertValuesLock);
                }
            }

            Console.WriteLine("[Alert Processor] Relay released.");
        }

        public void ProcessAlertTest()
        {
            try
            {
                ChooseTestForm ctf = new ChooseTestForm(false);
                var result = ctf.ShowDialog();

                ThreadPool.QueueUserWorkItem(_ =>
                {
                    if (result == DialogResult.Yes)
                    {
                        // https://sasmex.net
                        RelayWindow("TEST",
                            ctf.EventType,
                            new AlertTextClass
                            { Intro = "Test. Test. Test.", Body = $"{ctf.EventDescription}" },
                            string.Empty,
                            "alert",
                            new List<string>() { "" },
                            new List<string>() { "" });
                    }
                });

                ctf.Dispose();
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
                var alertEvent = AlertDetails.AlertCodes.DefaultIfEmpty(AlertDetails.cautionary);
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
            Console.WriteLine("Processing InfoX.");
            bool Final = false;

            // MsgType:
            // Alert
            // Update
            // Cancel

            try
            {
                string Severity = SeverityRegex.MatchOrDefault(InfoX, "moderate").ToLowerInvariant();
                string Urgency = UrgencyRegex.MatchOrDefault(InfoX, "immediate").ToLowerInvariant();

                // TODO: Canadians have multiple categories
                string Category = CategoryRegex.MatchOrDefault(InfoX, "other").ToLowerInvariant();

                bool var1; // Severity
                bool var2; // Urgency
                bool var3; // Category

                switch (Severity)
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

                switch (Urgency)
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

                switch (Category)
                {
                    case "geo":
                        var3 = Settings.Default.categoryGeophysical;
                        break;
                    case "met":
                        var3 = Settings.Default.categoryMeterological;
                        break;
                    case "safety":
                        var3 = Settings.Default.categoryGeneralSafety;
                        break;
                    case "security":
                        var3 = Settings.Default.categorySecurity;
                        break;
                    case "rescue":
                        var3 = Settings.Default.categoryRescue;
                        break;
                    case "fire":
                        var3 = Settings.Default.categoryFire;
                        break;
                    case "health":
                        var3 = Settings.Default.categoryMedical;
                        break;
                    case "env":
                        var3 = Settings.Default.categoryEnvironmental;
                        break;
                    case "transport":
                        var3 = Settings.Default.categoryTransportation;
                        break;
                    case "infra":
                        var3 = Settings.Default.categoryUtilities;
                        break;
                    case "cbrne":
                        var3 = Settings.Default.categoryToxicThreat;
                        break;
                    case "other":
                        var3 = Settings.Default.categoryOtherUnknown;
                        break;
                    default:
                        var3 = Settings.Default.categoryOtherUnknown;
                        break;
                }

                if (var1 && var2 && var3)
                {
                    Final = true;
                    Console.WriteLine("Severity, urgency, and category, passed all checks.");
                }
                else
                {
                    Console.WriteLine("Severity, urgency, and category, did not pass all checks.\r\n" +
                        $"Severity = {var1}\r\n" +
                        $"Urgency = {var2}\r\n" +
                        $"Category = {var3}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Severity, and urgency, did not pass all checks, and completed with one or more errors. {ex.Message}");
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
                    Console.WriteLine("Any locations are allowed.");
                    return true;
                }

                // SAME
                if (Settings.Default.AllowedSAMELocations_Geocodes.Count != 0)
                {
                    StringCollection locations = new StringCollection();
                    lock (Settings.Default.AllowedSAMELocations_Geocodes)
                    {
                        foreach (string location in Settings.Default.AllowedSAMELocations_Geocodes)
                        {
                            if (!locations.Contains(location))
                            {
                                locations.Add(location);
                            }

                            string AllAboveLocation = location.Remove(3, 3) + "000";

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
                            Console.WriteLine("One or more SAME locations were matched.");
                        }
                        else
                        {
                            Console.WriteLine("No locations matched the SAME list.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unknown amount of locations were matched due to one or more errors. {ex.Message}");
                    }
                }
                
                // UGC
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
                            Console.WriteLine("One or more UGC locations were matched.");
                        }
                        else
                        {
                            Console.WriteLine("No locations matched the UGC list.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An unknown amount of locations were matches due to one or more errors. {ex.Message}");
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
        public bool ProcessParameterX(string ParameterX)
        {
            Console.WriteLine("Processing ParemeterX.");

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
            Console.WriteLine("Processing AlertX.");

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
            Console.WriteLine("[Alert Processor] Compiling body text.");
            string BroadcastText = string.Empty;

            //if (Replay)
            //{
            //    BroadcastText += $"This is a replay of the most recent alert.\x20";
            //}

            Console.WriteLine("[Alert Processor] Parsing message type.");

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
                Console.WriteLine(ex.Message);
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
                    Console.WriteLine(exx.Message);
                    effectiveDate = DateTime.UtcNow;
                }
            }

            Console.WriteLine("[Alert Processor] Parsing expiration date.");

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
                Console.WriteLine(ex.Message);
                if (Settings.Default.alertTimeZoneUTC)
                {
                    expiryDate = DateTime.UtcNow.AddHours(1);
                }
                else
                {
                    expiryDate = DateTime.UtcNow.AddHours(1).ToLocalTime();
                }
            }

            Console.WriteLine("[Alert Processor] Parsing time zone.");

            string TimeZoneName = "Unknown TZ";
            if (Settings.Default.alertTimeZoneUTC) TimeZoneName = "UTC";
            else TimeZoneName = LocalTimeAbbreviation();

            string SentFormatted = $"{sentDate:HH:mm} {TimeZoneName}, {sentDate:MMMM dd}, {sentDate:yyyy}";
            string BeginFormatted = $"{effectiveDate:HH:mm} {TimeZoneName}, {effectiveDate:MMMM dd}, {effectiveDate:yyyy}";
            string EndFormatted = $"{expiryDate:HH:mm} {TimeZoneName}, {expiryDate:MMMM dd}, {expiryDate:yyyy}";

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
                Console.WriteLine("[Alert Processor] No description and instruction set.");
                Description = "The alert information is limited or unavailable at the moment.";
                Instruction = string.Empty;
            }

            Console.WriteLine("[Alert Processor] Compiling intro text.");

            string IntroText = string.Empty;

            IntroText += SentenceAppendSpace($"This alert goes into effect starting {BeginFormatted}, and ending at {EndFormatted}.");
            IntroText += $"Issued by {SenderName}. Event type is {EventType}. {MsgPrefix} For for the following areas, {SentenceAppendEnd(AreaDesc)}";
            IntroText = IntroText.Replace("\r\n", "\n").Replace("\n", "\r\n"); // fix mixed newline problems hopefully

            Console.WriteLine("[Alert Processor] Finished compiling intro text.");

            BroadcastText += NewLineRemoval(SentenceAppendSpace(SentenceAppendEnd(Description)));
            if (Description != Instruction) BroadcastText += NewLineRemoval(SentenceAppendSpace(SentenceAppendEnd(Instruction)));
            BroadcastText = BroadcastText.Replace("###", string.Empty);
            BroadcastText = BroadcastText.Replace(" E A S ", " EAS ");
            BroadcastText = BroadcastText.Replace(" 9 1 1 ", " 9-1-1 ");
            BroadcastText = SentencePuncuationCorrection(BroadcastText)
                .Replace(",", ",\x20");
            BroadcastText = BroadcastText.Replace("\r\n", "\n").Replace("\n", "\r\n"); // fix mixed newline problems hopefully
            BroadcastText = BroadcastText.Replace("\r\n\r\n\r\n\r\n", "\r\n\r\n").Replace("\r\n\r\n\r\n", "\r\n\r\n"); // fix spacing
            BroadcastText = SentenceAppendEnd(BroadcastText);
            BroadcastText = TimeCorrection(BroadcastText);
            BroadcastText = string.Join(" ", BroadcastText.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            // It should not be this painful to fix text formatting.

            Console.WriteLine("[Alert Processor] Finished compiling body text.");
            return (IntroText, BroadcastText);
        }

        // I'm probably going to remove this anyway, it's not very useful to read alerts in a single file line.
        public string NewLineRemoval(string input)
        {
            return input;
            //return input.Replace(@"\r", "").Replace(@"\n", " ").Replace("\r", "").Replace("\n", " ");
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
                    Console.WriteLine("[Alert Processor] The cache is unavailable.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Alert Processor] {ex.Message}");
            }

            return $"Unknown, {code}";
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
    }
}
