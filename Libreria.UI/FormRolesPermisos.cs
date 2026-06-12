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

namespace Libreria.UI
{
    public partial class FormRolesPermisos : Form
    {
        private readonly PermisoBusiness permisoBusiness;
        private readonly RolBusiness rolBusiness;
        private readonly UsuarioBusiness usuarioBusiness;

        public FormRolesPermisos()
        {
            InitializeComponent();
            this.ConfigurarTreeViews();
            this.permisoBusiness = new PermisoBusiness();
            this.rolBusiness = new RolBusiness();
            this.usuarioBusiness = new UsuarioBusiness();
            this.CargarUsuarios();
            this.CargarPermisos();
            this.CargarRoles();
        }

        private void ConfigurarTreeViews()
        {
            tvUsuarios.HideSelection = false;
            tvRoles.HideSelection = false;
            tvPermisos.HideSelection = false;
        }

        private void CargarUsuarios()
        {
            try
            {
                tvUsuarios.Nodes.Clear();

                foreach (var usuario in this.usuarioBusiness.ConsultarUsuarios())
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
                this.rolBusiness.AltaRol(txtNombreRol.Text);
                txtNombreRol.Clear();
                txtIdRol.Clear();
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
    }
}
