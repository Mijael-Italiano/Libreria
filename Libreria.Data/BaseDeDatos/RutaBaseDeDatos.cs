using System;
using System.IO;

namespace Libreria.Data.BaseDeDatos
{
    internal static class RutaBaseDeDatos
    {
        public static string BuscarRuta(string nombreArchivo)
        {
            string carpetaBaseDeDatos = Path.Combine(
                AppContext.BaseDirectory,
                "BaseDeDatos"
            );

            AsegurarBaseDeDatos(carpetaBaseDeDatos);

            return Path.Combine(carpetaBaseDeDatos, nombreArchivo);
        }

        private static void AsegurarBaseDeDatos(string carpetaBaseDeDatos)
        {
            Directory.CreateDirectory(carpetaBaseDeDatos);
            CrearUsuariosIniciales(carpetaBaseDeDatos);
            CrearRolesIniciales(carpetaBaseDeDatos);
            CrearPermisosIniciales(carpetaBaseDeDatos);
        }

        private static void CrearUsuariosIniciales(string carpetaBaseDeDatos)
        {
            string rutaUsuarios = Path.Combine(carpetaBaseDeDatos, "Usuarios.xml");

            if (File.Exists(rutaUsuarios))
            {
                return;
            }

            File.WriteAllText(
                rutaUsuarios,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <Usuarios>
                  <Usuario Id="1">
                    <Documento>1</Documento>
                    <NombreUsuario>Admin</NombreUsuario>
                    <Contrasena>MQAyADMANAA=</Contrasena>
                    <Nombre>Administrador</Nombre>
                    <Apellido>Sistema</Apellido>
                    <Mail>admin@libreria.local</Mail>
                    <Telefono>0000000000</Telefono>
                    <FechaNacimiento>2000-01-01</FechaNacimiento>
                    <Direccion>Sistema</Direccion>
                    <Departamento></Departamento>
                    <Estado>true</Estado>
                    <Bloqueado>false</Bloqueado>
                    <FechaAlta>2026-06-12T00:00:00</FechaAlta>
                    <IntentosFallidos>0</IntentosFallidos>
                  </Usuario>
                </Usuarios>
                """
            );
        }

        private static void CrearRolesIniciales(string carpetaBaseDeDatos)
        {
            string rutaRoles = Path.Combine(carpetaBaseDeDatos, "Roles.xml");

            if (File.Exists(rutaRoles))
            {
                return;
            }

            File.WriteAllText(
                rutaRoles,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <Roles>
                </Roles>
                """
            );
        }

        private static void CrearPermisosIniciales(string carpetaBaseDeDatos)
        {
            string rutaPermisos = Path.Combine(carpetaBaseDeDatos, "Permisos.xml");

            if (File.Exists(rutaPermisos))
            {
                return;
            }

            File.WriteAllText(
                rutaPermisos,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <Permisos>
                  <Permiso Id="1">
                    <Nombre>Inicio</Nombre>
                  </Permiso>
                  <Permiso Id="2">
                    <Nombre>ABM usuarios</Nombre>
                  </Permiso>
                  <Permiso Id="3">
                    <Nombre>Gestion de roles y permisos</Nombre>
                  </Permiso>
                </Permisos>
                """
            );
        }
    }
}
