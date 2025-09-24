namespace SharpAlert.AlertComponents
{
    partial class AlertInfoForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertInfoForm));
            InfoTip = new System.Windows.Forms.ToolTip(components);
            DismissButton = new System.Windows.Forms.Button();
            AlertIcon = new System.Windows.Forms.PictureBox();
            SubtitlePanel = new System.Windows.Forms.Panel();
            SubtitleText = new System.Windows.Forms.Label();
            SubtitleSpacer = new System.Windows.Forms.Panel();
            OutlineContainerPanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            AlertLinkText = new System.Windows.Forms.LinkLabel();
            AlertText = new System.Windows.Forms.TextBox();
            TitleText = new System.Windows.Forms.Label();
            ResizeBottomRight = new System.Windows.Forms.Panel();
            ChildFollowsParent = new System.Windows.Forms.Timer(components);
            TerminateSelf = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)AlertIcon).BeginInit();
            SubtitlePanel.SuspendLayout();
            OutlineContainerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // InfoTip
            // 
            InfoTip.AutomaticDelay = 250;
            InfoTip.AutoPopDelay = 15000;
            InfoTip.BackColor = System.Drawing.Color.White;
            InfoTip.ForeColor = System.Drawing.Color.Black;
            InfoTip.InitialDelay = 250;
            InfoTip.IsBalloon = true;
            InfoTip.ReshowDelay = 50;
            InfoTip.ToolTipTitle = "What does this do?";
            // 
            // DismissButton
            // 
            DismissButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DismissButton.BackColor = System.Drawing.Color.White;
            DismissButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DismissButton.Font = new System.Drawing.Font("Arial", 16F);
            DismissButton.ForeColor = System.Drawing.Color.Black;
            DismissButton.Location = new System.Drawing.Point(598, 329);
            DismissButton.Name = "DismissButton";
            DismissButton.Size = new System.Drawing.Size(115, 35);
            DismissButton.TabIndex = 0;
            DismissButton.Text = "Dismiss";
            InfoTip.SetToolTip(DismissButton, "Closes the alert.");
            DismissButton.UseVisualStyleBackColor = false;
            DismissButton.Click += DismissButton_Click;
            // 
            // AlertIcon
            // 
            AlertIcon.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AlertIcon.BackColor = System.Drawing.Color.Green;
            AlertIcon.Image = Properties.Resources.WarningApp;
            AlertIcon.Location = new System.Drawing.Point(665, 4);
            AlertIcon.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            AlertIcon.Name = "AlertIcon";
            AlertIcon.Size = new System.Drawing.Size(48, 48);
            AlertIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            AlertIcon.TabIndex = 2;
            AlertIcon.TabStop = false;
            AlertIcon.MouseDown += AlertIcon_MouseDown;
            // 
            // SubtitlePanel
            // 
            SubtitlePanel.BackColor = System.Drawing.Color.FromArgb(0, 80, 0);
            SubtitlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            SubtitlePanel.Controls.Add(SubtitleText);
            SubtitlePanel.Controls.Add(SubtitleSpacer);
            SubtitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            SubtitlePanel.ForeColor = System.Drawing.Color.White;
            SubtitlePanel.Location = new System.Drawing.Point(4, 54);
            SubtitlePanel.Margin = new System.Windows.Forms.Padding(10);
            SubtitlePanel.Name = "SubtitlePanel";
            SubtitlePanel.Size = new System.Drawing.Size(712, 32);
            SubtitlePanel.TabIndex = 7;
            // 
            // SubtitleText
            // 
            SubtitleText.BackColor = System.Drawing.Color.Transparent;
            SubtitleText.Dock = System.Windows.Forms.DockStyle.Fill;
            SubtitleText.Font = new System.Drawing.Font("Arial", 18F);
            SubtitleText.Location = new System.Drawing.Point(8, 0);
            SubtitleText.Name = "SubtitleText";
            SubtitleText.Size = new System.Drawing.Size(704, 32);
            SubtitleText.TabIndex = 3;
            SubtitleText.Text = "Short Alert Description";
            SubtitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            SubtitleText.DoubleClick += SubtitleText_DoubleClick;
            // 
            // SubtitleSpacer
            // 
            SubtitleSpacer.BackColor = System.Drawing.Color.Transparent;
            SubtitleSpacer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            SubtitleSpacer.Dock = System.Windows.Forms.DockStyle.Left;
            SubtitleSpacer.ForeColor = System.Drawing.Color.White;
            SubtitleSpacer.Location = new System.Drawing.Point(0, 0);
            SubtitleSpacer.Margin = new System.Windows.Forms.Padding(10);
            SubtitleSpacer.Name = "SubtitleSpacer";
            SubtitleSpacer.Size = new System.Drawing.Size(8, 32);
            SubtitleSpacer.TabIndex = 2;
            // 
            // OutlineContainerPanel
            // 
            OutlineContainerPanel.BorderColor = System.Drawing.Color.Green;
            OutlineContainerPanel.BorderThickness = 4;
            OutlineContainerPanel.Controls.Add(DismissButton);
            OutlineContainerPanel.Controls.Add(AlertLinkText);
            OutlineContainerPanel.Controls.Add(AlertIcon);
            OutlineContainerPanel.Controls.Add(AlertText);
            OutlineContainerPanel.Controls.Add(SubtitlePanel);
            OutlineContainerPanel.Controls.Add(TitleText);
            OutlineContainerPanel.Controls.Add(ResizeBottomRight);
            OutlineContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            OutlineContainerPanel.Location = new System.Drawing.Point(0, 0);
            OutlineContainerPanel.Margin = new System.Windows.Forms.Padding(0);
            OutlineContainerPanel.Name = "OutlineContainerPanel";
            OutlineContainerPanel.Padding = new System.Windows.Forms.Padding(4);
            OutlineContainerPanel.Size = new System.Drawing.Size(720, 371);
            OutlineContainerPanel.TabIndex = 12;
            OutlineContainerPanel.Paint += OutlineContainerPanel_Paint;
            // 
            // AlertLinkText
            // 
            AlertLinkText.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AlertLinkText.BackColor = System.Drawing.Color.Transparent;
            AlertLinkText.Font = new System.Drawing.Font("Arial", 12F);
            AlertLinkText.LinkColor = System.Drawing.Color.FromArgb(0, 127, 255);
            AlertLinkText.Location = new System.Drawing.Point(9, 329);
            AlertLinkText.Margin = new System.Windows.Forms.Padding(0);
            AlertLinkText.Name = "AlertLinkText";
            AlertLinkText.Size = new System.Drawing.Size(545, 35);
            AlertLinkText.TabIndex = 11;
            AlertLinkText.TabStop = true;
            AlertLinkText.Text = "https://bunnytub.com/SharpAlert";
            AlertLinkText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            AlertLinkText.LinkClicked += AlertLinkText_LinkClicked;
            // 
            // AlertText
            // 
            AlertText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AlertText.BackColor = System.Drawing.Color.Black;
            AlertText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            AlertText.Font = new System.Drawing.Font("Arial", 18F);
            AlertText.ForeColor = System.Drawing.Color.White;
            AlertText.Location = new System.Drawing.Point(4, 85);
            AlertText.Multiline = true;
            AlertText.Name = "AlertText";
            AlertText.ReadOnly = true;
            AlertText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            AlertText.Size = new System.Drawing.Size(711, 242);
            AlertText.TabIndex = 8;
            // 
            // TitleText
            // 
            TitleText.BackColor = System.Drawing.Color.Green;
            TitleText.Dock = System.Windows.Forms.DockStyle.Top;
            TitleText.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            TitleText.Location = new System.Drawing.Point(4, 4);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(712, 50);
            TitleText.TabIndex = 9;
            TitleText.Text = "ALERT DETAILS";
            TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TitleText.MouseDown += TitleText_MouseDown;
            // 
            // ResizeBottomRight
            // 
            ResizeBottomRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ResizeBottomRight.BackColor = System.Drawing.Color.Transparent;
            ResizeBottomRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            ResizeBottomRight.Location = new System.Drawing.Point(704, 355);
            ResizeBottomRight.Name = "ResizeBottomRight";
            ResizeBottomRight.Size = new System.Drawing.Size(16, 16);
            ResizeBottomRight.TabIndex = 10;
            ResizeBottomRight.MouseDown += ResizableThingPanel_MouseDown;
            ResizeBottomRight.MouseMove += ResizableThingPanel_MouseMove;
            ResizeBottomRight.MouseUp += ResizableThingPanel_MouseUp;
            // 
            // ChildFollowsParent
            // 
            ChildFollowsParent.Enabled = true;
            ChildFollowsParent.Interval = 75;
            ChildFollowsParent.Tick += ChildFollowsParent_Tick;
            // 
            // AlertInfoForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(720, 371);
            ControlBox = false;
            Controls.Add(OutlineContainerPanel);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Arial", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AlertInfoForm";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "SharpAlert - Alert Panel";
            TopMost = true;
            FormClosing += AlertForm_FormClosing;
            FormClosed += AlertForm_FormClosed;
            Load += AlertForm_Load;
            Shown += AlertForm_Shown;
            ((System.ComponentModel.ISupportInitialize)AlertIcon).EndInit();
            SubtitlePanel.ResumeLayout(false);
            OutlineContainerPanel.ResumeLayout(false);
            OutlineContainerPanel.PerformLayout();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip InfoTip;
        private System.Windows.Forms.PictureBox AlertIcon;
        private System.Windows.Forms.Panel SubtitlePanel;
        private System.Windows.Forms.Label SubtitleText;
        private System.Windows.Forms.Panel SubtitleSpacer;
        private WinFormsControls.ToolboxStuff.BorderPanel OutlineContainerPanel;
        private System.Windows.Forms.TextBox AlertText;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.Panel ResizeBottomRight;
        private System.Windows.Forms.LinkLabel AlertLinkText;
        private System.Windows.Forms.Timer ChildFollowsParent;
        private System.Windows.Forms.Timer TerminateSelf;
    }
}


