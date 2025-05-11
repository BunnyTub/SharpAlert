namespace SharpAlert
{
    partial class MiniAlertForm
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
            this.AutoTTS = new System.Windows.Forms.Timer(this.components);
            this.FadeInAnimation = new System.Windows.Forms.Timer(this.components);
            this.FadeOutAnimation = new System.Windows.Forms.Timer(this.components);
            this.InfoTip = new System.Windows.Forms.ToolTip(this.components);
            this.DismissButton = new System.Windows.Forms.Button();
            this.LinkButton = new System.Windows.Forms.Button();
            this.SpeakerButton = new System.Windows.Forms.Button();
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.TitleText = new System.Windows.Forms.Label();
            this.SubtitlePanel = new System.Windows.Forms.Panel();
            this.AlertText = new SharpAlert.ToolboxStuff.MarqueeLabel();
            this.OutlineContainerPanel = new SharpAlert.ToolboxStuff.BorderPanel();
            this.TerminateSelf = new System.Windows.Forms.Timer(this.components);
            this.TitlePanel.SuspendLayout();
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
            // AutoTTS
            // 
            this.AutoTTS.Interval = 8000;
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
            // DismissButton
            // 
            this.DismissButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DismissButton.BackColor = System.Drawing.Color.White;
            this.DismissButton.Enabled = false;
            this.DismissButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DismissButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.DismissButton.ForeColor = System.Drawing.Color.Black;
            this.DismissButton.Location = new System.Drawing.Point(412, 2);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(35, 35);
            this.DismissButton.TabIndex = 0;
            this.DismissButton.Text = "❌";
            this.InfoTip.SetToolTip(this.DismissButton, "Closes the alert.");
            this.DismissButton.UseVisualStyleBackColor = false;
            this.DismissButton.Click += new System.EventHandler(this.DismissButton_Click);
            // 
            // LinkButton
            // 
            this.LinkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkButton.BackColor = System.Drawing.Color.White;
            this.LinkButton.Enabled = false;
            this.LinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LinkButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.LinkButton.ForeColor = System.Drawing.Color.Black;
            this.LinkButton.Location = new System.Drawing.Point(330, 2);
            this.LinkButton.Name = "LinkButton";
            this.LinkButton.Size = new System.Drawing.Size(35, 35);
            this.LinkButton.TabIndex = 2;
            this.LinkButton.Text = "🔗";
            this.InfoTip.SetToolTip(this.LinkButton, "Opens the alert URL if there is one included.");
            this.LinkButton.UseVisualStyleBackColor = false;
            this.LinkButton.Click += new System.EventHandler(this.LinkButton_Click);
            // 
            // SpeakerButton
            // 
            this.SpeakerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SpeakerButton.BackColor = System.Drawing.Color.White;
            this.SpeakerButton.Enabled = false;
            this.SpeakerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SpeakerButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.SpeakerButton.ForeColor = System.Drawing.Color.Black;
            this.SpeakerButton.Location = new System.Drawing.Point(371, 2);
            this.SpeakerButton.Name = "SpeakerButton";
            this.SpeakerButton.Size = new System.Drawing.Size(35, 35);
            this.SpeakerButton.TabIndex = 1;
            this.SpeakerButton.Text = "🔊";
            this.InfoTip.SetToolTip(this.SpeakerButton, "Uses text to speech to read the text out loud.");
            this.SpeakerButton.UseVisualStyleBackColor = false;
            this.SpeakerButton.Click += new System.EventHandler(this.SpeakerButton_Click);
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.Red;
            this.TitlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TitlePanel.Controls.Add(this.SpeakerButton);
            this.TitlePanel.Controls.Add(this.LinkButton);
            this.TitlePanel.Controls.Add(this.DismissButton);
            this.TitlePanel.Controls.Add(this.TitleText);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.ForeColor = System.Drawing.Color.White;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Margin = new System.Windows.Forms.Padding(10);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(450, 40);
            this.TitlePanel.TabIndex = 1;
            // 
            // TitleText
            // 
            this.TitleText.BackColor = System.Drawing.Color.Transparent;
            this.TitleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleText.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            this.TitleText.Location = new System.Drawing.Point(0, 0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(450, 40);
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "EMERGENCY ALERT";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.TitleText.Click += new System.EventHandler(this.TitleText_Click);
            this.TitleText.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TitleText_MouseDown);
            // 
            // SubtitlePanel
            // 
            this.SubtitlePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SubtitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SubtitlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubtitlePanel.Controls.Add(this.AlertText);
            this.SubtitlePanel.ForeColor = System.Drawing.Color.White;
            this.SubtitlePanel.Location = new System.Drawing.Point(4, 40);
            this.SubtitlePanel.Margin = new System.Windows.Forms.Padding(4);
            this.SubtitlePanel.Name = "SubtitlePanel";
            this.SubtitlePanel.Size = new System.Drawing.Size(442, 32);
            this.SubtitlePanel.TabIndex = 7;
            // 
            // AlertText
            // 
            this.AlertText.BackColor = System.Drawing.Color.Transparent;
            this.AlertText.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AlertText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlertText.Font = new System.Drawing.Font("Arial", 18F);
            this.AlertText.Location = new System.Drawing.Point(0, 0);
            this.AlertText.Name = "AlertText";
            this.AlertText.ScrollSpeed = 3F;
            this.AlertText.Size = new System.Drawing.Size(442, 32);
            this.AlertText.TabIndex = 3;
            this.AlertText.Text = "Short Alert Description";
            this.AlertText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AlertText.Click += new System.EventHandler(this.AlertText_Click);
            // 
            // OutlineContainerPanel
            // 
            this.OutlineContainerPanel.BorderColor = System.Drawing.Color.Red;
            this.OutlineContainerPanel.BorderThickness = 4;
            this.OutlineContainerPanel.Controls.Add(this.SubtitlePanel);
            this.OutlineContainerPanel.Controls.Add(this.TitlePanel);
            this.OutlineContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutlineContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.OutlineContainerPanel.Margin = new System.Windows.Forms.Padding(0);
            this.OutlineContainerPanel.Name = "OutlineContainerPanel";
            this.OutlineContainerPanel.Size = new System.Drawing.Size(450, 76);
            this.OutlineContainerPanel.TabIndex = 8;
            // 
            // TerminateSelf
            // 
            this.TerminateSelf.Enabled = true;
            this.TerminateSelf.Interval = 500;
            this.TerminateSelf.Tick += new System.EventHandler(this.TerminateSelf_Tick);
            // 
            // MiniAlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(450, 76);
            this.ControlBox = false;
            this.Controls.Add(this.OutlineContainerPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MiniAlertForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SharpAlert - Alert Dialog";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AlertForm_FormClosed);
            this.Load += new System.EventHandler(this.AlertForm_Load);
            this.Shown += new System.EventHandler(this.AlertForm_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MiniAlertForm_Paint);
            this.TitlePanel.ResumeLayout(false);
            this.SubtitlePanel.ResumeLayout(false);
            this.OutlineContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer AutoExit;
        private System.Windows.Forms.Timer EnsureTopWindow;
        private System.Windows.Forms.Timer FlashTaskbarStatus;
        private System.Windows.Forms.Timer AutoTTS;
        private System.Windows.Forms.Timer FadeInAnimation;
        private System.Windows.Forms.Timer FadeOutAnimation;
        private System.Windows.Forms.ToolTip InfoTip;
        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Button SpeakerButton;
        private System.Windows.Forms.Button LinkButton;
        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Panel SubtitlePanel;
        private ToolboxStuff.MarqueeLabel AlertText;
        private ToolboxStuff.BorderPanel OutlineContainerPanel;
        private System.Windows.Forms.Timer TerminateSelf;
    }
}

