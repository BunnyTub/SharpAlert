namespace SharpAlert.ConfigurationDialogs
{
    partial class CreditsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreditsForm));
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            linkLabel2 = new System.Windows.Forms.LinkLabel();
            linkLabel3 = new System.Windows.Forms.LinkLabel();
            linkLabel4 = new System.Windows.Forms.LinkLabel();
            WindowShake = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(9, 9);
            label5.Margin = new System.Windows.Forms.Padding(0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(399, 15);
            label5.TabIndex = 7;
            label5.Text = "SharpAlert is a project created by BunnyTub, written and built in C# (.NET).";
            label5.DoubleClick += label5_DoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = System.Drawing.Color.Lime;
            label1.Location = new System.Drawing.Point(9, 39);
            label1.Margin = new System.Windows.Forms.Padding(0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(189, 15);
            label1.TabIndex = 8;
            label1.Text = "Libraries used (Tool generated list):";
            label1.Click += label1_Click;
            label1.DoubleClick += label1_DoubleClick;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            label2.ForeColor = System.Drawing.Color.Lime;
            label2.Location = new System.Drawing.Point(9, 54);
            label2.Margin = new System.Windows.Forms.Padding(0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(564, 147);
            label2.TabIndex = 9;
            label2.Text = resources.GetString("label2.Text");
            // 
            // linkLabel1
            // 
            linkLabel1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            linkLabel1.AutoSize = true;
            linkLabel1.LinkColor = System.Drawing.Color.Pink;
            linkLabel1.Location = new System.Drawing.Point(9, 252);
            linkLabel1.Margin = new System.Windows.Forms.Padding(0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new System.Drawing.Size(208, 15);
            linkLabel1.TabIndex = 101;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Credit to SecludedHusky for EAS2Text.";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // linkLabel2
            // 
            linkLabel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            linkLabel2.AutoSize = true;
            linkLabel2.LinkColor = System.Drawing.Color.Pink;
            linkLabel2.Location = new System.Drawing.Point(9, 267);
            linkLabel2.Margin = new System.Windows.Forms.Padding(0);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new System.Drawing.Size(260, 15);
            linkLabel2.TabIndex = 102;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Credit to BoxedApplePie for character drawings.";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // linkLabel3
            // 
            linkLabel3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            linkLabel3.AutoSize = true;
            linkLabel3.LinkColor = System.Drawing.Color.Pink;
            linkLabel3.Location = new System.Drawing.Point(9, 214);
            linkLabel3.Margin = new System.Windows.Forms.Padding(0);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new System.Drawing.Size(338, 15);
            linkLabel3.TabIndex = 0;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "This application and its contents are the property of BunnyTub.";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // linkLabel4
            // 
            linkLabel4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            linkLabel4.AutoSize = true;
            linkLabel4.LinkColor = System.Drawing.Color.Pink;
            linkLabel4.Location = new System.Drawing.Point(9, 237);
            linkLabel4.Margin = new System.Windows.Forms.Padding(0);
            linkLabel4.Name = "linkLabel4";
            linkLabel4.Size = new System.Drawing.Size(520, 15);
            linkLabel4.TabIndex = 103;
            linkLabel4.TabStop = true;
            linkLabel4.Text = "Credit to SkewerKing for webhook icons. (as of Nov 16, 2025. Icons are stored on a remote server.)";
            linkLabel4.LinkClicked += linkLabel4_LinkClicked;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // CreditsForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(582, 291);
            Controls.Add(linkLabel4);
            Controls.Add(linkLabel3);
            Controls.Add(linkLabel2);
            Controls.Add(linkLabel1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label5);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CreditsForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "About SharpAlert";
            HelpButtonClicked += CreditsForm_HelpButtonClicked;
            Load += CreditsForm_Load;
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.Timer WindowShake;
    }
}
