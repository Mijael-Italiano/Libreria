namespace Libreria.UI
{
    partial class FormElegirProducto
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
            dgvProductos = new DataGridView();
            colIdProducto = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colMarca = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colColor = new DataGridViewTextBoxColumn();
            colPrecioUnitario = new DataGridViewTextBoxColumn();
            colStockActual = new DataGridViewTextBoxColumn();
            grpBusqueda = new GroupBox();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            txtBuscarIdProducto = new TextBox();
            lblBuscarIdProducto = new Label();
            grpDatosProducto = new GroupBox();
            txtStockActual = new TextBox();
            lblStockActual = new Label();
            txtPrecioUnitario = new TextBox();
            lblPrecioUnitario = new Label();
            txtColor = new TextBox();
            lblColor = new Label();
            txtCategoria = new TextBox();
            lblCategoria = new Label();
            txtMarca = new TextBox();
            lblMarca = new Label();
            btnSeleccionar = new Button();
            txtDescripcion = new TextBox();
            lblDescripcion = new Label();
            txtIdProducto = new TextBox();
            lblIdProducto = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            grpBusqueda.SuspendLayout();
            grpDatosProducto.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(171, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Elegir producto";
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProductos.BackgroundColor = SystemColors.Window;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colIdProducto, colDescripcion, colMarca, colCategoria, colColor, colPrecioUnitario, colStockActual });
            dgvProductos.Location = new Point(20, 72);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(790, 280);
            dgvProductos.TabIndex = 1;
            // 
            // colIdProducto
            // 
            colIdProducto.FillWeight = 55F;
            colIdProducto.HeaderText = "Id producto";
            colIdProducto.Name = "colIdProducto";
            colIdProducto.ReadOnly = true;
            // 
            // colDescripcion
            // 
            colDescripcion.HeaderText = "Descripcion";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
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
            // colColor
            // 
            colColor.FillWeight = 80F;
            colColor.HeaderText = "Color";
            colColor.Name = "colColor";
            colColor.ReadOnly = true;
            // 
            // colPrecioUnitario
            // 
            colPrecioUnitario.FillWeight = 75F;
            colPrecioUnitario.HeaderText = "Precio";
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
            // grpBusqueda
            // 
            grpBusqueda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpBusqueda.Controls.Add(btnLimpiarBusqueda);
            grpBusqueda.Controls.Add(btnBuscar);
            grpBusqueda.Controls.Add(txtBuscarIdProducto);
            grpBusqueda.Controls.Add(lblBuscarIdProducto);
            grpBusqueda.Location = new Point(20, 370);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Size = new Size(360, 94);
            grpBusqueda.TabIndex = 2;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Buscar producto";
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Location = new Point(205, 58);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(118, 27);
            btnLimpiarBusqueda.TabIndex = 3;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            btnLimpiarBusqueda.Click += btnLimpiarBusqueda_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(75, 58);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(118, 27);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscarIdProducto
            // 
            txtBuscarIdProducto.Location = new Point(102, 27);
            txtBuscarIdProducto.Name = "txtBuscarIdProducto";
            txtBuscarIdProducto.Size = new Size(221, 23);
            txtBuscarIdProducto.TabIndex = 1;
            // 
            // lblBuscarIdProducto
            // 
            lblBuscarIdProducto.AutoSize = true;
            lblBuscarIdProducto.Location = new Point(18, 30);
            lblBuscarIdProducto.Name = "lblBuscarIdProducto";
            lblBuscarIdProducto.Size = new Size(69, 15);
            lblBuscarIdProducto.TabIndex = 0;
            lblBuscarIdProducto.Text = "Id producto";
            // 
            // grpDatosProducto
            // 
            grpDatosProducto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDatosProducto.Controls.Add(txtStockActual);
            grpDatosProducto.Controls.Add(lblStockActual);
            grpDatosProducto.Controls.Add(txtPrecioUnitario);
            grpDatosProducto.Controls.Add(lblPrecioUnitario);
            grpDatosProducto.Controls.Add(txtColor);
            grpDatosProducto.Controls.Add(lblColor);
            grpDatosProducto.Controls.Add(txtCategoria);
            grpDatosProducto.Controls.Add(lblCategoria);
            grpDatosProducto.Controls.Add(txtMarca);
            grpDatosProducto.Controls.Add(lblMarca);
            grpDatosProducto.Controls.Add(btnSeleccionar);
            grpDatosProducto.Controls.Add(txtDescripcion);
            grpDatosProducto.Controls.Add(lblDescripcion);
            grpDatosProducto.Controls.Add(txtIdProducto);
            grpDatosProducto.Controls.Add(lblIdProducto);
            grpDatosProducto.Location = new Point(400, 370);
            grpDatosProducto.Name = "grpDatosProducto";
            grpDatosProducto.Size = new Size(410, 190);
            grpDatosProducto.TabIndex = 3;
            grpDatosProducto.TabStop = false;
            grpDatosProducto.Text = "Datos del producto seleccionado";
            // 
            // txtStockActual
            // 
            txtStockActual.Location = new Point(274, 114);
            txtStockActual.Name = "txtStockActual";
            txtStockActual.ReadOnly = true;
            txtStockActual.Size = new Size(100, 23);
            txtStockActual.TabIndex = 13;
            // 
            // lblStockActual
            // 
            lblStockActual.AutoSize = true;
            lblStockActual.Location = new Point(211, 117);
            lblStockActual.Name = "lblStockActual";
            lblStockActual.Size = new Size(36, 15);
            lblStockActual.TabIndex = 12;
            lblStockActual.Text = "Stock";
            // 
            // txtPrecioUnitario
            // 
            txtPrecioUnitario.Location = new Point(274, 78);
            txtPrecioUnitario.Name = "txtPrecioUnitario";
            txtPrecioUnitario.ReadOnly = true;
            txtPrecioUnitario.Size = new Size(100, 23);
            txtPrecioUnitario.TabIndex = 11;
            // 
            // lblPrecioUnitario
            // 
            lblPrecioUnitario.AutoSize = true;
            lblPrecioUnitario.Location = new Point(211, 81);
            lblPrecioUnitario.Name = "lblPrecioUnitario";
            lblPrecioUnitario.Size = new Size(40, 15);
            lblPrecioUnitario.TabIndex = 10;
            lblPrecioUnitario.Text = "Precio";
            // 
            // txtColor
            // 
            txtColor.Location = new Point(274, 42);
            txtColor.Name = "txtColor";
            txtColor.ReadOnly = true;
            txtColor.Size = new Size(100, 23);
            txtColor.TabIndex = 9;
            // 
            // lblColor
            // 
            lblColor.AutoSize = true;
            lblColor.Location = new Point(211, 45);
            lblColor.Name = "lblColor";
            lblColor.Size = new Size(36, 15);
            lblColor.TabIndex = 8;
            lblColor.Text = "Color";
            // 
            // txtCategoria
            // 
            txtCategoria.Location = new Point(102, 149);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.ReadOnly = true;
            txtCategoria.Size = new Size(100, 23);
            txtCategoria.TabIndex = 7;
            // 
            // lblCategoria
            // 
            lblCategoria.AutoSize = true;
            lblCategoria.Location = new Point(18, 152);
            lblCategoria.Name = "lblCategoria";
            lblCategoria.Size = new Size(58, 15);
            lblCategoria.TabIndex = 6;
            lblCategoria.Text = "Categoria";
            // 
            // txtMarca
            // 
            txtMarca.Location = new Point(102, 114);
            txtMarca.Name = "txtMarca";
            txtMarca.ReadOnly = true;
            txtMarca.Size = new Size(100, 23);
            txtMarca.TabIndex = 5;
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(18, 117);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(40, 15);
            lblMarca.TabIndex = 4;
            lblMarca.Text = "Marca";
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(256, 149);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(118, 27);
            btnSeleccionar.TabIndex = 14;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(102, 78);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.ReadOnly = true;
            txtDescripcion.Size = new Size(100, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(18, 81);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(69, 15);
            lblDescripcion.TabIndex = 2;
            lblDescripcion.Text = "Descripcion";
            // 
            // txtIdProducto
            // 
            txtIdProducto.BackColor = SystemColors.Control;
            txtIdProducto.ForeColor = SystemColors.ControlDark;
            txtIdProducto.Location = new Point(102, 42);
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.ReadOnly = true;
            txtIdProducto.Size = new Size(100, 23);
            txtIdProducto.TabIndex = 1;
            // 
            // lblIdProducto
            // 
            lblIdProducto.AutoSize = true;
            lblIdProducto.Location = new Point(18, 45);
            lblIdProducto.Name = "lblIdProducto";
            lblIdProducto.Size = new Size(69, 15);
            lblIdProducto.TabIndex = 0;
            lblIdProducto.Text = "Id producto";
            // 
            // FormElegirProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(834, 581);
            Controls.Add(grpDatosProducto);
            Controls.Add(grpBusqueda);
            Controls.Add(dgvProductos);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(850, 620);
            Name = "FormElegirProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Elegir producto";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            grpDatosProducto.ResumeLayout(false);
            grpDatosProducto.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvProductos;
        private DataGridViewTextBoxColumn colIdProducto;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colMarca;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colColor;
        private DataGridViewTextBoxColumn colPrecioUnitario;
        private DataGridViewTextBoxColumn colStockActual;
        private GroupBox grpBusqueda;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
        private TextBox txtBuscarIdProducto;
        private Label lblBuscarIdProducto;
        private GroupBox grpDatosProducto;
        private TextBox txtStockActual;
        private Label lblStockActual;
        private TextBox txtPrecioUnitario;
        private Label lblPrecioUnitario;
        private TextBox txtColor;
        private Label lblColor;
        private TextBox txtCategoria;
        private Label lblCategoria;
        private TextBox txtMarca;
        private Label lblMarca;
        private Button btnSeleccionar;
        private TextBox txtDescripcion;
        private Label lblDescripcion;
        private TextBox txtIdProducto;
        private Label lblIdProducto;
    }
}
