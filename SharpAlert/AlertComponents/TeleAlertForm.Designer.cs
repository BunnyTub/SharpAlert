namespace SharpAlert
{
    partial class TeleAlertForm
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
            this.AlertPanel = new System.Windows.Forms.Panel();
            this.AlertText = new System.Windows.Forms.TextBox();
            this.FlashTaskbarStatus = new System.Windows.Forms.Timer(this.components);
            this.AutoTTS = new System.Windows.Forms.Timer(this.components);
            this.FadeInAnimation = new System.Windows.Forms.Timer(this.components);
            this.FadeOutAnimation = new System.Windows.Forms.Timer(this.components);
            this.MouseMoving = new System.Windows.Forms.Timer(this.components);
            this.AutoScroller = new System.Windows.Forms.Timer(this.components);
            this.MainPanel = new System.Windows.Forms.Panel();
            this.AutoHideButtons = new System.Windows.Forms.Timer(this.components);
            this.InfoTip = new System.Windows.Forms.ToolTip(this.components);
            this.ScreenshotButton = new System.Windows.Forms.Button();
            this.DismissButton = new System.Windows.Forms.Button();
            this.LinkButton = new System.Windows.Forms.Button();
            this.TerminateSelf = new System.Windows.Forms.Timer(this.components);
            this.OutlineContainerPanel = new System.Windows.Forms.Panel();
            this.TitleText = new System.Windows.Forms.Label();
            this.RightOutlinePanel = new System.Windows.Forms.Panel();
            this.LeftOutlinePanel = new System.Windows.Forms.Panel();
            this.BottomOutlinePanel = new System.Windows.Forms.Panel();
            this.WindowFlash = new System.Windows.Forms.Timer(this.components);
            this.EnsureTopWindow = new System.Windows.Forms.Timer(this.components);
            this.RightSubtitleSpacer = new System.Windows.Forms.Panel();
            this.LeftSubtitleSpacer = new System.Windows.Forms.Panel();
            this.SubtitleText = new System.Windows.Forms.Label();
            this.SubtitlePanel = new System.Windows.Forms.Panel();
            this.AlertPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.OutlineContainerPanel.SuspendLayout();
            this.SubtitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoExit
            // 
            this.AutoExit.Interval = 300000;
            this.AutoExit.Tick += new System.EventHandler(this.AutoExit_Tick);
            // 
            // AlertPanel
            // 
            this.AlertPanel.BackColor = System.Drawing.Color.Black;
            this.AlertPanel.Controls.Add(this.AlertText);
            this.AlertPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlertPanel.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.AlertPanel.Location = new System.Drawing.Point(0, 0);
            this.AlertPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AlertPanel.Name = "AlertPanel";
            this.AlertPanel.Size = new System.Drawing.Size(1264, 559);
            this.AlertPanel.TabIndex = 5;
            // 
            // AlertText
            // 
            this.AlertText.BackColor = System.Drawing.Color.Black;
            this.AlertText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AlertText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlertText.Font = new System.Drawing.Font("Arial", 34F);
            this.AlertText.ForeColor = System.Drawing.Color.White;
            this.AlertText.HideSelection = false;
            this.AlertText.Location = new System.Drawing.Point(0, 0);
            this.AlertText.Multiline = true;
            this.AlertText.Name = "AlertText";
            this.AlertText.ReadOnly = true;
            this.AlertText.Size = new System.Drawing.Size(1264, 559);
            this.AlertText.TabIndex = 3;
            this.AlertText.TextChanged += new System.EventHandler(this.AlertText_TextChanged);
            this.AlertText.DoubleClick += new System.EventHandler(this.AlertText_DoubleClick);
            this.AlertText.Enter += new System.EventHandler(this.AlertText_Enter);
            // 
            // FlashTaskbarStatus
            // 
            this.FlashTaskbarStatus.Interval = 500;
            this.FlashTaskbarStatus.Tick += new System.EventHandler(this.FlashTaskbarStatus_Tick);
            // 
            // AutoTTS
            // 
            this.AutoTTS.Interval = 50;
            this.AutoTTS.Tick += new System.EventHandler(this.AutoTTS_Tick);
            // 
            // FadeInAnimation
            // 
            this.FadeInAnimation.Interval = 6;
            this.FadeInAnimation.Tick += new System.EventHandler(this.FadeInAnimation_Tick);
            // 
            // FadeOutAnimation
            // 
            this.FadeOutAnimation.Interval = 6;
            this.FadeOutAnimation.Tick += new System.EventHandler(this.FadeOutAnimation_Tick);
            // 
            // MouseMoving
            // 
            this.MouseMoving.Tick += new System.EventHandler(this.MouseMoving_Tick);
            // 
            // AutoScroller
            // 
            this.AutoScroller.Interval = 50;
            this.AutoScroller.Tick += new System.EventHandler(this.AutoScroll_Tick);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.AlertPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(8, 153);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1264, 559);
            this.MainPanel.TabIndex = 9;
            // 
            // AutoHideButtons
            // 
            this.AutoHideButtons.Interval = 10000;
            this.AutoHideButtons.Tick += new System.EventHandler(this.AutoHideButtons_Tick);
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
            // ScreenshotButton
            // 
            this.ScreenshotButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScreenshotButton.BackColor = System.Drawing.Color.White;
            this.ScreenshotButton.Enabled = false;
            this.ScreenshotButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ScreenshotButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.ScreenshotButton.ForeColor = System.Drawing.Color.Black;
            this.ScreenshotButton.Location = new System.Drawing.Point(1192, 3);
            this.ScreenshotButton.Name = "ScreenshotButton";
            this.ScreenshotButton.Size = new System.Drawing.Size(35, 35);
            this.ScreenshotButton.TabIndex = 12;
            this.ScreenshotButton.Text = "📸";
            this.InfoTip.SetToolTip(this.ScreenshotButton, "Takes a screenshot of the alert window, and saves the image to the disk.");
            this.ScreenshotButton.UseVisualStyleBackColor = false;
            this.ScreenshotButton.Visible = false;
            this.ScreenshotButton.Click += new System.EventHandler(this.ScreenshotButton_Click);
            // 
            // DismissButton
            // 
            this.DismissButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DismissButton.BackColor = System.Drawing.Color.White;
            this.DismissButton.Enabled = false;
            this.DismissButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DismissButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.DismissButton.ForeColor = System.Drawing.Color.Black;
            this.DismissButton.Location = new System.Drawing.Point(1233, 3);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(35, 35);
            this.DismissButton.TabIndex = 11;
            this.DismissButton.Text = "✖";
            this.InfoTip.SetToolTip(this.DismissButton, "Closes the alert.");
            this.DismissButton.UseVisualStyleBackColor = false;
            this.DismissButton.Visible = false;
            this.DismissButton.Click += new System.EventHandler(this.DismissButton_Click);
            // 
            // LinkButton
            // 
            this.LinkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkButton.BackColor = System.Drawing.Color.White;
            this.LinkButton.Enabled = false;
            this.LinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LinkButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.LinkButton.ForeColor = System.Drawing.Color.Black;
            this.LinkButton.Location = new System.Drawing.Point(1151, 3);
            this.LinkButton.Name = "LinkButton";
            this.LinkButton.Size = new System.Drawing.Size(35, 35);
            this.LinkButton.TabIndex = 13;
            this.LinkButton.Text = "🔗";
            this.InfoTip.SetToolTip(this.LinkButton, "Opens the alert URL if there is one included.");
            this.LinkButton.UseVisualStyleBackColor = false;
            this.LinkButton.Visible = false;
            this.LinkButton.Click += new System.EventHandler(this.LinkButton_Click);
            // 
            // TerminateSelf
            // 
            this.TerminateSelf.Enabled = true;
            this.TerminateSelf.Interval = 500;
            this.TerminateSelf.Tick += new System.EventHandler(this.TerminateSelf_Tick);
            // 
            // OutlineContainerPanel
            // 
            this.OutlineContainerPanel.Controls.Add(this.MainPanel);
            this.OutlineContainerPanel.Controls.Add(this.ScreenshotButton);
            this.OutlineContainerPanel.Controls.Add(this.DismissButton);
            this.OutlineContainerPanel.Controls.Add(this.LinkButton);
            this.OutlineContainerPanel.Controls.Add(this.SubtitlePanel);
            this.OutlineContainerPanel.Controls.Add(this.TitleText);
            this.OutlineContainerPanel.Controls.Add(this.RightOutlinePanel);
            this.OutlineContainerPanel.Controls.Add(this.LeftOutlinePanel);
            this.OutlineContainerPanel.Controls.Add(this.BottomOutlinePanel);
            this.OutlineContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutlineContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.OutlineContainerPanel.Name = "OutlineContainerPanel";
            this.OutlineContainerPanel.Size = new System.Drawing.Size(1280, 720);
            this.OutlineContainerPanel.TabIndex = 10;
            // 
            // TitleText
            // 
            this.TitleText.BackColor = System.Drawing.Color.Red;
            this.TitleText.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleText.Font = new System.Drawing.Font("Arial", 56F, System.Drawing.FontStyle.Bold);
            this.TitleText.Location = new System.Drawing.Point(8, 0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(1264, 90);
            this.TitleText.TabIndex = 15;
            this.TitleText.Text = "EMERGENCY ALERT";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RightOutlinePanel
            // 
            this.RightOutlinePanel.BackColor = System.Drawing.Color.Red;
            this.RightOutlinePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RightOutlinePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightOutlinePanel.ForeColor = System.Drawing.Color.White;
            this.RightOutlinePanel.Location = new System.Drawing.Point(1272, 0);
            this.RightOutlinePanel.Margin = new System.Windows.Forms.Padding(10);
            this.RightOutlinePanel.Name = "RightOutlinePanel";
            this.RightOutlinePanel.Size = new System.Drawing.Size(8, 712);
            this.RightOutlinePanel.TabIndex = 17;
            // 
            // LeftOutlinePanel
            // 
            this.LeftOutlinePanel.BackColor = System.Drawing.Color.Red;
            this.LeftOutlinePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LeftOutlinePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftOutlinePanel.ForeColor = System.Drawing.Color.White;
            this.LeftOutlinePanel.Location = new System.Drawing.Point(0, 0);
            this.LeftOutlinePanel.Margin = new System.Windows.Forms.Padding(10);
            this.LeftOutlinePanel.Name = "LeftOutlinePanel";
            this.LeftOutlinePanel.Size = new System.Drawing.Size(8, 712);
            this.LeftOutlinePanel.TabIndex = 16;
            // 
            // BottomOutlinePanel
            // 
            this.BottomOutlinePanel.BackColor = System.Drawing.Color.Red;
            this.BottomOutlinePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BottomOutlinePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomOutlinePanel.ForeColor = System.Drawing.Color.White;
            this.BottomOutlinePanel.Location = new System.Drawing.Point(0, 712);
            this.BottomOutlinePanel.Margin = new System.Windows.Forms.Padding(10);
            this.BottomOutlinePanel.Name = "BottomOutlinePanel";
            this.BottomOutlinePanel.Size = new System.Drawing.Size(1280, 8);
            this.BottomOutlinePanel.TabIndex = 18;
            // 
            // WindowFlash
            // 
            this.WindowFlash.Interval = 1000;
            this.WindowFlash.Tick += new System.EventHandler(this.WindowFlash_Tick);
            // 
            // EnsureTopWindow
            // 
            this.EnsureTopWindow.Enabled = true;
            this.EnsureTopWindow.Interval = 1000;
            this.EnsureTopWindow.Tick += new System.EventHandler(this.EnsureTopWindow_Tick);
            // 
            // RightSubtitleSpacer
            // 
            this.RightSubtitleSpacer.BackColor = System.Drawing.Color.Transparent;
            this.RightSubtitleSpacer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RightSubtitleSpacer.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightSubtitleSpacer.ForeColor = System.Drawing.Color.White;
            this.RightSubtitleSpacer.Location = new System.Drawing.Point(1256, 0);
            this.RightSubtitleSpacer.Margin = new System.Windows.Forms.Padding(10);
            this.RightSubtitleSpacer.Name = "RightSubtitleSpacer";
            this.RightSubtitleSpacer.Size = new System.Drawing.Size(8, 63);
            this.RightSubtitleSpacer.TabIndex = 4;
            // 
            // LeftSubtitleSpacer
            // 
            this.LeftSubtitleSpacer.BackColor = System.Drawing.Color.Transparent;
            this.LeftSubtitleSpacer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LeftSubtitleSpacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftSubtitleSpacer.ForeColor = System.Drawing.Color.White;
            this.LeftSubtitleSpacer.Location = new System.Drawing.Point(0, 0);
            this.LeftSubtitleSpacer.Margin = new System.Windows.Forms.Padding(10);
            this.LeftSubtitleSpacer.Name = "LeftSubtitleSpacer";
            this.LeftSubtitleSpacer.Size = new System.Drawing.Size(8, 63);
            this.LeftSubtitleSpacer.TabIndex = 2;
            // 
            // SubtitleText
            // 
            this.SubtitleText.BackColor = System.Drawing.Color.Transparent;
            this.SubtitleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubtitleText.Font = new System.Drawing.Font("Arial", 36F);
            this.SubtitleText.Location = new System.Drawing.Point(8, 0);
            this.SubtitleText.Name = "SubtitleText";
            this.SubtitleText.Size = new System.Drawing.Size(1248, 63);
            this.SubtitleText.TabIndex = 3;
            this.SubtitleText.Text = "Short Alert Description";
            this.SubtitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SubtitlePanel
            // 
            this.SubtitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SubtitlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubtitlePanel.Controls.Add(this.SubtitleText);
            this.SubtitlePanel.Controls.Add(this.LeftSubtitleSpacer);
            this.SubtitlePanel.Controls.Add(this.RightSubtitleSpacer);
            this.SubtitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubtitlePanel.ForeColor = System.Drawing.Color.White;
            this.SubtitlePanel.Location = new System.Drawing.Point(8, 90);
            this.SubtitlePanel.Margin = new System.Windows.Forms.Padding(10);
            this.SubtitlePanel.Name = "SubtitlePanel";
            this.SubtitlePanel.Size = new System.Drawing.Size(1264, 63);
            this.SubtitlePanel.TabIndex = 14;
            // 
            // TeleAlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.ControlBox = false;
            this.Controls.Add(this.OutlineContainerPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeleAlertForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SharpAlert - Alert Panel";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AlertForm_FormClosed);
            this.Load += new System.EventHandler(this.AlertForm_Load);
            this.Shown += new System.EventHandler(this.AlertForm_Shown);
            this.AlertPanel.ResumeLayout(false);
            this.AlertPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.OutlineContainerPanel.ResumeLayout(false);
            this.SubtitlePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer AutoExit;
        private System.Windows.Forms.Panel AlertPanel;
        private System.Windows.Forms.TextBox AlertText;
        private System.Windows.Forms.Timer FlashTaskbarStatus;
        private System.Windows.Forms.Timer AutoTTS;
        private System.Windows.Forms.Timer FadeInAnimation;
        private System.Windows.Forms.Timer FadeOutAnimation;
        private System.Windows.Forms.Timer MouseMoving;
        private System.Windows.Forms.Timer AutoScroller;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Timer AutoHideButtons;
        private System.Windows.Forms.ToolTip InfoTip;
        private System.Windows.Forms.Timer TerminateSelf;
        private System.Windows.Forms.Panel OutlineContainerPanel;
        private System.Windows.Forms.Button ScreenshotButton;
        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.Button LinkButton;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Panel BottomOutlinePanel;
        private System.Windows.Forms.Panel RightOutlinePanel;
        private System.Windows.Forms.Panel LeftOutlinePanel;
        private System.Windows.Forms.Timer WindowFlash;
        private System.Windows.Forms.Timer EnsureTopWindow;
        private System.Windows.Forms.Panel SubtitlePanel;
        private System.Windows.Forms.Label SubtitleText;
        private System.Windows.Forms.Panel LeftSubtitleSpacer;
        private System.Windows.Forms.Panel RightSubtitleSpacer;
    }
}

