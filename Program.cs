namespace GlucoseTaskbar
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            var nsData = new NightscoutData();
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    LogManager.Log(ex.Message);
                }
            };
            Application.ThreadException += (sender, args) =>
            {
                LogManager.Log(args.Exception.Message);
            };

            ApplicationConfiguration.Initialize();
            Application.Run(new GlucoseTaskbar());
        }
    }
}