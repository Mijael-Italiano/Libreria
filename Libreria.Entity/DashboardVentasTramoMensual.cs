using System;

namespace Libreria.Entity
{
    public class DashboardVentasTramoMensual
    {
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Etiqueta { get; set; } = string.Empty;
        public decimal TotalFacturado { get; set; }
        public int CantidadFacturas { get; set; }
    }
}
