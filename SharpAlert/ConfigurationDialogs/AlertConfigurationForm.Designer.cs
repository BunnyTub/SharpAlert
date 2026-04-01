namespace SharpAlert.ConfigurationDialogs
{
    partial class AlertConfigurationForm
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertConfigurationForm));
            AlertFunctionalityGroup = new System.Windows.Forms.GroupBox();
            label7 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            AlertDeadIntervalInput = new System.Windows.Forms.NumericUpDown();
            AlertCheckIntervalInput = new System.Windows.Forms.NumericUpDown();
            groupBox11 = new System.Windows.Forms.GroupBox();
            IgnoreKeepAliveBox = new System.Windows.Forms.CheckBox();
            PreferCMAMTextWhereAvailableBox = new System.Windows.Forms.CheckBox();
            weaOnlyBox = new System.Windows.Forms.CheckBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            urgencyUnknownBox = new System.Windows.Forms.CheckBox();
            urgencyPastBox = new System.Windows.Forms.CheckBox();
            urgencyFutureBox = new System.Windows.Forms.CheckBox();
            urgencyExpectedBox = new System.Windows.Forms.CheckBox();
            urgencyImmediateBox = new System.Windows.Forms.CheckBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            severityUnknownBox = new System.Windows.Forms.CheckBox();
            severityMinorBox = new System.Windows.Forms.CheckBox();
            severityModerateBox = new System.Windows.Forms.CheckBox();
            severitySevereBox = new System.Windows.Forms.CheckBox();
            severityExtremeBox = new System.Windows.Forms.CheckBox();
            groupBox2 = new System.Windows.Forms.GroupBox();
            messageTypeTestBox = new System.Windows.Forms.CheckBox();
            messageTypeCancelBox = new System.Windows.Forms.CheckBox();
            messageTypeUpdateBox = new System.Windows.Forms.CheckBox();
            messageTypeAlertBox = new System.Windows.Forms.CheckBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            statusExerciseBox = new System.Windows.Forms.CheckBox();
            statusActualBox = new System.Windows.Forms.CheckBox();
            statusTestBox = new System.Windows.Forms.CheckBox();
            RainbowText = new System.Windows.Forms.Label();
            discardFirstAlertsBox = new System.Windows.Forms.CheckBox();
            LocationsClearButton = new System.Windows.Forms.Button();
            LocationsButton = new System.Windows.Forms.Button();
            LanguageButton = new System.Windows.Forms.Button();
            StationButton = new System.Windows.Forms.Button();
            MiscGroup = new System.Windows.Forms.GroupBox();
            BypassAlertFilteringButton = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            alertNoRelayBox = new System.Windows.Forms.CheckBox();
            storedMaxSizeInput = new System.Windows.Forms.NumericUpDown();
            CategoryGroup = new System.Windows.Forms.GroupBox();
            CategoryInfoButton = new System.Windows.Forms.Button();
            categoryOtherBox = new System.Windows.Forms.CheckBox();
            categoryCBRNEBox = new System.Windows.Forms.CheckBox();
            categoryInfraBox = new System.Windows.Forms.CheckBox();
            categoryTransportBox = new System.Windows.Forms.CheckBox();
            categoryEnvBox = new System.Windows.Forms.CheckBox();
            categoryHealthBox = new System.Windows.Forms.CheckBox();
            categoryFireBox = new System.Windows.Forms.CheckBox();
            categoryRescueBox = new System.Windows.Forms.CheckBox();
            categorySecurityBox = new System.Windows.Forms.CheckBox();
            categorySafetyBox = new System.Windows.Forms.CheckBox();
            categoryMetBox = new System.Windows.Forms.CheckBox();
            categoryGeoBox = new System.Windows.Forms.CheckBox();
            AlertListButton = new System.Windows.Forms.Button();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            BypassFilteringFlasher = new System.Windows.Forms.Timer(components);
            ArchiveSettingsButton = new System.Windows.Forms.Button();
            GeneralGroup = new System.Windows.Forms.GroupBox();
            RainbowColoring = new System.Windows.Forms.Timer(components);
            EventsButton = new System.Windows.Forms.Button();
            WindowShake = new System.Windows.Forms.Timer(components);
            AlertFunctionalityGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AlertDeadIntervalInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AlertCheckIntervalInput).BeginInit();
            groupBox11.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            MiscGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)storedMaxSizeInput).BeginInit();
            CategoryGroup.SuspendLayout();
            GeneralGroup.SuspendLayout();
            SuspendLayout();
            // 
            // AlertFunctionalityGroup
            // 
            AlertFunctionalityGroup.Controls.Add(label7);
            AlertFunctionalityGroup.Controls.Add(label4);
            AlertFunctionalityGroup.Controls.Add(AlertDeadIntervalInput);
            AlertFunctionalityGroup.Controls.Add(AlertCheckIntervalInput);
            AlertFunctionalityGroup.Controls.Add(groupBox11);
            AlertFunctionalityGroup.Controls.Add(groupBox5);
            AlertFunctionalityGroup.Controls.Add(groupBox4);
            AlertFunctionalityGroup.Controls.Add(groupBox2);
            AlertFunctionalityGroup.Controls.Add(groupBox1);
            AlertFunctionalityGroup.ForeColor = System.Drawing.Color.White;
            AlertFunctionalityGroup.Location = new System.Drawing.Point(12, 12);
            AlertFunctionalityGroup.Name = "AlertFunctionalityGroup";
            AlertFunctionalityGroup.Size = new System.Drawing.Size(342, 302);
            AlertFunctionalityGroup.TabIndex = 4;
            AlertFunctionalityGroup.TabStop = false;
            AlertFunctionalityGroup.Text = "Alert Filters";
            // 
            // label7
            // 
            label7.Location = new System.Drawing.Point(160, 195);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(176, 21);
            label7.TabIndex = 23;
            label7.Text = "Alert Check Spacing (seconds)";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(160, 245);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(176, 21);
            label4.TabIndex = 10;
            label4.Text = "Alert Shown Spacing (seconds)";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlertDeadIntervalInput
            // 
            AlertDeadIntervalInput.BackColor = System.Drawing.Color.Black;
            AlertDeadIntervalInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            AlertDeadIntervalInput.ForeColor = System.Drawing.Color.White;
            AlertDeadIntervalInput.Location = new System.Drawing.Point(160, 269);
            AlertDeadIntervalInput.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            AlertDeadIntervalInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            AlertDeadIntervalInput.Name = "AlertDeadIntervalInput";
            AlertDeadIntervalInput.Size = new System.Drawing.Size(176, 23);
            AlertDeadIntervalInput.TabIndex = 21;
            ToolTipInformation.SetToolTip(AlertDeadIntervalInput, "The amount of seconds to pause until the next alert can be shown.\r\nThis setting is ignored for earthquake alerts from SASMEX.");
            AlertDeadIntervalInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // AlertCheckIntervalInput
            // 
            AlertCheckIntervalInput.BackColor = System.Drawing.Color.Black;
            AlertCheckIntervalInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            AlertCheckIntervalInput.ForeColor = System.Drawing.Color.White;
            AlertCheckIntervalInput.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            AlertCheckIntervalInput.Location = new System.Drawing.Point(160, 219);
            AlertCheckIntervalInput.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            AlertCheckIntervalInput.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            AlertCheckIntervalInput.Name = "AlertCheckIntervalInput";
            AlertCheckIntervalInput.Size = new System.Drawing.Size(176, 23);
            AlertCheckIntervalInput.TabIndex = 20;
            ToolTipInformation.SetToolTip(AlertCheckIntervalInput, "The amount of seconds until the next server check.\r\n\r\nThis option only affects servers that can be polled from.\r\nTCP servers send data at their own specified intervals, and cannot be changed.");
            AlertCheckIntervalInput.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // groupBox11
            // 
            groupBox11.Controls.Add(IgnoreKeepAliveBox);
            groupBox11.Controls.Add(PreferCMAMTextWhereAvailableBox);
            groupBox11.Controls.Add(weaOnlyBox);
            groupBox11.ForeColor = System.Drawing.Color.White;
            groupBox11.Location = new System.Drawing.Point(6, 198);
            groupBox11.Name = "groupBox11";
            groupBox11.Size = new System.Drawing.Size(148, 98);
            groupBox11.TabIndex = 6;
            groupBox11.TabStop = false;
            groupBox11.Text = "Message Extras";
            // 
            // IgnoreKeepAliveBox
            // 
            IgnoreKeepAliveBox.AutoSize = true;
            IgnoreKeepAliveBox.Location = new System.Drawing.Point(6, 70);
            IgnoreKeepAliveBox.Name = "IgnoreKeepAliveBox";
            IgnoreKeepAliveBox.Size = new System.Drawing.Size(115, 19);
            IgnoreKeepAliveBox.TabIndex = 12;
            IgnoreKeepAliveBox.Text = "Ignore keep alive";
            ToolTipInformation.SetToolTip(IgnoreKeepAliveBox, "Ignores any CAP alerts with \"keepalive\" (one-word, case-insensitive) in the identifier.");
            IgnoreKeepAliveBox.UseVisualStyleBackColor = true;
            // 
            // PreferCMAMTextWhereAvailableBox
            // 
            PreferCMAMTextWhereAvailableBox.AutoSize = true;
            PreferCMAMTextWhereAvailableBox.Location = new System.Drawing.Point(6, 45);
            PreferCMAMTextWhereAvailableBox.Name = "PreferCMAMTextWhereAvailableBox";
            PreferCMAMTextWhereAvailableBox.Size = new System.Drawing.Size(118, 19);
            PreferCMAMTextWhereAvailableBox.TabIndex = 11;
            PreferCMAMTextWhereAvailableBox.Text = "Favor mobile text";
            ToolTipInformation.SetToolTip(PreferCMAMTextWhereAvailableBox, "Favors mobile text where available instead of the alert description and instruction text.");
            PreferCMAMTextWhereAvailableBox.UseVisualStyleBackColor = true;
            // 
            // weaOnlyBox
            // 
            weaOnlyBox.AutoSize = true;
            weaOnlyBox.Location = new System.Drawing.Point(6, 20);
            weaOnlyBox.Name = "weaOnlyBox";
            weaOnlyBox.Size = new System.Drawing.Size(120, 19);
            weaOnlyBox.TabIndex = 9;
            weaOnlyBox.Text = "Mobile alerts only";
            ToolTipInformation.SetToolTip(weaOnlyBox, "Filter out all alerts except mobile alerts.\r\nThis may cause issues with alerts from other sources than IPAWS and NAADS.");
            weaOnlyBox.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(urgencyUnknownBox);
            groupBox5.Controls.Add(urgencyPastBox);
            groupBox5.Controls.Add(urgencyFutureBox);
            groupBox5.Controls.Add(urgencyExpectedBox);
            groupBox5.Controls.Add(urgencyImmediateBox);
            groupBox5.ForeColor = System.Drawing.Color.White;
            groupBox5.Location = new System.Drawing.Point(160, 96);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(176, 96);
            groupBox5.TabIndex = 4;
            groupBox5.TabStop = false;
            groupBox5.Text = "Message Urgency";
            // 
            // urgencyUnknownBox
            // 
            urgencyUnknownBox.AutoSize = true;
            urgencyUnknownBox.Location = new System.Drawing.Point(6, 70);
            urgencyUnknownBox.Name = "urgencyUnknownBox";
            urgencyUnknownBox.Size = new System.Drawing.Size(77, 19);
            urgencyUnknownBox.TabIndex = 19;
            urgencyUnknownBox.Text = "Unknown";
            ToolTipInformation.SetToolTip(urgencyUnknownBox, "Allow messages with the following urgency.");
            urgencyUnknownBox.UseVisualStyleBackColor = true;
            // 
            // urgencyPastBox
            // 
            urgencyPastBox.AutoSize = true;
            urgencyPastBox.Location = new System.Drawing.Point(97, 45);
            urgencyPastBox.Name = "urgencyPastBox";
            urgencyPastBox.Size = new System.Drawing.Size(48, 19);
            urgencyPastBox.TabIndex = 18;
            urgencyPastBox.Text = "Past";
            ToolTipInformation.SetToolTip(urgencyPastBox, "Allow messages with the following urgency.");
            urgencyPastBox.UseVisualStyleBackColor = true;
            // 
            // urgencyFutureBox
            // 
            urgencyFutureBox.AutoSize = true;
            urgencyFutureBox.Location = new System.Drawing.Point(6, 45);
            urgencyFutureBox.Name = "urgencyFutureBox";
            urgencyFutureBox.Size = new System.Drawing.Size(60, 19);
            urgencyFutureBox.TabIndex = 17;
            urgencyFutureBox.Text = "Future";
            ToolTipInformation.SetToolTip(urgencyFutureBox, "Allow messages with the following urgency.");
            urgencyFutureBox.UseVisualStyleBackColor = true;
            // 
            // urgencyExpectedBox
            // 
            urgencyExpectedBox.AutoSize = true;
            urgencyExpectedBox.Location = new System.Drawing.Point(97, 20);
            urgencyExpectedBox.Name = "urgencyExpectedBox";
            urgencyExpectedBox.Size = new System.Drawing.Size(74, 19);
            urgencyExpectedBox.TabIndex = 16;
            urgencyExpectedBox.Text = "Expected";
            ToolTipInformation.SetToolTip(urgencyExpectedBox, "Allow messages with the following urgency.");
            urgencyExpectedBox.UseVisualStyleBackColor = true;
            // 
            // urgencyImmediateBox
            // 
            urgencyImmediateBox.AutoSize = true;
            urgencyImmediateBox.Location = new System.Drawing.Point(6, 20);
            urgencyImmediateBox.Name = "urgencyImmediateBox";
            urgencyImmediateBox.Size = new System.Drawing.Size(83, 19);
            urgencyImmediateBox.TabIndex = 15;
            urgencyImmediateBox.Text = "Immediate";
            ToolTipInformation.SetToolTip(urgencyImmediateBox, "Allow messages with the following urgency.");
            urgencyImmediateBox.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(severityUnknownBox);
            groupBox4.Controls.Add(severityMinorBox);
            groupBox4.Controls.Add(severityModerateBox);
            groupBox4.Controls.Add(severitySevereBox);
            groupBox4.Controls.Add(severityExtremeBox);
            groupBox4.ForeColor = System.Drawing.Color.White;
            groupBox4.Location = new System.Drawing.Point(6, 96);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(148, 96);
            groupBox4.TabIndex = 3;
            groupBox4.TabStop = false;
            groupBox4.Text = "Message Severity";
            // 
            // severityUnknownBox
            // 
            severityUnknownBox.AutoSize = true;
            severityUnknownBox.Location = new System.Drawing.Point(6, 70);
            severityUnknownBox.Name = "severityUnknownBox";
            severityUnknownBox.Size = new System.Drawing.Size(77, 19);
            severityUnknownBox.TabIndex = 8;
            severityUnknownBox.Text = "Unknown";
            ToolTipInformation.SetToolTip(severityUnknownBox, "Allow messages with this severity.");
            severityUnknownBox.UseVisualStyleBackColor = true;
            // 
            // severityMinorBox
            // 
            severityMinorBox.AutoSize = true;
            severityMinorBox.Location = new System.Drawing.Point(86, 45);
            severityMinorBox.Name = "severityMinorBox";
            severityMinorBox.Size = new System.Drawing.Size(58, 19);
            severityMinorBox.TabIndex = 7;
            severityMinorBox.Text = "Minor";
            ToolTipInformation.SetToolTip(severityMinorBox, "Allow messages with this severity.");
            severityMinorBox.UseVisualStyleBackColor = true;
            // 
            // severityModerateBox
            // 
            severityModerateBox.AutoSize = true;
            severityModerateBox.Location = new System.Drawing.Point(6, 45);
            severityModerateBox.Name = "severityModerateBox";
            severityModerateBox.Size = new System.Drawing.Size(77, 19);
            severityModerateBox.TabIndex = 6;
            severityModerateBox.Text = "Moderate";
            ToolTipInformation.SetToolTip(severityModerateBox, "Allow messages with this severity.");
            severityModerateBox.UseVisualStyleBackColor = true;
            // 
            // severitySevereBox
            // 
            severitySevereBox.AutoSize = true;
            severitySevereBox.Location = new System.Drawing.Point(78, 20);
            severitySevereBox.Name = "severitySevereBox";
            severitySevereBox.Size = new System.Drawing.Size(60, 19);
            severitySevereBox.TabIndex = 5;
            severitySevereBox.Text = "Severe";
            ToolTipInformation.SetToolTip(severitySevereBox, "Allow messages with this severity.");
            severitySevereBox.UseVisualStyleBackColor = true;
            // 
            // severityExtremeBox
            // 
            severityExtremeBox.AutoSize = true;
            severityExtremeBox.Location = new System.Drawing.Point(6, 20);
            severityExtremeBox.Name = "severityExtremeBox";
            severityExtremeBox.Size = new System.Drawing.Size(69, 19);
            severityExtremeBox.TabIndex = 4;
            severityExtremeBox.Text = "Extreme";
            ToolTipInformation.SetToolTip(severityExtremeBox, "Allow messages with this severity.");
            severityExtremeBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(messageTypeTestBox);
            groupBox2.Controls.Add(messageTypeCancelBox);
            groupBox2.Controls.Add(messageTypeUpdateBox);
            groupBox2.Controls.Add(messageTypeAlertBox);
            groupBox2.ForeColor = System.Drawing.Color.White;
            groupBox2.Location = new System.Drawing.Point(160, 20);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(176, 70);
            groupBox2.TabIndex = 1;
            groupBox2.TabStop = false;
            groupBox2.Text = "Message Type";
            // 
            // messageTypeTestBox
            // 
            messageTypeTestBox.AutoSize = true;
            messageTypeTestBox.Location = new System.Drawing.Point(79, 45);
            messageTypeTestBox.Name = "messageTypeTestBox";
            messageTypeTestBox.Size = new System.Drawing.Size(46, 19);
            messageTypeTestBox.TabIndex = 14;
            messageTypeTestBox.Text = "Test";
            ToolTipInformation.SetToolTip(messageTypeTestBox, "Allow messages of the following type.\r\nTake note! This differs from the message status variant of the same name, and is primarily used in CAP-CP (NAADS) messages.");
            messageTypeTestBox.UseVisualStyleBackColor = true;
            // 
            // messageTypeCancelBox
            // 
            messageTypeCancelBox.AutoSize = true;
            messageTypeCancelBox.Location = new System.Drawing.Point(79, 20);
            messageTypeCancelBox.Name = "messageTypeCancelBox";
            messageTypeCancelBox.Size = new System.Drawing.Size(62, 19);
            messageTypeCancelBox.TabIndex = 13;
            messageTypeCancelBox.Text = "Cancel";
            ToolTipInformation.SetToolTip(messageTypeCancelBox, "Allow messages of the following type.");
            messageTypeCancelBox.UseVisualStyleBackColor = true;
            // 
            // messageTypeUpdateBox
            // 
            messageTypeUpdateBox.AutoSize = true;
            messageTypeUpdateBox.Location = new System.Drawing.Point(6, 45);
            messageTypeUpdateBox.Name = "messageTypeUpdateBox";
            messageTypeUpdateBox.Size = new System.Drawing.Size(64, 19);
            messageTypeUpdateBox.TabIndex = 12;
            messageTypeUpdateBox.Text = "Update";
            ToolTipInformation.SetToolTip(messageTypeUpdateBox, "Allow messages of the following type.");
            messageTypeUpdateBox.UseVisualStyleBackColor = true;
            // 
            // messageTypeAlertBox
            // 
            messageTypeAlertBox.AutoSize = true;
            messageTypeAlertBox.Location = new System.Drawing.Point(6, 20);
            messageTypeAlertBox.Name = "messageTypeAlertBox";
            messageTypeAlertBox.Size = new System.Drawing.Size(51, 19);
            messageTypeAlertBox.TabIndex = 11;
            messageTypeAlertBox.Text = "Alert";
            ToolTipInformation.SetToolTip(messageTypeAlertBox, "Allow messages of the following type.");
            messageTypeAlertBox.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(statusExerciseBox);
            groupBox1.Controls.Add(statusActualBox);
            groupBox1.Controls.Add(statusTestBox);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(6, 20);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(148, 70);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Message Status";
            // 
            // statusExerciseBox
            // 
            statusExerciseBox.AutoSize = true;
            statusExerciseBox.Location = new System.Drawing.Point(69, 20);
            statusExerciseBox.Name = "statusExerciseBox";
            statusExerciseBox.Size = new System.Drawing.Size(68, 19);
            statusExerciseBox.TabIndex = 2;
            statusExerciseBox.Text = "Exercise";
            ToolTipInformation.SetToolTip(statusExerciseBox, "Allow messages with this status.");
            statusExerciseBox.UseVisualStyleBackColor = true;
            // 
            // statusActualBox
            // 
            statusActualBox.AutoSize = true;
            statusActualBox.Location = new System.Drawing.Point(6, 20);
            statusActualBox.Name = "statusActualBox";
            statusActualBox.Size = new System.Drawing.Size(60, 19);
            statusActualBox.TabIndex = 0;
            statusActualBox.Text = "Actual";
            ToolTipInformation.SetToolTip(statusActualBox, "Allow messages with this status.");
            statusActualBox.UseVisualStyleBackColor = true;
            // 
            // statusTestBox
            // 
            statusTestBox.AutoSize = true;
            statusTestBox.Location = new System.Drawing.Point(6, 45);
            statusTestBox.Name = "statusTestBox";
            statusTestBox.Size = new System.Drawing.Size(46, 19);
            statusTestBox.TabIndex = 3;
            statusTestBox.Text = "Test";
            ToolTipInformation.SetToolTip(statusTestBox, "Allow messages with this status.");
            statusTestBox.UseVisualStyleBackColor = true;
            // 
            // RainbowText
            // 
            RainbowText.Cursor = System.Windows.Forms.Cursors.Hand;
            RainbowText.Font = new System.Drawing.Font("Segoe UI", 9F);
            RainbowText.ForeColor = System.Drawing.Color.Red;
            RainbowText.Location = new System.Drawing.Point(360, 185);
            RainbowText.Name = "RainbowText";
            RainbowText.Size = new System.Drawing.Size(331, 52);
            RainbowText.TabIndex = 24;
            RainbowText.Text = "Tell us about your requests on features or to report problems and bugs by clicking here to go to our website.";
            RainbowText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RainbowText.Click += RainbowText_Click;
            // 
            // discardFirstAlertsBox
            // 
            discardFirstAlertsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            discardFirstAlertsBox.Location = new System.Drawing.Point(3, 19);
            discardFirstAlertsBox.Name = "discardFirstAlertsBox";
            discardFirstAlertsBox.Size = new System.Drawing.Size(151, 21);
            discardFirstAlertsBox.TabIndex = 10;
            discardFirstAlertsBox.Text = "Ignore first alerts";
            ToolTipInformation.SetToolTip(discardFirstAlertsBox, "Throw all alerts into the history instead of the queue on startup.");
            discardFirstAlertsBox.UseVisualStyleBackColor = true;
            // 
            // LocationsClearButton
            // 
            LocationsClearButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            LocationsClearButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            LocationsClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            LocationsClearButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            LocationsClearButton.Location = new System.Drawing.Point(360, 104);
            LocationsClearButton.Name = "LocationsClearButton";
            LocationsClearButton.Size = new System.Drawing.Size(331, 32);
            LocationsClearButton.TabIndex = 37;
            LocationsClearButton.Text = "Clear Locations";
            LocationsClearButton.UseVisualStyleBackColor = false;
            LocationsClearButton.Click += LocationsClearButton_Click;
            // 
            // LocationsButton
            // 
            LocationsButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            LocationsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            LocationsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            LocationsButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            LocationsButton.Location = new System.Drawing.Point(360, 58);
            LocationsButton.Name = "LocationsButton";
            LocationsButton.Size = new System.Drawing.Size(331, 40);
            LocationsButton.TabIndex = 36;
            LocationsButton.Text = "Manage Locations";
            LocationsButton.UseVisualStyleBackColor = false;
            LocationsButton.Click += LocationsButton_Click;
            // 
            // LanguageButton
            // 
            LanguageButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            LanguageButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            LanguageButton.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            LanguageButton.Location = new System.Drawing.Point(534, 317);
            LanguageButton.Margin = new System.Windows.Forms.Padding(0);
            LanguageButton.Name = "LanguageButton";
            LanguageButton.Size = new System.Drawing.Size(157, 23);
            LanguageButton.TabIndex = 52;
            LanguageButton.Text = "Language Settings";
            LanguageButton.UseVisualStyleBackColor = false;
            LanguageButton.Click += LanguageButton_Click;
            // 
            // StationButton
            // 
            StationButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            StationButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            StationButton.Location = new System.Drawing.Point(534, 343);
            StationButton.Name = "StationButton";
            StationButton.Size = new System.Drawing.Size(157, 23);
            StationButton.TabIndex = 51;
            StationButton.Text = "Ownership Settings";
            StationButton.UseVisualStyleBackColor = false;
            StationButton.Click += StationButton_Click;
            // 
            // MiscGroup
            // 
            MiscGroup.Controls.Add(BypassAlertFilteringButton);
            MiscGroup.Controls.Add(label5);
            MiscGroup.Controls.Add(alertNoRelayBox);
            MiscGroup.Controls.Add(storedMaxSizeInput);
            MiscGroup.ForeColor = System.Drawing.Color.White;
            MiscGroup.Location = new System.Drawing.Point(360, 240);
            MiscGroup.Name = "MiscGroup";
            MiscGroup.Size = new System.Drawing.Size(331, 74);
            MiscGroup.TabIndex = 17;
            MiscGroup.TabStop = false;
            MiscGroup.Text = "Miscellaneous";
            // 
            // BypassAlertFilteringButton
            // 
            BypassAlertFilteringButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            BypassAlertFilteringButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            BypassAlertFilteringButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            BypassAlertFilteringButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            BypassAlertFilteringButton.Location = new System.Drawing.Point(6, 45);
            BypassAlertFilteringButton.Name = "BypassAlertFilteringButton";
            BypassAlertFilteringButton.Size = new System.Drawing.Size(319, 23);
            BypassAlertFilteringButton.TabIndex = 38;
            BypassAlertFilteringButton.Text = "Bypass Alert Filtering";
            BypassAlertFilteringButton.UseVisualStyleBackColor = false;
            BypassAlertFilteringButton.Click += BypassAlertFilteringButton_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 21);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(62, 15);
            label5.TabIndex = 9;
            label5.Text = "Cache size";
            // 
            // alertNoRelayBox
            // 
            alertNoRelayBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            alertNoRelayBox.AutoSize = true;
            alertNoRelayBox.Location = new System.Drawing.Point(209, 19);
            alertNoRelayBox.Name = "alertNoRelayBox";
            alertNoRelayBox.Size = new System.Drawing.Size(116, 19);
            alertNoRelayBox.TabIndex = 16;
            alertNoRelayBox.Text = "Disable USB relay";
            ToolTipInformation.SetToolTip(alertNoRelayBox, "Stops USB relays from being triggered when alerts are being relayed.");
            alertNoRelayBox.UseVisualStyleBackColor = true;
            // 
            // storedMaxSizeInput
            // 
            storedMaxSizeInput.BackColor = System.Drawing.Color.Black;
            storedMaxSizeInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            storedMaxSizeInput.ForeColor = System.Drawing.Color.White;
            storedMaxSizeInput.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            storedMaxSizeInput.Location = new System.Drawing.Point(80, 18);
            storedMaxSizeInput.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            storedMaxSizeInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            storedMaxSizeInput.Name = "storedMaxSizeInput";
            storedMaxSizeInput.Size = new System.Drawing.Size(63, 23);
            storedMaxSizeInput.TabIndex = 35;
            ToolTipInformation.SetToolTip(storedMaxSizeInput, "Controls how many alerts can be cached for later usage.\r\nOlder alerts are trimmed first from history lists.");
            storedMaxSizeInput.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // CategoryGroup
            // 
            CategoryGroup.Controls.Add(CategoryInfoButton);
            CategoryGroup.Controls.Add(categoryOtherBox);
            CategoryGroup.Controls.Add(categoryCBRNEBox);
            CategoryGroup.Controls.Add(categoryInfraBox);
            CategoryGroup.Controls.Add(categoryTransportBox);
            CategoryGroup.Controls.Add(categoryEnvBox);
            CategoryGroup.Controls.Add(categoryHealthBox);
            CategoryGroup.Controls.Add(categoryFireBox);
            CategoryGroup.Controls.Add(categoryRescueBox);
            CategoryGroup.Controls.Add(categorySecurityBox);
            CategoryGroup.Controls.Add(categorySafetyBox);
            CategoryGroup.Controls.Add(categoryMetBox);
            CategoryGroup.Controls.Add(categoryGeoBox);
            CategoryGroup.ForeColor = System.Drawing.Color.White;
            CategoryGroup.Location = new System.Drawing.Point(12, 320);
            CategoryGroup.Name = "CategoryGroup";
            CategoryGroup.Size = new System.Drawing.Size(516, 95);
            CategoryGroup.TabIndex = 17;
            CategoryGroup.TabStop = false;
            CategoryGroup.Text = "Category Filters";
            ToolTipInformation.SetToolTip(CategoryGroup, "Do not change these unless you know what you are doing.\r\n\r\nAlerts can have categories embedded within them, to their specific event.\r\nSome alerts may have multiple categories for their event.");
            // 
            // CategoryInfoButton
            // 
            CategoryInfoButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            CategoryInfoButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            CategoryInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            CategoryInfoButton.ForeColor = System.Drawing.Color.Yellow;
            CategoryInfoButton.Location = new System.Drawing.Point(487, 14);
            CategoryInfoButton.Name = "CategoryInfoButton";
            CategoryInfoButton.Size = new System.Drawing.Size(23, 23);
            CategoryInfoButton.TabIndex = 52;
            CategoryInfoButton.Text = "?";
            CategoryInfoButton.UseVisualStyleBackColor = false;
            CategoryInfoButton.Click += CategoryInfoButton_Click;
            // 
            // categoryOtherBox
            // 
            categoryOtherBox.AutoSize = true;
            categoryOtherBox.Location = new System.Drawing.Point(374, 70);
            categoryOtherBox.Name = "categoryOtherBox";
            categoryOtherBox.Size = new System.Drawing.Size(112, 19);
            categoryOtherBox.TabIndex = 48;
            categoryOtherBox.Text = "Other/Unknown";
            ToolTipInformation.SetToolTip(categoryOtherBox, "Allow messages of the following category.");
            categoryOtherBox.UseVisualStyleBackColor = true;
            // 
            // categoryCBRNEBox
            // 
            categoryCBRNEBox.AutoSize = true;
            categoryCBRNEBox.Location = new System.Drawing.Point(374, 45);
            categoryCBRNEBox.Name = "categoryCBRNEBox";
            categoryCBRNEBox.Size = new System.Drawing.Size(89, 19);
            categoryCBRNEBox.TabIndex = 47;
            categoryCBRNEBox.Text = "Toxic Threat";
            ToolTipInformation.SetToolTip(categoryCBRNEBox, "Allow messages of the following category.");
            categoryCBRNEBox.UseVisualStyleBackColor = true;
            // 
            // categoryInfraBox
            // 
            categoryInfraBox.AutoSize = true;
            categoryInfraBox.Location = new System.Drawing.Point(374, 20);
            categoryInfraBox.Name = "categoryInfraBox";
            categoryInfraBox.Size = new System.Drawing.Size(65, 19);
            categoryInfraBox.TabIndex = 46;
            categoryInfraBox.Text = "Utilities";
            ToolTipInformation.SetToolTip(categoryInfraBox, "Allow messages of the following category.");
            categoryInfraBox.UseVisualStyleBackColor = true;
            // 
            // categoryTransportBox
            // 
            categoryTransportBox.AutoSize = true;
            categoryTransportBox.Location = new System.Drawing.Point(239, 70);
            categoryTransportBox.Name = "categoryTransportBox";
            categoryTransportBox.Size = new System.Drawing.Size(102, 19);
            categoryTransportBox.TabIndex = 45;
            categoryTransportBox.Text = "Transportation";
            ToolTipInformation.SetToolTip(categoryTransportBox, "Allow messages of the following category.");
            categoryTransportBox.UseVisualStyleBackColor = true;
            // 
            // categoryEnvBox
            // 
            categoryEnvBox.AutoSize = true;
            categoryEnvBox.Location = new System.Drawing.Point(239, 45);
            categoryEnvBox.Name = "categoryEnvBox";
            categoryEnvBox.Size = new System.Drawing.Size(103, 19);
            categoryEnvBox.TabIndex = 44;
            categoryEnvBox.Text = "Environmental";
            ToolTipInformation.SetToolTip(categoryEnvBox, "Allow messages of the following category.");
            categoryEnvBox.UseVisualStyleBackColor = true;
            // 
            // categoryHealthBox
            // 
            categoryHealthBox.AutoSize = true;
            categoryHealthBox.Location = new System.Drawing.Point(239, 20);
            categoryHealthBox.Name = "categoryHealthBox";
            categoryHealthBox.Size = new System.Drawing.Size(68, 19);
            categoryHealthBox.TabIndex = 43;
            categoryHealthBox.Text = "Medical";
            ToolTipInformation.SetToolTip(categoryHealthBox, "Allow messages of the following category.");
            categoryHealthBox.UseVisualStyleBackColor = true;
            // 
            // categoryFireBox
            // 
            categoryFireBox.AutoSize = true;
            categoryFireBox.Location = new System.Drawing.Point(138, 70);
            categoryFireBox.Name = "categoryFireBox";
            categoryFireBox.Size = new System.Drawing.Size(45, 19);
            categoryFireBox.TabIndex = 42;
            categoryFireBox.Text = "Fire";
            ToolTipInformation.SetToolTip(categoryFireBox, "Allow messages of the following category.");
            categoryFireBox.UseVisualStyleBackColor = true;
            // 
            // categoryRescueBox
            // 
            categoryRescueBox.AutoSize = true;
            categoryRescueBox.Location = new System.Drawing.Point(138, 45);
            categoryRescueBox.Name = "categoryRescueBox";
            categoryRescueBox.Size = new System.Drawing.Size(63, 19);
            categoryRescueBox.TabIndex = 41;
            categoryRescueBox.Text = "Rescue";
            ToolTipInformation.SetToolTip(categoryRescueBox, "Allow messages of the following category.");
            categoryRescueBox.UseVisualStyleBackColor = true;
            // 
            // categorySecurityBox
            // 
            categorySecurityBox.AutoSize = true;
            categorySecurityBox.Location = new System.Drawing.Point(138, 20);
            categorySecurityBox.Name = "categorySecurityBox";
            categorySecurityBox.Size = new System.Drawing.Size(68, 19);
            categorySecurityBox.TabIndex = 40;
            categorySecurityBox.Text = "Security";
            ToolTipInformation.SetToolTip(categorySecurityBox, "Allow messages of the following category.");
            categorySecurityBox.UseVisualStyleBackColor = true;
            // 
            // categorySafetyBox
            // 
            categorySafetyBox.AutoSize = true;
            categorySafetyBox.Location = new System.Drawing.Point(6, 70);
            categorySafetyBox.Name = "categorySafetyBox";
            categorySafetyBox.Size = new System.Drawing.Size(101, 19);
            categorySafetyBox.TabIndex = 39;
            categorySafetyBox.Text = "General Safety";
            ToolTipInformation.SetToolTip(categorySafetyBox, "Allow messages of the following category.");
            categorySafetyBox.UseVisualStyleBackColor = true;
            // 
            // categoryMetBox
            // 
            categoryMetBox.AutoSize = true;
            categoryMetBox.Location = new System.Drawing.Point(6, 45);
            categoryMetBox.Name = "categoryMetBox";
            categoryMetBox.Size = new System.Drawing.Size(106, 19);
            categoryMetBox.TabIndex = 38;
            categoryMetBox.Text = "Meteorological";
            ToolTipInformation.SetToolTip(categoryMetBox, "Allow messages of the following category.");
            categoryMetBox.UseVisualStyleBackColor = true;
            // 
            // categoryGeoBox
            // 
            categoryGeoBox.AutoSize = true;
            categoryGeoBox.Location = new System.Drawing.Point(6, 20);
            categoryGeoBox.Name = "categoryGeoBox";
            categoryGeoBox.Size = new System.Drawing.Size(90, 19);
            categoryGeoBox.TabIndex = 37;
            categoryGeoBox.Text = "Geophysical";
            ToolTipInformation.SetToolTip(categoryGeoBox, "Allow messages of the following category.");
            categoryGeoBox.UseVisualStyleBackColor = true;
            // 
            // AlertListButton
            // 
            AlertListButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AlertListButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            AlertListButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AlertListButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            AlertListButton.Location = new System.Drawing.Point(360, 12);
            AlertListButton.Name = "AlertListButton";
            AlertListButton.Size = new System.Drawing.Size(250, 40);
            AlertListButton.TabIndex = 34;
            AlertListButton.Text = "Manage Alerts";
            AlertListButton.UseVisualStyleBackColor = false;
            AlertListButton.Click += AlertListButton_Click;
            // 
            // ToolTipInformation
            // 
            ToolTipInformation.AutomaticDelay = 250;
            ToolTipInformation.AutoPopDelay = 15000;
            ToolTipInformation.BackColor = System.Drawing.Color.White;
            ToolTipInformation.ForeColor = System.Drawing.Color.Black;
            ToolTipInformation.InitialDelay = 250;
            ToolTipInformation.IsBalloon = true;
            ToolTipInformation.ReshowDelay = 50;
            ToolTipInformation.ToolTipTitle = "What does this do?";
            // 
            // BypassFilteringFlasher
            // 
            BypassFilteringFlasher.Interval = 500;
            BypassFilteringFlasher.Tick += BypassFilteringFlasher_Tick;
            // 
            // ArchiveSettingsButton
            // 
            ArchiveSettingsButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            ArchiveSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ArchiveSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ArchiveSettingsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            ArchiveSettingsButton.Location = new System.Drawing.Point(616, 12);
            ArchiveSettingsButton.Name = "ArchiveSettingsButton";
            ArchiveSettingsButton.Size = new System.Drawing.Size(75, 40);
            ArchiveSettingsButton.TabIndex = 35;
            ArchiveSettingsButton.Text = "Manage\r\nArchives";
            ArchiveSettingsButton.UseVisualStyleBackColor = false;
            ArchiveSettingsButton.Click += ArchiveSettingsButton_Click;
            // 
            // GeneralGroup
            // 
            GeneralGroup.Controls.Add(discardFirstAlertsBox);
            GeneralGroup.ForeColor = System.Drawing.Color.White;
            GeneralGroup.Location = new System.Drawing.Point(534, 372);
            GeneralGroup.Name = "GeneralGroup";
            GeneralGroup.Size = new System.Drawing.Size(157, 43);
            GeneralGroup.TabIndex = 53;
            GeneralGroup.TabStop = false;
            GeneralGroup.Text = "General Filters";
            // 
            // RainbowColoring
            // 
            RainbowColoring.Enabled = true;
            RainbowColoring.Interval = 60;
            RainbowColoring.Tick += RainbowColoring_Tick;
            // 
            // EventsButton
            // 
            EventsButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            EventsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            EventsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EventsButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            EventsButton.Location = new System.Drawing.Point(360, 142);
            EventsButton.Name = "EventsButton";
            EventsButton.Size = new System.Drawing.Size(331, 40);
            EventsButton.TabIndex = 54;
            EventsButton.Text = "Manage Events";
            EventsButton.UseVisualStyleBackColor = false;
            EventsButton.Click += EventsButton_Click;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // AlertConfigurationForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(703, 427);
            Controls.Add(EventsButton);
            Controls.Add(RainbowText);
            Controls.Add(GeneralGroup);
            Controls.Add(LanguageButton);
            Controls.Add(ArchiveSettingsButton);
            Controls.Add(StationButton);
            Controls.Add(AlertFunctionalityGroup);
            Controls.Add(MiscGroup);
            Controls.Add(LocationsButton);
            Controls.Add(CategoryGroup);
            Controls.Add(AlertListButton);
            Controls.Add(LocationsClearButton);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AlertConfigurationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Alert Settings (Advanced View)";
            HelpButtonClicked += AlertConfigurationForm_HelpButtonClicked;
            Load += AlertConfigurationForm_Load;
            AlertFunctionalityGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AlertDeadIntervalInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)AlertCheckIntervalInput).EndInit();
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            MiscGroup.ResumeLayout(false);
            MiscGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)storedMaxSizeInput).EndInit();
            CategoryGroup.ResumeLayout(false);
            CategoryGroup.PerformLayout();
            GeneralGroup.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox AlertFunctionalityGroup;
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
        private System.Windows.Forms.CheckBox messageTypeCancelBox;
        private System.Windows.Forms.CheckBox messageTypeUpdateBox;
        private System.Windows.Forms.CheckBox messageTypeAlertBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox statusActualBox;
        private System.Windows.Forms.CheckBox statusTestBox;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.CheckBox statusExerciseBox;
        private System.Windows.Forms.GroupBox CategoryGroup;
        private System.Windows.Forms.CheckBox categoryGeoBox;
        private System.Windows.Forms.CheckBox categorySafetyBox;
        private System.Windows.Forms.CheckBox categoryMetBox;
        private System.Windows.Forms.CheckBox categorySecurityBox;
        private System.Windows.Forms.CheckBox categoryHealthBox;
        private System.Windows.Forms.CheckBox categoryFireBox;
        private System.Windows.Forms.CheckBox categoryRescueBox;
        private System.Windows.Forms.CheckBox categoryTransportBox;
        private System.Windows.Forms.CheckBox categoryEnvBox;
        private System.Windows.Forms.CheckBox categoryInfraBox;
        private System.Windows.Forms.CheckBox categoryCBRNEBox;
        private System.Windows.Forms.CheckBox categoryOtherBox;
        private System.Windows.Forms.GroupBox MiscGroup;
        private System.Windows.Forms.NumericUpDown storedMaxSizeInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown AlertDeadIntervalInput;
        private System.Windows.Forms.CheckBox messageTypeTestBox;
        private System.Windows.Forms.Button LanguageButton;
        private System.Windows.Forms.Button StationButton;
        private System.Windows.Forms.Button LocationsButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox alertNoRelayBox;
        private System.Windows.Forms.Button LocationsClearButton;
        private System.Windows.Forms.Button AlertListButton;
        private System.Windows.Forms.Button CategoryInfoButton;
        private System.Windows.Forms.Button BypassAlertFilteringButton;
        private System.Windows.Forms.Timer BypassFilteringFlasher;
        private System.Windows.Forms.Button ArchiveSettingsButton;
        private System.Windows.Forms.CheckBox PreferCMAMTextWhereAvailableBox;
        private System.Windows.Forms.GroupBox GeneralGroup;
        private System.Windows.Forms.CheckBox IgnoreKeepAliveBox;
        private System.Windows.Forms.Label RainbowText;
        private System.Windows.Forms.Timer RainbowColoring;
        private System.Windows.Forms.Button EventsButton;
        private System.Windows.Forms.Timer WindowShake;
    }
}
