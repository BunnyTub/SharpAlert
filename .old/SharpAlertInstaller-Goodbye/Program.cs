namespace SharpAlertInstaller_Goodbye
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            UninstallingForm uf = new();
            Application.Run(uf);
            uf.Dispose();
        }
    }
}