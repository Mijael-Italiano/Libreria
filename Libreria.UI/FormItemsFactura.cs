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
using Libreria.Entity;

namespace Libreria.UI
{
    public partial class FormItemsFactura : Form
    {
        private readonly FacturaItemBusiness facturaItemBusiness;
        private readonly List<FacturaItem> itemsFactura;
        private Factura? facturaEnCurso;
        private Producto? productoSeleccionado;
        private FacturaItem? itemSeleccionado;

        public FormItemsFactura()
        {
            InitializeComponent();
            this.facturaItemBusiness = new FacturaItemBusiness();
            this.itemsFactura = new List<FacturaItem>();
            this.ActualizarResumenVenta();
        }

        public FormItemsFactura(Factura factura)
            : this()
        {
            this.facturaEnCurso = factura;
        }

        public List<FacturaItem> ItemsFactura => this.itemsFactura;

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using FormElegirProducto formElegirProducto = new FormElegirProducto();

            if (formElegirProducto.ShowDialog() == DialogResult.OK
                && formElegirProducto.ProductoSeleccionado != null)
            {
                this.productoSeleccionado = formElegirProducto.ProductoSeleccionado;
                this.MostrarProductoAlta(this.productoSeleccionado);
                txtAltaCantidad.Clear();
                txtAltaSubtotal.Clear();
            }
        }

        private void btnAgregarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.facturaEnCurso == null)
                {
                    throw new Exception("Debe iniciar una venta.");
                }

                if (this.productoSeleccionado == null)
                {
                    throw new Exception("Debe seleccionar un producto.");
                }

                if (!int.TryParse(txtAltaCantidad.Text, out int cantidad))
                {
                    throw new Exception("Debe ingresar una cantidad valida.");
                }

                FacturaItem item = this.facturaItemBusiness.CrearItemEnMemoria(
                    this.facturaEnCurso,
                    this.productoSeleccionado,
                    cantidad,
                    this.itemsFactura
                );

                this.itemsFactura.Add(item);
                this.CargarItems();
                this.ActualizarResumenVenta();
                this.SeleccionarItem(item);
                this.LimpiarAlta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Agregar item",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiarAlta_Click(object sender, EventArgs e)
        {
            this.LimpiarAlta();
        }

        private void dgvFacturaItems_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFacturaItems.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvFacturaItems.SelectedRows[0].Tag is FacturaItem item)
            {
                this.itemSeleccionado = item;
                this.MostrarItemSeleccionado(item);
            }
        }

        private void btnModificarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.itemSeleccionado == null)
                {
                    throw new Exception("Debe seleccionar un item.");
                }

                if (!int.TryParse(txtCantidad.Text, out int cantidad))
                {
                    throw new Exception("Debe ingresar una cantidad valida.");
                }

                this.facturaItemBusiness.ModificarItemEnMemoria(this.itemSeleccionado, cantidad);
                this.CargarItems();
                this.ActualizarResumenVenta();
                this.MostrarItemSeleccionado(this.itemSeleccionado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Modificar item",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminarItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.itemSeleccionado == null)
                {
                    throw new Exception("Debe seleccionar un item.");
                }

                this.itemsFactura.Remove(this.itemSeleccionado);
                this.itemSeleccionado = null;
                this.CargarItems();
                this.ActualizarResumenVenta();
                this.LimpiarSeleccion();
                dgvFacturaItems.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Eliminar item",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiarSeleccion_Click(object sender, EventArgs e)
        {
            this.LimpiarSeleccion();
            dgvFacturaItems.ClearSelection();
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.facturaEnCurso == null)
                {
                    throw new Exception("Debe iniciar una venta.");
                }

                if (this.itemsFactura.Count == 0)
                {
                    throw new Exception("Debe agregar al menos un item.");
                }

                if (this.facturaEnCurso.Total <= 0)
                {
                    throw new Exception("El total de la venta debe ser mayor a cero.");
                }

                using FormSeleccionarMetodoPago formSeleccionarMetodoPago = new FormSeleccionarMetodoPago(this.facturaEnCurso, this.itemsFactura);

                if (formSeleccionarMetodoPago.ShowDialog() == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Confirmar venta",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea cancelar la venta?",
                "Cancelar venta",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void MostrarItemSeleccionado(FacturaItem item)
        {
            txtIdFacturaItem.Text = this.ObtenerNumeroItem(item).ToString();
            txtIdProducto.Text = item.Producto.IdProducto.ToString();
            txtDescripcion.Text = item.Producto.Descripcion;
            txtMarca.Text = item.Producto.Marca?.Nombre ?? string.Empty;
            txtCategoria.Text = item.Producto.Categoria?.Nombre ?? string.Empty;
            txtStockActual.Text = item.Producto.StockActual.ToString();
            txtPrecioUnitario.Text = item.PrecioUnitario.ToString("0.00");
            txtCantidad.Text = item.Cantidad.ToString();
            txtSubtotal.Text = item.Subtotal.ToString("0.00");
            txtEstado.Text = item.Estado;
        }

        private int ObtenerNumeroItem(FacturaItem item)
        {
            int indice = this.itemsFactura.IndexOf(item);
            return indice >= 0 ? indice + 1 : 0;
        }

        private void LimpiarSeleccion()
        {
            this.itemSeleccionado = null;
            txtIdFacturaItem.Clear();
            txtIdProducto.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtCategoria.Clear();
            txtStockActual.Clear();
            txtPrecioUnitario.Clear();
            txtCantidad.Clear();
            txtSubtotal.Clear();
            txtEstado.Clear();
        }

        private void MostrarProductoAlta(Producto producto)
        {
            txtAltaIdProducto.Text = producto.IdProducto.ToString();
            txtAltaDescripcion.Text = producto.Descripcion;
            txtAltaMarca.Text = producto.Marca?.Nombre ?? string.Empty;
            txtAltaCategoria.Text = producto.Categoria?.Nombre ?? string.Empty;
            txtAltaStockActual.Text = producto.StockActual.ToString();
            txtAltaPrecioUnitario.Text = producto.PrecioUnitario.ToString("0.00");
        }

        private void CargarItems()
        {
            dgvFacturaItems.Rows.Clear();

            for (int indice = 0; indice < this.itemsFactura.Count; indice++)
            {
                FacturaItem item = this.itemsFactura[indice];

                int indiceFila = dgvFacturaItems.Rows.Add(
                    indice + 1,
                    item.Producto.IdProducto,
                    item.Producto.Descripcion,
                    item.Producto.Marca?.Nombre ?? string.Empty,
                    item.Producto.Categoria?.Nombre ?? string.Empty,
                    item.Cantidad,
                    item.PrecioUnitario.ToString("0.00"),
                    item.Subtotal.ToString("0.00"),
                    item.Estado
                );

                dgvFacturaItems.Rows[indiceFila].Tag = item;
            }
        }

        private void SeleccionarItem(FacturaItem item)
        {
            int indice = this.itemsFactura.IndexOf(item);

            if (indice < 0 || indice >= dgvFacturaItems.Rows.Count)
            {
                return;
            }

            dgvFacturaItems.ClearSelection();
            dgvFacturaItems.Rows[indice].Selected = true;
            this.itemSeleccionado = item;
            this.MostrarItemSeleccionado(item);
        }

        private void ActualizarResumenVenta()
        {
            decimal total = this.itemsFactura.Sum(item => item.Subtotal);

            if (this.facturaEnCurso != null)
            {
                this.facturaEnCurso.Total = total;
            }

            txtCantidadItems.Text = this.itemsFactura.Count.ToString();
            txtTotalVenta.Text = total.ToString("0.00");
        }

        private void LimpiarAlta()
        {
            this.productoSeleccionado = null;
            txtAltaIdProducto.Clear();
            txtAltaDescripcion.Clear();
            txtAltaMarca.Clear();
            txtAltaCategoria.Clear();
            txtAltaStockActual.Clear();
            txtAltaPrecioUnitario.Clear();
            txtAltaCantidad.Clear();
            txtAltaSubtotal.Clear();
        }
    }
}
