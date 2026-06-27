namespace Libreria.UI
{
    partial class FormColorProducto
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
            dgvColores = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewCheckBoxColumn();
            grpBusqueda = new GroupBox();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            txtBuscarNombre = new TextBox();
            lblBuscarNombre = new Label();
            grpAltaColor = new GroupBox();
            btnAgregarColor = new Button();
            txtAltaNombre = new TextBox();
            lblAltaNombre = new Label();
            grpDatosColor = new GroupBox();
            chkEstado = new CheckBox();
            pnlAcciones = new Panel();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtId = new TextBox();
            lblId = new Label();
            grpColoresNoActivos = new GroupBox();
            chkVerColoresNoActivos = new CheckBox();
            btnReactivarColor = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvColores).BeginInit();
            grpBusqueda.SuspendLayout();
            grpAltaColor.SuspendLayout();
            grpDatosColor.SuspendLayout();
            pnlAcciones.SuspendLayout();
            grpColoresNoActivos.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(233, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Colores de productos";
            // 
            // dgvColores
            // 
            dgvColores.AllowUserToAddRows = false;
            dgvColores.AllowUserToDeleteRows = false;
            dgvColores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvColores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvColores.BackgroundColor = SystemColors.Window;
            dgvColores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvColores.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colEstado });
            dgvColores.Location = new Point(20, 72);
            dgvColores.MultiSelect = false;
            dgvColores.Name = "dgvColores";
            dgvColores.ReadOnly = true;
            dgvColores.RowHeadersVisible = false;
            dgvColores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvColores.Size = new Size(740, 235);
            dgvColores.TabIndex = 1;
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
            colNombre.HeaderText = "Color";
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
            grpBusqueda.Text = "Buscar color";
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
            // grpAltaColor
            // 
            grpAltaColor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpAltaColor.Controls.Add(btnAgregarColor);
            grpAltaColor.Controls.Add(txtAltaNombre);
            grpAltaColor.Controls.Add(lblAltaNombre);
            grpAltaColor.Location = new Point(20, 424);
            grpAltaColor.Name = "grpAltaColor";
            grpAltaColor.Size = new Size(360, 100);
            grpAltaColor.TabIndex = 3;
            grpAltaColor.TabStop = false;
            grpAltaColor.Text = "Datos de alta color";
            // 
            // btnAgregarColor
            // 
            btnAgregarColor.Location = new Point(205, 59);
            btnAgregarColor.Name = "btnAgregarColor";
            btnAgregarColor.Size = new Size(118, 27);
            btnAgregarColor.TabIndex = 2;
            btnAgregarColor.Text = "Agregar color";
            btnAgregarColor.UseVisualStyleBackColor = true;
            btnAgregarColor.Click += btnAgregarColor_Click;
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
            // grpDatosColor
            // 
            grpDatosColor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDatosColor.Controls.Add(chkEstado);
            grpDatosColor.Controls.Add(pnlAcciones);
            grpDatosColor.Controls.Add(txtNombre);
            grpDatosColor.Controls.Add(lblNombre);
            grpDatosColor.Controls.Add(txtId);
            grpDatosColor.Controls.Add(lblId);
            grpDatosColor.Location = new Point(400, 324);
            grpDatosColor.Name = "grpDatosColor";
            grpDatosColor.Size = new Size(360, 200);
            grpDatosColor.TabIndex = 4;
            grpDatosColor.TabStop = false;
            grpDatosColor.Text = "Datos del color seleccionado";
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
            pnlAcciones.Controls.Add(btnLimpiar);
            pnlAcciones.Controls.Add(btnEliminar);
            pnlAcciones.Controls.Add(btnModificar);
            pnlAcciones.Location = new Point(18, 142);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Size = new Size(334, 48);
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
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(120, 10);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(104, 27);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(10, 10);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(104, 27);
            btnModificar.TabIndex = 0;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
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
            // grpColoresNoActivos
            // 
            grpColoresNoActivos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpColoresNoActivos.Controls.Add(chkVerColoresNoActivos);
            grpColoresNoActivos.Controls.Add(btnReactivarColor);
            grpColoresNoActivos.Location = new Point(428, 12);
            grpColoresNoActivos.Name = "grpColoresNoActivos";
            grpColoresNoActivos.Size = new Size(332, 54);
            grpColoresNoActivos.TabIndex = 5;
            grpColoresNoActivos.TabStop = false;
            grpColoresNoActivos.Text = "Colores no activos";
            // 
            // chkVerColoresNoActivos
            // 
            chkVerColoresNoActivos.AutoSize = true;
            chkVerColoresNoActivos.Location = new Point(15, 23);
            chkVerColoresNoActivos.Name = "chkVerColoresNoActivos";
            chkVerColoresNoActivos.Size = new Size(139, 19);
            chkVerColoresNoActivos.TabIndex = 0;
            chkVerColoresNoActivos.Text = "Ver colores no activos";
            chkVerColoresNoActivos.UseVisualStyleBackColor = true;
            // 
            // btnReactivarColor
            // 
            btnReactivarColor.Location = new Point(186, 19);
            btnReactivarColor.Name = "btnReactivarColor";
            btnReactivarColor.Size = new Size(126, 27);
            btnReactivarColor.TabIndex = 1;
            btnReactivarColor.Text = "Reactivar color";
            btnReactivarColor.UseVisualStyleBackColor = true;
            btnReactivarColor.Click += btnReactivarColor_Click;
            // 
            // FormColorProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 541);
            Controls.Add(grpColoresNoActivos);
            Controls.Add(grpDatosColor);
            Controls.Add(grpAltaColor);
            Controls.Add(grpBusqueda);
            Controls.Add(dgvColores);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(800, 580);
            Name = "FormColorProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Colores de productos";
            ((System.ComponentModel.ISupportInitialize)dgvColores).EndInit();
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            grpAltaColor.ResumeLayout(false);
            grpAltaColor.PerformLayout();
            grpDatosColor.ResumeLayout(false);
            grpDatosColor.PerformLayout();
            pnlAcciones.ResumeLayout(false);
            grpColoresNoActivos.ResumeLayout(false);
            grpColoresNoActivos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvColores;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewCheckBoxColumn colEstado;
        private GroupBox grpBusqueda;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
        private TextBox txtBuscarNombre;
        private Label lblBuscarNombre;
        private GroupBox grpAltaColor;
        private Button btnAgregarColor;
        private TextBox txtAltaNombre;
        private Label lblAltaNombre;
        private GroupBox grpDatosColor;
        private Panel pnlAcciones;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnModificar;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtId;
        private Label lblId;
        private CheckBox chkEstado;
        private GroupBox grpColoresNoActivos;
        private CheckBox chkVerColoresNoActivos;
        private Button btnReactivarColor;
    }
}
