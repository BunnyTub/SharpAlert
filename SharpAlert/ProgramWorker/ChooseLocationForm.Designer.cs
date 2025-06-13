namespace SharpAlert
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseLocationForm));
            this.DoneButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.AreaCAPCPInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.AreaSAMEInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AreaCustomNameInput = new System.Windows.Forms.TextBox();
            this.AreaCustomInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.ListAreaCAPCPOutput = new System.Windows.Forms.TextBox();
            this.UGCClearButton = new System.Windows.Forms.Button();
            this.UGCAddButton = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ListAreaSAMEOutput = new System.Windows.Forms.TextBox();
            this.SAMESelectButton = new System.Windows.Forms.Button();
            this.SAMEClearButton = new System.Windows.Forms.Button();
            this.SAMEAddButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ListAreaCustomOutput = new System.Windows.Forms.TextBox();
            this.CustomClearButton = new System.Windows.Forms.Button();
            this.CustomAddButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneButton.Location = new System.Drawing.Point(647, 309);
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
            this.TitleText.Text = "Customize your location(s).";
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Yellow;
            this.label8.Location = new System.Drawing.Point(136, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 15);
            this.label8.TabIndex = 8;
            this.label8.Text = "?";
            this.ToolTipInformation.SetToolTip(this.label8, "CAP-CP location restrictions are applied ONLY to alerts that arrive from NAADS.\r\n" +
        "\r\nTrying to remove a specific location?\r\nType the location\'s code, then click \"A" +
        "dd\". You\'ll be prompted to remove it.");
            // 
            // AreaCAPCPInput
            // 
            this.AreaCAPCPInput.BackColor = System.Drawing.Color.Black;
            this.AreaCAPCPInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AreaCAPCPInput.ForeColor = System.Drawing.Color.White;
            this.AreaCAPCPInput.Location = new System.Drawing.Point(6, 20);
            this.AreaCAPCPInput.Name = "AreaCAPCPInput";
            this.AreaCAPCPInput.Size = new System.Drawing.Size(124, 21);
            this.AreaCAPCPInput.TabIndex = 27;
            this.ToolTipInformation.SetToolTip(this.AreaCAPCPInput, "Enter a CAP-CP code here.");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Yellow;
            this.label7.Location = new System.Drawing.Point(136, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "?";
            this.ToolTipInformation.SetToolTip(this.label7, "SAME location restrictions are applied ONLY to alerts that arrive from IPAWS.\r\n\r\n" +
        "Trying to remove a specific location?\r\nType the location\'s code, then click \"Add" +
        "\". You\'ll be prompted to remove it.");
            // 
            // AreaSAMEInput
            // 
            this.AreaSAMEInput.BackColor = System.Drawing.Color.Black;
            this.AreaSAMEInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AreaSAMEInput.ForeColor = System.Drawing.Color.White;
            this.AreaSAMEInput.Location = new System.Drawing.Point(6, 20);
            this.AreaSAMEInput.Name = "AreaSAMEInput";
            this.AreaSAMEInput.Size = new System.Drawing.Size(124, 21);
            this.AreaSAMEInput.TabIndex = 22;
            this.ToolTipInformation.SetToolTip(this.AreaSAMEInput, "Enter a SAME code here.");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(264, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "?";
            this.ToolTipInformation.SetToolTip(this.label2, resources.GetString("label2.ToolTip"));
            // 
            // AreaCustomNameInput
            // 
            this.AreaCustomNameInput.BackColor = System.Drawing.Color.Black;
            this.AreaCustomNameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AreaCustomNameInput.ForeColor = System.Drawing.Color.White;
            this.AreaCustomNameInput.Location = new System.Drawing.Point(104, 20);
            this.AreaCustomNameInput.Name = "AreaCustomNameInput";
            this.AreaCustomNameInput.Size = new System.Drawing.Size(154, 21);
            this.AreaCustomNameInput.TabIndex = 27;
            this.ToolTipInformation.SetToolTip(this.AreaCustomNameInput, "Enter a CAP-CP code here.");
            // 
            // AreaCustomInput
            // 
            this.AreaCustomInput.BackColor = System.Drawing.Color.Black;
            this.AreaCustomInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AreaCustomInput.ForeColor = System.Drawing.Color.White;
            this.AreaCustomInput.Location = new System.Drawing.Point(104, 47);
            this.AreaCustomInput.Name = "AreaCustomInput";
            this.AreaCustomInput.Size = new System.Drawing.Size(174, 21);
            this.AreaCustomInput.TabIndex = 37;
            this.ToolTipInformation.SetToolTip(this.AreaCustomInput, "Enter a CAP-CP code here.");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(9, 291);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 41);
            this.label1.TabIndex = 13;
            this.label1.Text = "To relay any location, leave everything blank.\r\nTo change these options later, go" +
    " to Settings.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // groupBox8
            // 
            this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox8.Controls.Add(this.ListAreaCAPCPOutput);
            this.groupBox8.Controls.Add(this.label8);
            this.groupBox8.Controls.Add(this.UGCClearButton);
            this.groupBox8.Controls.Add(this.UGCAddButton);
            this.groupBox8.Controls.Add(this.AreaCAPCPInput);
            this.groupBox8.ForeColor = System.Drawing.Color.White;
            this.groupBox8.Location = new System.Drawing.Point(273, 42);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(156, 246);
            this.groupBox8.TabIndex = 15;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "CAP-CP Locations";
            // 
            // ListAreaCAPCPOutput
            // 
            this.ListAreaCAPCPOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListAreaCAPCPOutput.BackColor = System.Drawing.Color.Black;
            this.ListAreaCAPCPOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListAreaCAPCPOutput.Font = new System.Drawing.Font("Arial", 12F);
            this.ListAreaCAPCPOutput.ForeColor = System.Drawing.Color.White;
            this.ListAreaCAPCPOutput.Location = new System.Drawing.Point(6, 76);
            this.ListAreaCAPCPOutput.Multiline = true;
            this.ListAreaCAPCPOutput.Name = "ListAreaCAPCPOutput";
            this.ListAreaCAPCPOutput.ReadOnly = true;
            this.ListAreaCAPCPOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ListAreaCAPCPOutput.Size = new System.Drawing.Size(144, 164);
            this.ListAreaCAPCPOutput.TabIndex = 36;
            this.ListAreaCAPCPOutput.WordWrap = false;
            // 
            // UGCClearButton
            // 
            this.UGCClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.UGCClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UGCClearButton.Location = new System.Drawing.Point(6, 47);
            this.UGCClearButton.Name = "UGCClearButton";
            this.UGCClearButton.Size = new System.Drawing.Size(94, 23);
            this.UGCClearButton.TabIndex = 28;
            this.UGCClearButton.Text = "Clear";
            this.UGCClearButton.UseVisualStyleBackColor = false;
            this.UGCClearButton.Click += new System.EventHandler(this.UGCClearButton_Click);
            // 
            // UGCAddButton
            // 
            this.UGCAddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.UGCAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.UGCAddButton.Location = new System.Drawing.Point(106, 47);
            this.UGCAddButton.Name = "UGCAddButton";
            this.UGCAddButton.Size = new System.Drawing.Size(44, 23);
            this.UGCAddButton.TabIndex = 29;
            this.UGCAddButton.Text = "Add";
            this.UGCAddButton.UseVisualStyleBackColor = false;
            this.UGCAddButton.Click += new System.EventHandler(this.UGCAddButton_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox7.Controls.Add(this.ListAreaSAMEOutput);
            this.groupBox7.Controls.Add(this.label7);
            this.groupBox7.Controls.Add(this.SAMESelectButton);
            this.groupBox7.Controls.Add(this.SAMEClearButton);
            this.groupBox7.Controls.Add(this.SAMEAddButton);
            this.groupBox7.Controls.Add(this.AreaSAMEInput);
            this.groupBox7.ForeColor = System.Drawing.Color.White;
            this.groupBox7.Location = new System.Drawing.Point(110, 42);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(156, 246);
            this.groupBox7.TabIndex = 14;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "SAME Locations";
            // 
            // ListAreaSAMEOutput
            // 
            this.ListAreaSAMEOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListAreaSAMEOutput.BackColor = System.Drawing.Color.Black;
            this.ListAreaSAMEOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListAreaSAMEOutput.Font = new System.Drawing.Font("Arial", 12F);
            this.ListAreaSAMEOutput.ForeColor = System.Drawing.Color.White;
            this.ListAreaSAMEOutput.Location = new System.Drawing.Point(6, 76);
            this.ListAreaSAMEOutput.Multiline = true;
            this.ListAreaSAMEOutput.Name = "ListAreaSAMEOutput";
            this.ListAreaSAMEOutput.ReadOnly = true;
            this.ListAreaSAMEOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ListAreaSAMEOutput.Size = new System.Drawing.Size(144, 164);
            this.ListAreaSAMEOutput.TabIndex = 35;
            this.ListAreaSAMEOutput.WordWrap = false;
            // 
            // SAMESelectButton
            // 
            this.SAMESelectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SAMESelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SAMESelectButton.Font = new System.Drawing.Font("Arial", 8F);
            this.SAMESelectButton.Location = new System.Drawing.Point(102, 47);
            this.SAMESelectButton.Name = "SAMESelectButton";
            this.SAMESelectButton.Size = new System.Drawing.Size(48, 23);
            this.SAMESelectButton.TabIndex = 25;
            this.SAMESelectButton.Text = "Select";
            this.SAMESelectButton.UseVisualStyleBackColor = false;
            this.SAMESelectButton.Click += new System.EventHandler(this.SAMESelectButton_Click);
            // 
            // SAMEClearButton
            // 
            this.SAMEClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SAMEClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SAMEClearButton.Font = new System.Drawing.Font("Arial", 8F);
            this.SAMEClearButton.Location = new System.Drawing.Point(6, 47);
            this.SAMEClearButton.Name = "SAMEClearButton";
            this.SAMEClearButton.Size = new System.Drawing.Size(42, 23);
            this.SAMEClearButton.TabIndex = 23;
            this.SAMEClearButton.Text = "Clear";
            this.SAMEClearButton.UseVisualStyleBackColor = false;
            this.SAMEClearButton.Click += new System.EventHandler(this.SAMEClearButton_Click);
            // 
            // SAMEAddButton
            // 
            this.SAMEAddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SAMEAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SAMEAddButton.Font = new System.Drawing.Font("Arial", 8F);
            this.SAMEAddButton.Location = new System.Drawing.Point(54, 47);
            this.SAMEAddButton.Name = "SAMEAddButton";
            this.SAMEAddButton.Size = new System.Drawing.Size(42, 23);
            this.SAMEAddButton.TabIndex = 24;
            this.SAMEAddButton.Text = "Add";
            this.SAMEAddButton.UseVisualStyleBackColor = false;
            this.SAMEAddButton.Click += new System.EventHandler(this.SAMEAddButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.AreaCustomInput);
            this.groupBox1.Controls.Add(this.ListAreaCustomOutput);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.CustomClearButton);
            this.groupBox1.Controls.Add(this.CustomAddButton);
            this.groupBox1.Controls.Add(this.AreaCustomNameInput);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(435, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 246);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Custom Locations";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(3, 46);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 21);
            this.label4.TabIndex = 39;
            this.label4.Text = "Value";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 20);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 21);
            this.label3.TabIndex = 38;
            this.label3.Text = "ValueName";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ListAreaCustomOutput
            // 
            this.ListAreaCustomOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListAreaCustomOutput.BackColor = System.Drawing.Color.Black;
            this.ListAreaCustomOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListAreaCustomOutput.Font = new System.Drawing.Font("Arial", 12F);
            this.ListAreaCustomOutput.ForeColor = System.Drawing.Color.White;
            this.ListAreaCustomOutput.Location = new System.Drawing.Point(6, 103);
            this.ListAreaCustomOutput.Multiline = true;
            this.ListAreaCustomOutput.Name = "ListAreaCustomOutput";
            this.ListAreaCustomOutput.ReadOnly = true;
            this.ListAreaCustomOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ListAreaCustomOutput.Size = new System.Drawing.Size(272, 137);
            this.ListAreaCustomOutput.TabIndex = 36;
            this.ListAreaCustomOutput.WordWrap = false;
            // 
            // CustomClearButton
            // 
            this.CustomClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CustomClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CustomClearButton.Location = new System.Drawing.Point(104, 74);
            this.CustomClearButton.Name = "CustomClearButton";
            this.CustomClearButton.Size = new System.Drawing.Size(124, 23);
            this.CustomClearButton.TabIndex = 28;
            this.CustomClearButton.Text = "Clear";
            this.CustomClearButton.UseVisualStyleBackColor = false;
            this.CustomClearButton.Click += new System.EventHandler(this.CustomClearButton_Click);
            // 
            // CustomAddButton
            // 
            this.CustomAddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.CustomAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CustomAddButton.Location = new System.Drawing.Point(234, 74);
            this.CustomAddButton.Name = "CustomAddButton";
            this.CustomAddButton.Size = new System.Drawing.Size(44, 23);
            this.CustomAddButton.TabIndex = 29;
            this.CustomAddButton.Text = "Add";
            this.CustomAddButton.UseVisualStyleBackColor = false;
            this.CustomAddButton.Click += new System.EventHandler(this.CustomAddButton_Click);
            // 
            // ChooseLocationForm
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(728, 341);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox8);
            this.Controls.Add(this.groupBox7);
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
            this.Name = "ChooseLocationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Location Selection";
            this.TopMost = true;
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.ChooseRegionForm_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChooseRegionForm_FormClosing);
            this.Load += new System.EventHandler(this.ChooseRegionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DoneButton;
        private System.Windows.Forms.PictureBox pictureBox1;
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
    }
}