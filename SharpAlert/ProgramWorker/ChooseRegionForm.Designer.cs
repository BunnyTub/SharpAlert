namespace SharpAlert
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseRegionForm));
            this.DoneButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.RegionUnitedStatesBox = new System.Windows.Forms.CheckBox();
            this.RegionCanadaBox = new System.Windows.Forms.CheckBox();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.RegionMexicoBox = new System.Windows.Forms.CheckBox();
            this.LinkButton = new System.Windows.Forms.Button();
            this.RegionUnitedStatesNWSBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneButton.Location = new System.Drawing.Point(451, 185);
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
            this.TitleText.Text = "Choose your region settings.";
            // 
            // RegionUnitedStatesBox
            // 
            this.RegionUnitedStatesBox.AutoSize = true;
            this.RegionUnitedStatesBox.Font = new System.Drawing.Font("Arial", 12F);
            this.RegionUnitedStatesBox.Location = new System.Drawing.Point(111, 42);
            this.RegionUnitedStatesBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.RegionUnitedStatesBox.Name = "RegionUnitedStatesBox";
            this.RegionUnitedStatesBox.Size = new System.Drawing.Size(184, 22);
            this.RegionUnitedStatesBox.TabIndex = 11;
            this.RegionUnitedStatesBox.Text = "United States (IPAWS)";
            this.ToolTipInformation.SetToolTip(this.RegionUnitedStatesBox, "You can receive alerts from the United States via IPAWS (EAS & WEA).");
            this.RegionUnitedStatesBox.UseVisualStyleBackColor = true;
            // 
            // RegionCanadaBox
            // 
            this.RegionCanadaBox.AutoSize = true;
            this.RegionCanadaBox.Font = new System.Drawing.Font("Arial", 12F);
            this.RegionCanadaBox.Location = new System.Drawing.Point(111, 98);
            this.RegionCanadaBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.RegionCanadaBox.Name = "RegionCanadaBox";
            this.RegionCanadaBox.Size = new System.Drawing.Size(153, 22);
            this.RegionCanadaBox.TabIndex = 13;
            this.RegionCanadaBox.Text = "Canada (NAADS)";
            this.ToolTipInformation.SetToolTip(this.RegionCanadaBox, "You can receive alerts from Canada via NAADS (National Alert Aggregation and Diss" +
        "emination System).");
            this.RegionCanadaBox.UseVisualStyleBackColor = true;
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
            // RegionMexicoBox
            // 
            this.RegionMexicoBox.AutoSize = true;
            this.RegionMexicoBox.Font = new System.Drawing.Font("Arial", 12F);
            this.RegionMexicoBox.Location = new System.Drawing.Point(111, 126);
            this.RegionMexicoBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.RegionMexicoBox.Name = "RegionMexicoBox";
            this.RegionMexicoBox.Size = new System.Drawing.Size(159, 22);
            this.RegionMexicoBox.TabIndex = 14;
            this.RegionMexicoBox.Text = "Mexico (SASMEX)";
            this.ToolTipInformation.SetToolTip(this.RegionMexicoBox, "You can receive alerts from Mexico via SASMEX (Sistema de Alerta Sísmica Mexicano" +
        ").");
            this.RegionMexicoBox.UseVisualStyleBackColor = true;
            // 
            // LinkButton
            // 
            this.LinkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.LinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.LinkButton.Location = new System.Drawing.Point(451, 159);
            this.LinkButton.Margin = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.LinkButton.Name = "LinkButton";
            this.LinkButton.Size = new System.Drawing.Size(72, 23);
            this.LinkButton.TabIndex = 15;
            this.LinkButton.Text = "Custom";
            this.ToolTipInformation.SetToolTip(this.LinkButton, "Click this button if you have custom servers (XML feed only).");
            this.LinkButton.UseVisualStyleBackColor = false;
            this.LinkButton.Click += new System.EventHandler(this.LinkButton_Click);
            // 
            // RegionUnitedStatesNWSBox
            // 
            this.RegionUnitedStatesNWSBox.AutoSize = true;
            this.RegionUnitedStatesNWSBox.Font = new System.Drawing.Font("Arial", 12F);
            this.RegionUnitedStatesNWSBox.Location = new System.Drawing.Point(111, 70);
            this.RegionUnitedStatesNWSBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.RegionUnitedStatesNWSBox.Name = "RegionUnitedStatesNWSBox";
            this.RegionUnitedStatesNWSBox.Size = new System.Drawing.Size(172, 22);
            this.RegionUnitedStatesNWSBox.TabIndex = 12;
            this.RegionUnitedStatesNWSBox.Text = "United States (NWS)";
            this.ToolTipInformation.SetToolTip(this.RegionUnitedStatesNWSBox, "You can receive alerts from the United States via NWS (National Weather Service)." +
        "");
            this.RegionUnitedStatesNWSBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(9, 182);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "To change these options later, go to Settings.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Arial", 12F);
            this.checkBox1.Location = new System.Drawing.Point(111, 154);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(193, 22);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Brazil (IDAP) - Disabled";
            this.ToolTipInformation.SetToolTip(this.checkBox1, "You can receive alerts from Brazil via IDAP (Divulgação de Alertas Públicos).");
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            // 
            // ChooseRegionForm
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(532, 217);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.RegionUnitedStatesNWSBox);
            this.Controls.Add(this.LinkButton);
            this.Controls.Add(this.RegionMexicoBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RegionCanadaBox);
            this.Controls.Add(this.RegionUnitedStatesBox);
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
            this.Name = "ChooseRegionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Region Selection";
            this.TopMost = true;
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
        private System.Windows.Forms.CheckBox RegionUnitedStatesBox;
        private System.Windows.Forms.CheckBox RegionCanadaBox;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox RegionMexicoBox;
        private System.Windows.Forms.Button LinkButton;
        private System.Windows.Forms.CheckBox RegionUnitedStatesNWSBox;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}