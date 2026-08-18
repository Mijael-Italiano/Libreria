using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.Data
{
    public class UsuarioData
    {
        public List<Usuario> ConsultarUsuarios()
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Usuarios.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Usuarios.xml no tiene una raiz valida.");

                var consulta =
                    from usuario in raiz.Elements("Usuario")
                    select new Usuario
                    {
                        Id = int.Parse(usuario.Attribute("Id")?.Value ?? throw new Exception("Hay un usuario sin Id.")),
                        Documento = int.Parse(ObtenerValor(usuario, "Documento")),
                        NombreUsuario = ObtenerValor(usuario, "NombreUsuario"),
                        Contrasena = ObtenerValor(usuario, "Contrasena"),
                        Nombre = ObtenerValor(usuario, "Nombre"),
                        Apellido = ObtenerValor(usuario, "Apellido"),
                        Mail = ObtenerValor(usuario, "Mail"),
                        Telefono = ObtenerValor(usuario, "Telefono"),
                        FechaNacimiento = DateTime.Parse(ObtenerValor(usuario, "FechaNacimiento")),
                        Direccion = ObtenerValor(usuario, "Direccion"),
                        Departamento = ObtenerValorOpcional(usuario, "Departamento"),
                        Estado = bool.Parse(ObtenerValor(usuario, "Estado")),
                        Bloqueado = bool.Parse(ObtenerValor(usuario, "Bloqueado")),
                        FechaAlta = DateTime.Parse(ObtenerValor(usuario, "FechaAlta")),
                        IntentosFallidos = int.Parse(ObtenerValor(usuario, "IntentosFallidos")),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaUsuario(Usuario usuario, int id)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Usuarios.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Usuarios.xml no tiene una raiz valida.");

                XElement nuevoUsuario = new XElement(
                    "Usuario",
                    new XAttribute("Id", id),
                    new XElement("Documento", usuario.Documento),
                    new XElement("NombreUsuario", usuario.NombreUsuario),
                    new XElement("Contrasena", usuario.Contrasena),
                    new XElement("Nombre", usuario.Nombre),
                    new XElement("Apellido", usuario.Apellido),
                    new XElement("Mail", usuario.Mail),
                    new XElement("Telefono", usuario.Telefono),
                    new XElement("FechaNacimiento", usuario.FechaNacimiento),
                    new XElement("Direccion", usuario.Direccion),
                    new XElement("Departamento", usuario.Departamento ?? string.Empty),
                    new XElement("Estado", usuario.Estado),
                    new XElement("Bloqueado", usuario.Bloqueado),
                    new XElement("FechaAlta", usuario.FechaAlta),
                    new XElement("IntentosFallidos", usuario.IntentosFallidos)
                );

                raiz.Add(nuevoUsuario);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Usuarios.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Usuarios.xml no tiene una raiz valida.");

                XElement usuarioXml = raiz.Elements("Usuario").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un usuario sin Id.")) == usuario.Id
                ) ?? throw new Exception("No se encontro el usuario indicado.");

                usuarioXml.SetElementValue("Documento", usuario.Documento);
                usuarioXml.SetElementValue("NombreUsuario", usuario.NombreUsuario);
                usuarioXml.SetElementValue("Contrasena", usuario.Contrasena);
                usuarioXml.SetElementValue("Nombre", usuario.Nombre);
                usuarioXml.SetElementValue("Apellido", usuario.Apellido);
                usuarioXml.SetElementValue("Mail", usuario.Mail);
                usuarioXml.SetElementValue("Telefono", usuario.Telefono);
                usuarioXml.SetElementValue("FechaNacimiento", usuario.FechaNacimiento);
                usuarioXml.SetElementValue("Direccion", usuario.Direccion);
                usuarioXml.SetElementValue("Departamento", usuario.Departamento ?? string.Empty);
                usuarioXml.SetElementValue("Estado", usuario.Estado);
                usuarioXml.SetElementValue("Bloqueado", usuario.Bloqueado);
                usuarioXml.SetElementValue("FechaAlta", usuario.FechaAlta);
                usuarioXml.SetElementValue("IntentosFallidos", usuario.IntentosFallidos);

                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CambiarEstadoUsuario(int id, bool estado)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Usuarios.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Usuarios.xml no tiene una raiz valida.");

                XElement usuarioXml = raiz.Elements("Usuario").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un usuario sin Id.")) == id
                ) ?? throw new Exception("No se encontro el usuario indicado.");

                usuarioXml.SetElementValue("Estado", estado);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ActualizarSeguridadAcceso(int id, int intentosFallidos, bool bloqueado)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Usuarios.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Usuarios.xml no tiene una raiz valida.");

                XElement usuarioXml = raiz.Elements("Usuario").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un usuario sin Id.")) == id
                ) ?? throw new Exception("No se encontro el usuario indicado.");

                usuarioXml.SetElementValue("IntentosFallidos", intentosFallidos);
                usuarioXml.SetElementValue("Bloqueado", bloqueado);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> BuscarUsuarios(
            string nombre,
            string apellido,
            string documento,
            bool incluirNoActivos)
        {
            try
            {
                IEnumerable<Usuario> usuarios = this.ConsultarUsuarios();

                if (!incluirNoActivos)
                {
                    usuarios = usuarios.Where(usuario => usuario.Estado);
                }

                if (!string.IsNullOrWhiteSpace(nombre))
                {
                    usuarios = usuarios.Where(usuario =>
                        usuario.Nombre.StartsWith(nombre.Trim(), StringComparison.OrdinalIgnoreCase)
                    );
                }

                if (!string.IsNullOrWhiteSpace(apellido))
                {
                    usuarios = usuarios.Where(usuario =>
                        usuario.Apellido.StartsWith(apellido.Trim(), StringComparison.OrdinalIgnoreCase)
                    );
                }

                if (!string.IsNullOrWhiteSpace(documento))
                {
                    usuarios = usuarios.Where(usuario =>
                        usuario.Documento.ToString().StartsWith(documento.Trim(), StringComparison.Ordinal)
                    );
                }

                return usuarios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ObtenerProximoId()
        {
            try
            {
                List<Usuario> usuarios = this.ConsultarUsuarios();

                if (usuarios.Count == 0)
                {
                    return 1;
                }

                return usuarios.Max(usuario => usuario.Id) + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay un usuario sin {nombre}.");
        }

        private static string? ObtenerValorOpcional(XElement elemento, string nombre)
        {
            string? valor = elemento.Element(nombre)?.Value;

            if (string.IsNullOrWhiteSpace(valor))
            {
                return null;
            }

            return valor;
        }
    }
}
