namespace SharpAlert.ProgramWorker
{
    partial class UninstallingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UninstallingForm));
            DoneButton = new System.Windows.Forms.Button();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            TitleText = new System.Windows.Forms.Label();
            LogoBox = new System.Windows.Forms.PictureBox();
            DescriptionLinkText = new System.Windows.Forms.LinkLabel();
            AutoCloseProgress = new System.Windows.Forms.ProgressBar();
            AutoClose = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Location = new System.Drawing.Point(363, 124);
            DoneButton.Margin = new System.Windows.Forms.Padding(0);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new System.Drawing.Size(72, 23);
            DoneButton.TabIndex = 15;
            DoneButton.Text = "Okay";
            DoneButton.UseVisualStyleBackColor = false;
            DoneButton.Click += DoneButton_Click;
            // 
            // ToolTipInformation
            // 
            ToolTipInformation.AutomaticDelay = 250;
            ToolTipInformation.AutoPopDelay = 15000;
            ToolTipInformation.BackColor = System.Drawing.Color.White;
            ToolTipInformation.ForeColor = System.Drawing.Color.Black;
            ToolTipInformation.InitialDelay = 250;
            ToolTipInformation.IsBalloon = true;
            ToolTipInformation.ReshowDelay = 50;
            ToolTipInformation.ToolTipTitle = "What does this do?";
            // 
            // TitleText
            // 
            TitleText.Font = new System.Drawing.Font("Segoe UI", 16F);
            TitleText.Location = new System.Drawing.Point(105, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(400, 30);
            TitleText.TabIndex = 23;
            TitleText.Text = "See you next time!";
            // 
            // LogoBox
            // 
            LogoBox.Image = Properties.Resources.WarningApp;
            LogoBox.Location = new System.Drawing.Point(9, 9);
            LogoBox.Margin = new System.Windows.Forms.Padding(0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new System.Drawing.Size(96, 96);
            LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            LogoBox.TabIndex = 22;
            LogoBox.TabStop = false;
            // 
            // DescriptionLinkText
            // 
            DescriptionLinkText.Font = new System.Drawing.Font("Segoe UI", 12F);
            DescriptionLinkText.LinkArea = new System.Windows.Forms.LinkArea(93, 20);
            DescriptionLinkText.LinkColor = System.Drawing.Color.Cyan;
            DescriptionLinkText.Location = new System.Drawing.Point(108, 39);
            DescriptionLinkText.Margin = new System.Windows.Forms.Padding(0);
            DescriptionLinkText.Name = "DescriptionLinkText";
            DescriptionLinkText.Size = new System.Drawing.Size(327, 66);
            DescriptionLinkText.TabIndex = 27;
            DescriptionLinkText.TabStop = true;
            DescriptionLinkText.Text = "We hope you were able to get the fullest experience out of SharpAlert. Find more software at https://bunnytub.com!";
            DescriptionLinkText.UseCompatibleTextRendering = true;
            DescriptionLinkText.LinkClicked += DescriptionLinkText_LinkClicked;
            // 
            // AutoCloseProgress
            // 
            AutoCloseProgress.Location = new System.Drawing.Point(9, 124);
            AutoCloseProgress.Maximum = 30;
            AutoCloseProgress.Name = "AutoCloseProgress";
            AutoCloseProgress.Size = new System.Drawing.Size(351, 23);
            AutoCloseProgress.Step = 1;
            AutoCloseProgress.TabIndex = 28;
            // 
            // AutoClose
            // 
            AutoClose.Enabled = true;
            AutoClose.Interval = 1000;
            AutoClose.Tick += AutoClose_Tick;
            // 
            // UninstallingForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(444, 156);
            ControlBox = false;
            Controls.Add(AutoCloseProgress);
            Controls.Add(DescriptionLinkText);
            Controls.Add(TitleText);
            Controls.Add(LogoBox);
            Controls.Add(DoneButton);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UninstallingForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Uninstaller";
            TopMost = true;
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.LinkLabel DescriptionLinkText;
        private System.Windows.Forms.ProgressBar AutoCloseProgress;
        private System.Windows.Forms.Timer AutoClose;
    }
}
