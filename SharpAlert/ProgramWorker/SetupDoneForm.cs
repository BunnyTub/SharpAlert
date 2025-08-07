using System;
using System.Windows.Forms;

namespace SharpAlert.ProgramWorker
{
    public partial class SetupDoneForm : Form
    {
        public SetupDoneForm()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            SpeakingManager.SetupComplete();
            this.Close();
        }
    }
}

