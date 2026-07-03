using System;

namespace Libreria.Entity
{
    public class RegistroAuditoria
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public TipoRegistroAuditoria Tipo { get; set; }
        public UsuarioAuditoria UsuarioAuditoria { get; set; }
        public string NombreBackUp { get; set; }

        public RegistroAuditoria()
        {
            this.Id = 0;
            this.Fecha = DateTime.Now;
            this.Tipo = new TipoRegistroAuditoria();
            this.UsuarioAuditoria = new UsuarioAuditoria();
            this.NombreBackUp = string.Empty;
        }

        public RegistroAuditoria(
            TipoRegistroAuditoria tipo,
            UsuarioAuditoria usuarioAuditoria,
            string nombreBackUp)
        {
            this.Fecha = DateTime.Now;
            this.Tipo = tipo;
            this.UsuarioAuditoria = usuarioAuditoria;
            this.NombreBackUp = nombreBackUp;
        }
    }
}
