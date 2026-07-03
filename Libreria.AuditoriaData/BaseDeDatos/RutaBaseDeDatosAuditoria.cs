using System;
using System.IO;

namespace Libreria.AuditoriaData.BaseDeDatos
{
    public static class RutaBaseDeDatosAuditoria
    {
        public static string BuscarRuta(string nombreArchivo)
        {
            string carpetaBaseDeDatos = ObtenerCarpetaBaseDeDatos();
            AsegurarEstructura();

            return Path.Combine(carpetaBaseDeDatos, nombreArchivo);
        }

        public static string ObtenerCarpetaBackUps()
        {
            string carpetaBackUps = Path.Combine(
                AppContext.BaseDirectory,
                "Auditoria",
                "BackUps"
            );

            AsegurarEstructura();

            return carpetaBackUps;
        }

        private static string ObtenerCarpetaBaseDeDatos()
        {
            return Path.Combine(
                AppContext.BaseDirectory,
                "Auditoria",
                "BaseDeDatos"
            );
        }

        private static void AsegurarEstructura()
        {
            string carpetaAuditoria = Path.Combine(AppContext.BaseDirectory, "Auditoria");
            string carpetaBaseDeDatos = ObtenerCarpetaBaseDeDatos();
            string carpetaBackUps = Path.Combine(carpetaAuditoria, "BackUps");

            Directory.CreateDirectory(carpetaAuditoria);
            Directory.CreateDirectory(carpetaBaseDeDatos);
            Directory.CreateDirectory(carpetaBackUps);
            CrearUsuariosAuditoriaIniciales(carpetaBaseDeDatos);
            CrearTiposRegistroAuditoriaIniciales(carpetaBaseDeDatos);
            CrearRegistrosAuditoriaIniciales(carpetaBaseDeDatos);
        }

        private static void CrearUsuariosAuditoriaIniciales(string carpetaBaseDeDatos)
        {
            string rutaUsuariosAuditoria = Path.Combine(carpetaBaseDeDatos, "UsuariosAuditoria.xml");

            if (File.Exists(rutaUsuariosAuditoria))
            {
                return;
            }

            File.WriteAllText(
                rutaUsuariosAuditoria,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <UsuariosAuditoria>
                </UsuariosAuditoria>
                """
            );
        }

        private static void CrearTiposRegistroAuditoriaIniciales(string carpetaBaseDeDatos)
        {
            string rutaTiposRegistroAuditoria = Path.Combine(carpetaBaseDeDatos, "TiposRegistroAuditoria.xml");

            if (File.Exists(rutaTiposRegistroAuditoria))
            {
                return;
            }

            File.WriteAllText(
                rutaTiposRegistroAuditoria,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <TiposRegistroAuditoria>
                  <TipoRegistroAuditoria Id="1">
                    <Nombre>BackUp</Nombre>
                  </TipoRegistroAuditoria>
                  <TipoRegistroAuditoria Id="2">
                    <Nombre>Restore</Nombre>
                  </TipoRegistroAuditoria>
                </TiposRegistroAuditoria>
                """
            );
        }

        private static void CrearRegistrosAuditoriaIniciales(string carpetaBaseDeDatos)
        {
            string rutaRegistrosAuditoria = Path.Combine(carpetaBaseDeDatos, "RegistrosAuditoria.xml");

            if (File.Exists(rutaRegistrosAuditoria))
            {
                return;
            }

            File.WriteAllText(
                rutaRegistrosAuditoria,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <RegistrosAuditoria>
                </RegistrosAuditoria>
                """
            );
        }
    }
}

