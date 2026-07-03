namespace Libreria.UI
{
    partial class FormConsultarVentas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            dgvFacturas = new DataGridView();
            colIdFactura = new DataGridViewTextBoxColumn();
            colIdCliente = new DataGridViewTextBoxColumn();
            colNombreCliente = new DataGridViewTextBoxColumn();
            colApellidoCliente = new DataGridViewTextBoxColumn();
            colDocumentoCliente = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colFechaEmision = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            dgvFacturaItems = new DataGridView();
            colIdFacturaItem = new DataGridViewTextBoxColumn();
            colIdProducto = new DataGridViewTextBoxColumn();
            colProducto = new DataGridViewTextBoxColumn();
            colMarca = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colPrecioUnitario = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            colEstadoItem = new DataGridViewTextBoxColumn();
            grpFiltrosFactura = new GroupBox();
            dtpFechaHasta = new DateTimePicker();
            lblFechaHasta = new Label();
            dtpFechaDesde = new DateTimePicker();
            lblFechaDesde = new Label();
            txtUsuario = new TextBox();
            lblUsuario = new Label();
            txtIdFactura = new TextBox();
            lblIdFactura = new Label();
            grpFiltrosCliente = new GroupBox();
            txtApellidoCliente = new TextBox();
            lblApellidoCliente = new Label();
            txtNombreCliente = new TextBox();
            lblNombreCliente = new Label();
            txtDocumentoCliente = new TextBox();
            lblDocumentoCliente = new Label();
            txtIdCliente = new TextBox();
            lblIdCliente = new Label();
            pnlAccionesBusqueda = new Panel();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvFacturaItems).BeginInit();
            grpFiltrosFactura.SuspendLayout();
            grpFiltrosCliente.SuspendLayout();
            pnlAccionesBusqueda.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(178, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Consultar ventas";
            // 
            // dgvFacturas
            // 
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.AllowUserToDeleteRows = false;
            dgvFacturas.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.BackgroundColor = SystemColors.Window;
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Columns.AddRange(new DataGridViewColumn[] { colIdFactura, colIdCliente, colNombreCliente, colApellidoCliente, colDocumentoCliente, colUsuario, colFechaEmision, colTotal, colEstado });
            dgvFacturas.Location = new Point(20, 72);
            dgvFacturas.MultiSelect = false;
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dgvFacturas.RowHeadersVisible = false;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.Size = new Size(880, 270);
            dgvFacturas.TabIndex = 1;
            // 
            // colIdFactura
            // 
            colIdFactura.FillWeight = 55F;
            colIdFactura.HeaderText = "Id factura";
            colIdFactura.Name = "colIdFactura";
            colIdFactura.ReadOnly = true;
            // 
            // colIdCliente
            // 
            colIdCliente.FillWeight = 55F;
            colIdCliente.HeaderText = "Id cliente";
            colIdCliente.Name = "colIdCliente";
            colIdCliente.ReadOnly = true;
            // 
            // colNombreCliente
            // 
            colNombreCliente.HeaderText = "Nombre cliente";
            colNombreCliente.Name = "colNombreCliente";
            colNombreCliente.ReadOnly = true;
            // 
            // colApellidoCliente
            // 
            colApellidoCliente.HeaderText = "Apellido cliente";
            colApellidoCliente.Name = "colApellidoCliente";
            colApellidoCliente.ReadOnly = true;
            // 
            // colDocumentoCliente
            // 
            colDocumentoCliente.FillWeight = 75F;
            colDocumentoCliente.HeaderText = "Documento";
            colDocumentoCliente.Name = "colDocumentoCliente";
            colDocumentoCliente.ReadOnly = true;
            // 
            // colUsuario
            // 
            colUsuario.FillWeight = 80F;
            colUsuario.HeaderText = "Usuario";
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            // 
            // colFechaEmision
            // 
            colFechaEmision.FillWeight = 85F;
            colFechaEmision.HeaderText = "Fecha";
            colFechaEmision.Name = "colFechaEmision";
            colFechaEmision.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.FillWeight = 70F;
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.FillWeight = 70F;
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // dgvFacturaItems
            // 
            dgvFacturaItems.AllowUserToAddRows = false;
            dgvFacturaItems.AllowUserToDeleteRows = false;
            dgvFacturaItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFacturaItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturaItems.BackgroundColor = SystemColors.Window;
            dgvFacturaItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturaItems.Columns.AddRange(new DataGridViewColumn[] { colIdFacturaItem, colIdProducto, colProducto, colMarca, colCategoria, colCantidad, colPrecioUnitario, colSubtotal, colEstadoItem });
            dgvFacturaItems.Location = new Point(20, 365);
            dgvFacturaItems.MultiSelect = false;
            dgvFacturaItems.Name = "dgvFacturaItems";
            dgvFacturaItems.ReadOnly = true;
            dgvFacturaItems.RowHeadersVisible = false;
            dgvFacturaItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturaItems.Size = new Size(880, 268);
            dgvFacturaItems.TabIndex = 2;
            // 
            // colIdFacturaItem
            // 
            colIdFacturaItem.FillWeight = 55F;
            colIdFacturaItem.HeaderText = "Id item";
            colIdFacturaItem.Name = "colIdFacturaItem";
            colIdFacturaItem.ReadOnly = true;
            // 
            // colIdProducto
            // 
            colIdProducto.FillWeight = 65F;
            colIdProducto.HeaderText = "Id producto";
            colIdProducto.Name = "colIdProducto";
            colIdProducto.ReadOnly = true;
            // 
            // colProducto
            // 
            colProducto.HeaderText = "Producto";
            colProducto.Name = "colProducto";
            colProducto.ReadOnly = true;
            // 
            // colMarca
            // 
            colMarca.FillWeight = 80F;
            colMarca.HeaderText = "Marca";
            colMarca.Name = "colMarca";
            colMarca.ReadOnly = true;
            // 
            // colCategoria
            // 
            colCategoria.FillWeight = 80F;
            colCategoria.HeaderText = "Categoria";
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            // 
            // colCantidad
            // 
            colCantidad.FillWeight = 65F;
            colCantidad.HeaderText = "Cantidad";
            colCantidad.Name = "colCantidad";
            colCantidad.ReadOnly = true;
            // 
            // colPrecioUnitario
            // 
            colPrecioUnitario.FillWeight = 85F;
            colPrecioUnitario.HeaderText = "Precio unitario";
            colPrecioUnitario.Name = "colPrecioUnitario";
            colPrecioUnitario.ReadOnly = true;
            // 
            // colSubtotal
            // 
            colSubtotal.FillWeight = 75F;
            colSubtotal.HeaderText = "Subtotal";
            colSubtotal.Name = "colSubtotal";
            colSubtotal.ReadOnly = true;
            // 
            // colEstadoItem
            // 
            colEstadoItem.FillWeight = 70F;
            colEstadoItem.HeaderText = "Estado";
            colEstadoItem.Name = "colEstadoItem";
            colEstadoItem.ReadOnly = true;
            // 
            // grpFiltrosFactura
            // 
            grpFiltrosFactura.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpFiltrosFactura.Controls.Add(dtpFechaHasta);
            grpFiltrosFactura.Controls.Add(lblFechaHasta);
            grpFiltrosFactura.Controls.Add(dtpFechaDesde);
            grpFiltrosFactura.Controls.Add(lblFechaDesde);
            grpFiltrosFactura.Controls.Add(txtUsuario);
            grpFiltrosFactura.Controls.Add(lblUsuario);
            grpFiltrosFactura.Controls.Add(txtIdFactura);
            grpFiltrosFactura.Controls.Add(lblIdFactura);
            grpFiltrosFactura.Location = new Point(925, 72);
            grpFiltrosFactura.Name = "grpFiltrosFactura";
            grpFiltrosFactura.Size = new Size(360, 160);
            grpFiltrosFactura.TabIndex = 3;
            grpFiltrosFactura.TabStop = false;
            grpFiltrosFactura.Text = "Factura";
            // 
            // dtpFechaHasta
            // 
            dtpFechaHasta.Format = DateTimePickerFormat.Short;
            dtpFechaHasta.Location = new Point(235, 106);
            dtpFechaHasta.Name = "dtpFechaHasta";
            dtpFechaHasta.Size = new Size(105, 23);
            dtpFechaHasta.TabIndex = 7;
            // 
            // lblFechaHasta
            // 
            lblFechaHasta.AutoSize = true;
            lblFechaHasta.Location = new Point(185, 110);
            lblFechaHasta.Name = "lblFechaHasta";
            lblFechaHasta.Size = new Size(38, 15);
            lblFechaHasta.TabIndex = 6;
            lblFechaHasta.Text = "Hasta";
            // 
            // dtpFechaDesde
            // 
            dtpFechaDesde.Format = DateTimePickerFormat.Short;
            dtpFechaDesde.Location = new Point(74, 106);
            dtpFechaDesde.Name = "dtpFechaDesde";
            dtpFechaDesde.Size = new Size(105, 23);
            dtpFechaDesde.TabIndex = 5;
            // 
            // lblFechaDesde
            // 
            lblFechaDesde.AutoSize = true;
            lblFechaDesde.Location = new Point(18, 110);
            lblFechaDesde.Name = "lblFechaDesde";
            lblFechaDesde.Size = new Size(39, 15);
            lblFechaDesde.TabIndex = 4;
            lblFechaDesde.Text = "Desde";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(105, 66);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(235, 23);
            txtUsuario.TabIndex = 3;
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(18, 69);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(47, 15);
            lblUsuario.TabIndex = 2;
            lblUsuario.Text = "Usuario";
            // 
            // txtIdFactura
            // 
            txtIdFactura.Location = new Point(105, 30);
            txtIdFactura.Name = "txtIdFactura";
            txtIdFactura.Size = new Size(100, 23);
            txtIdFactura.TabIndex = 1;
            // 
            // lblIdFactura
            // 
            lblIdFactura.AutoSize = true;
            lblIdFactura.Location = new Point(18, 33);
            lblIdFactura.Name = "lblIdFactura";
            lblIdFactura.Size = new Size(57, 15);
            lblIdFactura.TabIndex = 0;
            lblIdFactura.Text = "Id factura";
            // 
            // grpFiltrosCliente
            // 
            grpFiltrosCliente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpFiltrosCliente.Controls.Add(txtApellidoCliente);
            grpFiltrosCliente.Controls.Add(lblApellidoCliente);
            grpFiltrosCliente.Controls.Add(txtNombreCliente);
            grpFiltrosCliente.Controls.Add(lblNombreCliente);
            grpFiltrosCliente.Controls.Add(txtDocumentoCliente);
            grpFiltrosCliente.Controls.Add(lblDocumentoCliente);
            grpFiltrosCliente.Controls.Add(txtIdCliente);
            grpFiltrosCliente.Controls.Add(lblIdCliente);
            grpFiltrosCliente.Location = new Point(925, 250);
            grpFiltrosCliente.Name = "grpFiltrosCliente";
            grpFiltrosCliente.Size = new Size(360, 160);
            grpFiltrosCliente.TabIndex = 4;
            grpFiltrosCliente.TabStop = false;
            grpFiltrosCliente.Text = "Cliente";
            // 
            // txtApellidoCliente
            // 
            txtApellidoCliente.Location = new Point(105, 118);
            txtApellidoCliente.Name = "txtApellidoCliente";
            txtApellidoCliente.Size = new Size(235, 23);
            txtApellidoCliente.TabIndex = 7;
            // 
            // lblApellidoCliente
            // 
            lblApellidoCliente.AutoSize = true;
            lblApellidoCliente.Location = new Point(18, 121);
            lblApellidoCliente.Name = "lblApellidoCliente";
            lblApellidoCliente.Size = new Size(51, 15);
            lblApellidoCliente.TabIndex = 6;
            lblApellidoCliente.Text = "Apellido";
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.Location = new Point(105, 88);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.Size = new Size(235, 23);
            txtNombreCliente.TabIndex = 5;
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Location = new Point(18, 91);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(51, 15);
            lblNombreCliente.TabIndex = 4;
            lblNombreCliente.Text = "Nombre";
            // 
            // txtDocumentoCliente
            // 
            txtDocumentoCliente.Location = new Point(105, 58);
            txtDocumentoCliente.Name = "txtDocumentoCliente";
            txtDocumentoCliente.Size = new Size(160, 23);
            txtDocumentoCliente.TabIndex = 3;
            // 
            // lblDocumentoCliente
            // 
            lblDocumentoCliente.AutoSize = true;
            lblDocumentoCliente.Location = new Point(18, 61);
            lblDocumentoCliente.Name = "lblDocumentoCliente";
            lblDocumentoCliente.Size = new Size(70, 15);
            lblDocumentoCliente.TabIndex = 2;
            lblDocumentoCliente.Text = "Documento";
            // 
            // txtIdCliente
            // 
            txtIdCliente.Location = new Point(105, 28);
            txtIdCliente.Name = "txtIdCliente";
            txtIdCliente.Size = new Size(100, 23);
            txtIdCliente.TabIndex = 1;
            // 
            // lblIdCliente
            // 
            lblIdCliente.AutoSize = true;
            lblIdCliente.Location = new Point(18, 31);
            lblIdCliente.Name = "lblIdCliente";
            lblIdCliente.Size = new Size(55, 15);
            lblIdCliente.TabIndex = 0;
            lblIdCliente.Text = "Id cliente";
            // 
            // pnlAccionesBusqueda
            // 
            pnlAccionesBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlAccionesBusqueda.Controls.Add(btnLimpiarBusqueda);
            pnlAccionesBusqueda.Controls.Add(btnBuscar);
            pnlAccionesBusqueda.Location = new Point(925, 430);
            pnlAccionesBusqueda.Name = "pnlAccionesBusqueda";
            pnlAccionesBusqueda.Size = new Size(360, 55);
            pnlAccionesBusqueda.TabIndex = 5;
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Location = new Point(191, 14);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(118, 27);
            btnLimpiarBusqueda.TabIndex = 1;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(50, 14);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(118, 27);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // FormConsultarVentas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1307, 681);
            Controls.Add(pnlAccionesBusqueda);
            Controls.Add(grpFiltrosCliente);
            Controls.Add(grpFiltrosFactura);
            Controls.Add(dgvFacturaItems);
            Controls.Add(dgvFacturas);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1256, 720);
            Name = "FormConsultarVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultar ventas";
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvFacturaItems).EndInit();
            grpFiltrosFactura.ResumeLayout(false);
            grpFiltrosFactura.PerformLayout();
            grpFiltrosCliente.ResumeLayout(false);
            grpFiltrosCliente.PerformLayout();
            pnlAccionesBusqueda.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvFacturas;
        private DataGridViewTextBoxColumn colIdFactura;
        private DataGridViewTextBoxColumn colIdCliente;
        private DataGridViewTextBoxColumn colNombreCliente;
        private DataGridViewTextBoxColumn colApellidoCliente;
        private DataGridViewTextBoxColumn colDocumentoCliente;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colFechaEmision;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colEstado;
        private DataGridView dgvFacturaItems;
        private DataGridViewTextBoxColumn colIdFacturaItem;
        private DataGridViewTextBoxColumn colIdProducto;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colMarca;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colPrecioUnitario;
        private DataGridViewTextBoxColumn colSubtotal;
        private DataGridViewTextBoxColumn colEstadoItem;
        private GroupBox grpFiltrosFactura;
        private DateTimePicker dtpFechaHasta;
        private Label lblFechaHasta;
        private DateTimePicker dtpFechaDesde;
        private Label lblFechaDesde;
        private TextBox txtUsuario;
        private Label lblUsuario;
        private TextBox txtIdFactura;
        private Label lblIdFactura;
        private GroupBox grpFiltrosCliente;
        private TextBox txtApellidoCliente;
        private Label lblApellidoCliente;
        private TextBox txtNombreCliente;
        private Label lblNombreCliente;
        private TextBox txtDocumentoCliente;
        private Label lblDocumentoCliente;
        private TextBox txtIdCliente;
        private Label lblIdCliente;
        private Panel pnlAccionesBusqueda;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
    }
}



