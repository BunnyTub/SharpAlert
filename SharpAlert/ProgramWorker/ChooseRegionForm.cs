using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using SharpAlert.Properties;
using static SharpAlert.MainEntryPoint;

namespace SharpAlert
{
    public partial class ChooseRegionForm : Form
    {
        public ChooseRegionForm(bool ShowNextInsteadOfDone)
        {
            InitializeComponent();
            if (ShowNextInsteadOfDone) DoneButton.Text = "Next";
            else DoneButton.Text = "Done";
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

            RegionUnitedStatesBox.Checked = Settings.Default.RegionUnitedStates;
            RegionUnitedStatesBox.CheckedChanged += (a, b) => Settings.Default.RegionUnitedStates = ((CheckBox)a).Checked;
            RegionUnitedStatesNWSBox.Checked = Settings.Default.RegionUnitedStatesNWS;
            RegionUnitedStatesNWSBox.CheckedChanged += (a, b) =>
            {
                Settings.Default.RegionUnitedStatesNWS = ((CheckBox)a).Checked;
                //if (((CheckBox)a).Checked) MessageBox.Show("",
                //    "SharpAlert",
                //    MessageBoxButtons.OK,
                //    MessageBoxIcon.Exclamation);
            };
            RegionCanadaBox.Checked = Settings.Default.RegionCanada;
            RegionCanadaBox.CheckedChanged += (a, b) => Settings.Default.RegionCanada = ((CheckBox)a).Checked;
            RegionMexicoBox.Checked = Settings.Default.RegionMexico;
            RegionMexicoBox.CheckedChanged += (a, b) => Settings.Default.RegionMexico = ((CheckBox)a).Checked;
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
                DialogResult = DialogResult.OK;
            }
            else
            {
                if (MessageBox.Show("There are no regions selected.\r\n" +
                    "Do you want to continue without alert polling?",
                    "SharpAlert",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ChooseRegionForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Hover over the region boxes for their respective info.",
                "SharpAlert",
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
                "SharpAlert",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Information);

            if (result == DialogResult.OK)
            {
                try
                {
                    if (!File.Exists($"{AssemblyDirectory}\\{CustomURLsFileName}"))
                    {
                        File.WriteAllText($"{AssemblyDirectory}\\{CustomURLsFileName}", "# Insert your URLs at any line in this file.\r\n" +
                            "# Changes only apply within SharpAlert after you restart the program.\r\n\r\n" +
                            "#https://example.com/feed.xml");
                    }

                    Process.Start($"{AssemblyDirectory}\\{CustomURLsFileName}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
