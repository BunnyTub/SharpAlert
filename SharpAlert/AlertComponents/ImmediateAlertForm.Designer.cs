namespace SharpAlert.AlertComponents
{
    partial class ImmediateAlertForm
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
            this.AutoExit = new System.Windows.Forms.Timer(this.components);
            this.AlertPanel = new System.Windows.Forms.Panel();
            this.AlertText = new System.Windows.Forms.TextBox();
            this.FlashTaskbarStatus = new System.Windows.Forms.Timer(this.components);
            this.AutoTTS = new System.Windows.Forms.Timer(this.components);
            this.AutoScroller = new System.Windows.Forms.Timer(this.components);
            this.MainPanel = new System.Windows.Forms.Panel();
            this.InfoTip = new System.Windows.Forms.ToolTip(this.components);
            this.DismissButton = new System.Windows.Forms.Button();
            this.TerminateSelf = new System.Windows.Forms.Timer(this.components);
            this.OutlineContainerPanel = new System.Windows.Forms.Panel();
            this.TitleText = new System.Windows.Forms.Label();
            this.RightOutlinePanel = new System.Windows.Forms.Panel();
            this.LeftOutlinePanel = new System.Windows.Forms.Panel();
            this.BottomOutlinePanel = new System.Windows.Forms.Panel();
            this.WindowFlash = new System.Windows.Forms.Timer(this.components);
            this.EnsureTopWindow = new System.Windows.Forms.Timer(this.components);
            this.AlertPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.OutlineContainerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // AutoExit
            // 
            this.AutoExit.Interval = 300000;
            this.AutoExit.Tick += new System.EventHandler(this.AutoExit_Tick);
            // 
            // AlertPanel
            // 
            this.AlertPanel.BackColor = System.Drawing.Color.Black;
            this.AlertPanel.Controls.Add(this.AlertText);
            this.AlertPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlertPanel.Font = new System.Drawing.Font("Arial", 9F);
            this.AlertPanel.Location = new System.Drawing.Point(0, 0);
            this.AlertPanel.Margin = new System.Windows.Forms.Padding(0);
            this.AlertPanel.Name = "AlertPanel";
            this.AlertPanel.Size = new System.Drawing.Size(1264, 592);
            this.AlertPanel.TabIndex = 5;
            // 
            // AlertText
            // 
            this.AlertText.BackColor = System.Drawing.Color.Black;
            this.AlertText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AlertText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlertText.Font = new System.Drawing.Font("Arial", 34F);
            this.AlertText.ForeColor = System.Drawing.Color.White;
            this.AlertText.HideSelection = false;
            this.AlertText.Location = new System.Drawing.Point(0, 0);
            this.AlertText.Multiline = true;
            this.AlertText.Name = "AlertText";
            this.AlertText.ReadOnly = true;
            this.AlertText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.AlertText.Size = new System.Drawing.Size(1264, 592);
            this.AlertText.TabIndex = 3;
            this.AlertText.TextChanged += new System.EventHandler(this.AlertText_TextChanged);
            this.AlertText.DoubleClick += new System.EventHandler(this.AlertText_DoubleClick);
            this.AlertText.Enter += new System.EventHandler(this.AlertText_Enter);
            // 
            // FlashTaskbarStatus
            // 
            this.FlashTaskbarStatus.Enabled = true;
            this.FlashTaskbarStatus.Interval = 500;
            this.FlashTaskbarStatus.Tick += new System.EventHandler(this.FlashTaskbarStatus_Tick);
            // 
            // AutoTTS
            // 
            this.AutoTTS.Interval = 50;
            this.AutoTTS.Tick += new System.EventHandler(this.AutoTTS_Tick);
            // 
            // AutoScroller
            // 
            this.AutoScroller.Enabled = true;
            this.AutoScroller.Interval = 65;
            this.AutoScroller.Tick += new System.EventHandler(this.AutoScroll_Tick);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.AlertPanel);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(8, 120);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(1264, 592);
            this.MainPanel.TabIndex = 9;
            // 
            // InfoTip
            // 
            this.InfoTip.AutomaticDelay = 250;
            this.InfoTip.AutoPopDelay = 15000;
            this.InfoTip.BackColor = System.Drawing.Color.White;
            this.InfoTip.ForeColor = System.Drawing.Color.Black;
            this.InfoTip.InitialDelay = 250;
            this.InfoTip.IsBalloon = true;
            this.InfoTip.ReshowDelay = 50;
            this.InfoTip.ToolTipTitle = "What does this do?";
            // 
            // DismissButton
            // 
            this.DismissButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DismissButton.BackColor = System.Drawing.Color.White;
            this.DismissButton.Enabled = false;
            this.DismissButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DismissButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            this.DismissButton.ForeColor = System.Drawing.Color.Black;
            this.DismissButton.Location = new System.Drawing.Point(1233, 3);
            this.DismissButton.Name = "DismissButton";
            this.DismissButton.Size = new System.Drawing.Size(35, 35);
            this.DismissButton.TabIndex = 11;
            this.DismissButton.Text = "✖";
            this.InfoTip.SetToolTip(this.DismissButton, "Closes the alert.");
            this.DismissButton.UseVisualStyleBackColor = false;
            this.DismissButton.Click += new System.EventHandler(this.DismissButton_Click);
            // 
            // TerminateSelf
            // 
            this.TerminateSelf.Enabled = true;
            this.TerminateSelf.Interval = 500;
            this.TerminateSelf.Tick += new System.EventHandler(this.TerminateSelf_Tick);
            // 
            // OutlineContainerPanel
            // 
            this.OutlineContainerPanel.Controls.Add(this.MainPanel);
            this.OutlineContainerPanel.Controls.Add(this.DismissButton);
            this.OutlineContainerPanel.Controls.Add(this.TitleText);
            this.OutlineContainerPanel.Controls.Add(this.RightOutlinePanel);
            this.OutlineContainerPanel.Controls.Add(this.LeftOutlinePanel);
            this.OutlineContainerPanel.Controls.Add(this.BottomOutlinePanel);
            this.OutlineContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OutlineContainerPanel.Location = new System.Drawing.Point(0, 0);
            this.OutlineContainerPanel.Name = "OutlineContainerPanel";
            this.OutlineContainerPanel.Size = new System.Drawing.Size(1280, 720);
            this.OutlineContainerPanel.TabIndex = 10;
            // 
            // TitleText
            // 
            this.TitleText.BackColor = System.Drawing.Color.Red;
            this.TitleText.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleText.Font = new System.Drawing.Font("Arial", 72F, System.Drawing.FontStyle.Bold);
            this.TitleText.Location = new System.Drawing.Point(8, 0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(1264, 120);
            this.TitleText.TabIndex = 15;
            this.TitleText.Text = "EMERGENCY ALERT";
            this.TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RightOutlinePanel
            // 
            this.RightOutlinePanel.BackColor = System.Drawing.Color.Red;
            this.RightOutlinePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RightOutlinePanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightOutlinePanel.ForeColor = System.Drawing.Color.White;
            this.RightOutlinePanel.Location = new System.Drawing.Point(1272, 0);
            this.RightOutlinePanel.Margin = new System.Windows.Forms.Padding(10);
            this.RightOutlinePanel.Name = "RightOutlinePanel";
            this.RightOutlinePanel.Size = new System.Drawing.Size(8, 712);
            this.RightOutlinePanel.TabIndex = 17;
            // 
            // LeftOutlinePanel
            // 
            this.LeftOutlinePanel.BackColor = System.Drawing.Color.Red;
            this.LeftOutlinePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LeftOutlinePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftOutlinePanel.ForeColor = System.Drawing.Color.White;
            this.LeftOutlinePanel.Location = new System.Drawing.Point(0, 0);
            this.LeftOutlinePanel.Margin = new System.Windows.Forms.Padding(10);
            this.LeftOutlinePanel.Name = "LeftOutlinePanel";
            this.LeftOutlinePanel.Size = new System.Drawing.Size(8, 712);
            this.LeftOutlinePanel.TabIndex = 16;
            // 
            // BottomOutlinePanel
            // 
            this.BottomOutlinePanel.BackColor = System.Drawing.Color.Red;
            this.BottomOutlinePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BottomOutlinePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomOutlinePanel.ForeColor = System.Drawing.Color.White;
            this.BottomOutlinePanel.Location = new System.Drawing.Point(0, 712);
            this.BottomOutlinePanel.Margin = new System.Windows.Forms.Padding(10);
            this.BottomOutlinePanel.Name = "BottomOutlinePanel";
            this.BottomOutlinePanel.Size = new System.Drawing.Size(1280, 8);
            this.BottomOutlinePanel.TabIndex = 18;
            // 
            // WindowFlash
            // 
            this.WindowFlash.Interval = 500;
            this.WindowFlash.Tick += new System.EventHandler(this.WindowFlash_Tick);
            // 
            // EnsureTopWindow
            // 
            this.EnsureTopWindow.Enabled = true;
            this.EnsureTopWindow.Interval = 1000;
            this.EnsureTopWindow.Tick += new System.EventHandler(this.EnsureTopWindow_Tick);
            // 
            // ImmediateAlertForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1920, 1080);
            this.ControlBox = false;
            this.Controls.Add(this.OutlineContainerPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImmediateAlertForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SharpAlert - Alert Panel";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AlertForm_FormClosed);
            this.Load += new System.EventHandler(this.AlertForm_Load);
            this.Shown += new System.EventHandler(this.AlertForm_Shown);
            this.AlertPanel.ResumeLayout(false);
            this.AlertPanel.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.OutlineContainerPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer AutoExit;
        private System.Windows.Forms.Panel AlertPanel;
        private System.Windows.Forms.TextBox AlertText;
        private System.Windows.Forms.Timer FlashTaskbarStatus;
        private System.Windows.Forms.Timer AutoTTS;
        private System.Windows.Forms.Timer AutoScroller;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ToolTip InfoTip;
        private System.Windows.Forms.Timer TerminateSelf;
        private System.Windows.Forms.Panel OutlineContainerPanel;
        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Panel BottomOutlinePanel;
        private System.Windows.Forms.Panel RightOutlinePanel;
        private System.Windows.Forms.Panel LeftOutlinePanel;
        private System.Windows.Forms.Timer WindowFlash;
        private System.Windows.Forms.Timer EnsureTopWindow;
        //private GMap.NET.WindowsForms.GMapControl GMapPoint;
    }
}


