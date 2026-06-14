using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;

namespace Libreria.Data.DataComposite
{
    public class RolPermisoData
    {
        public void AsociarRolPermiso(int idRol, int idPermiso)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("RolesPermisos.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo RolesPermisos.xml no tiene una raiz valida.");

                XElement nuevaRelacion = new XElement(
                    "RolPermiso",
                    new XAttribute("IdRol", idRol),
                    new XAttribute("IdPermiso", idPermiso)
                );

                raiz.Add(nuevaRelacion);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DesasociarRolPermiso(int idRol, int idPermiso)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("RolesPermisos.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo RolesPermisos.xml no tiene una raiz valida.");

                XElement? relacion = raiz.Elements("RolPermiso").FirstOrDefault(rolPermiso =>
                    int.Parse(rolPermiso.Attribute("IdRol")?.Value ?? throw new Exception("Hay una relacion rol-permiso sin IdRol.")) == idRol
                    && int.Parse(rolPermiso.Attribute("IdPermiso")?.Value ?? throw new Exception("Hay una relacion rol-permiso sin IdPermiso.")) == idPermiso
                );

                relacion?.Remove();
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<int> ConsultarIdsPermisosPorRol(int idRol)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("RolesPermisos.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo RolesPermisos.xml no tiene una raiz valida.");

                var consulta =
                    from rolPermiso in raiz.Elements("RolPermiso")
                    where int.Parse(rolPermiso.Attribute("IdRol")?.Value ?? throw new Exception("Hay una relacion rol-permiso sin IdRol.")) == idRol
                    select int.Parse(rolPermiso.Attribute("IdPermiso")?.Value ?? throw new Exception("Hay una relacion rol-permiso sin IdPermiso."));

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
