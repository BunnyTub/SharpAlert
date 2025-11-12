namespace SharpAlert.ProgramWorker
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            TitleText = new System.Windows.Forms.Label();
            DescriptionText = new System.Windows.Forms.Label();
            TextUpdater = new System.Windows.Forms.Timer(components);
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
            TitleText.Text = "SharpAlert is updating";
            TitleText.UseWaitCursor = true;
            // 
            // DescriptionText
            // 
            DescriptionText.Font = new System.Drawing.Font("Segoe UI", 12F);
            DescriptionText.Location = new System.Drawing.Point(12, 39);
            DescriptionText.Margin = new System.Windows.Forms.Padding(0);
            DescriptionText.Name = "DescriptionText";
            DescriptionText.Size = new System.Drawing.Size(400, 24);
            DescriptionText.TabIndex = 27;
            DescriptionText.Text = "Please wait...";
            DescriptionText.UseWaitCursor = true;
            // 
            // TextUpdater
            // 
            TextUpdater.Enabled = true;
            TextUpdater.Interval = 1000;
            TextUpdater.Tick += TextUpdater_Tick;
            // 
            // UpdateForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(424, 71);
            Controls.Add(DescriptionText);
            Controls.Add(TitleText);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "UpdateForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Updating (please wait...)";
            TopMost = true;
            UseWaitCursor = true;
            FormClosing += UpdateForm_FormClosing;
            Load += UpdateForm_Load;
            Shown += SetupForm_Shown;
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Label DescriptionText;
        private System.Windows.Forms.Timer TextUpdater;
    }
}
