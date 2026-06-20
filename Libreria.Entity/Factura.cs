using System;

namespace Libreria.Entity
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
        public DateTime FechaEmision { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }

        public Factura()
        {
            this.IdFactura = 0;
            this.Cliente = new Cliente();
            this.Usuario = new Usuario();
            this.FechaEmision = DateTime.Now;
            this.Total = 0;
            this.Estado = "Emitida";
        }

        public Factura(Cliente cliente, Usuario usuario, decimal total)
        {
            this.Cliente = cliente;
            this.Usuario = usuario;
            this.FechaEmision = DateTime.Now;
            this.Total = total;
            this.Estado = "Emitida";
        }
    }
}
