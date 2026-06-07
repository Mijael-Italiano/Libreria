using System;
using System.Collections.Generic;

namespace Libreria.Entity
{
    public class Usuario
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public string? Departamento { get; set; }
        public bool Estado { get; set; }
        public bool Bloqueado { get; set; }
        public DateTime FechaAlta { get; set; }
        public int IntentosFallidos { get; set; }
        public List<string> Roles { get; set; }

        public Usuario()
        {
            Documento = 0;
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
            Nombre = string.Empty;
            Apellido = string.Empty;
            Mail = string.Empty;
            Telefono = string.Empty;
            FechaNacimiento = DateTime.Today;
            Direccion = string.Empty;
            Departamento = null;
            Estado = true;
            Bloqueado = false;
            FechaAlta = DateTime.Now;
            IntentosFallidos = 0;
            Roles = new List<string>();
        }

        public Usuario(
            int documento,
            string nombreUsuario,
            string contrasena,
            string nombre,
            string apellido,
            string mail,
            string telefono,
            DateTime fechaNacimiento,
            string direccion,
            string? departamento,
            bool estado,
            bool bloqueado,
            List<string> roles)
        {
            Documento = documento;
            NombreUsuario = nombreUsuario;
            Contrasena = contrasena;
            Nombre = nombre;
            Apellido = apellido;
            Mail = mail;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            Direccion = direccion;
            Departamento = departamento;
            Estado = estado;
            Bloqueado = bloqueado;
            FechaAlta = DateTime.Now;
            IntentosFallidos = 0;
            Roles = roles ?? new List<string>();
        }
    }
}
