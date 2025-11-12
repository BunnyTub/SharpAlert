namespace SharpAlert.ConfigurationDialogs
{
    partial class SecretConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecretConfigurationForm));
            SuperSecretSettingsGroup = new System.Windows.Forms.GroupBox();
            BrokenUpdateButton = new System.Windows.Forms.Button();
            SoftUpdateButton = new System.Windows.Forms.Button();
            ForceUpdateButton = new System.Windows.Forms.Button();
            DebuggerText = new System.Windows.Forms.Label();
            CheckForDebugger = new System.Windows.Forms.Timer(components);
            SuperSecretSettingsGroup.SuspendLayout();
            SuspendLayout();
            // 
            // SuperSecretSettingsGroup
            // 
            SuperSecretSettingsGroup.Controls.Add(BrokenUpdateButton);
            SuperSecretSettingsGroup.Controls.Add(SoftUpdateButton);
            SuperSecretSettingsGroup.Controls.Add(ForceUpdateButton);
            SuperSecretSettingsGroup.ForeColor = System.Drawing.Color.White;
            SuperSecretSettingsGroup.Location = new System.Drawing.Point(12, 42);
            SuperSecretSettingsGroup.Name = "SuperSecretSettingsGroup";
            SuperSecretSettingsGroup.Size = new System.Drawing.Size(409, 44);
            SuperSecretSettingsGroup.TabIndex = 1;
            SuperSecretSettingsGroup.TabStop = false;
            SuperSecretSettingsGroup.Text = "Update Mechanism";
            // 
            // BrokenUpdateButton
            // 
            BrokenUpdateButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            BrokenUpdateButton.Dock = System.Windows.Forms.DockStyle.Fill;
            BrokenUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            BrokenUpdateButton.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            BrokenUpdateButton.ForeColor = System.Drawing.Color.White;
            BrokenUpdateButton.Location = new System.Drawing.Point(217, 19);
            BrokenUpdateButton.Margin = new System.Windows.Forms.Padding(0);
            BrokenUpdateButton.Name = "BrokenUpdateButton";
            BrokenUpdateButton.Size = new System.Drawing.Size(189, 22);
            BrokenUpdateButton.TabIndex = 4;
            BrokenUpdateButton.Text = "Try Broken Update";
            BrokenUpdateButton.UseVisualStyleBackColor = false;
            BrokenUpdateButton.Click += BrokenUpdateButton_Click;
            // 
            // SoftUpdateButton
            // 
            SoftUpdateButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SoftUpdateButton.Dock = System.Windows.Forms.DockStyle.Left;
            SoftUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SoftUpdateButton.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            SoftUpdateButton.ForeColor = System.Drawing.Color.White;
            SoftUpdateButton.Location = new System.Drawing.Point(99, 19);
            SoftUpdateButton.Margin = new System.Windows.Forms.Padding(0);
            SoftUpdateButton.Name = "SoftUpdateButton";
            SoftUpdateButton.Size = new System.Drawing.Size(118, 22);
            SoftUpdateButton.TabIndex = 3;
            SoftUpdateButton.Text = "Try Update";
            SoftUpdateButton.UseVisualStyleBackColor = false;
            SoftUpdateButton.Click += SoftUpdateButton_Click;
            // 
            // ForceUpdateButton
            // 
            ForceUpdateButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ForceUpdateButton.Dock = System.Windows.Forms.DockStyle.Left;
            ForceUpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ForceUpdateButton.Font = new System.Drawing.Font("Segoe UI", 8.8F);
            ForceUpdateButton.ForeColor = System.Drawing.Color.White;
            ForceUpdateButton.Location = new System.Drawing.Point(3, 19);
            ForceUpdateButton.Margin = new System.Windows.Forms.Padding(0);
            ForceUpdateButton.Name = "ForceUpdateButton";
            ForceUpdateButton.Size = new System.Drawing.Size(96, 22);
            ForceUpdateButton.TabIndex = 2;
            ForceUpdateButton.Text = "Force Update";
            ForceUpdateButton.UseVisualStyleBackColor = false;
            ForceUpdateButton.Click += ForceUpdateButton_Click;
            // 
            // DebuggerText
            // 
            DebuggerText.Location = new System.Drawing.Point(9, 9);
            DebuggerText.Margin = new System.Windows.Forms.Padding(0);
            DebuggerText.Name = "DebuggerText";
            DebuggerText.Size = new System.Drawing.Size(315, 30);
            DebuggerText.TabIndex = 2;
            DebuggerText.Text = "Checking application status.\r\nThis may take a moment.";
            // 
            // CheckForDebugger
            // 
            CheckForDebugger.Enabled = true;
            CheckForDebugger.Interval = 1000;
            CheckForDebugger.Tick += CheckForDebugger_Tick;
            // 
            // SecretConfigurationForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(433, 98);
            Controls.Add(DebuggerText);
            Controls.Add(SuperSecretSettingsGroup);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "SecretConfigurationForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Secret Settings";
            SuperSecretSettingsGroup.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox SuperSecretSettingsGroup;
        private System.Windows.Forms.Button ForceUpdateButton;
        private System.Windows.Forms.Button BrokenUpdateButton;
        private System.Windows.Forms.Button SoftUpdateButton;
        private System.Windows.Forms.Label DebuggerText;
        private System.Windows.Forms.Timer CheckForDebugger;
    }
}