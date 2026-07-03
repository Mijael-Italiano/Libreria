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
    public partial class FormDashboardVentasDiarias : Form
    {
        private readonly DashboardVentasBusiness dashboardVentasBusiness;
        private readonly DateTime fecha;
        private int horaInicioBloque;
        private DashboardVentasResumen? resumenDia;
        private Panel? panelGraficoMarcas;
        private Label? lblTituloGraficoMarcas;
        private List<DashboardVentasMarcaCategoria> marcasCategoriaSeleccionada;

        public FormDashboardVentasDiarias() : this(DateTime.Today)
        {
        }

        public FormDashboardVentasDiarias(DateTime fecha)
        {
            InitializeComponent();
            this.dashboardVentasBusiness = new DashboardVentasBusiness();
            this.fecha = fecha.Date;
            this.horaInicioBloque = 0;
            this.marcasCategoriaSeleccionada = new List<DashboardVentasMarcaCategoria>();
            this.ConfigurarLayoutGraficos();
            MostrarDia();
            MostrarBloqueHorario();
        }

        private void btnBloqueAnterior_Click(object? sender, EventArgs e)
        {
            if (horaInicioBloque > 0)
            {
                horaInicioBloque -= 6;
                MostrarBloqueHorario();
            }
        }

        private void btnBloqueSiguiente_Click(object? sender, EventArgs e)
        {
            if (horaInicioBloque < 18)
            {
                horaInicioBloque += 6;
                MostrarBloqueHorario();
            }
        }

        private void btnPrimerBloque_Click(object? sender, EventArgs e)
        {
            horaInicioBloque = 0;
            MostrarBloqueHorario();
        }

        private void MostrarDia()
        {
            try
            {
                this.resumenDia = this.dashboardVentasBusiness.ObtenerResumen(fecha, fecha);
                lblDia.Text = $"Ventas del dia {fecha:dd/MM/yyyy}";
                this.MostrarResumen(this.resumenDia);
                this.MostrarCategorias(this.resumenDia.VentasPorCategoria);
                this.LimpiarTortaMarcas("Seleccione una categoria del top para ver marcas.");
            }
            catch (Exception ex)
            {
                lblEstado.Text = "No se pudieron cargar los datos del dia.";
                MessageBox.Show(ex.Message, "Dashboard de ventas diarias", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarBloqueHorario()
        {
            int horaFin = horaInicioBloque + 5;
            lblRangoHorario.Text = $"Horas {horaInicioBloque:00}:00 a {horaFin:00}:59";
            btnBloqueAnterior.Enabled = horaInicioBloque > 0;
            btnBloqueSiguiente.Enabled = horaInicioBloque < 18;

            if (this.resumenDia == null)
            {
                this.resumenDia = this.dashboardVentasBusiness.ObtenerResumen(fecha, fecha);
            }

            this.MostrarBarrasHoras(this.resumenDia.VentasPorHora);
            lblEstado.Text = $"Datos actualizados para el dia seleccionado. Facturas: {this.resumenDia.CantidadFacturas}.";
        }

        private void ConfigurarLayoutGraficos()
        {
            GroupBox? grupoHoras = this.ObtenerControles<GroupBox>()
                .FirstOrDefault(control => control.Text.Contains("Hora", StringComparison.OrdinalIgnoreCase));
            Panel? panelHoras = grupoHoras == null ? null : this.ObtenerControles<Panel>(grupoHoras).FirstOrDefault();
            GroupBox? grupoCategorias = this.ObtenerControles<GroupBox>()
                .FirstOrDefault(control => control.Text.Contains("categoria", StringComparison.OrdinalIgnoreCase));
            Panel? panelCategorias = grupoCategorias == null ? null : this.ObtenerControles<Panel>(grupoCategorias).FirstOrDefault();

            if (grupoHoras != null)
            {
                grupoHoras.Size = new Size(grupoHoras.Width, 220);
            }

            if (panelHoras != null)
            {
                panelHoras.Size = new Size(panelHoras.Width, 172);
            }

            if (grupoCategorias != null)
            {
                grupoCategorias.Size = new Size(grupoCategorias.Width, 178);
            }

            if (panelCategorias != null)
            {
                panelCategorias.Size = new Size(panelCategorias.Width, 130);
            }

            if (grupoCategorias == null)
            {
                return;
            }

            GroupBox grupoMarcas = new GroupBox
            {
                Text = "Marcas de la categoria seleccionada",
                Location = new Point(grupoCategorias.Left, grupoCategorias.Bottom + 10),
                Size = new Size(grupoCategorias.Width, 140),
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
                Location = new Point(18, 44),
                Size = new Size(grupoMarcas.Width - 36, 78),
            };
            this.panelGraficoMarcas.Paint += panelGraficoMarcas_Paint;

            grupoMarcas.Controls.Add(this.lblTituloGraficoMarcas);
            grupoMarcas.Controls.Add(this.panelGraficoMarcas);
            this.Controls.Add(grupoMarcas);
        }

        private void MostrarResumen(DashboardVentasResumen resumen)
        {
            GroupBox? grupoResumen = this.ObtenerControles<GroupBox>().FirstOrDefault(grupo => grupo.Text.Contains("Resumen", StringComparison.OrdinalIgnoreCase));
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

        private void MostrarBarrasHoras(List<DashboardVentasHora> ventasPorHora)
        {
            Panel? panelGrafico = this.ObtenerPanelGraficoHoras();
            if (panelGrafico == null)
            {
                return;
            }

            List<DashboardVentasHora> ventasBloque = ventasPorHora
                .Where(hora => hora.Hora >= horaInicioBloque && hora.Hora <= horaInicioBloque + 5)
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
                int horaReal = horaInicioBloque + i;
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

        private Panel? ObtenerPanelGraficoHoras()
        {
            GroupBox? grupo = this.ObtenerControles<GroupBox>().FirstOrDefault(control => control.Text.Contains("Hora", StringComparison.OrdinalIgnoreCase));
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
                panel.Controls.Add(this.CrearEtiqueta("Sin ventas en el dia", new Point(20, 48), new Size(panel.Width - 40, 30), ContentAlignment.MiddleCenter));
                this.LimpiarTortaMarcas("Sin categorias con ventas.");
                return;
            }

            decimal maximo = topCategorias.Max(categoria => categoria.TotalFacturado);
            int y = 10;

            foreach (DashboardVentasCategoria categoria in topCategorias)
            {
                Label nombre = this.CrearEtiqueta(categoria.Categoria, new Point(12, y), new Size(132, 18), ContentAlignment.MiddleLeft);
                Label importe = this.CrearEtiqueta(FormatearImporteCorto(categoria.TotalFacturado), new Point(panel.Width - 106, y), new Size(92, 18), ContentAlignment.MiddleRight);
                Panel barra = new Panel
                {
                    BackColor = Color.SeaGreen,
                    Cursor = Cursors.Hand,
                    Location = new Point(12, y + 19),
                    Size = new Size(maximo == 0 ? 1 : Math.Max(1, (int)((panel.Width - 28) * categoria.TotalFacturado / maximo)), 7),
                };

                this.ConfigurarClickCategoria(nombre, categoria.Categoria);
                this.ConfigurarClickCategoria(importe, categoria.Categoria);
                this.ConfigurarClickCategoria(barra, categoria.Categoria);

                panel.Controls.Add(nombre);
                panel.Controls.Add(importe);
                panel.Controls.Add(barra);
                y += 24;
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
            if (this.resumenDia == null)
            {
                return;
            }

            this.marcasCategoriaSeleccionada = this.resumenDia.VentasPorMarcaCategoria
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

            int diametro = Math.Max(50, Math.Min(panel.Height - 14, 92));
            Rectangle rectanguloTorta = new Rectangle(12, (panel.Height - diametro) / 2, diametro, diametro);
            float anguloInicio = -90f;

            for (int i = 0; i < this.marcasCategoriaSeleccionada.Count; i++)
            {
                DashboardVentasMarcaCategoria marca = this.marcasCategoriaSeleccionada[i];
                float angulo = (float)(marca.TotalFacturado / total * 360m);

                using SolidBrush brush = new SolidBrush(colores[i % colores.Length]);
                e.Graphics.FillPie(brush, rectanguloTorta, anguloInicio, angulo);
                anguloInicio += angulo;
            }

            int leyendaX = rectanguloTorta.Right + 14;
            int leyendaY = 8;
            int anchoLeyenda = Math.Max(80, panel.Width - leyendaX - 8);

            for (int i = 0; i < this.marcasCategoriaSeleccionada.Count && i < 4; i++)
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

                leyendaY += 18;
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
