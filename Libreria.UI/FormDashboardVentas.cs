using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Libreria.Business;

namespace Libreria.UI
{
    public partial class FormDashboardVentas : Form
    {
        private readonly DashboardVentasBusiness dashboardVentasBusiness;
        private DateTime fechaInicioSemana;
        private DashboardVentasResumen? resumenSemana;
        private Panel? panelGraficoMarcas;
        private Panel? panelCategoriasItems;
        private Label? lblTituloGraficoMarcas;
        private List<DashboardVentasMarcaCategoria> marcasCategoriaSeleccionada;
        private CriterioTortaMarcas criterioTortaSeleccionado;

        public FormDashboardVentas()
        {
            InitializeComponent();
            this.dashboardVentasBusiness = new DashboardVentasBusiness();
            this.marcasCategoriaSeleccionada = new List<DashboardVentasMarcaCategoria>();
            this.criterioTortaSeleccionado = CriterioTortaMarcas.Ingresos;
            this.ConfigurarLayoutGraficos();
            fechaInicioSemana = ObtenerInicioSemana(DateTime.Today);
            MostrarSemana();
        }

        private void btnSemanaAnterior_Click(object? sender, EventArgs e)
        {
            fechaInicioSemana = fechaInicioSemana.AddDays(-7);
            MostrarSemana();
        }

        private void btnSemanaSiguiente_Click(object? sender, EventArgs e)
        {
            fechaInicioSemana = fechaInicioSemana.AddDays(7);
            MostrarSemana();
        }

        private void btnSemanaActual_Click(object? sender, EventArgs e)
        {
            fechaInicioSemana = ObtenerInicioSemana(DateTime.Today);
            MostrarSemana();
        }

        private void DiaSemana_Click(object? sender, EventArgs e)
        {
            if (sender is Control control && control.Tag is int dia)
            {
                new FormDashboardVentasDiarias(fechaInicioSemana.AddDays(dia)).Show();
            }
        }

        private static DateTime ObtenerInicioSemana(DateTime fecha)
        {
            int diferencia = ((int)fecha.DayOfWeek + 6) % 7;
            return fecha.Date.AddDays(-diferencia);
        }

        private void MostrarSemana()
        {
            try
            {
                DateTime fechaFinSemana = fechaInicioSemana.AddDays(6);
                this.resumenSemana = this.dashboardVentasBusiness.ObtenerResumen(fechaInicioSemana, fechaFinSemana);

                lblRangoSemana.Text = $"Semana del {fechaInicioSemana:dd/MM/yyyy} al {fechaFinSemana:dd/MM/yyyy}";
                this.MostrarResumen(this.resumenSemana);
                this.MostrarBarrasSemana(this.resumenSemana.VentasPorDia);
                this.MostrarCategoriasPorIngresos(this.resumenSemana.VentasPorCategoria);
                this.MostrarCategoriasPorItems(this.resumenSemana.CategoriasPorItems);
                this.LimpiarTortaMarcas("Seleccione una categoria del top para ver marcas.");
                lblEstado.Text = $"Datos actualizados para la semana seleccionada. Facturas: {this.resumenSemana.CantidadFacturas}.";
            }
            catch (Exception ex)
            {
                lblEstado.Text = "No se pudieron cargar los datos del dashboard.";
                MessageBox.Show(ex.Message, "Dashboard de ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarLayoutGraficos()
        {
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
                DashboardVentasDia ventaDia = ventasPorDia.FirstOrDefault(dia => dia.Fecha.Date == fechaInicioSemana.AddDays(i).Date)
                    ?? new DashboardVentasDia { Fecha = fechaInicioSemana.AddDays(i) };

                Panel? barra = this.ObtenerControles<Panel>(panelGrafico).FirstOrDefault(panel => panel.Tag is int tag && tag == i);
                Label? valor = this.ObtenerControles<Label>(panelGrafico).FirstOrDefault(label => label.Tag is int tag && tag == i && label.Text.StartsWith("$", StringComparison.Ordinal));
                Label? dia = this.ObtenerControles<Label>(panelGrafico).FirstOrDefault(label => label.Tag is int tag && tag == i && !label.Text.StartsWith("$", StringComparison.Ordinal));
                int centroSlot = (anchoSlot * i) + (anchoSlot / 2);

                if (barra != null)
                {
                    barra.Width = anchoBarra;
                    barra.Left = centroSlot - (anchoBarra / 2);
                    barra.Top = baseBarras - 2;
                    barra.Height = 2;
                    this.AjustarBarra(barra, ventaDia.TotalFacturado, maximo, alturaMaxima);
                }

                if (valor != null && barra != null)
                {
                    valor.Text = FormatearImporteCorto(ventaDia.TotalFacturado);
                    valor.Width = Math.Max(78, anchoSlot - 8);
                    this.AjustarValorSobreBarra(valor, barra);
                }

                if (dia != null)
                {
                    dia.Text = ventaDia.Fecha.ToString("ddd dd", CultureInfo.CurrentCulture);
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

        private void MostrarCategoriasPorIngresos(List<DashboardVentasCategoria> categorias)
        {
            Panel? panel = this.ObtenerPanelCategorias();
            if (panel == null)
            {
                return;
            }

            this.MostrarTopCategorias(
                panel,
                categorias.Take(5).ToList(),
                categoria => categoria.TotalFacturado,
                categoria => FormatearImporteCorto(categoria.TotalFacturado),
                "Sin ingresos en el periodo",
                CriterioTortaMarcas.Ingresos
            );
        }

        private void MostrarCategoriasPorItems(List<DashboardVentasCategoria> categorias)
        {
            if (this.panelCategoriasItems == null)
            {
                return;
            }

            this.MostrarTopCategorias(
                this.panelCategoriasItems,
                categorias.Take(5).ToList(),
                categoria => categoria.CantidadVendida,
                categoria => $"{categoria.CantidadVendida} items",
                "Sin items vendidos en el periodo",
                CriterioTortaMarcas.Items
            );
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

            this.panelGraficoMarcas?.Invalidate();
        }

        private void LimpiarTortaMarcas(string texto)
        {
            this.marcasCategoriaSeleccionada = new List<DashboardVentasMarcaCategoria>();
            this.criterioTortaSeleccionado = CriterioTortaMarcas.Ingresos;

            if (this.lblTituloGraficoMarcas != null)
            {
                this.lblTituloGraficoMarcas.Text = texto;
            }

            this.panelGraficoMarcas?.Invalidate();
        }

        private void panelGraficoMarcas_Paint(object? sender, PaintEventArgs e)
        {
            if (sender is not Panel panel)
            {
                return;
            }

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(panel.BackColor);

            if (this.marcasCategoriaSeleccionada.Count == 0)
            {
                TextRenderer.DrawText(
                    e.Graphics,
                    "Sin categoria seleccionada",
                    panel.Font,
                    panel.ClientRectangle,
                    SystemColors.GrayText,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
                );
                return;
            }

            decimal total = this.marcasCategoriaSeleccionada.Sum(marca => this.ObtenerValorMarca(marca, this.criterioTortaSeleccionado));
            if (total <= 0)
            {
                return;
            }

            Color[] colores =
            {
                Color.SeaGreen,
                Color.SteelBlue,
                Color.DarkOrange,
                Color.MediumPurple,
                Color.IndianRed,
                Color.Goldenrod,
            };

            int diametro = Math.Max(96, Math.Min(panel.Height - 22, 160));
            Rectangle rectanguloTorta = new Rectangle(18, (panel.Height - diametro) / 2, diametro, diametro);
            float anguloInicio = -90f;

            for (int i = 0; i < this.marcasCategoriaSeleccionada.Count; i++)
            {
                DashboardVentasMarcaCategoria marca = this.marcasCategoriaSeleccionada[i];
                float angulo = (float)(this.ObtenerValorMarca(marca, this.criterioTortaSeleccionado) / total * 360m);

                using SolidBrush brush = new SolidBrush(colores[i % colores.Length]);
                e.Graphics.FillPie(brush, rectanguloTorta, anguloInicio, angulo);
                anguloInicio += angulo;
            }

            int leyendaX = rectanguloTorta.Right + 18;
            int leyendaY = 18;
            int anchoLeyenda = Math.Max(120, panel.Width - leyendaX - 8);

            for (int i = 0; i < this.marcasCategoriaSeleccionada.Count && i < 6; i++)
            {
                DashboardVentasMarcaCategoria marca = this.marcasCategoriaSeleccionada[i];
                decimal porcentaje = this.ObtenerValorMarca(marca, this.criterioTortaSeleccionado) / total;

                using SolidBrush brush = new SolidBrush(colores[i % colores.Length]);
                e.Graphics.FillRectangle(brush, leyendaX, leyendaY + 4, 10, 10);

                string texto = $"{marca.Marca} {porcentaje:P0} - {this.FormatearValorMarca(marca, this.criterioTortaSeleccionado)}";
                TextRenderer.DrawText(
                    e.Graphics,
                    texto,
                    panel.Font,
                    new Rectangle(leyendaX + 16, leyendaY, anchoLeyenda - 16, 18),
                    panel.ForeColor,
                    TextFormatFlags.EndEllipsis | TextFormatFlags.Left
                );

                leyendaY += 22;
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
        private Panel? ObtenerPanelCategorias()
        {
            GroupBox? grupo = this.ObtenerControles<GroupBox>().FirstOrDefault(control => control.Text.Equals("Top 5 categorias por ingresos", StringComparison.OrdinalIgnoreCase));
            return grupo == null ? null : this.ObtenerControles<Panel>(grupo).FirstOrDefault();
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








