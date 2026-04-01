using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;

namespace SharpAlert.Languages
{
    public static class Language
    {
        private static Dictionary<string, string> _data = [];
        public static string CurrentLang { get; private set; } = string.Empty;
        public static Font CurrentFont { get; private set; } = null;
        //public static Font DefaultFont { get; private set; } = new Font("Segoe UI", 9F, FontStyle.Regular);

        private static bool CheckIfFontExists(string name)
        {
            using InstalledFontCollection fonts = new();
            return fonts.Families.Any(f =>
                string.Equals(f.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        public static void Load(string langCode)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = null;

            foreach (string name in assembly.GetManifestResourceNames())
            {
                //Console.WriteLine(name);
                if (name.EndsWith("Language_" + langCode + ".json", StringComparison.OrdinalIgnoreCase))
                {
                    resourceName = name;
                    break;
                }
            }

            if (resourceName == null)
            {
                if (langCode == "en")
                {
                    MessageBox.Show("The language data is invalid or corrupt.\r\n" +
                        "There may be more corrupted data.", "SharpAlert",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                MessageBox.Show("The language data is invalid or corrupt.\r\n" +
                    "The current language will be reset.", "SharpAlert",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                LanguageSelectionForm lsf = new();
                lsf.ShowDialog();
                lsf.Dispose();
                
                return;
                //throw new FileNotFoundException($"No such 'Language_{langCode}.json' file exists.");
            }

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new(stream))
            {
                string json = reader.ReadToEnd();
                _data = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                _data ??= [];
            }

            CurrentLang = langCode;

            string font = Get("RecommendedFontChoice", "none");
            string link = Get("FontChoiceURLDownload", "No download URL available.");

            if (!string.IsNullOrWhiteSpace(font))
            {
                if (font == "none")
                {
                    Console.WriteLine($"[Language] The language file did not specify a recommended font.");
                }
                else
                {
                    try
                    {
                        if (CheckIfFontExists(font))
                        {
                            CurrentFont = new Font(font, 12f);
                            Console.WriteLine($"[Language] Using font: {CurrentFont.Name}");
                        }
                        else
                        {
                            Console.WriteLine($"[Language] Using no set font. Font wasn't found: {font}");
                            MessageBox.Show(Get("FontNotFound", $"The recommended font for this language pack is not available. Some text may not properly display as the author of the language pack intends to.\r\n\r\n" +
                                $"Font name: %1\r\n" +
                                $"Font download: %2").Replace("%1", font).Replace("%2", link), "SharpAlert",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation);
                        }
                    }
                    catch (Exception ex)
                    {
                        CurrentFont = null;
                        Console.WriteLine($"[Language] Using no set font. {ex.Message}");
                    }
                }
            }
            else
            {
                CurrentFont = null;
                Console.WriteLine($"[Language] The language file did not specify a recommended font.");
            }
        }

        public static string LoadGet(string langCode, string key, string fallback = "")
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            string resourceName = null;

            foreach (string name in assembly.GetManifestResourceNames())
            {
                //Console.WriteLine(name);
                if (name.EndsWith("Language_" + langCode + ".json", StringComparison.OrdinalIgnoreCase))
                {
                    resourceName = name;
                    break;
                }
            }

            if (resourceName == null)
            {
                //if (langCode == "en")
                //{
                //    MessageBox.Show("There was a problem processing language data.\r\n" +
                //        "You may have a corrupted copy of SharpAlert.", "SharpAlert - Language Processing",
                //        MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //    return;
                //}

                //MessageBox.Show("There was a problem processing language data.\r\n" +
                //    "The language data may be corrupted.", "SharpAlert - Language Processing",
                //    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (!string.IsNullOrWhiteSpace(fallback)) return fallback;
                else return $"{key}...?";
                
                //throw new FileNotFoundException($"No such 'Language_{langCode}.json' file exists.");
            }

            Dictionary<string, string> data = [];

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new(stream))
            {
                string json = reader.ReadToEnd();
                data = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
                data ??= [];
            }

            CurrentLang = langCode;

            if (data.TryGetValue(key, out string val)) return val;
            else
            {
                if (!string.IsNullOrWhiteSpace(fallback)) return fallback;
                else return $"{key}...?";
            }
        }

        public static string Get(string key, string fallback = "")
        {
            //if (string.IsNullOrEmpty(CurrentLang)) return "";

            if (_data.TryGetValue(key, out string val))
            {
                if (AprilFools.IsAprilFoolsNow) val = AprilFools.OwOify(val); // APRIL FOOLS
                return val;
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(fallback)) return fallback;
                else return $"{key}...?";
            }
        }

        public static void ApplyFont(Control parent)
        {
            if (CurrentFont == null) // || CurrentFont == DefaultFont
            {
                //foreach (Control ctrl in parent.Controls)
                //{
                //    //if (ctrl.Font != null)
                //    //{
                //    //    ctrl.Font = new Font(
                //    //        DefaultFont.FontFamily,
                //    //        ctrl.Font.Size,
                //    //        ctrl.Font.Style,
                //    //        ctrl.Font.Unit,
                //    //        DefaultFont.GdiCharSet,
                //    //        DefaultFont.GdiVerticalFont
                //    //    );
                //    //}
                    
                //    if (ctrl.Font != null)
                //    {
                //        ctrl.Font = new Font(
                //            DefaultFont.FontFamily,
                //            ctrl.Font.Size,
                //            ctrl.Font.Style,
                //            ctrl.Font.Unit,
                //            DefaultFont.GdiCharSet,
                //            DefaultFont.GdiVerticalFont
                //        );
                //    }

                //    if (ctrl.HasChildren) ApplyFont(ctrl);
                //}
            }
            else
            {
                foreach (Control ctrl in parent.Controls)
                {
                    if (ctrl.Font != null)
                    {
                        ctrl.Font = new Font(
                            CurrentFont.FontFamily,
                            ctrl.Font.Size,
                            ctrl.Font.Style,
                            ctrl.Font.Unit,
                            CurrentFont.GdiCharSet,
                            CurrentFont.GdiVerticalFont
                        );
                    }

                    if (ctrl.HasChildren) ApplyFont(ctrl);
                }
            }
        }
    }
}
