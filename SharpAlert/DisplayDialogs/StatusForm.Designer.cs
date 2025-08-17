namespace SharpAlert.DisplayDialogs
{
    partial class StatusForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StatusForm));
            this.RefreshData = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.CAPQueueCountText = new System.Windows.Forms.Label();
            this.CAPHistoryCountText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AlertQueueCountText = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.AlertsRelayedText = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ServerRequestsText = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.UptimeMeterText = new System.Windows.Forms.Label();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // RefreshData
            // 
            this.RefreshData.Enabled = true;
            this.RefreshData.Interval = 500;
            this.RefreshData.Tick += new System.EventHandler(this.RefreshData_Tick);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 10F);
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "CAP Queue Count";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CAPQueueCountText
            // 
            this.CAPQueueCountText.Font = new System.Drawing.Font("Arial", 28F);
            this.CAPQueueCountText.Location = new System.Drawing.Point(9, 29);
            this.CAPQueueCountText.Margin = new System.Windows.Forms.Padding(0);
            this.CAPQueueCountText.Name = "CAPQueueCountText";
            this.CAPQueueCountText.Size = new System.Drawing.Size(134, 52);
            this.CAPQueueCountText.TabIndex = 1;
            this.CAPQueueCountText.Text = "0";
            this.CAPQueueCountText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.CAPQueueCountText, "The number of items waiting in the queue.");
            // 
            // CAPHistoryCountText
            // 
            this.CAPHistoryCountText.Font = new System.Drawing.Font("Arial", 28F);
            this.CAPHistoryCountText.Location = new System.Drawing.Point(143, 29);
            this.CAPHistoryCountText.Margin = new System.Windows.Forms.Padding(0);
            this.CAPHistoryCountText.Name = "CAPHistoryCountText";
            this.CAPHistoryCountText.Size = new System.Drawing.Size(134, 52);
            this.CAPHistoryCountText.TabIndex = 3;
            this.CAPHistoryCountText.Text = "0";
            this.CAPHistoryCountText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.CAPHistoryCountText, "The number of items in the history. This includes discarded alerts.");
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 10F);
            this.label4.Location = new System.Drawing.Point(143, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "CAP History Count";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlertQueueCountText
            // 
            this.AlertQueueCountText.Font = new System.Drawing.Font("Arial", 28F);
            this.AlertQueueCountText.Location = new System.Drawing.Point(277, 29);
            this.AlertQueueCountText.Margin = new System.Windows.Forms.Padding(0);
            this.AlertQueueCountText.Name = "AlertQueueCountText";
            this.AlertQueueCountText.Size = new System.Drawing.Size(134, 52);
            this.AlertQueueCountText.TabIndex = 5;
            this.AlertQueueCountText.Text = "0";
            this.AlertQueueCountText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.AlertQueueCountText, "The number of alerts in the queue.");
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 10F);
            this.label6.Location = new System.Drawing.Point(277, 9);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Alert Queue Count";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AlertsRelayedText
            // 
            this.AlertsRelayedText.Font = new System.Drawing.Font("Arial", 28F);
            this.AlertsRelayedText.Location = new System.Drawing.Point(9, 101);
            this.AlertsRelayedText.Margin = new System.Windows.Forms.Padding(0);
            this.AlertsRelayedText.Name = "AlertsRelayedText";
            this.AlertsRelayedText.Size = new System.Drawing.Size(134, 52);
            this.AlertsRelayedText.TabIndex = 7;
            this.AlertsRelayedText.Text = "0";
            this.AlertsRelayedText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.AlertsRelayedText, "The number of alerts relayed successfully.");
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 10F);
            this.label8.Location = new System.Drawing.Point(9, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Alerts Relayed";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServerRequestsText
            // 
            this.ServerRequestsText.Font = new System.Drawing.Font("Arial", 28F);
            this.ServerRequestsText.Location = new System.Drawing.Point(143, 101);
            this.ServerRequestsText.Margin = new System.Windows.Forms.Padding(0);
            this.ServerRequestsText.Name = "ServerRequestsText";
            this.ServerRequestsText.Size = new System.Drawing.Size(268, 52);
            this.ServerRequestsText.TabIndex = 9;
            this.ServerRequestsText.Text = "10000000";
            this.ServerRequestsText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.ServerRequestsText, "The number of successful server requests.\r\n\r\nFor HTTP servers, this indicates a r" +
        "equest returning code 200.\r\nFor TCP servers, this indicates that the \"</alert>\" " +
        "closing tag was received.");
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Arial", 10F);
            this.label10.Location = new System.Drawing.Point(143, 81);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(268, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "Server Messages (resets at 10,000,000)";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UptimeMeterText
            // 
            this.UptimeMeterText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UptimeMeterText.Font = new System.Drawing.Font("Arial", 10F);
            this.UptimeMeterText.Location = new System.Drawing.Point(0, 166);
            this.UptimeMeterText.Margin = new System.Windows.Forms.Padding(0);
            this.UptimeMeterText.Name = "UptimeMeterText";
            this.UptimeMeterText.Size = new System.Drawing.Size(420, 20);
            this.UptimeMeterText.TabIndex = 12;
            this.UptimeMeterText.Text = ";w;";
            this.UptimeMeterText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // StatusForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(420, 186);
            this.Controls.Add(this.UptimeMeterText);
            this.Controls.Add(this.ServerRequestsText);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.AlertsRelayedText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AlertQueueCountText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CAPHistoryCountText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CAPQueueCountText);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.Name = "StatusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert Status";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.StatusForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer RefreshData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CAPQueueCountText;
        private System.Windows.Forms.Label CAPHistoryCountText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label AlertQueueCountText;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label AlertsRelayedText;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label ServerRequestsText;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label UptimeMeterText;
        private System.Windows.Forms.ToolTip ToolTipInformation;
    }
}
