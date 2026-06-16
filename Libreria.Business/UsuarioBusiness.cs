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

        public Usuario IniciarSesion(string nombreUsuario, string contrasena)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nombreUsuario)
                    || string.IsNullOrWhiteSpace(contrasena))
                {
                    throw new Exception("Las credenciales no son correctas.");
                }

                Usuario usuario = this.usuarioData
                    .ConsultarUsuarios()
                    .FirstOrDefault(usuarioExistente =>
                        usuarioExistente.NombreUsuario.Equals(
                            nombreUsuario.Trim(),
                            StringComparison.OrdinalIgnoreCase
                        )
                    ) ?? throw new Exception("Las credenciales no son correctas.");

                string contrasenaEncriptada = Encriptacion.EncriptarPassword(contrasena);

                if (usuario.Contrasena != contrasenaEncriptada)
                {
                    this.usuarioData.ActualizarIntentosFallidos(
                        usuario.Id,
                        usuario.IntentosFallidos + 1
                    );

                    throw new Exception("Las credenciales no son correctas.");
                }

                this.usuarioData.ActualizarIntentosFallidos(usuario.Id, 0);
                usuario.IntentosFallidos = 0;

                return usuario;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ModificarUsuario(Usuario usuario)
        {
            try
            {
                if (usuario.Id <= 0)
                {
                    throw new Exception("Debe seleccionar un usuario.");
                }

                this.Validar(usuario, usuario.Id);

                Usuario usuarioActual = this.usuarioData
                    .ConsultarUsuarios()
                    .FirstOrDefault(usuarioExistente => usuarioExistente.Id == usuario.Id)
                    ?? throw new Exception("El usuario seleccionado no existe.");

                string contrasenaEncriptada = Encriptacion.EncriptarPassword(usuario.Contrasena);

                if (!this.UsuarioTieneCambios(usuarioActual, usuario, contrasenaEncriptada))
                {
                    throw new Exception("No se modifico ningun dato.");
                }

                usuario.Contrasena = contrasenaEncriptada;
                this.usuarioData.ModificarUsuario(usuario);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EliminarUsuario(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar un usuario.");
                }

                if (id == 1)
                {
                    throw new Exception("No se puede dar de baja el usuario Admin.");
                }

                Usuario usuarioActual = this.usuarioData
                    .ConsultarUsuarios()
                    .FirstOrDefault(usuarioExistente => usuarioExistente.Id == id)
                    ?? throw new Exception("El usuario seleccionado no existe.");

                if (!usuarioActual.Estado)
                {
                    throw new Exception("El usuario seleccionado ya esta dado de baja.");
                }

                this.usuarioData.CambiarEstadoUsuario(id, false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ReactivarUsuario(int id)
        {
            try
            {
                if (id <= 0)
                {
                    throw new Exception("Debe seleccionar un usuario.");
                }

                Usuario usuarioActual = this.usuarioData
                    .ConsultarUsuarios()
                    .FirstOrDefault(usuarioExistente => usuarioExistente.Id == id)
                    ?? throw new Exception("El usuario seleccionado no existe.");

                if (usuarioActual.Estado)
                {
                    throw new Exception("El usuario seleccionado ya esta activo.");
                }

                this.usuarioData.CambiarEstadoUsuario(id, true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Usuario> BuscarUsuarios(
            string nombre,
            string apellido,
            string documento,
            bool incluirNoActivos)
        {
            try
            {
                nombre = nombre.Trim();
                apellido = apellido.Trim();
                documento = documento.Trim();

                if (!string.IsNullOrWhiteSpace(documento)
                    && !documento.All(char.IsDigit))
                {
                    throw new Exception("Debe ingresar un DNI valido.");
                }

                return this.usuarioData.BuscarUsuarios(
                    nombre,
                    apellido,
                    documento,
                    incluirNoActivos
                );
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool UsuarioTieneCambios(
            Usuario usuarioActual,
            Usuario usuarioModificado,
            string contrasenaModificadaEncriptada)
        {
            return usuarioActual.Documento != usuarioModificado.Documento
                || !usuarioActual.NombreUsuario.Equals(usuarioModificado.NombreUsuario.Trim(), StringComparison.Ordinal)
                || usuarioActual.Contrasena != contrasenaModificadaEncriptada
                || !usuarioActual.Nombre.Equals(usuarioModificado.Nombre.Trim(), StringComparison.Ordinal)
                || !usuarioActual.Apellido.Equals(usuarioModificado.Apellido.Trim(), StringComparison.Ordinal)
                || !usuarioActual.Mail.Equals(usuarioModificado.Mail.Trim(), StringComparison.Ordinal)
                || !usuarioActual.Telefono.Equals(usuarioModificado.Telefono.Trim(), StringComparison.Ordinal)
                || usuarioActual.FechaNacimiento.Date != usuarioModificado.FechaNacimiento.Date
                || !usuarioActual.Direccion.Equals(usuarioModificado.Direccion.Trim(), StringComparison.Ordinal)
                || !NormalizarTextoOpcional(usuarioActual.Departamento).Equals(
                    NormalizarTextoOpcional(usuarioModificado.Departamento),
                    StringComparison.Ordinal
                )
                || usuarioActual.Estado != usuarioModificado.Estado
                || usuarioActual.Bloqueado != usuarioModificado.Bloqueado;
        }

        private static string NormalizarTextoOpcional(string? valor)
        {
            return valor?.Trim() ?? string.Empty;
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
