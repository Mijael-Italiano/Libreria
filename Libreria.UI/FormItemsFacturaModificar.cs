using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Libreria.Entity;

namespace Libreria.UI
{
    public partial class FormItemsFacturaModificar : Form
    {
        private readonly Factura factura;
        private readonly List<FacturaItem> itemsOriginales;
        private readonly List<FacturaItem> itemsFactura;
        private Producto? productoSeleccionado;
        private FacturaItem? itemSeleccionado;

        public FormItemsFacturaModificar()
        {
            InitializeComponent();
            this.factura = new Factura();
            this.itemsOriginales = new List<FacturaItem>();
            this.itemsFactura = new List<FacturaItem>();
            this.ConectarEventos();
            this.ActualizarResumenVenta();
        }

        public FormItemsFacturaModificar(Factura factura, List<FacturaItem> items)
            : this()
        {
            this.factura = factura ?? throw new ArgumentNullException(nameof(factura));
            this.itemsOriginales = this.ClonarItems(items ?? new List<FacturaItem>());
            this.itemsFactura = this.ClonarItems(items ?? new List<FacturaItem>());
            this.CargarItems();
            this.ActualizarResumenVenta();
        }

        public List<FacturaItem> ItemsFactura => this.itemsFactura;
        public bool HuboCambios { get; private set; }

        private void ConectarEventos()
        {
            btnBuscarProducto.Click += btnBuscarProducto_Click;
            btnLimpiarAlta.Click += btnLimpiarAlta_Click;
            btnModificarItem.Click += btnModificarItem_Click;
            btnEliminarItem.Click += btnEliminarItem_Click;
            btnLimpiarSeleccion.Click += btnLimpiarSeleccion_Click;
            btnConfirmarVenta.Click += btnConfirmarVenta_Click;
            btnCancelar.Click += btnCancelar_Click;
            dgvFacturaItems.SelectionChanged += dgvFacturaItems_SelectionChanged;
        }

        private void btnBuscarProducto_Click(object? sender, EventArgs e)
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
                if (this.productoSeleccionado == null)
                {
                    throw new Exception("Debe seleccionar un producto.");
                }

                if (!int.TryParse(txtAltaCantidad.Text, out int cantidad))
                {
                    throw new Exception("Debe ingresar una cantidad valida.");
                }

                this.ValidarProductoNoRepetido(this.productoSeleccionado);
                this.ValidarCantidadDisponible(this.productoSeleccionado, cantidad, null);

                FacturaItem item = new FacturaItem
                {
                    Factura = this.factura,
                    Producto = this.productoSeleccionado,
                    Cantidad = cantidad,
                    PrecioUnitario = this.productoSeleccionado.PrecioUnitario,
                    Subtotal = cantidad * this.productoSeleccionado.PrecioUnitario,
                    Estado = "Emitido"
                };

                this.itemsFactura.Add(item);
                this.CargarItems();
                this.ActualizarResumenVenta();
                this.SeleccionarItem(item);
                this.LimpiarAlta();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Agregar item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarAlta_Click(object? sender, EventArgs e)
        {
            this.LimpiarAlta();
        }

        private void dgvFacturaItems_SelectionChanged(object? sender, EventArgs e)
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

        private void btnModificarItem_Click(object? sender, EventArgs e)
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

                this.ValidarCantidadDisponible(this.itemSeleccionado.Producto, cantidad, this.itemSeleccionado);
                this.itemSeleccionado.Cantidad = cantidad;
                this.itemSeleccionado.PrecioUnitario = this.itemSeleccionado.Producto.PrecioUnitario;
                this.itemSeleccionado.Subtotal = cantidad * this.itemSeleccionado.PrecioUnitario;
                this.itemSeleccionado.Estado = "Emitido";

                this.CargarItems();
                this.ActualizarResumenVenta();
                this.SeleccionarItem(this.itemSeleccionado);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Modificar item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarItem_Click(object? sender, EventArgs e)
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
                MessageBox.Show(ex.Message, "Eliminar item", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiarSeleccion_Click(object? sender, EventArgs e)
        {
            this.LimpiarSeleccion();
            dgvFacturaItems.ClearSelection();
        }

        private void btnConfirmarVenta_Click(object? sender, EventArgs e)
        {
            try
            {
                if (this.itemsFactura.Count == 0)
                {
                    throw new Exception("Debe ingresar al menos un item.");
                }

                this.HuboCambios = this.ItemsTienenCambios();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Confirmar venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void CargarItems()
        {
            dgvFacturaItems.Rows.Clear();

            foreach (FacturaItem item in this.itemsFactura)
            {
                int indiceFila = dgvFacturaItems.Rows.Add(
                    this.ObtenerNumeroItem(item),
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

        private void MostrarProductoAlta(Producto producto)
        {
            txtAltaIdProducto.Text = producto.IdProducto.ToString();
            txtAltaDescripcion.Text = producto.Descripcion;
            txtAltaMarca.Text = producto.Marca?.Nombre ?? string.Empty;
            txtAltaCategoria.Text = producto.Categoria?.Nombre ?? string.Empty;
            txtAltaStockActual.Text = producto.StockActual.ToString();
            txtAltaPrecioUnitario.Text = producto.PrecioUnitario.ToString("0.00");
        }

        private void ActualizarResumenVenta()
        {
            decimal total = this.itemsFactura.Sum(item => item.Subtotal);
            txtIdFactura.Text = this.factura.IdFactura > 0 ? this.factura.IdFactura.ToString() : string.Empty;
            txtEstadoFactura.Text = this.factura.Estado;
            txtCantidadItems.Text = this.itemsFactura.Count.ToString();
            txtTotalVenta.Text = total.ToString("0.00");
        }

        private void ValidarProductoNoRepetido(Producto producto)
        {
            bool productoYaAgregado = this.itemsFactura.Any(item => item.Producto.IdProducto == producto.IdProducto);

            if (productoYaAgregado)
            {
                throw new Exception("El producto ya fue agregado. Modifique la cantidad del item existente.");
            }
        }

        private void ValidarCantidadDisponible(Producto producto, int cantidad, FacturaItem? itemActual)
        {
            if (cantidad <= 0)
            {
                throw new Exception("Debe ingresar una cantidad mayor a cero.");
            }

            int cantidadOriginal = this.ObtenerCantidadOriginal(producto.IdProducto);
            int cantidadActualMismoProducto = itemActual?.Producto.IdProducto == producto.IdProducto ? itemActual.Cantidad : 0;
            int cantidadUsadaPorOtrosItems = this.itemsFactura
                .Where(item => !ReferenceEquals(item, itemActual) && item.Producto.IdProducto == producto.IdProducto)
                .Sum(item => item.Cantidad);
            int disponible = producto.StockActual + cantidadOriginal + cantidadActualMismoProducto - cantidadUsadaPorOtrosItems;

            if (cantidad > disponible)
            {
                throw new Exception("La cantidad ingresada supera el stock disponible.");
            }
        }

        private int ObtenerCantidadOriginal(int idProducto)
        {
            return this.itemsOriginales
                .Where(item => item.Producto.IdProducto == idProducto)
                .Sum(item => item.Cantidad);
        }

        private int ObtenerStockDisponibleParaItem(FacturaItem item)
        {
            return item.Producto.StockActual + this.ObtenerCantidadOriginal(item.Producto.IdProducto);
        }

        private bool ItemsTienenCambios()
        {
            if (this.itemsOriginales.Count != this.itemsFactura.Count)
            {
                return true;
            }

            var originales = this.itemsOriginales
                .OrderBy(item => item.Producto.IdProducto)
                .Select(item => new { item.Producto.IdProducto, item.Cantidad, item.PrecioUnitario })
                .ToList();

            var actuales = this.itemsFactura
                .OrderBy(item => item.Producto.IdProducto)
                .Select(item => new { item.Producto.IdProducto, item.Cantidad, item.PrecioUnitario })
                .ToList();

            for (int indice = 0; indice < originales.Count; indice++)
            {
                if (originales[indice].IdProducto != actuales[indice].IdProducto
                    || originales[indice].Cantidad != actuales[indice].Cantidad
                    || originales[indice].PrecioUnitario != actuales[indice].PrecioUnitario)
                {
                    return true;
                }
            }

            return false;
        }

        private int ObtenerNumeroItem(FacturaItem item)
        {
            int indice = this.itemsFactura.IndexOf(item);
            return indice >= 0 ? indice + 1 : 0;
        }

        private List<FacturaItem> ClonarItems(List<FacturaItem> items)
        {
            return items.Select(item => new FacturaItem
            {
                IdFacturaItem = item.IdFacturaItem,
                Factura = this.factura,
                Producto = item.Producto,
                Cantidad = item.Cantidad,
                PrecioUnitario = item.PrecioUnitario,
                Subtotal = item.Subtotal,
                Estado = item.Estado
            }).ToList();
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
    }
}

