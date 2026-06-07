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
        public string Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IntentosFallidos { get; set; }
        public List<string> Roles { get; set; }

        public Usuario()
        {
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Estado = "Activo";
            FechaAlta = DateTime.Now;
            IntentosFallidos = 0;
            Roles = new List<string>();
        }
    }
}
