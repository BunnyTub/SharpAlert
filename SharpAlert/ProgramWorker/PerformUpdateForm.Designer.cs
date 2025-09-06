namespace SharpAlert.ProgramWorker
{
    partial class PerformUpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerformUpdateForm));
            this.TitleText = new System.Windows.Forms.Label();
            this.DescriptionText = new System.Windows.Forms.Label();
            this.CheckTimeUntilAutoInstall = new System.Windows.Forms.Timer(this.components);
            this.InstallButton = new System.Windows.Forms.Button();
            this.HideThisMessageButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleText
            // 
            this.TitleText.Font = new System.Drawing.Font("Arial", 16F);
            this.TitleText.Location = new System.Drawing.Point(9, 9);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(400, 30);
            this.TitleText.TabIndex = 23;
            this.TitleText.Text = "SharpAlert found updates";
            // 
            // DescriptionText
            // 
            this.DescriptionText.Font = new System.Drawing.Font("Arial", 12F);
            this.DescriptionText.Location = new System.Drawing.Point(12, 39);
            this.DescriptionText.Margin = new System.Windows.Forms.Padding(0);
            this.DescriptionText.Name = "DescriptionText";
            this.DescriptionText.Size = new System.Drawing.Size(400, 48);
            this.DescriptionText.TabIndex = 27;
            this.DescriptionText.Text = "SharpAlert will install updates automatically in:\r\n...";
            // 
            // CheckTimeUntilAutoInstall
            // 
            this.CheckTimeUntilAutoInstall.Enabled = true;
            this.CheckTimeUntilAutoInstall.Interval = 300;
            this.CheckTimeUntilAutoInstall.Tick += new System.EventHandler(this.CheckTimeUntilAutoInstall_Tick);
            // 
            // InstallButton
            // 
            this.InstallButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.InstallButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.InstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.InstallButton.Location = new System.Drawing.Point(343, 140);
            this.InstallButton.Margin = new System.Windows.Forms.Padding(0);
            this.InstallButton.Name = "InstallButton";
            this.InstallButton.Size = new System.Drawing.Size(72, 23);
            this.InstallButton.TabIndex = 28;
            this.InstallButton.Text = "Install";
            this.InstallButton.UseVisualStyleBackColor = false;
            this.InstallButton.Click += new System.EventHandler(this.InstallButton_Click);
            // 
            // HideThisMessageButton
            // 
            this.HideThisMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.HideThisMessageButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.HideThisMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.HideThisMessageButton.Location = new System.Drawing.Point(9, 140);
            this.HideThisMessageButton.Margin = new System.Windows.Forms.Padding(0);
            this.HideThisMessageButton.Name = "HideThisMessageButton";
            this.HideThisMessageButton.Size = new System.Drawing.Size(173, 23);
            this.HideThisMessageButton.TabIndex = 29;
            this.HideThisMessageButton.Text = "Hide this message";
            this.HideThisMessageButton.UseVisualStyleBackColor = false;
            this.HideThisMessageButton.Click += new System.EventHandler(this.RemindMeLaterButton_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 9F);
            this.label1.Location = new System.Drawing.Point(9, 87);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(406, 50);
            this.label1.TabIndex = 30;
            this.label1.Text = "You\'ll be prompted for\r\nadministrative privileges.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // PerformUpdateForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(424, 172);
            this.ControlBox = false;
            this.Controls.Add(this.HideThisMessageButton);
            this.Controls.Add(this.InstallButton);
            this.Controls.Add(this.DescriptionText);
            this.Controls.Add(this.TitleText);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PerformUpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Updates Found";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UpdateForm_FormClosing);
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.Shown += new System.EventHandler(this.SetupForm_Shown);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Label DescriptionText;
        private System.Windows.Forms.Timer CheckTimeUntilAutoInstall;
        private System.Windows.Forms.Button InstallButton;
        private System.Windows.Forms.Button HideThisMessageButton;
        private System.Windows.Forms.Label label1;
    }
}
