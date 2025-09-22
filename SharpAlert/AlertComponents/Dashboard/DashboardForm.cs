using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SharpAlert.AlertComponents.AlertProcessor;

namespace SharpAlert.AlertComponents.Dashboard
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            InitializeComponent();
            DashboardManager.NewProcessedAlert += DashboardManager_NewProcessedAlert;
        }

        private void DashboardManager_NewProcessedAlert(object sender, EventArgs e)
        {
            if (sender is AlertInfo info)
            {
                //AlertSource = "SASMEX",
                //AlertURL = "https://google.com",
                //AlertID = "ABCD123456-ABCDABCDABCDABCD",
                //AlertIntroText = "1. EARTHQUAKE. For the following, Bayamon Municipio, Puerto Rico; Catano Municipio, Puerto Rico; Guaynabo Municipio, Puerto Rico; San Juan Municipio, Puerto Rico; Trujillo Alto Municipio, Puerto Rico. This alert begins 01:43 PM EST, September 22, 2025, and ends at 03:45 PM EST, September 22, 2025. Issued by NWS San Juan PR. Sourced from FEMA IPAWS (WEA). \r\n\r\n2. Flash Flood Warning. For the following, Bayamon Municipio, Puerto Rico; Catano Municipio, Puerto Rico; Guaynabo Municipio, Puerto Rico; San Juan Municipio, Puerto Rico; Trujillo Alto Municipio, Puerto Rico. This alert begins 01:43 PM EST, September 22, 2025, and ends at 03:45 PM EST, September 22, 2025. Issued by NWS San Juan PR. Sourced from FEMA IPAWS (WEA).",
                //AlertBodyText = "1. NWS: EARTHQUAKE WARNING this area til 3:12:45 AM AST. Avoid flooded areas. National Weather Service: A FLASH FLOOD WARNING is in effect for this area until 3:12:45 AM AST. This is a dangerous and life-threatening situation. Do not attempt to travel unless you are fleeing an area subject to flooding or under an evacuation order.\r\n\r\n2. SNM: AVISO DE INUNDACIONES REPENTINAS hasta 3:12:45 AM AST. Evite areas inundadas. Servicio Nacional de Meteorologia: AVISO DE INUNDACIONES REPENTINAS en efecto para esta area hasta las 3:12:45 AM AST. Esta es una situacion peligrosa y amenaza la vida. No intente viajar a menos que sea para abandonar un area propensa a inundaciones o bajo una orden de desalojo.",
                //AlertMessageType = "update",
                //AlertSeverity = "minor",
                //AlertSentDate = $"{DateTime.UtcNow:s}",
                //AlertExpiryDate = $"{DateTime.UtcNow.AddSeconds(15):s}",
                //AlertFriendlyLocations =
                //[
                //    "Bayamon Municipio, Puerto Rico;",
                //    "Catano Municipio, Puerto Rico;",
                //    "Guaynabo Municipio, Puerto Rico;",
                //    "San Juan Municipio, Puerto Rico;",
                //    "Trujillo Alto Municipio, Puerto Rico"
                //],
                //AlertAudioURL = "https://bunnytub.com/media/AMERICA.mp3",
                //AlertImageURL = "https://bunnytub.com/media/uranium.png"

            }
        }
    }
}
