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
            BusyLockText = new System.Windows.Forms.Label();
            ConfigurationPanel = new System.Windows.Forms.Panel();
            groupBox7 = new System.Windows.Forms.GroupBox();
            label18 = new System.Windows.Forms.Label();
            label19 = new System.Windows.Forms.Label();
            IDAPURLInput = new System.Windows.Forms.TextBox();
            IDAPAppendInput = new System.Windows.Forms.TextBox();
            groupBox6 = new System.Windows.Forms.GroupBox();
            label16 = new System.Windows.Forms.Label();
            label17 = new System.Windows.Forms.Label();
            SASMEXURLInput = new System.Windows.Forms.TextBox();
            SASMEXAppendInput = new System.Windows.Forms.TextBox();
            groupBox5 = new System.Windows.Forms.GroupBox();
            label14 = new System.Windows.Forms.Label();
            label15 = new System.Windows.Forms.Label();
            NAADSBackupURLInput = new System.Windows.Forms.TextBox();
            NAADSBackupAppendInput = new System.Windows.Forms.TextBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            label12 = new System.Windows.Forms.Label();
            label13 = new System.Windows.Forms.Label();
            NAADSPrimaryURLInput = new System.Windows.Forms.TextBox();
            NAADSPrimaryAppendInput = new System.Windows.Forms.TextBox();
            DropChangesButton = new System.Windows.Forms.Button();
            groupBox3 = new System.Windows.Forms.GroupBox();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            NWSAtomURLInput = new System.Windows.Forms.TextBox();
            NWSAtomAppendInput = new System.Windows.Forms.TextBox();
            SaveDiscordSettingsButton = new System.Windows.Forms.Button();
            groupBox2 = new System.Windows.Forms.GroupBox();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            WEAURLInput = new System.Windows.Forms.TextBox();
            WEAAppendInput = new System.Windows.Forms.TextBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            EASURLInput = new System.Windows.Forms.TextBox();
            EASAppendInput = new System.Windows.Forms.TextBox();
            DefaultDiscordGroup = new System.Windows.Forms.GroupBox();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            DefaultURLInput = new System.Windows.Forms.TextBox();
            DefaultAppendInput = new System.Windows.Forms.TextBox();
            BatteryGroup = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            BatteryReportingCriticalLevelInput = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            BatteryReportingCautionLevelInput = new System.Windows.Forms.NumericUpDown();
            label3 = new System.Windows.Forms.Label();
            DisableHeartbeatBox = new System.Windows.Forms.CheckBox();
            TitleText = new System.Windows.Forms.Label();
            DiscordWebhookRelayLocallyBox = new System.Windows.Forms.CheckBox();
            DiscordWebhookConfirmAlertsBox = new System.Windows.Forms.CheckBox();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            ConfigurationPanel.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            DefaultDiscordGroup.SuspendLayout();
            BatteryGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)BatteryReportingCriticalLevelInput).BeginInit();
            ((System.ComponentModel.ISupportInitialize)BatteryReportingCautionLevelInput).BeginInit();
            SuspendLayout();
            // 
            // BusyLockText
            // 
            BusyLockText.Dock = System.Windows.Forms.DockStyle.Fill;
            BusyLockText.Font = new System.Drawing.Font("Segoe UI", 12F);
            BusyLockText.Location = new System.Drawing.Point(0, 0);
            BusyLockText.Name = "BusyLockText";
            BusyLockText.Size = new System.Drawing.Size(784, 411);
            BusyLockText.TabIndex = 9;
            BusyLockText.Text = "Please wait or dismiss all alerts to configure settings.";
            BusyLockText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConfigurationPanel
            // 
            ConfigurationPanel.Controls.Add(groupBox7);
            ConfigurationPanel.Controls.Add(groupBox6);
            ConfigurationPanel.Controls.Add(groupBox5);
            ConfigurationPanel.Controls.Add(groupBox4);
            ConfigurationPanel.Controls.Add(DropChangesButton);
            ConfigurationPanel.Controls.Add(groupBox3);
            ConfigurationPanel.Controls.Add(SaveDiscordSettingsButton);
            ConfigurationPanel.Controls.Add(groupBox2);
            ConfigurationPanel.Controls.Add(groupBox1);
            ConfigurationPanel.Controls.Add(DefaultDiscordGroup);
            ConfigurationPanel.Controls.Add(BatteryGroup);
            ConfigurationPanel.Controls.Add(DisableHeartbeatBox);
            ConfigurationPanel.Controls.Add(TitleText);
            ConfigurationPanel.Controls.Add(DiscordWebhookRelayLocallyBox);
            ConfigurationPanel.Controls.Add(DiscordWebhookConfirmAlertsBox);
            ConfigurationPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            ConfigurationPanel.Location = new System.Drawing.Point(0, 0);
            ConfigurationPanel.Name = "ConfigurationPanel";
            ConfigurationPanel.Size = new System.Drawing.Size(784, 411);
            ConfigurationPanel.TabIndex = 9;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(label18);
            groupBox7.Controls.Add(label19);
            groupBox7.Controls.Add(IDAPURLInput);
            groupBox7.Controls.Add(IDAPAppendInput);
            groupBox7.ForeColor = System.Drawing.Color.White;
            groupBox7.Location = new System.Drawing.Point(336, 333);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new System.Drawing.Size(318, 65);
            groupBox7.TabIndex = 36;
            groupBox7.TabStop = false;
            groupBox7.Text = "IDAP";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new System.Drawing.Point(158, 18);
            label18.Name = "label18";
            label18.Size = new System.Drawing.Size(111, 15);
            label18.TabIndex = 25;
            label18.Text = "Additional Message";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new System.Drawing.Point(6, 18);
            label19.Name = "label19";
            label19.Size = new System.Drawing.Size(125, 15);
            label19.TabIndex = 24;
            label19.Text = "Discord Webhook URL";
            // 
            // IDAPURLInput
            // 
            IDAPURLInput.BackColor = System.Drawing.Color.Black;
            IDAPURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            IDAPURLInput.ForeColor = System.Drawing.Color.White;
            IDAPURLInput.Location = new System.Drawing.Point(9, 36);
            IDAPURLInput.Name = "IDAPURLInput";
            IDAPURLInput.Size = new System.Drawing.Size(146, 23);
            IDAPURLInput.TabIndex = 19;
            ToolTipInformation.SetToolTip(IDAPURLInput, "The Discord webhook URL to send data to.");
            // 
            // IDAPAppendInput
            // 
            IDAPAppendInput.BackColor = System.Drawing.Color.Black;
            IDAPAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            IDAPAppendInput.ForeColor = System.Drawing.Color.White;
            IDAPAppendInput.Location = new System.Drawing.Point(161, 36);
            IDAPAppendInput.Name = "IDAPAppendInput";
            IDAPAppendInput.Size = new System.Drawing.Size(146, 23);
            IDAPAppendInput.TabIndex = 20;
            ToolTipInformation.SetToolTip(IDAPAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label16);
            groupBox6.Controls.Add(label17);
            groupBox6.Controls.Add(SASMEXURLInput);
            groupBox6.Controls.Add(SASMEXAppendInput);
            groupBox6.ForeColor = System.Drawing.Color.White;
            groupBox6.Location = new System.Drawing.Point(336, 262);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new System.Drawing.Size(318, 65);
            groupBox6.TabIndex = 35;
            groupBox6.TabStop = false;
            groupBox6.Text = "SASMEX";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new System.Drawing.Point(158, 18);
            label16.Name = "label16";
            label16.Size = new System.Drawing.Size(111, 15);
            label16.TabIndex = 25;
            label16.Text = "Additional Message";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new System.Drawing.Point(6, 18);
            label17.Name = "label17";
            label17.Size = new System.Drawing.Size(125, 15);
            label17.TabIndex = 24;
            label17.Text = "Discord Webhook URL";
            // 
            // SASMEXURLInput
            // 
            SASMEXURLInput.BackColor = System.Drawing.Color.Black;
            SASMEXURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            SASMEXURLInput.ForeColor = System.Drawing.Color.White;
            SASMEXURLInput.Location = new System.Drawing.Point(9, 36);
            SASMEXURLInput.Name = "SASMEXURLInput";
            SASMEXURLInput.Size = new System.Drawing.Size(146, 23);
            SASMEXURLInput.TabIndex = 19;
            ToolTipInformation.SetToolTip(SASMEXURLInput, "The Discord webhook URL to send data to.");
            // 
            // SASMEXAppendInput
            // 
            SASMEXAppendInput.BackColor = System.Drawing.Color.Black;
            SASMEXAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            SASMEXAppendInput.ForeColor = System.Drawing.Color.White;
            SASMEXAppendInput.Location = new System.Drawing.Point(161, 36);
            SASMEXAppendInput.Name = "SASMEXAppendInput";
            SASMEXAppendInput.Size = new System.Drawing.Size(146, 23);
            SASMEXAppendInput.TabIndex = 20;
            ToolTipInformation.SetToolTip(SASMEXAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label14);
            groupBox5.Controls.Add(label15);
            groupBox5.Controls.Add(NAADSBackupURLInput);
            groupBox5.Controls.Add(NAADSBackupAppendInput);
            groupBox5.ForeColor = System.Drawing.Color.White;
            groupBox5.Location = new System.Drawing.Point(336, 191);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(318, 65);
            groupBox5.TabIndex = 34;
            groupBox5.TabStop = false;
            groupBox5.Text = "Canada (NAADS Backup)";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new System.Drawing.Point(158, 18);
            label14.Name = "label14";
            label14.Size = new System.Drawing.Size(111, 15);
            label14.TabIndex = 25;
            label14.Text = "Additional Message";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new System.Drawing.Point(6, 18);
            label15.Name = "label15";
            label15.Size = new System.Drawing.Size(125, 15);
            label15.TabIndex = 24;
            label15.Text = "Discord Webhook URL";
            // 
            // NAADSBackupURLInput
            // 
            NAADSBackupURLInput.BackColor = System.Drawing.Color.Black;
            NAADSBackupURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            NAADSBackupURLInput.ForeColor = System.Drawing.Color.White;
            NAADSBackupURLInput.Location = new System.Drawing.Point(9, 36);
            NAADSBackupURLInput.Name = "NAADSBackupURLInput";
            NAADSBackupURLInput.Size = new System.Drawing.Size(146, 23);
            NAADSBackupURLInput.TabIndex = 19;
            ToolTipInformation.SetToolTip(NAADSBackupURLInput, "The Discord webhook URL to send data to.");
            // 
            // NAADSBackupAppendInput
            // 
            NAADSBackupAppendInput.BackColor = System.Drawing.Color.Black;
            NAADSBackupAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            NAADSBackupAppendInput.ForeColor = System.Drawing.Color.White;
            NAADSBackupAppendInput.Location = new System.Drawing.Point(161, 36);
            NAADSBackupAppendInput.Name = "NAADSBackupAppendInput";
            NAADSBackupAppendInput.Size = new System.Drawing.Size(146, 23);
            NAADSBackupAppendInput.TabIndex = 20;
            ToolTipInformation.SetToolTip(NAADSBackupAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label12);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(NAADSPrimaryURLInput);
            groupBox4.Controls.Add(NAADSPrimaryAppendInput);
            groupBox4.ForeColor = System.Drawing.Color.White;
            groupBox4.Location = new System.Drawing.Point(336, 120);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new System.Drawing.Size(318, 65);
            groupBox4.TabIndex = 33;
            groupBox4.TabStop = false;
            groupBox4.Text = "Canada (NAADS Primary)";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new System.Drawing.Point(158, 18);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(111, 15);
            label12.TabIndex = 25;
            label12.Text = "Additional Message";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new System.Drawing.Point(6, 18);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(125, 15);
            label13.TabIndex = 24;
            label13.Text = "Discord Webhook URL";
            // 
            // NAADSPrimaryURLInput
            // 
            NAADSPrimaryURLInput.BackColor = System.Drawing.Color.Black;
            NAADSPrimaryURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            NAADSPrimaryURLInput.ForeColor = System.Drawing.Color.White;
            NAADSPrimaryURLInput.Location = new System.Drawing.Point(9, 36);
            NAADSPrimaryURLInput.Name = "NAADSPrimaryURLInput";
            NAADSPrimaryURLInput.Size = new System.Drawing.Size(146, 23);
            NAADSPrimaryURLInput.TabIndex = 19;
            ToolTipInformation.SetToolTip(NAADSPrimaryURLInput, "The Discord webhook URL to send data to.");
            // 
            // NAADSPrimaryAppendInput
            // 
            NAADSPrimaryAppendInput.BackColor = System.Drawing.Color.Black;
            NAADSPrimaryAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            NAADSPrimaryAppendInput.ForeColor = System.Drawing.Color.White;
            NAADSPrimaryAppendInput.Location = new System.Drawing.Point(161, 36);
            NAADSPrimaryAppendInput.Name = "NAADSPrimaryAppendInput";
            NAADSPrimaryAppendInput.Size = new System.Drawing.Size(146, 23);
            NAADSPrimaryAppendInput.TabIndex = 20;
            ToolTipInformation.SetToolTip(NAADSPrimaryAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // DropChangesButton
            // 
            DropChangesButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            DropChangesButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            DropChangesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            DropChangesButton.Location = new System.Drawing.Point(665, 343);
            DropChangesButton.Name = "DropChangesButton";
            DropChangesButton.Size = new System.Drawing.Size(107, 25);
            DropChangesButton.TabIndex = 32;
            DropChangesButton.Text = "Drop Changes";
            ToolTipInformation.SetToolTip(DropChangesButton, "Drops changes that have been made to webhooks and additional messages.");
            DropChangesButton.UseVisualStyleBackColor = false;
            DropChangesButton.Click += DropChangesButton_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(NWSAtomURLInput);
            groupBox3.Controls.Add(NWSAtomAppendInput);
            groupBox3.ForeColor = System.Drawing.Color.White;
            groupBox3.Location = new System.Drawing.Point(12, 333);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(318, 65);
            groupBox3.TabIndex = 31;
            groupBox3.TabStop = false;
            groupBox3.Text = "NWS Atom";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(158, 18);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(111, 15);
            label10.TabIndex = 25;
            label10.Text = "Additional Message";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(6, 18);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(125, 15);
            label11.TabIndex = 24;
            label11.Text = "Discord Webhook URL";
            // 
            // NWSAtomURLInput
            // 
            NWSAtomURLInput.BackColor = System.Drawing.Color.Black;
            NWSAtomURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            NWSAtomURLInput.ForeColor = System.Drawing.Color.White;
            NWSAtomURLInput.Location = new System.Drawing.Point(9, 36);
            NWSAtomURLInput.Name = "NWSAtomURLInput";
            NWSAtomURLInput.Size = new System.Drawing.Size(146, 23);
            NWSAtomURLInput.TabIndex = 19;
            ToolTipInformation.SetToolTip(NWSAtomURLInput, "The Discord webhook URL to send data to.");
            // 
            // NWSAtomAppendInput
            // 
            NWSAtomAppendInput.BackColor = System.Drawing.Color.Black;
            NWSAtomAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            NWSAtomAppendInput.ForeColor = System.Drawing.Color.White;
            NWSAtomAppendInput.Location = new System.Drawing.Point(161, 36);
            NWSAtomAppendInput.Name = "NWSAtomAppendInput";
            NWSAtomAppendInput.Size = new System.Drawing.Size(146, 23);
            NWSAtomAppendInput.TabIndex = 20;
            ToolTipInformation.SetToolTip(NWSAtomAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // SaveDiscordSettingsButton
            // 
            SaveDiscordSettingsButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            SaveDiscordSettingsButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            SaveDiscordSettingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            SaveDiscordSettingsButton.Location = new System.Drawing.Point(665, 374);
            SaveDiscordSettingsButton.Name = "SaveDiscordSettingsButton";
            SaveDiscordSettingsButton.Size = new System.Drawing.Size(107, 25);
            SaveDiscordSettingsButton.TabIndex = 22;
            SaveDiscordSettingsButton.Text = "Apply Changes";
            ToolTipInformation.SetToolTip(SaveDiscordSettingsButton, "Applies webhook information immediately.");
            SaveDiscordSettingsButton.UseVisualStyleBackColor = false;
            SaveDiscordSettingsButton.Click += SaveDiscordSettingsButton_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(WEAURLInput);
            groupBox2.Controls.Add(WEAAppendInput);
            groupBox2.ForeColor = System.Drawing.Color.White;
            groupBox2.Location = new System.Drawing.Point(12, 262);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new System.Drawing.Size(318, 65);
            groupBox2.TabIndex = 30;
            groupBox2.TabStop = false;
            groupBox2.Text = "FEMA IPAWS (WEA)";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(158, 18);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(111, 15);
            label8.TabIndex = 25;
            label8.Text = "Additional Message";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(6, 18);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(125, 15);
            label9.TabIndex = 24;
            label9.Text = "Discord Webhook URL";
            // 
            // WEAURLInput
            // 
            WEAURLInput.BackColor = System.Drawing.Color.Black;
            WEAURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            WEAURLInput.ForeColor = System.Drawing.Color.White;
            WEAURLInput.Location = new System.Drawing.Point(9, 36);
            WEAURLInput.Name = "WEAURLInput";
            WEAURLInput.Size = new System.Drawing.Size(146, 23);
            WEAURLInput.TabIndex = 19;
            ToolTipInformation.SetToolTip(WEAURLInput, "The Discord webhook URL to send data to.");
            // 
            // WEAAppendInput
            // 
            WEAAppendInput.BackColor = System.Drawing.Color.Black;
            WEAAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            WEAAppendInput.ForeColor = System.Drawing.Color.White;
            WEAAppendInput.Location = new System.Drawing.Point(161, 36);
            WEAAppendInput.Name = "WEAAppendInput";
            WEAAppendInput.Size = new System.Drawing.Size(146, 23);
            WEAAppendInput.TabIndex = 20;
            ToolTipInformation.SetToolTip(WEAAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(EASURLInput);
            groupBox1.Controls.Add(EASAppendInput);
            groupBox1.ForeColor = System.Drawing.Color.White;
            groupBox1.Location = new System.Drawing.Point(12, 191);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(318, 65);
            groupBox1.TabIndex = 29;
            groupBox1.TabStop = false;
            groupBox1.Text = "FEMA IPAWS (EAS)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(158, 18);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(111, 15);
            label4.TabIndex = 25;
            label4.Text = "Additional Message";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(6, 18);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(125, 15);
            label5.TabIndex = 24;
            label5.Text = "Discord Webhook URL";
            // 
            // EASURLInput
            // 
            EASURLInput.BackColor = System.Drawing.Color.Black;
            EASURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EASURLInput.ForeColor = System.Drawing.Color.White;
            EASURLInput.Location = new System.Drawing.Point(9, 36);
            EASURLInput.Name = "EASURLInput";
            EASURLInput.Size = new System.Drawing.Size(146, 23);
            EASURLInput.TabIndex = 19;
            ToolTipInformation.SetToolTip(EASURLInput, "The Discord webhook URL to send data to.");
            // 
            // EASAppendInput
            // 
            EASAppendInput.BackColor = System.Drawing.Color.Black;
            EASAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            EASAppendInput.ForeColor = System.Drawing.Color.White;
            EASAppendInput.Location = new System.Drawing.Point(161, 36);
            EASAppendInput.Name = "EASAppendInput";
            EASAppendInput.Size = new System.Drawing.Size(146, 23);
            EASAppendInput.TabIndex = 20;
            ToolTipInformation.SetToolTip(EASAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // DefaultDiscordGroup
            // 
            DefaultDiscordGroup.Controls.Add(label7);
            DefaultDiscordGroup.Controls.Add(label6);
            DefaultDiscordGroup.Controls.Add(DefaultURLInput);
            DefaultDiscordGroup.Controls.Add(DefaultAppendInput);
            DefaultDiscordGroup.ForeColor = System.Drawing.Color.White;
            DefaultDiscordGroup.Location = new System.Drawing.Point(12, 120);
            DefaultDiscordGroup.Name = "DefaultDiscordGroup";
            DefaultDiscordGroup.Size = new System.Drawing.Size(318, 65);
            DefaultDiscordGroup.TabIndex = 28;
            DefaultDiscordGroup.TabStop = false;
            DefaultDiscordGroup.Text = "Default (any other source)";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(158, 18);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(111, 15);
            label7.TabIndex = 25;
            label7.Text = "Additional Message";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(6, 18);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(125, 15);
            label6.TabIndex = 24;
            label6.Text = "Discord Webhook URL";
            // 
            // DefaultURLInput
            // 
            DefaultURLInput.BackColor = System.Drawing.Color.Black;
            DefaultURLInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            DefaultURLInput.ForeColor = System.Drawing.Color.White;
            DefaultURLInput.Location = new System.Drawing.Point(9, 36);
            DefaultURLInput.Name = "DefaultURLInput";
            DefaultURLInput.Size = new System.Drawing.Size(146, 23);
            DefaultURLInput.TabIndex = 19;
            ToolTipInformation.SetToolTip(DefaultURLInput, "The Discord webhook URL to send data to.");
            // 
            // DefaultAppendInput
            // 
            DefaultAppendInput.BackColor = System.Drawing.Color.Black;
            DefaultAppendInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            DefaultAppendInput.ForeColor = System.Drawing.Color.White;
            DefaultAppendInput.Location = new System.Drawing.Point(161, 36);
            DefaultAppendInput.Name = "DefaultAppendInput";
            DefaultAppendInput.Size = new System.Drawing.Size(146, 23);
            DefaultAppendInput.TabIndex = 20;
            ToolTipInformation.SetToolTip(DefaultAppendInput, "An additional message to be added to the end of each alert message.");
            // 
            // BatteryGroup
            // 
            BatteryGroup.Controls.Add(label2);
            BatteryGroup.Controls.Add(BatteryReportingCriticalLevelInput);
            BatteryGroup.Controls.Add(label1);
            BatteryGroup.Controls.Add(BatteryReportingCautionLevelInput);
            BatteryGroup.Controls.Add(label3);
            BatteryGroup.ForeColor = System.Drawing.Color.White;
            BatteryGroup.Location = new System.Drawing.Point(12, 27);
            BatteryGroup.Name = "BatteryGroup";
            BatteryGroup.Size = new System.Drawing.Size(318, 87);
            BatteryGroup.TabIndex = 20;
            BatteryGroup.TabStop = false;
            BatteryGroup.Text = "Battery Reporting (system must have a battery installed)";
            // 
            // label2
            // 
            label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label2.Location = new System.Drawing.Point(168, 60);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(84, 21);
            label2.TabIndex = 27;
            label2.Text = "Critical";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ToolTipInformation.SetToolTip(label2, ".");
            // 
            // BatteryReportingCriticalLevelInput
            // 
            BatteryReportingCriticalLevelInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            BatteryReportingCriticalLevelInput.BackColor = System.Drawing.Color.Black;
            BatteryReportingCriticalLevelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            BatteryReportingCriticalLevelInput.ForeColor = System.Drawing.Color.White;
            BatteryReportingCriticalLevelInput.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            BatteryReportingCriticalLevelInput.Location = new System.Drawing.Point(258, 60);
            BatteryReportingCriticalLevelInput.Name = "BatteryReportingCriticalLevelInput";
            BatteryReportingCriticalLevelInput.Size = new System.Drawing.Size(54, 23);
            BatteryReportingCriticalLevelInput.TabIndex = 26;
            ToolTipInformation.SetToolTip(BatteryReportingCriticalLevelInput, "The level at which reporting starts for critical.");
            BatteryReportingCriticalLevelInput.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            label1.Location = new System.Drawing.Point(168, 33);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(84, 21);
            label1.TabIndex = 25;
            label1.Text = "Caution";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            ToolTipInformation.SetToolTip(label1, ".");
            // 
            // BatteryReportingCautionLevelInput
            // 
            BatteryReportingCautionLevelInput.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            BatteryReportingCautionLevelInput.BackColor = System.Drawing.Color.Black;
            BatteryReportingCautionLevelInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            BatteryReportingCautionLevelInput.ForeColor = System.Drawing.Color.White;
            BatteryReportingCautionLevelInput.Increment = new decimal(new int[] { 5, 0, 0, 0 });
            BatteryReportingCautionLevelInput.Location = new System.Drawing.Point(258, 33);
            BatteryReportingCautionLevelInput.Name = "BatteryReportingCautionLevelInput";
            BatteryReportingCautionLevelInput.Size = new System.Drawing.Size(54, 23);
            BatteryReportingCautionLevelInput.TabIndex = 24;
            ToolTipInformation.SetToolTip(BatteryReportingCautionLevelInput, "The level at which reporting starts for caution.");
            BatteryReportingCautionLevelInput.Value = new decimal(new int[] { 20, 0, 0, 0 });
            // 
            // label3
            // 
            label3.Location = new System.Drawing.Point(6, 17);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(156, 63);
            label3.TabIndex = 14;
            label3.Text = "Battery measurements are reported to the default Discord webhook when a\r\npercentage is reached.";
            // 
            // DisableHeartbeatBox
            // 
            DisableHeartbeatBox.AutoSize = true;
            DisableHeartbeatBox.Location = new System.Drawing.Point(336, 95);
            DisableHeartbeatBox.Name = "DisableHeartbeatBox";
            DisableHeartbeatBox.Size = new System.Drawing.Size(117, 19);
            DisableHeartbeatBox.TabIndex = 19;
            DisableHeartbeatBox.Text = "Disable heartbeat";
            ToolTipInformation.SetToolTip(DisableHeartbeatBox, "Disables the \"I'm\"\r\nThis is not related ");
            DisableHeartbeatBox.UseVisualStyleBackColor = true;
            // 
            // TitleText
            // 
            TitleText.AutoSize = true;
            TitleText.Location = new System.Drawing.Point(9, 9);
            TitleText.Margin = new System.Windows.Forms.Padding(0);
            TitleText.Name = "TitleText";
            TitleText.Size = new System.Drawing.Size(516, 15);
            TitleText.TabIndex = 21;
            TitleText.Text = "Choose a Discord webhook source to configure, and click Modify Webhook to apply all changes.";
            // 
            // DiscordWebhookRelayLocallyBox
            // 
            DiscordWebhookRelayLocallyBox.AutoSize = true;
            DiscordWebhookRelayLocallyBox.Location = new System.Drawing.Point(336, 70);
            DiscordWebhookRelayLocallyBox.Name = "DiscordWebhookRelayLocallyBox";
            DiscordWebhookRelayLocallyBox.Size = new System.Drawing.Size(91, 19);
            DiscordWebhookRelayLocallyBox.TabIndex = 17;
            DiscordWebhookRelayLocallyBox.Text = "Relay locally";
            ToolTipInformation.SetToolTip(DiscordWebhookRelayLocallyBox, "Relay alerts locally in addition to sending a message.");
            DiscordWebhookRelayLocallyBox.UseVisualStyleBackColor = true;
            // 
            // DiscordWebhookConfirmAlertsBox
            // 
            DiscordWebhookConfirmAlertsBox.AutoSize = true;
            DiscordWebhookConfirmAlertsBox.Location = new System.Drawing.Point(336, 45);
            DiscordWebhookConfirmAlertsBox.Name = "DiscordWebhookConfirmAlertsBox";
            DiscordWebhookConfirmAlertsBox.Size = new System.Drawing.Size(101, 19);
            DiscordWebhookConfirmAlertsBox.TabIndex = 15;
            DiscordWebhookConfirmAlertsBox.Text = "Confirm alerts";
            ToolTipInformation.SetToolTip(DiscordWebhookConfirmAlertsBox, "Shows a window with alert information for a short period of time.\r\nYou can either forward the alert by waiting or clicking \"FORWARD\", or discard it by clicking \"STOP\".");
            DiscordWebhookConfirmAlertsBox.UseVisualStyleBackColor = true;
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
            // DiscordConfigurationForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(784, 411);
            Controls.Add(ConfigurationPanel);
            Controls.Add(BusyLockText);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "DiscordConfigurationForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Discord Webhook Settings";
            FormClosing += ServerConfigurationForm_FormClosing;
            Load += ServerConfigurationForm_Load;
            ConfigurationPanel.ResumeLayout(false);
            ConfigurationPanel.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            DefaultDiscordGroup.ResumeLayout(false);
            DefaultDiscordGroup.PerformLayout();
            BatteryGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)BatteryReportingCriticalLevelInput).EndInit();
            ((System.ComponentModel.ISupportInitialize)BatteryReportingCautionLevelInput).EndInit();
            ResumeLayout(false);

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
