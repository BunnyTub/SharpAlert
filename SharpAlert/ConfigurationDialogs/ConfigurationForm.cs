using System;
using System.Linq;
using System.Windows.Forms;
using SharpAlert.Properties;
using static SharpAlert.IceBearWorker;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
        }

        private void ManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            QuickSettings.Instance.Save();
            this.Hide();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private AlertConfigurationForm acf = null;

        private void CAPSettingsButton_Click(object sender, EventArgs e)
        {
            if (acf == null || acf.IsDisposed) acf = new AlertConfigurationForm();
            acf.ShowDialog();
        }

        private ChooseStyleForm csf = null;

        private void StyleSettingsButton_Click(object sender, EventArgs e)
        {
            if (csf == null || csf.IsDisposed) csf = new ChooseStyleForm(false);
            csf.ShowDialog();
        }

        private ChooseAudioForm caf = null;

        private void SoundSettingsButton_Click(object sender, EventArgs e)
        {
            if (caf == null || caf.IsDisposed) caf = new ChooseAudioForm(false);
            caf.ShowDialog();
        }


        private ChooseRegionForm crf = null;

        private void RegionButton_Click(object sender, EventArgs e)
        {
            if (crf == null || crf.IsDisposed) crf = new ChooseRegionForm(false);
            crf.ShowDialog();
            MessageBox.Show("Restart the program to apply region changes.",
                "SharpAlert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private ServerConfigurationForm scf = null;

        private void ServerSettingsButton_Click(object sender, EventArgs e)
        {
            if (scf == null || scf.IsDisposed) scf = new ServerConfigurationForm();
            scf.ShowDialog();
        }

        private DiscordConfigurationForm dcf = null;

        private void DiscordSettingsButton_Click(object sender, EventArgs e)
        {
            if (dcf == null || dcf.IsDisposed) dcf = new DiscordConfigurationForm();
            dcf.ShowDialog();
        }

        private void MigrateSettingsButton_Click(object sender, EventArgs e)
        {
            if ((ModifierKeys & Keys.Shift) != Keys.Shift)
            {
                if (QuickSettings.Instance.MigrationOccurred)
                {
                    MessageBox.Show("You have already migrated your settings.\r\n" +
                        "Hold SHIFT while clicking the button to migrate anyway.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    return;
                }
            }

            DialogResult result = MessageBox.Show("Start migration from old settings?\r\n" +
                "The program will immediately close after it's successful, and all of your current new settings will be overwritten by your old settings.",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    var old = Settings.Default;
                    var sharp = QuickSettings.Instance;

                    var oldProps = old.GetType().GetProperties();
                    var newProps = typeof(QuickSettings).GetProperties();

                    foreach (var oldProp in oldProps)
                    {
                        var newProp = newProps.FirstOrDefault(p => p.Name == oldProp.Name &&
                                                                   p.PropertyType == oldProp.PropertyType);
                        if (newProp != null && newProp.CanWrite)
                        {
                            var value = oldProp.GetValue(old);
                            newProp.SetValue(sharp, value);
                        }
                    }

                    sharp.MigrationOccurred = true;
                    sharp.Save();
                    Environment.Exit(0);
                }
                catch (Exception ex)
                {
                    Exception exception = new Exception($"Migration from old settings to new settings failed.\r\n{ex.Message}");
                    UnsafeFault(exception, true);
                    //MessageBox.Show($"Migration has failed. {ex.Message}",
                    //    "SharpAlert",
                    //    MessageBoxButtons.OK,
                    //    MessageBoxIcon.Error);
                }
            }
        }

        private void SaveSettingsButton_Click(object sender, EventArgs e)
        {
            QuickSettings.Instance.Save();
        }

        private void ProgramCreditsButton_Click(object sender, EventArgs e)
        {
            new CreditsForm().ShowDialog();
        }
    }
}
