using System;
using System.Windows.Forms;

namespace SHInstaller
{
    internal static class Program
    {
        // MAKE SURE TO "PUBLISH" SHARPALERT BEFORE BUILDING

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
