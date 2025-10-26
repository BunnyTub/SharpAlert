namespace SharpAlert.ConfigurationDialogs
{
    partial class DoNotDisturbForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoNotDisturbForm));
            LogoBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            OneDayStopButton = new System.Windows.Forms.Button();
            TwoHourStopButton = new System.Windows.Forms.Button();
            FiniteStopButton = new System.Windows.Forms.Button();
            OneHourStopButton = new System.Windows.Forms.Button();
            RelayIgnoredAlertsAfterDND = new System.Windows.Forms.CheckBox();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
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
            LogoBox.Click += LogoBox_Click;
            // 
            // TitleText
            // 
            TitleText.Font = new System.Drawing.Font("Segoe UI", 14F);
            TitleText.Location = new System.Drawing.Point(105, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(533, 53);
            TitleText.TabIndex = 3;
            TitleText.Text = "How long do you want to enable Do Not Disturb?\r\nDND prevents any alerts from being processed.";
            // 
            // OneDayStopButton
            // 
            OneDayStopButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            OneDayStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            OneDayStopButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            OneDayStopButton.ForeColor = System.Drawing.Color.White;
            OneDayStopButton.Location = new System.Drawing.Point(376, 65);
            OneDayStopButton.Name = "OneDayStopButton";
            OneDayStopButton.Size = new System.Drawing.Size(128, 40);
            OneDayStopButton.TabIndex = 6;
            OneDayStopButton.Text = "24 hours";
            ToolTipInformation.SetToolTip(OneDayStopButton, "Enable DND for 1 day.");
            OneDayStopButton.UseMnemonic = false;
            OneDayStopButton.UseVisualStyleBackColor = false;
            OneDayStopButton.Click += OneDayStopButton_Click;
            // 
            // TwoHourStopButton
            // 
            TwoHourStopButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            TwoHourStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            TwoHourStopButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            TwoHourStopButton.ForeColor = System.Drawing.Color.White;
            TwoHourStopButton.Location = new System.Drawing.Point(242, 65);
            TwoHourStopButton.Name = "TwoHourStopButton";
            TwoHourStopButton.Size = new System.Drawing.Size(128, 40);
            TwoHourStopButton.TabIndex = 5;
            TwoHourStopButton.Text = "120 minutes";
            ToolTipInformation.SetToolTip(TwoHourStopButton, "Enable DND for 2 hours.");
            TwoHourStopButton.UseMnemonic = false;
            TwoHourStopButton.UseVisualStyleBackColor = false;
            TwoHourStopButton.Click += TwoHourStopButton_Click;
            // 
            // FiniteStopButton
            // 
            FiniteStopButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            FiniteStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            FiniteStopButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            FiniteStopButton.ForeColor = System.Drawing.Color.White;
            FiniteStopButton.Location = new System.Drawing.Point(510, 65);
            FiniteStopButton.Name = "FiniteStopButton";
            FiniteStopButton.Size = new System.Drawing.Size(128, 40);
            FiniteStopButton.TabIndex = 7;
            FiniteStopButton.Text = "Until forever";
            ToolTipInformation.SetToolTip(FiniteStopButton, "Enable DND until I choose to disable it.");
            FiniteStopButton.UseMnemonic = false;
            FiniteStopButton.UseVisualStyleBackColor = false;
            FiniteStopButton.Click += FiniteStopButton_Click;
            // 
            // OneHourStopButton
            // 
            OneHourStopButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            OneHourStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            OneHourStopButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            OneHourStopButton.ForeColor = System.Drawing.Color.White;
            OneHourStopButton.Location = new System.Drawing.Point(108, 65);
            OneHourStopButton.Name = "OneHourStopButton";
            OneHourStopButton.Size = new System.Drawing.Size(128, 40);
            OneHourStopButton.TabIndex = 4;
            OneHourStopButton.Text = "60 minutes";
            ToolTipInformation.SetToolTip(OneHourStopButton, "Enable DND for 1 hour.");
            OneHourStopButton.UseMnemonic = false;
            OneHourStopButton.UseVisualStyleBackColor = false;
            OneHourStopButton.Click += OneHourStopButton_Click;
            // 
            // RelayIgnoredAlertsAfterDND
            // 
            RelayIgnoredAlertsAfterDND.AutoSize = true;
            RelayIgnoredAlertsAfterDND.Location = new System.Drawing.Point(110, 111);
            RelayIgnoredAlertsAfterDND.Name = "RelayIgnoredAlertsAfterDND";
            RelayIgnoredAlertsAfterDND.Size = new System.Drawing.Size(251, 19);
            RelayIgnoredAlertsAfterDND.TabIndex = 8;
            RelayIgnoredAlertsAfterDND.Text = "Relay ignored alerts after DND is turned off";
            ToolTipInformation.SetToolTip(RelayIgnoredAlertsAfterDND, resources.GetString("RelayIgnoredAlertsAfterDND.ToolTip"));
            RelayIgnoredAlertsAfterDND.UseVisualStyleBackColor = true;
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
            // DoNotDisturbForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(650, 142);
            Controls.Add(RelayIgnoredAlertsAfterDND);
            Controls.Add(FiniteStopButton);
            Controls.Add(TwoHourStopButton);
            Controls.Add(OneDayStopButton);
            Controls.Add(OneHourStopButton);
            Controls.Add(TitleText);
            Controls.Add(LogoBox);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            HelpButton = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DoNotDisturbForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Do Not Disturb";
            HelpButtonClicked += DoNotDisturbForm_HelpButtonClicked;
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Button OneDayStopButton;
        private System.Windows.Forms.Button TwoHourStopButton;
        private System.Windows.Forms.Button FiniteStopButton;
        private System.Windows.Forms.Button OneHourStopButton;
        public System.Windows.Forms.CheckBox RelayIgnoredAlertsAfterDND;
        private System.Windows.Forms.ToolTip ToolTipInformation;
    }
}