using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SharpAlert.AlertComponents.AlertProcessor;

namespace SharpAlert.AlertComponents.Dashboard
{
    public static class DashboardManager
    {
        //private static List<AlertInfo> AlertList = [];

        public static event EventHandler NewProcessedAlert;

        public static void AddNewAlertToDashboard(AlertInfo info)
        {
            //AlertList.Add(info);
            NewProcessedAlert?.Invoke(info, EventArgs.Empty);
        }
    }
}
