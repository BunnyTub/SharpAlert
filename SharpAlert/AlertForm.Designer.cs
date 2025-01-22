namespace SharpAlert
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
            this.TitlePanel = new System.Windows.Forms.Panel();
            this.TitleText = new System.Windows.Forms.Label();
            this.TitleSpacer = new System.Windows.Forms.Panel();
            this.AutoExit = new System.Windows.Forms.Timer(this.components);
            this.AlertPanel = new System.Windows.Forms.Panel();
            this.AlertText = new System.Windows.Forms.TextBox();
            this.DismissButton = new System.Windows.Forms.Button();
            this.SubtitlePanel = new System.Windows.Forms.Panel();
            this.SubtitleText = new System.Windows.Forms.Label();
            this.SubtitleSpacer = new System.Windows.Forms.Panel();
            this.SpeakerButton = new System.Windows.Forms.Button();
            this.EnsureTopWindow = new System.Windows.Forms.Timer(this.components);
            this.LinkButton = new System.Windows.Forms.Button();
            this.FlashTaskbarStatus = new System.Windows.Forms.Timer(this.components);
            this.AutoTTS = new System.Windows.Forms.Timer(this.components);
            this.FadeInAnimation = new System.Windows.Forms.Timer(this.components);
            this.FadeOutAnimation = new System.Windows.Forms.Timer(this.components);
            this.AlertIcon = new System.Windows.Forms.PictureBox();
            this.TitlePanel.SuspendLayout();
            this.AlertPanel.SuspendLayout();
            this.SubtitlePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AlertIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.Red;
            this.TitlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TitlePanel.Controls.Add(this.TitleText);
            this.TitlePanel.Controls.Add(this.TitleSpacer);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.ForeColor = System.Drawing.Color.White;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Margin = new System.Windows.Forms.Padding(10);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(745, 60);
            this.TitlePanel.TabIndex = 1;
            // 
            // TitleText
            // 
            this.TitleText.BackColor = System.Drawing.Color.Transparent;
            this.TitleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleText.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.TitleText.Location = new System.Drawing.Point(4, 0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(741, 60);
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "EMERGENCY ALERT";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TitleSpacer
            // 
            this.TitleSpacer.BackColor = System.Drawing.Color.Red;
            this.TitleSpacer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TitleSpacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.TitleSpacer.ForeColor = System.Drawing.Color.White;
            this.TitleSpacer.Location = new System.Drawing.Point(0, 0);
            this.TitleSpacer.Margin = new System.Windows.Forms.Padding(10);
            this.TitleSpacer.Name = "TitleSpacer";
            this.TitleSpacer.Size = new System.Drawing.Size(4, 60);
            this.TitleSpacer.TabIndex = 2;
            // 
            // AutoExit
            // 
            this.AutoExit.Interval = 300000;
            this.AutoExit.Tick += new System.EventHandler(this.AutoExit_Tick);
            // 
            // AlertPanel
            // 
            this.AlertPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AlertPanel.BackColor = System.Drawing.Color.Black;
            this.AlertPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlertPanel.Controls.Add(this.AlertText);
            this.AlertPanel.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.AlertPanel.Location = new System.Drawing.Point(82, 105);
            this.AlertPanel.Name = "AlertPanel";
            this.AlertPanel.Size = new System.Drawing.Size(655, 200);
            this.AlertPanel.TabIndex = 4;
            // 
            // AlertText
            // 
            this.AlertText.BackColor = System.Drawing.Color.Black;
            this.AlertText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AlertText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlertText.Font = new System.Drawing.Font("Arial", 18F);
            this.AlertText.ForeColor = System.Drawing.Color.White;
            this.AlertText.Location = new System.Drawing.Point(0, 0);
            this.AlertText.Multiline = true;
            this.AlertText.Name = "AlertText";
            this.AlertText.ReadOnly = true;
            this.AlertText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AlertText.Size = new System.Drawing.Size(653, 198);
            this.AlertText.TabIndex = 5;
            // 
            // DismissButton
            // 
            this.DismissButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DismissButton.BackColor = System.Drawing.Color.White;
            this.DismissButton.Enabled = false;
            this.DismissButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DismissButton.Font = new System.Drawing.Font("Arial", 18F);
            this.DismissButton.ForeColor = System.Drawing.Color.Black;
            this.DismissButton.Location = new System.Drawing.Point(622, 311);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(115, 35);
            this.DismissButton.TabIndex = 6;
            this.DismissButton.Text = "Dismiss";
            this.DismissButton.UseVisualStyleBackColor = false;
            this.DismissButton.Click += new System.EventHandler(this.DismissButton_Click);
            // 
            // SubtitlePanel
            // 
            this.SubtitlePanel.BackColor = System.Drawing.Color.Red;
            this.SubtitlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubtitlePanel.Controls.Add(this.SubtitleText);
            this.SubtitlePanel.Controls.Add(this.SubtitleSpacer);
            this.SubtitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubtitlePanel.ForeColor = System.Drawing.Color.White;
            this.SubtitlePanel.Location = new System.Drawing.Point(0, 60);
            this.SubtitlePanel.Margin = new System.Windows.Forms.Padding(10);
            this.SubtitlePanel.Name = "SubtitlePanel";
            this.SubtitlePanel.Size = new System.Drawing.Size(745, 32);
            this.SubtitlePanel.TabIndex = 7;
            // 
            // SubtitleText
            // 
            this.SubtitleText.BackColor = System.Drawing.Color.Transparent;
            this.SubtitleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubtitleText.Font = new System.Drawing.Font("Arial", 18F);
            this.SubtitleText.Location = new System.Drawing.Point(10, 0);
            this.SubtitleText.Name = "SubtitleText";
            this.SubtitleText.Size = new System.Drawing.Size(735, 32);
            this.SubtitleText.TabIndex = 3;
            this.SubtitleText.Text = "Short Alert Description";
            // 
            // SubtitleSpacer
            // 
            this.SubtitleSpacer.BackColor = System.Drawing.Color.Red;
            this.SubtitleSpacer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubtitleSpacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.SubtitleSpacer.ForeColor = System.Drawing.Color.White;
            this.SubtitleSpacer.Location = new System.Drawing.Point(0, 0);
            this.SubtitleSpacer.Margin = new System.Windows.Forms.Padding(10);
            this.SubtitleSpacer.Name = "SubtitleSpacer";
            this.SubtitleSpacer.Size = new System.Drawing.Size(10, 32);
            this.SubtitleSpacer.TabIndex = 2;
            // 
            // SpeakerButton
            // 
            this.SpeakerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SpeakerButton.BackColor = System.Drawing.Color.White;
            this.SpeakerButton.Enabled = false;
            this.SpeakerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SpeakerButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.SpeakerButton.ForeColor = System.Drawing.Color.Black;
            this.SpeakerButton.Location = new System.Drawing.Point(581, 311);
            this.SpeakerButton.Name = "SpeakerButton";
            this.SpeakerButton.Size = new System.Drawing.Size(35, 35);
            this.SpeakerButton.TabIndex = 8;
            this.SpeakerButton.Text = "🔊";
            this.SpeakerButton.UseVisualStyleBackColor = false;
            this.SpeakerButton.Click += new System.EventHandler(this.SpeakerButton_Click);
            // 
            // EnsureTopWindow
            // 
            this.EnsureTopWindow.Enabled = true;
            this.EnsureTopWindow.Interval = 1000;
            this.EnsureTopWindow.Tick += new System.EventHandler(this.EnsureTopWindow_Tick);
            // 
            // LinkButton
            // 
            this.LinkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkButton.BackColor = System.Drawing.Color.White;
            this.LinkButton.Enabled = false;
            this.LinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LinkButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.LinkButton.ForeColor = System.Drawing.Color.Black;
            this.LinkButton.Location = new System.Drawing.Point(540, 311);
            this.LinkButton.Name = "LinkButton";
            this.LinkButton.Size = new System.Drawing.Size(35, 35);
            this.LinkButton.TabIndex = 9;
            this.LinkButton.Text = "🔗";
            this.LinkButton.UseVisualStyleBackColor = false;
            this.LinkButton.Click += new System.EventHandler(this.LinkButton_Click);
            // 
            // FlashTaskbarStatus
            // 
            this.FlashTaskbarStatus.Enabled = true;
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
            // AlertIcon
            // 
            this.AlertIcon.Image = global::SharpAlert.Properties.Resources.AlertIcon;
            this.AlertIcon.Location = new System.Drawing.Point(12, 105);
            this.AlertIcon.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.AlertIcon.Name = "AlertIcon";
            this.AlertIcon.Size = new System.Drawing.Size(64, 64);
            this.AlertIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AlertIcon.TabIndex = 2;
            this.AlertIcon.TabStop = false;
            // 
            // AlertForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(745, 354);
            this.ControlBox = false;
            this.Controls.Add(this.LinkButton);
            this.Controls.Add(this.SpeakerButton);
            this.Controls.Add(this.SubtitlePanel);
            this.Controls.Add(this.DismissButton);
            this.Controls.Add(this.AlertPanel);
            this.Controls.Add(this.AlertIcon);
            this.Controls.Add(this.TitlePanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Alert Dialog";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AlertForm_FormClosed);
            this.Load += new System.EventHandler(this.AlertForm_Load);
            this.Shown += new System.EventHandler(this.AlertForm_Shown);
            this.TitlePanel.ResumeLayout(false);
            this.AlertPanel.ResumeLayout(false);
            this.AlertPanel.PerformLayout();
            this.SubtitlePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AlertIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.PictureBox AlertIcon;
        private System.Windows.Forms.Timer AutoExit;
        private System.Windows.Forms.Panel AlertPanel;
        private System.Windows.Forms.TextBox AlertText;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Panel TitleSpacer;
        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.Panel SubtitlePanel;
        private System.Windows.Forms.Label SubtitleText;
        private System.Windows.Forms.Panel SubtitleSpacer;
        private System.Windows.Forms.Button SpeakerButton;
        private System.Windows.Forms.Timer EnsureTopWindow;
        private System.Windows.Forms.Button LinkButton;
        private System.Windows.Forms.Timer FlashTaskbarStatus;
        private System.Windows.Forms.Timer AutoTTS;
        private System.Windows.Forms.Timer FadeInAnimation;
        private System.Windows.Forms.Timer FadeOutAnimation;
    }
}

