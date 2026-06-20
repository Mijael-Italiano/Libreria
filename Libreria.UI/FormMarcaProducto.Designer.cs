namespace Libreria.UI
{
    partial class FormMarcaProducto
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
            dgvMarcas = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewCheckBoxColumn();
            grpBusqueda = new GroupBox();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            txtBuscarNombre = new TextBox();
            lblBuscarNombre = new Label();
            grpAltaMarca = new GroupBox();
            btnAgregarMarca = new Button();
            txtAltaNombre = new TextBox();
            lblAltaNombre = new Label();
            grpDatosMarca = new GroupBox();
            pnlAcciones = new Panel();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtId = new TextBox();
            lblId = new Label();
            chkEstado = new CheckBox();
            grpMarcasNoActivas = new GroupBox();
            chkVerMarcasNoActivas = new CheckBox();
            btnReactivarMarca = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).BeginInit();
            grpBusqueda.SuspendLayout();
            grpAltaMarca.SuspendLayout();
            grpDatosMarca.SuspendLayout();
            pnlAcciones.SuspendLayout();
            grpMarcasNoActivas.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(226, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Marcas de productos";
            // 
            // dgvMarcas
            // 
            dgvMarcas.AllowUserToAddRows = false;
            dgvMarcas.AllowUserToDeleteRows = false;
            dgvMarcas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMarcas.BackgroundColor = SystemColors.Window;
            dgvMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMarcas.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colEstado });
            dgvMarcas.Location = new Point(20, 72);
            dgvMarcas.MultiSelect = false;
            dgvMarcas.Name = "dgvMarcas";
            dgvMarcas.ReadOnly = true;
            dgvMarcas.RowHeadersVisible = false;
            dgvMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarcas.Size = new Size(740, 235);
            dgvMarcas.TabIndex = 1;
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
            colNombre.HeaderText = "Marca";
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
            grpBusqueda.Text = "Buscar marca";
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
            // grpAltaMarca
            // 
            grpAltaMarca.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpAltaMarca.Controls.Add(btnAgregarMarca);
            grpAltaMarca.Controls.Add(txtAltaNombre);
            grpAltaMarca.Controls.Add(lblAltaNombre);
            grpAltaMarca.Location = new Point(20, 424);
            grpAltaMarca.Name = "grpAltaMarca";
            grpAltaMarca.Size = new Size(360, 100);
            grpAltaMarca.TabIndex = 3;
            grpAltaMarca.TabStop = false;
            grpAltaMarca.Text = "Datos de alta marca";
            // 
            // btnAgregarMarca
            // 
            btnAgregarMarca.Location = new Point(205, 59);
            btnAgregarMarca.Name = "btnAgregarMarca";
            btnAgregarMarca.Size = new Size(118, 27);
            btnAgregarMarca.TabIndex = 2;
            btnAgregarMarca.Text = "Agregar marca";
            btnAgregarMarca.UseVisualStyleBackColor = true;
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
            // grpDatosMarca
            // 
            grpDatosMarca.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDatosMarca.Controls.Add(chkEstado);
            grpDatosMarca.Controls.Add(pnlAcciones);
            grpDatosMarca.Controls.Add(txtNombre);
            grpDatosMarca.Controls.Add(lblNombre);
            grpDatosMarca.Controls.Add(txtId);
            grpDatosMarca.Controls.Add(lblId);
            grpDatosMarca.Location = new Point(400, 324);
            grpDatosMarca.Name = "grpDatosMarca";
            grpDatosMarca.Size = new Size(360, 200);
            grpDatosMarca.TabIndex = 4;
            grpDatosMarca.TabStop = false;
            grpDatosMarca.Text = "Datos de la marca seleccionada";
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
            // grpMarcasNoActivas
            // 
            grpMarcasNoActivas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpMarcasNoActivas.Controls.Add(chkVerMarcasNoActivas);
            grpMarcasNoActivas.Controls.Add(btnReactivarMarca);
            grpMarcasNoActivas.Location = new Point(428, 12);
            grpMarcasNoActivas.Name = "grpMarcasNoActivas";
            grpMarcasNoActivas.Size = new Size(332, 54);
            grpMarcasNoActivas.TabIndex = 5;
            grpMarcasNoActivas.TabStop = false;
            grpMarcasNoActivas.Text = "Marcas no activas";
            // 
            // chkVerMarcasNoActivas
            // 
            chkVerMarcasNoActivas.AutoSize = true;
            chkVerMarcasNoActivas.Location = new Point(15, 23);
            chkVerMarcasNoActivas.Name = "chkVerMarcasNoActivas";
            chkVerMarcasNoActivas.Size = new Size(141, 19);
            chkVerMarcasNoActivas.TabIndex = 0;
            chkVerMarcasNoActivas.Text = "Ver marcas no activas";
            chkVerMarcasNoActivas.UseVisualStyleBackColor = true;
            // 
            // btnReactivarMarca
            // 
            btnReactivarMarca.Location = new Point(186, 19);
            btnReactivarMarca.Name = "btnReactivarMarca";
            btnReactivarMarca.Size = new Size(126, 27);
            btnReactivarMarca.TabIndex = 1;
            btnReactivarMarca.Text = "Reactivar marca";
            btnReactivarMarca.UseVisualStyleBackColor = true;
            // 
            // FormMarcaProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 541);
            Controls.Add(grpMarcasNoActivas);
            Controls.Add(grpDatosMarca);
            Controls.Add(grpAltaMarca);
            Controls.Add(grpBusqueda);
            Controls.Add(dgvMarcas);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(800, 580);
            Name = "FormMarcaProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Marcas de productos";
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).EndInit();
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            grpAltaMarca.ResumeLayout(false);
            grpAltaMarca.PerformLayout();
            grpDatosMarca.ResumeLayout(false);
            grpDatosMarca.PerformLayout();
            pnlAcciones.ResumeLayout(false);
            grpMarcasNoActivas.ResumeLayout(false);
            grpMarcasNoActivas.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvMarcas;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewCheckBoxColumn colEstado;
        private GroupBox grpBusqueda;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
        private TextBox txtBuscarNombre;
        private Label lblBuscarNombre;
        private GroupBox grpAltaMarca;
        private Button btnAgregarMarca;
        private TextBox txtAltaNombre;
        private Label lblAltaNombre;
        private GroupBox grpDatosMarca;
        private Panel pnlAcciones;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnModificar;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtId;
        private Label lblId;
        private CheckBox chkEstado;
        private GroupBox grpMarcasNoActivas;
        private CheckBox chkVerMarcasNoActivas;
        private Button btnReactivarMarca;
    }
}
