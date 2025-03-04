using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpAlert.DisplayDialogs.Panels
{
    public partial class AlertInfoHolder : UserControl
    {
        public string AlertIdentifier = string.Empty;
        public string AlertSubtitleStr = string.Empty;
        public string AlertTextStr = string.Empty;
        public string AlertUrlStr = string.Empty;
        public string AlertAudioUrlStr = string.Empty;
        public string AlertImageUrlStr = string.Empty;
        public string AlertType = string.Empty;

        public AlertInfoHolder()
        {
            InitializeComponent();
        }

        private void AlertInfoHolder_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AlertIdentifier)) throw new Exception("An alert identifier cannot be null, empty, or whitespace.");
        }

        public void UpdateFields(string subtitle, string text, string url, string audio, string image, string type)
        {
            label1.Text = $"{FirstCharToUpper(type)} Emergency Alert";
        }

        public static string FirstCharToUpper(string input)
        {
            if (String.IsNullOrEmpty(input))
                throw new ArgumentException("ARGH!");
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }
    }
}
