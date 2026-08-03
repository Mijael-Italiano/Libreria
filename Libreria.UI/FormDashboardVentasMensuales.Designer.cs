using System.Windows.Forms.DataVisualization.Charting;

namespace Libreria.UI
{
    partial class FormDashboardVentasMensuales
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblRangoMes;
        private Label lblEstado;
        private Label lblTotalValor;
        private Label lblItemsValor;
        private Label lblFacturasValor;
        private Chart chartFacturacionMes;
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
            lblRangoMes = new Label();
            lblEstado = new Label();
            lblTotalValor = new Label();
            lblItemsValor = new Label();
            lblFacturasValor = new Label();
            chartFacturacionMes = new Chart();
            chartClientes = new Chart();
            chartCategoriasIngresos = new Chart();
            chartCategoriasItems = new Chart();
            chartMarcas = new Chart();
            lblTituloGraficoMarcas = new Label();
            lblTitulo = new Label();
            pnlMes = new Panel();
            btnMesAnterior = new Button();
            btnMesSiguiente = new Button();
            btnMesActual = new Button();
            grpResumen = new GroupBox();
            lblTotalTitulo = new Label();
            lblItemsTitulo = new Label();
            lblFacturasTitulo = new Label();
            grpVentasMes = new GroupBox();
            grpClientes = new GroupBox();
            grpCategorias = new GroupBox();
            grpCategoriasItems = new GroupBox();
            grpMarcas = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)chartFacturacionMes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartCategoriasIngresos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartCategoriasItems).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartMarcas).BeginInit();
            pnlMes.SuspendLayout();
            grpResumen.SuspendLayout();
            grpVentasMes.SuspendLayout();
            grpClientes.SuspendLayout();
            grpCategorias.SuspendLayout();
            grpCategoriasItems.SuspendLayout();
            grpMarcas.SuspendLayout();
            SuspendLayout();
            // 
            // lblRangoMes
            // 
            lblRangoMes.AutoSize = true;
            lblRangoMes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRangoMes.Location = new Point(98, 14);
            lblRangoMes.Name = "lblRangoMes";
            lblRangoMes.Size = new Size(78, 20);
            lblRangoMes.TabIndex = 2;
            lblRangoMes.Text = "Mes 0000";
            // 
            // lblEstado
            // 
            lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEstado.AutoEllipsis = true;
            lblEstado.ForeColor = SystemColors.GrayText;
            lblEstado.Location = new Point(20, 656);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(1294, 22);
            lblEstado.TabIndex = 0;
            lblEstado.Visible = false;
            // 
            // lblTotalValor
            // 
            lblTotalValor.AutoSize = true;
            lblTotalValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalValor.Location = new Point(18, 39);
            lblTotalValor.Name = "lblTotalValor";
            lblTotalValor.Size = new Size(34, 25);
            lblTotalValor.TabIndex = 1;
            lblTotalValor.Text = "$0";
            // 
            // lblItemsValor
            // 
            lblItemsValor.AutoSize = true;
            lblItemsValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblItemsValor.Location = new Point(188, 39);
            lblItemsValor.Name = "lblItemsValor";
            lblItemsValor.Size = new Size(23, 25);
            lblItemsValor.TabIndex = 3;
            lblItemsValor.Text = "0";
            // 
            // lblFacturasValor
            // 
            lblFacturasValor.AutoSize = true;
            lblFacturasValor.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblFacturasValor.Location = new Point(354, 39);
            lblFacturasValor.Name = "lblFacturasValor";
            lblFacturasValor.Size = new Size(23, 25);
            lblFacturasValor.TabIndex = 5;
            lblFacturasValor.Text = "0";
            // 
            // chartFacturacionMes
            // 
            chartFacturacionMes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartFacturacionMes.Location = new Point(18, 28);
            chartFacturacionMes.Name = "chartFacturacionMes";
            chartFacturacionMes.Size = new Size(634, 222);
            chartFacturacionMes.TabIndex = 0;
            // 
            // chartClientes
            // 
            chartClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartClientes.Location = new Point(18, 28);
            chartClientes.Name = "chartClientes";
            chartClientes.Size = new Size(634, 134);
            chartClientes.TabIndex = 0;
            // 
            // chartCategoriasIngresos
            // 
            chartCategoriasIngresos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartCategoriasIngresos.Location = new Point(18, 28);
            chartCategoriasIngresos.Name = "chartCategoriasIngresos";
            chartCategoriasIngresos.Size = new Size(259, 160);
            chartCategoriasIngresos.TabIndex = 0;
            // 
            // chartCategoriasItems
            // 
            chartCategoriasItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartCategoriasItems.Location = new Point(18, 28);
            chartCategoriasItems.Name = "chartCategoriasItems";
            chartCategoriasItems.Size = new Size(253, 160);
            chartCategoriasItems.TabIndex = 0;
            // 
            // chartMarcas
            // 
            chartMarcas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chartMarcas.Location = new Point(18, 46);
            chartMarcas.Name = "chartMarcas";
            chartMarcas.Size = new Size(568, 236);
            chartMarcas.TabIndex = 1;
            // 
            // lblTituloGraficoMarcas
            // 
            lblTituloGraficoMarcas.AutoEllipsis = true;
            lblTituloGraficoMarcas.Location = new Point(12, 20);
            lblTituloGraficoMarcas.Name = "lblTituloGraficoMarcas";
            lblTituloGraficoMarcas.Size = new Size(646, 20);
            lblTituloGraficoMarcas.TabIndex = 0;
            lblTituloGraficoMarcas.Text = "Seleccione una categoria";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(324, 30);
            lblTitulo.TabIndex = 8;
            lblTitulo.Text = "Dashboard mensual de ventas";
            // 
            // pnlMes
            // 
            pnlMes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlMes.Controls.Add(btnMesAnterior);
            pnlMes.Controls.Add(btnMesSiguiente);
            pnlMes.Controls.Add(lblRangoMes);
            pnlMes.Controls.Add(btnMesActual);
            pnlMes.Location = new Point(20, 61);
            pnlMes.Name = "pnlMes";
            pnlMes.Size = new Size(1294, 48);
            pnlMes.TabIndex = 7;
            // 
            // btnMesAnterior
            // 
            btnMesAnterior.Location = new Point(6, 9);
            btnMesAnterior.Name = "btnMesAnterior";
            btnMesAnterior.Size = new Size(32, 30);
            btnMesAnterior.TabIndex = 0;
            btnMesAnterior.Text = "<";
            btnMesAnterior.Click += btnMesAnterior_Click;
            // 
            // btnMesSiguiente
            // 
            btnMesSiguiente.Location = new Point(48, 9);
            btnMesSiguiente.Name = "btnMesSiguiente";
            btnMesSiguiente.Size = new Size(32, 30);
            btnMesSiguiente.TabIndex = 1;
            btnMesSiguiente.Text = ">";
            btnMesSiguiente.Click += btnMesSiguiente_Click;
            // 
            // btnMesActual
            // 
            btnMesActual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMesActual.Location = new Point(1158, 9);
            btnMesActual.Name = "btnMesActual";
            btnMesActual.Size = new Size(130, 30);
            btnMesActual.TabIndex = 3;
            btnMesActual.Text = "Mes actual";
            btnMesActual.Click += btnMesActual_Click;
            // 
            // grpResumen
            // 
            grpResumen.Controls.Add(lblTotalTitulo);
            grpResumen.Controls.Add(lblTotalValor);
            grpResumen.Controls.Add(lblItemsTitulo);
            grpResumen.Controls.Add(lblItemsValor);
            grpResumen.Controls.Add(lblFacturasTitulo);
            grpResumen.Controls.Add(lblFacturasValor);
            grpResumen.Location = new Point(20, 120);
            grpResumen.Name = "grpResumen";
            grpResumen.Size = new Size(670, 78);
            grpResumen.TabIndex = 6;
            grpResumen.TabStop = false;
            grpResumen.Text = "Resumen mensual";
            // 
            // lblTotalTitulo
            // 
            lblTotalTitulo.AutoSize = true;
            lblTotalTitulo.Location = new Point(18, 21);
            lblTotalTitulo.Name = "lblTotalTitulo";
            lblTotalTitulo.Size = new Size(86, 15);
            lblTotalTitulo.TabIndex = 0;
            lblTotalTitulo.Text = "Total facturado";
            // 
            // lblItemsTitulo
            // 
            lblItemsTitulo.AutoSize = true;
            lblItemsTitulo.Location = new Point(188, 21);
            lblItemsTitulo.Name = "lblItemsTitulo";
            lblItemsTitulo.Size = new Size(87, 15);
            lblItemsTitulo.TabIndex = 2;
            lblItemsTitulo.Text = "Items vendidos";
            // 
            // lblFacturasTitulo
            // 
            lblFacturasTitulo.AutoSize = true;
            lblFacturasTitulo.Location = new Point(354, 21);
            lblFacturasTitulo.Name = "lblFacturasTitulo";
            lblFacturasTitulo.Size = new Size(116, 15);
            lblFacturasTitulo.TabIndex = 4;
            lblFacturasTitulo.Text = "Cantidad de facturas";
            // 
            // grpVentasMes
            // 
            grpVentasMes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpVentasMes.Controls.Add(chartFacturacionMes);
            grpVentasMes.Location = new Point(20, 214);
            grpVentasMes.Name = "grpVentasMes";
            grpVentasMes.Size = new Size(670, 270);
            grpVentasMes.TabIndex = 5;
            grpVentasMes.TabStop = false;
            grpVentasMes.Text = "Facturacion por tramos del mes";
            // 
            // grpClientes
            // 
            grpClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpClientes.Controls.Add(chartClientes);
            grpClientes.Location = new Point(20, 494);
            grpClientes.Name = "grpClientes";
            grpClientes.Size = new Size(670, 180);
            grpClientes.TabIndex = 4;
            grpClientes.TabStop = false;
            grpClientes.Text = "Top 5 clientes por ingresos";
            // 
            // grpCategorias
            // 
            grpCategorias.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpCategorias.Controls.Add(chartCategoriasIngresos);
            grpCategorias.Location = new Point(710, 120);
            grpCategorias.Name = "grpCategorias";
            grpCategorias.Size = new Size(295, 210);
            grpCategorias.TabIndex = 3;
            grpCategorias.TabStop = false;
            grpCategorias.Text = "Top 5 categorias por ingresos";
            // 
            // grpCategoriasItems
            // 
            grpCategoriasItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpCategoriasItems.Controls.Add(chartCategoriasItems);
            grpCategoriasItems.Location = new Point(1025, 120);
            grpCategoriasItems.Name = "grpCategoriasItems";
            grpCategoriasItems.Size = new Size(289, 210);
            grpCategoriasItems.TabIndex = 2;
            grpCategoriasItems.TabStop = false;
            grpCategoriasItems.Text = "Top 5 categorias por items vendidos";
            // 
            // grpMarcas
            // 
            grpMarcas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpMarcas.Controls.Add(lblTituloGraficoMarcas);
            grpMarcas.Controls.Add(chartMarcas);
            grpMarcas.Location = new Point(710, 340);
            grpMarcas.Name = "grpMarcas";
            grpMarcas.Size = new Size(604, 304);
            grpMarcas.TabIndex = 1;
            grpMarcas.TabStop = false;
            grpMarcas.Text = "Marcas de la categoria seleccionada";
            // 
            // FormDashboardVentasMensuales
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1334, 690);
            Controls.Add(lblEstado);
            Controls.Add(grpMarcas);
            Controls.Add(grpCategoriasItems);
            Controls.Add(grpCategorias);
            Controls.Add(grpClientes);
            Controls.Add(grpVentasMes);
            Controls.Add(grpResumen);
            Controls.Add(pnlMes);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1300, 650);
            Name = "FormDashboardVentasMensuales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard mensual de ventas";
            ((System.ComponentModel.ISupportInitialize)chartFacturacionMes).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCategoriasIngresos).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartCategoriasItems).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartMarcas).EndInit();
            pnlMes.ResumeLayout(false);
            pnlMes.PerformLayout();
            grpResumen.ResumeLayout(false);
            grpResumen.PerformLayout();
            grpVentasMes.ResumeLayout(false);
            grpClientes.ResumeLayout(false);
            grpCategorias.ResumeLayout(false);
            grpCategoriasItems.ResumeLayout(false);
            grpMarcas.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        private Label lblTitulo;
        private Panel pnlMes;
        private Button btnMesAnterior;
        private Button btnMesSiguiente;
        private Button btnMesActual;
        private GroupBox grpResumen;
        private Label lblTotalTitulo;
        private Label lblItemsTitulo;
        private Label lblFacturasTitulo;
        private GroupBox grpVentasMes;
        private GroupBox grpClientes;
        private GroupBox grpCategorias;
        private GroupBox grpCategoriasItems;
        private GroupBox grpMarcas;
    }
}
