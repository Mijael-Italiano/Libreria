namespace Libreria.UI
{
    partial class FormRolesPermisos
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
            grpUsuario = new GroupBox();
            chkCifrarContrasena = new CheckBox();
            txtContrasenaUsuario = new TextBox();
            lblContrasenaUsuario = new Label();
            chkActivo = new CheckBox();
            chkBloqueado = new CheckBox();
            txtNombreUsuario = new TextBox();
            lblNombreUsuario = new Label();
            txtIdUsuario = new TextBox();
            lblIdUsuario = new Label();
            grpRol = new GroupBox();
            btnEliminarRol = new Button();
            btnModificarRol = new Button();
            btnAltaRol = new Button();
            txtNombreRol = new TextBox();
            lblNombreRol = new Label();
            txtIdRol = new TextBox();
            lblIdRol = new Label();
            grpPermiso = new GroupBox();
            txtNombrePermiso = new TextBox();
            lblNombrePermiso = new Label();
            txtIdPermiso = new TextBox();
            lblIdPermiso = new Label();
            grpAsignarRolUsuario = new GroupBox();
            btnQuitarRolUsuario = new Button();
            btnAsignarRolUsuario = new Button();
            lblAsignarRolUsuario = new Label();
            grpPermisosRol = new GroupBox();
            btnQuitarPermisoRol = new Button();
            btnAsignarPermisoRol = new Button();
            lblPermisosRol = new Label();
            pnlAcciones = new Panel();
            btnSalir = new Button();
            btnLimpiar = new Button();
            grpUsuarios = new GroupBox();
            tvUsuarios = new TreeView();
            grpRoles = new GroupBox();
            tvRoles = new TreeView();
            grpPermisos = new GroupBox();
            tvPermisos = new TreeView();
            grpPermisosPorRol = new GroupBox();
            tvPermisosPorRol = new TreeView();
            grpRolesPermisosUsuario = new GroupBox();
            tvRolesPermisosUsuario = new TreeView();
            grpUsuario.SuspendLayout();
            grpRol.SuspendLayout();
            grpPermiso.SuspendLayout();
            grpAsignarRolUsuario.SuspendLayout();
            grpPermisosRol.SuspendLayout();
            pnlAcciones.SuspendLayout();
            grpUsuarios.SuspendLayout();
            grpRoles.SuspendLayout();
            grpPermisos.SuspendLayout();
            grpPermisosPorRol.SuspendLayout();
            grpRolesPermisosUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(298, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestion de roles y permisos";
            // 
            // grpUsuario
            // 
            grpUsuario.Controls.Add(chkCifrarContrasena);
            grpUsuario.Controls.Add(txtContrasenaUsuario);
            grpUsuario.Controls.Add(lblContrasenaUsuario);
            grpUsuario.Controls.Add(chkActivo);
            grpUsuario.Controls.Add(chkBloqueado);
            grpUsuario.Controls.Add(txtNombreUsuario);
            grpUsuario.Controls.Add(lblNombreUsuario);
            grpUsuario.Controls.Add(txtIdUsuario);
            grpUsuario.Controls.Add(lblIdUsuario);
            grpUsuario.Location = new Point(20, 65);
            grpUsuario.Name = "grpUsuario";
            grpUsuario.Size = new Size(360, 130);
            grpUsuario.TabIndex = 1;
            grpUsuario.TabStop = false;
            grpUsuario.Text = "Usuario seleccionado";
            // 
            // chkCifrarContrasena
            // 
            chkCifrarContrasena.AutoSize = true;
            chkCifrarContrasena.Checked = true;
            chkCifrarContrasena.CheckState = CheckState.Checked;
            chkCifrarContrasena.Location = new Point(232, 99);
            chkCifrarContrasena.Name = "chkCifrarContrasena";
            chkCifrarContrasena.Size = new Size(85, 19);
            chkCifrarContrasena.TabIndex = 8;
            chkCifrarContrasena.Text = "Cifrar clave";
            chkCifrarContrasena.UseVisualStyleBackColor = true;
            // 
            // txtContrasenaUsuario
            // 
            txtContrasenaUsuario.Location = new Point(80, 96);
            txtContrasenaUsuario.Name = "txtContrasenaUsuario";
            txtContrasenaUsuario.ReadOnly = true;
            txtContrasenaUsuario.Size = new Size(130, 23);
            txtContrasenaUsuario.TabIndex = 7;
            // 
            // lblContrasenaUsuario
            // 
            lblContrasenaUsuario.AutoSize = true;
            lblContrasenaUsuario.Location = new Point(17, 99);
            lblContrasenaUsuario.Name = "lblContrasenaUsuario";
            lblContrasenaUsuario.Size = new Size(36, 15);
            lblContrasenaUsuario.TabIndex = 6;
            lblContrasenaUsuario.Text = "Clave";
            // 
            // chkActivo
            // 
            chkActivo.AutoSize = true;
            chkActivo.Enabled = false;
            chkActivo.ForeColor = SystemColors.ControlDark;
            chkActivo.Location = new Point(232, 31);
            chkActivo.Name = "chkActivo";
            chkActivo.Size = new Size(60, 19);
            chkActivo.TabIndex = 5;
            chkActivo.Text = "Activo";
            chkActivo.UseVisualStyleBackColor = true;
            // 
            // chkBloqueado
            // 
            chkBloqueado.AutoSize = true;
            chkBloqueado.BackColor = SystemColors.Control;
            chkBloqueado.Enabled = false;
            chkBloqueado.ForeColor = SystemColors.ControlDark;
            chkBloqueado.Location = new Point(232, 67);
            chkBloqueado.Name = "chkBloqueado";
            chkBloqueado.Size = new Size(83, 19);
            chkBloqueado.TabIndex = 4;
            chkBloqueado.Text = "Bloqueado";
            chkBloqueado.UseVisualStyleBackColor = false;
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Location = new Point(80, 65);
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.ReadOnly = true;
            txtNombreUsuario.Size = new Size(130, 23);
            txtNombreUsuario.TabIndex = 3;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Location = new Point(17, 68);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(47, 15);
            lblNombreUsuario.TabIndex = 2;
            lblNombreUsuario.Text = "Usuario";
            // 
            // txtIdUsuario
            // 
            txtIdUsuario.Location = new Point(80, 29);
            txtIdUsuario.Name = "txtIdUsuario";
            txtIdUsuario.ReadOnly = true;
            txtIdUsuario.Size = new Size(130, 23);
            txtIdUsuario.TabIndex = 1;
            // 
            // lblIdUsuario
            // 
            lblIdUsuario.AutoSize = true;
            lblIdUsuario.Location = new Point(17, 32);
            lblIdUsuario.Name = "lblIdUsuario";
            lblIdUsuario.Size = new Size(18, 15);
            lblIdUsuario.TabIndex = 0;
            lblIdUsuario.Text = "ID";
            // 
            // grpRol
            // 
            grpRol.Controls.Add(btnEliminarRol);
            grpRol.Controls.Add(btnModificarRol);
            grpRol.Controls.Add(btnAltaRol);
            grpRol.Controls.Add(txtNombreRol);
            grpRol.Controls.Add(lblNombreRol);
            grpRol.Controls.Add(txtIdRol);
            grpRol.Controls.Add(lblIdRol);
            grpRol.Location = new Point(400, 65);
            grpRol.Name = "grpRol";
            grpRol.Size = new Size(360, 115);
            grpRol.TabIndex = 2;
            grpRol.TabStop = false;
            grpRol.Text = "Rol seleccionado";
            // 
            // btnEliminarRol
            // 
            btnEliminarRol.Location = new Point(238, 70);
            btnEliminarRol.Name = "btnEliminarRol";
            btnEliminarRol.Size = new Size(94, 28);
            btnEliminarRol.TabIndex = 6;
            btnEliminarRol.Text = "Eliminar";
            btnEliminarRol.UseVisualStyleBackColor = true;
            // 
            // btnModificarRol
            // 
            btnModificarRol.Location = new Point(132, 70);
            btnModificarRol.Name = "btnModificarRol";
            btnModificarRol.Size = new Size(94, 28);
            btnModificarRol.TabIndex = 5;
            btnModificarRol.Text = "Modificar";
            btnModificarRol.UseVisualStyleBackColor = true;
            // 
            // btnAltaRol
            // 
            btnAltaRol.Location = new Point(26, 70);
            btnAltaRol.Name = "btnAltaRol";
            btnAltaRol.Size = new Size(94, 28);
            btnAltaRol.TabIndex = 4;
            btnAltaRol.Text = "Alta";
            btnAltaRol.UseVisualStyleBackColor = true;
            // 
            // txtNombreRol
            // 
            txtNombreRol.Location = new Point(197, 29);
            txtNombreRol.Name = "txtNombreRol";
            txtNombreRol.Size = new Size(135, 23);
            txtNombreRol.TabIndex = 3;
            // 
            // lblNombreRol
            // 
            lblNombreRol.AutoSize = true;
            lblNombreRol.Location = new Point(137, 32);
            lblNombreRol.Name = "lblNombreRol";
            lblNombreRol.Size = new Size(51, 15);
            lblNombreRol.TabIndex = 2;
            lblNombreRol.Text = "Nombre";
            // 
            // txtIdRol
            // 
            txtIdRol.Location = new Point(39, 29);
            txtIdRol.Name = "txtIdRol";
            txtIdRol.ReadOnly = true;
            txtIdRol.Size = new Size(70, 23);
            txtIdRol.TabIndex = 1;
            // 
            // lblIdRol
            // 
            lblIdRol.AutoSize = true;
            lblIdRol.Location = new Point(15, 32);
            lblIdRol.Name = "lblIdRol";
            lblIdRol.Size = new Size(18, 15);
            lblIdRol.TabIndex = 0;
            lblIdRol.Text = "ID";
            // 
            // grpPermiso
            // 
            grpPermiso.Controls.Add(txtNombrePermiso);
            grpPermiso.Controls.Add(lblNombrePermiso);
            grpPermiso.Controls.Add(txtIdPermiso);
            grpPermiso.Controls.Add(lblIdPermiso);
            grpPermiso.Location = new Point(780, 65);
            grpPermiso.Name = "grpPermiso";
            grpPermiso.Size = new Size(360, 115);
            grpPermiso.TabIndex = 3;
            grpPermiso.TabStop = false;
            grpPermiso.Text = "Permiso seleccionado";
            // 
            // txtNombrePermiso
            // 
            txtNombrePermiso.Location = new Point(90, 65);
            txtNombrePermiso.Name = "txtNombrePermiso";
            txtNombrePermiso.ReadOnly = true;
            txtNombrePermiso.Size = new Size(226, 23);
            txtNombrePermiso.TabIndex = 3;
            // 
            // lblNombrePermiso
            // 
            lblNombrePermiso.AutoSize = true;
            lblNombrePermiso.Location = new Point(17, 68);
            lblNombrePermiso.Name = "lblNombrePermiso";
            lblNombrePermiso.Size = new Size(51, 15);
            lblNombrePermiso.TabIndex = 2;
            lblNombrePermiso.Text = "Nombre";
            // 
            // txtIdPermiso
            // 
            txtIdPermiso.Location = new Point(90, 29);
            txtIdPermiso.Name = "txtIdPermiso";
            txtIdPermiso.ReadOnly = true;
            txtIdPermiso.Size = new Size(226, 23);
            txtIdPermiso.TabIndex = 1;
            // 
            // lblIdPermiso
            // 
            lblIdPermiso.AutoSize = true;
            lblIdPermiso.Location = new Point(17, 32);
            lblIdPermiso.Name = "lblIdPermiso";
            lblIdPermiso.Size = new Size(18, 15);
            lblIdPermiso.TabIndex = 0;
            lblIdPermiso.Text = "ID";
            // 
            // grpAsignarRolUsuario
            // 
            grpAsignarRolUsuario.Controls.Add(btnQuitarRolUsuario);
            grpAsignarRolUsuario.Controls.Add(btnAsignarRolUsuario);
            grpAsignarRolUsuario.Controls.Add(lblAsignarRolUsuario);
            grpAsignarRolUsuario.Location = new Point(20, 205);
            grpAsignarRolUsuario.Name = "grpAsignarRolUsuario";
            grpAsignarRolUsuario.Size = new Size(360, 95);
            grpAsignarRolUsuario.TabIndex = 4;
            grpAsignarRolUsuario.TabStop = false;
            grpAsignarRolUsuario.Text = "Roles del usuario";
            // 
            // btnQuitarRolUsuario
            // 
            btnQuitarRolUsuario.Location = new Point(190, 47);
            btnQuitarRolUsuario.Name = "btnQuitarRolUsuario";
            btnQuitarRolUsuario.Size = new Size(126, 30);
            btnQuitarRolUsuario.TabIndex = 2;
            btnQuitarRolUsuario.Text = "Quitar rol";
            btnQuitarRolUsuario.UseVisualStyleBackColor = true;
            // 
            // btnAsignarRolUsuario
            // 
            btnAsignarRolUsuario.Location = new Point(38, 47);
            btnAsignarRolUsuario.Name = "btnAsignarRolUsuario";
            btnAsignarRolUsuario.Size = new Size(126, 30);
            btnAsignarRolUsuario.TabIndex = 1;
            btnAsignarRolUsuario.Text = "Asignar rol";
            btnAsignarRolUsuario.UseVisualStyleBackColor = true;
            // 
            // lblAsignarRolUsuario
            // 
            lblAsignarRolUsuario.AutoSize = true;
            lblAsignarRolUsuario.Location = new Point(17, 23);
            lblAsignarRolUsuario.Name = "lblAsignarRolUsuario";
            lblAsignarRolUsuario.Size = new Size(279, 15);
            lblAsignarRolUsuario.TabIndex = 0;
            lblAsignarRolUsuario.Text = "Seleccionar un usuario y un rol para operar sobre el.";
            // 
            // grpPermisosRol
            // 
            grpPermisosRol.Controls.Add(btnQuitarPermisoRol);
            grpPermisosRol.Controls.Add(btnAsignarPermisoRol);
            grpPermisosRol.Controls.Add(lblPermisosRol);
            grpPermisosRol.Location = new Point(400, 205);
            grpPermisosRol.Name = "grpPermisosRol";
            grpPermisosRol.Size = new Size(360, 95);
            grpPermisosRol.TabIndex = 5;
            grpPermisosRol.TabStop = false;
            grpPermisosRol.Text = "Permisos del rol";
            // 
            // btnQuitarPermisoRol
            // 
            btnQuitarPermisoRol.Location = new Point(190, 47);
            btnQuitarPermisoRol.Name = "btnQuitarPermisoRol";
            btnQuitarPermisoRol.Size = new Size(126, 30);
            btnQuitarPermisoRol.TabIndex = 2;
            btnQuitarPermisoRol.Text = "Quitar permiso";
            btnQuitarPermisoRol.UseVisualStyleBackColor = true;
            // 
            // btnAsignarPermisoRol
            // 
            btnAsignarPermisoRol.Location = new Point(38, 47);
            btnAsignarPermisoRol.Name = "btnAsignarPermisoRol";
            btnAsignarPermisoRol.Size = new Size(126, 30);
            btnAsignarPermisoRol.TabIndex = 1;
            btnAsignarPermisoRol.Text = "Asignar permiso";
            btnAsignarPermisoRol.UseVisualStyleBackColor = true;
            // 
            // lblPermisosRol
            // 
            lblPermisosRol.AutoSize = true;
            lblPermisosRol.Location = new Point(17, 23);
            lblPermisosRol.Name = "lblPermisosRol";
            lblPermisosRol.Size = new Size(283, 15);
            lblPermisosRol.TabIndex = 0;
            lblPermisosRol.Text = "Seleccionar un rol y un permiso para operar sobre el.";
            // 
            // pnlAcciones
            // 
            pnlAcciones.Controls.Add(btnSalir);
            pnlAcciones.Controls.Add(btnLimpiar);
            pnlAcciones.Location = new Point(780, 217);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Size = new Size(360, 83);
            pnlAcciones.TabIndex = 6;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(190, 26);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(126, 30);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(38, 26);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(126, 30);
            btnLimpiar.TabIndex = 0;
            btnLimpiar.Text = "Limpiar campos";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // grpUsuarios
            // 
            grpUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpUsuarios.Controls.Add(tvUsuarios);
            grpUsuarios.Location = new Point(20, 325);
            grpUsuarios.Name = "grpUsuarios";
            grpUsuarios.Size = new Size(210, 345);
            grpUsuarios.TabIndex = 7;
            grpUsuarios.TabStop = false;
            grpUsuarios.Text = "Usuarios";
            // 
            // tvUsuarios
            // 
            tvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tvUsuarios.Location = new Point(12, 24);
            tvUsuarios.Name = "tvUsuarios";
            tvUsuarios.Size = new Size(186, 309);
            tvUsuarios.TabIndex = 0;
            // 
            // grpRoles
            // 
            grpRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpRoles.Controls.Add(tvRoles);
            grpRoles.Location = new Point(244, 325);
            grpRoles.Name = "grpRoles";
            grpRoles.Size = new Size(210, 345);
            grpRoles.TabIndex = 8;
            grpRoles.TabStop = false;
            grpRoles.Text = "Roles";
            // 
            // tvRoles
            // 
            tvRoles.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tvRoles.Location = new Point(12, 24);
            tvRoles.Name = "tvRoles";
            tvRoles.Size = new Size(186, 309);
            tvRoles.TabIndex = 0;
            // 
            // grpPermisos
            // 
            grpPermisos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpPermisos.Controls.Add(tvPermisos);
            grpPermisos.Location = new Point(468, 325);
            grpPermisos.Name = "grpPermisos";
            grpPermisos.Size = new Size(250, 345);
            grpPermisos.TabIndex = 9;
            grpPermisos.TabStop = false;
            grpPermisos.Text = "Permisos";
            // 
            // tvPermisos
            // 
            tvPermisos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tvPermisos.Location = new Point(12, 24);
            tvPermisos.Name = "tvPermisos";
            tvPermisos.Size = new Size(226, 309);
            tvPermisos.TabIndex = 0;
            // 
            // grpPermisosPorRol
            // 
            grpPermisosPorRol.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            grpPermisosPorRol.Controls.Add(tvPermisosPorRol);
            grpPermisosPorRol.Location = new Point(732, 325);
            grpPermisosPorRol.Name = "grpPermisosPorRol";
            grpPermisosPorRol.Size = new Size(250, 345);
            grpPermisosPorRol.TabIndex = 10;
            grpPermisosPorRol.TabStop = false;
            grpPermisosPorRol.Text = "Permisos por rol";
            // 
            // tvPermisosPorRol
            // 
            tvPermisosPorRol.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tvPermisosPorRol.Location = new Point(12, 24);
            tvPermisosPorRol.Name = "tvPermisosPorRol";
            tvPermisosPorRol.Size = new Size(226, 309);
            tvPermisosPorRol.TabIndex = 0;
            // 
            // grpRolesPermisosUsuario
            // 
            grpRolesPermisosUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpRolesPermisosUsuario.Controls.Add(tvRolesPermisosUsuario);
            grpRolesPermisosUsuario.Location = new Point(996, 325);
            grpRolesPermisosUsuario.Name = "grpRolesPermisosUsuario";
            grpRolesPermisosUsuario.Size = new Size(260, 345);
            grpRolesPermisosUsuario.TabIndex = 11;
            grpRolesPermisosUsuario.TabStop = false;
            grpRolesPermisosUsuario.Text = "Roles y permisos del usuario";
            // 
            // tvRolesPermisosUsuario
            // 
            tvRolesPermisosUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tvRolesPermisosUsuario.Location = new Point(12, 24);
            tvRolesPermisosUsuario.Name = "tvRolesPermisosUsuario";
            tvRolesPermisosUsuario.Size = new Size(236, 309);
            tvRolesPermisosUsuario.TabIndex = 0;
            // 
            // FormRolesPermisos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1274, 691);
            Controls.Add(grpRolesPermisosUsuario);
            Controls.Add(grpPermisosPorRol);
            Controls.Add(grpPermisos);
            Controls.Add(grpRoles);
            Controls.Add(grpUsuarios);
            Controls.Add(pnlAcciones);
            Controls.Add(grpPermisosRol);
            Controls.Add(grpAsignarRolUsuario);
            Controls.Add(grpPermiso);
            Controls.Add(grpRol);
            Controls.Add(grpUsuario);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1290, 730);
            Name = "FormRolesPermisos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestion de roles y permisos";
            grpUsuario.ResumeLayout(false);
            grpUsuario.PerformLayout();
            grpRol.ResumeLayout(false);
            grpRol.PerformLayout();
            grpPermiso.ResumeLayout(false);
            grpPermiso.PerformLayout();
            grpAsignarRolUsuario.ResumeLayout(false);
            grpAsignarRolUsuario.PerformLayout();
            grpPermisosRol.ResumeLayout(false);
            grpPermisosRol.PerformLayout();
            pnlAcciones.ResumeLayout(false);
            grpUsuarios.ResumeLayout(false);
            grpRoles.ResumeLayout(false);
            grpPermisos.ResumeLayout(false);
            grpPermisosPorRol.ResumeLayout(false);
            grpRolesPermisosUsuario.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private GroupBox grpUsuario;
        private CheckBox chkCifrarContrasena;
        private TextBox txtContrasenaUsuario;
        private Label lblContrasenaUsuario;
        private CheckBox chkActivo;
        private CheckBox chkBloqueado;
        private TextBox txtNombreUsuario;
        private Label lblNombreUsuario;
        private TextBox txtIdUsuario;
        private Label lblIdUsuario;
        private GroupBox grpRol;
        private Button btnEliminarRol;
        private Button btnModificarRol;
        private Button btnAltaRol;
        private TextBox txtNombreRol;
        private Label lblNombreRol;
        private TextBox txtIdRol;
        private Label lblIdRol;
        private GroupBox grpPermiso;
        private TextBox txtNombrePermiso;
        private Label lblNombrePermiso;
        private TextBox txtIdPermiso;
        private Label lblIdPermiso;
        private GroupBox grpAsignarRolUsuario;
        private Button btnQuitarRolUsuario;
        private Button btnAsignarRolUsuario;
        private Label lblAsignarRolUsuario;
        private GroupBox grpPermisosRol;
        private Button btnQuitarPermisoRol;
        private Button btnAsignarPermisoRol;
        private Label lblPermisosRol;
        private Panel pnlAcciones;
        private Button btnSalir;
        private Button btnLimpiar;
        private GroupBox grpUsuarios;
        private TreeView tvUsuarios;
        private GroupBox grpRoles;
        private TreeView tvRoles;
        private GroupBox grpPermisos;
        private TreeView tvPermisos;
        private GroupBox grpPermisosPorRol;
        private TreeView tvPermisosPorRol;
        private GroupBox grpRolesPermisosUsuario;
        private TreeView tvRolesPermisosUsuario;
    }
}
