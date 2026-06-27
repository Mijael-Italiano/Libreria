namespace Libreria.UI
{
    partial class FormItemsFactura
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
            dgvFacturaItems = new DataGridView();
            colIdFacturaItem = new DataGridViewTextBoxColumn();
            colIdProducto = new DataGridViewTextBoxColumn();
            colProducto = new DataGridViewTextBoxColumn();
            colMarca = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colPrecioUnitario = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            grpAgregarItem = new GroupBox();
            btnBuscarProducto = new Button();
            btnLimpiarAlta = new Button();
            btnAgregarItem = new Button();
            txtAltaSubtotal = new TextBox();
            lblAltaSubtotal = new Label();
            txtAltaCantidad = new TextBox();
            lblAltaCantidad = new Label();
            txtAltaPrecioUnitario = new TextBox();
            lblAltaPrecioUnitario = new Label();
            txtAltaStockActual = new TextBox();
            lblAltaStockActual = new Label();
            txtAltaCategoria = new TextBox();
            lblAltaCategoria = new Label();
            txtAltaMarca = new TextBox();
            lblAltaMarca = new Label();
            txtAltaDescripcion = new TextBox();
            lblAltaDescripcion = new Label();
            txtAltaIdProducto = new TextBox();
            lblAltaIdProducto = new Label();
            grpItemSeleccionado = new GroupBox();
            pnlAccionesItem = new Panel();
            btnLimpiarSeleccion = new Button();
            btnEliminarItem = new Button();
            btnModificarItem = new Button();
            txtEstado = new TextBox();
            lblEstado = new Label();
            txtSubtotal = new TextBox();
            lblSubtotal = new Label();
            txtCantidad = new TextBox();
            lblCantidad = new Label();
            txtPrecioUnitario = new TextBox();
            lblPrecioUnitario = new Label();
            txtStockActual = new TextBox();
            lblStockActual = new Label();
            txtCategoria = new TextBox();
            lblCategoria = new Label();
            txtMarca = new TextBox();
            lblMarca = new Label();
            txtDescripcion = new TextBox();
            lblDescripcion = new Label();
            txtIdProducto = new TextBox();
            lblIdProducto = new Label();
            txtIdFacturaItem = new TextBox();
            lblIdFacturaItem = new Label();
            grpResumenVenta = new GroupBox();
            btnCancelar = new Button();
            btnConfirmarVenta = new Button();
            txtCantidadItems = new TextBox();
            lblCantidadItems = new Label();
            txtTotalVenta = new TextBox();
            lblTotalVenta = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFacturaItems).BeginInit();
            grpAgregarItem.SuspendLayout();
            grpItemSeleccionado.SuspendLayout();
            pnlAccionesItem.SuspendLayout();
            grpResumenVenta.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(134, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Iniciar venta";
            // 
            // dgvFacturaItems
            // 
            dgvFacturaItems.AllowUserToAddRows = false;
            dgvFacturaItems.AllowUserToDeleteRows = false;
            dgvFacturaItems.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFacturaItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturaItems.BackgroundColor = SystemColors.Window;
            dgvFacturaItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturaItems.Columns.AddRange(new DataGridViewColumn[] { colIdFacturaItem, colIdProducto, colProducto, colMarca, colCategoria, colCantidad, colPrecioUnitario, colSubtotal, colEstado });
            dgvFacturaItems.Location = new Point(20, 72);
            dgvFacturaItems.MultiSelect = false;
            dgvFacturaItems.Name = "dgvFacturaItems";
            dgvFacturaItems.ReadOnly = true;
            dgvFacturaItems.RowHeadersVisible = false;
            dgvFacturaItems.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturaItems.Size = new Size(830, 300);
            dgvFacturaItems.TabIndex = 1;
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
            // colEstado
            // 
            colEstado.FillWeight = 65F;
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // grpAgregarItem
            // 
            grpAgregarItem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpAgregarItem.Controls.Add(btnBuscarProducto);
            grpAgregarItem.Controls.Add(btnLimpiarAlta);
            grpAgregarItem.Controls.Add(btnAgregarItem);
            grpAgregarItem.Controls.Add(txtAltaSubtotal);
            grpAgregarItem.Controls.Add(lblAltaSubtotal);
            grpAgregarItem.Controls.Add(txtAltaCantidad);
            grpAgregarItem.Controls.Add(lblAltaCantidad);
            grpAgregarItem.Controls.Add(txtAltaPrecioUnitario);
            grpAgregarItem.Controls.Add(lblAltaPrecioUnitario);
            grpAgregarItem.Controls.Add(txtAltaStockActual);
            grpAgregarItem.Controls.Add(lblAltaStockActual);
            grpAgregarItem.Controls.Add(txtAltaCategoria);
            grpAgregarItem.Controls.Add(lblAltaCategoria);
            grpAgregarItem.Controls.Add(txtAltaMarca);
            grpAgregarItem.Controls.Add(lblAltaMarca);
            grpAgregarItem.Controls.Add(txtAltaDescripcion);
            grpAgregarItem.Controls.Add(lblAltaDescripcion);
            grpAgregarItem.Controls.Add(txtAltaIdProducto);
            grpAgregarItem.Controls.Add(lblAltaIdProducto);
            grpAgregarItem.Location = new Point(20, 395);
            grpAgregarItem.Name = "grpAgregarItem";
            grpAgregarItem.Size = new Size(410, 255);
            grpAgregarItem.TabIndex = 2;
            grpAgregarItem.TabStop = false;
            grpAgregarItem.Text = "Agregar item";
            // 
            // btnBuscarProducto
            // 
            btnBuscarProducto.Location = new Point(179, 28);
            btnBuscarProducto.Name = "btnBuscarProducto";
            btnBuscarProducto.Size = new Size(118, 27);
            btnBuscarProducto.TabIndex = 2;
            btnBuscarProducto.Text = "Buscar producto";
            btnBuscarProducto.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarAlta
            // 
            btnLimpiarAlta.Location = new Point(261, 214);
            btnLimpiarAlta.Name = "btnLimpiarAlta";
            btnLimpiarAlta.Size = new Size(118, 27);
            btnLimpiarAlta.TabIndex = 18;
            btnLimpiarAlta.Text = "Limpiar";
            btnLimpiarAlta.UseVisualStyleBackColor = true;
            // 
            // btnAgregarItem
            // 
            btnAgregarItem.Location = new Point(129, 214);
            btnAgregarItem.Name = "btnAgregarItem";
            btnAgregarItem.Size = new Size(118, 27);
            btnAgregarItem.TabIndex = 17;
            btnAgregarItem.Text = "Agregar item";
            btnAgregarItem.UseVisualStyleBackColor = true;
            // 
            // txtAltaSubtotal
            // 
            txtAltaSubtotal.BackColor = SystemColors.Control;
            txtAltaSubtotal.ForeColor = SystemColors.ControlDark;
            txtAltaSubtotal.Location = new Point(279, 175);
            txtAltaSubtotal.Name = "txtAltaSubtotal";
            txtAltaSubtotal.ReadOnly = true;
            txtAltaSubtotal.Size = new Size(100, 23);
            txtAltaSubtotal.TabIndex = 16;
            // 
            // lblAltaSubtotal
            // 
            lblAltaSubtotal.AutoSize = true;
            lblAltaSubtotal.Location = new Point(211, 178);
            lblAltaSubtotal.Name = "lblAltaSubtotal";
            lblAltaSubtotal.Size = new Size(51, 15);
            lblAltaSubtotal.TabIndex = 15;
            lblAltaSubtotal.Text = "Subtotal";
            // 
            // txtAltaCantidad
            // 
            txtAltaCantidad.Location = new Point(105, 175);
            txtAltaCantidad.Name = "txtAltaCantidad";
            txtAltaCantidad.Size = new Size(70, 23);
            txtAltaCantidad.TabIndex = 14;
            // 
            // lblAltaCantidad
            // 
            lblAltaCantidad.AutoSize = true;
            lblAltaCantidad.Location = new Point(18, 178);
            lblAltaCantidad.Name = "lblAltaCantidad";
            lblAltaCantidad.Size = new Size(55, 15);
            lblAltaCantidad.TabIndex = 13;
            lblAltaCantidad.Text = "Cantidad";
            // 
            // txtAltaPrecioUnitario
            // 
            txtAltaPrecioUnitario.BackColor = SystemColors.Control;
            txtAltaPrecioUnitario.ForeColor = SystemColors.ControlDark;
            txtAltaPrecioUnitario.Location = new Point(279, 142);
            txtAltaPrecioUnitario.Name = "txtAltaPrecioUnitario";
            txtAltaPrecioUnitario.ReadOnly = true;
            txtAltaPrecioUnitario.Size = new Size(100, 23);
            txtAltaPrecioUnitario.TabIndex = 12;
            // 
            // lblAltaPrecioUnitario
            // 
            lblAltaPrecioUnitario.AutoSize = true;
            lblAltaPrecioUnitario.Location = new Point(211, 145);
            lblAltaPrecioUnitario.Name = "lblAltaPrecioUnitario";
            lblAltaPrecioUnitario.Size = new Size(40, 15);
            lblAltaPrecioUnitario.TabIndex = 11;
            lblAltaPrecioUnitario.Text = "Precio";
            // 
            // txtAltaStockActual
            // 
            txtAltaStockActual.BackColor = SystemColors.Control;
            txtAltaStockActual.ForeColor = SystemColors.ControlDark;
            txtAltaStockActual.Location = new Point(105, 142);
            txtAltaStockActual.Name = "txtAltaStockActual";
            txtAltaStockActual.ReadOnly = true;
            txtAltaStockActual.Size = new Size(70, 23);
            txtAltaStockActual.TabIndex = 10;
            // 
            // lblAltaStockActual
            // 
            lblAltaStockActual.AutoSize = true;
            lblAltaStockActual.Location = new Point(18, 145);
            lblAltaStockActual.Name = "lblAltaStockActual";
            lblAltaStockActual.Size = new Size(36, 15);
            lblAltaStockActual.TabIndex = 9;
            lblAltaStockActual.Text = "Stock";
            // 
            // txtAltaCategoria
            // 
            txtAltaCategoria.BackColor = SystemColors.Control;
            txtAltaCategoria.ForeColor = SystemColors.ControlDark;
            txtAltaCategoria.Location = new Point(279, 105);
            txtAltaCategoria.Name = "txtAltaCategoria";
            txtAltaCategoria.ReadOnly = true;
            txtAltaCategoria.Size = new Size(100, 23);
            txtAltaCategoria.TabIndex = 8;
            // 
            // lblAltaCategoria
            // 
            lblAltaCategoria.AutoSize = true;
            lblAltaCategoria.Location = new Point(211, 108);
            lblAltaCategoria.Name = "lblAltaCategoria";
            lblAltaCategoria.Size = new Size(58, 15);
            lblAltaCategoria.TabIndex = 7;
            lblAltaCategoria.Text = "Categoria";
            // 
            // txtAltaMarca
            // 
            txtAltaMarca.BackColor = SystemColors.Control;
            txtAltaMarca.ForeColor = SystemColors.ControlDark;
            txtAltaMarca.Location = new Point(105, 105);
            txtAltaMarca.Name = "txtAltaMarca";
            txtAltaMarca.ReadOnly = true;
            txtAltaMarca.Size = new Size(100, 23);
            txtAltaMarca.TabIndex = 6;
            // 
            // lblAltaMarca
            // 
            lblAltaMarca.AutoSize = true;
            lblAltaMarca.Location = new Point(18, 108);
            lblAltaMarca.Name = "lblAltaMarca";
            lblAltaMarca.Size = new Size(40, 15);
            lblAltaMarca.TabIndex = 5;
            lblAltaMarca.Text = "Marca";
            // 
            // txtAltaDescripcion
            // 
            txtAltaDescripcion.BackColor = SystemColors.Control;
            txtAltaDescripcion.ForeColor = SystemColors.ControlDark;
            txtAltaDescripcion.Location = new Point(105, 66);
            txtAltaDescripcion.Name = "txtAltaDescripcion";
            txtAltaDescripcion.ReadOnly = true;
            txtAltaDescripcion.Size = new Size(274, 23);
            txtAltaDescripcion.TabIndex = 4;
            // 
            // lblAltaDescripcion
            // 
            lblAltaDescripcion.AutoSize = true;
            lblAltaDescripcion.Location = new Point(18, 69);
            lblAltaDescripcion.Name = "lblAltaDescripcion";
            lblAltaDescripcion.Size = new Size(69, 15);
            lblAltaDescripcion.TabIndex = 3;
            lblAltaDescripcion.Text = "Descripcion";
            // 
            // txtAltaIdProducto
            // 
            txtAltaIdProducto.BackColor = SystemColors.Control;
            txtAltaIdProducto.ForeColor = SystemColors.ControlDark;
            txtAltaIdProducto.Location = new Point(105, 30);
            txtAltaIdProducto.Name = "txtAltaIdProducto";
            txtAltaIdProducto.ReadOnly = true;
            txtAltaIdProducto.Size = new Size(70, 23);
            txtAltaIdProducto.TabIndex = 1;
            // 
            // lblAltaIdProducto
            // 
            lblAltaIdProducto.AutoSize = true;
            lblAltaIdProducto.Location = new Point(18, 33);
            lblAltaIdProducto.Name = "lblAltaIdProducto";
            lblAltaIdProducto.Size = new Size(69, 15);
            lblAltaIdProducto.TabIndex = 0;
            lblAltaIdProducto.Text = "Id producto";
            // 
            // grpItemSeleccionado
            // 
            grpItemSeleccionado.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpItemSeleccionado.Controls.Add(pnlAccionesItem);
            grpItemSeleccionado.Controls.Add(txtEstado);
            grpItemSeleccionado.Controls.Add(lblEstado);
            grpItemSeleccionado.Controls.Add(txtSubtotal);
            grpItemSeleccionado.Controls.Add(lblSubtotal);
            grpItemSeleccionado.Controls.Add(txtCantidad);
            grpItemSeleccionado.Controls.Add(lblCantidad);
            grpItemSeleccionado.Controls.Add(txtPrecioUnitario);
            grpItemSeleccionado.Controls.Add(lblPrecioUnitario);
            grpItemSeleccionado.Controls.Add(txtStockActual);
            grpItemSeleccionado.Controls.Add(lblStockActual);
            grpItemSeleccionado.Controls.Add(txtCategoria);
            grpItemSeleccionado.Controls.Add(lblCategoria);
            grpItemSeleccionado.Controls.Add(txtMarca);
            grpItemSeleccionado.Controls.Add(lblMarca);
            grpItemSeleccionado.Controls.Add(txtDescripcion);
            grpItemSeleccionado.Controls.Add(lblDescripcion);
            grpItemSeleccionado.Controls.Add(txtIdProducto);
            grpItemSeleccionado.Controls.Add(lblIdProducto);
            grpItemSeleccionado.Controls.Add(txtIdFacturaItem);
            grpItemSeleccionado.Controls.Add(lblIdFacturaItem);
            grpItemSeleccionado.Location = new Point(450, 395);
            grpItemSeleccionado.Name = "grpItemSeleccionado";
            grpItemSeleccionado.Size = new Size(585, 255);
            grpItemSeleccionado.TabIndex = 3;
            grpItemSeleccionado.TabStop = false;
            grpItemSeleccionado.Text = "Item seleccionado";
            // 
            // pnlAccionesItem
            // 
            pnlAccionesItem.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAccionesItem.Controls.Add(btnLimpiarSeleccion);
            pnlAccionesItem.Controls.Add(btnEliminarItem);
            pnlAccionesItem.Controls.Add(btnModificarItem);
            pnlAccionesItem.Location = new Point(213, 199);
            pnlAccionesItem.Name = "pnlAccionesItem";
            pnlAccionesItem.Size = new Size(360, 46);
            pnlAccionesItem.TabIndex = 16;
            // 
            // btnLimpiarSeleccion
            // 
            btnLimpiarSeleccion.Location = new Point(242, 10);
            btnLimpiarSeleccion.Name = "btnLimpiarSeleccion";
            btnLimpiarSeleccion.Size = new Size(105, 27);
            btnLimpiarSeleccion.TabIndex = 2;
            btnLimpiarSeleccion.Text = "Limpiar";
            btnLimpiarSeleccion.UseVisualStyleBackColor = true;
            // 
            // btnEliminarItem
            // 
            btnEliminarItem.Location = new Point(126, 10);
            btnEliminarItem.Name = "btnEliminarItem";
            btnEliminarItem.Size = new Size(105, 27);
            btnEliminarItem.TabIndex = 1;
            btnEliminarItem.Text = "Eliminar item";
            btnEliminarItem.UseVisualStyleBackColor = true;
            // 
            // btnModificarItem
            // 
            btnModificarItem.Location = new Point(10, 10);
            btnModificarItem.Name = "btnModificarItem";
            btnModificarItem.Size = new Size(105, 27);
            btnModificarItem.TabIndex = 0;
            btnModificarItem.Text = "Modificar item";
            btnModificarItem.UseVisualStyleBackColor = true;
            // 
            // txtEstado
            // 
            txtEstado.BackColor = SystemColors.Control;
            txtEstado.ForeColor = SystemColors.ControlDark;
            txtEstado.Location = new Point(421, 144);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(120, 23);
            txtEstado.TabIndex = 19;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(339, 147);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(42, 15);
            lblEstado.TabIndex = 18;
            lblEstado.Text = "Estado";
            // 
            // txtSubtotal
            // 
            txtSubtotal.BackColor = SystemColors.Control;
            txtSubtotal.ForeColor = SystemColors.ControlDark;
            txtSubtotal.Location = new Point(421, 105);
            txtSubtotal.Name = "txtSubtotal";
            txtSubtotal.ReadOnly = true;
            txtSubtotal.Size = new Size(120, 23);
            txtSubtotal.TabIndex = 15;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Location = new Point(339, 108);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(51, 15);
            lblSubtotal.TabIndex = 14;
            lblSubtotal.Text = "Subtotal";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(421, 66);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(70, 23);
            txtCantidad.TabIndex = 13;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(339, 69);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(55, 15);
            lblCantidad.TabIndex = 12;
            lblCantidad.Text = "Cantidad";
            // 
            // txtPrecioUnitario
            // 
            txtPrecioUnitario.BackColor = SystemColors.Control;
            txtPrecioUnitario.ForeColor = SystemColors.ControlDark;
            txtPrecioUnitario.Location = new Point(421, 30);
            txtPrecioUnitario.Name = "txtPrecioUnitario";
            txtPrecioUnitario.ReadOnly = true;
            txtPrecioUnitario.Size = new Size(120, 23);
            txtPrecioUnitario.TabIndex = 11;
            // 
            // lblPrecioUnitario
            // 
            lblPrecioUnitario.AutoSize = true;
            lblPrecioUnitario.Location = new Point(339, 33);
            lblPrecioUnitario.Name = "lblPrecioUnitario";
            lblPrecioUnitario.Size = new Size(40, 15);
            lblPrecioUnitario.TabIndex = 10;
            lblPrecioUnitario.Text = "Precio";
            // 
            // txtStockActual
            // 
            txtStockActual.BackColor = SystemColors.Control;
            txtStockActual.ForeColor = SystemColors.ControlDark;
            txtStockActual.Location = new Point(105, 214);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.ReadOnly = true;
            txtStockActual.Size = new Size(70, 23);
            txtStockActual.TabIndex = 9;
            // 
            // lblStockActual
            // 
            lblStockActual.AutoSize = true;
            lblStockActual.Location = new Point(18, 217);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(36, 15);
            lblStockActual.TabIndex = 8;
            lblStockActual.Text = "Stock";
            // 
            // txtCategoria
            // 
            txtCategoria.BackColor = SystemColors.Control;
            txtCategoria.ForeColor = SystemColors.ControlDark;
            txtCategoria.Location = new Point(105, 177);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.ReadOnly = true;
            txtCategoria.Size = new Size(185, 23);
            txtCategoria.TabIndex = 7;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(18, 180);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(58, 15);
            lblCategoria.TabIndex = 6;
            lblCategoria.Text = "Categoria";
            // 
            // txtMarca
            // 
            txtMarca.BackColor = SystemColors.Control;
            txtMarca.ForeColor = SystemColors.ControlDark;
            txtMarca.Location = new Point(105, 142);
            txtMarca.Name = "txtMarca";
            txtMarca.ReadOnly = true;
            txtMarca.Size = new Size(185, 23);
            txtMarca.TabIndex = 5;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(18, 145);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(40, 15);
            lblMarca.TabIndex = 4;
            lblMarca.Text = "Marca";
            // 
            // txtDescripcion
            // 
            txtDescripcion.BackColor = SystemColors.Control;
            txtDescripcion.ForeColor = SystemColors.ControlDark;
            txtDescripcion.Location = new Point(105, 101);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.Size = new Size(185, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(18, 104);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(69, 15);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripcion";
            // 
            // txtIdProducto
            // 
            txtIdProducto.BackColor = SystemColors.Control;
            txtIdProducto.ForeColor = SystemColors.ControlDark;
            txtIdProducto.Location = new Point(105, 65);
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.ReadOnly = true;
            txtIdProducto.Size = new Size(70, 23);
            txtIdProducto.TabIndex = 1;
            // 
            // lblIdProducto
            // 
            lblIdProducto.AutoSize = true;
            lblIdProducto.Location = new Point(18, 68);
            lblIdProducto.Name = "lblIdProducto";
            lblIdProducto.Size = new Size(69, 15);
            lblIdProducto.TabIndex = 0;
            lblIdProducto.Text = "Id producto";
            // 
            // txtIdFacturaItem
            // 
            txtIdFacturaItem.BackColor = SystemColors.Control;
            txtIdFacturaItem.ForeColor = SystemColors.ControlDark;
            txtIdFacturaItem.Location = new Point(105, 30);
            txtIdFacturaItem.Name = "txtIdFacturaItem";
            txtIdFacturaItem.ReadOnly = true;
            txtIdFacturaItem.Size = new Size(70, 23);
            txtIdFacturaItem.TabIndex = 1;
            // 
            // lblIdFacturaItem
            // 
            lblIdFacturaItem.AutoSize = true;
            lblIdFacturaItem.Location = new Point(18, 33);
            lblIdFacturaItem.Name = "lblIdFacturaItem";
            lblIdFacturaItem.Size = new Size(43, 15);
            lblIdFacturaItem.TabIndex = 0;
            lblIdFacturaItem.Text = "Id item";
            // 
            // grpResumenVenta
            // 
            grpResumenVenta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            grpResumenVenta.Controls.Add(btnCancelar);
            grpResumenVenta.Controls.Add(btnConfirmarVenta);
            grpResumenVenta.Controls.Add(txtCantidadItems);
            grpResumenVenta.Controls.Add(lblCantidadItems);
            grpResumenVenta.Controls.Add(txtTotalVenta);
            grpResumenVenta.Controls.Add(lblTotalVenta);
            grpResumenVenta.Location = new Point(870, 72);
            grpResumenVenta.Name = "grpResumenVenta";
            grpResumenVenta.Size = new Size(250, 300);
            grpResumenVenta.TabIndex = 4;
            grpResumenVenta.TabStop = false;
            grpResumenVenta.Text = "Resumen de venta";
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(127, 244);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(105, 27);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConfirmarVenta
            // 
            btnConfirmarVenta.Location = new Point(16, 244);
            btnConfirmarVenta.Name = "btnConfirmarVenta";
            btnConfirmarVenta.Size = new Size(105, 27);
            btnConfirmarVenta.TabIndex = 4;
            btnConfirmarVenta.Text = "Confirmar venta";
            btnConfirmarVenta.UseVisualStyleBackColor = true;
            // 
            // txtCantidadItems
            // 
            txtCantidadItems.BackColor = SystemColors.Control;
            txtCantidadItems.ForeColor = SystemColors.ControlDark;
            txtCantidadItems.Location = new Point(112, 64);
            txtCantidadItems.Name = "txtCantidadItems";
            txtCantidadItems.ReadOnly = true;
            txtCantidadItems.Size = new Size(120, 23);
            txtCantidadItems.TabIndex = 3;
            // 
            // lblCantidadItems
            // 
            lblCantidadItems.AutoSize = true;
            lblCantidadItems.Location = new Point(16, 67);
            lblCantidadItems.Name = "lblCantidadItems";
            lblCantidadItems.Size = new Size(87, 15);
            lblCantidadItems.TabIndex = 2;
            lblCantidadItems.Text = "Cantidad items";
            // 
            // txtTotalVenta
            // 
            txtTotalVenta.BackColor = SystemColors.Control;
            txtTotalVenta.ForeColor = SystemColors.ControlDark;
            txtTotalVenta.Location = new Point(112, 30);
            txtTotalVenta.Name = "txtTotalVenta";
            txtTotalVenta.ReadOnly = true;
            txtTotalVenta.Size = new Size(120, 23);
            txtTotalVenta.TabIndex = 1;
            // 
            // lblTotalVenta
            // 
            lblTotalVenta.AutoSize = true;
            lblTotalVenta.Location = new Point(16, 33);
            lblTotalVenta.Name = "lblTotalVenta";
            lblTotalVenta.Size = new Size(32, 15);
            lblTotalVenta.TabIndex = 0;
            lblTotalVenta.Text = "Total";
            // 
            // FormItemsFactura
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1144, 681);
            Controls.Add(grpResumenVenta);
            Controls.Add(grpItemSeleccionado);
            Controls.Add(grpAgregarItem);
            Controls.Add(dgvFacturaItems);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1120, 720);
            Name = "FormItemsFactura";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar venta";
            ((System.ComponentModel.ISupportInitialize)dgvFacturaItems).EndInit();
            grpAgregarItem.ResumeLayout(false);
            grpAgregarItem.PerformLayout();
            grpItemSeleccionado.ResumeLayout(false);
            grpItemSeleccionado.PerformLayout();
            pnlAccionesItem.ResumeLayout(false);
            grpResumenVenta.ResumeLayout(false);
            grpResumenVenta.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvFacturaItems;
        private DataGridViewTextBoxColumn colIdFacturaItem;
        private DataGridViewTextBoxColumn colIdProducto;
        private DataGridViewTextBoxColumn colProducto;
        private DataGridViewTextBoxColumn colMarca;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colPrecioUnitario;
        private DataGridViewTextBoxColumn colSubtotal;
        private DataGridViewTextBoxColumn colEstado;
        private GroupBox grpAgregarItem;
        private Button btnBuscarProducto;
        private Button btnLimpiarAlta;
        private Button btnAgregarItem;
        private TextBox txtAltaSubtotal;
        private Label lblAltaSubtotal;
        private TextBox txtAltaCantidad;
        private Label lblAltaCantidad;
        private TextBox txtAltaPrecioUnitario;
        private Label lblAltaPrecioUnitario;
        private TextBox txtAltaStockActual;
        private Label lblAltaStockActual;
        private TextBox txtAltaCategoria;
        private Label lblAltaCategoria;
        private TextBox txtAltaMarca;
        private Label lblAltaMarca;
        private TextBox txtAltaDescripcion;
        private Label lblAltaDescripcion;
        private TextBox txtAltaIdProducto;
        private Label lblAltaIdProducto;
        private GroupBox grpItemSeleccionado;
        private Panel pnlAccionesItem;
        private Button btnLimpiarSeleccion;
        private Button btnEliminarItem;
        private Button btnModificarItem;
        private TextBox txtEstado;
        private Label lblEstado;
        private TextBox txtSubtotal;
        private Label lblSubtotal;
        private TextBox txtCantidad;
        private Label lblCantidad;
        private TextBox txtPrecioUnitario;
        private Label lblPrecioUnitario;
        private TextBox txtStockActual;
        private Label lblStockActual;
        private TextBox txtCategoria;
        private Label lblCategoria;
        private TextBox txtMarca;
        private Label lblMarca;
        private TextBox txtDescripcion;
        private Label lblDescripcion;
        private TextBox txtIdProducto;
        private Label lblIdProducto;
        private TextBox txtIdFacturaItem;
        private Label lblIdFacturaItem;
        private GroupBox grpResumenVenta;
        private Button btnCancelar;
        private Button btnConfirmarVenta;
        private TextBox txtCantidadItems;
        private Label lblCantidadItems;
        private TextBox txtTotalVenta;
        private Label lblTotalVenta;
    }
}
