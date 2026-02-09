namespace SharpAlert.ConfigurationDialogs
{
    partial class ConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigurationForm));
            DoneButton = new System.Windows.Forms.Button();
            CAPSettingsButton = new System.Windows.Forms.Button();
            StyleSettingsButton = new System.Windows.Forms.Button();
            SoundSettingsButton = new System.Windows.Forms.Button();
            DiscordSettingsButton = new System.Windows.Forms.Button();
            ServerSettingsButton = new System.Windows.Forms.Button();
            RegionSettingsButton = new System.Windows.Forms.Button();
            MigrateSettingsButton = new System.Windows.Forms.Button();
            SaveSettingsButton = new System.Windows.Forms.Button();
            ProgramCreditsButton = new System.Windows.Forms.Button();
            EnableUpdatesBox = new System.Windows.Forms.CheckBox();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            SecretSettingsButton = new System.Windows.Forms.Button();
            SaveSlotsButton = new System.Windows.Forms.Button();
            SimpleModeButton = new System.Windows.Forms.Button();
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
            DoneButton.Location = new System.Drawing.Point(280, 280);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new System.Drawing.Size(128, 40);
            DoneButton.TabIndex = 12;
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
            SoundSettingsButton.TabIndex = 7;
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
            DiscordSettingsButton.TabIndex = 4;
            DiscordSettingsButton.Text = "Discord &\r\nWebhooks";
            ToolTipInformation.SetToolTip(DiscordSettingsButton, "Discord webhook settings can be configured here.");
            DiscordSettingsButton.UseMnemonic = false;
            DiscordSettingsButton.UseVisualStyleBackColor = false;
            DiscordSettingsButton.Click += DiscordSettingsButton_Click;
            // 
            // ServerSettingsButton
            // 
            ServerSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ServerSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ServerSettingsButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            ServerSettingsButton.ForeColor = System.Drawing.Color.White;
            ServerSettingsButton.Location = new System.Drawing.Point(12, 152);
            ServerSettingsButton.Name = "ServerSettingsButton";
            ServerSettingsButton.Size = new System.Drawing.Size(128, 64);
            ServerSettingsButton.TabIndex = 5;
            ServerSettingsButton.Text = "Server Settings";
            ToolTipInformation.SetToolTip(ServerSettingsButton, "Server settings can be configured here.");
            ServerSettingsButton.UseMnemonic = false;
            ServerSettingsButton.UseVisualStyleBackColor = false;
            ServerSettingsButton.Click += ServerSettingsButton_Click;
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
            // MigrateSettingsButton
            // 
            MigrateSettingsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            MigrateSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            MigrateSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            MigrateSettingsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            MigrateSettingsButton.ForeColor = System.Drawing.Color.White;
            MigrateSettingsButton.Location = new System.Drawing.Point(12, 251);
            MigrateSettingsButton.Name = "MigrateSettingsButton";
            MigrateSettingsButton.Size = new System.Drawing.Size(128, 23);
            MigrateSettingsButton.TabIndex = 9;
            MigrateSettingsButton.Text = "Migrate Settings";
            ToolTipInformation.SetToolTip(MigrateSettingsButton, "If you have updated from v8.x or an older version of SharpAlert,\r\nplease click this button to restore your older settings, and migrate\r\nto the new JSON format that v9.x and newer use.");
            MigrateSettingsButton.UseMnemonic = false;
            MigrateSettingsButton.UseVisualStyleBackColor = false;
            MigrateSettingsButton.Visible = false;
            MigrateSettingsButton.Click += MigrateSettingsButton_Click;
            // 
            // SaveSettingsButton
            // 
            SaveSettingsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            SaveSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SaveSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SaveSettingsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            SaveSettingsButton.ForeColor = System.Drawing.Color.White;
            SaveSettingsButton.Location = new System.Drawing.Point(12, 251);
            SaveSettingsButton.Name = "SaveSettingsButton";
            SaveSettingsButton.Size = new System.Drawing.Size(128, 23);
            SaveSettingsButton.TabIndex = 7;
            SaveSettingsButton.Text = "Save Settings";
            SaveSettingsButton.UseMnemonic = false;
            SaveSettingsButton.UseVisualStyleBackColor = false;
            SaveSettingsButton.Visible = false;
            SaveSettingsButton.Click += SaveSettingsButton_Click;
            // 
            // ProgramCreditsButton
            // 
            ProgramCreditsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ProgramCreditsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ProgramCreditsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ProgramCreditsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            ProgramCreditsButton.ForeColor = System.Drawing.Color.White;
            ProgramCreditsButton.Location = new System.Drawing.Point(280, 251);
            ProgramCreditsButton.Name = "ProgramCreditsButton";
            ProgramCreditsButton.Size = new System.Drawing.Size(128, 23);
            ProgramCreditsButton.TabIndex = 11;
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
            EnableUpdatesBox.Location = new System.Drawing.Point(12, 226);
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
            // SecretSettingsButton
            // 
            SecretSettingsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            SecretSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SecretSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SecretSettingsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            SecretSettingsButton.ForeColor = System.Drawing.Color.White;
            SecretSettingsButton.Location = new System.Drawing.Point(146, 251);
            SecretSettingsButton.Name = "SecretSettingsButton";
            SecretSettingsButton.Size = new System.Drawing.Size(128, 23);
            SecretSettingsButton.TabIndex = 11;
            SecretSettingsButton.Text = "Experiments";
            ToolTipInformation.SetToolTip(SecretSettingsButton, "Contains experiments for SharpAlert.");
            SecretSettingsButton.UseMnemonic = false;
            SecretSettingsButton.UseVisualStyleBackColor = false;
            SecretSettingsButton.Visible = false;
            SecretSettingsButton.Click += SecretSettingsButton_Click;
            // 
            // SaveSlotsButton
            // 
            SaveSlotsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SaveSlotsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SaveSlotsButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            SaveSlotsButton.ForeColor = System.Drawing.Color.White;
            SaveSlotsButton.Location = new System.Drawing.Point(146, 152);
            SaveSlotsButton.Name = "SaveSlotsButton";
            SaveSlotsButton.Size = new System.Drawing.Size(128, 64);
            SaveSlotsButton.TabIndex = 6;
            SaveSlotsButton.Text = "Save\r\nSlots";
            ToolTipInformation.SetToolTip(SaveSlotsButton, "Save slots for your settings can be configured here");
            SaveSlotsButton.UseMnemonic = false;
            SaveSlotsButton.UseVisualStyleBackColor = false;
            SaveSlotsButton.Click += SaveSlotsButton_Click;
            // 
            // SimpleModeButton
            // 
            SimpleModeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            SimpleModeButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SimpleModeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SimpleModeButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            SimpleModeButton.ForeColor = System.Drawing.Color.White;
            SimpleModeButton.Location = new System.Drawing.Point(12, 251);
            SimpleModeButton.Name = "SimpleModeButton";
            SimpleModeButton.Size = new System.Drawing.Size(262, 23);
            SimpleModeButton.TabIndex = 10;
            SimpleModeButton.Text = "Simple Mode";
            ToolTipInformation.SetToolTip(SimpleModeButton, "Re-opens the window into a simplified view.");
            SimpleModeButton.UseMnemonic = false;
            SimpleModeButton.UseVisualStyleBackColor = false;
            SimpleModeButton.Click += SimpleModeButton_Click;
            // 
            // SlidesBox
            // 
            SlidesBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            SlidesBox.ErrorImage = Properties.Resources.announce;
            SlidesBox.ImageLocation = "https://bunnytub.com/SharpAlert-Slides/Announcement.png";
            SlidesBox.InitialImage = Properties.Resources.announce;
            SlidesBox.Location = new System.Drawing.Point(12, 280);
            SlidesBox.Name = "SlidesBox";
            SlidesBox.Size = new System.Drawing.Size(262, 40);
            SlidesBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            SlidesBox.TabIndex = 13;
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
            // ConfigurationForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(420, 332);
            ControlBox = false;
            Controls.Add(SlidesBox);
            Controls.Add(SimpleModeButton);
            Controls.Add(SaveSlotsButton);
            Controls.Add(SecretSettingsButton);
            Controls.Add(EnableUpdatesBox);
            Controls.Add(MigrateSettingsButton);
            Controls.Add(ProgramCreditsButton);
            Controls.Add(SaveSettingsButton);
            Controls.Add(DiscordSettingsButton);
            Controls.Add(ServerSettingsButton);
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
            Name = "ConfigurationForm";
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
        private System.Windows.Forms.Button ServerSettingsButton;
        private System.Windows.Forms.Button RegionSettingsButton;
        private System.Windows.Forms.Button MigrateSettingsButton;
        private System.Windows.Forms.Button SaveSettingsButton;
        private System.Windows.Forms.Button ProgramCreditsButton;
        private System.Windows.Forms.CheckBox EnableUpdatesBox;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Button SecretSettingsButton;
        private System.Windows.Forms.Button SaveSlotsButton;
        private System.Windows.Forms.Button SimpleModeButton;
        private System.Windows.Forms.PictureBox SlidesBox;
        private System.Windows.Forms.Timer Reloader;
    }
}
