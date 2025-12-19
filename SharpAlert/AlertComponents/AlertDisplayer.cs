using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using SharpAlert.PrinterStuff;
using SharpAlert.ProgramWorker;
using SharpAlert.Properties;
using SharpAlert.WebServer;
using static SharpAlert.AlertComponents.AlertProcessor;
using static SharpAlert.AudioManager;
using static SharpAlert.ProgramWorker.MainEntryPoint;
using static SharpAlert.ProgramWorker.NotificationWorker;

namespace SharpAlert.AlertComponents
{
    public static class AlertDisplayer
    {
        //public static string DialogAlertID = string.Empty;
        //public static string DialogAlertTitle = string.Empty;
        //public static  (string Intro, string Body) DialogAlertText = (string.Empty, string.Empty);
        //public static string DialogAlertURL = string.Empty;
        //public static string DialogAlertAudioURL = string.Empty;
        //public static string DialogAlertImageURL = string.Empty;
        //public static string DialogAlertType = string.Empty;
        //public static string DialogAlertSeverity = string.Empty;
        private static readonly List<AlertDisplayerInfo> Alerts = [];

        public class AlertDisplayerInfo
        {
            public string Identifier = string.Empty;
            public string EventTypeFull = string.Empty;
            public AlertTextClass _AlertText = null;
            public string PrimaryURL = string.Empty;
            public string MsgType = string.Empty;
            public string Severity = string.Empty;
            public List<string> AudioFiles = [];
            public List<string> AudioDeref = [];
            public List<string> ImageFiles = [];
        }

        public static void RelayWindow(string Identifier, string EventTypeFull, AlertTextClass _AlertText, string PrimaryURL, string MsgType, string Severity, List<string> AudioFiles, List<string> AudioDeref, List<string> ImageFiles)
        {
            AlertDisplayerInfo alert = new()
            {
                Identifier = Identifier,
                EventTypeFull = EventTypeFull,
                _AlertText = _AlertText,
                PrimaryURL = PrimaryURL,
                MsgType = MsgType,
                Severity = Severity,
                AudioFiles = AudioFiles,
                AudioDeref = AudioDeref,
                ImageFiles = ImageFiles
            };

            Alerts.Add(alert);
            Console.WriteLine($"[Alert Displayer] Queued message -> {Identifier}");
        }

        public static void StartDisplayerCallLoop()
        {
            ThreadDrool.StartCatchAllThread("Displayer Loop", () =>
            {
                Console.WriteLine($"[Displayer Loop] Initializing call loop.");
                while (true)
                {   
                    try
                    {
                        if (Alerts.Count != 0)
                        {
                            lock (Alerts)
                            {
                                AlertDisplayerInfo alert = Alerts.First();
                                Alerts.Remove(alert);
                                if (QuickSettings.Instance.DisableAlertProcessing)
                                {
                                    Console.WriteLine($"[Displayer Loop] Discarded, the Alert Processor is disabled -> {alert.Identifier}");
                                    continue;
                                }
                                Console.WriteLine($"[Displayer Loop] Processing -> {alert.Identifier}");
                                ProcessQueueItem(alert);
                                //Console.WriteLine($"[Displayer Loop] Waiting for queued items.");
                            }
                        }
                        Thread.Sleep(100);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"[Displayer Loop] {ex.Message}");
                    }
                }
            }, true, true, ApartmentState.STA);
        }

        private static void ProcessQueueItem(AlertDisplayerInfo alert)
        {
            Console.WriteLine("[Alert Displayer] Relay queued.");

            lock (AlertValuesLock)
            {
                Console.WriteLine("[Alert Displayer] Relay queue locked.");
                AlertsQueued++;
                while (AlertDisplaying)
                {
                    Monitor.Wait(AlertValuesLock);
                }
                Console.WriteLine("[Alert Displayer] Relay queue unlocked.");
            }

            AlertsQueued--;

            if (QuickSettings.Instance.DisableDialogs)
            {
                Console.WriteLine("[Alert Displayer] Relay dialogs are disabled. Pausing for 5 seconds.");
                AlertDisplaying = true;
                Thread.Sleep(5000);
                AlertDisplaying = false;
                return;
            }

            hyper.RecentAlert = alert;

            if (QuickSettings.Instance.alertAutoPrintingEnabled)
            {
                PrinterController.Print(alert.EventTypeFull, $"{alert._AlertText.Intro}\r\n\r\n{alert._AlertText.Body}".Trim());
            }

            if (QuickSettings.Instance.alertNoGUI)
            {
                AlertDisplaying = true;

                Console.WriteLine("[Alert Displayer] Beginning alert.");

                Notify.Icon = Resources.TrayAlertIcon;

                Console.WriteLine("[Alert Displayer] Beginning playback of start tone.");
                PlayStartToneFile(alert.Severity, alert.MsgType, true);
                Console.WriteLine("[Alert Displayer] Beginning TTS playback of the intro text.");
                PlayFromTTSEngine(alert._AlertText.Intro, true);
                Console.WriteLine("[Alert Displayer] Beginning TTS playback of the body text.");
                PlayFromTTSEngine(alert._AlertText.Body, true);
                Console.WriteLine("[Alert Displayer] Beginning playback of end tone.");
                PlayEndToneFile(true);

                Notify.Icon = Resources.TrayLightIcon;

                Console.WriteLine("[Alert Displayer] Ending alert.");

                lock (AlertValuesLock)
                {
                    AlertDisplaying = false;
                    Monitor.PulseAll(AlertValuesLock);
                }
            }
            else
            {
                AlertDisplaying = true;

                ShowPopup(alert);

                lock (AlertValuesLock)
                {
                    AlertDisplaying = false;
                    Monitor.PulseAll(AlertValuesLock);
                }
            }

            Console.WriteLine("[Alert Displayer] Relay released.");
        }

        private static readonly object PopupLock = new object();

        /// <summary>
        /// The time in seconds to wait until the next alert dialog can be shown.
        /// </summary>
        public static int DeadTimeOverride = 0;

        private static void ShowPopup(AlertDisplayerInfo alert)
        {
            lock (PopupLock)
            {
                DeadTimeOverride = 0;
                if (!AllowThreadRestarts) return;

                // determine the dialog to use

                //if (alert.PrimaryURL.Contains("sasmex.net"))
                //{
                //    Console.WriteLine("[Alert Displayer] Earthquake alert detected.");
                //    if (shkPing)
                //    {
                //        try
                //        {
                //            shk.Invoke((Action)delegate
                //            {
                //                shk.UpdateFields(alert.Identifier,
                //                    alert.EventTypeFull,
                //                    alert._AlertText.Intro,
                //                    alert._AlertText.Body,
                //                    alert.PrimaryURL,
                //                    alert.MsgType, 16.74151, -95.09448);
                //            });
                //        }
                //        catch (Exception ex)
                //        {
                //            Console.WriteLine($"[Alert Displayer] {ex.Message}");
                //        }
                //    }
                //    else shkPing = true;
                //}
                //else
                {
                    AlertDisplaying = true;

                    Notify.Icon = Resources.TrayAlertIcon;

                    relayPing = true;

                    switch (alert.Severity.ToLowerInvariant())
                    {
                        case "extreme":
                        case "severe":
                            SpeakingManager.SevereOrHigher();
                            break;
                        default:
                            SpeakingManager.ModerateOrLower();
                            break;
                    }

                    // don't forget to implement audio deref...

                    switch (QuickSettings.Instance.alertDisplayType)
                    {
                        default:
                        case 0:
                            // AlertForm
                            if (raf == null || raf.IsDisposed) raf = new AlertForm();
                            raf.UpdateFields(alert.Identifier,
                                alert.EventTypeFull,
                                alert._AlertText.Intro,
                                alert._AlertText.Body,
                                alert.PrimaryURL,
                                alert.AudioFiles.FirstOrEmpty(),
                                alert.ImageFiles.FirstOrEmpty(),
                                alert.MsgType,
                                alert.Severity);
                            raf.ShowDialog();
                            break;
                        case 1:
                            // MiniAlertForm
                            if (maf == null || maf.IsDisposed) maf = new MiniAlertForm();
                            maf.UpdateFields(alert.Identifier,
                                alert.EventTypeFull,
                                alert._AlertText.Intro,
                                alert._AlertText.Body,
                                alert.PrimaryURL,
                                alert.AudioFiles.FirstOrEmpty(),
                                alert.ImageFiles.FirstOrEmpty(),
                                alert.MsgType,
                                alert.Severity);
                            maf.ShowDialog();
                            break;
                        case 2:
                            // TeleAlertForm
                            if (taf == null || taf.IsDisposed) taf = new TeleAlertForm();
                            taf.UpdateFields(alert.Identifier,
                                alert.EventTypeFull,
                                alert._AlertText.Intro,
                                alert._AlertText.Body,
                                alert.PrimaryURL,
                                alert.AudioFiles.FirstOrEmpty(),
                                alert.ImageFiles.FirstOrEmpty(),
                                alert.MsgType,
                                alert.Severity);
                            taf.ShowDialog();
                            break;
                        case 3:
                            // ScrollAlertForm
                            if (saf == null || saf.IsDisposed) saf = new ScrollAlertForm();
                            saf.UpdateFields(alert.Identifier,
                                alert.EventTypeFull,
                                alert._AlertText.Intro,
                                alert._AlertText.Body,
                                alert.PrimaryURL,
                                alert.AudioFiles.FirstOrEmpty(),
                                alert.ImageFiles.FirstOrEmpty(),
                                alert.MsgType,
                                alert.Severity);
                            saf.ShowDialog();
                            break;
                        case 4:
                            // MultiAlertForm
                            if (baf == null || baf.IsDisposed) baf = new BoardAlertForm();
                            baf.UpdateFields(alert.Identifier,
                                alert.EventTypeFull,
                                alert._AlertText.Intro,
                                alert._AlertText.Body,
                                alert.PrimaryURL,
                                alert.AudioFiles.FirstOrEmpty(),
                                alert.ImageFiles.FirstOrEmpty(),
                                alert.MsgType,
                                alert.Severity);
                            baf.ShowDialog();
                            break;
                    }

                    Notify.Icon = Resources.TrayLightIcon;

                    AlertDisplaying = false;

                    if (DeadTimeOverride <= 0)
                    {
                        int DeadTime = QuickSettings.Instance.AlertDeadInterval;
                        if (DeadTime != 0)
                        {
                            Console.WriteLine($"[Alert Displayer] Pausing alerts for {DeadTime} second(s) to fill dead time.");
                            Thread.Sleep(DeadTime * 1000);
                        }
                        else Thread.Sleep(100);
                    }
                    else
                    {
                        Console.WriteLine($"[Alert Displayer] Pausing alerts for {DeadTimeOverride} second(s) to fill dead time override.");
                        Thread.Sleep(DeadTimeOverride * 1000);
                    }
                }
            }
        }

        public static string FirstOrEmpty(this List<string> list)
        {
            // inconceivable, but it works.
            return (list != null && list.Count > 0) ? list[0] : string.Empty;
        }

        private static AlertForm raf = null;
        private static TeleAlertForm taf = null;
        private static MiniAlertForm maf = null;
        private static ScrollAlertForm saf = null;
        private static BoardAlertForm baf = null;

        private static RelayController relay = null;
        private static bool relayPing = false;

        public static void StartRelayCallLoop()
        {
            ThreadDrool.StartCatchAllThread("Relay Ping", () =>
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

                        if (QuickSettings.Instance.alertNoRelay) continue;

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
            }, true);
        }

        public static void StartAudioCallLoop()
        {
            ThreadDrool.StartCatchAllThread("Audio Loop", () =>
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
            ThreadDrool.StartCatchAllThread("SHK Loop", () =>
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
                        //shk.UpdateFields(alert.Identifier, DialogAlertTitle, DialogAlertText.Intro, DialogAlertText.Body, DialogAlertURL, DialogAlertType, 16.74151, -95.09448);
                        relayPing = true;
                        Notify.Icon = Resources.TrayAlertIcon;
                        shk.ShowDialog();
                        shkPing = false;
                        Notify.Icon = Resources.TrayLightIcon;
                    }
                    catch (Exception ex)
                    {
                        shkPing = false;
                        Console.WriteLine($"[SHK Loop] {ex.Message}");
                    }
                }
            }, true);
        }
    }
}

