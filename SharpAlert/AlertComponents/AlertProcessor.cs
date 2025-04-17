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

namespace SharpAlert
{
    public class AlertProcessor
    {
        private AlertForm raf = null;
        private bool rafPing = false;
        private TeleAlertForm taf = null;
        private bool tafPing = false;
        private RelayController relay = null;
        private bool relayPing = false;

        private string DialogAlertID = string.Empty;
        private string DialogAlertTitle = string.Empty;
        private (string Intro, string Body) DialogAlertText = (string.Empty, string.Empty);
        private string DialogAlertURL = string.Empty;
        private string DialogAlertAudioURL = string.Empty;
        private string DialogAlertImageURL = string.Empty;
        private string DialogAlertType = string.Empty;

        public AlertProcessor()
        {
            StartRelayCallLoop();
            StartAudioCallLoop();
            StartRAFCallLoop();
            StartTAFCallLoop();
        }

        private void StartRelayCallLoop()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                relay = new RelayController();
                Console.WriteLine("[Relay Ping] Getting HID USB relay.");
                if (relay.GetHidUSBRelay())
                {
                    Console.WriteLine("[Relay Ping] Device connected.");
                }
                else
                {
                    Console.WriteLine("[Relay Ping] Device not connected.");
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
                        StopAllAudioSilently();
                        Thread.Sleep(50);
                    }
                    Thread.Sleep(10);
                }
            });
        }

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
                        if (raf.IsDisposed) raf = new AlertForm();
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
        
        private void StartTAFCallLoop()
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Console.WriteLine($"[TAF Loop] Initializing call loop.");
                Application.EnableVisualStyles();
                taf = new TeleAlertForm();
                while (true)
                {
                    Console.WriteLine($"[TAF Loop] Waiting for the next ping.");
                    try
                    {
                        while (!tafPing) Thread.Sleep(500);
                        if (taf.IsDisposed) taf = new TeleAlertForm();
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
                        Console.WriteLine($"[Alert Processor] An info tag couldn't processed.");
                        IceBearWorker.LogFault(ex);
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

                foreach (Match infoMatch in infoMatches)
                {
                    infoProc++;
                    Console.WriteLine($"[Alert Processor] Processing {infoProc} of {infoMatches.Count}.");

                    string AlertInfo = $"{infoMatch.Groups[1].Value}";

                    string Effective = EffectiveRegex.MatchOrDefault(relayItem.Data, DateTime.UtcNow.ToString("O", CultureInfo.InvariantCulture));
                    Console.WriteLine($"Effective: {Effective}");

                    string Expiry = ExpiresRegex.MatchOrDefault(relayItem.Data, DateTime.UtcNow.AddHours(1).ToString("O", CultureInfo.InvariantCulture));
                    Console.WriteLine($"Expires: {Expiry}");

                    string EventName = EventRegex.MatchOrDefault(AlertInfo, "Cautionary (Unknown Event)");
                    Console.WriteLine($"Event Type: {EventName}");

                    string Urgency = UrgencyRegex.MatchOrDefault(AlertInfo, "Unknown");
                    Console.WriteLine($"Urgency: {Urgency}");

                    string Severity = SeverityRegex.MatchOrDefault(AlertInfo, "Unknown");
                    Console.WriteLine($"Severity: {Severity}");

                    List<string> AudioFiles = new List<string>();
                    List<string> ImageFiles = new List<string>();

                    int ResourceCount = 0;
                    MatchCollection MatchedResources = ResourceRegex.Matches(AlertInfo);
                    foreach (Match resource in MatchedResources)
                    {
                        ResourceCount++;
                        Console.WriteLine($"Resource {ResourceCount} Value: {resource.Groups[1].Value}");
                        Match desc = ResourceDescRegex.Match(resource.Groups[1].Value);
                        Console.WriteLine($"Resource {ResourceCount} Description: {desc.Groups[1].Value}");
                        Match mime = MIMETypeRegex.Match(resource.Groups[1].Value);
                        Console.WriteLine($"Resource {ResourceCount} MIME Type: {mime.Groups[1].Value}");
                        Match size = SizeRegex.Match(resource.Groups[1].Value);
                        Console.WriteLine($"Resource {ResourceCount} Size (if any | not supported): {size.Groups[1].Value}");
                        Match uri = URIRegex.Match(resource.Groups[1].Value);
                        Console.WriteLine($"Resource {ResourceCount} URI (if any): {uri.Groups[1].Value}");
                        Match derefUri = DerefURIRegex.Match(resource.Groups[1].Value);
                        Console.WriteLine($"Resource {ResourceCount} Dereference URI (if any | not supported): {derefUri.Groups[1].Value}");
                        Match digest = DigestSecureHashAlgorithmOneRegex.Match(resource.Groups[1].Value);
                        Console.WriteLine($"Resource {ResourceCount} SHA-1 (if any | not supported): {digest.Groups[1].Value}");

                        void AddAudioToList(string URI)
                        {
                            if (!string.IsNullOrWhiteSpace(URI))
                            {
                                if (URI.StartsWith("http://") || URI.StartsWith("https://")) AudioFiles.Add(URI);
                                else Console.WriteLine($"[Alert Processor] Resource {ResourceCount} contains an invalid URI.");
                            }
                            else Console.WriteLine($"[Alert Processor] Resource {ResourceCount} contains an invalid URI.");
                        }
                        
                        void AddImageToList(string URI)
                        {
                            if (!string.IsNullOrWhiteSpace(URI))
                            {
                                if (URI.StartsWith("http://") || URI.StartsWith("https://")) ImageFiles.Add(URI);
                                else Console.WriteLine($"[Alert Processor] Resource {ResourceCount} contains an invalid URI.");
                            }
                            else Console.WriteLine($"[Alert Processor] Resource {ResourceCount} contains an invalid URI.");
                        }

                        if (uri.Groups[1].Value != null)
                        {
                            switch (mime.Groups[1].Value)
                            {
                                case "audio/ogg":
                                    AddAudioToList(uri.Groups[1].Value);
                                    break;
                                case "audio/opus":
                                    AddAudioToList(uri.Groups[1].Value);
                                    break;
                                case "audio/vorbis":
                                    AddAudioToList(uri.Groups[1].Value);
                                    break;
                                case "audio/aac":
                                    AddAudioToList(uri.Groups[1].Value);
                                    break;
                                case "audio/mpeg":
                                    AddAudioToList(uri.Groups[1].Value);
                                    break;
                                case "audio/x-ipaws-audio-mp3":
                                    AddAudioToList(uri.Groups[1].Value);
                                    break;
                                case "application/x-url":
                                    AddAudioToList(uri.Groups[1].Value);
                                    break;
                            }
                            
                            switch (mime.Groups[1].Value)
                            {
                                case "image/bmp":
                                    AddImageToList(uri.Groups[1].Value);
                                    break;
                                case "image/gif":
                                    AddImageToList(uri.Groups[1].Value);
                                    break;
                                case "image/jpeg":
                                    AddImageToList(uri.Groups[1].Value);
                                    break;
                                case "image/png":
                                    AddImageToList(uri.Groups[1].Value);
                                    break;
                            }
                        }
                    }

                    string URL = WebRegex.MatchOrDefault(AlertInfo, string.Empty);
                    Console.WriteLine($"Associated URL (if any): {URL}");

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
                        Console.WriteLine($"[Alert Processor] Expiry check skipped due to replay mode.");
                    }

                    bool EventBlacklisted = false;

                    if (ProcessParameterX(AlertInfo) &&
                        ProcessAlertX(Status, MsgType, Severity))
                    {
                        foreach (string Event in Settings.Default.EnforceEventBlacklist)
                        {
                            if (EventName.ToLowerInvariant().Contains(Event.ToLowerInvariant()))
                            {
                                EventBlacklisted = true;
                                break;
                            }
                        }

                        if (EventBlacklisted)
                        {
                            Console.WriteLine($"[Alert Processor] Info tag discarded due to blacklist (event).");
                            continue;
                        }

                        var AlertText = CompiledBody(AlertInfo, MsgType, Sent, ReplayMode);

                        Console.WriteLine($"{AlertText.Intro} {AlertText.Body}");
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

                        try
                        {
                            if (ReplayMode)
                            {
                                lock (notify)
                                {
                                    notify.BalloonTipIcon = ToolTipIcon.Info;
                                    notify.BalloonTipTitle = $"{Sent}";
                                    notify.BalloonTipText = $"An alert with the event {EventName} was sent in replay mode.";
                                    notify.ShowBalloonTip(5000);
                                }
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
                                //if (Settings.Default.weaOnly) AlertCompiled = "## WIRELESS EMERGENCY ALERT\r\n";
                                //else AlertCompiled = "# EMERGENCY ALERT\r\n";
                                AlertCompiled = $"**Sent: {sentDate:f}**\r\n**Expiry: {expiresDate:f}.**\r\n\r\n" +
                                    "## Alert Message\r\n" +
                                    $"{AlertText.Intro}\r\n{AlertText.Body}";

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

                                if (DiscordWebhook.SendEmbeddedMessage($"{MaxSeverity} Emergency Alert | {MsgType.First().ToString().ToUpper() + MsgType.Substring(1)}",
                                    AlertCompiled,
                                    relayItem,
                                    color))
                                {
                                    lock (notify)
                                    {
                                        notify.BalloonTipIcon = ToolTipIcon.Info;
                                        notify.BalloonTipTitle = $"{Sent}";
                                        notify.BalloonTipText = $"An alert with the event {EventName} was issued.";
                                        notify.ShowBalloonTip(5000);
                                    }
                                    AnyAlertRelayed = true;
                                }
                                else
                                {
                                    lock (notify)
                                    {
                                        notify.BalloonTipIcon = ToolTipIcon.Warning;
                                        notify.BalloonTipTitle = $"{Sent}";
                                        notify.BalloonTipText = $"An alert with the event {EventName} was issued, but it couldn't be sent through the webhook.";
                                        notify.ShowBalloonTip(5000);
                                    }
                                }

                                // Delay to prevent the webhook from being rate limited
                                Thread.Sleep(1000);
                            }
                            else
                            {
                                ThreadPool.QueueUserWorkItem(_ =>
                                {
                                    AlertsQueued++;

                                    Console.WriteLine("[Alert Processor] Relay queued.");

                                    lock (AlertValuesLock)
                                    {
                                        Console.WriteLine("[Alert Processor] Relay queue locked.");
                                        while (AlertDisplaying)
                                        {
                                            Monitor.Wait(AlertValuesLock);
                                        }
                                        Console.WriteLine("[Alert Processor] Relay queue unlocked.");
                                    }

                                    if (Settings.Default.alertNoGUI)
                                    {
                                        AlertDisplaying = true;
                                        AlertsQueued--;

                                        DialogAlertID = relayItem.Name;
                                        DialogAlertTitle = EventName;
                                        DialogAlertText = AlertText;
                                        if (!string.IsNullOrWhiteSpace(DialogAlertURL)) DialogAlertURL = URL;
                                        else DialogAlertURL = string.Empty;

                                        Console.WriteLine($"[Alert Processor] Alert Text:\r\n{DialogAlertText.Intro} {DialogAlertText.Body}");

                                        notify.Icon = Resources.TrayAlertIcon;

                                        PlayStartToneFile();
                                        PlayFromTTSEngineAndWait(DialogAlertText.Intro);
                                        PlayFromTTSEngineAndWait(DialogAlertText.Body);
                                        PlayEndToneFile();

                                        notify.Icon = Resources.TrayLightIcon;

                                        lock (AlertValuesLock)
                                        {
                                            AlertDisplaying = false;
                                            Monitor.PulseAll(AlertValuesLock);
                                        }
                                    }
                                    else
                                    {
                                        AlertDisplaying = true;
                                        AlertsQueued--;

                                        DialogAlertID = relayItem.Name;
                                        DialogAlertTitle = EventName;
                                        DialogAlertText = AlertText;
                                        if (!string.IsNullOrWhiteSpace(DialogAlertURL)) DialogAlertURL = URL;
                                        else DialogAlertURL = string.Empty;

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

                                        DialogAlertType = $"{MsgType.ToLowerInvariant()}";

                                        if (Settings.Default.alertFullscreen)
                                        {
                                            tafPing = true;
                                            while (tafPing) Thread.Sleep(500);
                                        }
                                        else
                                        {
                                            rafPing = true;
                                            while (rafPing) Thread.Sleep(500);
                                        }

                                        lock (AlertValuesLock)
                                        {
                                            AlertDisplaying = false;
                                            Monitor.PulseAll(AlertValuesLock);
                                        }
                                    }

                                    Console.WriteLine("[Alert Processor] Relay released.");
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

                        if (AnyAlertRelayed) AlertsRelayed++;
                    }
                    else
                    {
                        Console.WriteLine($"[Alert Processor] Alert discarded either due to user preferences or invalidity.");
                    }
                }

                if (AnyAlertRelayed)
                {
                    if (UsedDiscordHook)
                    {
                        string EventsList = string.Empty;
                        foreach (string Event in AllEvents)
                        {
                            EventsList += $"{Regex.Replace(Event.ToLowerInvariant(), @"(^\w)|(\s\w)", m => m.Value.ToUpperInvariant())}, ";
                        }
                        EventsList = EventsList.Substring(0, EventsList.Length - 2);

                        string LocationList = string.Empty;
                        foreach (string Location in AllLocations)
                        {
                            foreach (string loc in Location.Split(';')) LocationList += $"{loc.Trim()}; ";
                        }

                        LocationList = LocationList.Trim().Substring(0, LocationList.Length - 2).Trim();
                        if (LocationList.EndsWith(";")) LocationList = LocationList.Substring(0, LocationList.Length - 1);

                        string CompiledMessage = $"{EventsList} | {MaxSeverity} | Location(s): {LocationList}\r\n-# Identifier: {relayItem.Name}\r\n-# Process Time: {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms";
                        if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhookAppend)) CompiledMessage += "\r\n" + Settings.Default.DiscordWebhookAppend;
                        DiscordWebhook.SendUnformattedMessage(CompiledMessage);

                        Console.WriteLine("[Alert Processor] Sent finalizing text to the Discord webhook.");
                    }
                }
                else
                {
                    //DiscordWebhook.SendUnformattedMessage($"The incoming alert was discarded. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");
                }

                Console.WriteLine($"[Alert Processor] Processed all available entries. (completed in {(int)(DateTime.UtcNow - startProc).TotalMilliseconds} ms)");
            }
        }

        public void ProcessAlertTest()
        {
            try
            {
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    Console.WriteLine("[Alert Processor] Relay queued.");

                    lock (AlertValuesLock)
                    {
                        Console.WriteLine("[Alert Processor] Relay queue locked.");
                        while (AlertDisplaying)
                        {
                            Monitor.Wait(AlertValuesLock);
                        }
                        Console.WriteLine("[Alert Processor] Relay queue unlocked.");
                    }

                    AlertDisplaying = true;
                    DialogAlertID = "TEST";
                    DialogAlertTitle = "Standard Test";
                    DialogAlertText.Intro = "This is a test of SharpAlert's alert display.";
                    DialogAlertText.Body = Resources.TestScript.Replace("\r", string.Empty).Replace("\n", "\x20").Trim();
                    DialogAlertURL = "https://sharpalert.bunnytub.com";
                    DialogAlertAudioURL = string.Empty;
                    DialogAlertImageURL = string.Empty;
                    DialogAlertType = "alert";

                    if (Settings.Default.alertFullscreen)
                    {
                        tafPing = true;
                        while (tafPing) Thread.Sleep(500);
                    }
                    else
                    {
                        rafPing = true;
                        while (rafPing) Thread.Sleep(500);
                    }

                    lock (AlertValuesLock)
                    {
                        AlertDisplaying = false;
                        Monitor.PulseAll(AlertValuesLock);
                    }

                    Console.WriteLine("[Alert Processor] Test released.");
                });
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
                string Severity = SeverityRegex.MatchOrDefault(InfoX, "Moderate").ToLowerInvariant();
                string Urgency = UrgencyRegex.MatchOrDefault(InfoX, "Immediate").ToLowerInvariant();
                string Category = CategoryRegex.MatchOrDefault(InfoX, "Other").ToLowerInvariant();

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
                    Settings.Default.AllowedUGCLocations_Geocodes.Count == 0)
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
                var WEAHandle = WEAHandlingRegex.Match(ParameterX);

                if (WEAHandle.Success)
                {
                    switch (WEAHandle.Value.ToLowerInvariant())
                    {
                        case "imminent threat":
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
        public (string Intro, string Body) CompiledBody(string InfoData, string MsgType, string Sent, bool Replay)
        {
            string BroadcastText = string.Empty;

            if (Replay)
            {
                BroadcastText += $"This is a replay of the most recent alert.\x20";
            }

            string issue = "issued";
            string update = "updated";
            string cancel = "cancelled";

            string MsgPrefix;
            switch (MsgType.ToLowerInvariant())
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
                Match effective = EffectiveRegex.Match(InfoData);
                if (Settings.Default.alertTimeZoneUTC)
                {
                    effectiveDate = DateTime.Parse(effective.Groups[1].Value, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                }
                else
                {
                    effectiveDate = DateTime.Parse(effective.Groups[1].Value, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal).ToLocalTime();
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

            DateTime expiryDate;
            try
            {
                Match expires = ExpiresRegex.Match(InfoData);
                if (Settings.Default.alertTimeZoneUTC)
                {
                    expiryDate = DateTime.Parse(expires.Groups[1].Value, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
                }
                else
                {
                    expiryDate = DateTime.Parse(expires.Groups[1].Value, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal).ToLocalTime();
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

            //DateTime sentDate = DateTime.Parse(Sent, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal).ToUniversalTime();

            string TimeZoneName = "Unknown TZ";
            if (Settings.Default.alertTimeZoneUTC) TimeZoneName = "UTC";
            else TimeZoneName = LocalTimeAbbreviation();

            string SentFormatted = $"{sentDate:HH:mm} {TimeZoneName}, {sentDate:MMMM dd}, {sentDate:yyyy}";
            string BeginFormatted = $"{effectiveDate:HH:mm} {TimeZoneName}, {effectiveDate:MMMM dd}, {effectiveDate:yyyy}";
            string EndFormatted = $"{expiryDate:HH:mm} {TimeZoneName}, {expiryDate:MMMM dd}, {expiryDate:yyyy}";

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

            string AreaDesc = "Unspecified localities";

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
            }
            catch (Exception)
            {
            }

            string SenderName;

            try
            {
                SenderName = SenderNameRegex.MatchOrDefault(InfoData, "Governing Entity (Unknown Sender)").Replace(",", ",\x20");
            }
            catch (Exception)
            {
                SenderName = "Governing Entity (Unknown Sender)";
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
                Description = "The alert information is limited or unavailable. It may be within another info tag.";
                Instruction = string.Empty;
            }

            string IntroText = string.Empty;

            IntroText += SentenceAppendSpace($"This alert goes into effect starting {BeginFormatted}, and ends at {EndFormatted}.");
            IntroText += $"Issued by {SenderName}. Event type is {EventType}. Covering the following areas, {SentenceAppendEnd(AreaDesc)}";
            BroadcastText += NewLineRemoval(SentenceAppendSpace(SentenceAppendEnd(Description)));
            if (Description != Instruction) BroadcastText += NewLineRemoval(SentenceAppendSpace(SentenceAppendEnd(Instruction)));
            BroadcastText = BroadcastText.Replace("###", string.Empty);
            BroadcastText = BroadcastText.Replace("E A S", " EAS ");
            BroadcastText = BroadcastText.Replace("9 1 1", " 9-1-1 ");
            BroadcastText = SentencePuncuationCorrection(BroadcastText)
                .Replace("* WHAT,", string.Empty)
                .Replace("* WHERE,", string.Empty)
                .Replace("* WHEN,", string.Empty)
                .Replace("* IMPACTS,", string.Empty);
            BroadcastText = SentenceAppendEnd(BroadcastText);
            BroadcastText = TimeCorrection(BroadcastText);
            BroadcastText = string.Join(" ", BroadcastText.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            return (IntroText, BroadcastText);
        }

        string NewLineRemoval(string input)
        {
            return input.Replace(@"\r", "").Replace(@"\n", " ").Replace("\r", "").Replace("\n", " ");
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
            FriendlyData = FriendlyData.Replace("\r", string.Empty).Replace("\n", ".");
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
