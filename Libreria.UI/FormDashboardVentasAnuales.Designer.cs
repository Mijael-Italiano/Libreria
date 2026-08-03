using System.Windows.Forms.DataVisualization.Charting;

namespace Libreria.UI
{
    partial class FormDashboardVentasAnuales
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblRangoAnio;
        private Label lblEstado;
        private Label lblTotalValor;
        private Label lblItemsValor;
        private Label lblFacturasValor;
        private Chart chartFacturacionAnio;
        private Chart chartClientes;
        private Chart chartCategoriasIngresos;
        private Chart chartCategoriasItems;
        private Chart chartMarcas;
        private Label lblTituloGraficoMarcas;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblRangoAnio = new Label();
            lblEstado = new Label();
            lblTotalValor = new Label();
            lblItemsValor = new Label();
            lblFacturasValor = new Label();
            chartFacturacionAnio = new Chart();
            chartClientes = new Chart();
            chartCategoriasIngresos = new Chart();
            chartCategoriasItems = new Chart();
            chartMarcas = new Chart();
            lblTituloGraficoMarcas = new Label();
            Label lblTitulo = new Label();
            Panel pnlAnio = new Panel();
            Button btnAnioAnterior = new Button();
            Button btnAnioSiguiente = new Button();
            Button btnAnioActual = new Button();
            GroupBox grpResumen = new GroupBox();
            Label lblTotalTitulo = new Label();
            Label lblItemsTitulo = new Label();
            Label lblFacturasTitulo = new Label();
            GroupBox grpVentasAnio = new GroupBox();
            GroupBox grpClientes = new GroupBox();
            GroupBox grpCategorias = new GroupBox();
            GroupBox grpCategoriasItems = new GroupBox();
            GroupBox grpMarcas = new GroupBox();
            SuspendLayout();
            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Text = "Dashboard anual de ventas";
            // pnlAnio
            pnlAnio.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlAnio.Location = new Point(20, 61);
            pnlAnio.Size = new Size(1294, 48);
            btnAnioAnterior.Location = new Point(6, 9);
            btnAnioAnterior.Size = new Size(32, 30);
            btnAnioAnterior.Text = "<";
            btnAnioAnterior.Click += btnAnioAnterior_Click;
            btnAnioSiguiente.Location = new Point(48, 9);
            btnAnioSiguiente.Size = new Size(32, 30);
            btnAnioSiguiente.Text = ">";
            btnAnioSiguiente.Click += btnAnioSiguiente_Click;
            lblRangoAnio.AutoSize = true;
            lblRangoAnio.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRangoAnio.Location = new Point(98, 14);
            lblRangoAnio.Text = "Año 0000";
            btnAnioActual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnioActual.Location = new Point(1158, 9);
            btnAnioActual.Size = new Size(130, 30);
            btnAnioActual.Text = "Año actual";
            btnAnioActual.Click += btnAnioActual_Click;
            pnlAnio.Controls.Add(btnAnioAnterior);
            pnlAnio.Controls.Add(btnAnioSiguiente);
            pnlAnio.Controls.Add(lblRangoAnio);
            pnlAnio.Controls.Add(btnAnioActual);
            // grpResumen
            grpResumen.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            grpResumen.Location = new Point(20, 120);
            grpResumen.Size = new Size(670, 78);
            grpResumen.Text = "Resumen anual";
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
            // grpVentasAnio
            grpVentasAnio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpVentasAnio.Location = new Point(20, 214);
            grpVentasAnio.Size = new Size(670, 270);
            grpVentasAnio.Text = "Facturacion por mes del año";
            chartFacturacionAnio.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartFacturacionAnio.Location = new Point(18, 28);
            chartFacturacionAnio.Size = new Size(634, 222);
            grpVentasAnio.Controls.Add(chartFacturacionAnio);
            // grpClientes
            grpClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpClientes.Location = new Point(20, 494);
            grpClientes.Size = new Size(670, 180);
            grpClientes.Text = "Top 5 clientes por ingresos";
            chartClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartClientes.Location = new Point(18, 28);
            chartClientes.Size = new Size(634, 134);
            grpClientes.Controls.Add(chartClientes);
            // grpCategorias
            grpCategorias.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpCategorias.Location = new Point(710, 120);
            grpCategorias.Size = new Size(295, 210);
            grpCategorias.Text = "Top 5 categorias por ingresos";
            chartCategoriasIngresos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartCategoriasIngresos.Location = new Point(18, 28);
            chartCategoriasIngresos.Size = new Size(259, 160);
            grpCategorias.Controls.Add(chartCategoriasIngresos);
            // grpCategoriasItems
            grpCategoriasItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpCategoriasItems.Location = new Point(1025, 120);
            grpCategoriasItems.Size = new Size(289, 210);
            grpCategoriasItems.Text = "Top 5 categorias por items vendidos";
            chartCategoriasItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartCategoriasItems.Location = new Point(18, 28);
            chartCategoriasItems.Size = new Size(253, 160);
            grpCategoriasItems.Controls.Add(chartCategoriasItems);
            // grpMarcas
            grpMarcas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpMarcas.Location = new Point(710, 340);
            grpMarcas.Size = new Size(604, 304);
            grpMarcas.Text = "Marcas de la categoria seleccionada";
            lblTituloGraficoMarcas.AutoEllipsis = true;
            lblTituloGraficoMarcas.Location = new Point(12, 20);
            lblTituloGraficoMarcas.Size = new Size(646, 20);
            lblTituloGraficoMarcas.Text = "Seleccione una categoria";
            chartMarcas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartMarcas.Location = new Point(18, 46);
            chartMarcas.Size = new Size(568, 236);
            grpMarcas.Controls.Add(lblTituloGraficoMarcas);
            grpMarcas.Controls.Add(chartMarcas);
            // lblEstado
            lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEstado.AutoEllipsis = true;
            lblEstado.ForeColor = SystemColors.GrayText;
            lblEstado.Location = new Point(20, 656);
            lblEstado.Size = new Size(1294, 22);
            lblEstado.Text = "";
            lblEstado.Visible = false;
            // FormDashboardVentasAnuales
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1334, 690);
            Controls.Add(lblEstado);
            Controls.Add(grpMarcas);
            Controls.Add(grpCategoriasItems);
            Controls.Add(grpCategorias);
            Controls.Add(grpClientes);
            Controls.Add(grpVentasAnio);
            Controls.Add(grpResumen);
            Controls.Add(pnlAnio);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1300, 650);
            Name = "FormDashboardVentasAnuales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard anual de ventas";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
