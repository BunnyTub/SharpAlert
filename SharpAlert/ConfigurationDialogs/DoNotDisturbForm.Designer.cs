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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DoNotDisturbForm));
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.OneDayStopButton = new System.Windows.Forms.Button();
            this.TwoHourStopButton = new System.Windows.Forms.Button();
            this.FiniteStopButton = new System.Windows.Forms.Button();
            this.OneHourStopButton = new System.Windows.Forms.Button();
            this.RelayIgnoredAlertsAfterDND = new System.Windows.Forms.CheckBox();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LogoBox
            // 
            this.LogoBox.Image = global::SharpAlert.Properties.Resources.WarningApp;
            this.LogoBox.Location = new System.Drawing.Point(9, 9);
            this.LogoBox.Margin = new System.Windows.Forms.Padding(0);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(96, 96);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoBox.TabIndex = 2;
            this.LogoBox.TabStop = false;
            this.LogoBox.Click += new System.EventHandler(this.LogoBox_Click);
            // 
            // TitleText
            // 
            this.TitleText.Font = new System.Drawing.Font("Arial", 16F);
            this.TitleText.Location = new System.Drawing.Point(105, 9);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(533, 53);
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "How long do you want to enable Do Not Disturb?\r\nDND prevents any alerts from bein" +
    "g processed.";
            // 
            // OneDayStopButton
            // 
            this.OneDayStopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.OneDayStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OneDayStopButton.Font = new System.Drawing.Font("Arial", 14F);
            this.OneDayStopButton.ForeColor = System.Drawing.Color.White;
            this.OneDayStopButton.Location = new System.Drawing.Point(376, 65);
            this.OneDayStopButton.Name = "OneDayStopButton";
            this.OneDayStopButton.Size = new System.Drawing.Size(128, 40);
            this.OneDayStopButton.TabIndex = 6;
            this.OneDayStopButton.Text = "24 hours";
            this.ToolTipInformation.SetToolTip(this.OneDayStopButton, "Enable DND for 1 day.");
            this.OneDayStopButton.UseMnemonic = false;
            this.OneDayStopButton.UseVisualStyleBackColor = false;
            this.OneDayStopButton.Click += new System.EventHandler(this.OneDayStopButton_Click);
            // 
            // TwoHourStopButton
            // 
            this.TwoHourStopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.TwoHourStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.TwoHourStopButton.Font = new System.Drawing.Font("Arial", 14F);
            this.TwoHourStopButton.ForeColor = System.Drawing.Color.White;
            this.TwoHourStopButton.Location = new System.Drawing.Point(242, 65);
            this.TwoHourStopButton.Name = "TwoHourStopButton";
            this.TwoHourStopButton.Size = new System.Drawing.Size(128, 40);
            this.TwoHourStopButton.TabIndex = 5;
            this.TwoHourStopButton.Text = "120 minutes";
            this.ToolTipInformation.SetToolTip(this.TwoHourStopButton, "Enable DND for 2 hours.");
            this.TwoHourStopButton.UseMnemonic = false;
            this.TwoHourStopButton.UseVisualStyleBackColor = false;
            this.TwoHourStopButton.Click += new System.EventHandler(this.TwoHourStopButton_Click);
            // 
            // FiniteStopButton
            // 
            this.FiniteStopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.FiniteStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.FiniteStopButton.Font = new System.Drawing.Font("Arial", 14F);
            this.FiniteStopButton.ForeColor = System.Drawing.Color.White;
            this.FiniteStopButton.Location = new System.Drawing.Point(510, 65);
            this.FiniteStopButton.Name = "FiniteStopButton";
            this.FiniteStopButton.Size = new System.Drawing.Size(128, 40);
            this.FiniteStopButton.TabIndex = 7;
            this.FiniteStopButton.Text = "Until forever";
            this.ToolTipInformation.SetToolTip(this.FiniteStopButton, "Enable DND until I choose to disable it.");
            this.FiniteStopButton.UseMnemonic = false;
            this.FiniteStopButton.UseVisualStyleBackColor = false;
            this.FiniteStopButton.Click += new System.EventHandler(this.FiniteStopButton_Click);
            // 
            // OneHourStopButton
            // 
            this.OneHourStopButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.OneHourStopButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.OneHourStopButton.Font = new System.Drawing.Font("Arial", 14F);
            this.OneHourStopButton.ForeColor = System.Drawing.Color.White;
            this.OneHourStopButton.Location = new System.Drawing.Point(108, 65);
            this.OneHourStopButton.Name = "OneHourStopButton";
            this.OneHourStopButton.Size = new System.Drawing.Size(128, 40);
            this.OneHourStopButton.TabIndex = 4;
            this.OneHourStopButton.Text = "60 minutes";
            this.ToolTipInformation.SetToolTip(this.OneHourStopButton, "Enable DND for 1 hour.");
            this.OneHourStopButton.UseMnemonic = false;
            this.OneHourStopButton.UseVisualStyleBackColor = false;
            this.OneHourStopButton.Click += new System.EventHandler(this.OneHourStopButton_Click);
            // 
            // RelayIgnoredAlertsAfterDND
            // 
            this.RelayIgnoredAlertsAfterDND.AutoSize = true;
            this.RelayIgnoredAlertsAfterDND.Location = new System.Drawing.Point(110, 111);
            this.RelayIgnoredAlertsAfterDND.Name = "RelayIgnoredAlertsAfterDND";
            this.RelayIgnoredAlertsAfterDND.Size = new System.Drawing.Size(260, 19);
            this.RelayIgnoredAlertsAfterDND.TabIndex = 8;
            this.RelayIgnoredAlertsAfterDND.Text = "Relay ignored alerts after DND is turned off";
            this.ToolTipInformation.SetToolTip(this.RelayIgnoredAlertsAfterDND, resources.GetString("RelayIgnoredAlertsAfterDND.ToolTip"));
            this.RelayIgnoredAlertsAfterDND.UseVisualStyleBackColor = true;
            // 
            // ToolTipInformation
            // 
            this.ToolTipInformation.AutomaticDelay = 250;
            this.ToolTipInformation.AutoPopDelay = 15000;
            this.ToolTipInformation.BackColor = System.Drawing.Color.White;
            this.ToolTipInformation.ForeColor = System.Drawing.Color.Black;
            this.ToolTipInformation.InitialDelay = 250;
            this.ToolTipInformation.IsBalloon = true;
            this.ToolTipInformation.ReshowDelay = 50;
            this.ToolTipInformation.ToolTipTitle = "What does this do?";
            // 
            // DoNotDisturbForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(650, 142);
            this.Controls.Add(this.RelayIgnoredAlertsAfterDND);
            this.Controls.Add(this.FiniteStopButton);
            this.Controls.Add(this.TwoHourStopButton);
            this.Controls.Add(this.OneDayStopButton);
            this.Controls.Add(this.OneHourStopButton);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.LogoBox);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoNotDisturbForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Do Not Disturb";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.DoNotDisturbForm_HelpButtonClicked);
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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