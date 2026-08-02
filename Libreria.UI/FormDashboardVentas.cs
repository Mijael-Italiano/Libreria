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
            fechaMesAnalisis = ObtenerMesPredominanteSemana(fechaInicioSemana);
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

        private void DiaSemana_Click(object? sender, EventArgs e)
        {
            if (sender is Control control && control.Tag is int dia)
            {
                DateTime fecha = fechaInicioSemana.AddDays(dia);
                if (this.PerteneceMesAnalisis(fecha))
                {
                    new FormDashboardVentasDiarias(fecha).Show();
                }
            }
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
            Panel? panelGrafico = this.ObtenerPanelGraficoSemana();
            if (panelGrafico == null)
            {
                return;
            }

            decimal maximo = ventasPorDia.Select(dia => dia.TotalFacturado).DefaultIfEmpty(0).Max();
            int baseBarras = panelGrafico.Height - 40;
            int alturaMaxima = Math.Max(24, baseBarras - 30);
            int anchoSlot = Math.Max(1, panelGrafico.Width / 7);
            int anchoBarra = Math.Min(42, Math.Max(24, anchoSlot / 2));

            for (int i = 0; i < 7; i++)
            {
                DateTime fechaDia = fechaInicioSemana.AddDays(i);
                bool perteneceMes = this.PerteneceMesAnalisis(fechaDia);
                DashboardVentasDia ventaDia = ventasPorDia.FirstOrDefault(dia => dia.Fecha.Date == fechaDia.Date)
                    ?? new DashboardVentasDia { Fecha = fechaDia };

                Panel? barra = this.ObtenerControles<Panel>(panelGrafico).FirstOrDefault(panel => panel.Tag is int tag && tag == i);
                Label? valor = this.ObtenerControles<Label>(panelGrafico).FirstOrDefault(label => label.Tag is int tag && tag == i && label.Text.StartsWith("$", StringComparison.Ordinal));
                Label? dia = this.ObtenerControles<Label>(panelGrafico).FirstOrDefault(label => label.Tag is int tag && tag == i && !label.Text.StartsWith("$", StringComparison.Ordinal));
                int centroSlot = (anchoSlot * i) + (anchoSlot / 2);
                decimal totalDia = ventaDia.TotalFacturado;

                if (barra != null)
                {
                    barra.Width = anchoBarra;
                    barra.Left = centroSlot - (anchoBarra / 2);
                    barra.Top = baseBarras - 2;
                    barra.Height = 2;
                    barra.BackColor = perteneceMes ? Color.SteelBlue : Color.LightSteelBlue;
                    barra.Cursor = perteneceMes ? Cursors.Hand : Cursors.Default;
                    this.AjustarBarra(barra, totalDia, maximo, alturaMaxima);
                }

                if (valor != null && barra != null)
                {
                    valor.Text = FormatearImporteCorto(totalDia);
                    valor.ForeColor = perteneceMes ? SystemColors.ControlText : SystemColors.GrayText;
                    valor.Cursor = perteneceMes ? Cursors.Hand : Cursors.Default;
                    valor.Width = Math.Max(78, anchoSlot - 8);
                    this.AjustarValorSobreBarra(valor, barra);
                }

                if (dia != null)
                {
                    dia.Text = fechaDia.ToString("ddd dd", CultureInfo.CurrentCulture);
                    dia.ForeColor = perteneceMes ? SystemColors.ControlText : SystemColors.GrayText;
                    dia.Cursor = perteneceMes ? Cursors.Hand : Cursors.Default;
                    dia.Width = Math.Max(78, anchoSlot - 8);
                    dia.Left = centroSlot - (dia.Width / 2);
                    dia.Top = baseBarras + 6;
                }
            }
        }

        private Panel? ObtenerPanelGraficoSemana()
        {
            GroupBox? grupo = this.ObtenerControles<GroupBox>().FirstOrDefault(control => control.Text.Contains("semana", StringComparison.OrdinalIgnoreCase)
                && control.Text.Contains("Facturacion", StringComparison.OrdinalIgnoreCase));
            return grupo == null ? null : this.ObtenerControles<Panel>(grupo).FirstOrDefault();
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

        private void AjustarBarra(Panel barra, decimal valor, decimal maximo, int alturaMaxima)
        {
            int baseInferior = barra.Top + barra.Height;
            int altura = maximo <= 0 ? 2 : Math.Max(2, (int)(alturaMaxima * valor / maximo));
            barra.Height = altura;
            barra.Top = baseInferior - altura;
        }

        private void AjustarValorSobreBarra(Label valor, Panel barra)
        {
            const int margenSuperior = 4;
            const int separacionBarra = 4;

            valor.Left = barra.Left + (barra.Width / 2) - (valor.Width / 2);
            valor.Top = Math.Max(margenSuperior, barra.Top - valor.Height - separacionBarra);
            valor.BringToFront();
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



















