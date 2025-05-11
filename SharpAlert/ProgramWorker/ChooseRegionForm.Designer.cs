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
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // DoneButton
            // 
            this.DoneButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DoneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DoneButton.Location = new System.Drawing.Point(469, 203);
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
            this.TitleText.Text = "Choose countries to receive alerts from.";
            // 
            // RegionUnitedStatesBox
            // 
            this.RegionUnitedStatesBox.AutoSize = true;
            this.RegionUnitedStatesBox.Font = new System.Drawing.Font("Arial", 12F);
            this.RegionUnitedStatesBox.Location = new System.Drawing.Point(111, 42);
            this.RegionUnitedStatesBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.RegionUnitedStatesBox.Name = "RegionUnitedStatesBox";
            this.RegionUnitedStatesBox.Size = new System.Drawing.Size(121, 22);
            this.RegionUnitedStatesBox.TabIndex = 11;
            this.RegionUnitedStatesBox.Text = "United States";
            this.ToolTipInformation.SetToolTip(this.RegionUnitedStatesBox, "You can receive alerts from the United States via IPAWS (EAS & WEA).");
            this.RegionUnitedStatesBox.UseVisualStyleBackColor = true;
            // 
            // RegionCanadaBox
            // 
            this.RegionCanadaBox.AutoSize = true;
            this.RegionCanadaBox.Font = new System.Drawing.Font("Arial", 12F);
            this.RegionCanadaBox.Location = new System.Drawing.Point(111, 70);
            this.RegionCanadaBox.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            this.RegionCanadaBox.Name = "RegionCanadaBox";
            this.RegionCanadaBox.Size = new System.Drawing.Size(83, 22);
            this.RegionCanadaBox.TabIndex = 12;
            this.RegionCanadaBox.Text = "Canada";
            this.ToolTipInformation.SetToolTip(this.RegionCanadaBox, "You can receive alerts from Canada via NAADs (Alert Ready).");
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
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(9, 203);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 26);
            this.label1.TabIndex = 13;
            this.label1.Text = "SharpAlert will close immediately once you\'re done.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ChooseRegionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(553, 238);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RegionCanadaBox);
            this.Controls.Add(this.RegionUnitedStatesBox);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.DoneButton);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "ChooseRegionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Region Selection";
            this.TopMost = true;
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
    }
}