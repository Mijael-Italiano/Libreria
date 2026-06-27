using System;

namespace Libreria.Entity
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public Marca? Marca { get; set; }
        public Categoria? Categoria { get; set; }
        public ColorProducto? Color { get; set; }
        public string Descripcion { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaUltimaActualizacion { get; set; }
        public bool Estado { get; set; }

        public Producto()
        {
            this.IdProducto = 0;
            this.Marca = null;
            this.Categoria = null;
            this.Color = null;
            this.Descripcion = string.Empty;
            this.PrecioUnitario = 0;
            this.StockActual = 0;
            this.StockMinimo = 0;
            this.FechaAlta = DateTime.Now;
            this.FechaUltimaActualizacion = DateTime.Now;
            this.Estado = true;
        }

        public Producto(
            Marca? marca,
            Categoria? categoria,
            ColorProducto? color,
            string descripcion,
            decimal precioUnitario,
            int stockActual,
            int stockMinimo,
            bool estado)
        {
            this.Marca = marca;
            this.Categoria = categoria;
            this.Color = color;
            this.Descripcion = descripcion;
            this.PrecioUnitario = precioUnitario;
            this.StockActual = stockActual;
            this.StockMinimo = stockMinimo;
            this.FechaAlta = DateTime.Now;
            this.FechaUltimaActualizacion = DateTime.Now;
            this.Estado = estado;
        }
    }
}
