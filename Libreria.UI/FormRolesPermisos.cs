using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria.Business.BusinessComposite;

namespace Libreria.UI
{
    public partial class FormRolesPermisos : Form
    {
        private readonly PermisoBusiness permisoBusiness;

        public FormRolesPermisos()
        {
            InitializeComponent();
            this.permisoBusiness = new PermisoBusiness();
            this.CargarPermisos();
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
    }
}
