namespace SharpAlert.Languages
{
    partial class LanguageSelectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LanguageSelectionForm));
            LanguagesGroup = new System.Windows.Forms.GroupBox();
            LanguageProgress = new System.Windows.Forms.ProgressBar();
            ContinueButton = new System.Windows.Forms.Button();
            CustomLanguageRadio = new System.Windows.Forms.RadioButton();
            LangJapaneseRadio = new System.Windows.Forms.RadioButton();
            LangSpanishRadio = new System.Windows.Forms.RadioButton();
            LangEnglishRadio = new System.Windows.Forms.RadioButton();
            RestartProgramButton = new System.Windows.Forms.Button();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            RotateLanguages = new System.Windows.Forms.Timer(components);
            LanguagesGroup.SuspendLayout();
            SuspendLayout();
            // 
            // LanguagesGroup
            // 
            LanguagesGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            LanguagesGroup.Controls.Add(LanguageProgress);
            LanguagesGroup.Controls.Add(ContinueButton);
            LanguagesGroup.Controls.Add(CustomLanguageRadio);
            LanguagesGroup.Controls.Add(LangJapaneseRadio);
            LanguagesGroup.Controls.Add(LangSpanishRadio);
            LanguagesGroup.Controls.Add(LangEnglishRadio);
            LanguagesGroup.Controls.Add(RestartProgramButton);
            LanguagesGroup.ForeColor = System.Drawing.Color.White;
            LanguagesGroup.Location = new System.Drawing.Point(12, 12);
            LanguagesGroup.Name = "LanguagesGroup";
            LanguagesGroup.Size = new System.Drawing.Size(379, 189);
            LanguagesGroup.TabIndex = 1;
            LanguagesGroup.TabStop = false;
            LanguagesGroup.Text = "Language Selector";
            // 
            // LanguageProgress
            // 
            LanguageProgress.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            LanguageProgress.Location = new System.Drawing.Point(6, 160);
            LanguageProgress.Maximum = 8;
            LanguageProgress.Name = "LanguageProgress";
            LanguageProgress.Size = new System.Drawing.Size(367, 23);
            LanguageProgress.Step = 1;
            LanguageProgress.TabIndex = 8;
            LanguageProgress.Click += LanguageProgress_Click;
            // 
            // ContinueButton
            // 
            ContinueButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ContinueButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ContinueButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ContinueButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            ContinueButton.Location = new System.Drawing.Point(242, 22);
            ContinueButton.Name = "ContinueButton";
            ContinueButton.Size = new System.Drawing.Size(131, 40);
            ContinueButton.TabIndex = 7;
            ContinueButton.Text = "Done";
            ContinueButton.UseVisualStyleBackColor = false;
            ContinueButton.Click += ContinueButton_Click;
            // 
            // CustomLanguageRadio
            // 
            CustomLanguageRadio.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            CustomLanguageRadio.AutoSize = true;
            CustomLanguageRadio.Enabled = false;
            CustomLanguageRadio.Font = new System.Drawing.Font("Segoe UI", 12F);
            CustomLanguageRadio.Location = new System.Drawing.Point(291, 68);
            CustomLanguageRadio.Name = "CustomLanguageRadio";
            CustomLanguageRadio.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            CustomLanguageRadio.Size = new System.Drawing.Size(82, 25);
            CustomLanguageRadio.TabIndex = 6;
            CustomLanguageRadio.TabStop = true;
            CustomLanguageRadio.Text = "Custom";
            CustomLanguageRadio.UseVisualStyleBackColor = true;
            // 
            // LangJapaneseRadio
            // 
            LangJapaneseRadio.AutoSize = true;
            LangJapaneseRadio.Font = new System.Drawing.Font("Segoe UI", 12F);
            LangJapaneseRadio.Location = new System.Drawing.Point(6, 130);
            LangJapaneseRadio.Name = "LangJapaneseRadio";
            LangJapaneseRadio.Size = new System.Drawing.Size(79, 25);
            LangJapaneseRadio.TabIndex = 5;
            LangJapaneseRadio.TabStop = true;
            LangJapaneseRadio.Text = "日本語";
            LangJapaneseRadio.UseVisualStyleBackColor = true;
            // 
            // LangSpanishRadio
            // 
            LangSpanishRadio.AutoSize = true;
            LangSpanishRadio.Font = new System.Drawing.Font("Segoe UI", 12F);
            LangSpanishRadio.Location = new System.Drawing.Point(6, 99);
            LangSpanishRadio.Name = "LangSpanishRadio";
            LangSpanishRadio.Size = new System.Drawing.Size(82, 25);
            LangSpanishRadio.TabIndex = 4;
            LangSpanishRadio.TabStop = true;
            LangSpanishRadio.Text = "Español";
            LangSpanishRadio.UseVisualStyleBackColor = true;
            // 
            // LangEnglishRadio
            // 
            LangEnglishRadio.AutoSize = true;
            LangEnglishRadio.Font = new System.Drawing.Font("Segoe UI", 12F);
            LangEnglishRadio.Location = new System.Drawing.Point(6, 68);
            LangEnglishRadio.Name = "LangEnglishRadio";
            LangEnglishRadio.Size = new System.Drawing.Size(78, 25);
            LangEnglishRadio.TabIndex = 3;
            LangEnglishRadio.TabStop = true;
            LangEnglishRadio.Text = "English";
            LangEnglishRadio.UseVisualStyleBackColor = true;
            // 
            // RestartProgramButton
            // 
            RestartProgramButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            RestartProgramButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            RestartProgramButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            RestartProgramButton.Font = new System.Drawing.Font("Segoe UI", 18F);
            RestartProgramButton.Location = new System.Drawing.Point(6, 22);
            RestartProgramButton.Name = "RestartProgramButton";
            RestartProgramButton.Size = new System.Drawing.Size(230, 40);
            RestartProgramButton.TabIndex = 2;
            RestartProgramButton.Text = "Restart Program";
            RestartProgramButton.UseVisualStyleBackColor = false;
            RestartProgramButton.Click += RestartProgramButton_Click;
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
            // RotateLanguages
            // 
            RotateLanguages.Enabled = true;
            RotateLanguages.Interval = 500;
            RotateLanguages.Tick += RotateLanguages_Tick;
            // 
            // LanguageSelectionForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(20, 20, 20);
            ClientSize = new System.Drawing.Size(403, 213);
            Controls.Add(LanguagesGroup);
            Font = new System.Drawing.Font("Segoe UI", 9F);
            ForeColor = System.Drawing.Color.White;
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LanguageSelectionForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "SharpAlert - Language Selector";
            Load += AlertConfigurationForm_Load;
            LanguagesGroup.ResumeLayout(false);
            LanguagesGroup.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox LanguagesGroup;
        private System.Windows.Forms.ToolTip ToolTipInformation;
        private System.Windows.Forms.Button RestartProgramButton;
        private System.Windows.Forms.RadioButton LangEnglishRadio;
        private System.Windows.Forms.RadioButton LangJapaneseRadio;
        private System.Windows.Forms.RadioButton LangSpanishRadio;
        private System.Windows.Forms.RadioButton CustomLanguageRadio;
        private System.Windows.Forms.Timer RotateLanguages;
        private System.Windows.Forms.Button ContinueButton;
        private System.Windows.Forms.ProgressBar LanguageProgress;
    }
}
