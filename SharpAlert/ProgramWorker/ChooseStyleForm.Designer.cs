namespace SharpAlert
{
    partial class ChooseStyleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseStyleForm));
            this.DoneButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.alertTimeZoneUTCBox = new System.Windows.Forms.CheckBox();
            this.alertCompatibilityModeBox = new System.Windows.Forms.CheckBox();
            this.alertTimeoutInput = new System.Windows.Forms.NumericUpDown();
            this.alertFullscreenDisplayInput = new System.Windows.Forms.NumericUpDown();
            this.alertFullscreenIdleBox = new System.Windows.Forms.CheckBox();
            this.alertFullscreenWindowedBox = new System.Windows.Forms.CheckBox();
            this.alertTTSonlyBox = new System.Windows.Forms.CheckBox();
            this.alertIncreaseSizeBox = new System.Windows.Forms.CheckBox();
            this.alertNoGUIBox = new System.Windows.Forms.CheckBox();
            this.AlertFullscreenCombo = new System.Windows.Forms.ComboBox();
            this.WindowLocationCombo = new System.Windows.Forms.ComboBox();
            this.alertPlayStartToneTwiceBox = new System.Windows.Forms.CheckBox();
            this.statusWindowBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertTimeoutInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertFullscreenDisplayInput)).BeginInit();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneButton.Location = new System.Drawing.Point(451, 193);
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
            this.TitleText.TabIndex = 3;
            this.TitleText.Text = "Choose your style settings.";
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
            // alertTimeZoneUTCBox
            // 
            this.alertTimeZoneUTCBox.AutoSize = true;
            this.alertTimeZoneUTCBox.Location = new System.Drawing.Point(214, 92);
            this.alertTimeZoneUTCBox.Name = "alertTimeZoneUTCBox";
            this.alertTimeZoneUTCBox.Size = new System.Drawing.Size(77, 19);
            this.alertTimeZoneUTCBox.TabIndex = 7;
            this.alertTimeZoneUTCBox.Text = "Use UTC";
            this.ToolTipInformation.SetToolTip(this.alertTimeZoneUTCBox, "Uses UTC visually everywhere instead of the system time zone.\r\nAlert text may not" +
        " be affected by this setting.");
            this.alertTimeZoneUTCBox.UseVisualStyleBackColor = true;
            // 
            // alertCompatibilityModeBox
            // 
            this.alertCompatibilityModeBox.AutoSize = true;
            this.alertCompatibilityModeBox.Location = new System.Drawing.Point(214, 117);
            this.alertCompatibilityModeBox.Name = "alertCompatibilityModeBox";
            this.alertCompatibilityModeBox.Size = new System.Drawing.Size(132, 19);
            this.alertCompatibilityModeBox.TabIndex = 8;
            this.alertCompatibilityModeBox.Text = "Compatibility mode";
            this.ToolTipInformation.SetToolTip(this.alertCompatibilityModeBox, "Disables most animations and some background stuff. May help performance on older" +
        " systems.");
            this.alertCompatibilityModeBox.UseVisualStyleBackColor = true;
            // 
            // alertTimeoutInput
            // 
            this.alertTimeoutInput.Location = new System.Drawing.Point(168, 113);
            this.alertTimeoutInput.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.alertTimeoutInput.Name = "alertTimeoutInput";
            this.alertTimeoutInput.Size = new System.Drawing.Size(37, 21);
            this.alertTimeoutInput.TabIndex = 3;
            this.ToolTipInformation.SetToolTip(this.alertTimeoutInput, "The amount of time (in minutes) until an alert automatically closes itself.");
            this.alertTimeoutInput.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // alertFullscreenDisplayInput
            // 
            this.alertFullscreenDisplayInput.Location = new System.Drawing.Point(168, 86);
            this.alertFullscreenDisplayInput.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.alertFullscreenDisplayInput.Name = "alertFullscreenDisplayInput";
            this.alertFullscreenDisplayInput.Size = new System.Drawing.Size(37, 21);
            this.alertFullscreenDisplayInput.TabIndex = 2;
            this.ToolTipInformation.SetToolTip(this.alertFullscreenDisplayInput, "The screen to display the alert and idle panels on.");
            // 
            // alertFullscreenIdleBox
            // 
            this.alertFullscreenIdleBox.AutoSize = true;
            this.alertFullscreenIdleBox.Location = new System.Drawing.Point(214, 42);
            this.alertFullscreenIdleBox.Name = "alertFullscreenIdleBox";
            this.alertFullscreenIdleBox.Size = new System.Drawing.Size(80, 19);
            this.alertFullscreenIdleBox.TabIndex = 5;
            this.alertFullscreenIdleBox.Text = "Idle panel";
            this.ToolTipInformation.SetToolTip(this.alertFullscreenIdleBox, "Shows an idle panel on top of all content.");
            this.alertFullscreenIdleBox.UseVisualStyleBackColor = true;
            // 
            // alertFullscreenWindowedBox
            // 
            this.alertFullscreenWindowedBox.AutoSize = true;
            this.alertFullscreenWindowedBox.Location = new System.Drawing.Point(214, 142);
            this.alertFullscreenWindowedBox.Name = "alertFullscreenWindowedBox";
            this.alertFullscreenWindowedBox.Size = new System.Drawing.Size(157, 19);
            this.alertFullscreenWindowedBox.TabIndex = 9;
            this.alertFullscreenWindowedBox.Text = "Enable window controls";
            this.ToolTipInformation.SetToolTip(this.alertFullscreenWindowedBox, "Enables titlebar window controls for alert panels.");
            this.alertFullscreenWindowedBox.UseVisualStyleBackColor = true;
            // 
            // alertTTSonlyBox
            // 
            this.alertTTSonlyBox.AutoSize = true;
            this.alertTTSonlyBox.Location = new System.Drawing.Point(214, 167);
            this.alertTTSonlyBox.Name = "alertTTSonlyBox";
            this.alertTTSonlyBox.Size = new System.Drawing.Size(159, 19);
            this.alertTTSonlyBox.TabIndex = 10;
            this.alertTTSonlyBox.Text = "Never play remote audio";
            this.ToolTipInformation.SetToolTip(this.alertTTSonlyBox, "Turn off requests for remote audio. Only plays TTS.");
            this.alertTTSonlyBox.UseVisualStyleBackColor = true;
            // 
            // alertIncreaseSizeBox
            // 
            this.alertIncreaseSizeBox.AutoSize = true;
            this.alertIncreaseSizeBox.Location = new System.Drawing.Point(387, 67);
            this.alertIncreaseSizeBox.Name = "alertIncreaseSizeBox";
            this.alertIncreaseSizeBox.Size = new System.Drawing.Size(106, 19);
            this.alertIncreaseSizeBox.TabIndex = 12;
            this.alertIncreaseSizeBox.Text = "Large font size";
            this.ToolTipInformation.SetToolTip(this.alertIncreaseSizeBox, "Increases the font size of alert text.");
            this.alertIncreaseSizeBox.UseVisualStyleBackColor = true;
            // 
            // alertNoGUIBox
            // 
            this.alertNoGUIBox.AutoSize = true;
            this.alertNoGUIBox.Location = new System.Drawing.Point(387, 42);
            this.alertNoGUIBox.Name = "alertNoGUIBox";
            this.alertNoGUIBox.Size = new System.Drawing.Size(98, 19);
            this.alertNoGUIBox.TabIndex = 11;
            this.alertNoGUIBox.Text = "Console only";
            this.ToolTipInformation.SetToolTip(this.alertNoGUIBox, "All alert functions are done through the console, and no dialogs are shown.\r\nAler" +
        "ts cannot be interrupted or cancelled when this option is enabled.");
            this.alertNoGUIBox.UseVisualStyleBackColor = true;
            // 
            // AlertFullscreenCombo
            // 
            this.AlertFullscreenCombo.BackColor = System.Drawing.Color.Black;
            this.AlertFullscreenCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlertFullscreenCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AlertFullscreenCombo.ForeColor = System.Drawing.Color.White;
            this.AlertFullscreenCombo.FormattingEnabled = true;
            this.AlertFullscreenCombo.Location = new System.Drawing.Point(110, 57);
            this.AlertFullscreenCombo.Name = "AlertFullscreenCombo";
            this.AlertFullscreenCombo.Size = new System.Drawing.Size(95, 23);
            this.AlertFullscreenCombo.TabIndex = 1;
            this.ToolTipInformation.SetToolTip(this.AlertFullscreenCombo, "Choose how alerts are displayed.");
            // 
            // WindowLocationCombo
            // 
            this.WindowLocationCombo.BackColor = System.Drawing.Color.Black;
            this.WindowLocationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.WindowLocationCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WindowLocationCombo.ForeColor = System.Drawing.Color.White;
            this.WindowLocationCombo.FormattingEnabled = true;
            this.WindowLocationCombo.Location = new System.Drawing.Point(110, 162);
            this.WindowLocationCombo.Name = "WindowLocationCombo";
            this.WindowLocationCombo.Size = new System.Drawing.Size(95, 23);
            this.WindowLocationCombo.TabIndex = 4;
            this.ToolTipInformation.SetToolTip(this.WindowLocationCombo, "Choose where on the screen alerts are displayed.\r\nThis option only affects some d" +
        "isplay styles.");
            // 
            // alertPlayStartToneTwiceBox
            // 
            this.alertPlayStartToneTwiceBox.AutoSize = true;
            this.alertPlayStartToneTwiceBox.Location = new System.Drawing.Point(387, 92);
            this.alertPlayStartToneTwiceBox.Name = "alertPlayStartToneTwiceBox";
            this.alertPlayStartToneTwiceBox.Size = new System.Drawing.Size(117, 19);
            this.alertPlayStartToneTwiceBox.TabIndex = 13;
            this.alertPlayStartToneTwiceBox.Text = "Extend alert tone";
            this.ToolTipInformation.SetToolTip(this.alertPlayStartToneTwiceBox, "Extends the start tone by instructing the audio stack to play it twice.");
            this.alertPlayStartToneTwiceBox.UseVisualStyleBackColor = true;
            this.alertPlayStartToneTwiceBox.Visible = false;
            // 
            // statusWindowBox
            // 
            this.statusWindowBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.statusWindowBox.AutoSize = true;
            this.statusWindowBox.Location = new System.Drawing.Point(214, 67);
            this.statusWindowBox.Name = "statusWindowBox";
            this.statusWindowBox.Size = new System.Drawing.Size(106, 19);
            this.statusWindowBox.TabIndex = 6;
            this.statusWindowBox.Text = "Status window";
            this.ToolTipInformation.SetToolTip(this.statusWindowBox, "Shows the status window.");
            this.statusWindowBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(9, 190);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "To change these options later, go to Settings.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(108, 115);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 15);
            this.label9.TabIndex = 34;
            this.label9.Text = "Timeout";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(107, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Display style";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(108, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 37;
            this.label8.Text = "Screen";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(107, 144);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 39;
            this.label11.Text = "Display where";
            // 
            // ChooseStyleForm
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(532, 225);
            this.Controls.Add(this.statusWindowBox);
            this.Controls.Add(this.alertPlayStartToneTwiceBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.WindowLocationCombo);
            this.Controls.Add(this.alertIncreaseSizeBox);
            this.Controls.Add(this.alertNoGUIBox);
            this.Controls.Add(this.alertTTSonlyBox);
            this.Controls.Add(this.alertFullscreenWindowedBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AlertFullscreenCombo);
            this.Controls.Add(this.alertTimeZoneUTCBox);
            this.Controls.Add(this.alertCompatibilityModeBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.alertTimeoutInput);
            this.Controls.Add(this.alertFullscreenDisplayInput);
            this.Controls.Add(this.alertFullscreenIdleBox);
            this.Controls.Add(this.label1);
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
            this.Name = "ChooseStyleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Style Selection";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ChooseRegionForm_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseRegionForm_FormClosing);
            this.Load += new System.EventHandler(this.ChooseRegionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertTimeoutInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alertFullscreenDisplayInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AlertFullscreenCombo;
        private System.Windows.Forms.CheckBox alertTimeZoneUTCBox;
        private System.Windows.Forms.CheckBox alertCompatibilityModeBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown alertTimeoutInput;
        private System.Windows.Forms.NumericUpDown alertFullscreenDisplayInput;
        private System.Windows.Forms.CheckBox alertFullscreenIdleBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox alertFullscreenWindowedBox;
        private System.Windows.Forms.CheckBox alertTTSonlyBox;
        private System.Windows.Forms.CheckBox alertIncreaseSizeBox;
        private System.Windows.Forms.CheckBox alertNoGUIBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox WindowLocationCombo;
        private System.Windows.Forms.CheckBox alertPlayStartToneTwiceBox;
        private System.Windows.Forms.CheckBox statusWindowBox;
    }
}