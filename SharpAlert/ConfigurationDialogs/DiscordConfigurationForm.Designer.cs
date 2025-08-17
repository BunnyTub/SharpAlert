namespace SharpAlert.ConfigurationDialogs
{
    partial class DiscordConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscordConfigurationForm));
            this.BusyLockText = new System.Windows.Forms.Label();
            this.ApplicationTypeGroup = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DisableHeartbeatBox = new System.Windows.Forms.CheckBox();
            this.DiscordWebhookRelayLocallyBox = new System.Windows.Forms.CheckBox();
            this.DiscordWebhookConfirmAlertsBox = new System.Windows.Forms.CheckBox();
            this.SaveDiscordSettingsButton = new System.Windows.Forms.Button();
            this.NS_UnhideSecureBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.DiscordWebhookAppendInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DiscordWebhookURLInput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.BatteryReportingCautionLevelInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.BatteryReportingCriticalLevelInput = new System.Windows.Forms.NumericUpDown();
            this.ApplicationTypeGroup.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ConfigurationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BatteryReportingCautionLevelInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatteryReportingCriticalLevelInput)).BeginInit();
            this.SuspendLayout();
            // 
            // BusyLockText
            // 
            this.BusyLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BusyLockText.Font = new System.Drawing.Font("Arial", 12F);
            this.BusyLockText.Location = new System.Drawing.Point(0, 0);
            this.BusyLockText.Name = "BusyLockText";
            this.BusyLockText.Size = new System.Drawing.Size(570, 201);
            this.BusyLockText.TabIndex = 9;
            this.BusyLockText.Text = "Please wait or dismiss all alerts to configure settings.";
            this.BusyLockText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ApplicationTypeGroup
            // 
            this.ApplicationTypeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplicationTypeGroup.Controls.Add(this.groupBox1);
            this.ApplicationTypeGroup.Controls.Add(this.DisableHeartbeatBox);
            this.ApplicationTypeGroup.Controls.Add(this.DiscordWebhookRelayLocallyBox);
            this.ApplicationTypeGroup.Controls.Add(this.DiscordWebhookConfirmAlertsBox);
            this.ApplicationTypeGroup.Controls.Add(this.SaveDiscordSettingsButton);
            this.ApplicationTypeGroup.Controls.Add(this.NS_UnhideSecureBox);
            this.ApplicationTypeGroup.Controls.Add(this.label7);
            this.ApplicationTypeGroup.Controls.Add(this.DiscordWebhookAppendInput);
            this.ApplicationTypeGroup.Controls.Add(this.label6);
            this.ApplicationTypeGroup.Controls.Add(this.DiscordWebhookURLInput);
            this.ApplicationTypeGroup.Controls.Add(this.label5);
            this.ApplicationTypeGroup.ForeColor = System.Drawing.Color.White;
            this.ApplicationTypeGroup.Location = new System.Drawing.Point(12, 12);
            this.ApplicationTypeGroup.Name = "ApplicationTypeGroup";
            this.ApplicationTypeGroup.Size = new System.Drawing.Size(546, 177);
            this.ApplicationTypeGroup.TabIndex = 2;
            this.ApplicationTypeGroup.TabStop = false;
            this.ApplicationTypeGroup.Text = "Discord Webhook";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.BatteryReportingCriticalLevelInput);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.BatteryReportingCautionLevelInput);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(6, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 86);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Battery Reporting";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 63);
            this.label3.TabIndex = 14;
            this.label3.Text = "Battery measurements are reported to Discord webhooks when a\r\ncertain percentage " +
    "is reached.";
            // 
            // DisableHeartbeatBox
            // 
            this.DisableHeartbeatBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DisableHeartbeatBox.AutoSize = true;
            this.DisableHeartbeatBox.Location = new System.Drawing.Point(407, 135);
            this.DisableHeartbeatBox.Name = "DisableHeartbeatBox";
            this.DisableHeartbeatBox.Size = new System.Drawing.Size(124, 19);
            this.DisableHeartbeatBox.TabIndex = 19;
            this.DisableHeartbeatBox.Text = "Disable heartbeat";
            this.ToolTipInformation.SetToolTip(this.DisableHeartbeatBox, "Disables the \"I\'m\"\r\nThis is not related ");
            this.DisableHeartbeatBox.UseVisualStyleBackColor = true;
            // 
            // DiscordWebhookRelayLocallyBox
            // 
            this.DiscordWebhookRelayLocallyBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscordWebhookRelayLocallyBox.AutoSize = true;
            this.DiscordWebhookRelayLocallyBox.Location = new System.Drawing.Point(407, 110);
            this.DiscordWebhookRelayLocallyBox.Name = "DiscordWebhookRelayLocallyBox";
            this.DiscordWebhookRelayLocallyBox.Size = new System.Drawing.Size(94, 19);
            this.DiscordWebhookRelayLocallyBox.TabIndex = 17;
            this.DiscordWebhookRelayLocallyBox.Text = "Relay locally";
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookRelayLocallyBox, "Relay alerts locally in addition to sending a message.");
            this.DiscordWebhookRelayLocallyBox.UseVisualStyleBackColor = true;
            // 
            // DiscordWebhookConfirmAlertsBox
            // 
            this.DiscordWebhookConfirmAlertsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DiscordWebhookConfirmAlertsBox.AutoSize = true;
            this.DiscordWebhookConfirmAlertsBox.Location = new System.Drawing.Point(407, 85);
            this.DiscordWebhookConfirmAlertsBox.Name = "DiscordWebhookConfirmAlertsBox";
            this.DiscordWebhookConfirmAlertsBox.Size = new System.Drawing.Size(104, 19);
            this.DiscordWebhookConfirmAlertsBox.TabIndex = 15;
            this.DiscordWebhookConfirmAlertsBox.Text = "Confirm alerts";
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookConfirmAlertsBox, "Shows a window with alert information for a short period of time.\r\nYou can either" +
        " forward the alert by waiting or clicking \"FORWARD\", or discard it by clicking \"" +
        "STOP\".");
            this.DiscordWebhookConfirmAlertsBox.UseVisualStyleBackColor = true;
            // 
            // SaveDiscordSettingsButton
            // 
            this.SaveDiscordSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SaveDiscordSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveDiscordSettingsButton.Location = new System.Drawing.Point(407, 54);
            this.SaveDiscordSettingsButton.Name = "SaveDiscordSettingsButton";
            this.SaveDiscordSettingsButton.Size = new System.Drawing.Size(133, 25);
            this.SaveDiscordSettingsButton.TabIndex = 13;
            this.SaveDiscordSettingsButton.Text = "Modfiy Webhook";
            this.ToolTipInformation.SetToolTip(this.SaveDiscordSettingsButton, "Applies webhook information immediately.");
            this.SaveDiscordSettingsButton.UseVisualStyleBackColor = false;
            this.SaveDiscordSettingsButton.Click += new System.EventHandler(this.SaveDiscordSettingsButton_Click);
            // 
            // NS_UnhideSecureBox
            // 
            this.NS_UnhideSecureBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.NS_UnhideSecureBox.AutoSize = true;
            this.NS_UnhideSecureBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.NS_UnhideSecureBox.Checked = true;
            this.NS_UnhideSecureBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.NS_UnhideSecureBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.NS_UnhideSecureBox.Location = new System.Drawing.Point(358, 54);
            this.NS_UnhideSecureBox.Name = "NS_UnhideSecureBox";
            this.NS_UnhideSecureBox.Size = new System.Drawing.Size(43, 25);
            this.NS_UnhideSecureBox.TabIndex = 12;
            this.NS_UnhideSecureBox.Text = "Hide";
            this.ToolTipInformation.SetToolTip(this.NS_UnhideSecureBox, "Hides possibly sensitive information.");
            this.NS_UnhideSecureBox.UseVisualStyleBackColor = false;
            this.NS_UnhideSecureBox.CheckedChanged += new System.EventHandler(this.NS_UnhideSecureBox_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(182, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Appended Message";
            // 
            // DiscordWebhookAppendInput
            // 
            this.DiscordWebhookAppendInput.BackColor = System.Drawing.Color.Black;
            this.DiscordWebhookAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DiscordWebhookAppendInput.ForeColor = System.Drawing.Color.White;
            this.DiscordWebhookAppendInput.Location = new System.Drawing.Point(182, 58);
            this.DiscordWebhookAppendInput.Name = "DiscordWebhookAppendInput";
            this.DiscordWebhookAppendInput.Size = new System.Drawing.Size(170, 21);
            this.DiscordWebhookAppendInput.TabIndex = 11;
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookAppendInput, "The message to be appended after all data of an alert is sent successfully.");
            this.DiscordWebhookAppendInput.UseSystemPasswordChar = true;
            this.DiscordWebhookAppendInput.TextChanged += new System.EventHandler(this.DiscordWebhookAppendInput_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Discord Webhook URL";
            // 
            // DiscordWebhookURLInput
            // 
            this.DiscordWebhookURLInput.BackColor = System.Drawing.Color.Black;
            this.DiscordWebhookURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DiscordWebhookURLInput.ForeColor = System.Drawing.Color.White;
            this.DiscordWebhookURLInput.Location = new System.Drawing.Point(6, 58);
            this.DiscordWebhookURLInput.Name = "DiscordWebhookURLInput";
            this.DiscordWebhookURLInput.Size = new System.Drawing.Size(170, 21);
            this.DiscordWebhookURLInput.TabIndex = 10;
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookURLInput, "The Discord webhook URL to send data to.");
            this.DiscordWebhookURLInput.UseSystemPasswordChar = true;
            this.DiscordWebhookURLInput.TextChanged += new System.EventHandler(this.DiscordWebhookURLInput_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(509, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "You can send alerts to a Discord webhook here. Leave the URL blank to disable thi" +
    "s feature.";
            // 
            // ConfigurationPanel
            // 
            this.ConfigurationPanel.Controls.Add(this.ApplicationTypeGroup);
            this.ConfigurationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigurationPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfigurationPanel.Name = "ConfigurationPanel";
            this.ConfigurationPanel.Size = new System.Drawing.Size(570, 201);
            this.ConfigurationPanel.TabIndex = 9;
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
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(242, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 21);
            this.label1.TabIndex = 25;
            this.label1.Text = "Caution";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.label1, ".");
            // 
            // BatteryReportingCautionLevelInput
            // 
            this.BatteryReportingCautionLevelInput.BackColor = System.Drawing.Color.Black;
            this.BatteryReportingCautionLevelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BatteryReportingCautionLevelInput.ForeColor = System.Drawing.Color.White;
            this.BatteryReportingCautionLevelInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.BatteryReportingCautionLevelInput.Location = new System.Drawing.Point(332, 32);
            this.BatteryReportingCautionLevelInput.Name = "BatteryReportingCautionLevelInput";
            this.BatteryReportingCautionLevelInput.Size = new System.Drawing.Size(54, 21);
            this.BatteryReportingCautionLevelInput.TabIndex = 24;
            this.ToolTipInformation.SetToolTip(this.BatteryReportingCautionLevelInput, "The level at which reporting starts for caution.");
            this.BatteryReportingCautionLevelInput.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(242, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "Critical";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.label2, ".");
            // 
            // BatteryReportingCriticalLevelInput
            // 
            this.BatteryReportingCriticalLevelInput.BackColor = System.Drawing.Color.Black;
            this.BatteryReportingCriticalLevelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BatteryReportingCriticalLevelInput.ForeColor = System.Drawing.Color.White;
            this.BatteryReportingCriticalLevelInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.BatteryReportingCriticalLevelInput.Location = new System.Drawing.Point(332, 59);
            this.BatteryReportingCriticalLevelInput.Name = "BatteryReportingCriticalLevelInput";
            this.BatteryReportingCriticalLevelInput.Size = new System.Drawing.Size(54, 21);
            this.BatteryReportingCriticalLevelInput.TabIndex = 26;
            this.ToolTipInformation.SetToolTip(this.BatteryReportingCriticalLevelInput, "The level at which reporting starts for critical.");
            this.BatteryReportingCriticalLevelInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // DiscordConfigurationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(570, 201);
            this.Controls.Add(this.ConfigurationPanel);
            this.Controls.Add(this.BusyLockText);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscordConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SharpAlert - Discord Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerConfigurationForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerConfigurationForm_Load);
            this.ApplicationTypeGroup.ResumeLayout(false);
            this.ApplicationTypeGroup.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ConfigurationPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BatteryReportingCautionLevelInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatteryReportingCriticalLevelInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label BusyLockText;
        private System.Windows.Forms.GroupBox ApplicationTypeGroup;
        private System.Windows.Forms.Panel ConfigurationPanel;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.CheckBox DiscordWebhookRelayLocallyBox;
        private System.Windows.Forms.CheckBox DiscordWebhookConfirmAlertsBox;
        private System.Windows.Forms.Button SaveDiscordSettingsButton;
        private System.Windows.Forms.CheckBox NS_UnhideSecureBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox DiscordWebhookAppendInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DiscordWebhookURLInput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox DisableHeartbeatBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown BatteryReportingCautionLevelInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown BatteryReportingCriticalLevelInput;
    }
}
