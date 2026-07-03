namespace Libreria.UI
{
    partial class FormInventario
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            dgvInventario = new DataGridView();
            colIdProducto = new DataGridViewTextBoxColumn();
            colIdMarca = new DataGridViewTextBoxColumn();
            colIdCategoria = new DataGridViewTextBoxColumn();
            colColor = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colPrecioUnitario = new DataGridViewTextBoxColumn();
            colStockActual = new DataGridViewTextBoxColumn();
            colStockMinimo = new DataGridViewTextBoxColumn();
            colFechaAlta = new DataGridViewTextBoxColumn();
            colFechaUltimaActualizacion = new DataGridViewTextBoxColumn();
            grpBusquedaInventario = new GroupBox();
            txtBuscarIdProducto = new TextBox();
            lblBuscarIdProducto = new Label();
            txtBuscarIdMarca = new TextBox();
            lblBuscarIdMarca = new Label();
            txtBuscarMarca = new TextBox();
            lblBuscarMarca = new Label();
            txtBuscarIdCategoria = new TextBox();
            lblBuscarIdCategoria = new Label();
            txtBuscarCategoria = new TextBox();
            lblBuscarCategoria = new Label();
            txtBuscarIdColor = new TextBox();
            lblBuscarIdColor = new Label();
            txtBuscarColor = new TextBox();
            lblBuscarColor = new Label();
            btnBusquedaSeleccionarMarca = new Button();
            btnBusquedaSeleccionarCategoria = new Button();
            btnBusquedaSeleccionarColor = new Button();
            btnLimpiarBusquedaInventario = new Button();
            btnBuscarInventario = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            grpBusquedaInventario.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(251, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Inventario de productos";
            // 
            // dgvInventario
            // 
            dgvInventario.AllowUserToAddRows = false;
            dgvInventario.AllowUserToDeleteRows = false;
            dgvInventario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvInventario.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInventario.BackgroundColor = SystemColors.Window;
            dgvInventario.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventario.Columns.AddRange(new DataGridViewColumn[] { colIdProducto, colIdMarca, colIdCategoria, colColor, colDescripcion, colPrecioUnitario, colStockActual, colStockMinimo, colFechaAlta, colFechaUltimaActualizacion });
            dgvInventario.Location = new Point(20, 82);
            dgvInventario.MultiSelect = false;
            dgvInventario.Name = "dgvInventario";
            dgvInventario.ReadOnly = true;
            dgvInventario.RowHeadersVisible = false;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new Size(991, 356);
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
            colIdCategoria.HeaderText = "Categoria";
            colIdCategoria.Name = "colIdCategoria";
            colIdCategoria.ReadOnly = true;
            // 
            // colColor
            // 
            colColor.FillWeight = 60F;
            colColor.HeaderText = "Color";
            colColor.Name = "colColor";
            colColor.ReadOnly = true;
            // 
            // colDescripcion
            // 
            colDescripcion.HeaderText = "Descripcion";
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
            colStockMinimo.HeaderText = "Stock minimo";
            colStockMinimo.Name = "colStockMinimo";
            colStockMinimo.ReadOnly = true;
            // 
            // colFechaAlta
            // 
            colFechaAlta.HeaderText = "Fecha alta";
            colFechaAlta.Name = "colFechaAlta";
            colFechaAlta.ReadOnly = true;
            // 
            // colFechaUltimaActualizacion
            // 
            colFechaUltimaActualizacion.HeaderText = "Fecha ultima actualizacion";
            colFechaUltimaActualizacion.Name = "colFechaUltimaActualizacion";
            colFechaUltimaActualizacion.ReadOnly = true;
            // 
            // 
            // grpBusquedaInventario
            // 
            grpBusquedaInventario.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpBusquedaInventario.Controls.Add(btnLimpiarBusquedaInventario);
            grpBusquedaInventario.Controls.Add(btnBuscarInventario);
            grpBusquedaInventario.Controls.Add(btnBusquedaSeleccionarColor);
            grpBusquedaInventario.Controls.Add(btnBusquedaSeleccionarCategoria);
            grpBusquedaInventario.Controls.Add(btnBusquedaSeleccionarMarca);
            grpBusquedaInventario.Controls.Add(txtBuscarColor);
            grpBusquedaInventario.Controls.Add(lblBuscarColor);
            grpBusquedaInventario.Controls.Add(txtBuscarIdColor);
            grpBusquedaInventario.Controls.Add(lblBuscarIdColor);
            grpBusquedaInventario.Controls.Add(txtBuscarCategoria);
            grpBusquedaInventario.Controls.Add(lblBuscarCategoria);
            grpBusquedaInventario.Controls.Add(txtBuscarIdCategoria);
            grpBusquedaInventario.Controls.Add(lblBuscarIdCategoria);
            grpBusquedaInventario.Controls.Add(txtBuscarMarca);
            grpBusquedaInventario.Controls.Add(lblBuscarMarca);
            grpBusquedaInventario.Controls.Add(txtBuscarIdMarca);
            grpBusquedaInventario.Controls.Add(lblBuscarIdMarca);
            grpBusquedaInventario.Controls.Add(txtBuscarIdProducto);
            grpBusquedaInventario.Controls.Add(lblBuscarIdProducto);
            grpBusquedaInventario.Location = new Point(1030, 82);
            grpBusquedaInventario.Name = "grpBusquedaInventario";
            grpBusquedaInventario.Size = new Size(320, 286);
            grpBusquedaInventario.TabIndex = 2;
            grpBusquedaInventario.TabStop = false;
            grpBusquedaInventario.Text = "Buscar producto";
            // 
            // txtBuscarIdProducto
            // 
            txtBuscarIdProducto.Location = new Point(118, 27);
            txtBuscarIdProducto.Name = "txtBuscarIdProducto";
            txtBuscarIdProducto.Size = new Size(80, 23);
            txtBuscarIdProducto.TabIndex = 1;
            // 
            // lblBuscarIdProducto
            // 
            lblBuscarIdProducto.AutoSize = true;
            lblBuscarIdProducto.Location = new Point(15, 30);
            lblBuscarIdProducto.Name = "lblBuscarIdProducto";
            lblBuscarIdProducto.Size = new Size(69, 15);
            lblBuscarIdProducto.TabIndex = 0;
            lblBuscarIdProducto.Text = "Id producto";
            // 
            // txtBuscarIdMarca
            // 
            txtBuscarIdMarca.BackColor = SystemColors.Control;
            txtBuscarIdMarca.ForeColor = SystemColors.ControlDark;
            txtBuscarIdMarca.Location = new Point(118, 62);
            txtBuscarIdMarca.Name = "txtBuscarIdMarca";
            txtBuscarIdMarca.ReadOnly = true;
            txtBuscarIdMarca.Size = new Size(80, 23);
            txtBuscarIdMarca.TabIndex = 3;
            // 
            // lblBuscarIdMarca
            // 
            lblBuscarIdMarca.AutoSize = true;
            lblBuscarIdMarca.Location = new Point(15, 65);
            lblBuscarIdMarca.Name = "lblBuscarIdMarca";
            lblBuscarIdMarca.Size = new Size(53, 15);
            lblBuscarIdMarca.TabIndex = 2;
            lblBuscarIdMarca.Text = "Id marca";
            // 
            // txtBuscarMarca
            // 
            txtBuscarMarca.BackColor = SystemColors.Control;
            txtBuscarMarca.ForeColor = SystemColors.ControlDark;
            txtBuscarMarca.Location = new Point(118, 95);
            txtBuscarMarca.Name = "txtBuscarMarca";
            txtBuscarMarca.ReadOnly = true;
            txtBuscarMarca.Size = new Size(128, 23);
            txtBuscarMarca.TabIndex = 5;
            // 
            // lblBuscarMarca
            // 
            lblBuscarMarca.AutoSize = true;
            lblBuscarMarca.Location = new Point(15, 98);
            lblBuscarMarca.Name = "lblBuscarMarca";
            lblBuscarMarca.Size = new Size(40, 15);
            lblBuscarMarca.TabIndex = 4;
            lblBuscarMarca.Text = "Marca";
            // 
            // txtBuscarIdCategoria
            // 
            txtBuscarIdCategoria.BackColor = SystemColors.Control;
            txtBuscarIdCategoria.ForeColor = SystemColors.ControlDark;
            txtBuscarIdCategoria.Location = new Point(118, 128);
            txtBuscarIdCategoria.Name = "txtBuscarIdCategoria";
            txtBuscarIdCategoria.ReadOnly = true;
            txtBuscarIdCategoria.Size = new Size(80, 23);
            txtBuscarIdCategoria.TabIndex = 8;
            // 
            // lblBuscarIdCategoria
            // 
            lblBuscarIdCategoria.AutoSize = true;
            lblBuscarIdCategoria.Location = new Point(15, 131);
            lblBuscarIdCategoria.Name = "lblBuscarIdCategoria";
            lblBuscarIdCategoria.Size = new Size(69, 15);
            lblBuscarIdCategoria.TabIndex = 7;
            lblBuscarIdCategoria.Text = "Id categoria";
            // 
            // txtBuscarCategoria
            // 
            txtBuscarCategoria.BackColor = SystemColors.Control;
            txtBuscarCategoria.ForeColor = SystemColors.ControlDark;
            txtBuscarCategoria.Location = new Point(118, 161);
            txtBuscarCategoria.Name = "txtBuscarCategoria";
            txtBuscarCategoria.ReadOnly = true;
            txtBuscarCategoria.Size = new Size(128, 23);
            txtBuscarCategoria.TabIndex = 10;
            // 
            // lblBuscarCategoria
            // 
            lblBuscarCategoria.AutoSize = true;
            lblBuscarCategoria.Location = new Point(15, 164);
            lblBuscarCategoria.Name = "lblBuscarCategoria";
            lblBuscarCategoria.Size = new Size(58, 15);
            lblBuscarCategoria.TabIndex = 9;
            lblBuscarCategoria.Text = "Categoria";
            // 
            // txtBuscarIdColor
            // 
            txtBuscarIdColor.BackColor = SystemColors.Control;
            txtBuscarIdColor.ForeColor = SystemColors.ControlDark;
            txtBuscarIdColor.Location = new Point(118, 194);
            txtBuscarIdColor.Name = "txtBuscarIdColor";
            txtBuscarIdColor.ReadOnly = true;
            txtBuscarIdColor.Size = new Size(80, 23);
            txtBuscarIdColor.TabIndex = 13;
            // 
            // lblBuscarIdColor
            // 
            lblBuscarIdColor.AutoSize = true;
            lblBuscarIdColor.Location = new Point(15, 197);
            lblBuscarIdColor.Name = "lblBuscarIdColor";
            lblBuscarIdColor.Size = new Size(47, 15);
            lblBuscarIdColor.TabIndex = 12;
            lblBuscarIdColor.Text = "Id color";
            // 
            // txtBuscarColor
            // 
            txtBuscarColor.BackColor = SystemColors.Control;
            txtBuscarColor.ForeColor = SystemColors.ControlDark;
            txtBuscarColor.Location = new Point(118, 227);
            txtBuscarColor.Name = "txtBuscarColor";
            txtBuscarColor.ReadOnly = true;
            txtBuscarColor.Size = new Size(128, 23);
            txtBuscarColor.TabIndex = 15;
            // 
            // lblBuscarColor
            // 
            lblBuscarColor.AutoSize = true;
            lblBuscarColor.Location = new Point(15, 230);
            lblBuscarColor.Name = "lblBuscarColor";
            lblBuscarColor.Size = new Size(36, 15);
            lblBuscarColor.TabIndex = 14;
            lblBuscarColor.Text = "Color";
            // 
            // btnBusquedaSeleccionarMarca
            // 
            btnBusquedaSeleccionarMarca.Location = new Point(252, 94);
            btnBusquedaSeleccionarMarca.Name = "btnBusquedaSeleccionarMarca";
            btnBusquedaSeleccionarMarca.Size = new Size(45, 25);
            btnBusquedaSeleccionarMarca.TabIndex = 6;
            btnBusquedaSeleccionarMarca.Text = "...";
            btnBusquedaSeleccionarMarca.UseVisualStyleBackColor = true;
            btnBusquedaSeleccionarMarca.Click += btnBusquedaSeleccionarMarca_Click;
            // 
            // btnBusquedaSeleccionarCategoria
            // 
            btnBusquedaSeleccionarCategoria.Location = new Point(252, 160);
            btnBusquedaSeleccionarCategoria.Name = "btnBusquedaSeleccionarCategoria";
            btnBusquedaSeleccionarCategoria.Size = new Size(45, 25);
            btnBusquedaSeleccionarCategoria.TabIndex = 11;
            btnBusquedaSeleccionarCategoria.Text = "...";
            btnBusquedaSeleccionarCategoria.UseVisualStyleBackColor = true;
            btnBusquedaSeleccionarCategoria.Click += btnBusquedaSeleccionarCategoria_Click;
            // 
            // btnBusquedaSeleccionarColor
            // 
            btnBusquedaSeleccionarColor.Location = new Point(252, 226);
            btnBusquedaSeleccionarColor.Name = "btnBusquedaSeleccionarColor";
            btnBusquedaSeleccionarColor.Size = new Size(45, 25);
            btnBusquedaSeleccionarColor.TabIndex = 16;
            btnBusquedaSeleccionarColor.Text = "...";
            btnBusquedaSeleccionarColor.UseVisualStyleBackColor = true;
            btnBusquedaSeleccionarColor.Click += btnBusquedaSeleccionarColor_Click;
            // 
            // btnLimpiarBusquedaInventario
            // 
            btnLimpiarBusquedaInventario.Location = new Point(230, 255);
            btnLimpiarBusquedaInventario.Name = "btnLimpiarBusquedaInventario";
            btnLimpiarBusquedaInventario.Size = new Size(75, 25);
            btnLimpiarBusquedaInventario.TabIndex = 19;
            btnLimpiarBusquedaInventario.Text = "Limpiar";
            btnLimpiarBusquedaInventario.UseVisualStyleBackColor = true;
            btnLimpiarBusquedaInventario.Click += btnLimpiarBusquedaInventario_Click;
            // 
            // btnBuscarInventario
            // 
            btnBuscarInventario.Location = new Point(145, 255);
            btnBuscarInventario.Name = "btnBuscarInventario";
            btnBuscarInventario.Size = new Size(75, 25);
            btnBuscarInventario.TabIndex = 18;
            btnBuscarInventario.Text = "Buscar";
            btnBuscarInventario.UseVisualStyleBackColor = true;
            btnBuscarInventario.Click += btnBuscarInventario_Click;
            // 
            // 
            // FormInventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 461);
            Controls.Add(grpBusquedaInventario);
            Controls.Add(dgvInventario);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1200, 500);
            Name = "FormInventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventario";
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            grpBusquedaInventario.ResumeLayout(false);
            grpBusquedaInventario.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvInventario;
        private DataGridViewTextBoxColumn colIdProducto;
        private DataGridViewTextBoxColumn colIdMarca;
        private DataGridViewTextBoxColumn colIdCategoria;
        private DataGridViewTextBoxColumn colColor;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colPrecioUnitario;
        private DataGridViewTextBoxColumn colStockActual;
        private DataGridViewTextBoxColumn colStockMinimo;
        private DataGridViewTextBoxColumn colFechaAlta;
        private DataGridViewTextBoxColumn colFechaUltimaActualizacion;
        private GroupBox grpBusquedaInventario;
        private TextBox txtBuscarIdProducto;
        private Label lblBuscarIdProducto;
        private TextBox txtBuscarIdMarca;
        private Label lblBuscarIdMarca;
        private TextBox txtBuscarMarca;
        private Label lblBuscarMarca;
        private TextBox txtBuscarIdCategoria;
        private Label lblBuscarIdCategoria;
        private TextBox txtBuscarCategoria;
        private Label lblBuscarCategoria;
        private TextBox txtBuscarIdColor;
        private Label lblBuscarIdColor;
        private TextBox txtBuscarColor;
        private Label lblBuscarColor;
        private Button btnBusquedaSeleccionarMarca;
        private Button btnBusquedaSeleccionarCategoria;
        private Button btnBusquedaSeleccionarColor;
        private Button btnLimpiarBusquedaInventario;
        private Button btnBuscarInventario;
    }
}
