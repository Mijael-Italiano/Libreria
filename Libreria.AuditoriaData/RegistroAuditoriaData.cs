using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.AuditoriaData.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.AuditoriaData
{
    public class RegistroAuditoriaData
    {
        private readonly UsuarioAuditoriaData usuarioAuditoriaData;
        private readonly TipoRegistroAuditoriaData tipoRegistroAuditoriaData;

        public RegistroAuditoriaData()
        {
            this.usuarioAuditoriaData = new UsuarioAuditoriaData();
            this.tipoRegistroAuditoriaData = new TipoRegistroAuditoriaData();
        }

        public List<RegistroAuditoria> ConsultarRegistrosAuditoria()
        {
            try
            {
                string ruta = RutaBaseDeDatosAuditoria.BuscarRuta("RegistrosAuditoria.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo RegistrosAuditoria.xml no tiene una raiz valida.");

                List<UsuarioAuditoria> usuariosAuditoria = this.usuarioAuditoriaData.ConsultarUsuariosAuditoria();
                List<TipoRegistroAuditoria> tiposRegistroAuditoria = this.tipoRegistroAuditoriaData.ConsultarTiposRegistroAuditoria();

                var consulta =
                    from registro in raiz.Elements("RegistroAuditoria")
                    let idUsuarioAuditoria = int.Parse(ObtenerValor(registro, "IdUsuarioAuditoria"))
                    let idTipoRegistroAuditoria = int.Parse(ObtenerValor(registro, "IdTipoRegistroAuditoria"))
                    select new RegistroAuditoria
                    {
                        Id = int.Parse(registro.Attribute("Id")?.Value ?? throw new Exception("Hay un registro de auditoria sin Id.")),
                        Fecha = DateTime.Parse(ObtenerValor(registro, "Fecha")),
                        Tipo = tiposRegistroAuditoria.FirstOrDefault(tipo => tipo.Id == idTipoRegistroAuditoria)
                            ?? throw new Exception("Hay un registro de auditoria con un tipo inexistente."),
                        UsuarioAuditoria = usuariosAuditoria.FirstOrDefault(usuario => usuario.Id == idUsuarioAuditoria)
                            ?? throw new Exception("Hay un registro de auditoria con un usuario inexistente."),
                        NombreBackUp = ObtenerValor(registro, "NombreBackUp"),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AltaRegistroAuditoria(RegistroAuditoria registroAuditoria, int id)
        {
            try
            {
                string ruta = RutaBaseDeDatosAuditoria.BuscarRuta("RegistrosAuditoria.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo RegistrosAuditoria.xml no tiene una raiz valida.");

                XElement nuevoRegistroAuditoria = new XElement(
                    "RegistroAuditoria",
                    new XAttribute("Id", id),
                    new XElement("Fecha", registroAuditoria.Fecha),
                    new XElement("IdTipoRegistroAuditoria", registroAuditoria.Tipo.Id),
                    new XElement("IdUsuarioAuditoria", registroAuditoria.UsuarioAuditoria.Id),
                    new XElement("NombreBackUp", registroAuditoria.NombreBackUp)
                );

                raiz.Add(nuevoRegistroAuditoria);
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
                List<RegistroAuditoria> registrosAuditoria = this.ConsultarRegistrosAuditoria();

                if (registrosAuditoria.Count == 0)
                {
                    return 1;
                }

                return registrosAuditoria.Max(registro => registro.Id) + 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay un registro de auditoria sin {nombre}.");
        }
    }
}
