namespace SharpAlert.ConfigurationDialogs
{
    partial class ChooseAudioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseAudioForm));
            this.DoneButton = new System.Windows.Forms.Button();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.RefreshOutputsButton = new System.Windows.Forms.Button();
            this.AudioDeviceCombo = new System.Windows.Forms.ComboBox();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.LegacyAudioPlayerBox = new System.Windows.Forms.CheckBox();
            this.alertPlayEndToneBox = new System.Windows.Forms.CheckBox();
            this.AudioOutputClearLink = new System.Windows.Forms.LinkLabel();
            this.TTSButton = new System.Windows.Forms.Button();
            this.EnableBasicSpeakingBox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.alertTTSonlyBox = new System.Windows.Forms.CheckBox();
            this.alertPlayStartToneTwiceBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AudioOutputLabel = new System.Windows.Forms.Label();
            this.GlobalVolumeLabel = new System.Windows.Forms.Label();
            this.ApplicationTypeGroup = new System.Windows.Forms.GroupBox();
            this.SupportedLinesButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.ChangeEndButton = new System.Windows.Forms.Button();
            this.ChangeStartButton = new System.Windows.Forms.Button();
            this.AudioTinkeringFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ShowRefreshTip = new System.Windows.Forms.Timer(this.components);
            this.ChangeStartLowButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.ApplicationTypeGroup.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneButton.Location = new System.Drawing.Point(506, 372);
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
            // 
            // TitleText
            // 
            this.TitleText.Font = new System.Drawing.Font("Arial", 16F);
            this.TitleText.Location = new System.Drawing.Point(105, 9);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(473, 30);
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "Choose your audio settings.";
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
            // RefreshOutputsButton
            // 
            this.RefreshOutputsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RefreshOutputsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.RefreshOutputsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RefreshOutputsButton.Font = new System.Drawing.Font("Arial", 9F);
            this.RefreshOutputsButton.Location = new System.Drawing.Point(506, 57);
            this.RefreshOutputsButton.Name = "RefreshOutputsButton";
            this.RefreshOutputsButton.Size = new System.Drawing.Size(72, 23);
            this.RefreshOutputsButton.TabIndex = 42;
            this.RefreshOutputsButton.Text = "Refresh";
            this.ToolTipInformation.SetToolTip(this.RefreshOutputsButton, "Refreshes the audio output list.");
            this.RefreshOutputsButton.UseMnemonic = false;
            this.RefreshOutputsButton.UseVisualStyleBackColor = false;
            this.RefreshOutputsButton.Click += new System.EventHandler(this.RefreshOutputsButton_Click);
            // 
            // AudioDeviceCombo
            // 
            this.AudioDeviceCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioDeviceCombo.BackColor = System.Drawing.Color.Black;
            this.AudioDeviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AudioDeviceCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AudioDeviceCombo.ForeColor = System.Drawing.Color.White;
            this.AudioDeviceCombo.FormattingEnabled = true;
            this.AudioDeviceCombo.Items.AddRange(new object[] {
            "Refresh the outputs..."});
            this.AudioDeviceCombo.Location = new System.Drawing.Point(110, 57);
            this.AudioDeviceCombo.Name = "AudioDeviceCombo";
            this.AudioDeviceCombo.Size = new System.Drawing.Size(390, 23);
            this.AudioDeviceCombo.TabIndex = 40;
            this.ToolTipInformation.SetToolTip(this.AudioDeviceCombo, "Choose the audio output device to use for sounds.");
            this.AudioDeviceCombo.SelectedIndexChanged += new System.EventHandler(this.AudioDeviceCombo_SelectedIndexChanged);
            // 
            // volumeBar
            // 
            this.volumeBar.LargeChange = 1;
            this.volumeBar.Location = new System.Drawing.Point(174, 83);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(404, 45);
            this.volumeBar.TabIndex = 44;
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.ToolTipInformation.SetToolTip(this.volumeBar, "Controls the global volume of the application.");
            // 
            // LegacyAudioPlayerBox
            // 
            this.LegacyAudioPlayerBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.LegacyAudioPlayerBox.AutoSize = true;
            this.LegacyAudioPlayerBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.LegacyAudioPlayerBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LegacyAudioPlayerBox.Location = new System.Drawing.Point(110, 131);
            this.LegacyAudioPlayerBox.Name = "LegacyAudioPlayerBox";
            this.LegacyAudioPlayerBox.Size = new System.Drawing.Size(148, 25);
            this.LegacyAudioPlayerBox.TabIndex = 45;
            this.LegacyAudioPlayerBox.Text = "Use legacy audio player";
            this.ToolTipInformation.SetToolTip(this.LegacyAudioPlayerBox, "Switches out the default audio player (NAudio) in favor of the legacy audio playe" +
        "r (SoundPlayer).\r\nThe program will immediately close if you change this option.");
            this.LegacyAudioPlayerBox.UseVisualStyleBackColor = false;
            // 
            // alertPlayEndToneBox
            // 
            this.alertPlayEndToneBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.alertPlayEndToneBox.AutoSize = true;
            this.alertPlayEndToneBox.Location = new System.Drawing.Point(478, 134);
            this.alertPlayEndToneBox.Name = "alertPlayEndToneBox";
            this.alertPlayEndToneBox.Size = new System.Drawing.Size(100, 19);
            this.alertPlayEndToneBox.TabIndex = 46;
            this.alertPlayEndToneBox.Text = "Play end tone";
            this.ToolTipInformation.SetToolTip(this.alertPlayEndToneBox, "Plays an auditory tone when an alert is closed.");
            this.alertPlayEndToneBox.UseVisualStyleBackColor = true;
            // 
            // AudioOutputClearLink
            // 
            this.AudioOutputClearLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AudioOutputClearLink.AutoSize = true;
            this.AudioOutputClearLink.Font = new System.Drawing.Font("Arial", 9F);
            this.AudioOutputClearLink.LinkColor = System.Drawing.Color.Pink;
            this.AudioOutputClearLink.Location = new System.Drawing.Point(394, 39);
            this.AudioOutputClearLink.Name = "AudioOutputClearLink";
            this.AudioOutputClearLink.Size = new System.Drawing.Size(184, 15);
            this.AudioOutputClearLink.TabIndex = 47;
            this.AudioOutputClearLink.TabStop = true;
            this.AudioOutputClearLink.Text = "Use first available device (Clear)";
            this.ToolTipInformation.SetToolTip(this.AudioOutputClearLink, "Uses the first available audio device.");
            this.AudioOutputClearLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AudioOutputClearLink_LinkClicked);
            // 
            // TTSButton
            // 
            this.TTSButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TTSButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.TTSButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TTSButton.Location = new System.Drawing.Point(403, 372);
            this.TTSButton.Name = "TTSButton";
            this.TTSButton.Size = new System.Drawing.Size(100, 23);
            this.TTSButton.TabIndex = 48;
            this.TTSButton.Text = "TTS Settings";
            this.ToolTipInformation.SetToolTip(this.TTSButton, "Opens the TTS configuration window.");
            this.TTSButton.UseMnemonic = false;
            this.TTSButton.UseVisualStyleBackColor = false;
            this.TTSButton.Click += new System.EventHandler(this.TTSButton_Click);
            // 
            // EnableBasicSpeakingBox
            // 
            this.EnableBasicSpeakingBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnableBasicSpeakingBox.AutoSize = true;
            this.EnableBasicSpeakingBox.Location = new System.Drawing.Point(311, 20);
            this.EnableBasicSpeakingBox.Name = "EnableBasicSpeakingBox";
            this.EnableBasicSpeakingBox.Size = new System.Drawing.Size(152, 19);
            this.EnableBasicSpeakingBox.TabIndex = 14;
            this.EnableBasicSpeakingBox.Text = "Enable basic speaking";
            this.EnableBasicSpeakingBox.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ToolTipInformation.SetToolTip(this.EnableBasicSpeakingBox, "Enables Basic Speaking.");
            this.EnableBasicSpeakingBox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(344, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "To clear an alert sound, click the button for it, then click cancel.";
            this.ToolTipInformation.SetToolTip(this.label2, "If you choose custom sounds, you will not be able to control the severity level t" +
        "hey play at.");
            // 
            // alertTTSonlyBox
            // 
            this.alertTTSonlyBox.AutoSize = true;
            this.alertTTSonlyBox.Location = new System.Drawing.Point(313, 134);
            this.alertTTSonlyBox.Name = "alertTTSonlyBox";
            this.alertTTSonlyBox.Size = new System.Drawing.Size(159, 19);
            this.alertTTSonlyBox.TabIndex = 51;
            this.alertTTSonlyBox.Text = "Never play remote audio";
            this.ToolTipInformation.SetToolTip(this.alertTTSonlyBox, "Turn off requests for remote audio. Only plays TTS.");
            this.alertTTSonlyBox.UseVisualStyleBackColor = true;
            // 
            // alertPlayStartToneTwiceBox
            // 
            this.alertPlayStartToneTwiceBox.AutoSize = true;
            this.alertPlayStartToneTwiceBox.Location = new System.Drawing.Point(313, 159);
            this.alertPlayStartToneTwiceBox.Name = "alertPlayStartToneTwiceBox";
            this.alertPlayStartToneTwiceBox.Size = new System.Drawing.Size(117, 19);
            this.alertPlayStartToneTwiceBox.TabIndex = 52;
            this.alertPlayStartToneTwiceBox.Text = "Extend alert tone";
            this.ToolTipInformation.SetToolTip(this.alertPlayStartToneTwiceBox, "Extends the start tone by instructing the audio stack to play it twice.");
            this.alertPlayStartToneTwiceBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(9, 369);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "To change these options later, go to Settings.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // AudioOutputLabel
            // 
            this.AudioOutputLabel.AutoSize = true;
            this.AudioOutputLabel.Font = new System.Drawing.Font("Arial", 9F);
            this.AudioOutputLabel.Location = new System.Drawing.Point(107, 39);
            this.AudioOutputLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AudioOutputLabel.Name = "AudioOutputLabel";
            this.AudioOutputLabel.Size = new System.Drawing.Size(77, 15);
            this.AudioOutputLabel.TabIndex = 41;
            this.AudioOutputLabel.Text = "Audio Output";
            this.AudioOutputLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // GlobalVolumeLabel
            // 
            this.GlobalVolumeLabel.Location = new System.Drawing.Point(108, 83);
            this.GlobalVolumeLabel.Name = "GlobalVolumeLabel";
            this.GlobalVolumeLabel.Size = new System.Drawing.Size(60, 45);
            this.GlobalVolumeLabel.TabIndex = 43;
            this.GlobalVolumeLabel.Text = "Global\r\nVolume";
            this.GlobalVolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ApplicationTypeGroup
            // 
            this.ApplicationTypeGroup.Controls.Add(this.SupportedLinesButton);
            this.ApplicationTypeGroup.Controls.Add(this.EnableBasicSpeakingBox);
            this.ApplicationTypeGroup.Controls.Add(this.label3);
            this.ApplicationTypeGroup.ForeColor = System.Drawing.Color.White;
            this.ApplicationTypeGroup.Location = new System.Drawing.Point(110, 184);
            this.ApplicationTypeGroup.Name = "ApplicationTypeGroup";
            this.ApplicationTypeGroup.Size = new System.Drawing.Size(468, 76);
            this.ApplicationTypeGroup.TabIndex = 49;
            this.ApplicationTypeGroup.TabStop = false;
            this.ApplicationTypeGroup.Text = "Basic Speaking";
            // 
            // SupportedLinesButton
            // 
            this.SupportedLinesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SupportedLinesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SupportedLinesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SupportedLinesButton.Location = new System.Drawing.Point(311, 42);
            this.SupportedLinesButton.Margin = new System.Windows.Forms.Padding(0);
            this.SupportedLinesButton.Name = "SupportedLinesButton";
            this.SupportedLinesButton.Size = new System.Drawing.Size(151, 23);
            this.SupportedLinesButton.TabIndex = 50;
            this.SupportedLinesButton.Text = "Supported Lines";
            this.SupportedLinesButton.UseVisualStyleBackColor = false;
            this.SupportedLinesButton.Click += new System.EventHandler(this.SupportedLinesButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(236, 45);
            this.label3.TabIndex = 6;
            this.label3.Text = "The program can speak basic information\r\nabout your current actions, or of an ale" +
    "rt\r\nvia pre-recorded voice lines or sounds.";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.ChangeStartLowButton);
            this.groupBox10.Controls.Add(this.label2);
            this.groupBox10.Controls.Add(this.ChangeEndButton);
            this.groupBox10.Controls.Add(this.ChangeStartButton);
            this.groupBox10.ForeColor = System.Drawing.Color.White;
            this.groupBox10.Location = new System.Drawing.Point(110, 266);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(468, 95);
            this.groupBox10.TabIndex = 50;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Program Events";
            // 
            // ChangeEndButton
            // 
            this.ChangeEndButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ChangeEndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChangeEndButton.Location = new System.Drawing.Point(287, 35);
            this.ChangeEndButton.Name = "ChangeEndButton";
            this.ChangeEndButton.Size = new System.Drawing.Size(175, 52);
            this.ChangeEndButton.TabIndex = 51;
            this.ChangeEndButton.Text = "Select End Tone Location";
            this.ChangeEndButton.UseVisualStyleBackColor = false;
            this.ChangeEndButton.Click += new System.EventHandler(this.ChangeEndButton_Click);
            // 
            // ChangeStartButton
            // 
            this.ChangeStartButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ChangeStartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChangeStartButton.Location = new System.Drawing.Point(6, 35);
            this.ChangeStartButton.Name = "ChangeStartButton";
            this.ChangeStartButton.Size = new System.Drawing.Size(275, 23);
            this.ChangeStartButton.TabIndex = 49;
            this.ChangeStartButton.Text = "Select (Severe+) Start Tone Location";
            this.ChangeStartButton.UseVisualStyleBackColor = false;
            this.ChangeStartButton.Click += new System.EventHandler(this.ChangeStartButton_Click);
            // 
            // ShowRefreshTip
            // 
            this.ShowRefreshTip.Enabled = true;
            this.ShowRefreshTip.Interval = 1000;
            this.ShowRefreshTip.Tick += new System.EventHandler(this.ShowRefreshTip_Tick);
            // 
            // ChangeStartLowButton
            // 
            this.ChangeStartLowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ChangeStartLowButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ChangeStartLowButton.Location = new System.Drawing.Point(6, 64);
            this.ChangeStartLowButton.Name = "ChangeStartLowButton";
            this.ChangeStartLowButton.Size = new System.Drawing.Size(275, 23);
            this.ChangeStartLowButton.TabIndex = 50;
            this.ChangeStartLowButton.Text = "Select (Moderate-) Start Tone Location";
            this.ChangeStartLowButton.UseVisualStyleBackColor = false;
            this.ChangeStartLowButton.Click += new System.EventHandler(this.ChangeStartLowButton_Click);
            // 
            // ChooseAudioForm
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(587, 404);
            this.Controls.Add(this.alertPlayStartToneTwiceBox);
            this.Controls.Add(this.alertTTSonlyBox);
            this.Controls.Add(this.groupBox10);
            this.Controls.Add(this.ApplicationTypeGroup);
            this.Controls.Add(this.TTSButton);
            this.Controls.Add(this.AudioOutputClearLink);
            this.Controls.Add(this.alertPlayEndToneBox);
            this.Controls.Add(this.LegacyAudioPlayerBox);
            this.Controls.Add(this.GlobalVolumeLabel);
            this.Controls.Add(this.volumeBar);
            this.Controls.Add(this.RefreshOutputsButton);
            this.Controls.Add(this.AudioOutputLabel);
            this.Controls.Add(this.AudioDeviceCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.LogoBox);
            this.Controls.Add(this.DoneButton);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseAudioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Audio Selection";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ChooseRegionForm_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseRegionForm_FormClosing);
            this.Load += new System.EventHandler(this.ChooseRegionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.ApplicationTypeGroup.ResumeLayout(false);
            this.ApplicationTypeGroup.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RefreshOutputsButton;
        private System.Windows.Forms.Label AudioOutputLabel;
        private System.Windows.Forms.ComboBox AudioDeviceCombo;
        private System.Windows.Forms.Label GlobalVolumeLabel;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.CheckBox LegacyAudioPlayerBox;
        private System.Windows.Forms.CheckBox alertPlayEndToneBox;
        private System.Windows.Forms.LinkLabel AudioOutputClearLink;
        private System.Windows.Forms.Button TTSButton;
        private System.Windows.Forms.GroupBox ApplicationTypeGroup;
        private System.Windows.Forms.CheckBox EnableBasicSpeakingBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SupportedLinesButton;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ChangeEndButton;
        private System.Windows.Forms.Button ChangeStartButton;
        private System.Windows.Forms.OpenFileDialog AudioTinkeringFileDialog;
        private System.Windows.Forms.Timer ShowRefreshTip;
        private System.Windows.Forms.CheckBox alertTTSonlyBox;
        private System.Windows.Forms.CheckBox alertPlayStartToneTwiceBox;
        private System.Windows.Forms.Button ChangeStartLowButton;
    }
}
