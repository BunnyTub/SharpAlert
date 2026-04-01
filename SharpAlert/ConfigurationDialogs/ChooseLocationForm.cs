using System;
using System.Drawing;
using System.Windows.Forms;
using SharpAlert.ProgramWorker;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class ChooseLocationForm : Form
    {
        public ChooseLocationForm(bool ShowNextInsteadOfDone)
        {
            InitializeComponent();
            if (ShowNextInsteadOfDone)
            {
                DoneButton.Text = "Next";
                TitleText.Text = "Receive alerts for only some locations?";
                SkipButton.Visible = true;
            }
            else
            {
                DoneButton.Text = "Done";
                TitleText.Text = "Customize your location(s) here.";
                SkipButton.Visible = false;
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

            ListAreaSAMEOutput.Clear();
            foreach (string area in QuickSettings.Instance.AllowedSAMELocations_Geocodes)
            {
                ListAreaSAMEOutput.Text = $"{area}\r\n{ListAreaSAMEOutput.Text}";
            }

            ListAreaCAPCPOutput.Clear();
            foreach (string area in QuickSettings.Instance.AllowedCAPCPLocations_Geocodes)
            {
                ListAreaCAPCPOutput.Text = $"{area}\r\n{ListAreaCAPCPOutput.Text}";
            }
        }

        private void ChooseRegionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void ChooseRegionForm_HelpButtonClicked(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Hover over the options for their respective info.\r\n" +
                "Locations are used to control what alerts you receive.\r\n" +
                "You'll only receive alerts for the locations you specify.",
                "SharpAlert",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            e.Cancel = true;
        }

        private void SAMEAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AreaSAMEInput.Text))
            {
                if (!(AreaSAMEInput.Text.Length >= 5))
                {
                    MessageBox.Show("The SAME location must be at least 5-6 characters.",
                        "SharpAlert",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                    AreaSAMEInput.Clear();
                    return;
                }

                if (QuickSettings.Instance.AllowedSAMELocations_Geocodes.Contains(AreaSAMEInput.Text))
                {
                    var removal = MessageBox.Show("The SAME location is already in the list. Remove it?",
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (removal == DialogResult.Yes) QuickSettings.Instance.AllowedSAMELocations_Geocodes.Remove(AreaSAMEInput.Text);
                    ListAreaSAMEOutput.Clear();
                    foreach (string area in QuickSettings.Instance.AllowedSAMELocations_Geocodes)
                    {
                        ListAreaSAMEOutput.Text = $"{area}\r\n{ListAreaSAMEOutput.Text}";
                    }
                    AreaSAMEInput.Clear();
                    return;
                }
                else
                {
                    QuickSettings.Instance.AllowedSAMELocations_Geocodes.Add(AreaSAMEInput.Text);
                    ListAreaSAMEOutput.Clear();
                    foreach (string area in QuickSettings.Instance.AllowedSAMELocations_Geocodes)
                    {
                        ListAreaSAMEOutput.Text = $"{area}\r\n{ListAreaSAMEOutput.Text}";
                    }
                    AreaSAMEInput.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter a SAME location value to add it.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void UGCAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AreaCAPCPInput.Text))
            {
                //if (!(AreaCAPCPInput.Text.Length >= 5))
                //{
                //    MessageBox.Show("The CAP-CP location must be at least 5-6 characters.",
                //        "SharpAlert",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Exclamation);
                //    AreaCAPCPInput.Clear();
                //    return;
                //}

                if (QuickSettings.Instance.AllowedCAPCPLocations_Geocodes.Contains(AreaCAPCPInput.Text))
                {
                    var removal = MessageBox.Show("The CAP-CP location is already in the list. Remove it?",
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (removal == DialogResult.Yes) QuickSettings.Instance.AllowedCAPCPLocations_Geocodes.Remove(AreaCAPCPInput.Text);
                    ListAreaCAPCPOutput.Clear();
                    foreach (string area in QuickSettings.Instance.AllowedCAPCPLocations_Geocodes)
                    {
                        ListAreaCAPCPOutput.Text = $"{area}\r\n{ListAreaCAPCPOutput.Text}";
                    }
                    AreaCAPCPInput.Clear();
                    return;
                }
                else
                {
                    QuickSettings.Instance.AllowedCAPCPLocations_Geocodes.Add(AreaCAPCPInput.Text);
                    ListAreaCAPCPOutput.Clear();
                    foreach (string area in QuickSettings.Instance.AllowedCAPCPLocations_Geocodes)
                    {
                        ListAreaCAPCPOutput.Text = $"{area}\r\n{ListAreaCAPCPOutput.Text}";
                    }
                    AreaCAPCPInput.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter a CAP-CP location value to add it.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void SAMEClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear SAME location data?",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QuickSettings.Instance.AllowedSAMELocations_Geocodes.Clear();
                ListAreaSAMEOutput.Clear();
            }
        }

        private void UGCClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear CAP-CP location data?",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QuickSettings.Instance.AllowedCAPCPLocations_Geocodes.Clear();
                ListAreaCAPCPOutput.Clear();
            }
        }

        private readonly LocationsAdditionForm laf = new LocationsAdditionForm();

        private void SAMESelectButton_Click(object sender, EventArgs e)
        {
            var result = laf.ShowDialog();
            if (result == DialogResult.OK)
            {
                string lefted = $"{laf.SelectedState.Id.ToString().PadLeft(3, '0')}";
                string righted;

                if (laf.AnyAlertsInThisStateBox.Enabled && laf.AnyAlertsInThisStateBox.Checked && laf.SelectedCounty.Id == 0)
                {
                    righted = "***";
                }
                else
                {
                    righted = $"{laf.SelectedCounty.Id.ToString().PadLeft(3, '0')}";
                }

                AreaSAMEInput.Enabled = false;
                AreaSAMEInput.Text = lefted + righted;
                SAMEAddButton.PerformClick();
                AreaSAMEInput.Enabled = true;
            }
        }

        private void CustomAddButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(AreaCustomNameInput.Text) && !string.IsNullOrWhiteSpace(AreaCustomInput.Text))
            {
                var geocode = new CustomGeocodeValues
                {
                    ValueName = AreaCustomNameInput.Text,
                    Value = AreaCustomInput.Text
                };

                if (QuickSettings.Instance.AllowedCustomLocations_GeocodesList.Contains(geocode))
                {
                    var removal = MessageBox.Show("The location is already in the list. Remove it?",
                        "SharpAlert",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
                    if (removal == DialogResult.Yes) QuickSettings.Instance.AllowedCustomLocations_GeocodesList.Remove(geocode);
                    ListAreaCustomOutput.Clear();
                    foreach (var area in QuickSettings.Instance.AllowedCustomLocations_GeocodesList)
                    {
                        ListAreaCustomOutput.Text = $"ValueName: {area.ValueName}\r\n" +
                            $"Value: {area.Value}\r\n" +
                            $"---\r\n" +
                            $"{ListAreaCustomOutput.Text}";
                    }
                    AreaCustomNameInput.Clear();
                    AreaCustomInput.Clear();
                    return;
                }
                else
                {
                    QuickSettings.Instance.AllowedCustomLocations_GeocodesList.Add(geocode);
                    ListAreaCustomOutput.Clear();
                    foreach (var area in QuickSettings.Instance.AllowedCustomLocations_GeocodesList)
                    {
                        ListAreaCustomOutput.Text = $"ValueName: {area.ValueName}\r\n" +
                            $"Value: {area.Value}\r\n" +
                            $"---\r\n" +
                            $"{ListAreaCustomOutput.Text}";
                    }
                    AreaCustomNameInput.Clear();
                    AreaCustomInput.Clear();
                }
            }
            else
            {
                MessageBox.Show("Enter a ValueName and Value to add them.",
                    "SharpAlert",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        private void CustomClearButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Clear custom location data?",
                "SharpAlert",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                QuickSettings.Instance.AllowedCustomLocations_GeocodesList.Clear();
                ListAreaCustomOutput.Clear();
            }
        }

        private void SkipButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool UpDown = true;

        private void WindowShake_Tick(object sender, EventArgs e)
        {
            if (AprilFools.IsAprilFoolsNow)
            {
                if (UpDown)
                {
                    Location = new Point(Location.X, Location.Y + 10);
                }
                else
                {
                    Location = new Point(Location.X, Location.Y - 10);
                }

                UpDown = !UpDown;
            }
        }
    }
}

