namespace SharpAlert.AlertComponents
{
    partial class ManualAlertRelayForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualAlertRelayForm));
            this.AllowButton = new System.Windows.Forms.Button();
            this.DenyButton = new System.Windows.Forms.Button();
            this.SubtitleText = new System.Windows.Forms.Label();
            this.AutoRelayTimer = new System.Windows.Forms.Timer(this.components);
            this.AutomaticRelayProgressBar = new System.Windows.Forms.ProgressBar();
            this.AlertText = new System.Windows.Forms.TextBox();
            this.OutlinePanel = new System.Windows.Forms.Panel();
            this.EnsureTopWindow = new System.Windows.Forms.Timer(this.components);
            this.PauseButton = new System.Windows.Forms.Button();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.OutlinePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AllowButton
            // 
            this.AllowButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AllowButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.AllowButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.AllowButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.AllowButton.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.AllowButton.Location = new System.Drawing.Point(698, 12);
            this.AllowButton.Name = "AllowButton";
            this.AllowButton.Size = new System.Drawing.Size(82, 50);
            this.AllowButton.TabIndex = 0;
            this.AllowButton.Text = "FORWARD";
            this.AllowButton.UseVisualStyleBackColor = false;
            this.AllowButton.Click += new System.EventHandler(this.AllowButton_Click);
            // 
            // DenyButton
            // 
            this.DenyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DenyButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.DenyButton.DialogResult = System.Windows.Forms.DialogResult.No;
            this.DenyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DenyButton.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Bold);
            this.DenyButton.Location = new System.Drawing.Point(698, 68);
            this.DenyButton.Name = "DenyButton";
            this.DenyButton.Size = new System.Drawing.Size(82, 161);
            this.DenyButton.TabIndex = 1;
            this.DenyButton.Text = "STOP";
            this.DenyButton.UseVisualStyleBackColor = false;
            this.DenyButton.Click += new System.EventHandler(this.DenyButton_Click);
            // 
            // SubtitleText
            // 
            this.SubtitleText.AutoSize = true;
            this.SubtitleText.Font = new System.Drawing.Font("Arial", 18F);
            this.SubtitleText.Location = new System.Drawing.Point(9, 9);
            this.SubtitleText.Margin = new System.Windows.Forms.Padding(0);
            this.SubtitleText.Name = "SubtitleText";
            this.SubtitleText.Size = new System.Drawing.Size(252, 27);
            this.SubtitleText.TabIndex = 2;
            this.SubtitleText.Text = "Short Alert Description";
            // 
            // AutoRelayTimer
            // 
            this.AutoRelayTimer.Interval = 1000;
            this.AutoRelayTimer.Tick += new System.EventHandler(this.AutoRelayTimer_Tick);
            // 
            // AutomaticRelayProgressBar
            // 
            this.AutomaticRelayProgressBar.Location = new System.Drawing.Point(12, 235);
            this.AutomaticRelayProgressBar.Maximum = 1000;
            this.AutomaticRelayProgressBar.Name = "AutomaticRelayProgressBar";
            this.AutomaticRelayProgressBar.Size = new System.Drawing.Size(680, 23);
            this.AutomaticRelayProgressBar.Step = 1;
            this.AutomaticRelayProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.AutomaticRelayProgressBar.TabIndex = 3;
            // 
            // AlertText
            // 
            this.AlertText.BackColor = System.Drawing.Color.Black;
            this.AlertText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AlertText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlertText.Font = new System.Drawing.Font("Arial", 18F);
            this.AlertText.ForeColor = System.Drawing.Color.White;
            this.AlertText.Location = new System.Drawing.Point(0, 0);
            this.AlertText.Multiline = true;
            this.AlertText.Name = "AlertText";
            this.AlertText.ReadOnly = true;
            this.AlertText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AlertText.Size = new System.Drawing.Size(678, 186);
            this.AlertText.TabIndex = 9;
            // 
            // OutlinePanel
            // 
            this.OutlinePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutlinePanel.Controls.Add(this.AlertText);
            this.OutlinePanel.Location = new System.Drawing.Point(12, 41);
            this.OutlinePanel.Name = "OutlinePanel";
            this.OutlinePanel.Size = new System.Drawing.Size(680, 188);
            this.OutlinePanel.TabIndex = 10;
            // 
            // EnsureTopWindow
            // 
            this.EnsureTopWindow.Enabled = true;
            this.EnsureTopWindow.Interval = 1000;
            this.EnsureTopWindow.Tick += new System.EventHandler(this.EnsureTopWindow_Tick);
            // 
            // PauseButton
            // 
            this.PauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PauseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(180)))), ((int)(((byte)(0)))));
            this.PauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.PauseButton.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.PauseButton.ForeColor = System.Drawing.Color.Black;
            this.PauseButton.Location = new System.Drawing.Point(698, 235);
            this.PauseButton.Name = "PauseButton";
            this.PauseButton.Size = new System.Drawing.Size(82, 23);
            this.PauseButton.TabIndex = 11;
            this.PauseButton.Text = "EXTEND";
            this.ToolTipInformation.SetToolTip(this.PauseButton, "Resets and extends the timer to one minute.");
            this.PauseButton.UseVisualStyleBackColor = false;
            this.PauseButton.Click += new System.EventHandler(this.PauseButton_Click);
            // 
            // ToolTipInformation
            // 
            this.ToolTipInformation.AutomaticDelay = 250;
            this.ToolTipInformation.AutoPopDelay = 15000;
            this.ToolTipInformation.BackColor = System.Drawing.Color.White;
            this.ToolTipInformation.ForeColor = System.Drawing.Color.Black;
            this.ToolTipInformation.InitialDelay = 250;
            this.ToolTipInformation.IsBalloon = true;
            this.ToolTipInformation.ReshowDelay = 50;
            this.ToolTipInformation.ToolTipTitle = "What does this do?";
            // 
            // ManualAlertRelayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(792, 270);
            this.ControlBox = false;
            this.Controls.Add(this.PauseButton);
            this.Controls.Add(this.AutomaticRelayProgressBar);
            this.Controls.Add(this.OutlinePanel);
            this.Controls.Add(this.SubtitleText);
            this.Controls.Add(this.AllowButton);
            this.Controls.Add(this.DenyButton);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManualAlertRelayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Forward Consent";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ManualAlertRelay_Load);
            this.Shown += new System.EventHandler(this.ManualAlertRelay_Shown);
            this.VisibleChanged += new System.EventHandler(this.ManualAlertRelay_VisibleChanged);
            this.OutlinePanel.ResumeLayout(false);
            this.OutlinePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button AllowButton;
        private System.Windows.Forms.Button DenyButton;
        private System.Windows.Forms.Label SubtitleText;
        private System.Windows.Forms.Timer AutoRelayTimer;
        private System.Windows.Forms.ProgressBar AutomaticRelayProgressBar;
        private System.Windows.Forms.TextBox AlertText;
        private System.Windows.Forms.Panel OutlinePanel;
        private System.Windows.Forms.Timer EnsureTopWindow;
        private System.Windows.Forms.Button PauseButton;
        private System.Windows.Forms.ToolTip ToolTipInformation;
    }
}
