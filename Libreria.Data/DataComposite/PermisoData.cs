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
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo Permisos.xml no tiene una raiz valida.");

                var consulta =
                    from permiso in raiz.Elements("Permiso")
                    select new Permiso(
                        int.Parse(permiso.Attribute("Id")?.Value ?? throw new Exception("Hay un permiso sin Id.")),
                        permiso.Element("Nombre")?.Value ?? throw new Exception("Hay un permiso sin nombre.")
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
