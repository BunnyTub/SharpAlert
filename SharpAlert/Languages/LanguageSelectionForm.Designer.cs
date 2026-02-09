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
            ContinueButton = new System.Windows.Forms.Button();
            LangJapaneseRadio = new System.Windows.Forms.RadioButton();
            LangSpanishRadio = new System.Windows.Forms.RadioButton();
            LangEnglishRadio = new System.Windows.Forms.RadioButton();
            ToolTipInformation = new System.Windows.Forms.ToolTip(components);
            RotateLanguages = new System.Windows.Forms.Timer(components);
            LanguagesGroup.SuspendLayout();
            SuspendLayout();
            // 
            // LanguagesGroup
            // 
            LanguagesGroup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            LanguagesGroup.Controls.Add(ContinueButton);
            LanguagesGroup.Controls.Add(LangJapaneseRadio);
            LanguagesGroup.Controls.Add(LangSpanishRadio);
            LanguagesGroup.Controls.Add(LangEnglishRadio);
            LanguagesGroup.ForeColor = System.Drawing.Color.White;
            LanguagesGroup.Location = new System.Drawing.Point(12, 12);
            LanguagesGroup.Name = "LanguagesGroup";
            LanguagesGroup.Size = new System.Drawing.Size(257, 149);
            LanguagesGroup.TabIndex = 1;
            LanguagesGroup.TabStop = false;
            LanguagesGroup.Text = "Language Selector";
            // 
            // ContinueButton
            // 
            ContinueButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            ContinueButton.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            ContinueButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            ContinueButton.Font = new System.Drawing.Font("Segoe UI", 14F);
            ContinueButton.Location = new System.Drawing.Point(151, 111);
            ContinueButton.Name = "ContinueButton";
            ContinueButton.Size = new System.Drawing.Size(100, 32);
            ContinueButton.TabIndex = 7;
            ContinueButton.Text = "Done";
            ContinueButton.UseVisualStyleBackColor = false;
            ContinueButton.Click += ContinueButton_Click;
            // 
            // LangJapaneseRadio
            // 
            LangJapaneseRadio.AutoSize = true;
            LangJapaneseRadio.Font = new System.Drawing.Font("Segoe UI", 12F);
            LangJapaneseRadio.Location = new System.Drawing.Point(9, 84);
            LangJapaneseRadio.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
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
            LangSpanishRadio.Location = new System.Drawing.Point(9, 53);
            LangSpanishRadio.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
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
            LangEnglishRadio.Location = new System.Drawing.Point(9, 22);
            LangEnglishRadio.Margin = new System.Windows.Forms.Padding(6, 3, 3, 3);
            LangEnglishRadio.Name = "LangEnglishRadio";
            LangEnglishRadio.Size = new System.Drawing.Size(78, 25);
            LangEnglishRadio.TabIndex = 3;
            LangEnglishRadio.TabStop = true;
            LangEnglishRadio.Text = "English";
            LangEnglishRadio.UseVisualStyleBackColor = true;
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
            ClientSize = new System.Drawing.Size(281, 173);
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
        private System.Windows.Forms.RadioButton LangEnglishRadio;
        private System.Windows.Forms.RadioButton LangJapaneseRadio;
        private System.Windows.Forms.RadioButton LangSpanishRadio;
        private System.Windows.Forms.Timer RotateLanguages;
        private System.Windows.Forms.Button ContinueButton;
    }
}
