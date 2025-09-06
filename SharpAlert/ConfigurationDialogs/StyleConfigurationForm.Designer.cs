namespace SharpAlert.ConfigurationDialogs
{
    partial class StyleConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StyleConfigurationForm));
            this.DoneButton = new System.Windows.Forms.Button();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.alertTimeZoneUTCBox = new System.Windows.Forms.CheckBox();
            this.alertCompatibilityModeBox = new System.Windows.Forms.CheckBox();
            this.alertTimeoutInput = new System.Windows.Forms.NumericUpDown();
            this.alertFullscreenDisplayInput = new System.Windows.Forms.NumericUpDown();
            this.alertFullscreenIdleBox = new System.Windows.Forms.CheckBox();
            this.alertFullscreenWindowedBox = new System.Windows.Forms.CheckBox();
            this.alertIncreaseSizeBox = new System.Windows.Forms.CheckBox();
            this.alertNoGUIBox = new System.Windows.Forms.CheckBox();
            this.AlertFullscreenCombo = new System.Windows.Forms.ComboBox();
            this.WindowLocationCombo = new System.Windows.Forms.ComboBox();
            this.statusWindowBox = new System.Windows.Forms.CheckBox();
            this.NoSystemSleepBox = new System.Windows.Forms.CheckBox();
            this.alertAutoPrintingEnabledBox = new System.Windows.Forms.CheckBox();
            this.ScrollSpeedBar = new System.Windows.Forms.TrackBar();
            this.HideNetworkErrorsBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AlertTextButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DisplayStyleInfoButton = new System.Windows.Forms.Button();
            this.DisplayPanelsGroup = new System.Windows.Forms.GroupBox();
            this.TimeDisplayGroup = new System.Windows.Forms.GroupBox();
            this.SystemControlsGroup = new System.Windows.Forms.GroupBox();
            this.TextDisplayGroup = new System.Windows.Forms.GroupBox();
            this.PrintingGroup = new System.Windows.Forms.GroupBox();
            this.NotificationsGroup = new System.Windows.Forms.GroupBox();
            this.DisplayWhereInfoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertTimeoutInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertFullscreenDisplayInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollSpeedBar)).BeginInit();
            this.DisplayPanelsGroup.SuspendLayout();
            this.TimeDisplayGroup.SuspendLayout();
            this.SystemControlsGroup.SuspendLayout();
            this.TextDisplayGroup.SuspendLayout();
            this.PrintingGroup.SuspendLayout();
            this.NotificationsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneButton.Location = new System.Drawing.Point(578, 275);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(0);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(72, 23);
            this.DoneButton.TabIndex = 0;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = false;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // LogoBox
            // 
            this.LogoBox.Image = global::SharpAlert.Properties.Resources.WarningApp;
            this.LogoBox.Location = new System.Drawing.Point(9, 9);
            this.LogoBox.Margin = new System.Windows.Forms.Padding(0);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(96, 96);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoBox.TabIndex = 1;
            this.LogoBox.TabStop = false;
            this.LogoBox.DoubleClick += new System.EventHandler(this.LogoBox_DoubleClick);
            // 
            // TitleText
            // 
            this.TitleText.Font = new System.Drawing.Font("Arial", 16F);
            this.TitleText.Location = new System.Drawing.Point(105, 9);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(504, 30);
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "Choose your style settings.";
            this.TitleText.Click += new System.EventHandler(this.TitleText_Click);
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
            // alertTimeZoneUTCBox
            // 
            this.alertTimeZoneUTCBox.AutoSize = true;
            this.alertTimeZoneUTCBox.Location = new System.Drawing.Point(6, 20);
            this.alertTimeZoneUTCBox.Name = "alertTimeZoneUTCBox";
            this.alertTimeZoneUTCBox.Size = new System.Drawing.Size(77, 19);
            this.alertTimeZoneUTCBox.TabIndex = 7;
            this.alertTimeZoneUTCBox.Text = "Use UTC";
            this.ToolTipInformation.SetToolTip(this.alertTimeZoneUTCBox, "Uses UTC visually everywhere instead of the system time zone.\r\nAlert text may not" +
        " be affected by this setting.");
            this.alertTimeZoneUTCBox.UseVisualStyleBackColor = true;
            // 
            // alertCompatibilityModeBox
            // 
            this.alertCompatibilityModeBox.AutoSize = true;
            this.alertCompatibilityModeBox.Location = new System.Drawing.Point(6, 20);
            this.alertCompatibilityModeBox.Name = "alertCompatibilityModeBox";
            this.alertCompatibilityModeBox.Size = new System.Drawing.Size(132, 19);
            this.alertCompatibilityModeBox.TabIndex = 8;
            this.alertCompatibilityModeBox.Text = "Compatibility mode";
            this.ToolTipInformation.SetToolTip(this.alertCompatibilityModeBox, "Disables most animations and some background stuff. May help performance on older" +
        " systems.");
            this.alertCompatibilityModeBox.UseVisualStyleBackColor = true;
            // 
            // alertTimeoutInput
            // 
            this.alertTimeoutInput.Location = new System.Drawing.Point(168, 113);
            this.alertTimeoutInput.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.alertTimeoutInput.Name = "alertTimeoutInput";
            this.alertTimeoutInput.Size = new System.Drawing.Size(37, 21);
            this.alertTimeoutInput.TabIndex = 3;
            this.ToolTipInformation.SetToolTip(this.alertTimeoutInput, "The amount of time (in minutes) until an alert automatically closes itself.");
            this.alertTimeoutInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // alertFullscreenDisplayInput
            // 
            this.alertFullscreenDisplayInput.Location = new System.Drawing.Point(168, 86);
            this.alertFullscreenDisplayInput.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.alertFullscreenDisplayInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.alertFullscreenDisplayInput.Name = "alertFullscreenDisplayInput";
            this.alertFullscreenDisplayInput.Size = new System.Drawing.Size(37, 21);
            this.alertFullscreenDisplayInput.TabIndex = 2;
            this.ToolTipInformation.SetToolTip(this.alertFullscreenDisplayInput, "The screen to display the alert and idle panels on.");
            this.alertFullscreenDisplayInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // alertFullscreenIdleBox
            // 
            this.alertFullscreenIdleBox.AutoSize = true;
            this.alertFullscreenIdleBox.Location = new System.Drawing.Point(6, 20);
            this.alertFullscreenIdleBox.Name = "alertFullscreenIdleBox";
            this.alertFullscreenIdleBox.Size = new System.Drawing.Size(80, 19);
            this.alertFullscreenIdleBox.TabIndex = 5;
            this.alertFullscreenIdleBox.Text = "Idle panel";
            this.ToolTipInformation.SetToolTip(this.alertFullscreenIdleBox, "Shows an idle panel on top of all content.");
            this.alertFullscreenIdleBox.UseVisualStyleBackColor = true;
            // 
            // alertFullscreenWindowedBox
            // 
            this.alertFullscreenWindowedBox.AutoSize = true;
            this.alertFullscreenWindowedBox.Location = new System.Drawing.Point(6, 45);
            this.alertFullscreenWindowedBox.Name = "alertFullscreenWindowedBox";
            this.alertFullscreenWindowedBox.Size = new System.Drawing.Size(152, 19);
            this.alertFullscreenWindowedBox.TabIndex = 12;
            this.alertFullscreenWindowedBox.Text = "Enable titlebar controls";
            this.ToolTipInformation.SetToolTip(this.alertFullscreenWindowedBox, "Enables titlebar window controls for alert panels.");
            this.alertFullscreenWindowedBox.UseVisualStyleBackColor = true;
            // 
            // alertIncreaseSizeBox
            // 
            this.alertIncreaseSizeBox.AutoSize = true;
            this.alertIncreaseSizeBox.Location = new System.Drawing.Point(6, 20);
            this.alertIncreaseSizeBox.Name = "alertIncreaseSizeBox";
            this.alertIncreaseSizeBox.Size = new System.Drawing.Size(106, 19);
            this.alertIncreaseSizeBox.TabIndex = 11;
            this.alertIncreaseSizeBox.Text = "Large font size";
            this.ToolTipInformation.SetToolTip(this.alertIncreaseSizeBox, "Increases the font size of alert text.");
            this.alertIncreaseSizeBox.UseVisualStyleBackColor = true;
            // 
            // alertNoGUIBox
            // 
            this.alertNoGUIBox.AutoSize = true;
            this.alertNoGUIBox.Location = new System.Drawing.Point(6, 70);
            this.alertNoGUIBox.Name = "alertNoGUIBox";
            this.alertNoGUIBox.Size = new System.Drawing.Size(98, 19);
            this.alertNoGUIBox.TabIndex = 10;
            this.alertNoGUIBox.Text = "Console only";
            this.ToolTipInformation.SetToolTip(this.alertNoGUIBox, "All alert functions are done through the console, and no dialogs are shown.\r\nAler" +
        "ts cannot be interrupted or cancelled when this option is enabled.");
            this.alertNoGUIBox.UseVisualStyleBackColor = true;
            // 
            // AlertFullscreenCombo
            // 
            this.AlertFullscreenCombo.BackColor = System.Drawing.Color.Black;
            this.AlertFullscreenCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlertFullscreenCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AlertFullscreenCombo.ForeColor = System.Drawing.Color.White;
            this.AlertFullscreenCombo.FormattingEnabled = true;
            this.AlertFullscreenCombo.Location = new System.Drawing.Point(110, 57);
            this.AlertFullscreenCombo.Name = "AlertFullscreenCombo";
            this.AlertFullscreenCombo.Size = new System.Drawing.Size(95, 23);
            this.AlertFullscreenCombo.TabIndex = 1;
            this.ToolTipInformation.SetToolTip(this.AlertFullscreenCombo, "Choose how alerts are displayed.");
            // 
            // WindowLocationCombo
            // 
            this.WindowLocationCombo.BackColor = System.Drawing.Color.Black;
            this.WindowLocationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WindowLocationCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.WindowLocationCombo.ForeColor = System.Drawing.Color.White;
            this.WindowLocationCombo.FormattingEnabled = true;
            this.WindowLocationCombo.Location = new System.Drawing.Point(110, 162);
            this.WindowLocationCombo.Name = "WindowLocationCombo";
            this.WindowLocationCombo.Size = new System.Drawing.Size(95, 23);
            this.WindowLocationCombo.TabIndex = 4;
            this.ToolTipInformation.SetToolTip(this.WindowLocationCombo, "Choose where on the screen alerts are displayed.\r\nThis option only affects some d" +
        "isplay styles.");
            // 
            // statusWindowBox
            // 
            this.statusWindowBox.AutoSize = true;
            this.statusWindowBox.Location = new System.Drawing.Point(6, 45);
            this.statusWindowBox.Name = "statusWindowBox";
            this.statusWindowBox.Size = new System.Drawing.Size(95, 19);
            this.statusWindowBox.TabIndex = 6;
            this.statusWindowBox.Text = "Status panel";
            this.ToolTipInformation.SetToolTip(this.statusWindowBox, "Shows the status window.");
            this.statusWindowBox.UseVisualStyleBackColor = true;
            // 
            // NoSystemSleepBox
            // 
            this.NoSystemSleepBox.AutoSize = true;
            this.NoSystemSleepBox.Location = new System.Drawing.Point(6, 45);
            this.NoSystemSleepBox.Name = "NoSystemSleepBox";
            this.NoSystemSleepBox.Size = new System.Drawing.Size(136, 19);
            this.NoSystemSleepBox.TabIndex = 9;
            this.NoSystemSleepBox.Text = "Prevent sleep mode";
            this.ToolTipInformation.SetToolTip(this.NoSystemSleepBox, "Prevents the system from entering sleep mode at all times.");
            this.NoSystemSleepBox.UseVisualStyleBackColor = true;
            // 
            // alertAutoPrintingEnabledBox
            // 
            this.alertAutoPrintingEnabledBox.AutoSize = true;
            this.alertAutoPrintingEnabledBox.Location = new System.Drawing.Point(6, 20);
            this.alertAutoPrintingEnabledBox.Name = "alertAutoPrintingEnabledBox";
            this.alertAutoPrintingEnabledBox.Size = new System.Drawing.Size(128, 19);
            this.alertAutoPrintingEnabledBox.TabIndex = 13;
            this.alertAutoPrintingEnabledBox.Text = "Print relayed alerts";
            this.ToolTipInformation.SetToolTip(this.alertAutoPrintingEnabledBox, "Prints relayed alerts. This feature is only available if dialogs are enabled.");
            this.alertAutoPrintingEnabledBox.UseVisualStyleBackColor = true;
            // 
            // ScrollSpeedBar
            // 
            this.ScrollSpeedBar.Location = new System.Drawing.Point(107, 230);
            this.ScrollSpeedBar.Maximum = 20;
            this.ScrollSpeedBar.Name = "ScrollSpeedBar";
            this.ScrollSpeedBar.Size = new System.Drawing.Size(127, 45);
            this.ScrollSpeedBar.TabIndex = 44;
            this.ToolTipInformation.SetToolTip(this.ScrollSpeedBar, "Controls the scroll speed on panels with scrolling text. This cannot control the " +
        "idle panel scroll speed.");
            this.ScrollSpeedBar.Value = 5;
            // 
            // HideNetworkErrorsBox
            // 
            this.HideNetworkErrorsBox.AutoSize = true;
            this.HideNetworkErrorsBox.Location = new System.Drawing.Point(6, 20);
            this.HideNetworkErrorsBox.Name = "HideNetworkErrorsBox";
            this.HideNetworkErrorsBox.Size = new System.Drawing.Size(134, 19);
            this.HideNetworkErrorsBox.TabIndex = 14;
            this.HideNetworkErrorsBox.Text = "Hide network errors";
            this.ToolTipInformation.SetToolTip(this.HideNetworkErrorsBox, "Hides network error notifications from appearing.\r\nThey\'ll still appear in the co" +
        "nsole.");
            this.HideNetworkErrorsBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(9, 272);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "To change these options later, go to Settings.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(107, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "Timeout";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(107, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Display style";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(107, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 37;
            this.label8.Text = "Screen";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(107, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 39;
            this.label11.Text = "Display where";
            // 
            // AlertTextButton
            // 
            this.AlertTextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertTextButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AlertTextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AlertTextButton.Location = new System.Drawing.Point(578, 249);
            this.AlertTextButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.AlertTextButton.Name = "AlertTextButton";
            this.AlertTextButton.Size = new System.Drawing.Size(72, 23);
            this.AlertTextButton.TabIndex = 41;
            this.AlertTextButton.Text = "Alert Text";
            this.AlertTextButton.UseVisualStyleBackColor = false;
            this.AlertTextButton.Click += new System.EventHandler(this.AlertTextButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(107, 194);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 30);
            this.label3.TabIndex = 43;
            this.label3.Text = "Scroll speed\r\n(Full scroll style only)";
            // 
            // DisplayStyleInfoButton
            // 
            this.DisplayStyleInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DisplayStyleInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DisplayStyleInfoButton.ForeColor = System.Drawing.Color.Yellow;
            this.DisplayStyleInfoButton.Location = new System.Drawing.Point(211, 57);
            this.DisplayStyleInfoButton.Name = "DisplayStyleInfoButton";
            this.DisplayStyleInfoButton.Size = new System.Drawing.Size(23, 23);
            this.DisplayStyleInfoButton.TabIndex = 53;
            this.DisplayStyleInfoButton.Text = "?";
            this.DisplayStyleInfoButton.UseVisualStyleBackColor = false;
            this.DisplayStyleInfoButton.Click += new System.EventHandler(this.DisplayStyleInfoButton_Click);
            // 
            // DisplayPanelsGroup
            // 
            this.DisplayPanelsGroup.Controls.Add(this.alertFullscreenIdleBox);
            this.DisplayPanelsGroup.Controls.Add(this.statusWindowBox);
            this.DisplayPanelsGroup.ForeColor = System.Drawing.Color.White;
            this.DisplayPanelsGroup.Location = new System.Drawing.Point(240, 42);
            this.DisplayPanelsGroup.Name = "DisplayPanelsGroup";
            this.DisplayPanelsGroup.Size = new System.Drawing.Size(163, 69);
            this.DisplayPanelsGroup.TabIndex = 54;
            this.DisplayPanelsGroup.TabStop = false;
            this.DisplayPanelsGroup.Text = "Display Panels";
            // 
            // TimeDisplayGroup
            // 
            this.TimeDisplayGroup.Controls.Add(this.alertTimeZoneUTCBox);
            this.TimeDisplayGroup.ForeColor = System.Drawing.Color.White;
            this.TimeDisplayGroup.Location = new System.Drawing.Point(240, 117);
            this.TimeDisplayGroup.Name = "TimeDisplayGroup";
            this.TimeDisplayGroup.Size = new System.Drawing.Size(163, 47);
            this.TimeDisplayGroup.TabIndex = 55;
            this.TimeDisplayGroup.TabStop = false;
            this.TimeDisplayGroup.Text = "Time Display";
            // 
            // SystemControlsGroup
            // 
            this.SystemControlsGroup.Controls.Add(this.alertCompatibilityModeBox);
            this.SystemControlsGroup.Controls.Add(this.NoSystemSleepBox);
            this.SystemControlsGroup.Controls.Add(this.alertNoGUIBox);
            this.SystemControlsGroup.ForeColor = System.Drawing.Color.White;
            this.SystemControlsGroup.Location = new System.Drawing.Point(240, 170);
            this.SystemControlsGroup.Name = "SystemControlsGroup";
            this.SystemControlsGroup.Size = new System.Drawing.Size(163, 99);
            this.SystemControlsGroup.TabIndex = 57;
            this.SystemControlsGroup.TabStop = false;
            this.SystemControlsGroup.Text = "System Controls";
            // 
            // TextDisplayGroup
            // 
            this.TextDisplayGroup.Controls.Add(this.alertIncreaseSizeBox);
            this.TextDisplayGroup.Controls.Add(this.alertFullscreenWindowedBox);
            this.TextDisplayGroup.ForeColor = System.Drawing.Color.White;
            this.TextDisplayGroup.Location = new System.Drawing.Point(409, 42);
            this.TextDisplayGroup.Name = "TextDisplayGroup";
            this.TextDisplayGroup.Size = new System.Drawing.Size(163, 69);
            this.TextDisplayGroup.TabIndex = 58;
            this.TextDisplayGroup.TabStop = false;
            this.TextDisplayGroup.Text = "Alert Display";
            // 
            // PrintingGroup
            // 
            this.PrintingGroup.Controls.Add(this.alertAutoPrintingEnabledBox);
            this.PrintingGroup.ForeColor = System.Drawing.Color.White;
            this.PrintingGroup.Location = new System.Drawing.Point(409, 117);
            this.PrintingGroup.Name = "PrintingGroup";
            this.PrintingGroup.Size = new System.Drawing.Size(163, 47);
            this.PrintingGroup.TabIndex = 59;
            this.PrintingGroup.TabStop = false;
            this.PrintingGroup.Text = "Printing";
            // 
            // NotificationsGroup
            // 
            this.NotificationsGroup.Controls.Add(this.HideNetworkErrorsBox);
            this.NotificationsGroup.ForeColor = System.Drawing.Color.White;
            this.NotificationsGroup.Location = new System.Drawing.Point(409, 170);
            this.NotificationsGroup.Name = "NotificationsGroup";
            this.NotificationsGroup.Size = new System.Drawing.Size(163, 47);
            this.NotificationsGroup.TabIndex = 60;
            this.NotificationsGroup.TabStop = false;
            this.NotificationsGroup.Text = "Notifications";
            // 
            // DisplayWhereInfoButton
            // 
            this.DisplayWhereInfoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DisplayWhereInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DisplayWhereInfoButton.ForeColor = System.Drawing.Color.Yellow;
            this.DisplayWhereInfoButton.Location = new System.Drawing.Point(211, 162);
            this.DisplayWhereInfoButton.Name = "DisplayWhereInfoButton";
            this.DisplayWhereInfoButton.Size = new System.Drawing.Size(23, 23);
            this.DisplayWhereInfoButton.TabIndex = 61;
            this.DisplayWhereInfoButton.Text = "?";
            this.DisplayWhereInfoButton.UseVisualStyleBackColor = false;
            this.DisplayWhereInfoButton.Click += new System.EventHandler(this.DisplayWhereInfoButton_Click);
            // 
            // StyleConfigurationForm
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(659, 307);
            this.Controls.Add(this.DisplayWhereInfoButton);
            this.Controls.Add(this.NotificationsGroup);
            this.Controls.Add(this.PrintingGroup);
            this.Controls.Add(this.SystemControlsGroup);
            this.Controls.Add(this.TimeDisplayGroup);
            this.Controls.Add(this.DisplayStyleInfoButton);
            this.Controls.Add(this.ScrollSpeedBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AlertTextButton);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.WindowLocationCombo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AlertFullscreenCombo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.alertTimeoutInput);
            this.Controls.Add(this.alertFullscreenDisplayInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.LogoBox);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.DisplayPanelsGroup);
            this.Controls.Add(this.TextDisplayGroup);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StyleConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Style Selection";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ChooseRegionForm_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseRegionForm_FormClosing);
            this.Load += new System.EventHandler(this.ChooseRegionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertTimeoutInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertFullscreenDisplayInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ScrollSpeedBar)).EndInit();
            this.DisplayPanelsGroup.ResumeLayout(false);
            this.DisplayPanelsGroup.PerformLayout();
            this.TimeDisplayGroup.ResumeLayout(false);
            this.TimeDisplayGroup.PerformLayout();
            this.SystemControlsGroup.ResumeLayout(false);
            this.SystemControlsGroup.PerformLayout();
            this.TextDisplayGroup.ResumeLayout(false);
            this.TextDisplayGroup.PerformLayout();
            this.PrintingGroup.ResumeLayout(false);
            this.PrintingGroup.PerformLayout();
            this.NotificationsGroup.ResumeLayout(false);
            this.NotificationsGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AlertFullscreenCombo;
        private System.Windows.Forms.CheckBox alertTimeZoneUTCBox;
        private System.Windows.Forms.CheckBox alertCompatibilityModeBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown alertTimeoutInput;
        private System.Windows.Forms.NumericUpDown alertFullscreenDisplayInput;
        private System.Windows.Forms.CheckBox alertFullscreenIdleBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox alertFullscreenWindowedBox;
        private System.Windows.Forms.CheckBox alertIncreaseSizeBox;
        private System.Windows.Forms.CheckBox alertNoGUIBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox WindowLocationCombo;
        private System.Windows.Forms.CheckBox statusWindowBox;
        private System.Windows.Forms.CheckBox NoSystemSleepBox;
        private System.Windows.Forms.Button AlertTextButton;
        private System.Windows.Forms.CheckBox alertAutoPrintingEnabledBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar ScrollSpeedBar;
        private System.Windows.Forms.Button DisplayStyleInfoButton;
        private System.Windows.Forms.GroupBox DisplayPanelsGroup;
        private System.Windows.Forms.GroupBox TimeDisplayGroup;
        private System.Windows.Forms.CheckBox HideNetworkErrorsBox;
        private System.Windows.Forms.GroupBox SystemControlsGroup;
        private System.Windows.Forms.GroupBox TextDisplayGroup;
        private System.Windows.Forms.GroupBox PrintingGroup;
        private System.Windows.Forms.GroupBox NotificationsGroup;
        private System.Windows.Forms.Button DisplayWhereInfoButton;
    }
}
