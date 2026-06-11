using System;
using System.Collections.Generic;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;
using Libreria.Entity.EntityComposite;

namespace Libreria.Data.DataComposite
{
    public class PermisoData
    {
        public List<Permiso> ConsultarPermisos()
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("Permisos.xml");

                XDocument documento = XDocument.Load(ruta);

                var consulta =
                    from permiso in documento.Root.Elements("Permiso")
                    select new Permiso(
                        int.Parse(permiso.Attribute("Id").Value),
                        permiso.Element("Nombre").Value
                    );

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
