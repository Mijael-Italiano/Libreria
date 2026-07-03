using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.AuditoriaData;
using Libreria.Entity;

namespace Libreria.Business
{
    public class UsuarioAuditoriaBusiness
    {
        private readonly UsuarioAuditoriaData usuarioAuditoriaData;

        public UsuarioAuditoriaBusiness()
        {
            this.usuarioAuditoriaData = new UsuarioAuditoriaData();
        }

        public void AltaUsuarioAuditoria(UsuarioAuditoria usuarioAuditoria)
        {
            try
            {
                this.Validar(usuarioAuditoria);

                bool existeUsuarioAuditoria = this.usuarioAuditoriaData.ConsultarUsuariosAuditoria().Any(usuario =>
                    this.EsMismoUsuarioAuditoria(usuario, usuarioAuditoria)
                );

                if (existeUsuarioAuditoria)
                {
                    throw new Exception("Ya existe un usuario de auditoria con el DNI, nombre y apellido indicados.");
                }

                int id = this.usuarioAuditoriaData.ObtenerProximoId();
                usuarioAuditoria.Nombre = usuarioAuditoria.Nombre.Trim();
                usuarioAuditoria.Apellido = usuarioAuditoria.Apellido.Trim();
                this.usuarioAuditoriaData.AltaUsuarioAuditoria(usuarioAuditoria, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<UsuarioAuditoria> ConsultarUsuariosAuditoria()
        {
            try
            {
                return this.usuarioAuditoriaData.ConsultarUsuariosAuditoria();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public UsuarioAuditoria ObtenerOCrearUsuarioAuditoria(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                {
                    throw new Exception("Debe informar un usuario.");
                }

                UsuarioAuditoria usuarioAuditoriaBuscado = new UsuarioAuditoria(
                    usuario.Nombre,
                    usuario.Apellido,
                    usuario.Documento
                );

                UsuarioAuditoria? usuarioAuditoriaExistente = this.usuarioAuditoriaData
                    .ConsultarUsuariosAuditoria()
                    .FirstOrDefault(usuarioAuditoria => this.EsMismoUsuarioAuditoria(usuarioAuditoria, usuarioAuditoriaBuscado));

                if (usuarioAuditoriaExistente != null)
                {
                    return usuarioAuditoriaExistente;
                }

                this.AltaUsuarioAuditoria(usuarioAuditoriaBuscado);

                return this.usuarioAuditoriaData
                    .ConsultarUsuariosAuditoria()
                    .First(usuarioAuditoria => this.EsMismoUsuarioAuditoria(usuarioAuditoria, usuarioAuditoriaBuscado));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarUsuarioAuditoria(UsuarioAuditoria usuarioAuditoria)
        {
            try
            {
                if (usuarioAuditoria.Id <= 0)
                {
                    throw new Exception("Debe seleccionar un usuario de auditoria.");
                }

                this.Validar(usuarioAuditoria);

                UsuarioAuditoria usuarioActual = this.usuarioAuditoriaData
                    .ConsultarUsuariosAuditoria()
                    .FirstOrDefault(usuario => usuario.Id == usuarioAuditoria.Id)
                    ?? throw new Exception("El usuario de auditoria seleccionado no existe.");

                bool existeUsuarioAuditoria = this.usuarioAuditoriaData.ConsultarUsuariosAuditoria().Any(usuario =>
                    usuario.Id != usuarioAuditoria.Id && this.EsMismoUsuarioAuditoria(usuario, usuarioAuditoria)
                );

                if (existeUsuarioAuditoria)
                {
                    throw new Exception("Ya existe otro usuario de auditoria con el DNI, nombre y apellido indicados.");
                }

                if (!this.UsuarioTieneCambios(usuarioActual, usuarioAuditoria))
                {
                    throw new Exception("No se modifico ningun dato.");
                }

                usuarioAuditoria.Nombre = usuarioAuditoria.Nombre.Trim();
                usuarioAuditoria.Apellido = usuarioAuditoria.Apellido.Trim();
                this.usuarioAuditoriaData.ModificarUsuarioAuditoria(usuarioAuditoria);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool UsuarioTieneCambios(UsuarioAuditoria usuarioActual, UsuarioAuditoria usuarioModificado)
        {
            return !usuarioActual.Nombre.Equals(usuarioModificado.Nombre.Trim(), StringComparison.Ordinal)
                || !usuarioActual.Apellido.Equals(usuarioModificado.Apellido.Trim(), StringComparison.Ordinal)
                || usuarioActual.Dni != usuarioModificado.Dni;
        }

        private bool EsMismoUsuarioAuditoria(UsuarioAuditoria usuario, UsuarioAuditoria otroUsuario)
        {
            return usuario.Dni == otroUsuario.Dni
                && usuario.Nombre.Equals(otroUsuario.Nombre.Trim(), StringComparison.OrdinalIgnoreCase)
                && usuario.Apellido.Equals(otroUsuario.Apellido.Trim(), StringComparison.OrdinalIgnoreCase);
        }

        private void Validar(UsuarioAuditoria usuarioAuditoria)
        {
            if (usuarioAuditoria == null)
            {
                throw new Exception("Debe informar un usuario de auditoria.");
            }

            if (string.IsNullOrWhiteSpace(usuarioAuditoria.Nombre))
            {
                throw new Exception("Debe ingresar el nombre del usuario de auditoria.");
            }

            if (string.IsNullOrWhiteSpace(usuarioAuditoria.Apellido))
            {
                throw new Exception("Debe ingresar el apellido del usuario de auditoria.");
            }

            if (usuarioAuditoria.Dni <= 0)
            {
                throw new Exception("Debe ingresar un DNI valido.");
            }
        }
    }
}
