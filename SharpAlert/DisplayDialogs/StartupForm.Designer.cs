namespace SharpAlert.DisplayDialogs
{
    partial class StartupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            this.IconBox = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.AutoClose = new System.Windows.Forms.Timer(this.components);
            this.MainContentsPanel = new System.Windows.Forms.Panel();
            this.FadeInAnimation = new System.Windows.Forms.Timer(this.components);
            this.FadeOutAnimation = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).BeginInit();
            this.MainContentsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // IconBox
            // 
            this.IconBox.Image = global::SharpAlert.Properties.Resources.WarningApp;
            this.IconBox.Location = new System.Drawing.Point(8, 8);
            this.IconBox.Margin = new System.Windows.Forms.Padding(0);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(128, 128);
            this.IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IconBox.TabIndex = 0;
            this.IconBox.TabStop = false;
            this.IconBox.Click += new System.EventHandler(this.IconBox_Click);
            // 
            // TitleText
            // 
            this.TitleText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleText.Font = new System.Drawing.Font("Arial", 62F, System.Drawing.FontStyle.Bold);
            this.TitleText.Location = new System.Drawing.Point(139, 8);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(468, 128);
            this.TitleText.TabIndex = 1;
            this.TitleText.Text = "SharpAlert";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoClose
            // 
            this.AutoClose.Interval = 2000;
            this.AutoClose.Tick += new System.EventHandler(this.AutoClose_Tick);
            // 
            // MainContentsPanel
            // 
            this.MainContentsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MainContentsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainContentsPanel.Controls.Add(this.TitleText);
            this.MainContentsPanel.Controls.Add(this.IconBox);
            this.MainContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContentsPanel.Location = new System.Drawing.Point(0, 0);
            this.MainContentsPanel.Name = "MainContentsPanel";
            this.MainContentsPanel.Size = new System.Drawing.Size(620, 146);
            this.MainContentsPanel.TabIndex = 3;
            this.MainContentsPanel.Visible = false;
            // 
            // FadeInAnimation
            // 
            this.FadeInAnimation.Interval = 2;
            this.FadeInAnimation.Tick += new System.EventHandler(this.FadeInAnimation_Tick);
            // 
            // FadeOutAnimation
            // 
            this.FadeOutAnimation.Interval = 2;
            this.FadeOutAnimation.Tick += new System.EventHandler(this.FadeOutAnimation_Tick);
            // 
            // StartupForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(620, 146);
            this.ControlBox = false;
            this.Controls.Add(this.MainContentsPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartupForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert Splash Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StartupForm_FormClosing);
            this.Load += new System.EventHandler(this.StartupForm_Load);
            this.Shown += new System.EventHandler(this.StartupForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.IconBox)).EndInit();
            this.MainContentsPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox IconBox;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Timer AutoClose;
        private System.Windows.Forms.Panel MainContentsPanel;
        private System.Windows.Forms.Timer FadeInAnimation;
        private System.Windows.Forms.Timer FadeOutAnimation;
    }
}
