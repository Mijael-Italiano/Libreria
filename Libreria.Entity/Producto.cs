using System;

namespace Libreria.Entity
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
        public bool Estado { get; set; }

        public Producto()
        {
            this.IdProducto = 0;
            this.Marca = new Marca();
            this.Categoria = new Categoria();
            this.Descripcion = string.Empty;
            this.PrecioUnitario = 0;
            this.StockActual = 0;
            this.StockMinimo = 0;
            this.FechaUltimaActualizacion = DateTime.Now;
            this.Estado = true;
        }

        public Producto(
            Marca marca,
            Categoria categoria,
            string descripcion,
            decimal precioUnitario,
            int stockActual,
            int stockMinimo,
            bool estado)
        {
            this.Marca = marca;
            this.Categoria = categoria;
            this.Descripcion = descripcion;
            this.PrecioUnitario = precioUnitario;
            this.StockActual = stockActual;
            this.StockMinimo = stockMinimo;
            this.FechaUltimaActualizacion = DateTime.Now;
            this.Estado = estado;
        }
    }
}
