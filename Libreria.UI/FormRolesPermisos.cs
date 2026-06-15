using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria.Business;
using Libreria.Business.BusinessComposite;
using Libreria.Entity;
using Libreria.Entity.EntityComposite;
using Libreria.Seguridad;

namespace Libreria.UI
{
    public partial class FormRolesPermisos : Form
    {
        private readonly PermisoBusiness permisoBusiness;
        private readonly RolBusiness rolBusiness;
        private readonly RolPermisoBusiness rolPermisoBusiness;
        private readonly UsuarioBusiness usuarioBusiness;
        private readonly UsuarioRolBusiness usuarioRolBusiness;

        public FormRolesPermisos()
        {
            InitializeComponent();
            this.ConfigurarTreeViews();
            this.permisoBusiness = new PermisoBusiness();
            this.rolBusiness = new RolBusiness();
            this.rolPermisoBusiness = new RolPermisoBusiness();
            this.usuarioBusiness = new UsuarioBusiness();
            this.usuarioRolBusiness = new UsuarioRolBusiness();
            this.CargarUsuarios();
            this.CargarPermisos();
            this.CargarRoles();
        }

        private void ConfigurarTreeViews()
        {
            tvUsuarios.HideSelection = false;
            tvRoles.HideSelection = false;
            tvPermisos.HideSelection = false;
            tvPermisosPorRol.HideSelection = false;
            tvRolesPermisosUsuario.HideSelection = false;
            tvUsuarios.AfterSelect += tvUsuarios_AfterSelect;
            tvRoles.AfterSelect += tvRoles_AfterSelect;
            tvPermisos.AfterSelect += tvPermisos_AfterSelect;
            chkCifrarContrasena.CheckedChanged += chkCifrarContrasena_CheckedChanged;
        }

        private void CargarUsuarios()
        {
            try
            {
                tvUsuarios.Nodes.Clear();

                foreach (var usuario in this.usuarioBusiness.ConsultarUsuarios().Where(usuario => usuario.Estado))
                {
                    TreeNode nodo = new TreeNode(usuario.NombreUsuario)
                    {
                        Tag = usuario
                    };

                    tvUsuarios.Nodes.Add(nodo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los usuarios disponibles. " + ex.Message,
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarPermisos()
        {
            try
            {
                tvPermisos.Nodes.Clear();

                foreach (var permiso in this.permisoBusiness.ConsultarPermisos())
                {
                    TreeNode nodo = new TreeNode(permiso.Nombre)
                    {
                        Tag = permiso
                    };

                    tvPermisos.Nodes.Add(nodo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los permisos disponibles. " + ex.Message,
                    "Permisos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarRoles()
        {
            try
            {
                tvRoles.Nodes.Clear();

                foreach (var rol in this.rolBusiness.ConsultarRoles())
                {
                    TreeNode nodo = new TreeNode(rol.Nombre)
                    {
                        Tag = rol
                    };

                    tvRoles.Nodes.Add(nodo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los roles disponibles. " + ex.Message,
                    "Roles",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnAltaRol_Click(object sender, EventArgs e)
        {
            try
            {
                this.rolBusiness.AltaRol(txtNombreAltaRol.Text);
                txtNombreAltaRol.Clear();
                this.CargarRoles();

                MessageBox.Show(
                    "Rol agregado correctamente.",
                    "Roles",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Roles",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnModificarRol_Click(object sender, EventArgs e)
        {
            try
            {
                int idRol = int.Parse(txtIdRol.Text);

                this.rolBusiness.ModificarRol(idRol, txtNombreRol.Text);
                this.CargarRoles();

                Rol rolModificado = new Rol(idRol, txtNombreRol.Text.Trim());
                this.CargarPermisosPorRol(rolModificado);

                if (tvUsuarios.SelectedNode?.Tag is Usuario usuario)
                {
                    this.CargarRolesPermisosUsuario(usuario);
                }

                MessageBox.Show(
                    "Rol modificado correctamente.",
                    "Roles",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar un rol.",
                    "Roles",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Roles",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void tvUsuarios_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is Usuario usuario)
            {
                this.MostrarUsuarioSeleccionado(usuario);
                this.CargarRolesPermisosUsuario(usuario);
            }
        }

        private void chkCifrarContrasena_CheckedChanged(object? sender, EventArgs e)
        {
            if (tvUsuarios.SelectedNode?.Tag is Usuario usuario)
            {
                this.MostrarContrasenaUsuario(usuario);
            }
        }

        private void tvRoles_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is Rol rol)
            {
                this.MostrarRolSeleccionado(rol);
                this.CargarPermisosPorRol(rol);
            }
        }

        private void tvPermisos_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node?.Tag is Permiso permiso)
            {
                this.MostrarPermisoSeleccionado(permiso);
            }
        }

        private void MostrarUsuarioSeleccionado(Usuario usuario)
        {
            txtIdUsuario.Text = usuario.Id.ToString();
            txtNombreUsuario.Text = usuario.NombreUsuario;
            chkBloqueado.Checked = usuario.Bloqueado;
            this.MostrarContrasenaUsuario(usuario);
        }

        private void MostrarContrasenaUsuario(Usuario usuario)
        {
            try
            {
                txtContrasenaUsuario.Text = chkCifrarContrasena.Checked
                    ? usuario.Contrasena
                    : usuario.Contrasena.DesencriptarPassword();
            }
            catch (Exception)
            {
                txtContrasenaUsuario.Text = usuario.Contrasena;
            }
        }

        private void MostrarRolSeleccionado(Rol rol)
        {
            txtIdRol.Text = rol.Id.ToString();
            txtNombreRol.Text = rol.Nombre;
        }

        private void MostrarPermisoSeleccionado(Permiso permiso)
        {
            txtIdPermiso.Text = permiso.Id.ToString();
            txtNombrePermiso.Text = permiso.Nombre;
        }

        private void CargarPermisosPorRol(Rol rol)
        {
            try
            {
                tvPermisosPorRol.Nodes.Clear();

                TreeNode nodoRol = new TreeNode(rol.Nombre)
                {
                    Tag = rol
                };

                foreach (Permiso permiso in this.rolPermisoBusiness.ConsultarPermisosPorRol(rol.Id))
                {
                    TreeNode nodoPermiso = new TreeNode(permiso.Nombre)
                    {
                        Tag = permiso
                    };

                    nodoRol.Nodes.Add(nodoPermiso);
                }

                tvPermisosPorRol.Nodes.Add(nodoRol);
                nodoRol.Expand();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los permisos del rol. " + ex.Message,
                    "Permisos del rol",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarRolesPermisosUsuario(Usuario usuario)
        {
            try
            {
                tvRolesPermisosUsuario.Nodes.Clear();

                TreeNode nodoUsuario = new TreeNode(usuario.NombreUsuario)
                {
                    Tag = usuario
                };

                foreach (Rol rol in this.usuarioRolBusiness.ConsultarRolesPorUsuario(usuario.Id))
                {
                    TreeNode nodoRol = new TreeNode(rol.Nombre)
                    {
                        Tag = rol
                    };

                    foreach (Permiso permiso in this.rolPermisoBusiness.ConsultarPermisosPorRol(rol.Id))
                    {
                        TreeNode nodoPermiso = new TreeNode(permiso.Nombre)
                        {
                            Tag = permiso
                        };

                        nodoRol.Nodes.Add(nodoPermiso);
                    }

                    nodoUsuario.Nodes.Add(nodoRol);
                }

                tvRolesPermisosUsuario.Nodes.Add(nodoUsuario);
                nodoUsuario.ExpandAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los roles y permisos del usuario. " + ex.Message,
                    "Roles y permisos del usuario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnAsignarPermisoRol_Click(object sender, EventArgs e)
        {
            try
            {
                Rol rol = this.ObtenerRolSeleccionado();
                Permiso permiso = this.ObtenerPermisoSeleccionado();

                this.rolPermisoBusiness.AsociarRolPermiso(rol.Id, permiso.Id);
                this.CargarPermisosPorRol(rol);
                this.RefrescarRolesPermisosUsuarioSeleccionado();

                MessageBox.Show(
                    "Permiso asignado correctamente al rol.",
                    "Permisos del rol",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Permisos del rol",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnQuitarPermisoRol_Click(object sender, EventArgs e)
        {
            try
            {
                Rol rol = this.ObtenerRolSeleccionado();
                Permiso permiso = this.ObtenerPermisoSeleccionado();

                this.rolPermisoBusiness.DesasociarRolPermiso(rol.Id, permiso.Id);
                this.CargarPermisosPorRol(rol);
                this.RefrescarRolesPermisosUsuarioSeleccionado();

                MessageBox.Show(
                    "Permiso quitado correctamente del rol.",
                    "Permisos del rol",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Permisos del rol",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnAsignarRolUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = this.ObtenerUsuarioSeleccionado();
                Rol rol = this.ObtenerRolSeleccionado();

                this.usuarioRolBusiness.AsociarUsuarioRol(usuario.Id, rol.Id);
                this.CargarRolesPermisosUsuario(usuario);

                MessageBox.Show(
                    "Rol asignado correctamente al usuario.",
                    "Roles del usuario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Roles del usuario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnQuitarRolUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = this.ObtenerUsuarioSeleccionado();
                Rol rol = this.ObtenerRolSeleccionado();

                this.usuarioRolBusiness.DesasociarUsuarioRol(usuario.Id, rol.Id);
                this.CargarRolesPermisosUsuario(usuario);

                MessageBox.Show(
                    "Rol quitado correctamente del usuario.",
                    "Roles del usuario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Roles del usuario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private Usuario ObtenerUsuarioSeleccionado()
        {
            if (tvUsuarios.SelectedNode?.Tag is Usuario usuario)
            {
                return usuario;
            }

            throw new Exception("Debe seleccionar un usuario.");
        }

        private void RefrescarRolesPermisosUsuarioSeleccionado()
        {
            if (tvUsuarios.SelectedNode?.Tag is Usuario usuario)
            {
                this.CargarRolesPermisosUsuario(usuario);
            }
        }

        private Rol ObtenerRolSeleccionado()
        {
            if (tvRoles.SelectedNode?.Tag is Rol rol)
            {
                return rol;
            }

            throw new Exception("Debe seleccionar un rol.");
        }

        private Permiso ObtenerPermisoSeleccionado()
        {
            if (tvPermisos.SelectedNode?.Tag is Permiso permiso)
            {
                return permiso;
            }

            throw new Exception("Debe seleccionar un permiso.");
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            try
            {
                Rol rol = this.ObtenerRolSeleccionado();

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Desea eliminar el rol {rol.Nombre}?",
                    "Roles",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                foreach (int idUsuario in this.usuarioRolBusiness.ConsultarIdsUsuariosPorRol(rol.Id))
                {
                    this.usuarioRolBusiness.DesasociarUsuarioRol(idUsuario, rol.Id);
                }

                foreach (Permiso permiso in this.rolPermisoBusiness.ConsultarPermisosPorRol(rol.Id))
                {
                    this.rolPermisoBusiness.DesasociarRolPermiso(rol.Id, permiso.Id);
                }

                this.rolBusiness.EliminarRol(rol.Id);

                txtIdRol.Clear();
                txtNombreRol.Clear();
                tvPermisosPorRol.Nodes.Clear();
                this.CargarRoles();
                this.RefrescarRolesPermisosUsuarioSeleccionado();

                MessageBox.Show(
                    "Rol eliminado correctamente.",
                    "Roles",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Roles",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
