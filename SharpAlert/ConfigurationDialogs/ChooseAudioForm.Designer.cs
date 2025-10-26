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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseAudioForm));
            DoneButton = new System.Windows.Forms.Button();
            LogoBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            RefreshOutputsButton = new System.Windows.Forms.Button();
            AudioDeviceCombo = new System.Windows.Forms.ComboBox();
            volumeBar = new System.Windows.Forms.TrackBar();
            LegacyAudioPlayerBox = new System.Windows.Forms.CheckBox();
            alertPlayEndToneBox = new System.Windows.Forms.CheckBox();
            AudioOutputClearLink = new System.Windows.Forms.LinkLabel();
            TTSButton = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            alertTTSonlyBox = new System.Windows.Forms.CheckBox();
            alertPlayStartToneTwiceBox = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            AudioOutputLabel = new System.Windows.Forms.Label();
            GlobalVolumeLabel = new System.Windows.Forms.Label();
            ApplicationTypeGroup = new System.Windows.Forms.GroupBox();
            label3 = new System.Windows.Forms.Label();
            groupBox10 = new System.Windows.Forms.GroupBox();
            ChangeStartLowButton = new System.Windows.Forms.Button();
            ChangeEndButton = new System.Windows.Forms.Button();
            ChangeStartButton = new System.Windows.Forms.Button();
            AudioTinkeringFileDialog = new System.Windows.Forms.OpenFileDialog();
            ShowRefreshTip = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)volumeBar).BeginInit();
            ApplicationTypeGroup.SuspendLayout();
            groupBox10.SuspendLayout();
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Location = new System.Drawing.Point(506, 350);
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
            // 
            // TitleText
            // 
            TitleText.Font = new System.Drawing.Font("Segoe UI", 16F);
            TitleText.Location = new System.Drawing.Point(105, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(473, 30);
            TitleText.TabIndex = 3;
            TitleText.Text = "Choose your audio settings.";
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
            // RefreshOutputsButton
            // 
            RefreshOutputsButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            RefreshOutputsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            RefreshOutputsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            RefreshOutputsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            RefreshOutputsButton.Location = new System.Drawing.Point(506, 57);
            RefreshOutputsButton.Name = "RefreshOutputsButton";
            RefreshOutputsButton.Size = new System.Drawing.Size(72, 23);
            RefreshOutputsButton.TabIndex = 42;
            RefreshOutputsButton.Text = "Refresh";
            ToolTipInformation.SetToolTip(RefreshOutputsButton, "Refreshes the audio output list.");
            RefreshOutputsButton.UseMnemonic = false;
            RefreshOutputsButton.UseVisualStyleBackColor = false;
            RefreshOutputsButton.Click += RefreshOutputsButton_Click;
            // 
            // AudioDeviceCombo
            // 
            AudioDeviceCombo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AudioDeviceCombo.BackColor = System.Drawing.Color.Black;
            AudioDeviceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            AudioDeviceCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AudioDeviceCombo.ForeColor = System.Drawing.Color.White;
            AudioDeviceCombo.FormattingEnabled = true;
            AudioDeviceCombo.Items.AddRange(new object[] { "Refresh the outputs..." });
            AudioDeviceCombo.Location = new System.Drawing.Point(110, 57);
            AudioDeviceCombo.Name = "AudioDeviceCombo";
            AudioDeviceCombo.Size = new System.Drawing.Size(390, 23);
            AudioDeviceCombo.TabIndex = 40;
            ToolTipInformation.SetToolTip(AudioDeviceCombo, "Choose the audio output device to use for sounds.");
            AudioDeviceCombo.SelectedIndexChanged += AudioDeviceCombo_SelectedIndexChanged;
            // 
            // volumeBar
            // 
            volumeBar.LargeChange = 1;
            volumeBar.Location = new System.Drawing.Point(174, 83);
            volumeBar.Name = "volumeBar";
            volumeBar.Size = new System.Drawing.Size(404, 45);
            volumeBar.TabIndex = 44;
            volumeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            ToolTipInformation.SetToolTip(volumeBar, "Controls the global volume of the application.");
            // 
            // LegacyAudioPlayerBox
            // 
            LegacyAudioPlayerBox.Appearance = System.Windows.Forms.Appearance.Button;
            LegacyAudioPlayerBox.AutoSize = true;
            LegacyAudioPlayerBox.BackColor = System.Drawing.Color.FromArgb(80, 80, 80);
            LegacyAudioPlayerBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            LegacyAudioPlayerBox.Location = new System.Drawing.Point(110, 131);
            LegacyAudioPlayerBox.Name = "LegacyAudioPlayerBox";
            LegacyAudioPlayerBox.Size = new System.Drawing.Size(141, 25);
            LegacyAudioPlayerBox.TabIndex = 45;
            LegacyAudioPlayerBox.Text = "Use legacy audio player";
            ToolTipInformation.SetToolTip(LegacyAudioPlayerBox, "Switches out the default audio player (NAudio) in favor of the legacy audio player (SoundPlayer).\r\nThe program will immediately close if you change this option.");
            LegacyAudioPlayerBox.UseVisualStyleBackColor = false;
            // 
            // alertPlayEndToneBox
            // 
            alertPlayEndToneBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            alertPlayEndToneBox.AutoSize = true;
            alertPlayEndToneBox.Location = new System.Drawing.Point(480, 134);
            alertPlayEndToneBox.Name = "alertPlayEndToneBox";
            alertPlayEndToneBox.Size = new System.Drawing.Size(98, 19);
            alertPlayEndToneBox.TabIndex = 46;
            alertPlayEndToneBox.Text = "Play end tone";
            ToolTipInformation.SetToolTip(alertPlayEndToneBox, "Plays an auditory tone when an alert is closed.");
            alertPlayEndToneBox.UseVisualStyleBackColor = true;
            // 
            // AudioOutputClearLink
            // 
            AudioOutputClearLink.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AudioOutputClearLink.AutoSize = true;
            AudioOutputClearLink.Font = new System.Drawing.Font("Segoe UI", 9F);
            AudioOutputClearLink.LinkColor = System.Drawing.Color.Pink;
            AudioOutputClearLink.Location = new System.Drawing.Point(394, 39);
            AudioOutputClearLink.Name = "AudioOutputClearLink";
            AudioOutputClearLink.Size = new System.Drawing.Size(173, 15);
            AudioOutputClearLink.TabIndex = 47;
            AudioOutputClearLink.TabStop = true;
            AudioOutputClearLink.Text = "Use first available device (Clear)";
            ToolTipInformation.SetToolTip(AudioOutputClearLink, "Uses the first available audio device.");
            AudioOutputClearLink.LinkClicked += AudioOutputClearLink_LinkClicked;
            // 
            // TTSButton
            // 
            TTSButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            TTSButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            TTSButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            TTSButton.Location = new System.Drawing.Point(403, 350);
            TTSButton.Name = "TTSButton";
            TTSButton.Size = new System.Drawing.Size(100, 23);
            TTSButton.TabIndex = 48;
            TTSButton.Text = "TTS Settings";
            ToolTipInformation.SetToolTip(TTSButton, "Opens the TTS configuration window.");
            TTSButton.UseMnemonic = false;
            TTSButton.UseVisualStyleBackColor = false;
            TTSButton.Click += TTSButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.Yellow;
            label2.Location = new System.Drawing.Point(6, 17);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(339, 15);
            label2.TabIndex = 8;
            label2.Text = "To clear an alert sound, click the button for it, then click cancel.";
            ToolTipInformation.SetToolTip(label2, "If you choose custom sounds, you will not be able to control the severity level they play at.");
            // 
            // alertTTSonlyBox
            // 
            alertTTSonlyBox.AutoSize = true;
            alertTTSonlyBox.Location = new System.Drawing.Point(313, 134);
            alertTTSonlyBox.Name = "alertTTSonlyBox";
            alertTTSonlyBox.Size = new System.Drawing.Size(156, 19);
            alertTTSonlyBox.TabIndex = 51;
            alertTTSonlyBox.Text = "Never play remote audio";
            ToolTipInformation.SetToolTip(alertTTSonlyBox, "Turn off requests for remote audio. Only plays TTS.");
            alertTTSonlyBox.UseVisualStyleBackColor = true;
            // 
            // alertPlayStartToneTwiceBox
            // 
            alertPlayStartToneTwiceBox.AutoSize = true;
            alertPlayStartToneTwiceBox.Location = new System.Drawing.Point(313, 159);
            alertPlayStartToneTwiceBox.Name = "alertPlayStartToneTwiceBox";
            alertPlayStartToneTwiceBox.Size = new System.Drawing.Size(115, 19);
            alertPlayStartToneTwiceBox.TabIndex = 52;
            alertPlayStartToneTwiceBox.Text = "Extend alert tone";
            ToolTipInformation.SetToolTip(alertPlayStartToneTwiceBox, "Extends the start tone by instructing the audio stack to play it twice.");
            alertPlayStartToneTwiceBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(9, 347);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(332, 26);
            label1.TabIndex = 13;
            label1.Text = "To change these options later, go to Settings.";
            label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // AudioOutputLabel
            // 
            AudioOutputLabel.AutoSize = true;
            AudioOutputLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            AudioOutputLabel.Location = new System.Drawing.Point(107, 39);
            AudioOutputLabel.Margin = new System.Windows.Forms.Padding(0);
            AudioOutputLabel.Name = "AudioOutputLabel";
            AudioOutputLabel.Size = new System.Drawing.Size(80, 15);
            AudioOutputLabel.TabIndex = 41;
            AudioOutputLabel.Text = "Audio Output";
            AudioOutputLabel.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // GlobalVolumeLabel
            // 
            GlobalVolumeLabel.Location = new System.Drawing.Point(108, 83);
            GlobalVolumeLabel.Name = "GlobalVolumeLabel";
            GlobalVolumeLabel.Size = new System.Drawing.Size(60, 45);
            GlobalVolumeLabel.TabIndex = 43;
            GlobalVolumeLabel.Text = "Global\r\nVolume";
            GlobalVolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ApplicationTypeGroup
            // 
            ApplicationTypeGroup.Controls.Add(label3);
            ApplicationTypeGroup.ForeColor = System.Drawing.Color.White;
            ApplicationTypeGroup.Location = new System.Drawing.Point(110, 184);
            ApplicationTypeGroup.Name = "ApplicationTypeGroup";
            ApplicationTypeGroup.Size = new System.Drawing.Size(468, 56);
            ApplicationTypeGroup.TabIndex = 49;
            ApplicationTypeGroup.TabStop = false;
            ApplicationTypeGroup.Text = "Basic Speaking";
            // 
            // label3
            // 
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Location = new System.Drawing.Point(3, 19);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(462, 34);
            label3.TabIndex = 6;
            label3.Text = "All Basic Speaking functions have been deprecated due to the lack of need and usage for such a feature to exist in the first place.";
            // 
            // groupBox10
            // 
            groupBox10.Controls.Add(ChangeStartLowButton);
            groupBox10.Controls.Add(label2);
            groupBox10.Controls.Add(ChangeEndButton);
            groupBox10.Controls.Add(ChangeStartButton);
            groupBox10.ForeColor = System.Drawing.Color.White;
            groupBox10.Location = new System.Drawing.Point(110, 246);
            groupBox10.Name = "groupBox10";
            groupBox10.Size = new System.Drawing.Size(468, 95);
            groupBox10.TabIndex = 50;
            groupBox10.TabStop = false;
            groupBox10.Text = "Program Events";
            // 
            // ChangeStartLowButton
            // 
            ChangeStartLowButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ChangeStartLowButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ChangeStartLowButton.Location = new System.Drawing.Point(6, 64);
            ChangeStartLowButton.Name = "ChangeStartLowButton";
            ChangeStartLowButton.Size = new System.Drawing.Size(275, 23);
            ChangeStartLowButton.TabIndex = 50;
            ChangeStartLowButton.Text = "Select (Moderate-) Start Tone Location";
            ChangeStartLowButton.UseVisualStyleBackColor = false;
            ChangeStartLowButton.Click += ChangeStartLowButton_Click;
            // 
            // ChangeEndButton
            // 
            ChangeEndButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ChangeEndButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ChangeEndButton.Location = new System.Drawing.Point(287, 35);
            ChangeEndButton.Name = "ChangeEndButton";
            ChangeEndButton.Size = new System.Drawing.Size(175, 52);
            ChangeEndButton.TabIndex = 51;
            ChangeEndButton.Text = "Select End Tone Location";
            ChangeEndButton.UseVisualStyleBackColor = false;
            ChangeEndButton.Click += ChangeEndButton_Click;
            // 
            // ChangeStartButton
            // 
            ChangeStartButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ChangeStartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ChangeStartButton.Location = new System.Drawing.Point(6, 35);
            ChangeStartButton.Name = "ChangeStartButton";
            ChangeStartButton.Size = new System.Drawing.Size(275, 23);
            ChangeStartButton.TabIndex = 49;
            ChangeStartButton.Text = "Select (Severe+) Start Tone Location";
            ChangeStartButton.UseVisualStyleBackColor = false;
            ChangeStartButton.Click += ChangeStartButton_Click;
            // 
            // ShowRefreshTip
            // 
            ShowRefreshTip.Enabled = true;
            ShowRefreshTip.Interval = 1000;
            ShowRefreshTip.Tick += ShowRefreshTip_Tick;
            // 
            // ChooseAudioForm
            // 
            AcceptButton = DoneButton;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(587, 382);
            Controls.Add(alertPlayStartToneTwiceBox);
            Controls.Add(alertTTSonlyBox);
            Controls.Add(groupBox10);
            Controls.Add(ApplicationTypeGroup);
            Controls.Add(TTSButton);
            Controls.Add(AudioOutputClearLink);
            Controls.Add(alertPlayEndToneBox);
            Controls.Add(LegacyAudioPlayerBox);
            Controls.Add(GlobalVolumeLabel);
            Controls.Add(volumeBar);
            Controls.Add(RefreshOutputsButton);
            Controls.Add(AudioOutputLabel);
            Controls.Add(AudioDeviceCombo);
            Controls.Add(label1);
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
            Name = "ChooseAudioForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Audio Selection";
            HelpButtonClicked += ChooseRegionForm_HelpButtonClicked;
            FormClosing += ChooseRegionForm_FormClosing;
            Load += ChooseRegionForm_Load;
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)volumeBar).EndInit();
            ApplicationTypeGroup.ResumeLayout(false);
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.Label label3;
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
