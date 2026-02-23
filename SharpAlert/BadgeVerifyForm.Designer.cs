namespace SharpAlert
{
    partial class BadgeVerifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BadgeVerifyForm));
            IDIconBox = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            DoneButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)IDIconBox).BeginInit();
            SuspendLayout();
            // 
            // IDIconBox
            // 
            IDIconBox.Image = Properties.Resources.id_card_regular;
            IDIconBox.Location = new System.Drawing.Point(12, 12);
            IDIconBox.Name = "IDIconBox";
            IDIconBox.Size = new System.Drawing.Size(128, 128);
            IDIconBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            IDIconBox.TabIndex = 0;
            IDIconBox.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(143, 12);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(539, 37);
            label1.TabIndex = 1;
            label1.Text = "You're not old enough to use this feature";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 16F);
            label2.Location = new System.Drawing.Point(148, 49);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(605, 90);
            label2.TabIndex = 2;
            label2.Text = "We couldn't verify that you're 18 or older, so you cannot\r\nuse this feature right now. To continue, verify your age\r\nusing a government ID, social security number, or credit card.";
            // 
            // DoneButton
            // 
            DoneButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DoneButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DoneButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DoneButton.Font = new System.Drawing.Font("Segoe UI", 16F);
            DoneButton.ForeColor = System.Drawing.Color.White;
            DoneButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            DoneButton.Location = new System.Drawing.Point(660, 155);
            DoneButton.Name = "DoneButton";
            DoneButton.Size = new System.Drawing.Size(128, 40);
            DoneButton.TabIndex = 14;
            DoneButton.Text = "Close";
            DoneButton.UseMnemonic = false;
            DoneButton.UseVisualStyleBackColor = false;
            DoneButton.Click += DoneButton_Click;
            // 
            // BadgeVerifyForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(800, 207);
            Controls.Add(DoneButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(IDIconBox);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BadgeVerifyForm";
            Text = "SharpAlert - You're not old enough to use this feature";
            Load += BadgeVerifyForm_Load;
            ((System.ComponentModel.ISupportInitialize)IDIconBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox IDIconBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button DoneButton;
    }
}