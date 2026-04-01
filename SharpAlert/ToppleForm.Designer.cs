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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToppleForm));
            TitleText = new System.Windows.Forms.Label();
            ProblemDetailsText = new System.Windows.Forms.TextBox();
            ProblemTitleText = new System.Windows.Forms.Label();
            CloseButton = new System.Windows.Forms.Button();
            ReportButton = new System.Windows.Forms.Button();
            AutoTerminate = new System.Windows.Forms.Timer(components);
            label1 = new System.Windows.Forms.Label();
            LogoBox = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            TerminateButton = new System.Windows.Forms.Button();
            ResetButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // TitleText
            // 
            TitleText.Dock = System.Windows.Forms.DockStyle.Top;
            TitleText.Font = new System.Drawing.Font("Segoe UI", 26F);
            TitleText.Location = new System.Drawing.Point(0, 0);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            TitleText.Size = new System.Drawing.Size(636, 49);
            TitleText.TabIndex = 1;
            TitleText.Text = "SharpAlert has crashed...";
            TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProblemDetailsText
            // 
            ProblemDetailsText.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ProblemDetailsText.BackColor = System.Drawing.Color.Black;
            ProblemDetailsText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ProblemDetailsText.ForeColor = System.Drawing.Color.White;
            ProblemDetailsText.Location = new System.Drawing.Point(12, 71);
            ProblemDetailsText.Multiline = true;
            ProblemDetailsText.Name = "ProblemDetailsText";
            ProblemDetailsText.ReadOnly = true;
            ProblemDetailsText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            ProblemDetailsText.Size = new System.Drawing.Size(387, 254);
            ProblemDetailsText.TabIndex = 3;
            ProblemDetailsText.Text = "We're gathering information about the problem.";
            // 
            // ProblemTitleText
            // 
            ProblemTitleText.AutoSize = true;
            ProblemTitleText.Font = new System.Drawing.Font("Segoe UI", 9F);
            ProblemTitleText.Location = new System.Drawing.Point(9, 53);
            ProblemTitleText.Margin = new System.Windows.Forms.Padding(0);
            ProblemTitleText.Name = "ProblemTitleText";
            ProblemTitleText.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
            ProblemTitleText.Size = new System.Drawing.Size(91, 15);
            ProblemTitleText.TabIndex = 4;
            ProblemTitleText.Text = "Problem Details";
            // 
            // CloseButton
            // 
            CloseButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            CloseButton.BackColor = System.Drawing.Color.OrangeRed;
            CloseButton.FlatAppearance.BorderSize = 2;
            CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            CloseButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            CloseButton.ForeColor = System.Drawing.Color.White;
            CloseButton.Location = new System.Drawing.Point(143, 331);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new System.Drawing.Size(125, 35);
            CloseButton.TabIndex = 7;
            CloseButton.Text = "Restart";
            CloseButton.UseVisualStyleBackColor = false;
            CloseButton.Click += CloseButton_Click;
            // 
            // ReportButton
            // 
            ReportButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ReportButton.BackColor = System.Drawing.Color.OrangeRed;
            ReportButton.FlatAppearance.BorderSize = 2;
            ReportButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ReportButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            ReportButton.ForeColor = System.Drawing.Color.White;
            ReportButton.Location = new System.Drawing.Point(12, 331);
            ReportButton.Name = "ReportButton";
            ReportButton.Size = new System.Drawing.Size(125, 35);
            ReportButton.TabIndex = 8;
            ReportButton.Text = "Report";
            ReportButton.UseVisualStyleBackColor = false;
            ReportButton.Click += ReportButton_Click;
            // 
            // AutoTerminate
            // 
            AutoTerminate.Enabled = true;
            AutoTerminate.Interval = 1000;
            AutoTerminate.Tick += AutoTerminate_Tick;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label1.Font = new System.Drawing.Font("Segoe UI", 18F);
            label1.Location = new System.Drawing.Point(346, 331);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(278, 35);
            label1.TabIndex = 9;
            label1.Text = "0s";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LogoBox
            // 
            LogoBox.Image = Properties.Resources.AlertIcon;
            LogoBox.Location = new System.Drawing.Point(587, 0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new System.Drawing.Size(49, 49);
            LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            LogoBox.TabIndex = 0;
            LogoBox.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            pictureBox2.Image = Properties.Resources.TrippingBunny;
            pictureBox2.Location = new System.Drawing.Point(405, 54);
            pictureBox2.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(222, 290);
            pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // TerminateButton
            // 
            TerminateButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TerminateButton.BackColor = System.Drawing.Color.OrangeRed;
            TerminateButton.FlatAppearance.BorderSize = 2;
            TerminateButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            TerminateButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            TerminateButton.ForeColor = System.Drawing.Color.White;
            TerminateButton.Location = new System.Drawing.Point(274, 331);
            TerminateButton.Name = "TerminateButton";
            TerminateButton.Size = new System.Drawing.Size(125, 35);
            TerminateButton.TabIndex = 12;
            TerminateButton.Text = "Close";
            TerminateButton.UseVisualStyleBackColor = false;
            TerminateButton.Click += TerminateButton_Click;
            // 
            // ResetButton
            // 
            ResetButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ResetButton.BackColor = System.Drawing.Color.Green;
            ResetButton.FlatAppearance.BorderSize = 2;
            ResetButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ResetButton.Font = new System.Drawing.Font("Segoe UI", 12F);
            ResetButton.ForeColor = System.Drawing.Color.White;
            ResetButton.Location = new System.Drawing.Point(405, 331);
            ResetButton.Name = "ResetButton";
            ResetButton.Size = new System.Drawing.Size(156, 35);
            ResetButton.TabIndex = 13;
            ResetButton.Text = "Reset Settings";
            ResetButton.UseVisualStyleBackColor = false;
            ResetButton.Click += ResetButton_Click;
            // 
            // ToppleForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(636, 378);
            Controls.Add(ResetButton);
            Controls.Add(TerminateButton);
            Controls.Add(ReportButton);
            Controls.Add(CloseButton);
            Controls.Add(ProblemDetailsText);
            Controls.Add(label1);
            Controls.Add(ProblemTitleText);
            Controls.Add(LogoBox);
            Controls.Add(TitleText);
            Controls.Add(pictureBox2);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ToppleForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert";
            TopMost = true;
            FormClosed += ToppleForm_FormClosed;
            Load += ToppleForm_Load;
            Shown += ToppleForm_Shown;
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
