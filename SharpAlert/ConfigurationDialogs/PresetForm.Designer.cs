namespace SharpAlert.ConfigurationDialogs
{
    partial class PresetForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PresetForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.PreferMinorButton = new System.Windows.Forms.Button();
            this.PreferAllButton = new System.Windows.Forms.Button();
            this.PreferSevereButton = new System.Windows.Forms.Button();
            this.SkipButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SharpAlert.Properties.Resources.WarningApp;
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // TitleText
            // 
            this.TitleText.Font = new System.Drawing.Font("Arial", 16F);
            this.TitleText.Location = new System.Drawing.Point(105, 9);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(533, 53);
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "Choose an alert receiver preset to start with. You can change individual options " +
    "in your CAP settings.";
            // 
            // PreferMinorButton
            // 
            this.PreferMinorButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.PreferMinorButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PreferMinorButton.Font = new System.Drawing.Font("Arial", 16F);
            this.PreferMinorButton.ForeColor = System.Drawing.Color.White;
            this.PreferMinorButton.Location = new System.Drawing.Point(108, 65);
            this.PreferMinorButton.Name = "PreferMinorButton";
            this.PreferMinorButton.Size = new System.Drawing.Size(128, 128);
            this.PreferMinorButton.TabIndex = 4;
            this.PreferMinorButton.Text = "I prefer...\r\nminor and higher alerts";
            this.PreferMinorButton.UseMnemonic = false;
            this.PreferMinorButton.UseVisualStyleBackColor = false;
            // 
            // PreferAllButton
            // 
            this.PreferAllButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.PreferAllButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PreferAllButton.Font = new System.Drawing.Font("Arial", 16F);
            this.PreferAllButton.ForeColor = System.Drawing.Color.White;
            this.PreferAllButton.Location = new System.Drawing.Point(376, 65);
            this.PreferAllButton.Name = "PreferAllButton";
            this.PreferAllButton.Size = new System.Drawing.Size(128, 128);
            this.PreferAllButton.TabIndex = 6;
            this.PreferAllButton.Text = "I prefer...\r\nany and all alerts";
            this.PreferAllButton.UseMnemonic = false;
            this.PreferAllButton.UseVisualStyleBackColor = false;
            // 
            // PreferSevereButton
            // 
            this.PreferSevereButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.PreferSevereButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PreferSevereButton.Font = new System.Drawing.Font("Arial", 16F);
            this.PreferSevereButton.ForeColor = System.Drawing.Color.White;
            this.PreferSevereButton.Location = new System.Drawing.Point(242, 65);
            this.PreferSevereButton.Name = "PreferSevereButton";
            this.PreferSevereButton.Size = new System.Drawing.Size(128, 128);
            this.PreferSevereButton.TabIndex = 5;
            this.PreferSevereButton.Text = "I prefer...\r\nsevere and higher alerts";
            this.PreferSevereButton.UseMnemonic = false;
            this.PreferSevereButton.UseVisualStyleBackColor = false;
            // 
            // SkipButton
            // 
            this.SkipButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SkipButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SkipButton.Font = new System.Drawing.Font("Arial", 24F);
            this.SkipButton.ForeColor = System.Drawing.Color.White;
            this.SkipButton.Location = new System.Drawing.Point(510, 64);
            this.SkipButton.Name = "SkipButton";
            this.SkipButton.Size = new System.Drawing.Size(128, 128);
            this.SkipButton.TabIndex = 7;
            this.SkipButton.Text = "Skip";
            this.SkipButton.UseMnemonic = false;
            this.SkipButton.UseVisualStyleBackColor = false;
            // 
            // PresetForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(650, 204);
            this.Controls.Add(this.SkipButton);
            this.Controls.Add(this.PreferSevereButton);
            this.Controls.Add(this.PreferAllButton);
            this.Controls.Add(this.PreferMinorButton);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PresetForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Alert Presets";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Button PreferMinorButton;
        private System.Windows.Forms.Button PreferAllButton;
        private System.Windows.Forms.Button PreferSevereButton;
        private System.Windows.Forms.Button SkipButton;
    }
}