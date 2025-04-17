using SharpAlert.Properties;
using System;
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
            while (true)
            {
                try
                {
                    Thread.Sleep(TimeSpan.FromHours(1));
                    if (!string.IsNullOrWhiteSpace(Settings.Default.DiscordWebhook))
                    {
                        DiscordWebhook.SendUnformattedMessage($"My heart is still beating. ({(DateTime.UtcNow - MainEntryPoint.startDT).TotalHours})");
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
