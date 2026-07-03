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
            Panel panelGrafico = this.panelGraficoHoras;

            List<DashboardVentasHora> ventasBloque = ventasPorHora
                .Where(hora => hora.Hora >= this.horaInicioBloque && hora.Hora <= this.horaInicioBloque + 5)
                .ToList();

            decimal maximo = ventasBloque.Select(hora => hora.TotalFacturado).DefaultIfEmpty(0).Max();
            List<Panel> barras = this.ObtenerControles<Panel>(panelGrafico).OrderBy(panel => panel.Left).ToList();
            List<Label> valores = this.ObtenerControles<Label>(panelGrafico)
                .Where(label => label.Text.StartsWith("$", StringComparison.Ordinal))
                .OrderBy(label => label.Left)
                .ToList();
            List<Label> horas = this.ObtenerControles<Label>(panelGrafico)
                .Where(label => !label.Text.StartsWith("$", StringComparison.Ordinal))
                .OrderBy(label => label.Left)
                .ToList();

            int baseBarras = panelGrafico.Height - 38;
            int alturaMaxima = Math.Max(20, baseBarras - 28);
            int anchoSlot = Math.Max(1, panelGrafico.Width / 6);
            int anchoBarra = Math.Min(42, Math.Max(24, anchoSlot / 2));

            for (int i = 0; i < 6; i++)
            {
                int horaReal = this.horaInicioBloque + i;
                DashboardVentasHora ventaHora = ventasPorHora.FirstOrDefault(hora => hora.Hora == horaReal)
                    ?? new DashboardVentasHora { Hora = horaReal };

                int centroSlot = (anchoSlot * i) + (anchoSlot / 2);

                if (i < barras.Count)
                {
                    barras[i].Width = anchoBarra;
                    barras[i].Left = centroSlot - (anchoBarra / 2);
                    barras[i].Top = baseBarras - 2;
                    barras[i].Height = 2;
                    this.AjustarBarra(barras[i], ventaHora.TotalFacturado, maximo, alturaMaxima);
                }

                if (i < valores.Count && i < barras.Count)
                {
                    valores[i].Text = FormatearImporteCorto(ventaHora.TotalFacturado);
                    valores[i].Width = Math.Max(78, anchoSlot - 8);
                    this.AjustarValorSobreBarra(valores[i], barras[i]);
                }

                if (i < horas.Count)
                {
                    horas[i].Text = horaReal.ToString("00");
                    horas[i].Width = Math.Max(78, anchoSlot - 8);
                    horas[i].Left = centroSlot - (horas[i].Width / 2);
                    horas[i].Top = baseBarras + 6;
                }
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
