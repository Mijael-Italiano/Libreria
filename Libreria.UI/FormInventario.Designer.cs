namespace Libreria.UI
{
    partial class FormInventario
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
            colIdInventario = new DataGridViewTextBoxColumn();
            colIdProducto = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colMarca = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colStockActual = new DataGridViewTextBoxColumn();
            colStockMinimo = new DataGridViewTextBoxColumn();
            colFechaUltimaActualizacion = new DataGridViewTextBoxColumn();
            grpBusqueda = new GroupBox();
            txtBuscarDescripcion = new TextBox();
            lblBuscarDescripcion = new Label();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvInventario).BeginInit();
            grpBusqueda.SuspendLayout();
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
            dgvInventario.Columns.AddRange(new DataGridViewColumn[] { colIdInventario, colIdProducto, colDescripcion, colMarca, colCategoria, colStockActual, colStockMinimo, colFechaUltimaActualizacion });
            dgvInventario.Location = new Point(20, 82);
            dgvInventario.MultiSelect = false;
            dgvInventario.Name = "dgvInventario";
            dgvInventario.ReadOnly = true;
            dgvInventario.RowHeadersVisible = false;
            dgvInventario.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvInventario.Size = new Size(940, 356);
            dgvInventario.TabIndex = 1;
            // 
            // colIdInventario
            // 
            colIdInventario.FillWeight = 55F;
            colIdInventario.HeaderText = "Id inventario";
            colIdInventario.Name = "colIdInventario";
            colIdInventario.ReadOnly = true;
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
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.Name = "colDescripcion";
            colDescripcion.ReadOnly = true;
            // 
            // colMarca
            // 
            colMarca.HeaderText = "Marca";
            colMarca.Name = "colMarca";
            colMarca.ReadOnly = true;
            // 
            // colCategoria
            // 
            colCategoria.HeaderText = "Categoría";
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
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
            colFechaUltimaActualizacion.HeaderText = "Actualización stock";
            colFechaUltimaActualizacion.Name = "colFechaUltimaActualizacion";
            colFechaUltimaActualizacion.ReadOnly = true;
            // 
            // grpBusqueda
            // 
            grpBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpBusqueda.Controls.Add(txtBuscarDescripcion);
            grpBusqueda.Controls.Add(lblBuscarDescripcion);
            grpBusqueda.Controls.Add(btnLimpiarBusqueda);
            grpBusqueda.Controls.Add(btnBuscar);
            grpBusqueda.Location = new Point(980, 82);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Size = new Size(320, 116);
            grpBusqueda.TabIndex = 2;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Buscar producto";
            // 
            // txtBuscarDescripcion
            // 
            txtBuscarDescripcion.Location = new Point(95, 28);
            txtBuscarDescripcion.Name = "txtBuscarDescripcion";
            txtBuscarDescripcion.Size = new Size(196, 23);
            txtBuscarDescripcion.TabIndex = 1;
            // 
            // lblBuscarDescripcion
            // 
            lblBuscarDescripcion.AutoSize = true;
            lblBuscarDescripcion.Location = new Point(15, 31);
            lblBuscarDescripcion.Name = "lblBuscarDescripcion";
            lblBuscarDescripcion.Size = new Size(69, 15);
            lblBuscarDescripcion.TabIndex = 0;
            lblBuscarDescripcion.Text = "Descripción";
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Location = new Point(173, 70);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(118, 27);
            btnLimpiarBusqueda.TabIndex = 3;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(43, 70);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(118, 27);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // FormInventario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1324, 461);
            Controls.Add(grpBusqueda);
            Controls.Add(dgvInventario);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1000, 500);
            Name = "FormInventario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inventario";
            ((System.ComponentModel.ISupportInitialize)dgvInventario).EndInit();
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvInventario;
        private DataGridViewTextBoxColumn colIdInventario;
        private DataGridViewTextBoxColumn colIdProducto;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colMarca;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colStockActual;
        private DataGridViewTextBoxColumn colStockMinimo;
        private DataGridViewTextBoxColumn colFechaUltimaActualizacion;
        private GroupBox grpBusqueda;
        private TextBox txtBuscarDescripcion;
        private Label lblBuscarDescripcion;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
    }
}
