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
            EnableDiscordRichPresenceBox = new System.Windows.Forms.CheckBox();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            SecretSettingsButton = new System.Windows.Forms.Button();
            SaveSlotsButton = new System.Windows.Forms.Button();
            ProhibitUsers = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Font = new System.Drawing.Font("Segoe UI", 16F);
            DoneButton.ForeColor = System.Drawing.Color.White;
            DoneButton.Location = new System.Drawing.Point(12, 276);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new System.Drawing.Size(396, 40);
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
            CAPSettingsButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
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
            StyleSettingsButton.Text = "Alert\r\nStyling";
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
            SoundSettingsButton.Location = new System.Drawing.Point(12, 152);
            SoundSettingsButton.Name = "SoundSettingsButton";
            SoundSettingsButton.Size = new System.Drawing.Size(128, 64);
            SoundSettingsButton.TabIndex = 5;
            SoundSettingsButton.Text = "Sound\r\nSettings";
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
            DiscordSettingsButton.Location = new System.Drawing.Point(146, 152);
            DiscordSettingsButton.Name = "DiscordSettingsButton";
            DiscordSettingsButton.Size = new System.Drawing.Size(128, 64);
            DiscordSettingsButton.TabIndex = 6;
            DiscordSettingsButton.Text = "Webhook\r\nSettings";
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
            ServerSettingsButton.Location = new System.Drawing.Point(280, 82);
            ServerSettingsButton.Name = "ServerSettingsButton";
            ServerSettingsButton.Size = new System.Drawing.Size(128, 64);
            ServerSettingsButton.TabIndex = 4;
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
            RegionSettingsButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
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
            MigrateSettingsButton.Location = new System.Drawing.Point(12, 247);
            MigrateSettingsButton.Name = "MigrateSettingsButton";
            MigrateSettingsButton.Size = new System.Drawing.Size(128, 23);
            MigrateSettingsButton.TabIndex = 10;
            MigrateSettingsButton.Text = "Migrate Settings";
            ToolTipInformation.SetToolTip(MigrateSettingsButton, "If you have updated from v8.x or an older version of SharpAlert,\r\nplease click this button to restore your older settings, and migrate\r\nto the new JSON format that v9.x and newer use.");
            MigrateSettingsButton.UseMnemonic = false;
            MigrateSettingsButton.UseVisualStyleBackColor = false;
            MigrateSettingsButton.Click += MigrateSettingsButton_Click;
            // 
            // SaveSettingsButton
            // 
            SaveSettingsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            SaveSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SaveSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SaveSettingsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            SaveSettingsButton.ForeColor = System.Drawing.Color.White;
            SaveSettingsButton.Location = new System.Drawing.Point(12, 247);
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
            ProgramCreditsButton.Location = new System.Drawing.Point(280, 247);
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
            EnableUpdatesBox.Location = new System.Drawing.Point(12, 222);
            EnableUpdatesBox.Name = "EnableUpdatesBox";
            EnableUpdatesBox.Size = new System.Drawing.Size(166, 19);
            EnableUpdatesBox.TabIndex = 8;
            EnableUpdatesBox.Text = "Enable Automatic Updates";
            ToolTipInformation.SetToolTip(EnableUpdatesBox, resources.GetString("EnableUpdatesBox.ToolTip"));
            EnableUpdatesBox.UseVisualStyleBackColor = true;
            EnableUpdatesBox.CheckedChanged += EnableUpdatesBox_CheckedChanged;
            // 
            // EnableDiscordRichPresenceBox
            // 
            EnableDiscordRichPresenceBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            EnableDiscordRichPresenceBox.AutoSize = true;
            EnableDiscordRichPresenceBox.Location = new System.Drawing.Point(228, 222);
            EnableDiscordRichPresenceBox.Name = "EnableDiscordRichPresenceBox";
            EnableDiscordRichPresenceBox.Size = new System.Drawing.Size(180, 19);
            EnableDiscordRichPresenceBox.TabIndex = 9;
            EnableDiscordRichPresenceBox.Text = "Enable Discord Rich Presence";
            ToolTipInformation.SetToolTip(EnableDiscordRichPresenceBox, "Enables Discord rich presence. If you are a supporter, SharpAlert will use this feature to automatically unlock exclusive features.");
            EnableDiscordRichPresenceBox.UseVisualStyleBackColor = true;
            EnableDiscordRichPresenceBox.CheckedChanged += EnableDiscordRichPresenceBox_CheckedChanged;
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
            SecretSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SecretSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SecretSettingsButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            SecretSettingsButton.ForeColor = System.Drawing.Color.White;
            SecretSettingsButton.Location = new System.Drawing.Point(146, 247);
            SecretSettingsButton.Name = "SecretSettingsButton";
            SecretSettingsButton.Size = new System.Drawing.Size(128, 23);
            SecretSettingsButton.TabIndex = 11;
            SecretSettingsButton.Text = "Secret Settings";
            ToolTipInformation.SetToolTip(SecretSettingsButton, resources.GetString("SecretSettingsButton.ToolTip"));
            SecretSettingsButton.UseMnemonic = false;
            SecretSettingsButton.UseVisualStyleBackColor = false;
            SecretSettingsButton.Click += SecretSettingsButton_Click;
            // 
            // SaveSlotsButton
            // 
            SaveSlotsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SaveSlotsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SaveSlotsButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            SaveSlotsButton.ForeColor = System.Drawing.Color.White;
            SaveSlotsButton.Location = new System.Drawing.Point(280, 152);
            SaveSlotsButton.Name = "SaveSlotsButton";
            SaveSlotsButton.Size = new System.Drawing.Size(128, 64);
            SaveSlotsButton.TabIndex = 7;
            SaveSlotsButton.Text = "Save Slots";
            ToolTipInformation.SetToolTip(SaveSlotsButton, "Discord webhook settings can be configured here.");
            SaveSlotsButton.UseMnemonic = false;
            SaveSlotsButton.UseVisualStyleBackColor = false;
            SaveSlotsButton.Click += SaveSlotsButton_Click;
            // 
            // ProhibitUsers
            // 
            ProhibitUsers.Enabled = true;
            ProhibitUsers.Interval = 5000;
            ProhibitUsers.Tick += ProhibitUsers_Tick;
            // 
            // ConfigurationForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(420, 328);
            ControlBox = false;
            Controls.Add(SaveSlotsButton);
            Controls.Add(SecretSettingsButton);
            Controls.Add(EnableDiscordRichPresenceBox);
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
        private System.Windows.Forms.CheckBox EnableDiscordRichPresenceBox;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Button SecretSettingsButton;
        private System.Windows.Forms.Button SaveSlotsButton;
        private System.Windows.Forms.Timer ProhibitUsers;
    }
}
