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
            this.SAMEAddButton = new System.Windows.Forms.Button();
            this.SAMEClearButton = new System.Windows.Forms.Button();
            this.UGCAddButton = new System.Windows.Forms.Button();
            this.UGCClearButton = new System.Windows.Forms.Button();
            this.EventAddButton = new System.Windows.Forms.Button();
            this.EventClearButton = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.AlertCheckIntervalInput = new System.Windows.Forms.NumericUpDown();
            this.CacheOperationButton = new System.Windows.Forms.Button();
            this.BusyLockText = new System.Windows.Forms.Label();
            this.DiscordWebhookGroup = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AlertAppearanceGroup = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.PastAlertsGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AlertHistoryOutput = new System.Windows.Forms.TextBox();
            this.LocationsAndEventsGroup = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.EventBlacklistOutput = new System.Windows.Forms.TextBox();
            this.EventBlacklistInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.AreaUGCOutput = new System.Windows.Forms.TextBox();
            this.AreaUGCInput = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.AreaSAMEOutput = new System.Windows.Forms.TextBox();
            this.AreaSAMEInput = new System.Windows.Forms.TextBox();
            this.AlertFunctionalityGroup = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.discardFirstAlertsBox = new System.Windows.Forms.CheckBox();
            this.weaOnlyBox = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.urgencyUnknownBox = new System.Windows.Forms.CheckBox();
            this.urgencyPastBox = new System.Windows.Forms.CheckBox();
            this.urgencyFutureBox = new System.Windows.Forms.CheckBox();
            this.urgencyExpectedBox = new System.Windows.Forms.CheckBox();
            this.urgencyImmediateBox = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.severityUnknownBox = new System.Windows.Forms.CheckBox();
            this.severityMinorBox = new System.Windows.Forms.CheckBox();
            this.severityModerateBox = new System.Windows.Forms.CheckBox();
            this.severitySevereBox = new System.Windows.Forms.CheckBox();
            this.severityExtremeBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.messageTypeTestBox = new System.Windows.Forms.CheckBox();
            this.messageTypeCancelBox = new System.Windows.Forms.CheckBox();
            this.messageTypeUpdateBox = new System.Windows.Forms.CheckBox();
            this.messageTypeAlertBox = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusActualBox = new System.Windows.Forms.CheckBox();
            this.statusTestBox = new System.Windows.Forms.CheckBox();
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.alertFullscreenDisplayInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertTimeoutInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AlertCheckIntervalInput)).BeginInit();
            this.DiscordWebhookGroup.SuspendLayout();
            this.AlertAppearanceGroup.SuspendLayout();
            this.PastAlertsGroup.SuspendLayout();
            this.LocationsAndEventsGroup.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.AlertFunctionalityGroup.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.DiscordWebhookURLInput.Location = new System.Drawing.Point(6, 58);
            this.DiscordWebhookURLInput.Name = "DiscordWebhookURLInput";
            this.DiscordWebhookURLInput.Size = new System.Drawing.Size(169, 21);
            this.DiscordWebhookURLInput.TabIndex = 4;
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookURLInput, "The Discord webhook URL to send data to.");
            this.DiscordWebhookURLInput.UseSystemPasswordChar = true;
            // 
            // DiscordWebhookAppendInput
            // 
            this.DiscordWebhookAppendInput.Location = new System.Drawing.Point(181, 58);
            this.DiscordWebhookAppendInput.Name = "DiscordWebhookAppendInput";
            this.DiscordWebhookAppendInput.Size = new System.Drawing.Size(460, 21);
            this.DiscordWebhookAppendInput.TabIndex = 8;
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
            this.NS_UnhideSecureBox.TabIndex = 10;
            this.NS_UnhideSecureBox.Text = "Hide";
            this.ToolTipInformation.SetToolTip(this.NS_UnhideSecureBox, "Hides possibly sensitive information.");
            this.NS_UnhideSecureBox.UseVisualStyleBackColor = true;
            this.NS_UnhideSecureBox.CheckedChanged += new System.EventHandler(this.NS_UnhideSecureBox_CheckedChanged);
            // 
            // SaveDiscordSettingsButton
            // 
            this.SaveDiscordSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveDiscordSettingsButton.Location = new System.Drawing.Point(537, 13);
            this.SaveDiscordSettingsButton.Name = "SaveDiscordSettingsButton";
            this.SaveDiscordSettingsButton.Size = new System.Drawing.Size(104, 23);
            this.SaveDiscordSettingsButton.TabIndex = 12;
            this.SaveDiscordSettingsButton.Text = "Save Webhook";
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
            this.alertFullscreenBox.TabIndex = 19;
            this.alertFullscreenBox.Text = "Full screen";
            this.ToolTipInformation.SetToolTip(this.alertFullscreenBox, "Shows alerts in full screen (1280x720 recommended) instead of in a window.");
            this.alertFullscreenBox.UseVisualStyleBackColor = true;
            // 
            // alertFullscreenIdleBox
            // 
            this.alertFullscreenIdleBox.AutoSize = true;
            this.alertFullscreenIdleBox.Location = new System.Drawing.Point(228, 20);
            this.alertFullscreenIdleBox.Name = "alertFullscreenIdleBox";
            this.alertFullscreenIdleBox.Size = new System.Drawing.Size(125, 19);
            this.alertFullscreenIdleBox.TabIndex = 20;
            this.alertFullscreenIdleBox.Text = "Show idle window";
            this.ToolTipInformation.SetToolTip(this.alertFullscreenIdleBox, "Shows an idle panel on top of all content.");
            this.alertFullscreenIdleBox.UseVisualStyleBackColor = true;
            // 
            // alertFullscreenDisplayInput
            // 
            this.alertFullscreenDisplayInput.Location = new System.Drawing.Point(421, 18);
            this.alertFullscreenDisplayInput.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.alertFullscreenDisplayInput.Name = "alertFullscreenDisplayInput";
            this.alertFullscreenDisplayInput.Size = new System.Drawing.Size(72, 21);
            this.alertFullscreenDisplayInput.TabIndex = 21;
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
            this.alertTimeoutInput.TabIndex = 23;
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
            this.alertCompatibilityModeBox.TabIndex = 24;
            this.alertCompatibilityModeBox.Text = "Compatibility mode";
            this.ToolTipInformation.SetToolTip(this.alertCompatibilityModeBox, "Disables most animations, and when idle is used, attaches alerts to the idle pane" +
        "l. (Better for window capturing)");
            this.alertCompatibilityModeBox.UseVisualStyleBackColor = true;
            // 
            // AlertHistoryClearButton
            // 
            this.AlertHistoryClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlertHistoryClearButton.Location = new System.Drawing.Point(547, 78);
            this.AlertHistoryClearButton.Name = "AlertHistoryClearButton";
            this.AlertHistoryClearButton.Size = new System.Drawing.Size(94, 23);
            this.AlertHistoryClearButton.TabIndex = 2;
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
            this.AlertHistoryRefreshButton.TabIndex = 7;
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
            this.AlertHistoryReplayRecentButton.TabIndex = 8;
            this.AlertHistoryReplayRecentButton.Text = "Replay";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryReplayRecentButton, "Immediately re-adds the most recent alert back into the queue after wiping it fro" +
        "m the history.");
            this.AlertHistoryReplayRecentButton.UseVisualStyleBackColor = true;
            this.AlertHistoryReplayRecentButton.Click += new System.EventHandler(this.AlertHistoryReplayRecentButton_Click);
            // 
            // AlertHistoryDumpLink
            // 
            this.AlertHistoryDumpLink.AutoSize = true;
            this.AlertHistoryDumpLink.LinkColor = System.Drawing.Color.Cyan;
            this.AlertHistoryDumpLink.Location = new System.Drawing.Point(387, 16);
            this.AlertHistoryDumpLink.Name = "AlertHistoryDumpLink";
            this.AlertHistoryDumpLink.Size = new System.Drawing.Size(154, 15);
            this.AlertHistoryDumpLink.TabIndex = 9;
            this.AlertHistoryDumpLink.TabStop = true;
            this.AlertHistoryDumpLink.Text = "Dump alert history to folder";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryDumpLink, "Dumps the entire alert history to a folder named \"dump\".");
            this.AlertHistoryDumpLink.VisitedLinkColor = System.Drawing.Color.Cyan;
            this.AlertHistoryDumpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AlertHistoryDumpLink_LinkClicked);
            // 
            // OpenCreditsButton
            // 
            this.OpenCreditsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenCreditsButton.Location = new System.Drawing.Point(12, 602);
            this.OpenCreditsButton.Name = "OpenCreditsButton";
            this.OpenCreditsButton.Size = new System.Drawing.Size(94, 23);
            this.OpenCreditsButton.TabIndex = 9;
            this.OpenCreditsButton.Text = "Credits";
            this.ToolTipInformation.SetToolTip(this.OpenCreditsButton, "Ice Bear definitely helped here :3 (This is a dialog, not a link)");
            this.OpenCreditsButton.UseVisualStyleBackColor = true;
            this.OpenCreditsButton.Click += new System.EventHandler(this.OpenCreditsButton_Click);
            // 
            // SAMEAddButton
            // 
            this.SAMEAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAMEAddButton.Location = new System.Drawing.Point(106, 47);
            this.SAMEAddButton.Name = "SAMEAddButton";
            this.SAMEAddButton.Size = new System.Drawing.Size(44, 23);
            this.SAMEAddButton.TabIndex = 1;
            this.SAMEAddButton.Text = "Add";
            this.ToolTipInformation.SetToolTip(this.SAMEAddButton, "Adds a SAME location to the allowlist.");
            this.SAMEAddButton.UseVisualStyleBackColor = true;
            this.SAMEAddButton.Click += new System.EventHandler(this.SAMEAddButton_Click);
            // 
            // SAMEClearButton
            // 
            this.SAMEClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SAMEClearButton.Location = new System.Drawing.Point(6, 47);
            this.SAMEClearButton.Name = "SAMEClearButton";
            this.SAMEClearButton.Size = new System.Drawing.Size(94, 23);
            this.SAMEClearButton.TabIndex = 2;
            this.SAMEClearButton.Text = "Clear";
            this.ToolTipInformation.SetToolTip(this.SAMEClearButton, "Clears the SAME locations allowlist.");
            this.SAMEClearButton.UseVisualStyleBackColor = true;
            this.SAMEClearButton.Click += new System.EventHandler(this.SAMEClearButton_Click);
            // 
            // UGCAddButton
            // 
            this.UGCAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UGCAddButton.Location = new System.Drawing.Point(106, 47);
            this.UGCAddButton.Name = "UGCAddButton";
            this.UGCAddButton.Size = new System.Drawing.Size(44, 23);
            this.UGCAddButton.TabIndex = 1;
            this.UGCAddButton.Text = "Add";
            this.ToolTipInformation.SetToolTip(this.UGCAddButton, "Adds a UGC location to the allowlist.");
            this.UGCAddButton.UseVisualStyleBackColor = true;
            this.UGCAddButton.Click += new System.EventHandler(this.UGCAddButton_Click);
            // 
            // UGCClearButton
            // 
            this.UGCClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UGCClearButton.Location = new System.Drawing.Point(6, 47);
            this.UGCClearButton.Name = "UGCClearButton";
            this.UGCClearButton.Size = new System.Drawing.Size(94, 23);
            this.UGCClearButton.TabIndex = 2;
            this.UGCClearButton.Text = "Clear";
            this.ToolTipInformation.SetToolTip(this.UGCClearButton, "Clears the UGC locations allowlist.");
            this.UGCClearButton.UseVisualStyleBackColor = true;
            this.UGCClearButton.Click += new System.EventHandler(this.UGCClearButton_Click);
            // 
            // EventAddButton
            // 
            this.EventAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EventAddButton.Location = new System.Drawing.Point(106, 64);
            this.EventAddButton.Name = "EventAddButton";
            this.EventAddButton.Size = new System.Drawing.Size(44, 23);
            this.EventAddButton.TabIndex = 1;
            this.EventAddButton.Text = "Add";
            this.ToolTipInformation.SetToolTip(this.EventAddButton, "Adds a SAME event to the blacklist.");
            this.EventAddButton.UseVisualStyleBackColor = true;
            this.EventAddButton.Click += new System.EventHandler(this.EventAddButton_Click);
            // 
            // EventClearButton
            // 
            this.EventClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EventClearButton.Location = new System.Drawing.Point(6, 64);
            this.EventClearButton.Name = "EventClearButton";
            this.EventClearButton.Size = new System.Drawing.Size(94, 23);
            this.EventClearButton.TabIndex = 2;
            this.EventClearButton.Text = "Clear";
            this.ToolTipInformation.SetToolTip(this.EventClearButton, "Clears the SAME event blacklist.");
            this.EventClearButton.UseVisualStyleBackColor = true;
            this.EventClearButton.Click += new System.EventHandler(this.EventClearButton_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(112, 606);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(246, 15);
            this.label10.TabIndex = 11;
            this.label10.Text = "BunnyTub © 2024-2025 | All rights reserved.";
            this.ToolTipInformation.SetToolTip(this.label10, "The copyright text. Because left is not right. :\')");
            // 
            // AlertCheckIntervalInput
            // 
            this.AlertCheckIntervalInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.AlertCheckIntervalInput.Location = new System.Drawing.Point(250, 299);
            this.AlertCheckIntervalInput.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.AlertCheckIntervalInput.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.AlertCheckIntervalInput.Name = "AlertCheckIntervalInput";
            this.AlertCheckIntervalInput.Size = new System.Drawing.Size(54, 21);
            this.AlertCheckIntervalInput.TabIndex = 6;
            this.ToolTipInformation.SetToolTip(this.AlertCheckIntervalInput, "Sets the delay (in seconds) between each request to FEMA (or a set server). Using" +
        " values under 30 is not recommended if this software is used more than once on t" +
        "he same network.");
            this.AlertCheckIntervalInput.Value = new decimal(new int[] {
            45,
            0,
            0,
            0});
            // 
            // CacheOperationButton
            // 
            this.CacheOperationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CacheOperationButton.Location = new System.Drawing.Point(486, 602);
            this.CacheOperationButton.Name = "CacheOperationButton";
            this.CacheOperationButton.Size = new System.Drawing.Size(173, 23);
            this.CacheOperationButton.TabIndex = 12;
            this.CacheOperationButton.Text = "Force Cache Reset";
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
            this.BusyLockText.Size = new System.Drawing.Size(671, 633);
            this.BusyLockText.TabIndex = 14;
            this.BusyLockText.Text = "Please wait or dismiss all alerts to configure settings.";
            this.BusyLockText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.BusyLockText, "You\'ll need to wait for all alerts to finish before continuing.");
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
            this.DiscordWebhookGroup.Location = new System.Drawing.Point(12, 344);
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
            // AlertAppearanceGroup
            // 
            this.AlertAppearanceGroup.Controls.Add(this.alertCompatibilityModeBox);
            this.AlertAppearanceGroup.Controls.Add(this.label9);
            this.AlertAppearanceGroup.Controls.Add(this.alertTimeoutInput);
            this.AlertAppearanceGroup.Controls.Add(this.label8);
            this.AlertAppearanceGroup.Controls.Add(this.alertFullscreenDisplayInput);
            this.AlertAppearanceGroup.Controls.Add(this.alertFullscreenIdleBox);
            this.AlertAppearanceGroup.Controls.Add(this.alertFullscreenBox);
            this.AlertAppearanceGroup.ForeColor = System.Drawing.Color.White;
            this.AlertAppearanceGroup.Location = new System.Drawing.Point(12, 435);
            this.AlertAppearanceGroup.Name = "AlertAppearanceGroup";
            this.AlertAppearanceGroup.Size = new System.Drawing.Size(647, 48);
            this.AlertAppearanceGroup.TabIndex = 7;
            this.AlertAppearanceGroup.TabStop = false;
            this.AlertAppearanceGroup.Text = "Alert Appearance";
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
            this.label8.Location = new System.Drawing.Point(369, 21);
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
            this.PastAlertsGroup.Location = new System.Drawing.Point(12, 489);
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
            this.label2.Size = new System.Drawing.Size(250, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "This list shows the MD5 values of each alert.";
            // 
            // AlertHistoryOutput
            // 
            this.AlertHistoryOutput.Font = new System.Drawing.Font("Arial", 12F);
            this.AlertHistoryOutput.Location = new System.Drawing.Point(6, 35);
            this.AlertHistoryOutput.Multiline = true;
            this.AlertHistoryOutput.Name = "AlertHistoryOutput";
            this.AlertHistoryOutput.ReadOnly = true;
            this.AlertHistoryOutput.Size = new System.Drawing.Size(535, 66);
            this.AlertHistoryOutput.TabIndex = 3;
            this.AlertHistoryOutput.WordWrap = false;
            // 
            // LocationsAndEventsGroup
            // 
            this.LocationsAndEventsGroup.Controls.Add(this.groupBox9);
            this.LocationsAndEventsGroup.Controls.Add(this.label1);
            this.LocationsAndEventsGroup.Controls.Add(this.groupBox8);
            this.LocationsAndEventsGroup.Controls.Add(this.groupBox7);
            this.LocationsAndEventsGroup.ForeColor = System.Drawing.Color.White;
            this.LocationsAndEventsGroup.Location = new System.Drawing.Point(328, 12);
            this.LocationsAndEventsGroup.Name = "LocationsAndEventsGroup";
            this.LocationsAndEventsGroup.Size = new System.Drawing.Size(331, 326);
            this.LocationsAndEventsGroup.TabIndex = 3;
            this.LocationsAndEventsGroup.TabStop = false;
            this.LocationsAndEventsGroup.Text = "Locations/Events";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label3);
            this.groupBox9.Controls.Add(this.EventBlacklistOutput);
            this.groupBox9.Controls.Add(this.EventClearButton);
            this.groupBox9.Controls.Add(this.EventAddButton);
            this.groupBox9.Controls.Add(this.EventBlacklistInput);
            this.groupBox9.ForeColor = System.Drawing.Color.White;
            this.groupBox9.Location = new System.Drawing.Point(6, 227);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(319, 93);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "SAME Events";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(240, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "You can add SAME events to blacklist here.";
            // 
            // EventBlacklistOutput
            // 
            this.EventBlacklistOutput.Font = new System.Drawing.Font("Arial", 12F);
            this.EventBlacklistOutput.Location = new System.Drawing.Point(169, 37);
            this.EventBlacklistOutput.Multiline = true;
            this.EventBlacklistOutput.Name = "EventBlacklistOutput";
            this.EventBlacklistOutput.ReadOnly = true;
            this.EventBlacklistOutput.Size = new System.Drawing.Size(144, 51);
            this.EventBlacklistOutput.TabIndex = 3;
            this.EventBlacklistOutput.WordWrap = false;
            // 
            // EventBlacklistInput
            // 
            this.EventBlacklistInput.Location = new System.Drawing.Point(6, 37);
            this.EventBlacklistInput.Name = "EventBlacklistInput";
            this.EventBlacklistInput.Size = new System.Drawing.Size(144, 21);
            this.EventBlacklistInput.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(310, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "If all location fields are blank, any locations are allowed.";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.AreaUGCOutput);
            this.groupBox8.Controls.Add(this.UGCClearButton);
            this.groupBox8.Controls.Add(this.UGCAddButton);
            this.groupBox8.Controls.Add(this.AreaUGCInput);
            this.groupBox8.ForeColor = System.Drawing.Color.White;
            this.groupBox8.Location = new System.Drawing.Point(169, 35);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(156, 186);
            this.groupBox8.TabIndex = 4;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "UGC Locations";
            // 
            // AreaUGCOutput
            // 
            this.AreaUGCOutput.Font = new System.Drawing.Font("Arial", 12F);
            this.AreaUGCOutput.Location = new System.Drawing.Point(6, 76);
            this.AreaUGCOutput.Multiline = true;
            this.AreaUGCOutput.Name = "AreaUGCOutput";
            this.AreaUGCOutput.ReadOnly = true;
            this.AreaUGCOutput.Size = new System.Drawing.Size(144, 104);
            this.AreaUGCOutput.TabIndex = 3;
            this.AreaUGCOutput.WordWrap = false;
            // 
            // AreaUGCInput
            // 
            this.AreaUGCInput.Location = new System.Drawing.Point(6, 20);
            this.AreaUGCInput.Name = "AreaUGCInput";
            this.AreaUGCInput.Size = new System.Drawing.Size(144, 21);
            this.AreaUGCInput.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.AreaSAMEOutput);
            this.groupBox7.Controls.Add(this.SAMEClearButton);
            this.groupBox7.Controls.Add(this.SAMEAddButton);
            this.groupBox7.Controls.Add(this.AreaSAMEInput);
            this.groupBox7.ForeColor = System.Drawing.Color.White;
            this.groupBox7.Location = new System.Drawing.Point(6, 35);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(156, 186);
            this.groupBox7.TabIndex = 3;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "SAME Locations";
            // 
            // AreaSAMEOutput
            // 
            this.AreaSAMEOutput.Font = new System.Drawing.Font("Arial", 12F);
            this.AreaSAMEOutput.Location = new System.Drawing.Point(6, 76);
            this.AreaSAMEOutput.Multiline = true;
            this.AreaSAMEOutput.Name = "AreaSAMEOutput";
            this.AreaSAMEOutput.ReadOnly = true;
            this.AreaSAMEOutput.Size = new System.Drawing.Size(144, 104);
            this.AreaSAMEOutput.TabIndex = 3;
            this.AreaSAMEOutput.WordWrap = false;
            // 
            // AreaSAMEInput
            // 
            this.AreaSAMEInput.Location = new System.Drawing.Point(6, 20);
            this.AreaSAMEInput.Name = "AreaSAMEInput";
            this.AreaSAMEInput.Size = new System.Drawing.Size(144, 21);
            this.AreaSAMEInput.TabIndex = 0;
            // 
            // AlertFunctionalityGroup
            // 
            this.AlertFunctionalityGroup.Controls.Add(this.label4);
            this.AlertFunctionalityGroup.Controls.Add(this.AlertCheckIntervalInput);
            this.AlertFunctionalityGroup.Controls.Add(this.groupBox11);
            this.AlertFunctionalityGroup.Controls.Add(this.groupBox5);
            this.AlertFunctionalityGroup.Controls.Add(this.groupBox4);
            this.AlertFunctionalityGroup.Controls.Add(this.groupBox2);
            this.AlertFunctionalityGroup.Controls.Add(this.groupBox1);
            this.AlertFunctionalityGroup.ForeColor = System.Drawing.Color.White;
            this.AlertFunctionalityGroup.Location = new System.Drawing.Point(12, 12);
            this.AlertFunctionalityGroup.Name = "AlertFunctionalityGroup";
            this.AlertFunctionalityGroup.Size = new System.Drawing.Size(310, 326);
            this.AlertFunctionalityGroup.TabIndex = 2;
            this.AlertFunctionalityGroup.TabStop = false;
            this.AlertFunctionalityGroup.Text = "Alert Functionality";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(160, 301);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Check Interval";
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.discardFirstAlertsBox);
            this.groupBox11.Controls.Add(this.weaOnlyBox);
            this.groupBox11.ForeColor = System.Drawing.Color.White;
            this.groupBox11.Location = new System.Drawing.Point(6, 246);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(148, 74);
            this.groupBox11.TabIndex = 6;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Message Extras";
            // 
            // discardFirstAlertsBox
            // 
            this.discardFirstAlertsBox.AutoSize = true;
            this.discardFirstAlertsBox.Location = new System.Drawing.Point(6, 45);
            this.discardFirstAlertsBox.Name = "discardFirstAlertsBox";
            this.discardFirstAlertsBox.Size = new System.Drawing.Size(129, 19);
            this.discardFirstAlertsBox.TabIndex = 18;
            this.discardFirstAlertsBox.Text = "Discard all on start";
            this.discardFirstAlertsBox.UseVisualStyleBackColor = true;
            // 
            // weaOnlyBox
            // 
            this.weaOnlyBox.AutoSize = true;
            this.weaOnlyBox.Location = new System.Drawing.Point(6, 20);
            this.weaOnlyBox.Name = "weaOnlyBox";
            this.weaOnlyBox.Size = new System.Drawing.Size(76, 19);
            this.weaOnlyBox.TabIndex = 17;
            this.weaOnlyBox.Text = "WEA only";
            this.weaOnlyBox.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.urgencyUnknownBox);
            this.groupBox5.Controls.Add(this.urgencyPastBox);
            this.groupBox5.Controls.Add(this.urgencyFutureBox);
            this.groupBox5.Controls.Add(this.urgencyExpectedBox);
            this.groupBox5.Controls.Add(this.urgencyImmediateBox);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(160, 149);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(144, 143);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Message Urgency";
            // 
            // urgencyUnknownBox
            // 
            this.urgencyUnknownBox.AutoSize = true;
            this.urgencyUnknownBox.Location = new System.Drawing.Point(6, 120);
            this.urgencyUnknownBox.Name = "urgencyUnknownBox";
            this.urgencyUnknownBox.Size = new System.Drawing.Size(78, 19);
            this.urgencyUnknownBox.TabIndex = 16;
            this.urgencyUnknownBox.Text = "Unknown";
            this.urgencyUnknownBox.UseVisualStyleBackColor = true;
            // 
            // urgencyPastBox
            // 
            this.urgencyPastBox.AutoSize = true;
            this.urgencyPastBox.Location = new System.Drawing.Point(6, 95);
            this.urgencyPastBox.Name = "urgencyPastBox";
            this.urgencyPastBox.Size = new System.Drawing.Size(51, 19);
            this.urgencyPastBox.TabIndex = 15;
            this.urgencyPastBox.Text = "Past";
            this.urgencyPastBox.UseVisualStyleBackColor = true;
            // 
            // urgencyFutureBox
            // 
            this.urgencyFutureBox.AutoSize = true;
            this.urgencyFutureBox.Location = new System.Drawing.Point(6, 70);
            this.urgencyFutureBox.Name = "urgencyFutureBox";
            this.urgencyFutureBox.Size = new System.Drawing.Size(61, 19);
            this.urgencyFutureBox.TabIndex = 14;
            this.urgencyFutureBox.Text = "Future";
            this.urgencyFutureBox.UseVisualStyleBackColor = true;
            // 
            // urgencyExpectedBox
            // 
            this.urgencyExpectedBox.AutoSize = true;
            this.urgencyExpectedBox.Location = new System.Drawing.Point(6, 45);
            this.urgencyExpectedBox.Name = "urgencyExpectedBox";
            this.urgencyExpectedBox.Size = new System.Drawing.Size(76, 19);
            this.urgencyExpectedBox.TabIndex = 13;
            this.urgencyExpectedBox.Text = "Expected";
            this.urgencyExpectedBox.UseVisualStyleBackColor = true;
            // 
            // urgencyImmediateBox
            // 
            this.urgencyImmediateBox.AutoSize = true;
            this.urgencyImmediateBox.Location = new System.Drawing.Point(6, 20);
            this.urgencyImmediateBox.Name = "urgencyImmediateBox";
            this.urgencyImmediateBox.Size = new System.Drawing.Size(85, 19);
            this.urgencyImmediateBox.TabIndex = 12;
            this.urgencyImmediateBox.Text = "Immediate";
            this.urgencyImmediateBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.severityUnknownBox);
            this.groupBox4.Controls.Add(this.severityMinorBox);
            this.groupBox4.Controls.Add(this.severityModerateBox);
            this.groupBox4.Controls.Add(this.severitySevereBox);
            this.groupBox4.Controls.Add(this.severityExtremeBox);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(6, 94);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(148, 146);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Message Severity";
            // 
            // severityUnknownBox
            // 
            this.severityUnknownBox.AutoSize = true;
            this.severityUnknownBox.Location = new System.Drawing.Point(6, 120);
            this.severityUnknownBox.Name = "severityUnknownBox";
            this.severityUnknownBox.Size = new System.Drawing.Size(78, 19);
            this.severityUnknownBox.TabIndex = 11;
            this.severityUnknownBox.Text = "Unknown";
            this.severityUnknownBox.UseVisualStyleBackColor = true;
            // 
            // severityMinorBox
            // 
            this.severityMinorBox.AutoSize = true;
            this.severityMinorBox.Location = new System.Drawing.Point(6, 95);
            this.severityMinorBox.Name = "severityMinorBox";
            this.severityMinorBox.Size = new System.Drawing.Size(56, 19);
            this.severityMinorBox.TabIndex = 10;
            this.severityMinorBox.Text = "Minor";
            this.severityMinorBox.UseVisualStyleBackColor = true;
            // 
            // severityModerateBox
            // 
            this.severityModerateBox.AutoSize = true;
            this.severityModerateBox.Location = new System.Drawing.Point(6, 70);
            this.severityModerateBox.Name = "severityModerateBox";
            this.severityModerateBox.Size = new System.Drawing.Size(77, 19);
            this.severityModerateBox.TabIndex = 9;
            this.severityModerateBox.Text = "Moderate";
            this.severityModerateBox.UseVisualStyleBackColor = true;
            // 
            // severitySevereBox
            // 
            this.severitySevereBox.AutoSize = true;
            this.severitySevereBox.Location = new System.Drawing.Point(6, 45);
            this.severitySevereBox.Name = "severitySevereBox";
            this.severitySevereBox.Size = new System.Drawing.Size(64, 19);
            this.severitySevereBox.TabIndex = 8;
            this.severitySevereBox.Text = "Severe";
            this.severitySevereBox.UseVisualStyleBackColor = true;
            // 
            // severityExtremeBox
            // 
            this.severityExtremeBox.AutoSize = true;
            this.severityExtremeBox.Location = new System.Drawing.Point(6, 20);
            this.severityExtremeBox.Name = "severityExtremeBox";
            this.severityExtremeBox.Size = new System.Drawing.Size(71, 19);
            this.severityExtremeBox.TabIndex = 7;
            this.severityExtremeBox.Text = "Extreme";
            this.severityExtremeBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.messageTypeTestBox);
            this.groupBox2.Controls.Add(this.messageTypeCancelBox);
            this.groupBox2.Controls.Add(this.messageTypeUpdateBox);
            this.groupBox2.Controls.Add(this.messageTypeAlertBox);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(160, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(144, 123);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message Type";
            // 
            // messageTypeTestBox
            // 
            this.messageTypeTestBox.AutoSize = true;
            this.messageTypeTestBox.Location = new System.Drawing.Point(6, 95);
            this.messageTypeTestBox.Name = "messageTypeTestBox";
            this.messageTypeTestBox.Size = new System.Drawing.Size(49, 19);
            this.messageTypeTestBox.TabIndex = 6;
            this.messageTypeTestBox.Text = "Test";
            this.messageTypeTestBox.UseVisualStyleBackColor = true;
            // 
            // messageTypeCancelBox
            // 
            this.messageTypeCancelBox.AutoSize = true;
            this.messageTypeCancelBox.Location = new System.Drawing.Point(6, 70);
            this.messageTypeCancelBox.Name = "messageTypeCancelBox";
            this.messageTypeCancelBox.Size = new System.Drawing.Size(65, 19);
            this.messageTypeCancelBox.TabIndex = 5;
            this.messageTypeCancelBox.Text = "Cancel";
            this.messageTypeCancelBox.UseVisualStyleBackColor = true;
            // 
            // messageTypeUpdateBox
            // 
            this.messageTypeUpdateBox.AutoSize = true;
            this.messageTypeUpdateBox.Location = new System.Drawing.Point(6, 45);
            this.messageTypeUpdateBox.Name = "messageTypeUpdateBox";
            this.messageTypeUpdateBox.Size = new System.Drawing.Size(66, 19);
            this.messageTypeUpdateBox.TabIndex = 4;
            this.messageTypeUpdateBox.Text = "Update";
            this.messageTypeUpdateBox.UseVisualStyleBackColor = true;
            // 
            // messageTypeAlertBox
            // 
            this.messageTypeAlertBox.AutoSize = true;
            this.messageTypeAlertBox.Location = new System.Drawing.Point(6, 20);
            this.messageTypeAlertBox.Name = "messageTypeAlertBox";
            this.messageTypeAlertBox.Size = new System.Drawing.Size(50, 19);
            this.messageTypeAlertBox.TabIndex = 3;
            this.messageTypeAlertBox.Text = "Alert";
            this.messageTypeAlertBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusActualBox);
            this.groupBox1.Controls.Add(this.statusTestBox);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(6, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(148, 68);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Message Status";
            // 
            // statusActualBox
            // 
            this.statusActualBox.AutoSize = true;
            this.statusActualBox.Location = new System.Drawing.Point(6, 45);
            this.statusActualBox.Name = "statusActualBox";
            this.statusActualBox.Size = new System.Drawing.Size(59, 19);
            this.statusActualBox.TabIndex = 2;
            this.statusActualBox.Text = "Actual";
            this.statusActualBox.UseVisualStyleBackColor = true;
            // 
            // statusTestBox
            // 
            this.statusTestBox.AutoSize = true;
            this.statusTestBox.Location = new System.Drawing.Point(6, 20);
            this.statusTestBox.Name = "statusTestBox";
            this.statusTestBox.Size = new System.Drawing.Size(49, 19);
            this.statusTestBox.TabIndex = 1;
            this.statusTestBox.Text = "Test";
            this.statusTestBox.UseVisualStyleBackColor = true;
            // 
            // ConfigurationPanel
            // 
            this.ConfigurationPanel.Controls.Add(this.CacheOperationButton);
            this.ConfigurationPanel.Controls.Add(this.AlertFunctionalityGroup);
            this.ConfigurationPanel.Controls.Add(this.label10);
            this.ConfigurationPanel.Controls.Add(this.LocationsAndEventsGroup);
            this.ConfigurationPanel.Controls.Add(this.OpenCreditsButton);
            this.ConfigurationPanel.Controls.Add(this.PastAlertsGroup);
            this.ConfigurationPanel.Controls.Add(this.AlertAppearanceGroup);
            this.ConfigurationPanel.Controls.Add(this.DiscordWebhookGroup);
            this.ConfigurationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigurationPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfigurationPanel.Name = "ConfigurationPanel";
            this.ConfigurationPanel.Size = new System.Drawing.Size(671, 633);
            this.ConfigurationPanel.TabIndex = 13;
            // 
            // ConfigurationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(25)))));
            this.ClientSize = new System.Drawing.Size(671, 633);
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
            ((System.ComponentModel.ISupportInitialize)(this.AlertCheckIntervalInput)).EndInit();
            this.DiscordWebhookGroup.ResumeLayout(false);
            this.DiscordWebhookGroup.PerformLayout();
            this.AlertAppearanceGroup.ResumeLayout(false);
            this.AlertAppearanceGroup.PerformLayout();
            this.PastAlertsGroup.ResumeLayout(false);
            this.PastAlertsGroup.PerformLayout();
            this.LocationsAndEventsGroup.ResumeLayout(false);
            this.LocationsAndEventsGroup.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.AlertFunctionalityGroup.ResumeLayout(false);
            this.AlertFunctionalityGroup.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.GroupBox AlertAppearanceGroup;
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
        private System.Windows.Forms.GroupBox LocationsAndEventsGroup;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EventBlacklistOutput;
        private System.Windows.Forms.Button EventClearButton;
        private System.Windows.Forms.Button EventAddButton;
        private System.Windows.Forms.TextBox EventBlacklistInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox AreaUGCOutput;
        private System.Windows.Forms.Button UGCClearButton;
        private System.Windows.Forms.Button UGCAddButton;
        private System.Windows.Forms.TextBox AreaUGCInput;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox AreaSAMEOutput;
        private System.Windows.Forms.Button SAMEClearButton;
        private System.Windows.Forms.Button SAMEAddButton;
        private System.Windows.Forms.TextBox AreaSAMEInput;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox AlertFunctionalityGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown AlertCheckIntervalInput;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.CheckBox discardFirstAlertsBox;
        private System.Windows.Forms.CheckBox weaOnlyBox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.CheckBox urgencyUnknownBox;
        private System.Windows.Forms.CheckBox urgencyPastBox;
        private System.Windows.Forms.CheckBox urgencyFutureBox;
        private System.Windows.Forms.CheckBox urgencyExpectedBox;
        private System.Windows.Forms.CheckBox urgencyImmediateBox;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox severityUnknownBox;
        private System.Windows.Forms.CheckBox severityMinorBox;
        private System.Windows.Forms.CheckBox severityModerateBox;
        private System.Windows.Forms.CheckBox severitySevereBox;
        private System.Windows.Forms.CheckBox severityExtremeBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox messageTypeTestBox;
        private System.Windows.Forms.CheckBox messageTypeCancelBox;
        private System.Windows.Forms.CheckBox messageTypeUpdateBox;
        private System.Windows.Forms.CheckBox messageTypeAlertBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox statusActualBox;
        private System.Windows.Forms.CheckBox statusTestBox;
        private System.Windows.Forms.Button CacheOperationButton;
        private System.Windows.Forms.Panel ConfigurationPanel;
        private System.Windows.Forms.Label BusyLockText;
    }
}