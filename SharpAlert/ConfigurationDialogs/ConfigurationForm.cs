using SharpAlert.AlertComponents;
using SharpAlert.Languages;
using SharpAlert.ProgramWorker;
using SharpAlert.Properties;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static SharpAlert.ProgramWorker.HaidaWorker;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();
            Language.ApplyFont(this);

            Text = $"SharpAlert - {Language.Get("WindowTitle_GlobalSettings", "Global Settings")}";
            CAPSettingsButton.Text = Language.Get("SettingsButton_AlertSettings", "Alert Settings");
            RegionSettingsButton.Text = Language.Get("SettingsButton_RegionSettings", "Region Settings");
            StyleSettingsButton.Text = Language.Get("SettingsButton_StylesAndMore", "Styles &\r\nMore");
            DiscordSettingsButton.Text = Language.Get("SettingsButton_DiscordAndWebhooks", "Discord &\r\nWebhooks");
            SoundSettingsButton.Text = Language.Get("SettingsButton_SoundsAndEffects", "Sounds &\r\nEffects");
            ExtraOptionsButton.Text = Language.Get("SettingsButton_ExtraOptions", "Extra\r\nOptions");
            EnableUpdatesBox.Text = Language.Get("SettingsButton_EnableAutoUpdates", "Enable Automatic Updates");
            ServerSettingsButton.Text = Language.Get("SettingsButton_ServerSettings", "Server Settings");
            SimpleModeButton.Text = Language.Get("SettingsButton_SimpleMode", "Simple Mode");
            ProgramCreditsButton.Text = Language.Get("SettingsButton_AboutButton", "About SharpAlert");
            DoneButton.Text = Language.Get("SettingsButton_CloseButton", "Close");
        }

        private void ManagementForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //e.Cancel = true;
            QuickSettings.Instance.Save();
            acf?.Close();
            csf?.Close();
            caf?.Close();
            crf?.Close();
            scf?.Close();
            dcf?.Close();
            ecf?.Close();
            cf?.Close();
            //this.Hide();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private AlertConfigurationForm acf = null;

        private void CAPSettingsButton_Click(object sender, EventArgs e)
        {
            if (acf == null || acf.IsDisposed) acf = new AlertConfigurationForm();
            acf.Show();
            acf.Activate();
        }

        private StyleConfigurationForm csf = null;

        private void StyleSettingsButton_Click(object sender, EventArgs e)
        {
            if (csf == null || csf.IsDisposed) csf = new StyleConfigurationForm(false);
            csf.Show();
            csf.Activate();
        }

        private ChooseAudioForm caf = null;

        private void SoundSettingsButton_Click(object sender, EventArgs e)
        {
            string OldTitle = this.Text;
            this.Text = $"{OldTitle} ({Language.Get("PleaseWait", "Please wait a moment")})";
            // added this stuff because the window freezes while waiting for the audio form to load
            if (caf == null || caf.IsDisposed) caf = new ChooseAudioForm(false);
            caf.Show();
            caf.Activate();
            this.Text = OldTitle;
        }

        private ChooseRegionForm crf = null;

        private void RegionButton_Click(object sender, EventArgs e)
        {
            if (crf == null || crf.IsDisposed) crf = new ChooseRegionForm(false);
            crf.Show();
            crf.Activate();
        }

        private ServerConfigurationForm scf = null;

        private void ServerSettingsButton_Click(object sender, EventArgs e)
        {
            if (scf == null || scf.IsDisposed) scf = new ServerConfigurationForm();
            scf.Show();
            scf.Activate();
        }

        private DiscordConfigurationForm dcf = null;

        private void DiscordSettingsButton_Click(object sender, EventArgs e)
        {
            if (dcf == null || dcf.IsDisposed) dcf = new DiscordConfigurationForm();
            dcf.Show();
            dcf.Activate();
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

            DialogResult resultX = MessageBox.Show("Start migration from v8.x (or older) settings store?\r\n\r\n" +
                "The program will immediately close after the migration is complete, and all of your current new settings will be overwritten by your old program settings.",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultX == DialogResult.Yes)
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
                    Exception exception = new($"Migration from old settings to new settings failed.\r\n{ex.Message}\r\n{ex.StackTrace}");
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
            SpeakingManager.SettingsSaved();

            MessageBox.Show("Settings manually saved.\r\nYour settings are already saved when you click \"Close\".",
                "SharpAlert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private CreditsForm cf = null;

        private void ProgramCreditsButton_Click(object sender, EventArgs e)
        {
            if (cf == null || cf.IsDisposed) cf = new CreditsForm();
            cf.Show();
            cf.Activate();
        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            EnableUpdatesBox.Checked = QuickSettings.Instance.AllowPerformingUpdates;
            AllowNotifications = true;
            //ProhibitUsers_Tick(this, EventArgs.Empty);
            //if (IsUserLocked)
            //{
            //    MessageBox.Show("Your access to some features (such as webhooks) that require connectivity have been restricted due to inappropriate behavior. This restriction is likely related to an infringement that was given to an associated account on this device.",
            //        Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private bool AllowNotifications = false;

        private void EnableUpdatesBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!AllowNotifications) return;

            if (EnableUpdatesBox.Checked)
            {
                MessageBox.Show("SharpAlert will try to update on the fly, as long as you have administrative permissions on this device.",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("SharpAlert will no longer automatically update.",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            QuickSettings.Instance.AskedForAutomaticUpdates = true;
            QuickSettings.Instance.AllowPerformingUpdates = EnableUpdatesBox.Checked;
        }

        //private SecretConfigurationForm secret = null;

        private void SecretSettingsButton_Click(object sender, EventArgs e)
        {
            //if (MainEntryPoint.IsUserSuperSecretAccessor())
            //{
            //    if (secret == null || secret.IsDisposed) secret = new SecretConfigurationForm();
            //    secret.Show();
            //    secret.Activate();
            //}
            //else
            {
                //Console.Beep(300, 200);
                MessageBox.Show("There are no experiments available.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //private bool IsUserLocked = false;

        private void ProhibitUsers_Tick(object sender, EventArgs e)
        {
            //if (MainEntryPoint.IsUserLocked())
            //{
            //    IsUserLocked = true;
            //    DiscordSettingsButton.Enabled = false;
            //    try { if (dcf != null && !dcf.IsDisposed) dcf.Close(); } catch (Exception) { }
            //    QuickSettings.Instance.DiscordWebhookFeaturesLocked = true;
            //}
            //else
            //{
            //    IsUserLocked = false;
            //    DiscordSettingsButton.Enabled = true;
            //    QuickSettings.Instance.DiscordWebhookFeaturesLocked = false;
            //}
        }

        public bool Swap = false;

        private void SimpleModeButton_Click(object sender, EventArgs e)
        {
            QuickSettings.Instance.UseAdvancedView = false;
            Swap = true;
            this.Close();
        }

        private void Reloader_Tick(object sender, EventArgs e)
        {
            SlidesBox.LoadAsync("https://bunnytub.com/SharpAlert-Slides/Announcement.png");
        }

        private void SlidesBox_Click(object sender, EventArgs e)
        {
            try
            {
                HackyWorkarounds.OpenURL(Client.GetStringAsync("https://bunnytub.com/SharpAlert-Slides/Announcement.txt").Result);
            }
            catch (Exception)
            {
            }
        }

        private ExtraConfigurationForm ecf = null;

        private void ExtraOptionsButton_Click(object sender, EventArgs e)
        {
            if (ecf == null || ecf.IsDisposed) ecf = new ExtraConfigurationForm(false);
            ecf.Show();
            ecf.Activate();
        }

        private bool UpDown = true;

        private void WindowShake_Tick(object sender, EventArgs e)
        {
            if (AprilFools.IsAprilFoolsNow)
            {
                if (UpDown)
                {
                    Location = new Point(Location.X, Location.Y + 10);
                }
                else
                {
                    Location = new Point(Location.X, Location.Y - 10);
                }

                UpDown = !UpDown;
            }
        }
    }
}