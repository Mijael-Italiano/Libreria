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
    public partial class FormElegirProducto : Form
    {
        private readonly ProductoBusiness productoBusiness;
        public Producto? ProductoSeleccionado { get; private set; }

        public FormElegirProducto()
        {
            InitializeComponent();
            this.productoBusiness = new ProductoBusiness();
            dgvProductos.SelectionChanged += dgvProductos_SelectionChanged;
            this.Load += FormElegirProducto_Load;
        }

        private void FormElegirProducto_Load(object? sender, EventArgs e)
        {
            this.CargarProductos();
        }

        private void CargarProductos(List<Producto>? productos = null)
        {
            try
            {
                dgvProductos.Rows.Clear();

                productos ??= this.productoBusiness.BuscarProductos(
                    string.Empty,
                    null,
                    null,
                    null,
                    false
                );

                foreach (Producto producto in productos)
                {
                    int indiceFila = dgvProductos.Rows.Add(
                        producto.IdProducto,
                        producto.Descripcion,
                        producto.Marca?.Nombre ?? string.Empty,
                        producto.Categoria?.Nombre ?? string.Empty,
                        producto.Color?.Nombre ?? string.Empty,
                        producto.PrecioUnitario.ToString("0.00"),
                        producto.StockActual
                    );

                    dgvProductos.Rows[indiceFila].Tag = producto;
                }

                this.SeleccionarPrimerProducto();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los productos. " + ex.Message,
                    "Elegir producto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvProductos_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvProductos.SelectedRows[0].Tag is Producto producto)
            {
                this.MostrarProductoSeleccionado(producto);
            }
        }

        private void MostrarProductoSeleccionado(Producto producto)
        {
            txtIdProducto.Text = producto.IdProducto.ToString();
            txtDescripcion.Text = producto.Descripcion;
            txtMarca.Text = producto.Marca?.Nombre ?? string.Empty;
            txtCategoria.Text = producto.Categoria?.Nombre ?? string.Empty;
            txtColor.Text = producto.Color?.Nombre ?? string.Empty;
            txtPrecioUnitario.Text = producto.PrecioUnitario.ToString("0.00");
            txtStockActual.Text = producto.StockActual.ToString();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ProductoSeleccionado = this.ObtenerProductoSeleccionado();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Elegir producto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarProductos(this.productoBusiness.BuscarProductos(
                    txtBuscarIdProducto.Text,
                    null,
                    null,
                    null,
                    false
                ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Buscar producto",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscarIdProducto.Clear();
            this.CargarProductos();
        }

        private void SeleccionarPrimerProducto()
        {
            if (dgvProductos.Rows.Count == 0)
            {
                this.LimpiarCampos();
                return;
            }

            dgvProductos.ClearSelection();
            dgvProductos.Rows[0].Selected = true;

            if (dgvProductos.Rows[0].Tag is Producto producto)
            {
                this.MostrarProductoSeleccionado(producto);
            }
        }

        private Producto ObtenerProductoSeleccionado()
        {
            if (dgvProductos.SelectedRows.Count > 0
                && dgvProductos.SelectedRows[0].Tag is Producto producto)
            {
                return producto;
            }

            throw new Exception("Debe seleccionar un producto.");
        }

        private void LimpiarCampos()
        {
            txtIdProducto.Clear();
            txtDescripcion.Clear();
            txtMarca.Clear();
            txtCategoria.Clear();
            txtColor.Clear();
            txtPrecioUnitario.Clear();
            txtStockActual.Clear();
        }
    }
}


