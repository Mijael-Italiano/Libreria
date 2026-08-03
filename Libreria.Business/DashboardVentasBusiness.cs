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
                ClientesPorIngresos = this.ObtenerClientesPorIngresos(facturas),
                VentasPorHora = this.ObtenerVentasPorHora(facturas, desde),
                VentasPorCategoria = this.ObtenerVentasPorCategoria(items),
                CategoriasPorItems = this.ObtenerCategoriasPorItems(items),
                VentasPorMarcaCategoria = this.ObtenerVentasPorMarcaCategoria(items),
            };
        }



        public DashboardVentasResumen ObtenerResumenMensual(int anio, int mes)
        {
            if (mes < 1 || mes > 12)
            {
                throw new Exception("El mes indicado no es valido.");
            }

            DateTime desde = new DateTime(anio, mes, 1);
            DateTime hasta = desde.AddMonths(1).AddDays(-1);

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
                VentasPorTramoMensual = this.ObtenerVentasPorTramoMensual(facturas, desde, hasta),
                ClientesPorIngresos = this.ObtenerClientesPorIngresos(facturas),
                VentasPorHora = this.ObtenerVentasPorHora(facturas, desde),
                VentasPorCategoria = this.ObtenerVentasPorCategoria(items),
                CategoriasPorItems = this.ObtenerCategoriasPorItems(items),
                VentasPorMarcaCategoria = this.ObtenerVentasPorMarcaCategoria(items),
            };
        }
        private List<DashboardVentasCliente> ObtenerClientesPorIngresos(List<Factura> facturas)
        {
            return facturas
                .GroupBy(factura => new
                {
                    factura.Cliente.Id,
                    factura.Cliente.Nombre,
                    factura.Cliente.Apellido
                })
                .Select(grupo => new DashboardVentasCliente
                {
                    Cliente = $"{grupo.Key.Apellido}, {grupo.Key.Nombre}",
                    TotalFacturado = grupo.Sum(factura => factura.Total),
                    CantidadCompras = grupo.Count(),
                })
                .OrderByDescending(cliente => cliente.TotalFacturado)
                .ThenBy(cliente => cliente.Cliente)
                .ToList();
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


        private List<DashboardVentasTramoMensual> ObtenerVentasPorTramoMensual(List<Factura> facturas, DateTime desde, DateTime hasta)
        {
            List<DashboardVentasTramoMensual> ventas = new List<DashboardVentasTramoMensual>();
            DateTime inicioTramo = desde.Date;

            while (inicioTramo <= hasta.Date)
            {
                int diasHastaDomingo = DayOfWeek.Sunday - inicioTramo.DayOfWeek;
                if (diasHastaDomingo < 0)
                {
                    diasHastaDomingo += 7;
                }

                DateTime finTramo = inicioTramo.AddDays(diasHastaDomingo);
                if (finTramo > hasta.Date)
                {
                    finTramo = hasta.Date;
                }

                List<Factura> facturasTramo = facturas
                    .Where(factura => factura.FechaEmision.Date >= inicioTramo.Date
                        && factura.FechaEmision.Date <= finTramo.Date)
                    .ToList();

                ventas.Add(new DashboardVentasTramoMensual
                {
                    FechaDesde = inicioTramo,
                    FechaHasta = finTramo,
                    Etiqueta = $"{ObtenerDiaCorto(inicioTramo)} {inicioTramo.Day} - {ObtenerDiaCorto(finTramo)} {finTramo.Day}",
                    TotalFacturado = facturasTramo.Sum(factura => factura.Total),
                    CantidadFacturas = facturasTramo.Count,
                });

                inicioTramo = finTramo.AddDays(1);
            }

            return ventas;
        }

        private static string ObtenerDiaCorto(DateTime fecha)
        {
            return fecha.DayOfWeek switch
            {
                DayOfWeek.Monday => "Lun",
                DayOfWeek.Tuesday => "Mar",
                DayOfWeek.Wednesday => "Mié",
                DayOfWeek.Thursday => "Jue",
                DayOfWeek.Friday => "Vie",
                DayOfWeek.Saturday => "Sáb",
                DayOfWeek.Sunday => "Dom",
                _ => string.Empty,
            };
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

}











