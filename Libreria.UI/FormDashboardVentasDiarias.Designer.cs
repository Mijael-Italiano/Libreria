using System.Windows.Forms.DataVisualization.Charting;

namespace Libreria.UI
{
    partial class FormDashboardVentasDiarias
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblRangoDia;
        private Label lblEstado;
        private Label lblTotalValor;
        private Label lblItemsValor;
        private Label lblFacturasValor;
        private Chart chartHoras;
        private Chart chartClientes;
        private Chart chartCategoriasIngresos;
        private Chart chartCategoriasItems;
        private Chart chartMarcas;
        private Label lblTituloGraficoMarcas;
        private Label lblRangoHorario;
        private Button btnBloqueAnterior;
        private Button btnBloqueSiguiente;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblRangoDia = new Label();
            lblEstado = new Label();
            lblTotalValor = new Label();
            lblItemsValor = new Label();
            lblFacturasValor = new Label();
            chartHoras = new Chart();
            chartClientes = new Chart();
            chartCategoriasIngresos = new Chart();
            chartCategoriasItems = new Chart();
            chartMarcas = new Chart();
            lblTituloGraficoMarcas = new Label();
            lblRangoHorario = new Label();
            btnBloqueAnterior = new Button();
            btnBloqueSiguiente = new Button();
            Label lblTitulo = new Label();
            Panel pnlDia = new Panel();
            Button btnDiaAnterior = new Button();
            Button btnDiaSiguiente = new Button();
            Button btnDiaActual = new Button();
            GroupBox grpResumen = new GroupBox();
            Label lblTotalTitulo = new Label();
            Label lblItemsTitulo = new Label();
            Label lblFacturasTitulo = new Label();
            GroupBox grpHoras = new GroupBox();
            Panel pnlBloque = new Panel();
            GroupBox grpClientes = new GroupBox();
            GroupBox grpCategorias = new GroupBox();
            GroupBox grpCategoriasItems = new GroupBox();
            GroupBox grpMarcas = new GroupBox();
            SuspendLayout();

            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Text = "Dashboard de ventas diarias";

            // pnlDia
            pnlDia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlDia.Location = new Point(20, 61);
            pnlDia.Size = new Size(1060, 48);
            btnDiaAnterior.Location = new Point(6, 9);
            btnDiaAnterior.Size = new Size(32, 30);
            btnDiaAnterior.Text = "<";
            btnDiaAnterior.Click += btnDiaAnterior_Click;
            btnDiaSiguiente.Location = new Point(48, 9);
            btnDiaSiguiente.Size = new Size(32, 30);
            btnDiaSiguiente.Text = ">";
            btnDiaSiguiente.Click += btnDiaSiguiente_Click;
            lblRangoDia.AutoSize = true;
            lblRangoDia.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRangoDia.Location = new Point(98, 14);
            lblRangoDia.Text = "00/00/0000";
            btnDiaActual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnDiaActual.Location = new Point(924, 9);
            btnDiaActual.Size = new Size(130, 30);
            btnDiaActual.Text = "Día actual";
            btnDiaActual.Click += btnDiaActual_Click;
            pnlDia.Controls.Add(btnDiaAnterior);
            pnlDia.Controls.Add(btnDiaSiguiente);
            pnlDia.Controls.Add(lblRangoDia);
            pnlDia.Controls.Add(btnDiaActual);

            // grpResumen
            grpResumen.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            grpResumen.Location = new Point(20, 120);
            grpResumen.Size = new Size(520, 78);
            grpResumen.Text = "Resumen del día";
            lblTotalTitulo.AutoSize = true;
            lblTotalTitulo.Location = new Point(18, 21);
            lblTotalTitulo.Text = "Total facturado";
            lblTotalValor.AutoSize = true;
            lblTotalValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalValor.Location = new Point(18, 39);
            lblTotalValor.Text = "$0";
            lblItemsTitulo.AutoSize = true;
            lblItemsTitulo.Location = new Point(188, 21);
            lblItemsTitulo.Text = "Items vendidos";
            lblItemsValor.AutoSize = true;
            lblItemsValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblItemsValor.Location = new Point(188, 39);
            lblItemsValor.Text = "0";
            lblFacturasTitulo.AutoSize = true;
            lblFacturasTitulo.Location = new Point(354, 21);
            lblFacturasTitulo.Text = "Cantidad de facturas";
            lblFacturasValor.AutoSize = true;
            lblFacturasValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFacturasValor.Location = new Point(354, 39);
            lblFacturasValor.Text = "0";
            grpResumen.Controls.Add(lblTotalTitulo);
            grpResumen.Controls.Add(lblTotalValor);
            grpResumen.Controls.Add(lblItemsTitulo);
            grpResumen.Controls.Add(lblItemsValor);
            grpResumen.Controls.Add(lblFacturasTitulo);
            grpResumen.Controls.Add(lblFacturasValor);

            // grpHoras
            grpHoras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpHoras.Location = new Point(20, 210);
            grpHoras.Size = new Size(520, 300);
            grpHoras.Text = "Facturacion por hora";
            // pnlBloque (navega bloques de 6 horas, dentro de grpHoras)
            pnlBloque.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlBloque.Location = new Point(18, 22);
            pnlBloque.Size = new Size(484, 38);
            btnBloqueAnterior.Location = new Point(0, 4);
            btnBloqueAnterior.Size = new Size(32, 30);
            btnBloqueAnterior.Text = "<";
            btnBloqueAnterior.Click += btnBloqueAnterior_Click;
            btnBloqueSiguiente.Location = new Point(42, 4);
            btnBloqueSiguiente.Size = new Size(32, 30);
            btnBloqueSiguiente.Text = ">";
            btnBloqueSiguiente.Click += btnBloqueSiguiente_Click;
            lblRangoHorario.AutoSize = true;
            lblRangoHorario.Font = new Font("Segoe UI", 10F);
            lblRangoHorario.Location = new Point(86, 9);
            lblRangoHorario.Text = "Horas 00:00 a 05:59";
            pnlBloque.Controls.Add(btnBloqueAnterior);
            pnlBloque.Controls.Add(btnBloqueSiguiente);
            pnlBloque.Controls.Add(lblRangoHorario);
            // chartHoras
            chartHoras.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartHoras.Location = new Point(18, 64);
            chartHoras.Size = new Size(484, 220);
            grpHoras.Controls.Add(pnlBloque);
            grpHoras.Controls.Add(chartHoras);

            // grpClientes
            grpClientes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpClientes.Location = new Point(20, 520);
            grpClientes.Size = new Size(520, 186);
            grpClientes.Text = "Top 5 clientes por ingresos";
            chartClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartClientes.Location = new Point(18, 28);
            chartClientes.Size = new Size(484, 140);
            grpClientes.Controls.Add(chartClientes);

            // grpCategorias (ingresos)
            grpCategorias.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpCategorias.Location = new Point(560, 120);
            grpCategorias.Size = new Size(250, 210);
            grpCategorias.Text = "Top 5 categorias por ingresos";
            chartCategoriasIngresos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartCategoriasIngresos.Location = new Point(18, 28);
            chartCategoriasIngresos.Size = new Size(214, 160);
            grpCategorias.Controls.Add(chartCategoriasIngresos);

            // grpCategoriasItems
            grpCategoriasItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpCategoriasItems.Location = new Point(830, 120);
            grpCategoriasItems.Size = new Size(250, 210);
            grpCategoriasItems.Text = "Top 5 categorias por items vendidos";
            chartCategoriasItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartCategoriasItems.Location = new Point(18, 28);
            chartCategoriasItems.Size = new Size(214, 160);
            grpCategoriasItems.Controls.Add(chartCategoriasItems);

            // grpMarcas
            grpMarcas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpMarcas.Location = new Point(560, 340);
            grpMarcas.Size = new Size(520, 324);
            grpMarcas.Text = "Marcas de la categoria seleccionada";
            lblTituloGraficoMarcas.AutoEllipsis = true;
            lblTituloGraficoMarcas.Location = new Point(12, 20);
            lblTituloGraficoMarcas.Size = new Size(496, 20);
            lblTituloGraficoMarcas.Text = "Seleccione una categoria";
            chartMarcas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartMarcas.Location = new Point(18, 46);
            chartMarcas.Size = new Size(484, 256);
            grpMarcas.Controls.Add(lblTituloGraficoMarcas);
            grpMarcas.Controls.Add(chartMarcas);

            // lblEstado
            lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEstado.AutoEllipsis = true;
            lblEstado.ForeColor = SystemColors.GrayText;
            lblEstado.Location = new Point(20, 716);
            lblEstado.Size = new Size(1060, 22);
            lblEstado.Text = string.Empty;

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 744);
            Controls.Add(lblEstado);
            Controls.Add(grpMarcas);
            Controls.Add(grpCategoriasItems);
            Controls.Add(grpCategorias);
            Controls.Add(grpClientes);
            Controls.Add(grpHoras);
            Controls.Add(grpResumen);
            Controls.Add(pnlDia);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1000, 650);
            Name = "FormDashboardVentasDiarias";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard de ventas diarias";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
