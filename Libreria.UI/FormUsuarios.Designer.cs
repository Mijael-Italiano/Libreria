namespace Libreria.UI
{
    partial class FormUsuarios
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
            dgvUsuarios = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colDocumento = new DataGridViewTextBoxColumn();
            colNombreUsuario = new DataGridViewTextBoxColumn();
            colContrasena = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colMail = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colFechaNacimiento = new DataGridViewTextBoxColumn();
            colDireccion = new DataGridViewTextBoxColumn();
            colDepartamento = new DataGridViewTextBoxColumn();
            colFechaAlta = new DataGridViewTextBoxColumn();
            colIntentosFallidos = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewCheckBoxColumn();
            colBloqueado = new DataGridViewCheckBoxColumn();
            grpDatosUsuario = new GroupBox();
            txtContrasenaEncriptada = new TextBox();
            lblContrasenaEncriptada = new Label();
            chkVerUsuariosNoActivos = new CheckBox();
            btnReactivarUsuario = new Button();
            grpUsuariosNoActivos = new GroupBox();
            pnlAcciones = new Panel();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            txtIntentosFallidos = new TextBox();
            lblIntentosFallidos = new Label();
            txtFechaAlta = new TextBox();
            lblFechaAlta = new Label();
            chkBloqueado = new CheckBox();
            chkEstado = new CheckBox();
            txtMail = new TextBox();
            lblMail = new Label();
            txtTelefono = new TextBox();
            lblTelefono = new Label();
            dtpFechaNacimiento = new DateTimePicker();
            lblFechaNacimiento = new Label();
            txtDireccion = new TextBox();
            lblDireccion = new Label();
            txtDepartamento = new TextBox();
            lblDepartamento = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtContrasena = new TextBox();
            lblContrasena = new Label();
            txtNombreUsuario = new TextBox();
            lblNombreUsuario = new Label();
            txtDocumento = new TextBox();
            lblDocumento = new Label();
            txtId = new TextBox();
            lblId = new Label();
            grpRolesPermisos = new GroupBox();
            tvRolesPermisos = new TreeView();
            grpBusqueda = new GroupBox();
            txtBuscarDocumento = new TextBox();
            lblBuscarDocumento = new Label();
            txtBuscarApellido = new TextBox();
            lblBuscarApellido = new Label();
            txtBuscarNombre = new TextBox();
            lblBuscarNombre = new Label();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            grpDatosUsuario.SuspendLayout();
            grpUsuariosNoActivos.SuspendLayout();
            pnlAcciones.SuspendLayout();
            grpRolesPermisos.SuspendLayout();
            grpBusqueda.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(187, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ABM de usuarios";
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsuarios.BackgroundColor = SystemColors.Window;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { colId, colDocumento, colNombreUsuario, colContrasena, colNombre, colApellido, colMail, colTelefono, colFechaNacimiento, colDireccion, colDepartamento, colFechaAlta, colIntentosFallidos, colEstado, colBloqueado });
            dgvUsuarios.Location = new Point(20, 64);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(1280, 282);
            dgvUsuarios.TabIndex = 1;
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
            // colNombreUsuario
            // 
            colNombreUsuario.HeaderText = "Usuario";
            colNombreUsuario.Name = "colNombreUsuario";
            colNombreUsuario.ReadOnly = true;
            // 
            // colContrasena
            // 
            colContrasena.HeaderText = "Clave";
            colContrasena.Name = "colContrasena";
            colContrasena.ReadOnly = true;
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
            // colMail
            // 
            colMail.HeaderText = "Mail";
            colMail.Name = "colMail";
            colMail.ReadOnly = true;
            // 
            // colTelefono
            // 
            colTelefono.HeaderText = "Telefono";
            colTelefono.Name = "colTelefono";
            colTelefono.ReadOnly = true;
            // 
            // colFechaNacimiento
            // 
            colFechaNacimiento.HeaderText = "Nacimiento";
            colFechaNacimiento.Name = "colFechaNacimiento";
            colFechaNacimiento.ReadOnly = true;
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
            // colFechaAlta
            // 
            colFechaAlta.HeaderText = "Fecha alta";
            colFechaAlta.Name = "colFechaAlta";
            colFechaAlta.ReadOnly = true;
            // 
            // colIntentosFallidos
            // 
            colIntentosFallidos.HeaderText = "Intentos";
            colIntentosFallidos.Name = "colIntentosFallidos";
            colIntentosFallidos.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.HeaderText = "Activo";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // colBloqueado
            // 
            colBloqueado.HeaderText = "Bloqueado";
            colBloqueado.Name = "colBloqueado";
            colBloqueado.ReadOnly = true;
            // 
            // grpDatosUsuario
            // 
            grpDatosUsuario.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDatosUsuario.Controls.Add(txtContrasenaEncriptada);
            grpDatosUsuario.Controls.Add(lblContrasenaEncriptada);
            grpDatosUsuario.Controls.Add(pnlAcciones);
            grpDatosUsuario.Controls.Add(txtIntentosFallidos);
            grpDatosUsuario.Controls.Add(lblIntentosFallidos);
            grpDatosUsuario.Controls.Add(txtFechaAlta);
            grpDatosUsuario.Controls.Add(lblFechaAlta);
            grpDatosUsuario.Controls.Add(chkBloqueado);
            grpDatosUsuario.Controls.Add(chkEstado);
            grpDatosUsuario.Controls.Add(txtMail);
            grpDatosUsuario.Controls.Add(lblMail);
            grpDatosUsuario.Controls.Add(txtTelefono);
            grpDatosUsuario.Controls.Add(lblTelefono);
            grpDatosUsuario.Controls.Add(dtpFechaNacimiento);
            grpDatosUsuario.Controls.Add(lblFechaNacimiento);
            grpDatosUsuario.Controls.Add(txtDireccion);
            grpDatosUsuario.Controls.Add(lblDireccion);
            grpDatosUsuario.Controls.Add(txtDepartamento);
            grpDatosUsuario.Controls.Add(lblDepartamento);
            grpDatosUsuario.Controls.Add(txtApellido);
            grpDatosUsuario.Controls.Add(lblApellido);
            grpDatosUsuario.Controls.Add(txtNombre);
            grpDatosUsuario.Controls.Add(lblNombre);
            grpDatosUsuario.Controls.Add(txtContrasena);
            grpDatosUsuario.Controls.Add(lblContrasena);
            grpDatosUsuario.Controls.Add(txtNombreUsuario);
            grpDatosUsuario.Controls.Add(lblNombreUsuario);
            grpDatosUsuario.Controls.Add(txtDocumento);
            grpDatosUsuario.Controls.Add(lblDocumento);
            grpDatosUsuario.Controls.Add(txtId);
            grpDatosUsuario.Controls.Add(lblId);
            grpDatosUsuario.Location = new Point(20, 452);
            grpDatosUsuario.Name = "grpDatosUsuario";
            grpDatosUsuario.Size = new Size(1000, 285);
            grpDatosUsuario.TabIndex = 2;
            grpDatosUsuario.TabStop = false;
            grpDatosUsuario.Text = "Datos del usuario";
            // 
            // txtContrasenaEncriptada
            // 
            txtContrasenaEncriptada.Location = new Point(430, 104);
            txtContrasenaEncriptada.Name = "txtContrasenaEncriptada";
            txtContrasenaEncriptada.ReadOnly = true;
            txtContrasenaEncriptada.Size = new Size(160, 23);
            txtContrasenaEncriptada.TabIndex = 19;
            // 
            // lblContrasenaEncriptada
            // 
            lblContrasenaEncriptada.AutoSize = true;
            lblContrasenaEncriptada.Location = new Point(326, 101);
            lblContrasenaEncriptada.Name = "lblContrasenaEncriptada";
            lblContrasenaEncriptada.Size = new Size(63, 30);
            lblContrasenaEncriptada.TabIndex = 18;
            lblContrasenaEncriptada.Text = "Clave\r\nencriptada";
            // 
            // chkVerUsuariosNoActivos
            // 
            chkVerUsuariosNoActivos.AutoSize = true;
            chkVerUsuariosNoActivos.Location = new Point(18, 32);
            chkVerUsuariosNoActivos.Name = "chkVerUsuariosNoActivos";
            chkVerUsuariosNoActivos.Size = new Size(146, 19);
            chkVerUsuariosNoActivos.TabIndex = 37;
            chkVerUsuariosNoActivos.Text = "Ver usuarios no activos";
            chkVerUsuariosNoActivos.UseVisualStyleBackColor = true;
            // 
            // btnReactivarUsuario
            // 
            btnReactivarUsuario.Location = new Point(194, 24);
            btnReactivarUsuario.Name = "btnReactivarUsuario";
            btnReactivarUsuario.Size = new Size(130, 27);
            btnReactivarUsuario.TabIndex = 36;
            btnReactivarUsuario.Text = "Reactivar usuario";
            btnReactivarUsuario.UseVisualStyleBackColor = true;
            // 
            // grpUsuariosNoActivos
            // 
            grpUsuariosNoActivos.Controls.Add(chkVerUsuariosNoActivos);
            grpUsuariosNoActivos.Controls.Add(btnReactivarUsuario);
            grpUsuariosNoActivos.Location = new Point(656, 363);
            grpUsuariosNoActivos.Name = "grpUsuariosNoActivos";
            grpUsuariosNoActivos.Size = new Size(344, 70);
            grpUsuariosNoActivos.TabIndex = 6;
            grpUsuariosNoActivos.TabStop = false;
            grpUsuariosNoActivos.Text = "Usuarios no activos";
            // 
            // pnlAcciones
            // 
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Controls.Add(btnLimpiar);
            pnlAcciones.Controls.Add(btnEliminar);
            pnlAcciones.Controls.Add(btnModificar);
            pnlAcciones.Controls.Add(btnAgregar);
            pnlAcciones.Location = new Point(6, 231);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Size = new Size(572, 48);
            pnlAcciones.TabIndex = 3;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(414, 10);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(118, 27);
            btnLimpiar.TabIndex = 3;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(284, 10);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(118, 27);
            btnEliminar.TabIndex = 2;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(154, 10);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(118, 27);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(24, 10);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(118, 27);
            btnAgregar.TabIndex = 0;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            // 
            // txtIntentosFallidos
            // 
            txtIntentosFallidos.Location = new Point(430, 179);
            txtIntentosFallidos.Name = "txtIntentosFallidos";
            txtIntentosFallidos.ReadOnly = true;
            txtIntentosFallidos.Size = new Size(160, 23);
            txtIntentosFallidos.TabIndex = 17;
            // 
            // lblIntentosFallidos
            // 
            lblIntentosFallidos.AutoSize = true;
            lblIntentosFallidos.Location = new Point(326, 179);
            lblIntentosFallidos.Name = "lblIntentosFallidos";
            lblIntentosFallidos.Size = new Size(91, 15);
            lblIntentosFallidos.TabIndex = 16;
            lblIntentosFallidos.Text = "Intentos fallidos";
            // 
            // txtFechaAlta
            // 
            txtFechaAlta.Location = new Point(430, 142);
            txtFechaAlta.Name = "txtFechaAlta";
            txtFechaAlta.ReadOnly = true;
            txtFechaAlta.Size = new Size(160, 23);
            txtFechaAlta.TabIndex = 15;
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Location = new Point(326, 142);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(76, 15);
            lblFechaAlta.TabIndex = 14;
            lblFechaAlta.Text = "Fecha de alta";
            // 
            // chkBloqueado
            // 
            chkBloqueado.AutoSize = true;
            chkBloqueado.Location = new Point(825, 104);
            chkBloqueado.Name = "chkBloqueado";
            chkBloqueado.Size = new Size(83, 19);
            chkBloqueado.TabIndex = 13;
            chkBloqueado.Text = "Bloqueado";
            chkBloqueado.UseVisualStyleBackColor = true;
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.BackColor = SystemColors.Control;
            chkEstado.Checked = true;
            chkEstado.CheckState = CheckState.Checked;
            chkEstado.Enabled = false;
            chkEstado.ForeColor = SystemColors.ControlDark;
            chkEstado.Location = new Point(740, 104);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(60, 19);
            chkEstado.TabIndex = 12;
            chkEstado.Text = "Activo";
            chkEstado.UseVisualStyleBackColor = false;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(740, 66);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(160, 23);
            txtMail.TabIndex = 11;
            // 
            // lblMail
            // 
            lblMail.AutoSize = true;
            lblMail.Location = new Point(650, 69);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(30, 15);
            lblMail.TabIndex = 10;
            lblMail.Text = "Mail";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(740, 31);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(160, 23);
            txtTelefono.TabIndex = 29;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(650, 34);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 28;
            lblTelefono.Text = "Telefono";
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Format = DateTimePickerFormat.Short;
            dtpFechaNacimiento.Location = new Point(102, 179);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(160, 23);
            dtpFechaNacimiento.TabIndex = 31;
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(18, 187);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(69, 15);
            lblFechaNacimiento.TabIndex = 30;
            lblFechaNacimiento.Text = "Nacimiento";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(740, 142);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(220, 23);
            txtDireccion.TabIndex = 33;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(650, 142);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 32;
            lblDireccion.Text = "Direccion";
            // 
            // txtDepartamento
            // 
            txtDepartamento.Location = new Point(740, 179);
            txtDepartamento.Name = "txtDepartamento";
            txtDepartamento.Size = new Size(160, 23);
            txtDepartamento.TabIndex = 35;
            // 
            // lblDepartamento
            // 
            lblDepartamento.AutoSize = true;
            lblDepartamento.Location = new Point(650, 179);
            lblDepartamento.Name = "lblDepartamento";
            lblDepartamento.Size = new Size(83, 15);
            lblDepartamento.TabIndex = 34;
            lblDepartamento.Text = "Departamento";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(102, 104);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(160, 23);
            txtApellido.TabIndex = 9;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(18, 106);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 8;
            lblApellido.Text = "Apellido";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(102, 66);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(160, 23);
            txtNombre.TabIndex = 7;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(18, 69);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 6;
            lblNombre.Text = "Nombre";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(430, 66);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(160, 23);
            txtContrasena.TabIndex = 5;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(326, 69);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(67, 15);
            lblContrasena.TabIndex = 4;
            lblContrasena.Text = "Contrasena";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(430, 31);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(160, 23);
            txtNombreUsuario.TabIndex = 3;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(326, 34);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(47, 15);
            lblNombreUsuario.TabIndex = 2;
            lblNombreUsuario.Text = "Usuario";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(102, 139);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(160, 23);
            txtDocumento.TabIndex = 1;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(18, 142);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(27, 15);
            lblDocumento.TabIndex = 0;
            lblDocumento.Text = "DNI";
            // 
            // txtId
            // 
            txtId.Location = new Point(102, 31);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(160, 23);
            txtId.TabIndex = 21;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(18, 34);
            lblId.Name = "lblId";
            lblId.Size = new Size(18, 15);
            lblId.TabIndex = 20;
            lblId.Text = "ID";
            // 
            // grpRolesPermisos
            // 
            grpRolesPermisos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            grpRolesPermisos.Controls.Add(tvRolesPermisos);
            grpRolesPermisos.Location = new Point(1048, 363);
            grpRolesPermisos.Name = "grpRolesPermisos";
            grpRolesPermisos.Size = new Size(264, 374);
            grpRolesPermisos.TabIndex = 4;
            grpRolesPermisos.TabStop = false;
            grpRolesPermisos.Text = "Roles y permisos";
            // 
            // tvRolesPermisos
            // 
            tvRolesPermisos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tvRolesPermisos.Location = new Point(15, 30);
            tvRolesPermisos.Name = "tvRolesPermisos";
            tvRolesPermisos.Size = new Size(234, 333);
            tvRolesPermisos.TabIndex = 0;
            // 
            // grpBusqueda
            // 
            grpBusqueda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpBusqueda.Controls.Add(txtBuscarDocumento);
            grpBusqueda.Controls.Add(lblBuscarDocumento);
            grpBusqueda.Controls.Add(txtBuscarApellido);
            grpBusqueda.Controls.Add(lblBuscarApellido);
            grpBusqueda.Controls.Add(txtBuscarNombre);
            grpBusqueda.Controls.Add(lblBuscarNombre);
            grpBusqueda.Controls.Add(btnLimpiarBusqueda);
            grpBusqueda.Controls.Add(btnBuscar);
            grpBusqueda.Location = new Point(20, 352);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Size = new Size(624, 94);
            grpBusqueda.TabIndex = 5;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Buscar usuario";
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
            // FormUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1324, 749);
            Controls.Add(grpBusqueda);
            Controls.Add(grpRolesPermisos);
            Controls.Add(grpUsuariosNoActivos);
            Controls.Add(grpDatosUsuario);
            Controls.Add(dgvUsuarios);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1340, 736);
            Name = "FormUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            grpDatosUsuario.ResumeLayout(false);
            grpDatosUsuario.PerformLayout();
            grpUsuariosNoActivos.ResumeLayout(false);
            grpUsuariosNoActivos.PerformLayout();
            pnlAcciones.ResumeLayout(false);
            grpRolesPermisos.ResumeLayout(false);
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvUsuarios;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDocumento;
        private DataGridViewTextBoxColumn colNombreUsuario;
        private DataGridViewTextBoxColumn colContrasena;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colMail;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colFechaNacimiento;
        private DataGridViewTextBoxColumn colDireccion;
        private DataGridViewTextBoxColumn colDepartamento;
        private DataGridViewTextBoxColumn colFechaAlta;
        private DataGridViewTextBoxColumn colIntentosFallidos;
        private DataGridViewCheckBoxColumn colEstado;
        private DataGridViewCheckBoxColumn colBloqueado;
        private GroupBox grpDatosUsuario;
        private CheckBox chkBloqueado;
        private CheckBox chkEstado;
        private TextBox txtContrasenaEncriptada;
        private Label lblContrasenaEncriptada;
        private TextBox txtIntentosFallidos;
        private Label lblIntentosFallidos;
        private TextBox txtFechaAlta;
        private Label lblFechaAlta;
        private TextBox txtMail;
        private Label lblMail;
        private TextBox txtTelefono;
        private Label lblTelefono;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblFechaNacimiento;
        private TextBox txtDireccion;
        private Label lblDireccion;
        private TextBox txtDepartamento;
        private Label lblDepartamento;
        private TextBox txtApellido;
        private Label lblApellido;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtContrasena;
        private Label lblContrasena;
        private TextBox txtNombreUsuario;
        private Label lblNombreUsuario;
        private TextBox txtDocumento;
        private Label lblDocumento;
        private TextBox txtId;
        private Label lblId;
        private GroupBox grpRolesPermisos;
        private TreeView tvRolesPermisos;
        private Panel pnlAcciones;
        private Button btnLimpiar;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnAgregar;
        private GroupBox grpBusqueda;
        private TextBox txtBuscarDocumento;
        private Label lblBuscarDocumento;
        private TextBox txtBuscarApellido;
        private Label lblBuscarApellido;
        private TextBox txtBuscarNombre;
        private Label lblBuscarNombre;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
        private CheckBox chkVerUsuariosNoActivos;
        private Button btnReactivarUsuario;
        private GroupBox grpUsuariosNoActivos;
    }
}
