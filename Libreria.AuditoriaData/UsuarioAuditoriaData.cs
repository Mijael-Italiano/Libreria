using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.AuditoriaData.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.AuditoriaData
{
    public class UsuarioAuditoriaData
    {
        public List<UsuarioAuditoria> ConsultarUsuariosAuditoria()
        {
            try
            {
                string ruta = RutaBaseDeDatosAuditoria.BuscarRuta("UsuariosAuditoria.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo UsuariosAuditoria.xml no tiene una raiz valida.");

                var consulta =
                    from usuario in raiz.Elements("UsuarioAuditoria")
                    select new UsuarioAuditoria
                    {
                        Id = int.Parse(usuario.Attribute("Id")?.Value ?? throw new Exception("Hay un usuario de auditoria sin Id.")),
                        Nombre = ObtenerValor(usuario, "Nombre"),
                        Apellido = ObtenerValor(usuario, "Apellido"),
                        Dni = int.Parse(ObtenerValor(usuario, "Dni")),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaUsuarioAuditoria(UsuarioAuditoria usuarioAuditoria, int id)
        {
            try
            {
                string ruta = RutaBaseDeDatosAuditoria.BuscarRuta("UsuariosAuditoria.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo UsuariosAuditoria.xml no tiene una raiz valida.");

                XElement nuevoUsuarioAuditoria = new XElement(
                    "UsuarioAuditoria",
                    new XAttribute("Id", id),
                    new XElement("Nombre", usuarioAuditoria.Nombre),
                    new XElement("Apellido", usuarioAuditoria.Apellido),
                    new XElement("Dni", usuarioAuditoria.Dni)
                );

                raiz.Add(nuevoUsuarioAuditoria);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarUsuarioAuditoria(UsuarioAuditoria usuarioAuditoria)
        {
            try
            {
                string ruta = RutaBaseDeDatosAuditoria.BuscarRuta("UsuariosAuditoria.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo UsuariosAuditoria.xml no tiene una raiz valida.");

                XElement usuarioXml = raiz.Elements("UsuarioAuditoria").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un usuario de auditoria sin Id.")) == usuarioAuditoria.Id
                ) ?? throw new Exception("No se encontro el usuario de auditoria indicado.");

                usuarioXml.SetElementValue("Nombre", usuarioAuditoria.Nombre);
                usuarioXml.SetElementValue("Apellido", usuarioAuditoria.Apellido);
                usuarioXml.SetElementValue("Dni", usuarioAuditoria.Dni);

                documento.Save(ruta);
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
                List<UsuarioAuditoria> usuariosAuditoria = this.ConsultarUsuariosAuditoria();

                if (usuariosAuditoria.Count == 0)
                {
                    return 1;
                }

                return usuariosAuditoria.Max(usuario => usuario.Id) + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay un usuario de auditoria sin {nombre}.");
        }
    }
}
