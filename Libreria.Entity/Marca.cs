namespace Libreria.Entity
{
    public class Marca
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public Marca()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Estado = true;
        }

        public Marca(string nombre)
        {
            this.Nombre = nombre;
            this.Estado = true;
        }
    }
}
