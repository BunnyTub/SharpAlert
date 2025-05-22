namespace SharpAlert.ConfigurationDialogs
{
    partial class QuickAccessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickAccessForm));
            this.label4 = new System.Windows.Forms.Label();
            this.volumeBar = new System.Windows.Forms.TrackBar();
            this.HideWhenSettingsOpen = new System.Windows.Forms.Timer(this.components);
            this.MainPanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 30);
            this.label4.TabIndex = 15;
            this.label4.Text = "Global\r\nVolume";
            // 
            // volumeBar
            // 
            this.volumeBar.LargeChange = 1;
            this.volumeBar.Location = new System.Drawing.Point(66, 4);
            this.volumeBar.Name = "volumeBar";
            this.volumeBar.Size = new System.Drawing.Size(227, 45);
            this.volumeBar.TabIndex = 16;
            this.volumeBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            // 
            // HideWhenSettingsOpen
            // 
            this.HideWhenSettingsOpen.Enabled = true;
            this.HideWhenSettingsOpen.Interval = 50;
            this.HideWhenSettingsOpen.Tick += new System.EventHandler(this.HideWhenSettingsOpen_Tick);
            // 
            // MainPanel
            // 
            this.MainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.MainPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(297, 53);
            this.MainPanel.TabIndex = 18;
            this.MainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.MainPanel_Paint);
            // 
            // QuickAccessForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(297, 53);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.volumeBar);
            this.Controls.Add(this.MainPanel);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "QuickAccessForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SharpAlert - Quick Center";
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.QuickAccessForm_Deactivate);
            this.Load += new System.EventHandler(this.QuickAccessForm_Load);
            this.VisibleChanged += new System.EventHandler(this.QuickAccessForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.volumeBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar volumeBar;
        private System.Windows.Forms.Timer HideWhenSettingsOpen;
        private System.Windows.Forms.Panel MainPanel;
    }
}