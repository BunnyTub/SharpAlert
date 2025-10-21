using SharpAlert.ProgramWorker;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Windows.Media.Protection.PlayReady;

namespace SharpAlert.SourceCapturing.SystemSpecific
{
    public partial class IDAPNoticeForm : Form
    {
        public IDAPNoticeForm()
        {
            InitializeComponent();
        }

        private void UnderstandButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Brazil (IDAP) has been hidden from view in Region Settings, and has been disabled. You won't see this message again.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void TestConnection_Tick(object sender, EventArgs e)
        {
            TestConnection.Stop();
            try
            {
                Console.WriteLine($"[IDAP Notice Window] Getting data from IDAP. URL -> {IDAPFeedCapture.serverPath}");
                HttpResponseMessage message = HaidaWorker.client.GetAsync($"https://{IDAPFeedCapture.serverPath}").Result;
                message.EnsureSuccessStatusCode();
                label2.Text = "You should be able to receive alerts without issue.";
                label2.BackColor = Color.Green;
                message.Dispose();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[IDAP Notice Window] {ex.GetBaseException().Message}");
                label2.Text = "You may not be able to receive alerts right now.";
                label2.BackColor = Color.DarkRed;
            }
        }
    }
}
