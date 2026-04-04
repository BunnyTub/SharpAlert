namespace SharpAlert.ConfigurationDialogs
{
    partial class ExtraConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExtraConfigurationForm));
            DoneButton = new System.Windows.Forms.Button();
            LogoBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            alertCompatibilityModeBox = new System.Windows.Forms.CheckBox();
            alertFullscreenIdleBox = new System.Windows.Forms.CheckBox();
            statusWindowBox = new System.Windows.Forms.CheckBox();
            NoSystemSleepBox = new System.Windows.Forms.CheckBox();
            HideNetworkErrorsBox = new System.Windows.Forms.CheckBox();
            OpenDashboardAutomaticallyBox = new System.Windows.Forms.CheckBox();
            PlayChimeOnRunBox = new System.Windows.Forms.CheckBox();
            ChildLockBox = new System.Windows.Forms.CheckBox();
            ChangeLaterText = new System.Windows.Forms.Label();
            DisplayPanelsGroup = new System.Windows.Forms.GroupBox();
            SystemControlsGroup = new System.Windows.Forms.GroupBox();
            NotificationsGroup = new System.Windows.Forms.GroupBox();
            SaveSlotsButton = new System.Windows.Forms.Button();
            WindowShake = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            DisplayPanelsGroup.SuspendLayout();
            SystemControlsGroup.SuspendLayout();
            NotificationsGroup.SuspendLayout();
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Location = new System.Drawing.Point(362, 209);
            DoneButton.Margin = new System.Windows.Forms.Padding(0);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new System.Drawing.Size(116, 23);
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
            // 
            // TitleText
            // 
            TitleText.Font = new System.Drawing.Font("Segoe UI", 16F);
            TitleText.Location = new System.Drawing.Point(105, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(504, 30);
            TitleText.TabIndex = 3;
            TitleText.Text = "Choose your extra settings.";
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
            // alertCompatibilityModeBox
            // 
            alertCompatibilityModeBox.AutoSize = true;
            alertCompatibilityModeBox.Location = new System.Drawing.Point(6, 20);
            alertCompatibilityModeBox.Name = "alertCompatibilityModeBox";
            alertCompatibilityModeBox.Size = new System.Drawing.Size(132, 19);
            alertCompatibilityModeBox.TabIndex = 9;
            alertCompatibilityModeBox.Text = "Compatibility mode";
            ToolTipInformation.SetToolTip(alertCompatibilityModeBox, "Disables most animations and some background stuff. May help performance on older systems.");
            alertCompatibilityModeBox.UseVisualStyleBackColor = true;
            // 
            // alertFullscreenIdleBox
            // 
            alertFullscreenIdleBox.AutoSize = true;
            alertFullscreenIdleBox.BackColor = System.Drawing.Color.FromArgb(120, 20, 20);
            alertFullscreenIdleBox.Location = new System.Drawing.Point(6, 20);
            alertFullscreenIdleBox.Name = "alertFullscreenIdleBox";
            alertFullscreenIdleBox.Size = new System.Drawing.Size(120, 19);
            alertFullscreenIdleBox.TabIndex = 5;
            alertFullscreenIdleBox.Text = "Idle panel on start";
            ToolTipInformation.SetToolTip(alertFullscreenIdleBox, "Shows an idle panel on top of all content.");
            alertFullscreenIdleBox.UseVisualStyleBackColor = false;
            // 
            // statusWindowBox
            // 
            statusWindowBox.AutoSize = true;
            statusWindowBox.BackColor = System.Drawing.Color.FromArgb(120, 20, 20);
            statusWindowBox.Location = new System.Drawing.Point(6, 45);
            statusWindowBox.Name = "statusWindowBox";
            statusWindowBox.Size = new System.Drawing.Size(133, 19);
            statusWindowBox.TabIndex = 6;
            statusWindowBox.Text = "Status panel on start";
            ToolTipInformation.SetToolTip(statusWindowBox, "Shows the status window.");
            statusWindowBox.UseVisualStyleBackColor = false;
            // 
            // NoSystemSleepBox
            // 
            NoSystemSleepBox.AutoSize = true;
            NoSystemSleepBox.Location = new System.Drawing.Point(6, 45);
            NoSystemSleepBox.Name = "NoSystemSleepBox";
            NoSystemSleepBox.Size = new System.Drawing.Size(130, 19);
            NoSystemSleepBox.TabIndex = 10;
            NoSystemSleepBox.Text = "Prevent sleep mode";
            ToolTipInformation.SetToolTip(NoSystemSleepBox, "Prevents the system from entering sleep mode at all times.");
            NoSystemSleepBox.UseVisualStyleBackColor = true;
            // 
            // HideNetworkErrorsBox
            // 
            HideNetworkErrorsBox.AutoSize = true;
            HideNetworkErrorsBox.Location = new System.Drawing.Point(6, 20);
            HideNetworkErrorsBox.Name = "HideNetworkErrorsBox";
            HideNetworkErrorsBox.Size = new System.Drawing.Size(140, 34);
            HideNetworkErrorsBox.TabIndex = 15;
            HideNetworkErrorsBox.Text = "Do not show network\r\nproblem notifications";
            ToolTipInformation.SetToolTip(HideNetworkErrorsBox, "Hides network error notifications from appearing.\r\nThey'll still appear in the console.");
            HideNetworkErrorsBox.UseVisualStyleBackColor = true;
            // 
            // OpenDashboardAutomaticallyBox
            // 
            OpenDashboardAutomaticallyBox.AutoSize = true;
            OpenDashboardAutomaticallyBox.Location = new System.Drawing.Point(6, 70);
            OpenDashboardAutomaticallyBox.Name = "OpenDashboardAutomaticallyBox";
            OpenDashboardAutomaticallyBox.Size = new System.Drawing.Size(126, 19);
            OpenDashboardAutomaticallyBox.TabIndex = 7;
            OpenDashboardAutomaticallyBox.Text = "Dashboard on start";
            ToolTipInformation.SetToolTip(OpenDashboardAutomaticallyBox, "Shows the dashboard. You can open this manually in the tray icon right-click menu.");
            OpenDashboardAutomaticallyBox.UseVisualStyleBackColor = true;
            // 
            // PlayChimeOnRunBox
            // 
            PlayChimeOnRunBox.AutoSize = true;
            PlayChimeOnRunBox.Location = new System.Drawing.Point(6, 95);
            PlayChimeOnRunBox.Name = "PlayChimeOnRunBox";
            PlayChimeOnRunBox.Size = new System.Drawing.Size(131, 34);
            PlayChimeOnRunBox.TabIndex = 16;
            PlayChimeOnRunBox.Text = "Notify me when the\r\nprogram fully starts";
            ToolTipInformation.SetToolTip(PlayChimeOnRunBox, "Shows a notification that covers the screen when the program is fully started.");
            PlayChimeOnRunBox.UseVisualStyleBackColor = true;
            // 
            // ChildLockBox
            // 
            ChildLockBox.AutoSize = true;
            ChildLockBox.Location = new System.Drawing.Point(108, 183);
            ChildLockBox.Name = "ChildLockBox";
            ChildLockBox.Size = new System.Drawing.Size(156, 19);
            ChildLockBox.TabIndex = 11;
            ChildLockBox.Text = "Math problem child lock";
            ToolTipInformation.SetToolTip(ChildLockBox, "Displays a question each time the settings window is opened.\r\nIf the answer to the question is wrong, the settings window will not open.");
            ChildLockBox.UseVisualStyleBackColor = true;
            // 
            // ChangeLaterText
            // 
            ChangeLaterText.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ChangeLaterText.Font = new System.Drawing.Font("Segoe UI", 10F);
            ChangeLaterText.Location = new System.Drawing.Point(9, 184);
            ChangeLaterText.Margin = new System.Windows.Forms.Padding(0);
            ChangeLaterText.Name = "ChangeLaterText";
            ChangeLaterText.Size = new System.Drawing.Size(353, 48);
            ChangeLaterText.TabIndex = 13;
            ChangeLaterText.Text = "To change these options later, go to Settings.";
            ChangeLaterText.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // DisplayPanelsGroup
            // 
            DisplayPanelsGroup.Controls.Add(PlayChimeOnRunBox);
            DisplayPanelsGroup.Controls.Add(OpenDashboardAutomaticallyBox);
            DisplayPanelsGroup.Controls.Add(alertFullscreenIdleBox);
            DisplayPanelsGroup.Controls.Add(statusWindowBox);
            DisplayPanelsGroup.ForeColor = System.Drawing.Color.White;
            DisplayPanelsGroup.Location = new System.Drawing.Point(108, 42);
            DisplayPanelsGroup.Name = "DisplayPanelsGroup";
            DisplayPanelsGroup.Size = new System.Drawing.Size(163, 135);
            DisplayPanelsGroup.TabIndex = 54;
            DisplayPanelsGroup.TabStop = false;
            DisplayPanelsGroup.Text = "Startup";
            // 
            // SystemControlsGroup
            // 
            SystemControlsGroup.Controls.Add(alertCompatibilityModeBox);
            SystemControlsGroup.Controls.Add(NoSystemSleepBox);
            SystemControlsGroup.ForeColor = System.Drawing.Color.White;
            SystemControlsGroup.Location = new System.Drawing.Point(277, 42);
            SystemControlsGroup.Name = "SystemControlsGroup";
            SystemControlsGroup.Size = new System.Drawing.Size(163, 70);
            SystemControlsGroup.TabIndex = 57;
            SystemControlsGroup.TabStop = false;
            SystemControlsGroup.Text = "System";
            // 
            // NotificationsGroup
            // 
            NotificationsGroup.Controls.Add(HideNetworkErrorsBox);
            NotificationsGroup.ForeColor = System.Drawing.Color.White;
            NotificationsGroup.Location = new System.Drawing.Point(277, 118);
            NotificationsGroup.Name = "NotificationsGroup";
            NotificationsGroup.Size = new System.Drawing.Size(163, 59);
            NotificationsGroup.TabIndex = 60;
            NotificationsGroup.TabStop = false;
            NotificationsGroup.Text = "Networking";
            // 
            // SaveSlotsButton
            // 
            SaveSlotsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            SaveSlotsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SaveSlotsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SaveSlotsButton.Location = new System.Drawing.Point(362, 184);
            SaveSlotsButton.Margin = new System.Windows.Forms.Padding(0);
            SaveSlotsButton.Name = "SaveSlotsButton";
            SaveSlotsButton.Size = new System.Drawing.Size(116, 23);
            SaveSlotsButton.TabIndex = 61;
            SaveSlotsButton.Text = "Save Slots";
            SaveSlotsButton.UseVisualStyleBackColor = false;
            SaveSlotsButton.Click += SaveSlotsButton_Click;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // ExtraConfigurationForm
            // 
            AcceptButton = DoneButton;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(487, 241);
            Controls.Add(ChildLockBox);
            Controls.Add(SaveSlotsButton);
            Controls.Add(DisplayPanelsGroup);
            Controls.Add(NotificationsGroup);
            Controls.Add(ChangeLaterText);
            Controls.Add(SystemControlsGroup);
            Controls.Add(TitleText);
            Controls.Add(LogoBox);
            Controls.Add(DoneButton);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExtraConfigurationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Extra Settings";
            HelpButtonClicked += ChooseRegionForm_HelpButtonClicked;
            FormClosing += ChooseRegionForm_FormClosing;
            Load += ChooseRegionForm_Load;
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            DisplayPanelsGroup.ResumeLayout(false);
            DisplayPanelsGroup.PerformLayout();
            SystemControlsGroup.ResumeLayout(false);
            SystemControlsGroup.PerformLayout();
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
        private System.Windows.Forms.Label ChangeLaterText;
        private System.Windows.Forms.CheckBox alertCompatibilityModeBox;
        private System.Windows.Forms.CheckBox alertFullscreenIdleBox;
        private System.Windows.Forms.CheckBox statusWindowBox;
        private System.Windows.Forms.CheckBox NoSystemSleepBox;
        private System.Windows.Forms.GroupBox DisplayPanelsGroup;
        private System.Windows.Forms.CheckBox HideNetworkErrorsBox;
        private System.Windows.Forms.GroupBox SystemControlsGroup;
        private System.Windows.Forms.GroupBox NotificationsGroup;
        private System.Windows.Forms.CheckBox OpenDashboardAutomaticallyBox;
        private System.Windows.Forms.CheckBox PlayChimeOnRunBox;
        private System.Windows.Forms.Button SaveSlotsButton;
        private System.Windows.Forms.Timer WindowShake;
        private System.Windows.Forms.CheckBox ChildLockBox;
    }
}
