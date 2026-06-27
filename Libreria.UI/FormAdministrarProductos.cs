using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Libreria.Business;
using Libreria.Entity;

namespace Libreria.UI
{
    public partial class FormAdministrarProductos : Form
    {
        private readonly ProductoBusiness productoBusiness;
        private int? idProductoForzarSeleccion;

        public FormAdministrarProductos()
        {
            InitializeComponent();
            this.productoBusiness = new ProductoBusiness();
            chkAltaEstado.Checked = true;
            this.CargarProductos();
        }

        private void btnAltaSeleccionarMarca_Click(object sender, EventArgs e)
        {
            this.SeleccionarMarcaEnCampos(txtAltaIdMarca, txtAltaMarca);
        }

        private void btnAltaSeleccionarCategoria_Click(object sender, EventArgs e)
        {
            this.SeleccionarCategoriaEnCampos(txtAltaIdCategoria, txtAltaCategoria);
        }

        private void btnAltaSeleccionarColor_Click(object sender, EventArgs e)
        {
            this.SeleccionarColorEnCampos(txtAltaIdColor, txtAltaColor);
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = this.ObtenerProductoDesdeCamposAlta();

                this.productoBusiness.AltaProducto(producto);
                this.CargarProductos();
                this.LimpiarCamposAlta();

                MessageBox.Show(
                    "Producto agregado correctamente.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnSeleccionadoSeleccionarMarca_Click(object sender, EventArgs e)
        {
            this.SeleccionarMarcaEnCampos(txtIdMarca, txtMarca);
        }

        private void btnSeleccionadoSeleccionarCategoria_Click(object sender, EventArgs e)
        {
            this.SeleccionarCategoriaEnCampos(txtIdCategoria, txtCategoria);
        }

        private void btnSeleccionadoSeleccionarColor_Click(object sender, EventArgs e)
        {
            this.SeleccionarColorEnCampos(txtIdColor, txtColor);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto producto = this.ObtenerProductoDesdeCamposSeleccionados();
                this.idProductoForzarSeleccion = producto.IdProducto;

                this.productoBusiness.ModificarProducto(producto);
                this.CargarProductos(this.ObtenerProductosSegunBusqueda());

                MessageBox.Show(
                    "Producto modificado correctamente.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idProducto = this.ObtenerIdProductoSeleccionado();

                DialogResult confirmacion = MessageBox.Show(
                    $"Desea dar de baja el producto {txtDescripcion.Text}?",
                    "Productos",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.idProductoForzarSeleccion = idProducto;
                this.productoBusiness.EliminarProducto(idProducto);
                this.CargarProductos(this.ObtenerProductosSegunBusqueda());

                MessageBox.Show(
                    "Producto dado de baja correctamente.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvInventario.ClearSelection();
            this.LimpiarCamposSeleccionados();
        }

        private void btnBuscarInventario_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarProductos(this.ObtenerProductosSegunBusqueda());
                dgvInventario.ClearSelection();
                this.LimpiarCamposSeleccionados();
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
            this.LimpiarCamposSeleccionados();
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

        private void btnReactivarProducto_Click(object sender, EventArgs e)
        {
            try
            {
                int idProducto = this.ObtenerIdProductoSeleccionado();

                DialogResult confirmacion = MessageBox.Show(
                    $"Desea reactivar el producto {txtDescripcion.Text}?",
                    "Productos",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.idProductoForzarSeleccion = idProducto;
                this.productoBusiness.ReactivarProducto(idProducto);
                this.CargarProductos(this.ObtenerProductosSegunBusqueda());

                MessageBox.Show(
                    "Producto reactivado correctamente.",
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void chkVerProductosNoActivos_CheckedChanged(object sender, EventArgs e)
        {
            this.CargarProductos(this.ObtenerProductosSegunBusqueda());
            dgvInventario.ClearSelection();
            this.LimpiarCamposSeleccionados();
        }

        private void dgvInventario_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvInventario.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvInventario.SelectedRows[0].Tag is Producto producto)
            {
                this.MostrarProductoSeleccionado(producto);
            }
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
                    chkVerProductosNoActivos.Checked
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
                }

                if (this.idProductoForzarSeleccion.HasValue)
                {
                    this.SeleccionarProductoEnGrilla(this.idProductoForzarSeleccion.Value);
                    this.idProductoForzarSeleccion = null;
                }
                else
                {
                    dgvInventario.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los productos. " + ex.Message,
                    "Productos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private List<Producto> ObtenerProductosSegunBusqueda()
        {
            return this.productoBusiness.BuscarProductos(
                txtBuscarIdProducto.Text,
                this.ObtenerIdOpcional(txtBuscarIdMarca.Text),
                this.ObtenerIdOpcional(txtBuscarIdCategoria.Text),
                this.ObtenerIdOpcional(txtBuscarIdColor.Text),
                chkVerProductosNoActivos.Checked
            );
        }

        private Producto ObtenerProductoDesdeCamposAlta()
        {
            return new Producto
            {
                Marca = this.ObtenerMarcaAlta(),
                Categoria = this.ObtenerCategoriaAlta(),
                Color = this.ObtenerColorAlta(),
                Descripcion = txtAltaDescripcion.Text,
                PrecioUnitario = this.ObtenerDecimalObligatorio(txtAltaPrecioUnitario.Text, "Debe ingresar un precio valido."),
                StockActual = this.ObtenerEnteroObligatorio(txtAltaStockActual.Text, "Debe ingresar un stock actual valido."),
                StockMinimo = this.ObtenerEnteroObligatorio(txtAltaStockMinimo.Text, "Debe ingresar un stock minimo valido."),
                Estado = chkAltaEstado.Checked,
            };
        }

        private Marca? ObtenerMarcaAlta()
        {
            if (string.IsNullOrWhiteSpace(txtAltaIdMarca.Text))
            {
                return null;
            }

            return new Marca
            {
                Id = this.ObtenerIdObligatorio(txtAltaIdMarca.Text, "Debe seleccionar una marca valida."),
                Nombre = txtAltaMarca.Text,
                Estado = true,
            };
        }

        private Categoria? ObtenerCategoriaAlta()
        {
            if (string.IsNullOrWhiteSpace(txtAltaIdCategoria.Text))
            {
                return null;
            }

            return new Categoria
            {
                Id = this.ObtenerIdObligatorio(txtAltaIdCategoria.Text, "Debe seleccionar una categoria valida."),
                Nombre = txtAltaCategoria.Text,
                Estado = true,
            };
        }
        private ColorProducto? ObtenerColorAlta()
        {
            if (string.IsNullOrWhiteSpace(txtAltaIdColor.Text))
            {
                return null;
            }

            return new ColorProducto
            {
                Id = this.ObtenerIdObligatorio(txtAltaIdColor.Text, "Debe seleccionar un color valido."),
                Nombre = txtAltaColor.Text,
                Estado = true,
            };
        }

        private Producto ObtenerProductoDesdeCamposSeleccionados()
        {
            return new Producto
            {
                IdProducto = this.ObtenerIdProductoSeleccionado(),
                Marca = this.ObtenerMarcaSeleccionada(),
                Categoria = this.ObtenerCategoriaSeleccionada(),
                Color = this.ObtenerColorSeleccionado(),
                Descripcion = txtDescripcion.Text,
                PrecioUnitario = this.ObtenerDecimalObligatorio(txtPrecioUnitario.Text, "Debe ingresar un precio valido."),
                StockActual = this.ObtenerEnteroObligatorio(txtStockActual.Text, "Debe ingresar un stock actual valido."),
                StockMinimo = this.ObtenerEnteroObligatorio(txtStockMinimo.Text, "Debe ingresar un stock minimo valido."),
                Estado = chkEstado.Checked,
            };
        }

        private Marca? ObtenerMarcaSeleccionada()
        {
            if (string.IsNullOrWhiteSpace(txtIdMarca.Text))
            {
                return null;
            }

            return new Marca
            {
                Id = this.ObtenerIdObligatorio(txtIdMarca.Text, "Debe seleccionar una marca valida."),
                Nombre = txtMarca.Text,
                Estado = true,
            };
        }

        private Categoria? ObtenerCategoriaSeleccionada()
        {
            if (string.IsNullOrWhiteSpace(txtIdCategoria.Text))
            {
                return null;
            }

            return new Categoria
            {
                Id = this.ObtenerIdObligatorio(txtIdCategoria.Text, "Debe seleccionar una categoria valida."),
                Nombre = txtCategoria.Text,
                Estado = true,
            };
        }
        private ColorProducto? ObtenerColorSeleccionado()
        {
            if (string.IsNullOrWhiteSpace(txtIdColor.Text))
            {
                return null;
            }

            return new ColorProducto
            {
                Id = this.ObtenerIdObligatorio(txtIdColor.Text, "Debe seleccionar un color valido."),
                Nombre = txtColor.Text,
                Estado = true,
            };
        }

        private int ObtenerIdProductoSeleccionado()
        {
            return this.ObtenerIdObligatorio(txtIdProducto.Text, "Debe seleccionar un producto.");
        }
        private void MostrarProductoSeleccionado(Producto producto)
        {
            txtIdProducto.Text = producto.IdProducto.ToString();
            txtIdMarca.Text = producto.Marca?.Id.ToString() ?? string.Empty;
            txtMarca.Text = producto.Marca?.Nombre ?? string.Empty;
            txtIdCategoria.Text = producto.Categoria?.Id.ToString() ?? string.Empty;
            txtCategoria.Text = producto.Categoria?.Nombre ?? string.Empty;
            txtIdColor.Text = producto.Color?.Id.ToString() ?? string.Empty;
            txtColor.Text = producto.Color?.Nombre ?? string.Empty;
            txtDescripcion.Text = producto.Descripcion;
            txtPrecioUnitario.Text = producto.PrecioUnitario.ToString();
            txtStockActual.Text = producto.StockActual.ToString();
            txtStockMinimo.Text = producto.StockMinimo.ToString();
            txtFechaUltimaActualizacion.Text = producto.FechaUltimaActualizacion.ToString("dd/MM/yyyy HH:mm");
            txtFechaAlta.Text = producto.FechaAlta.ToString("dd/MM/yyyy HH:mm");
            chkEstado.Checked = producto.Estado;
        }

        private int? ObtenerIdOpcional(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return null;
            }

            return this.ObtenerIdObligatorio(valor, "Debe ingresar un id valido.");
        }

        private int ObtenerIdObligatorio(string valor, string mensajeError)
        {
            if (!int.TryParse(valor, out int id) || id <= 0)
            {
                throw new Exception(mensajeError);
            }

            return id;
        }

        private int ObtenerEnteroObligatorio(string valor, string mensajeError)
        {
            if (!int.TryParse(valor, out int numero))
            {
                throw new Exception(mensajeError);
            }

            return numero;
        }

        private decimal ObtenerDecimalObligatorio(string valor, string mensajeError)
        {
            if (!decimal.TryParse(valor, out decimal numero))
            {
                throw new Exception(mensajeError);
            }

            return numero;
        }

        private void SeleccionarProductoEnGrilla(int idProducto)
        {
            foreach (DataGridViewRow fila in dgvInventario.Rows)
            {
                if (fila.Tag is Producto producto && producto.IdProducto == idProducto)
                {
                    fila.Selected = true;
                    dgvInventario.CurrentCell = fila.Cells[0];
                    this.MostrarProductoSeleccionado(producto);
                    return;
                }
            }

            dgvInventario.ClearSelection();
            this.LimpiarCamposSeleccionados();
        }
        private void LimpiarCamposSeleccionados()
        {
            txtIdProducto.Clear();
            txtIdMarca.Clear();
            txtMarca.Clear();
            txtIdCategoria.Clear();
            txtCategoria.Clear();
            txtIdColor.Clear();
            txtColor.Clear();
            txtDescripcion.Clear();
            txtPrecioUnitario.Clear();
            txtStockActual.Clear();
            txtStockMinimo.Clear();
            txtFechaUltimaActualizacion.Clear();
            txtFechaAlta.Clear();
            chkEstado.Checked = true;
        }

        private void LimpiarCamposAlta()
        {
            txtAltaIdMarca.Clear();
            txtAltaMarca.Clear();
            txtAltaIdCategoria.Clear();
            txtAltaCategoria.Clear();
            txtAltaIdColor.Clear();
            txtAltaColor.Clear();
            txtAltaDescripcion.Clear();
            txtAltaPrecioUnitario.Clear();
            txtAltaStockActual.Clear();
            txtAltaStockMinimo.Clear();
            chkAltaEstado.Checked = true;
        }

        private void SeleccionarMarcaEnCampos(TextBox txtIdDestino, TextBox txtNombreDestino)
        {
            using FormElegirMarca form = new FormElegirMarca();

            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (form.SinMarcaSeleccionada)
            {
                txtIdDestino.Clear();
                txtNombreDestino.Clear();
                return;
            }

            if (form.MarcaSeleccionada != null)
            {
                txtIdDestino.Text = form.MarcaSeleccionada.Id.ToString();
                txtNombreDestino.Text = form.MarcaSeleccionada.Nombre;
            }
        }

        private void SeleccionarCategoriaEnCampos(TextBox txtIdDestino, TextBox txtNombreDestino)
        {
            using FormElegirCategoria form = new FormElegirCategoria();

            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (form.SinCategoriaSeleccionada)
            {
                txtIdDestino.Clear();
                txtNombreDestino.Clear();
                return;
            }

            if (form.CategoriaSeleccionada != null)
            {
                txtIdDestino.Text = form.CategoriaSeleccionada.Id.ToString();
                txtNombreDestino.Text = form.CategoriaSeleccionada.Nombre;
            }
        }

        private void SeleccionarColorEnCampos(TextBox txtIdDestino, TextBox txtNombreDestino)
        {
            using FormElegirColor form = new FormElegirColor();

            if (form.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (form.SinColorSeleccionado)
            {
                txtIdDestino.Clear();
                txtNombreDestino.Clear();
                return;
            }

            if (form.ColorSeleccionado != null)
            {
                txtIdDestino.Text = form.ColorSeleccionado.Id.ToString();
                txtNombreDestino.Text = form.ColorSeleccionado.Nombre;
            }
        }
    }
}