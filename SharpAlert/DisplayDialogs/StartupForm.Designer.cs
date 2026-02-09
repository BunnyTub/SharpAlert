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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartupForm));
            IconBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            AutoClose = new System.Windows.Forms.Timer(components);
            MainContentsPanel = new System.Windows.Forms.Panel();
            FadeInAnimation = new System.Windows.Forms.Timer(components);
            FadeOutAnimation = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)IconBox).BeginInit();
            MainContentsPanel.SuspendLayout();
            SuspendLayout();
            // 
            // IconBox
            // 
            IconBox.Image = Properties.Resources.WarningApp;
            IconBox.Location = new System.Drawing.Point(8, 8);
            IconBox.Margin = new System.Windows.Forms.Padding(0);
            IconBox.Name = "IconBox";
            IconBox.Size = new System.Drawing.Size(128, 128);
            IconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            IconBox.TabIndex = 0;
            IconBox.TabStop = false;
            IconBox.Click += IconBox_Click;
            // 
            // TitleText
            // 
            TitleText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TitleText.Font = new System.Drawing.Font("Segoe UI", 62F, System.Drawing.FontStyle.Bold);
            TitleText.Location = new System.Drawing.Point(139, 8);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(468, 128);
            TitleText.TabIndex = 1;
            TitleText.Text = "SharpAlert";
            TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AutoClose
            // 
            AutoClose.Interval = 1200;
            AutoClose.Tick += AutoClose_Tick;
            // 
            // MainContentsPanel
            // 
            MainContentsPanel.BackColor = System.Drawing.Color.FromArgb(50, 0, 0);
            MainContentsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            MainContentsPanel.Controls.Add(TitleText);
            MainContentsPanel.Controls.Add(IconBox);
            MainContentsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            MainContentsPanel.Location = new System.Drawing.Point(0, 0);
            MainContentsPanel.Name = "MainContentsPanel";
            MainContentsPanel.Size = new System.Drawing.Size(620, 146);
            MainContentsPanel.TabIndex = 3;
            MainContentsPanel.Visible = false;
            // 
            // FadeInAnimation
            // 
            FadeInAnimation.Interval = 2;
            FadeInAnimation.Tick += FadeInAnimation_Tick;
            // 
            // FadeOutAnimation
            // 
            FadeOutAnimation.Interval = 2;
            FadeOutAnimation.Tick += FadeOutAnimation_Tick;
            // 
            // StartupForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.Red;
            ClientSize = new System.Drawing.Size(620, 146);
            ControlBox = false;
            Controls.Add(MainContentsPanel);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StartupForm";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert Splash Window";
            FormClosing += StartupForm_FormClosing;
            Load += StartupForm_Load;
            Shown += StartupForm_Shown;
            ((System.ComponentModel.ISupportInitialize)IconBox).EndInit();
            MainContentsPanel.ResumeLayout(false);
            ResumeLayout(false);

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
