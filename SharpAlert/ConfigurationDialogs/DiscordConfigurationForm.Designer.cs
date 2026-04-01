namespace SharpAlert.ConfigurationDialogs
{
    partial class DiscordConfigurationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscordConfigurationForm));
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            SwapToRPCButton = new System.Windows.Forms.Button();
            SwapToDiscordWebhooksButton = new System.Windows.Forms.Button();
            TabPanel = new System.Windows.Forms.Panel();
            SwappingText = new System.Windows.Forms.Label();
            WindowShake = new System.Windows.Forms.Timer(components);
            TabPanel.SuspendLayout();
            SuspendLayout();
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
            // SwapToRPCButton
            // 
            SwapToRPCButton.BackColor = System.Drawing.Color.Gainsboro;
            SwapToRPCButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            SwapToRPCButton.FlatAppearance.BorderSize = 2;
            SwapToRPCButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SwapToRPCButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            SwapToRPCButton.ForeColor = System.Drawing.Color.Black;
            SwapToRPCButton.Location = new System.Drawing.Point(12, 12);
            SwapToRPCButton.Name = "SwapToRPCButton";
            SwapToRPCButton.Size = new System.Drawing.Size(180, 30);
            SwapToRPCButton.TabIndex = 23;
            SwapToRPCButton.Tag = "SwapTabButton";
            SwapToRPCButton.Text = "Discord Rich Presence";
            SwapToRPCButton.UseVisualStyleBackColor = false;
            SwapToRPCButton.Click += SwapToRPCButton_Click;
            // 
            // SwapToDiscordWebhooksButton
            // 
            SwapToDiscordWebhooksButton.BackColor = System.Drawing.Color.Gainsboro;
            SwapToDiscordWebhooksButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            SwapToDiscordWebhooksButton.FlatAppearance.BorderSize = 2;
            SwapToDiscordWebhooksButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            SwapToDiscordWebhooksButton.Font = new System.Drawing.Font("Segoe UI", 10F);
            SwapToDiscordWebhooksButton.ForeColor = System.Drawing.Color.Black;
            SwapToDiscordWebhooksButton.Location = new System.Drawing.Point(198, 12);
            SwapToDiscordWebhooksButton.Name = "SwapToDiscordWebhooksButton";
            SwapToDiscordWebhooksButton.Size = new System.Drawing.Size(180, 30);
            SwapToDiscordWebhooksButton.TabIndex = 24;
            SwapToDiscordWebhooksButton.Tag = "SwapTabButton";
            SwapToDiscordWebhooksButton.Text = "Discord Webhooks";
            SwapToDiscordWebhooksButton.UseVisualStyleBackColor = false;
            SwapToDiscordWebhooksButton.Click += SwapToDiscordWebhooksButton_Click;
            // 
            // TabPanel
            // 
            TabPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            TabPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            TabPanel.Controls.Add(SwappingText);
            TabPanel.Location = new System.Drawing.Point(12, 48);
            TabPanel.Name = "TabPanel";
            TabPanel.Size = new System.Drawing.Size(760, 401);
            TabPanel.TabIndex = 25;
            // 
            // SwappingText
            // 
            SwappingText.Dock = System.Windows.Forms.DockStyle.Fill;
            SwappingText.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            SwappingText.Location = new System.Drawing.Point(0, 0);
            SwappingText.Name = "SwappingText";
            SwappingText.Size = new System.Drawing.Size(758, 399);
            SwappingText.TabIndex = 0;
            SwappingText.Tag = "LoadingGraphic";
            SwappingText.Text = "Loading...";
            SwappingText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WindowShake
            // 
            WindowShake.Enabled = true;
            WindowShake.Interval = 500;
            WindowShake.Tick += WindowShake_Tick;
            // 
            // DiscordConfigurationForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(784, 461);
            Controls.Add(TabPanel);
            Controls.Add(SwapToDiscordWebhooksButton);
            Controls.Add(SwapToRPCButton);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DiscordConfigurationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Discord Settings";
            FormClosing += ServerConfigurationForm_FormClosing;
            Load += ServerConfigurationForm_Load;
            TabPanel.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Button SwapToRPCButton;
        private System.Windows.Forms.Button SwapToDiscordWebhooksButton;
        private System.Windows.Forms.Panel TabPanel;
        private System.Windows.Forms.Label SwappingText;
        private System.Windows.Forms.Timer WindowShake;
    }
}
