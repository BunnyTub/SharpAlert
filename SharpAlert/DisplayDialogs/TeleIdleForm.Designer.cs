namespace SharpAlert
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TeleIdleForm));
            this.WindowClosingChecker = new System.Windows.Forms.Timer(this.components);
            this.ClockSet = new System.Windows.Forms.Timer(this.components);
            this.MovePreventBurnIn = new System.Windows.Forms.Timer(this.components);
            this.IdleText = new System.Windows.Forms.Label();
            this.IdleContainer = new System.Windows.Forms.Panel();
            this.InfoText = new SharpAlert.ToolboxStuff.MarqueeLabel();
            this.IdleContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // WindowClosingChecker
            // 
            this.WindowClosingChecker.Enabled = true;
            this.WindowClosingChecker.Interval = 50;
            this.WindowClosingChecker.Tick += new System.EventHandler(this.WindowClosingChecker_Tick);
            // 
            // ClockSet
            // 
            this.ClockSet.Enabled = true;
            this.ClockSet.Interval = 1000;
            this.ClockSet.Tick += new System.EventHandler(this.ClockSet_Tick);
            // 
            // MovePreventBurnIn
            // 
            this.MovePreventBurnIn.Enabled = true;
            this.MovePreventBurnIn.Interval = 15000;
            this.MovePreventBurnIn.Tick += new System.EventHandler(this.MovePreventBurnIn_Tick);
            // 
            // IdleText
            // 
            this.IdleText.Font = new System.Drawing.Font("Arial", 56F);
            this.IdleText.ForeColor = System.Drawing.Color.White;
            this.IdleText.Location = new System.Drawing.Point(0, 0);
            this.IdleText.Margin = new System.Windows.Forms.Padding(0);
            this.IdleText.Name = "IdleText";
            this.IdleText.Size = new System.Drawing.Size(520, 170);
            this.IdleText.TabIndex = 0;
            this.IdleText.Text = "Please wait...\r\n...one moment";
            this.IdleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.IdleText.DoubleClick += new System.EventHandler(this.IdleText_DoubleClick);
            // 
            // IdleContainer
            // 
            this.IdleContainer.Controls.Add(this.InfoText);
            this.IdleContainer.Controls.Add(this.IdleText);
            this.IdleContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IdleContainer.Location = new System.Drawing.Point(0, 0);
            this.IdleContainer.Name = "IdleContainer";
            this.IdleContainer.Size = new System.Drawing.Size(1280, 720);
            this.IdleContainer.TabIndex = 1;
            this.IdleContainer.DoubleClick += new System.EventHandler(this.IdleContainer_DoubleClick);
            // 
            // InfoText
            // 
            this.InfoText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InfoText.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.InfoText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.InfoText.Location = new System.Drawing.Point(0, 694);
            this.InfoText.Name = "InfoText";
            this.InfoText.ScrollSpeed = 2F;
            this.InfoText.Size = new System.Drawing.Size(1280, 26);
            this.InfoText.TabIndex = 1;
            this.InfoText.Text = "SharpAlert";
            this.InfoText.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TeleIdleForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.ControlBox = false;
            this.Controls.Add(this.IdleContainer);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TeleIdleForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SharpAlert - Idle Window";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TeleIdleForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TeleIdleForm_FormClosed);
            this.Load += new System.EventHandler(this.TeleIdleForm_Load);
            this.Shown += new System.EventHandler(this.TeleIdleForm_Shown);
            this.Resize += new System.EventHandler(this.TeleIdleForm_Resize);
            this.IdleContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer WindowClosingChecker;
        private System.Windows.Forms.Timer ClockSet;
        private System.Windows.Forms.Timer MovePreventBurnIn;
        private System.Windows.Forms.Label IdleText;
        private ToolboxStuff.MarqueeLabel InfoText;
        public System.Windows.Forms.Panel IdleContainer;
    }
}