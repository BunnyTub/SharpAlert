namespace SharpAlert.AlertComponents
{
    partial class BoardAlertForm
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
            AutoExit = new System.Windows.Forms.Timer(components);
            AlertPanel = new System.Windows.Forms.Panel();
            AlertText = new System.Windows.Forms.TextBox();
            AutoTTS = new System.Windows.Forms.Timer(components);
            MouseMoving = new System.Windows.Forms.Timer(components);
            AutoScroller = new System.Windows.Forms.Timer(components);
            MainPanel = new System.Windows.Forms.Panel();
            AutoHideButtons = new System.Windows.Forms.Timer(components);
            InfoTip = new System.Windows.Forms.ToolTip(components);
            DismissButton = new System.Windows.Forms.Button();
            LinkButton = new System.Windows.Forms.Button();
            TerminateSelf = new System.Windows.Forms.Timer(components);
            OutlineContainerPanel = new System.Windows.Forms.Panel();
            TitleText = new System.Windows.Forms.Label();
            RightOutlinePanel = new System.Windows.Forms.Panel();
            LeftOutlinePanel = new System.Windows.Forms.Panel();
            BottomOutlinePanel = new System.Windows.Forms.Panel();
            WindowFlash = new System.Windows.Forms.Timer(components);
            EnsureTopWindow = new System.Windows.Forms.Timer(components);
            WindowFlashSmooth = new System.Windows.Forms.Timer(components);
            AlertPanel.SuspendLayout();
            MainPanel.SuspendLayout();
            OutlineContainerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // AutoExit
            // 
            AutoExit.Interval = 300000;
            AutoExit.Tick += AutoExit_Tick;
            // 
            // AlertPanel
            // 
            AlertPanel.BackColor = System.Drawing.Color.Black;
            AlertPanel.Controls.Add(AlertText);
            AlertPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            AlertPanel.Font = new System.Drawing.Font("Arial", 18F);
            AlertPanel.Location = new System.Drawing.Point(0, 0);
            AlertPanel.Margin = new System.Windows.Forms.Padding(0);
            AlertPanel.Name = "AlertPanel";
            AlertPanel.Size = new System.Drawing.Size(1264, 600);
            AlertPanel.TabIndex = 5;
            // 
            // AlertText
            // 
            AlertText.BackColor = System.Drawing.Color.Black;
            AlertText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            AlertText.Dock = System.Windows.Forms.DockStyle.Fill;
            AlertText.Font = new System.Drawing.Font("Arial", 48F);
            AlertText.ForeColor = System.Drawing.Color.White;
            AlertText.HideSelection = false;
            AlertText.Location = new System.Drawing.Point(0, 0);
            AlertText.Multiline = true;
            AlertText.Name = "AlertText";
            AlertText.ReadOnly = true;
            AlertText.Size = new System.Drawing.Size(1264, 600);
            AlertText.TabIndex = 3;
            AlertText.TextChanged += AlertText_TextChanged;
            AlertText.DoubleClick += AlertText_DoubleClick;
            AlertText.Enter += AlertText_Enter;
            // 
            // AutoTTS
            // 
            AutoTTS.Interval = 50;
            AutoTTS.Tick += AutoTTS_Tick;
            // 
            // MouseMoving
            // 
            MouseMoving.Tick += MouseMoving_Tick;
            // 
            // AutoScroller
            // 
            AutoScroller.Interval = 50;
            AutoScroller.Tick += AutoScroll_Tick;
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(AlertPanel);
            MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            MainPanel.Location = new System.Drawing.Point(8, 112);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new System.Drawing.Size(1264, 600);
            MainPanel.TabIndex = 9;
            // 
            // AutoHideButtons
            // 
            AutoHideButtons.Interval = 10000;
            AutoHideButtons.Tick += AutoHideButtons_Tick;
            // 
            // InfoTip
            // 
            InfoTip.AutomaticDelay = 250;
            InfoTip.AutoPopDelay = 15000;
            InfoTip.BackColor = System.Drawing.Color.White;
            InfoTip.ForeColor = System.Drawing.Color.Black;
            InfoTip.InitialDelay = 250;
            InfoTip.IsBalloon = true;
            InfoTip.ReshowDelay = 50;
            InfoTip.ToolTipTitle = "What does this do?";
            // 
            // DismissButton
            // 
            DismissButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            DismissButton.BackColor = System.Drawing.Color.White;
            DismissButton.Enabled = false;
            DismissButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DismissButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            DismissButton.ForeColor = System.Drawing.Color.Black;
            DismissButton.Location = new System.Drawing.Point(1233, 3);
            DismissButton.Name = "DismissButton";
            DismissButton.Size = new System.Drawing.Size(35, 35);
            DismissButton.TabIndex = 11;
            DismissButton.Text = "✖";
            InfoTip.SetToolTip(DismissButton, "Closes the alert.");
            DismissButton.UseVisualStyleBackColor = false;
            DismissButton.Visible = false;
            DismissButton.Click += DismissButton_Click;
            // 
            // LinkButton
            // 
            LinkButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            LinkButton.BackColor = System.Drawing.Color.White;
            LinkButton.Enabled = false;
            LinkButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            LinkButton.Font = new System.Drawing.Font("Segoe UI Emoji", 9F);
            LinkButton.ForeColor = System.Drawing.Color.Black;
            LinkButton.Location = new System.Drawing.Point(1192, 3);
            LinkButton.Name = "LinkButton";
            LinkButton.Size = new System.Drawing.Size(35, 35);
            LinkButton.TabIndex = 13;
            LinkButton.Text = "🔗";
            InfoTip.SetToolTip(LinkButton, "Opens the alert URL if there is one included.");
            LinkButton.UseVisualStyleBackColor = false;
            LinkButton.Visible = false;
            LinkButton.Click += LinkButton_Click;
            // 
            // TerminateSelf
            // 
            TerminateSelf.Enabled = true;
            TerminateSelf.Interval = 500;
            TerminateSelf.Tick += TerminateSelf_Tick;
            // 
            // OutlineContainerPanel
            // 
            OutlineContainerPanel.Controls.Add(LinkButton);
            OutlineContainerPanel.Controls.Add(MainPanel);
            OutlineContainerPanel.Controls.Add(DismissButton);
            OutlineContainerPanel.Controls.Add(TitleText);
            OutlineContainerPanel.Controls.Add(RightOutlinePanel);
            OutlineContainerPanel.Controls.Add(LeftOutlinePanel);
            OutlineContainerPanel.Controls.Add(BottomOutlinePanel);
            OutlineContainerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            OutlineContainerPanel.Location = new System.Drawing.Point(0, 0);
            OutlineContainerPanel.Name = "OutlineContainerPanel";
            OutlineContainerPanel.Size = new System.Drawing.Size(1280, 720);
            OutlineContainerPanel.TabIndex = 10;
            // 
            // TitleText
            // 
            TitleText.BackColor = System.Drawing.Color.Red;
            TitleText.Dock = System.Windows.Forms.DockStyle.Top;
            TitleText.Font = new System.Drawing.Font("Arial", 62F, System.Drawing.FontStyle.Bold);
            TitleText.Location = new System.Drawing.Point(8, 0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(1264, 112);
            TitleText.TabIndex = 15;
            TitleText.Text = "Short Alert Description";
            TitleText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RightOutlinePanel
            // 
            RightOutlinePanel.BackColor = System.Drawing.Color.Red;
            RightOutlinePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            RightOutlinePanel.Dock = System.Windows.Forms.DockStyle.Right;
            RightOutlinePanel.ForeColor = System.Drawing.Color.White;
            RightOutlinePanel.Location = new System.Drawing.Point(1272, 0);
            RightOutlinePanel.Margin = new System.Windows.Forms.Padding(10);
            RightOutlinePanel.Name = "RightOutlinePanel";
            RightOutlinePanel.Size = new System.Drawing.Size(8, 712);
            RightOutlinePanel.TabIndex = 17;
            // 
            // LeftOutlinePanel
            // 
            LeftOutlinePanel.BackColor = System.Drawing.Color.Red;
            LeftOutlinePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            LeftOutlinePanel.Dock = System.Windows.Forms.DockStyle.Left;
            LeftOutlinePanel.ForeColor = System.Drawing.Color.White;
            LeftOutlinePanel.Location = new System.Drawing.Point(0, 0);
            LeftOutlinePanel.Margin = new System.Windows.Forms.Padding(10);
            LeftOutlinePanel.Name = "LeftOutlinePanel";
            LeftOutlinePanel.Size = new System.Drawing.Size(8, 712);
            LeftOutlinePanel.TabIndex = 16;
            // 
            // BottomOutlinePanel
            // 
            BottomOutlinePanel.BackColor = System.Drawing.Color.Red;
            BottomOutlinePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            BottomOutlinePanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            BottomOutlinePanel.ForeColor = System.Drawing.Color.White;
            BottomOutlinePanel.Location = new System.Drawing.Point(0, 712);
            BottomOutlinePanel.Margin = new System.Windows.Forms.Padding(10);
            BottomOutlinePanel.Name = "BottomOutlinePanel";
            BottomOutlinePanel.Size = new System.Drawing.Size(1280, 8);
            BottomOutlinePanel.TabIndex = 18;
            // 
            // WindowFlash
            // 
            WindowFlash.Interval = 1000;
            WindowFlash.Tick += WindowFlash_Tick;
            // 
            // EnsureTopWindow
            // 
            EnsureTopWindow.Enabled = true;
            EnsureTopWindow.Interval = 1000;
            EnsureTopWindow.Tick += EnsureTopWindow_Tick;
            // 
            // WindowFlashSmooth
            // 
            WindowFlashSmooth.Interval = 60;
            WindowFlashSmooth.Tick += WindowFlashSmooth_Tick;
            // 
            // BoardAlertForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(1280, 720);
            ControlBox = false;
            Controls.Add(OutlineContainerPanel);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Arial", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BoardAlertForm";
            Opacity = 0D;
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "SharpAlert - Televised Alert Panel";
            TopMost = true;
            FormClosing += AlertForm_FormClosing;
            FormClosed += AlertForm_FormClosed;
            Load += AlertForm_Load;
            Shown += AlertForm_Shown;
            AlertPanel.ResumeLayout(false);
            AlertPanel.PerformLayout();
            MainPanel.ResumeLayout(false);
            OutlineContainerPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer AutoExit;
        private System.Windows.Forms.Panel AlertPanel;
        private System.Windows.Forms.TextBox AlertText;
        private System.Windows.Forms.Timer AutoTTS;
        private System.Windows.Forms.Timer MouseMoving;
        private System.Windows.Forms.Timer AutoScroller;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Timer AutoHideButtons;
        private System.Windows.Forms.ToolTip InfoTip;
        private System.Windows.Forms.Timer TerminateSelf;
        private System.Windows.Forms.Panel OutlineContainerPanel;
        private System.Windows.Forms.Button DismissButton;
        private System.Windows.Forms.Button LinkButton;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.Panel BottomOutlinePanel;
        private System.Windows.Forms.Panel RightOutlinePanel;
        private System.Windows.Forms.Panel LeftOutlinePanel;
        private System.Windows.Forms.Timer WindowFlash;
        private System.Windows.Forms.Timer EnsureTopWindow;
        private System.Windows.Forms.Timer WindowFlashSmooth;
    }
}


