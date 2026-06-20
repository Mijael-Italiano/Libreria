namespace Libreria.UI
{
    partial class FormAdministrarProductos
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
            dgvInventario = new DataGridView();
            colIdProducto = new DataGridViewTextBoxColumn();
            colIdMarca = new DataGridViewTextBoxColumn();
            colIdCategoria = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colPrecioUnitario = new DataGridViewTextBoxColumn();
            colStockActual = new DataGridViewTextBoxColumn();
            colStockMinimo = new DataGridViewTextBoxColumn();
            colFechaUltimaActualizacion = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewCheckBoxColumn();
            grpBusquedaInventario = new GroupBox();
            txtBuscarIdProducto = new TextBox();
            lblBuscarIdProducto = new Label();
            txtBuscarIdMarca = new TextBox();
            lblBuscarIdMarca = new Label();
            txtBuscarIdCategoria = new TextBox();
            lblBuscarIdCategoria = new Label();
            txtBuscarMarca = new TextBox();
            lblBuscarMarca = new Label();
            txtBuscarCategoria = new TextBox();
            lblBuscarCategoria = new Label();
            btnBusquedaSeleccionarMarca = new Button();
            btnBusquedaSeleccionarCategoria = new Button();
            btnLimpiarBusquedaInventario = new Button();
            btnBuscarInventario = new Button();
            grpAltaProducto = new GroupBox();
            txtAltaIdProducto = new TextBox();
            lblAltaIdProducto = new Label();
            txtAltaIdMarca = new TextBox();
            lblAltaIdMarca = new Label();
            txtAltaIdCategoria = new TextBox();
            lblAltaIdCategoria = new Label();
            txtAltaStockMinimo = new TextBox();
            lblAltaStockMinimo = new Label();
            txtAltaStockActual = new TextBox();
            lblAltaStockActual = new Label();
            txtAltaPrecioUnitario = new TextBox();
            lblAltaPrecioUnitario = new Label();
            txtAltaFechaUltimaActualizacion = new TextBox();
            lblAltaFechaUltimaActualizacion = new Label();
            chkAltaEstado = new CheckBox();
            txtAltaCategoria = new TextBox();
            lblAltaCategoria = new Label();
            txtAltaMarca = new TextBox();
            lblAltaMarca = new Label();
            txtAltaDescripcion = new TextBox();
            lblAltaDescripcion = new Label();
            btnAltaSeleccionarMarca = new Button();
            btnAltaSeleccionarCategoria = new Button();
            btnAgregarProducto = new Button();
            grpDatosProducto = new GroupBox();
            chkEstado = new CheckBox();
            btnSeleccionadoSeleccionarMarca = new Button();
            btnSeleccionadoSeleccionarCategoria = new Button();
            pnlAcciones = new Panel();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            txtFechaAlta = new TextBox();
            lblFechaAlta = new Label();
            txtFechaUltimaActualizacion = new TextBox();
            lblFechaUltimaActualizacion = new Label();
            txtStockMinimo = new TextBox();
            lblStockMinimo = new Label();
            txtStockActual = new TextBox();
            lblStockActual = new Label();
            txtPrecioUnitario = new TextBox();
            lblPrecioUnitario = new Label();
            txtCategoria = new TextBox();
            lblCategoria = new Label();
            txtMarca = new TextBox();
            lblMarca = new Label();
            txtDescripcion = new TextBox();
            lblDescripcion = new Label();
            txtIdProducto = new TextBox();
            lblIdProducto = new Label();
            txtIdMarca = new TextBox();
            lblIdMarca = new Label();
            txtIdCategoria = new TextBox();
            lblIdCategoria = new Label();
            txtIdInventario = new TextBox();
            lblIdInventario = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            grpBusquedaInventario.SuspendLayout();
            grpAltaProducto.SuspendLayout();
            grpDatosProducto.SuspendLayout();
            pnlAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(248, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Administrar productos";
            // 
            // dgvInventario
            // 
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AllowUserToDeleteRows = false;
            dgvInventario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventario.BackgroundColor = SystemColors.Window;
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Columns.AddRange(new DataGridViewColumn[] { colIdProducto, colIdMarca, colIdCategoria, colDescripcion, colPrecioUnitario, colStockActual, colStockMinimo, colFechaUltimaActualizacion, colEstado });
            dgvInventario.Location = new Point(20, 82);
            dgvInventario.MultiSelect = false;
            dgvInventario.Name = "dgvInventario";
            dgvInventario.ReadOnly = true;
            dgvInventario.RowHeadersVisible = false;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new Size(991, 300);
            dgvInventario.TabIndex = 1;
            // 
            // colIdProducto
            // 
            colIdProducto.FillWeight = 55F;
            colIdProducto.HeaderText = "Id producto";
            colIdProducto.Name = "colIdProducto";
            colIdProducto.ReadOnly = true;
            // 
            // colIdMarca
            // 
            colIdMarca.FillWeight = 55F;
            colIdMarca.HeaderText = "Marca";
            colIdMarca.Name = "colIdMarca";
            colIdMarca.ReadOnly = true;
            // 
            // colIdCategoria
            // 
            colIdCategoria.FillWeight = 65F;
            colIdCategoria.HeaderText = "Categoría";
            colIdCategoria.Name = "colIdCategoria";
            colIdCategoria.ReadOnly = true;
            // 
            // colDescripcion
            // 
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // colPrecioUnitario
            // 
            colPrecioUnitario.FillWeight = 70F;
            colPrecioUnitario.HeaderText = "Precio unitario";
            colPrecioUnitario.Name = "colPrecioUnitario";
            colPrecioUnitario.ReadOnly = true;
            // 
            // colStockActual
            // 
            colStockActual.FillWeight = 65F;
            colStockActual.HeaderText = "Stock";
            colStockActual.Name = "colStockActual";
            colStockActual.ReadOnly = true;
            // 
            // colStockMinimo
            // 
            colStockMinimo.FillWeight = 75F;
            colStockMinimo.HeaderText = "Stock mínimo";
            colStockMinimo.Name = "colStockMinimo";
            colStockMinimo.ReadOnly = true;
            // 
            // colFechaUltimaActualizacion
            // 
            colFechaUltimaActualizacion.HeaderText = "Fecha última actualización";
            colFechaUltimaActualizacion.Name = "colFechaUltimaActualizacion";
            colFechaUltimaActualizacion.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.FillWeight = 50F;
            colEstado.HeaderText = "Activo";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // grpBusquedaInventario
            // 
            grpBusquedaInventario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpBusquedaInventario.Controls.Add(txtBuscarIdProducto);
            grpBusquedaInventario.Controls.Add(lblBuscarIdProducto);
            grpBusquedaInventario.Controls.Add(txtBuscarIdMarca);
            grpBusquedaInventario.Controls.Add(lblBuscarIdMarca);
            grpBusquedaInventario.Controls.Add(txtBuscarIdCategoria);
            grpBusquedaInventario.Controls.Add(lblBuscarIdCategoria);
            grpBusquedaInventario.Controls.Add(txtBuscarMarca);
            grpBusquedaInventario.Controls.Add(lblBuscarMarca);
            grpBusquedaInventario.Controls.Add(txtBuscarCategoria);
            grpBusquedaInventario.Controls.Add(lblBuscarCategoria);
            grpBusquedaInventario.Controls.Add(btnBusquedaSeleccionarMarca);
            grpBusquedaInventario.Controls.Add(btnBusquedaSeleccionarCategoria);
            grpBusquedaInventario.Controls.Add(btnLimpiarBusquedaInventario);
            grpBusquedaInventario.Controls.Add(btnBuscarInventario);
            grpBusquedaInventario.Location = new Point(1030, 18);
            grpBusquedaInventario.Name = "grpBusquedaInventario";
            grpBusquedaInventario.Size = new Size(312, 235);
            grpBusquedaInventario.TabIndex = 2;
            grpBusquedaInventario.TabStop = false;
            grpBusquedaInventario.Text = "Buscar producto";
            // 
            // txtBuscarIdProducto
            // 
            txtBuscarIdProducto.Location = new Point(95, 28);
            txtBuscarIdProducto.Name = "txtBuscarIdProducto";
            txtBuscarIdProducto.Size = new Size(196, 23);
            txtBuscarIdProducto.TabIndex = 1;
            // 
            // lblBuscarIdProducto
            // 
            lblBuscarIdProducto.AutoSize = true;
            lblBuscarIdProducto.Location = new Point(15, 31);
            lblBuscarIdProducto.Name = "lblBuscarIdProducto";
            lblBuscarIdProducto.Size = new Size(69, 15);
            lblBuscarIdProducto.TabIndex = 0;
            lblBuscarIdProducto.Text = "Id producto";
            // 
            // txtBuscarIdMarca
            // 
            txtBuscarIdMarca.BackColor = SystemColors.Control;
            txtBuscarIdMarca.ForeColor = SystemColors.ControlDark;
            txtBuscarIdMarca.Location = new Point(95, 57);
            txtBuscarIdMarca.Name = "txtBuscarIdMarca";
            txtBuscarIdMarca.ReadOnly = true;
            txtBuscarIdMarca.Size = new Size(70, 23);
            txtBuscarIdMarca.TabIndex = 10;
            // 
            // lblBuscarIdMarca
            // 
            lblBuscarIdMarca.AutoSize = true;
            lblBuscarIdMarca.Location = new Point(15, 60);
            lblBuscarIdMarca.Name = "lblBuscarIdMarca";
            lblBuscarIdMarca.Size = new Size(53, 15);
            lblBuscarIdMarca.TabIndex = 11;
            lblBuscarIdMarca.Text = "Id marca";
            // 
            // txtBuscarIdCategoria
            // 
            txtBuscarIdCategoria.BackColor = SystemColors.Control;
            txtBuscarIdCategoria.ForeColor = SystemColors.ControlDark;
            txtBuscarIdCategoria.Location = new Point(95, 115);
            txtBuscarIdCategoria.Name = "txtBuscarIdCategoria";
            txtBuscarIdCategoria.ReadOnly = true;
            txtBuscarIdCategoria.Size = new Size(70, 23);
            txtBuscarIdCategoria.TabIndex = 12;
            // 
            // lblBuscarIdCategoria
            // 
            lblBuscarIdCategoria.AutoSize = true;
            lblBuscarIdCategoria.Location = new Point(15, 118);
            lblBuscarIdCategoria.Name = "lblBuscarIdCategoria";
            lblBuscarIdCategoria.Size = new Size(69, 15);
            lblBuscarIdCategoria.TabIndex = 13;
            lblBuscarIdCategoria.Text = "Id categoria";
            // 
            // txtBuscarMarca
            // 
            txtBuscarMarca.BackColor = SystemColors.Control;
            txtBuscarMarca.ForeColor = SystemColors.ControlDark;
            txtBuscarMarca.Location = new Point(95, 86);
            txtBuscarMarca.Name = "txtBuscarMarca";
            txtBuscarMarca.ReadOnly = true;
            txtBuscarMarca.Size = new Size(196, 23);
            txtBuscarMarca.TabIndex = 6;
            // 
            // lblBuscarMarca
            // 
            lblBuscarMarca.AutoSize = true;
            lblBuscarMarca.Location = new Point(15, 89);
            lblBuscarMarca.Name = "lblBuscarMarca";
            lblBuscarMarca.Size = new Size(40, 15);
            lblBuscarMarca.TabIndex = 7;
            lblBuscarMarca.Text = "Marca";
            // 
            // txtBuscarCategoria
            // 
            txtBuscarCategoria.BackColor = SystemColors.Control;
            txtBuscarCategoria.ForeColor = SystemColors.ControlDark;
            txtBuscarCategoria.Location = new Point(95, 144);
            txtBuscarCategoria.Name = "txtBuscarCategoria";
            txtBuscarCategoria.ReadOnly = true;
            txtBuscarCategoria.Size = new Size(196, 23);
            txtBuscarCategoria.TabIndex = 8;
            // 
            // lblBuscarCategoria
            // 
            lblBuscarCategoria.AutoSize = true;
            lblBuscarCategoria.Location = new Point(15, 147);
            lblBuscarCategoria.Name = "lblBuscarCategoria";
            lblBuscarCategoria.Size = new Size(58, 15);
            lblBuscarCategoria.TabIndex = 9;
            lblBuscarCategoria.Text = "Categoría";
            // 
            // btnBusquedaSeleccionarMarca
            // 
            btnBusquedaSeleccionarMarca.Location = new Point(175, 55);
            btnBusquedaSeleccionarMarca.Name = "btnBusquedaSeleccionarMarca";
            btnBusquedaSeleccionarMarca.Size = new Size(50, 27);
            btnBusquedaSeleccionarMarca.TabIndex = 4;
            btnBusquedaSeleccionarMarca.Text = "...";
            btnBusquedaSeleccionarMarca.UseVisualStyleBackColor = true;
            // 
            // btnBusquedaSeleccionarCategoria
            // 
            btnBusquedaSeleccionarCategoria.Location = new Point(175, 113);
            btnBusquedaSeleccionarCategoria.Name = "btnBusquedaSeleccionarCategoria";
            btnBusquedaSeleccionarCategoria.Size = new Size(50, 27);
            btnBusquedaSeleccionarCategoria.TabIndex = 5;
            btnBusquedaSeleccionarCategoria.Text = "...";
            btnBusquedaSeleccionarCategoria.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarBusquedaInventario
            // 
            btnLimpiarBusquedaInventario.Location = new Point(167, 183);
            btnLimpiarBusquedaInventario.Name = "btnLimpiarBusquedaInventario";
            btnLimpiarBusquedaInventario.Size = new Size(118, 27);
            btnLimpiarBusquedaInventario.TabIndex = 3;
            btnLimpiarBusquedaInventario.Text = "Limpiar";
            btnLimpiarBusquedaInventario.UseVisualStyleBackColor = true;
            // 
            // btnBuscarInventario
            // 
            btnBuscarInventario.Location = new Point(40, 183);
            btnBuscarInventario.Name = "btnBuscarInventario";
            btnBuscarInventario.Size = new Size(118, 27);
            btnBuscarInventario.TabIndex = 2;
            btnBuscarInventario.Text = "Buscar";
            btnBuscarInventario.UseVisualStyleBackColor = true;
            // 
            // grpAltaProducto
            // 
            grpAltaProducto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpAltaProducto.Controls.Add(txtAltaIdProducto);
            grpAltaProducto.Controls.Add(lblAltaIdProducto);
            grpAltaProducto.Controls.Add(txtAltaIdMarca);
            grpAltaProducto.Controls.Add(lblAltaIdMarca);
            grpAltaProducto.Controls.Add(txtAltaIdCategoria);
            grpAltaProducto.Controls.Add(lblAltaIdCategoria);
            grpAltaProducto.Controls.Add(txtAltaStockMinimo);
            grpAltaProducto.Controls.Add(lblAltaStockMinimo);
            grpAltaProducto.Controls.Add(txtAltaStockActual);
            grpAltaProducto.Controls.Add(lblAltaStockActual);
            grpAltaProducto.Controls.Add(txtAltaPrecioUnitario);
            grpAltaProducto.Controls.Add(lblAltaPrecioUnitario);
            grpAltaProducto.Controls.Add(txtAltaFechaUltimaActualizacion);
            grpAltaProducto.Controls.Add(lblAltaFechaUltimaActualizacion);
            grpAltaProducto.Controls.Add(chkAltaEstado);
            grpAltaProducto.Controls.Add(txtAltaCategoria);
            grpAltaProducto.Controls.Add(lblAltaCategoria);
            grpAltaProducto.Controls.Add(txtAltaMarca);
            grpAltaProducto.Controls.Add(lblAltaMarca);
            grpAltaProducto.Controls.Add(txtAltaDescripcion);
            grpAltaProducto.Controls.Add(lblAltaDescripcion);
            grpAltaProducto.Controls.Add(btnAltaSeleccionarMarca);
            grpAltaProducto.Controls.Add(btnAltaSeleccionarCategoria);
            grpAltaProducto.Controls.Add(btnAgregarProducto);
            grpAltaProducto.Location = new Point(20, 400);
            grpAltaProducto.Name = "grpAltaProducto";
            grpAltaProducto.Size = new Size(510, 260);
            grpAltaProducto.TabIndex = 3;
            grpAltaProducto.TabStop = false;
            grpAltaProducto.Text = "Datos de alta producto";
            // 
            // txtAltaIdProducto
            // 
            txtAltaIdProducto.BackColor = SystemColors.Control;
            txtAltaIdProducto.ForeColor = SystemColors.ControlDark;
            txtAltaIdProducto.Location = new Point(105, 30);
            txtAltaIdProducto.Name = "txtAltaIdProducto";
            txtAltaIdProducto.ReadOnly = true;
            txtAltaIdProducto.Size = new Size(70, 23);
            txtAltaIdProducto.TabIndex = 15;
            // 
            // lblAltaIdProducto
            // 
            lblAltaIdProducto.AutoSize = true;
            lblAltaIdProducto.Location = new Point(18, 33);
            lblAltaIdProducto.Name = "lblAltaIdProducto";
            lblAltaIdProducto.Size = new Size(69, 15);
            lblAltaIdProducto.TabIndex = 16;
            lblAltaIdProducto.Text = "Id producto";
            // 
            // txtAltaIdMarca
            // 
            txtAltaIdMarca.BackColor = SystemColors.Control;
            txtAltaIdMarca.ForeColor = SystemColors.ControlDark;
            txtAltaIdMarca.Location = new Point(105, 65);
            txtAltaIdMarca.Name = "txtAltaIdMarca";
            txtAltaIdMarca.ReadOnly = true;
            txtAltaIdMarca.Size = new Size(70, 23);
            txtAltaIdMarca.TabIndex = 17;
            // 
            // lblAltaIdMarca
            // 
            lblAltaIdMarca.AutoSize = true;
            lblAltaIdMarca.Location = new Point(18, 68);
            lblAltaIdMarca.Name = "lblAltaIdMarca";
            lblAltaIdMarca.Size = new Size(53, 15);
            lblAltaIdMarca.TabIndex = 18;
            lblAltaIdMarca.Text = "Id marca";
            // 
            // txtAltaIdCategoria
            // 
            txtAltaIdCategoria.BackColor = SystemColors.Control;
            txtAltaIdCategoria.ForeColor = SystemColors.ControlDark;
            txtAltaIdCategoria.Location = new Point(105, 133);
            txtAltaIdCategoria.Name = "txtAltaIdCategoria";
            txtAltaIdCategoria.ReadOnly = true;
            txtAltaIdCategoria.Size = new Size(70, 23);
            txtAltaIdCategoria.TabIndex = 19;
            // 
            // lblAltaIdCategoria
            // 
            lblAltaIdCategoria.AutoSize = true;
            lblAltaIdCategoria.Location = new Point(18, 131);
            lblAltaIdCategoria.Name = "lblAltaIdCategoria";
            lblAltaIdCategoria.Size = new Size(69, 15);
            lblAltaIdCategoria.TabIndex = 20;
            lblAltaIdCategoria.Text = "Id categoría";
            // 
            // txtAltaStockMinimo
            // 
            txtAltaStockMinimo.Location = new Point(344, 100);
            txtAltaStockMinimo.Name = "txtAltaStockMinimo";
            txtAltaStockMinimo.Size = new Size(130, 23);
            txtAltaStockMinimo.TabIndex = 11;
            // 
            // lblAltaStockMinimo
            // 
            lblAltaStockMinimo.AutoSize = true;
            lblAltaStockMinimo.Location = new Point(257, 104);
            lblAltaStockMinimo.Name = "lblAltaStockMinimo";
            lblAltaStockMinimo.Size = new Size(81, 15);
            lblAltaStockMinimo.TabIndex = 10;
            lblAltaStockMinimo.Text = "Stock mínimo";
            // 
            // txtAltaStockActual
            // 
            txtAltaStockActual.Location = new Point(344, 65);
            txtAltaStockActual.Name = "txtAltaStockActual";
            txtAltaStockActual.Size = new Size(130, 23);
            txtAltaStockActual.TabIndex = 9;
            // 
            // lblAltaStockActual
            // 
            lblAltaStockActual.AutoSize = true;
            lblAltaStockActual.Location = new Point(257, 69);
            lblAltaStockActual.Name = "lblAltaStockActual";
            lblAltaStockActual.Size = new Size(71, 15);
            lblAltaStockActual.TabIndex = 8;
            lblAltaStockActual.Text = "Stock actual";
            // 
            // txtAltaPrecioUnitario
            // 
            txtAltaPrecioUnitario.Location = new Point(344, 30);
            txtAltaPrecioUnitario.Name = "txtAltaPrecioUnitario";
            txtAltaPrecioUnitario.Size = new Size(130, 23);
            txtAltaPrecioUnitario.TabIndex = 7;
            // 
            // lblAltaPrecioUnitario
            // 
            lblAltaPrecioUnitario.AutoSize = true;
            lblAltaPrecioUnitario.Location = new Point(257, 34);
            lblAltaPrecioUnitario.Name = "lblAltaPrecioUnitario";
            lblAltaPrecioUnitario.Size = new Size(84, 15);
            lblAltaPrecioUnitario.TabIndex = 6;
            lblAltaPrecioUnitario.Text = "Precio unitario";
            // 
            // txtAltaFechaUltimaActualizacion
            // 
            txtAltaFechaUltimaActualizacion.BackColor = SystemColors.Control;
            txtAltaFechaUltimaActualizacion.ForeColor = SystemColors.ControlDark;
            txtAltaFechaUltimaActualizacion.Location = new Point(344, 132);
            txtAltaFechaUltimaActualizacion.Name = "txtAltaFechaUltimaActualizacion";
            txtAltaFechaUltimaActualizacion.ReadOnly = true;
            txtAltaFechaUltimaActualizacion.Size = new Size(130, 23);
            txtAltaFechaUltimaActualizacion.TabIndex = 21;
            // 
            // lblAltaFechaUltimaActualizacion
            // 
            lblAltaFechaUltimaActualizacion.AutoSize = true;
            lblAltaFechaUltimaActualizacion.Location = new Point(250, 136);
            lblAltaFechaUltimaActualizacion.Name = "lblAltaFechaUltimaActualizacion";
            lblAltaFechaUltimaActualizacion.Size = new Size(78, 15);
            lblAltaFechaUltimaActualizacion.TabIndex = 22;
            lblAltaFechaUltimaActualizacion.Text = "Actualización";
            // 
            // chkAltaEstado
            // 
            chkAltaEstado.AutoSize = true;
            chkAltaEstado.BackColor = SystemColors.Control;
            chkAltaEstado.Checked = true;
            chkAltaEstado.CheckState = CheckState.Checked;
            chkAltaEstado.Enabled = false;
            chkAltaEstado.ForeColor = SystemColors.ControlDark;
            chkAltaEstado.Location = new Point(344, 172);
            chkAltaEstado.Name = "chkAltaEstado";
            chkAltaEstado.Size = new Size(60, 19);
            chkAltaEstado.TabIndex = 23;
            chkAltaEstado.Text = "Activo";
            chkAltaEstado.UseVisualStyleBackColor = false;
            // 
            // txtAltaCategoria
            // 
            txtAltaCategoria.BackColor = SystemColors.Control;
            txtAltaCategoria.ForeColor = SystemColors.ControlDark;
            txtAltaCategoria.Location = new Point(105, 169);
            txtAltaCategoria.Name = "txtAltaCategoria";
            txtAltaCategoria.ReadOnly = true;
            txtAltaCategoria.Size = new Size(130, 23);
            txtAltaCategoria.TabIndex = 5;
            // 
            // lblAltaCategoria
            // 
            lblAltaCategoria.AutoSize = true;
            lblAltaCategoria.Location = new Point(18, 169);
            lblAltaCategoria.Name = "lblAltaCategoria";
            lblAltaCategoria.Size = new Size(58, 15);
            lblAltaCategoria.TabIndex = 4;
            lblAltaCategoria.Text = "Categoría";
            // 
            // txtAltaMarca
            // 
            txtAltaMarca.BackColor = SystemColors.Control;
            txtAltaMarca.ForeColor = SystemColors.ControlDark;
            txtAltaMarca.Location = new Point(105, 96);
            txtAltaMarca.Name = "txtAltaMarca";
            txtAltaMarca.ReadOnly = true;
            txtAltaMarca.Size = new Size(130, 23);
            txtAltaMarca.TabIndex = 3;
            // 
            // lblAltaMarca
            // 
            lblAltaMarca.AutoSize = true;
            lblAltaMarca.Location = new Point(18, 99);
            lblAltaMarca.Name = "lblAltaMarca";
            lblAltaMarca.Size = new Size(40, 15);
            lblAltaMarca.TabIndex = 2;
            lblAltaMarca.Text = "Marca";
            // 
            // txtAltaDescripcion
            // 
            txtAltaDescripcion.Location = new Point(105, 202);
            txtAltaDescripcion.Multiline = true;
            txtAltaDescripcion.Name = "txtAltaDescripcion";
            txtAltaDescripcion.Size = new Size(230, 45);
            txtAltaDescripcion.TabIndex = 1;
            // 
            // lblAltaDescripcion
            // 
            lblAltaDescripcion.AutoSize = true;
            lblAltaDescripcion.Location = new Point(18, 205);
            lblAltaDescripcion.Name = "lblAltaDescripcion";
            lblAltaDescripcion.Size = new Size(69, 15);
            lblAltaDescripcion.TabIndex = 0;
            lblAltaDescripcion.Text = "Descripción";
            // 
            // btnAltaSeleccionarMarca
            // 
            btnAltaSeleccionarMarca.Location = new Point(185, 63);
            btnAltaSeleccionarMarca.Name = "btnAltaSeleccionarMarca";
            btnAltaSeleccionarMarca.Size = new Size(50, 27);
            btnAltaSeleccionarMarca.TabIndex = 13;
            btnAltaSeleccionarMarca.Text = "...";
            btnAltaSeleccionarMarca.UseVisualStyleBackColor = true;
            // 
            // btnAltaSeleccionarCategoria
            // 
            btnAltaSeleccionarCategoria.Location = new Point(181, 129);
            btnAltaSeleccionarCategoria.Name = "btnAltaSeleccionarCategoria";
            btnAltaSeleccionarCategoria.Size = new Size(50, 27);
            btnAltaSeleccionarCategoria.TabIndex = 14;
            btnAltaSeleccionarCategoria.Text = "...";
            btnAltaSeleccionarCategoria.UseVisualStyleBackColor = true;
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(344, 220);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(136, 27);
            btnAgregarProducto.TabIndex = 12;
            btnAgregarProducto.Text = "Agregar producto";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            // 
            // grpDatosProducto
            // 
            grpDatosProducto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDatosProducto.Controls.Add(chkEstado);
            grpDatosProducto.Controls.Add(btnSeleccionadoSeleccionarMarca);
            grpDatosProducto.Controls.Add(btnSeleccionadoSeleccionarCategoria);
            grpDatosProducto.Controls.Add(pnlAcciones);
            grpDatosProducto.Controls.Add(txtFechaAlta);
            grpDatosProducto.Controls.Add(lblFechaAlta);
            grpDatosProducto.Controls.Add(txtFechaUltimaActualizacion);
            grpDatosProducto.Controls.Add(lblFechaUltimaActualizacion);
            grpDatosProducto.Controls.Add(txtStockMinimo);
            grpDatosProducto.Controls.Add(lblStockMinimo);
            grpDatosProducto.Controls.Add(txtStockActual);
            grpDatosProducto.Controls.Add(lblStockActual);
            grpDatosProducto.Controls.Add(txtPrecioUnitario);
            grpDatosProducto.Controls.Add(lblPrecioUnitario);
            grpDatosProducto.Controls.Add(txtCategoria);
            grpDatosProducto.Controls.Add(lblCategoria);
            grpDatosProducto.Controls.Add(txtMarca);
            grpDatosProducto.Controls.Add(lblMarca);
            grpDatosProducto.Controls.Add(txtDescripcion);
            grpDatosProducto.Controls.Add(lblDescripcion);
            grpDatosProducto.Controls.Add(txtIdProducto);
            grpDatosProducto.Controls.Add(lblIdProducto);
            grpDatosProducto.Controls.Add(txtIdMarca);
            grpDatosProducto.Controls.Add(lblIdMarca);
            grpDatosProducto.Controls.Add(txtIdCategoria);
            grpDatosProducto.Controls.Add(lblIdCategoria);
            grpDatosProducto.Location = new Point(620, 400);
            grpDatosProducto.Name = "grpDatosProducto";
            grpDatosProducto.Size = new Size(722, 260);
            grpDatosProducto.TabIndex = 4;
            grpDatosProducto.TabStop = false;
            grpDatosProducto.Text = "Datos del producto seleccionado";
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.BackColor = SystemColors.Control;
            chkEstado.Checked = true;
            chkEstado.CheckState = CheckState.Checked;
            chkEstado.Enabled = false;
            chkEstado.ForeColor = SystemColors.ControlDark;
            chkEstado.Location = new Point(558, 71);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(60, 19);
            chkEstado.TabIndex = 19;
            chkEstado.Text = "Activo";
            chkEstado.UseVisualStyleBackColor = false;
            // 
            // btnSeleccionadoSeleccionarMarca
            // 
            btnSeleccionadoSeleccionarMarca.Location = new Point(185, 63);
            btnSeleccionadoSeleccionarMarca.Name = "btnSeleccionadoSeleccionarMarca";
            btnSeleccionadoSeleccionarMarca.Size = new Size(50, 27);
            btnSeleccionadoSeleccionarMarca.TabIndex = 23;
            btnSeleccionadoSeleccionarMarca.Text = "...";
            btnSeleccionadoSeleccionarMarca.UseVisualStyleBackColor = true;
            // 
            // btnSeleccionadoSeleccionarCategoria
            // 
            btnSeleccionadoSeleccionarCategoria.Location = new Point(185, 138);
            btnSeleccionadoSeleccionarCategoria.Name = "btnSeleccionadoSeleccionarCategoria";
            btnSeleccionadoSeleccionarCategoria.Size = new Size(50, 27);
            btnSeleccionadoSeleccionarCategoria.TabIndex = 24;
            btnSeleccionadoSeleccionarCategoria.Text = "...";
            btnSeleccionadoSeleccionarCategoria.UseVisualStyleBackColor = true;
            // 
            // pnlAcciones
            // 
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Controls.Add(btnLimpiar);
            pnlAcciones.Controls.Add(btnEliminar);
            pnlAcciones.Controls.Add(btnModificar);
            pnlAcciones.Location = new Point(344, 205);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Size = new Size(372, 48);
            pnlAcciones.TabIndex = 20;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(232, 10);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(105, 27);
            btnLimpiar.TabIndex = 2;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(121, 10);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(105, 27);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(10, 10);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(105, 27);
            btnModificar.TabIndex = 0;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // txtFechaAlta
            // 
            txtFechaAlta.BackColor = SystemColors.Control;
            txtFechaAlta.ForeColor = SystemColors.ControlDark;
            txtFechaAlta.Location = new Point(558, 30);
            txtFechaAlta.Name = "txtFechaAlta";
            txtFechaAlta.ReadOnly = true;
            txtFechaAlta.Size = new Size(130, 23);
            txtFechaAlta.TabIndex = 17;
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Location = new Point(492, 33);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(60, 15);
            lblFechaAlta.TabIndex = 16;
            lblFechaAlta.Text = "Fecha alta";
            // 
            // txtFechaUltimaActualizacion
            // 
            txtFechaUltimaActualizacion.BackColor = SystemColors.Control;
            txtFechaUltimaActualizacion.ForeColor = SystemColors.ControlDark;
            txtFechaUltimaActualizacion.Location = new Point(344, 100);
            txtFechaUltimaActualizacion.Name = "txtFechaUltimaActualizacion";
            txtFechaUltimaActualizacion.ReadOnly = true;
            txtFechaUltimaActualizacion.Size = new Size(130, 23);
            txtFechaUltimaActualizacion.TabIndex = 15;
            // 
            // lblFechaUltimaActualizacion
            // 
            lblFechaUltimaActualizacion.AutoSize = true;
            lblFechaUltimaActualizacion.Location = new Point(260, 131);
            lblFechaUltimaActualizacion.Name = "lblFechaUltimaActualizacion";
            lblFechaUltimaActualizacion.Size = new Size(78, 30);
            lblFechaUltimaActualizacion.TabIndex = 14;
            lblFechaUltimaActualizacion.Text = "Actualización\r\nstock";
            // 
            // txtStockMinimo
            // 
            txtStockMinimo.Location = new Point(344, 133);
            txtStockMinimo.Name = "txtStockMinimo";
            txtStockMinimo.Size = new Size(130, 23);
            txtStockMinimo.TabIndex = 13;
            // 
            // lblStockMinimo
            // 
            lblStockMinimo.AutoSize = true;
            lblStockMinimo.Location = new Point(260, 100);
            lblStockMinimo.Name = "lblStockMinimo";
            lblStockMinimo.Size = new Size(81, 15);
            lblStockMinimo.TabIndex = 12;
            lblStockMinimo.Text = "Stock mínimo";
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(344, 65);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.Size = new Size(130, 23);
            txtStockActual.TabIndex = 11;
            // 
            // lblStockActual
            // 
            lblStockActual.AutoSize = true;
            lblStockActual.Location = new Point(260, 68);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(71, 15);
            lblStockActual.TabIndex = 10;
            lblStockActual.Text = "Stock actual";
            // 
            // txtPrecioUnitario
            // 
            txtPrecioUnitario.Location = new Point(344, 30);
            txtPrecioUnitario.Name = "txtPrecioUnitario";
            txtPrecioUnitario.Size = new Size(130, 23);
            txtPrecioUnitario.TabIndex = 9;
            // 
            // lblPrecioUnitario
            // 
            lblPrecioUnitario.AutoSize = true;
            lblPrecioUnitario.Location = new Point(260, 33);
            lblPrecioUnitario.Name = "lblPrecioUnitario";
            lblPrecioUnitario.Size = new Size(40, 15);
            lblPrecioUnitario.TabIndex = 8;
            lblPrecioUnitario.Text = "Precio";
            // 
            // txtCategoria
            // 
            txtCategoria.BackColor = SystemColors.Control;
            txtCategoria.ForeColor = SystemColors.ControlDark;
            txtCategoria.Location = new Point(105, 173);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.ReadOnly = true;
            txtCategoria.Size = new Size(130, 23);
            txtCategoria.TabIndex = 7;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(18, 173);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(58, 15);
            lblCategoria.TabIndex = 6;
            lblCategoria.Text = "Categoría";
            // 
            // txtMarca
            // 
            txtMarca.BackColor = SystemColors.Control;
            txtMarca.ForeColor = SystemColors.ControlDark;
            txtMarca.Location = new Point(105, 100);
            txtMarca.Name = "txtMarca";
            txtMarca.ReadOnly = true;
            txtMarca.Size = new Size(130, 23);
            txtMarca.TabIndex = 5;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(18, 104);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(40, 15);
            lblMarca.TabIndex = 4;
            lblMarca.Text = "Marca";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(105, 205);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(213, 42);
            txtDescripcion.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(18, 205);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(69, 15);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripción";
            // 
            // txtIdProducto
            // 
            txtIdProducto.BackColor = SystemColors.Control;
            txtIdProducto.ForeColor = SystemColors.ControlDark;
            txtIdProducto.Location = new Point(105, 30);
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.ReadOnly = true;
            txtIdProducto.Size = new Size(70, 23);
            txtIdProducto.TabIndex = 1;
            // 
            // lblIdProducto
            // 
            lblIdProducto.AutoSize = true;
            lblIdProducto.Location = new Point(18, 33);
            lblIdProducto.Name = "lblIdProducto";
            lblIdProducto.Size = new Size(69, 15);
            lblIdProducto.TabIndex = 0;
            lblIdProducto.Text = "Id producto";
            // 
            // txtIdMarca
            // 
            txtIdMarca.BackColor = SystemColors.Control;
            txtIdMarca.ForeColor = SystemColors.ControlDark;
            txtIdMarca.Location = new Point(105, 65);
            txtIdMarca.Name = "txtIdMarca";
            txtIdMarca.ReadOnly = true;
            txtIdMarca.Size = new Size(70, 23);
            txtIdMarca.TabIndex = 25;
            // 
            // lblIdMarca
            // 
            lblIdMarca.AutoSize = true;
            lblIdMarca.Location = new Point(18, 69);
            lblIdMarca.Name = "lblIdMarca";
            lblIdMarca.Size = new Size(53, 15);
            lblIdMarca.TabIndex = 26;
            lblIdMarca.Text = "Id marca";
            // 
            // txtIdCategoria
            // 
            txtIdCategoria.BackColor = SystemColors.Control;
            txtIdCategoria.ForeColor = SystemColors.ControlDark;
            txtIdCategoria.Location = new Point(105, 138);
            txtIdCategoria.Name = "txtIdCategoria";
            txtIdCategoria.ReadOnly = true;
            txtIdCategoria.Size = new Size(70, 23);
            txtIdCategoria.TabIndex = 27;
            // 
            // lblIdCategoria
            // 
            lblIdCategoria.AutoSize = true;
            lblIdCategoria.Location = new Point(18, 141);
            lblIdCategoria.Name = "lblIdCategoria";
            lblIdCategoria.Size = new Size(69, 15);
            lblIdCategoria.TabIndex = 28;
            lblIdCategoria.Text = "Id categoria";
            // 
            // txtIdInventario
            // 
            txtIdInventario.BackColor = SystemColors.Control;
            txtIdInventario.ForeColor = SystemColors.ControlDark;
            txtIdInventario.Location = new Point(529, 30);
            txtIdInventario.Name = "txtIdInventario";
            txtIdInventario.ReadOnly = true;
            txtIdInventario.Size = new Size(50, 23);
            txtIdInventario.TabIndex = 21;
            // 
            // lblIdInventario
            // 
            lblIdInventario.AutoSize = true;
            lblIdInventario.Location = new Point(529, 12);
            lblIdInventario.Name = "lblIdInventario";
            lblIdInventario.Size = new Size(73, 15);
            lblIdInventario.TabIndex = 22;
            lblIdInventario.Text = "Id inventario";
            // 
            // FormAdministrarProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 681);
            Controls.Add(grpDatosProducto);
            Controls.Add(grpAltaProducto);
            Controls.Add(grpBusquedaInventario);
            Controls.Add(dgvInventario);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1364, 720);
            Name = "FormAdministrarProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Administrar productos";
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            grpBusquedaInventario.ResumeLayout(false);
            grpBusquedaInventario.PerformLayout();
            grpAltaProducto.ResumeLayout(false);
            grpAltaProducto.PerformLayout();
            grpDatosProducto.ResumeLayout(false);
            grpDatosProducto.PerformLayout();
            pnlAcciones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvInventario;
        private DataGridViewTextBoxColumn colIdProducto;
        private DataGridViewTextBoxColumn colIdMarca;
        private DataGridViewTextBoxColumn colIdCategoria;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colPrecioUnitario;
        private DataGridViewTextBoxColumn colStockActual;
        private DataGridViewTextBoxColumn colStockMinimo;
        private DataGridViewTextBoxColumn colFechaUltimaActualizacion;
        private DataGridViewCheckBoxColumn colEstado;
        private GroupBox grpBusquedaInventario;
        private TextBox txtBuscarIdProducto;
        private Label lblBuscarIdProducto;
        private TextBox txtBuscarIdMarca;
        private Label lblBuscarIdMarca;
        private TextBox txtBuscarIdCategoria;
        private Label lblBuscarIdCategoria;
        private TextBox txtBuscarMarca;
        private Label lblBuscarMarca;
        private TextBox txtBuscarCategoria;
        private Label lblBuscarCategoria;
        private Button btnLimpiarBusquedaInventario;
        private Button btnBuscarInventario;
        private Button btnBusquedaSeleccionarMarca;
        private Button btnBusquedaSeleccionarCategoria;
        private GroupBox grpAltaProducto;
        private TextBox txtAltaIdProducto;
        private Label lblAltaIdProducto;
        private TextBox txtAltaIdMarca;
        private Label lblAltaIdMarca;
        private TextBox txtAltaIdCategoria;
        private Label lblAltaIdCategoria;
        private TextBox txtAltaStockMinimo;
        private Label lblAltaStockMinimo;
        private TextBox txtAltaStockActual;
        private Label lblAltaStockActual;
        private TextBox txtAltaPrecioUnitario;
        private Label lblAltaPrecioUnitario;
        private TextBox txtAltaFechaUltimaActualizacion;
        private Label lblAltaFechaUltimaActualizacion;
        private CheckBox chkAltaEstado;
        private TextBox txtAltaCategoria;
        private Label lblAltaCategoria;
        private TextBox txtAltaMarca;
        private Label lblAltaMarca;
        private TextBox txtAltaDescripcion;
        private Label lblAltaDescripcion;
        private Button btnAgregarProducto;
        private Button btnAltaSeleccionarMarca;
        private Button btnAltaSeleccionarCategoria;
        private GroupBox grpDatosProducto;
        private CheckBox chkEstado;
        private Panel pnlAcciones;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnModificar;
        private TextBox txtFechaAlta;
        private Label lblFechaAlta;
        private TextBox txtFechaUltimaActualizacion;
        private Label lblFechaUltimaActualizacion;
        private TextBox txtStockMinimo;
        private Label lblStockMinimo;
        private TextBox txtStockActual;
        private Label lblStockActual;
        private TextBox txtPrecioUnitario;
        private Label lblPrecioUnitario;
        private TextBox txtCategoria;
        private Label lblCategoria;
        private TextBox txtMarca;
        private Label lblMarca;
        private TextBox txtDescripcion;
        private Label lblDescripcion;
        private TextBox txtIdProducto;
        private Label lblIdProducto;
        private TextBox txtIdMarca;
        private Label lblIdMarca;
        private TextBox txtIdCategoria;
        private Label lblIdCategoria;
        private TextBox txtIdInventario;
        private Label lblIdInventario;
        private Button btnSeleccionadoSeleccionarMarca;
        private Button btnSeleccionadoSeleccionarCategoria;
    }
}
