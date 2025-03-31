using SharpAlert.DisplayDialogs.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpAlert
{
    public partial class ListingForm : Form
    {
        public ListingForm()
        {
            InitializeComponent();
        }

        private void CheckAndUpdateListing_Tick(object sender, EventArgs e)
        {
            foreach (Control control in flowLayoutPanel1.Controls) control.Dispose();
            flowLayoutPanel1.Controls.Clear();
            lock (MainEntryPoint.SharpDataHistory)
            foreach (SharpDataItem item in MainEntryPoint.SharpDataHistory)
            flowLayoutPanel1.Controls.Add(new AlertInfoHolder
            {
                AlertIdentifier = item.Name
            });
        }

        private void ListingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            CheckAndUpdateListing.Stop();
            foreach (Control control in flowLayoutPanel1.Controls) control.Dispose();
            flowLayoutPanel1.Controls.Clear();
        }
    }
}
