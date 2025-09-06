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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveConfigurationForm));
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.PastAlertsGroup = new System.Windows.Forms.GroupBox();
            this.DeleteArchiveButton = new System.Windows.Forms.Button();
            this.ArchivingSaveAllAlertsBox = new System.Windows.Forms.CheckBox();
            this.ArchivingDeleteOldAlertsOver48hBox = new System.Windows.Forms.CheckBox();
            this.ArchivingAggressiveProcessingBox = new System.Windows.Forms.CheckBox();
            this.OpenArchiveButton = new System.Windows.Forms.Button();
            this.PastAlertsGroup.SuspendLayout();
            this.SuspendLayout();
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
            // PastAlertsGroup
            // 
            this.PastAlertsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PastAlertsGroup.Controls.Add(this.OpenArchiveButton);
            this.PastAlertsGroup.Controls.Add(this.ArchivingAggressiveProcessingBox);
            this.PastAlertsGroup.Controls.Add(this.ArchivingDeleteOldAlertsOver48hBox);
            this.PastAlertsGroup.Controls.Add(this.ArchivingSaveAllAlertsBox);
            this.PastAlertsGroup.Controls.Add(this.DeleteArchiveButton);
            this.PastAlertsGroup.ForeColor = System.Drawing.Color.White;
            this.PastAlertsGroup.Location = new System.Drawing.Point(12, 12);
            this.PastAlertsGroup.Name = "PastAlertsGroup";
            this.PastAlertsGroup.Size = new System.Drawing.Size(460, 97);
            this.PastAlertsGroup.TabIndex = 5;
            this.PastAlertsGroup.TabStop = false;
            this.PastAlertsGroup.Text = "Archive Manager";
            // 
            // DeleteArchiveButton
            // 
            this.DeleteArchiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DeleteArchiveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DeleteArchiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DeleteArchiveButton.Font = new System.Drawing.Font("Arial", 9F);
            this.DeleteArchiveButton.ForeColor = System.Drawing.Color.White;
            this.DeleteArchiveButton.Location = new System.Drawing.Point(343, 20);
            this.DeleteArchiveButton.Name = "DeleteArchiveButton";
            this.DeleteArchiveButton.Size = new System.Drawing.Size(111, 23);
            this.DeleteArchiveButton.TabIndex = 28;
            this.DeleteArchiveButton.Text = "Delete Archive";
            this.DeleteArchiveButton.UseVisualStyleBackColor = false;
            this.DeleteArchiveButton.Click += new System.EventHandler(this.DeleteArchiveButton_Click);
            // 
            // ArchivingSaveAllAlertsBox
            // 
            this.ArchivingSaveAllAlertsBox.AutoSize = true;
            this.ArchivingSaveAllAlertsBox.Location = new System.Drawing.Point(6, 20);
            this.ArchivingSaveAllAlertsBox.Name = "ArchivingSaveAllAlertsBox";
            this.ArchivingSaveAllAlertsBox.Size = new System.Drawing.Size(142, 19);
            this.ArchivingSaveAllAlertsBox.TabIndex = 29;
            this.ArchivingSaveAllAlertsBox.Text = "Save all alerts to disk";
            this.ToolTipInformation.SetToolTip(this.ArchivingSaveAllAlertsBox, "Saves alerts in the history to disk.");
            this.ArchivingSaveAllAlertsBox.UseVisualStyleBackColor = true;
            // 
            // ArchivingDeleteOldAlertsOver48hBox
            // 
            this.ArchivingDeleteOldAlertsOver48hBox.AutoSize = true;
            this.ArchivingDeleteOldAlertsOver48hBox.Location = new System.Drawing.Point(6, 45);
            this.ArchivingDeleteOldAlertsOver48hBox.Name = "ArchivingDeleteOldAlertsOver48hBox";
            this.ArchivingDeleteOldAlertsOver48hBox.Size = new System.Drawing.Size(206, 19);
            this.ArchivingDeleteOldAlertsOver48hBox.TabIndex = 30;
            this.ArchivingDeleteOldAlertsOver48hBox.Text = "Delete alerts older than 48 hours";
            this.ToolTipInformation.SetToolTip(this.ArchivingDeleteOldAlertsOver48hBox, "Deletes alerts older than 48 hours from disk.\r\nThis feature deletes ANY file olde" +
        "r than 48 hours in the archive folder, please do not store important data inside" +
        " of it.");
            this.ArchivingDeleteOldAlertsOver48hBox.UseVisualStyleBackColor = true;
            // 
            // ArchivingAggressiveProcessingBox
            // 
            this.ArchivingAggressiveProcessingBox.AutoSize = true;
            this.ArchivingAggressiveProcessingBox.Location = new System.Drawing.Point(6, 70);
            this.ArchivingAggressiveProcessingBox.Name = "ArchivingAggressiveProcessingBox";
            this.ArchivingAggressiveProcessingBox.Size = new System.Drawing.Size(194, 19);
            this.ArchivingAggressiveProcessingBox.TabIndex = 31;
            this.ArchivingAggressiveProcessingBox.Text = "Aggressive archive processing";
            this.ToolTipInformation.SetToolTip(this.ArchivingAggressiveProcessingBox, "Completely removes sleeping between file operations.\r\nThis will most likely incre" +
        "ase disk usage.");
            this.ArchivingAggressiveProcessingBox.UseVisualStyleBackColor = true;
            // 
            // OpenArchiveButton
            // 
            this.OpenArchiveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenArchiveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.OpenArchiveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OpenArchiveButton.Font = new System.Drawing.Font("Arial", 9F);
            this.OpenArchiveButton.ForeColor = System.Drawing.Color.White;
            this.OpenArchiveButton.Location = new System.Drawing.Point(343, 49);
            this.OpenArchiveButton.Name = "OpenArchiveButton";
            this.OpenArchiveButton.Size = new System.Drawing.Size(111, 42);
            this.OpenArchiveButton.TabIndex = 29;
            this.OpenArchiveButton.Text = "View Archive";
            this.OpenArchiveButton.UseVisualStyleBackColor = false;
            this.OpenArchiveButton.Click += new System.EventHandler(this.OpenArchiveButton_Click);
            // 
            // ArchiveConfigurationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(484, 121);
            this.Controls.Add(this.PastAlertsGroup);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 160);
            this.Name = "ArchiveConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Archive Manager";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.VisibleChanged += new System.EventHandler(this.ConfigurationForm_VisibleChanged);
            this.PastAlertsGroup.ResumeLayout(false);
            this.PastAlertsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.GroupBox PastAlertsGroup;
        private System.Windows.Forms.CheckBox ArchivingAggressiveProcessingBox;
        private System.Windows.Forms.CheckBox ArchivingDeleteOldAlertsOver48hBox;
        private System.Windows.Forms.CheckBox ArchivingSaveAllAlertsBox;
        private System.Windows.Forms.Button DeleteArchiveButton;
        private System.Windows.Forms.Button OpenArchiveButton;
    }
}
