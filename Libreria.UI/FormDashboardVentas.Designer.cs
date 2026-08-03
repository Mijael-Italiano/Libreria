using System.Windows.Forms.DataVisualization.Charting;

namespace Libreria.UI
{
    partial class FormDashboardVentas
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblRangoSemana;
        private Label lblEstado;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblRangoSemana = new Label();
            lblEstado = new Label();
            Label lblTitulo = new Label();
            Panel pnlSemana = new Panel();
            Button btnSemanaAnterior = new Button();
            Button btnSemanaSiguiente = new Button();
            Button btnSemanaActual = new Button();
            GroupBox grpResumen = new GroupBox();
            Label lblTotalTitulo = new Label();
            Label lblTotalValor = new Label();
            Label lblItemsTitulo = new Label();
            Label lblItemsValor = new Label();
            Label lblFacturasTitulo = new Label();
            Label lblFacturasValor = new Label();
            GroupBox grpVentasSemana = new GroupBox();
            GroupBox grpClientes = new GroupBox();
            chartClientes = new Chart();
            chartFacturacionSemana = new Chart();
            GroupBox grpCategorias = new GroupBox();
            chartCategoriasIngresos = new Chart();
            Button btnDetalleCategoria = new Button();
            GroupBox grpCategoriasItems = new GroupBox();
            chartCategoriasItems = new Chart();
            GroupBox grpMarcas = new GroupBox();
            lblTituloGraficoMarcas = new Label();
            chartMarcas = new Chart();
            SuspendLayout();
            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Text = "Dashboard de ventas";
            // pnlSemana
            pnlSemana.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlSemana.Location = new Point(20, 61);
            pnlSemana.Size = new Size(1060, 48);
            btnSemanaAnterior.Location = new Point(6, 9);
            btnSemanaAnterior.Size = new Size(32, 30);
            btnSemanaAnterior.Text = "<";
            btnSemanaAnterior.Click += btnSemanaAnterior_Click;
            btnSemanaSiguiente.Location = new Point(48, 9);
            btnSemanaSiguiente.Size = new Size(32, 30);
            btnSemanaSiguiente.Text = ">";
            btnSemanaSiguiente.Click += btnSemanaSiguiente_Click;
            lblRangoSemana.AutoSize = true;
            lblRangoSemana.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRangoSemana.Location = new Point(98, 14);
            lblRangoSemana.Text = "Semana del 00/00/0000 al 00/00/0000";
            btnSemanaActual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSemanaActual.Location = new Point(924, 9);
            btnSemanaActual.Size = new Size(130, 30);
            btnSemanaActual.Text = "Semana actual";
            btnSemanaActual.Click += btnSemanaActual_Click;
            pnlSemana.Controls.Add(btnSemanaAnterior);
            pnlSemana.Controls.Add(btnSemanaSiguiente);
            pnlSemana.Controls.Add(lblRangoSemana);
            pnlSemana.Controls.Add(btnSemanaActual);
            // grpResumen
            grpResumen.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            grpResumen.Location = new Point(20, 120);
            grpResumen.Size = new Size(520, 78);
            grpResumen.Text = "Resumen semanal";
            lblTotalTitulo.AutoSize = true;
            lblTotalTitulo.Location = new Point(18, 21);
            lblTotalTitulo.Text = "Total facturado";
            lblTotalValor.AutoSize = true;
            lblTotalValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalValor.Location = new Point(18, 39);
            lblTotalValor.Text = ",00";
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
            // grpVentasSemana
            grpVentasSemana.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpVentasSemana.Location = new Point(20, 214);
            grpVentasSemana.Size = new Size(520, 270);
            grpVentasSemana.Text = "Facturacion por dia de la semana";
            chartFacturacionSemana.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartFacturacionSemana.Location = new Point(18, 28);
            chartFacturacionSemana.Size = new Size(484, 222);
            grpVentasSemana.Controls.Add(chartFacturacionSemana);
            // grpClientes
            grpClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpClientes.Location = new Point(20, 494);
            grpClientes.Size = new Size(520, 180);
            grpClientes.Text = "Top 5 clientes por ingresos";
            chartClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartClientes.Location = new Point(18, 28);
            chartClientes.Size = new Size(484, 134);
            grpClientes.Controls.Add(chartClientes);
            // grpCategorias
            grpCategorias.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpCategorias.Location = new Point(560, 120);
            grpCategorias.Size = new Size(250, 210);
            grpCategorias.Text = "Top 5 categorias por ingresos";
            chartCategoriasIngresos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartCategoriasIngresos.Location = new Point(18, 28);
            chartCategoriasIngresos.Size = new Size(214, 160);
            btnDetalleCategoria.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnDetalleCategoria.Enabled = false;
            btnDetalleCategoria.Visible = false;
            btnDetalleCategoria.Location = new Point(181, 388);
            btnDetalleCategoria.Size = new Size(157, 28);
            btnDetalleCategoria.Text = "Ver detalle categoria";
            grpCategorias.Controls.Add(chartCategoriasIngresos);
            grpCategorias.Controls.Add(btnDetalleCategoria);
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
            grpMarcas.Size = new Size(520, 304);
            grpMarcas.Text = "Marcas de la categoria seleccionada";
            lblTituloGraficoMarcas.AutoEllipsis = true;
            lblTituloGraficoMarcas.Location = new Point(12, 20);
            lblTituloGraficoMarcas.Size = new Size(496, 20);
            lblTituloGraficoMarcas.Text = "Seleccione una categoria";
            chartMarcas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartMarcas.Location = new Point(18, 46);
            chartMarcas.Size = new Size(484, 236);
            grpMarcas.Controls.Add(lblTituloGraficoMarcas);
            grpMarcas.Controls.Add(chartMarcas);
            lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEstado.AutoEllipsis = true;
            lblEstado.ForeColor = SystemColors.GrayText;
            lblEstado.Location = new Point(20, 656);
            lblEstado.Size = new Size(1060, 22);
            lblEstado.Text = "";
            lblEstado.Visible = false;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 690);
            Controls.Add(lblEstado);
            Controls.Add(grpMarcas);
            Controls.Add(grpCategoriasItems);
            Controls.Add(grpCategorias);
            Controls.Add(grpClientes);
            Controls.Add(grpVentasSemana);
            Controls.Add(grpResumen);
            Controls.Add(pnlSemana);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1000, 650);
            Name = "FormDashboardVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard de ventas";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}












