using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.AuditoriaData;
using Libreria.Entity;

namespace Libreria.Business
{
    public class RegistroAuditoriaBusiness
    {
        private readonly RegistroAuditoriaData registroAuditoriaData;
        private readonly UsuarioAuditoriaData usuarioAuditoriaData;
        private readonly TipoRegistroAuditoriaData tipoRegistroAuditoriaData;

        public RegistroAuditoriaBusiness()
        {
            this.registroAuditoriaData = new RegistroAuditoriaData();
            this.usuarioAuditoriaData = new UsuarioAuditoriaData();
            this.tipoRegistroAuditoriaData = new TipoRegistroAuditoriaData();
        }

        public void AltaRegistroAuditoria(RegistroAuditoria registroAuditoria)
        {
            try
            {
                this.Validar(registroAuditoria);

                int id = this.registroAuditoriaData.ObtenerProximoId();
                registroAuditoria.Fecha = DateTime.Now;
                registroAuditoria.NombreBackUp = registroAuditoria.NombreBackUp.Trim();
                this.registroAuditoriaData.AltaRegistroAuditoria(registroAuditoria, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<RegistroAuditoria> ConsultarRegistrosAuditoria()
        {
            try
            {
                return this.registroAuditoriaData.ConsultarRegistrosAuditoria();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Validar(RegistroAuditoria registroAuditoria)
        {
            if (registroAuditoria == null)
            {
                throw new Exception("Debe informar un registro de auditoria.");
            }

            if (registroAuditoria.Tipo == null || registroAuditoria.Tipo.Id <= 0)
            {
                throw new Exception("Debe informar un tipo de registro de auditoria.");
            }

            bool existeTipo = this.tipoRegistroAuditoriaData.ConsultarTiposRegistroAuditoria().Any(tipo =>
                tipo.Id == registroAuditoria.Tipo.Id
            );

            if (!existeTipo)
            {
                throw new Exception("El tipo de registro de auditoria indicado no existe.");
            }

            if (registroAuditoria.UsuarioAuditoria == null || registroAuditoria.UsuarioAuditoria.Id <= 0)
            {
                throw new Exception("Debe informar un usuario de auditoria.");
            }

            bool existeUsuario = this.usuarioAuditoriaData.ConsultarUsuariosAuditoria().Any(usuario =>
                usuario.Id == registroAuditoria.UsuarioAuditoria.Id
            );

            if (!existeUsuario)
            {
                throw new Exception("El usuario de auditoria indicado no existe.");
            }

            if (string.IsNullOrWhiteSpace(registroAuditoria.NombreBackUp))
            {
                throw new Exception("Debe informar el nombre del back up.");
            }
        }
    }
}
