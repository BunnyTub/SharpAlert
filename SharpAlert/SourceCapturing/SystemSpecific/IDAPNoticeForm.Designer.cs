namespace SharpAlert.SourceCapturing.SystemSpecific
{
    partial class IDAPNoticeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IDAPNoticeForm));
            UnderstandButton = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            label2 = new System.Windows.Forms.Label();
            TestConnection = new System.Windows.Forms.Timer(components);
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // UnderstandButton
            // 
            UnderstandButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            UnderstandButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            UnderstandButton.Location = new System.Drawing.Point(405, 161);
            UnderstandButton.Margin = new System.Windows.Forms.Padding(6, 12, 6, 12);
            UnderstandButton.Name = "UnderstandButton";
            UnderstandButton.Size = new System.Drawing.Size(104, 23);
            UnderstandButton.TabIndex = 1;
            UnderstandButton.Text = "Understandable";
            UnderstandButton.UseVisualStyleBackColor = false;
            UnderstandButton.Click += UnderstandButton_Click;
            // 
            // label1
            // 
            label1.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            label1.Location = new System.Drawing.Point(17, 17);
            label1.Margin = new System.Windows.Forms.Padding(8);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(490, 139);
            label1.TabIndex = 2;
            label1.Text = resources.GetString("label1.Text");
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(18, 18, 18);
            panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            panel1.Controls.Add(label2);
            panel1.Location = new System.Drawing.Point(15, 152);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(381, 32);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            label2.Location = new System.Drawing.Point(0, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(379, 30);
            label2.TabIndex = 0;
            label2.Text = "Testing connection... Please allow up to 1 minute.";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TestConnection
            // 
            TestConnection.Enabled = true;
            TestConnection.Interval = 1000;
            TestConnection.Tick += TestConnection_Tick;
            // 
            // IDAPNoticeForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(524, 198);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(UnderstandButton);
            ForeColor = System.Drawing.Color.White;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "IDAPNoticeForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Brazil (IDAP) Connection Test";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Button UnderstandButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer TestConnection;
    }
}