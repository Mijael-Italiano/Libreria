using System;
using System.IO;

namespace Libreria.Data.BaseDeDatos
{
    internal static class RutaBaseDeDatos
    {
        public static string BuscarRuta(string nombreArchivo)
        {
            return Path.Combine(
                AppDomain.CurrentDomain.BaseDirectory,
                "BaseDeDatos",
                nombreArchivo
            );
        }
    }
}
