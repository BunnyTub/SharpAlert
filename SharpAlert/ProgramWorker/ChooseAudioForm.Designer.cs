namespace SharpAlert
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.RefreshOutputsButton = new System.Windows.Forms.Button();
            this.AudioDeviceCombo = new System.Windows.Forms.ComboBox();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.LegacyAudioPlayerBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AudioOutputLabel = new System.Windows.Forms.Label();
            this.GlobalVolumeLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneButton.Location = new System.Drawing.Point(451, 161);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(0);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(72, 23);
            this.DoneButton.TabIndex = 0;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = false;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SharpAlert.Properties.Resources.WarningApp;
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // TitleText
            // 
            this.TitleText.Font = new System.Drawing.Font("Arial", 16F);
            this.TitleText.Location = new System.Drawing.Point(105, 9);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(400, 30);
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
            this.RefreshOutputsButton.Location = new System.Drawing.Point(497, 57);
            this.RefreshOutputsButton.Name = "RefreshOutputsButton";
            this.RefreshOutputsButton.Size = new System.Drawing.Size(23, 23);
            this.RefreshOutputsButton.TabIndex = 42;
            this.RefreshOutputsButton.Text = "⭐";
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
            this.AudioDeviceCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AudioDeviceCombo.ForeColor = System.Drawing.Color.White;
            this.AudioDeviceCombo.FormattingEnabled = true;
            this.AudioDeviceCombo.Items.AddRange(new object[] {
            "Refresh the outputs..."});
            this.AudioDeviceCombo.Location = new System.Drawing.Point(110, 57);
            this.AudioDeviceCombo.Name = "AudioDeviceCombo";
            this.AudioDeviceCombo.Size = new System.Drawing.Size(381, 23);
            this.AudioDeviceCombo.TabIndex = 40;
            this.ToolTipInformation.SetToolTip(this.AudioDeviceCombo, "Choose the audio output device to use for sounds.");
            this.AudioDeviceCombo.SelectedIndexChanged += new System.EventHandler(this.AudioDeviceCombo_SelectedIndexChanged);
            // 
            // volumeBar
            // 
            this.volumeBar.LargeChange = 1;
            this.volumeBar.Location = new System.Drawing.Point(162, 83);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(358, 45);
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
        "r (SoundPlayer).");
            this.LegacyAudioPlayerBox.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(9, 158);
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
            this.GlobalVolumeLabel.Size = new System.Drawing.Size(48, 45);
            this.GlobalVolumeLabel.TabIndex = 43;
            this.GlobalVolumeLabel.Text = "Global\r\nVolume";
            this.GlobalVolumeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChooseAudioForm
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(532, 193);
            this.Controls.Add(this.LegacyAudioPlayerBox);
            this.Controls.Add(this.GlobalVolumeLabel);
            this.Controls.Add(this.volumeBar);
            this.Controls.Add(this.RefreshOutputsButton);
            this.Controls.Add(this.AudioOutputLabel);
            this.Controls.Add(this.AudioDeviceCombo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.pictureBox1);
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
            this.TopMost = true;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ChooseRegionForm_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseRegionForm_FormClosing);
            this.Load += new System.EventHandler(this.ChooseRegionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button RefreshOutputsButton;
        private System.Windows.Forms.Label AudioOutputLabel;
        private System.Windows.Forms.ComboBox AudioDeviceCombo;
        private System.Windows.Forms.Label GlobalVolumeLabel;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.CheckBox LegacyAudioPlayerBox;
    }
}