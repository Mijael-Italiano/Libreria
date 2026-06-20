namespace Libreria.Entity
{
    public class MedioPago
    {
        public int IdMedioPago { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }

        public MedioPago()
        {
            this.IdMedioPago = 0;
            this.Nombre = string.Empty;
            this.Estado = true;
        }

        public MedioPago(string nombre)
        {
            this.Nombre = nombre;
            this.Estado = true;
        }
    }
}
