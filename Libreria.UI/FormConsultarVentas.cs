using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Libreria.Business;
using Libreria.Entity;

namespace Libreria.UI
{
    public partial class FormConsultarVentas : Form
    {
        private readonly FacturaBusiness facturaBusiness;
        private readonly FacturaItemBusiness facturaItemBusiness;
        private bool cargandoFacturas;

        public FormConsultarVentas()
        {
            InitializeComponent();
            this.facturaBusiness = new FacturaBusiness();
            this.facturaItemBusiness = new FacturaItemBusiness();
            this.Load += FormConsultarVentas_Load;
            dgvFacturas.SelectionChanged += dgvFacturas_SelectionChanged;
            btnBuscar.Click += btnBuscar_Click;
            btnLimpiarBusqueda.Click += btnLimpiarBusqueda_Click;
        }

        private void FormConsultarVentas_Load(object? sender, EventArgs e)
        {
            this.ConfigurarFiltrosFecha();
            this.CargarFacturas();
        }

        private void dgvFacturas_SelectionChanged(object? sender, EventArgs e)
        {
            if (this.cargandoFacturas || dgvFacturas.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvFacturas.SelectedRows[0].Tag is Factura factura)
            {
                this.CargarItemsFactura(factura);
            }
        }

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            try
            {
                DateTime? fechaDesde = dtpFechaDesde.Checked ? dtpFechaDesde.Value.Date : null;
                DateTime? fechaHasta = dtpFechaHasta.Checked ? dtpFechaHasta.Value.Date : null;

                List<Factura> facturas = this.facturaBusiness.BuscarFacturas(
                    txtIdFactura.Text,
                    txtIdCliente.Text,
                    txtDocumentoCliente.Text,
                    txtNombreCliente.Text,
                    txtApellidoCliente.Text,
                    fechaDesde,
                    fechaHasta
                );

                if (!string.IsNullOrWhiteSpace(txtUsuario.Text))
                {
                    facturas = facturas
                        .Where(factura => factura.Usuario.NombreUsuario.StartsWith(txtUsuario.Text.Trim(), StringComparison.OrdinalIgnoreCase))
                        .ToList();
                }

                this.CargarFacturas(facturas);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Consultar ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarBusqueda_Click(object? sender, EventArgs e)
        {
            txtIdFactura.Clear();
            txtUsuario.Clear();
            txtIdCliente.Clear();
            txtDocumentoCliente.Clear();
            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            dtpFechaDesde.Checked = false;
            dtpFechaHasta.Checked = false;
            this.CargarFacturas();
        }

        private void ConfigurarFiltrosFecha()
        {
            dtpFechaDesde.ShowCheckBox = true;
            dtpFechaHasta.ShowCheckBox = true;
            dtpFechaDesde.Checked = false;
            dtpFechaHasta.Checked = false;
            dtpFechaDesde.Value = DateTime.Today;
            dtpFechaHasta.Value = DateTime.Today;
        }

        private void CargarFacturas(List<Factura>? facturas = null)
        {
            try
            {
                this.cargandoFacturas = true;
                dgvFacturas.Rows.Clear();
                dgvFacturaItems.Rows.Clear();

                facturas ??= this.facturaBusiness.ConsultarFacturas();
                foreach (Factura factura in facturas)
                {
                    int indiceFila = dgvFacturas.Rows.Add(
                        factura.IdFactura,
                        factura.Cliente.Id,
                        factura.Cliente.Nombre,
                        factura.Cliente.Apellido,
                        factura.Cliente.Documento,
                        factura.Usuario.NombreUsuario,
                        factura.FechaEmision.ToShortDateString(),
                        factura.Total.ToString("0.00"),
                        factura.Estado
                    );

                    dgvFacturas.Rows[indiceFila].Tag = factura;
                }

                this.cargandoFacturas = false;

                if (dgvFacturas.Rows.Count > 0)
                {
                    dgvFacturas.ClearSelection();
                    dgvFacturas.Rows[0].Selected = true;

                    if (dgvFacturas.Rows[0].Tag is Factura factura)
                    {
                        this.CargarItemsFactura(factura);
                    }
                }
            }
            catch (Exception ex)
            {
                this.cargandoFacturas = false;
                MessageBox.Show(
                    "No se pudieron cargar las ventas. " + ex.Message,
                    "Consultar ventas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarItemsFactura(Factura factura)
        {
            try
            {
                dgvFacturaItems.Rows.Clear();

                foreach (FacturaItem item in this.facturaItemBusiness.ConsultarItemsPorFactura(factura.IdFactura))
                {
                    dgvFacturaItems.Rows.Add(
                        item.IdFacturaItem,
                        item.Producto.IdProducto,
                        item.Producto.Descripcion,
                        item.Producto.Marca?.Nombre ?? string.Empty,
                        item.Producto.Categoria?.Nombre ?? string.Empty,
                        item.Cantidad,
                        item.PrecioUnitario.ToString("0.00"),
                        item.Subtotal.ToString("0.00"),
                        item.Estado
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los items de la venta. " + ex.Message,
                    "Consultar ventas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}



