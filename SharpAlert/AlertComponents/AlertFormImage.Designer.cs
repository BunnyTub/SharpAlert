namespace SharpAlert.AlertComponents
{
    partial class AlertFormImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertFormImage));
            this.AttachedImageBox = new System.Windows.Forms.PictureBox();
            this.FollowParentTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.AttachedImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AttachedImageBox
            // 
            this.AttachedImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttachedImageBox.ErrorImage = global::SharpAlert.Properties.Resources.CrashIcon;
            this.AttachedImageBox.ImageLocation = "https://bunnytub.com/SharpAlert/fallback.png";
            this.AttachedImageBox.InitialImage = global::SharpAlert.Properties.Resources.AlertIcon;
            this.AttachedImageBox.Location = new System.Drawing.Point(0, 0);
            this.AttachedImageBox.Name = "AttachedImageBox";
            this.AttachedImageBox.Size = new System.Drawing.Size(484, 332);
            this.AttachedImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.AttachedImageBox.TabIndex = 0;
            this.AttachedImageBox.TabStop = false;
            this.AttachedImageBox.LoadCompleted += new System.ComponentModel.AsyncCompletedEventHandler(this.AttachedImageBox_LoadCompleted);
            // 
            // FollowParentTimer
            // 
            this.FollowParentTimer.Interval = 25;
            this.FollowParentTimer.Tick += new System.EventHandler(this.FollowParentTimer_Tick);
            // 
            // AlertFormImage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(484, 332);
            this.ControlBox = false;
            this.Controls.Add(this.AttachedImageBox);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertFormImage";
            this.Opacity = 0D;
            this.ShowIcon = false;
            this.Text = "Attached Alert Image";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AlertFormImage_FormClosing);
            this.Load += new System.EventHandler(this.AlertFormImage_Load);
            this.Shown += new System.EventHandler(this.AlertFormImage_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.AttachedImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox AttachedImageBox;
        private System.Windows.Forms.Timer FollowParentTimer;
    }
}
