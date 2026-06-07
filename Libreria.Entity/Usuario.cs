using System;
using System.Collections.Generic;

namespace Libreria.Entity
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Estado { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IntentosFallidos { get; set; }
        public List<string> Roles { get; set; }

        public Usuario()
        {
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Estado = true;
            Bloqueado = false;
            FechaAlta = DateTime.Now;
            IntentosFallidos = 0;
            Roles = new List<string>();
        }

        public Usuario(
            string nombreUsuario,
            string contrasena,
            string nombre,
            string apellido,
            bool estado,
            bool bloqueado,
            List<string> roles)
        {
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            Nombre = nombre;
            Apellido = apellido;
            Estado = estado;
            Bloqueado = bloqueado;
            FechaAlta = DateTime.Now;
            IntentosFallidos = 0;
            Roles = roles ?? new List<string>();
        }
    }
}
