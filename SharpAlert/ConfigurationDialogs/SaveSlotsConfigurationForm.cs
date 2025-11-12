using SharpAlert.ProgramWorker;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace SharpAlert.ConfigurationDialogs
{
    public partial class SaveSlotsConfigurationForm : Form
    {
        public SaveSlotsConfigurationForm()
        {
            InitializeComponent();
        }

        private void LoadSaveSlot(int SlotNumber)
        {
            if (MessageBox.Show("Switch to this save slot?\r\nThe program will use the save slot settings.\r\n\r\n" +
                "(ALL settings are per save slot, there aren't any global settings!)", Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                List<string> args = [.. MainEntryPoint.Args];
                args.Add($"--set{SlotNumber}");
                args.Add($"--wait-until-parent-closes");
                Process.Start(MainEntryPoint.AssemblyFile, args);
                Environment.Exit(0);
            }
        }

        private void OneButton_Click(object sender, EventArgs e)
        {
            LoadSaveSlot(1);
        }

        private void TwoButton_Click(object sender, EventArgs e)
        {
            LoadSaveSlot(2);
        }

        private void ThreeButton_Click(object sender, EventArgs e)
        {
            LoadSaveSlot(3);
        }

        private void FourButton_Click(object sender, EventArgs e)
        {
            LoadSaveSlot(4);
        }

        private void FiveButton_Click(object sender, EventArgs e)
        {
            LoadSaveSlot(5);
        }

        private void DefaultButton_Click(object sender, EventArgs e)
        {
            LoadSaveSlot(0);
        }

        private void CheckTimer_Tick(object sender, EventArgs e)
        {
            TitleText.Text = $"You are currently using save slot {QuickSettings.CurrentSaveSlot}. (0 = Primary)";
        }
    }
}
