namespace SharpAlert.ConfigurationDialogs
{
    partial class EventsAdditionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventsAdditionForm));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CountyCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StateCombo = new System.Windows.Forms.ComboBox();
            this.SAMEAddButton = new System.Windows.Forms.Button();
            this.BusyLock = new System.Windows.Forms.Timer(this.components);
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            this.BusyLockText = new System.Windows.Forms.Label();
            this.groupBox7.SuspendLayout();
            this.ConfigurationPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.label3);
            this.groupBox7.Controls.Add(this.label2);
            this.groupBox7.Controls.Add(this.CountyCombo);
            this.groupBox7.Controls.Add(this.label1);
            this.groupBox7.Controls.Add(this.StateCombo);
            this.groupBox7.Controls.Add(this.SAMEAddButton);
            this.groupBox7.ForeColor = System.Drawing.Color.White;
            this.groupBox7.Location = new System.Drawing.Point(12, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(401, 145);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "SAME Events";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(279, 30);
            this.label3.TabIndex = 32;
            this.label3.Text = "Select your state and county from the fields above.\r\nWhen you\'re done, click add " +
    "to move it to the list.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 31;
            this.label2.Text = "County/Area";
            // 
            // CountyCombo
            // 
            this.CountyCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CountyCombo.BackColor = System.Drawing.Color.Black;
            this.CountyCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CountyCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CountyCombo.ForeColor = System.Drawing.Color.White;
            this.CountyCombo.FormattingEnabled = true;
            this.CountyCombo.Location = new System.Drawing.Point(98, 49);
            this.CountyCombo.Name = "CountyCombo";
            this.CountyCombo.Size = new System.Drawing.Size(297, 23);
            this.CountyCombo.TabIndex = 30;
            this.CountyCombo.SelectedIndexChanged += new System.EventHandler(this.CountyCombo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 15);
            this.label1.TabIndex = 29;
            this.label1.Text = "State/Territory";
            // 
            // StateCombo
            // 
            this.StateCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StateCombo.BackColor = System.Drawing.Color.Black;
            this.StateCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.StateCombo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StateCombo.ForeColor = System.Drawing.Color.White;
            this.StateCombo.FormattingEnabled = true;
            this.StateCombo.Location = new System.Drawing.Point(98, 20);
            this.StateCombo.Name = "StateCombo";
            this.StateCombo.Size = new System.Drawing.Size(297, 23);
            this.StateCombo.TabIndex = 28;
            this.StateCombo.SelectedIndexChanged += new System.EventHandler(this.StateCombo_SelectedIndexChanged);
            // 
            // SAMEAddButton
            // 
            this.SAMEAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SAMEAddButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SAMEAddButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SAMEAddButton.Font = new System.Drawing.Font("Arial", 9F);
            this.SAMEAddButton.Location = new System.Drawing.Point(330, 116);
            this.SAMEAddButton.Name = "SAMEAddButton";
            this.SAMEAddButton.Size = new System.Drawing.Size(65, 23);
            this.SAMEAddButton.TabIndex = 1;
            this.SAMEAddButton.Text = "Add";
            this.SAMEAddButton.UseVisualStyleBackColor = false;
            this.SAMEAddButton.Click += new System.EventHandler(this.SAMEAddButton_Click);
            // 
            // BusyLock
            // 
            this.BusyLock.Tick += new System.EventHandler(this.BusyLock_Tick);
            // 
            // ConfigurationPanel
            // 
            this.ConfigurationPanel.Controls.Add(this.groupBox7);
            this.ConfigurationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigurationPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfigurationPanel.Name = "ConfigurationPanel";
            this.ConfigurationPanel.Size = new System.Drawing.Size(425, 169);
            this.ConfigurationPanel.TabIndex = 5;
            // 
            // BusyLockText
            // 
            this.BusyLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BusyLockText.Font = new System.Drawing.Font("Arial", 12F);
            this.BusyLockText.Location = new System.Drawing.Point(0, 0);
            this.BusyLockText.Name = "BusyLockText";
            this.BusyLockText.Size = new System.Drawing.Size(425, 169);
            this.BusyLockText.TabIndex = 16;
            this.BusyLockText.Text = "Please wait or dismiss all alerts to configure settings.";
            this.BusyLockText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EventsAdditionForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(425, 169);
            this.Controls.Add(this.ConfigurationPanel);
            this.Controls.Add(this.BusyLockText);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EventsAdditionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SharpAlert Events";
            this.Load += new System.EventHandler(this.LocationsAdditionForm_Load);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ConfigurationPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button SAMEAddButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CountyCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox StateCombo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer BusyLock;
        private System.Windows.Forms.Panel ConfigurationPanel;
        private System.Windows.Forms.Label BusyLockText;
    }
}
