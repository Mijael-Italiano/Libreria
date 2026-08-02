using System.Globalization;

namespace Libreria.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            CultureInfo cultura = new CultureInfo("es-AR");
            Thread.CurrentThread.CurrentCulture = cultura;
            Thread.CurrentThread.CurrentUICulture = cultura;
            ApplicationConfiguration.Initialize();
            Application.Run(new FormIniciarSesion());
        }
    }
}