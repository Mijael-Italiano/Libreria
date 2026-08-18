using System.Collections.Generic;

namespace Libreria.Entity
{
    public class DashboardVentasResumen
    {
        public decimal TotalFacturado { get; set; }
        public int CantidadFacturas { get; set; }
        public int CantidadItemsVendidos { get; set; }
        public List<DashboardVentasDia> VentasPorDia { get; set; } = new List<DashboardVentasDia>();
        public List<DashboardVentasTramoMensual> VentasPorTramoMensual { get; set; } = new List<DashboardVentasTramoMensual>();
        public List<DashboardVentasMes> VentasPorMes { get; set; } = new List<DashboardVentasMes>();
        public List<DashboardVentasCliente> ClientesPorIngresos { get; set; } = new List<DashboardVentasCliente>();
        public List<DashboardVentasHora> VentasPorHora { get; set; } = new List<DashboardVentasHora>();
        public List<DashboardVentasCategoria> VentasPorCategoria { get; set; } = new List<DashboardVentasCategoria>();
        public List<DashboardVentasCategoria> CategoriasPorItems { get; set; } = new List<DashboardVentasCategoria>();
        public List<DashboardVentasMarcaCategoria> VentasPorMarcaCategoria { get; set; } = new List<DashboardVentasMarcaCategoria>();
    }
}
