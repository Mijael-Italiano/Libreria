using System;

namespace Libreria.Entity
{
    public class ItemInventario
    {
        public int Id { get; set; }
        public Producto Producto { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }

        public ItemInventario()
        {
            this.Id = 0;
            this.Producto = new Producto();
            this.StockActual = 0;
            this.StockMinimo = 0;
            this.FechaUltimaActualizacion = DateTime.Now;
        }

        public ItemInventario(
            Producto producto,
            int stockActual,
            int stockMinimo)
        {
            this.Producto = producto;
            this.StockActual = stockActual;
            this.StockMinimo = stockMinimo;
            this.FechaUltimaActualizacion = DateTime.Now;
        }
    }
}
