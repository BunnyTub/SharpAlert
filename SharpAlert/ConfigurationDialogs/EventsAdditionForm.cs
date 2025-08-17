using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using SharpAlert.AlertComponents;
using static SharpAlert.ProgramWorker.MainEntryPoint;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class EventsAdditionForm : Form
    {
        public EventsAdditionForm()
        {
            InitializeComponent();
        }

        public AlertDetails.SAME_EventCode SelectedEvent;

        private bool Initialized = false;

        private void LocationsAdditionForm_Load(object sender, EventArgs e)
        {
            if (Initialized) return;
            Initialized = true;
            EventCombo.Items.AddRange(AlertDetails.AlertCodes.OrderBy(x => x.Name).Select(x => x.Name).ToArray());
        }

        private void StateCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedEvent = AlertDetails.AlertCodes.FirstOrDefault(x => x.Name == EventCombo.Text);
        }

        private void SAMEAddButton_Click(object sender, EventArgs e)
        {
            if (SelectedEvent == null)
            {
                MessageBox.Show("You must select an option from the field.", "SharpAlert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

