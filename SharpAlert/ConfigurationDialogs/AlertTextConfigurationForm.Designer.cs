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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.AddAlertEffectiveAndEndingTimesBox = new System.Windows.Forms.CheckBox();
            this.AddAlertIssuerBox = new System.Windows.Forms.CheckBox();
            this.AddIntroTextBox = new System.Windows.Forms.CheckBox();
            this.UpdateTextField = new System.Windows.Forms.Timer(this.components);
            this.RemoveNWSDescCodeBox = new System.Windows.Forms.CheckBox();
            this.RemoveNWSNewLinesBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SharpAlert.Properties.Resources.WarningApp;
            this.pictureBox1.Location = new System.Drawing.Point(9, 9);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(96, 96);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
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
            // RemoveNWSDescCodeBox
            // 
            this.RemoveNWSDescCodeBox.AutoSize = true;
            this.RemoveNWSDescCodeBox.Location = new System.Drawing.Point(110, 117);
            this.RemoveNWSDescCodeBox.Name = "RemoveNWSDescCodeBox";
            this.RemoveNWSDescCodeBox.Size = new System.Drawing.Size(327, 19);
            this.RemoveNWSDescCodeBox.TabIndex = 5;
            this.RemoveNWSDescCodeBox.Text = "Attempt to remove 6 character short code in NWS alerts";
            this.ToolTipInformation.SetToolTip(this.RemoveNWSDescCodeBox, resources.GetString("RemoveNWSDescCodeBox.ToolTip"));
            this.RemoveNWSDescCodeBox.UseVisualStyleBackColor = true;
            // 
            // RemoveNWSNewLinesBox
            // 
            this.RemoveNWSNewLinesBox.AutoSize = true;
            this.RemoveNWSNewLinesBox.Location = new System.Drawing.Point(110, 142);
            this.RemoveNWSNewLinesBox.Name = "RemoveNWSNewLinesBox";
            this.RemoveNWSNewLinesBox.Size = new System.Drawing.Size(323, 19);
            this.RemoveNWSNewLinesBox.TabIndex = 6;
            this.RemoveNWSNewLinesBox.Text = "Forcefully remove all newline characters in NWS alerts";
            this.ToolTipInformation.SetToolTip(this.RemoveNWSNewLinesBox, "Removes newline characters anywhere in the alert text, and splices everything tog" +
        "ether with spaces.");
            this.RemoveNWSNewLinesBox.UseVisualStyleBackColor = true;
            // 
            // AlertTextConfigurationForm
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(501, 219);
            this.Controls.Add(this.RemoveNWSNewLinesBox);
            this.Controls.Add(this.RemoveNWSDescCodeBox);
            this.Controls.Add(this.AddIntroTextBox);
            this.Controls.Add(this.AddAlertIssuerBox);
            this.Controls.Add(this.AddAlertEffectiveAndEndingTimesBox);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.pictureBox1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.CheckBox AddAlertEffectiveAndEndingTimesBox;
        private System.Windows.Forms.Timer UpdateTextField;
        private System.Windows.Forms.CheckBox AddAlertIssuerBox;
        private System.Windows.Forms.CheckBox AddIntroTextBox;
        private System.Windows.Forms.CheckBox RemoveNWSDescCodeBox;
        private System.Windows.Forms.CheckBox RemoveNWSNewLinesBox;
    }
}
