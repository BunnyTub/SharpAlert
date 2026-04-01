namespace SharpAlert.ConfigurationDialogs
{
    partial class AlertTextConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertTextConfigurationForm));
            DoneButton = new System.Windows.Forms.Button();
            LogoBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            AddAlertEffectiveAndEndingTimesBox = new System.Windows.Forms.CheckBox();
            AddAlertIssuerBox = new System.Windows.Forms.CheckBox();
            AddIntroTextBox = new System.Windows.Forms.CheckBox();
            AddSourcedFromBox = new System.Windows.Forms.CheckBox();
            AddEventNameBox = new System.Windows.Forms.CheckBox();
            Use24HrTimeBox = new System.Windows.Forms.CheckBox();
            alertTimeZoneUTCBox = new System.Windows.Forms.CheckBox();
            UpdateTextField = new System.Windows.Forms.Timer(components);
            WindowShake = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Location = new System.Drawing.Point(420, 216);
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
            TitleText.TabIndex = 0;
            TitleText.Text = "Choose your alert text settings.";
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
            // AddAlertEffectiveAndEndingTimesBox
            // 
            AddAlertEffectiveAndEndingTimesBox.AutoSize = true;
            AddAlertEffectiveAndEndingTimesBox.Location = new System.Drawing.Point(110, 67);
            AddAlertEffectiveAndEndingTimesBox.Name = "AddAlertEffectiveAndEndingTimesBox";
            AddAlertEffectiveAndEndingTimesBox.Size = new System.Drawing.Size(208, 19);
            AddAlertEffectiveAndEndingTimesBox.TabIndex = 3;
            AddAlertEffectiveAndEndingTimesBox.Text = "Include the \"Effective/Ending\" text";
            ToolTipInformation.SetToolTip(AddAlertEffectiveAndEndingTimesBox, "Effective/Ending times of the current alert.");
            AddAlertEffectiveAndEndingTimesBox.UseVisualStyleBackColor = true;
            // 
            // AddAlertIssuerBox
            // 
            AddAlertIssuerBox.AutoSize = true;
            AddAlertIssuerBox.Location = new System.Drawing.Point(110, 92);
            AddAlertIssuerBox.Name = "AddAlertIssuerBox";
            AddAlertIssuerBox.Size = new System.Drawing.Size(170, 19);
            AddAlertIssuerBox.TabIndex = 4;
            AddAlertIssuerBox.Text = "Include the \"Issued by\" text";
            ToolTipInformation.SetToolTip(AddAlertIssuerBox, "The issuer of the current alert.");
            AddAlertIssuerBox.UseVisualStyleBackColor = true;
            // 
            // AddIntroTextBox
            // 
            AddIntroTextBox.AutoSize = true;
            AddIntroTextBox.Location = new System.Drawing.Point(110, 42);
            AddIntroTextBox.Name = "AddIntroTextBox";
            AddIntroTextBox.Size = new System.Drawing.Size(121, 19);
            AddIntroTextBox.TabIndex = 2;
            AddIntroTextBox.Text = "Prepend intro text";
            ToolTipInformation.SetToolTip(AddIntroTextBox, resources.GetString("AddIntroTextBox.ToolTip"));
            AddIntroTextBox.UseVisualStyleBackColor = true;
            // 
            // AddSourcedFromBox
            // 
            AddSourcedFromBox.AutoSize = true;
            AddSourcedFromBox.Location = new System.Drawing.Point(110, 117);
            AddSourcedFromBox.Name = "AddSourcedFromBox";
            AddSourcedFromBox.Size = new System.Drawing.Size(193, 19);
            AddSourcedFromBox.TabIndex = 7;
            AddSourcedFromBox.Text = "Include the \"Sourced from\" text";
            ToolTipInformation.SetToolTip(AddSourcedFromBox, "The source of the current alert.");
            AddSourcedFromBox.UseVisualStyleBackColor = true;
            // 
            // AddEventNameBox
            // 
            AddEventNameBox.AutoSize = true;
            AddEventNameBox.Location = new System.Drawing.Point(110, 142);
            AddEventNameBox.Name = "AddEventNameBox";
            AddEventNameBox.Size = new System.Drawing.Size(150, 19);
            AddEventNameBox.TabIndex = 8;
            AddEventNameBox.Text = "Include the event name";
            ToolTipInformation.SetToolTip(AddEventNameBox, "The event of the current alert.");
            AddEventNameBox.UseVisualStyleBackColor = true;
            // 
            // Use24HrTimeBox
            // 
            Use24HrTimeBox.AutoSize = true;
            Use24HrTimeBox.Location = new System.Drawing.Point(110, 167);
            Use24HrTimeBox.Name = "Use24HrTimeBox";
            Use24HrTimeBox.Size = new System.Drawing.Size(240, 19);
            Use24HrTimeBox.TabIndex = 9;
            Use24HrTimeBox.Text = "Use 24 hour time instead of 12 hour time";
            ToolTipInformation.SetToolTip(Use24HrTimeBox, "The event of the current alert.");
            Use24HrTimeBox.UseVisualStyleBackColor = true;
            // 
            // alertTimeZoneUTCBox
            // 
            alertTimeZoneUTCBox.AutoSize = true;
            alertTimeZoneUTCBox.Location = new System.Drawing.Point(110, 192);
            alertTimeZoneUTCBox.Name = "alertTimeZoneUTCBox";
            alertTimeZoneUTCBox.Size = new System.Drawing.Size(226, 19);
            alertTimeZoneUTCBox.TabIndex = 10;
            alertTimeZoneUTCBox.Text = "Use UTC (Coordinated Universal Time)";
            ToolTipInformation.SetToolTip(alertTimeZoneUTCBox, "Uses UTC visually everywhere instead of the system time zone.\r\nAlert text may not be affected by this setting.");
            alertTimeZoneUTCBox.UseVisualStyleBackColor = true;
            // 
            // UpdateTextField
            // 
            UpdateTextField.Enabled = true;
            UpdateTextField.Interval = 1000;
            UpdateTextField.Tick += UpdateTextField_Tick;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // AlertTextConfigurationForm
            // 
            AcceptButton = DoneButton;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(501, 248);
            Controls.Add(alertTimeZoneUTCBox);
            Controls.Add(Use24HrTimeBox);
            Controls.Add(AddEventNameBox);
            Controls.Add(AddSourcedFromBox);
            Controls.Add(AddIntroTextBox);
            Controls.Add(AddAlertIssuerBox);
            Controls.Add(AddAlertEffectiveAndEndingTimesBox);
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
            Name = "AlertTextConfigurationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Alert Text Customization";
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
        private System.Windows.Forms.CheckBox AddAlertEffectiveAndEndingTimesBox;
        private System.Windows.Forms.Timer UpdateTextField;
        private System.Windows.Forms.CheckBox AddAlertIssuerBox;
        private System.Windows.Forms.CheckBox AddIntroTextBox;
        private System.Windows.Forms.CheckBox AddSourcedFromBox;
        private System.Windows.Forms.CheckBox AddEventNameBox;
        private System.Windows.Forms.CheckBox Use24HrTimeBox;
        private System.Windows.Forms.CheckBox alertTimeZoneUTCBox;
        private System.Windows.Forms.Timer WindowShake;
    }
}
