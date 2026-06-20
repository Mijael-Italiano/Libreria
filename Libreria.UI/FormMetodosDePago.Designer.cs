namespace Libreria.UI
{
    partial class FormMetodosDePago
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
            dgvMediosPago = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewCheckBoxColumn();
            grpBusqueda = new GroupBox();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            txtBuscarNombre = new TextBox();
            lblBuscarNombre = new Label();
            grpAltaMedioPago = new GroupBox();
            btnAgregarMedioPago = new Button();
            txtAltaNombre = new TextBox();
            lblAltaNombre = new Label();
            grpDatosMedioPago = new GroupBox();
            chkEstado = new CheckBox();
            pnlAcciones = new Panel();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtId = new TextBox();
            lblId = new Label();
            grpMediosPagoNoActivos = new GroupBox();
            chkVerMediosPagoNoActivos = new CheckBox();
            btnReactivarMedioPago = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMediosPago).BeginInit();
            grpBusqueda.SuspendLayout();
            grpAltaMedioPago.SuspendLayout();
            grpDatosMedioPago.SuspendLayout();
            pnlAcciones.SuspendLayout();
            grpMediosPagoNoActivos.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(195, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Métodos de pago";
            // 
            // dgvMediosPago
            // 
            dgvMediosPago.AllowUserToAddRows = false;
            dgvMediosPago.AllowUserToDeleteRows = false;
            dgvMediosPago.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMediosPago.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMediosPago.BackgroundColor = SystemColors.Window;
            dgvMediosPago.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMediosPago.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre, colEstado });
            dgvMediosPago.Location = new Point(112, 72);
            dgvMediosPago.MultiSelect = false;
            dgvMediosPago.Name = "dgvMediosPago";
            dgvMediosPago.ReadOnly = true;
            dgvMediosPago.RowHeadersVisible = false;
            dgvMediosPago.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMediosPago.Size = new Size(560, 235);
            dgvMediosPago.TabIndex = 1;
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
            colNombre.HeaderText = "Nombre";
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
            grpBusqueda.Text = "Buscar método de pago";
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
            // grpAltaMedioPago
            // 
            grpAltaMedioPago.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpAltaMedioPago.Controls.Add(btnAgregarMedioPago);
            grpAltaMedioPago.Controls.Add(txtAltaNombre);
            grpAltaMedioPago.Controls.Add(lblAltaNombre);
            grpAltaMedioPago.Location = new Point(20, 424);
            grpAltaMedioPago.Name = "grpAltaMedioPago";
            grpAltaMedioPago.Size = new Size(360, 100);
            grpAltaMedioPago.TabIndex = 3;
            grpAltaMedioPago.TabStop = false;
            grpAltaMedioPago.Text = "Datos de alta método de pago";
            // 
            // btnAgregarMedioPago
            // 
            btnAgregarMedioPago.Location = new Point(187, 59);
            btnAgregarMedioPago.Name = "btnAgregarMedioPago";
            btnAgregarMedioPago.Size = new Size(136, 27);
            btnAgregarMedioPago.TabIndex = 4;
            btnAgregarMedioPago.Text = "Agregar método";
            btnAgregarMedioPago.UseVisualStyleBackColor = true;
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
            // grpDatosMedioPago
            // 
            grpDatosMedioPago.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDatosMedioPago.Controls.Add(chkEstado);
            grpDatosMedioPago.Controls.Add(pnlAcciones);
            grpDatosMedioPago.Controls.Add(txtNombre);
            grpDatosMedioPago.Controls.Add(lblNombre);
            grpDatosMedioPago.Controls.Add(txtId);
            grpDatosMedioPago.Controls.Add(lblId);
            grpDatosMedioPago.Location = new Point(400, 324);
            grpDatosMedioPago.Name = "grpDatosMedioPago";
            grpDatosMedioPago.Size = new Size(360, 200);
            grpDatosMedioPago.TabIndex = 4;
            grpDatosMedioPago.TabStop = false;
            grpDatosMedioPago.Text = "Datos del método de pago seleccionado";
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
            chkEstado.TabIndex = 7;
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
            pnlAcciones.TabIndex = 6;
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
            // grpMediosPagoNoActivos
            // 
            grpMediosPagoNoActivos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpMediosPagoNoActivos.Controls.Add(chkVerMediosPagoNoActivos);
            grpMediosPagoNoActivos.Controls.Add(btnReactivarMedioPago);
            grpMediosPagoNoActivos.Location = new Point(428, 12);
            grpMediosPagoNoActivos.Name = "grpMediosPagoNoActivos";
            grpMediosPagoNoActivos.Size = new Size(332, 54);
            grpMediosPagoNoActivos.TabIndex = 5;
            grpMediosPagoNoActivos.TabStop = false;
            grpMediosPagoNoActivos.Text = "Métodos de pago no activos";
            // 
            // chkVerMediosPagoNoActivos
            // 
            chkVerMediosPagoNoActivos.AutoSize = true;
            chkVerMediosPagoNoActivos.Location = new Point(15, 23);
            chkVerMediosPagoNoActivos.Name = "chkVerMediosPagoNoActivos";
            chkVerMediosPagoNoActivos.Size = new Size(194, 19);
            chkVerMediosPagoNoActivos.TabIndex = 0;
            chkVerMediosPagoNoActivos.Text = "Ver métodos de pago no activos";
            chkVerMediosPagoNoActivos.UseVisualStyleBackColor = true;
            // 
            // btnReactivarMedioPago
            // 
            btnReactivarMedioPago.Location = new Point(215, 19);
            btnReactivarMedioPago.Name = "btnReactivarMedioPago";
            btnReactivarMedioPago.Size = new Size(97, 27);
            btnReactivarMedioPago.TabIndex = 1;
            btnReactivarMedioPago.Text = "Reactivar";
            btnReactivarMedioPago.UseVisualStyleBackColor = true;
            // 
            // FormMetodosDePago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 541);
            Controls.Add(grpMediosPagoNoActivos);
            Controls.Add(grpDatosMedioPago);
            Controls.Add(grpAltaMedioPago);
            Controls.Add(grpBusqueda);
            Controls.Add(dgvMediosPago);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(800, 580);
            Name = "FormMetodosDePago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Métodos de pago";
            ((System.ComponentModel.ISupportInitialize)dgvMediosPago).EndInit();
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            grpAltaMedioPago.ResumeLayout(false);
            grpAltaMedioPago.PerformLayout();
            grpDatosMedioPago.ResumeLayout(false);
            grpDatosMedioPago.PerformLayout();
            pnlAcciones.ResumeLayout(false);
            grpMediosPagoNoActivos.ResumeLayout(false);
            grpMediosPagoNoActivos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvMediosPago;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewCheckBoxColumn colEstado;
        private GroupBox grpBusqueda;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
        private TextBox txtBuscarNombre;
        private Label lblBuscarNombre;
        private GroupBox grpAltaMedioPago;
        private Button btnAgregarMedioPago;
        private TextBox txtAltaNombre;
        private Label lblAltaNombre;
        private GroupBox grpDatosMedioPago;
        private CheckBox chkEstado;
        private Panel pnlAcciones;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnModificar;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtId;
        private Label lblId;
        private GroupBox grpMediosPagoNoActivos;
        private CheckBox chkVerMediosPagoNoActivos;
        private Button btnReactivarMedioPago;
    }
}
