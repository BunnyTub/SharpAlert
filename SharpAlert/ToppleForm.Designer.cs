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
            this.ProblemDetailsText = new System.Windows.Forms.TextBox();
            this.ProblemTitleText = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ReportButton = new System.Windows.Forms.Button();
            this.AutoTerminate = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.TerminateButton = new System.Windows.Forms.Button();
            this.ResetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // TitleText
            // 
            this.TitleText.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleText.Font = new System.Drawing.Font("Segoe UI", 26F);
            this.TitleText.Location = new System.Drawing.Point(0, 0);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(636, 49);
            this.TitleText.TabIndex = 1;
            this.TitleText.Text = "SharpAlert has crashed...";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProblemDetailsText
            // 
            this.ProblemDetailsText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProblemDetailsText.BackColor = System.Drawing.Color.Black;
            this.ProblemDetailsText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProblemDetailsText.ForeColor = System.Drawing.Color.White;
            this.ProblemDetailsText.Location = new System.Drawing.Point(12, 71);
            this.ProblemDetailsText.Multiline = true;
            this.ProblemDetailsText.Name = "ProblemDetailsText";
            this.ProblemDetailsText.ReadOnly = true;
            this.ProblemDetailsText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ProblemDetailsText.Size = new System.Drawing.Size(376, 254);
            this.ProblemDetailsText.TabIndex = 3;
            this.ProblemDetailsText.Text = "We\'re gathering information about the problem.";
            // 
            // ProblemTitleText
            // 
            this.ProblemTitleText.AutoSize = true;
            this.ProblemTitleText.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ProblemTitleText.Location = new System.Drawing.Point(9, 53);
            this.ProblemTitleText.Margin = new System.Windows.Forms.Padding(0);
            this.ProblemTitleText.Name = "ProblemTitleText";
            this.ProblemTitleText.Size = new System.Drawing.Size(96, 15);
            this.ProblemTitleText.TabIndex = 4;
            this.ProblemTitleText.Text = "Problem Details";
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CloseButton.BackColor = System.Drawing.Color.OrangeRed;
            this.CloseButton.FlatAppearance.BorderSize = 2;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(138, 331);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(125, 35);
            this.CloseButton.TabIndex = 7;
            this.CloseButton.Text = "Restart";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ReportButton
            // 
            this.ReportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ReportButton.BackColor = System.Drawing.Color.OrangeRed;
            this.ReportButton.FlatAppearance.BorderSize = 2;
            this.ReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ReportButton.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.ReportButton.ForeColor = System.Drawing.Color.White;
            this.ReportButton.Location = new System.Drawing.Point(7, 331);
            this.ReportButton.Name = "ReportButton";
            this.ReportButton.Size = new System.Drawing.Size(125, 35);
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
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F);
            this.label1.Location = new System.Drawing.Point(346, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 35);
            this.label1.TabIndex = 9;
            this.label1.Text = "0s";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LogoBox
            // 
            this.LogoBox.Image = global::SharpAlert.Properties.Resources.CrashIcon;
            this.LogoBox.Location = new System.Drawing.Point(587, 0);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(49, 49);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoBox.TabIndex = 0;
            this.LogoBox.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Image = global::SharpAlert.Properties.Resources.Topple;
            this.pictureBox2.Location = new System.Drawing.Point(232, 54);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(404, 290);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // TerminateButton
            // 
            this.TerminateButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TerminateButton.BackColor = System.Drawing.Color.OrangeRed;
            this.TerminateButton.FlatAppearance.BorderSize = 2;
            this.TerminateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TerminateButton.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.TerminateButton.ForeColor = System.Drawing.Color.White;
            this.TerminateButton.Location = new System.Drawing.Point(269, 331);
            this.TerminateButton.Name = "TerminateButton";
            this.TerminateButton.Size = new System.Drawing.Size(125, 35);
            this.TerminateButton.TabIndex = 12;
            this.TerminateButton.Text = "Close";
            this.TerminateButton.UseVisualStyleBackColor = false;
            this.TerminateButton.Click += new System.EventHandler(this.TerminateButton_Click);
            // 
            // ResetButton
            // 
            this.ResetButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ResetButton.BackColor = System.Drawing.Color.Green;
            this.ResetButton.FlatAppearance.BorderSize = 2;
            this.ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ResetButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.ResetButton.ForeColor = System.Drawing.Color.White;
            this.ResetButton.Location = new System.Drawing.Point(400, 331);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(161, 35);
            this.ResetButton.TabIndex = 13;
            this.ResetButton.Text = "Reset Settings";
            this.ResetButton.UseVisualStyleBackColor = false;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // ToppleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(636, 378);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.TerminateButton);
            this.Controls.Add(this.ReportButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ProblemDetailsText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ProblemTitleText);
            this.Controls.Add(this.LogoBox);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.pictureBox2);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
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
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.TextBox ProblemDetailsText;
        private System.Windows.Forms.Label ProblemTitleText;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ReportButton;
        private System.Windows.Forms.Timer AutoTerminate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button TerminateButton;
        private System.Windows.Forms.Button ResetButton;
    }
}
