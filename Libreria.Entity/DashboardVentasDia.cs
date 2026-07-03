using System;

namespace Libreria.Entity
{
    public class DashboardVentasDia
    {
        public DateTime Fecha { get; set; }
        public decimal TotalFacturado { get; set; }
        public int CantidadFacturas { get; set; }
    }
}
