namespace Libreria.Entity
{
    public class DashboardVentasMes
    {
        public int Mes { get; set; }
        public string NombreMes { get; set; } = string.Empty;
        public decimal TotalFacturado { get; set; }
        public int CantidadFacturas { get; set; }
    }
}
