using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using SharpAlert.ProgramWorker;
using SharpAlert.SourceCapturing.SystemSpecific;
using static SharpAlert.ProgramWorker.MainEntryPoint;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class ChooseRegionForm : Form
    {
        bool ShowNextInsteadOfDone = false;

        public ChooseRegionForm(bool ShowNextInsteadOfDone_)
        {
            InitializeComponent();
            ShowNextInsteadOfDone = ShowNextInsteadOfDone_;
            if (ShowNextInsteadOfDone)
            {
                TitleText.Text = "Where do you want alerts from?";
                DoneButton.Text = "Next";
            }
            else
            {
                TitleText.Text = "Choose your region settings.";
                DoneButton.Text = "Done";
            }
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool Initialized = false;

        private void ChooseRegionForm_Load(object sender, EventArgs e)
        {
            if (Initialized) return;
            Initialized = true;

            RegionUnitedStatesBox.Checked = QuickSettings.Instance.RegionUnitedStates;
            RegionUnitedStatesBox.CheckedChanged += (a, b) => QuickSettings.Instance.RegionUnitedStates = ((CheckBox)a).Checked;
            RegionUnitedStatesNWSBox.Checked = QuickSettings.Instance.RegionUnitedStatesNWS;
            RegionUnitedStatesNWSBox.CheckedChanged += (a, b) =>
            {
                QuickSettings.Instance.RegionUnitedStatesNWS = ((CheckBox)a).Checked;
                //if (((CheckBox)a).Checked) MessageBox.Show("",
                //    "SharpAlert",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Exclamation);
            };
            RegionCanadaBox.Checked = QuickSettings.Instance.RegionCanada;
            RegionCanadaBox.CheckedChanged += (a, b) => QuickSettings.Instance.RegionCanada = ((CheckBox)a).Checked;
            RegionMexicoBox.Checked = QuickSettings.Instance.RegionMexico;
            RegionMexicoBox.CheckedChanged += (a, b) => QuickSettings.Instance.RegionMexico = ((CheckBox)a).Checked;
            RegionBrazilBox.Checked = QuickSettings.Instance.RegionBrazil;
            RegionBrazilBox.CheckedChanged += (a, b) => QuickSettings.Instance.RegionBrazil = ((CheckBox)a).Checked;
        }

        private void ChooseRegionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            bool AtLeastOneChecked = false;

            foreach (var control in this.Controls)
            {
                if (control is CheckBox box)
                {
                    if (box.Checked)
                    {
                        AtLeastOneChecked = true;
                        break;
                    }
                }
            }

            if (AtLeastOneChecked)
            {
            }
            else
            {
                if (MessageBox.Show("There are no regions selected.\r\n" +
                    "Do you want to continue without alert polling?",
                    Text,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }

            if (!ShowNextInsteadOfDone)
            {
                MessageBox.Show("Restart the program to apply region changes.",
                    Text,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void ChooseRegionForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Hover over the region boxes for their respective info.",
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            e.Cancel = true;
        }

        private void LinkButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("If you have custom URLs, click OK.\r\n" +
                "Your URLs must provide alerts in CAP (XML) format.\r\n" +
                "Separate URLs by placing them in separate lines.\r\n" +
                "Create comments by starting a new line with \"#\".",
                Text,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                try
                {
                    if (!File.Exists($"{QuickSettings.ConfigDirPath}\\{CustomURLsFileName}"))
                    {
                        File.WriteAllText($"{QuickSettings.ConfigDirPath}\\{CustomURLsFileName}", "# Insert your URLs at any line in this file.\r\n" +
                            "# Changes only apply within SharpAlert after you restart the program.\r\n\r\n" +
                            "#https://example.com/feed.xml");
                    }

                    Process.Start(new ProcessStartInfo { FileName = $"{QuickSettings.ConfigDirPath}\\{CustomURLsFileName}", UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ChangeLaterText_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new IDAPNoticeForm().ShowDialog();
        }
    }
}

