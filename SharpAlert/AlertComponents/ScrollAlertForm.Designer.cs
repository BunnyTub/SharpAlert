namespace SharpAlert.AlertComponents
{
    partial class ScrollAlertForm
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
            this.FlashTaskbarStatus = new System.Windows.Forms.Timer(this.components);
            this.AutoTTS = new System.Windows.Forms.Timer(this.components);
            this.FadeInAnimation = new System.Windows.Forms.Timer(this.components);
            this.FadeOutAnimation = new System.Windows.Forms.Timer(this.components);
            this.MouseMoving = new System.Windows.Forms.Timer(this.components);
            this.AutoHideButtons = new System.Windows.Forms.Timer(this.components);
            this.InfoTip = new System.Windows.Forms.ToolTip(this.components);
            this.LinkButton = new System.Windows.Forms.Button();
            this.DismissButton = new System.Windows.Forms.Button();
            this.ScreenshotButton = new System.Windows.Forms.Button();
            this.TerminateSelf = new System.Windows.Forms.Timer(this.components);
            this.WindowFlash = new System.Windows.Forms.Timer(this.components);
            this.BottomOutlinePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.OutlineContainerPanel = new System.Windows.Forms.Panel();
            this.AlertText = new SharpAlert.WinFormsControls.ToolboxStuff.MarqueeLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.OutlineContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoExit
            // 
            this.AutoExit.Interval = 300000;
            this.AutoExit.Tick += new System.EventHandler(this.AutoExit_Tick);
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
            this.FadeInAnimation.Interval = 3;
            this.FadeInAnimation.Tick += new System.EventHandler(this.FadeInAnimation_Tick);
            // 
            // FadeOutAnimation
            // 
            this.FadeOutAnimation.Interval = 3;
            this.FadeOutAnimation.Tick += new System.EventHandler(this.FadeOutAnimation_Tick);
            // 
            // MouseMoving
            // 
            this.MouseMoving.Tick += new System.EventHandler(this.MouseMoving_Tick);
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
            // LinkButton
            // 
            this.LinkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkButton.BackColor = System.Drawing.Color.White;
            this.LinkButton.Enabled = false;
            this.LinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LinkButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.LinkButton.ForeColor = System.Drawing.Color.Black;
            this.LinkButton.Location = new System.Drawing.Point(1160, 102);
            this.LinkButton.Name = "LinkButton";
            this.LinkButton.Size = new System.Drawing.Size(35, 35);
            this.LinkButton.TabIndex = 13;
            this.LinkButton.Text = "🔗";
            this.InfoTip.SetToolTip(this.LinkButton, "Opens the alert URL if there is one included.");
            this.LinkButton.UseVisualStyleBackColor = false;
            this.LinkButton.Visible = false;
            this.LinkButton.Click += new System.EventHandler(this.LinkButton_Click);
            // 
            // DismissButton
            // 
            this.DismissButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DismissButton.BackColor = System.Drawing.Color.White;
            this.DismissButton.Enabled = false;
            this.DismissButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DismissButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.DismissButton.ForeColor = System.Drawing.Color.Black;
            this.DismissButton.Location = new System.Drawing.Point(1242, 102);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(35, 35);
            this.DismissButton.TabIndex = 11;
            this.DismissButton.Text = "✖";
            this.InfoTip.SetToolTip(this.DismissButton, "Closes the alert.");
            this.DismissButton.UseVisualStyleBackColor = false;
            this.DismissButton.Visible = false;
            this.DismissButton.Click += new System.EventHandler(this.DismissButton_Click);
            // 
            // ScreenshotButton
            // 
            this.ScreenshotButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ScreenshotButton.BackColor = System.Drawing.Color.White;
            this.ScreenshotButton.Enabled = false;
            this.ScreenshotButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ScreenshotButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.ScreenshotButton.ForeColor = System.Drawing.Color.Black;
            this.ScreenshotButton.Location = new System.Drawing.Point(1201, 102);
            this.ScreenshotButton.Name = "ScreenshotButton";
            this.ScreenshotButton.Size = new System.Drawing.Size(35, 35);
            this.ScreenshotButton.TabIndex = 12;
            this.ScreenshotButton.Text = "📸";
            this.InfoTip.SetToolTip(this.ScreenshotButton, "Takes a screenshot of the alert window, and saves the image to the disk.");
            this.ScreenshotButton.UseVisualStyleBackColor = false;
            this.ScreenshotButton.Visible = false;
            this.ScreenshotButton.Click += new System.EventHandler(this.ScreenshotButton_Click);
            // 
            // TerminateSelf
            // 
            this.TerminateSelf.Enabled = true;
            this.TerminateSelf.Interval = 500;
            this.TerminateSelf.Tick += new System.EventHandler(this.TerminateSelf_Tick);
            // 
            // WindowFlash
            // 
            this.WindowFlash.Interval = 1000;
            this.WindowFlash.Tick += new System.EventHandler(this.WindowFlash_Tick);
            // 
            // BottomOutlinePanel
            // 
            this.BottomOutlinePanel.BackColor = System.Drawing.Color.Red;
            this.BottomOutlinePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BottomOutlinePanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.BottomOutlinePanel.ForeColor = System.Drawing.Color.White;
            this.BottomOutlinePanel.Location = new System.Drawing.Point(0, 90);
            this.BottomOutlinePanel.Margin = new System.Windows.Forms.Padding(10);
            this.BottomOutlinePanel.Name = "BottomOutlinePanel";
            this.BottomOutlinePanel.Size = new System.Drawing.Size(1280, 8);
            this.BottomOutlinePanel.TabIndex = 18;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DarkRed;
            this.pictureBox1.Image = global::SharpAlert.Properties.Resources.AlertIcon;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(90, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // OutlineContainerPanel
            // 
            this.OutlineContainerPanel.BackColor = System.Drawing.Color.Magenta;
            this.OutlineContainerPanel.Controls.Add(this.pictureBox1);
            this.OutlineContainerPanel.Controls.Add(this.BottomOutlinePanel);
            this.OutlineContainerPanel.Controls.Add(this.ScreenshotButton);
            this.OutlineContainerPanel.Controls.Add(this.DismissButton);
            this.OutlineContainerPanel.Controls.Add(this.LinkButton);
            this.OutlineContainerPanel.Controls.Add(this.AlertText);
            this.OutlineContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutlineContainerPanel.Font = new System.Drawing.Font("Arial", 16F);
            this.OutlineContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.OutlineContainerPanel.Name = "OutlineContainerPanel";
            this.OutlineContainerPanel.Size = new System.Drawing.Size(1280, 720);
            this.OutlineContainerPanel.TabIndex = 10;
            // 
            // AlertText
            // 
            this.AlertText.BackColor = System.Drawing.Color.DarkRed;
            this.AlertText.Dock = System.Windows.Forms.DockStyle.Top;
            this.AlertText.Font = new System.Drawing.Font("Arial", 52F);
            this.AlertText.Location = new System.Drawing.Point(0, 0);
            this.AlertText.Name = "AlertText";
            this.AlertText.ScrollSpeed = 5F;
            this.AlertText.Size = new System.Drawing.Size(1280, 90);
            this.AlertText.Stutter = 25;
            this.AlertText.TabIndex = 15;
            this.AlertText.Text = "Alert Message";
            this.AlertText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AlertText.UseCustomPixelCount = false;
            // 
            // ScrollAlertForm
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
            this.Name = "ScrollAlertForm";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SharpAlert - Scroll Panel";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Magenta;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AlertForm_FormClosed);
            this.Load += new System.EventHandler(this.AlertForm_Load);
            this.Shown += new System.EventHandler(this.AlertForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.OutlineContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer AutoExit;
        private System.Windows.Forms.Timer FlashTaskbarStatus;
        private System.Windows.Forms.Timer AutoTTS;
        private System.Windows.Forms.Timer FadeInAnimation;
        private System.Windows.Forms.Timer FadeOutAnimation;
        private System.Windows.Forms.Timer MouseMoving;
        private System.Windows.Forms.Timer AutoHideButtons;
        private System.Windows.Forms.ToolTip InfoTip;
        private System.Windows.Forms.Timer TerminateSelf;
        private System.Windows.Forms.Timer WindowFlash;
        private System.Windows.Forms.Button LinkButton;
        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.Button ScreenshotButton;
        private System.Windows.Forms.Panel BottomOutlinePanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel OutlineContainerPanel;
        private WinFormsControls.ToolboxStuff.MarqueeLabel AlertText;
    }
}


