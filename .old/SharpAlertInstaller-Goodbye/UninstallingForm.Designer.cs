namespace SharpAlertInstaller_Goodbye
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
            DoneButton = new Button();
            ToolTipInformation = new ToolTip(components);
            TitleText = new Label();
            LogoBox = new PictureBox();
            DescriptionLinkText = new LinkLabel();
            AutoCloseProgress = new ProgressBar();
            AutoClose = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            DoneButton.BackColor = Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = FlatStyle.Popup;
            DoneButton.Location = new Point(363, 124);
            DoneButton.Margin = new Padding(0);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new Size(72, 23);
            DoneButton.TabIndex = 15;
            DoneButton.Text = "Okay";
            DoneButton.UseVisualStyleBackColor = false;
            DoneButton.Click += DoneButton_Click;
            // 
            // ToolTipInformation
            // 
            ToolTipInformation.AutomaticDelay = 250;
            ToolTipInformation.AutoPopDelay = 15000;
            ToolTipInformation.BackColor = Color.White;
            ToolTipInformation.ForeColor = Color.Black;
            ToolTipInformation.InitialDelay = 250;
            ToolTipInformation.IsBalloon = true;
            ToolTipInformation.ReshowDelay = 50;
            ToolTipInformation.ToolTipTitle = "What does this do?";
            // 
            // TitleText
            // 
            TitleText.Font = new Font("Segoe UI", 16F);
            TitleText.Location = new Point(105, 9);
            TitleText.Margin = new Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new Size(400, 30);
            TitleText.TabIndex = 23;
            TitleText.Text = "See you next time!";
            // 
            // LogoBox
            // 
            LogoBox.Image = Properties.Resources.WarningApp;
            LogoBox.Location = new Point(9, 9);
            LogoBox.Margin = new Padding(0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new Size(96, 96);
            LogoBox.SizeMode = PictureBoxSizeMode.Zoom;
            LogoBox.TabIndex = 22;
            LogoBox.TabStop = false;
            // 
            // DescriptionLinkText
            // 
            DescriptionLinkText.Font = new Font("Segoe UI", 12F);
            DescriptionLinkText.LinkArea = new LinkArea(93, 20);
            DescriptionLinkText.LinkColor = Color.Cyan;
            DescriptionLinkText.Location = new Point(108, 39);
            DescriptionLinkText.Margin = new Padding(0);
            DescriptionLinkText.Name = "DescriptionLinkText";
            DescriptionLinkText.Size = new Size(327, 66);
            DescriptionLinkText.TabIndex = 27;
            DescriptionLinkText.TabStop = true;
            DescriptionLinkText.Text = "We hope you were able to get the fullest experience out of SharpAlert. Find more software at https://bunnytub.com!";
            DescriptionLinkText.UseCompatibleTextRendering = true;
            DescriptionLinkText.LinkClicked += DescriptionLinkText_LinkClicked;
            // 
            // AutoCloseProgress
            // 
            AutoCloseProgress.Location = new Point(9, 124);
            AutoCloseProgress.Maximum = 30;
            AutoCloseProgress.Name = "AutoCloseProgress";
            AutoCloseProgress.Size = new Size(351, 23);
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
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(20, 20, 20);
            ClientSize = new Size(444, 156);
            ControlBox = false;
            Controls.Add(AutoCloseProgress);
            Controls.Add(DescriptionLinkText);
            Controls.Add(TitleText);
            Controls.Add(LogoBox);
            Controls.Add(DoneButton);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UninstallingForm";
            StartPosition = FormStartPosition.CenterScreen;
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
