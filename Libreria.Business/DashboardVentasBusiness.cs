using System;
using System.Collections.Generic;
using System.Linq;
using Libreria.Entity;

namespace Libreria.Business
{
    public class DashboardVentasBusiness
    {
        private readonly FacturaBusiness facturaBusiness;
        private readonly FacturaItemBusiness facturaItemBusiness;

        public DashboardVentasBusiness()
        {
            this.facturaBusiness = new FacturaBusiness();
            this.facturaItemBusiness = new FacturaItemBusiness();
        }

        public DashboardVentasResumen ObtenerResumen(DateTime fechaDesde, DateTime fechaHasta)
        {
            DateTime desde = fechaDesde.Date;
            DateTime hasta = fechaHasta.Date;

            if (desde > hasta)
            {
                throw new Exception("La fecha desde no puede ser mayor a la fecha hasta.");
            }

            List<Factura> facturas = this.facturaBusiness.ConsultarFacturas()
                .Where(factura => factura.FechaEmision.Date >= desde
                    && factura.FechaEmision.Date <= hasta
                    && !factura.Estado.Equals("Anulada", StringComparison.OrdinalIgnoreCase))
                .ToList();

            List<FacturaItem> items = this.facturaItemBusiness.ConsultarFacturaItems()
                .Where(item => item.Factura.FechaEmision.Date >= desde
                    && item.Factura.FechaEmision.Date <= hasta
                    && !item.Estado.Equals("Anulado", StringComparison.OrdinalIgnoreCase)
                    && !item.Factura.Estado.Equals("Anulada", StringComparison.OrdinalIgnoreCase))
                .ToList();

            return new DashboardVentasResumen
            {
                TotalFacturado = facturas.Sum(factura => factura.Total),
                CantidadFacturas = facturas.Count,
                CantidadItemsVendidos = items.Sum(item => item.Cantidad),
                VentasPorDia = this.ObtenerVentasPorDia(facturas, desde, hasta),
                VentasPorHora = this.ObtenerVentasPorHora(facturas, desde),
                VentasPorCategoria = this.ObtenerVentasPorCategoria(items),
                CategoriasPorItems = this.ObtenerCategoriasPorItems(items),
                VentasPorMarcaCategoria = this.ObtenerVentasPorMarcaCategoria(items),
            };
        }

        private List<DashboardVentasDia> ObtenerVentasPorDia(List<Factura> facturas, DateTime desde, DateTime hasta)
        {
            List<DashboardVentasDia> ventas = new List<DashboardVentasDia>();

            for (DateTime fecha = desde; fecha <= hasta; fecha = fecha.AddDays(1))
            {
                List<Factura> facturasDia = facturas
                    .Where(factura => factura.FechaEmision.Date == fecha.Date)
                    .ToList();

                ventas.Add(new DashboardVentasDia
                {
                    Fecha = fecha,
                    TotalFacturado = facturasDia.Sum(factura => factura.Total),
                    CantidadFacturas = facturasDia.Count,
                });
            }

            return ventas;
        }

        private List<DashboardVentasHora> ObtenerVentasPorHora(List<Factura> facturas, DateTime fecha)
        {
            List<DashboardVentasHora> ventas = new List<DashboardVentasHora>();

            for (int hora = 0; hora < 24; hora++)
            {
                List<Factura> facturasHora = facturas
                    .Where(factura => factura.FechaEmision.Date == fecha.Date
                        && factura.FechaEmision.Hour == hora)
                    .ToList();

                ventas.Add(new DashboardVentasHora
                {
                    Hora = hora,
                    TotalFacturado = facturasHora.Sum(factura => factura.Total),
                    CantidadFacturas = facturasHora.Count,
                });
            }

            return ventas;
        }



        private List<DashboardVentasCategoria> ObtenerCategoriasPorItems(List<FacturaItem> items)
        {
            return items
                .GroupBy(item => item.Producto.Categoria?.Nombre ?? "Sin categoria")
                .Select(grupo => new DashboardVentasCategoria
                {
                    Categoria = grupo.Key,
                    TotalFacturado = grupo.Sum(item => item.Subtotal),
                    CantidadVendida = grupo.Sum(item => item.Cantidad),
                })
                .OrderByDescending(categoria => categoria.CantidadVendida)
                .ThenBy(categoria => categoria.Categoria)
                .ToList();
        }
        private List<DashboardVentasMarcaCategoria> ObtenerVentasPorMarcaCategoria(List<FacturaItem> items)
        {
            return items
                .GroupBy(item => new
                {
                    Categoria = item.Producto.Categoria?.Nombre ?? "Sin categoria",
                    Marca = item.Producto.Marca?.Nombre ?? "Sin marca"
                })
                .Select(grupo => new DashboardVentasMarcaCategoria
                {
                    Categoria = grupo.Key.Categoria,
                    Marca = grupo.Key.Marca,
                    TotalFacturado = grupo.Sum(item => item.Subtotal),
                    CantidadVendida = grupo.Sum(item => item.Cantidad),
                })
                .OrderByDescending(marca => marca.TotalFacturado)
                .ThenBy(marca => marca.Marca)
                .ToList();
        }
        private List<DashboardVentasCategoria> ObtenerVentasPorCategoria(List<FacturaItem> items)
        {
            return items
                .GroupBy(item => item.Producto.Categoria?.Nombre ?? "Sin categoria")
                .Select(grupo => new DashboardVentasCategoria
                {
                    Categoria = grupo.Key,
                    TotalFacturado = grupo.Sum(item => item.Subtotal),
                    CantidadVendida = grupo.Sum(item => item.Cantidad),
                })
                .OrderByDescending(categoria => categoria.TotalFacturado)
                .ThenBy(categoria => categoria.Categoria)
                .ToList();
        }
    }

    public class DashboardVentasResumen
    {
        public decimal TotalFacturado { get; set; }
        public int CantidadFacturas { get; set; }
        public int CantidadItemsVendidos { get; set; }
        public List<DashboardVentasDia> VentasPorDia { get; set; } = new List<DashboardVentasDia>();
        public List<DashboardVentasHora> VentasPorHora { get; set; } = new List<DashboardVentasHora>();
        public List<DashboardVentasCategoria> VentasPorCategoria { get; set; } = new List<DashboardVentasCategoria>();
        public List<DashboardVentasCategoria> CategoriasPorItems { get; set; } = new List<DashboardVentasCategoria>();
        public List<DashboardVentasMarcaCategoria> VentasPorMarcaCategoria { get; set; } = new List<DashboardVentasMarcaCategoria>();
    }

    public class DashboardVentasDia
    {
        public DateTime Fecha { get; set; }
        public decimal TotalFacturado { get; set; }
        public int CantidadFacturas { get; set; }
    }

    public class DashboardVentasHora
    {
        public int Hora { get; set; }
        public decimal TotalFacturado { get; set; }
        public int CantidadFacturas { get; set; }
    }


    public class DashboardVentasMarcaCategoria
    {
        public string Categoria { get; set; } = string.Empty;
        public string Marca { get; set; } = string.Empty;
        public decimal TotalFacturado { get; set; }
        public int CantidadVendida { get; set; }
    }
    public class DashboardVentasCategoria
    {
        public string Categoria { get; set; } = string.Empty;
        public decimal TotalFacturado { get; set; }
        public int CantidadVendida { get; set; }
    }
}






