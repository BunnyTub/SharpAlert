namespace SharpAlert.ProgramWorker
{
    partial class SetupForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            DoneButton = new System.Windows.Forms.Button();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            SideLogoBox = new System.Windows.Forms.PictureBox();
            ExampleBarBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            LogoBox = new System.Windows.Forms.PictureBox();
            label2 = new System.Windows.Forms.Label();
            DescriptionText = new System.Windows.Forms.Label();
            FadeInAnimation = new System.Windows.Forms.Timer(components);
            SkipButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)SideLogoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ExampleBarBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Location = new System.Drawing.Point(518, 257);
            DoneButton.Margin = new System.Windows.Forms.Padding(0);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new System.Drawing.Size(72, 23);
            DoneButton.TabIndex = 15;
            DoneButton.Text = "Next";
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
            // SideLogoBox
            // 
            SideLogoBox.Image = Properties.Resources.V_Sign;
            SideLogoBox.Location = new System.Drawing.Point(12, 9);
            SideLogoBox.Margin = new System.Windows.Forms.Padding(0);
            SideLogoBox.Name = "SideLogoBox";
            SideLogoBox.Size = new System.Drawing.Size(184, 230);
            SideLogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            SideLogoBox.TabIndex = 28;
            SideLogoBox.TabStop = false;
            ToolTipInformation.SetToolTip(SideLogoBox, "Click me! >w<");
            SideLogoBox.Click += SideLogoBox_Click;
            // 
            // ExampleBarBox
            // 
            ExampleBarBox.Image = Properties.Resources.TaskBarExample;
            ExampleBarBox.Location = new System.Drawing.Point(199, 174);
            ExampleBarBox.Margin = new System.Windows.Forms.Padding(0);
            ExampleBarBox.Name = "ExampleBarBox";
            ExampleBarBox.Size = new System.Drawing.Size(394, 47);
            ExampleBarBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            ExampleBarBox.TabIndex = 29;
            ExampleBarBox.TabStop = false;
            ToolTipInformation.SetToolTip(ExampleBarBox, "This is an example image of SharpAlert's task tray icon on the taskbar.");
            // 
            // TitleText
            // 
            TitleText.Font = new System.Drawing.Font("Segoe UI", 16F);
            TitleText.Location = new System.Drawing.Point(196, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(394, 30);
            TitleText.TabIndex = 23;
            TitleText.Text = "Welcome to SharpAlert!";
            // 
            // LogoBox
            // 
            LogoBox.Image = Properties.Resources.WarningApp;
            LogoBox.Location = new System.Drawing.Point(40, 21);
            LogoBox.Margin = new System.Windows.Forms.Padding(0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new System.Drawing.Size(48, 48);
            LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            LogoBox.TabIndex = 22;
            LogoBox.TabStop = false;
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            label2.Location = new System.Drawing.Point(9, 239);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(342, 41);
            label2.TabIndex = 26;
            label2.Text = "To go through the setup more than once, reset the program.\r\nCreated by BunnyTub. More credits can be found in Settings.";
            label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // DescriptionText
            // 
            DescriptionText.Font = new System.Drawing.Font("Segoe UI", 12F);
            DescriptionText.Location = new System.Drawing.Point(199, 39);
            DescriptionText.Margin = new System.Windows.Forms.Padding(0);
            DescriptionText.Name = "DescriptionText";
            DescriptionText.Size = new System.Drawing.Size(391, 207);
            DescriptionText.TabIndex = 27;
            DescriptionText.Text = resources.GetString("DescriptionText.Text");
            // 
            // FadeInAnimation
            // 
            FadeInAnimation.Interval = 12;
            FadeInAnimation.Tick += FadeInAnimation_Tick;
            // 
            // SkipButton
            // 
            SkipButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            SkipButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SkipButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SkipButton.Location = new System.Drawing.Point(443, 257);
            SkipButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            SkipButton.Name = "SkipButton";
            SkipButton.Size = new System.Drawing.Size(72, 23);
            SkipButton.TabIndex = 30;
            SkipButton.Text = "Skip";
            SkipButton.UseVisualStyleBackColor = false;
            SkipButton.Click += SkipButton_Click;
            // 
            // SetupForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(599, 289);
            ControlBox = false;
            Controls.Add(SkipButton);
            Controls.Add(ExampleBarBox);
            Controls.Add(DescriptionText);
            Controls.Add(TitleText);
            Controls.Add(label2);
            Controls.Add(DoneButton);
            Controls.Add(LogoBox);
            Controls.Add(SideLogoBox);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetupForm";
            Opacity = 0D;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Setup";
            TopMost = true;
            Load += SetupForm_Load;
            Shown += SetupForm_Shown;
            ((System.ComponentModel.ISupportInitialize)SideLogoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)ExampleBarBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label DescriptionText;
        private System.Windows.Forms.Timer FadeInAnimation;
        private System.Windows.Forms.PictureBox SideLogoBox;
        private System.Windows.Forms.PictureBox ExampleBarBox;
        private System.Windows.Forms.Button SkipButton;
    }
}
