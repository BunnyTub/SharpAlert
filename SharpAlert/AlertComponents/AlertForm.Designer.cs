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
            components = new System.ComponentModel.Container();
            AutoExit = new System.Windows.Forms.Timer(components);
            EnsureTopWindow = new System.Windows.Forms.Timer(components);
            FlashTaskbarStatus = new System.Windows.Forms.Timer(components);
            FadeInAnimation = new System.Windows.Forms.Timer(components);
            FadeOutAnimation = new System.Windows.Forms.Timer(components);
            InfoTip = new System.Windows.Forms.ToolTip(components);
            SpeakerButton = new System.Windows.Forms.Button();
            DismissButton = new System.Windows.Forms.Button();
            ButtonOptionsStrip = new System.Windows.Forms.ContextMenuStrip(components);
            dismissAllAlertsFor30SecondsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            AlertIcon = new System.Windows.Forms.PictureBox();
            SubtitlePanel = new System.Windows.Forms.Panel();
            SubtitleText = new System.Windows.Forms.Label();
            SubtitleSpacer = new System.Windows.Forms.Panel();
            OutlineContainerPanel = new SharpAlert.WinFormsControls.ToolboxStuff.BorderPanel();
            AlertLinkText = new System.Windows.Forms.LinkLabel();
            AlertText = new System.Windows.Forms.TextBox();
            TitleText = new System.Windows.Forms.Label();
            ResizeBottomRight = new System.Windows.Forms.Panel();
            WindowFlash = new System.Windows.Forms.Timer(components);
            TerminateSelf = new System.Windows.Forms.Timer(components);
            ChildFollowsParent = new System.Windows.Forms.Timer(components);
            WindowFlashSmooth = new System.Windows.Forms.Timer(components);
            WindowShake = new System.Windows.Forms.Timer(components);
            ButtonOptionsStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AlertIcon).BeginInit();
            SubtitlePanel.SuspendLayout();
            OutlineContainerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AutoExit
            // 
            AutoExit.Interval = 300000;
            AutoExit.Tick += AutoExit_Tick;
            // 
            // EnsureTopWindow
            // 
            EnsureTopWindow.Enabled = true;
            EnsureTopWindow.Interval = 1000;
            EnsureTopWindow.Tick += EnsureTopWindow_Tick;
            // 
            // FlashTaskbarStatus
            // 
            FlashTaskbarStatus.Interval = 500;
            FlashTaskbarStatus.Tick += FlashTaskbarStatus_Tick;
            // 
            // FadeInAnimation
            // 
            FadeInAnimation.Interval = 3;
            FadeInAnimation.Tick += FadeInAnimation_Tick;
            // 
            // FadeOutAnimation
            // 
            FadeOutAnimation.Interval = 3;
            FadeOutAnimation.Tick += FadeOutAnimation_Tick;
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
            // SpeakerButton
            // 
            SpeakerButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            SpeakerButton.BackColor = System.Drawing.Color.White;
            SpeakerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SpeakerButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            SpeakerButton.ForeColor = System.Drawing.Color.Black;
            SpeakerButton.Location = new System.Drawing.Point(557, 328);
            SpeakerButton.Name = "SpeakerButton";
            SpeakerButton.Size = new System.Drawing.Size(35, 35);
            SpeakerButton.TabIndex = 1;
            SpeakerButton.Text = "🔊";
            InfoTip.SetToolTip(SpeakerButton, "Uses text to speech to read the text out loud.");
            SpeakerButton.UseVisualStyleBackColor = false;
            SpeakerButton.Click += SpeakerButton_Click;
            // 
            // DismissButton
            // 
            DismissButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DismissButton.BackColor = System.Drawing.Color.White;
            DismissButton.ContextMenuStrip = ButtonOptionsStrip;
            DismissButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DismissButton.Font = new System.Drawing.Font("Arial", 16F);
            DismissButton.ForeColor = System.Drawing.Color.Black;
            DismissButton.Location = new System.Drawing.Point(598, 328);
            DismissButton.Name = "DismissButton";
            DismissButton.Size = new System.Drawing.Size(115, 35);
            DismissButton.TabIndex = 0;
            DismissButton.Text = "Dismiss";
            InfoTip.SetToolTip(DismissButton, "Closes the alert.");
            DismissButton.UseVisualStyleBackColor = false;
            DismissButton.Click += DismissButton_Click;
            // 
            // ButtonOptionsStrip
            // 
            ButtonOptionsStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { dismissAllAlertsFor30SecondsToolStripMenuItem });
            ButtonOptionsStrip.Name = "ButtonOptionsStrip";
            ButtonOptionsStrip.Size = new System.Drawing.Size(216, 26);
            // 
            // dismissAllAlertsFor30SecondsToolStripMenuItem
            // 
            dismissAllAlertsFor30SecondsToolStripMenuItem.Name = "dismissAllAlertsFor30SecondsToolStripMenuItem";
            dismissAllAlertsFor30SecondsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            dismissAllAlertsFor30SecondsToolStripMenuItem.Text = "Pause alerts for 30 seconds";
            dismissAllAlertsFor30SecondsToolStripMenuItem.Click += DismissAllAlertsFor30SecondsToolStripMenuItem_Click;
            // 
            // AlertIcon
            // 
            AlertIcon.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AlertIcon.BackColor = System.Drawing.Color.Red;
            AlertIcon.Image = Properties.Resources.WarningApp;
            AlertIcon.Location = new System.Drawing.Point(665, 4);
            AlertIcon.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            AlertIcon.Name = "AlertIcon";
            AlertIcon.Size = new System.Drawing.Size(48, 48);
            AlertIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            AlertIcon.TabIndex = 2;
            AlertIcon.TabStop = false;
            AlertIcon.Click += AlertIcon_Click;
            AlertIcon.MouseDown += AlertIcon_MouseDown;
            // 
            // SubtitlePanel
            // 
            SubtitlePanel.BackColor = System.Drawing.Color.FromArgb(140, 0, 0);
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
            OutlineContainerPanel.BorderColor = System.Drawing.Color.Red;
            OutlineContainerPanel.BorderThickness = 4;
            OutlineContainerPanel.Controls.Add(DismissButton);
            OutlineContainerPanel.Controls.Add(SpeakerButton);
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
            OutlineContainerPanel.Size = new System.Drawing.Size(720, 370);
            OutlineContainerPanel.TabIndex = 12;
            OutlineContainerPanel.Paint += OutlineContainerPanel_Paint;
            // 
            // AlertLinkText
            // 
            AlertLinkText.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            AlertLinkText.BackColor = System.Drawing.Color.Transparent;
            AlertLinkText.Font = new System.Drawing.Font("Arial", 12F);
            AlertLinkText.LinkColor = System.Drawing.Color.FromArgb(0, 127, 255);
            AlertLinkText.Location = new System.Drawing.Point(9, 328);
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
            AlertText.Size = new System.Drawing.Size(711, 241);
            AlertText.TabIndex = 8;
            // 
            // TitleText
            // 
            TitleText.BackColor = System.Drawing.Color.Red;
            TitleText.Dock = System.Windows.Forms.DockStyle.Top;
            TitleText.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            TitleText.Location = new System.Drawing.Point(4, 4);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(712, 50);
            TitleText.TabIndex = 9;
            TitleText.Text = "EMERGENCY ALERT";
            TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            TitleText.MouseDown += TitleText_MouseDown;
            // 
            // ResizeBottomRight
            // 
            ResizeBottomRight.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ResizeBottomRight.BackColor = System.Drawing.Color.Transparent;
            ResizeBottomRight.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            ResizeBottomRight.Location = new System.Drawing.Point(716, 366);
            ResizeBottomRight.Name = "ResizeBottomRight";
            ResizeBottomRight.Size = new System.Drawing.Size(4, 4);
            ResizeBottomRight.TabIndex = 10;
            ResizeBottomRight.MouseDown += ResizableThingPanel_MouseDown;
            ResizeBottomRight.MouseMove += ResizableThingPanel_MouseMove;
            ResizeBottomRight.MouseUp += ResizableThingPanel_MouseUp;
            // 
            // WindowFlash
            // 
            WindowFlash.Interval = 1000;
            WindowFlash.Tick += WindowFlash_Tick;
            // 
            // TerminateSelf
            // 
            TerminateSelf.Enabled = true;
            TerminateSelf.Interval = 500;
            TerminateSelf.Tick += TerminateSelf_Tick;
            // 
            // ChildFollowsParent
            // 
            ChildFollowsParent.Enabled = true;
            ChildFollowsParent.Interval = 75;
            ChildFollowsParent.Tick += ChildFollowsParent_Tick;
            // 
            // WindowFlashSmooth
            // 
            WindowFlashSmooth.Interval = 60;
            WindowFlashSmooth.Tick += WindowFlashSmooth_Tick;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // AlertForm
            // 
            AcceptButton = DismissButton;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.Black;
            CancelButton = DismissButton;
            ClientSize = new System.Drawing.Size(720, 370);
            ControlBox = false;
            Controls.Add(OutlineContainerPanel);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Arial", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new System.Drawing.Size(720, 370);
            Name = "AlertForm";
            Opacity = 0D;
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "SharpAlert - Alert Panel";
            TopMost = true;
            FormClosing += AlertForm_FormClosing;
            FormClosed += AlertForm_FormClosed;
            Load += AlertForm_Load;
            Shown += AlertForm_Shown;
            ButtonOptionsStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)AlertIcon).EndInit();
            SubtitlePanel.ResumeLayout(false);
            OutlineContainerPanel.ResumeLayout(false);
            OutlineContainerPanel.PerformLayout();
            ResumeLayout(false);

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
        private System.Windows.Forms.Timer WindowFlashSmooth;
        private System.Windows.Forms.Timer WindowShake;
    }
}


