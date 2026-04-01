namespace SharpAlert.ConfigurationDialogs
{
    partial class ArchiveConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveConfigurationForm));
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            ArchivingSaveAllAlertsBox = new System.Windows.Forms.CheckBox();
            ArchivingDeleteOldAlertsOver48hBox = new System.Windows.Forms.CheckBox();
            ArchivingAggressiveProcessingBox = new System.Windows.Forms.CheckBox();
            PastAlertsGroup = new System.Windows.Forms.GroupBox();
            OpenArchiveButton = new System.Windows.Forms.Button();
            DeleteArchiveButton = new System.Windows.Forms.Button();
            WindowShake = new System.Windows.Forms.Timer(components);
            PastAlertsGroup.SuspendLayout();
            SuspendLayout();
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
            // ArchivingSaveAllAlertsBox
            // 
            ArchivingSaveAllAlertsBox.AutoSize = true;
            ArchivingSaveAllAlertsBox.Location = new System.Drawing.Point(6, 20);
            ArchivingSaveAllAlertsBox.Name = "ArchivingSaveAllAlertsBox";
            ArchivingSaveAllAlertsBox.Size = new System.Drawing.Size(134, 19);
            ArchivingSaveAllAlertsBox.TabIndex = 29;
            ArchivingSaveAllAlertsBox.Text = "Save all alerts to disk";
            ToolTipInformation.SetToolTip(ArchivingSaveAllAlertsBox, "Saves alerts in the history to disk.");
            ArchivingSaveAllAlertsBox.UseVisualStyleBackColor = true;
            // 
            // ArchivingDeleteOldAlertsOver48hBox
            // 
            ArchivingDeleteOldAlertsOver48hBox.AutoSize = true;
            ArchivingDeleteOldAlertsOver48hBox.Location = new System.Drawing.Point(6, 45);
            ArchivingDeleteOldAlertsOver48hBox.Name = "ArchivingDeleteOldAlertsOver48hBox";
            ArchivingDeleteOldAlertsOver48hBox.Size = new System.Drawing.Size(195, 19);
            ArchivingDeleteOldAlertsOver48hBox.TabIndex = 30;
            ArchivingDeleteOldAlertsOver48hBox.Text = "Delete alerts older than 48 hours";
            ToolTipInformation.SetToolTip(ArchivingDeleteOldAlertsOver48hBox, "Deletes alerts older than 48 hours from disk.\r\nThis feature deletes ANY file older than 48 hours in the archive folder, please do not store important data inside of it.");
            ArchivingDeleteOldAlertsOver48hBox.UseVisualStyleBackColor = true;
            // 
            // ArchivingAggressiveProcessingBox
            // 
            ArchivingAggressiveProcessingBox.AutoSize = true;
            ArchivingAggressiveProcessingBox.Location = new System.Drawing.Point(6, 70);
            ArchivingAggressiveProcessingBox.Name = "ArchivingAggressiveProcessingBox";
            ArchivingAggressiveProcessingBox.Size = new System.Drawing.Size(184, 19);
            ArchivingAggressiveProcessingBox.TabIndex = 31;
            ArchivingAggressiveProcessingBox.Text = "Aggressive archive processing";
            ToolTipInformation.SetToolTip(ArchivingAggressiveProcessingBox, "Completely removes sleeping between file operations.\r\nThis will most likely increase disk usage.");
            ArchivingAggressiveProcessingBox.UseVisualStyleBackColor = true;
            // 
            // PastAlertsGroup
            // 
            PastAlertsGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            PastAlertsGroup.Controls.Add(OpenArchiveButton);
            PastAlertsGroup.Controls.Add(ArchivingAggressiveProcessingBox);
            PastAlertsGroup.Controls.Add(ArchivingDeleteOldAlertsOver48hBox);
            PastAlertsGroup.Controls.Add(ArchivingSaveAllAlertsBox);
            PastAlertsGroup.Controls.Add(DeleteArchiveButton);
            PastAlertsGroup.ForeColor = System.Drawing.Color.White;
            PastAlertsGroup.Location = new System.Drawing.Point(12, 12);
            PastAlertsGroup.Name = "PastAlertsGroup";
            PastAlertsGroup.Size = new System.Drawing.Size(460, 97);
            PastAlertsGroup.TabIndex = 5;
            PastAlertsGroup.TabStop = false;
            PastAlertsGroup.Text = "Archive Manager";
            // 
            // OpenArchiveButton
            // 
            OpenArchiveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            OpenArchiveButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            OpenArchiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            OpenArchiveButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            OpenArchiveButton.ForeColor = System.Drawing.Color.White;
            OpenArchiveButton.Location = new System.Drawing.Point(343, 49);
            OpenArchiveButton.Name = "OpenArchiveButton";
            OpenArchiveButton.Size = new System.Drawing.Size(111, 42);
            OpenArchiveButton.TabIndex = 29;
            OpenArchiveButton.Text = "View Archive";
            OpenArchiveButton.UseVisualStyleBackColor = false;
            OpenArchiveButton.Click += OpenArchiveButton_Click;
            // 
            // DeleteArchiveButton
            // 
            DeleteArchiveButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DeleteArchiveButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DeleteArchiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DeleteArchiveButton.Font = new System.Drawing.Font("Segoe UI", 9F);
            DeleteArchiveButton.ForeColor = System.Drawing.Color.White;
            DeleteArchiveButton.Location = new System.Drawing.Point(343, 20);
            DeleteArchiveButton.Name = "DeleteArchiveButton";
            DeleteArchiveButton.Size = new System.Drawing.Size(111, 23);
            DeleteArchiveButton.TabIndex = 28;
            DeleteArchiveButton.Text = "Delete Archive";
            DeleteArchiveButton.UseVisualStyleBackColor = false;
            DeleteArchiveButton.Click += DeleteArchiveButton_Click;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // ArchiveConfigurationForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(484, 121);
            Controls.Add(PastAlertsGroup);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(500, 160);
            Name = "ArchiveConfigurationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Archive Manager";
            Load += ConfigurationForm_Load;
            VisibleChanged += ConfigurationForm_VisibleChanged;
            PastAlertsGroup.ResumeLayout(false);
            PastAlertsGroup.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.GroupBox PastAlertsGroup;
        private System.Windows.Forms.CheckBox ArchivingAggressiveProcessingBox;
        private System.Windows.Forms.CheckBox ArchivingDeleteOldAlertsOver48hBox;
        private System.Windows.Forms.CheckBox ArchivingSaveAllAlertsBox;
        private System.Windows.Forms.Button DeleteArchiveButton;
        private System.Windows.Forms.Button OpenArchiveButton;
        private System.Windows.Forms.Timer WindowShake;
    }
}
