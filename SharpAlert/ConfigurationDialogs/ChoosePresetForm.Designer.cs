namespace SharpAlert.ConfigurationDialogs
{
    partial class ChoosePresetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChoosePresetForm));
            LogoBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            PreferMinorButton = new System.Windows.Forms.Button();
            PreferAllButton = new System.Windows.Forms.Button();
            PreferSevereButton = new System.Windows.Forms.Button();
            SkipButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            SuspendLayout();
            // 
            // LogoBox
            // 
            LogoBox.Image = Properties.Resources.WarningApp;
            LogoBox.Location = new System.Drawing.Point(9, 9);
            LogoBox.Margin = new System.Windows.Forms.Padding(0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new System.Drawing.Size(96, 96);
            LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            LogoBox.TabIndex = 2;
            LogoBox.TabStop = false;
            // 
            // TitleText
            // 
            TitleText.Font = new System.Drawing.Font("Segoe UI", 14F);
            TitleText.Location = new System.Drawing.Point(105, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(533, 53);
            TitleText.TabIndex = 3;
            TitleText.Text = "Choose an alert receiving preset to start with. You can change individual options in your alert settings (Advanced Mode). ";
            // 
            // PreferMinorButton
            // 
            PreferMinorButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            PreferMinorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            PreferMinorButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            PreferMinorButton.ForeColor = System.Drawing.Color.White;
            PreferMinorButton.Location = new System.Drawing.Point(108, 65);
            PreferMinorButton.Name = "PreferMinorButton";
            PreferMinorButton.Size = new System.Drawing.Size(128, 128);
            PreferMinorButton.TabIndex = 4;
            PreferMinorButton.Text = "I prefer...\r\n\r\nMinor and higher alerts.";
            PreferMinorButton.UseMnemonic = false;
            PreferMinorButton.UseVisualStyleBackColor = false;
            PreferMinorButton.Click += PreferMinorButton_Click;
            // 
            // PreferAllButton
            // 
            PreferAllButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            PreferAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            PreferAllButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            PreferAllButton.ForeColor = System.Drawing.Color.White;
            PreferAllButton.Location = new System.Drawing.Point(376, 65);
            PreferAllButton.Name = "PreferAllButton";
            PreferAllButton.Size = new System.Drawing.Size(128, 128);
            PreferAllButton.TabIndex = 6;
            PreferAllButton.Text = "I prefer...\r\n\r\nAny alerts, including tests.";
            PreferAllButton.UseMnemonic = false;
            PreferAllButton.UseVisualStyleBackColor = false;
            PreferAllButton.Click += PreferAllButton_Click;
            // 
            // PreferSevereButton
            // 
            PreferSevereButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            PreferSevereButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            PreferSevereButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            PreferSevereButton.ForeColor = System.Drawing.Color.White;
            PreferSevereButton.Location = new System.Drawing.Point(242, 65);
            PreferSevereButton.Name = "PreferSevereButton";
            PreferSevereButton.Size = new System.Drawing.Size(128, 128);
            PreferSevereButton.TabIndex = 5;
            PreferSevereButton.Text = "I prefer...\r\n\r\nSevere and higher alerts.";
            PreferSevereButton.UseMnemonic = false;
            PreferSevereButton.UseVisualStyleBackColor = false;
            PreferSevereButton.Click += PreferSevereButton_Click;
            // 
            // SkipButton
            // 
            SkipButton.BackColor = System.Drawing.Color.FromArgb(180, 60, 60);
            SkipButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SkipButton.Font = new System.Drawing.Font("Segoe UI", 24F);
            SkipButton.ForeColor = System.Drawing.Color.White;
            SkipButton.Location = new System.Drawing.Point(510, 64);
            SkipButton.Name = "SkipButton";
            SkipButton.Size = new System.Drawing.Size(128, 128);
            SkipButton.TabIndex = 7;
            SkipButton.Text = "Skip";
            SkipButton.UseMnemonic = false;
            SkipButton.UseVisualStyleBackColor = false;
            SkipButton.Click += SkipButton_Click;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(9, 202);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(629, 21);
            label1.TabIndex = 14;
            label1.Text = "To change these options later, go to Settings (under Alert Settings).";
            label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ChoosePresetForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(650, 232);
            Controls.Add(label1);
            Controls.Add(SkipButton);
            Controls.Add(PreferSevereButton);
            Controls.Add(PreferAllButton);
            Controls.Add(PreferMinorButton);
            Controls.Add(TitleText);
            Controls.Add(LogoBox);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChoosePresetForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Alert Presets";
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Button PreferMinorButton;
        private System.Windows.Forms.Button PreferAllButton;
        private System.Windows.Forms.Button PreferSevereButton;
        private System.Windows.Forms.Button SkipButton;
        private System.Windows.Forms.Label label1;
    }
}