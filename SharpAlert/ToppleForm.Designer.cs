namespace SharpAlert
{
    partial class ToppleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToppleForm));
            this.TitleText = new System.Windows.Forms.Label();
            this.SubtitleText = new System.Windows.Forms.Label();
            this.ProblemDetailsText = new System.Windows.Forms.TextBox();
            this.ProblemTitleText = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ReportButton = new System.Windows.Forms.Button();
            this.AutoTerminate = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleText
            // 
            this.TitleText.AutoSize = true;
            this.TitleText.Font = new System.Drawing.Font("Arial", 32F);
            this.TitleText.Location = new System.Drawing.Point(111, 12);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(511, 49);
            this.TitleText.TabIndex = 1;
            this.TitleText.Text = "Tripped over a loose cord";
            // 
            // SubtitleText
            // 
            this.SubtitleText.AutoSize = true;
            this.SubtitleText.Font = new System.Drawing.Font("Arial", 18F);
            this.SubtitleText.Location = new System.Drawing.Point(115, 61);
            this.SubtitleText.Margin = new System.Windows.Forms.Padding(0);
            this.SubtitleText.Name = "SubtitleText";
            this.SubtitleText.Size = new System.Drawing.Size(510, 54);
            this.SubtitleText.TabIndex = 2;
            this.SubtitleText.Text = "SharpAlert has logged the current issue inside\r\nof the Windows event logs. Sorry " +
    "about that.";
            // 
            // ProblemDetailsText
            // 
            this.ProblemDetailsText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProblemDetailsText.BackColor = System.Drawing.Color.Black;
            this.ProblemDetailsText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProblemDetailsText.ForeColor = System.Drawing.Color.White;
            this.ProblemDetailsText.Location = new System.Drawing.Point(12, 161);
            this.ProblemDetailsText.Multiline = true;
            this.ProblemDetailsText.Name = "ProblemDetailsText";
            this.ProblemDetailsText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProblemDetailsText.Size = new System.Drawing.Size(398, 259);
            this.ProblemDetailsText.TabIndex = 3;
            this.ProblemDetailsText.Text = "We\'re gathering information about the problem.";
            // 
            // ProblemTitleText
            // 
            this.ProblemTitleText.AutoSize = true;
            this.ProblemTitleText.Font = new System.Drawing.Font("Arial", 9F);
            this.ProblemTitleText.Location = new System.Drawing.Point(9, 143);
            this.ProblemTitleText.Margin = new System.Windows.Forms.Padding(0);
            this.ProblemTitleText.Name = "ProblemTitleText";
            this.ProblemTitleText.Size = new System.Drawing.Size(96, 15);
            this.ProblemTitleText.TabIndex = 4;
            this.ProblemTitleText.Text = "Problem Details";
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.BackColor = System.Drawing.Color.OrangeRed;
            this.CloseButton.FlatAppearance.BorderSize = 2;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseButton.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(243, 426);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(225, 35);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ReportButton
            // 
            this.ReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReportButton.BackColor = System.Drawing.Color.OrangeRed;
            this.ReportButton.FlatAppearance.BorderSize = 2;
            this.ReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ReportButton.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.ReportButton.ForeColor = System.Drawing.Color.White;
            this.ReportButton.Location = new System.Drawing.Point(12, 426);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(225, 35);
            this.ReportButton.TabIndex = 8;
            this.ReportButton.Text = "Report";
            this.ReportButton.UseVisualStyleBackColor = false;
            this.ReportButton.Click += new System.EventHandler(this.ReportButton_Click);
            // 
            // AutoTerminate
            // 
            this.AutoTerminate.Enabled = true;
            this.AutoTerminate.Interval = 1000;
            this.AutoTerminate.Tick += new System.EventHandler(this.AutoTerminate_Tick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Arial", 18F);
            this.label1.Location = new System.Drawing.Point(346, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 35);
            this.label1.TabIndex = 9;
            this.label1.Text = "0s";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SharpAlert.Properties.Resources.CrashIcon;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::SharpAlert.Properties.Resources.Topple;
            this.pictureBox2.Location = new System.Drawing.Point(209, 149);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(442, 290);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // ToppleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(636, 473);
            this.Controls.Add(this.ReportButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ProblemDetailsText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProblemTitleText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SubtitleText);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ToppleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ToppleForm_FormClosed);
            this.Load += new System.EventHandler(this.ToppleForm_Load);
            this.Shown += new System.EventHandler(this.ToppleForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Label SubtitleText;
        private System.Windows.Forms.TextBox ProblemDetailsText;
        private System.Windows.Forms.Label ProblemTitleText;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.Timer AutoTerminate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}