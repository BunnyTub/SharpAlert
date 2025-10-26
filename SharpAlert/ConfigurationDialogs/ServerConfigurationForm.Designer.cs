namespace SharpAlert.ConfigurationDialogs
{
    partial class ServerConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConfigurationForm));
            BusyLockText = new System.Windows.Forms.Label();
            ApplicationTypeGroup = new System.Windows.Forms.GroupBox();
            EnableServerBox = new System.Windows.Forms.CheckBox();
            SaveServerSettingsButton = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            WebServerPasswordInput = new System.Windows.Forms.TextBox();
            label6 = new System.Windows.Forms.Label();
            WebServerUsernameInput = new System.Windows.Forms.TextBox();
            DisableDialogsBox = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            ConfigurationPanel = new System.Windows.Forms.Panel();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            ApplicationTypeGroup.SuspendLayout();
            ConfigurationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // BusyLockText
            // 
            BusyLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            BusyLockText.Font = new System.Drawing.Font("Segoe UI", 12F);
            BusyLockText.Location = new System.Drawing.Point(0, 0);
            BusyLockText.Name = "BusyLockText";
            BusyLockText.Size = new System.Drawing.Size(570, 151);
            BusyLockText.TabIndex = 9;
            BusyLockText.Text = "Please wait or dismiss all alerts to configure settings.";
            BusyLockText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ApplicationTypeGroup
            // 
            ApplicationTypeGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ApplicationTypeGroup.Controls.Add(EnableServerBox);
            ApplicationTypeGroup.Controls.Add(SaveServerSettingsButton);
            ApplicationTypeGroup.Controls.Add(label2);
            ApplicationTypeGroup.Controls.Add(WebServerPasswordInput);
            ApplicationTypeGroup.Controls.Add(label6);
            ApplicationTypeGroup.Controls.Add(WebServerUsernameInput);
            ApplicationTypeGroup.Controls.Add(DisableDialogsBox);
            ApplicationTypeGroup.Controls.Add(label1);
            ApplicationTypeGroup.ForeColor = System.Drawing.Color.White;
            ApplicationTypeGroup.Location = new System.Drawing.Point(12, 12);
            ApplicationTypeGroup.Name = "ApplicationTypeGroup";
            ApplicationTypeGroup.Size = new System.Drawing.Size(546, 127);
            ApplicationTypeGroup.TabIndex = 2;
            ApplicationTypeGroup.TabStop = false;
            ApplicationTypeGroup.Text = "Server";
            // 
            // EnableServerBox
            // 
            EnableServerBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            EnableServerBox.AutoSize = true;
            EnableServerBox.Location = new System.Drawing.Point(434, 45);
            EnableServerBox.Name = "EnableServerBox";
            EnableServerBox.Size = new System.Drawing.Size(95, 19);
            EnableServerBox.TabIndex = 20;
            EnableServerBox.Text = "Enable server";
            ToolTipInformation.SetToolTip(EnableServerBox, "Causes the alert displayer to toggle the alert display boolean on for 5 seconds.\r\nUseful if you're only wanting to send alerts out via the web server, or for other purposes.");
            EnableServerBox.UseVisualStyleBackColor = true;
            // 
            // SaveServerSettingsButton
            // 
            SaveServerSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SaveServerSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SaveServerSettingsButton.ForeColor = System.Drawing.Color.White;
            SaveServerSettingsButton.Location = new System.Drawing.Point(415, 98);
            SaveServerSettingsButton.Name = "SaveServerSettingsButton";
            SaveServerSettingsButton.Size = new System.Drawing.Size(125, 23);
            SaveServerSettingsButton.TabIndex = 19;
            SaveServerSettingsButton.Text = "Modify Server";
            ToolTipInformation.SetToolTip(SaveServerSettingsButton, "Applies server settings immediately.");
            SaveServerSettingsButton.UseMnemonic = false;
            SaveServerSettingsButton.UseVisualStyleBackColor = false;
            SaveServerSettingsButton.Click += SaveServerSettingsButton_Click;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(182, 82);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(57, 15);
            label2.TabIndex = 18;
            label2.Text = "Password";
            label2.Visible = false;
            // 
            // WebServerPasswordInput
            // 
            WebServerPasswordInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            WebServerPasswordInput.BackColor = System.Drawing.Color.Black;
            WebServerPasswordInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            WebServerPasswordInput.ForeColor = System.Drawing.Color.White;
            WebServerPasswordInput.Location = new System.Drawing.Point(182, 100);
            WebServerPasswordInput.Name = "WebServerPasswordInput";
            WebServerPasswordInput.Size = new System.Drawing.Size(170, 23);
            WebServerPasswordInput.TabIndex = 17;
            ToolTipInformation.SetToolTip(WebServerPasswordInput, "The server password used to authenticate with administrative pages/actions.");
            WebServerPasswordInput.UseSystemPasswordChar = true;
            WebServerPasswordInput.Visible = false;
            WebServerPasswordInput.KeyDown += WebServerPasswordInput_KeyDown;
            // 
            // label6
            // 
            label6.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 82);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(60, 15);
            label6.TabIndex = 16;
            label6.Text = "Username";
            label6.Visible = false;
            // 
            // WebServerUsernameInput
            // 
            WebServerUsernameInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            WebServerUsernameInput.BackColor = System.Drawing.Color.Black;
            WebServerUsernameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            WebServerUsernameInput.ForeColor = System.Drawing.Color.White;
            WebServerUsernameInput.Location = new System.Drawing.Point(6, 100);
            WebServerUsernameInput.Name = "WebServerUsernameInput";
            WebServerUsernameInput.Size = new System.Drawing.Size(170, 23);
            WebServerUsernameInput.TabIndex = 15;
            ToolTipInformation.SetToolTip(WebServerUsernameInput, "The server username used to authenticate with administrative pages/actions.");
            WebServerUsernameInput.Visible = false;
            WebServerUsernameInput.KeyDown += WebServerUsernameInput_KeyDown;
            // 
            // DisableDialogsBox
            // 
            DisableDialogsBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            DisableDialogsBox.AutoSize = true;
            DisableDialogsBox.Location = new System.Drawing.Point(435, 20);
            DisableDialogsBox.Name = "DisableDialogsBox";
            DisableDialogsBox.Size = new System.Drawing.Size(105, 19);
            DisableDialogsBox.TabIndex = 14;
            DisableDialogsBox.Text = "Disable dialogs";
            ToolTipInformation.SetToolTip(DisableDialogsBox, "Causes the alert displayer to toggle the alert display boolean on for 5 seconds.\r\nUseful if you're only wanting to send alerts out via the web server, or for other purposes.");
            DisableDialogsBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(6, 17);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(293, 30);
            label1.TabIndex = 6;
            label1.Text = "The server runs locally on port 5576.\r\nElevate the process to allow any inbound connections.";
            // 
            // ConfigurationPanel
            // 
            ConfigurationPanel.Controls.Add(ApplicationTypeGroup);
            ConfigurationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            ConfigurationPanel.Location = new System.Drawing.Point(0, 0);
            ConfigurationPanel.Name = "ConfigurationPanel";
            ConfigurationPanel.Size = new System.Drawing.Size(570, 151);
            ConfigurationPanel.TabIndex = 9;
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
            // ServerConfigurationForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(570, 151);
            Controls.Add(ConfigurationPanel);
            Controls.Add(BusyLockText);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ServerConfigurationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Server Settings";
            FormClosing += ServerConfigurationForm_FormClosing;
            Load += ServerConfigurationForm_Load;
            ApplicationTypeGroup.ResumeLayout(false);
            ApplicationTypeGroup.PerformLayout();
            ConfigurationPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label BusyLockText;
        private System.Windows.Forms.GroupBox ApplicationTypeGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel ConfigurationPanel;
        private System.Windows.Forms.CheckBox DisableDialogsBox;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox WebServerPasswordInput;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox WebServerUsernameInput;
        private System.Windows.Forms.Button SaveServerSettingsButton;
        private System.Windows.Forms.CheckBox EnableServerBox;
    }
}
