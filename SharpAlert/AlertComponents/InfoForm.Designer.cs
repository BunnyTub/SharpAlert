namespace SharpAlert
{
    partial class InfoForm
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
            this.DismissButton = new System.Windows.Forms.Button();
            this.AutoExit = new System.Windows.Forms.Timer(this.components);
            this.SubtitlePanel = new System.Windows.Forms.Panel();
            this.SubtitleText = new SharpAlert.ToolboxStuff.MarqueeLabel();
            this.EnsureTopWindow = new System.Windows.Forms.Timer(this.components);
            this.FadeInAnimation = new System.Windows.Forms.Timer(this.components);
            this.FadeOutAnimation = new System.Windows.Forms.Timer(this.components);
            this.TitlePanel.SuspendLayout();
            this.SubtitlePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitlePanel
            // 
            this.TitlePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.TitlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TitlePanel.Controls.Add(this.TitleText);
            this.TitlePanel.Controls.Add(this.TitleSpacer);
            this.TitlePanel.Controls.Add(this.DismissButton);
            this.TitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitlePanel.ForeColor = System.Drawing.Color.White;
            this.TitlePanel.Location = new System.Drawing.Point(0, 0);
            this.TitlePanel.Margin = new System.Windows.Forms.Padding(10);
            this.TitlePanel.Name = "TitlePanel";
            this.TitlePanel.Size = new System.Drawing.Size(1024, 60);
            this.TitlePanel.TabIndex = 1;
            // 
            // TitleText
            // 
            this.TitleText.BackColor = System.Drawing.Color.Transparent;
            this.TitleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TitleText.Font = new System.Drawing.Font("Arial", 32F, System.Drawing.FontStyle.Bold);
            this.TitleText.Location = new System.Drawing.Point(4, 0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(905, 60);
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "ALERT INFORMATION";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TitleSpacer
            // 
            this.TitleSpacer.BackColor = System.Drawing.Color.Transparent;
            this.TitleSpacer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TitleSpacer.Dock = System.Windows.Forms.DockStyle.Left;
            this.TitleSpacer.ForeColor = System.Drawing.Color.White;
            this.TitleSpacer.Location = new System.Drawing.Point(0, 0);
            this.TitleSpacer.Margin = new System.Windows.Forms.Padding(10);
            this.TitleSpacer.Name = "TitleSpacer";
            this.TitleSpacer.Size = new System.Drawing.Size(4, 60);
            this.TitleSpacer.TabIndex = 2;
            // 
            // DismissButton
            // 
            this.DismissButton.BackColor = System.Drawing.Color.White;
            this.DismissButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.DismissButton.Enabled = false;
            this.DismissButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DismissButton.Font = new System.Drawing.Font("Arial", 18F);
            this.DismissButton.ForeColor = System.Drawing.Color.Black;
            this.DismissButton.Location = new System.Drawing.Point(909, 0);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(115, 60);
            this.DismissButton.TabIndex = 4;
            this.DismissButton.Text = "Dismiss";
            this.DismissButton.UseVisualStyleBackColor = false;
            this.DismissButton.Click += new System.EventHandler(this.DismissButton_Click);
            // 
            // AutoExit
            // 
            this.AutoExit.Interval = 60000;
            this.AutoExit.Tick += new System.EventHandler(this.AutoExit_Tick);
            // 
            // SubtitlePanel
            // 
            this.SubtitlePanel.BackColor = System.Drawing.Color.DarkGreen;
            this.SubtitlePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.SubtitlePanel.Controls.Add(this.SubtitleText);
            this.SubtitlePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.SubtitlePanel.ForeColor = System.Drawing.Color.White;
            this.SubtitlePanel.Location = new System.Drawing.Point(0, 60);
            this.SubtitlePanel.Margin = new System.Windows.Forms.Padding(10);
            this.SubtitlePanel.Name = "SubtitlePanel";
            this.SubtitlePanel.Size = new System.Drawing.Size(1024, 36);
            this.SubtitlePanel.TabIndex = 7;
            // 
            // SubtitleText
            // 
            this.SubtitleText.BackColor = System.Drawing.Color.Transparent;
            this.SubtitleText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SubtitleText.Font = new System.Drawing.Font("Arial", 22F);
            this.SubtitleText.Location = new System.Drawing.Point(0, 0);
            this.SubtitleText.Name = "SubtitleText";
            this.SubtitleText.ScrollSpeed = 4F;
            this.SubtitleText.Size = new System.Drawing.Size(1024, 36);
            this.SubtitleText.TabIndex = 3;
            this.SubtitleText.Text = "This scroll should contain alert information.";
            this.SubtitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EnsureTopWindow
            // 
            this.EnsureTopWindow.Enabled = true;
            this.EnsureTopWindow.Interval = 1000;
            this.EnsureTopWindow.Tick += new System.EventHandler(this.EnsureTopWindow_Tick);
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
            // InfoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Magenta;
            this.ClientSize = new System.Drawing.Size(1024, 128);
            this.ControlBox = false;
            this.Controls.Add(this.SubtitlePanel);
            this.Controls.Add(this.TitlePanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Alert Dialog";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AlertForm_FormClosed);
            this.Load += new System.EventHandler(this.AlertForm_Load);
            this.Shown += new System.EventHandler(this.AlertForm_Shown);
            this.TitlePanel.ResumeLayout(false);
            this.SubtitlePanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TitlePanel;
        private System.Windows.Forms.Timer AutoExit;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Panel TitleSpacer;
        private System.Windows.Forms.Panel SubtitlePanel;
        private SharpAlert.ToolboxStuff.MarqueeLabel SubtitleText;
        private System.Windows.Forms.Timer EnsureTopWindow;
        private System.Windows.Forms.Timer FadeInAnimation;
        private System.Windows.Forms.Timer FadeOutAnimation;
        private System.Windows.Forms.Button DismissButton;
    }
}

