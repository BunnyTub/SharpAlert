namespace SharpAlert
{
    partial class ShareAlertsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShareAlertsForm));
            TitleText = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            StatusText = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            UseCodeButton = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // TitleText
            // 
            TitleText.AutoSize = true;
            TitleText.Font = new System.Drawing.Font("Segoe UI", 18F);
            TitleText.Location = new System.Drawing.Point(9, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(449, 32);
            TitleText.TabIndex = 0;
            TitleText.Text = "Share alerts over an internet connection!";
            // 
            // StatusText
            // 
            StatusText.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            StatusText.Font = new System.Drawing.Font("Segoe UI", 16F);
            StatusText.Location = new System.Drawing.Point(258, 148);
            StatusText.Margin = new System.Windows.Forms.Padding(0);
            StatusText.Name = "StatusText";
            StatusText.Size = new System.Drawing.Size(399, 30);
            StatusText.TabIndex = 1;
            StatusText.Text = "Getting ready...";
            StatusText.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 14F);
            label1.Location = new System.Drawing.Point(9, 41);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(629, 50);
            label1.TabIndex = 2;
            label1.Text = "Copy and share the code below to get someone else connected to you.\r\nOnce they connect, they'll receive your alerts until either one disconnects.";
            // 
            // UseCodeButton
            // 
            UseCodeButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            UseCodeButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            UseCodeButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            UseCodeButton.Location = new System.Drawing.Point(9, 155);
            UseCodeButton.Margin = new System.Windows.Forms.Padding(0);
            UseCodeButton.Name = "UseCodeButton";
            UseCodeButton.Size = new System.Drawing.Size(72, 23);
            UseCodeButton.TabIndex = 29;
            UseCodeButton.Text = "Use Code";
            UseCodeButton.UseVisualStyleBackColor = false;
            // 
            // ShareAlertsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(666, 187);
            Controls.Add(UseCodeButton);
            Controls.Add(label1);
            Controls.Add(StatusText);
            Controls.Add(TitleText);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ShareAlertsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Alert Sharing";
            FormClosing += ShareAlertsForm_FormClosing;
            Load += ShareAlertsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label StatusText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button UseCodeButton;
    }
}