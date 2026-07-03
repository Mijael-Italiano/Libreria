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
using Libreria.Entity.EntityComposite;
using Libreria.Sesion;

namespace Libreria.UI
{
    public partial class FormMenuInicio : Form
    {
        private readonly UsuarioRolBusiness usuarioRolBusiness;
        private readonly RolPermisoBusiness rolPermisoBusiness;
        private bool cerrandoSesion;

        public FormMenuInicio()
        {
            InitializeComponent();
            this.usuarioRolBusiness = new UsuarioRolBusiness();
            this.rolPermisoBusiness = new RolPermisoBusiness();
            this.Load += FormMenuInicio_Load;
            this.ConfigurarEventosMenu();
        }

        private void FormMenuInicio_Load(object? sender, EventArgs e)
        {
            this.CargarMenuSegunPermisos();
        }

        private void CargarMenuSegunPermisos()
        {
            this.OcultarOpcionesPorPermiso();

            try
            {
                this.AplicarPermisosUsuarioActual();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudieron cargar los permisos del usuario.\n\n{ex.Message}",
                    "Permisos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cerrandoSesion = true;
            SesionActual.Cerrar();

            FormIniciarSesion formIniciarSesion = new FormIniciarSesion();
            formIniciarSesion.Show();
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMenuInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.cerrandoSesion)
            {
                Application.Exit();
            }
        }

        private void ConfigurarEventosMenu()
        {
            aBMUsuariosToolStripMenuItem.Click += aBMUsuariosToolStripMenuItem_Click;
            permisosYRolesToolStripMenuItem.Click += permisosYRolesToolStripMenuItem_Click;
            verInventarioToolStripMenuItem.Click += verInventarioToolStripMenuItem_Click;
            administrarProductosToolStripMenuItem.Click += administrarProductosToolStripMenuItem_Click;
            administrarMarcasToolStripMenuItem.Click += administrarMarcasToolStripMenuItem_Click;
            administrarCategoriasToolStripMenuItem.Click += administrarCategoriasToolStripMenuItem_Click;
            administrarColoresToolStripMenuItem.Click += administrarColoresToolStripMenuItem_Click;
            administrarClientesToolStripMenuItem.Click += administrarClientesToolStripMenuItem_Click;
            registrarVentaToolStripMenuItem.Click += registrarVentaToolStripMenuItem_Click;
            consultarVentasToolStripMenuItem.Click += consultarVentasToolStripMenuItem_Click;
            administrarMetodosDePagoToolStripMenuItem.Click += administrarMetodosDePagoToolStripMenuItem_Click;
            backupToolStripMenuItem.Click += backupToolStripMenuItem_Click;
            restoreToolStripMenuItem.Click += restoreToolStripMenuItem_Click;
            bitacoraToolStripMenuItem.Click += bitacoraToolStripMenuItem_Click;
            dashboardDiarioToolStripMenuItem.Click += dashboardDiarioToolStripMenuItem_Click;
            dashboardSemanalToolStripMenuItem.Click += dashboardSemanalToolStripMenuItem_Click;
            dashboardMensualToolStripMenuItem.Click += dashboardMensualToolStripMenuItem_Click;
        }

        private void aBMUsuariosToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormUsuarios().Show();
        }

        private void permisosYRolesToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormRolesPermisos().Show();
        }

        private void verInventarioToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormInventario().Show();
        }

        private void administrarProductosToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormAdministrarProductos().Show();
        }

        private void administrarMarcasToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormMarcaProducto().Show();
        }

        private void administrarCategoriasToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormCategoriaProducto().Show();
        }

        private void administrarColoresToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormColorProducto().Show();
        }

        private void administrarClientesToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormClientes().Show();
        }

        private void registrarVentaToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormRegistrarVenta().Show();
        }

        private void consultarVentasToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormConsultarVentas().Show();
        }

        private void administrarMetodosDePagoToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormMetodosDePago().Show();
        }

        private void backupToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormBackUp().Show();
        }

        private void restoreToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormRestore().Show();
        }

        private void bitacoraToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormBitacora().Show();
        }


        private void dashboardDiarioToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormDashboardVentasDiarias().Show();
        }

        private void dashboardSemanalToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormDashboardVentas().Show();
        }

        private void dashboardMensualToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            new FormDashboardVentasMensuales().Show();
        }
        private void OcultarOpcionesPorPermiso()
        {
            foreach (ToolStripMenuItem menuItem in menuStrip1.Items.OfType<ToolStripMenuItem>())
            {
                this.OcultarOpcion(menuItem);
            }
        }

        private void AplicarPermisosUsuarioActual()
        {
            HashSet<string> permisos = this.ObtenerPermisosUsuarioActual()
                .Select(permiso => permiso.Nombre)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            foreach (ToolStripMenuItem menuItem in menuStrip1.Items.OfType<ToolStripMenuItem>())
            {
                this.AplicarPermisos(menuItem, permisos);
            }
        }

        private void OcultarOpcion(ToolStripMenuItem menuItem)
        {
            menuItem.Visible = false;

            foreach (ToolStripMenuItem subMenuItem in menuItem.DropDownItems.OfType<ToolStripMenuItem>())
            {
                this.OcultarOpcion(subMenuItem);
            }
        }

        private bool AplicarPermisos(ToolStripMenuItem menuItem, HashSet<string> permisos)
        {
            bool tienePermisoPropio = menuItem.Tag is string permiso
                && permisos.Contains(permiso);

            bool tieneSubMenuVisible = false;

            foreach (ToolStripMenuItem subMenuItem in menuItem.DropDownItems.OfType<ToolStripMenuItem>())
            {
                tieneSubMenuVisible |= this.AplicarPermisos(subMenuItem, permisos);
            }

            bool esVisible = tienePermisoPropio || tieneSubMenuVisible;
            menuItem.Visible = esVisible;
            return esVisible;
        }

        private List<Permiso> ObtenerPermisosUsuarioActual()
        {
            List<Permiso> permisos = new List<Permiso>();

            if (SesionActual.Usuario == null)
            {
                return permisos;
            }

            foreach (Rol rol in this.usuarioRolBusiness.ConsultarRolesPorUsuario(SesionActual.Usuario.Id))
            {
                foreach (Permiso permiso in this.rolPermisoBusiness.ConsultarPermisosPorRol(rol.Id))
                {
                    if (!TienePermiso(permisos, permiso.Nombre))
                    {
                        permisos.Add(permiso);
                    }
                }
            }

            return permisos;
        }

        private static bool TienePermiso(List<Permiso> permisos, string nombrePermiso)
        {
            return permisos.Any(permiso =>
                permiso.Nombre.Equals(nombrePermiso, StringComparison.OrdinalIgnoreCase)
            );
        }

    }
}



