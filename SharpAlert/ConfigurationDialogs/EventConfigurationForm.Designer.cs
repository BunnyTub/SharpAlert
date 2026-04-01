namespace SharpAlert.ConfigurationDialogs
{
    partial class EventConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventConfigurationForm));
            groupBox9 = new System.Windows.Forms.GroupBox();
            NamedEventsInfoButton = new System.Windows.Forms.Button();
            EventSelectButton = new System.Windows.Forms.Button();
            EventAddButton = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            EventBlacklistOutput = new System.Windows.Forms.TextBox();
            EventBlacklistInput = new System.Windows.Forms.TextBox();
            EventClearButton = new System.Windows.Forms.Button();
            EventWhitelistModeBox = new System.Windows.Forms.CheckBox();
            label1 = new System.Windows.Forms.Label();
            LogoBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            SAMEEventsInfoButton = new System.Windows.Forms.Button();
            EventSAMESelectButton = new System.Windows.Forms.Button();
            EventSAMEAddButton = new System.Windows.Forms.Button();
            label2 = new System.Windows.Forms.Label();
            EventSAMEBlacklistOutput = new System.Windows.Forms.TextBox();
            EventSAMEBlacklistInput = new System.Windows.Forms.TextBox();
            EventSAMEClearButton = new System.Windows.Forms.Button();
            WindowShake = new System.Windows.Forms.Timer(components);
            groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox9
            // 
            groupBox9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox9.Controls.Add(NamedEventsInfoButton);
            groupBox9.Controls.Add(EventSelectButton);
            groupBox9.Controls.Add(EventAddButton);
            groupBox9.Controls.Add(label3);
            groupBox9.Controls.Add(EventBlacklistOutput);
            groupBox9.Controls.Add(EventBlacklistInput);
            groupBox9.Controls.Add(EventClearButton);
            groupBox9.ForeColor = System.Drawing.Color.White;
            groupBox9.Location = new System.Drawing.Point(108, 42);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new System.Drawing.Size(319, 93);
            groupBox9.TabIndex = 5;
            groupBox9.TabStop = false;
            groupBox9.Text = "Named Events";
            // 
            // NamedEventsInfoButton
            // 
            NamedEventsInfoButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            NamedEventsInfoButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            NamedEventsInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            NamedEventsInfoButton.ForeColor = System.Drawing.Color.Yellow;
            NamedEventsInfoButton.Location = new System.Drawing.Point(290, 13);
            NamedEventsInfoButton.Name = "NamedEventsInfoButton";
            NamedEventsInfoButton.Size = new System.Drawing.Size(23, 23);
            NamedEventsInfoButton.TabIndex = 53;
            NamedEventsInfoButton.Text = "?";
            NamedEventsInfoButton.UseVisualStyleBackColor = false;
            NamedEventsInfoButton.Click += NamedEventsInfoButton_Click;
            // 
            // EventSelectButton
            // 
            EventSelectButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            EventSelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EventSelectButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            EventSelectButton.Location = new System.Drawing.Point(102, 64);
            EventSelectButton.Name = "EventSelectButton";
            EventSelectButton.Size = new System.Drawing.Size(48, 23);
            EventSelectButton.TabIndex = 36;
            EventSelectButton.Text = "Select";
            EventSelectButton.UseVisualStyleBackColor = false;
            EventSelectButton.Click += EventSelectButton_Click;
            // 
            // EventAddButton
            // 
            EventAddButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            EventAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EventAddButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            EventAddButton.Location = new System.Drawing.Point(54, 64);
            EventAddButton.Name = "EventAddButton";
            EventAddButton.Size = new System.Drawing.Size(42, 23);
            EventAddButton.TabIndex = 35;
            EventAddButton.Text = "Add";
            EventAddButton.UseVisualStyleBackColor = false;
            EventAddButton.Click += EventAddButton_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(6, 17);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(138, 15);
            label3.TabIndex = 6;
            label3.Text = "You can add events here.";
            // 
            // EventBlacklistOutput
            // 
            EventBlacklistOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            EventBlacklistOutput.BackColor = System.Drawing.Color.Black;
            EventBlacklistOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EventBlacklistOutput.Font = new System.Drawing.Font("Segoe UI", 12F);
            EventBlacklistOutput.ForeColor = System.Drawing.Color.White;
            EventBlacklistOutput.Location = new System.Drawing.Point(169, 37);
            EventBlacklistOutput.Multiline = true;
            EventBlacklistOutput.Name = "EventBlacklistOutput";
            EventBlacklistOutput.ReadOnly = true;
            EventBlacklistOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            EventBlacklistOutput.Size = new System.Drawing.Size(144, 50);
            EventBlacklistOutput.TabIndex = 34;
            EventBlacklistOutput.WordWrap = false;
            // 
            // EventBlacklistInput
            // 
            EventBlacklistInput.BackColor = System.Drawing.Color.Black;
            EventBlacklistInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EventBlacklistInput.ForeColor = System.Drawing.Color.White;
            EventBlacklistInput.Location = new System.Drawing.Point(6, 37);
            EventBlacklistInput.MaxLength = 128;
            EventBlacklistInput.Name = "EventBlacklistInput";
            EventBlacklistInput.Size = new System.Drawing.Size(144, 23);
            EventBlacklistInput.TabIndex = 31;
            // 
            // EventClearButton
            // 
            EventClearButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            EventClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EventClearButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            EventClearButton.Location = new System.Drawing.Point(6, 64);
            EventClearButton.Name = "EventClearButton";
            EventClearButton.Size = new System.Drawing.Size(42, 23);
            EventClearButton.TabIndex = 32;
            EventClearButton.Text = "Clear";
            EventClearButton.UseVisualStyleBackColor = false;
            EventClearButton.Click += EventClearButton_Click;
            // 
            // EventWhitelistModeBox
            // 
            EventWhitelistModeBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            EventWhitelistModeBox.AutoSize = true;
            EventWhitelistModeBox.Location = new System.Drawing.Point(321, 294);
            EventWhitelistModeBox.Name = "EventWhitelistModeBox";
            EventWhitelistModeBox.Size = new System.Drawing.Size(106, 19);
            EventWhitelistModeBox.TabIndex = 54;
            EventWhitelistModeBox.Text = "Whitelist mode";
            EventWhitelistModeBox.UseVisualStyleBackColor = true;
            EventWhitelistModeBox.CheckedChanged += EventWhitelistModeBox_CheckedChanged;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(9, 291);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(431, 41);
            label1.TabIndex = 15;
            label1.Text = "To relay any event, leave everything blank, and turn off whitelist mode.";
            label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // LogoBox
            // 
            LogoBox.Image = Properties.Resources.WarningApp;
            LogoBox.Location = new System.Drawing.Point(9, 9);
            LogoBox.Margin = new System.Windows.Forms.Padding(0);
            LogoBox.Name = "LogoBox";
            LogoBox.Size = new System.Drawing.Size(96, 96);
            LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            LogoBox.TabIndex = 14;
            LogoBox.TabStop = false;
            // 
            // TitleText
            // 
            TitleText.Font = new System.Drawing.Font("Segoe UI", 16F);
            TitleText.Location = new System.Drawing.Point(105, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(614, 30);
            TitleText.TabIndex = 16;
            TitleText.Text = "Choose your events.";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(SAMEEventsInfoButton);
            groupBox1.Controls.Add(EventSAMESelectButton);
            groupBox1.Controls.Add(EventSAMEAddButton);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(EventSAMEBlacklistOutput);
            groupBox1.Controls.Add(EventSAMEBlacklistInput);
            groupBox1.Controls.Add(EventSAMEClearButton);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(108, 141);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(319, 147);
            groupBox1.TabIndex = 17;
            groupBox1.TabStop = false;
            groupBox1.Text = "SAME Events";
            // 
            // SAMEEventsInfoButton
            // 
            SAMEEventsInfoButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            SAMEEventsInfoButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SAMEEventsInfoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SAMEEventsInfoButton.ForeColor = System.Drawing.Color.Yellow;
            SAMEEventsInfoButton.Location = new System.Drawing.Point(290, 13);
            SAMEEventsInfoButton.Name = "SAMEEventsInfoButton";
            SAMEEventsInfoButton.Size = new System.Drawing.Size(23, 23);
            SAMEEventsInfoButton.TabIndex = 53;
            SAMEEventsInfoButton.Text = "?";
            SAMEEventsInfoButton.UseVisualStyleBackColor = false;
            SAMEEventsInfoButton.Click += SAMEEventsInfoButton_Click;
            // 
            // EventSAMESelectButton
            // 
            EventSAMESelectButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            EventSAMESelectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EventSAMESelectButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            EventSAMESelectButton.Location = new System.Drawing.Point(102, 93);
            EventSAMESelectButton.Name = "EventSAMESelectButton";
            EventSAMESelectButton.Size = new System.Drawing.Size(48, 23);
            EventSAMESelectButton.TabIndex = 36;
            EventSAMESelectButton.Text = "Select";
            EventSAMESelectButton.UseVisualStyleBackColor = false;
            EventSAMESelectButton.Click += EventSAMESelectButton_Click;
            // 
            // EventSAMEAddButton
            // 
            EventSAMEAddButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            EventSAMEAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EventSAMEAddButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            EventSAMEAddButton.Location = new System.Drawing.Point(54, 93);
            EventSAMEAddButton.Name = "EventSAMEAddButton";
            EventSAMEAddButton.Size = new System.Drawing.Size(42, 23);
            EventSAMEAddButton.TabIndex = 35;
            EventSAMEAddButton.Text = "Add";
            EventSAMEAddButton.UseVisualStyleBackColor = false;
            EventSAMEAddButton.Click += EventSAMEAddButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(6, 17);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(172, 15);
            label2.TabIndex = 6;
            label2.Text = "You can add SAME events here.";
            // 
            // EventSAMEBlacklistOutput
            // 
            EventSAMEBlacklistOutput.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            EventSAMEBlacklistOutput.BackColor = System.Drawing.Color.Black;
            EventSAMEBlacklistOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EventSAMEBlacklistOutput.Font = new System.Drawing.Font("Segoe UI", 12F);
            EventSAMEBlacklistOutput.ForeColor = System.Drawing.Color.White;
            EventSAMEBlacklistOutput.Location = new System.Drawing.Point(169, 37);
            EventSAMEBlacklistOutput.Multiline = true;
            EventSAMEBlacklistOutput.Name = "EventSAMEBlacklistOutput";
            EventSAMEBlacklistOutput.ReadOnly = true;
            EventSAMEBlacklistOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            EventSAMEBlacklistOutput.Size = new System.Drawing.Size(144, 104);
            EventSAMEBlacklistOutput.TabIndex = 34;
            EventSAMEBlacklistOutput.WordWrap = false;
            // 
            // EventSAMEBlacklistInput
            // 
            EventSAMEBlacklistInput.BackColor = System.Drawing.Color.Black;
            EventSAMEBlacklistInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EventSAMEBlacklistInput.Font = new System.Drawing.Font("Segoe UI", 24F);
            EventSAMEBlacklistInput.ForeColor = System.Drawing.Color.White;
            EventSAMEBlacklistInput.Location = new System.Drawing.Point(6, 37);
            EventSAMEBlacklistInput.MaxLength = 3;
            EventSAMEBlacklistInput.Name = "EventSAMEBlacklistInput";
            EventSAMEBlacklistInput.Size = new System.Drawing.Size(144, 50);
            EventSAMEBlacklistInput.TabIndex = 31;
            EventSAMEBlacklistInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // EventSAMEClearButton
            // 
            EventSAMEClearButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            EventSAMEClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            EventSAMEClearButton.Font = new System.Drawing.Font("Segoe UI", 8F);
            EventSAMEClearButton.Location = new System.Drawing.Point(6, 93);
            EventSAMEClearButton.Name = "EventSAMEClearButton";
            EventSAMEClearButton.Size = new System.Drawing.Size(42, 23);
            EventSAMEClearButton.TabIndex = 32;
            EventSAMEClearButton.Text = "Clear";
            EventSAMEClearButton.UseVisualStyleBackColor = false;
            EventSAMEClearButton.Click += EventSAMEClearButton_Click;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // EventConfigurationForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(449, 341);
            Controls.Add(EventWhitelistModeBox);
            Controls.Add(groupBox1);
            Controls.Add(TitleText);
            Controls.Add(label1);
            Controls.Add(LogoBox);
            Controls.Add(groupBox9);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EventConfigurationForm";
            Text = "SharpAlert - Event Selection";
            Load += EventConfigurationForm_Load;
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)LogoBox).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.CheckBox EventWhitelistModeBox;
        private System.Windows.Forms.Button NamedEventsInfoButton;
        private System.Windows.Forms.Button EventSelectButton;
        private System.Windows.Forms.Button EventAddButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox EventBlacklistOutput;
        private System.Windows.Forms.TextBox EventBlacklistInput;
        private System.Windows.Forms.Button EventClearButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button SAMEEventsInfoButton;
        private System.Windows.Forms.Button EventSAMESelectButton;
        private System.Windows.Forms.Button EventSAMEAddButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EventSAMEBlacklistOutput;
        private System.Windows.Forms.TextBox EventSAMEBlacklistInput;
        private System.Windows.Forms.Button EventSAMEClearButton;
        private System.Windows.Forms.Timer WindowShake;
    }
}