using System;
using System.Collections.Generic;
using Libreria.AuditoriaData;
using Libreria.Entity;

namespace Libreria.Business
{
    public class TipoRegistroAuditoriaBusiness
    {
        private readonly TipoRegistroAuditoriaData tipoRegistroAuditoriaData;

        public TipoRegistroAuditoriaBusiness()
        {
            this.tipoRegistroAuditoriaData = new TipoRegistroAuditoriaData();
        }

        public List<TipoRegistroAuditoria> ConsultarTiposRegistroAuditoria()
        {
            try
            {
                return this.tipoRegistroAuditoriaData.ConsultarTiposRegistroAuditoria();
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
                if (id <= 0)
                {
                    throw new Exception("Debe informar un tipo de registro de auditoria valido.");
                }

                return this.tipoRegistroAuditoriaData.ConsultarTipoRegistroAuditoriaPorId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
