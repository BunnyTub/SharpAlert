namespace SharpAlert
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
            this.BusyLock = new System.Windows.Forms.Timer(this.components);
            this.BusyLockText = new System.Windows.Forms.Label();
            this.ApplicationTypeGroup = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ClientServerPortInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ClientServerURLInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AppTypeCombo = new System.Windows.Forms.ComboBox();
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            this.ApplicationTypeGroup.SuspendLayout();
            this.ConfigurationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // BusyLock
            // 
            this.BusyLock.Tick += new System.EventHandler(this.BusyLock_Tick);
            // 
            // BusyLockText
            // 
            this.BusyLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BusyLockText.Font = new System.Drawing.Font("Arial", 12F);
            this.BusyLockText.Location = new System.Drawing.Point(0, 0);
            this.BusyLockText.Name = "BusyLockText";
            this.BusyLockText.Size = new System.Drawing.Size(712, 156);
            this.BusyLockText.TabIndex = 9;
            this.BusyLockText.Text = "Please wait or dismiss all alerts to configure settings.";
            this.BusyLockText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ApplicationTypeGroup
            // 
            this.ApplicationTypeGroup.Controls.Add(this.label3);
            this.ApplicationTypeGroup.Controls.Add(this.ClientServerPortInput);
            this.ApplicationTypeGroup.Controls.Add(this.label2);
            this.ApplicationTypeGroup.Controls.Add(this.ClientServerURLInput);
            this.ApplicationTypeGroup.Controls.Add(this.label1);
            this.ApplicationTypeGroup.Controls.Add(this.AppTypeCombo);
            this.ApplicationTypeGroup.Enabled = false;
            this.ApplicationTypeGroup.ForeColor = System.Drawing.Color.White;
            this.ApplicationTypeGroup.Location = new System.Drawing.Point(12, 12);
            this.ApplicationTypeGroup.Name = "ApplicationTypeGroup";
            this.ApplicationTypeGroup.Size = new System.Drawing.Size(688, 132);
            this.ApplicationTypeGroup.TabIndex = 2;
            this.ApplicationTypeGroup.TabStop = false;
            this.ApplicationTypeGroup.Text = "Application Type";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(594, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 30);
            this.label3.TabIndex = 10;
            this.label3.Text = "Port\r\n(Default: 9792)";
            // 
            // ClientServerPortInput
            // 
            this.ClientServerPortInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientServerPortInput.BackColor = System.Drawing.Color.Black;
            this.ClientServerPortInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ClientServerPortInput.ForeColor = System.Drawing.Color.Red;
            this.ClientServerPortInput.Location = new System.Drawing.Point(597, 105);
            this.ClientServerPortInput.Name = "ClientServerPortInput";
            this.ClientServerPortInput.Size = new System.Drawing.Size(85, 21);
            this.ClientServerPortInput.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(132, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(459, 30);
            this.label2.TabIndex = 8;
            this.label2.Text = "Server URL (Only takes effect when the app type is \"Client\".)\r\n(Only include the " +
    "hostname or IP address. No \"http://\", \"https://\", \"/furry\", \"/paws\", etc)";
            // 
            // ClientServerURLInput
            // 
            this.ClientServerURLInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ClientServerURLInput.BackColor = System.Drawing.Color.Black;
            this.ClientServerURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ClientServerURLInput.ForeColor = System.Drawing.Color.Red;
            this.ClientServerURLInput.Location = new System.Drawing.Point(135, 105);
            this.ClientServerURLInput.Name = "ClientServerURLInput";
            this.ClientServerURLInput.Size = new System.Drawing.Size(456, 21);
            this.ClientServerURLInput.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(672, 45);
            this.label1.TabIndex = 6;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // AppTypeCombo
            // 
            this.AppTypeCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AppTypeCombo.BackColor = System.Drawing.Color.Black;
            this.AppTypeCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AppTypeCombo.ForeColor = System.Drawing.Color.White;
            this.AppTypeCombo.FormattingEnabled = true;
            this.AppTypeCombo.Location = new System.Drawing.Point(6, 103);
            this.AppTypeCombo.Name = "AppTypeCombo";
            this.AppTypeCombo.Size = new System.Drawing.Size(123, 23);
            this.AppTypeCombo.TabIndex = 3;
            // 
            // ConfigurationPanel
            // 
            this.ConfigurationPanel.Controls.Add(this.ApplicationTypeGroup);
            this.ConfigurationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigurationPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfigurationPanel.Name = "ConfigurationPanel";
            this.ConfigurationPanel.Size = new System.Drawing.Size(712, 156);
            this.ConfigurationPanel.TabIndex = 9;
            // 
            // ServerConfigurationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(712, 156);
            this.Controls.Add(this.ConfigurationPanel);
            this.Controls.Add(this.BusyLockText);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ServerConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SharpAlert Server Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerConfigurationForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerConfigurationForm_Load);
            this.ApplicationTypeGroup.ResumeLayout(false);
            this.ApplicationTypeGroup.PerformLayout();
            this.ConfigurationPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer BusyLock;
        private System.Windows.Forms.Label BusyLockText;
        private System.Windows.Forms.GroupBox ApplicationTypeGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ClientServerURLInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AppTypeCombo;
        private System.Windows.Forms.Panel ConfigurationPanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ClientServerPortInput;
    }
}