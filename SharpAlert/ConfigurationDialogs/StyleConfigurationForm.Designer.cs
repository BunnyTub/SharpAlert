namespace SharpAlert.ConfigurationDialogs
{
    partial class StyleConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StyleConfigurationForm));
            DoneButton = new System.Windows.Forms.Button();
            LogoBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            alertTimeoutInput = new System.Windows.Forms.NumericUpDown();
            alertFullscreenDisplayInput = new System.Windows.Forms.NumericUpDown();
            alertFullscreenWindowedBox = new System.Windows.Forms.CheckBox();
            alertIncreaseSizeBox = new System.Windows.Forms.CheckBox();
            alertNoGUIBox = new System.Windows.Forms.CheckBox();
            AlertFullscreenCombo = new System.Windows.Forms.ComboBox();
            WindowLocationCombo = new System.Windows.Forms.ComboBox();
            ScrollSpeedBar = new System.Windows.Forms.TrackBar();
            alertFadeTimeBar = new System.Windows.Forms.TrackBar();
            PreviewPicture = new System.Windows.Forms.PictureBox();
            TryForceWindowFocusBox = new System.Windows.Forms.CheckBox();
            ForceCustomFontBox = new System.Windows.Forms.CheckBox();
            CustomFontCombo = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            AlertTextButton = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            DisplayStyleInfoButton = new System.Windows.Forms.Button();
            TextDisplayGroup = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            DisplayWhereInfoButton = new System.Windows.Forms.Button();
            WindowShake = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alertTimeoutInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alertFullscreenDisplayInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ScrollSpeedBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)alertFadeTimeBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PreviewPicture).BeginInit();
            TextDisplayGroup.SuspendLayout();
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Location = new System.Drawing.Point(578, 364);
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
            TitleText.Size = new System.Drawing.Size(504, 30);
            TitleText.TabIndex = 3;
            TitleText.Text = "Choose your style settings.";
            TitleText.Click += TitleText_Click;
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
            // alertTimeoutInput
            // 
            alertTimeoutInput.Location = new System.Drawing.Point(194, 66);
            alertTimeoutInput.Maximum = new decimal(new int[] { 60, 0, 0, 0 });
            alertTimeoutInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            alertTimeoutInput.Name = "alertTimeoutInput";
            alertTimeoutInput.Size = new System.Drawing.Size(37, 23);
            alertTimeoutInput.TabIndex = 3;
            ToolTipInformation.SetToolTip(alertTimeoutInput, "The amount of time (in minutes) until an alert automatically closes itself.");
            alertTimeoutInput.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // alertFullscreenDisplayInput
            // 
            alertFullscreenDisplayInput.Location = new System.Drawing.Point(64, 66);
            alertFullscreenDisplayInput.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            alertFullscreenDisplayInput.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            alertFullscreenDisplayInput.Name = "alertFullscreenDisplayInput";
            alertFullscreenDisplayInput.Size = new System.Drawing.Size(37, 23);
            alertFullscreenDisplayInput.TabIndex = 2;
            ToolTipInformation.SetToolTip(alertFullscreenDisplayInput, "The screen to display the alert and idle panels on.");
            alertFullscreenDisplayInput.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // alertFullscreenWindowedBox
            // 
            alertFullscreenWindowedBox.AutoSize = true;
            alertFullscreenWindowedBox.Location = new System.Drawing.Point(374, 40);
            alertFullscreenWindowedBox.Name = "alertFullscreenWindowedBox";
            alertFullscreenWindowedBox.Size = new System.Drawing.Size(147, 19);
            alertFullscreenWindowedBox.TabIndex = 13;
            alertFullscreenWindowedBox.Text = "Enable titlebar controls";
            ToolTipInformation.SetToolTip(alertFullscreenWindowedBox, "Enables titlebar window controls for alert panels.");
            alertFullscreenWindowedBox.UseVisualStyleBackColor = true;
            // 
            // alertIncreaseSizeBox
            // 
            alertIncreaseSizeBox.AutoSize = true;
            alertIncreaseSizeBox.Location = new System.Drawing.Point(266, 40);
            alertIncreaseSizeBox.Name = "alertIncreaseSizeBox";
            alertIncreaseSizeBox.Size = new System.Drawing.Size(102, 19);
            alertIncreaseSizeBox.TabIndex = 12;
            alertIncreaseSizeBox.Text = "Large font size";
            ToolTipInformation.SetToolTip(alertIncreaseSizeBox, "Increases the font size of alert text.");
            alertIncreaseSizeBox.UseVisualStyleBackColor = true;
            // 
            // alertNoGUIBox
            // 
            alertNoGUIBox.AutoSize = true;
            alertNoGUIBox.Location = new System.Drawing.Point(110, 341);
            alertNoGUIBox.Name = "alertNoGUIBox";
            alertNoGUIBox.Size = new System.Drawing.Size(95, 19);
            alertNoGUIBox.TabIndex = 11;
            alertNoGUIBox.Text = "Console only";
            ToolTipInformation.SetToolTip(alertNoGUIBox, "All alert functions are done through the console, and no dialogs are shown.\r\nAlerts cannot be interrupted or cancelled when this option is enabled.");
            alertNoGUIBox.UseVisualStyleBackColor = true;
            // 
            // AlertFullscreenCombo
            // 
            AlertFullscreenCombo.BackColor = System.Drawing.Color.Black;
            AlertFullscreenCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            AlertFullscreenCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AlertFullscreenCombo.ForeColor = System.Drawing.Color.White;
            AlertFullscreenCombo.FormattingEnabled = true;
            AlertFullscreenCombo.Location = new System.Drawing.Point(6, 37);
            AlertFullscreenCombo.Name = "AlertFullscreenCombo";
            AlertFullscreenCombo.Size = new System.Drawing.Size(95, 23);
            AlertFullscreenCombo.TabIndex = 1;
            ToolTipInformation.SetToolTip(AlertFullscreenCombo, "Choose how alerts are displayed.");
            // 
            // WindowLocationCombo
            // 
            WindowLocationCombo.BackColor = System.Drawing.Color.Black;
            WindowLocationCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            WindowLocationCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            WindowLocationCombo.ForeColor = System.Drawing.Color.White;
            WindowLocationCombo.FormattingEnabled = true;
            WindowLocationCombo.Location = new System.Drawing.Point(136, 37);
            WindowLocationCombo.Name = "WindowLocationCombo";
            WindowLocationCombo.Size = new System.Drawing.Size(95, 23);
            WindowLocationCombo.TabIndex = 4;
            ToolTipInformation.SetToolTip(WindowLocationCombo, "Choose where on the screen alerts are displayed.\r\nThis option only affects some display styles.");
            // 
            // ScrollSpeedBar
            // 
            ScrollSpeedBar.Location = new System.Drawing.Point(3, 204);
            ScrollSpeedBar.Maximum = 20;
            ScrollSpeedBar.Name = "ScrollSpeedBar";
            ScrollSpeedBar.Size = new System.Drawing.Size(127, 45);
            ScrollSpeedBar.TabIndex = 44;
            ToolTipInformation.SetToolTip(ScrollSpeedBar, "Controls the scroll speed on panels with scrolling text. This cannot control the idle panel scroll speed.");
            ScrollSpeedBar.Value = 5;
            // 
            // alertFadeTimeBar
            // 
            alertFadeTimeBar.LargeChange = 1;
            alertFadeTimeBar.Location = new System.Drawing.Point(3, 120);
            alertFadeTimeBar.Maximum = 20;
            alertFadeTimeBar.Minimum = 1;
            alertFadeTimeBar.Name = "alertFadeTimeBar";
            alertFadeTimeBar.Size = new System.Drawing.Size(127, 45);
            alertFadeTimeBar.TabIndex = 63;
            ToolTipInformation.SetToolTip(alertFadeTimeBar, "Controls the fade speed on alert panels.\r\nMoving this slider lower increases the speed. Higher is slower.\r\n\r\nThis does nothing if compatibility mode is turned on.");
            alertFadeTimeBar.Value = 3;
            // 
            // PreviewPicture
            // 
            PreviewPicture.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            PreviewPicture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            PreviewPicture.Location = new System.Drawing.Point(136, 95);
            PreviewPicture.Name = "PreviewPicture";
            PreviewPicture.Size = new System.Drawing.Size(395, 192);
            PreviewPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            PreviewPicture.TabIndex = 64;
            PreviewPicture.TabStop = false;
            ToolTipInformation.SetToolTip(PreviewPicture, "This is a preview of the alert display style currently selected. This is not affected by any other settings, except display style.");
            // 
            // TryForceWindowFocusBox
            // 
            TryForceWindowFocusBox.AutoSize = true;
            TryForceWindowFocusBox.Location = new System.Drawing.Point(6, 255);
            TryForceWindowFocusBox.Name = "TryForceWindowFocusBox";
            TryForceWindowFocusBox.Size = new System.Drawing.Size(130, 34);
            TryForceWindowFocusBox.TabIndex = 65;
            TryForceWindowFocusBox.Text = "Try forcefully taking\r\nwindow focus";
            ToolTipInformation.SetToolTip(TryForceWindowFocusBox, "Tries to take window focus by forcing the window's Z-order to be the highest for up to 5 seconds.");
            TryForceWindowFocusBox.UseVisualStyleBackColor = true;
            // 
            // ForceCustomFontBox
            // 
            ForceCustomFontBox.AutoSize = true;
            ForceCustomFontBox.Location = new System.Drawing.Point(213, 341);
            ForceCustomFontBox.Name = "ForceCustomFontBox";
            ForceCustomFontBox.Size = new System.Drawing.Size(123, 19);
            ForceCustomFontBox.TabIndex = 60;
            ForceCustomFontBox.Text = "Force custom font";
            ToolTipInformation.SetToolTip(ForceCustomFontBox, "Forces a specific font of your choice on all windows.\r\nRequires a program restart.");
            ForceCustomFontBox.UseVisualStyleBackColor = true;
            // 
            // CustomFontCombo
            // 
            CustomFontCombo.BackColor = System.Drawing.Color.Black;
            CustomFontCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CustomFontCombo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            CustomFontCombo.ForeColor = System.Drawing.Color.White;
            CustomFontCombo.FormattingEnabled = true;
            CustomFontCombo.Location = new System.Drawing.Point(342, 338);
            CustomFontCombo.Name = "CustomFontCombo";
            CustomFontCombo.Size = new System.Drawing.Size(233, 23);
            CustomFontCombo.TabIndex = 61;
            ToolTipInformation.SetToolTip(CustomFontCombo, "Choose a font to force everywhere possiible.\r\nThis is ignored if \"Force custom font\" is off.");
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(9, 361);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(258, 26);
            label1.TabIndex = 13;
            label1.Text = "To change these options later, go to Settings.";
            label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label9
            // 
            label9.Location = new System.Drawing.Point(136, 66);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(52, 23);
            label9.TabIndex = 34;
            label9.Text = "Timeout";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F);
            label2.Location = new System.Drawing.Point(3, 19);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(99, 15);
            label2.TabIndex = 36;
            label2.Text = "Alert display style";
            label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label8
            // 
            label8.Location = new System.Drawing.Point(6, 66);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(52, 23);
            label8.TabIndex = 37;
            label8.Text = "Screen";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(133, 19);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(134, 15);
            label11.TabIndex = 39;
            label11.Text = "Alert window alignment";
            // 
            // AlertTextButton
            // 
            AlertTextButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            AlertTextButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            AlertTextButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AlertTextButton.Location = new System.Drawing.Point(578, 338);
            AlertTextButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            AlertTextButton.Name = "AlertTextButton";
            AlertTextButton.Size = new System.Drawing.Size(72, 23);
            AlertTextButton.TabIndex = 41;
            AlertTextButton.Text = "Alert Text";
            AlertTextButton.UseVisualStyleBackColor = false;
            AlertTextButton.Click += AlertTextButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(3, 168);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(118, 30);
            label3.TabIndex = 43;
            label3.Text = "Scroll speed\r\n(Full scroll style only)";
            // 
            // DisplayStyleInfoButton
            // 
            DisplayStyleInfoButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DisplayStyleInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DisplayStyleInfoButton.ForeColor = System.Drawing.Color.Yellow;
            DisplayStyleInfoButton.Location = new System.Drawing.Point(107, 37);
            DisplayStyleInfoButton.Name = "DisplayStyleInfoButton";
            DisplayStyleInfoButton.Size = new System.Drawing.Size(23, 23);
            DisplayStyleInfoButton.TabIndex = 53;
            DisplayStyleInfoButton.Text = "?";
            DisplayStyleInfoButton.UseVisualStyleBackColor = false;
            DisplayStyleInfoButton.Click += DisplayStyleInfoButton_Click;
            // 
            // TextDisplayGroup
            // 
            TextDisplayGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TextDisplayGroup.Controls.Add(TryForceWindowFocusBox);
            TextDisplayGroup.Controls.Add(PreviewPicture);
            TextDisplayGroup.Controls.Add(alertIncreaseSizeBox);
            TextDisplayGroup.Controls.Add(alertFullscreenWindowedBox);
            TextDisplayGroup.Controls.Add(label4);
            TextDisplayGroup.Controls.Add(label2);
            TextDisplayGroup.Controls.Add(DisplayWhereInfoButton);
            TextDisplayGroup.Controls.Add(alertFadeTimeBar);
            TextDisplayGroup.Controls.Add(alertFullscreenDisplayInput);
            TextDisplayGroup.Controls.Add(alertTimeoutInput);
            TextDisplayGroup.Controls.Add(label9);
            TextDisplayGroup.Controls.Add(DisplayStyleInfoButton);
            TextDisplayGroup.Controls.Add(AlertFullscreenCombo);
            TextDisplayGroup.Controls.Add(ScrollSpeedBar);
            TextDisplayGroup.Controls.Add(label8);
            TextDisplayGroup.Controls.Add(label3);
            TextDisplayGroup.Controls.Add(WindowLocationCombo);
            TextDisplayGroup.Controls.Add(label11);
            TextDisplayGroup.ForeColor = System.Drawing.Color.White;
            TextDisplayGroup.Location = new System.Drawing.Point(110, 42);
            TextDisplayGroup.Name = "TextDisplayGroup";
            TextDisplayGroup.Size = new System.Drawing.Size(537, 293);
            TextDisplayGroup.TabIndex = 58;
            TextDisplayGroup.TabStop = false;
            TextDisplayGroup.Text = "Alert Window";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(3, 102);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(119, 15);
            label4.TabIndex = 62;
            label4.Text = "Fade transition speed";
            // 
            // DisplayWhereInfoButton
            // 
            DisplayWhereInfoButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DisplayWhereInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DisplayWhereInfoButton.ForeColor = System.Drawing.Color.Yellow;
            DisplayWhereInfoButton.Location = new System.Drawing.Point(237, 37);
            DisplayWhereInfoButton.Name = "DisplayWhereInfoButton";
            DisplayWhereInfoButton.Size = new System.Drawing.Size(23, 23);
            DisplayWhereInfoButton.TabIndex = 61;
            DisplayWhereInfoButton.Text = "?";
            DisplayWhereInfoButton.UseVisualStyleBackColor = false;
            DisplayWhereInfoButton.Click += DisplayWhereInfoButton_Click;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // StyleConfigurationForm
            // 
            AcceptButton = DoneButton;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(659, 396);
            Controls.Add(CustomFontCombo);
            Controls.Add(ForceCustomFontBox);
            Controls.Add(AlertTextButton);
            Controls.Add(alertNoGUIBox);
            Controls.Add(label1);
            Controls.Add(TitleText);
            Controls.Add(LogoBox);
            Controls.Add(DoneButton);
            Controls.Add(TextDisplayGroup);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StyleConfigurationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Style Settings";
            HelpButtonClicked += ChooseRegionForm_HelpButtonClicked;
            FormClosing += ChooseRegionForm_FormClosing;
            Load += ChooseRegionForm_Load;
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)alertTimeoutInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)alertFullscreenDisplayInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)ScrollSpeedBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)alertFadeTimeBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)PreviewPicture).EndInit();
            TextDisplayGroup.ResumeLayout(false);
            TextDisplayGroup.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AlertFullscreenCombo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown alertTimeoutInput;
        private System.Windows.Forms.NumericUpDown alertFullscreenDisplayInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox alertFullscreenWindowedBox;
        private System.Windows.Forms.CheckBox alertIncreaseSizeBox;
        private System.Windows.Forms.CheckBox alertNoGUIBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox WindowLocationCombo;
        private System.Windows.Forms.Button AlertTextButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar ScrollSpeedBar;
        private System.Windows.Forms.Button DisplayStyleInfoButton;
        private System.Windows.Forms.GroupBox TextDisplayGroup;
        private System.Windows.Forms.Button DisplayWhereInfoButton;
        private System.Windows.Forms.TrackBar alertFadeTimeBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox PreviewPicture;
        private System.Windows.Forms.CheckBox TryForceWindowFocusBox;
        private System.Windows.Forms.Timer WindowShake;
        private System.Windows.Forms.TextBox AreaSAMEInput;
        private System.Windows.Forms.CheckBox ForceCustomFontBox;
        private System.Windows.Forms.ComboBox CustomFontCombo;
    }
}
