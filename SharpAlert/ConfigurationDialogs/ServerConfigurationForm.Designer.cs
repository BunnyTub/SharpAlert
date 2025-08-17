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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerConfigurationForm));
            this.BusyLockText = new System.Windows.Forms.Label();
            this.ApplicationTypeGroup = new System.Windows.Forms.GroupBox();
            this.EnableServerBox = new System.Windows.Forms.CheckBox();
            this.SaveServerSettingsButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.WebServerPasswordInput = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.WebServerUsernameInput = new System.Windows.Forms.TextBox();
            this.DisableDialogsBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.ApplicationTypeGroup.SuspendLayout();
            this.ConfigurationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BusyLockText
            // 
            this.BusyLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BusyLockText.Font = new System.Drawing.Font("Arial", 12F);
            this.BusyLockText.Location = new System.Drawing.Point(0, 0);
            this.BusyLockText.Name = "BusyLockText";
            this.BusyLockText.Size = new System.Drawing.Size(570, 151);
            this.BusyLockText.TabIndex = 9;
            this.BusyLockText.Text = "Please wait or dismiss all alerts to configure settings.";
            this.BusyLockText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ApplicationTypeGroup
            // 
            this.ApplicationTypeGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplicationTypeGroup.Controls.Add(this.EnableServerBox);
            this.ApplicationTypeGroup.Controls.Add(this.SaveServerSettingsButton);
            this.ApplicationTypeGroup.Controls.Add(this.label2);
            this.ApplicationTypeGroup.Controls.Add(this.WebServerPasswordInput);
            this.ApplicationTypeGroup.Controls.Add(this.label6);
            this.ApplicationTypeGroup.Controls.Add(this.WebServerUsernameInput);
            this.ApplicationTypeGroup.Controls.Add(this.DisableDialogsBox);
            this.ApplicationTypeGroup.Controls.Add(this.label1);
            this.ApplicationTypeGroup.ForeColor = System.Drawing.Color.White;
            this.ApplicationTypeGroup.Location = new System.Drawing.Point(12, 12);
            this.ApplicationTypeGroup.Name = "ApplicationTypeGroup";
            this.ApplicationTypeGroup.Size = new System.Drawing.Size(546, 127);
            this.ApplicationTypeGroup.TabIndex = 2;
            this.ApplicationTypeGroup.TabStop = false;
            this.ApplicationTypeGroup.Text = "Server";
            // 
            // EnableServerBox
            // 
            this.EnableServerBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnableServerBox.AutoSize = true;
            this.EnableServerBox.Location = new System.Drawing.Point(427, 45);
            this.EnableServerBox.Name = "EnableServerBox";
            this.EnableServerBox.Size = new System.Drawing.Size(102, 19);
            this.EnableServerBox.TabIndex = 20;
            this.EnableServerBox.Text = "Enable server";
            this.ToolTipInformation.SetToolTip(this.EnableServerBox, "Causes the alert displayer to toggle the alert display boolean on for 5 seconds.\r" +
        "\nUseful if you\'re only wanting to send alerts out via the web server, or for oth" +
        "er purposes.");
            this.EnableServerBox.UseVisualStyleBackColor = true;
            // 
            // SaveServerSettingsButton
            // 
            this.SaveServerSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SaveServerSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveServerSettingsButton.ForeColor = System.Drawing.Color.White;
            this.SaveServerSettingsButton.Location = new System.Drawing.Point(415, 98);
            this.SaveServerSettingsButton.Name = "SaveServerSettingsButton";
            this.SaveServerSettingsButton.Size = new System.Drawing.Size(125, 23);
            this.SaveServerSettingsButton.TabIndex = 19;
            this.SaveServerSettingsButton.Text = "Modify Server";
            this.ToolTipInformation.SetToolTip(this.SaveServerSettingsButton, "Applies server settings immediately.");
            this.SaveServerSettingsButton.UseMnemonic = false;
            this.SaveServerSettingsButton.UseVisualStyleBackColor = false;
            this.SaveServerSettingsButton.Click += new System.EventHandler(this.SaveServerSettingsButton_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 18;
            this.label2.Text = "Password";
            // 
            // WebServerPasswordInput
            // 
            this.WebServerPasswordInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WebServerPasswordInput.BackColor = System.Drawing.Color.Black;
            this.WebServerPasswordInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WebServerPasswordInput.ForeColor = System.Drawing.Color.White;
            this.WebServerPasswordInput.Location = new System.Drawing.Point(182, 100);
            this.WebServerPasswordInput.Name = "WebServerPasswordInput";
            this.WebServerPasswordInput.Size = new System.Drawing.Size(170, 21);
            this.WebServerPasswordInput.TabIndex = 17;
            this.ToolTipInformation.SetToolTip(this.WebServerPasswordInput, "The server password used to authenticate with administrative pages/actions.");
            this.WebServerPasswordInput.UseSystemPasswordChar = true;
            this.WebServerPasswordInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WebServerPasswordInput_KeyDown);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "Username";
            // 
            // WebServerUsernameInput
            // 
            this.WebServerUsernameInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.WebServerUsernameInput.BackColor = System.Drawing.Color.Black;
            this.WebServerUsernameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WebServerUsernameInput.ForeColor = System.Drawing.Color.White;
            this.WebServerUsernameInput.Location = new System.Drawing.Point(6, 100);
            this.WebServerUsernameInput.Name = "WebServerUsernameInput";
            this.WebServerUsernameInput.Size = new System.Drawing.Size(170, 21);
            this.WebServerUsernameInput.TabIndex = 15;
            this.ToolTipInformation.SetToolTip(this.WebServerUsernameInput, "The server username used to authenticate with administrative pages/actions.");
            this.WebServerUsernameInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WebServerUsernameInput_KeyDown);
            // 
            // DisableDialogsBox
            // 
            this.DisableDialogsBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DisableDialogsBox.AutoSize = true;
            this.DisableDialogsBox.Location = new System.Drawing.Point(427, 20);
            this.DisableDialogsBox.Name = "DisableDialogsBox";
            this.DisableDialogsBox.Size = new System.Drawing.Size(113, 19);
            this.DisableDialogsBox.TabIndex = 14;
            this.DisableDialogsBox.Text = "Disable dialogs";
            this.ToolTipInformation.SetToolTip(this.DisableDialogsBox, "Causes the alert displayer to toggle the alert display boolean on for 5 seconds.\r" +
        "\nUseful if you\'re only wanting to send alerts out via the web server, or for oth" +
        "er purposes.");
            this.DisableDialogsBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "The server runs locally on port 5576.\r\nElevate the process to allow any inbound c" +
    "onnections.";
            // 
            // ConfigurationPanel
            // 
            this.ConfigurationPanel.Controls.Add(this.ApplicationTypeGroup);
            this.ConfigurationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigurationPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfigurationPanel.Name = "ConfigurationPanel";
            this.ConfigurationPanel.Size = new System.Drawing.Size(570, 151);
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
            // ServerConfigurationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(570, 151);
            this.Controls.Add(this.ConfigurationPanel);
            this.Controls.Add(this.BusyLockText);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Server Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerConfigurationForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerConfigurationForm_Load);
            this.ApplicationTypeGroup.ResumeLayout(false);
            this.ApplicationTypeGroup.PerformLayout();
            this.ConfigurationPanel.ResumeLayout(false);
            this.ResumeLayout(false);

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
