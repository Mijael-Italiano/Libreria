using System;
using System.Collections.Generic;
using Libreria.Entity.EntityComposite;

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
        public List<Rol> Roles { get; set; }

        public Usuario()
        {
            this.Documento = 0;
            this.NombreUsuario = string.Empty;
            this.Contrasena = string.Empty;
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.Mail = string.Empty;
            this.Telefono = string.Empty;
            this.FechaNacimiento = DateTime.Today;
            this.Direccion = string.Empty;
            this.Departamento = null;
            this.Estado = true;
            this.Bloqueado = false;
            this.FechaAlta = DateTime.Now;
            this.IntentosFallidos = 0;
            this.Roles = new List<Rol>();
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
            bool bloqueado)
        {
            this.Documento = documento;
            this.NombreUsuario = nombreUsuario;
            this.Contrasena = contrasena;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Mail = mail;
            this.Telefono = telefono;
            this.FechaNacimiento = fechaNacimiento;
            this.Direccion = direccion;
            this.Departamento = departamento;
            this.Estado = estado;
            this.Bloqueado = bloqueado;
            this.FechaAlta = DateTime.Now;
            this.IntentosFallidos = 0;
            this.Roles = new List<Rol>();
        }
    }
}
