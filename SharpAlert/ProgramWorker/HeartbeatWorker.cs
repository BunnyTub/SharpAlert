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
                if (!string.IsNullOrWhiteSpace(QuickSettings.Instance.DiscordWebhook))
                {
                    DiscordWebhook.SendUnformattedMessage("My heartbeat has begun.");
                }
            }
            catch (Exception)
            {
            }

            int WarningCount = 0;

            while (true)
            {
                try
                {
                    int LastAlertCount = AlertProcessor.AlertsRelayed;

                    // wait
                    Thread.Sleep(TimeSpan.FromHours(2));

                    if (LastAlertCount == AlertProcessor.AlertsRelayed)
                    {
                        // if there haven't been any relayed alerts, send heartbeat message
                        WarningCount++;
                        if (WarningCount > 12)
                        {
                            DiscordWebhook.SendUnformattedMessage($"There hasn't been any alerts queued recently. (uptime: {(int)(DateTime.UtcNow - MainEntryPoint.startDT).TotalHours}h)");
                            WarningCount = 0;
                        }
                        else
                        {
                            DiscordWebhook.SendUnformattedMessage($"My heart is still beating. (uptime: {(int)(DateTime.UtcNow - MainEntryPoint.startDT).TotalHours}h)");
                        }
                        // idk
                    }
                    else
                    {
                        WarningCount = 0;
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
