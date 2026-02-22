namespace SharpAlert.ConfigurationDialogs
{
    partial class SimpleConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleConfigurationForm));
            DoneButton = new System.Windows.Forms.Button();
            CAPSettingsButton = new System.Windows.Forms.Button();
            StyleSettingsButton = new System.Windows.Forms.Button();
            SoundSettingsButton = new System.Windows.Forms.Button();
            DiscordSettingsButton = new System.Windows.Forms.Button();
            RegionSettingsButton = new System.Windows.Forms.Button();
            ProgramCreditsButton = new System.Windows.Forms.Button();
            EnableUpdatesBox = new System.Windows.Forms.CheckBox();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            AdvancedModeButton = new System.Windows.Forms.Button();
            SlidesBox = new System.Windows.Forms.PictureBox();
            Reloader = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)SlidesBox).BeginInit();
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Font = new System.Drawing.Font("Segoe UI", 16F);
            DoneButton.ForeColor = System.Drawing.Color.White;
            DoneButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            DoneButton.Location = new System.Drawing.Point(280, 251);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new System.Drawing.Size(128, 40);
            DoneButton.TabIndex = 13;
            DoneButton.Text = "Close";
            DoneButton.UseMnemonic = false;
            DoneButton.UseVisualStyleBackColor = false;
            DoneButton.Click += DoneButton_Click;
            // 
            // CAPSettingsButton
            // 
            CAPSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            CAPSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            CAPSettingsButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            CAPSettingsButton.ForeColor = System.Drawing.Color.White;
            CAPSettingsButton.Location = new System.Drawing.Point(12, 12);
            CAPSettingsButton.Name = "CAPSettingsButton";
            CAPSettingsButton.Size = new System.Drawing.Size(262, 64);
            CAPSettingsButton.TabIndex = 1;
            CAPSettingsButton.Text = "Alert Settings";
            ToolTipInformation.SetToolTip(CAPSettingsButton, "Various alert processing settings can be configured here.");
            CAPSettingsButton.UseMnemonic = false;
            CAPSettingsButton.UseVisualStyleBackColor = false;
            CAPSettingsButton.Click += CAPSettingsButton_Click;
            // 
            // StyleSettingsButton
            // 
            StyleSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            StyleSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            StyleSettingsButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            StyleSettingsButton.ForeColor = System.Drawing.Color.White;
            StyleSettingsButton.Location = new System.Drawing.Point(280, 12);
            StyleSettingsButton.Name = "StyleSettingsButton";
            StyleSettingsButton.Size = new System.Drawing.Size(128, 64);
            StyleSettingsButton.TabIndex = 2;
            StyleSettingsButton.Text = "Styles &\r\nMore";
            ToolTipInformation.SetToolTip(StyleSettingsButton, "Alert styling for GUI, text, and more can be configured here.");
            StyleSettingsButton.UseMnemonic = false;
            StyleSettingsButton.UseVisualStyleBackColor = false;
            StyleSettingsButton.Click += StyleSettingsButton_Click;
            // 
            // SoundSettingsButton
            // 
            SoundSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SoundSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SoundSettingsButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            SoundSettingsButton.ForeColor = System.Drawing.Color.White;
            SoundSettingsButton.Location = new System.Drawing.Point(280, 152);
            SoundSettingsButton.Name = "SoundSettingsButton";
            SoundSettingsButton.Size = new System.Drawing.Size(128, 64);
            SoundSettingsButton.TabIndex = 5;
            SoundSettingsButton.Text = "Sounds &\r\nEffects";
            ToolTipInformation.SetToolTip(SoundSettingsButton, "Sound device and sound customization settings can be configured here.");
            SoundSettingsButton.UseMnemonic = false;
            SoundSettingsButton.UseVisualStyleBackColor = false;
            SoundSettingsButton.Click += SoundSettingsButton_Click;
            // 
            // DiscordSettingsButton
            // 
            DiscordSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DiscordSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DiscordSettingsButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            DiscordSettingsButton.ForeColor = System.Drawing.Color.White;
            DiscordSettingsButton.Location = new System.Drawing.Point(280, 82);
            DiscordSettingsButton.Name = "DiscordSettingsButton";
            DiscordSettingsButton.Size = new System.Drawing.Size(128, 64);
            DiscordSettingsButton.TabIndex = 6;
            DiscordSettingsButton.Text = "Discord &\r\nWebhooks";
            ToolTipInformation.SetToolTip(DiscordSettingsButton, "Discord webhook settings can be configured here.");
            DiscordSettingsButton.UseMnemonic = false;
            DiscordSettingsButton.UseVisualStyleBackColor = false;
            DiscordSettingsButton.Click += DiscordSettingsButton_Click;
            // 
            // RegionSettingsButton
            // 
            RegionSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            RegionSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            RegionSettingsButton.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            RegionSettingsButton.ForeColor = System.Drawing.Color.White;
            RegionSettingsButton.Location = new System.Drawing.Point(12, 82);
            RegionSettingsButton.Name = "RegionSettingsButton";
            RegionSettingsButton.Size = new System.Drawing.Size(262, 64);
            RegionSettingsButton.TabIndex = 3;
            RegionSettingsButton.Text = "Region Settings";
            ToolTipInformation.SetToolTip(RegionSettingsButton, "Alert regions (sources) can be configured here.");
            RegionSettingsButton.UseMnemonic = false;
            RegionSettingsButton.UseVisualStyleBackColor = false;
            RegionSettingsButton.Click += RegionButton_Click;
            // 
            // ProgramCreditsButton
            // 
            ProgramCreditsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ProgramCreditsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ProgramCreditsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ProgramCreditsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            ProgramCreditsButton.ForeColor = System.Drawing.Color.White;
            ProgramCreditsButton.Location = new System.Drawing.Point(280, 222);
            ProgramCreditsButton.Name = "ProgramCreditsButton";
            ProgramCreditsButton.Size = new System.Drawing.Size(128, 23);
            ProgramCreditsButton.TabIndex = 12;
            ProgramCreditsButton.Text = "About SharpAlert";
            ToolTipInformation.SetToolTip(ProgramCreditsButton, "Shows some information about the program. This is not user specific.");
            ProgramCreditsButton.UseMnemonic = false;
            ProgramCreditsButton.UseVisualStyleBackColor = false;
            ProgramCreditsButton.Click += ProgramCreditsButton_Click;
            // 
            // EnableUpdatesBox
            // 
            EnableUpdatesBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            EnableUpdatesBox.AutoSize = true;
            EnableUpdatesBox.Location = new System.Drawing.Point(12, 225);
            EnableUpdatesBox.Name = "EnableUpdatesBox";
            EnableUpdatesBox.Size = new System.Drawing.Size(166, 19);
            EnableUpdatesBox.TabIndex = 8;
            EnableUpdatesBox.Text = "Enable Automatic Updates";
            ToolTipInformation.SetToolTip(EnableUpdatesBox, resources.GetString("EnableUpdatesBox.ToolTip"));
            EnableUpdatesBox.UseVisualStyleBackColor = true;
            EnableUpdatesBox.CheckedChanged += EnableUpdatesBox_CheckedChanged;
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
            // AdvancedModeButton
            // 
            AdvancedModeButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            AdvancedModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AdvancedModeButton.Font = new System.Drawing.Font("Segoe UI", 20F);
            AdvancedModeButton.ForeColor = System.Drawing.Color.White;
            AdvancedModeButton.Location = new System.Drawing.Point(12, 152);
            AdvancedModeButton.Name = "AdvancedModeButton";
            AdvancedModeButton.Size = new System.Drawing.Size(262, 64);
            AdvancedModeButton.TabIndex = 14;
            AdvancedModeButton.Text = "Advanced Mode";
            ToolTipInformation.SetToolTip(AdvancedModeButton, "Re-opens the window into an advanced view.");
            AdvancedModeButton.UseMnemonic = false;
            AdvancedModeButton.UseVisualStyleBackColor = false;
            AdvancedModeButton.Click += AdvancedModeButton_Click;
            // 
            // SlidesBox
            // 
            SlidesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            SlidesBox.ErrorImage = Properties.Resources.announce;
            SlidesBox.ImageLocation = "https://bunnytub.com/SharpAlert-Slides/Announcement.png";
            SlidesBox.InitialImage = Properties.Resources.announce;
            SlidesBox.Location = new System.Drawing.Point(12, 251);
            SlidesBox.Name = "SlidesBox";
            SlidesBox.Size = new System.Drawing.Size(262, 40);
            SlidesBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            SlidesBox.TabIndex = 15;
            SlidesBox.TabStop = false;
            ToolTipInformation.SetToolTip(SlidesBox, "Click here to go to the website associated with this slide.");
            SlidesBox.Click += SlidesBox_Click;
            // 
            // Reloader
            // 
            Reloader.Enabled = true;
            Reloader.Interval = 60000;
            Reloader.Tick += Reloader_Tick;
            // 
            // SimpleConfigurationForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(420, 303);
            ControlBox = false;
            Controls.Add(SlidesBox);
            Controls.Add(AdvancedModeButton);
            Controls.Add(EnableUpdatesBox);
            Controls.Add(ProgramCreditsButton);
            Controls.Add(DiscordSettingsButton);
            Controls.Add(RegionSettingsButton);
            Controls.Add(SoundSettingsButton);
            Controls.Add(StyleSettingsButton);
            Controls.Add(CAPSettingsButton);
            Controls.Add(DoneButton);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SimpleConfigurationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Global Settings";
            FormClosing += ManagementForm_FormClosing;
            Load += ConfigurationForm_Load;
            ((System.ComponentModel.ISupportInitialize)SlidesBox).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Button CAPSettingsButton;
        private System.Windows.Forms.Button StyleSettingsButton;
        private System.Windows.Forms.Button SoundSettingsButton;
        private System.Windows.Forms.Button DiscordSettingsButton;
        private System.Windows.Forms.Button RegionSettingsButton;
        private System.Windows.Forms.Button ProgramCreditsButton;
        private System.Windows.Forms.CheckBox EnableUpdatesBox;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Button AdvancedModeButton;
        private System.Windows.Forms.PictureBox SlidesBox;
        private System.Windows.Forms.Timer Reloader;
    }
}
