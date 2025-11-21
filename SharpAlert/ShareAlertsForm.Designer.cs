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
            SuspendLayout();
            // 
            // TitleText
            // 
            TitleText.AutoSize = true;
            TitleText.Font = new System.Drawing.Font("Segoe UI", 24F);
            TitleText.Location = new System.Drawing.Point(9, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(595, 45);
            TitleText.TabIndex = 0;
            TitleText.Text = "Share alerts over an internet connection!";
            // 
            // StatusText
            // 
            StatusText.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            StatusText.AutoSize = true;
            StatusText.Font = new System.Drawing.Font("Segoe UI", 16F);
            StatusText.Location = new System.Drawing.Point(574, 240);
            StatusText.Margin = new System.Windows.Forms.Padding(0);
            StatusText.Name = "StatusText";
            StatusText.Size = new System.Drawing.Size(160, 30);
            StatusText.TabIndex = 1;
            StatusText.Text = "Getting ready...";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 16F);
            label1.Location = new System.Drawing.Point(9, 54);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(721, 60);
            label1.TabIndex = 2;
            label1.Text = "Copy and share the code below to get someone else connected to you.\r\nOnce they connect, they'll receive your alerts until either one disconnects.";
            // 
            // ShareAlertsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(743, 279);
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
    }
}