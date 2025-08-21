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
            this.button1 = new System.Windows.Forms.Button();
            this.ArchivingSaveAllAlertsBox = new System.Windows.Forms.CheckBox();
            this.ArchivingDeleteOldAlertsOver48hBox = new System.Windows.Forms.CheckBox();
            this.PastAlertsGroup = new System.Windows.Forms.GroupBox();
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            this.PastAlertsGroup.SuspendLayout();
            this.ConfigurationPanel.SuspendLayout();
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
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Arial", 9F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(682, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 23);
            this.button1.TabIndex = 28;
            this.button1.Text = "unknown";
            this.ToolTipInformation.SetToolTip(this.button1, "Opens the alert editor window.");
            this.button1.UseVisualStyleBackColor = false;
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
            this.ToolTipInformation.SetToolTip(this.ArchivingDeleteOldAlertsOver48hBox, "Deletes alerts older than 48 hours from disk.");
            this.ArchivingDeleteOldAlertsOver48hBox.UseVisualStyleBackColor = true;
            // 
            // PastAlertsGroup
            // 
            this.PastAlertsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PastAlertsGroup.Controls.Add(this.ArchivingDeleteOldAlertsOver48hBox);
            this.PastAlertsGroup.Controls.Add(this.ArchivingSaveAllAlertsBox);
            this.PastAlertsGroup.Controls.Add(this.button1);
            this.PastAlertsGroup.ForeColor = System.Drawing.Color.White;
            this.PastAlertsGroup.Location = new System.Drawing.Point(12, 12);
            this.PastAlertsGroup.Name = "PastAlertsGroup";
            this.PastAlertsGroup.Size = new System.Drawing.Size(460, 87);
            this.PastAlertsGroup.TabIndex = 5;
            this.PastAlertsGroup.TabStop = false;
            this.PastAlertsGroup.Text = "Archive Manager";
            // 
            // ConfigurationPanel
            // 
            this.ConfigurationPanel.Controls.Add(this.PastAlertsGroup);
            this.ConfigurationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigurationPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfigurationPanel.Name = "ConfigurationPanel";
            this.ConfigurationPanel.Size = new System.Drawing.Size(484, 111);
            this.ConfigurationPanel.TabIndex = 13;
            // 
            // ArchiveConfigurationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(484, 111);
            this.Controls.Add(this.ConfigurationPanel);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 150);
            this.Name = "ArchiveConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Archive Manager";
            this.Load += new System.EventHandler(this.ConfigurationForm_Load);
            this.VisibleChanged += new System.EventHandler(this.ConfigurationForm_VisibleChanged);
            this.PastAlertsGroup.ResumeLayout(false);
            this.PastAlertsGroup.PerformLayout();
            this.ConfigurationPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.GroupBox PastAlertsGroup;
        private System.Windows.Forms.Panel ConfigurationPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox ArchivingSaveAllAlertsBox;
        private System.Windows.Forms.CheckBox ArchivingDeleteOldAlertsOver48hBox;
    }
}
