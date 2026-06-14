using System;
using System.Linq;
using Libreria.Data.DataComposite;

namespace Libreria.Business.BusinessComposite
{
    public class UsuarioRolBusiness
    {
        private readonly RolBusiness rolBusiness;
        private readonly UsuarioBusiness usuarioBusiness;
        private readonly UsuarioRolData usuarioRolData;

        public UsuarioRolBusiness()
        {
            this.rolBusiness = new RolBusiness();
            this.usuarioBusiness = new UsuarioBusiness();
            this.usuarioRolData = new UsuarioRolData();
        }

        public void AsociarUsuarioRol(int idUsuario, int idRol)
        {
            try
            {
                this.ValidarUsuarioYRol(idUsuario, idRol);
                this.ValidarRelacionNoExistente(idUsuario, idRol);

                this.usuarioRolData.AsociarUsuarioRol(idUsuario, idRol);
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
                this.ValidarUsuarioYRol(idUsuario, idRol);
                this.ValidarRelacionExistente(idUsuario, idRol);

                this.usuarioRolData.DesasociarUsuarioRol(idUsuario, idRol);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidarUsuarioYRol(int idUsuario, int idRol)
        {
            if (idUsuario <= 0)
            {
                throw new Exception("Debe seleccionar un usuario.");
            }

            if (idRol <= 0)
            {
                throw new Exception("Debe seleccionar un rol.");
            }

            bool existeUsuario = this.usuarioBusiness.ConsultarUsuarios().Any(usuario => usuario.Id == idUsuario);

            if (!existeUsuario)
            {
                throw new Exception("El usuario seleccionado no existe.");
            }

            bool existeRol = this.rolBusiness.ConsultarRoles().Any(rol => rol.Id == idRol);

            if (!existeRol)
            {
                throw new Exception("El rol seleccionado no existe.");
            }
        }

        private void ValidarRelacionNoExistente(int idUsuario, int idRol)
        {
            bool existeRelacion = this.usuarioRolData
                .ConsultarIdsRolesPorUsuario(idUsuario)
                .Contains(idRol);

            if (existeRelacion)
            {
                throw new Exception("El usuario ya tiene asignado ese rol.");
            }
        }

        private void ValidarRelacionExistente(int idUsuario, int idRol)
        {
            bool existeRelacion = this.usuarioRolData
                .ConsultarIdsRolesPorUsuario(idUsuario)
                .Contains(idRol);

            if (!existeRelacion)
            {
                throw new Exception("El usuario no tiene asignado ese rol.");
            }
        }
    }
}
