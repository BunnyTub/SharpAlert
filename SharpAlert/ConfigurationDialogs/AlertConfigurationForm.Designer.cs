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
            RainbowText = new System.Windows.Forms.Label();
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
            discardFirstAlertsBox = new System.Windows.Forms.CheckBox();
            LocationsAndEventsGroup = new System.Windows.Forms.GroupBox();
            groupBox9 = new System.Windows.Forms.GroupBox();
            EventWhitelistModeBox = new System.Windows.Forms.CheckBox();
            NamedEventsInfoButton = new System.Windows.Forms.Button();
            EventSelectButton = new System.Windows.Forms.Button();
            EventAddButton = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            EventBlacklistOutput = new System.Windows.Forms.TextBox();
            EventBlacklistInput = new System.Windows.Forms.TextBox();
            EventClearButton = new System.Windows.Forms.Button();
            LocationsClearButton = new System.Windows.Forms.Button();
            LocationsButton = new System.Windows.Forms.Button();
            LanguageButton = new System.Windows.Forms.Button();
            StationButton = new System.Windows.Forms.Button();
            groupBox6 = new System.Windows.Forms.GroupBox();
            BypassAlertFilteringButton = new System.Windows.Forms.Button();
            label5 = new System.Windows.Forms.Label();
            alertNoRelayBox = new System.Windows.Forms.CheckBox();
            storedMaxSizeInput = new System.Windows.Forms.NumericUpDown();
            groupBox3 = new System.Windows.Forms.GroupBox();
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
            groupBox7 = new System.Windows.Forms.GroupBox();
            RainbowColoring = new System.Windows.Forms.Timer(components);
            AlertFunctionalityGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AlertDeadIntervalInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)AlertCheckIntervalInput).BeginInit();
            groupBox11.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            LocationsAndEventsGroup.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)storedMaxSizeInput).BeginInit();
            groupBox3.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // AlertFunctionalityGroup
            // 
            AlertFunctionalityGroup.Controls.Add(RainbowText);
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
            AlertFunctionalityGroup.Size = new System.Drawing.Size(342, 353);
            AlertFunctionalityGroup.TabIndex = 4;
            AlertFunctionalityGroup.TabStop = false;
            AlertFunctionalityGroup.Text = "Alert Filters";
            // 
            // RainbowText
            // 
            RainbowText.Cursor = System.Windows.Forms.Cursors.Hand;
            RainbowText.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            RainbowText.ForeColor = System.Drawing.Color.Red;
            RainbowText.Location = new System.Drawing.Point(160, 198);
            RainbowText.Name = "RainbowText";
            RainbowText.Size = new System.Drawing.Size(176, 98);
            RainbowText.TabIndex = 24;
            RainbowText.Text = "There's nothing here yet.\r\nFeel free to ask us about adding new features or changes into the program!";
            RainbowText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            RainbowText.Click += RainbowText_Click;
            // 
            // label7
            // 
            label7.Location = new System.Drawing.Point(160, 299);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(84, 21);
            label7.TabIndex = 23;
            label7.Text = "Check Time";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ToolTipInformation.SetToolTip(label7, ".");
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(160, 326);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(84, 21);
            label4.TabIndex = 10;
            label4.Text = "Dead Time";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ToolTipInformation.SetToolTip(label4, ".");
            // 
            // AlertDeadIntervalInput
            // 
            AlertDeadIntervalInput.BackColor = System.Drawing.Color.Black;
            AlertDeadIntervalInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            AlertDeadIntervalInput.ForeColor = System.Drawing.Color.White;
            AlertDeadIntervalInput.Location = new System.Drawing.Point(250, 326);
            AlertDeadIntervalInput.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            AlertDeadIntervalInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            AlertDeadIntervalInput.Name = "AlertDeadIntervalInput";
            AlertDeadIntervalInput.Size = new System.Drawing.Size(86, 21);
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
            AlertCheckIntervalInput.Location = new System.Drawing.Point(250, 299);
            AlertCheckIntervalInput.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            AlertCheckIntervalInput.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            AlertCheckIntervalInput.Name = "AlertCheckIntervalInput";
            AlertCheckIntervalInput.Size = new System.Drawing.Size(86, 21);
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
            groupBox11.Size = new System.Drawing.Size(148, 149);
            groupBox11.TabIndex = 6;
            groupBox11.TabStop = false;
            groupBox11.Text = "Message Extras";
            // 
            // IgnoreKeepAliveBox
            // 
            IgnoreKeepAliveBox.AutoSize = true;
            IgnoreKeepAliveBox.Location = new System.Drawing.Point(6, 70);
            IgnoreKeepAliveBox.Name = "IgnoreKeepAliveBox";
            IgnoreKeepAliveBox.Size = new System.Drawing.Size(119, 19);
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
            weaOnlyBox.Size = new System.Drawing.Size(121, 19);
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
            urgencyUnknownBox.Size = new System.Drawing.Size(78, 19);
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
            urgencyPastBox.Size = new System.Drawing.Size(51, 19);
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
            urgencyFutureBox.Size = new System.Drawing.Size(61, 19);
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
            urgencyExpectedBox.Size = new System.Drawing.Size(76, 19);
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
            urgencyImmediateBox.Size = new System.Drawing.Size(85, 19);
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
            severityUnknownBox.Size = new System.Drawing.Size(78, 19);
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
            severityMinorBox.Size = new System.Drawing.Size(56, 19);
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
            severitySevereBox.Size = new System.Drawing.Size(64, 19);
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
            severityExtremeBox.Size = new System.Drawing.Size(71, 19);
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
            messageTypeTestBox.Size = new System.Drawing.Size(49, 19);
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
            messageTypeCancelBox.Size = new System.Drawing.Size(65, 19);
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
            messageTypeUpdateBox.Size = new System.Drawing.Size(66, 19);
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
            messageTypeAlertBox.Size = new System.Drawing.Size(50, 19);
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
            statusExerciseBox.Size = new System.Drawing.Size(73, 19);
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
            statusActualBox.Size = new System.Drawing.Size(59, 19);
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
            statusTestBox.Size = new System.Drawing.Size(49, 19);
            statusTestBox.TabIndex = 3;
            statusTestBox.Text = "Test";
            ToolTipInformation.SetToolTip(statusTestBox, "Allow messages with this status.");
            statusTestBox.UseVisualStyleBackColor = true;
            // 
            // discardFirstAlertsBox
            // 
            discardFirstAlertsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            discardFirstAlertsBox.Location = new System.Drawing.Point(3, 17);
            discardFirstAlertsBox.Name = "discardFirstAlertsBox";
            discardFirstAlertsBox.Size = new System.Drawing.Size(151, 23);
            discardFirstAlertsBox.TabIndex = 10;
            discardFirstAlertsBox.Text = "Ignore first alerts";
            ToolTipInformation.SetToolTip(discardFirstAlertsBox, "Throw all alerts into the history instead of the queue on startup.");
            discardFirstAlertsBox.UseVisualStyleBackColor = true;
            // 
            // LocationsAndEventsGroup
            // 
            LocationsAndEventsGroup.Controls.Add(groupBox9);
            LocationsAndEventsGroup.ForeColor = System.Drawing.Color.White;
            LocationsAndEventsGroup.Location = new System.Drawing.Point(360, 142);
            LocationsAndEventsGroup.Name = "LocationsAndEventsGroup";
            LocationsAndEventsGroup.Size = new System.Drawing.Size(331, 120);
            LocationsAndEventsGroup.TabIndex = 5;
            LocationsAndEventsGroup.TabStop = false;
            LocationsAndEventsGroup.Text = "Event Filters";
            // 
            // groupBox9
            // 
            groupBox9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox9.Controls.Add(EventWhitelistModeBox);
            groupBox9.Controls.Add(NamedEventsInfoButton);
            groupBox9.Controls.Add(EventSelectButton);
            groupBox9.Controls.Add(EventAddButton);
            groupBox9.Controls.Add(label3);
            groupBox9.Controls.Add(EventBlacklistOutput);
            groupBox9.Controls.Add(EventBlacklistInput);
            groupBox9.Controls.Add(EventClearButton);
            groupBox9.ForeColor = System.Drawing.Color.White;
            groupBox9.Location = new System.Drawing.Point(6, 20);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new System.Drawing.Size(319, 93);
            groupBox9.TabIndex = 4;
            groupBox9.TabStop = false;
            groupBox9.Text = "Named Events";
            // 
            // EventWhitelistModeBox
            // 
            EventWhitelistModeBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            EventWhitelistModeBox.AutoSize = true;
            EventWhitelistModeBox.Location = new System.Drawing.Point(169, 16);
            EventWhitelistModeBox.Name = "EventWhitelistModeBox";
            EventWhitelistModeBox.Size = new System.Drawing.Size(108, 19);
            EventWhitelistModeBox.TabIndex = 54;
            EventWhitelistModeBox.Text = "Whitelist mode";
            ToolTipInformation.SetToolTip(EventWhitelistModeBox, "Treat this as a whitelist instead of a blacklist.");
            EventWhitelistModeBox.UseVisualStyleBackColor = true;
            // 
            // NamedEventsInfoButton
            // 
            NamedEventsInfoButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            NamedEventsInfoButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            NamedEventsInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            NamedEventsInfoButton.ForeColor = System.Drawing.Color.Yellow;
            NamedEventsInfoButton.Location = new System.Drawing.Point(290, 13);
            NamedEventsInfoButton.Name = "NamedEventsInfoButton";
            NamedEventsInfoButton.Size = new System.Drawing.Size(23, 23);
            NamedEventsInfoButton.TabIndex = 53;
            NamedEventsInfoButton.Text = "?";
            NamedEventsInfoButton.UseVisualStyleBackColor = false;
            NamedEventsInfoButton.Click += NamedEventsInfoButton_Click;
            // 
            // EventSelectButton
            // 
            EventSelectButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            EventSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EventSelectButton.Font = new System.Drawing.Font("Arial", 8F);
            EventSelectButton.Location = new System.Drawing.Point(102, 64);
            EventSelectButton.Name = "EventSelectButton";
            EventSelectButton.Size = new System.Drawing.Size(48, 23);
            EventSelectButton.TabIndex = 36;
            EventSelectButton.Text = "Select";
            EventSelectButton.UseVisualStyleBackColor = false;
            EventSelectButton.Click += EventSelectButton_Click;
            // 
            // EventAddButton
            // 
            EventAddButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            EventAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EventAddButton.Font = new System.Drawing.Font("Arial", 8F);
            EventAddButton.Location = new System.Drawing.Point(54, 64);
            EventAddButton.Name = "EventAddButton";
            EventAddButton.Size = new System.Drawing.Size(42, 23);
            EventAddButton.TabIndex = 35;
            EventAddButton.Text = "Add";
            EventAddButton.UseVisualStyleBackColor = false;
            EventAddButton.Click += EventAddButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 17);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(144, 15);
            label3.TabIndex = 6;
            label3.Text = "You can add events here.";
            // 
            // EventBlacklistOutput
            // 
            EventBlacklistOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            EventBlacklistOutput.BackColor = System.Drawing.Color.Black;
            EventBlacklistOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EventBlacklistOutput.Font = new System.Drawing.Font("Arial", 12F);
            EventBlacklistOutput.ForeColor = System.Drawing.Color.White;
            EventBlacklistOutput.Location = new System.Drawing.Point(169, 37);
            EventBlacklistOutput.Multiline = true;
            EventBlacklistOutput.Name = "EventBlacklistOutput";
            EventBlacklistOutput.ReadOnly = true;
            EventBlacklistOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            EventBlacklistOutput.Size = new System.Drawing.Size(144, 50);
            EventBlacklistOutput.TabIndex = 34;
            EventBlacklistOutput.WordWrap = false;
            // 
            // EventBlacklistInput
            // 
            EventBlacklistInput.BackColor = System.Drawing.Color.Black;
            EventBlacklistInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EventBlacklistInput.ForeColor = System.Drawing.Color.White;
            EventBlacklistInput.Location = new System.Drawing.Point(6, 37);
            EventBlacklistInput.Name = "EventBlacklistInput";
            EventBlacklistInput.Size = new System.Drawing.Size(144, 21);
            EventBlacklistInput.TabIndex = 31;
            // 
            // EventClearButton
            // 
            EventClearButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            EventClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EventClearButton.Font = new System.Drawing.Font("Arial", 8F);
            EventClearButton.Location = new System.Drawing.Point(6, 64);
            EventClearButton.Name = "EventClearButton";
            EventClearButton.Size = new System.Drawing.Size(42, 23);
            EventClearButton.TabIndex = 32;
            EventClearButton.Text = "Clear";
            EventClearButton.UseVisualStyleBackColor = false;
            EventClearButton.Click += EventClearButton_Click;
            // 
            // LocationsClearButton
            // 
            LocationsClearButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            LocationsClearButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            LocationsClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            LocationsClearButton.Font = new System.Drawing.Font("Arial", 12F);
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
            LocationsButton.Font = new System.Drawing.Font("Arial", 18F);
            LocationsButton.Location = new System.Drawing.Point(360, 58);
            LocationsButton.Name = "LocationsButton";
            LocationsButton.Size = new System.Drawing.Size(331, 40);
            LocationsButton.TabIndex = 36;
            LocationsButton.Text = "Location Manager";
            LocationsButton.UseVisualStyleBackColor = false;
            LocationsButton.Click += LocationsButton_Click;
            // 
            // LanguageButton
            // 
            LanguageButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            LanguageButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            LanguageButton.Font = new System.Drawing.Font("Arial", 8.8F);
            LanguageButton.Location = new System.Drawing.Point(534, 368);
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
            StationButton.Location = new System.Drawing.Point(534, 394);
            StationButton.Name = "StationButton";
            StationButton.Size = new System.Drawing.Size(157, 23);
            StationButton.TabIndex = 51;
            StationButton.Text = "Ownership Settings";
            StationButton.UseVisualStyleBackColor = false;
            StationButton.Click += StationButton_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(BypassAlertFilteringButton);
            groupBox6.Controls.Add(label5);
            groupBox6.Controls.Add(alertNoRelayBox);
            groupBox6.Controls.Add(storedMaxSizeInput);
            groupBox6.ForeColor = System.Drawing.Color.White;
            groupBox6.Location = new System.Drawing.Point(360, 268);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(331, 97);
            groupBox6.TabIndex = 17;
            groupBox6.TabStop = false;
            groupBox6.Text = "Miscellaneous";
            // 
            // BypassAlertFilteringButton
            // 
            BypassAlertFilteringButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            BypassAlertFilteringButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            BypassAlertFilteringButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            BypassAlertFilteringButton.Font = new System.Drawing.Font("Arial", 18F);
            BypassAlertFilteringButton.Location = new System.Drawing.Point(6, 45);
            BypassAlertFilteringButton.Name = "BypassAlertFilteringButton";
            BypassAlertFilteringButton.Size = new System.Drawing.Size(319, 46);
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
            label5.Size = new System.Drawing.Size(68, 15);
            label5.TabIndex = 9;
            label5.Text = "Cache size";
            // 
            // alertNoRelayBox
            // 
            alertNoRelayBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            alertNoRelayBox.AutoSize = true;
            alertNoRelayBox.Location = new System.Drawing.Point(199, 19);
            alertNoRelayBox.Name = "alertNoRelayBox";
            alertNoRelayBox.Size = new System.Drawing.Size(126, 19);
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
            storedMaxSizeInput.Size = new System.Drawing.Size(63, 21);
            storedMaxSizeInput.TabIndex = 35;
            ToolTipInformation.SetToolTip(storedMaxSizeInput, "Controls how many alerts can be cached for later usage.\r\nOlder alerts are trimmed first from history lists.");
            storedMaxSizeInput.Value = new decimal(new int[] { 1000, 0, 0, 0 });
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(CategoryInfoButton);
            groupBox3.Controls.Add(categoryOtherBox);
            groupBox3.Controls.Add(categoryCBRNEBox);
            groupBox3.Controls.Add(categoryInfraBox);
            groupBox3.Controls.Add(categoryTransportBox);
            groupBox3.Controls.Add(categoryEnvBox);
            groupBox3.Controls.Add(categoryHealthBox);
            groupBox3.Controls.Add(categoryFireBox);
            groupBox3.Controls.Add(categoryRescueBox);
            groupBox3.Controls.Add(categorySecurityBox);
            groupBox3.Controls.Add(categorySafetyBox);
            groupBox3.Controls.Add(categoryMetBox);
            groupBox3.Controls.Add(categoryGeoBox);
            groupBox3.ForeColor = System.Drawing.Color.White;
            groupBox3.Location = new System.Drawing.Point(12, 371);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(516, 95);
            groupBox3.TabIndex = 17;
            groupBox3.TabStop = false;
            groupBox3.Text = "Category Filters";
            ToolTipInformation.SetToolTip(groupBox3, "Do not change these unless you know what you are doing.\r\n\r\nAlerts can have categories embedded within them, to their specific event.\r\nSome alerts may have multiple categories for their event.");
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
            categoryOtherBox.Size = new System.Drawing.Size(111, 19);
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
            categoryCBRNEBox.Size = new System.Drawing.Size(91, 19);
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
            categoryInfraBox.Size = new System.Drawing.Size(67, 19);
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
            categoryTransportBox.Size = new System.Drawing.Size(106, 19);
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
            categoryEnvBox.Size = new System.Drawing.Size(105, 19);
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
            categoryFireBox.Size = new System.Drawing.Size(47, 19);
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
            categoryRescueBox.Size = new System.Drawing.Size(69, 19);
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
            categorySecurityBox.Size = new System.Drawing.Size(69, 19);
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
            categorySafetyBox.Size = new System.Drawing.Size(106, 19);
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
            categoryGeoBox.Size = new System.Drawing.Size(94, 19);
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
            AlertListButton.Font = new System.Drawing.Font("Arial", 18F);
            AlertListButton.Location = new System.Drawing.Point(360, 12);
            AlertListButton.Name = "AlertListButton";
            AlertListButton.Size = new System.Drawing.Size(250, 40);
            AlertListButton.TabIndex = 34;
            AlertListButton.Text = "Alert Manager";
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
            ArchiveSettingsButton.Font = new System.Drawing.Font("Arial", 9F);
            ArchiveSettingsButton.Location = new System.Drawing.Point(616, 12);
            ArchiveSettingsButton.Name = "ArchiveSettingsButton";
            ArchiveSettingsButton.Size = new System.Drawing.Size(75, 40);
            ArchiveSettingsButton.TabIndex = 35;
            ArchiveSettingsButton.Text = "Archive\r\nManager";
            ArchiveSettingsButton.UseVisualStyleBackColor = false;
            ArchiveSettingsButton.Click += ArchiveSettingsButton_Click;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(discardFirstAlertsBox);
            groupBox7.ForeColor = System.Drawing.Color.White;
            groupBox7.Location = new System.Drawing.Point(534, 423);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(157, 43);
            groupBox7.TabIndex = 53;
            groupBox7.TabStop = false;
            groupBox7.Text = "General Filters";
            // 
            // RainbowColoring
            // 
            RainbowColoring.Enabled = true;
            RainbowColoring.Interval = 50;
            RainbowColoring.Tick += RainbowColoring_Tick;
            // 
            // AlertConfigurationForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(703, 477);
            Controls.Add(groupBox7);
            Controls.Add(LanguageButton);
            Controls.Add(ArchiveSettingsButton);
            Controls.Add(StationButton);
            Controls.Add(AlertFunctionalityGroup);
            Controls.Add(groupBox6);
            Controls.Add(LocationsButton);
            Controls.Add(groupBox3);
            Controls.Add(AlertListButton);
            Controls.Add(LocationsClearButton);
            Controls.Add(LocationsAndEventsGroup);
            Font = new System.Drawing.Font("Arial", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AlertConfigurationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - CAP Settings";
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
            LocationsAndEventsGroup.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)storedMaxSizeInput).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox7.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox LocationsAndEventsGroup;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EventBlacklistOutput;
        private System.Windows.Forms.Button EventClearButton;
        private System.Windows.Forms.TextBox EventBlacklistInput;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.CheckBox statusExerciseBox;
        private System.Windows.Forms.GroupBox groupBox3;
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
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown storedMaxSizeInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown AlertDeadIntervalInput;
        private System.Windows.Forms.CheckBox messageTypeTestBox;
        private System.Windows.Forms.Button LanguageButton;
        private System.Windows.Forms.Button StationButton;
        private System.Windows.Forms.Button LocationsButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button EventAddButton;
        private System.Windows.Forms.CheckBox alertNoRelayBox;
        private System.Windows.Forms.Button LocationsClearButton;
        private System.Windows.Forms.Button AlertListButton;
        private System.Windows.Forms.Button EventSelectButton;
        private System.Windows.Forms.Button CategoryInfoButton;
        private System.Windows.Forms.Button BypassAlertFilteringButton;
        private System.Windows.Forms.Timer BypassFilteringFlasher;
        private System.Windows.Forms.Button NamedEventsInfoButton;
        private System.Windows.Forms.CheckBox EventWhitelistModeBox;
        private System.Windows.Forms.Button ArchiveSettingsButton;
        private System.Windows.Forms.CheckBox PreferCMAMTextWhereAvailableBox;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.CheckBox IgnoreKeepAliveBox;
        private System.Windows.Forms.Label RainbowText;
        private System.Windows.Forms.Timer RainbowColoring;
    }
}
