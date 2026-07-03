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

namespace Libreria.UI
{
    public partial class FormSeleccionarMetodoPago : Form
    {
        private readonly FacturaBusiness facturaBusiness;
        private readonly ProductoBusiness productoBusiness;
        private readonly MedioPagoBusiness medioPagoBusiness;
        private readonly FacturaItemBusiness facturaItemBusiness;
        private readonly FacturaMedioPagoBusiness facturaMedioPagoBusiness;
        private readonly List<FacturaMedioPago> pagosVenta;
        private readonly List<FacturaItem> itemsVenta;
        private Factura? facturaEnCurso;
        private MedioPago? medioPagoSeleccionado;
        private FacturaMedioPago? pagoSeleccionado;
        private bool persistirAlConfirmar;

        public FormSeleccionarMetodoPago()
        {
            InitializeComponent();
            this.facturaBusiness = new FacturaBusiness();
            this.productoBusiness = new ProductoBusiness();
            this.medioPagoBusiness = new MedioPagoBusiness();
            this.facturaItemBusiness = new FacturaItemBusiness();
            this.facturaMedioPagoBusiness = new FacturaMedioPagoBusiness();
            this.pagosVenta = new List<FacturaMedioPago>();
            this.itemsVenta = new List<FacturaItem>();
            this.persistirAlConfirmar = true;
            this.Load += FormSeleccionarMetodoPago_Load;
        }

        public FormSeleccionarMetodoPago(Factura factura)
            : this()
        {
            this.facturaEnCurso = factura;
        }

        public FormSeleccionarMetodoPago(Factura factura, List<FacturaItem> itemsVenta)
            : this()
        {
            this.facturaEnCurso = factura;
            this.itemsVenta = itemsVenta ?? new List<FacturaItem>();
        }


        public FormSeleccionarMetodoPago(
            Factura factura,
            List<FacturaItem> itemsVenta,
            List<FacturaMedioPago> pagosIniciales,
            bool persistirAlConfirmar)
            : this(factura, itemsVenta)
        {
            this.persistirAlConfirmar = persistirAlConfirmar;

            foreach (FacturaMedioPago pago in pagosIniciales ?? new List<FacturaMedioPago>())
            {
                this.pagosVenta.Add(new FacturaMedioPago
                {
                    Factura = factura,
                    MedioPago = pago.MedioPago,
                    Monto = pago.Monto,
                    Estado = "Activo"
                });
            }
        }
        public List<FacturaMedioPago> PagosVenta => this.pagosVenta;

        private void FormSeleccionarMetodoPago_Load(object? sender, EventArgs e)
        {
            this.CargarMediosPago();
            this.CargarPagosVenta();
            this.ActualizarResumenPago();
        }

        private void dgvMediosPago_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMediosPago.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvMediosPago.SelectedRows[0].Tag is MedioPago medioPago)
            {
                this.medioPagoSeleccionado = medioPago;
                this.MostrarMedioPagoParaAgregar(medioPago);
            }
        }

        private void dgvPagosVenta_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPagosVenta.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvPagosVenta.SelectedRows[0].Tag is FacturaMedioPago pago)
            {
                this.pagoSeleccionado = pago;
                this.MostrarPagoSeleccionado(pago);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarMediosPago(this.medioPagoBusiness.BuscarMediosPago(txtBuscarNombre.Text, false));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Buscar medio de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            this.CargarMediosPago();
        }

        private void btnAgregarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.facturaEnCurso == null)
                {
                    throw new Exception("Debe iniciar una venta.");
                }

                if (this.medioPagoSeleccionado == null)
                {
                    throw new Exception("Debe seleccionar un medio de pago.");
                }

                decimal monto = this.ObtenerMontoParaAgregar();

                FacturaMedioPago pago = this.facturaMedioPagoBusiness.CrearPagoEnMemoria(
                    this.facturaEnCurso,
                    this.medioPagoSeleccionado,
                    monto,
                    this.pagosVenta
                );

                this.pagosVenta.Add(pago);
                this.CargarPagosVenta();
                this.ActualizarResumenPago();
                this.SeleccionarPago(pago);
                this.LimpiarPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Agregar pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiarPago_Click(object sender, EventArgs e)
        {
            this.LimpiarPago();
            dgvMediosPago.ClearSelection();
        }

        private void btnModificarMonto_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.facturaEnCurso == null)
                {
                    throw new Exception("Debe iniciar una venta.");
                }

                if (this.pagoSeleccionado == null)
                {
                    throw new Exception("Debe seleccionar un pago.");
                }

                if (!decimal.TryParse(txtMontoSeleccionado.Text, out decimal monto))
                {
                    throw new Exception("Debe ingresar un monto valido.");
                }

                this.facturaMedioPagoBusiness.ModificarPagoEnMemoria(
                    this.facturaEnCurso,
                    this.pagoSeleccionado,
                    monto,
                    this.pagosVenta
                );

                this.CargarPagosVenta();
                this.ActualizarResumenPago();
                this.SeleccionarPago(this.pagoSeleccionado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Modificar pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.pagoSeleccionado == null)
                {
                    throw new Exception("Debe seleccionar un pago.");
                }

                this.pagosVenta.Remove(this.pagoSeleccionado);
                this.pagoSeleccionado = null;
                this.CargarPagosVenta();
                this.ActualizarResumenPago();
                this.LimpiarSeleccion();
                dgvPagosVenta.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Eliminar pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiarSeleccion_Click(object sender, EventArgs e)
        {
            this.LimpiarSeleccion();
            dgvPagosVenta.ClearSelection();
        }

        private void btnConfirmarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.facturaEnCurso == null)
                {
                    throw new Exception("Debe iniciar una venta.");
                }

                this.facturaMedioPagoBusiness.ValidarPagosCompletos(
                    this.facturaEnCurso,
                    this.pagosVenta
                );

                if (this.persistirAlConfirmar)
                {
                    this.RegistrarVentaFisica();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Confirmar pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea cancelar el pago?",
                "Cancelar pago",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void chkAgregarRestante_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAgregarRestante.Checked)
            {
                txtMonto.Text = this.ObtenerSaldoPendiente().ToString("0.00");
                txtMonto.ReadOnly = true;
                return;
            }

            txtMonto.ReadOnly = false;
            txtMonto.Clear();
        }

        private void CargarMediosPago(List<MedioPago>? mediosPago = null)
        {
            try
            {
                dgvMediosPago.Rows.Clear();

                mediosPago ??= this.medioPagoBusiness.BuscarMediosPago(string.Empty, false);

                foreach (MedioPago medioPago in mediosPago)
                {
                    int indiceFila = dgvMediosPago.Rows.Add(
                        medioPago.IdMedioPago,
                        medioPago.Nombre,
                        medioPago.Estado
                    );

                    dgvMediosPago.Rows[indiceFila].Tag = medioPago;
                }

                this.SeleccionarPrimerMedioPago();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los medios de pago. " + ex.Message,
                    "Seleccionar metodo de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SeleccionarPrimerMedioPago()
        {
            if (dgvMediosPago.Rows.Count == 0)
            {
                this.LimpiarPago();
                return;
            }

            dgvMediosPago.ClearSelection();
            dgvMediosPago.Rows[0].Selected = true;

            if (dgvMediosPago.Rows[0].Tag is MedioPago medioPago)
            {
                this.medioPagoSeleccionado = medioPago;
                this.MostrarMedioPagoParaAgregar(medioPago);
            }
        }
        private void CargarPagosVenta()
        {
            dgvPagosVenta.Rows.Clear();

            foreach (FacturaMedioPago pago in this.pagosVenta)
            {
                int indiceFila = dgvPagosVenta.Rows.Add(
                    pago.MedioPago.IdMedioPago,
                    pago.MedioPago.Nombre,
                    pago.Monto.ToString("0.00")
                );

                dgvPagosVenta.Rows[indiceFila].Tag = pago;
            }
        }

        private decimal ObtenerMontoParaAgregar()
        {
            if (chkAgregarRestante.Checked)
            {
                return this.ObtenerSaldoPendiente();
            }

            if (!decimal.TryParse(txtMonto.Text, out decimal monto))
            {
                throw new Exception("Debe ingresar un monto valido.");
            }

            return monto;
        }

        private void MostrarMedioPagoParaAgregar(MedioPago medioPago)
        {
            txtIdMedioPago.Text = medioPago.IdMedioPago.ToString();
            txtNombreMedioPago.Text = medioPago.Nombre;
        }

        private void MostrarPagoSeleccionado(FacturaMedioPago pago)
        {
            txtIdMedioPagoSeleccionado.Text = pago.MedioPago.IdMedioPago.ToString();
            txtNombreMedioPagoSeleccionado.Text = pago.MedioPago.Nombre;
            txtMontoSeleccionado.Text = pago.Monto.ToString("0.00");
        }

        private void SeleccionarPago(FacturaMedioPago pago)
        {
            int indice = this.pagosVenta.IndexOf(pago);

            if (indice < 0 || indice >= dgvPagosVenta.Rows.Count)
            {
                return;
            }

            dgvPagosVenta.ClearSelection();
            dgvPagosVenta.Rows[indice].Selected = true;
            this.pagoSeleccionado = pago;
            this.MostrarPagoSeleccionado(pago);
        }

        private void ActualizarResumenPago()
        {
            decimal totalPagar = this.facturaEnCurso?.Total ?? 0;
            decimal totalAsignado = this.pagosVenta.Sum(pago => pago.Monto);
            decimal saldoPendiente = totalPagar - totalAsignado;

            txtTotalPagar.Text = totalPagar.ToString("0.00");
            txtTotalAsignado.Text = totalAsignado.ToString("0.00");
            txtSaldoPendiente.Text = saldoPendiente.ToString("0.00");
        }

        private decimal ObtenerSaldoPendiente()
        {
            decimal totalPagar = this.facturaEnCurso?.Total ?? 0;
            decimal totalAsignado = this.pagosVenta.Sum(pago => pago.Monto);
            return totalPagar - totalAsignado;
        }

        private void RegistrarVentaFisica()
        {
            if (this.facturaEnCurso == null)
            {
                throw new Exception("Debe iniciar una venta.");
            }

            if (this.itemsVenta.Count == 0)
            {
                throw new Exception("Debe ingresar al menos un item.");
            }

            int nuevoIdFactura = this.facturaBusiness.ObtenerProximoId();
            this.facturaEnCurso.IdFactura = nuevoIdFactura;
            this.facturaEnCurso.Estado = "Emitida";
            this.facturaBusiness.AltaFactura(this.facturaEnCurso);

            foreach (FacturaItem item in this.itemsVenta)
            {
                item.Factura = this.facturaEnCurso;
                item.Estado = "Emitido";
                this.facturaItemBusiness.AltaFacturaItem(item);
            }

            foreach (FacturaMedioPago pago in this.pagosVenta)
            {
                pago.Factura = this.facturaEnCurso;
                pago.Estado = "Activo";
                this.facturaMedioPagoBusiness.AltaFacturaMedioPago(pago);
            }

            foreach (FacturaItem item in this.itemsVenta)
            {
                Producto producto = item.Producto;
                producto.StockActual -= item.Cantidad;
                this.productoBusiness.ModificarProducto(producto);
            }

            this.GenerarPdfVenta("Emitida");
        }


        private void GenerarPdfVenta(string tipoDocumento)
        {
            try
            {
                if (this.facturaEnCurso == null)
                {
                    return;
                }

                FacturaPdfGenerator generador = new FacturaPdfGenerator();
                generador.Generar(this.facturaEnCurso, this.itemsVenta, this.pagosVenta, tipoDocumento);
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
        private void LimpiarPago()
        {
            this.medioPagoSeleccionado = null;
            txtIdMedioPago.Clear();
            txtNombreMedioPago.Clear();
            txtMonto.Clear();
            chkAgregarRestante.Checked = false;
            txtMonto.ReadOnly = false;
        }

        private void LimpiarSeleccion()
        {
            this.pagoSeleccionado = null;
            txtIdMedioPagoSeleccionado.Clear();
            txtNombreMedioPagoSeleccionado.Clear();
            txtMontoSeleccionado.Clear();
        }
    }
}







