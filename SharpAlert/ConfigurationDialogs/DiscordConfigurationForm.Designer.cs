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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DiscordConfigurationForm));
            this.BusyLockText = new System.Windows.Forms.Label();
            this.ConfigurationPanel = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.IDAPURLInput = new System.Windows.Forms.TextBox();
            this.IDAPAppendInput = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.SASMEXURLInput = new System.Windows.Forms.TextBox();
            this.SASMEXAppendInput = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.NAADSBackupURLInput = new System.Windows.Forms.TextBox();
            this.NAADSBackupAppendInput = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.NAADSPrimaryURLInput = new System.Windows.Forms.TextBox();
            this.NAADSPrimaryAppendInput = new System.Windows.Forms.TextBox();
            this.DropChangesButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.NWSAtomURLInput = new System.Windows.Forms.TextBox();
            this.NWSAtomAppendInput = new System.Windows.Forms.TextBox();
            this.SaveDiscordSettingsButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.WEAURLInput = new System.Windows.Forms.TextBox();
            this.WEAAppendInput = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EASURLInput = new System.Windows.Forms.TextBox();
            this.EASAppendInput = new System.Windows.Forms.TextBox();
            this.DefaultDiscordGroup = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DefaultURLInput = new System.Windows.Forms.TextBox();
            this.DefaultAppendInput = new System.Windows.Forms.TextBox();
            this.BatteryGroup = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BatteryReportingCriticalLevelInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.BatteryReportingCautionLevelInput = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.DisableHeartbeatBox = new System.Windows.Forms.CheckBox();
            this.TitleText = new System.Windows.Forms.Label();
            this.DiscordWebhookRelayLocallyBox = new System.Windows.Forms.CheckBox();
            this.DiscordWebhookConfirmAlertsBox = new System.Windows.Forms.CheckBox();
            this.ToolTipInformation = new System.Windows.Forms.ToolTip(this.components);
            this.ConfigurationPanel.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.DefaultDiscordGroup.SuspendLayout();
            this.BatteryGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BatteryReportingCriticalLevelInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatteryReportingCautionLevelInput)).BeginInit();
            this.SuspendLayout();
            // 
            // BusyLockText
            // 
            this.BusyLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BusyLockText.Font = new System.Drawing.Font("Arial", 12F);
            this.BusyLockText.Location = new System.Drawing.Point(0, 0);
            this.BusyLockText.Name = "BusyLockText";
            this.BusyLockText.Size = new System.Drawing.Size(784, 411);
            this.BusyLockText.TabIndex = 9;
            this.BusyLockText.Text = "Please wait or dismiss all alerts to configure settings.";
            this.BusyLockText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfigurationPanel
            // 
            this.ConfigurationPanel.Controls.Add(this.groupBox7);
            this.ConfigurationPanel.Controls.Add(this.groupBox6);
            this.ConfigurationPanel.Controls.Add(this.groupBox5);
            this.ConfigurationPanel.Controls.Add(this.groupBox4);
            this.ConfigurationPanel.Controls.Add(this.DropChangesButton);
            this.ConfigurationPanel.Controls.Add(this.groupBox3);
            this.ConfigurationPanel.Controls.Add(this.SaveDiscordSettingsButton);
            this.ConfigurationPanel.Controls.Add(this.groupBox2);
            this.ConfigurationPanel.Controls.Add(this.groupBox1);
            this.ConfigurationPanel.Controls.Add(this.DefaultDiscordGroup);
            this.ConfigurationPanel.Controls.Add(this.BatteryGroup);
            this.ConfigurationPanel.Controls.Add(this.DisableHeartbeatBox);
            this.ConfigurationPanel.Controls.Add(this.TitleText);
            this.ConfigurationPanel.Controls.Add(this.DiscordWebhookRelayLocallyBox);
            this.ConfigurationPanel.Controls.Add(this.DiscordWebhookConfirmAlertsBox);
            this.ConfigurationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigurationPanel.Location = new System.Drawing.Point(0, 0);
            this.ConfigurationPanel.Name = "ConfigurationPanel";
            this.ConfigurationPanel.Size = new System.Drawing.Size(784, 411);
            this.ConfigurationPanel.TabIndex = 9;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label18);
            this.groupBox7.Controls.Add(this.label19);
            this.groupBox7.Controls.Add(this.IDAPURLInput);
            this.groupBox7.Controls.Add(this.IDAPAppendInput);
            this.groupBox7.ForeColor = System.Drawing.Color.White;
            this.groupBox7.Location = new System.Drawing.Point(336, 333);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(318, 65);
            this.groupBox7.TabIndex = 36;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "IDAP";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(158, 18);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(115, 15);
            this.label18.TabIndex = 25;
            this.label18.Text = "Additional Message";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 18);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(133, 15);
            this.label19.TabIndex = 24;
            this.label19.Text = "Discord Webhook URL";
            // 
            // IDAPURLInput
            // 
            this.IDAPURLInput.BackColor = System.Drawing.Color.Black;
            this.IDAPURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IDAPURLInput.ForeColor = System.Drawing.Color.White;
            this.IDAPURLInput.Location = new System.Drawing.Point(9, 36);
            this.IDAPURLInput.Name = "IDAPURLInput";
            this.IDAPURLInput.Size = new System.Drawing.Size(146, 21);
            this.IDAPURLInput.TabIndex = 19;
            this.ToolTipInformation.SetToolTip(this.IDAPURLInput, "The Discord webhook URL to send data to.");
            // 
            // IDAPAppendInput
            // 
            this.IDAPAppendInput.BackColor = System.Drawing.Color.Black;
            this.IDAPAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.IDAPAppendInput.ForeColor = System.Drawing.Color.White;
            this.IDAPAppendInput.Location = new System.Drawing.Point(161, 36);
            this.IDAPAppendInput.Name = "IDAPAppendInput";
            this.IDAPAppendInput.Size = new System.Drawing.Size(146, 21);
            this.IDAPAppendInput.TabIndex = 20;
            this.ToolTipInformation.SetToolTip(this.IDAPAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.label17);
            this.groupBox6.Controls.Add(this.SASMEXURLInput);
            this.groupBox6.Controls.Add(this.SASMEXAppendInput);
            this.groupBox6.ForeColor = System.Drawing.Color.White;
            this.groupBox6.Location = new System.Drawing.Point(336, 262);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(318, 65);
            this.groupBox6.TabIndex = 35;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "SASMEX";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(158, 18);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(115, 15);
            this.label16.TabIndex = 25;
            this.label16.Text = "Additional Message";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 18);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(133, 15);
            this.label17.TabIndex = 24;
            this.label17.Text = "Discord Webhook URL";
            // 
            // SASMEXURLInput
            // 
            this.SASMEXURLInput.BackColor = System.Drawing.Color.Black;
            this.SASMEXURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SASMEXURLInput.ForeColor = System.Drawing.Color.White;
            this.SASMEXURLInput.Location = new System.Drawing.Point(9, 36);
            this.SASMEXURLInput.Name = "SASMEXURLInput";
            this.SASMEXURLInput.Size = new System.Drawing.Size(146, 21);
            this.SASMEXURLInput.TabIndex = 19;
            this.ToolTipInformation.SetToolTip(this.SASMEXURLInput, "The Discord webhook URL to send data to.");
            // 
            // SASMEXAppendInput
            // 
            this.SASMEXAppendInput.BackColor = System.Drawing.Color.Black;
            this.SASMEXAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SASMEXAppendInput.ForeColor = System.Drawing.Color.White;
            this.SASMEXAppendInput.Location = new System.Drawing.Point(161, 36);
            this.SASMEXAppendInput.Name = "SASMEXAppendInput";
            this.SASMEXAppendInput.Size = new System.Drawing.Size(146, 21);
            this.SASMEXAppendInput.TabIndex = 20;
            this.ToolTipInformation.SetToolTip(this.SASMEXAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.NAADSBackupURLInput);
            this.groupBox5.Controls.Add(this.NAADSBackupAppendInput);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(336, 191);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(318, 65);
            this.groupBox5.TabIndex = 34;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Canada (NAADS Backup)";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(158, 18);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 15);
            this.label14.TabIndex = 25;
            this.label14.Text = "Additional Message";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(133, 15);
            this.label15.TabIndex = 24;
            this.label15.Text = "Discord Webhook URL";
            // 
            // NAADSBackupURLInput
            // 
            this.NAADSBackupURLInput.BackColor = System.Drawing.Color.Black;
            this.NAADSBackupURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NAADSBackupURLInput.ForeColor = System.Drawing.Color.White;
            this.NAADSBackupURLInput.Location = new System.Drawing.Point(9, 36);
            this.NAADSBackupURLInput.Name = "NAADSBackupURLInput";
            this.NAADSBackupURLInput.Size = new System.Drawing.Size(146, 21);
            this.NAADSBackupURLInput.TabIndex = 19;
            this.ToolTipInformation.SetToolTip(this.NAADSBackupURLInput, "The Discord webhook URL to send data to.");
            // 
            // NAADSBackupAppendInput
            // 
            this.NAADSBackupAppendInput.BackColor = System.Drawing.Color.Black;
            this.NAADSBackupAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NAADSBackupAppendInput.ForeColor = System.Drawing.Color.White;
            this.NAADSBackupAppendInput.Location = new System.Drawing.Point(161, 36);
            this.NAADSBackupAppendInput.Name = "NAADSBackupAppendInput";
            this.NAADSBackupAppendInput.Size = new System.Drawing.Size(146, 21);
            this.NAADSBackupAppendInput.TabIndex = 20;
            this.ToolTipInformation.SetToolTip(this.NAADSBackupAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.NAADSPrimaryURLInput);
            this.groupBox4.Controls.Add(this.NAADSPrimaryAppendInput);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(336, 120);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(318, 65);
            this.groupBox4.TabIndex = 33;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Canada (NAADS Primary)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(158, 18);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 15);
            this.label12.TabIndex = 25;
            this.label12.Text = "Additional Message";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 18);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(133, 15);
            this.label13.TabIndex = 24;
            this.label13.Text = "Discord Webhook URL";
            // 
            // NAADSPrimaryURLInput
            // 
            this.NAADSPrimaryURLInput.BackColor = System.Drawing.Color.Black;
            this.NAADSPrimaryURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NAADSPrimaryURLInput.ForeColor = System.Drawing.Color.White;
            this.NAADSPrimaryURLInput.Location = new System.Drawing.Point(9, 36);
            this.NAADSPrimaryURLInput.Name = "NAADSPrimaryURLInput";
            this.NAADSPrimaryURLInput.Size = new System.Drawing.Size(146, 21);
            this.NAADSPrimaryURLInput.TabIndex = 19;
            this.ToolTipInformation.SetToolTip(this.NAADSPrimaryURLInput, "The Discord webhook URL to send data to.");
            // 
            // NAADSPrimaryAppendInput
            // 
            this.NAADSPrimaryAppendInput.BackColor = System.Drawing.Color.Black;
            this.NAADSPrimaryAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NAADSPrimaryAppendInput.ForeColor = System.Drawing.Color.White;
            this.NAADSPrimaryAppendInput.Location = new System.Drawing.Point(161, 36);
            this.NAADSPrimaryAppendInput.Name = "NAADSPrimaryAppendInput";
            this.NAADSPrimaryAppendInput.Size = new System.Drawing.Size(146, 21);
            this.NAADSPrimaryAppendInput.TabIndex = 20;
            this.ToolTipInformation.SetToolTip(this.NAADSPrimaryAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // DropChangesButton
            // 
            this.DropChangesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DropChangesButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.DropChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DropChangesButton.Location = new System.Drawing.Point(665, 343);
            this.DropChangesButton.Name = "DropChangesButton";
            this.DropChangesButton.Size = new System.Drawing.Size(107, 25);
            this.DropChangesButton.TabIndex = 32;
            this.DropChangesButton.Text = "Drop Changes";
            this.ToolTipInformation.SetToolTip(this.DropChangesButton, "Drops changes that have been made to webhooks and additional messages.");
            this.DropChangesButton.UseVisualStyleBackColor = false;
            this.DropChangesButton.Click += new System.EventHandler(this.DropChangesButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.NWSAtomURLInput);
            this.groupBox3.Controls.Add(this.NWSAtomAppendInput);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 333);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(318, 65);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "NWS Atom";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(158, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(115, 15);
            this.label10.TabIndex = 25;
            this.label10.Text = "Additional Message";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(133, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "Discord Webhook URL";
            // 
            // NWSAtomURLInput
            // 
            this.NWSAtomURLInput.BackColor = System.Drawing.Color.Black;
            this.NWSAtomURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NWSAtomURLInput.ForeColor = System.Drawing.Color.White;
            this.NWSAtomURLInput.Location = new System.Drawing.Point(9, 36);
            this.NWSAtomURLInput.Name = "NWSAtomURLInput";
            this.NWSAtomURLInput.Size = new System.Drawing.Size(146, 21);
            this.NWSAtomURLInput.TabIndex = 19;
            this.ToolTipInformation.SetToolTip(this.NWSAtomURLInput, "The Discord webhook URL to send data to.");
            // 
            // NWSAtomAppendInput
            // 
            this.NWSAtomAppendInput.BackColor = System.Drawing.Color.Black;
            this.NWSAtomAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NWSAtomAppendInput.ForeColor = System.Drawing.Color.White;
            this.NWSAtomAppendInput.Location = new System.Drawing.Point(161, 36);
            this.NWSAtomAppendInput.Name = "NWSAtomAppendInput";
            this.NWSAtomAppendInput.Size = new System.Drawing.Size(146, 21);
            this.NWSAtomAppendInput.TabIndex = 20;
            this.ToolTipInformation.SetToolTip(this.NWSAtomAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // SaveDiscordSettingsButton
            // 
            this.SaveDiscordSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SaveDiscordSettingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.SaveDiscordSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveDiscordSettingsButton.Location = new System.Drawing.Point(665, 374);
            this.SaveDiscordSettingsButton.Name = "SaveDiscordSettingsButton";
            this.SaveDiscordSettingsButton.Size = new System.Drawing.Size(107, 25);
            this.SaveDiscordSettingsButton.TabIndex = 22;
            this.SaveDiscordSettingsButton.Text = "Apply Changes";
            this.ToolTipInformation.SetToolTip(this.SaveDiscordSettingsButton, "Applies webhook information immediately.");
            this.SaveDiscordSettingsButton.UseVisualStyleBackColor = false;
            this.SaveDiscordSettingsButton.Click += new System.EventHandler(this.SaveDiscordSettingsButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.WEAURLInput);
            this.groupBox2.Controls.Add(this.WEAAppendInput);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(12, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(318, 65);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FEMA IPAWS (WEA)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(158, 18);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(115, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Additional Message";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(133, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Discord Webhook URL";
            // 
            // WEAURLInput
            // 
            this.WEAURLInput.BackColor = System.Drawing.Color.Black;
            this.WEAURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WEAURLInput.ForeColor = System.Drawing.Color.White;
            this.WEAURLInput.Location = new System.Drawing.Point(9, 36);
            this.WEAURLInput.Name = "WEAURLInput";
            this.WEAURLInput.Size = new System.Drawing.Size(146, 21);
            this.WEAURLInput.TabIndex = 19;
            this.ToolTipInformation.SetToolTip(this.WEAURLInput, "The Discord webhook URL to send data to.");
            // 
            // WEAAppendInput
            // 
            this.WEAAppendInput.BackColor = System.Drawing.Color.Black;
            this.WEAAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.WEAAppendInput.ForeColor = System.Drawing.Color.White;
            this.WEAAppendInput.Location = new System.Drawing.Point(161, 36);
            this.WEAAppendInput.Name = "WEAAppendInput";
            this.WEAAppendInput.Size = new System.Drawing.Size(146, 21);
            this.WEAAppendInput.TabIndex = 20;
            this.ToolTipInformation.SetToolTip(this.WEAAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.EASURLInput);
            this.groupBox1.Controls.Add(this.EASAppendInput);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(12, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(318, 65);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "FEMA IPAWS (EAS)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Additional Message";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Discord Webhook URL";
            // 
            // EASURLInput
            // 
            this.EASURLInput.BackColor = System.Drawing.Color.Black;
            this.EASURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EASURLInput.ForeColor = System.Drawing.Color.White;
            this.EASURLInput.Location = new System.Drawing.Point(9, 36);
            this.EASURLInput.Name = "EASURLInput";
            this.EASURLInput.Size = new System.Drawing.Size(146, 21);
            this.EASURLInput.TabIndex = 19;
            this.ToolTipInformation.SetToolTip(this.EASURLInput, "The Discord webhook URL to send data to.");
            // 
            // EASAppendInput
            // 
            this.EASAppendInput.BackColor = System.Drawing.Color.Black;
            this.EASAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EASAppendInput.ForeColor = System.Drawing.Color.White;
            this.EASAppendInput.Location = new System.Drawing.Point(161, 36);
            this.EASAppendInput.Name = "EASAppendInput";
            this.EASAppendInput.Size = new System.Drawing.Size(146, 21);
            this.EASAppendInput.TabIndex = 20;
            this.ToolTipInformation.SetToolTip(this.EASAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // DefaultDiscordGroup
            // 
            this.DefaultDiscordGroup.Controls.Add(this.label7);
            this.DefaultDiscordGroup.Controls.Add(this.label6);
            this.DefaultDiscordGroup.Controls.Add(this.DefaultURLInput);
            this.DefaultDiscordGroup.Controls.Add(this.DefaultAppendInput);
            this.DefaultDiscordGroup.ForeColor = System.Drawing.Color.White;
            this.DefaultDiscordGroup.Location = new System.Drawing.Point(12, 120);
            this.DefaultDiscordGroup.Name = "DefaultDiscordGroup";
            this.DefaultDiscordGroup.Size = new System.Drawing.Size(318, 65);
            this.DefaultDiscordGroup.TabIndex = 28;
            this.DefaultDiscordGroup.TabStop = false;
            this.DefaultDiscordGroup.Text = "Default (any other source)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(158, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(115, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "Additional Message";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 15);
            this.label6.TabIndex = 24;
            this.label6.Text = "Discord Webhook URL";
            // 
            // DefaultURLInput
            // 
            this.DefaultURLInput.BackColor = System.Drawing.Color.Black;
            this.DefaultURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DefaultURLInput.ForeColor = System.Drawing.Color.White;
            this.DefaultURLInput.Location = new System.Drawing.Point(9, 36);
            this.DefaultURLInput.Name = "DefaultURLInput";
            this.DefaultURLInput.Size = new System.Drawing.Size(146, 21);
            this.DefaultURLInput.TabIndex = 19;
            this.ToolTipInformation.SetToolTip(this.DefaultURLInput, "The Discord webhook URL to send data to.");
            // 
            // DefaultAppendInput
            // 
            this.DefaultAppendInput.BackColor = System.Drawing.Color.Black;
            this.DefaultAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DefaultAppendInput.ForeColor = System.Drawing.Color.White;
            this.DefaultAppendInput.Location = new System.Drawing.Point(161, 36);
            this.DefaultAppendInput.Name = "DefaultAppendInput";
            this.DefaultAppendInput.Size = new System.Drawing.Size(146, 21);
            this.DefaultAppendInput.TabIndex = 20;
            this.ToolTipInformation.SetToolTip(this.DefaultAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // BatteryGroup
            // 
            this.BatteryGroup.Controls.Add(this.label2);
            this.BatteryGroup.Controls.Add(this.BatteryReportingCriticalLevelInput);
            this.BatteryGroup.Controls.Add(this.label1);
            this.BatteryGroup.Controls.Add(this.BatteryReportingCautionLevelInput);
            this.BatteryGroup.Controls.Add(this.label3);
            this.BatteryGroup.ForeColor = System.Drawing.Color.White;
            this.BatteryGroup.Location = new System.Drawing.Point(12, 27);
            this.BatteryGroup.Name = "BatteryGroup";
            this.BatteryGroup.Size = new System.Drawing.Size(318, 87);
            this.BatteryGroup.TabIndex = 20;
            this.BatteryGroup.TabStop = false;
            this.BatteryGroup.Text = "Battery Reporting";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(168, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 21);
            this.label2.TabIndex = 27;
            this.label2.Text = "Critical";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.label2, ".");
            // 
            // BatteryReportingCriticalLevelInput
            // 
            this.BatteryReportingCriticalLevelInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BatteryReportingCriticalLevelInput.BackColor = System.Drawing.Color.Black;
            this.BatteryReportingCriticalLevelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BatteryReportingCriticalLevelInput.ForeColor = System.Drawing.Color.White;
            this.BatteryReportingCriticalLevelInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.BatteryReportingCriticalLevelInput.Location = new System.Drawing.Point(258, 60);
            this.BatteryReportingCriticalLevelInput.Name = "BatteryReportingCriticalLevelInput";
            this.BatteryReportingCriticalLevelInput.Size = new System.Drawing.Size(54, 21);
            this.BatteryReportingCriticalLevelInput.TabIndex = 26;
            this.ToolTipInformation.SetToolTip(this.BatteryReportingCriticalLevelInput, "The level at which reporting starts for critical.");
            this.BatteryReportingCriticalLevelInput.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(168, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 21);
            this.label1.TabIndex = 25;
            this.label1.Text = "Caution";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToolTipInformation.SetToolTip(this.label1, ".");
            // 
            // BatteryReportingCautionLevelInput
            // 
            this.BatteryReportingCautionLevelInput.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BatteryReportingCautionLevelInput.BackColor = System.Drawing.Color.Black;
            this.BatteryReportingCautionLevelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BatteryReportingCautionLevelInput.ForeColor = System.Drawing.Color.White;
            this.BatteryReportingCautionLevelInput.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.BatteryReportingCautionLevelInput.Location = new System.Drawing.Point(258, 33);
            this.BatteryReportingCautionLevelInput.Name = "BatteryReportingCautionLevelInput";
            this.BatteryReportingCautionLevelInput.Size = new System.Drawing.Size(54, 21);
            this.BatteryReportingCautionLevelInput.TabIndex = 24;
            this.ToolTipInformation.SetToolTip(this.BatteryReportingCautionLevelInput, "The level at which reporting starts for caution.");
            this.BatteryReportingCautionLevelInput.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 63);
            this.label3.TabIndex = 14;
            this.label3.Text = "Battery measurements are reported to the default Discord webhook when a\r\npercenta" +
    "ge is reached.";
            // 
            // DisableHeartbeatBox
            // 
            this.DisableHeartbeatBox.AutoSize = true;
            this.DisableHeartbeatBox.Location = new System.Drawing.Point(336, 95);
            this.DisableHeartbeatBox.Name = "DisableHeartbeatBox";
            this.DisableHeartbeatBox.Size = new System.Drawing.Size(124, 19);
            this.DisableHeartbeatBox.TabIndex = 19;
            this.DisableHeartbeatBox.Text = "Disable heartbeat";
            this.ToolTipInformation.SetToolTip(this.DisableHeartbeatBox, "Disables the \"I\'m\"\r\nThis is not related ");
            this.DisableHeartbeatBox.UseVisualStyleBackColor = true;
            // 
            // TitleText
            // 
            this.TitleText.AutoSize = true;
            this.TitleText.Location = new System.Drawing.Point(9, 9);
            this.TitleText.Margin = new System.Windows.Forms.Padding(0);
            this.TitleText.Name = "TitleText";
            this.TitleText.Size = new System.Drawing.Size(536, 15);
            this.TitleText.TabIndex = 21;
            this.TitleText.Text = "Choose a Discord webhoook source to configure, and click Modify Webhook to apply " +
    "all changes.";
            // 
            // DiscordWebhookRelayLocallyBox
            // 
            this.DiscordWebhookRelayLocallyBox.AutoSize = true;
            this.DiscordWebhookRelayLocallyBox.Location = new System.Drawing.Point(336, 70);
            this.DiscordWebhookRelayLocallyBox.Name = "DiscordWebhookRelayLocallyBox";
            this.DiscordWebhookRelayLocallyBox.Size = new System.Drawing.Size(94, 19);
            this.DiscordWebhookRelayLocallyBox.TabIndex = 17;
            this.DiscordWebhookRelayLocallyBox.Text = "Relay locally";
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookRelayLocallyBox, "Relay alerts locally in addition to sending a message.");
            this.DiscordWebhookRelayLocallyBox.UseVisualStyleBackColor = true;
            // 
            // DiscordWebhookConfirmAlertsBox
            // 
            this.DiscordWebhookConfirmAlertsBox.AutoSize = true;
            this.DiscordWebhookConfirmAlertsBox.Location = new System.Drawing.Point(336, 45);
            this.DiscordWebhookConfirmAlertsBox.Name = "DiscordWebhookConfirmAlertsBox";
            this.DiscordWebhookConfirmAlertsBox.Size = new System.Drawing.Size(104, 19);
            this.DiscordWebhookConfirmAlertsBox.TabIndex = 15;
            this.DiscordWebhookConfirmAlertsBox.Text = "Confirm alerts";
            this.ToolTipInformation.SetToolTip(this.DiscordWebhookConfirmAlertsBox, "Shows a window with alert information for a short period of time.\r\nYou can either" +
        " forward the alert by waiting or clicking \"FORWARD\", or discard it by clicking \"" +
        "STOP\".");
            this.DiscordWebhookConfirmAlertsBox.UseVisualStyleBackColor = true;
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
            // DiscordConfigurationForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(784, 411);
            this.Controls.Add(this.ConfigurationPanel);
            this.Controls.Add(this.BusyLockText);
            this.Font = new System.Drawing.Font("Arial", 9F);
            this.ForeColor = System.Drawing.Color.White;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DiscordConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SharpAlert - Discord Settings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ServerConfigurationForm_FormClosing);
            this.Load += new System.EventHandler(this.ServerConfigurationForm_Load);
            this.ConfigurationPanel.ResumeLayout(false);
            this.ConfigurationPanel.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.DefaultDiscordGroup.ResumeLayout(false);
            this.DefaultDiscordGroup.PerformLayout();
            this.BatteryGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BatteryReportingCriticalLevelInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BatteryReportingCautionLevelInput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label BusyLockText;
        private System.Windows.Forms.Panel ConfigurationPanel;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Label TitleText;
        private System.Windows.Forms.GroupBox BatteryGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown BatteryReportingCriticalLevelInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown BatteryReportingCautionLevelInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox DisableHeartbeatBox;
        private System.Windows.Forms.CheckBox DiscordWebhookRelayLocallyBox;
        private System.Windows.Forms.CheckBox DiscordWebhookConfirmAlertsBox;
        private System.Windows.Forms.GroupBox DefaultDiscordGroup;
        private System.Windows.Forms.Button SaveDiscordSettingsButton;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DefaultURLInput;
        private System.Windows.Forms.TextBox DefaultAppendInput;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox EASURLInput;
        private System.Windows.Forms.TextBox EASAppendInput;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox WEAURLInput;
        private System.Windows.Forms.TextBox WEAAppendInput;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox NWSAtomURLInput;
        private System.Windows.Forms.TextBox NWSAtomAppendInput;
        private System.Windows.Forms.Button DropChangesButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox NAADSPrimaryURLInput;
        private System.Windows.Forms.TextBox NAADSPrimaryAppendInput;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox NAADSBackupURLInput;
        private System.Windows.Forms.TextBox NAADSBackupAppendInput;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox SASMEXURLInput;
        private System.Windows.Forms.TextBox SASMEXAppendInput;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox IDAPURLInput;
        private System.Windows.Forms.TextBox IDAPAppendInput;
    }
}
