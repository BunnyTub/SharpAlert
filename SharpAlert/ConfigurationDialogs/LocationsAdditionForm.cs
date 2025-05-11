using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using static SharpAlert.MainEntryPoint;

namespace SharpAlert
{
    public partial class LocationsAdditionForm : Form
    {
        public LocationsAdditionForm()
        {
            InitializeComponent();
        }

        public AlertDetails.SAME_StateCode SelectedState;
        public AlertDetails.SAME_CountyCode SelectedCounty;

        private void LocationsAdditionForm_Load(object sender, EventArgs e)
        {
            StateCombo.Items.AddRange(AlertDetails.States.OrderBy(x => x.Name).Select(x => x.Name).ToArray());
        }

        private void StateCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedState = AlertDetails.States.FirstOrDefault(x => x.Name == StateCombo.Text);
            if (SelectedState != null)
            {
                CountyCombo.Items.Clear();
                CountyCombo.Text = string.Empty;
                SelectedCounty = null;
                foreach (var thisCounty in
                        AlertDetails.Counties.Where(x => x.State.Id == SelectedState.Id).OrderBy(x => x.Name))
                {
                    CountyCombo.Items.Add(thisCounty.Name);
                }
            }
        }

        private void CountyCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedCounty =
                AlertDetails.Counties.FirstOrDefault(
                    x => x.State.Id == SelectedState.Id && x.Name == CountyCombo.Text);
        }

        private void SAMEAddButton_Click(object sender, EventArgs e)
        {
            if (SelectedState == null || SelectedCounty == null)
            {
                MessageBox.Show("You must select an option from both fields.", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void BusyLock_Tick(object sender, EventArgs e)
        {
            if (AlertDisplaying)
            {
                ConfigurationPanel.Visible = false;
                BusyLockText.BringToFront();
            }
            else
            {
                ConfigurationPanel.Visible = true;
                BusyLockText.SendToBack();
            }
        }
    }
}
