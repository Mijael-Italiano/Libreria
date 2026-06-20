namespace Libreria.UI
{
    partial class FormClientes
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
            dgvClientes = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDocumento = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colMail = new DataGridViewTextBoxColumn();
            colDireccion = new DataGridViewTextBoxColumn();
            colDepartamento = new DataGridViewTextBoxColumn();
            colFechaNacimiento = new DataGridViewTextBoxColumn();
            colEdad = new DataGridViewTextBoxColumn();
            colFechaAlta = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewCheckBoxColumn();
            grpDatosCliente = new GroupBox();
            txtEdad = new TextBox();
            lblEdad = new Label();
            pnlAcciones = new Panel();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            txtFechaAlta = new TextBox();
            lblFechaAlta = new Label();
            chkEstado = new CheckBox();
            dtpFechaNacimiento = new DateTimePicker();
            lblFechaNacimiento = new Label();
            txtDepartamento = new TextBox();
            lblDepartamento = new Label();
            txtDireccion = new TextBox();
            lblDireccion = new Label();
            txtMail = new TextBox();
            lblMail = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtDocumento = new TextBox();
            lblDocumento = new Label();
            txtId = new TextBox();
            lblId = new Label();
            grpAltaCliente = new GroupBox();
            btnAgregarCliente = new Button();
            dtpAltaFechaNacimiento = new DateTimePicker();
            lblAltaFechaNacimiento = new Label();
            txtAltaDepartamento = new TextBox();
            lblAltaDepartamento = new Label();
            txtAltaDireccion = new TextBox();
            lblAltaDireccion = new Label();
            txtAltaMail = new TextBox();
            lblAltaMail = new Label();
            txtAltaTelefono = new TextBox();
            lblAltaTelefono = new Label();
            txtAltaApellido = new TextBox();
            lblAltaApellido = new Label();
            txtAltaNombre = new TextBox();
            lblAltaNombre = new Label();
            txtAltaDocumento = new TextBox();
            lblAltaDocumento = new Label();
            grpBusqueda = new GroupBox();
            txtBuscarDocumento = new TextBox();
            lblBuscarDocumento = new Label();
            txtBuscarApellido = new TextBox();
            lblBuscarApellido = new Label();
            txtBuscarNombre = new TextBox();
            lblBuscarNombre = new Label();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            grpClientesNoActivos = new GroupBox();
            chkVerClientesNoActivos = new CheckBox();
            btnReactivarCliente = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            grpDatosCliente.SuspendLayout();
            pnlAcciones.SuspendLayout();
            grpAltaCliente.SuspendLayout();
            grpBusqueda.SuspendLayout();
            grpClientesNoActivos.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(177, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ABM de clientes";
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = SystemColors.Window;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { colId, colDocumento, colNombre, colApellido, colTelefono, colMail, colDireccion, colDepartamento, colFechaNacimiento, colEdad, colFechaAlta, colEstado });
            dgvClientes.Location = new Point(20, 85);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(1280, 283);
            dgvClientes.TabIndex = 1;
            // 
            // colId
            // 
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colDocumento
            // 
            colDocumento.HeaderText = "DNI";
            colDocumento.Name = "colDocumento";
            colDocumento.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colApellido
            // 
            colApellido.HeaderText = "Apellido";
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            // 
            // colTelefono
            // 
            colTelefono.HeaderText = "Telefono";
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            // 
            // colMail
            // 
            colMail.HeaderText = "Mail";
            colMail.Name = "colMail";
            colMail.ReadOnly = true;
            // 
            // colDireccion
            // 
            colDireccion.HeaderText = "Direccion";
            colDireccion.Name = "colDireccion";
            colDireccion.ReadOnly = true;
            // 
            // colDepartamento
            // 
            colDepartamento.HeaderText = "Departamento";
            colDepartamento.Name = "colDepartamento";
            colDepartamento.ReadOnly = true;
            // 
            // colFechaNacimiento
            // 
            colFechaNacimiento.HeaderText = "Nacimiento";
            colFechaNacimiento.Name = "colFechaNacimiento";
            colFechaNacimiento.ReadOnly = true;
            // 
            // colEdad
            // 
            colEdad.HeaderText = "Edad";
            colEdad.Name = "colEdad";
            colEdad.ReadOnly = true;
            // 
            // colFechaAlta
            // 
            colFechaAlta.HeaderText = "Fecha alta";
            colFechaAlta.Name = "colFechaAlta";
            colFechaAlta.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.HeaderText = "Activo";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // grpDatosCliente
            // 
            grpDatosCliente.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDatosCliente.Controls.Add(txtEdad);
            grpDatosCliente.Controls.Add(lblEdad);
            grpDatosCliente.Controls.Add(pnlAcciones);
            grpDatosCliente.Controls.Add(txtFechaAlta);
            grpDatosCliente.Controls.Add(lblFechaAlta);
            grpDatosCliente.Controls.Add(chkEstado);
            grpDatosCliente.Controls.Add(dtpFechaNacimiento);
            grpDatosCliente.Controls.Add(lblFechaNacimiento);
            grpDatosCliente.Controls.Add(txtDepartamento);
            grpDatosCliente.Controls.Add(lblDepartamento);
            grpDatosCliente.Controls.Add(txtDireccion);
            grpDatosCliente.Controls.Add(lblDireccion);
            grpDatosCliente.Controls.Add(txtMail);
            grpDatosCliente.Controls.Add(lblMail);
            grpDatosCliente.Controls.Add(txtTelefono);
            grpDatosCliente.Controls.Add(lblTelefono);
            grpDatosCliente.Controls.Add(txtApellido);
            grpDatosCliente.Controls.Add(lblApellido);
            grpDatosCliente.Controls.Add(txtNombre);
            grpDatosCliente.Controls.Add(lblNombre);
            grpDatosCliente.Controls.Add(txtDocumento);
            grpDatosCliente.Controls.Add(lblDocumento);
            grpDatosCliente.Controls.Add(txtId);
            grpDatosCliente.Controls.Add(lblId);
            grpDatosCliente.Location = new Point(676, 374);
            grpDatosCliente.Name = "grpDatosCliente";
            grpDatosCliente.Size = new Size(624, 277);
            grpDatosCliente.TabIndex = 2;
            grpDatosCliente.TabStop = false;
            grpDatosCliente.Text = "Datos del cliente seleccionado";
            // 
            // txtEdad
            // 
            txtEdad.BackColor = SystemColors.Control;
            txtEdad.ForeColor = SystemColors.ControlDark;
            txtEdad.Location = new Point(430, 154);
            txtEdad.Name = "txtEdad";
            txtEdad.ReadOnly = true;
            txtEdad.Size = new Size(160, 23);
            txtEdad.TabIndex = 23;
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Location = new Point(326, 157);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(33, 15);
            lblEdad.TabIndex = 22;
            lblEdad.Text = "Edad";
            // 
            // pnlAcciones
            // 
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Controls.Add(btnLimpiar);
            pnlAcciones.Controls.Add(btnEliminar);
            pnlAcciones.Controls.Add(btnModificar);
            pnlAcciones.Location = new Point(6, 223);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Size = new Size(572, 48);
            pnlAcciones.TabIndex = 21;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(284, 10);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(118, 27);
            btnLimpiar.TabIndex = 2;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(154, 10);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(118, 27);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(24, 10);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(118, 27);
            btnModificar.TabIndex = 0;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // txtFechaAlta
            // 
            txtFechaAlta.BackColor = SystemColors.Control;
            txtFechaAlta.ForeColor = SystemColors.ControlDark;
            txtFechaAlta.Location = new Point(430, 183);
            txtFechaAlta.Name = "txtFechaAlta";
            txtFechaAlta.ReadOnly = true;
            txtFechaAlta.Size = new Size(160, 23);
            txtFechaAlta.TabIndex = 20;
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Location = new Point(326, 186);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(76, 15);
            lblFechaAlta.TabIndex = 19;
            lblFechaAlta.Text = "Fecha de alta";
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.BackColor = SystemColors.Control;
            chkEstado.Checked = true;
            chkEstado.CheckState = CheckState.Checked;
            chkEstado.Enabled = false;
            chkEstado.ForeColor = SystemColors.ControlDark;
            chkEstado.Location = new Point(102, 187);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(60, 19);
            chkEstado.TabIndex = 18;
            chkEstado.Text = "Activo";
            chkEstado.UseVisualStyleBackColor = false;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Checked = false;
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(430, 125);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.ShowCheckBox = true;
            dtpFechaNacimiento.Size = new Size(160, 23);
            dtpFechaNacimiento.TabIndex = 17;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(326, 128);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(69, 15);
            lblFechaNacimiento.TabIndex = 16;
            lblFechaNacimiento.Text = "Nacimiento";
            // 
            // txtDepartamento
            // 
            txtDepartamento.Location = new Point(430, 96);
            txtDepartamento.Name = "txtDepartamento";
            txtDepartamento.Size = new Size(160, 23);
            txtDepartamento.TabIndex = 15;
            // 
            // lblDepartamento
            // 
            lblDepartamento.AutoSize = true;
            lblDepartamento.Location = new Point(326, 99);
            lblDepartamento.Name = "lblDepartamento";
            lblDepartamento.Size = new Size(83, 15);
            lblDepartamento.TabIndex = 14;
            lblDepartamento.Text = "Departamento";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(430, 67);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(160, 23);
            txtDireccion.TabIndex = 13;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(326, 70);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 12;
            lblDireccion.Text = "Direccion";
            // 
            // txtMail
            // 
            txtMail.Location = new Point(430, 38);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(160, 23);
            txtMail.TabIndex = 11;
            // 
            // lblMail
            // 
            lblMail.AutoSize = true;
            lblMail.Location = new Point(326, 41);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(30, 15);
            lblMail.TabIndex = 10;
            lblMail.Text = "Mail";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(102, 154);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(160, 23);
            txtTelefono.TabIndex = 9;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(18, 157);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 8;
            lblTelefono.Text = "Telefono";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(102, 125);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(160, 23);
            txtApellido.TabIndex = 7;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(18, 128);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 6;
            lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(102, 96);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(160, 23);
            txtNombre.TabIndex = 5;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(18, 99);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 4;
            lblNombre.Text = "Nombre";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(102, 67);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(160, 23);
            txtDocumento.TabIndex = 3;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(18, 70);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(27, 15);
            lblDocumento.TabIndex = 2;
            lblDocumento.Text = "DNI";
            // 
            // txtId
            // 
            txtId.BackColor = SystemColors.Control;
            txtId.ForeColor = SystemColors.ControlDark;
            txtId.Location = new Point(102, 38);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(160, 23);
            txtId.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(18, 41);
            lblId.Name = "lblId";
            lblId.Size = new Size(18, 15);
            lblId.TabIndex = 0;
            lblId.Text = "ID";
            // 
            // grpAltaCliente
            // 
            grpAltaCliente.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpAltaCliente.Controls.Add(btnAgregarCliente);
            grpAltaCliente.Controls.Add(dtpAltaFechaNacimiento);
            grpAltaCliente.Controls.Add(lblAltaFechaNacimiento);
            grpAltaCliente.Controls.Add(txtAltaDepartamento);
            grpAltaCliente.Controls.Add(lblAltaDepartamento);
            grpAltaCliente.Controls.Add(txtAltaDireccion);
            grpAltaCliente.Controls.Add(lblAltaDireccion);
            grpAltaCliente.Controls.Add(txtAltaMail);
            grpAltaCliente.Controls.Add(lblAltaMail);
            grpAltaCliente.Controls.Add(txtAltaTelefono);
            grpAltaCliente.Controls.Add(lblAltaTelefono);
            grpAltaCliente.Controls.Add(txtAltaApellido);
            grpAltaCliente.Controls.Add(lblAltaApellido);
            grpAltaCliente.Controls.Add(txtAltaNombre);
            grpAltaCliente.Controls.Add(lblAltaNombre);
            grpAltaCliente.Controls.Add(txtAltaDocumento);
            grpAltaCliente.Controls.Add(lblAltaDocumento);
            grpAltaCliente.Location = new Point(20, 474);
            grpAltaCliente.Name = "grpAltaCliente";
            grpAltaCliente.Size = new Size(624, 177);
            grpAltaCliente.TabIndex = 4;
            grpAltaCliente.TabStop = false;
            grpAltaCliente.Text = "Datos de alta cliente";
            // 
            // btnAgregarCliente
            // 
            btnAgregarCliente.Location = new Point(454, 139);
            btnAgregarCliente.Name = "btnAgregarCliente";
            btnAgregarCliente.Size = new Size(136, 27);
            btnAgregarCliente.TabIndex = 16;
            btnAgregarCliente.Text = "Agregar cliente";
            btnAgregarCliente.UseVisualStyleBackColor = true;
            // 
            // dtpAltaFechaNacimiento
            // 
            dtpAltaFechaNacimiento.Checked = false;
            dtpAltaFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpAltaFechaNacimiento.Location = new Point(430, 109);
            dtpAltaFechaNacimiento.Name = "dtpAltaFechaNacimiento";
            dtpAltaFechaNacimiento.ShowCheckBox = true;
            dtpAltaFechaNacimiento.Size = new Size(160, 23);
            dtpAltaFechaNacimiento.TabIndex = 15;
            // 
            // lblAltaFechaNacimiento
            // 
            lblAltaFechaNacimiento.AutoSize = true;
            lblAltaFechaNacimiento.Location = new Point(326, 112);
            lblAltaFechaNacimiento.Name = "lblAltaFechaNacimiento";
            lblAltaFechaNacimiento.Size = new Size(69, 15);
            lblAltaFechaNacimiento.TabIndex = 14;
            lblAltaFechaNacimiento.Text = "Nacimiento";
            // 
            // txtAltaDepartamento
            // 
            txtAltaDepartamento.Location = new Point(430, 80);
            txtAltaDepartamento.Name = "txtAltaDepartamento";
            txtAltaDepartamento.Size = new Size(160, 23);
            txtAltaDepartamento.TabIndex = 13;
            // 
            // lblAltaDepartamento
            // 
            lblAltaDepartamento.AutoSize = true;
            lblAltaDepartamento.Location = new Point(326, 83);
            lblAltaDepartamento.Name = "lblAltaDepartamento";
            lblAltaDepartamento.Size = new Size(83, 15);
            lblAltaDepartamento.TabIndex = 12;
            lblAltaDepartamento.Text = "Departamento";
            // 
            // txtAltaDireccion
            // 
            txtAltaDireccion.Location = new Point(430, 51);
            txtAltaDireccion.Name = "txtAltaDireccion";
            txtAltaDireccion.Size = new Size(160, 23);
            txtAltaDireccion.TabIndex = 11;
            // 
            // lblAltaDireccion
            // 
            lblAltaDireccion.AutoSize = true;
            lblAltaDireccion.Location = new Point(326, 54);
            lblAltaDireccion.Name = "lblAltaDireccion";
            lblAltaDireccion.Size = new Size(57, 15);
            lblAltaDireccion.TabIndex = 10;
            lblAltaDireccion.Text = "Direccion";
            // 
            // txtAltaMail
            // 
            txtAltaMail.Location = new Point(430, 22);
            txtAltaMail.Name = "txtAltaMail";
            txtAltaMail.Size = new Size(160, 23);
            txtAltaMail.TabIndex = 9;
            // 
            // lblAltaMail
            // 
            lblAltaMail.AutoSize = true;
            lblAltaMail.Location = new Point(326, 25);
            lblAltaMail.Name = "lblAltaMail";
            lblAltaMail.Size = new Size(30, 15);
            lblAltaMail.TabIndex = 8;
            lblAltaMail.Text = "Mail";
            // 
            // txtAltaTelefono
            // 
            txtAltaTelefono.Location = new Point(102, 109);
            txtAltaTelefono.Name = "txtAltaTelefono";
            txtAltaTelefono.Size = new Size(160, 23);
            txtAltaTelefono.TabIndex = 7;
            // 
            // lblAltaTelefono
            // 
            lblAltaTelefono.AutoSize = true;
            lblAltaTelefono.Location = new Point(18, 112);
            lblAltaTelefono.Name = "lblAltaTelefono";
            lblAltaTelefono.Size = new Size(52, 15);
            lblAltaTelefono.TabIndex = 6;
            lblAltaTelefono.Text = "Telefono";
            // 
            // txtAltaApellido
            // 
            txtAltaApellido.Location = new Point(102, 80);
            txtAltaApellido.Name = "txtAltaApellido";
            txtAltaApellido.Size = new Size(160, 23);
            txtAltaApellido.TabIndex = 5;
            // 
            // lblAltaApellido
            // 
            lblAltaApellido.AutoSize = true;
            lblAltaApellido.Location = new Point(18, 83);
            lblAltaApellido.Name = "lblAltaApellido";
            lblAltaApellido.Size = new Size(51, 15);
            lblAltaApellido.TabIndex = 4;
            lblAltaApellido.Text = "Apellido";
            // 
            // txtAltaNombre
            // 
            txtAltaNombre.Location = new Point(102, 51);
            txtAltaNombre.Name = "txtAltaNombre";
            txtAltaNombre.Size = new Size(160, 23);
            txtAltaNombre.TabIndex = 3;
            // 
            // lblAltaNombre
            // 
            lblAltaNombre.AutoSize = true;
            lblAltaNombre.Location = new Point(18, 54);
            lblAltaNombre.Name = "lblAltaNombre";
            lblAltaNombre.Size = new Size(51, 15);
            lblAltaNombre.TabIndex = 2;
            lblAltaNombre.Text = "Nombre";
            // 
            // txtAltaDocumento
            // 
            txtAltaDocumento.Location = new Point(102, 22);
            txtAltaDocumento.Name = "txtAltaDocumento";
            txtAltaDocumento.Size = new Size(160, 23);
            txtAltaDocumento.TabIndex = 1;
            // 
            // lblAltaDocumento
            // 
            lblAltaDocumento.AutoSize = true;
            lblAltaDocumento.Location = new Point(18, 25);
            lblAltaDocumento.Name = "lblAltaDocumento";
            lblAltaDocumento.Size = new Size(27, 15);
            lblAltaDocumento.TabIndex = 0;
            lblAltaDocumento.Text = "DNI";
            // 
            // grpBusqueda
            // 
            grpBusqueda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpBusqueda.Controls.Add(txtBuscarDocumento);
            grpBusqueda.Controls.Add(lblBuscarDocumento);
            grpBusqueda.Controls.Add(txtBuscarApellido);
            grpBusqueda.Controls.Add(lblBuscarApellido);
            grpBusqueda.Controls.Add(txtBuscarNombre);
            grpBusqueda.Controls.Add(lblBuscarNombre);
            grpBusqueda.Controls.Add(btnLimpiarBusqueda);
            grpBusqueda.Controls.Add(btnBuscar);
            grpBusqueda.Location = new Point(20, 374);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Size = new Size(624, 94);
            grpBusqueda.TabIndex = 3;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Buscar cliente";
            // 
            // txtBuscarDocumento
            // 
            txtBuscarDocumento.Location = new Point(102, 62);
            txtBuscarDocumento.Name = "txtBuscarDocumento";
            txtBuscarDocumento.Size = new Size(160, 23);
            txtBuscarDocumento.TabIndex = 5;
            // 
            // lblBuscarDocumento
            // 
            lblBuscarDocumento.AutoSize = true;
            lblBuscarDocumento.Location = new Point(18, 65);
            lblBuscarDocumento.Name = "lblBuscarDocumento";
            lblBuscarDocumento.Size = new Size(27, 15);
            lblBuscarDocumento.TabIndex = 4;
            lblBuscarDocumento.Text = "DNI";
            // 
            // txtBuscarApellido
            // 
            txtBuscarApellido.Location = new Point(390, 27);
            txtBuscarApellido.Name = "txtBuscarApellido";
            txtBuscarApellido.Size = new Size(160, 23);
            txtBuscarApellido.TabIndex = 3;
            // 
            // lblBuscarApellido
            // 
            lblBuscarApellido.AutoSize = true;
            lblBuscarApellido.Location = new Point(306, 30);
            lblBuscarApellido.Name = "lblBuscarApellido";
            lblBuscarApellido.Size = new Size(51, 15);
            lblBuscarApellido.TabIndex = 2;
            lblBuscarApellido.Text = "Apellido";
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.Location = new Point(102, 27);
            txtBuscarNombre.Name = "txtBuscarNombre";
            txtBuscarNombre.Size = new Size(160, 23);
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
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Location = new Point(414, 60);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(118, 27);
            btnLimpiarBusqueda.TabIndex = 7;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(286, 60);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(118, 27);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // grpClientesNoActivos
            // 
            grpClientesNoActivos.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpClientesNoActivos.Controls.Add(chkVerClientesNoActivos);
            grpClientesNoActivos.Controls.Add(btnReactivarCliente);
            grpClientesNoActivos.Location = new Point(956, 12);
            grpClientesNoActivos.Name = "grpClientesNoActivos";
            grpClientesNoActivos.Size = new Size(344, 70);
            grpClientesNoActivos.TabIndex = 5;
            grpClientesNoActivos.TabStop = false;
            grpClientesNoActivos.Text = "Clientes no activos";
            // 
            // chkVerClientesNoActivos
            // 
            chkVerClientesNoActivos.AutoSize = true;
            chkVerClientesNoActivos.Location = new Point(18, 32);
            chkVerClientesNoActivos.Name = "chkVerClientesNoActivos";
            chkVerClientesNoActivos.Size = new Size(143, 19);
            chkVerClientesNoActivos.TabIndex = 0;
            chkVerClientesNoActivos.Text = "Ver clientes no activos";
            chkVerClientesNoActivos.UseVisualStyleBackColor = true;
            // 
            // btnReactivarCliente
            // 
            btnReactivarCliente.Location = new Point(194, 24);
            btnReactivarCliente.Name = "btnReactivarCliente";
            btnReactivarCliente.Size = new Size(130, 27);
            btnReactivarCliente.TabIndex = 1;
            btnReactivarCliente.Text = "Reactivar cliente";
            btnReactivarCliente.UseVisualStyleBackColor = true;
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1324, 679);
            Controls.Add(grpClientesNoActivos);
            Controls.Add(grpAltaCliente);
            Controls.Add(grpBusqueda);
            Controls.Add(grpDatosCliente);
            Controls.Add(dgvClientes);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1340, 718);
            Name = "FormClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            grpDatosCliente.ResumeLayout(false);
            grpDatosCliente.PerformLayout();
            pnlAcciones.ResumeLayout(false);
            grpAltaCliente.ResumeLayout(false);
            grpAltaCliente.PerformLayout();
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            grpClientesNoActivos.ResumeLayout(false);
            grpClientesNoActivos.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvClientes;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDocumento;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colMail;
        private DataGridViewTextBoxColumn colDireccion;
        private DataGridViewTextBoxColumn colDepartamento;
        private DataGridViewTextBoxColumn colFechaNacimiento;
        private DataGridViewTextBoxColumn colEdad;
        private DataGridViewTextBoxColumn colFechaAlta;
        private DataGridViewCheckBoxColumn colEstado;
        private GroupBox grpDatosCliente;
        private TextBox txtEdad;
        private Label lblEdad;
        private Panel pnlAcciones;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnModificar;
        private TextBox txtFechaAlta;
        private Label lblFechaAlta;
        private CheckBox chkEstado;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblFechaNacimiento;
        private TextBox txtDepartamento;
        private Label lblDepartamento;
        private TextBox txtDireccion;
        private Label lblDireccion;
        private TextBox txtMail;
        private Label lblMail;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtDocumento;
        private Label lblDocumento;
        private TextBox txtId;
        private Label lblId;
        private GroupBox grpAltaCliente;
        private Button btnAgregarCliente;
        private DateTimePicker dtpAltaFechaNacimiento;
        private Label lblAltaFechaNacimiento;
        private TextBox txtAltaDepartamento;
        private Label lblAltaDepartamento;
        private TextBox txtAltaDireccion;
        private Label lblAltaDireccion;
        private TextBox txtAltaMail;
        private Label lblAltaMail;
        private TextBox txtAltaTelefono;
        private Label lblAltaTelefono;
        private TextBox txtAltaApellido;
        private Label lblAltaApellido;
        private TextBox txtAltaNombre;
        private Label lblAltaNombre;
        private TextBox txtAltaDocumento;
        private Label lblAltaDocumento;
        private GroupBox grpBusqueda;
        private TextBox txtBuscarDocumento;
        private Label lblBuscarDocumento;
        private TextBox txtBuscarApellido;
        private Label lblBuscarApellido;
        private TextBox txtBuscarNombre;
        private Label lblBuscarNombre;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
        private GroupBox grpClientesNoActivos;
        private CheckBox chkVerClientesNoActivos;
        private Button btnReactivarCliente;
    }
}
