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
        private Label? lblTituloGraficoMarcas;
        private List<DashboardVentasMarcaCategoria> marcasCategoriaSeleccionada;

        public FormDashboardVentas()
        {
            InitializeComponent();
            this.dashboardVentasBusiness = new DashboardVentasBusiness();
            this.marcasCategoriaSeleccionada = new List<DashboardVentasMarcaCategoria>();
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
                this.MostrarCategorias(this.resumenSemana.VentasPorCategoria);
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
            GroupBox? grupoVentasSemana = this.ObtenerControles<GroupBox>()
                .FirstOrDefault(control => control.Text.Contains("semana", StringComparison.OrdinalIgnoreCase)
                    && control.Text.Contains("Facturacion", StringComparison.OrdinalIgnoreCase));
            Panel? panelSemana = grupoVentasSemana == null ? null : this.ObtenerControles<Panel>(grupoVentasSemana).FirstOrDefault();
            GroupBox? grupoCategorias = this.ObtenerControles<GroupBox>()
                .FirstOrDefault(control => control.Text.Contains("categoria", StringComparison.OrdinalIgnoreCase));
            Panel? panelCategorias = grupoCategorias == null ? null : this.ObtenerControles<Panel>(grupoCategorias).FirstOrDefault();
            Button? botonDetalle = grupoCategorias == null ? null : this.ObtenerControles<Button>(grupoCategorias).FirstOrDefault();

            if (grupoVentasSemana != null)
            {
                grupoVentasSemana.Size = new Size(grupoVentasSemana.Width, 270);
            }

            if (panelSemana != null)
            {
                panelSemana.Size = new Size(panelSemana.Width, 220);
            }

            if (grupoCategorias != null)
            {
                grupoCategorias.Size = new Size(grupoCategorias.Width, 210);
            }

            if (panelCategorias != null)
            {
                panelCategorias.Size = new Size(panelCategorias.Width, 150);
            }

            if (botonDetalle != null)
            {
                botonDetalle.Visible = false;
            }

            if (grupoCategorias == null)
            {
                return;
            }

            GroupBox grupoMarcas = new GroupBox
            {
                Text = "Marcas de la categoria seleccionada",
                Location = new Point(grupoCategorias.Left, grupoCategorias.Bottom + 10),
                Size = new Size(grupoCategorias.Width, 190),
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
            };

            this.lblTituloGraficoMarcas = new Label
            {
                AutoEllipsis = true,
                Location = new Point(12, 20),
                Size = new Size(grupoMarcas.Width - 24, 20),
                Text = "Seleccione una categoria",
            };

            this.panelGraficoMarcas = new Panel
            {
                Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                BackColor = SystemColors.Window,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(18, 46),
                Size = new Size(grupoMarcas.Width - 36, 122),
            };
            this.panelGraficoMarcas.Paint += panelGraficoMarcas_Paint;

            grupoMarcas.Controls.Add(this.lblTituloGraficoMarcas);
            grupoMarcas.Controls.Add(this.panelGraficoMarcas);
            this.Controls.Add(grupoMarcas);
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

            if (valores.Count >= 2)
            {
                valores[0].Text = FormatearImporte(resumen.TotalFacturado);
                valores[1].Text = resumen.CantidadFacturas.ToString();
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

        private void MostrarCategorias(List<DashboardVentasCategoria> categorias)
        {
            Panel? panel = this.ObtenerPanelCategorias();
            if (panel == null)
            {
                return;
            }

            panel.Controls.Clear();
            List<DashboardVentasCategoria> topCategorias = categorias.Take(5).ToList();

            if (topCategorias.Count == 0)
            {
                panel.Controls.Add(this.CrearEtiqueta("Sin ventas en el periodo", new Point(20, 58), new Size(panel.Width - 40, 30), ContentAlignment.MiddleCenter));
                this.LimpiarTortaMarcas("Sin categorias con ventas.");
                return;
            }

            decimal maximo = topCategorias.Max(categoria => categoria.TotalFacturado);
            int y = 12;

            foreach (DashboardVentasCategoria categoria in topCategorias)
            {
                Label nombre = this.CrearEtiqueta(categoria.Categoria, new Point(14, y), new Size(155, 18), ContentAlignment.MiddleLeft);
                Label importe = this.CrearEtiqueta(FormatearImporteCorto(categoria.TotalFacturado), new Point(panel.Width - 106, y), new Size(90, 18), ContentAlignment.MiddleRight);
                Panel barra = new Panel
                {
                    BackColor = Color.SeaGreen,
                    Cursor = Cursors.Hand,
                    Location = new Point(14, y + 20),
                    Size = new Size(maximo == 0 ? 1 : Math.Max(1, (int)((panel.Width - 30) * categoria.TotalFacturado / maximo)), 8),
                };

                this.ConfigurarClickCategoria(nombre, categoria.Categoria);
                this.ConfigurarClickCategoria(importe, categoria.Categoria);
                this.ConfigurarClickCategoria(barra, categoria.Categoria);

                panel.Controls.Add(nombre);
                panel.Controls.Add(importe);
                panel.Controls.Add(barra);
                y += 27;
            }
        }

        private void ConfigurarClickCategoria(Control control, string categoria)
        {
            control.Cursor = Cursors.Hand;
            control.Tag = categoria;
            control.Click += Categoria_Click;
        }

        private void Categoria_Click(object? sender, EventArgs e)
        {
            if (sender is Control control && control.Tag is string categoria)
            {
                this.MostrarTortaMarcas(categoria);
            }
        }

        private void MostrarTortaMarcas(string categoria)
        {
            if (this.resumenSemana == null)
            {
                return;
            }

            this.marcasCategoriaSeleccionada = this.resumenSemana.VentasPorMarcaCategoria
                .Where(marca => marca.Categoria.Equals(categoria, StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(marca => marca.TotalFacturado)
                .ToList();

            if (this.lblTituloGraficoMarcas != null)
            {
                this.lblTituloGraficoMarcas.Text = $"Marcas de {categoria}";
            }

            this.panelGraficoMarcas?.Invalidate();
        }

        private void LimpiarTortaMarcas(string texto)
        {
            this.marcasCategoriaSeleccionada = new List<DashboardVentasMarcaCategoria>();

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

            decimal total = this.marcasCategoriaSeleccionada.Sum(marca => marca.TotalFacturado);
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

            int diametro = Math.Max(64, Math.Min(panel.Height - 18, 112));
            Rectangle rectanguloTorta = new Rectangle(14, (panel.Height - diametro) / 2, diametro, diametro);
            float anguloInicio = -90f;

            for (int i = 0; i < this.marcasCategoriaSeleccionada.Count; i++)
            {
                DashboardVentasMarcaCategoria marca = this.marcasCategoriaSeleccionada[i];
                float angulo = (float)(marca.TotalFacturado / total * 360m);

                using SolidBrush brush = new SolidBrush(colores[i % colores.Length]);
                e.Graphics.FillPie(brush, rectanguloTorta, anguloInicio, angulo);
                anguloInicio += angulo;
            }

            int leyendaX = rectanguloTorta.Right + 16;
            int leyendaY = 12;
            int anchoLeyenda = Math.Max(90, panel.Width - leyendaX - 8);

            for (int i = 0; i < this.marcasCategoriaSeleccionada.Count && i < 5; i++)
            {
                DashboardVentasMarcaCategoria marca = this.marcasCategoriaSeleccionada[i];
                decimal porcentaje = marca.TotalFacturado / total;

                using SolidBrush brush = new SolidBrush(colores[i % colores.Length]);
                e.Graphics.FillRectangle(brush, leyendaX, leyendaY + 4, 10, 10);

                string texto = $"{marca.Marca} {porcentaje:P0}";
                TextRenderer.DrawText(
                    e.Graphics,
                    texto,
                    panel.Font,
                    new Rectangle(leyendaX + 16, leyendaY, anchoLeyenda - 16, 18),
                    panel.ForeColor,
                    TextFormatFlags.EndEllipsis | TextFormatFlags.Left
                );

                leyendaY += 20;
            }
        }

        private Panel? ObtenerPanelCategorias()
        {
            GroupBox? grupo = this.ObtenerControles<GroupBox>().FirstOrDefault(control => control.Text.Contains("Categoria", StringComparison.OrdinalIgnoreCase));
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
