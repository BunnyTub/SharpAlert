namespace SharpAlert.ConfigurationDialogs
{
    partial class ChooseOwnershipForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseOwnershipForm));
            DoneButton = new System.Windows.Forms.Button();
            LogoBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            StationIdentifierInput = new System.Windows.Forms.TextBox();
            StationNameInput = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            SkipButton = new System.Windows.Forms.Button();
            WindowShake = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Location = new System.Drawing.Point(451, 193);
            DoneButton.Margin = new System.Windows.Forms.Padding(0);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new System.Drawing.Size(72, 23);
            DoneButton.TabIndex = 0;
            DoneButton.Text = "Done";
            DoneButton.UseVisualStyleBackColor = false;
            DoneButton.Click += DoneButton_Click;
            // 
            // LogoBox
            // 
            LogoBox.Image = Properties.Resources.WarningApp;
            LogoBox.Location = new System.Drawing.Point(9, 9);
            LogoBox.Margin = new System.Windows.Forms.Padding(0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new System.Drawing.Size(96, 96);
            LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            LogoBox.TabIndex = 1;
            LogoBox.TabStop = false;
            // 
            // TitleText
            // 
            TitleText.Font = new System.Drawing.Font("Segoe UI", 16F);
            TitleText.Location = new System.Drawing.Point(105, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(400, 30);
            TitleText.TabIndex = 3;
            TitleText.Text = "Make yourself the owner.";
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
            // StationIdentifierInput
            // 
            StationIdentifierInput.BackColor = System.Drawing.Color.Black;
            StationIdentifierInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            StationIdentifierInput.ForeColor = System.Drawing.Color.White;
            StationIdentifierInput.Location = new System.Drawing.Point(108, 92);
            StationIdentifierInput.Name = "StationIdentifierInput";
            StationIdentifierInput.Size = new System.Drawing.Size(170, 23);
            StationIdentifierInput.TabIndex = 37;
            ToolTipInformation.SetToolTip(StationIdentifierInput, "This is your station ID.");
            // 
            // StationNameInput
            // 
            StationNameInput.BackColor = System.Drawing.Color.Black;
            StationNameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            StationNameInput.ForeColor = System.Drawing.Color.White;
            StationNameInput.Location = new System.Drawing.Point(108, 134);
            StationNameInput.Name = "StationNameInput";
            StationNameInput.Size = new System.Drawing.Size(170, 23);
            StationNameInput.TabIndex = 39;
            ToolTipInformation.SetToolTip(StationNameInput, "This is your station's friendly name.");
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(9, 175);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(342, 41);
            label1.TabIndex = 13;
            label1.Text = "To change these options later, go to Settings.";
            label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            label2.Location = new System.Drawing.Point(107, 74);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(94, 15);
            label2.TabIndex = 36;
            label2.Text = "Station Identifier";
            label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F);
            label3.Location = new System.Drawing.Point(107, 116);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(79, 15);
            label3.TabIndex = 38;
            label3.Text = "Station Name";
            label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label4
            // 
            label4.Font = new System.Drawing.Font("Segoe UI", 9F);
            label4.Location = new System.Drawing.Point(108, 39);
            label4.Margin = new System.Windows.Forms.Padding(0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(397, 30);
            label4.TabIndex = 40;
            label4.Text = "If you intend to use SharpAlert for hosting purposes, such as forwarding alerts to a Discord webhook, you can stylize your alerts here.";
            // 
            // SkipButton
            // 
            SkipButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            SkipButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SkipButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SkipButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            SkipButton.Location = new System.Drawing.Point(302, 92);
            SkipButton.Margin = new System.Windows.Forms.Padding(0);
            SkipButton.Name = "SkipButton";
            SkipButton.Size = new System.Drawing.Size(221, 101);
            SkipButton.TabIndex = 41;
            SkipButton.Text = "I do not use SharpAlert\r\nfor hosting purposes\r\nat the moment.";
            SkipButton.UseVisualStyleBackColor = false;
            SkipButton.Click += SkipButton_Click;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // ChooseOwnershipForm
            // 
            AcceptButton = DoneButton;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(532, 225);
            Controls.Add(SkipButton);
            Controls.Add(label4);
            Controls.Add(StationNameInput);
            Controls.Add(label3);
            Controls.Add(StationIdentifierInput);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TitleText);
            Controls.Add(LogoBox);
            Controls.Add(DoneButton);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChooseOwnershipForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Ownership Selection";
            HelpButtonClicked += ChooseRegionForm_HelpButtonClicked;
            FormClosing += ChooseRegionForm_FormClosing;
            Load += ChooseRegionForm_Load;
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox StationIdentifierInput;
        private System.Windows.Forms.TextBox StationNameInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button SkipButton;
        private System.Windows.Forms.Timer WindowShake;
    }
}
