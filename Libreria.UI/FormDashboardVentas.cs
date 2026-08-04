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
    public partial class FormDashboardVentas : Form
    {
        private readonly DashboardVentasBusiness dashboardVentasBusiness;
        private DateTime fechaInicioSemana;
        private DateTime fechaMesAnalisis;
        private DashboardVentasResumen? resumenSemana;
        private Chart chartMarcas = null!;
        private Chart chartClientes = null!;
        private Chart chartCategoriasIngresos = null!;
        private Chart chartCategoriasItems = null!;
        private Chart chartFacturacionSemana = null!;
        private Label? lblTituloGraficoMarcas;
        private List<DashboardVentasMarcaCategoria> marcasCategoriaSeleccionada;
        private CriterioTortaMarcas criterioTortaSeleccionado;

        public FormDashboardVentas() : this(DateTime.Today, new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1))
        {
        }

        public FormDashboardVentas(DateTime fechaReferencia, DateTime fechaMesAnalisis)
        {
            InitializeComponent();
            this.dashboardVentasBusiness = new DashboardVentasBusiness();
            this.marcasCategoriaSeleccionada = new List<DashboardVentasMarcaCategoria>();
            this.criterioTortaSeleccionado = CriterioTortaMarcas.Ingresos;
            this.ConfigurarLayoutGraficos();
            this.fechaInicioSemana = ObtenerInicioSemana(fechaReferencia);
            this.fechaMesAnalisis = new DateTime(fechaMesAnalisis.Year, fechaMesAnalisis.Month, 1);
            this.MostrarSemana();
        }

        private void btnSemanaAnterior_Click(object? sender, EventArgs e)
        {
            DateTime finSemana = fechaInicioSemana.AddDays(6);
            bool spansDosM = fechaInicioSemana.Month != finSemana.Month || fechaInicioSemana.Year != finSemana.Year;

            if (spansDosM)
            {
                DateTime mesPosterior = new DateTime(finSemana.Year, finSemana.Month, 1);
                if (fechaMesAnalisis == mesPosterior)
                {
                    fechaMesAnalisis = new DateTime(fechaInicioSemana.Year, fechaInicioSemana.Month, 1);
                    MostrarSemana();
                    return;
                }
            }

            fechaInicioSemana = fechaInicioSemana.AddDays(-7);
            DateTime nuevoFinSemana = fechaInicioSemana.AddDays(6);
            bool nuevaSemanaAbarcaDosMeses = fechaInicioSemana.Month != nuevoFinSemana.Month
                || fechaInicioSemana.Year != nuevoFinSemana.Year;

            fechaMesAnalisis = nuevaSemanaAbarcaDosMeses
                ? new DateTime(nuevoFinSemana.Year, nuevoFinSemana.Month, 1)
                : ObtenerMesPredominanteSemana(fechaInicioSemana);
            MostrarSemana();
        }

        private void btnSemanaSiguiente_Click(object? sender, EventArgs e)
        {
            DateTime finSemana = fechaInicioSemana.AddDays(6);
            bool spansDosM = fechaInicioSemana.Month != finSemana.Month || fechaInicioSemana.Year != finSemana.Year;

            if (spansDosM)
            {
                DateTime mesAnterior = new DateTime(fechaInicioSemana.Year, fechaInicioSemana.Month, 1);
                if (fechaMesAnalisis == mesAnterior)
                {
                    fechaMesAnalisis = new DateTime(finSemana.Year, finSemana.Month, 1);
                    MostrarSemana();
                    return;
                }
            }

            fechaInicioSemana = fechaInicioSemana.AddDays(7);
            fechaMesAnalisis = ObtenerMesPredominanteSemana(fechaInicioSemana);
            MostrarSemana();
        }

        private void btnSemanaActual_Click(object? sender, EventArgs e)
        {
            fechaInicioSemana = ObtenerInicioSemana(DateTime.Today);
            fechaMesAnalisis = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            MostrarSemana();
        }

        private static DateTime ObtenerInicioSemana(DateTime fecha)
        {
            int diferencia = ((int)fecha.DayOfWeek + 6) % 7;
            return fecha.Date.AddDays(-diferencia);
        }

        private static DateTime ObtenerMesPredominanteSemana(DateTime inicioSemana)
        {
            return new DateTime(inicioSemana.Year, inicioSemana.Month, 1);
        }

        private bool PerteneceMesAnalisis(DateTime fecha)
        {
            return fecha.Year == this.fechaMesAnalisis.Year && fecha.Month == this.fechaMesAnalisis.Month;
        }

        private void MostrarSemana()
        {
            try
            {
                DateTime fechaFinSemana = fechaInicioSemana.AddDays(6);
                DateTime inicioMes = this.fechaMesAnalisis;
                DateTime finMes = inicioMes.AddMonths(1).AddDays(-1);
                DateTime fechaDesdeAnalisis = fechaInicioSemana > inicioMes ? fechaInicioSemana : inicioMes;
                DateTime fechaHastaAnalisis = fechaFinSemana < finMes ? fechaFinSemana : finMes;
                DashboardVentasResumen resumenVisualSemana = this.dashboardVentasBusiness.ObtenerResumen(fechaInicioSemana, fechaFinSemana);
                this.resumenSemana = this.dashboardVentasBusiness.ObtenerResumen(fechaDesdeAnalisis, fechaHastaAnalisis);

                lblRangoSemana.Text = $"Semana del {fechaInicioSemana:dd/MM/yyyy} al {fechaFinSemana:dd/MM/yyyy} - Analiza {fechaDesdeAnalisis:dd/MM/yyyy} al {fechaHastaAnalisis:dd/MM/yyyy}";
                this.MostrarResumen(this.resumenSemana);
                this.MostrarBarrasSemana(resumenVisualSemana.VentasPorDia);
                this.MostrarClientesPorIngresos(this.resumenSemana.ClientesPorIngresos);
                this.MostrarCategoriasPorIngresos(this.resumenSemana.VentasPorCategoria);
                this.MostrarCategoriasPorItems(this.resumenSemana.CategoriasPorItems);
                this.LimpiarTortaMarcas("Seleccione una categoria del top para ver marcas.");
                lblEstado.Text = string.Empty;
            }
            catch (Exception ex)
            {
                lblEstado.Text = "No se pudieron cargar los datos del dashboard.";
                MessageBox.Show(ex.Message, "Dashboard de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarLayoutGraficos()
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

            ChartArea areaClientes = new ChartArea("clientes");
            areaClientes.AxisY.LabelStyle.Enabled = false;
            areaClientes.AxisY.MajorGrid.Enabled = false;
            areaClientes.AxisX.LabelStyle.Font = new Font("Segoe UI", 7.5F);
            areaClientes.AxisX.MajorGrid.Enabled = false;
            areaClientes.AxisX.Interval = 1;
            this.chartClientes.ChartAreas.Add(areaClientes);

            Series seriesClientes = new Series("clientes");
            seriesClientes.ChartType = SeriesChartType.Bar;
            seriesClientes.Color = Color.SteelBlue;
            seriesClientes.Font = new Font("Segoe UI", 7.5F);
            seriesClientes["PointWidth"] = "0.5";
            this.chartClientes.Series.Add(seriesClientes);

            Title tituloClientes = new Title(string.Empty, Docking.Top, new Font("Segoe UI", 8.5F), Color.Gray)
            {
                Name = "tituloClientes",
                DockedToChartArea = "clientes",
            };
            this.chartClientes.Titles.Add(tituloClientes);

            this.chartClientes.BackColor = SystemColors.Window;

            this.ConfigurarChartTopCategorias(this.chartCategoriasIngresos, "categoriasIngresos", CriterioTortaMarcas.Ingresos);
            this.ConfigurarChartTopCategorias(this.chartCategoriasItems, "categoriasItems", CriterioTortaMarcas.Items);

            ChartArea areaFacturacionSemana = new ChartArea("facturacionSemana");
            areaFacturacionSemana.AxisY.LabelStyle.Enabled = false;
            areaFacturacionSemana.AxisY.MajorGrid.Enabled = false;
            areaFacturacionSemana.AxisX.MajorGrid.Enabled = false;
            areaFacturacionSemana.AxisX.Interval = 1;
            areaFacturacionSemana.AxisX.LabelStyle.Font = new Font("Segoe UI", 7.5F);
            this.chartFacturacionSemana.ChartAreas.Add(areaFacturacionSemana);

            Series seriesFacturacionSemana = new Series("facturacionSemana");
            seriesFacturacionSemana.ChartType = SeriesChartType.Column;
            seriesFacturacionSemana.Font = new Font("Segoe UI", 7.5F);
            seriesFacturacionSemana["PointWidth"] = "0.5";
            this.chartFacturacionSemana.Series.Add(seriesFacturacionSemana);

            this.chartFacturacionSemana.BackColor = SystemColors.Window;
            this.chartFacturacionSemana.Cursor = Cursors.Hand;
            this.chartFacturacionSemana.MouseClick += ChartFacturacionSemana_MouseClick;
        }

        private void ChartFacturacionSemana_MouseClick(object? sender, MouseEventArgs e)
        {
            if (sender is not Chart chart)
            {
                return;
            }

            HitTestResult resultado = chart.HitTest(e.X, e.Y);

            if (resultado.ChartElementType != ChartElementType.DataPoint || resultado.PointIndex < 0)
            {
                return;
            }

            DateTime fecha = fechaInicioSemana.AddDays(resultado.PointIndex);

            if (this.PerteneceMesAnalisis(fecha))
            {
                new FormDashboardVentasDiarias(fecha).Show();
            }
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

        private void MostrarResumen(DashboardVentasResumen resumen)
        {
            GroupBox? grupoResumen = this.ObtenerControles<GroupBox>().FirstOrDefault(grupo => grupo.Text == "Resumen semanal");
            if (grupoResumen == null)
            {
                return;
            }

            List<Label> valores = this.ObtenerControles<Label>(grupoResumen)
                .Where(label => label.Font.Bold && label.Font.Size >= 13)
                .OrderBy(label => label.Left)
                .ToList();

            if (valores.Count >= 3)
            {
                valores[0].Text = FormatearImporte(resumen.TotalFacturado);
                valores[1].Text = resumen.CantidadItemsVendidos.ToString();
                valores[2].Text = resumen.CantidadFacturas.ToString();
            }
        }

        private void MostrarBarrasSemana(List<DashboardVentasDia> ventasPorDia)
        {
            Series series = this.chartFacturacionSemana.Series[0];
            series.Points.Clear();

            for (int i = 0; i < 7; i++)
            {
                DateTime fechaDia = fechaInicioSemana.AddDays(i);
                bool perteneceMes = this.PerteneceMesAnalisis(fechaDia);
                DashboardVentasDia ventaDia = ventasPorDia.FirstOrDefault(dia => dia.Fecha.Date == fechaDia.Date)
                    ?? new DashboardVentasDia { Fecha = fechaDia };

                int puntoIndice = series.Points.AddXY(i + 1, (double)ventaDia.TotalFacturado);
                series.Points[puntoIndice].AxisLabel = fechaDia.ToString("ddd dd", CultureInfo.CurrentCulture);
                series.Points[puntoIndice].Label = FormatearImporteCorto(ventaDia.TotalFacturado);
                series.Points[puntoIndice].Color = perteneceMes ? Color.SteelBlue : Color.LightSteelBlue;
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
                "Sin ingresos en el periodo"
            );
        }

        private void MostrarCategoriasPorItems(List<DashboardVentasCategoria> categorias)
        {
            this.MostrarTopCategorias(
                this.chartCategoriasItems,
                categorias.Take(5).ToList(),
                categoria => categoria.CantidadVendida,
                categoria => $"{categoria.CantidadVendida} items",
                "Sin items vendidos en el periodo"
            );
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
            if (this.resumenSemana == null)
            {
                return;
            }

            this.marcasCategoriaSeleccionada = this.resumenSemana.VentasPorMarcaCategoria
                .Where(marca => marca.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(marca => this.ObtenerValorMarca(marca, criterio))
                .ToList();

            if (this.lblTituloGraficoMarcas != null)
            {
                this.lblTituloGraficoMarcas.Text = $"Marcas de {categoria} por {this.ObtenerNombreCriterio(criterio)}";
            }

            this.ActualizarChartMarcas();
        }

        private void LimpiarTortaMarcas(string texto)
        {
            this.marcasCategoriaSeleccionada = new List<DashboardVentasMarcaCategoria>();
            this.criterioTortaSeleccionado = CriterioTortaMarcas.Ingresos;

            if (this.lblTituloGraficoMarcas != null)
            {
                this.lblTituloGraficoMarcas.Text = texto;
            }

            this.ActualizarChartMarcas();
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

        private enum CriterioTortaMarcas
        {
            Ingresos,
            Items,
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

        private List<T> ObtenerControles<T>() where T : Control
        {
            return this.ObtenerControles<T>(this);
        }

        private List<T> ObtenerControles<T>(Control contenedor) where T : Control
        {
            List<T> controles = new List<T>();

            foreach (Control control in contenedor.Controls)
            {
                if (control is T controlTipado)
                {
                    controles.Add(controlTipado);
                }

                controles.AddRange(this.ObtenerControles<T>(control));
            }

            return controles;
        }

        private static string FormatearImporte(decimal importe)
        {
            return importe.ToString("C0", CultureInfo.CurrentCulture);
        }

        private static string FormatearImporteCorto(decimal importe)
        {
            return importe.ToString("C0", CultureInfo.CurrentCulture);
        }
    }
}



















