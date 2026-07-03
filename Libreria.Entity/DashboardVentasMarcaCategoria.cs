namespace Libreria.Entity
{
    public class DashboardVentasMarcaCategoria
    {
        public string Categoria { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public decimal TotalFacturado { get; set; }
        public int CantidadVendida { get; set; }
    }
}
