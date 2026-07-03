using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Libreria.Business;
using Libreria.Entity;

namespace Libreria.UI
{
    public partial class FormInventario : Form
    {
        private readonly ProductoBusiness productoBusiness;

        public FormInventario()
        {
            InitializeComponent();
            this.productoBusiness = new ProductoBusiness();
            this.CargarProductos();
        }

        private void btnBuscarInventario_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarProductos(this.ObtenerProductosSegunBusqueda());
                dgvInventario.ClearSelection();
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

        private void btnLimpiarBusquedaInventario_Click(object sender, EventArgs e)
        {
            txtBuscarIdProducto.Clear();
            txtBuscarIdMarca.Clear();
            txtBuscarMarca.Clear();
            txtBuscarIdCategoria.Clear();
            txtBuscarCategoria.Clear();
            txtBuscarIdColor.Clear();
            txtBuscarColor.Clear();
            this.CargarProductos();
            dgvInventario.ClearSelection();
        }

        private void btnBusquedaSeleccionarMarca_Click(object sender, EventArgs e)
        {
            this.SeleccionarMarcaEnCampos(txtBuscarIdMarca, txtBuscarMarca);
        }

        private void btnBusquedaSeleccionarCategoria_Click(object sender, EventArgs e)
        {
            this.SeleccionarCategoriaEnCampos(txtBuscarIdCategoria, txtBuscarCategoria);
        }

        private void btnBusquedaSeleccionarColor_Click(object sender, EventArgs e)
        {
            this.SeleccionarColorEnCampos(txtBuscarIdColor, txtBuscarColor);
        }

        private void CargarProductos(List<Producto>? productos = null)
        {
            try
            {
                dgvInventario.Rows.Clear();

                productos ??= this.productoBusiness.BuscarProductos(
                    string.Empty,
                    null,
                    null,
                    null,
                    false
                );

                foreach (Producto producto in productos)
                {
                    int indiceFila = dgvInventario.Rows.Add(
                        producto.IdProducto,
                        producto.Marca?.Nombre ?? string.Empty,
                        producto.Categoria?.Nombre ?? string.Empty,
                        producto.Color?.Nombre ?? string.Empty,
                        producto.Descripcion,
                        producto.PrecioUnitario,
                        producto.StockActual,
                        producto.StockMinimo,
                        producto.FechaAlta,
                        producto.FechaUltimaActualizacion,
                        producto.Estado
                    );

                    dgvInventario.Rows[indiceFila].Tag = producto;
                    this.AplicarEstiloStock(dgvInventario.Rows[indiceFila], producto);
                }

                dgvInventario.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los productos. " + ex.Message,
                    "Inventario",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void AplicarEstiloStock(DataGridViewRow fila, Producto producto)
        {
            if (producto.StockActual >= producto.StockMinimo)
            {
                return;
            }

            fila.DefaultCellStyle.BackColor = Color.MistyRose;
            fila.DefaultCellStyle.ForeColor = Color.DarkRed;
            fila.DefaultCellStyle.SelectionBackColor = Color.IndianRed;
            fila.DefaultCellStyle.SelectionForeColor = Color.White;
        }
        private List<Producto> ObtenerProductosSegunBusqueda()
        {
            return this.productoBusiness.BuscarProductos(
                txtBuscarIdProducto.Text,
                this.ObtenerIdOpcional(txtBuscarIdMarca.Text),
                this.ObtenerIdOpcional(txtBuscarIdCategoria.Text),
                this.ObtenerIdOpcional(txtBuscarIdColor.Text),
                false
            );
        }

        private int? ObtenerIdOpcional(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return null;
            }

            if (!int.TryParse(valor, out int id) || id <= 0)
            {
                throw new Exception("Debe ingresar un id valido.");
            }

            return id;
        }

        private void SeleccionarMarcaEnCampos(TextBox txtIdDestino, TextBox txtNombreDestino)
        {
            using FormElegirMarca form = new FormElegirMarca();

            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (form.SinMarcaSeleccionada || form.MarcaSeleccionada == null)
            {
                txtIdDestino.Clear();
                txtNombreDestino.Clear();
                return;
            }

            txtIdDestino.Text = form.MarcaSeleccionada.Id.ToString();
            txtNombreDestino.Text = form.MarcaSeleccionada.Nombre;
        }

        private void SeleccionarCategoriaEnCampos(TextBox txtIdDestino, TextBox txtNombreDestino)
        {
            using FormElegirCategoria form = new FormElegirCategoria();

            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (form.SinCategoriaSeleccionada || form.CategoriaSeleccionada == null)
            {
                txtIdDestino.Clear();
                txtNombreDestino.Clear();
                return;
            }

            txtIdDestino.Text = form.CategoriaSeleccionada.Id.ToString();
            txtNombreDestino.Text = form.CategoriaSeleccionada.Nombre;
        }

        private void SeleccionarColorEnCampos(TextBox txtIdDestino, TextBox txtNombreDestino)
        {
            using FormElegirColor form = new FormElegirColor();

            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (form.SinColorSeleccionado || form.ColorSeleccionado == null)
            {
                txtIdDestino.Clear();
                txtNombreDestino.Clear();
                return;
            }

            txtIdDestino.Text = form.ColorSeleccionado.Id.ToString();
            txtNombreDestino.Text = form.ColorSeleccionado.Nombre;
        }
    }
}
