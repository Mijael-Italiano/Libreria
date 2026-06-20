namespace Libreria.UI
{
    partial class FormCategoriaProducto
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
            dgvCategorias = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewCheckBoxColumn();
            grpBusqueda = new GroupBox();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            txtBuscarNombre = new TextBox();
            lblBuscarNombre = new Label();
            grpAltaCategoria = new GroupBox();
            btnAgregarCategoria = new Button();
            txtAltaNombre = new TextBox();
            lblAltaNombre = new Label();
            grpDatosCategoria = new GroupBox();
            chkEstado = new CheckBox();
            pnlAcciones = new Panel();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtId = new TextBox();
            lblId = new Label();
            grpCategoriasNoActivas = new GroupBox();
            chkVerCategoriasNoActivas = new CheckBox();
            btnReactivarCategoria = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            grpBusqueda.SuspendLayout();
            grpAltaCategoria.SuspendLayout();
            grpDatosCategoria.SuspendLayout();
            pnlAcciones.SuspendLayout();
            grpCategoriasNoActivas.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(264, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Categorías de productos";
            // 
            // dgvCategorias
            // 
            dgvCategorias.AllowUserToAddRows = false;
            dgvCategorias.AllowUserToDeleteRows = false;
            dgvCategorias.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvCategorias.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCategorias.BackgroundColor = SystemColors.Window;
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colEstado });
            dgvCategorias.Location = new Point(20, 72);
            dgvCategorias.MultiSelect = false;
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.ReadOnly = true;
            dgvCategorias.RowHeadersVisible = false;
            dgvCategorias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCategorias.Size = new Size(740, 235);
            dgvCategorias.TabIndex = 1;
            // 
            // colId
            // 
            colId.FillWeight = 35F;
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Categoría";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.FillWeight = 45F;
            colEstado.HeaderText = "Activo";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // grpBusqueda
            // 
            grpBusqueda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpBusqueda.Controls.Add(btnLimpiarBusqueda);
            grpBusqueda.Controls.Add(btnBuscar);
            grpBusqueda.Controls.Add(txtBuscarNombre);
            grpBusqueda.Controls.Add(lblBuscarNombre);
            grpBusqueda.Location = new Point(20, 324);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Size = new Size(360, 94);
            grpBusqueda.TabIndex = 2;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Buscar categoría";
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Location = new Point(205, 58);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(118, 27);
            btnLimpiarBusqueda.TabIndex = 3;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(75, 58);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(118, 27);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.Location = new Point(102, 27);
            txtBuscarNombre.Name = "txtBuscarNombre";
            txtBuscarNombre.Size = new Size(221, 23);
            txtBuscarNombre.TabIndex = 1;
            // 
            // lblBuscarNombre
            // 
            lblBuscarNombre.AutoSize = true;
            lblBuscarNombre.Location = new Point(18, 30);
            lblBuscarNombre.Name = "lblBuscarNombre";
            lblBuscarNombre.Size = new Size(51, 15);
            lblBuscarNombre.TabIndex = 0;
            lblBuscarNombre.Text = "Nombre";
            // 
            // grpAltaCategoria
            // 
            grpAltaCategoria.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpAltaCategoria.Controls.Add(btnAgregarCategoria);
            grpAltaCategoria.Controls.Add(txtAltaNombre);
            grpAltaCategoria.Controls.Add(lblAltaNombre);
            grpAltaCategoria.Location = new Point(20, 424);
            grpAltaCategoria.Name = "grpAltaCategoria";
            grpAltaCategoria.Size = new Size(360, 100);
            grpAltaCategoria.TabIndex = 3;
            grpAltaCategoria.TabStop = false;
            grpAltaCategoria.Text = "Datos de alta categoría";
            // 
            // btnAgregarCategoria
            // 
            btnAgregarCategoria.Location = new Point(187, 59);
            btnAgregarCategoria.Name = "btnAgregarCategoria";
            btnAgregarCategoria.Size = new Size(136, 27);
            btnAgregarCategoria.TabIndex = 2;
            btnAgregarCategoria.Text = "Agregar categoría";
            btnAgregarCategoria.UseVisualStyleBackColor = true;
            // 
            // txtAltaNombre
            // 
            txtAltaNombre.Location = new Point(102, 27);
            txtAltaNombre.Name = "txtAltaNombre";
            txtAltaNombre.Size = new Size(221, 23);
            txtAltaNombre.TabIndex = 1;
            // 
            // lblAltaNombre
            // 
            lblAltaNombre.AutoSize = true;
            lblAltaNombre.Location = new Point(18, 30);
            lblAltaNombre.Name = "lblAltaNombre";
            lblAltaNombre.Size = new Size(51, 15);
            lblAltaNombre.TabIndex = 0;
            lblAltaNombre.Text = "Nombre";
            // 
            // grpDatosCategoria
            // 
            grpDatosCategoria.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDatosCategoria.Controls.Add(chkEstado);
            grpDatosCategoria.Controls.Add(pnlAcciones);
            grpDatosCategoria.Controls.Add(txtNombre);
            grpDatosCategoria.Controls.Add(lblNombre);
            grpDatosCategoria.Controls.Add(txtId);
            grpDatosCategoria.Controls.Add(lblId);
            grpDatosCategoria.Location = new Point(400, 324);
            grpDatosCategoria.Name = "grpDatosCategoria";
            grpDatosCategoria.Size = new Size(360, 200);
            grpDatosCategoria.TabIndex = 4;
            grpDatosCategoria.TabStop = false;
            grpDatosCategoria.Text = "Datos de la categoría seleccionada";
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.BackColor = SystemColors.Control;
            chkEstado.Checked = true;
            chkEstado.CheckState = CheckState.Checked;
            chkEstado.Enabled = false;
            chkEstado.ForeColor = SystemColors.ControlDark;
            chkEstado.Location = new Point(102, 108);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(60, 19);
            chkEstado.TabIndex = 5;
            chkEstado.Text = "Activo";
            chkEstado.UseVisualStyleBackColor = false;
            // 
            // pnlAcciones
            // 
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Controls.Add(btnLimpiar);
            pnlAcciones.Controls.Add(btnEliminar);
            pnlAcciones.Controls.Add(btnModificar);
            pnlAcciones.Location = new Point(6, 141);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Size = new Size(348, 48);
            pnlAcciones.TabIndex = 4;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(230, 10);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(104, 27);
            btnLimpiar.TabIndex = 2;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(120, 10);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(104, 27);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(10, 10);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(104, 27);
            btnModificar.TabIndex = 0;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(102, 72);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(221, 23);
            txtNombre.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(18, 75);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // txtId
            // 
            txtId.BackColor = SystemColors.Control;
            txtId.ForeColor = SystemColors.ControlDark;
            txtId.Location = new Point(102, 36);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(221, 23);
            txtId.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(18, 39);
            lblId.Name = "lblId";
            lblId.Size = new Size(18, 15);
            lblId.TabIndex = 0;
            lblId.Text = "ID";
            // 
            // grpCategoriasNoActivas
            // 
            grpCategoriasNoActivas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpCategoriasNoActivas.Controls.Add(chkVerCategoriasNoActivas);
            grpCategoriasNoActivas.Controls.Add(btnReactivarCategoria);
            grpCategoriasNoActivas.Location = new Point(428, 12);
            grpCategoriasNoActivas.Name = "grpCategoriasNoActivas";
            grpCategoriasNoActivas.Size = new Size(332, 54);
            grpCategoriasNoActivas.TabIndex = 5;
            grpCategoriasNoActivas.TabStop = false;
            grpCategoriasNoActivas.Text = "Categorías no activas";
            // 
            // chkVerCategoriasNoActivas
            // 
            chkVerCategoriasNoActivas.AutoSize = true;
            chkVerCategoriasNoActivas.Location = new Point(15, 23);
            chkVerCategoriasNoActivas.Name = "chkVerCategoriasNoActivas";
            chkVerCategoriasNoActivas.Size = new Size(158, 19);
            chkVerCategoriasNoActivas.TabIndex = 0;
            chkVerCategoriasNoActivas.Text = "Ver categorías no activas";
            chkVerCategoriasNoActivas.UseVisualStyleBackColor = true;
            // 
            // btnReactivarCategoria
            // 
            btnReactivarCategoria.Location = new Point(186, 19);
            btnReactivarCategoria.Name = "btnReactivarCategoria";
            btnReactivarCategoria.Size = new Size(126, 27);
            btnReactivarCategoria.TabIndex = 1;
            btnReactivarCategoria.Text = "Reactivar categoría";
            btnReactivarCategoria.UseVisualStyleBackColor = true;
            // 
            // FormCategoriaProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 541);
            Controls.Add(grpCategoriasNoActivas);
            Controls.Add(grpDatosCategoria);
            Controls.Add(grpAltaCategoria);
            Controls.Add(grpBusqueda);
            Controls.Add(dgvCategorias);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(800, 580);
            Name = "FormCategoriaProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Categorías de productos";
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            grpAltaCategoria.ResumeLayout(false);
            grpAltaCategoria.PerformLayout();
            grpDatosCategoria.ResumeLayout(false);
            grpDatosCategoria.PerformLayout();
            pnlAcciones.ResumeLayout(false);
            grpCategoriasNoActivas.ResumeLayout(false);
            grpCategoriasNoActivas.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvCategorias;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewCheckBoxColumn colEstado;
        private GroupBox grpBusqueda;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
        private TextBox txtBuscarNombre;
        private Label lblBuscarNombre;
        private GroupBox grpAltaCategoria;
        private Button btnAgregarCategoria;
        private TextBox txtAltaNombre;
        private Label lblAltaNombre;
        private GroupBox grpDatosCategoria;
        private CheckBox chkEstado;
        private Panel pnlAcciones;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnModificar;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtId;
        private Label lblId;
        private GroupBox grpCategoriasNoActivas;
        private CheckBox chkVerCategoriasNoActivas;
        private Button btnReactivarCategoria;
    }
}
