namespace SharpAlert.ConfigurationDialogs.DiscordPanels
{
    partial class DiscordRichPresenceUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TitleText = new System.Windows.Forms.Label();
            EnableDiscordRichPresenceBox = new System.Windows.Forms.CheckBox();
            BatteryGroup = new System.Windows.Forms.GroupBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            checkBox1 = new System.Windows.Forms.CheckBox();
            label3 = new System.Windows.Forms.Label();
            BatteryGroup.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // TitleText
            // 
            TitleText.AutoSize = true;
            TitleText.Location = new System.Drawing.Point(0, 0);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(735, 15);
            TitleText.TabIndex = 42;
            TitleText.Text = "These options reflect the data that is shown on your Discord profile (only if Discord is installed, and if you allow others to see your activity).";
            // 
            // EnableDiscordRichPresenceBox
            // 
            EnableDiscordRichPresenceBox.AutoSize = true;
            EnableDiscordRichPresenceBox.Location = new System.Drawing.Point(3, 18);
            EnableDiscordRichPresenceBox.Name = "EnableDiscordRichPresenceBox";
            EnableDiscordRichPresenceBox.Size = new System.Drawing.Size(180, 19);
            EnableDiscordRichPresenceBox.TabIndex = 43;
            EnableDiscordRichPresenceBox.Text = "Enable Discord Rich Presence";
            EnableDiscordRichPresenceBox.UseVisualStyleBackColor = true;
            EnableDiscordRichPresenceBox.CheckedChanged += EnableDiscordRichPresenceBox_CheckedChanged;
            // 
            // BatteryGroup
            // 
            BatteryGroup.Controls.Add(groupBox1);
            BatteryGroup.Controls.Add(label3);
            BatteryGroup.ForeColor = System.Drawing.Color.White;
            BatteryGroup.Location = new System.Drawing.Point(3, 43);
            BatteryGroup.Name = "BatteryGroup";
            BatteryGroup.Size = new System.Drawing.Size(285, 92);
            BatteryGroup.TabIndex = 44;
            BatteryGroup.TabStop = false;
            BatteryGroup.Text = "Visibility (This is not available for use yet!)";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(checkBox1);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(6, 39);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(273, 47);
            groupBox1.TabIndex = 46;
            groupBox1.TabStop = false;
            groupBox1.Text = "Message Type";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Enabled = false;
            checkBox1.Location = new System.Drawing.Point(6, 22);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new System.Drawing.Size(237, 19);
            checkBox1.TabIndex = 45;
            checkBox1.Text = "Update (This option is not available yet!)";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(6, 19);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(273, 17);
            label3.TabIndex = 14;
            label3.Text = "Choose alerts that can be shown on your profile.";
            // 
            // DiscordRichPresenceUserControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            Controls.Add(BatteryGroup);
            Controls.Add(EnableDiscordRichPresenceBox);
            Controls.Add(TitleText);
            ForeColor = System.Drawing.Color.White;
            Name = "DiscordRichPresenceUserControl";
            Size = new System.Drawing.Size(773, 392);
            Load += DiscordRichPresenceUserControl_Load;
            BatteryGroup.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.CheckBox EnableDiscordRichPresenceBox;
        private System.Windows.Forms.GroupBox BatteryGroup;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
