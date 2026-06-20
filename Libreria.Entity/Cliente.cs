using System;

namespace Libreria.Entity
{
    public class Cliente
    {
        public int Id { get; set; }
        public int Documento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string? Telefono { get; set; }
        public string? Mail { get; set; }
        public string? Direccion { get; set; }
        public string? Departamento { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaAlta { get; set; }

        public int? Edad
        {
            get
            {
                if (this.FechaNacimiento == null)
                {
                    return null;
                }

                int edad = DateTime.Today.Year - this.FechaNacimiento.Value.Year;

                if (this.FechaNacimiento.Value.Date > DateTime.Today.AddYears(-edad))
                {
                    edad--;
                }

                return edad;
            }
        }

        public Cliente()
        {
            this.Documento = 0;
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.Telefono = null;
            this.Mail = null;
            this.Direccion = null;
            this.Departamento = null;
            this.FechaNacimiento = null;
            this.Estado = true;
            this.FechaAlta = DateTime.Now;
        }

        public Cliente(
            int documento,
            string nombre,
            string apellido,
            string? telefono,
            string? mail,
            string? direccion,
            string? departamento,
            DateTime? fechaNacimiento,
            bool estado)
        {
            this.Documento = documento;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Telefono = telefono;
            this.Mail = mail;
            this.Direccion = direccion;
            this.Departamento = departamento;
            this.FechaNacimiento = fechaNacimiento;
            this.Estado = estado;
            this.FechaAlta = DateTime.Now;
        }
    }
}
