using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Data;
using Libreria.Entity;
using Libreria.Seguridad;

namespace Libreria.Business
{
    public class UsuarioBusiness
    {
        private readonly UsuarioData usuarioData;

        public UsuarioBusiness()
        {
            this.usuarioData = new UsuarioData();
        }

        public void AltaUsuario(Usuario usuario)
        {
            try
            {
                this.Validar(usuario);

                int id = this.usuarioData.ObtenerProximoId();
                usuario.Contrasena = Encriptacion.EncriptarPassword(usuario.Contrasena);
                this.usuarioData.AltaUsuario(usuario, id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> ConsultarUsuarios()
        {
            try
            {
                return this.usuarioData.ConsultarUsuarios();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void Validar(Usuario usuario)
        {
            this.Validar(usuario, 0);
        }

        private void Validar(Usuario usuario, int idUsuarioActual)
        {
            if (usuario == null)
            {
                throw new Exception("Debe informar un usuario.");
            }

            if (usuario.Documento <= 0)
            {
                throw new Exception("Debe ingresar un documento valido.");
            }

            if (string.IsNullOrWhiteSpace(usuario.NombreUsuario))
            {
                throw new Exception("Debe ingresar un nombre de usuario.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Contrasena))
            {
                throw new Exception("Debe ingresar una contrasena.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                throw new Exception("Debe ingresar un nombre.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Apellido))
            {
                throw new Exception("Debe ingresar un apellido.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Mail))
            {
                throw new Exception("Debe ingresar un mail.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Telefono))
            {
                throw new Exception("Debe ingresar un telefono.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Direccion))
            {
                throw new Exception("Debe ingresar una direccion.");
            }

            List<Usuario> usuarios = this.usuarioData.ConsultarUsuarios();

            bool documentoExistente = usuarios.Any(usuarioExistente =>
                usuarioExistente.Documento == usuario.Documento
                && usuarioExistente.Id != idUsuarioActual
            );

            if (documentoExistente)
            {
                throw new Exception("Ya existe un usuario con ese documento.");
            }

            bool nombreUsuarioExistente = usuarios.Any(usuarioExistente =>
                usuarioExistente.NombreUsuario.Equals(
                    usuario.NombreUsuario.Trim(),
                    StringComparison.OrdinalIgnoreCase
                )
                && usuarioExistente.Id != idUsuarioActual
            );

            if (nombreUsuarioExistente)
            {
                throw new Exception("Ya existe un usuario con ese nombre de usuario.");
            }
        }
    }
}
