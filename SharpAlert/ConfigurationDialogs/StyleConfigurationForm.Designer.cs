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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StyleConfigurationForm));
            DoneButton = new System.Windows.Forms.Button();
            LogoBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            alertTimeZoneUTCBox = new System.Windows.Forms.CheckBox();
            alertCompatibilityModeBox = new System.Windows.Forms.CheckBox();
            alertTimeoutInput = new System.Windows.Forms.NumericUpDown();
            alertFullscreenDisplayInput = new System.Windows.Forms.NumericUpDown();
            alertFullscreenIdleBox = new System.Windows.Forms.CheckBox();
            alertFullscreenWindowedBox = new System.Windows.Forms.CheckBox();
            alertIncreaseSizeBox = new System.Windows.Forms.CheckBox();
            alertNoGUIBox = new System.Windows.Forms.CheckBox();
            AlertFullscreenCombo = new System.Windows.Forms.ComboBox();
            WindowLocationCombo = new System.Windows.Forms.ComboBox();
            statusWindowBox = new System.Windows.Forms.CheckBox();
            NoSystemSleepBox = new System.Windows.Forms.CheckBox();
            alertAutoPrintingEnabledBox = new System.Windows.Forms.CheckBox();
            ScrollSpeedBar = new System.Windows.Forms.TrackBar();
            HideNetworkErrorsBox = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            AlertTextButton = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            DisplayStyleInfoButton = new System.Windows.Forms.Button();
            DisplayPanelsGroup = new System.Windows.Forms.GroupBox();
            TimeDisplayGroup = new System.Windows.Forms.GroupBox();
            SystemControlsGroup = new System.Windows.Forms.GroupBox();
            TextDisplayGroup = new System.Windows.Forms.GroupBox();
            PrintingGroup = new System.Windows.Forms.GroupBox();
            NotificationsGroup = new System.Windows.Forms.GroupBox();
            DisplayWhereInfoButton = new System.Windows.Forms.Button();
            OpenDashboardAutomaticallyBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alertTimeoutInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alertFullscreenDisplayInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ScrollSpeedBar).BeginInit();
            DisplayPanelsGroup.SuspendLayout();
            TimeDisplayGroup.SuspendLayout();
            SystemControlsGroup.SuspendLayout();
            TextDisplayGroup.SuspendLayout();
            PrintingGroup.SuspendLayout();
            NotificationsGroup.SuspendLayout();
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Location = new System.Drawing.Point(578, 275);
            DoneButton.Margin = new System.Windows.Forms.Padding(0);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new System.Drawing.Size(72, 23);
            DoneButton.TabIndex = 0;
            DoneButton.Text = "Done";
            DoneButton.UseVisualStyleBackColor = false;
            DoneButton.Click += DoneButton_Click;
            // 
            // LogoBox
            // 
            LogoBox.Image = Properties.Resources.WarningApp;
            LogoBox.Location = new System.Drawing.Point(9, 9);
            LogoBox.Margin = new System.Windows.Forms.Padding(0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new System.Drawing.Size(96, 96);
            LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            LogoBox.TabIndex = 1;
            LogoBox.TabStop = false;
            LogoBox.DoubleClick += LogoBox_DoubleClick;
            // 
            // TitleText
            // 
            TitleText.Font = new System.Drawing.Font("Segoe UI", 16F);
            TitleText.Location = new System.Drawing.Point(105, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(504, 30);
            TitleText.TabIndex = 3;
            TitleText.Text = "Choose your style settings.";
            TitleText.Click += TitleText_Click;
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
            // alertTimeZoneUTCBox
            // 
            alertTimeZoneUTCBox.AutoSize = true;
            alertTimeZoneUTCBox.Location = new System.Drawing.Point(6, 20);
            alertTimeZoneUTCBox.Name = "alertTimeZoneUTCBox";
            alertTimeZoneUTCBox.Size = new System.Drawing.Size(69, 19);
            alertTimeZoneUTCBox.TabIndex = 7;
            alertTimeZoneUTCBox.Text = "Use UTC";
            ToolTipInformation.SetToolTip(alertTimeZoneUTCBox, "Uses UTC visually everywhere instead of the system time zone.\r\nAlert text may not be affected by this setting.");
            alertTimeZoneUTCBox.UseVisualStyleBackColor = true;
            // 
            // alertCompatibilityModeBox
            // 
            alertCompatibilityModeBox.AutoSize = true;
            alertCompatibilityModeBox.Location = new System.Drawing.Point(6, 20);
            alertCompatibilityModeBox.Name = "alertCompatibilityModeBox";
            alertCompatibilityModeBox.Size = new System.Drawing.Size(132, 19);
            alertCompatibilityModeBox.TabIndex = 8;
            alertCompatibilityModeBox.Text = "Compatibility mode";
            ToolTipInformation.SetToolTip(alertCompatibilityModeBox, "Disables most animations and some background stuff. May help performance on older systems.");
            alertCompatibilityModeBox.UseVisualStyleBackColor = true;
            // 
            // alertTimeoutInput
            // 
            alertTimeoutInput.Location = new System.Drawing.Point(168, 113);
            alertTimeoutInput.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            alertTimeoutInput.Name = "alertTimeoutInput";
            alertTimeoutInput.Size = new System.Drawing.Size(37, 23);
            alertTimeoutInput.TabIndex = 3;
            ToolTipInformation.SetToolTip(alertTimeoutInput, "The amount of time (in minutes) until an alert automatically closes itself.");
            alertTimeoutInput.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // alertFullscreenDisplayInput
            // 
            alertFullscreenDisplayInput.Location = new System.Drawing.Point(168, 86);
            alertFullscreenDisplayInput.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            alertFullscreenDisplayInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            alertFullscreenDisplayInput.Name = "alertFullscreenDisplayInput";
            alertFullscreenDisplayInput.Size = new System.Drawing.Size(37, 23);
            alertFullscreenDisplayInput.TabIndex = 2;
            ToolTipInformation.SetToolTip(alertFullscreenDisplayInput, "The screen to display the alert and idle panels on.");
            alertFullscreenDisplayInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // alertFullscreenIdleBox
            // 
            alertFullscreenIdleBox.AutoSize = true;
            alertFullscreenIdleBox.Location = new System.Drawing.Point(6, 20);
            alertFullscreenIdleBox.Name = "alertFullscreenIdleBox";
            alertFullscreenIdleBox.Size = new System.Drawing.Size(77, 19);
            alertFullscreenIdleBox.TabIndex = 5;
            alertFullscreenIdleBox.Text = "Idle panel";
            ToolTipInformation.SetToolTip(alertFullscreenIdleBox, "Shows an idle panel on top of all content.");
            alertFullscreenIdleBox.UseVisualStyleBackColor = true;
            // 
            // alertFullscreenWindowedBox
            // 
            alertFullscreenWindowedBox.AutoSize = true;
            alertFullscreenWindowedBox.Location = new System.Drawing.Point(6, 45);
            alertFullscreenWindowedBox.Name = "alertFullscreenWindowedBox";
            alertFullscreenWindowedBox.Size = new System.Drawing.Size(147, 19);
            alertFullscreenWindowedBox.TabIndex = 12;
            alertFullscreenWindowedBox.Text = "Enable titlebar controls";
            ToolTipInformation.SetToolTip(alertFullscreenWindowedBox, "Enables titlebar window controls for alert panels.");
            alertFullscreenWindowedBox.UseVisualStyleBackColor = true;
            // 
            // alertIncreaseSizeBox
            // 
            alertIncreaseSizeBox.AutoSize = true;
            alertIncreaseSizeBox.Location = new System.Drawing.Point(6, 20);
            alertIncreaseSizeBox.Name = "alertIncreaseSizeBox";
            alertIncreaseSizeBox.Size = new System.Drawing.Size(102, 19);
            alertIncreaseSizeBox.TabIndex = 11;
            alertIncreaseSizeBox.Text = "Large font size";
            ToolTipInformation.SetToolTip(alertIncreaseSizeBox, "Increases the font size of alert text.");
            alertIncreaseSizeBox.UseVisualStyleBackColor = true;
            // 
            // alertNoGUIBox
            // 
            alertNoGUIBox.AutoSize = true;
            alertNoGUIBox.Location = new System.Drawing.Point(6, 70);
            alertNoGUIBox.Name = "alertNoGUIBox";
            alertNoGUIBox.Size = new System.Drawing.Size(95, 19);
            alertNoGUIBox.TabIndex = 10;
            alertNoGUIBox.Text = "Console only";
            ToolTipInformation.SetToolTip(alertNoGUIBox, "All alert functions are done through the console, and no dialogs are shown.\r\nAlerts cannot be interrupted or cancelled when this option is enabled.");
            alertNoGUIBox.UseVisualStyleBackColor = true;
            // 
            // AlertFullscreenCombo
            // 
            AlertFullscreenCombo.BackColor = System.Drawing.Color.Black;
            AlertFullscreenCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            AlertFullscreenCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AlertFullscreenCombo.ForeColor = System.Drawing.Color.White;
            AlertFullscreenCombo.FormattingEnabled = true;
            AlertFullscreenCombo.Location = new System.Drawing.Point(110, 57);
            AlertFullscreenCombo.Name = "AlertFullscreenCombo";
            AlertFullscreenCombo.Size = new System.Drawing.Size(95, 23);
            AlertFullscreenCombo.TabIndex = 1;
            ToolTipInformation.SetToolTip(AlertFullscreenCombo, "Choose how alerts are displayed.");
            // 
            // WindowLocationCombo
            // 
            WindowLocationCombo.BackColor = System.Drawing.Color.Black;
            WindowLocationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            WindowLocationCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            WindowLocationCombo.ForeColor = System.Drawing.Color.White;
            WindowLocationCombo.FormattingEnabled = true;
            WindowLocationCombo.Location = new System.Drawing.Point(110, 162);
            WindowLocationCombo.Name = "WindowLocationCombo";
            WindowLocationCombo.Size = new System.Drawing.Size(95, 23);
            WindowLocationCombo.TabIndex = 4;
            ToolTipInformation.SetToolTip(WindowLocationCombo, "Choose where on the screen alerts are displayed.\r\nThis option only affects some display styles.");
            // 
            // statusWindowBox
            // 
            statusWindowBox.AutoSize = true;
            statusWindowBox.Location = new System.Drawing.Point(6, 45);
            statusWindowBox.Name = "statusWindowBox";
            statusWindowBox.Size = new System.Drawing.Size(90, 19);
            statusWindowBox.TabIndex = 6;
            statusWindowBox.Text = "Status panel";
            ToolTipInformation.SetToolTip(statusWindowBox, "Shows the status window.");
            statusWindowBox.UseVisualStyleBackColor = true;
            // 
            // NoSystemSleepBox
            // 
            NoSystemSleepBox.AutoSize = true;
            NoSystemSleepBox.Location = new System.Drawing.Point(6, 45);
            NoSystemSleepBox.Name = "NoSystemSleepBox";
            NoSystemSleepBox.Size = new System.Drawing.Size(130, 19);
            NoSystemSleepBox.TabIndex = 9;
            NoSystemSleepBox.Text = "Prevent sleep mode";
            ToolTipInformation.SetToolTip(NoSystemSleepBox, "Prevents the system from entering sleep mode at all times.");
            NoSystemSleepBox.UseVisualStyleBackColor = true;
            // 
            // alertAutoPrintingEnabledBox
            // 
            alertAutoPrintingEnabledBox.AutoSize = true;
            alertAutoPrintingEnabledBox.Location = new System.Drawing.Point(6, 20);
            alertAutoPrintingEnabledBox.Name = "alertAutoPrintingEnabledBox";
            alertAutoPrintingEnabledBox.Size = new System.Drawing.Size(123, 19);
            alertAutoPrintingEnabledBox.TabIndex = 13;
            alertAutoPrintingEnabledBox.Text = "Print relayed alerts";
            ToolTipInformation.SetToolTip(alertAutoPrintingEnabledBox, "Prints relayed alerts. This feature is only available if dialogs are enabled.");
            alertAutoPrintingEnabledBox.UseVisualStyleBackColor = true;
            // 
            // ScrollSpeedBar
            // 
            ScrollSpeedBar.Location = new System.Drawing.Point(107, 230);
            ScrollSpeedBar.Maximum = 20;
            ScrollSpeedBar.Name = "ScrollSpeedBar";
            ScrollSpeedBar.Size = new System.Drawing.Size(127, 45);
            ScrollSpeedBar.TabIndex = 44;
            ToolTipInformation.SetToolTip(ScrollSpeedBar, "Controls the scroll speed on panels with scrolling text. This cannot control the idle panel scroll speed.");
            ScrollSpeedBar.Value = 5;
            // 
            // HideNetworkErrorsBox
            // 
            HideNetworkErrorsBox.AutoSize = true;
            HideNetworkErrorsBox.Location = new System.Drawing.Point(6, 20);
            HideNetworkErrorsBox.Name = "HideNetworkErrorsBox";
            HideNetworkErrorsBox.Size = new System.Drawing.Size(130, 19);
            HideNetworkErrorsBox.TabIndex = 14;
            HideNetworkErrorsBox.Text = "Hide network errors";
            ToolTipInformation.SetToolTip(HideNetworkErrorsBox, "Hides network error notifications from appearing.\r\nThey'll still appear in the console.");
            HideNetworkErrorsBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(9, 272);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(332, 26);
            label1.TabIndex = 13;
            label1.Text = "To change these options later, go to Settings.";
            label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(107, 115);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(51, 15);
            label9.TabIndex = 34;
            label9.Text = "Timeout";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            label2.Location = new System.Drawing.Point(107, 39);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(72, 15);
            label2.TabIndex = 36;
            label2.Text = "Display style";
            label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(107, 88);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(42, 15);
            label8.TabIndex = 37;
            label8.Text = "Screen";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(107, 144);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(80, 15);
            label11.TabIndex = 39;
            label11.Text = "Display where";
            // 
            // AlertTextButton
            // 
            AlertTextButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            AlertTextButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            AlertTextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AlertTextButton.Location = new System.Drawing.Point(578, 249);
            AlertTextButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            AlertTextButton.Name = "AlertTextButton";
            AlertTextButton.Size = new System.Drawing.Size(72, 23);
            AlertTextButton.TabIndex = 41;
            AlertTextButton.Text = "Alert Text";
            AlertTextButton.UseVisualStyleBackColor = false;
            AlertTextButton.Click += AlertTextButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(107, 194);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(118, 30);
            label3.TabIndex = 43;
            label3.Text = "Scroll speed\r\n(Full scroll style only)";
            // 
            // DisplayStyleInfoButton
            // 
            DisplayStyleInfoButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DisplayStyleInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DisplayStyleInfoButton.ForeColor = System.Drawing.Color.Yellow;
            DisplayStyleInfoButton.Location = new System.Drawing.Point(211, 57);
            DisplayStyleInfoButton.Name = "DisplayStyleInfoButton";
            DisplayStyleInfoButton.Size = new System.Drawing.Size(23, 23);
            DisplayStyleInfoButton.TabIndex = 53;
            DisplayStyleInfoButton.Text = "?";
            DisplayStyleInfoButton.UseVisualStyleBackColor = false;
            DisplayStyleInfoButton.Click += DisplayStyleInfoButton_Click;
            // 
            // DisplayPanelsGroup
            // 
            DisplayPanelsGroup.Controls.Add(OpenDashboardAutomaticallyBox);
            DisplayPanelsGroup.Controls.Add(alertFullscreenIdleBox);
            DisplayPanelsGroup.Controls.Add(statusWindowBox);
            DisplayPanelsGroup.ForeColor = System.Drawing.Color.White;
            DisplayPanelsGroup.Location = new System.Drawing.Point(240, 42);
            DisplayPanelsGroup.Name = "DisplayPanelsGroup";
            DisplayPanelsGroup.Size = new System.Drawing.Size(163, 122);
            DisplayPanelsGroup.TabIndex = 54;
            DisplayPanelsGroup.TabStop = false;
            DisplayPanelsGroup.Text = "Display Panels";
            // 
            // TimeDisplayGroup
            // 
            TimeDisplayGroup.Controls.Add(alertTimeZoneUTCBox);
            TimeDisplayGroup.ForeColor = System.Drawing.Color.White;
            TimeDisplayGroup.Location = new System.Drawing.Point(409, 223);
            TimeDisplayGroup.Name = "TimeDisplayGroup";
            TimeDisplayGroup.Size = new System.Drawing.Size(163, 46);
            TimeDisplayGroup.TabIndex = 55;
            TimeDisplayGroup.TabStop = false;
            TimeDisplayGroup.Text = "Time Display";
            // 
            // SystemControlsGroup
            // 
            SystemControlsGroup.Controls.Add(alertCompatibilityModeBox);
            SystemControlsGroup.Controls.Add(NoSystemSleepBox);
            SystemControlsGroup.Controls.Add(alertNoGUIBox);
            SystemControlsGroup.ForeColor = System.Drawing.Color.White;
            SystemControlsGroup.Location = new System.Drawing.Point(240, 170);
            SystemControlsGroup.Name = "SystemControlsGroup";
            SystemControlsGroup.Size = new System.Drawing.Size(163, 99);
            SystemControlsGroup.TabIndex = 57;
            SystemControlsGroup.TabStop = false;
            SystemControlsGroup.Text = "System Controls";
            // 
            // TextDisplayGroup
            // 
            TextDisplayGroup.Controls.Add(alertIncreaseSizeBox);
            TextDisplayGroup.Controls.Add(alertFullscreenWindowedBox);
            TextDisplayGroup.ForeColor = System.Drawing.Color.White;
            TextDisplayGroup.Location = new System.Drawing.Point(409, 42);
            TextDisplayGroup.Name = "TextDisplayGroup";
            TextDisplayGroup.Size = new System.Drawing.Size(163, 69);
            TextDisplayGroup.TabIndex = 58;
            TextDisplayGroup.TabStop = false;
            TextDisplayGroup.Text = "Alert Display";
            // 
            // PrintingGroup
            // 
            PrintingGroup.Controls.Add(alertAutoPrintingEnabledBox);
            PrintingGroup.ForeColor = System.Drawing.Color.White;
            PrintingGroup.Location = new System.Drawing.Point(409, 117);
            PrintingGroup.Name = "PrintingGroup";
            PrintingGroup.Size = new System.Drawing.Size(163, 47);
            PrintingGroup.TabIndex = 59;
            PrintingGroup.TabStop = false;
            PrintingGroup.Text = "Printing";
            // 
            // NotificationsGroup
            // 
            NotificationsGroup.Controls.Add(HideNetworkErrorsBox);
            NotificationsGroup.ForeColor = System.Drawing.Color.White;
            NotificationsGroup.Location = new System.Drawing.Point(409, 170);
            NotificationsGroup.Name = "NotificationsGroup";
            NotificationsGroup.Size = new System.Drawing.Size(163, 47);
            NotificationsGroup.TabIndex = 60;
            NotificationsGroup.TabStop = false;
            NotificationsGroup.Text = "Notifications";
            // 
            // DisplayWhereInfoButton
            // 
            DisplayWhereInfoButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DisplayWhereInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DisplayWhereInfoButton.ForeColor = System.Drawing.Color.Yellow;
            DisplayWhereInfoButton.Location = new System.Drawing.Point(211, 162);
            DisplayWhereInfoButton.Name = "DisplayWhereInfoButton";
            DisplayWhereInfoButton.Size = new System.Drawing.Size(23, 23);
            DisplayWhereInfoButton.TabIndex = 61;
            DisplayWhereInfoButton.Text = "?";
            DisplayWhereInfoButton.UseVisualStyleBackColor = false;
            DisplayWhereInfoButton.Click += DisplayWhereInfoButton_Click;
            // 
            // OpenDashboardAutomaticallyBox
            // 
            OpenDashboardAutomaticallyBox.AutoSize = true;
            OpenDashboardAutomaticallyBox.Location = new System.Drawing.Point(6, 70);
            OpenDashboardAutomaticallyBox.Name = "OpenDashboardAutomaticallyBox";
            OpenDashboardAutomaticallyBox.Size = new System.Drawing.Size(126, 19);
            OpenDashboardAutomaticallyBox.TabIndex = 7;
            OpenDashboardAutomaticallyBox.Text = "Dashboard on start";
            ToolTipInformation.SetToolTip(OpenDashboardAutomaticallyBox, "Shows the status window.");
            OpenDashboardAutomaticallyBox.UseVisualStyleBackColor = true;
            // 
            // StyleConfigurationForm
            // 
            AcceptButton = DoneButton;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(659, 307);
            Controls.Add(DisplayWhereInfoButton);
            Controls.Add(NotificationsGroup);
            Controls.Add(PrintingGroup);
            Controls.Add(SystemControlsGroup);
            Controls.Add(TimeDisplayGroup);
            Controls.Add(DisplayStyleInfoButton);
            Controls.Add(ScrollSpeedBar);
            Controls.Add(label3);
            Controls.Add(AlertTextButton);
            Controls.Add(label11);
            Controls.Add(WindowLocationCombo);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(AlertFullscreenCombo);
            Controls.Add(label9);
            Controls.Add(alertTimeoutInput);
            Controls.Add(alertFullscreenDisplayInput);
            Controls.Add(label1);
            Controls.Add(TitleText);
            Controls.Add(LogoBox);
            Controls.Add(DoneButton);
            Controls.Add(DisplayPanelsGroup);
            Controls.Add(TextDisplayGroup);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StyleConfigurationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Style Selection";
            HelpButtonClicked += ChooseRegionForm_HelpButtonClicked;
            FormClosing += ChooseRegionForm_FormClosing;
            Load += ChooseRegionForm_Load;
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)alertTimeoutInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)alertFullscreenDisplayInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)ScrollSpeedBar).EndInit();
            DisplayPanelsGroup.ResumeLayout(false);
            DisplayPanelsGroup.PerformLayout();
            TimeDisplayGroup.ResumeLayout(false);
            TimeDisplayGroup.PerformLayout();
            SystemControlsGroup.ResumeLayout(false);
            SystemControlsGroup.PerformLayout();
            TextDisplayGroup.ResumeLayout(false);
            TextDisplayGroup.PerformLayout();
            PrintingGroup.ResumeLayout(false);
            PrintingGroup.PerformLayout();
            NotificationsGroup.ResumeLayout(false);
            NotificationsGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.CheckBox OpenDashboardAutomaticallyBox;
    }
}
