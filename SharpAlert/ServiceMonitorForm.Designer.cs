namespace SharpAlert
{
    partial class ServiceMonitorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceMonitorForm));
            this.label1 = new System.Windows.Forms.Label();
            this.FeedCapturePanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            this.FeedCaptureStatusText = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AtomFeedCapturePanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            this.AtomFeedCaptureStatusText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.DirectFeedCapturePanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            this.DirectFeedCaptureStatusText = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.CacheCapturePanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            this.CacheCaptureStatusText = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.DataProcessorPanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            this.DataProcessorStatusText = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.HistoryProcessorPanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            this.HistoryProcessorStatusText = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.UpdateStatusPage = new System.Windows.Forms.Timer(this.components);
            this.UpdateDirectFeedCapture = new System.Windows.Forms.Timer(this.components);
            this.AlertProcessorPanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            this.AlertProcessorStatusText = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.borderPanel1 = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.FeedCapturePanel.SuspendLayout();
            this.AtomFeedCapturePanel.SuspendLayout();
            this.DirectFeedCapturePanel.SuspendLayout();
            this.CacheCapturePanel.SuspendLayout();
            this.DataProcessorPanel.SuspendLayout();
            this.HistoryProcessorPanel.SuspendLayout();
            this.AlertProcessorPanel.SuspendLayout();
            this.borderPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(251, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Details concerning services are shown here.";
            // 
            // FeedCapturePanel
            // 
            this.FeedCapturePanel.BorderColor = System.Drawing.Color.White;
            this.FeedCapturePanel.BorderThickness = 8;
            this.FeedCapturePanel.Controls.Add(this.FeedCaptureStatusText);
            this.FeedCapturePanel.Controls.Add(this.label3);
            this.FeedCapturePanel.Location = new System.Drawing.Point(12, 27);
            this.FeedCapturePanel.Name = "FeedCapturePanel";
            this.FeedCapturePanel.Size = new System.Drawing.Size(420, 90);
            this.FeedCapturePanel.TabIndex = 1;
            // 
            // FeedCaptureStatusText
            // 
            this.FeedCaptureStatusText.BackColor = System.Drawing.Color.Transparent;
            this.FeedCaptureStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FeedCaptureStatusText.Font = new System.Drawing.Font("Arial", 30F);
            this.FeedCaptureStatusText.Location = new System.Drawing.Point(0, 31);
            this.FeedCaptureStatusText.Margin = new System.Windows.Forms.Padding(0);
            this.FeedCaptureStatusText.Name = "FeedCaptureStatusText";
            this.FeedCaptureStatusText.Size = new System.Drawing.Size(420, 59);
            this.FeedCaptureStatusText.TabIndex = 1;
            this.FeedCaptureStatusText.Text = "...";
            this.FeedCaptureStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Arial", 12F);
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(420, 31);
            this.label3.TabIndex = 0;
            this.label3.Text = "HTTP Feed Capture";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // AtomFeedCapturePanel
            // 
            this.AtomFeedCapturePanel.BorderColor = System.Drawing.Color.White;
            this.AtomFeedCapturePanel.BorderThickness = 8;
            this.AtomFeedCapturePanel.Controls.Add(this.AtomFeedCaptureStatusText);
            this.AtomFeedCapturePanel.Controls.Add(this.label4);
            this.AtomFeedCapturePanel.Location = new System.Drawing.Point(12, 123);
            this.AtomFeedCapturePanel.Name = "AtomFeedCapturePanel";
            this.AtomFeedCapturePanel.Size = new System.Drawing.Size(420, 90);
            this.AtomFeedCapturePanel.TabIndex = 2;
            // 
            // AtomFeedCaptureStatusText
            // 
            this.AtomFeedCaptureStatusText.BackColor = System.Drawing.Color.Transparent;
            this.AtomFeedCaptureStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AtomFeedCaptureStatusText.Font = new System.Drawing.Font("Arial", 30F);
            this.AtomFeedCaptureStatusText.Location = new System.Drawing.Point(0, 31);
            this.AtomFeedCaptureStatusText.Margin = new System.Windows.Forms.Padding(0);
            this.AtomFeedCaptureStatusText.Name = "AtomFeedCaptureStatusText";
            this.AtomFeedCaptureStatusText.Size = new System.Drawing.Size(420, 59);
            this.AtomFeedCaptureStatusText.TabIndex = 1;
            this.AtomFeedCaptureStatusText.Text = "...";
            this.AtomFeedCaptureStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Arial", 12F);
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(420, 31);
            this.label4.TabIndex = 0;
            this.label4.Text = "Atom Feed Capture";
            this.label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // DirectFeedCapturePanel
            // 
            this.DirectFeedCapturePanel.BorderColor = System.Drawing.Color.White;
            this.DirectFeedCapturePanel.BorderThickness = 8;
            this.DirectFeedCapturePanel.Controls.Add(this.DirectFeedCaptureStatusText);
            this.DirectFeedCapturePanel.Controls.Add(this.label6);
            this.DirectFeedCapturePanel.Location = new System.Drawing.Point(12, 219);
            this.DirectFeedCapturePanel.Name = "DirectFeedCapturePanel";
            this.DirectFeedCapturePanel.Size = new System.Drawing.Size(420, 90);
            this.DirectFeedCapturePanel.TabIndex = 3;
            // 
            // DirectFeedCaptureStatusText
            // 
            this.DirectFeedCaptureStatusText.BackColor = System.Drawing.Color.Transparent;
            this.DirectFeedCaptureStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DirectFeedCaptureStatusText.Font = new System.Drawing.Font("Arial", 30F);
            this.DirectFeedCaptureStatusText.Location = new System.Drawing.Point(0, 31);
            this.DirectFeedCaptureStatusText.Margin = new System.Windows.Forms.Padding(0);
            this.DirectFeedCaptureStatusText.Name = "DirectFeedCaptureStatusText";
            this.DirectFeedCaptureStatusText.Size = new System.Drawing.Size(420, 59);
            this.DirectFeedCaptureStatusText.TabIndex = 1;
            this.DirectFeedCaptureStatusText.Text = "...";
            this.DirectFeedCaptureStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Arial", 12F);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(420, 31);
            this.label6.TabIndex = 0;
            this.label6.Text = "TCP Feed Capture";
            this.label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // CacheCapturePanel
            // 
            this.CacheCapturePanel.BorderColor = System.Drawing.Color.White;
            this.CacheCapturePanel.BorderThickness = 8;
            this.CacheCapturePanel.Controls.Add(this.CacheCaptureStatusText);
            this.CacheCapturePanel.Controls.Add(this.label8);
            this.CacheCapturePanel.Location = new System.Drawing.Point(12, 315);
            this.CacheCapturePanel.Name = "CacheCapturePanel";
            this.CacheCapturePanel.Size = new System.Drawing.Size(420, 90);
            this.CacheCapturePanel.TabIndex = 4;
            // 
            // CacheCaptureStatusText
            // 
            this.CacheCaptureStatusText.BackColor = System.Drawing.Color.Transparent;
            this.CacheCaptureStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CacheCaptureStatusText.Font = new System.Drawing.Font("Arial", 30F);
            this.CacheCaptureStatusText.Location = new System.Drawing.Point(0, 31);
            this.CacheCaptureStatusText.Margin = new System.Windows.Forms.Padding(0);
            this.CacheCaptureStatusText.Name = "CacheCaptureStatusText";
            this.CacheCaptureStatusText.Size = new System.Drawing.Size(420, 59);
            this.CacheCaptureStatusText.TabIndex = 1;
            this.CacheCaptureStatusText.Text = "...";
            this.CacheCaptureStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Arial", 12F);
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Margin = new System.Windows.Forms.Padding(0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(420, 31);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cache Capture";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // DataProcessorPanel
            // 
            this.DataProcessorPanel.BorderColor = System.Drawing.Color.White;
            this.DataProcessorPanel.BorderThickness = 8;
            this.DataProcessorPanel.Controls.Add(this.DataProcessorStatusText);
            this.DataProcessorPanel.Controls.Add(this.label10);
            this.DataProcessorPanel.Location = new System.Drawing.Point(438, 27);
            this.DataProcessorPanel.Name = "DataProcessorPanel";
            this.DataProcessorPanel.Size = new System.Drawing.Size(420, 90);
            this.DataProcessorPanel.TabIndex = 5;
            // 
            // DataProcessorStatusText
            // 
            this.DataProcessorStatusText.BackColor = System.Drawing.Color.Transparent;
            this.DataProcessorStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DataProcessorStatusText.Font = new System.Drawing.Font("Arial", 30F);
            this.DataProcessorStatusText.Location = new System.Drawing.Point(0, 31);
            this.DataProcessorStatusText.Margin = new System.Windows.Forms.Padding(0);
            this.DataProcessorStatusText.Name = "DataProcessorStatusText";
            this.DataProcessorStatusText.Size = new System.Drawing.Size(420, 59);
            this.DataProcessorStatusText.TabIndex = 1;
            this.DataProcessorStatusText.Text = "...";
            this.DataProcessorStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Arial", 12F);
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(420, 31);
            this.label10.TabIndex = 0;
            this.label10.Text = "Data Processor";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // HistoryProcessorPanel
            // 
            this.HistoryProcessorPanel.BorderColor = System.Drawing.Color.White;
            this.HistoryProcessorPanel.BorderThickness = 8;
            this.HistoryProcessorPanel.Controls.Add(this.HistoryProcessorStatusText);
            this.HistoryProcessorPanel.Controls.Add(this.label12);
            this.HistoryProcessorPanel.Location = new System.Drawing.Point(438, 123);
            this.HistoryProcessorPanel.Name = "HistoryProcessorPanel";
            this.HistoryProcessorPanel.Size = new System.Drawing.Size(420, 90);
            this.HistoryProcessorPanel.TabIndex = 6;
            // 
            // HistoryProcessorStatusText
            // 
            this.HistoryProcessorStatusText.BackColor = System.Drawing.Color.Transparent;
            this.HistoryProcessorStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HistoryProcessorStatusText.Font = new System.Drawing.Font("Arial", 30F);
            this.HistoryProcessorStatusText.Location = new System.Drawing.Point(0, 31);
            this.HistoryProcessorStatusText.Margin = new System.Windows.Forms.Padding(0);
            this.HistoryProcessorStatusText.Name = "HistoryProcessorStatusText";
            this.HistoryProcessorStatusText.Size = new System.Drawing.Size(420, 59);
            this.HistoryProcessorStatusText.TabIndex = 1;
            this.HistoryProcessorStatusText.Text = "...";
            this.HistoryProcessorStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Arial", 12F);
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(420, 31);
            this.label12.TabIndex = 0;
            this.label12.Text = "History Processor";
            this.label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // UpdateStatusPage
            // 
            this.UpdateStatusPage.Enabled = true;
            this.UpdateStatusPage.Interval = 50;
            this.UpdateStatusPage.Tick += new System.EventHandler(this.UpdateStatusPage_Tick);
            // 
            // UpdateDirectFeedCapture
            // 
            this.UpdateDirectFeedCapture.Enabled = true;
            this.UpdateDirectFeedCapture.Interval = 500;
            this.UpdateDirectFeedCapture.Tick += new System.EventHandler(this.UpdateDirectFeedCapture_Tick);
            // 
            // AlertProcessorPanel
            // 
            this.AlertProcessorPanel.BorderColor = System.Drawing.Color.White;
            this.AlertProcessorPanel.BorderThickness = 8;
            this.AlertProcessorPanel.Controls.Add(this.AlertProcessorStatusText);
            this.AlertProcessorPanel.Controls.Add(this.label5);
            this.AlertProcessorPanel.Location = new System.Drawing.Point(438, 219);
            this.AlertProcessorPanel.Name = "AlertProcessorPanel";
            this.AlertProcessorPanel.Size = new System.Drawing.Size(420, 90);
            this.AlertProcessorPanel.TabIndex = 7;
            // 
            // AlertProcessorStatusText
            // 
            this.AlertProcessorStatusText.BackColor = System.Drawing.Color.Transparent;
            this.AlertProcessorStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlertProcessorStatusText.Font = new System.Drawing.Font("Arial", 30F);
            this.AlertProcessorStatusText.Location = new System.Drawing.Point(0, 31);
            this.AlertProcessorStatusText.Margin = new System.Windows.Forms.Padding(0);
            this.AlertProcessorStatusText.Name = "AlertProcessorStatusText";
            this.AlertProcessorStatusText.Size = new System.Drawing.Size(420, 59);
            this.AlertProcessorStatusText.TabIndex = 1;
            this.AlertProcessorStatusText.Text = "...";
            this.AlertProcessorStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Arial", 12F);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(420, 31);
            this.label5.TabIndex = 0;
            this.label5.Text = "Alert Processor";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // borderPanel1
            // 
            this.borderPanel1.BorderColor = System.Drawing.Color.White;
            this.borderPanel1.BorderThickness = 8;
            this.borderPanel1.Controls.Add(this.label2);
            this.borderPanel1.Controls.Add(this.label7);
            this.borderPanel1.Location = new System.Drawing.Point(438, 315);
            this.borderPanel1.Name = "borderPanel1";
            this.borderPanel1.Size = new System.Drawing.Size(420, 90);
            this.borderPanel1.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Arial", 30F);
            this.label2.Location = new System.Drawing.Point(0, 31);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(420, 59);
            this.label2.TabIndex = 1;
            this.label2.Text = "...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Arial", 12F);
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(420, 31);
            this.label7.TabIndex = 0;
            this.label7.Text = "Pipe Worker";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // ServiceMonitorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(870, 424);
            this.Controls.Add(this.borderPanel1);
            this.Controls.Add(this.AlertProcessorPanel);
            this.Controls.Add(this.HistoryProcessorPanel);
            this.Controls.Add(this.DataProcessorPanel);
            this.Controls.Add(this.CacheCapturePanel);
            this.Controls.Add(this.DirectFeedCapturePanel);
            this.Controls.Add(this.AtomFeedCapturePanel);
            this.Controls.Add(this.FeedCapturePanel);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ServiceMonitorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Service Monitoring";
            this.Load += new System.EventHandler(this.ServiceMonitorForm_Load);
            this.FeedCapturePanel.ResumeLayout(false);
            this.AtomFeedCapturePanel.ResumeLayout(false);
            this.DirectFeedCapturePanel.ResumeLayout(false);
            this.CacheCapturePanel.ResumeLayout(false);
            this.DataProcessorPanel.ResumeLayout(false);
            this.HistoryProcessorPanel.ResumeLayout(false);
            this.AlertProcessorPanel.ResumeLayout(false);
            this.borderPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private WinFormsControls.ToolboxStuff.BorderPanel FeedCapturePanel;
        private System.Windows.Forms.Label FeedCaptureStatusText;
        private System.Windows.Forms.Label label3;
        private WinFormsControls.ToolboxStuff.BorderPanel AtomFeedCapturePanel;
        private System.Windows.Forms.Label AtomFeedCaptureStatusText;
        private System.Windows.Forms.Label label4;
        private WinFormsControls.ToolboxStuff.BorderPanel DirectFeedCapturePanel;
        private System.Windows.Forms.Label DirectFeedCaptureStatusText;
        private System.Windows.Forms.Label label6;
        private WinFormsControls.ToolboxStuff.BorderPanel CacheCapturePanel;
        private System.Windows.Forms.Label CacheCaptureStatusText;
        private System.Windows.Forms.Label label8;
        private WinFormsControls.ToolboxStuff.BorderPanel DataProcessorPanel;
        private System.Windows.Forms.Label DataProcessorStatusText;
        private System.Windows.Forms.Label label10;
        private WinFormsControls.ToolboxStuff.BorderPanel HistoryProcessorPanel;
        private System.Windows.Forms.Label HistoryProcessorStatusText;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Timer UpdateStatusPage;
        private System.Windows.Forms.Timer UpdateDirectFeedCapture;
        private WinFormsControls.ToolboxStuff.BorderPanel AlertProcessorPanel;
        private System.Windows.Forms.Label AlertProcessorStatusText;
        private System.Windows.Forms.Label label5;
        private WinFormsControls.ToolboxStuff.BorderPanel borderPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
    }
}
