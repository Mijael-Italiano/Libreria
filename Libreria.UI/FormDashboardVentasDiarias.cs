using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Libreria.Business;
using Libreria.Entity;

namespace Libreria.UI
{
    public partial class FormDashboardVentasDiarias : Form
    {
        private readonly DashboardVentasBusiness dashboardVentasBusiness;
        private DateTime fecha;
        private int horaInicioBloque;
        private DashboardVentasResumen? resumenDia;
        private List<DashboardVentasMarcaCategoria> marcasCategoriaSeleccionada;
        private CriterioTortaMarcas criterioTortaSeleccionado;

        public FormDashboardVentasDiarias() : this(DateTime.Today)
        {
        }

        public FormDashboardVentasDiarias(DateTime fecha)
        {
            InitializeComponent();
            this.dashboardVentasBusiness = new DashboardVentasBusiness();
            this.fecha = fecha.Date;
            this.horaInicioBloque = 6;
            this.marcasCategoriaSeleccionada = new List<DashboardVentasMarcaCategoria>();
            this.criterioTortaSeleccionado = CriterioTortaMarcas.Ingresos;
            this.ConfigurarChartMarcas();
            this.ConfigurarChartHoras();
            this.ConfigurarChartClientes();
            this.ConfigurarChartTopCategorias(this.chartCategoriasIngresos, "categoriasIngresos", CriterioTortaMarcas.Ingresos);
            this.ConfigurarChartTopCategorias(this.chartCategoriasItems, "categoriasItems", CriterioTortaMarcas.Items);
            this.MostrarDia();
        }

        private void btnDiaAnterior_Click(object? sender, EventArgs e)
        {
            this.fecha = this.fecha.AddDays(-1);
            this.horaInicioBloque = 6;
            this.MostrarDia();
        }

        private void btnDiaSiguiente_Click(object? sender, EventArgs e)
        {
            this.fecha = this.fecha.AddDays(1);
            this.horaInicioBloque = 6;
            this.MostrarDia();
        }

        private void btnDiaActual_Click(object? sender, EventArgs e)
        {
            this.fecha = DateTime.Today;
            this.horaInicioBloque = 6;
            this.MostrarDia();
        }

        private void btnBloqueAnterior_Click(object? sender, EventArgs e)
        {
            if (this.horaInicioBloque > 0)
            {
                this.horaInicioBloque -= 6;
                this.MostrarBloqueHorario();
            }
        }

        private void btnBloqueSiguiente_Click(object? sender, EventArgs e)
        {
            if (this.horaInicioBloque < 18)
            {
                this.horaInicioBloque += 6;
                this.MostrarBloqueHorario();
            }
        }

        private void MostrarDia()
        {
            try
            {
                this.resumenDia = this.dashboardVentasBusiness.ObtenerResumen(this.fecha, this.fecha);
                this.lblRangoDia.Text = this.fecha.ToString("dddd dd/MM/yyyy", CultureInfo.CurrentCulture);
                this.MostrarResumen(this.resumenDia);
                this.MostrarBloqueHorario();
                this.MostrarClientesPorIngresos(this.resumenDia.ClientesPorIngresos);
                this.MostrarCategoriasPorIngresos(this.resumenDia.VentasPorCategoria);
                this.MostrarCategoriasPorItems(this.resumenDia.CategoriasPorItems);
                this.LimpiarTortaMarcas("Seleccione una categoria del top para ver marcas.");
                this.lblEstado.Text = string.Empty;
            }
            catch (Exception ex)
            {
                this.lblEstado.Text = "No se pudieron cargar los datos del dia.";
                MessageBox.Show(ex.Message, "Dashboard de ventas diarias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarBloqueHorario()
        {
            int horaFin = this.horaInicioBloque + 5;
            this.lblRangoHorario.Text = $"Horas {this.horaInicioBloque:00}:00 a {horaFin:00}:59";
            this.btnBloqueAnterior.Enabled = this.horaInicioBloque > 0;
            this.btnBloqueSiguiente.Enabled = this.horaInicioBloque < 18;

            if (this.resumenDia != null)
            {
                this.MostrarBarrasHoras(this.resumenDia.VentasPorHora);
            }
        }

        private void MostrarResumen(DashboardVentasResumen resumen)
        {
            this.lblTotalValor.Text = FormatearImporte(resumen.TotalFacturado);
            this.lblItemsValor.Text = resumen.CantidadItemsVendidos.ToString();
            this.lblFacturasValor.Text = resumen.CantidadFacturas.ToString();
        }

        private void MostrarBarrasHoras(List<DashboardVentasHora> ventasPorHora)
        {
            Series series = this.chartHoras.Series[0];
            series.Points.Clear();

            for (int i = 0; i < 6; i++)
            {
                int horaReal = this.horaInicioBloque + i;
                DashboardVentasHora ventaHora = ventasPorHora.FirstOrDefault(hora => hora.Hora == horaReal)
                    ?? new DashboardVentasHora { Hora = horaReal };

                int puntoIndice = series.Points.AddXY(i + 1, (double)ventaHora.TotalFacturado);
                series.Points[puntoIndice].AxisLabel = horaReal.ToString("00");
                series.Points[puntoIndice].Label = FormatearImporteCorto(ventaHora.TotalFacturado);
            }
        }

        private void MostrarClientesPorIngresos(List<DashboardVentasCliente> clientes)
        {
            Series series = this.chartClientes.Series["clientes"];
            series.Points.Clear();

            List<DashboardVentasCliente> topClientes = clientes.Take(5).ToList();

            if (topClientes.Count == 0)
            {
                this.chartClientes.Titles["tituloClientes"].Text = "Sin clientes con compras en el periodo";
                return;
            }

            this.chartClientes.Titles["tituloClientes"].Text = string.Empty;

            for (int indice = topClientes.Count - 1; indice >= 0; indice--)
            {
                DashboardVentasCliente cliente = topClientes[indice];
                string textoCompras = cliente.CantidadCompras == 1 ? "1 asistencia" : $"{cliente.CantidadCompras} asistencias";

                int puntoIndice = series.Points.AddXY(series.Points.Count + 1, (double)cliente.TotalFacturado);
                series.Points[puntoIndice].AxisLabel = cliente.Cliente;
                series.Points[puntoIndice].Label = FormatearImporteCorto(cliente.TotalFacturado);
                series.Points[puntoIndice].ToolTip = $"{cliente.Cliente}: {FormatearImporteCorto(cliente.TotalFacturado)} ({textoCompras})";
            }
        }

        private void MostrarCategoriasPorIngresos(List<DashboardVentasCategoria> categorias)
        {
            this.MostrarTopCategorias(
                this.chartCategoriasIngresos,
                categorias.Take(5).ToList(),
                categoria => categoria.TotalFacturado,
                categoria => FormatearImporteCorto(categoria.TotalFacturado),
                "Sin ingresos en el periodo");
        }

        private void MostrarCategoriasPorItems(List<DashboardVentasCategoria> categorias)
        {
            this.MostrarTopCategorias(
                this.chartCategoriasItems,
                categorias.Take(5).ToList(),
                categoria => categoria.CantidadVendida,
                categoria => $"{categoria.CantidadVendida} items",
                "Sin items vendidos en el periodo");
        }

        private void MostrarTopCategorias(
            Chart chart,
            List<DashboardVentasCategoria> categorias,
            Func<DashboardVentasCategoria, decimal> obtenerValor,
            Func<DashboardVentasCategoria, string> formatearValor,
            string mensajeSinDatos)
        {
            Series series = chart.Series[0];
            series.Points.Clear();

            if (categorias.Count == 0)
            {
                chart.Titles[0].Text = mensajeSinDatos;
                return;
            }

            chart.Titles[0].Text = string.Empty;

            for (int indice = categorias.Count - 1; indice >= 0; indice--)
            {
                DashboardVentasCategoria categoria = categorias[indice];

                int puntoIndice = series.Points.AddXY(series.Points.Count + 1, (double)obtenerValor(categoria));
                series.Points[puntoIndice].AxisLabel = categoria.Categoria;
                series.Points[puntoIndice].Label = formatearValor(categoria);
            }
        }

        private void MostrarTortaMarcas(string categoria, CriterioTortaMarcas criterio)
        {
            if (this.resumenDia == null)
            {
                return;
            }

            this.criterioTortaSeleccionado = criterio;
            this.marcasCategoriaSeleccionada = this.resumenDia.VentasPorMarcaCategoria
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

        private void ConfigurarChartHoras()
        {
            ChartArea area = new ChartArea("horas");
            area.AxisY.LabelStyle.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 7.5F);
            this.chartHoras.ChartAreas.Add(area);

            Series series = new Series("horas");
            series.ChartType = SeriesChartType.Column;
            series.Color = Color.SeaGreen;
            series.Font = new Font("Segoe UI", 7.5F);
            series["PointWidth"] = "0.5";
            this.chartHoras.Series.Add(series);

            this.chartHoras.BackColor = SystemColors.Window;
        }

        private void ConfigurarChartClientes()
        {
            ChartArea area = new ChartArea("clientes");
            area.AxisY.LabelStyle.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 7.5F);
            this.chartClientes.ChartAreas.Add(area);

            Series series = new Series("clientes");
            series.ChartType = SeriesChartType.Bar;
            series.Color = Color.SteelBlue;
            series.Font = new Font("Segoe UI", 7.5F);
            series["PointWidth"] = "0.5";
            this.chartClientes.Series.Add(series);

            Title titulo = new Title(string.Empty, Docking.Top, new Font("Segoe UI", 8.5F), Color.Gray)
            {
                Name = "tituloClientes",
                DockedToChartArea = "clientes",
            };
            this.chartClientes.Titles.Add(titulo);

            this.chartClientes.BackColor = SystemColors.Window;
        }

        private void ConfigurarChartTopCategorias(Chart chart, string nombreArea, CriterioTortaMarcas criterio)
        {
            ChartArea area = new ChartArea(nombreArea);
            area.AxisY.LabelStyle.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisX.Interval = 1;
            area.AxisX.LabelStyle.Font = new Font("Segoe UI", 7.5F);
            chart.ChartAreas.Add(area);

            Series series = new Series(nombreArea);
            series.ChartType = SeriesChartType.Bar;
            series.Color = Color.SeaGreen;
            series.Font = new Font("Segoe UI", 7.5F);
            series["PointWidth"] = "0.5";
            chart.Series.Add(series);

            Title titulo = new Title(string.Empty, Docking.Top, new Font("Segoe UI", 8.5F), Color.Gray)
            {
                Name = "titulo" + nombreArea,
                DockedToChartArea = nombreArea,
            };
            chart.Titles.Add(titulo);

            chart.BackColor = SystemColors.Window;
            chart.Cursor = Cursors.Hand;
            chart.Tag = criterio;
            chart.MouseClick += ChartTopCategorias_MouseClick;
        }

        private void ChartTopCategorias_MouseClick(object? sender, MouseEventArgs e)
        {
            if (sender is not Chart chart || chart.Tag is not CriterioTortaMarcas criterio)
            {
                return;
            }

            HitTestResult resultado = chart.HitTest(e.X, e.Y);

            if (resultado.ChartElementType != ChartElementType.DataPoint || resultado.PointIndex < 0 || resultado.Series == null)
            {
                return;
            }

            string categoria = resultado.Series.Points[resultado.PointIndex].AxisLabel;
            this.MostrarTortaMarcas(categoria, criterio);
        }

        private void ActualizarChartMarcas()
        {
            Series series = this.chartMarcas.Series["marcas"];
            series.Points.Clear();
            if (this.marcasCategoriaSeleccionada.Count == 0) return;
            Color[] colores = { Color.SeaGreen, Color.SteelBlue, Color.DarkOrange, Color.MediumPurple, Color.IndianRed, Color.Goldenrod };
            decimal total = this.marcasCategoriaSeleccionada.Sum(marca => this.ObtenerValorMarca(marca, this.criterioTortaSeleccionado));
            if (total <= 0) return;
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

        private static string FormatearImporte(decimal importe)
        {
            return importe.ToString("C0", CultureInfo.CurrentCulture);
        }

        private static string FormatearImporteCorto(decimal importe)
        {
            return importe.ToString("C0", CultureInfo.CurrentCulture);
        }

        private enum CriterioTortaMarcas
        {
            Ingresos,
            Items,
        }
    }
}
