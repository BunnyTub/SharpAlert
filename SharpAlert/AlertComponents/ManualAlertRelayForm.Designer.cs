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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManualAlertRelayForm));
            AllowButton = new System.Windows.Forms.Button();
            DenyButton = new System.Windows.Forms.Button();
            SubtitleText = new System.Windows.Forms.Label();
            AutoRelayTimer = new System.Windows.Forms.Timer(components);
            AutomaticRelayProgressBar = new System.Windows.Forms.ProgressBar();
            AlertText = new System.Windows.Forms.TextBox();
            OutlinePanel = new System.Windows.Forms.Panel();
            EnsureTopWindow = new System.Windows.Forms.Timer(components);
            PauseButton = new System.Windows.Forms.Button();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            OutlinePanel.SuspendLayout();
            SuspendLayout();
            // 
            // AllowButton
            // 
            AllowButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            AllowButton.BackColor = System.Drawing.Color.FromArgb(0, 180, 0);
            AllowButton.DialogResult = System.Windows.Forms.DialogResult.Yes;
            AllowButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            AllowButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            AllowButton.Location = new System.Drawing.Point(698, 12);
            AllowButton.Name = "AllowButton";
            AllowButton.Size = new System.Drawing.Size(82, 50);
            AllowButton.TabIndex = 0;
            AllowButton.Text = "FORWARD";
            AllowButton.UseVisualStyleBackColor = false;
            AllowButton.Click += AllowButton_Click;
            // 
            // DenyButton
            // 
            DenyButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            DenyButton.BackColor = System.Drawing.Color.FromArgb(180, 0, 0);
            DenyButton.DialogResult = System.Windows.Forms.DialogResult.No;
            DenyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DenyButton.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            DenyButton.Location = new System.Drawing.Point(698, 68);
            DenyButton.Name = "DenyButton";
            DenyButton.Size = new System.Drawing.Size(82, 161);
            DenyButton.TabIndex = 1;
            DenyButton.Text = "STOP";
            DenyButton.UseVisualStyleBackColor = false;
            DenyButton.Click += DenyButton_Click;
            // 
            // SubtitleText
            // 
            SubtitleText.AutoSize = true;
            SubtitleText.Font = new System.Drawing.Font("Segoe UI", 18F);
            SubtitleText.Location = new System.Drawing.Point(9, 9);
            SubtitleText.Margin = new System.Windows.Forms.Padding(0);
            SubtitleText.Name = "SubtitleText";
            SubtitleText.Size = new System.Drawing.Size(256, 32);
            SubtitleText.TabIndex = 2;
            SubtitleText.Text = "Short Alert Description";
            // 
            // AutoRelayTimer
            // 
            AutoRelayTimer.Interval = 1000;
            AutoRelayTimer.Tick += AutoRelayTimer_Tick;
            // 
            // AutomaticRelayProgressBar
            // 
            AutomaticRelayProgressBar.Location = new System.Drawing.Point(12, 235);
            AutomaticRelayProgressBar.Maximum = 1000;
            AutomaticRelayProgressBar.Name = "AutomaticRelayProgressBar";
            AutomaticRelayProgressBar.Size = new System.Drawing.Size(680, 23);
            AutomaticRelayProgressBar.Step = 1;
            AutomaticRelayProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            AutomaticRelayProgressBar.TabIndex = 3;
            // 
            // AlertText
            // 
            AlertText.BackColor = System.Drawing.Color.Black;
            AlertText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            AlertText.Dock = System.Windows.Forms.DockStyle.Fill;
            AlertText.Font = new System.Drawing.Font("Segoe UI", 18F);
            AlertText.ForeColor = System.Drawing.Color.White;
            AlertText.Location = new System.Drawing.Point(0, 0);
            AlertText.Multiline = true;
            AlertText.Name = "AlertText";
            AlertText.ReadOnly = true;
            AlertText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            AlertText.Size = new System.Drawing.Size(678, 186);
            AlertText.TabIndex = 9;
            // 
            // OutlinePanel
            // 
            OutlinePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            OutlinePanel.Controls.Add(AlertText);
            OutlinePanel.Location = new System.Drawing.Point(12, 41);
            OutlinePanel.Name = "OutlinePanel";
            OutlinePanel.Size = new System.Drawing.Size(680, 188);
            OutlinePanel.TabIndex = 10;
            // 
            // EnsureTopWindow
            // 
            EnsureTopWindow.Enabled = true;
            EnsureTopWindow.Interval = 1000;
            EnsureTopWindow.Tick += EnsureTopWindow_Tick;
            // 
            // PauseButton
            // 
            PauseButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            PauseButton.BackColor = System.Drawing.Color.FromArgb(255, 180, 0);
            PauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            PauseButton.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            PauseButton.ForeColor = System.Drawing.Color.Black;
            PauseButton.Location = new System.Drawing.Point(698, 235);
            PauseButton.Name = "PauseButton";
            PauseButton.Size = new System.Drawing.Size(82, 23);
            PauseButton.TabIndex = 11;
            PauseButton.Text = "EXTEND";
            ToolTipInformation.SetToolTip(PauseButton, "Resets and extends the timer to one minute.");
            PauseButton.UseVisualStyleBackColor = false;
            PauseButton.Click += PauseButton_Click;
            // 
            // ToolTipInformation
            // 
            ToolTipInformation.AutomaticDelay = 250;
            ToolTipInformation.AutoPopDelay = 15000;
            ToolTipInformation.BackColor = System.Drawing.Color.White;
            ToolTipInformation.ForeColor = System.Drawing.Color.Black;
            ToolTipInformation.InitialDelay = 250;
            ToolTipInformation.IsBalloon = true;
            ToolTipInformation.ReshowDelay = 50;
            ToolTipInformation.ToolTipTitle = "What does this do?";
            // 
            // ManualAlertRelayForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(792, 270);
            ControlBox = false;
            Controls.Add(PauseButton);
            Controls.Add(AutomaticRelayProgressBar);
            Controls.Add(OutlinePanel);
            Controls.Add(SubtitleText);
            Controls.Add(AllowButton);
            Controls.Add(DenyButton);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ManualAlertRelayForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Forward Consent";
            TopMost = true;
            Load += ManualAlertRelay_Load;
            Shown += ManualAlertRelay_Shown;
            VisibleChanged += ManualAlertRelay_VisibleChanged;
            OutlinePanel.ResumeLayout(false);
            OutlinePanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

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
