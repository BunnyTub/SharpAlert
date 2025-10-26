namespace SharpAlert.AlertComponents.Dashboard
{
    partial class DashboardForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DashboardForm));
            TitlePanel = new System.Windows.Forms.Panel();
            PrimaryGeneralInfoText = new System.Windows.Forms.Label();
            GeneralInfoText = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            BrandText = new System.Windows.Forms.Label();
            LogoBox = new System.Windows.Forms.PictureBox();
            SpacerPanel = new System.Windows.Forms.Panel();
            DashboardPanel = new System.Windows.Forms.Panel();
            UpdateGeneralInfoTextTimer = new System.Windows.Forms.Timer(components);
            UpdateExpiryTimer = new System.Windows.Forms.Timer(components);
            ActiveAlertsText = new System.Windows.Forms.Label();
            SpacerLinePanel1 = new System.Windows.Forms.Panel();
            SubtitlePanel = new System.Windows.Forms.Panel();
            AutoScrollBox = new System.Windows.Forms.CheckBox();
            CycleBetweenInfoAndClockTimer = new System.Windows.Forms.Timer(components);
            DetectAlertActivity = new System.Windows.Forms.Timer(components);
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            TitlePanel.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            SubtitlePanel.SuspendLayout();
            SuspendLayout();
            // 
            // TitlePanel
            // 
            TitlePanel.BackColor = System.Drawing.Color.DarkRed;
            TitlePanel.Controls.Add(PrimaryGeneralInfoText);
            TitlePanel.Controls.Add(GeneralInfoText);
            TitlePanel.Controls.Add(panel1);
            TitlePanel.Controls.Add(LogoBox);
            TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            TitlePanel.Location = new System.Drawing.Point(0, 0);
            TitlePanel.Name = "TitlePanel";
            TitlePanel.Size = new System.Drawing.Size(800, 49);
            TitlePanel.TabIndex = 0;
            // 
            // PrimaryGeneralInfoText
            // 
            PrimaryGeneralInfoText.Dock = System.Windows.Forms.DockStyle.Fill;
            PrimaryGeneralInfoText.Font = new System.Drawing.Font("Segoe UI", 9F);
            PrimaryGeneralInfoText.Location = new System.Drawing.Point(358, 32);
            PrimaryGeneralInfoText.Margin = new System.Windows.Forms.Padding(2);
            PrimaryGeneralInfoText.Name = "PrimaryGeneralInfoText";
            PrimaryGeneralInfoText.Size = new System.Drawing.Size(442, 17);
            PrimaryGeneralInfoText.TabIndex = 5;
            PrimaryGeneralInfoText.Text = "...";
            PrimaryGeneralInfoText.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // GeneralInfoText
            // 
            GeneralInfoText.Dock = System.Windows.Forms.DockStyle.Top;
            GeneralInfoText.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            GeneralInfoText.Location = new System.Drawing.Point(358, 0);
            GeneralInfoText.Margin = new System.Windows.Forms.Padding(2);
            GeneralInfoText.Name = "GeneralInfoText";
            GeneralInfoText.Size = new System.Drawing.Size(442, 32);
            GeneralInfoText.TabIndex = 3;
            GeneralInfoText.Text = "...";
            GeneralInfoText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.DarkRed;
            panel1.Controls.Add(BrandText);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(64, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(294, 49);
            panel1.TabIndex = 4;
            // 
            // BrandText
            // 
            BrandText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            BrandText.Location = new System.Drawing.Point(5, 2);
            BrandText.Margin = new System.Windows.Forms.Padding(2);
            BrandText.Name = "BrandText";
            BrandText.Size = new System.Drawing.Size(285, 42);
            BrandText.TabIndex = 1;
            BrandText.Text = "SharpAlert";
            BrandText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LogoBox
            // 
            LogoBox.Dock = System.Windows.Forms.DockStyle.Left;
            LogoBox.Image = Properties.Resources.AlertIcon;
            LogoBox.Location = new System.Drawing.Point(0, 0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new System.Drawing.Size(64, 49);
            LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            LogoBox.TabIndex = 0;
            LogoBox.TabStop = false;
            ToolTipInformation.SetToolTip(LogoBox, "Double-click here to open a version of this dashboard for expired alerts only.\r\nThe expired alerts dashboard will display");
            LogoBox.DoubleClick += LogoBox_DoubleClick;
            // 
            // SpacerPanel
            // 
            SpacerPanel.BackColor = System.Drawing.Color.LightCoral;
            SpacerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            SpacerPanel.Location = new System.Drawing.Point(0, 49);
            SpacerPanel.Name = "SpacerPanel";
            SpacerPanel.Size = new System.Drawing.Size(800, 4);
            SpacerPanel.TabIndex = 1;
            // 
            // DashboardPanel
            // 
            DashboardPanel.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            DashboardPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            DashboardPanel.Location = new System.Drawing.Point(0, 103);
            DashboardPanel.Name = "DashboardPanel";
            DashboardPanel.Size = new System.Drawing.Size(800, 347);
            DashboardPanel.TabIndex = 2;
            // 
            // UpdateGeneralInfoTextTimer
            // 
            UpdateGeneralInfoTextTimer.Enabled = true;
            UpdateGeneralInfoTextTimer.Interval = 1000;
            UpdateGeneralInfoTextTimer.Tick += UpdateGeneralInfoTextTimer_Tick;
            // 
            // UpdateExpiryTimer
            // 
            UpdateExpiryTimer.Enabled = true;
            UpdateExpiryTimer.Interval = 5000;
            UpdateExpiryTimer.Tick += UpdateExpiryTimer_Tick;
            // 
            // ActiveAlertsText
            // 
            ActiveAlertsText.Dock = System.Windows.Forms.DockStyle.Top;
            ActiveAlertsText.Font = new System.Drawing.Font("Segoe UI", 24F);
            ActiveAlertsText.ForeColor = System.Drawing.Color.Gray;
            ActiveAlertsText.Location = new System.Drawing.Point(0, 0);
            ActiveAlertsText.Margin = new System.Windows.Forms.Padding(2);
            ActiveAlertsText.Name = "ActiveAlertsText";
            ActiveAlertsText.Size = new System.Drawing.Size(800, 40);
            ActiveAlertsText.TabIndex = 3;
            ActiveAlertsText.Text = " crickets... ~w~";
            ActiveAlertsText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            ActiveAlertsText.Click += ActiveAlertsText_Click;
            // 
            // SpacerLinePanel1
            // 
            SpacerLinePanel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            SpacerLinePanel1.BackColor = System.Drawing.Color.White;
            SpacerLinePanel1.Location = new System.Drawing.Point(12, 45);
            SpacerLinePanel1.Name = "SpacerLinePanel1";
            SpacerLinePanel1.Size = new System.Drawing.Size(776, 2);
            SpacerLinePanel1.TabIndex = 4;
            // 
            // SubtitlePanel
            // 
            SubtitlePanel.BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            SubtitlePanel.Controls.Add(AutoScrollBox);
            SubtitlePanel.Controls.Add(SpacerLinePanel1);
            SubtitlePanel.Controls.Add(ActiveAlertsText);
            SubtitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            SubtitlePanel.Location = new System.Drawing.Point(0, 53);
            SubtitlePanel.Name = "SubtitlePanel";
            SubtitlePanel.Size = new System.Drawing.Size(800, 50);
            SubtitlePanel.TabIndex = 5;
            // 
            // AutoScrollBox
            // 
            AutoScrollBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AutoScrollBox.AutoSize = true;
            AutoScrollBox.Location = new System.Drawing.Point(678, 0);
            AutoScrollBox.Name = "AutoScrollBox";
            AutoScrollBox.Size = new System.Drawing.Size(122, 19);
            AutoScrollBox.TabIndex = 0;
            AutoScrollBox.Text = "Enable Auto Scroll";
            AutoScrollBox.UseVisualStyleBackColor = true;
            AutoScrollBox.Visible = false;
            // 
            // CycleBetweenInfoAndClockTimer
            // 
            CycleBetweenInfoAndClockTimer.Interval = 5000;
            CycleBetweenInfoAndClockTimer.Tick += CycleBetweenInfoAndClockTimer_Tick;
            // 
            // DetectAlertActivity
            // 
            DetectAlertActivity.Enabled = true;
            DetectAlertActivity.Interval = 300;
            DetectAlertActivity.Tick += DetectAlertActivity_Tick;
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
            // DashboardForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(DashboardPanel);
            Controls.Add(SubtitlePanel);
            Controls.Add(SpacerPanel);
            Controls.Add(TitlePanel);
            DoubleBuffered = true;
            ForeColor = System.Drawing.Color.White;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MinimumSize = new System.Drawing.Size(816, 489);
            Name = "DashboardForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert Dashboard";
            FormClosed += DashboardForm_FormClosed;
            Load += DashboardForm_Load;
            TitlePanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            SubtitlePanel.ResumeLayout(false);
            SubtitlePanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Panel SpacerPanel;
        private System.Windows.Forms.Panel DashboardPanel;
        private System.Windows.Forms.Timer UpdateGeneralInfoTextTimer;
        private System.Windows.Forms.Timer UpdateExpiryTimer;
        private System.Windows.Forms.Label ActiveAlertsText;
        private System.Windows.Forms.Panel SpacerLinePanel1;
        private System.Windows.Forms.Panel SubtitlePanel;
        private System.Windows.Forms.CheckBox AutoScrollBox;
        private System.Windows.Forms.Timer CycleBetweenInfoAndClockTimer;
        private System.Windows.Forms.Label PrimaryGeneralInfoText;
        private System.Windows.Forms.Label GeneralInfoText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label BrandText;
        private System.Windows.Forms.Timer DetectAlertActivity;
        private System.Windows.Forms.ToolTip ToolTipInformation;
    }
}