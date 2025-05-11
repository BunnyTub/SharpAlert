using SharpAlert.Properties;
using System;
using System.Diagnostics;
using System.Threading;

namespace SharpAlert
{
    public static class HeartbeatWorker
    {
        public static void ServiceRun()
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhook))
                {
                    DiscordWebhook.SendUnformattedMessage("My heartbeat has begun.");
                }
            }
            catch (Exception)
            {
            }

            int LastAlertCount = AlertProcessor.AlertsRelayed;
            int WarningCount = 0;

            while (true)
            {
                try
                {
                    Thread.Sleep(TimeSpan.FromHours(2));
                    if (LastAlertCount != AlertProcessor.AlertsRelayed)
                    {
                        LastAlertCount = AlertProcessor.AlertsRelayed;
                        WarningCount = 0;
                        DiscordWebhook.SendUnformattedMessage($"My heart is still beating. (uptime: {(int)(DateTime.UtcNow - MainEntryPoint.startDT).TotalHours}h)");
                    }
                    else
                    {
                        WarningCount++;
                        if (WarningCount > 12)
                        {
                            DiscordWebhook.SendUnformattedMessage($"There hasn't been an alert queued within the past 24+ hours. (uptime: {(int)(DateTime.UtcNow - MainEntryPoint.startDT).TotalHours}h)");
                            WarningCount = 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    IceBearWorker.LogFault(ex);
                }
            }
        }
    }
}
