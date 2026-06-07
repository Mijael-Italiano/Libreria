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
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colMail = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewCheckBoxColumn();
            colBloqueado = new DataGridViewCheckBoxColumn();
            grpDatosUsuario = new GroupBox();
            txtContrasenaEncriptada = new TextBox();
            lblContrasenaEncriptada = new Label();
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
            txtPiso = new TextBox();
            lblPiso = new Label();
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
            pnlAcciones = new Panel();
            btnLimpiar = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnAgregar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            grpDatosUsuario.SuspendLayout();
            grpRolesPermisos.SuspendLayout();
            pnlAcciones.SuspendLayout();
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
            dgvUsuarios.Columns.AddRange(new DataGridViewColumn[] { colId, colDocumento, colNombreUsuario, colNombre, colApellido, colMail, colTelefono, colEstado, colBloqueado });
            dgvUsuarios.Location = new Point(20, 64);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersVisible = false;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(890, 356);
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
            grpDatosUsuario.Controls.Add(txtPiso);
            grpDatosUsuario.Controls.Add(lblPiso);
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
            grpDatosUsuario.Location = new Point(20, 436);
            grpDatosUsuario.Name = "grpDatosUsuario";
            grpDatosUsuario.Size = new Size(1180, 218);
            grpDatosUsuario.TabIndex = 2;
            grpDatosUsuario.TabStop = false;
            grpDatosUsuario.Text = "Datos del usuario";
            // 
            // txtContrasenaEncriptada
            // 
            txtContrasenaEncriptada.Location = new Point(390, 112);
            txtContrasenaEncriptada.Name = "txtContrasenaEncriptada";
            txtContrasenaEncriptada.ReadOnly = true;
            txtContrasenaEncriptada.Size = new Size(160, 23);
            txtContrasenaEncriptada.TabIndex = 19;
            // 
            // lblContrasenaEncriptada
            // 
            lblContrasenaEncriptada.AutoSize = true;
            lblContrasenaEncriptada.Location = new Point(310, 107);
            lblContrasenaEncriptada.Name = "lblContrasenaEncriptada";
            lblContrasenaEncriptada.Size = new Size(63, 30);
            lblContrasenaEncriptada.TabIndex = 18;
            lblContrasenaEncriptada.Text = "Clave\r\nencriptada";
            // 
            // txtIntentosFallidos
            // 
            txtIntentosFallidos.Location = new Point(982, 101);
            txtIntentosFallidos.Name = "txtIntentosFallidos";
            txtIntentosFallidos.ReadOnly = true;
            txtIntentosFallidos.Size = new Size(160, 23);
            txtIntentosFallidos.TabIndex = 17;
            // 
            // lblIntentosFallidos
            // 
            lblIntentosFallidos.AutoSize = true;
            lblIntentosFallidos.Location = new Point(858, 104);
            lblIntentosFallidos.Name = "lblIntentosFallidos";
            lblIntentosFallidos.Size = new Size(91, 15);
            lblIntentosFallidos.TabIndex = 16;
            lblIntentosFallidos.Text = "Intentos fallidos";
            // 
            // txtFechaAlta
            // 
            txtFechaAlta.Location = new Point(982, 66);
            txtFechaAlta.Name = "txtFechaAlta";
            txtFechaAlta.ReadOnly = true;
            txtFechaAlta.Size = new Size(160, 23);
            txtFechaAlta.TabIndex = 15;
            // 
            // lblFechaAlta
            // 
            lblFechaAlta.AutoSize = true;
            lblFechaAlta.Location = new Point(858, 69);
            lblFechaAlta.Name = "lblFechaAlta";
            lblFechaAlta.Size = new Size(76, 15);
            lblFechaAlta.TabIndex = 14;
            lblFechaAlta.Text = "Fecha de alta";
            // 
            // chkBloqueado
            // 
            chkBloqueado.AutoSize = true;
            chkBloqueado.Location = new Point(751, 104);
            chkBloqueado.Name = "chkBloqueado";
            chkBloqueado.Size = new Size(83, 19);
            chkBloqueado.TabIndex = 13;
            chkBloqueado.Text = "Bloqueado";
            chkBloqueado.UseVisualStyleBackColor = true;
            // 
            // chkEstado
            // 
            chkEstado.AutoSize = true;
            chkEstado.Checked = true;
            chkEstado.CheckState = CheckState.Checked;
            chkEstado.Location = new Point(666, 104);
            chkEstado.Name = "chkEstado";
            chkEstado.Size = new Size(60, 19);
            chkEstado.TabIndex = 12;
            chkEstado.Text = "Activo";
            chkEstado.UseVisualStyleBackColor = true;
            // 
            // txtMail
            // 
            txtMail.Location = new Point(666, 66);
            txtMail.Name = "txtMail";
            txtMail.Size = new Size(160, 23);
            txtMail.TabIndex = 11;
            // 
            // lblMail
            // 
            lblMail.AutoSize = true;
            lblMail.Location = new Point(588, 69);
            lblMail.Name = "lblMail";
            lblMail.Size = new Size(30, 15);
            lblMail.TabIndex = 10;
            lblMail.Text = "Mail";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(666, 31);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(160, 23);
            txtTelefono.TabIndex = 29;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(588, 34);
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
            txtDireccion.Location = new Point(666, 142);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(283, 23);
            txtDireccion.TabIndex = 33;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(588, 142);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(57, 15);
            lblDireccion.TabIndex = 32;
            lblDireccion.Text = "Direccion";
            // 
            // txtPiso
            // 
            txtPiso.Location = new Point(666, 179);
            txtPiso.Name = "txtPiso";
            txtPiso.Size = new Size(160, 23);
            txtPiso.TabIndex = 35;
            // 
            // lblPiso
            // 
            lblPiso.AutoSize = true;
            lblPiso.Location = new Point(589, 179);
            lblPiso.Name = "lblPiso";
            lblPiso.Size = new Size(29, 15);
            lblPiso.TabIndex = 34;
            lblPiso.Text = "Piso";
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
            txtContrasena.Location = new Point(390, 69);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(160, 23);
            txtContrasena.TabIndex = 5;
            // 
            // lblContrasena
            // 
            lblContrasena.AutoSize = true;
            lblContrasena.Location = new Point(306, 69);
            lblContrasena.Name = "lblContrasena";
            lblContrasena.Size = new Size(67, 15);
            lblContrasena.TabIndex = 4;
            lblContrasena.Text = "Contrasena";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(390, 27);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.Size = new Size(160, 23);
            txtNombreUsuario.TabIndex = 3;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(306, 30);
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
            grpRolesPermisos.Location = new Point(926, 64);
            grpRolesPermisos.Name = "grpRolesPermisos";
            grpRolesPermisos.Size = new Size(274, 356);
            grpRolesPermisos.TabIndex = 4;
            grpRolesPermisos.TabStop = false;
            grpRolesPermisos.Text = "Roles y permisos";
            // 
            // tvRolesPermisos
            // 
            tvRolesPermisos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tvRolesPermisos.Location = new Point(14, 25);
            tvRolesPermisos.Name = "tvRolesPermisos";
            tvRolesPermisos.Size = new Size(244, 315);
            tvRolesPermisos.TabIndex = 0;
            // 
            // pnlAcciones
            // 
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Controls.Add(btnLimpiar);
            pnlAcciones.Controls.Add(btnEliminar);
            pnlAcciones.Controls.Add(btnModificar);
            pnlAcciones.Controls.Add(btnAgregar);
            pnlAcciones.Location = new Point(20, 662);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Size = new Size(1180, 48);
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
            // FormUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1224, 731);
            Controls.Add(grpRolesPermisos);
            Controls.Add(pnlAcciones);
            Controls.Add(grpDatosUsuario);
            Controls.Add(dgvUsuarios);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1240, 736);
            Name = "FormUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Usuarios";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            grpDatosUsuario.ResumeLayout(false);
            grpDatosUsuario.PerformLayout();
            grpRolesPermisos.ResumeLayout(false);
            pnlAcciones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvUsuarios;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colDocumento;
        private DataGridViewTextBoxColumn colNombreUsuario;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colMail;
        private DataGridViewTextBoxColumn colTelefono;
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
        private TextBox txtPiso;
        private Label lblPiso;
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
    }
}
