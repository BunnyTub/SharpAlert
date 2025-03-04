namespace SharpAlert
{
    partial class AltTrayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AltTrayForm));
            this.label1 = new System.Windows.Forms.Label();
            this.ConsoleButton = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.OpenSettingsButton = new System.Windows.Forms.Button();
            this.SaveSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "SharpAlert v0.0";
            // 
            // ConsoleButton
            // 
            this.ConsoleButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConsoleButton.Location = new System.Drawing.Point(12, 27);
            this.ConsoleButton.Name = "ConsoleButton";
            this.ConsoleButton.Size = new System.Drawing.Size(124, 23);
            this.ConsoleButton.TabIndex = 1;
            this.ConsoleButton.Text = "Show Console";
            this.ConsoleButton.UseVisualStyleBackColor = true;
            this.ConsoleButton.Click += new System.EventHandler(this.ConsoleButton_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ImportButton.Location = new System.Drawing.Point(12, 56);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(124, 23);
            this.ImportButton.TabIndex = 2;
            this.ImportButton.Text = "Import CAP Data";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // OpenSettingsButton
            // 
            this.OpenSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OpenSettingsButton.Location = new System.Drawing.Point(12, 85);
            this.OpenSettingsButton.Name = "OpenSettingsButton";
            this.OpenSettingsButton.Size = new System.Drawing.Size(124, 23);
            this.OpenSettingsButton.TabIndex = 3;
            this.OpenSettingsButton.Text = "Open Settings";
            this.OpenSettingsButton.UseVisualStyleBackColor = true;
            this.OpenSettingsButton.Click += new System.EventHandler(this.OpenSettingsButton_Click);
            // 
            // SaveSettingsButton
            // 
            this.SaveSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SaveSettingsButton.Location = new System.Drawing.Point(12, 114);
            this.SaveSettingsButton.Name = "SaveSettingsButton";
            this.SaveSettingsButton.Size = new System.Drawing.Size(124, 23);
            this.SaveSettingsButton.TabIndex = 4;
            this.SaveSettingsButton.Text = "Save Settings";
            this.SaveSettingsButton.UseVisualStyleBackColor = true;
            this.SaveSettingsButton.Click += new System.EventHandler(this.SaveSettingsButton_Click);
            // 
            // AltTrayForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(148, 149);
            this.Controls.Add(this.SaveSettingsButton);
            this.Controls.Add(this.OpenSettingsButton);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.ConsoleButton);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AltTrayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Tray";
            this.Load += new System.EventHandler(this.AltTrayForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConsoleButton;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.Button OpenSettingsButton;
        private System.Windows.Forms.Button SaveSettingsButton;
    }
}