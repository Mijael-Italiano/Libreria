using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Libreria.AuditoriaData.BaseDeDatos;
using Libreria.Entity;

namespace Libreria.AuditoriaData
{
    public class TipoRegistroAuditoriaData
    {
        public List<TipoRegistroAuditoria> ConsultarTiposRegistroAuditoria()
        {
            try
            {
                string ruta = RutaBaseDeDatosAuditoria.BuscarRuta("TiposRegistroAuditoria.xml");

                XDocument documento = XDocument.Load(ruta);
                XElement raiz = documento.Root
                    ?? throw new Exception("El archivo TiposRegistroAuditoria.xml no tiene una raiz valida.");

                var consulta =
                    from tipo in raiz.Elements("TipoRegistroAuditoria")
                    select new TipoRegistroAuditoria
                    {
                        Id = int.Parse(tipo.Attribute("Id")?.Value ?? throw new Exception("Hay un tipo de registro de auditoria sin Id.")),
                        Nombre = ObtenerValor(tipo, "Nombre"),
                    };

                return consulta.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public TipoRegistroAuditoria ConsultarTipoRegistroAuditoriaPorId(int id)
        {
            try
            {
                return this.ConsultarTiposRegistroAuditoria().FirstOrDefault(tipo => tipo.Id == id)
                    ?? throw new Exception("No se encontro el tipo de registro de auditoria indicado.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static string ObtenerValor(XElement elemento, string nombre)
        {
            return elemento.Element(nombre)?.Value
                ?? throw new Exception($"Hay un tipo de registro de auditoria sin {nombre}.");
        }
    }
}
