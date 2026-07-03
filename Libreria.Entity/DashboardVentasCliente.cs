namespace Libreria.Entity
{
    public class DashboardVentasCliente
    {
        public string Cliente { get; set; } = string.Empty;
        public decimal TotalFacturado { get; set; }
        public int CantidadCompras { get; set; }
    }
}
