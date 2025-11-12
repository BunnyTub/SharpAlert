namespace SharpAlert.DisplayDialogs
{
    partial class TeleIdleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeleIdleForm));
            WindowClosingChecker = new System.Windows.Forms.Timer(components);
            ClockSet = new System.Windows.Forms.Timer(components);
            MovePreventBurnIn = new System.Windows.Forms.Timer(components);
            IdleText = new System.Windows.Forms.Label();
            IdleContainer = new System.Windows.Forms.Panel();
            InfoText = new SharpAlert.WinFormsControls.ToolboxStuff.MarqueeLabel();
            IdleContainer.SuspendLayout();
            SuspendLayout();
            // 
            // WindowClosingChecker
            // 
            WindowClosingChecker.Enabled = true;
            WindowClosingChecker.Interval = 50;
            WindowClosingChecker.Tick += WindowClosingChecker_Tick;
            // 
            // ClockSet
            // 
            ClockSet.Enabled = true;
            ClockSet.Interval = 1000;
            ClockSet.Tick += ClockSet_Tick;
            // 
            // MovePreventBurnIn
            // 
            MovePreventBurnIn.Enabled = true;
            MovePreventBurnIn.Interval = 15000;
            MovePreventBurnIn.Tick += MovePreventBurnIn_Tick;
            // 
            // IdleText
            // 
            IdleText.Font = new System.Drawing.Font("Segoe UI", 48F);
            IdleText.ForeColor = System.Drawing.Color.White;
            IdleText.Location = new System.Drawing.Point(0, 0);
            IdleText.Margin = new System.Windows.Forms.Padding(0);
            IdleText.Name = "IdleText";
            IdleText.Size = new System.Drawing.Size(520, 170);
            IdleText.TabIndex = 0;
            IdleText.Text = "Please wait...\r\n...one moment";
            IdleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            IdleText.DoubleClick += IdleText_DoubleClick;
            // 
            // IdleContainer
            // 
            IdleContainer.Controls.Add(InfoText);
            IdleContainer.Controls.Add(IdleText);
            IdleContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            IdleContainer.Location = new System.Drawing.Point(0, 0);
            IdleContainer.Name = "IdleContainer";
            IdleContainer.Size = new System.Drawing.Size(1280, 720);
            IdleContainer.TabIndex = 1;
            IdleContainer.DoubleClick += IdleContainer_DoubleClick;
            // 
            // InfoText
            // 
            InfoText.Dock = System.Windows.Forms.DockStyle.Bottom;
            InfoText.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            InfoText.ForeColor = System.Drawing.Color.FromArgb(127, 127, 127);
            InfoText.Location = new System.Drawing.Point(0, 694);
            InfoText.Name = "InfoText";
            InfoText.ScrollSpeed = 2F;
            InfoText.Size = new System.Drawing.Size(1280, 26);
            InfoText.Stutter = 50;
            InfoText.TabIndex = 1;
            InfoText.Text = "SharpAlert";
            InfoText.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            InfoText.UseCustomPixelCount = false;
            // 
            // TeleIdleForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.Black;
            ClientSize = new System.Drawing.Size(1280, 720);
            ControlBox = false;
            Controls.Add(IdleContainer);
            DoubleBuffered = true;
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TeleIdleForm";
            ShowIcon = false;
            StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            Text = "SharpAlert - Idle Window";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            FormClosing += TeleIdleForm_FormClosing;
            FormClosed += TeleIdleForm_FormClosed;
            Load += TeleIdleForm_Load;
            Shown += TeleIdleForm_Shown;
            Resize += TeleIdleForm_Resize;
            IdleContainer.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer WindowClosingChecker;
        private System.Windows.Forms.Timer ClockSet;
        private System.Windows.Forms.Timer MovePreventBurnIn;
        private System.Windows.Forms.Label IdleText;
        private WinFormsControls.ToolboxStuff.MarqueeLabel InfoText;
        public System.Windows.Forms.Panel IdleContainer;
    }
}
