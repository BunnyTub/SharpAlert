namespace SharpAlert.AlertComponents
{
    partial class AlertForm
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
            this.AutoExit = new System.Windows.Forms.Timer(this.components);
            this.EnsureTopWindow = new System.Windows.Forms.Timer(this.components);
            this.FlashTaskbarStatus = new System.Windows.Forms.Timer(this.components);
            this.FadeInAnimation = new System.Windows.Forms.Timer(this.components);
            this.FadeOutAnimation = new System.Windows.Forms.Timer(this.components);
            this.InfoTip = new System.Windows.Forms.ToolTip(this.components);
            this.SpeakerButton = new System.Windows.Forms.Button();
            this.DismissButton = new System.Windows.Forms.Button();
            this.ButtonOptionsStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dismissAllAlertsFor30SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AlertIcon = new System.Windows.Forms.PictureBox();
            this.SubtitlePanel = new System.Windows.Forms.Panel();
            this.SubtitleText = new System.Windows.Forms.Label();
            this.SubtitleSpacer = new System.Windows.Forms.Panel();
            this.OutlineContainerPanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            this.AlertLinkText = new System.Windows.Forms.LinkLabel();
            this.AlertText = new System.Windows.Forms.TextBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.ResizeBottomRight = new System.Windows.Forms.Panel();
            this.WindowFlash = new System.Windows.Forms.Timer(this.components);
            this.TerminateSelf = new System.Windows.Forms.Timer(this.components);
            this.ChildFollowsParent = new System.Windows.Forms.Timer(this.components);
            this.ButtonOptionsStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlertIcon)).BeginInit();
            this.SubtitlePanel.SuspendLayout();
            this.OutlineContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoExit
            // 
            this.AutoExit.Interval = 300000;
            this.AutoExit.Tick += new System.EventHandler(this.AutoExit_Tick);
            // 
            // EnsureTopWindow
            // 
            this.EnsureTopWindow.Enabled = true;
            this.EnsureTopWindow.Interval = 1000;
            this.EnsureTopWindow.Tick += new System.EventHandler(this.EnsureTopWindow_Tick);
            // 
            // FlashTaskbarStatus
            // 
            this.FlashTaskbarStatus.Interval = 500;
            this.FlashTaskbarStatus.Tick += new System.EventHandler(this.FlashTaskbarStatus_Tick);
            // 
            // FadeInAnimation
            // 
            this.FadeInAnimation.Interval = 3;
            this.FadeInAnimation.Tick += new System.EventHandler(this.FadeInAnimation_Tick);
            // 
            // FadeOutAnimation
            // 
            this.FadeOutAnimation.Interval = 3;
            this.FadeOutAnimation.Tick += new System.EventHandler(this.FadeOutAnimation_Tick);
            // 
            // InfoTip
            // 
            this.InfoTip.AutomaticDelay = 250;
            this.InfoTip.AutoPopDelay = 15000;
            this.InfoTip.BackColor = System.Drawing.Color.White;
            this.InfoTip.ForeColor = System.Drawing.Color.Black;
            this.InfoTip.InitialDelay = 250;
            this.InfoTip.IsBalloon = true;
            this.InfoTip.ReshowDelay = 50;
            this.InfoTip.ToolTipTitle = "What does this do?";
            // 
            // SpeakerButton
            // 
            this.SpeakerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SpeakerButton.BackColor = System.Drawing.Color.White;
            this.SpeakerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SpeakerButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.SpeakerButton.ForeColor = System.Drawing.Color.Black;
            this.SpeakerButton.Location = new System.Drawing.Point(557, 328);
            this.SpeakerButton.Name = "SpeakerButton";
            this.SpeakerButton.Size = new System.Drawing.Size(35, 35);
            this.SpeakerButton.TabIndex = 1;
            this.SpeakerButton.Text = "🔊";
            this.InfoTip.SetToolTip(this.SpeakerButton, "Uses text to speech to read the text out loud.");
            this.SpeakerButton.UseVisualStyleBackColor = false;
            this.SpeakerButton.Click += new System.EventHandler(this.SpeakerButton_Click);
            // 
            // DismissButton
            // 
            this.DismissButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DismissButton.BackColor = System.Drawing.Color.White;
            this.DismissButton.ContextMenuStrip = this.ButtonOptionsStrip;
            this.DismissButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DismissButton.Font = new System.Drawing.Font("Arial", 16F);
            this.DismissButton.ForeColor = System.Drawing.Color.Black;
            this.DismissButton.Location = new System.Drawing.Point(598, 328);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(115, 35);
            this.DismissButton.TabIndex = 0;
            this.DismissButton.Text = "Dismiss";
            this.InfoTip.SetToolTip(this.DismissButton, "Closes the alert.");
            this.DismissButton.UseVisualStyleBackColor = false;
            this.DismissButton.Click += new System.EventHandler(this.DismissButton_Click);
            // 
            // ButtonOptionsStrip
            // 
            this.ButtonOptionsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dismissAllAlertsFor30SecondsToolStripMenuItem});
            this.ButtonOptionsStrip.Name = "ButtonOptionsStrip";
            this.ButtonOptionsStrip.Size = new System.Drawing.Size(216, 26);
            // 
            // dismissAllAlertsFor30SecondsToolStripMenuItem
            // 
            this.dismissAllAlertsFor30SecondsToolStripMenuItem.Name = "dismissAllAlertsFor30SecondsToolStripMenuItem";
            this.dismissAllAlertsFor30SecondsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.dismissAllAlertsFor30SecondsToolStripMenuItem.Text = "Pause alerts for 30 seconds";
            this.dismissAllAlertsFor30SecondsToolStripMenuItem.Click += new System.EventHandler(this.DismissAllAlertsFor30SecondsToolStripMenuItem_Click);
            // 
            // AlertIcon
            // 
            this.AlertIcon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertIcon.BackColor = System.Drawing.Color.Red;
            this.AlertIcon.Image = global::SharpAlert.Properties.Resources.WarningApp;
            this.AlertIcon.Location = new System.Drawing.Point(665, 4);
            this.AlertIcon.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.AlertIcon.Name = "AlertIcon";
            this.AlertIcon.Size = new System.Drawing.Size(48, 48);
            this.AlertIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AlertIcon.TabIndex = 2;
            this.AlertIcon.TabStop = false;
            this.AlertIcon.Click += new System.EventHandler(this.AlertIcon_Click);
            this.AlertIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AlertIcon_MouseDown);
            // 
            // SubtitlePanel
            // 
            this.SubtitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SubtitlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubtitlePanel.Controls.Add(this.SubtitleText);
            this.SubtitlePanel.Controls.Add(this.SubtitleSpacer);
            this.SubtitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubtitlePanel.ForeColor = System.Drawing.Color.White;
            this.SubtitlePanel.Location = new System.Drawing.Point(4, 54);
            this.SubtitlePanel.Margin = new System.Windows.Forms.Padding(10);
            this.SubtitlePanel.Name = "SubtitlePanel";
            this.SubtitlePanel.Size = new System.Drawing.Size(712, 32);
            this.SubtitlePanel.TabIndex = 7;
            // 
            // SubtitleText
            // 
            this.SubtitleText.BackColor = System.Drawing.Color.Transparent;
            this.SubtitleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubtitleText.Font = new System.Drawing.Font("Arial", 18F);
            this.SubtitleText.Location = new System.Drawing.Point(8, 0);
            this.SubtitleText.Name = "SubtitleText";
            this.SubtitleText.Size = new System.Drawing.Size(704, 32);
            this.SubtitleText.TabIndex = 3;
            this.SubtitleText.Text = "Short Alert Description";
            this.SubtitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SubtitleText.DoubleClick += new System.EventHandler(this.SubtitleText_DoubleClick);
            // 
            // SubtitleSpacer
            // 
            this.SubtitleSpacer.BackColor = System.Drawing.Color.Transparent;
            this.SubtitleSpacer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubtitleSpacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.SubtitleSpacer.ForeColor = System.Drawing.Color.White;
            this.SubtitleSpacer.Location = new System.Drawing.Point(0, 0);
            this.SubtitleSpacer.Margin = new System.Windows.Forms.Padding(10);
            this.SubtitleSpacer.Name = "SubtitleSpacer";
            this.SubtitleSpacer.Size = new System.Drawing.Size(8, 32);
            this.SubtitleSpacer.TabIndex = 2;
            // 
            // OutlineContainerPanel
            // 
            this.OutlineContainerPanel.BorderColor = System.Drawing.Color.Red;
            this.OutlineContainerPanel.BorderThickness = 4;
            this.OutlineContainerPanel.Controls.Add(this.DismissButton);
            this.OutlineContainerPanel.Controls.Add(this.SpeakerButton);
            this.OutlineContainerPanel.Controls.Add(this.AlertLinkText);
            this.OutlineContainerPanel.Controls.Add(this.AlertIcon);
            this.OutlineContainerPanel.Controls.Add(this.AlertText);
            this.OutlineContainerPanel.Controls.Add(this.SubtitlePanel);
            this.OutlineContainerPanel.Controls.Add(this.TitleText);
            this.OutlineContainerPanel.Controls.Add(this.ResizeBottomRight);
            this.OutlineContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutlineContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.OutlineContainerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OutlineContainerPanel.Name = "OutlineContainerPanel";
            this.OutlineContainerPanel.Padding = new System.Windows.Forms.Padding(4);
            this.OutlineContainerPanel.Size = new System.Drawing.Size(720, 370);
            this.OutlineContainerPanel.TabIndex = 12;
            this.OutlineContainerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.OutlineContainerPanel_Paint);
            // 
            // AlertLinkText
            // 
            this.AlertLinkText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertLinkText.BackColor = System.Drawing.Color.Transparent;
            this.AlertLinkText.Font = new System.Drawing.Font("Arial", 12F);
            this.AlertLinkText.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(127)))), ((int)(((byte)(255)))));
            this.AlertLinkText.Location = new System.Drawing.Point(9, 328);
            this.AlertLinkText.Margin = new System.Windows.Forms.Padding(0);
            this.AlertLinkText.Name = "AlertLinkText";
            this.AlertLinkText.Size = new System.Drawing.Size(545, 35);
            this.AlertLinkText.TabIndex = 11;
            this.AlertLinkText.TabStop = true;
            this.AlertLinkText.Text = "https://bunnytub.com/SharpAlert";
            this.AlertLinkText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AlertLinkText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AlertLinkText_LinkClicked);
            // 
            // AlertText
            // 
            this.AlertText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertText.BackColor = System.Drawing.Color.Black;
            this.AlertText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AlertText.Font = new System.Drawing.Font("Arial", 18F);
            this.AlertText.ForeColor = System.Drawing.Color.White;
            this.AlertText.Location = new System.Drawing.Point(4, 85);
            this.AlertText.Multiline = true;
            this.AlertText.Name = "AlertText";
            this.AlertText.ReadOnly = true;
            this.AlertText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AlertText.Size = new System.Drawing.Size(711, 241);
            this.AlertText.TabIndex = 8;
            // 
            // TitleText
            // 
            this.TitleText.BackColor = System.Drawing.Color.Red;
            this.TitleText.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleText.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.TitleText.Location = new System.Drawing.Point(4, 4);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(712, 50);
            this.TitleText.TabIndex = 9;
            this.TitleText.Text = "EMERGENCY ALERT";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleText_MouseDown);
            // 
            // ResizeBottomRight
            // 
            this.ResizeBottomRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ResizeBottomRight.BackColor = System.Drawing.Color.Transparent;
            this.ResizeBottomRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.ResizeBottomRight.Location = new System.Drawing.Point(704, 354);
            this.ResizeBottomRight.Name = "ResizeBottomRight";
            this.ResizeBottomRight.Size = new System.Drawing.Size(16, 16);
            this.ResizeBottomRight.TabIndex = 10;
            this.ResizeBottomRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ResizableThingPanel_MouseDown);
            this.ResizeBottomRight.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ResizableThingPanel_MouseMove);
            this.ResizeBottomRight.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ResizableThingPanel_MouseUp);
            // 
            // WindowFlash
            // 
            this.WindowFlash.Interval = 1000;
            this.WindowFlash.Tick += new System.EventHandler(this.WindowFlash_Tick);
            // 
            // TerminateSelf
            // 
            this.TerminateSelf.Enabled = true;
            this.TerminateSelf.Interval = 500;
            this.TerminateSelf.Tick += new System.EventHandler(this.TerminateSelf_Tick);
            // 
            // ChildFollowsParent
            // 
            this.ChildFollowsParent.Enabled = true;
            this.ChildFollowsParent.Interval = 75;
            this.ChildFollowsParent.Tick += new System.EventHandler(this.ChildFollowsParent_Tick);
            // 
            // AlertForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(720, 370);
            this.ControlBox = false;
            this.Controls.Add(this.OutlineContainerPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(720, 370);
            this.Name = "AlertForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SharpAlert - Alert Panel";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AlertForm_FormClosed);
            this.Load += new System.EventHandler(this.AlertForm_Load);
            this.Shown += new System.EventHandler(this.AlertForm_Shown);
            this.ButtonOptionsStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlertIcon)).EndInit();
            this.SubtitlePanel.ResumeLayout(false);
            this.OutlineContainerPanel.ResumeLayout(false);
            this.OutlineContainerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer AutoExit;
        private System.Windows.Forms.Timer EnsureTopWindow;
        private System.Windows.Forms.Timer FlashTaskbarStatus;
        private System.Windows.Forms.Timer FadeInAnimation;
        private System.Windows.Forms.Timer FadeOutAnimation;
        private System.Windows.Forms.ToolTip InfoTip;
        private System.Windows.Forms.PictureBox AlertIcon;
        private System.Windows.Forms.Panel SubtitlePanel;
        private System.Windows.Forms.Label SubtitleText;
        private System.Windows.Forms.Panel SubtitleSpacer;
        private WinFormsControls.ToolboxStuff.BorderPanel OutlineContainerPanel;
        private System.Windows.Forms.TextBox AlertText;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Timer WindowFlash;
        private System.Windows.Forms.Timer TerminateSelf;
        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.Button SpeakerButton;
        private System.Windows.Forms.Panel ResizeBottomRight;
        private System.Windows.Forms.LinkLabel AlertLinkText;
        private System.Windows.Forms.Timer ChildFollowsParent;
        private System.Windows.Forms.ContextMenuStrip ButtonOptionsStrip;
        private System.Windows.Forms.ToolStripMenuItem dismissAllAlertsFor30SecondsToolStripMenuItem;
    }
}


