using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;
using Libreria.Entity.EntityComposite;

namespace Libreria.Data.DataComposite
{
    public class RolData
    {
        public List<Rol> ConsultarRoles()
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Roles.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Roles.xml no tiene una raiz valida.");

                var consulta =
                    from rol in raiz.Elements("Rol")
                    select new Rol(
                        int.Parse(rol.Attribute("Id")?.Value ?? throw new Exception("Hay un rol sin Id.")),
                        rol.Element("Nombre")?.Value ?? throw new Exception("Hay un rol sin nombre.")
                    );

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaRol(Rol rol)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Roles.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Roles.xml no tiene una raiz valida.");

                XElement nuevoRol = new XElement(
                    "Rol",
                    new XAttribute("Id", rol.Id),
                    new XElement("Nombre", rol.Nombre)
                );

                raiz.Add(nuevoRol);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarRol(Rol rol)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Roles.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Roles.xml no tiene una raiz valida.");

                XElement rolXml = raiz.Elements("Rol").FirstOrDefault(elemento =>
                    int.Parse(elemento.Attribute("Id")?.Value ?? throw new Exception("Hay un rol sin Id.")) == rol.Id
                ) ?? throw new Exception("No se encontro el rol indicado.");

                rolXml.SetElementValue("Nombre", rol.Nombre);
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
                List<Rol> roles = this.ConsultarRoles();

                if (roles.Count == 0)
                {
                    return 1;
                }

                return roles.Max(rol => rol.Id) + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
