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
        private const string PermisoInicio = "Inicio";
        private const string PermisoAbmUsuarios = "ABM usuarios";
        private const string PermisoGestionRolesPermisos = "Gestion de roles y permisos";
        private const string PermisoVerInventario = "Ver inventario";
        private const string PermisoAdministrarProductos = "Administrar productos";
        private const string PermisoAdministrarClientes = "Administrar clientes";
        private const string PermisoGestionVentas = "Gestion de ventas";
        private const string PermisoAdministrarMetodosPago = "Administrar metodos de pago";
        private const string PermisoGestionBaseDatos = "Gestion de base de datos";
        private const string PermisoAnalisisVentas = "Analisis de ventas";
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
            administrarClientesToolStripMenuItem.Click += administrarClientesToolStripMenuItem_Click;
            registrarVentaToolStripMenuItem.Click += registrarVentaToolStripMenuItem_Click;
            consultarVentasToolStripMenuItem.Click += consultarVentasToolStripMenuItem_Click;
            administrarMetodosDePagoToolStripMenuItem.Click += administrarMetodosDePagoToolStripMenuItem_Click;
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

        private void OcultarOpcionesPorPermiso()
        {
            inicioToolStripMenuItem.Visible = false;
            gestionDeUsuariosToolStripMenuItem.Visible = false;
            productosToolStripMenuItem.Visible = false;
            clientesToolStripMenuItem.Visible = false;
            ventasToolStripMenuItem.Visible = false;
            gestionDeBaseDeDatosToolStripMenuItem.Visible = false;
            analisisToolStripMenuItem.Visible = false;

            cerrarSesionToolStripMenuItem.Visible = false;
            salirToolStripMenuItem.Visible = false;
            aBMUsuariosToolStripMenuItem.Visible = false;
            permisosYRolesToolStripMenuItem.Visible = false;
            verInventarioToolStripMenuItem.Visible = false;
            administrarProductosToolStripMenuItem.Visible = false;
            administrarMarcasToolStripMenuItem.Visible = false;
            administrarCategoriasToolStripMenuItem.Visible = false;
            administrarClientesToolStripMenuItem.Visible = false;
            registrarVentaToolStripMenuItem.Visible = false;
            consultarVentasToolStripMenuItem.Visible = false;
            administrarMetodosDePagoToolStripMenuItem.Visible = false;
            backupToolStripMenuItem.Visible = false;
            restoreToolStripMenuItem.Visible = false;
            bitacoraToolStripMenuItem.Visible = false;
            dashboardProductosToolStripMenuItem.Visible = false;
            dashboardClientesToolStripMenuItem.Visible = false;
        }

        private void AplicarPermisosUsuarioActual()
        {
            List<Permiso> permisos = this.ObtenerPermisosUsuarioActual();

            if (TienePermiso(permisos, PermisoInicio))
            {
                inicioToolStripMenuItem.Visible = true;
                cerrarSesionToolStripMenuItem.Visible = true;
                salirToolStripMenuItem.Visible = true;
            }

            if (TienePermiso(permisos, PermisoAbmUsuarios))
            {
                gestionDeUsuariosToolStripMenuItem.Visible = true;
                aBMUsuariosToolStripMenuItem.Visible = true;
            }

            if (TienePermiso(permisos, PermisoGestionRolesPermisos))
            {
                gestionDeUsuariosToolStripMenuItem.Visible = true;
                permisosYRolesToolStripMenuItem.Visible = true;
            }

            if (TienePermiso(permisos, PermisoVerInventario))
            {
                productosToolStripMenuItem.Visible = true;
                verInventarioToolStripMenuItem.Visible = true;
            }

            if (TienePermiso(permisos, PermisoAdministrarProductos))
            {
                productosToolStripMenuItem.Visible = true;
                administrarProductosToolStripMenuItem.Visible = true;
                administrarMarcasToolStripMenuItem.Visible = true;
                administrarCategoriasToolStripMenuItem.Visible = true;
            }

            if (TienePermiso(permisos, PermisoAdministrarClientes))
            {
                clientesToolStripMenuItem.Visible = true;
                administrarClientesToolStripMenuItem.Visible = true;
            }

            if (TienePermiso(permisos, PermisoGestionVentas))
            {
                ventasToolStripMenuItem.Visible = true;
                registrarVentaToolStripMenuItem.Visible = true;
                consultarVentasToolStripMenuItem.Visible = true;
            }

            if (TienePermiso(permisos, PermisoAdministrarMetodosPago))
            {
                ventasToolStripMenuItem.Visible = true;
                administrarMetodosDePagoToolStripMenuItem.Visible = true;
            }

            if (TienePermiso(permisos, PermisoGestionBaseDatos))
            {
                gestionDeBaseDeDatosToolStripMenuItem.Visible = true;
                backupToolStripMenuItem.Visible = true;
                restoreToolStripMenuItem.Visible = true;
                bitacoraToolStripMenuItem.Visible = true;
            }

            if (TienePermiso(permisos, PermisoAnalisisVentas))
            {
                analisisToolStripMenuItem.Visible = true;
                dashboardProductosToolStripMenuItem.Visible = true;
                dashboardClientesToolStripMenuItem.Visible = true;
            }

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
