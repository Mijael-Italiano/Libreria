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
using Libreria.Documentos.Facturas;
using Libreria.Entity;
using Libreria.Sesion;

namespace Libreria.UI
{
    public partial class FormRegistrarVenta : Form
    {
        private readonly FacturaBusiness facturaBusiness;
        private readonly FacturaItemBusiness facturaItemBusiness;
        private readonly FacturaMedioPagoBusiness facturaMedioPagoBusiness;
        private readonly ProductoBusiness productoBusiness;
        private Cliente? clienteAltaSeleccionado;
        private Factura? facturaEnCurso;
        private Factura? facturaSeleccionada;
        private Cliente? clienteModificadoSeleccionado;
        private bool cargandoFacturas;

        public FormRegistrarVenta()
        {
            InitializeComponent();
            this.facturaBusiness = new FacturaBusiness();
            this.facturaItemBusiness = new FacturaItemBusiness();
            this.facturaMedioPagoBusiness = new FacturaMedioPagoBusiness();
            this.productoBusiness = new ProductoBusiness();
            dgvFacturas.SelectionChanged += dgvFacturas_SelectionChanged;
            this.Load += FormRegistrarVenta_Load;
        }

        private void FormRegistrarVenta_Load(object? sender, EventArgs e)
        {
            this.CargarFacturas();
        }

        private void chkBuscarPorPeriodo_CheckedChanged(object? sender, EventArgs e)
        {
            bool habilitarPeriodo = chkBuscarPorPeriodo.Checked;
            dtpBuscarFechaDesde.Enabled = habilitarPeriodo;
            dtpBuscarFechaHasta.Enabled = habilitarPeriodo;
        }

        private void CargarFacturas(List<Factura>? facturas = null)
        {
            try
            {
                this.cargandoFacturas = true;
                dgvFacturas.Rows.Clear();
                this.LimpiarFacturaSeleccionada();

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
                    this.MostrarFacturaDesdeFila(dgvFacturas.Rows[0]);
                }
            }
            catch (Exception ex)
            {
                this.cargandoFacturas = false;

                MessageBox.Show(
                    "No se pudieron cargar las facturas. " + ex.Message,
                    "Registrar venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvFacturas_SelectionChanged(object? sender, EventArgs e)
        {
            if (this.cargandoFacturas || dgvFacturas.SelectedRows.Count == 0)
            {
                return;
            }

            this.MostrarFacturaDesdeFila(dgvFacturas.SelectedRows[0]);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.facturaSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                this.ValidarFacturaEditable(this.facturaSeleccionada);

                Factura facturaModificada = this.ClonarFactura(this.facturaSeleccionada);

                if (this.clienteModificadoSeleccionado != null)
                {
                    facturaModificada.Cliente = this.clienteModificadoSeleccionado;
                }

                List<FacturaItem> itemsOriginales = this.facturaItemBusiness.ConsultarItemsPorFactura(facturaModificada.IdFactura);
                List<FacturaMedioPago> pagosOriginales = this.facturaMedioPagoBusiness.ConsultarPorFactura(facturaModificada.IdFactura);

                using FormItemsFacturaModificar formItems = new FormItemsFacturaModificar(facturaModificada, itemsOriginales);

                if (formItems.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                List<FacturaItem> itemsFinales = formItems.ItemsFactura;
                bool clienteCambio = facturaModificada.Cliente.Id != this.facturaSeleccionada.Cliente.Id;
                bool itemsCambiaron = formItems.HuboCambios;

                if (!clienteCambio && !itemsCambiaron)
                {
                    throw new Exception("No se modifico ningun dato.");
                }

                facturaModificada.Total = itemsFinales.Sum(item => item.Subtotal);

                List<FacturaMedioPago> pagosFinales = pagosOriginales;

                if (itemsCambiaron)
                {
                    pagosFinales = new List<FacturaMedioPago>();
                    using FormSeleccionarMetodoPago formPagos = new FormSeleccionarMetodoPago(
                        facturaModificada,
                        itemsFinales,
                        pagosFinales,
                        false
                    );

                    if (formPagos.ShowDialog() != DialogResult.OK)
                    {
                        return;
                    }

                    pagosFinales = formPagos.PagosVenta;
                }

                this.ValidarStockParaEdicion(itemsOriginales, itemsFinales);
                this.ConfirmarModificacionVenta(facturaModificada, itemsOriginales, itemsFinales, pagosFinales, itemsCambiaron);
                this.clienteModificadoSeleccionado = null;
                this.CargarFacturas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Editar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.facturaSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                if (this.facturaSeleccionada.Estado.Equals("Anulada", StringComparison.OrdinalIgnoreCase))
                {
                    throw new Exception("La factura seleccionada ya esta anulada.");
                }

                DialogResult resultado = MessageBox.Show(
                    "¿Está seguro que desea anular la factura seleccionada? Se restaurara el stock de sus items.",
                    "Anular factura",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado != DialogResult.Yes)
                {
                    return;
                }

                this.AnularFactura(this.facturaSeleccionada);
                this.clienteModificadoSeleccionado = null;
                this.CargarFacturas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Anular factura", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.clienteModificadoSeleccionado = null;
            this.LimpiarFacturaSeleccionada();
            dgvFacturas.ClearSelection();
        }

        private void btnSeleccionadoSeleccionarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.facturaSeleccionada == null)
                {
                    throw new Exception("Debe seleccionar una factura.");
                }

                this.ValidarFacturaEditable(this.facturaSeleccionada);

                using FormElegirCliente formElegirCliente = new FormElegirCliente();

                if (formElegirCliente.ShowDialog() == DialogResult.OK
                    && formElegirCliente.ClienteSeleccionado != null)
                {
                    this.clienteModificadoSeleccionado = formElegirCliente.ClienteSeleccionado;
                    Factura facturaVista = this.ClonarFactura(this.facturaSeleccionada);
                    facturaVista.Cliente = this.clienteModificadoSeleccionado;
                    this.MostrarFacturaSeleccionada(facturaVista);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Seleccionar cliente", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAltaSeleccionarCliente_Click(object sender, EventArgs e)
        {
            using FormElegirCliente formElegirCliente = new FormElegirCliente();

            if (formElegirCliente.ShowDialog() == DialogResult.OK
                && formElegirCliente.ClienteSeleccionado != null)
            {
                this.clienteAltaSeleccionado = formElegirCliente.ClienteSeleccionado;
                this.MostrarClienteAltaSeleccionado(this.clienteAltaSeleccionado);
            }
        }

        private void btnCrearFactura_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.clienteAltaSeleccionado == null)
                {
                    throw new Exception("Debe seleccionar un cliente.");
                }

                this.facturaEnCurso = new Factura
                {
                    Cliente = this.clienteAltaSeleccionado,
                    Usuario = SesionActual.Usuario!,
                    FechaEmision = DateTime.Now,
                    Total = 0,
                    Estado = "En curso"
                };

                this.MostrarFacturaEnCurso(this.facturaEnCurso);
                dgvFacturaItems.Rows.Clear();

                using FormItemsFactura formItemsFactura = new FormItemsFactura(this.facturaEnCurso);

                if (formItemsFactura.ShowDialog() == DialogResult.OK)
                {
                    this.facturaEnCurso = null;
                    this.clienteAltaSeleccionado = null;
                    this.LimpiarFacturaAlta();
                    this.CargarFacturas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Iniciar venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? fechaDesde = chkBuscarPorPeriodo.Checked
                    ? dtpBuscarFechaDesde.Value.Date
                    : null;

                DateTime? fechaHasta = chkBuscarPorPeriodo.Checked
                    ? dtpBuscarFechaHasta.Value.Date
                    : null;

                this.CargarFacturas(this.facturaBusiness.BuscarFacturas(
                    txtBuscarIdFactura.Text,
                    txtBuscarIdCliente.Text,
                    txtBuscarDocumentoCliente.Text,
                    txtBuscarNombreCliente.Text,
                    txtBuscarApellidoCliente.Text,
                    fechaDesde,
                    fechaHasta
                ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Buscar factura",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscarIdFactura.Clear();
            txtBuscarIdCliente.Clear();
            txtBuscarDocumentoCliente.Clear();
            txtBuscarNombreCliente.Clear();
            txtBuscarApellidoCliente.Clear();
            chkBuscarPorPeriodo.Checked = false;
            dtpBuscarFechaDesde.Value = DateTime.Today;
            dtpBuscarFechaHasta.Value = DateTime.Today;
            this.CargarFacturas();
        }

        private void ValidarFacturaEditable(Factura factura)
        {
            if (factura.Estado.Equals("Anulada", StringComparison.OrdinalIgnoreCase))
            {
                throw new Exception("No se puede modificar una factura anulada.");
            }
        }
        private void AnularFactura(Factura factura)
        {
            List<FacturaItem> items = this.facturaItemBusiness.ConsultarItemsPorFactura(factura.IdFactura);

            foreach (FacturaItem item in items.Where(item => !item.Estado.Equals("Anulado", StringComparison.OrdinalIgnoreCase)))
            {
                Producto producto = item.Producto;
                producto.StockActual += item.Cantidad;
                this.productoBusiness.ModificarProducto(producto);
                this.facturaItemBusiness.EliminarFacturaItem(item.IdFacturaItem);
                item.Estado = "Anulado";
            }

            factura.Estado = "Anulada";
            this.facturaBusiness.ModificarFactura(factura);
            this.facturaMedioPagoBusiness.AnularPorFactura(factura.IdFactura);

            List<FacturaMedioPago> pagos = this.facturaMedioPagoBusiness.ConsultarFacturasMediosPago()
                .Where(pago => pago.Factura.IdFactura == factura.IdFactura)
                .ToList();
            this.GenerarPdfVenta(factura, items, pagos, "Anulada");
        }
        private void ConfirmarModificacionVenta(
            Factura factura,
            List<FacturaItem> itemsOriginales,
            List<FacturaItem> itemsFinales,
            List<FacturaMedioPago> pagosFinales,
            bool reemplazarItemsYPagos)
        {
            this.facturaBusiness.ModificarFactura(factura);

            if (reemplazarItemsYPagos)
            {
                this.facturaItemBusiness.ReemplazarItemsPorFactura(factura, itemsFinales);
                this.facturaMedioPagoBusiness.ReemplazarPagosPorFactura(factura, pagosFinales);
                this.AplicarDiferenciaStock(itemsOriginales, itemsFinales);
            }

            this.GenerarPdfVenta(factura, itemsFinales, pagosFinales, "Modificada");
        }


        private void GenerarPdfVenta(
            Factura factura,
            List<FacturaItem> items,
            List<FacturaMedioPago> pagos,
            string tipoDocumento)
        {
            try
            {
                FacturaPdfGenerator generador = new FacturaPdfGenerator();
                generador.Generar(factura, items, pagos, tipoDocumento);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "La operacion se confirmo, pero no se pudo generar el PDF. " + ex.Message,
                    "PDF factura",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }
        private void ValidarStockParaEdicion(List<FacturaItem> itemsOriginales, List<FacturaItem> itemsFinales)
        {
            foreach (var grupoFinal in itemsFinales.GroupBy(item => item.Producto.IdProducto))
            {
                Producto producto = grupoFinal.First().Producto;
                int cantidadOriginal = itemsOriginales
                    .Where(item => item.Producto.IdProducto == producto.IdProducto)
                    .Sum(item => item.Cantidad);
                int cantidadFinal = grupoFinal.Sum(item => item.Cantidad);
                int diferencia = cantidadFinal - cantidadOriginal;

                if (diferencia > producto.StockActual)
                {
                    throw new Exception($"La cantidad del producto {producto.Descripcion} supera el stock disponible.");
                }
            }
        }

        private void AplicarDiferenciaStock(List<FacturaItem> itemsOriginales, List<FacturaItem> itemsFinales)
        {
            IEnumerable<int> idsProductos = itemsOriginales
                .Select(item => item.Producto.IdProducto)
                .Union(itemsFinales.Select(item => item.Producto.IdProducto));

            foreach (int idProducto in idsProductos)
            {
                FacturaItem? itemReferencia = itemsFinales.FirstOrDefault(item => item.Producto.IdProducto == idProducto)
                    ?? itemsOriginales.FirstOrDefault(item => item.Producto.IdProducto == idProducto);

                if (itemReferencia == null)
                {
                    continue;
                }

                Producto producto = itemReferencia.Producto;
                int cantidadOriginal = itemsOriginales
                    .Where(item => item.Producto.IdProducto == idProducto)
                    .Sum(item => item.Cantidad);
                int cantidadFinal = itemsFinales
                    .Where(item => item.Producto.IdProducto == idProducto)
                    .Sum(item => item.Cantidad);
                int diferencia = cantidadFinal - cantidadOriginal;

                if (diferencia == 0)
                {
                    continue;
                }

                producto.StockActual -= diferencia;
                this.productoBusiness.ModificarProducto(producto);
            }
        }

        private Factura ClonarFactura(Factura factura)
        {
            return new Factura
            {
                IdFactura = factura.IdFactura,
                Cliente = factura.Cliente,
                Usuario = factura.Usuario,
                FechaEmision = factura.FechaEmision,
                Total = factura.Total,
                Estado = factura.Estado
            };
        }

        private void MostrarClienteAltaSeleccionado(Cliente cliente)
        {
            txtAltaIdCliente.Text = cliente.Id.ToString();
            txtAltaNombreCliente.Text = cliente.Nombre;
            txtAltaApellidoCliente.Text = cliente.Apellido;
            txtAltaDocumentoCliente.Text = cliente.Documento.ToString();
        }

        private void MostrarFacturaEnCurso(Factura factura)
        {
            txtIdFactura.Text = string.Empty;
            txtIdCliente.Text = factura.Cliente.Id.ToString();
            txtNombreCliente.Text = factura.Cliente.Nombre;
            txtApellidoCliente.Text = factura.Cliente.Apellido;
            txtDniCliente.Text = factura.Cliente.Documento.ToString();
            txtUsuario.Text = factura.Usuario.NombreUsuario;
            txtFechaEmision.Text = factura.FechaEmision.ToShortDateString();
            txtEstado.Text = factura.Estado;
            txtTotal.Text = factura.Total.ToString("0.00");
        }

        private void MostrarFacturaSeleccionada(Factura factura)
        {
            txtIdFactura.Text = factura.IdFactura.ToString();
            txtIdCliente.Text = factura.Cliente.Id.ToString();
            txtNombreCliente.Text = factura.Cliente.Nombre;
            txtApellidoCliente.Text = factura.Cliente.Apellido;
            txtDniCliente.Text = factura.Cliente.Documento.ToString();
            txtUsuario.Text = factura.Usuario.NombreUsuario;
            txtFechaEmision.Text = factura.FechaEmision.ToShortDateString();
            txtEstado.Text = factura.Estado;
            txtTotal.Text = factura.Total.ToString("0.00");
        }

        private void MostrarFacturaDesdeFila(DataGridViewRow fila)
        {
            if (fila.Tag is not Factura factura)
            {
                this.LimpiarFacturaSeleccionada();
                return;
            }

            this.facturaSeleccionada = factura;
            this.clienteModificadoSeleccionado = null;
            this.MostrarFacturaSeleccionada(factura);
            this.CargarItemsFactura(factura);
        }

        private void CargarItemsFactura(Factura factura)
        {
            try
            {
                dgvFacturaItems.Rows.Clear();

                List<FacturaItem> items = this.facturaItemBusiness.ConsultarItemsPorFactura(factura.IdFactura);

                foreach (FacturaItem item in items)
                {
                    int indiceFila = dgvFacturaItems.Rows.Add(
                        item.IdFacturaItem,
                        item.Producto.IdProducto,
                        item.Producto.Descripcion,
                        item.Cantidad,
                        item.PrecioUnitario.ToString("0.00"),
                        item.Subtotal.ToString("0.00"),
                        item.Estado
                    );

                    dgvFacturaItems.Rows[indiceFila].Tag = item;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los items de la factura. " + ex.Message,
                    "Registrar venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void LimpiarFacturaSeleccionada()
        {
            this.facturaSeleccionada = null;
            this.clienteModificadoSeleccionado = null;
            txtIdFactura.Clear();
            txtIdCliente.Clear();
            txtNombreCliente.Clear();
            txtApellidoCliente.Clear();
            txtDniCliente.Clear();
            txtUsuario.Clear();
            txtFechaEmision.Clear();
            txtEstado.Clear();
            txtTotal.Clear();
            dgvFacturaItems.Rows.Clear();
        }

        private void LimpiarFacturaAlta()
        {
            this.LimpiarFacturaSeleccionada();
            txtAltaIdCliente.Clear();
            txtAltaNombreCliente.Clear();
            txtAltaApellidoCliente.Clear();
            txtAltaDocumentoCliente.Clear();
        }
    }
}






