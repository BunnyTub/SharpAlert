using System;
using System.Windows.Forms;

namespace SharpAlert
{
    public partial class SetupDoneForm : Form
    {
        public SetupDoneForm()
        {
            InitializeComponent();
        }

        private void DoneButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
