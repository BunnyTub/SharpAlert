using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SharpAlert.Properties;
using static SharpAlert.AlertProcessor;
using static SharpAlert.AudioManager;
using static SharpAlert.MainEntryPoint;

namespace SharpAlert
{
    public static class AlertDisplayer
    {
        public static string DialogAlertID = string.Empty;
        public static string DialogAlertTitle = string.Empty;
        public static  (string Intro, string Body) DialogAlertText = (string.Empty, string.Empty);
        public static string DialogAlertURL = string.Empty;
        public static string DialogAlertAudioURL = string.Empty;
        public static string DialogAlertImageURL = string.Empty;
        public static string DialogAlertType = string.Empty;
        public static List<AlertDisplayerInfo> Alerts = new List<AlertDisplayerInfo>();
        public class AlertDisplayerInfo
        {
            public string Identifier = string.Empty;
            public string EventTypeFull = string.Empty;
            public AlertTextClass _AlertText = null;
            public string PrimaryURL = string.Empty;
            public string MsgType = string.Empty;
            public List<string> AudioFiles = new List<string>();
            public List<string> ImageFiles = new List<string>();
        }

        public static void RelayWindow(string Identifier, string EventTypeFull, AlertTextClass _AlertText, string PrimaryURL, string MsgType, List<string> AudioFiles, List<string> ImageFiles)
        {
            if (Settings.Default.DisableDialogs)
            {
                ConsoleExt.WriteLine("[Alert Displayer] Relay dialogs are disabled.");
                return;
            }

            AlertDisplayerInfo alert = new AlertDisplayerInfo
            {
                Identifier = Identifier,
                EventTypeFull = EventTypeFull,
                _AlertText = _AlertText,
                PrimaryURL = PrimaryURL,
                MsgType = MsgType,
                AudioFiles = AudioFiles,
                ImageFiles = ImageFiles
            };

            ConsoleExt.WriteLine($"[Alert Displayer] Queued -> {Identifier}");
            Alerts.Add(alert);
        }

        public static void StartDisplayerCallLoop()
        {
            ThreadDrool.StartCatchAllThread(() =>
            {
                ConsoleExt.WriteLine($"[Displayer Loop] Initializing call loop.");
                while (true)
                {
                    try
                    {
                        if (Alerts.Any())
                        {
                            lock (Alerts)
                            {
                                AlertDisplayerInfo alert = Alerts.First();
                                Alerts.Remove(alert);
                                ConsoleExt.WriteLine($"[Displayer Loop] Processing -> {alert.Identifier}");
                                ProcessQueueItem(alert.Identifier, alert.EventTypeFull, alert._AlertText, alert.PrimaryURL, alert.MsgType, alert.AudioFiles, alert.ImageFiles);
                                //ConsoleExt.WriteLine($"[Displayer Loop] Waiting for queued items.");
                            }
                        }
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        ConsoleExt.WriteLine($"[Displayer Loop] {ex.Message}");
                    }
                }
            }, true);
        }

        private static void ProcessQueueItem(string Identifier, string EventTypeFull, AlertTextClass _AlertText, string PrimaryURL, string MsgType, List<string> AudioFiles, List<string> ImageFiles)
        {
            ConsoleExt.WriteLine("[Alert Displayer] Relay queued.");

            lock (AlertValuesLock)
            {
                ConsoleExt.WriteLine("[Alert Displayer] Relay queue locked.");
                AlertsQueued++;
                while (AlertDisplaying)
                {
                    Monitor.Wait(AlertValuesLock);
                }
                ConsoleExt.WriteLine("[Alert Displayer] Relay queue unlocked.");
            }

            //if (MsgType.ToLowerInvariant() == "cancel")
            //{
            //}

            AlertsQueued--;

            if (Settings.Default.alertNoGUI)
            {
                AlertDisplaying = true;

                ConsoleExt.WriteLine("[Alert Displayer] Beginning alert.");

                DialogAlertID = Identifier;
                DialogAlertTitle = EventTypeFull;
                DialogAlertText = (_AlertText.Intro, _AlertText.Body);
                DialogAlertType = MsgType.ToLowerInvariant();
                DialogAlertURL = PrimaryURL;

                notify.Icon = Resources.TrayAlertIcon;

                ConsoleExt.WriteLine("[Alert Displayer] Beginning playback of start tone.");
                PlayStartToneFile(true);
                ConsoleExt.WriteLine("[Alert Displayer] Beginning TTS playback of the intro text.");
                PlayFromTTSEngine(DialogAlertText.Intro, true);
                ConsoleExt.WriteLine("[Alert Displayer] Beginning TTS playback of the body text.");
                PlayFromTTSEngine(DialogAlertText.Body, true);
                ConsoleExt.WriteLine("[Alert Displayer] Beginning playback of end tone.");
                PlayEndToneFile(true);
                //PlayFromManagedSource(GenerateHeaderStream("NNNN"));

                notify.Icon = Resources.TrayLightIcon;

                ConsoleExt.WriteLine("[Alert Displayer] Ending alert.");

                lock (AlertValuesLock)
                {
                    AlertDisplaying = false;
                    Monitor.PulseAll(AlertValuesLock);
                }
            }
            else
            {
                AlertDisplaying = true;

                DialogAlertID = Identifier;
                DialogAlertTitle = EventTypeFull;
                DialogAlertText = (_AlertText.Intro, _AlertText.Body);
                DialogAlertType = MsgType.ToLowerInvariant();
                DialogAlertURL = PrimaryURL;

                if (AudioFiles.Count != 0)
                {
                    DialogAlertAudioURL = AudioFiles[0];
                    ConsoleExt.WriteLine("[Alert Displayer] Using attached alert audio.");
                }
                else DialogAlertAudioURL = string.Empty;

                if (ImageFiles.Count != 0)
                {
                    ConsoleExt.WriteLine("[Alert Displayer] Using attached alert image.");
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

            ConsoleExt.WriteLine("[Alert Displayer] Relay released.");
        }

        private static readonly object PopupLock = new object();

        public static int DeadTimeOverride = 0;

        public static void ShowPopup(bool IgnoreAlertsInProgress = false)
        {
            lock (PopupLock)
            {
                DeadTimeOverride = 0;
                if (!AllowThreadRestarts) return;

                // determine the dialog to use

                if (DialogAlertURL.Contains("sasmex.net"))
                {
                    ConsoleExt.WriteLine("[Alert Displayer] Earthquake alert detected.");
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
                            Console.WriteLine($"[Alert Displayer] {ex.Message}");
                        }
                    }
                    else shkPing = true;
                }
                else
                {
                    AlertDisplaying = true;

                    if (IgnoreAlertsInProgress)
                    {
                        ThreadDrool.StartAndForget(() =>
                        {
                            AlertForm af = new AlertForm();
                            af.UpdateFields(DialogAlertID, DialogAlertTitle, DialogAlertText.Intro, DialogAlertText.Body, DialogAlertURL, DialogAlertAudioURL, DialogAlertImageURL, DialogAlertType);
                            relayPing = true;
                            af.ShowDialog();
                        });
                    }
                    else
                    {
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
                    }

                    AlertDisplaying = false;

                    if (DeadTimeOverride <= 0)
                    {
                        int DeadTime = Settings.Default.AlertDeadInterval;
                        if (DeadTime != 0)
                        {
                            ConsoleExt.WriteLine($"[Alert Displayer] Pausing alerts for {DeadTime} second(s) to fill dead time.");
                            Thread.Sleep(DeadTime * 1000);
                        }
                        else Thread.Sleep(100);
                    }
                    else
                    {
                        ConsoleExt.WriteLine($"[Alert Displayer] Pausing alerts for {DeadTimeOverride} second(s) to fill dead time override.");
                        Thread.Sleep(DeadTimeOverride * 1000);
                    }
                }
            }
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
        //            ConsoleExt.WriteLine($"[Alert Displayer] {ex.Message}");
        //        }
        //    }
        //}

        private static RelayController relay = null;
        private static bool relayPing = false;

        public static void StartRelayCallLoop()
        {
            ThreadDrool.StartCatchAllThread(() =>
            {
                relay = new RelayController();
                ConsoleExt.WriteLine("[Relay Ping] Getting HID USB relay.");
                if (relay.GetHidUSBRelay())
                {
                    ConsoleExt.WriteLine("[Relay Ping] HID USB relay connected.");
                }
                else
                {
                    ConsoleExt.WriteLine("[Relay Ping] No HID USB relay is connected.");
                }
                while (true)
                {
                    if (relayPing)
                    {
                        relayPing = false;

                        if (Settings.Default.alertNoRelay) continue;

                        Thread.Sleep(1000);

                        ConsoleExt.WriteLine("[Relay Ping] Triggering relay.");

                        if (!relay.OffAll())
                        {
                            if (relay.GetHidUSBRelay())
                            {
                                ConsoleExt.WriteLine("[Relay Ping] Device connected.");
                            }
                            else
                            {
                                ConsoleExt.WriteLine("[Relay Ping] Device not connected.");
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
            }, true);
        }

        public static void StartAudioCallLoop()
        {
            ThreadDrool.StartCatchAllThread(() =>
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
            }, true);
        }

        private static ImmediateAlertForm shk = null;
        private static bool shkPing = false;

        public static void StartShakeCallLoop()
        {
            ThreadDrool.StartCatchAllThread(() =>
            {
                ConsoleExt.WriteLine($"[SHK Loop] Initializing call loop.");
                Application.EnableVisualStyles();
                shk = new ImmediateAlertForm();
                while (true)
                {
                    ConsoleExt.WriteLine($"[SHK Loop] Waiting for the next ping.");
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
                        ConsoleExt.WriteLine($"[SHK Loop] {ex.Message}");
                    }
                }
            }, true);
        }

        private static AlertForm raf = null;
        private static bool rafPing = false;

        public static void StartRAFCallLoop()
        {
            ThreadDrool.StartCatchAllThread(() =>
            {
                ConsoleExt.WriteLine($"[RAF Loop] Initializing call loop.");
                Application.EnableVisualStyles();
                raf = new AlertForm();
                while (true)
                {
                    ConsoleExt.WriteLine($"[RAF Loop] Waiting for the next ping.");
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
                        ConsoleExt.WriteLine($"[RAF Loop] {ex.Message}");
                    }
                }
            }, true);
        }

        private static TeleAlertForm taf = null;
        private static bool tafPing = false;

        public static void StartTAFCallLoop()
        {
            ThreadDrool.StartCatchAllThread(() =>
            {
                ConsoleExt.WriteLine($"[TAF Loop] Initializing call loop.");
                Application.EnableVisualStyles();
                while (true)
                {
                    ConsoleExt.WriteLine($"[TAF Loop] Waiting for the next ping.");
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
                        ConsoleExt.WriteLine($"[TAF Loop] {ex.Message}");
                    }
                }
            }, true);
        }

        private static MiniAlertForm maf = null;
        private static bool mafPing = false;

        public static void StartMAFCallLoop()
        {
            ThreadDrool.StartCatchAllThread(() =>
            {
                ConsoleExt.WriteLine($"[MAF Loop] Initializing call loop.");
                Application.EnableVisualStyles();
                while (true)
                {
                    ConsoleExt.WriteLine($"[MAF Loop] Waiting for the next ping.");
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
                        ConsoleExt.WriteLine($"[MAF Loop] {ex.Message}");
                    }
                }
            }, true);
        }

        private static ScrollAlertForm saf = null;
        private static bool safPing = false;

        public static void StartSAFCallLoop()
        {
            ThreadDrool.StartCatchAllThread(() =>
            {
                ConsoleExt.WriteLine($"[SAF Loop] Initializing call loop.");
                Application.EnableVisualStyles();
                while (true)
                {
                    ConsoleExt.WriteLine($"[SAF Loop] Waiting for the next ping.");
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
                        ConsoleExt.WriteLine($"[SAF Loop] {ex.Message}");

                    }
                }
            }, true);
        }
    }
}
