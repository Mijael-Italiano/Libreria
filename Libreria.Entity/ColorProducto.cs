namespace Libreria.Entity
{
    public class ColorProducto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public ColorProducto()
        {
            this.Id = 0;
            this.Nombre = string.Empty;
            this.Estado = true;
        }

        public ColorProducto(string nombre)
        {
            this.Nombre = nombre;
            this.Estado = true;
        }
    }
}
