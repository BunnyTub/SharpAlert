using SharpAlert.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpAlert
{
    public partial class AltTrayForm : Form
    {
        public AltTrayForm()
        {
            InitializeComponent();
        }

        private void AltTrayForm_Load(object sender, EventArgs e)
        {
            label1.Text = $"SharpAlert v{VersionInfo.MajorVersion}.{VersionInfo.MinorVersion}";
        }

        private void ConsoleButton_Click(object sender, EventArgs e)
        {
            IceBearWorker.AllocateTerminal();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            IceBearWorker.AddFileToQueue();
        }

        private void OpenSettingsButton_Click(object sender, EventArgs e)
        {
            ConfigurationForm cf = new ConfigurationForm();
            cf.ShowDialog();
            cf.Dispose();
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
