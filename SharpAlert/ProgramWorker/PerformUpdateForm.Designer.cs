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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PerformUpdateForm));
            TitleText = new System.Windows.Forms.Label();
            DescriptionText = new System.Windows.Forms.Label();
            CheckTimeUntilAutoInstall = new System.Windows.Forms.Timer(components);
            InstallButton = new System.Windows.Forms.Button();
            HideThisMessageButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // TitleText
            // 
            TitleText.Font = new System.Drawing.Font("Segoe UI", 16F);
            TitleText.Location = new System.Drawing.Point(9, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(400, 30);
            TitleText.TabIndex = 23;
            TitleText.Text = "There's an update available!";
            // 
            // DescriptionText
            // 
            DescriptionText.Font = new System.Drawing.Font("Segoe UI", 12F);
            DescriptionText.Location = new System.Drawing.Point(12, 39);
            DescriptionText.Margin = new System.Windows.Forms.Padding(0);
            DescriptionText.Name = "DescriptionText";
            DescriptionText.Size = new System.Drawing.Size(400, 48);
            DescriptionText.TabIndex = 27;
            DescriptionText.Text = "SharpAlert will install updates automatically in:\r\n...";
            // 
            // CheckTimeUntilAutoInstall
            // 
            CheckTimeUntilAutoInstall.Enabled = true;
            CheckTimeUntilAutoInstall.Interval = 300;
            CheckTimeUntilAutoInstall.Tick += CheckTimeUntilAutoInstall_Tick;
            // 
            // InstallButton
            // 
            InstallButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            InstallButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            InstallButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            InstallButton.Location = new System.Drawing.Point(343, 140);
            InstallButton.Margin = new System.Windows.Forms.Padding(0);
            InstallButton.Name = "InstallButton";
            InstallButton.Size = new System.Drawing.Size(72, 23);
            InstallButton.TabIndex = 28;
            InstallButton.Text = "Install";
            InstallButton.UseVisualStyleBackColor = false;
            InstallButton.Click += InstallButton_Click;
            // 
            // HideThisMessageButton
            // 
            HideThisMessageButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            HideThisMessageButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            HideThisMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            HideThisMessageButton.Location = new System.Drawing.Point(9, 140);
            HideThisMessageButton.Margin = new System.Windows.Forms.Padding(0);
            HideThisMessageButton.Name = "HideThisMessageButton";
            HideThisMessageButton.Size = new System.Drawing.Size(173, 23);
            HideThisMessageButton.TabIndex = 29;
            HideThisMessageButton.Text = "Hide this message";
            HideThisMessageButton.UseVisualStyleBackColor = false;
            HideThisMessageButton.Click += RemindMeLaterButton_Click;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Segoe UI", 9F);
            label1.Location = new System.Drawing.Point(9, 87);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(406, 50);
            label1.TabIndex = 30;
            label1.Text = "You'll be prompted for\r\nadministrative privileges.";
            label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // PerformUpdateForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(424, 172);
            ControlBox = false;
            Controls.Add(HideThisMessageButton);
            Controls.Add(InstallButton);
            Controls.Add(DescriptionText);
            Controls.Add(TitleText);
            Controls.Add(label1);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PerformUpdateForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Updates Found";
            TopMost = true;
            FormClosing += UpdateForm_FormClosing;
            Load += UpdateForm_Load;
            Shown += SetupForm_Shown;
            ResumeLayout(false);

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
