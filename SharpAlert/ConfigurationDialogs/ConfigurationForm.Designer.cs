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
            this.alertFullscreenBox = new System.Windows.Forms.CheckBox();
            this.alertFullscreenIdleBox = new System.Windows.Forms.CheckBox();
            this.alertFullscreenDisplayInput = new System.Windows.Forms.NumericUpDown();
            this.alertTimeoutInput = new System.Windows.Forms.NumericUpDown();
            this.alertCompatibilityModeBox = new System.Windows.Forms.CheckBox();
            this.AlertHistoryClearButton = new System.Windows.Forms.Button();
            this.AlertHistoryRefreshButton = new System.Windows.Forms.Button();
            this.AlertHistoryReplayRecentButton = new System.Windows.Forms.Button();
            this.AlertHistoryDumpLink = new System.Windows.Forms.LinkLabel();
            this.OpenCreditsButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.CacheOperationButton = new System.Windows.Forms.Button();
            this.BusyLockText = new System.Windows.Forms.Label();
            this.statusWindowBox = new System.Windows.Forms.CheckBox();
            this.alertTimeZoneUTCBox = new System.Windows.Forms.CheckBox();
            this.ServerButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.AlertButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.alertTTSonlyBox = new System.Windows.Forms.CheckBox();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.alertNoGUIBox = new System.Windows.Forms.CheckBox();
            this.AlertHistoryOutput = new System.Windows.Forms.TextBox();
            this.DiscordWebhookGroup = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AlertAppearanceAndSoundsGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PastAlertsGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            this.alertFullscreenWindowedBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.alertFullscreenDisplayInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertTimeoutInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.DiscordWebhookGroup.SuspendLayout();
            this.AlertAppearanceAndSoundsGroup.SuspendLayout();
            this.PastAlertsGroup.SuspendLayout();
            this.ConfigurationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BusyLock
            // 
            this.BusyLock.Enabled = true;
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
            this.DiscordWebhookURLInput.ForeColor = System.Drawing.Color.Red;
            this.DiscordWebhookURLInput.Location = new System.Drawing.Point(6, 58);
            this.DiscordWebhookURLInput.Name = "DiscordWebhookURLInput";
            this.DiscordWebhookURLInput.Size = new System.Drawing.Size(169, 21);
            this.DiscordWebhookURLInput.TabIndex = 2;
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookURLInput, "The Discord webhook URL to send data to.");
            this.DiscordWebhookURLInput.UseSystemPasswordChar = true;
            // 
            // DiscordWebhookAppendInput
            // 
            this.DiscordWebhookAppendInput.BackColor = System.Drawing.Color.Black;
            this.DiscordWebhookAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DiscordWebhookAppendInput.ForeColor = System.Drawing.Color.Red;
            this.DiscordWebhookAppendInput.Location = new System.Drawing.Point(181, 58);
            this.DiscordWebhookAppendInput.Name = "DiscordWebhookAppendInput";
            this.DiscordWebhookAppendInput.Size = new System.Drawing.Size(460, 21);
            this.DiscordWebhookAppendInput.TabIndex = 3;
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookAppendInput, "The message to be appended after all data of an alert is sent successfully.");
            this.DiscordWebhookAppendInput.UseSystemPasswordChar = true;
            // 
            // NS_UnhideSecureBox
            // 
            this.NS_UnhideSecureBox.AutoSize = true;
            this.NS_UnhideSecureBox.Checked = true;
            this.NS_UnhideSecureBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NS_UnhideSecureBox.Location = new System.Drawing.Point(589, 39);
            this.NS_UnhideSecureBox.Name = "NS_UnhideSecureBox";
            this.NS_UnhideSecureBox.Size = new System.Drawing.Size(52, 19);
            this.NS_UnhideSecureBox.TabIndex = 4;
            this.NS_UnhideSecureBox.Text = "Hide";
            this.ToolTipInformation.SetToolTip(this.NS_UnhideSecureBox, "Hides possibly sensitive information.");
            this.NS_UnhideSecureBox.UseVisualStyleBackColor = true;
            this.NS_UnhideSecureBox.CheckedChanged += new System.EventHandler(this.NS_UnhideSecureBox_CheckedChanged);
            // 
            // SaveDiscordSettingsButton
            // 
            this.SaveDiscordSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveDiscordSettingsButton.Location = new System.Drawing.Point(521, 13);
            this.SaveDiscordSettingsButton.Name = "SaveDiscordSettingsButton";
            this.SaveDiscordSettingsButton.Size = new System.Drawing.Size(120, 23);
            this.SaveDiscordSettingsButton.TabIndex = 1;
            this.SaveDiscordSettingsButton.Text = "Modfiy Webhook";
            this.ToolTipInformation.SetToolTip(this.SaveDiscordSettingsButton, "Saves the webhook and message data.");
            this.SaveDiscordSettingsButton.UseVisualStyleBackColor = true;
            this.SaveDiscordSettingsButton.Click += new System.EventHandler(this.SaveDiscordSettingsButton_Click);
            // 
            // alertFullscreenBox
            // 
            this.alertFullscreenBox.AutoSize = true;
            this.alertFullscreenBox.Location = new System.Drawing.Point(6, 20);
            this.alertFullscreenBox.Name = "alertFullscreenBox";
            this.alertFullscreenBox.Size = new System.Drawing.Size(87, 19);
            this.alertFullscreenBox.TabIndex = 5;
            this.alertFullscreenBox.Text = "Full screen";
            this.ToolTipInformation.SetToolTip(this.alertFullscreenBox, "Shows alerts in full screen (1280x720 recommended) instead of in a window.");
            this.alertFullscreenBox.UseVisualStyleBackColor = true;
            // 
            // alertFullscreenIdleBox
            // 
            this.alertFullscreenIdleBox.AutoSize = true;
            this.alertFullscreenIdleBox.Location = new System.Drawing.Point(228, 20);
            this.alertFullscreenIdleBox.Name = "alertFullscreenIdleBox";
            this.alertFullscreenIdleBox.Size = new System.Drawing.Size(91, 19);
            this.alertFullscreenIdleBox.TabIndex = 10;
            this.alertFullscreenIdleBox.Text = "Idle window";
            this.ToolTipInformation.SetToolTip(this.alertFullscreenIdleBox, "Shows an idle panel on top of all content.");
            this.alertFullscreenIdleBox.UseVisualStyleBackColor = true;
            // 
            // alertFullscreenDisplayInput
            // 
            this.alertFullscreenDisplayInput.Location = new System.Drawing.Point(463, 18);
            this.alertFullscreenDisplayInput.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.alertFullscreenDisplayInput.Name = "alertFullscreenDisplayInput";
            this.alertFullscreenDisplayInput.Size = new System.Drawing.Size(30, 21);
            this.alertFullscreenDisplayInput.TabIndex = 12;
            this.ToolTipInformation.SetToolTip(this.alertFullscreenDisplayInput, "The screen to display the full screen alert and idle panels on.");
            // 
            // alertTimeoutInput
            // 
            this.alertTimeoutInput.Location = new System.Drawing.Point(158, 18);
            this.alertTimeoutInput.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.alertTimeoutInput.Name = "alertTimeoutInput";
            this.alertTimeoutInput.Size = new System.Drawing.Size(53, 21);
            this.alertTimeoutInput.TabIndex = 9;
            this.ToolTipInformation.SetToolTip(this.alertTimeoutInput, "The amount of time (in minutes) until an alert automatically closes itself.");
            this.alertTimeoutInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // alertCompatibilityModeBox
            // 
            this.alertCompatibilityModeBox.AutoSize = true;
            this.alertCompatibilityModeBox.Location = new System.Drawing.Point(509, 20);
            this.alertCompatibilityModeBox.Name = "alertCompatibilityModeBox";
            this.alertCompatibilityModeBox.Size = new System.Drawing.Size(132, 19);
            this.alertCompatibilityModeBox.TabIndex = 13;
            this.alertCompatibilityModeBox.Text = "Compatibility mode";
            this.ToolTipInformation.SetToolTip(this.alertCompatibilityModeBox, "Disables most animations, and some background stuff. May help older systems.");
            this.alertCompatibilityModeBox.UseVisualStyleBackColor = true;
            // 
            // AlertHistoryClearButton
            // 
            this.AlertHistoryClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlertHistoryClearButton.Location = new System.Drawing.Point(547, 78);
            this.AlertHistoryClearButton.Name = "AlertHistoryClearButton";
            this.AlertHistoryClearButton.Size = new System.Drawing.Size(94, 23);
            this.AlertHistoryClearButton.TabIndex = 19;
            this.AlertHistoryClearButton.Text = "Clear";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryClearButton, "Clears the history list.");
            this.AlertHistoryClearButton.UseVisualStyleBackColor = true;
            this.AlertHistoryClearButton.Click += new System.EventHandler(this.AlertHistoryClearButton_Click);
            // 
            // AlertHistoryRefreshButton
            // 
            this.AlertHistoryRefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlertHistoryRefreshButton.Location = new System.Drawing.Point(547, 49);
            this.AlertHistoryRefreshButton.Name = "AlertHistoryRefreshButton";
            this.AlertHistoryRefreshButton.Size = new System.Drawing.Size(94, 23);
            this.AlertHistoryRefreshButton.TabIndex = 18;
            this.AlertHistoryRefreshButton.Text = "Refresh";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryRefreshButton, "Refreshes the history list.");
            this.AlertHistoryRefreshButton.UseVisualStyleBackColor = true;
            this.AlertHistoryRefreshButton.Click += new System.EventHandler(this.AlertHistoryRefreshButton_Click);
            // 
            // AlertHistoryReplayRecentButton
            // 
            this.AlertHistoryReplayRecentButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlertHistoryReplayRecentButton.Location = new System.Drawing.Point(547, 20);
            this.AlertHistoryReplayRecentButton.Name = "AlertHistoryReplayRecentButton";
            this.AlertHistoryReplayRecentButton.Size = new System.Drawing.Size(94, 23);
            this.AlertHistoryReplayRecentButton.TabIndex = 17;
            this.AlertHistoryReplayRecentButton.Text = "Replay";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryReplayRecentButton, "Immediately re-adds the most recent alert back into the queue after wiping it fro" +
        "m the history.");
            this.AlertHistoryReplayRecentButton.UseVisualStyleBackColor = true;
            this.AlertHistoryReplayRecentButton.Click += new System.EventHandler(this.AlertHistoryReplayRecentButton_Click);
            // 
            // AlertHistoryDumpLink
            // 
            this.AlertHistoryDumpLink.AutoSize = true;
            this.AlertHistoryDumpLink.LinkColor = System.Drawing.Color.Yellow;
            this.AlertHistoryDumpLink.Location = new System.Drawing.Point(434, 17);
            this.AlertHistoryDumpLink.Name = "AlertHistoryDumpLink";
            this.AlertHistoryDumpLink.Size = new System.Drawing.Size(107, 15);
            this.AlertHistoryDumpLink.TabIndex = 16;
            this.AlertHistoryDumpLink.TabStop = true;
            this.AlertHistoryDumpLink.Text = "Dump alert history";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryDumpLink, "Dumps the entire alert history to a folder named \"dump\".");
            this.AlertHistoryDumpLink.VisitedLinkColor = System.Drawing.Color.Cyan;
            this.AlertHistoryDumpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AlertHistoryDumpLink_LinkClicked);
            // 
            // OpenCreditsButton
            // 
            this.OpenCreditsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenCreditsButton.Location = new System.Drawing.Point(12, 375);
            this.OpenCreditsButton.Name = "OpenCreditsButton";
            this.OpenCreditsButton.Size = new System.Drawing.Size(61, 23);
            this.OpenCreditsButton.TabIndex = 20;
            this.OpenCreditsButton.Text = "Credits";
            this.ToolTipInformation.SetToolTip(this.OpenCreditsButton, "Ice Bear definitely helped here :3 (This is a dialog, not a link)");
            this.OpenCreditsButton.UseVisualStyleBackColor = true;
            this.OpenCreditsButton.Click += new System.EventHandler(this.OpenCreditsButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(79, 379);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(246, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "BunnyTub © 2024-2025 | All rights reserved.";
            this.ToolTipInformation.SetToolTip(this.label10, "The copyright text. Because left is not right. :\')");
            // 
            // CacheOperationButton
            // 
            this.CacheOperationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CacheOperationButton.Location = new System.Drawing.Point(459, 375);
            this.CacheOperationButton.Name = "CacheOperationButton";
            this.CacheOperationButton.Size = new System.Drawing.Size(94, 23);
            this.CacheOperationButton.TabIndex = 22;
            this.CacheOperationButton.Text = "Reset Cache";
            this.ToolTipInformation.SetToolTip(this.CacheOperationButton, "Re-caches information from the internet.");
            this.CacheOperationButton.UseMnemonic = false;
            this.CacheOperationButton.UseVisualStyleBackColor = true;
            this.CacheOperationButton.Click += new System.EventHandler(this.CacheOperationButton_Click);
            // 
            // BusyLockText
            // 
            this.BusyLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BusyLockText.Font = new System.Drawing.Font("Arial", 12F);
            this.BusyLockText.Location = new System.Drawing.Point(0, 0);
            this.BusyLockText.Name = "BusyLockText";
            this.BusyLockText.Size = new System.Drawing.Size(671, 429);
            this.BusyLockText.TabIndex = 14;
            this.BusyLockText.Text = "Please wait or dismiss all alerts to configure settings.";
            this.BusyLockText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.BusyLockText, "You\'ll need to wait for all alerts to finish before continuing.");
            // 
            // statusWindowBox
            // 
            this.statusWindowBox.AutoSize = true;
            this.statusWindowBox.Location = new System.Drawing.Point(345, 378);
            this.statusWindowBox.Name = "statusWindowBox";
            this.statusWindowBox.Size = new System.Drawing.Size(106, 19);
            this.statusWindowBox.TabIndex = 21;
            this.statusWindowBox.Text = "Status window";
            this.ToolTipInformation.SetToolTip(this.statusWindowBox, "Shows the status window.");
            this.statusWindowBox.UseVisualStyleBackColor = true;
            // 
            // alertTimeZoneUTCBox
            // 
            this.alertTimeZoneUTCBox.AutoSize = true;
            this.alertTimeZoneUTCBox.Location = new System.Drawing.Point(327, 20);
            this.alertTimeZoneUTCBox.Name = "alertTimeZoneUTCBox";
            this.alertTimeZoneUTCBox.Size = new System.Drawing.Size(77, 19);
            this.alertTimeZoneUTCBox.TabIndex = 11;
            this.alertTimeZoneUTCBox.Text = "Use UTC";
            this.ToolTipInformation.SetToolTip(this.alertTimeZoneUTCBox, "Sets the time display on the idle window to UTC instead of the system time zone.");
            this.alertTimeZoneUTCBox.UseVisualStyleBackColor = true;
            // 
            // ServerButton
            // 
            this.ServerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ServerButton.Location = new System.Drawing.Point(559, 375);
            this.ServerButton.Name = "ServerButton";
            this.ServerButton.Size = new System.Drawing.Size(100, 23);
            this.ServerButton.TabIndex = 23;
            this.ServerButton.Text = "Server Config";
            this.ToolTipInformation.SetToolTip(this.ServerButton, "Opens the server configuration window.");
            this.ServerButton.UseMnemonic = false;
            this.ServerButton.UseVisualStyleBackColor = true;
            this.ServerButton.Click += new System.EventHandler(this.ServerButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label1.Font = new System.Drawing.Font("Arial", 16F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(380, 25);
            this.label1.TabIndex = 27;
            this.label1.Text = "Most settings are immediately applied.";
            this.ToolTipInformation.SetToolTip(this.label1, "Mostly everything is immediately applied. Some settings may require a program res" +
        "tart.");
            // 
            // AlertButton
            // 
            this.AlertButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlertButton.Location = new System.Drawing.Point(559, 12);
            this.AlertButton.Name = "AlertButton";
            this.AlertButton.Size = new System.Drawing.Size(100, 23);
            this.AlertButton.TabIndex = 0;
            this.AlertButton.Text = "Alert Config";
            this.ToolTipInformation.SetToolTip(this.AlertButton, "Opens the alert configuration window.");
            this.AlertButton.UseMnemonic = false;
            this.AlertButton.UseVisualStyleBackColor = true;
            this.AlertButton.Click += new System.EventHandler(this.AlertButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 405);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(608, 15);
            this.label3.TabIndex = 29;
            this.label3.Text = "This piece of software is not sold in any shape or form. It is provided for free," +
    " \"as is\", by the original developers.";
            this.ToolTipInformation.SetToolTip(this.label3, "Can\'t be too careful.");
            // 
            // alertTTSonlyBox
            // 
            this.alertTTSonlyBox.AutoSize = true;
            this.alertTTSonlyBox.Location = new System.Drawing.Point(6, 70);
            this.alertTTSonlyBox.Name = "alertTTSonlyBox";
            this.alertTTSonlyBox.Size = new System.Drawing.Size(159, 19);
            this.alertTTSonlyBox.TabIndex = 7;
            this.alertTTSonlyBox.Text = "Never play remote audio";
            this.ToolTipInformation.SetToolTip(this.alertTTSonlyBox, "Turn off requests for remote audio. Only plays TTS.");
            this.alertTTSonlyBox.UseVisualStyleBackColor = true;
            // 
            // volumeBar
            // 
            this.volumeBar.LargeChange = 1;
            this.volumeBar.Location = new System.Drawing.Point(235, 45);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(406, 45);
            this.volumeBar.TabIndex = 14;
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ToolTipInformation.SetToolTip(this.volumeBar, "The global volume of the application.");
            // 
            // alertNoGUIBox
            // 
            this.alertNoGUIBox.AutoSize = true;
            this.alertNoGUIBox.Location = new System.Drawing.Point(6, 95);
            this.alertNoGUIBox.Name = "alertNoGUIBox";
            this.alertNoGUIBox.Size = new System.Drawing.Size(142, 19);
            this.alertNoGUIBox.TabIndex = 8;
            this.alertNoGUIBox.Text = "Never show alert GUI";
            this.ToolTipInformation.SetToolTip(this.alertNoGUIBox, "Stops alert panels from displaying. Similar to the functionality of SharpENDEC.");
            this.alertNoGUIBox.UseVisualStyleBackColor = true;
            // 
            // AlertHistoryOutput
            // 
            this.AlertHistoryOutput.BackColor = System.Drawing.Color.Black;
            this.AlertHistoryOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlertHistoryOutput.Font = new System.Drawing.Font("Arial", 12F);
            this.AlertHistoryOutput.ForeColor = System.Drawing.Color.Red;
            this.AlertHistoryOutput.Location = new System.Drawing.Point(6, 35);
            this.AlertHistoryOutput.Multiline = true;
            this.AlertHistoryOutput.Name = "AlertHistoryOutput";
            this.AlertHistoryOutput.ReadOnly = true;
            this.AlertHistoryOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AlertHistoryOutput.Size = new System.Drawing.Size(535, 66);
            this.AlertHistoryOutput.TabIndex = 15;
            this.ToolTipInformation.SetToolTip(this.AlertHistoryOutput, "This area shows the identifiers of each alert. If an identifier couldn\'t be found" +
        ", the identifier will be an MD5 value based on the alert\'s raw data.");
            this.AlertHistoryOutput.WordWrap = false;
            // 
            // DiscordWebhookGroup
            // 
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
            this.DiscordWebhookGroup.Size = new System.Drawing.Size(647, 85);
            this.DiscordWebhookGroup.TabIndex = 6;
            this.DiscordWebhookGroup.TabStop = false;
            this.DiscordWebhookGroup.Text = "Discord Webhook";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(181, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(329, 15);
            this.label7.TabIndex = 9;
            this.label7.Text = "Message (appended after all alerts in a message are sent)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 40);
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
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.alertFullscreenWindowedBox);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.alertNoGUIBox);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.label4);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.volumeBar);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.alertTTSonlyBox);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.alertTimeZoneUTCBox);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.alertCompatibilityModeBox);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.label9);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.alertTimeoutInput);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.label8);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.alertFullscreenDisplayInput);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.alertFullscreenIdleBox);
            this.AlertAppearanceAndSoundsGroup.Controls.Add(this.alertFullscreenBox);
            this.AlertAppearanceAndSoundsGroup.ForeColor = System.Drawing.Color.White;
            this.AlertAppearanceAndSoundsGroup.Location = new System.Drawing.Point(12, 130);
            this.AlertAppearanceAndSoundsGroup.Name = "AlertAppearanceAndSoundsGroup";
            this.AlertAppearanceAndSoundsGroup.Size = new System.Drawing.Size(647, 126);
            this.AlertAppearanceAndSoundsGroup.TabIndex = 7;
            this.AlertAppearanceAndSoundsGroup.TabStop = false;
            this.AlertAppearanceAndSoundsGroup.Text = "Alert Appearance/Sounds";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(181, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 30);
            this.label4.TabIndex = 13;
            this.label4.Text = "Global\r\nVolume";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(100, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Timeout";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(411, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "Screen";
            // 
            // PastAlertsGroup
            // 
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryDumpLink);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryReplayRecentButton);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryRefreshButton);
            this.PastAlertsGroup.Controls.Add(this.label2);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryOutput);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryClearButton);
            this.PastAlertsGroup.ForeColor = System.Drawing.Color.White;
            this.PastAlertsGroup.Location = new System.Drawing.Point(12, 262);
            this.PastAlertsGroup.Name = "PastAlertsGroup";
            this.PastAlertsGroup.Size = new System.Drawing.Size(647, 107);
            this.PastAlertsGroup.TabIndex = 5;
            this.PastAlertsGroup.TabStop = false;
            this.PastAlertsGroup.Text = "Past Alerts";
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
            this.ConfigurationPanel.Controls.Add(this.label3);
            this.ConfigurationPanel.Controls.Add(this.AlertButton);
            this.ConfigurationPanel.Controls.Add(this.label1);
            this.ConfigurationPanel.Controls.Add(this.ServerButton);
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
            this.ConfigurationPanel.Size = new System.Drawing.Size(671, 429);
            this.ConfigurationPanel.TabIndex = 13;
            // 
            // alertFullscreenWindowedBox
            // 
            this.alertFullscreenWindowedBox.AutoSize = true;
            this.alertFullscreenWindowedBox.Location = new System.Drawing.Point(6, 45);
            this.alertFullscreenWindowedBox.Name = "alertFullscreenWindowedBox";
            this.alertFullscreenWindowedBox.Size = new System.Drawing.Size(143, 19);
            this.alertFullscreenWindowedBox.TabIndex = 6;
            this.alertFullscreenWindowedBox.Text = "Force windowed view";
            this.ToolTipInformation.SetToolTip(this.alertFullscreenWindowedBox, "Forces the full screen panel to have window controls. It can be useful if you\'re " +
        "trying to window capture.");
            this.alertFullscreenWindowedBox.UseVisualStyleBackColor = true;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(671, 429);
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
            this.Text = "SharpAlert Settings";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alertFullscreenDisplayInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertTimeoutInput)).EndInit();
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
        private System.Windows.Forms.CheckBox alertCompatibilityModeBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown alertTimeoutInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown alertFullscreenDisplayInput;
        private System.Windows.Forms.CheckBox alertFullscreenIdleBox;
        private System.Windows.Forms.CheckBox alertFullscreenBox;
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
        private System.Windows.Forms.CheckBox alertTimeZoneUTCBox;
        private System.Windows.Forms.Button ServerButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button AlertButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox alertTTSonlyBox;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox alertNoGUIBox;
        private System.Windows.Forms.CheckBox alertFullscreenWindowedBox;
    }
}