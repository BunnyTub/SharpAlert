using System;
using System.Windows.Forms;
using SharpAlert.ProgramWorker;
using SharpAlert.Properties;

namespace SharpAlert.Languages
{
    public partial class LanguageSelectionForm : Form
    {
        public LanguageSelectionForm()
        {
            InitializeComponent();
        }

        private bool Initialized = false;

        private void AlertConfigurationForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Translations are not complete, and there are many places without proper translations from English. You are still able to change languages.", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (Initialized) return;
            Initialized = true;

            RotateLanguages_Tick(null, null);

            //CustomLanguageRadio.Checked = false;
            LangEnglishRadio.Checked = false;
            LangSpanishRadio.Checked = false;
            LangJapaneseRadio.Checked = false;

            switch (QuickSettings.Instance.LanguageCode)
            {
                case "en":
                    LangEnglishRadio.Checked = true;
                    break;
                case "es":
                    LangSpanishRadio.Checked = true;
                    break;
                case "ja":
                    LangJapaneseRadio.Checked = true;
                    break;
                default:
                    //CustomLanguageRadio.Checked = true;
                    break;
            }

            LangEnglishRadio.CheckedChanged += (a, b) => { if (((RadioButton)a).Checked) ChangeLanguage("en"); };
            LangSpanishRadio.CheckedChanged += (a, b) => { if (((RadioButton)a).Checked) ChangeLanguage("es"); };
            LangJapaneseRadio.CheckedChanged += (a, b) => { if (((RadioButton)a).Checked) ChangeLanguage("ja"); };
        }

        private void ChangeLanguage(string code)
        {
            QuickSettings.Instance.LanguageCode = code;
            QuickSettings.Instance.Save();

            MessageBox.Show(Language.LoadGet(code, "LanguageChanged", "The language has been changed.\r\nRe-open SharpAlert to see the new language everywhere."), Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

            QuickSettings.Instance.Save();
            Environment.Exit(100);
        }

        int CurrentLocalLang = 1;

        private readonly string LanguageWindowTitle_en = "Language Selector";
        private readonly string LanguageWindowTitle_es = "Selector de idioma";
        private readonly string LanguageWindowTitle_ja = "言語セレクター";

        //private readonly string LanguageRestartButton_en = "Restart Program";
        //private readonly string LanguageRestartButton_es = "Reiniciar Programa";
        //private readonly string LanguageRestartButton_ja = "アプリを再起動";

        private readonly string LanguageDoneButton_en = "Done";
        private readonly string LanguageDoneButton_es = "Listo";
        private readonly string LanguageDoneButton_ja = "終了";

        private int WaitTime = 0;

        private void RotateLanguages_Tick(object sender, EventArgs e)
        {
            if (WaitTime == 3)
            {
                //LanguageProgress.Value = 8;
                WaitTime = 0;
            }
            else
            {
                //LanguageProgress.Value = WaitTime + 1;
                WaitTime++;
                return;
            }

        entry:
            switch (CurrentLocalLang)
            {
                case 1:
                    Text = $"SharpAlert - {LanguageWindowTitle_en}";
                    LanguagesGroup.Text = LanguageWindowTitle_en;
                    //RestartProgramButton.Text = LanguageRestartButton_en;
                    ContinueButton.Text = LanguageDoneButton_en;
                    break;
                case 2:
                    Text = $"SharpAlert - {LanguageWindowTitle_es}";
                    LanguagesGroup.Text = LanguageWindowTitle_es;
                    //RestartProgramButton.Text = LanguageRestartButton_es;
                    ContinueButton.Text = LanguageDoneButton_es;
                    break;
                case 3:
                    Text = $"SharpAlert - {LanguageWindowTitle_ja}";
                    LanguagesGroup.Text = LanguageWindowTitle_ja;
                    //RestartProgramButton.Text = LanguageRestartButton_ja;
                    ContinueButton.Text = LanguageDoneButton_ja;
                    break;
                default:
                    CurrentLocalLang = 0;
                    break;
            }

            if (CurrentLocalLang == 0)
            {
                CurrentLocalLang++;
                goto entry;
            }

            //LanguageProgress.Value = 0;

            CurrentLocalLang++;
        }

        private void ContinueButton_Click(object sender, EventArgs e)
        {
            QuickSettings.Instance.Save();
            Close();
        }

        private void LanguageProgress_Click(object sender, EventArgs e)
        {
            RotateLanguages_Tick(null, null);
        }
    }
}

