namespace SharpAlert
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            this.BusyLock = new System.Windows.Forms.Timer(this.components);
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.DiscordWebhookURLInput = new System.Windows.Forms.TextBox();
            this.DiscordWebhookAppendInput = new System.Windows.Forms.TextBox();
            this.NS_UnhideSecureBox = new System.Windows.Forms.CheckBox();
            this.SaveDiscordSettingsButton = new System.Windows.Forms.Button();
            this.AlertHistoryClearButton = new System.Windows.Forms.Button();
            this.AlertHistoryRefreshButton = new System.Windows.Forms.Button();
            this.AlertHistoryReplayRecentButton = new System.Windows.Forms.Button();
            this.AlertHistoryDumpLink = new System.Windows.Forms.LinkLabel();
            this.OpenCreditsButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.CacheOperationButton = new System.Windows.Forms.Button();
            this.BusyLockText = new System.Windows.Forms.Label();
            this.statusWindowBox = new System.Windows.Forms.CheckBox();
            this.TTSButton = new System.Windows.Forms.Button();
            this.AlertButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.AlertHistoryOutput = new System.Windows.Forms.TextBox();
            this.alertNoRelayBox = new System.Windows.Forms.CheckBox();
            this.alertPlayEndToneBox = new System.Windows.Forms.CheckBox();
            this.PlayTestButton = new System.Windows.Forms.Button();
            this.ImportFileButton = new System.Windows.Forms.Button();
            this.DiscordWebhookConfirmAlertsBox = new System.Windows.Forms.CheckBox();
            this.RegionButton = new System.Windows.Forms.Button();
            this.StyleButton = new System.Windows.Forms.Button();
            this.DiscordWebhookRelayLocallyBox = new System.Windows.Forms.CheckBox();
            this.AudioDeviceCombo = new System.Windows.Forms.ComboBox();
            this.RefreshOutputsButton = new System.Windows.Forms.Button();
            this.DisableDialogsBox = new System.Windows.Forms.CheckBox();
            this.DiscordWebhookGroup = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AlertAppearanceAndSoundsGroup = new System.Windows.Forms.GroupBox();
            this.AudioOutputLabel = new System.Windows.Forms.Label();
            this.GlobalVolumeLabel = new System.Windows.Forms.Label();
            this.PastAlertsGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            this.AlertListRefresher = new System.Windows.Forms.Timer(this.components);
            this.AudioDeviceMessage = new System.Windows.Forms.Timer(this.components);
            this.AppliedLink = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.DiscordWebhookGroup.SuspendLayout();
            this.AlertAppearanceAndSoundsGroup.SuspendLayout();
            this.PastAlertsGroup.SuspendLayout();
            this.ConfigurationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BusyLock
            // 
            this.BusyLock.Tick += new System.EventHandler(this.BusyLock_Tick);
            // 
            // ToolTipInformation
            // 
            this.ToolTipInformation.AutomaticDelay = 250;
            this.ToolTipInformation.AutoPopDelay = 15000;
            this.ToolTipInformation.BackColor = System.Drawing.Color.White;
            this.ToolTipInformation.ForeColor = System.Drawing.Color.Black;
            this.ToolTipInformation.InitialDelay = 250;
            this.ToolTipInformation.IsBalloon = true;
            this.ToolTipInformation.ReshowDelay = 50;
            this.ToolTipInformation.ToolTipTitle = "What does this do?";
            // 
            // DiscordWebhookURLInput
            // 
            this.DiscordWebhookURLInput.BackColor = System.Drawing.Color.Black;
            this.DiscordWebhookURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DiscordWebhookURLInput.ForeColor = System.Drawing.Color.White;
            this.DiscordWebhookURLInput.Location = new System.Drawing.Point(6, 60);
            this.DiscordWebhookURLInput.Name = "DiscordWebhookURLInput";
            this.DiscordWebhookURLInput.Size = new System.Drawing.Size(170, 21);
            this.DiscordWebhookURLInput.TabIndex = 2;
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookURLInput, "The Discord webhook URL to send data to.");
            this.DiscordWebhookURLInput.UseSystemPasswordChar = true;
            this.DiscordWebhookURLInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DiscordWebhookURLInput_KeyDown);
            // 
            // DiscordWebhookAppendInput
            // 
            this.DiscordWebhookAppendInput.BackColor = System.Drawing.Color.Black;
            this.DiscordWebhookAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DiscordWebhookAppendInput.ForeColor = System.Drawing.Color.White;
            this.DiscordWebhookAppendInput.Location = new System.Drawing.Point(182, 60);
            this.DiscordWebhookAppendInput.Name = "DiscordWebhookAppendInput";
            this.DiscordWebhookAppendInput.Size = new System.Drawing.Size(170, 21);
            this.DiscordWebhookAppendInput.TabIndex = 3;
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookAppendInput, "The message to be appended after all data of an alert is sent successfully.");
            this.DiscordWebhookAppendInput.UseSystemPasswordChar = true;
            this.DiscordWebhookAppendInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DiscordWebhookAppendInput_KeyDown);
            // 
            // NS_UnhideSecureBox
            // 
            this.NS_UnhideSecureBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.NS_UnhideSecureBox.AutoSize = true;
            this.NS_UnhideSecureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.NS_UnhideSecureBox.Checked = true;
            this.NS_UnhideSecureBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NS_UnhideSecureBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NS_UnhideSecureBox.Location = new System.Drawing.Point(358, 56);
            this.NS_UnhideSecureBox.Name = "NS_UnhideSecureBox";
            this.NS_UnhideSecureBox.Size = new System.Drawing.Size(43, 25);
            this.NS_UnhideSecureBox.TabIndex = 4;
            this.NS_UnhideSecureBox.Text = "Hide";
            this.ToolTipInformation.SetToolTip(this.NS_UnhideSecureBox, "Hides possibly sensitive information.");
            this.NS_UnhideSecureBox.UseVisualStyleBackColor = false;
            this.NS_UnhideSecureBox.CheckedChanged += new System.EventHandler(this.NS_UnhideSecureBox_CheckedChanged);
            // 
            // SaveDiscordSettingsButton
            // 
            this.SaveDiscordSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SaveDiscordSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveDiscordSettingsButton.Location = new System.Drawing.Point(407, 56);
            this.SaveDiscordSettingsButton.Name = "SaveDiscordSettingsButton";
            this.SaveDiscordSettingsButton.Size = new System.Drawing.Size(120, 25);
            this.SaveDiscordSettingsButton.TabIndex = 1;
            this.SaveDiscordSettingsButton.Text = "Modfiy Webhook";
            this.ToolTipInformation.SetToolTip(this.SaveDiscordSettingsButton, "Saves the webhook and message data.\r\nIf this button is red, click it to save chan" +
        "ges.");
            this.SaveDiscordSettingsButton.UseVisualStyleBackColor = false;
            this.SaveDiscordSettingsButton.Click += new System.EventHandler(this.SaveDiscordSettingsButton_Click);
            // 
            // AlertHistoryClearButton
            // 
            this.AlertHistoryClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AlertHistoryClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AlertHistoryClearButton.Location = new System.Drawing.Point(569, 49);
            this.AlertHistoryClearButton.Name = "AlertHistoryClearButton";
            this.AlertHistoryClearButton.Size = new System.Drawing.Size(72, 52);
            this.AlertHistoryClearButton.TabIndex = 19;
            this.AlertHistoryClearButton.Text = "Clear\r\nHistory";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryClearButton, "Clears the history list.");
            this.AlertHistoryClearButton.UseVisualStyleBackColor = false;
            this.AlertHistoryClearButton.Click += new System.EventHandler(this.AlertHistoryClearButton_Click);
            // 
            // AlertHistoryRefreshButton
            // 
            this.AlertHistoryRefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AlertHistoryRefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AlertHistoryRefreshButton.Location = new System.Drawing.Point(569, 49);
            this.AlertHistoryRefreshButton.Name = "AlertHistoryRefreshButton";
            this.AlertHistoryRefreshButton.Size = new System.Drawing.Size(72, 23);
            this.AlertHistoryRefreshButton.TabIndex = 18;
            this.AlertHistoryRefreshButton.Text = "Refresh";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryRefreshButton, "Refreshes the history list.\r\nRefreshing happens automatically every second, so th" +
        "is button may be removed in the future.");
            this.AlertHistoryRefreshButton.UseVisualStyleBackColor = false;
            this.AlertHistoryRefreshButton.Visible = false;
            this.AlertHistoryRefreshButton.Click += new System.EventHandler(this.AlertHistoryRefreshButton_Click);
            // 
            // AlertHistoryReplayRecentButton
            // 
            this.AlertHistoryReplayRecentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AlertHistoryReplayRecentButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AlertHistoryReplayRecentButton.Location = new System.Drawing.Point(491, 20);
            this.AlertHistoryReplayRecentButton.Name = "AlertHistoryReplayRecentButton";
            this.AlertHistoryReplayRecentButton.Size = new System.Drawing.Size(72, 23);
            this.AlertHistoryReplayRecentButton.TabIndex = 20;
            this.AlertHistoryReplayRecentButton.Text = "Replay";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryReplayRecentButton, "Immediately re-adds the most recent alert back into the queue after wiping it fro" +
        "m the history.");
            this.AlertHistoryReplayRecentButton.UseVisualStyleBackColor = false;
            this.AlertHistoryReplayRecentButton.Click += new System.EventHandler(this.AlertHistoryReplayRecentButton_Click);
            // 
            // AlertHistoryDumpLink
            // 
            this.AlertHistoryDumpLink.AutoSize = true;
            this.AlertHistoryDumpLink.LinkColor = System.Drawing.Color.Yellow;
            this.AlertHistoryDumpLink.Location = new System.Drawing.Point(378, 17);
            this.AlertHistoryDumpLink.Name = "AlertHistoryDumpLink";
            this.AlertHistoryDumpLink.Size = new System.Drawing.Size(107, 15);
            this.AlertHistoryDumpLink.TabIndex = 16;
            this.AlertHistoryDumpLink.TabStop = true;
            this.AlertHistoryDumpLink.Text = "Dump alert history";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryDumpLink, "Dumps the alert history to a folder named \"dump\", then opens the folder in File E" +
        "xplorer.");
            this.AlertHistoryDumpLink.VisitedLinkColor = System.Drawing.Color.Cyan;
            this.AlertHistoryDumpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AlertHistoryDumpLink_LinkClicked);
            // 
            // OpenCreditsButton
            // 
            this.OpenCreditsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.OpenCreditsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OpenCreditsButton.Location = new System.Drawing.Point(12, 351);
            this.OpenCreditsButton.Name = "OpenCreditsButton";
            this.OpenCreditsButton.Size = new System.Drawing.Size(61, 23);
            this.OpenCreditsButton.TabIndex = 20;
            this.OpenCreditsButton.Text = "Credits";
            this.ToolTipInformation.SetToolTip(this.OpenCreditsButton, "Ice Bear definitely helped here :3 (This is a dialog, not a link)");
            this.OpenCreditsButton.UseVisualStyleBackColor = false;
            this.OpenCreditsButton.Click += new System.EventHandler(this.OpenCreditsButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 355);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(246, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "BunnyTub © 2024-2025 | All rights reserved.";
            this.ToolTipInformation.SetToolTip(this.label10, "The copyright text. Because left is not right. :\')");
            // 
            // CacheOperationButton
            // 
            this.CacheOperationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CacheOperationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CacheOperationButton.Location = new System.Drawing.Point(459, 351);
            this.CacheOperationButton.Name = "CacheOperationButton";
            this.CacheOperationButton.Size = new System.Drawing.Size(94, 23);
            this.CacheOperationButton.TabIndex = 22;
            this.CacheOperationButton.Text = "Reset Cache";
            this.ToolTipInformation.SetToolTip(this.CacheOperationButton, "Re-caches information from the internet.");
            this.CacheOperationButton.UseMnemonic = false;
            this.CacheOperationButton.UseVisualStyleBackColor = false;
            this.CacheOperationButton.Click += new System.EventHandler(this.CacheOperationButton_Click);
            // 
            // BusyLockText
            // 
            this.BusyLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BusyLockText.Font = new System.Drawing.Font("Arial", 12F);
            this.BusyLockText.Location = new System.Drawing.Point(0, 0);
            this.BusyLockText.Name = "BusyLockText";
            this.BusyLockText.Size = new System.Drawing.Size(671, 405);
            this.BusyLockText.TabIndex = 14;
            this.BusyLockText.Text = "Please wait or dismiss all alerts to configure settings.";
            this.BusyLockText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.BusyLockText, "You\'ll need to wait for all alerts to finish before continuing.");
            // 
            // statusWindowBox
            // 
            this.statusWindowBox.AutoSize = true;
            this.statusWindowBox.Location = new System.Drawing.Point(345, 354);
            this.statusWindowBox.Name = "statusWindowBox";
            this.statusWindowBox.Size = new System.Drawing.Size(106, 19);
            this.statusWindowBox.TabIndex = 21;
            this.statusWindowBox.Text = "Status window";
            this.ToolTipInformation.SetToolTip(this.statusWindowBox, "Shows the status window.");
            this.statusWindowBox.UseVisualStyleBackColor = true;
            // 
            // TTSButton
            // 
            this.TTSButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.TTSButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TTSButton.Location = new System.Drawing.Point(559, 351);
            this.TTSButton.Name = "TTSButton";
            this.TTSButton.Size = new System.Drawing.Size(100, 23);
            this.TTSButton.TabIndex = 23;
            this.TTSButton.Text = "TTS Settings";
            this.ToolTipInformation.SetToolTip(this.TTSButton, "Opens the TTS configuration window.");
            this.TTSButton.UseMnemonic = false;
            this.TTSButton.UseVisualStyleBackColor = false;
            this.TTSButton.Click += new System.EventHandler(this.TTSButton_Click);
            // 
            // AlertButton
            // 
            this.AlertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AlertButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AlertButton.Location = new System.Drawing.Point(534, 12);
            this.AlertButton.Name = "AlertButton";
            this.AlertButton.Size = new System.Drawing.Size(125, 23);
            this.AlertButton.TabIndex = 0;
            this.AlertButton.Text = "Message Settings";
            this.ToolTipInformation.SetToolTip(this.AlertButton, "Opens the alert configuration window.");
            this.AlertButton.UseMnemonic = false;
            this.AlertButton.UseVisualStyleBackColor = false;
            this.AlertButton.Click += new System.EventHandler(this.AlertButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 381);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(616, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "This piece of software is not sold in any shape or form. It is provided for free," +
    " \"as is\", by the original developer(s).";
            this.ToolTipInformation.SetToolTip(this.label3, "Can\'t be too careful.");
            // 
            // volumeBar
            // 
            this.volumeBar.LargeChange = 1;
            this.volumeBar.Location = new System.Drawing.Point(60, 49);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(320, 45);
            this.volumeBar.TabIndex = 14;
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ToolTipInformation.SetToolTip(this.volumeBar, "Controls the global volume of the application.");
            // 
            // AlertHistoryOutput
            // 
            this.AlertHistoryOutput.BackColor = System.Drawing.Color.Black;
            this.AlertHistoryOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlertHistoryOutput.Font = new System.Drawing.Font("Arial", 12F);
            this.AlertHistoryOutput.ForeColor = System.Drawing.Color.White;
            this.AlertHistoryOutput.Location = new System.Drawing.Point(6, 35);
            this.AlertHistoryOutput.Multiline = true;
            this.AlertHistoryOutput.Name = "AlertHistoryOutput";
            this.AlertHistoryOutput.ReadOnly = true;
            this.AlertHistoryOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AlertHistoryOutput.Size = new System.Drawing.Size(479, 66);
            this.AlertHistoryOutput.TabIndex = 15;
            this.ToolTipInformation.SetToolTip(this.AlertHistoryOutput, "This area shows the identifiers of each alert. If an identifier couldn\'t be found" +
        ", the identifier will be an MD5 value based on the alert\'s raw data.");
            this.AlertHistoryOutput.WordWrap = false;
            // 
            // alertNoRelayBox
            // 
            this.alertNoRelayBox.AutoSize = true;
            this.alertNoRelayBox.Location = new System.Drawing.Point(396, 20);
            this.alertNoRelayBox.Name = "alertNoRelayBox";
            this.alertNoRelayBox.Size = new System.Drawing.Size(126, 19);
            this.alertNoRelayBox.TabIndex = 25;
            this.alertNoRelayBox.Text = "Disable USB relay";
            this.ToolTipInformation.SetToolTip(this.alertNoRelayBox, "Stops USB relays from being triggered when alerts are being relayed.");
            this.alertNoRelayBox.UseVisualStyleBackColor = true;
            // 
            // alertPlayEndToneBox
            // 
            this.alertPlayEndToneBox.AutoSize = true;
            this.alertPlayEndToneBox.Location = new System.Drawing.Point(290, 20);
            this.alertPlayEndToneBox.Name = "alertPlayEndToneBox";
            this.alertPlayEndToneBox.Size = new System.Drawing.Size(100, 19);
            this.alertPlayEndToneBox.TabIndex = 28;
            this.alertPlayEndToneBox.Text = "Play end tone";
            this.ToolTipInformation.SetToolTip(this.alertPlayEndToneBox, "Plays an auditory tone when an alert is closed.");
            this.alertPlayEndToneBox.UseVisualStyleBackColor = true;
            // 
            // PlayTestButton
            // 
            this.PlayTestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.PlayTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlayTestButton.Font = new System.Drawing.Font("Arial", 9F);
            this.PlayTestButton.ForeColor = System.Drawing.Color.White;
            this.PlayTestButton.Location = new System.Drawing.Point(569, 20);
            this.PlayTestButton.Name = "PlayTestButton";
            this.PlayTestButton.Size = new System.Drawing.Size(72, 23);
            this.PlayTestButton.TabIndex = 17;
            this.PlayTestButton.Text = "New Alert";
            this.ToolTipInformation.SetToolTip(this.PlayTestButton, "Opens the alert editor window.");
            this.PlayTestButton.UseVisualStyleBackColor = false;
            this.PlayTestButton.Click += new System.EventHandler(this.PlayTestButton_Click);
            // 
            // ImportFileButton
            // 
            this.ImportFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ImportFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ImportFileButton.Font = new System.Drawing.Font("Arial", 9F);
            this.ImportFileButton.ForeColor = System.Drawing.Color.White;
            this.ImportFileButton.Location = new System.Drawing.Point(491, 49);
            this.ImportFileButton.Name = "ImportFileButton";
            this.ImportFileButton.Size = new System.Drawing.Size(72, 52);
            this.ImportFileButton.TabIndex = 21;
            this.ImportFileButton.Text = "Add File To Queue";
            this.ToolTipInformation.SetToolTip(this.ImportFileButton, resources.GetString("ImportFileButton.ToolTip"));
            this.ImportFileButton.UseVisualStyleBackColor = false;
            this.ImportFileButton.Click += new System.EventHandler(this.ImportFileButton_Click);
            // 
            // DiscordWebhookConfirmAlertsBox
            // 
            this.DiscordWebhookConfirmAlertsBox.AutoSize = true;
            this.DiscordWebhookConfirmAlertsBox.Location = new System.Drawing.Point(537, 37);
            this.DiscordWebhookConfirmAlertsBox.Name = "DiscordWebhookConfirmAlertsBox";
            this.DiscordWebhookConfirmAlertsBox.Size = new System.Drawing.Size(104, 19);
            this.DiscordWebhookConfirmAlertsBox.TabIndex = 29;
            this.DiscordWebhookConfirmAlertsBox.Text = "Confirm alerts";
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookConfirmAlertsBox, "Shows a window with alert information for a short period of time.\r\nYou can either" +
        " forward the alert by waiting or clicking \"FORWARD\", or discard it by clicking \"" +
        "STOP\".");
            this.DiscordWebhookConfirmAlertsBox.UseVisualStyleBackColor = true;
            // 
            // RegionButton
            // 
            this.RegionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RegionButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.RegionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RegionButton.Location = new System.Drawing.Point(403, 12);
            this.RegionButton.Name = "RegionButton";
            this.RegionButton.Size = new System.Drawing.Size(125, 23);
            this.RegionButton.TabIndex = 30;
            this.RegionButton.Text = "Region Settings";
            this.ToolTipInformation.SetToolTip(this.RegionButton, "Opens the region configuration window.\r\n");
            this.RegionButton.UseMnemonic = false;
            this.RegionButton.UseVisualStyleBackColor = false;
            this.RegionButton.Click += new System.EventHandler(this.RegionButton_Click);
            // 
            // StyleButton
            // 
            this.StyleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.StyleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.StyleButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StyleButton.Location = new System.Drawing.Point(6, 20);
            this.StyleButton.Name = "StyleButton";
            this.StyleButton.Size = new System.Drawing.Size(125, 23);
            this.StyleButton.TabIndex = 31;
            this.StyleButton.Text = "Style Settings";
            this.ToolTipInformation.SetToolTip(this.StyleButton, "Opens the style configuration window.");
            this.StyleButton.UseMnemonic = false;
            this.StyleButton.UseVisualStyleBackColor = false;
            this.StyleButton.Click += new System.EventHandler(this.StyleButton_Click);
            // 
            // DiscordWebhookRelayLocallyBox
            // 
            this.DiscordWebhookRelayLocallyBox.AutoSize = true;
            this.DiscordWebhookRelayLocallyBox.Location = new System.Drawing.Point(537, 62);
            this.DiscordWebhookRelayLocallyBox.Name = "DiscordWebhookRelayLocallyBox";
            this.DiscordWebhookRelayLocallyBox.Size = new System.Drawing.Size(94, 19);
            this.DiscordWebhookRelayLocallyBox.TabIndex = 30;
            this.DiscordWebhookRelayLocallyBox.Text = "Relay locally";
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookRelayLocallyBox, "Relay alerts locally in addition to sending a message.");
            this.DiscordWebhookRelayLocallyBox.UseVisualStyleBackColor = true;
            // 
            // AudioDeviceCombo
            // 
            this.AudioDeviceCombo.BackColor = System.Drawing.Color.Black;
            this.AudioDeviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AudioDeviceCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AudioDeviceCombo.ForeColor = System.Drawing.Color.White;
            this.AudioDeviceCombo.FormattingEnabled = true;
            this.AudioDeviceCombo.Items.AddRange(new object[] {
            "Refresh the outputs..."});
            this.AudioDeviceCombo.Location = new System.Drawing.Point(386, 67);
            this.AudioDeviceCombo.Name = "AudioDeviceCombo";
            this.AudioDeviceCombo.Size = new System.Drawing.Size(226, 23);
            this.AudioDeviceCombo.TabIndex = 37;
            this.ToolTipInformation.SetToolTip(this.AudioDeviceCombo, "Choose the audio output device to use for sounds.");
            this.AudioDeviceCombo.SelectedIndexChanged += new System.EventHandler(this.AudioDeviceCombo_SelectedIndexChanged);
            // 
            // RefreshOutputsButton
            // 
            this.RefreshOutputsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshOutputsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.RefreshOutputsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RefreshOutputsButton.Font = new System.Drawing.Font("Arial", 9F);
            this.RefreshOutputsButton.Location = new System.Drawing.Point(618, 67);
            this.RefreshOutputsButton.Name = "RefreshOutputsButton";
            this.RefreshOutputsButton.Size = new System.Drawing.Size(23, 23);
            this.RefreshOutputsButton.TabIndex = 39;
            this.RefreshOutputsButton.Text = "⭐";
            this.ToolTipInformation.SetToolTip(this.RefreshOutputsButton, "Refreshes the audio output list.");
            this.RefreshOutputsButton.UseMnemonic = false;
            this.RefreshOutputsButton.UseVisualStyleBackColor = false;
            this.RefreshOutputsButton.Click += new System.EventHandler(this.RefreshOutputsButton_Click);
            // 
            // DisableDialogsBox
            // 
            this.DisableDialogsBox.AutoSize = true;
            this.DisableDialogsBox.Location = new System.Drawing.Point(528, 20);
            this.DisableDialogsBox.Name = "DisableDialogsBox";
            this.DisableDialogsBox.Size = new System.Drawing.Size(113, 19);
            this.DisableDialogsBox.TabIndex = 40;
            this.DisableDialogsBox.Text = "Disable dialogs";
            this.ToolTipInformation.SetToolTip(this.DisableDialogsBox, "Disable alert dialogs from appearing.\r\nUseful if you just need to only use the we" +
        "b server function.");
            this.DisableDialogsBox.UseVisualStyleBackColor = true;
            // 
            // DiscordWebhookGroup
            // 
            this.DiscordWebhookGroup.Controls.Add(this.DiscordWebhookRelayLocallyBox);
            this.DiscordWebhookGroup.Controls.Add(this.DiscordWebhookConfirmAlertsBox);
            this.DiscordWebhookGroup.Controls.Add(this.SaveDiscordSettingsButton);
            this.DiscordWebhookGroup.Controls.Add(this.NS_UnhideSecureBox);
            this.DiscordWebhookGroup.Controls.Add(this.label7);
            this.DiscordWebhookGroup.Controls.Add(this.DiscordWebhookAppendInput);
            this.DiscordWebhookGroup.Controls.Add(this.label6);
            this.DiscordWebhookGroup.Controls.Add(this.DiscordWebhookURLInput);
            this.DiscordWebhookGroup.Controls.Add(this.label5);
            this.DiscordWebhookGroup.ForeColor = System.Drawing.Color.White;
            this.DiscordWebhookGroup.Location = new System.Drawing.Point(12, 39);
            this.DiscordWebhookGroup.Name = "DiscordWebhookGroup";
            this.DiscordWebhookGroup.Size = new System.Drawing.Size(647, 87);
            this.DiscordWebhookGroup.TabIndex = 6;
            this.DiscordWebhookGroup.TabStop = false;
            this.DiscordWebhookGroup.Text = "Discord Webhook";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(182, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Appended Message";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 15);
            this.label6.TabIndex = 7;
            this.label6.Text = "Discord Webhook URL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(491, 15);
            this.label5.TabIndex = 6;
            this.label5.Text = "Using a Discord webhook will disable all GUI alerts. Leave the URL blank to disab" +
    "le this.";
            // 
            // AlertAppearanceAndSoundsGroup
            // 
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.DisableDialogsBox);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.RefreshOutputsButton);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.AudioOutputLabel);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.AudioDeviceCombo);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.StyleButton);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.alertPlayEndToneBox);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.alertNoRelayBox);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.GlobalVolumeLabel);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.volumeBar);
            this.AlertAppearanceAndSoundsGroup.ForeColor = System.Drawing.Color.White;
            this.AlertAppearanceAndSoundsGroup.Location = new System.Drawing.Point(12, 132);
            this.AlertAppearanceAndSoundsGroup.Name = "AlertAppearanceAndSoundsGroup";
            this.AlertAppearanceAndSoundsGroup.Size = new System.Drawing.Size(647, 100);
            this.AlertAppearanceAndSoundsGroup.TabIndex = 7;
            this.AlertAppearanceAndSoundsGroup.TabStop = false;
            this.AlertAppearanceAndSoundsGroup.Text = "Alert Settings";
            // 
            // AudioOutputLabel
            // 
            this.AudioOutputLabel.AutoSize = true;
            this.AudioOutputLabel.Font = new System.Drawing.Font("Arial", 9F);
            this.AudioOutputLabel.Location = new System.Drawing.Point(383, 49);
            this.AudioOutputLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AudioOutputLabel.Name = "AudioOutputLabel";
            this.AudioOutputLabel.Size = new System.Drawing.Size(77, 15);
            this.AudioOutputLabel.TabIndex = 38;
            this.AudioOutputLabel.Text = "Audio Output";
            this.AudioOutputLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // GlobalVolumeLabel
            // 
            this.GlobalVolumeLabel.Location = new System.Drawing.Point(6, 49);
            this.GlobalVolumeLabel.Name = "GlobalVolumeLabel";
            this.GlobalVolumeLabel.Size = new System.Drawing.Size(48, 45);
            this.GlobalVolumeLabel.TabIndex = 13;
            this.GlobalVolumeLabel.Text = "Global\r\nVolume";
            this.GlobalVolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PastAlertsGroup
            // 
            this.PastAlertsGroup.Controls.Add(this.ImportFileButton);
            this.PastAlertsGroup.Controls.Add(this.PlayTestButton);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryDumpLink);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryReplayRecentButton);
            this.PastAlertsGroup.Controls.Add(this.label2);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryOutput);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryClearButton);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryRefreshButton);
            this.PastAlertsGroup.ForeColor = System.Drawing.Color.White;
            this.PastAlertsGroup.Location = new System.Drawing.Point(12, 238);
            this.PastAlertsGroup.Name = "PastAlertsGroup";
            this.PastAlertsGroup.Size = new System.Drawing.Size(647, 107);
            this.PastAlertsGroup.TabIndex = 5;
            this.PastAlertsGroup.TabStop = false;
            this.PastAlertsGroup.Text = "Alert List";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "This list shows the identifiers of each alert.";
            // 
            // ConfigurationPanel
            // 
            this.ConfigurationPanel.Controls.Add(this.AppliedLink);
            this.ConfigurationPanel.Controls.Add(this.label3);
            this.ConfigurationPanel.Controls.Add(this.RegionButton);
            this.ConfigurationPanel.Controls.Add(this.AlertButton);
            this.ConfigurationPanel.Controls.Add(this.TTSButton);
            this.ConfigurationPanel.Controls.Add(this.statusWindowBox);
            this.ConfigurationPanel.Controls.Add(this.CacheOperationButton);
            this.ConfigurationPanel.Controls.Add(this.label10);
            this.ConfigurationPanel.Controls.Add(this.OpenCreditsButton);
            this.ConfigurationPanel.Controls.Add(this.PastAlertsGroup);
            this.ConfigurationPanel.Controls.Add(this.AlertAppearanceAndSoundsGroup);
            this.ConfigurationPanel.Controls.Add(this.DiscordWebhookGroup);
            this.ConfigurationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigurationPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfigurationPanel.Name = "ConfigurationPanel";
            this.ConfigurationPanel.Size = new System.Drawing.Size(671, 405);
            this.ConfigurationPanel.TabIndex = 13;
            // 
            // AlertListRefresher
            // 
            this.AlertListRefresher.Enabled = true;
            this.AlertListRefresher.Interval = 1000;
            this.AlertListRefresher.Tick += new System.EventHandler(this.AlertListRefresher_Tick);
            // 
            // AudioDeviceMessage
            // 
            this.AudioDeviceMessage.Enabled = true;
            this.AudioDeviceMessage.Interval = 2000;
            this.AudioDeviceMessage.Tick += new System.EventHandler(this.AudioDeviceMessage_Tick);
            // 
            // AppliedLink
            // 
            this.AppliedLink.AutoSize = true;
            this.AppliedLink.Font = new System.Drawing.Font("Arial", 16F);
            this.AppliedLink.LinkColor = System.Drawing.Color.Yellow;
            this.AppliedLink.Location = new System.Drawing.Point(12, 9);
            this.AppliedLink.Name = "AppliedLink";
            this.AppliedLink.Size = new System.Drawing.Size(378, 25);
            this.AppliedLink.TabIndex = 27;
            this.AppliedLink.TabStop = true;
            this.AppliedLink.Text = "Most settings are applied immediately.";
            this.ToolTipInformation.SetToolTip(this.AppliedLink, "Mostly everything is immediately applied. Some settings may require a program res" +
        "tart.");
            this.AppliedLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AppliedLink_LinkClicked);
            // 
            // ConfigurationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(671, 405);
            this.Controls.Add(this.ConfigurationPanel);
            this.Controls.Add(this.BusyLockText);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Settings";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.VisibleChanged += new System.EventHandler(this.ConfigurationForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.DiscordWebhookGroup.ResumeLayout(false);
            this.DiscordWebhookGroup.PerformLayout();
            this.AlertAppearanceAndSoundsGroup.ResumeLayout(false);
            this.AlertAppearanceAndSoundsGroup.PerformLayout();
            this.PastAlertsGroup.ResumeLayout(false);
            this.PastAlertsGroup.PerformLayout();
            this.ConfigurationPanel.ResumeLayout(false);
            this.ConfigurationPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer BusyLock;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.GroupBox DiscordWebhookGroup;
        private System.Windows.Forms.Button SaveDiscordSettingsButton;
        private System.Windows.Forms.CheckBox NS_UnhideSecureBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DiscordWebhookAppendInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DiscordWebhookURLInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox AlertAppearanceAndSoundsGroup;
        private System.Windows.Forms.GroupBox PastAlertsGroup;
        private System.Windows.Forms.LinkLabel AlertHistoryDumpLink;
        private System.Windows.Forms.Button AlertHistoryReplayRecentButton;
        private System.Windows.Forms.Button AlertHistoryRefreshButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox AlertHistoryOutput;
        private System.Windows.Forms.Button AlertHistoryClearButton;
        private System.Windows.Forms.Button OpenCreditsButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button CacheOperationButton;
        private System.Windows.Forms.Panel ConfigurationPanel;
        private System.Windows.Forms.Label BusyLockText;
        private System.Windows.Forms.CheckBox statusWindowBox;
        private System.Windows.Forms.Button TTSButton;
        private System.Windows.Forms.Button AlertButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Label GlobalVolumeLabel;
        private System.Windows.Forms.CheckBox alertNoRelayBox;
        private System.Windows.Forms.CheckBox alertPlayEndToneBox;
        private System.Windows.Forms.Button PlayTestButton;
        private System.Windows.Forms.Button ImportFileButton;
        private System.Windows.Forms.CheckBox DiscordWebhookConfirmAlertsBox;
        private System.Windows.Forms.Button RegionButton;
        private System.Windows.Forms.Button StyleButton;
        private System.Windows.Forms.CheckBox DiscordWebhookRelayLocallyBox;
        private System.Windows.Forms.Timer AlertListRefresher;
        private System.Windows.Forms.Label AudioOutputLabel;
        private System.Windows.Forms.ComboBox AudioDeviceCombo;
        private System.Windows.Forms.Button RefreshOutputsButton;
        private System.Windows.Forms.CheckBox DisableDialogsBox;
        private System.Windows.Forms.Timer AudioDeviceMessage;
        private System.Windows.Forms.LinkLabel AppliedLink;
    }
}