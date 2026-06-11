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

                var consulta =
                    from rol in documento.Root.Elements("Rol")
                    select new Rol(
                        int.Parse(rol.Attribute("Id").Value),
                        rol.Element("Nombre").Value
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

                XElement nuevoRol = new XElement(
                    "Rol",
                    new XAttribute("Id", rol.Id),
                    new XElement("Nombre", rol.Nombre)
                );

                documento.Root.Add(nuevoRol);
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
