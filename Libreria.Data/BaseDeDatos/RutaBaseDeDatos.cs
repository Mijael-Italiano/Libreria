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
            CrearRolesPermisosIniciales(carpetaBaseDeDatos);
            CrearUsuariosRolesIniciales(carpetaBaseDeDatos);
            CrearMarcasIniciales(carpetaBaseDeDatos);
            CrearCategoriasIniciales(carpetaBaseDeDatos);
            CrearColoresIniciales(carpetaBaseDeDatos);
            CrearProductosIniciales(carpetaBaseDeDatos);
            CrearMediosPagoIniciales(carpetaBaseDeDatos);
            CrearFacturasIniciales(carpetaBaseDeDatos);
            CrearFacturaItemsIniciales(carpetaBaseDeDatos);
            CrearFacturasMediosPagoIniciales(carpetaBaseDeDatos);
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
                  <Rol Id="1">
                    <Nombre>Admin</Nombre>
                  </Rol>
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
                  <Permiso Id="4">
                    <Nombre>Ver inventario</Nombre>
                  </Permiso>
                  <Permiso Id="5">
                    <Nombre>Administrar productos</Nombre>
                  </Permiso>
                  <Permiso Id="6">
                    <Nombre>Administrar clientes</Nombre>
                  </Permiso>
                  <Permiso Id="7">
                    <Nombre>Gestion de ventas</Nombre>
                  </Permiso>
                  <Permiso Id="8">
                    <Nombre>Administrar metodos de pago</Nombre>
                  </Permiso>
                  <Permiso Id="9">
                    <Nombre>Gestion de base de datos</Nombre>
                  </Permiso>
                  <Permiso Id="10">
                    <Nombre>Analisis de ventas</Nombre>
                  </Permiso>
                </Permisos>
                """
            );
        }

        private static void CrearRolesPermisosIniciales(string carpetaBaseDeDatos)
        {
            string rutaRolesPermisos = Path.Combine(carpetaBaseDeDatos, "RolesPermisos.xml");

            if (File.Exists(rutaRolesPermisos))
            {
                return;
            }

            File.WriteAllText(
                rutaRolesPermisos,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <RolesPermisos>
                  <RolPermiso IdRol="1" IdPermiso="1" />
                  <RolPermiso IdRol="1" IdPermiso="2" />
                  <RolPermiso IdRol="1" IdPermiso="3" />
                  <RolPermiso IdRol="1" IdPermiso="4" />
                  <RolPermiso IdRol="1" IdPermiso="5" />
                  <RolPermiso IdRol="1" IdPermiso="6" />
                  <RolPermiso IdRol="1" IdPermiso="7" />
                  <RolPermiso IdRol="1" IdPermiso="8" />
                  <RolPermiso IdRol="1" IdPermiso="9" />
                  <RolPermiso IdRol="1" IdPermiso="10" />
                </RolesPermisos>
                """
            );
        }

        private static void CrearUsuariosRolesIniciales(string carpetaBaseDeDatos)
        {
            string rutaUsuariosRoles = Path.Combine(carpetaBaseDeDatos, "UsuariosRoles.xml");

            if (File.Exists(rutaUsuariosRoles))
            {
                return;
            }

            File.WriteAllText(
                rutaUsuariosRoles,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <UsuariosRoles>
                  <UsuarioRol IdUsuario="1" IdRol="1" />
                </UsuariosRoles>
                """
            );
        }

        private static void CrearMarcasIniciales(string carpetaBaseDeDatos)
        {
            string rutaMarcas = Path.Combine(carpetaBaseDeDatos, "Marcas.xml");

            if (File.Exists(rutaMarcas))
            {
                return;
            }

            File.WriteAllText(
                rutaMarcas,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <Marcas>
                </Marcas>
                """
            );
        }

        private static void CrearCategoriasIniciales(string carpetaBaseDeDatos)
        {
            string rutaCategorias = Path.Combine(carpetaBaseDeDatos, "Categorias.xml");

            if (File.Exists(rutaCategorias))
            {
                return;
            }

            File.WriteAllText(
                rutaCategorias,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <Categorias>
                </Categorias>
                """
            );
        }

        private static void CrearColoresIniciales(string carpetaBaseDeDatos)
        {
            string rutaColores = Path.Combine(carpetaBaseDeDatos, "Colores.xml");

            if (File.Exists(rutaColores))
            {
                return;
            }

            File.WriteAllText(
                rutaColores,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <Colores>
                </Colores>
                """
            );
        }

        private static void CrearProductosIniciales(string carpetaBaseDeDatos)
        {
            string rutaProductos = Path.Combine(carpetaBaseDeDatos, "Productos.xml");

            if (File.Exists(rutaProductos))
            {
                return;
            }

            File.WriteAllText(
                rutaProductos,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <Productos>
                </Productos>
                """
            );
        }

        private static void CrearMediosPagoIniciales(string carpetaBaseDeDatos)
        {
            string rutaMediosPago = Path.Combine(carpetaBaseDeDatos, "MediosPago.xml");

            if (File.Exists(rutaMediosPago))
            {
                return;
            }

            File.WriteAllText(
                rutaMediosPago,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <MediosPago>
                </MediosPago>
                """
            );
        }

        private static void CrearFacturasIniciales(string carpetaBaseDeDatos)
        {
            string rutaFacturas = Path.Combine(carpetaBaseDeDatos, "Facturas.xml");

            if (File.Exists(rutaFacturas))
            {
                return;
            }

            File.WriteAllText(
                rutaFacturas,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <Facturas>
                </Facturas>
                """
            );
        }

        private static void CrearFacturaItemsIniciales(string carpetaBaseDeDatos)
        {
            string rutaFacturaItems = Path.Combine(carpetaBaseDeDatos, "FacturaItems.xml");

            if (File.Exists(rutaFacturaItems))
            {
                return;
            }

            File.WriteAllText(
                rutaFacturaItems,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <FacturaItems>
                </FacturaItems>
                """
            );
        }

        private static void CrearFacturasMediosPagoIniciales(string carpetaBaseDeDatos)
        {
            string rutaFacturasMediosPago = Path.Combine(carpetaBaseDeDatos, "FacturasMediosPago.xml");

            if (File.Exists(rutaFacturasMediosPago))
            {
                return;
            }

            File.WriteAllText(
                rutaFacturasMediosPago,
                """
                <?xml version="1.0" encoding="utf-8"?>
                <FacturasMediosPago>
                </FacturasMediosPago>
                """
            );
        }
    }
}
