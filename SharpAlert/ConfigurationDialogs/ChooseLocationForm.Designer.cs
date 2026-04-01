namespace SharpAlert.ConfigurationDialogs
{
    partial class ChooseLocationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseLocationForm));
            DoneButton = new System.Windows.Forms.Button();
            LogoBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            label8 = new System.Windows.Forms.Label();
            AreaCAPCPInput = new System.Windows.Forms.TextBox();
            label7 = new System.Windows.Forms.Label();
            AreaSAMEInput = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            AreaCustomNameInput = new System.Windows.Forms.TextBox();
            AreaCustomInput = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            groupBox8 = new System.Windows.Forms.GroupBox();
            ListAreaCAPCPOutput = new System.Windows.Forms.TextBox();
            UGCClearButton = new System.Windows.Forms.Button();
            UGCAddButton = new System.Windows.Forms.Button();
            groupBox7 = new System.Windows.Forms.GroupBox();
            ListAreaSAMEOutput = new System.Windows.Forms.TextBox();
            SAMESelectButton = new System.Windows.Forms.Button();
            SAMEClearButton = new System.Windows.Forms.Button();
            SAMEAddButton = new System.Windows.Forms.Button();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ListAreaCustomOutput = new System.Windows.Forms.TextBox();
            CustomClearButton = new System.Windows.Forms.Button();
            CustomAddButton = new System.Windows.Forms.Button();
            SkipButton = new System.Windows.Forms.Button();
            WindowShake = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            groupBox8.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Location = new System.Drawing.Point(647, 309);
            DoneButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
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
            TitleText.Size = new System.Drawing.Size(614, 30);
            TitleText.TabIndex = 3;
            TitleText.Text = "Receive alerts for only some locations?";
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
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = System.Drawing.Color.Yellow;
            label8.Location = new System.Drawing.Point(136, 22);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(12, 15);
            label8.TabIndex = 8;
            label8.Text = "?";
            ToolTipInformation.SetToolTip(label8, "CAP-CP location restrictions are applied ONLY to alerts that arrive from NAADS.\r\n\r\nTrying to remove a specific location?\r\nType the location's code, then click \"Add\". You'll be prompted to remove it.");
            // 
            // AreaCAPCPInput
            // 
            AreaCAPCPInput.BackColor = System.Drawing.Color.Black;
            AreaCAPCPInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            AreaCAPCPInput.ForeColor = System.Drawing.Color.White;
            AreaCAPCPInput.Location = new System.Drawing.Point(6, 20);
            AreaCAPCPInput.Name = "AreaCAPCPInput";
            AreaCAPCPInput.Size = new System.Drawing.Size(124, 23);
            AreaCAPCPInput.TabIndex = 27;
            ToolTipInformation.SetToolTip(AreaCAPCPInput, "Enter a CAP-CP code here.");
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.Color.Yellow;
            label7.Location = new System.Drawing.Point(136, 22);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(12, 15);
            label7.TabIndex = 8;
            label7.Text = "?";
            ToolTipInformation.SetToolTip(label7, resources.GetString("label7.ToolTip"));
            // 
            // AreaSAMEInput
            // 
            AreaSAMEInput.BackColor = System.Drawing.Color.Black;
            AreaSAMEInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            AreaSAMEInput.ForeColor = System.Drawing.Color.White;
            AreaSAMEInput.Location = new System.Drawing.Point(6, 20);
            AreaSAMEInput.Name = "AreaSAMEInput";
            AreaSAMEInput.Size = new System.Drawing.Size(124, 23);
            AreaSAMEInput.TabIndex = 22;
            ToolTipInformation.SetToolTip(AreaSAMEInput, "Enter a SAME code here.\r\nSAME codes are 6 digits long, but the first digit is currently ignored. You can input the first digit anyway.");
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.Color.Yellow;
            label2.Location = new System.Drawing.Point(264, 22);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(12, 15);
            label2.TabIndex = 8;
            label2.Text = "?";
            ToolTipInformation.SetToolTip(label2, resources.GetString("label2.ToolTip"));
            // 
            // AreaCustomNameInput
            // 
            AreaCustomNameInput.BackColor = System.Drawing.Color.Black;
            AreaCustomNameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            AreaCustomNameInput.ForeColor = System.Drawing.Color.White;
            AreaCustomNameInput.Location = new System.Drawing.Point(104, 20);
            AreaCustomNameInput.Name = "AreaCustomNameInput";
            AreaCustomNameInput.Size = new System.Drawing.Size(154, 23);
            AreaCustomNameInput.TabIndex = 27;
            ToolTipInformation.SetToolTip(AreaCustomNameInput, "Enter a CAP-CP code here.");
            // 
            // AreaCustomInput
            // 
            AreaCustomInput.BackColor = System.Drawing.Color.Black;
            AreaCustomInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            AreaCustomInput.ForeColor = System.Drawing.Color.White;
            AreaCustomInput.Location = new System.Drawing.Point(104, 47);
            AreaCustomInput.Name = "AreaCustomInput";
            AreaCustomInput.Size = new System.Drawing.Size(174, 23);
            AreaCustomInput.TabIndex = 37;
            ToolTipInformation.SetToolTip(AreaCustomInput, "Enter a CAP-CP code here.");
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(9, 291);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(342, 41);
            label1.TabIndex = 13;
            label1.Text = "To relay any location, leave everything blank.\r\nTo change these options later, go to Settings.";
            label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox8
            // 
            groupBox8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            groupBox8.Controls.Add(ListAreaCAPCPOutput);
            groupBox8.Controls.Add(label8);
            groupBox8.Controls.Add(UGCClearButton);
            groupBox8.Controls.Add(UGCAddButton);
            groupBox8.Controls.Add(AreaCAPCPInput);
            groupBox8.ForeColor = System.Drawing.Color.White;
            groupBox8.Location = new System.Drawing.Point(273, 42);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new System.Drawing.Size(156, 246);
            groupBox8.TabIndex = 15;
            groupBox8.TabStop = false;
            groupBox8.Text = "CAP-CP (Canada)";
            // 
            // ListAreaCAPCPOutput
            // 
            ListAreaCAPCPOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ListAreaCAPCPOutput.BackColor = System.Drawing.Color.Black;
            ListAreaCAPCPOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ListAreaCAPCPOutput.Font = new System.Drawing.Font("Segoe UI", 12F);
            ListAreaCAPCPOutput.ForeColor = System.Drawing.Color.White;
            ListAreaCAPCPOutput.Location = new System.Drawing.Point(6, 76);
            ListAreaCAPCPOutput.Multiline = true;
            ListAreaCAPCPOutput.Name = "ListAreaCAPCPOutput";
            ListAreaCAPCPOutput.ReadOnly = true;
            ListAreaCAPCPOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            ListAreaCAPCPOutput.Size = new System.Drawing.Size(144, 164);
            ListAreaCAPCPOutput.TabIndex = 36;
            ListAreaCAPCPOutput.WordWrap = false;
            // 
            // UGCClearButton
            // 
            UGCClearButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            UGCClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            UGCClearButton.Location = new System.Drawing.Point(6, 47);
            UGCClearButton.Name = "UGCClearButton";
            UGCClearButton.Size = new System.Drawing.Size(94, 23);
            UGCClearButton.TabIndex = 28;
            UGCClearButton.Text = "Clear";
            UGCClearButton.UseVisualStyleBackColor = false;
            UGCClearButton.Click += UGCClearButton_Click;
            // 
            // UGCAddButton
            // 
            UGCAddButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            UGCAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            UGCAddButton.Location = new System.Drawing.Point(106, 47);
            UGCAddButton.Name = "UGCAddButton";
            UGCAddButton.Size = new System.Drawing.Size(44, 23);
            UGCAddButton.TabIndex = 29;
            UGCAddButton.Text = "Add";
            UGCAddButton.UseVisualStyleBackColor = false;
            UGCAddButton.Click += UGCAddButton_Click;
            // 
            // groupBox7
            // 
            groupBox7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            groupBox7.Controls.Add(ListAreaSAMEOutput);
            groupBox7.Controls.Add(label7);
            groupBox7.Controls.Add(SAMESelectButton);
            groupBox7.Controls.Add(SAMEClearButton);
            groupBox7.Controls.Add(SAMEAddButton);
            groupBox7.Controls.Add(AreaSAMEInput);
            groupBox7.ForeColor = System.Drawing.Color.White;
            groupBox7.Location = new System.Drawing.Point(110, 42);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(156, 246);
            groupBox7.TabIndex = 14;
            groupBox7.TabStop = false;
            groupBox7.Text = "SAME (United States)";
            // 
            // ListAreaSAMEOutput
            // 
            ListAreaSAMEOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ListAreaSAMEOutput.BackColor = System.Drawing.Color.Black;
            ListAreaSAMEOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ListAreaSAMEOutput.Font = new System.Drawing.Font("Segoe UI", 12F);
            ListAreaSAMEOutput.ForeColor = System.Drawing.Color.White;
            ListAreaSAMEOutput.Location = new System.Drawing.Point(6, 76);
            ListAreaSAMEOutput.Multiline = true;
            ListAreaSAMEOutput.Name = "ListAreaSAMEOutput";
            ListAreaSAMEOutput.ReadOnly = true;
            ListAreaSAMEOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            ListAreaSAMEOutput.Size = new System.Drawing.Size(144, 164);
            ListAreaSAMEOutput.TabIndex = 35;
            ListAreaSAMEOutput.WordWrap = false;
            // 
            // SAMESelectButton
            // 
            SAMESelectButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SAMESelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SAMESelectButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            SAMESelectButton.Location = new System.Drawing.Point(102, 47);
            SAMESelectButton.Name = "SAMESelectButton";
            SAMESelectButton.Size = new System.Drawing.Size(48, 23);
            SAMESelectButton.TabIndex = 25;
            SAMESelectButton.Text = "Select";
            SAMESelectButton.UseVisualStyleBackColor = false;
            SAMESelectButton.Click += SAMESelectButton_Click;
            // 
            // SAMEClearButton
            // 
            SAMEClearButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SAMEClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SAMEClearButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            SAMEClearButton.Location = new System.Drawing.Point(6, 47);
            SAMEClearButton.Name = "SAMEClearButton";
            SAMEClearButton.Size = new System.Drawing.Size(42, 23);
            SAMEClearButton.TabIndex = 23;
            SAMEClearButton.Text = "Clear";
            SAMEClearButton.UseVisualStyleBackColor = false;
            SAMEClearButton.Click += SAMEClearButton_Click;
            // 
            // SAMEAddButton
            // 
            SAMEAddButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SAMEAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SAMEAddButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            SAMEAddButton.Location = new System.Drawing.Point(54, 47);
            SAMEAddButton.Name = "SAMEAddButton";
            SAMEAddButton.Size = new System.Drawing.Size(42, 23);
            SAMEAddButton.TabIndex = 24;
            SAMEAddButton.Text = "Add";
            SAMEAddButton.UseVisualStyleBackColor = false;
            SAMEAddButton.Click += SAMEAddButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(AreaCustomInput);
            groupBox1.Controls.Add(ListAreaCustomOutput);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(CustomClearButton);
            groupBox1.Controls.Add(CustomAddButton);
            groupBox1.Controls.Add(AreaCustomNameInput);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(435, 42);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(284, 246);
            groupBox1.TabIndex = 16;
            groupBox1.TabStop = false;
            groupBox1.Text = "Custom Locations";
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(3, 46);
            label4.Margin = new System.Windows.Forms.Padding(0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(98, 21);
            label4.TabIndex = 39;
            label4.Text = "Value";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(3, 20);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(98, 21);
            label3.TabIndex = 38;
            label3.Text = "ValueName";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListAreaCustomOutput
            // 
            ListAreaCustomOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ListAreaCustomOutput.BackColor = System.Drawing.Color.Black;
            ListAreaCustomOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            ListAreaCustomOutput.Font = new System.Drawing.Font("Segoe UI", 12F);
            ListAreaCustomOutput.ForeColor = System.Drawing.Color.White;
            ListAreaCustomOutput.Location = new System.Drawing.Point(6, 103);
            ListAreaCustomOutput.Multiline = true;
            ListAreaCustomOutput.Name = "ListAreaCustomOutput";
            ListAreaCustomOutput.ReadOnly = true;
            ListAreaCustomOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            ListAreaCustomOutput.Size = new System.Drawing.Size(272, 137);
            ListAreaCustomOutput.TabIndex = 36;
            ListAreaCustomOutput.WordWrap = false;
            // 
            // CustomClearButton
            // 
            CustomClearButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            CustomClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            CustomClearButton.Location = new System.Drawing.Point(104, 74);
            CustomClearButton.Name = "CustomClearButton";
            CustomClearButton.Size = new System.Drawing.Size(124, 23);
            CustomClearButton.TabIndex = 28;
            CustomClearButton.Text = "Clear";
            CustomClearButton.UseVisualStyleBackColor = false;
            CustomClearButton.Click += CustomClearButton_Click;
            // 
            // CustomAddButton
            // 
            CustomAddButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            CustomAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            CustomAddButton.Location = new System.Drawing.Point(234, 74);
            CustomAddButton.Name = "CustomAddButton";
            CustomAddButton.Size = new System.Drawing.Size(44, 23);
            CustomAddButton.TabIndex = 29;
            CustomAddButton.Text = "Add";
            CustomAddButton.UseVisualStyleBackColor = false;
            CustomAddButton.Click += CustomAddButton_Click;
            // 
            // SkipButton
            // 
            SkipButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            SkipButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SkipButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SkipButton.Location = new System.Drawing.Point(435, 309);
            SkipButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            SkipButton.Name = "SkipButton";
            SkipButton.Size = new System.Drawing.Size(209, 23);
            SkipButton.TabIndex = 17;
            SkipButton.Text = "I don't want to add locations now.";
            SkipButton.UseVisualStyleBackColor = false;
            SkipButton.Click += SkipButton_Click;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // ChooseLocationForm
            // 
            AcceptButton = DoneButton;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(728, 341);
            Controls.Add(SkipButton);
            Controls.Add(groupBox1);
            Controls.Add(groupBox8);
            Controls.Add(groupBox7);
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
            Name = "ChooseLocationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Location Selection";
            HelpButtonClicked += ChooseRegionForm_HelpButtonClicked;
            FormClosing += ChooseRegionForm_FormClosing;
            Load += ChooseRegionForm_Load;
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox ListAreaCAPCPOutput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button UGCClearButton;
        private System.Windows.Forms.Button UGCAddButton;
        private System.Windows.Forms.TextBox AreaCAPCPInput;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox ListAreaSAMEOutput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button SAMESelectButton;
        private System.Windows.Forms.Button SAMEClearButton;
        private System.Windows.Forms.Button SAMEAddButton;
        private System.Windows.Forms.TextBox AreaSAMEInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button CustomClearButton;
        private System.Windows.Forms.Button CustomAddButton;
        private System.Windows.Forms.TextBox AreaCustomNameInput;
        private System.Windows.Forms.TextBox AreaCustomInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ListAreaCustomOutput;
        private System.Windows.Forms.Button SkipButton;
        private System.Windows.Forms.Timer WindowShake;
    }
}
