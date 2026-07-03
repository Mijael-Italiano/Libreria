using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Libreria.Business;
using Libreria.Entity;

namespace Libreria.UI
{
    public partial class FormDashboardVentasMensuales : Form
    {
        private readonly DashboardVentasBusiness dashboardVentasBusiness;
        private DateTime fechaMes;
        private DashboardVentasResumen? resumenMes;
        private List<DashboardVentasMarcaCategoria> marcasCategoriaSeleccionada;
        private CriterioTortaMarcas criterioTortaSeleccionado;

        public FormDashboardVentasMensuales()
        {
            InitializeComponent();
            this.dashboardVentasBusiness = new DashboardVentasBusiness();
            this.marcasCategoriaSeleccionada = new List<DashboardVentasMarcaCategoria>();
            this.criterioTortaSeleccionado = CriterioTortaMarcas.Ingresos;
            this.fechaMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            this.ConfigurarChartMarcas();
            this.MostrarMes();
        }

        private void btnMesAnterior_Click(object? sender, EventArgs e)
        {
            this.fechaMes = this.fechaMes.AddMonths(-1);
            this.MostrarMes();
        }

        private void btnMesSiguiente_Click(object? sender, EventArgs e)
        {
            this.fechaMes = this.fechaMes.AddMonths(1);
            this.MostrarMes();
        }

        private void btnMesActual_Click(object? sender, EventArgs e)
        {
            this.fechaMes = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            this.MostrarMes();
        }

        private void MostrarMes()
        {
            try
            {
                this.resumenMes = this.dashboardVentasBusiness.ObtenerResumenMensual(this.fechaMes.Year, this.fechaMes.Month);
                DateTime fechaFinMes = this.fechaMes.AddMonths(1).AddDays(-1);

                this.lblRangoMes.Text = $"{this.fechaMes:MMMM yyyy} ({this.fechaMes:dd/MM/yyyy} al {fechaFinMes:dd/MM/yyyy})";
                this.MostrarResumen(this.resumenMes);
                this.MostrarBarrasTramos(this.resumenMes.VentasPorTramoMensual);
                this.MostrarClientesPorIngresos(this.resumenMes.ClientesPorIngresos);
                this.MostrarCategoriasPorIngresos(this.resumenMes.VentasPorCategoria);
                this.MostrarCategoriasPorItems(this.resumenMes.CategoriasPorItems);
                this.LimpiarTortaMarcas("Seleccione una categoria del top para ver marcas.");
                this.lblEstado.Text = string.Empty;
            }
            catch (Exception ex)
            {
                this.lblEstado.Text = "No se pudieron cargar los datos del dashboard mensual.";
                MessageBox.Show(ex.Message, "Dashboard mensual de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarResumen(DashboardVentasResumen resumen)
        {
            this.lblTotalValor.Text = FormatearImporte(resumen.TotalFacturado);
            this.lblItemsValor.Text = resumen.CantidadItemsVendidos.ToString();
            this.lblFacturasValor.Text = resumen.CantidadFacturas.ToString();
        }

        private void MostrarBarrasTramos(List<DashboardVentasTramoMensual> tramos)
        {
            this.panelGraficoMes.Controls.Clear();

            if (tramos.Count == 0)
            {
                this.panelGraficoMes.Controls.Add(this.CrearEtiqueta(
                    "Sin ventas en el mes",
                    new Point(12, 80),
                    new Size(this.panelGraficoMes.Width - 24, 30),
                    ContentAlignment.MiddleCenter));
                return;
            }

            decimal maximo = tramos.Select(tramo => tramo.TotalFacturado).DefaultIfEmpty(0).Max();
            int baseBarras = this.panelGraficoMes.Height - 50;
            int alturaMaxima = Math.Max(24, baseBarras - 34);
            int cantidad = tramos.Count;
            int anchoSlot = Math.Max(1, this.panelGraficoMes.Width / cantidad);
            int anchoBarra = Math.Min(46, Math.Max(24, anchoSlot / 2));

            for (int i = 0; i < cantidad; i++)
            {
                DashboardVentasTramoMensual tramo = tramos[i];
                int centroSlot = (anchoSlot * i) + (anchoSlot / 2);
                int altura = maximo <= 0 ? 2 : Math.Max(2, (int)(alturaMaxima * tramo.TotalFacturado / maximo));

                Panel barra = new Panel
                {
                    BackColor = Color.SteelBlue,
                    Location = new Point(centroSlot - (anchoBarra / 2), baseBarras - altura),
                    Size = new Size(anchoBarra, altura),
                };

                Label valor = this.CrearEtiqueta(
                    FormatearImporteCorto(tramo.TotalFacturado),
                    new Point(centroSlot - (Math.Max(82, anchoSlot - 8) / 2), Math.Max(4, barra.Top - 24)),
                    new Size(Math.Max(82, anchoSlot - 8), 20),
                    ContentAlignment.MiddleCenter);

                Label etiqueta = this.CrearEtiqueta(
                    tramo.Etiqueta,
                    new Point(centroSlot - (Math.Max(82, anchoSlot - 8) / 2), baseBarras + 8),
                    new Size(Math.Max(82, anchoSlot - 8), 34),
                    ContentAlignment.TopCenter);

                this.ConfigurarClickTramo(barra, tramo);
                this.ConfigurarClickTramo(valor, tramo);
                this.ConfigurarClickTramo(etiqueta, tramo);

                this.panelGraficoMes.Controls.Add(barra);
                this.panelGraficoMes.Controls.Add(valor);
                this.panelGraficoMes.Controls.Add(etiqueta);
                valor.BringToFront();
            }
        }

        private void ConfigurarClickTramo(Control control, DashboardVentasTramoMensual tramo)
        {
            control.Cursor = Cursors.Hand;
            control.Tag = tramo;
            control.Click += TramoMensual_Click;
        }

        private void TramoMensual_Click(object? sender, EventArgs e)
        {
            if (sender is Control control && control.Tag is DashboardVentasTramoMensual tramo)
            {
                new FormDashboardVentas(tramo.FechaDesde, this.fechaMes).Show();
            }
        }

        private void MostrarClientesPorIngresos(List<DashboardVentasCliente> clientes)
        {
            this.panelClientesIngresos.Controls.Clear();
            List<DashboardVentasCliente> topClientes = clientes.Take(5).ToList();

            if (topClientes.Count == 0)
            {
                this.panelClientesIngresos.Controls.Add(this.CrearEtiqueta(
                    "Sin clientes con compras en el periodo",
                    new Point(12, 35),
                    new Size(this.panelClientesIngresos.Width - 24, 30),
                    ContentAlignment.MiddleCenter));
                return;
            }

            decimal maximo = topClientes.Select(cliente => cliente.TotalFacturado).DefaultIfEmpty(0).Max();
            int y = 8;

            foreach (DashboardVentasCliente cliente in topClientes)
            {
                Label nombre = this.CrearEtiqueta(cliente.Cliente, new Point(10, y), new Size(210, 18), ContentAlignment.MiddleLeft);
                Label total = this.CrearEtiqueta(FormatearImporteCorto(cliente.TotalFacturado), new Point(this.panelClientesIngresos.Width - 106, y), new Size(94, 18), ContentAlignment.MiddleRight);
                string textoCompras = cliente.CantidadCompras == 1 ? "1 asistencia" : $"{cliente.CantidadCompras} asistencias";
                Label compras = this.CrearEtiqueta(textoCompras, new Point(226, y), new Size(120, 18), ContentAlignment.MiddleLeft);
                Panel barra = new Panel
                {
                    BackColor = Color.SteelBlue,
                    Location = new Point(10, y + 17),
                    Size = new Size(maximo == 0 ? 1 : Math.Max(1, (int)(210 * cliente.TotalFacturado / maximo)), 6),
                };

                this.panelClientesIngresos.Controls.Add(nombre);
                this.panelClientesIngresos.Controls.Add(compras);
                this.panelClientesIngresos.Controls.Add(total);
                this.panelClientesIngresos.Controls.Add(barra);
                y += 24;
            }
        }

        private void MostrarCategoriasPorIngresos(List<DashboardVentasCategoria> categorias)
        {
            this.MostrarTopCategorias(
                this.panelCategoriasIngresos,
                categorias.Take(5).ToList(),
                categoria => categoria.TotalFacturado,
                categoria => FormatearImporteCorto(categoria.TotalFacturado),
                "Sin ingresos en el periodo",
                CriterioTortaMarcas.Ingresos);
        }

        private void MostrarCategoriasPorItems(List<DashboardVentasCategoria> categorias)
        {
            this.MostrarTopCategorias(
                this.panelCategoriasItems,
                categorias.Take(5).ToList(),
                categoria => categoria.CantidadVendida,
                categoria => $"{categoria.CantidadVendida} items",
                "Sin items vendidos en el periodo",
                CriterioTortaMarcas.Items);
        }

        private void MostrarTopCategorias(
            Panel panel,
            List<DashboardVentasCategoria> categorias,
            Func<DashboardVentasCategoria, decimal> obtenerValor,
            Func<DashboardVentasCategoria, string> formatearValor,
            string mensajeSinDatos,
            CriterioTortaMarcas criterio)
        {
            panel.Controls.Clear();

            if (categorias.Count == 0)
            {
                panel.Controls.Add(this.CrearEtiqueta(mensajeSinDatos, new Point(12, 58), new Size(panel.Width - 24, 30), ContentAlignment.MiddleCenter));
                return;
            }

            decimal maximo = categorias.Select(obtenerValor).DefaultIfEmpty(0).Max();
            int y = 12;

            foreach (DashboardVentasCategoria categoria in categorias)
            {
                Label nombre = this.CrearEtiqueta(categoria.Categoria, new Point(10, y), new Size(100, 18), ContentAlignment.MiddleLeft);
                Label valor = this.CrearEtiqueta(formatearValor(categoria), new Point(panel.Width - 98, y), new Size(88, 18), ContentAlignment.MiddleRight);
                Panel barra = new Panel
                {
                    BackColor = Color.SeaGreen,
                    Cursor = Cursors.Hand,
                    Location = new Point(10, y + 20),
                    Size = new Size(maximo == 0 ? 1 : Math.Max(1, (int)((panel.Width - 20) * obtenerValor(categoria) / maximo)), 8),
                };

                this.ConfigurarClickCategoria(nombre, categoria.Categoria, criterio);
                this.ConfigurarClickCategoria(valor, categoria.Categoria, criterio);
                this.ConfigurarClickCategoria(barra, categoria.Categoria, criterio);

                panel.Controls.Add(nombre);
                panel.Controls.Add(valor);
                panel.Controls.Add(barra);
                y += 27;
            }
        }

        private void ConfigurarClickCategoria(Control control, string categoria, CriterioTortaMarcas criterio)
        {
            control.Cursor = Cursors.Hand;
            control.Tag = new CategoriaSeleccionada(categoria, criterio);
            control.Click += Categoria_Click;
        }

        private void Categoria_Click(object? sender, EventArgs e)
        {
            if (sender is Control control && control.Tag is CategoriaSeleccionada seleccion)
            {
                this.MostrarTortaMarcas(seleccion.Categoria, seleccion.Criterio);
            }
        }

        private void MostrarTortaMarcas(string categoria, CriterioTortaMarcas criterio)
        {
            if (this.resumenMes == null)
            {
                return;
            }

            this.criterioTortaSeleccionado = criterio;
            this.marcasCategoriaSeleccionada = this.resumenMes.VentasPorMarcaCategoria
                .Where(marca => marca.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(marca => this.ObtenerValorMarca(marca, criterio))
                .ToList();

            this.lblTituloGraficoMarcas.Text = $"Marcas de {categoria} por {this.ObtenerNombreCriterio(criterio)}";
            this.ActualizarChartMarcas();
        }

        private void LimpiarTortaMarcas(string texto)
        {
            this.marcasCategoriaSeleccionada = new List<DashboardVentasMarcaCategoria>();
            this.criterioTortaSeleccionado = CriterioTortaMarcas.Ingresos;
            this.lblTituloGraficoMarcas.Text = texto;
            this.ActualizarChartMarcas();
        }

        private void ConfigurarChartMarcas()
        {
            ChartArea area = new ChartArea("marcas");
            this.chartMarcas.ChartAreas.Add(area);

            Series series = new Series("marcas");
            series.ChartType = SeriesChartType.Pie;
            series["PieLabelStyle"] = "Disabled";
            this.chartMarcas.Series.Add(series);

            Legend legend = new Legend("marcas");
            legend.Docking = Docking.Right;
            this.chartMarcas.Legends.Add(legend);

            this.chartMarcas.BackColor = SystemColors.Window;
        }

        private void ActualizarChartMarcas()
        {
            Series series = this.chartMarcas.Series["marcas"];
            series.Points.Clear();

            if (this.marcasCategoriaSeleccionada.Count == 0)
            {
                return;
            }

            Color[] colores = { Color.SeaGreen, Color.SteelBlue, Color.DarkOrange, Color.MediumPurple, Color.IndianRed, Color.Goldenrod };
            decimal total = this.marcasCategoriaSeleccionada.Sum(marca => this.ObtenerValorMarca(marca, this.criterioTortaSeleccionado));
            if (total <= 0)
            {
                return;
            }

            for (int i = 0; i < this.marcasCategoriaSeleccionada.Count; i++)
            {
                DashboardVentasMarcaCategoria marca = this.marcasCategoriaSeleccionada[i];
                decimal valor = this.ObtenerValorMarca(marca, this.criterioTortaSeleccionado);
                decimal porcentaje = valor / total;

                DataPoint point = new DataPoint();
                point.SetValueY((double)valor);
                point.Color = colores[i % colores.Length];
                point.LegendText = $"{marca.Marca} {porcentaje:P0} - {this.FormatearValorMarca(marca, this.criterioTortaSeleccionado)}";
                series.Points.Add(point);
            }
        }

        private decimal ObtenerValorMarca(DashboardVentasMarcaCategoria marca, CriterioTortaMarcas criterio)
        {
            return criterio == CriterioTortaMarcas.Items
                ? marca.CantidadVendida
                : marca.TotalFacturado;
        }

        private string FormatearValorMarca(DashboardVentasMarcaCategoria marca, CriterioTortaMarcas criterio)
        {
            return criterio == CriterioTortaMarcas.Items
                ? $"{marca.CantidadVendida} items"
                : FormatearImporteCorto(marca.TotalFacturado);
        }

        private string ObtenerNombreCriterio(CriterioTortaMarcas criterio)
        {
            return criterio == CriterioTortaMarcas.Items ? "items vendidos" : "ingresos";
        }

        private Label CrearEtiqueta(string texto, Point location, Size size, ContentAlignment alineacion)
        {
            return new Label
            {
                Text = texto,
                Location = location,
                Size = size,
                TextAlign = alineacion,
                AutoEllipsis = true,
            };
        }

        private static string FormatearImporte(decimal importe)
        {
            return importe.ToString("C0", CultureInfo.CurrentCulture);
        }

        private static string FormatearImporteCorto(decimal importe)
        {
            return importe.ToString("C0", CultureInfo.CurrentCulture);
        }

        private class CategoriaSeleccionada
        {
            public CategoriaSeleccionada(string categoria, CriterioTortaMarcas criterio)
            {
                this.Categoria = categoria;
                this.Criterio = criterio;
            }

            public string Categoria { get; }
            public CriterioTortaMarcas Criterio { get; }
        }

        private enum CriterioTortaMarcas
        {
            Ingresos,
            Items,
        }
    }
}

