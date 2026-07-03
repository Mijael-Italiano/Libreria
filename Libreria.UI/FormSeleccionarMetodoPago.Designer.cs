namespace Libreria.UI
{
    partial class FormSeleccionarMetodoPago
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
            colIdMedioPago = new DataGridViewTextBoxColumn();
            colMedioPago = new DataGridViewTextBoxColumn();
            colEstadoMedioPago = new DataGridViewCheckBoxColumn();
            dgvPagosVenta = new DataGridView();
            colPagoIdMedioPago = new DataGridViewTextBoxColumn();
            colPagoMedioPago = new DataGridViewTextBoxColumn();
            colPagoMonto = new DataGridViewTextBoxColumn();
            grpBusqueda = new GroupBox();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            txtBuscarNombre = new TextBox();
            lblBuscarNombre = new Label();
            grpResumenPago = new GroupBox();
            txtSaldoPendiente = new TextBox();
            lblSaldoPendiente = new Label();
            txtTotalAsignado = new TextBox();
            lblTotalAsignado = new Label();
            txtTotalPagar = new TextBox();
            lblTotalPagar = new Label();
            grpAgregarPago = new GroupBox();
            chkAgregarRestante = new CheckBox();
            btnLimpiarPago = new Button();
            btnAgregarPago = new Button();
            txtMonto = new TextBox();
            lblMonto = new Label();
            txtNombreMedioPago = new TextBox();
            lblNombreMedioPago = new Label();
            txtIdMedioPago = new TextBox();
            lblIdMedioPago = new Label();
            grpPagoSeleccionado = new GroupBox();
            pnlAccionesPago = new Panel();
            btnLimpiarSeleccion = new Button();
            btnEliminarPago = new Button();
            btnModificarMonto = new Button();
            txtMontoSeleccionado = new TextBox();
            lblMontoSeleccionado = new Label();
            txtNombreMedioPagoSeleccionado = new TextBox();
            lblNombreMedioPagoSeleccionado = new Label();
            txtIdMedioPagoSeleccionado = new TextBox();
            lblIdMedioPagoSeleccionado = new Label();
            pnlAccionesFinales = new Panel();
            btnCancelar = new Button();
            btnConfirmarPago = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMediosPago).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagosVenta).BeginInit();
            grpBusqueda.SuspendLayout();
            grpResumenPago.SuspendLayout();
            grpAgregarPago.SuspendLayout();
            grpPagoSeleccionado.SuspendLayout();
            pnlAccionesPago.SuspendLayout();
            pnlAccionesFinales.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(308, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Seleccionar metodo de pago";
            // 
            // dgvMediosPago
            // 
            dgvMediosPago.AllowUserToAddRows = false;
            dgvMediosPago.AllowUserToDeleteRows = false;
            dgvMediosPago.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dgvMediosPago.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMediosPago.BackgroundColor = SystemColors.Window;
            dgvMediosPago.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMediosPago.Columns.AddRange(new DataGridViewColumn[] { colIdMedioPago, colMedioPago, colEstadoMedioPago });
            dgvMediosPago.Location = new Point(20, 72);
            dgvMediosPago.MultiSelect = false;
            dgvMediosPago.Name = "dgvMediosPago";
            dgvMediosPago.ReadOnly = true;
            dgvMediosPago.RowHeadersVisible = false;
            dgvMediosPago.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMediosPago.Size = new Size(450, 205);
            dgvMediosPago.TabIndex = 1;
            dgvMediosPago.SelectionChanged += dgvMediosPago_SelectionChanged;
            // 
            // colIdMedioPago
            // 
            colIdMedioPago.FillWeight = 45F;
            colIdMedioPago.HeaderText = "Id";
            colIdMedioPago.Name = "colIdMedioPago";
            colIdMedioPago.ReadOnly = true;
            // 
            // colMedioPago
            // 
            colMedioPago.HeaderText = "Medio de pago";
            colMedioPago.Name = "colMedioPago";
            colMedioPago.ReadOnly = true;
            // 
            // colEstadoMedioPago
            // 
            colEstadoMedioPago.FillWeight = 45F;
            colEstadoMedioPago.HeaderText = "Activo";
            colEstadoMedioPago.Name = "colEstadoMedioPago";
            colEstadoMedioPago.ReadOnly = true;
            // 
            // dgvPagosVenta
            // 
            dgvPagosVenta.AllowUserToAddRows = false;
            dgvPagosVenta.AllowUserToDeleteRows = false;
            dgvPagosVenta.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvPagosVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPagosVenta.BackgroundColor = SystemColors.Window;
            dgvPagosVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPagosVenta.Columns.AddRange(new DataGridViewColumn[] { colPagoIdMedioPago, colPagoMedioPago, colPagoMonto });
            dgvPagosVenta.Location = new Point(20, 345);
            dgvPagosVenta.MultiSelect = false;
            dgvPagosVenta.Name = "dgvPagosVenta";
            dgvPagosVenta.ReadOnly = true;
            dgvPagosVenta.RowHeadersVisible = false;
            dgvPagosVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPagosVenta.Size = new Size(450, 288);
            dgvPagosVenta.TabIndex = 2;
            dgvPagosVenta.SelectionChanged += dgvPagosVenta_SelectionChanged;
            // 
            // colPagoIdMedioPago
            // 
            colPagoIdMedioPago.FillWeight = 45F;
            colPagoIdMedioPago.HeaderText = "Id";
            colPagoIdMedioPago.Name = "colPagoIdMedioPago";
            colPagoIdMedioPago.ReadOnly = true;
            // 
            // colPagoMedioPago
            // 
            colPagoMedioPago.HeaderText = "Medio de pago";
            colPagoMedioPago.Name = "colPagoMedioPago";
            colPagoMedioPago.ReadOnly = true;
            // 
            // colPagoMonto
            // 
            colPagoMonto.FillWeight = 70F;
            colPagoMonto.HeaderText = "Monto";
            colPagoMonto.Name = "colPagoMonto";
            colPagoMonto.ReadOnly = true;
            // 
            // grpBusqueda
            // 
            grpBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            grpBusqueda.Controls.Add(btnLimpiarBusqueda);
            grpBusqueda.Controls.Add(btnBuscar);
            grpBusqueda.Controls.Add(txtBuscarNombre);
            grpBusqueda.Controls.Add(lblBuscarNombre);
            grpBusqueda.Location = new Point(20, 285);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Size = new Size(450, 48);
            grpBusqueda.TabIndex = 7;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Buscar medio de pago";
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLimpiarBusqueda.Location = new Point(337, 15);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(90, 27);
            btnLimpiarBusqueda.TabIndex = 3;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            btnLimpiarBusqueda.Click += btnLimpiarBusqueda_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.Location = new Point(241, 15);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(90, 27);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtBuscarNombre.Location = new Point(85, 18);
            txtBuscarNombre.Name = "txtBuscarNombre";
            txtBuscarNombre.Size = new Size(140, 23);
            txtBuscarNombre.TabIndex = 1;
            // 
            // lblBuscarNombre
            // 
            lblBuscarNombre.AutoSize = true;
            lblBuscarNombre.Location = new Point(18, 21);
            lblBuscarNombre.Name = "lblBuscarNombre";
            lblBuscarNombre.Size = new Size(51, 15);
            lblBuscarNombre.TabIndex = 0;
            lblBuscarNombre.Text = "Nombre";
            // 
            // grpResumenPago
            // 
            grpResumenPago.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpResumenPago.Controls.Add(txtSaldoPendiente);
            grpResumenPago.Controls.Add(lblSaldoPendiente);
            grpResumenPago.Controls.Add(txtTotalAsignado);
            grpResumenPago.Controls.Add(lblTotalAsignado);
            grpResumenPago.Controls.Add(txtTotalPagar);
            grpResumenPago.Controls.Add(lblTotalPagar);
            grpResumenPago.Location = new Point(500, 72);
            grpResumenPago.Name = "grpResumenPago";
            grpResumenPago.Size = new Size(360, 130);
            grpResumenPago.TabIndex = 3;
            grpResumenPago.TabStop = false;
            grpResumenPago.Text = "Resumen de pago";
            // 
            // txtSaldoPendiente
            // 
            txtSaldoPendiente.BackColor = SystemColors.Control;
            txtSaldoPendiente.ForeColor = SystemColors.ControlDark;
            txtSaldoPendiente.Location = new Point(140, 90);
            txtSaldoPendiente.Name = "txtSaldoPendiente";
            txtSaldoPendiente.ReadOnly = true;
            txtSaldoPendiente.Size = new Size(190, 23);
            txtSaldoPendiente.TabIndex = 5;
            // 
            // lblSaldoPendiente
            // 
            lblSaldoPendiente.AutoSize = true;
            lblSaldoPendiente.Location = new Point(18, 93);
            lblSaldoPendiente.Name = "lblSaldoPendiente";
            lblSaldoPendiente.Size = new Size(92, 15);
            lblSaldoPendiente.TabIndex = 4;
            lblSaldoPendiente.Text = "Saldo pendiente";
            // 
            // txtTotalAsignado
            // 
            txtTotalAsignado.BackColor = SystemColors.Control;
            txtTotalAsignado.ForeColor = SystemColors.ControlDark;
            txtTotalAsignado.Location = new Point(140, 58);
            txtTotalAsignado.Name = "txtTotalAsignado";
            txtTotalAsignado.ReadOnly = true;
            txtTotalAsignado.Size = new Size(190, 23);
            txtTotalAsignado.TabIndex = 3;
            // 
            // lblTotalAsignado
            // 
            lblTotalAsignado.AutoSize = true;
            lblTotalAsignado.Location = new Point(18, 61);
            lblTotalAsignado.Name = "lblTotalAsignado";
            lblTotalAsignado.Size = new Size(83, 15);
            lblTotalAsignado.TabIndex = 2;
            lblTotalAsignado.Text = "Total asignado";
            // 
            // txtTotalPagar
            // 
            txtTotalPagar.BackColor = SystemColors.Control;
            txtTotalPagar.ForeColor = SystemColors.ControlDark;
            txtTotalPagar.Location = new Point(140, 27);
            txtTotalPagar.Name = "txtTotalPagar";
            txtTotalPagar.ReadOnly = true;
            txtTotalPagar.Size = new Size(190, 23);
            txtTotalPagar.TabIndex = 1;
            // 
            // lblTotalPagar
            // 
            lblTotalPagar.AutoSize = true;
            lblTotalPagar.Location = new Point(18, 30);
            lblTotalPagar.Name = "lblTotalPagar";
            lblTotalPagar.Size = new Size(74, 15);
            lblTotalPagar.TabIndex = 0;
            lblTotalPagar.Text = "Total a pagar";
            // 
            // grpAgregarPago
            // 
            grpAgregarPago.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpAgregarPago.Controls.Add(chkAgregarRestante);
            grpAgregarPago.Controls.Add(btnLimpiarPago);
            grpAgregarPago.Controls.Add(btnAgregarPago);
            grpAgregarPago.Controls.Add(txtMonto);
            grpAgregarPago.Controls.Add(lblMonto);
            grpAgregarPago.Controls.Add(txtNombreMedioPago);
            grpAgregarPago.Controls.Add(lblNombreMedioPago);
            grpAgregarPago.Controls.Add(txtIdMedioPago);
            grpAgregarPago.Controls.Add(lblIdMedioPago);
            grpAgregarPago.Location = new Point(500, 220);
            grpAgregarPago.Name = "grpAgregarPago";
            grpAgregarPago.Size = new Size(360, 190);
            grpAgregarPago.TabIndex = 4;
            grpAgregarPago.TabStop = false;
            grpAgregarPago.Text = "Agregar pago";
            // 
            // chkAgregarRestante
            // 
            chkAgregarRestante.AutoSize = true;
            chkAgregarRestante.Location = new Point(140, 113);
            chkAgregarRestante.Name = "chkAgregarRestante";
            chkAgregarRestante.Size = new Size(113, 19);
            chkAgregarRestante.TabIndex = 6;
            chkAgregarRestante.Text = "Agregar restante";
            chkAgregarRestante.UseVisualStyleBackColor = true;
            // 
            // btnLimpiarPago
            // 
            btnLimpiarPago.Location = new Point(212, 146);
            btnLimpiarPago.Name = "btnLimpiarPago";
            btnLimpiarPago.Size = new Size(118, 27);
            btnLimpiarPago.TabIndex = 8;
            btnLimpiarPago.Text = "Limpiar";
            btnLimpiarPago.UseVisualStyleBackColor = true;
            btnLimpiarPago.Click += btnLimpiarPago_Click;
            // 
            // btnAgregarPago
            // 
            btnAgregarPago.Location = new Point(75, 146);
            btnAgregarPago.Name = "btnAgregarPago";
            btnAgregarPago.Size = new Size(118, 27);
            btnAgregarPago.TabIndex = 7;
            btnAgregarPago.Text = "Agregar pago";
            btnAgregarPago.UseVisualStyleBackColor = true;
            btnAgregarPago.Click += btnAgregarPago_Click;
            // 
            // txtMonto
            // 
            txtMonto.Location = new Point(140, 84);
            txtMonto.Name = "txtMonto";
            txtMonto.Size = new Size(190, 23);
            txtMonto.TabIndex = 5;
            // 
            // lblMonto
            // 
            lblMonto.AutoSize = true;
            lblMonto.Location = new Point(18, 87);
            lblMonto.Name = "lblMonto";
            lblMonto.Size = new Size(43, 15);
            lblMonto.TabIndex = 4;
            lblMonto.Text = "Monto";
            // 
            // txtNombreMedioPago
            // 
            txtNombreMedioPago.BackColor = SystemColors.Control;
            txtNombreMedioPago.ForeColor = SystemColors.ControlDark;
            txtNombreMedioPago.Location = new Point(140, 55);
            txtNombreMedioPago.Name = "txtNombreMedioPago";
            txtNombreMedioPago.ReadOnly = true;
            txtNombreMedioPago.Size = new Size(190, 23);
            txtNombreMedioPago.TabIndex = 3;
            // 
            // lblNombreMedioPago
            // 
            lblNombreMedioPago.AutoSize = true;
            lblNombreMedioPago.Location = new Point(18, 58);
            lblNombreMedioPago.Name = "lblNombreMedioPago";
            lblNombreMedioPago.Size = new Size(51, 15);
            lblNombreMedioPago.TabIndex = 2;
            lblNombreMedioPago.Text = "Nombre";
            // 
            // txtIdMedioPago
            // 
            txtIdMedioPago.BackColor = SystemColors.Control;
            txtIdMedioPago.ForeColor = SystemColors.ControlDark;
            txtIdMedioPago.Location = new Point(140, 26);
            txtIdMedioPago.Name = "txtIdMedioPago";
            txtIdMedioPago.ReadOnly = true;
            txtIdMedioPago.Size = new Size(70, 23);
            txtIdMedioPago.TabIndex = 1;
            // 
            // lblIdMedioPago
            // 
            lblIdMedioPago.AutoSize = true;
            lblIdMedioPago.Location = new Point(18, 29);
            lblIdMedioPago.Name = "lblIdMedioPago";
            lblIdMedioPago.Size = new Size(17, 15);
            lblIdMedioPago.TabIndex = 0;
            lblIdMedioPago.Text = "Id";
            // 
            // grpPagoSeleccionado
            // 
            grpPagoSeleccionado.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            grpPagoSeleccionado.Controls.Add(pnlAccionesPago);
            grpPagoSeleccionado.Controls.Add(txtMontoSeleccionado);
            grpPagoSeleccionado.Controls.Add(lblMontoSeleccionado);
            grpPagoSeleccionado.Controls.Add(txtNombreMedioPagoSeleccionado);
            grpPagoSeleccionado.Controls.Add(lblNombreMedioPagoSeleccionado);
            grpPagoSeleccionado.Controls.Add(txtIdMedioPagoSeleccionado);
            grpPagoSeleccionado.Controls.Add(lblIdMedioPagoSeleccionado);
            grpPagoSeleccionado.Location = new Point(500, 430);
            grpPagoSeleccionado.Name = "grpPagoSeleccionado";
            grpPagoSeleccionado.Size = new Size(360, 145);
            grpPagoSeleccionado.TabIndex = 5;
            grpPagoSeleccionado.TabStop = false;
            grpPagoSeleccionado.Text = "Pago seleccionado";
            // 
            // pnlAccionesPago
            // 
            pnlAccionesPago.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAccionesPago.Controls.Add(btnLimpiarSeleccion);
            pnlAccionesPago.Controls.Add(btnEliminarPago);
            pnlAccionesPago.Controls.Add(btnModificarMonto);
            pnlAccionesPago.Location = new Point(6, 94);
            pnlAccionesPago.Name = "pnlAccionesPago";
            pnlAccionesPago.Size = new Size(348, 45);
            pnlAccionesPago.TabIndex = 6;
            // 
            // btnLimpiarSeleccion
            // 
            btnLimpiarSeleccion.Location = new Point(238, 10);
            btnLimpiarSeleccion.Name = "btnLimpiarSeleccion";
            btnLimpiarSeleccion.Size = new Size(100, 27);
            btnLimpiarSeleccion.TabIndex = 2;
            btnLimpiarSeleccion.Text = "Limpiar";
            btnLimpiarSeleccion.UseVisualStyleBackColor = true;
            btnLimpiarSeleccion.Click += btnLimpiarSeleccion_Click;
            // 
            // btnEliminarPago
            // 
            btnEliminarPago.Location = new Point(128, 10);
            btnEliminarPago.Name = "btnEliminarPago";
            btnEliminarPago.Size = new Size(100, 27);
            btnEliminarPago.TabIndex = 1;
            btnEliminarPago.Text = "Eliminar pago";
            btnEliminarPago.UseVisualStyleBackColor = true;
            btnEliminarPago.Click += btnEliminarPago_Click;
            // 
            // btnModificarMonto
            // 
            btnModificarMonto.Location = new Point(10, 10);
            btnModificarMonto.Name = "btnModificarMonto";
            btnModificarMonto.Size = new Size(108, 27);
            btnModificarMonto.TabIndex = 0;
            btnModificarMonto.Text = "Modificar monto";
            btnModificarMonto.UseVisualStyleBackColor = true;
            btnModificarMonto.Click += btnModificarMonto_Click;
            // 
            // txtMontoSeleccionado
            // 
            txtMontoSeleccionado.Location = new Point(242, 58);
            txtMontoSeleccionado.Name = "txtMontoSeleccionado";
            txtMontoSeleccionado.Size = new Size(88, 23);
            txtMontoSeleccionado.TabIndex = 5;
            // 
            // lblMontoSeleccionado
            // 
            lblMontoSeleccionado.AutoSize = true;
            lblMontoSeleccionado.Location = new Point(190, 61);
            lblMontoSeleccionado.Name = "lblMontoSeleccionado";
            lblMontoSeleccionado.Size = new Size(43, 15);
            lblMontoSeleccionado.TabIndex = 4;
            lblMontoSeleccionado.Text = "Monto";
            // 
            // txtNombreMedioPagoSeleccionado
            // 
            txtNombreMedioPagoSeleccionado.BackColor = SystemColors.Control;
            txtNombreMedioPagoSeleccionado.ForeColor = SystemColors.ControlDark;
            txtNombreMedioPagoSeleccionado.Location = new Point(83, 58);
            txtNombreMedioPagoSeleccionado.Name = "txtNombreMedioPagoSeleccionado";
            txtNombreMedioPagoSeleccionado.ReadOnly = true;
            txtNombreMedioPagoSeleccionado.Size = new Size(100, 23);
            txtNombreMedioPagoSeleccionado.TabIndex = 3;
            // 
            // lblNombreMedioPagoSeleccionado
            // 
            lblNombreMedioPagoSeleccionado.AutoSize = true;
            lblNombreMedioPagoSeleccionado.Location = new Point(18, 61);
            lblNombreMedioPagoSeleccionado.Name = "lblNombreMedioPagoSeleccionado";
            lblNombreMedioPagoSeleccionado.Size = new Size(51, 15);
            lblNombreMedioPagoSeleccionado.TabIndex = 2;
            lblNombreMedioPagoSeleccionado.Text = "Nombre";
            // 
            // txtIdMedioPagoSeleccionado
            // 
            txtIdMedioPagoSeleccionado.BackColor = SystemColors.Control;
            txtIdMedioPagoSeleccionado.ForeColor = SystemColors.ControlDark;
            txtIdMedioPagoSeleccionado.Location = new Point(83, 27);
            txtIdMedioPagoSeleccionado.Name = "txtIdMedioPagoSeleccionado";
            txtIdMedioPagoSeleccionado.ReadOnly = true;
            txtIdMedioPagoSeleccionado.Size = new Size(70, 23);
            txtIdMedioPagoSeleccionado.TabIndex = 1;
            // 
            // lblIdMedioPagoSeleccionado
            // 
            lblIdMedioPagoSeleccionado.AutoSize = true;
            lblIdMedioPagoSeleccionado.Location = new Point(18, 30);
            lblIdMedioPagoSeleccionado.Name = "lblIdMedioPagoSeleccionado";
            lblIdMedioPagoSeleccionado.Size = new Size(17, 15);
            lblIdMedioPagoSeleccionado.TabIndex = 0;
            lblIdMedioPagoSeleccionado.Text = "Id";
            // 
            // pnlAccionesFinales
            // 
            pnlAccionesFinales.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pnlAccionesFinales.Controls.Add(btnCancelar);
            pnlAccionesFinales.Controls.Add(btnConfirmarPago);
            pnlAccionesFinales.Location = new Point(500, 588);
            pnlAccionesFinales.Name = "pnlAccionesFinales";
            pnlAccionesFinales.Size = new Size(360, 45);
            pnlAccionesFinales.TabIndex = 6;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(212, 10);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(118, 27);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnConfirmarPago
            // 
            btnConfirmarPago.Location = new Point(75, 10);
            btnConfirmarPago.Name = "btnConfirmarPago";
            btnConfirmarPago.Size = new Size(118, 27);
            btnConfirmarPago.TabIndex = 0;
            btnConfirmarPago.Text = "Confirmar pago";
            btnConfirmarPago.UseVisualStyleBackColor = true;
            btnConfirmarPago.Click += btnConfirmarPago_Click;
            // 
            // FormSeleccionarMetodoPago
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 681);
            Controls.Add(pnlAccionesFinales);
            Controls.Add(grpPagoSeleccionado);
            Controls.Add(grpAgregarPago);
            Controls.Add(grpResumenPago);
            Controls.Add(grpBusqueda);
            Controls.Add(dgvPagosVenta);
            Controls.Add(dgvMediosPago);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(900, 720);
            Name = "FormSeleccionarMetodoPago";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Seleccionar metodo de pago";
            ((System.ComponentModel.ISupportInitialize)dgvMediosPago).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPagosVenta).EndInit();
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            grpResumenPago.ResumeLayout(false);
            grpResumenPago.PerformLayout();
            grpAgregarPago.ResumeLayout(false);
            grpAgregarPago.PerformLayout();
            grpPagoSeleccionado.ResumeLayout(false);
            grpPagoSeleccionado.PerformLayout();
            pnlAccionesPago.ResumeLayout(false);
            pnlAccionesFinales.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvMediosPago;
        private DataGridViewTextBoxColumn colIdMedioPago;
        private DataGridViewTextBoxColumn colMedioPago;
        private DataGridViewCheckBoxColumn colEstadoMedioPago;
        private DataGridView dgvPagosVenta;
        private DataGridViewTextBoxColumn colPagoIdMedioPago;
        private DataGridViewTextBoxColumn colPagoMedioPago;
        private DataGridViewTextBoxColumn colPagoMonto;
        private GroupBox grpBusqueda;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
        private TextBox txtBuscarNombre;
        private Label lblBuscarNombre;
        private GroupBox grpResumenPago;
        private TextBox txtSaldoPendiente;
        private Label lblSaldoPendiente;
        private TextBox txtTotalAsignado;
        private Label lblTotalAsignado;
        private TextBox txtTotalPagar;
        private Label lblTotalPagar;
        private GroupBox grpAgregarPago;
        private CheckBox chkAgregarRestante;
        private Button btnLimpiarPago;
        private Button btnAgregarPago;
        private TextBox txtMonto;
        private Label lblMonto;
        private TextBox txtNombreMedioPago;
        private Label lblNombreMedioPago;
        private TextBox txtIdMedioPago;
        private Label lblIdMedioPago;
        private GroupBox grpPagoSeleccionado;
        private Panel pnlAccionesPago;
        private Button btnLimpiarSeleccion;
        private Button btnEliminarPago;
        private Button btnModificarMonto;
        private TextBox txtMontoSeleccionado;
        private Label lblMontoSeleccionado;
        private TextBox txtNombreMedioPagoSeleccionado;
        private Label lblNombreMedioPagoSeleccionado;
        private TextBox txtIdMedioPagoSeleccionado;
        private Label lblIdMedioPagoSeleccionado;
        private Panel pnlAccionesFinales;
        private Button btnCancelar;
        private Button btnConfirmarPago;
    }
}


