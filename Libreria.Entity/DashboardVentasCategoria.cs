namespace Libreria.Entity
{
    public class DashboardVentasCategoria
    {
        public string Categoria { get; set; } = string.Empty;
        public decimal TotalFacturado { get; set; }
        public int CantidadVendida { get; set; }
    }
}
