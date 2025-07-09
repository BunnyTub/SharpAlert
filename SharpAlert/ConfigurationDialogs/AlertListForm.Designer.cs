namespace SharpAlert.ConfigurationDialogs
{
    partial class AlertListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertListForm));
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.AlertHistoryClearButton = new System.Windows.Forms.Button();
            this.AlertHistoryRefreshButton = new System.Windows.Forms.Button();
            this.AlertHistoryReplayRecentButton = new System.Windows.Forms.Button();
            this.AlertHistoryDumpLink = new System.Windows.Forms.LinkLabel();
            this.BusyLockText = new System.Windows.Forms.Label();
            this.AlertHistoryOutput = new System.Windows.Forms.TextBox();
            this.PlayTestButton = new System.Windows.Forms.Button();
            this.ImportFileButton = new System.Windows.Forms.Button();
            this.RevealAlertIdentifierInput = new System.Windows.Forms.TextBox();
            this.RevealButton = new System.Windows.Forms.Button();
            this.RevealRecentButton = new System.Windows.Forms.Button();
            this.PastAlertsGroup = new System.Windows.Forms.GroupBox();
            this.AlertHistoryText = new System.Windows.Forms.Label();
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            this.AlertListRefresher = new System.Windows.Forms.Timer(this.components);
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
            // AlertHistoryClearButton
            // 
            this.AlertHistoryClearButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertHistoryClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AlertHistoryClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AlertHistoryClearButton.Location = new System.Drawing.Point(592, 78);
            this.AlertHistoryClearButton.Name = "AlertHistoryClearButton";
            this.AlertHistoryClearButton.Size = new System.Drawing.Size(72, 93);
            this.AlertHistoryClearButton.TabIndex = 26;
            this.AlertHistoryClearButton.Text = "Clear\r\nHistory";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryClearButton, "Clears the history list.");
            this.AlertHistoryClearButton.UseVisualStyleBackColor = false;
            this.AlertHistoryClearButton.Click += new System.EventHandler(this.AlertHistoryClearButton_Click);
            // 
            // AlertHistoryRefreshButton
            // 
            this.AlertHistoryRefreshButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertHistoryRefreshButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AlertHistoryRefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AlertHistoryRefreshButton.Location = new System.Drawing.Point(592, 49);
            this.AlertHistoryRefreshButton.Name = "AlertHistoryRefreshButton";
            this.AlertHistoryRefreshButton.Size = new System.Drawing.Size(72, 23);
            this.AlertHistoryRefreshButton.TabIndex = 25;
            this.AlertHistoryRefreshButton.Text = "Refresh";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryRefreshButton, "Refreshes the history list.\r\n");
            this.AlertHistoryRefreshButton.UseVisualStyleBackColor = false;
            this.AlertHistoryRefreshButton.Click += new System.EventHandler(this.AlertHistoryRefreshButton_Click);
            // 
            // AlertHistoryReplayRecentButton
            // 
            this.AlertHistoryReplayRecentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertHistoryReplayRecentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.AlertHistoryReplayRecentButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AlertHistoryReplayRecentButton.Location = new System.Drawing.Point(514, 20);
            this.AlertHistoryReplayRecentButton.Name = "AlertHistoryReplayRecentButton";
            this.AlertHistoryReplayRecentButton.Size = new System.Drawing.Size(72, 23);
            this.AlertHistoryReplayRecentButton.TabIndex = 22;
            this.AlertHistoryReplayRecentButton.Text = "Replay";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryReplayRecentButton, "Immediately calls the Alert Proccessor to process the most recent alert again.\r\nE" +
        "xpiry does not affect whether or not an alert can be replayed.");
            this.AlertHistoryReplayRecentButton.UseVisualStyleBackColor = false;
            this.AlertHistoryReplayRecentButton.Click += new System.EventHandler(this.AlertHistoryReplayRecentButton_Click);
            // 
            // AlertHistoryDumpLink
            // 
            this.AlertHistoryDumpLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertHistoryDumpLink.AutoSize = true;
            this.AlertHistoryDumpLink.LinkColor = System.Drawing.Color.Pink;
            this.AlertHistoryDumpLink.Location = new System.Drawing.Point(401, 17);
            this.AlertHistoryDumpLink.Name = "AlertHistoryDumpLink";
            this.AlertHistoryDumpLink.Size = new System.Drawing.Size(107, 15);
            this.AlertHistoryDumpLink.TabIndex = 16;
            this.AlertHistoryDumpLink.TabStop = true;
            this.AlertHistoryDumpLink.Text = "Export alert history";
            this.ToolTipInformation.SetToolTip(this.AlertHistoryDumpLink, "Dumps the alert history to a folder named \"dump\", then opens the folder in File E" +
        "xplorer.");
            this.AlertHistoryDumpLink.VisitedLinkColor = System.Drawing.Color.Cyan;
            this.AlertHistoryDumpLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AlertHistoryDumpLink_LinkClicked);
            // 
            // BusyLockText
            // 
            this.BusyLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BusyLockText.Font = new System.Drawing.Font("Arial", 12F);
            this.BusyLockText.Location = new System.Drawing.Point(0, 0);
            this.BusyLockText.Name = "BusyLockText";
            this.BusyLockText.Size = new System.Drawing.Size(694, 201);
            this.BusyLockText.TabIndex = 14;
            this.BusyLockText.Text = "Please wait or dismiss all alerts to configure settings.";
            this.BusyLockText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.BusyLockText, "You\'ll need to wait for all alerts to finish before continuing.");
            // 
            // AlertHistoryOutput
            // 
            this.AlertHistoryOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertHistoryOutput.BackColor = System.Drawing.Color.Black;
            this.AlertHistoryOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlertHistoryOutput.Font = new System.Drawing.Font("Arial", 12F);
            this.AlertHistoryOutput.ForeColor = System.Drawing.Color.White;
            this.AlertHistoryOutput.Location = new System.Drawing.Point(6, 35);
            this.AlertHistoryOutput.Multiline = true;
            this.AlertHistoryOutput.Name = "AlertHistoryOutput";
            this.AlertHistoryOutput.ReadOnly = true;
            this.AlertHistoryOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AlertHistoryOutput.Size = new System.Drawing.Size(502, 107);
            this.AlertHistoryOutput.TabIndex = 18;
            this.ToolTipInformation.SetToolTip(this.AlertHistoryOutput, "This area shows the identifiers of each alert. If an identifier couldn\'t be found" +
        ", the identifier will be an MD5 value based on the alert\'s raw data.");
            this.AlertHistoryOutput.WordWrap = false;
            // 
            // PlayTestButton
            // 
            this.PlayTestButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PlayTestButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.PlayTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PlayTestButton.Font = new System.Drawing.Font("Arial", 9F);
            this.PlayTestButton.ForeColor = System.Drawing.Color.White;
            this.PlayTestButton.Location = new System.Drawing.Point(592, 20);
            this.PlayTestButton.Name = "PlayTestButton";
            this.PlayTestButton.Size = new System.Drawing.Size(72, 23);
            this.PlayTestButton.TabIndex = 24;
            this.PlayTestButton.Text = "New Alert";
            this.ToolTipInformation.SetToolTip(this.PlayTestButton, "Opens the alert editor window.");
            this.PlayTestButton.UseVisualStyleBackColor = false;
            this.PlayTestButton.Click += new System.EventHandler(this.PlayTestButton_Click);
            // 
            // ImportFileButton
            // 
            this.ImportFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportFileButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.ImportFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ImportFileButton.Font = new System.Drawing.Font("Arial", 9F);
            this.ImportFileButton.ForeColor = System.Drawing.Color.White;
            this.ImportFileButton.Location = new System.Drawing.Point(514, 49);
            this.ImportFileButton.Name = "ImportFileButton";
            this.ImportFileButton.Size = new System.Drawing.Size(72, 122);
            this.ImportFileButton.TabIndex = 23;
            this.ImportFileButton.Text = "Add File To Queue";
            this.ToolTipInformation.SetToolTip(this.ImportFileButton, resources.GetString("ImportFileButton.ToolTip"));
            this.ImportFileButton.UseVisualStyleBackColor = false;
            this.ImportFileButton.Click += new System.EventHandler(this.ImportFileButton_Click);
            // 
            // RevealAlertIdentifierInput
            // 
            this.RevealAlertIdentifierInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RevealAlertIdentifierInput.BackColor = System.Drawing.Color.Black;
            this.RevealAlertIdentifierInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RevealAlertIdentifierInput.ForeColor = System.Drawing.Color.White;
            this.RevealAlertIdentifierInput.Location = new System.Drawing.Point(6, 150);
            this.RevealAlertIdentifierInput.Name = "RevealAlertIdentifierInput";
            this.RevealAlertIdentifierInput.Size = new System.Drawing.Size(380, 21);
            this.RevealAlertIdentifierInput.TabIndex = 19;
            this.ToolTipInformation.SetToolTip(this.RevealAlertIdentifierInput, "The alert identifier you want to access.");
            this.RevealAlertIdentifierInput.UseSystemPasswordChar = true;
            // 
            // RevealButton
            // 
            this.RevealButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RevealButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.RevealButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RevealButton.Font = new System.Drawing.Font("Arial", 9F);
            this.RevealButton.Location = new System.Drawing.Point(392, 148);
            this.RevealButton.Name = "RevealButton";
            this.RevealButton.Size = new System.Drawing.Size(55, 23);
            this.RevealButton.TabIndex = 20;
            this.RevealButton.Text = "Show";
            this.ToolTipInformation.SetToolTip(this.RevealButton, "Reveal more information about a specific identifier in the list.");
            this.RevealButton.UseMnemonic = false;
            this.RevealButton.UseVisualStyleBackColor = false;
            this.RevealButton.Click += new System.EventHandler(this.RevealButton_Click);
            // 
            // RevealRecentButton
            // 
            this.RevealRecentButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RevealRecentButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.RevealRecentButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RevealRecentButton.Font = new System.Drawing.Font("Arial", 9F);
            this.RevealRecentButton.Location = new System.Drawing.Point(453, 148);
            this.RevealRecentButton.Name = "RevealRecentButton";
            this.RevealRecentButton.Size = new System.Drawing.Size(55, 23);
            this.RevealRecentButton.TabIndex = 21;
            this.RevealRecentButton.Text = "Recent";
            this.ToolTipInformation.SetToolTip(this.RevealRecentButton, "Reveal more information about the most recent alert in the list.");
            this.RevealRecentButton.UseMnemonic = false;
            this.RevealRecentButton.UseVisualStyleBackColor = false;
            this.RevealRecentButton.Click += new System.EventHandler(this.RevealRecentButton_Click);
            // 
            // PastAlertsGroup
            // 
            this.PastAlertsGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PastAlertsGroup.Controls.Add(this.RevealRecentButton);
            this.PastAlertsGroup.Controls.Add(this.RevealButton);
            this.PastAlertsGroup.Controls.Add(this.RevealAlertIdentifierInput);
            this.PastAlertsGroup.Controls.Add(this.ImportFileButton);
            this.PastAlertsGroup.Controls.Add(this.PlayTestButton);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryDumpLink);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryReplayRecentButton);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryText);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryOutput);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryClearButton);
            this.PastAlertsGroup.Controls.Add(this.AlertHistoryRefreshButton);
            this.PastAlertsGroup.ForeColor = System.Drawing.Color.White;
            this.PastAlertsGroup.Location = new System.Drawing.Point(12, 12);
            this.PastAlertsGroup.Name = "PastAlertsGroup";
            this.PastAlertsGroup.Size = new System.Drawing.Size(670, 177);
            this.PastAlertsGroup.TabIndex = 5;
            this.PastAlertsGroup.TabStop = false;
            this.PastAlertsGroup.Text = "Alert List";
            // 
            // AlertHistoryText
            // 
            this.AlertHistoryText.AutoSize = true;
            this.AlertHistoryText.Location = new System.Drawing.Point(6, 17);
            this.AlertHistoryText.Name = "AlertHistoryText";
            this.AlertHistoryText.Size = new System.Drawing.Size(185, 15);
            this.AlertHistoryText.TabIndex = 6;
            this.AlertHistoryText.Text = "There are no items in the history.";
            // 
            // ConfigurationPanel
            // 
            this.ConfigurationPanel.Controls.Add(this.PastAlertsGroup);
            this.ConfigurationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigurationPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfigurationPanel.Name = "ConfigurationPanel";
            this.ConfigurationPanel.Size = new System.Drawing.Size(694, 201);
            this.ConfigurationPanel.TabIndex = 13;
            this.ConfigurationPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.ConfigurationPanel_Paint);
            // 
            // AlertListRefresher
            // 
            this.AlertListRefresher.Enabled = true;
            this.AlertListRefresher.Tick += new System.EventHandler(this.AlertListRefresher_Tick);
            // 
            // AlertListForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(694, 201);
            this.Controls.Add(this.ConfigurationPanel);
            this.Controls.Add(this.BusyLockText);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(710, 240);
            this.Name = "AlertListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Alert Manager";
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
        private System.Windows.Forms.LinkLabel AlertHistoryDumpLink;
        private System.Windows.Forms.Button AlertHistoryReplayRecentButton;
        private System.Windows.Forms.Button AlertHistoryRefreshButton;
        private System.Windows.Forms.Label AlertHistoryText;
        private System.Windows.Forms.TextBox AlertHistoryOutput;
        private System.Windows.Forms.Button AlertHistoryClearButton;
        private System.Windows.Forms.Panel ConfigurationPanel;
        private System.Windows.Forms.Label BusyLockText;
        private System.Windows.Forms.Button PlayTestButton;
        private System.Windows.Forms.Button ImportFileButton;
        private System.Windows.Forms.Timer AlertListRefresher;
        private System.Windows.Forms.Button RevealRecentButton;
        private System.Windows.Forms.Button RevealButton;
        private System.Windows.Forms.TextBox RevealAlertIdentifierInput;
    }
}
