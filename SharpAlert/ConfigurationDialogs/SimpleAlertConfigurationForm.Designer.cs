namespace SharpAlert.ConfigurationDialogs
{
    partial class SimpleAlertConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleAlertConfigurationForm));
            AlertFunctionalityGroup = new System.Windows.Forms.GroupBox();
            label7 = new System.Windows.Forms.Label();
            GeneralGroup = new System.Windows.Forms.GroupBox();
            discardFirstAlertsBox = new System.Windows.Forms.CheckBox();
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
            LocationsClearButton = new System.Windows.Forms.Button();
            LocationsButton = new System.Windows.Forms.Button();
            AlertListButton = new System.Windows.Forms.Button();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            RainbowColoring = new System.Windows.Forms.Timer(components);
            EventsButton = new System.Windows.Forms.Button();
            AdvancedDisclaimerText = new System.Windows.Forms.Label();
            PreferAllButton = new System.Windows.Forms.Button();
            PreferSevereButton = new System.Windows.Forms.Button();
            PreferMinorButton = new System.Windows.Forms.Button();
            ChangeToInfoButton = new System.Windows.Forms.Button();
            PreferMagicButton = new System.Windows.Forms.Button();
            WindowShake = new System.Windows.Forms.Timer(components);
            AlertFunctionalityGroup.SuspendLayout();
            GeneralGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AlertCheckIntervalInput).BeginInit();
            groupBox11.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // AlertFunctionalityGroup
            // 
            AlertFunctionalityGroup.Controls.Add(label7);
            AlertFunctionalityGroup.Controls.Add(GeneralGroup);
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
            // GeneralGroup
            // 
            GeneralGroup.Controls.Add(discardFirstAlertsBox);
            GeneralGroup.ForeColor = System.Drawing.Color.White;
            GeneralGroup.Location = new System.Drawing.Point(160, 253);
            GeneralGroup.Name = "GeneralGroup";
            GeneralGroup.Size = new System.Drawing.Size(176, 43);
            GeneralGroup.TabIndex = 53;
            GeneralGroup.TabStop = false;
            GeneralGroup.Text = "General Filters";
            // 
            // discardFirstAlertsBox
            // 
            discardFirstAlertsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            discardFirstAlertsBox.Location = new System.Drawing.Point(3, 19);
            discardFirstAlertsBox.Name = "discardFirstAlertsBox";
            discardFirstAlertsBox.Size = new System.Drawing.Size(170, 21);
            discardFirstAlertsBox.TabIndex = 10;
            discardFirstAlertsBox.Text = "Ignore first alerts on start";
            ToolTipInformation.SetToolTip(discardFirstAlertsBox, "Throw all alerts into the history instead of the queue on startup.");
            discardFirstAlertsBox.UseVisualStyleBackColor = true;
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
            // AlertListButton
            // 
            AlertListButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AlertListButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            AlertListButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AlertListButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            AlertListButton.Location = new System.Drawing.Point(360, 12);
            AlertListButton.Name = "AlertListButton";
            AlertListButton.Size = new System.Drawing.Size(331, 40);
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
            // AdvancedDisclaimerText
            // 
            AdvancedDisclaimerText.Cursor = System.Windows.Forms.Cursors.Hand;
            AdvancedDisclaimerText.Font = new System.Drawing.Font("Segoe UI", 16F);
            AdvancedDisclaimerText.ForeColor = System.Drawing.Color.White;
            AdvancedDisclaimerText.Location = new System.Drawing.Point(360, 237);
            AdvancedDisclaimerText.Name = "AdvancedDisclaimerText";
            AdvancedDisclaimerText.Size = new System.Drawing.Size(331, 77);
            AdvancedDisclaimerText.TabIndex = 55;
            AdvancedDisclaimerText.Text = "Looking for more settings?\r\nSwitch to advanced mode.";
            AdvancedDisclaimerText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            AdvancedDisclaimerText.Visible = false;
            // 
            // PreferAllButton
            // 
            PreferAllButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            PreferAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            PreferAllButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            PreferAllButton.ForeColor = System.Drawing.Color.White;
            PreferAllButton.Location = new System.Drawing.Point(280, 321);
            PreferAllButton.Name = "PreferAllButton";
            PreferAllButton.Size = new System.Drawing.Size(128, 128);
            PreferAllButton.TabIndex = 56;
            PreferAllButton.Text = "Change to...\r\n\r\nAny alerts that match my locations.";
            PreferAllButton.UseMnemonic = false;
            PreferAllButton.UseVisualStyleBackColor = false;
            PreferAllButton.Click += PreferAllButton_Click;
            // 
            // PreferSevereButton
            // 
            PreferSevereButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            PreferSevereButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            PreferSevereButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            PreferSevereButton.ForeColor = System.Drawing.Color.White;
            PreferSevereButton.Location = new System.Drawing.Point(146, 321);
            PreferSevereButton.Name = "PreferSevereButton";
            PreferSevereButton.Size = new System.Drawing.Size(128, 128);
            PreferSevereButton.TabIndex = 58;
            PreferSevereButton.Text = "Change to...\r\n\r\nAny alerts that are severe or higher ratings.";
            PreferSevereButton.UseMnemonic = false;
            PreferSevereButton.UseVisualStyleBackColor = false;
            PreferSevereButton.Click += PreferSevereButton_Click;
            // 
            // PreferMinorButton
            // 
            PreferMinorButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            PreferMinorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            PreferMinorButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            PreferMinorButton.ForeColor = System.Drawing.Color.White;
            PreferMinorButton.Location = new System.Drawing.Point(12, 321);
            PreferMinorButton.Name = "PreferMinorButton";
            PreferMinorButton.Size = new System.Drawing.Size(128, 128);
            PreferMinorButton.TabIndex = 57;
            PreferMinorButton.Text = "Change to...\r\n\r\nAny alerts that are minor or higher ratings.";
            PreferMinorButton.UseMnemonic = false;
            PreferMinorButton.UseVisualStyleBackColor = false;
            PreferMinorButton.Click += PreferMinorButton_Click;
            // 
            // ChangeToInfoButton
            // 
            ChangeToInfoButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            ChangeToInfoButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ChangeToInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ChangeToInfoButton.ForeColor = System.Drawing.Color.Yellow;
            ChangeToInfoButton.Location = new System.Drawing.Point(548, 321);
            ChangeToInfoButton.Name = "ChangeToInfoButton";
            ChangeToInfoButton.Size = new System.Drawing.Size(23, 23);
            ChangeToInfoButton.TabIndex = 59;
            ChangeToInfoButton.Text = "?";
            ChangeToInfoButton.UseVisualStyleBackColor = false;
            ChangeToInfoButton.Click += ChangeToInfoButton_Click;
            // 
            // PreferMagicButton
            // 
            PreferMagicButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            PreferMagicButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            PreferMagicButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            PreferMagicButton.ForeColor = System.Drawing.Color.White;
            PreferMagicButton.Location = new System.Drawing.Point(414, 321);
            PreferMagicButton.Name = "PreferMagicButton";
            PreferMagicButton.Size = new System.Drawing.Size(128, 128);
            PreferMagicButton.TabIndex = 60;
            PreferMagicButton.Text = "Read my mind and adjust accordingly.";
            PreferMagicButton.UseMnemonic = false;
            PreferMagicButton.UseVisualStyleBackColor = false;
            PreferMagicButton.Click += PreferMagicButton_Click;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // SimpleAlertConfigurationForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(703, 461);
            Controls.Add(PreferMagicButton);
            Controls.Add(ChangeToInfoButton);
            Controls.Add(PreferSevereButton);
            Controls.Add(PreferMinorButton);
            Controls.Add(PreferAllButton);
            Controls.Add(AdvancedDisclaimerText);
            Controls.Add(EventsButton);
            Controls.Add(RainbowText);
            Controls.Add(AlertFunctionalityGroup);
            Controls.Add(LocationsButton);
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
            Name = "SimpleAlertConfigurationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Alert Settings (Simplified View)";
            HelpButtonClicked += AlertConfigurationForm_HelpButtonClicked;
            Load += AlertConfigurationForm_Load;
            AlertFunctionalityGroup.ResumeLayout(false);
            GeneralGroup.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox messageTypeTestBox;
        private System.Windows.Forms.Button LocationsButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button LocationsClearButton;
        private System.Windows.Forms.Button AlertListButton;
        private System.Windows.Forms.CheckBox PreferCMAMTextWhereAvailableBox;
        private System.Windows.Forms.GroupBox GeneralGroup;
        private System.Windows.Forms.CheckBox IgnoreKeepAliveBox;
        private System.Windows.Forms.Label RainbowText;
        private System.Windows.Forms.Timer RainbowColoring;
        private System.Windows.Forms.Button EventsButton;
        private System.Windows.Forms.Label AdvancedDisclaimerText;
        private System.Windows.Forms.Button PreferAllButton;
        private System.Windows.Forms.Button PreferSevereButton;
        private System.Windows.Forms.Button PreferMinorButton;
        private System.Windows.Forms.Button ChangeToInfoButton;
        private System.Windows.Forms.Button PreferMagicButton;
        private System.Windows.Forms.Timer WindowShake;
    }
}
