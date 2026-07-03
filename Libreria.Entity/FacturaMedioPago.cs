namespace Libreria.Entity
{
    public class FacturaMedioPago
    {
        public Factura Factura { get; set; }
        public MedioPago MedioPago { get; set; }
        public decimal Monto { get; set; }
        public string Estado { get; set; }

        public FacturaMedioPago()
        {
            this.Factura = new Factura();
            this.MedioPago = new MedioPago();
            this.Monto = 0;
            this.Estado = "Activo";
        }

        public FacturaMedioPago(Factura factura, MedioPago medioPago, decimal monto)
        {
            this.Factura = factura;
            this.MedioPago = medioPago;
            this.Monto = monto;
            this.Estado = "Activo";
        }
    }
}


