namespace SharpAlert
{
    partial class ChooseOwnershipForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChooseOwnershipForm));
            this.DoneButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.StationIdentifierInput = new System.Windows.Forms.TextBox();
            this.StationNameInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.TitleText.Text = "Mark down your station information.";
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
            // StationIdentifierInput
            // 
            this.StationIdentifierInput.BackColor = System.Drawing.Color.Black;
            this.StationIdentifierInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StationIdentifierInput.ForeColor = System.Drawing.Color.White;
            this.StationIdentifierInput.Location = new System.Drawing.Point(108, 57);
            this.StationIdentifierInput.Name = "StationIdentifierInput";
            this.StationIdentifierInput.Size = new System.Drawing.Size(170, 21);
            this.StationIdentifierInput.TabIndex = 37;
            this.ToolTipInformation.SetToolTip(this.StationIdentifierInput, "This is your station ID.");
            // 
            // StationNameInput
            // 
            this.StationNameInput.BackColor = System.Drawing.Color.Black;
            this.StationNameInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StationNameInput.ForeColor = System.Drawing.Color.White;
            this.StationNameInput.Location = new System.Drawing.Point(108, 99);
            this.StationNameInput.Name = "StationNameInput";
            this.StationNameInput.Size = new System.Drawing.Size(170, 21);
            this.StationNameInput.TabIndex = 39;
            this.ToolTipInformation.SetToolTip(this.StationNameInput, "This is your station\'s friendly name.");
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(9, 175);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(342, 41);
            this.label1.TabIndex = 13;
            this.label1.Text = "If you don\'t need these options, leave them blank.\r\nTo change these options later" +
    ", go to Settings.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F);
            this.label2.Location = new System.Drawing.Point(107, 39);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Station Identifier";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F);
            this.label3.Location = new System.Drawing.Point(107, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 15);
            this.label3.TabIndex = 38;
            this.label3.Text = "Station Name";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // ChooseOwnershipForm
            // 
            this.AcceptButton = this.DoneButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(532, 225);
            this.Controls.Add(this.StationNameInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.StationIdentifierInput);
            this.Controls.Add(this.label2);
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
            this.Name = "ChooseOwnershipForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Ownership Selection";
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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox StationIdentifierInput;
        private System.Windows.Forms.TextBox StationNameInput;
        private System.Windows.Forms.Label label3;
    }
}