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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceMonitorForm));
            label1 = new System.Windows.Forms.Label();
            FeedCapturePanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            FeedCaptureStatusText = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            AtomFeedCapturePanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            AtomFeedCaptureStatusText = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            DirectFeedCapturePanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            DirectFeedCaptureStatusText = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            CacheCapturePanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            CacheCaptureStatusText = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            DataProcessorPanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            DataProcessorStatusText = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            HistoryProcessorPanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            HistoryProcessorStatusText = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            UpdateStatusPage = new System.Windows.Forms.Timer(components);
            UpdateDirectFeedCapture = new System.Windows.Forms.Timer(components);
            AlertProcessorPanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            AlertProcessorStatusText = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            borderPanel1 = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            label2 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            IDAPCapturePanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            IDAPCaptureStatusText = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            FeedCapturePanel.SuspendLayout();
            AtomFeedCapturePanel.SuspendLayout();
            DirectFeedCapturePanel.SuspendLayout();
            CacheCapturePanel.SuspendLayout();
            DataProcessorPanel.SuspendLayout();
            HistoryProcessorPanel.SuspendLayout();
            AlertProcessorPanel.SuspendLayout();
            borderPanel1.SuspendLayout();
            IDAPCapturePanel.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(420, 15);
            label1.TabIndex = 0;
            label1.Text = "Capturing";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FeedCapturePanel
            // 
            FeedCapturePanel.BorderColor = System.Drawing.Color.White;
            FeedCapturePanel.BorderThickness = 8;
            FeedCapturePanel.Controls.Add(FeedCaptureStatusText);
            FeedCapturePanel.Controls.Add(label3);
            FeedCapturePanel.Location = new System.Drawing.Point(12, 123);
            FeedCapturePanel.Name = "FeedCapturePanel";
            FeedCapturePanel.Size = new System.Drawing.Size(420, 90);
            FeedCapturePanel.TabIndex = 1;
            // 
            // FeedCaptureStatusText
            // 
            FeedCaptureStatusText.BackColor = System.Drawing.Color.Transparent;
            FeedCaptureStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            FeedCaptureStatusText.Font = new System.Drawing.Font("Segoe UI", 26F);
            FeedCaptureStatusText.Location = new System.Drawing.Point(0, 31);
            FeedCaptureStatusText.Margin = new System.Windows.Forms.Padding(0);
            FeedCaptureStatusText.Name = "FeedCaptureStatusText";
            FeedCaptureStatusText.Size = new System.Drawing.Size(420, 59);
            FeedCaptureStatusText.TabIndex = 1;
            FeedCaptureStatusText.Text = "...";
            FeedCaptureStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Dock = System.Windows.Forms.DockStyle.Top;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F);
            label3.Location = new System.Drawing.Point(0, 0);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(420, 31);
            label3.TabIndex = 0;
            label3.Text = "HTTP Feed Capture";
            label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // AtomFeedCapturePanel
            // 
            AtomFeedCapturePanel.BorderColor = System.Drawing.Color.White;
            AtomFeedCapturePanel.BorderThickness = 8;
            AtomFeedCapturePanel.Controls.Add(AtomFeedCaptureStatusText);
            AtomFeedCapturePanel.Controls.Add(label4);
            AtomFeedCapturePanel.Location = new System.Drawing.Point(12, 219);
            AtomFeedCapturePanel.Name = "AtomFeedCapturePanel";
            AtomFeedCapturePanel.Size = new System.Drawing.Size(420, 90);
            AtomFeedCapturePanel.TabIndex = 2;
            // 
            // AtomFeedCaptureStatusText
            // 
            AtomFeedCaptureStatusText.BackColor = System.Drawing.Color.Transparent;
            AtomFeedCaptureStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            AtomFeedCaptureStatusText.Font = new System.Drawing.Font("Segoe UI", 26F);
            AtomFeedCaptureStatusText.Location = new System.Drawing.Point(0, 31);
            AtomFeedCaptureStatusText.Margin = new System.Windows.Forms.Padding(0);
            AtomFeedCaptureStatusText.Name = "AtomFeedCaptureStatusText";
            AtomFeedCaptureStatusText.Size = new System.Drawing.Size(420, 59);
            AtomFeedCaptureStatusText.TabIndex = 1;
            AtomFeedCaptureStatusText.Text = "...";
            AtomFeedCaptureStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label4
            // 
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Dock = System.Windows.Forms.DockStyle.Top;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F);
            label4.Location = new System.Drawing.Point(0, 0);
            label4.Margin = new System.Windows.Forms.Padding(0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(420, 31);
            label4.TabIndex = 0;
            label4.Text = "Atom Feed Capture";
            label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // DirectFeedCapturePanel
            // 
            DirectFeedCapturePanel.BorderColor = System.Drawing.Color.White;
            DirectFeedCapturePanel.BorderThickness = 8;
            DirectFeedCapturePanel.Controls.Add(DirectFeedCaptureStatusText);
            DirectFeedCapturePanel.Controls.Add(label6);
            DirectFeedCapturePanel.Location = new System.Drawing.Point(12, 315);
            DirectFeedCapturePanel.Name = "DirectFeedCapturePanel";
            DirectFeedCapturePanel.Size = new System.Drawing.Size(420, 90);
            DirectFeedCapturePanel.TabIndex = 3;
            // 
            // DirectFeedCaptureStatusText
            // 
            DirectFeedCaptureStatusText.BackColor = System.Drawing.Color.Transparent;
            DirectFeedCaptureStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            DirectFeedCaptureStatusText.Font = new System.Drawing.Font("Segoe UI", 26F);
            DirectFeedCaptureStatusText.Location = new System.Drawing.Point(0, 31);
            DirectFeedCaptureStatusText.Margin = new System.Windows.Forms.Padding(0);
            DirectFeedCaptureStatusText.Name = "DirectFeedCaptureStatusText";
            DirectFeedCaptureStatusText.Size = new System.Drawing.Size(420, 59);
            DirectFeedCaptureStatusText.TabIndex = 1;
            DirectFeedCaptureStatusText.Text = "...";
            DirectFeedCaptureStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label6
            // 
            label6.BackColor = System.Drawing.Color.Transparent;
            label6.Dock = System.Windows.Forms.DockStyle.Top;
            label6.Font = new System.Drawing.Font("Segoe UI", 12F);
            label6.Location = new System.Drawing.Point(0, 0);
            label6.Margin = new System.Windows.Forms.Padding(0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(420, 31);
            label6.TabIndex = 0;
            label6.Text = "TCP Feed Capture";
            label6.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // CacheCapturePanel
            // 
            CacheCapturePanel.BorderColor = System.Drawing.Color.White;
            CacheCapturePanel.BorderThickness = 8;
            CacheCapturePanel.Controls.Add(CacheCaptureStatusText);
            CacheCapturePanel.Controls.Add(label8);
            CacheCapturePanel.Location = new System.Drawing.Point(12, 27);
            CacheCapturePanel.Name = "CacheCapturePanel";
            CacheCapturePanel.Size = new System.Drawing.Size(420, 90);
            CacheCapturePanel.TabIndex = 4;
            // 
            // CacheCaptureStatusText
            // 
            CacheCaptureStatusText.BackColor = System.Drawing.Color.Transparent;
            CacheCaptureStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            CacheCaptureStatusText.Font = new System.Drawing.Font("Segoe UI", 26F);
            CacheCaptureStatusText.Location = new System.Drawing.Point(0, 31);
            CacheCaptureStatusText.Margin = new System.Windows.Forms.Padding(0);
            CacheCaptureStatusText.Name = "CacheCaptureStatusText";
            CacheCaptureStatusText.Size = new System.Drawing.Size(420, 59);
            CacheCaptureStatusText.TabIndex = 1;
            CacheCaptureStatusText.Text = "...";
            CacheCaptureStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            label8.BackColor = System.Drawing.Color.Transparent;
            label8.Dock = System.Windows.Forms.DockStyle.Top;
            label8.Font = new System.Drawing.Font("Segoe UI", 12F);
            label8.Location = new System.Drawing.Point(0, 0);
            label8.Margin = new System.Windows.Forms.Padding(0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(420, 31);
            label8.TabIndex = 0;
            label8.Text = "Cache Capture";
            label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // DataProcessorPanel
            // 
            DataProcessorPanel.BorderColor = System.Drawing.Color.White;
            DataProcessorPanel.BorderThickness = 8;
            DataProcessorPanel.Controls.Add(DataProcessorStatusText);
            DataProcessorPanel.Controls.Add(label10);
            DataProcessorPanel.Location = new System.Drawing.Point(438, 27);
            DataProcessorPanel.Name = "DataProcessorPanel";
            DataProcessorPanel.Size = new System.Drawing.Size(420, 90);
            DataProcessorPanel.TabIndex = 5;
            // 
            // DataProcessorStatusText
            // 
            DataProcessorStatusText.BackColor = System.Drawing.Color.Transparent;
            DataProcessorStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            DataProcessorStatusText.Font = new System.Drawing.Font("Segoe UI", 26F);
            DataProcessorStatusText.Location = new System.Drawing.Point(0, 31);
            DataProcessorStatusText.Margin = new System.Windows.Forms.Padding(0);
            DataProcessorStatusText.Name = "DataProcessorStatusText";
            DataProcessorStatusText.Size = new System.Drawing.Size(420, 59);
            DataProcessorStatusText.TabIndex = 1;
            DataProcessorStatusText.Text = "...";
            DataProcessorStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label10
            // 
            label10.BackColor = System.Drawing.Color.Transparent;
            label10.Dock = System.Windows.Forms.DockStyle.Top;
            label10.Font = new System.Drawing.Font("Segoe UI", 12F);
            label10.Location = new System.Drawing.Point(0, 0);
            label10.Margin = new System.Windows.Forms.Padding(0);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(420, 31);
            label10.TabIndex = 0;
            label10.Text = "Data Processor";
            label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // HistoryProcessorPanel
            // 
            HistoryProcessorPanel.BorderColor = System.Drawing.Color.White;
            HistoryProcessorPanel.BorderThickness = 8;
            HistoryProcessorPanel.Controls.Add(HistoryProcessorStatusText);
            HistoryProcessorPanel.Controls.Add(label12);
            HistoryProcessorPanel.Location = new System.Drawing.Point(438, 123);
            HistoryProcessorPanel.Name = "HistoryProcessorPanel";
            HistoryProcessorPanel.Size = new System.Drawing.Size(420, 90);
            HistoryProcessorPanel.TabIndex = 6;
            // 
            // HistoryProcessorStatusText
            // 
            HistoryProcessorStatusText.BackColor = System.Drawing.Color.Transparent;
            HistoryProcessorStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            HistoryProcessorStatusText.Font = new System.Drawing.Font("Segoe UI", 26F);
            HistoryProcessorStatusText.Location = new System.Drawing.Point(0, 31);
            HistoryProcessorStatusText.Margin = new System.Windows.Forms.Padding(0);
            HistoryProcessorStatusText.Name = "HistoryProcessorStatusText";
            HistoryProcessorStatusText.Size = new System.Drawing.Size(420, 59);
            HistoryProcessorStatusText.TabIndex = 1;
            HistoryProcessorStatusText.Text = "...";
            HistoryProcessorStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label12
            // 
            label12.BackColor = System.Drawing.Color.Transparent;
            label12.Dock = System.Windows.Forms.DockStyle.Top;
            label12.Font = new System.Drawing.Font("Segoe UI", 12F);
            label12.Location = new System.Drawing.Point(0, 0);
            label12.Margin = new System.Windows.Forms.Padding(0);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(420, 31);
            label12.TabIndex = 0;
            label12.Text = "History Processor";
            label12.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // UpdateStatusPage
            // 
            UpdateStatusPage.Enabled = true;
            UpdateStatusPage.Interval = 50;
            UpdateStatusPage.Tick += UpdateStatusPage_Tick;
            // 
            // UpdateDirectFeedCapture
            // 
            UpdateDirectFeedCapture.Enabled = true;
            UpdateDirectFeedCapture.Interval = 500;
            UpdateDirectFeedCapture.Tick += UpdateDirectFeedCapture_Tick;
            // 
            // AlertProcessorPanel
            // 
            AlertProcessorPanel.BorderColor = System.Drawing.Color.White;
            AlertProcessorPanel.BorderThickness = 8;
            AlertProcessorPanel.Controls.Add(AlertProcessorStatusText);
            AlertProcessorPanel.Controls.Add(label5);
            AlertProcessorPanel.Location = new System.Drawing.Point(438, 219);
            AlertProcessorPanel.Name = "AlertProcessorPanel";
            AlertProcessorPanel.Size = new System.Drawing.Size(420, 90);
            AlertProcessorPanel.TabIndex = 7;
            // 
            // AlertProcessorStatusText
            // 
            AlertProcessorStatusText.BackColor = System.Drawing.Color.Transparent;
            AlertProcessorStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            AlertProcessorStatusText.Font = new System.Drawing.Font("Segoe UI", 26F);
            AlertProcessorStatusText.Location = new System.Drawing.Point(0, 31);
            AlertProcessorStatusText.Margin = new System.Windows.Forms.Padding(0);
            AlertProcessorStatusText.Name = "AlertProcessorStatusText";
            AlertProcessorStatusText.Size = new System.Drawing.Size(420, 59);
            AlertProcessorStatusText.TabIndex = 1;
            AlertProcessorStatusText.Text = "...";
            AlertProcessorStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.BackColor = System.Drawing.Color.Transparent;
            label5.Dock = System.Windows.Forms.DockStyle.Top;
            label5.Font = new System.Drawing.Font("Segoe UI", 12F);
            label5.Location = new System.Drawing.Point(0, 0);
            label5.Margin = new System.Windows.Forms.Padding(0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(420, 31);
            label5.TabIndex = 0;
            label5.Text = "Alert Processor";
            label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // borderPanel1
            // 
            borderPanel1.BorderColor = System.Drawing.Color.White;
            borderPanel1.BorderThickness = 8;
            borderPanel1.Controls.Add(label2);
            borderPanel1.Controls.Add(label7);
            borderPanel1.Location = new System.Drawing.Point(438, 315);
            borderPanel1.Name = "borderPanel1";
            borderPanel1.Size = new System.Drawing.Size(420, 90);
            borderPanel1.TabIndex = 8;
            // 
            // label2
            // 
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Font = new System.Drawing.Font("Segoe UI", 26F);
            label2.Location = new System.Drawing.Point(0, 31);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(420, 59);
            label2.TabIndex = 1;
            label2.Text = "...";
            label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            label7.BackColor = System.Drawing.Color.Transparent;
            label7.Dock = System.Windows.Forms.DockStyle.Top;
            label7.Font = new System.Drawing.Font("Segoe UI", 12F);
            label7.Location = new System.Drawing.Point(0, 0);
            label7.Margin = new System.Windows.Forms.Padding(0);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(420, 31);
            label7.TabIndex = 0;
            label7.Text = "Pipe Worker";
            label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // IDAPCapturePanel
            // 
            IDAPCapturePanel.BorderColor = System.Drawing.Color.White;
            IDAPCapturePanel.BorderThickness = 8;
            IDAPCapturePanel.Controls.Add(IDAPCaptureStatusText);
            IDAPCapturePanel.Controls.Add(label11);
            IDAPCapturePanel.Location = new System.Drawing.Point(12, 411);
            IDAPCapturePanel.Name = "IDAPCapturePanel";
            IDAPCapturePanel.Size = new System.Drawing.Size(420, 90);
            IDAPCapturePanel.TabIndex = 9;
            // 
            // IDAPCaptureStatusText
            // 
            IDAPCaptureStatusText.BackColor = System.Drawing.Color.Transparent;
            IDAPCaptureStatusText.Dock = System.Windows.Forms.DockStyle.Fill;
            IDAPCaptureStatusText.Font = new System.Drawing.Font("Segoe UI", 26F);
            IDAPCaptureStatusText.Location = new System.Drawing.Point(0, 31);
            IDAPCaptureStatusText.Margin = new System.Windows.Forms.Padding(0);
            IDAPCaptureStatusText.Name = "IDAPCaptureStatusText";
            IDAPCaptureStatusText.Size = new System.Drawing.Size(420, 59);
            IDAPCaptureStatusText.TabIndex = 1;
            IDAPCaptureStatusText.Text = "...";
            IDAPCaptureStatusText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            label11.BackColor = System.Drawing.Color.Transparent;
            label11.Dock = System.Windows.Forms.DockStyle.Top;
            label11.Font = new System.Drawing.Font("Segoe UI", 12F);
            label11.Location = new System.Drawing.Point(0, 0);
            label11.Margin = new System.Windows.Forms.Padding(0);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(420, 31);
            label11.TabIndex = 0;
            label11.Text = "IDAP Feed Capture";
            label11.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label9
            // 
            label9.Location = new System.Drawing.Point(438, 9);
            label9.Margin = new System.Windows.Forms.Padding(0);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(420, 15);
            label9.TabIndex = 10;
            label9.Text = "Processing";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ServiceMonitorForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(870, 511);
            Controls.Add(label9);
            Controls.Add(IDAPCapturePanel);
            Controls.Add(borderPanel1);
            Controls.Add(AlertProcessorPanel);
            Controls.Add(HistoryProcessorPanel);
            Controls.Add(DataProcessorPanel);
            Controls.Add(CacheCapturePanel);
            Controls.Add(DirectFeedCapturePanel);
            Controls.Add(AtomFeedCapturePanel);
            Controls.Add(FeedCapturePanel);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ServiceMonitorForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Service Monitoring";
            Load += ServiceMonitorForm_Load;
            FeedCapturePanel.ResumeLayout(false);
            AtomFeedCapturePanel.ResumeLayout(false);
            DirectFeedCapturePanel.ResumeLayout(false);
            CacheCapturePanel.ResumeLayout(false);
            DataProcessorPanel.ResumeLayout(false);
            HistoryProcessorPanel.ResumeLayout(false);
            AlertProcessorPanel.ResumeLayout(false);
            borderPanel1.ResumeLayout(false);
            IDAPCapturePanel.ResumeLayout(false);
            ResumeLayout(false);

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
        private WinFormsControls.ToolboxStuff.BorderPanel IDAPCapturePanel;
        private System.Windows.Forms.Label IDAPCaptureStatusText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
    }
}
