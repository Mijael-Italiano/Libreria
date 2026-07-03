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
        private Panel panelGraficoMes;
        private Panel panelClientesIngresos;
        private Panel panelCategoriasIngresos;
        private Panel panelCategoriasItems;
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
            panelGraficoMes = new Panel();
            panelClientesIngresos = new Panel();
            panelCategoriasIngresos = new Panel();
            panelCategoriasItems = new Panel();
            chartMarcas = new Chart();
            lblTituloGraficoMarcas = new Label();
            Label lblTitulo = new Label();
            Panel pnlMes = new Panel();
            Button btnMesAnterior = new Button();
            Button btnMesSiguiente = new Button();
            Button btnMesActual = new Button();
            GroupBox grpResumen = new GroupBox();
            Label lblTotalTitulo = new Label();
            Label lblItemsTitulo = new Label();
            Label lblFacturasTitulo = new Label();
            GroupBox grpVentasMes = new GroupBox();
            GroupBox grpClientes = new GroupBox();
            GroupBox grpCategorias = new GroupBox();
            GroupBox grpCategoriasItems = new GroupBox();
            GroupBox grpMarcas = new GroupBox();
            SuspendLayout();
            // lblTitulo
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Text = "Dashboard mensual de ventas";
            // pnlMes
            pnlMes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlMes.Location = new Point(20, 61);
            pnlMes.Size = new Size(1060, 48);
            btnMesAnterior.Location = new Point(6, 9);
            btnMesAnterior.Size = new Size(32, 30);
            btnMesAnterior.Text = "<";
            btnMesAnterior.Click += btnMesAnterior_Click;
            btnMesSiguiente.Location = new Point(48, 9);
            btnMesSiguiente.Size = new Size(32, 30);
            btnMesSiguiente.Text = ">";
            btnMesSiguiente.Click += btnMesSiguiente_Click;
            lblRangoMes.AutoSize = true;
            lblRangoMes.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblRangoMes.Location = new Point(98, 14);
            lblRangoMes.Text = "Mes 0000";
            btnMesActual.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnMesActual.Location = new Point(924, 9);
            btnMesActual.Size = new Size(130, 30);
            btnMesActual.Text = "Mes actual";
            btnMesActual.Click += btnMesActual_Click;
            pnlMes.Controls.Add(btnMesAnterior);
            pnlMes.Controls.Add(btnMesSiguiente);
            pnlMes.Controls.Add(lblRangoMes);
            pnlMes.Controls.Add(btnMesActual);
            // grpResumen
            grpResumen.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            grpResumen.Location = new Point(20, 120);
            grpResumen.Size = new Size(520, 78);
            grpResumen.Text = "Resumen mensual";
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
            // grpVentasMes
            grpVentasMes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpVentasMes.Location = new Point(20, 214);
            grpVentasMes.Size = new Size(520, 270);
            grpVentasMes.Text = "Facturacion por tramos del mes";
            panelGraficoMes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelGraficoMes.BackColor = SystemColors.Window;
            panelGraficoMes.BorderStyle = BorderStyle.FixedSingle;
            panelGraficoMes.Location = new Point(18, 28);
            panelGraficoMes.Size = new Size(484, 222);
            grpVentasMes.Controls.Add(panelGraficoMes);
            // grpClientes
            grpClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpClientes.Location = new Point(20, 494);
            grpClientes.Size = new Size(520, 180);
            grpClientes.Text = "Top 5 clientes por ingresos";
            panelClientesIngresos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelClientesIngresos.BackColor = SystemColors.Window;
            panelClientesIngresos.BorderStyle = BorderStyle.FixedSingle;
            panelClientesIngresos.Location = new Point(18, 28);
            panelClientesIngresos.Size = new Size(484, 134);
            grpClientes.Controls.Add(panelClientesIngresos);
            // grpCategorias
            grpCategorias.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpCategorias.Location = new Point(560, 120);
            grpCategorias.Size = new Size(250, 210);
            grpCategorias.Text = "Top 5 categorias por ingresos";
            panelCategoriasIngresos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCategoriasIngresos.BackColor = SystemColors.Window;
            panelCategoriasIngresos.BorderStyle = BorderStyle.FixedSingle;
            panelCategoriasIngresos.Location = new Point(18, 28);
            panelCategoriasIngresos.Size = new Size(214, 160);
            grpCategorias.Controls.Add(panelCategoriasIngresos);
            // grpCategoriasItems
            grpCategoriasItems.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpCategoriasItems.Location = new Point(830, 120);
            grpCategoriasItems.Size = new Size(250, 210);
            grpCategoriasItems.Text = "Top 5 categorias por items vendidos";
            panelCategoriasItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelCategoriasItems.BackColor = SystemColors.Window;
            panelCategoriasItems.BorderStyle = BorderStyle.FixedSingle;
            panelCategoriasItems.Location = new Point(18, 28);
            panelCategoriasItems.Size = new Size(214, 160);
            grpCategoriasItems.Controls.Add(panelCategoriasItems);
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
            // lblEstado
            lblEstado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblEstado.AutoEllipsis = true;
            lblEstado.ForeColor = SystemColors.GrayText;
            lblEstado.Location = new Point(20, 656);
            lblEstado.Size = new Size(1060, 22);
            lblEstado.Text = "";
            lblEstado.Visible = false;
            // FormDashboardVentasMensuales
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 690);
            Controls.Add(lblEstado);
            Controls.Add(grpMarcas);
            Controls.Add(grpCategoriasItems);
            Controls.Add(grpCategorias);
            Controls.Add(grpClientes);
            Controls.Add(grpVentasMes);
            Controls.Add(grpResumen);
            Controls.Add(pnlMes);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1000, 650);
            Name = "FormDashboardVentasMensuales";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dashboard mensual de ventas";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
