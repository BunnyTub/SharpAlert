namespace SharpAlert.AlertComponents.Dashboard
{
    partial class DashboardListItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            AlertTitleText = new System.Windows.Forms.Label();
            AlertExpiresInTitleText = new System.Windows.Forms.Label();
            AlertExpiryText = new System.Windows.Forms.Label();
            AlertDescriptionText = new System.Windows.Forms.Label();
            AlertIssuedTimeAndDateText = new System.Windows.Forms.Label();
            ContainerPanel = new System.Windows.Forms.Panel();
            ChangeBackgroundColorTimer = new System.Windows.Forms.Timer(components);
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            ContainerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AlertTitleText
            // 
            AlertTitleText.AutoSize = true;
            AlertTitleText.BackColor = System.Drawing.Color.Transparent;
            AlertTitleText.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            AlertTitleText.Location = new System.Drawing.Point(4, 4);
            AlertTitleText.Margin = new System.Windows.Forms.Padding(8);
            AlertTitleText.Name = "AlertTitleText";
            AlertTitleText.Size = new System.Drawing.Size(286, 37);
            AlertTitleText.TabIndex = 1;
            AlertTitleText.Text = "Unknown Event Type";
            // 
            // AlertExpiresInTitleText
            // 
            AlertExpiresInTitleText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AlertExpiresInTitleText.BackColor = System.Drawing.Color.Transparent;
            AlertExpiresInTitleText.Font = new System.Drawing.Font("Segoe UI", 12F);
            AlertExpiresInTitleText.Location = new System.Drawing.Point(592, 3);
            AlertExpiresInTitleText.Margin = new System.Windows.Forms.Padding(8, 8, 8, 0);
            AlertExpiresInTitleText.Name = "AlertExpiresInTitleText";
            AlertExpiresInTitleText.Size = new System.Drawing.Size(102, 24);
            AlertExpiresInTitleText.TabIndex = 2;
            AlertExpiresInTitleText.Text = "Expires in:";
            AlertExpiresInTitleText.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AlertExpiryText
            // 
            AlertExpiryText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AlertExpiryText.BackColor = System.Drawing.Color.Transparent;
            AlertExpiryText.Cursor = System.Windows.Forms.Cursors.Hand;
            AlertExpiryText.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            AlertExpiryText.Location = new System.Drawing.Point(591, 20);
            AlertExpiryText.Margin = new System.Windows.Forms.Padding(0, 2, 0, 0);
            AlertExpiryText.Name = "AlertExpiryText";
            AlertExpiryText.Size = new System.Drawing.Size(102, 23);
            AlertExpiryText.TabIndex = 3;
            AlertExpiryText.Text = "99h 99m";
            AlertExpiryText.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            AlertExpiryText.Click += AlertExpiryText_Click;
            // 
            // AlertDescriptionText
            // 
            AlertDescriptionText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AlertDescriptionText.BackColor = System.Drawing.Color.Transparent;
            AlertDescriptionText.Cursor = System.Windows.Forms.Cursors.Hand;
            AlertDescriptionText.Font = new System.Drawing.Font("Segoe UI", 15.75F);
            AlertDescriptionText.Location = new System.Drawing.Point(4, 39);
            AlertDescriptionText.Margin = new System.Windows.Forms.Padding(0);
            AlertDescriptionText.Name = "AlertDescriptionText";
            AlertDescriptionText.Size = new System.Drawing.Size(689, 68);
            AlertDescriptionText.TabIndex = 4;
            AlertDescriptionText.Text = "Issued by Unknown Authority, sourced from External Source. For the following areas, No Known Good Areas...";
            AlertDescriptionText.Click += AlertDescriptionText_Click;
            // 
            // AlertIssuedTimeAndDateText
            // 
            AlertIssuedTimeAndDateText.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AlertIssuedTimeAndDateText.BackColor = System.Drawing.Color.Transparent;
            AlertIssuedTimeAndDateText.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            AlertIssuedTimeAndDateText.Location = new System.Drawing.Point(399, 97);
            AlertIssuedTimeAndDateText.Margin = new System.Windows.Forms.Padding(8, 4, 8, 8);
            AlertIssuedTimeAndDateText.Name = "AlertIssuedTimeAndDateText";
            AlertIssuedTimeAndDateText.Size = new System.Drawing.Size(294, 15);
            AlertIssuedTimeAndDateText.TabIndex = 5;
            AlertIssuedTimeAndDateText.Text = "Issued at 11:00 AM PDT 09/22/2025";
            AlertIssuedTimeAndDateText.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // ContainerPanel
            // 
            ContainerPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ContainerPanel.BackColor = System.Drawing.Color.Green;
            ContainerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ContainerPanel.Controls.Add(AlertIssuedTimeAndDateText);
            ContainerPanel.Controls.Add(AlertExpiresInTitleText);
            ContainerPanel.Controls.Add(AlertExpiryText);
            ContainerPanel.Controls.Add(AlertTitleText);
            ContainerPanel.Controls.Add(AlertDescriptionText);
            ContainerPanel.Location = new System.Drawing.Point(6, 6);
            ContainerPanel.Margin = new System.Windows.Forms.Padding(6);
            ContainerPanel.Name = "ContainerPanel";
            ContainerPanel.Size = new System.Drawing.Size(699, 118);
            ContainerPanel.TabIndex = 6;
            // 
            // ChangeBackgroundColorTimer
            // 
            ChangeBackgroundColorTimer.Enabled = true;
            ChangeBackgroundColorTimer.Interval = 1000;
            ChangeBackgroundColorTimer.Tick += ChangeBackgroundColorTimer_Tick;
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
            ToolTipInformation.ToolTipTitle = "What is the expanded alert info?";
            // 
            // DashboardListItem
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            Controls.Add(ContainerPanel);
            Font = new System.Drawing.Font("Arial", 9F);
            ForeColor = System.Drawing.Color.White;
            Name = "DashboardListItem";
            Size = new System.Drawing.Size(711, 130);
            Load += DashboardListItem_Load;
            ContainerPanel.ResumeLayout(false);
            ContainerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.Label AlertTitleText;
        public System.Windows.Forms.Label AlertExpiresInTitleText;
        public System.Windows.Forms.Label AlertExpiryText;
        public System.Windows.Forms.Label AlertDescriptionText;
        public System.Windows.Forms.Label AlertIssuedTimeAndDateText;
        public System.Windows.Forms.Panel ContainerPanel;
        private System.Windows.Forms.Timer ChangeBackgroundColorTimer;
        public System.Windows.Forms.ToolTip ToolTipInformation;
    }
}
