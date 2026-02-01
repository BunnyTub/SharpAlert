using System;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace SharpAlert.ProgramWorker
{
    public static class DoNotDisturbMode
    {
        //public static int DNDModeRemainingTimeInMinutes { get; private set; } = 0;
        private static readonly Timer DNDSubtractionTimer = new()
        {
            AutoReset = true,
            Enabled = false
        };

        public static void StartDND(int RemainingTimeInMinutes, bool PauseDataProcInsteadOfDisablingAlertProc)
        {
            lock (DNDSubtractionTimer)
            {
                //DNDModeRemainingTimeInMinutes = RemainingTimeInMinutes;
                DNDSubtractionTimer.Stop();
                if (PauseDataProcInsteadOfDisablingAlertProc)
                {
                    QuickSettings.Instance.DisableAlertProcessing = false;
                    QuickSettings.Instance.PauseDataProcessing = true;
                }
                else
                {
                    QuickSettings.Instance.DisableAlertProcessing = true;
                    QuickSettings.Instance.PauseDataProcessing = false;
                }
                if (RemainingTimeInMinutes > 0)
                {
                    DNDSubtractionTimer.Interval = TimeSpan.FromMinutes(RemainingTimeInMinutes).TotalMilliseconds;
                    DNDSubtractionTimer.Elapsed -= DNDSubtractionTimer_Elapsed;
                    DNDSubtractionTimer.Elapsed += DNDSubtractionTimer_Elapsed;
                    DNDSubtractionTimer.Start();
                    Console.WriteLine($"[Do Not Disturb] DND started with a remaining time of {RemainingTimeInMinutes} minute(s).");
                    NotificationWorker.Notify.ShowNotification($"You cannot receive alerts for {RemainingTimeInMinutes} minute(s).", "DND has been enabled", ToolTipIcon.Info);
                }
                else
                {
                    Console.WriteLine($"[Do Not Disturb] DND started.");
                    NotificationWorker.Notify.ShowNotification($"You cannot receive alerts. You'll need to manually disable DND to start receive alerts again.", "DND has been enabled", ToolTipIcon.Info);
                }

                SpeakingManager.EnabledDoNotDisturb();
            }
        }

        public static void StopDND()
        {
            lock (DNDSubtractionTimer)
            {
                DNDSubtractionTimer.Stop();
                QuickSettings.Instance.DisableAlertProcessing = false;
                QuickSettings.Instance.PauseDataProcessing = false;
                Console.WriteLine($"[Do Not Disturb] DND stopped.");
                NotificationWorker.Notify.ShowNotification("You can now receive alerts.", "DND has been disabled", ToolTipIcon.Info);
                SpeakingManager.DisabledDoNotDisturb();
            }
        }

        private static void DNDSubtractionTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            StopDND();
        }
    }
}
