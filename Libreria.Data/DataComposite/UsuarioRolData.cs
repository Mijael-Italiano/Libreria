using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.Data.BaseDeDatos;

namespace Libreria.Data.DataComposite
{
    public class UsuarioRolData
    {
        public void AsociarUsuarioRol(int idUsuario, int idRol)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("UsuariosRoles.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo UsuariosRoles.xml no tiene una raiz valida.");

                XElement nuevaRelacion = new XElement(
                    "UsuarioRol",
                    new XAttribute("IdUsuario", idUsuario),
                    new XAttribute("IdRol", idRol)
                );

                raiz.Add(nuevaRelacion);
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DesasociarUsuarioRol(int idUsuario, int idRol)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("UsuariosRoles.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo UsuariosRoles.xml no tiene una raiz valida.");

                XElement? relacion = raiz.Elements("UsuarioRol").FirstOrDefault(usuarioRol =>
                    int.Parse(usuarioRol.Attribute("IdUsuario")?.Value ?? throw new Exception("Hay una relacion usuario-rol sin IdUsuario.")) == idUsuario
                    && int.Parse(usuarioRol.Attribute("IdRol")?.Value ?? throw new Exception("Hay una relacion usuario-rol sin IdRol.")) == idRol
                );

                relacion?.Remove();
                documento.Save(ruta);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<int> ConsultarIdsRolesPorUsuario(int idUsuario)
        {
            try
            {
                string ruta = RutaBaseDeDatos.BuscarRuta("UsuariosRoles.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo UsuariosRoles.xml no tiene una raiz valida.");

                var consulta =
                    from usuarioRol in raiz.Elements("UsuarioRol")
                    where int.Parse(usuarioRol.Attribute("IdUsuario")?.Value ?? throw new Exception("Hay una relacion usuario-rol sin IdUsuario.")) == idUsuario
                    select int.Parse(usuarioRol.Attribute("IdRol")?.Value ?? throw new Exception("Hay una relacion usuario-rol sin IdRol."));

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
