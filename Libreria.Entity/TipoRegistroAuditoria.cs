namespace Libreria.Entity
{
    public class TipoRegistroAuditoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public TipoRegistroAuditoria()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
        }

        public TipoRegistroAuditoria(string nombre)
        {
            this.Nombre = nombre;
        }
    }
}
