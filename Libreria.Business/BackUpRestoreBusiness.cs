using System;
using System.Collections.Generic;
using Libreria.AuditoriaData;
using Libreria.Entity;

namespace Libreria.Business
{
    public class BackUpRestoreBusiness
    {
        private const int IdTipoBackUp = 1;
        private const int IdTipoRestore = 2;

        private readonly BackUpRestoreData backUpRestoreData;
        private readonly UsuarioAuditoriaBusiness usuarioAuditoriaBusiness;
        private readonly TipoRegistroAuditoriaBusiness tipoRegistroAuditoriaBusiness;
        private readonly RegistroAuditoriaBusiness registroAuditoriaBusiness;

        public BackUpRestoreBusiness()
        {
            this.backUpRestoreData = new BackUpRestoreData();
            this.usuarioAuditoriaBusiness = new UsuarioAuditoriaBusiness();
            this.tipoRegistroAuditoriaBusiness = new TipoRegistroAuditoriaBusiness();
            this.registroAuditoriaBusiness = new RegistroAuditoriaBusiness();
        }

        public string CrearBackUp(Usuario usuario)
        {
            try
            {
                this.ValidarUsuario(usuario);

                string nombreBackUp = this.backUpRestoreData.CrearBackUp();
                this.RegistrarAuditoria(usuario, IdTipoBackUp, nombreBackUp);

                return nombreBackUp;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RestaurarBackUp(string nombreBackUp, Usuario usuario)
        {
            try
            {
                this.ValidarUsuario(usuario);

                if (string.IsNullOrWhiteSpace(nombreBackUp))
                {
                    throw new Exception("Debe seleccionar un back up.");
                }

                nombreBackUp = nombreBackUp.Trim();
                this.backUpRestoreData.RestaurarBackUp(nombreBackUp);
                this.RegistrarAuditoria(usuario, IdTipoRestore, nombreBackUp);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<string> ListarBackUps()
        {
            try
            {
                return this.backUpRestoreData.ListarBackUps();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void RegistrarAuditoria(Usuario usuario, int idTipo, string nombreBackUp)
        {
            UsuarioAuditoria usuarioAuditoria = this.usuarioAuditoriaBusiness.ObtenerOCrearUsuarioAuditoria(usuario);
            TipoRegistroAuditoria tipo = this.tipoRegistroAuditoriaBusiness.ConsultarTipoRegistroAuditoriaPorId(idTipo);

            RegistroAuditoria registroAuditoria = new RegistroAuditoria(
                tipo,
                usuarioAuditoria,
                nombreBackUp
            );

            this.registroAuditoriaBusiness.AltaRegistroAuditoria(registroAuditoria);
        }

        private void ValidarUsuario(Usuario usuario)
        {
            if (usuario == null || usuario.Id <= 0)
            {
                throw new Exception("Debe existir un usuario logueado.");
            }
        }
    }
}
