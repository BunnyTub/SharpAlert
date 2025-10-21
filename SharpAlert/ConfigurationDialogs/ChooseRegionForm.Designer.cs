namespace SharpAlert.ConfigurationDialogs
{
    partial class ChooseRegionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseRegionForm));
            DoneButton = new System.Windows.Forms.Button();
            LogoBox = new System.Windows.Forms.PictureBox();
            TitleText = new System.Windows.Forms.Label();
            RegionUnitedStatesBox = new System.Windows.Forms.CheckBox();
            RegionCanadaBox = new System.Windows.Forms.CheckBox();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            RegionMexicoBox = new System.Windows.Forms.CheckBox();
            LinkButton = new System.Windows.Forms.Button();
            RegionUnitedStatesNWSBox = new System.Windows.Forms.CheckBox();
            RegionBrazilBox = new System.Windows.Forms.CheckBox();
            ChangeLaterText = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)LogoBox).BeginInit();
            SuspendLayout();
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Location = new System.Drawing.Point(451, 229);
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
            TitleText.Font = new System.Drawing.Font("Arial", 16F);
            TitleText.Location = new System.Drawing.Point(105, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(400, 30);
            TitleText.TabIndex = 3;
            TitleText.Text = "Choose your region settings.";
            // 
            // RegionUnitedStatesBox
            // 
            RegionUnitedStatesBox.AutoSize = true;
            RegionUnitedStatesBox.Font = new System.Drawing.Font("Arial", 12F);
            RegionUnitedStatesBox.Location = new System.Drawing.Point(111, 42);
            RegionUnitedStatesBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            RegionUnitedStatesBox.Name = "RegionUnitedStatesBox";
            RegionUnitedStatesBox.Size = new System.Drawing.Size(184, 22);
            RegionUnitedStatesBox.TabIndex = 11;
            RegionUnitedStatesBox.Text = "United States (IPAWS)";
            ToolTipInformation.SetToolTip(RegionUnitedStatesBox, "You can receive alerts from the United States via IPAWS (EAS & WEA).");
            RegionUnitedStatesBox.UseVisualStyleBackColor = true;
            // 
            // RegionCanadaBox
            // 
            RegionCanadaBox.AutoSize = true;
            RegionCanadaBox.Font = new System.Drawing.Font("Arial", 12F);
            RegionCanadaBox.Location = new System.Drawing.Point(111, 98);
            RegionCanadaBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            RegionCanadaBox.Name = "RegionCanadaBox";
            RegionCanadaBox.Size = new System.Drawing.Size(153, 22);
            RegionCanadaBox.TabIndex = 13;
            RegionCanadaBox.Text = "Canada (NAADS)";
            ToolTipInformation.SetToolTip(RegionCanadaBox, "You can receive alerts from Canada via NAADS (National Alert Aggregation and Dissemination System).");
            RegionCanadaBox.UseVisualStyleBackColor = true;
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
            // RegionMexicoBox
            // 
            RegionMexicoBox.AutoSize = true;
            RegionMexicoBox.Font = new System.Drawing.Font("Arial", 12F);
            RegionMexicoBox.Location = new System.Drawing.Point(111, 126);
            RegionMexicoBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            RegionMexicoBox.Name = "RegionMexicoBox";
            RegionMexicoBox.Size = new System.Drawing.Size(159, 22);
            RegionMexicoBox.TabIndex = 14;
            RegionMexicoBox.Text = "Mexico (SASMEX)";
            ToolTipInformation.SetToolTip(RegionMexicoBox, "You can receive alerts from Mexico via SASMEX (Sistema de Alerta Sísmica Mexicano).");
            RegionMexicoBox.UseVisualStyleBackColor = true;
            // 
            // LinkButton
            // 
            LinkButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            LinkButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            LinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            LinkButton.Location = new System.Drawing.Point(451, 203);
            LinkButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            LinkButton.Name = "LinkButton";
            LinkButton.Size = new System.Drawing.Size(72, 23);
            LinkButton.TabIndex = 16;
            LinkButton.Text = "Custom";
            ToolTipInformation.SetToolTip(LinkButton, "Click this button if you have custom servers (XML feed only).");
            LinkButton.UseVisualStyleBackColor = false;
            LinkButton.Click += LinkButton_Click;
            // 
            // RegionUnitedStatesNWSBox
            // 
            RegionUnitedStatesNWSBox.AutoSize = true;
            RegionUnitedStatesNWSBox.Font = new System.Drawing.Font("Arial", 12F);
            RegionUnitedStatesNWSBox.Location = new System.Drawing.Point(111, 70);
            RegionUnitedStatesNWSBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            RegionUnitedStatesNWSBox.Name = "RegionUnitedStatesNWSBox";
            RegionUnitedStatesNWSBox.Size = new System.Drawing.Size(172, 22);
            RegionUnitedStatesNWSBox.TabIndex = 12;
            RegionUnitedStatesNWSBox.Text = "United States (NWS)";
            ToolTipInformation.SetToolTip(RegionUnitedStatesNWSBox, "You can receive alerts from the United States via NWS (National Weather Service).");
            RegionUnitedStatesNWSBox.UseVisualStyleBackColor = true;
            // 
            // RegionBrazilBox
            // 
            RegionBrazilBox.AutoSize = true;
            RegionBrazilBox.Font = new System.Drawing.Font("Arial", 12F);
            RegionBrazilBox.Location = new System.Drawing.Point(111, 154);
            RegionBrazilBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            RegionBrazilBox.Name = "RegionBrazilBox";
            RegionBrazilBox.Size = new System.Drawing.Size(117, 22);
            RegionBrazilBox.TabIndex = 15;
            RegionBrazilBox.Text = "Brazil (IDAP)";
            ToolTipInformation.SetToolTip(RegionBrazilBox, "You can receive alerts from Brazil via IDAP (Divulgação de Alertas Públicos).");
            RegionBrazilBox.UseVisualStyleBackColor = true;
            // 
            // ChangeLaterText
            // 
            ChangeLaterText.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            ChangeLaterText.Font = new System.Drawing.Font("Arial", 9F);
            ChangeLaterText.ForeColor = System.Drawing.Color.Yellow;
            ChangeLaterText.LinkArea = new System.Windows.Forms.LinkArea(0, 96);
            ChangeLaterText.LinkColor = System.Drawing.Color.Yellow;
            ChangeLaterText.Location = new System.Drawing.Point(9, 179);
            ChangeLaterText.Margin = new System.Windows.Forms.Padding(0);
            ChangeLaterText.Name = "ChangeLaterText";
            ChangeLaterText.Size = new System.Drawing.Size(442, 73);
            ChangeLaterText.TabIndex = 13;
            ChangeLaterText.TabStop = true;
            ChangeLaterText.Text = "Some networks may have trouble accessing Brazil (IDAP).\r\nClick here to perform a connection test.\r\n\r\nTo change these options later, go to Settings.";
            ChangeLaterText.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            ChangeLaterText.UseCompatibleTextRendering = true;
            ChangeLaterText.LinkClicked += ChangeLaterText_LinkClicked;
            // 
            // ChooseRegionForm
            // 
            AcceptButton = DoneButton;
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(532, 261);
            Controls.Add(RegionBrazilBox);
            Controls.Add(RegionUnitedStatesNWSBox);
            Controls.Add(LinkButton);
            Controls.Add(RegionMexicoBox);
            Controls.Add(ChangeLaterText);
            Controls.Add(RegionCanadaBox);
            Controls.Add(RegionUnitedStatesBox);
            Controls.Add(TitleText);
            Controls.Add(LogoBox);
            Controls.Add(DoneButton);
            Font = new System.Drawing.Font("Arial", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            HelpButton = true;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ChooseRegionForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Region Selection";
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
        private System.Windows.Forms.CheckBox RegionUnitedStatesBox;
        private System.Windows.Forms.CheckBox RegionCanadaBox;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.LinkLabel ChangeLaterText;
        private System.Windows.Forms.CheckBox RegionMexicoBox;
        private System.Windows.Forms.Button LinkButton;
        private System.Windows.Forms.CheckBox RegionUnitedStatesNWSBox;
        private System.Windows.Forms.CheckBox RegionBrazilBox;
    }
}
