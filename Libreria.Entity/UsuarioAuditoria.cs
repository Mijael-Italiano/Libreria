using System;

namespace Libreria.Entity
{
    public class UsuarioAuditoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }

        public UsuarioAuditoria()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Apellido = string.Empty;
            this.Dni = 0;
        }

        public UsuarioAuditoria(string nombre, string apellido, int dni)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
        }
    }
}
