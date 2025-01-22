namespace SharpAlert
{
    partial class StatusForm
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
            this.RefreshData = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // RefreshData
            // 
            this.RefreshData.Enabled = true;
            this.RefreshData.Interval = 1000;
            this.RefreshData.Tick += new System.EventHandler(this.RefreshData_Tick);
            // 
            // StatusForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(933, 519);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "StatusForm";
            this.Text = "StatusForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer RefreshData;
    }
}