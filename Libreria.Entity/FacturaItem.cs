namespace Libreria.Entity
{
    public class FacturaItem
    {
        public int IdFacturaItem { get; set; }
        public Factura Factura { get; set; }
        public Producto Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public string Estado { get; set; }

        public FacturaItem()
        {
            this.IdFacturaItem = 0;
            this.Factura = new Factura();
            this.Producto = new Producto();
            this.Cantidad = 0;
            this.PrecioUnitario = 0;
            this.Subtotal = 0;
            this.Estado = "Emitido";
        }

        public FacturaItem(Factura factura, Producto producto, int cantidad, decimal precioUnitario)
        {
            this.Factura = factura;
            this.Producto = producto;
            this.Cantidad = cantidad;
            this.PrecioUnitario = precioUnitario;
            this.Subtotal = cantidad * precioUnitario;
            this.Estado = "Emitido";
        }
    }
}
