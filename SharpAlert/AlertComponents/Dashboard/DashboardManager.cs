using System;
using static SharpAlert.AlertComponents.AlertProcessor;

namespace SharpAlert.AlertComponents.Dashboard
{
    public static class DashboardManager
    {
        //private static List<AlertInfo> AlertList = [];

        public static event EventHandler NewProcessedAlert;

        public static void AddNewAlertToDashboard(AlertInfo info)
        {
            try
            {
                NewProcessedAlert?.Invoke(info, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Dashboard Manager] {ex.Message}");
            }
            //AlertList.Add(info);
        }
    }
}
