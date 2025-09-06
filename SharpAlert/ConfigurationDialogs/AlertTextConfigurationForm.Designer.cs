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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertTextConfigurationForm));
            this.DoneButton = new System.Windows.Forms.Button();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.AddAlertEffectiveAndEndingTimesBox = new System.Windows.Forms.CheckBox();
            this.AddAlertIssuerBox = new System.Windows.Forms.CheckBox();
            this.AddIntroTextBox = new System.Windows.Forms.CheckBox();
            this.UpdateTextField = new System.Windows.Forms.Timer(this.components);
            this.AddSourcedFromBox = new System.Windows.Forms.CheckBox();
            this.AddEventNameBox = new System.Windows.Forms.CheckBox();
            this.Use24HrTimeBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneButton.Location = new System.Drawing.Point(420, 187);
            this.DoneButton.Margin = new System.Windows.Forms.Padding(0);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(72, 23);
            this.DoneButton.TabIndex = 0;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = false;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // LogoBox
            // 
            this.LogoBox.Image = global::SharpAlert.Properties.Resources.WarningApp;
            this.LogoBox.Location = new System.Drawing.Point(9, 9);
            this.LogoBox.Margin = new System.Windows.Forms.Padding(0);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(96, 96);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoBox.TabIndex = 1;
            this.LogoBox.TabStop = false;
            // 
            // TitleText
            // 
            this.TitleText.Font = new System.Drawing.Font("Arial", 16F);
            this.TitleText.Location = new System.Drawing.Point(105, 9);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(400, 30);
            this.TitleText.TabIndex = 0;
            this.TitleText.Text = "Choose your alert text settings.";
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
            // AddAlertEffectiveAndEndingTimesBox
            // 
            this.AddAlertEffectiveAndEndingTimesBox.AutoSize = true;
            this.AddAlertEffectiveAndEndingTimesBox.Location = new System.Drawing.Point(110, 67);
            this.AddAlertEffectiveAndEndingTimesBox.Name = "AddAlertEffectiveAndEndingTimesBox";
            this.AddAlertEffectiveAndEndingTimesBox.Size = new System.Drawing.Size(205, 19);
            this.AddAlertEffectiveAndEndingTimesBox.TabIndex = 3;
            this.AddAlertEffectiveAndEndingTimesBox.Text = "Include the \"Effective/Ending\" text";
            this.ToolTipInformation.SetToolTip(this.AddAlertEffectiveAndEndingTimesBox, "Effective/Ending times of the current alert.");
            this.AddAlertEffectiveAndEndingTimesBox.UseVisualStyleBackColor = true;
            // 
            // AddAlertIssuerBox
            // 
            this.AddAlertIssuerBox.AutoSize = true;
            this.AddAlertIssuerBox.Location = new System.Drawing.Point(110, 92);
            this.AddAlertIssuerBox.Name = "AddAlertIssuerBox";
            this.AddAlertIssuerBox.Size = new System.Drawing.Size(171, 19);
            this.AddAlertIssuerBox.TabIndex = 4;
            this.AddAlertIssuerBox.Text = "Include the \"Issued by\" text";
            this.ToolTipInformation.SetToolTip(this.AddAlertIssuerBox, "The issuer of the current alert.");
            this.AddAlertIssuerBox.UseVisualStyleBackColor = true;
            // 
            // AddIntroTextBox
            // 
            this.AddIntroTextBox.AutoSize = true;
            this.AddIntroTextBox.Location = new System.Drawing.Point(110, 42);
            this.AddIntroTextBox.Name = "AddIntroTextBox";
            this.AddIntroTextBox.Size = new System.Drawing.Size(121, 19);
            this.AddIntroTextBox.TabIndex = 2;
            this.AddIntroTextBox.Text = "Prepend intro text";
            this.ToolTipInformation.SetToolTip(this.AddIntroTextBox, resources.GetString("AddIntroTextBox.ToolTip"));
            this.AddIntroTextBox.UseVisualStyleBackColor = true;
            // 
            // UpdateTextField
            // 
            this.UpdateTextField.Enabled = true;
            this.UpdateTextField.Interval = 1000;
            this.UpdateTextField.Tick += new System.EventHandler(this.UpdateTextField_Tick);
            // 
            // AddSourcedFromBox
            // 
            this.AddSourcedFromBox.AutoSize = true;
            this.AddSourcedFromBox.Location = new System.Drawing.Point(110, 117);
            this.AddSourcedFromBox.Name = "AddSourcedFromBox";
            this.AddSourcedFromBox.Size = new System.Drawing.Size(192, 19);
            this.AddSourcedFromBox.TabIndex = 7;
            this.AddSourcedFromBox.Text = "Include the \"Sourced from\" text";
            this.ToolTipInformation.SetToolTip(this.AddSourcedFromBox, "The source of the current alert.");
            this.AddSourcedFromBox.UseVisualStyleBackColor = true;
            // 
            // AddEventNameBox
            // 
            this.AddEventNameBox.AutoSize = true;
            this.AddEventNameBox.Location = new System.Drawing.Point(110, 142);
            this.AddEventNameBox.Name = "AddEventNameBox";
            this.AddEventNameBox.Size = new System.Drawing.Size(153, 19);
            this.AddEventNameBox.TabIndex = 8;
            this.AddEventNameBox.Text = "Include the event name";
            this.ToolTipInformation.SetToolTip(this.AddEventNameBox, "The event of the current alert.");
            this.AddEventNameBox.UseVisualStyleBackColor = true;
            // 
            // Use24HrTimeBox
            // 
            this.Use24HrTimeBox.AutoSize = true;
            this.Use24HrTimeBox.Location = new System.Drawing.Point(110, 167);
            this.Use24HrTimeBox.Name = "Use24HrTimeBox";
            this.Use24HrTimeBox.Size = new System.Drawing.Size(250, 19);
            this.Use24HrTimeBox.TabIndex = 9;
            this.Use24HrTimeBox.Text = "Use 24 hour time instead of 12 hour time";
            this.ToolTipInformation.SetToolTip(this.Use24HrTimeBox, "The event of the current alert.");
            this.Use24HrTimeBox.UseVisualStyleBackColor = true;
            // 
            // AlertTextConfigurationForm
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(501, 219);
            this.Controls.Add(this.Use24HrTimeBox);
            this.Controls.Add(this.AddEventNameBox);
            this.Controls.Add(this.AddSourcedFromBox);
            this.Controls.Add(this.AddIntroTextBox);
            this.Controls.Add(this.AddAlertIssuerBox);
            this.Controls.Add(this.AddAlertEffectiveAndEndingTimesBox);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.LogoBox);
            this.Controls.Add(this.DoneButton);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertTextConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Alert Text Customization";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ChooseRegionForm_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseRegionForm_FormClosing);
            this.Load += new System.EventHandler(this.ChooseRegionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}
