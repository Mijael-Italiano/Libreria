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
    public partial class FormCategoriaProducto : Form
    {
        private readonly CategoriaBusiness categoriaBusiness;
        private int? idCategoriaForzarSeleccion;

        public FormCategoriaProducto()
        {
            InitializeComponent();
            this.categoriaBusiness = new CategoriaBusiness();
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;
            chkVerCategoriasNoActivas.CheckedChanged += chkVerCategoriasNoActivas_CheckedChanged;
            this.CargarCategorias();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = new Categoria(txtAltaNombre.Text);

                this.categoriaBusiness.AltaCategoria(categoria);
                this.CargarCategorias();
                this.LimpiarCamposAlta();

                MessageBox.Show(
                    "Categoria agregada correctamente.",
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarCategorias(this.ObtenerCategoriasSegunBusqueda());
                dgvCategorias.ClearSelection();
                this.LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Buscar categoria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            this.CargarCategorias();
            dgvCategorias.ClearSelection();
            this.LimpiarCampos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Categoria categoria = this.ObtenerCategoriaDesdeCamposSeleccionados();
                this.idCategoriaForzarSeleccion = categoria.Id;

                this.categoriaBusiness.ModificarCategoria(categoria);
                this.CargarCategorias();
                this.SeleccionarCategoriaEnGrilla(categoria.Id);

                MessageBox.Show(
                    "Categoria modificada correctamente.",
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar una categoria valida.",
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int idCategoria = this.ObtenerIdCategoriaSeleccionada();

                DialogResult confirmacion = MessageBox.Show(
                    $"Desea dar de baja la categoria {txtNombre.Text}?",
                    "Categorias",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.idCategoriaForzarSeleccion = idCategoria;
                this.categoriaBusiness.EliminarCategoria(idCategoria);
                this.CargarCategorias();
                this.SeleccionarCategoriaEnGrilla(idCategoria);

                MessageBox.Show(
                    "Categoria dada de baja correctamente.",
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar una categoria valida.",
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvCategorias.ClearSelection();
            this.LimpiarCampos();
        }

        private void btnReactivarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                int idCategoria = this.ObtenerIdCategoriaSeleccionada();

                DialogResult confirmacion = MessageBox.Show(
                    $"Desea reactivar la categoria {txtNombre.Text}?",
                    "Categorias",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.idCategoriaForzarSeleccion = idCategoria;
                this.categoriaBusiness.ReactivarCategoria(idCategoria);
                this.CargarCategorias();
                this.SeleccionarCategoriaEnGrilla(idCategoria);

                MessageBox.Show(
                    "Categoria reactivada correctamente.",
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar una categoria valida.",
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void chkVerCategoriasNoActivas_CheckedChanged(object? sender, EventArgs e)
        {
            this.CargarCategorias(this.ObtenerCategoriasSegunBusqueda());
            dgvCategorias.ClearSelection();
            this.LimpiarCampos();
        }

        private void CargarCategorias(List<Categoria>? categorias = null)
        {
            try
            {
                dgvCategorias.Rows.Clear();

                categorias ??= this.categoriaBusiness.BuscarCategorias(
                    string.Empty,
                    chkVerCategoriasNoActivas.Checked
                );

                foreach (Categoria categoria in categorias)
                {
                    int indiceFila = dgvCategorias.Rows.Add(
                        categoria.Id,
                        categoria.Nombre,
                        categoria.Estado
                    );

                    dgvCategorias.Rows[indiceFila].Tag = categoria;
                }

                if (this.idCategoriaForzarSeleccion.HasValue)
                {
                    this.SeleccionarCategoriaEnGrilla(this.idCategoriaForzarSeleccion.Value);
                    this.idCategoriaForzarSeleccion = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar las categorias. " + ex.Message,
                    "Categorias",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private List<Categoria> ObtenerCategoriasSegunBusqueda()
        {
            return this.categoriaBusiness.BuscarCategorias(
                txtBuscarNombre.Text,
                chkVerCategoriasNoActivas.Checked
            );
        }

        private void dgvCategorias_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvCategorias.SelectedRows[0].Tag is Categoria categoria)
            {
                this.MostrarCategoriaSeleccionada(categoria);
            }
        }

        private void MostrarCategoriaSeleccionada(Categoria categoria)
        {
            txtId.Text = categoria.Id.ToString();
            txtNombre.Text = categoria.Nombre;
            chkEstado.Checked = categoria.Estado;
        }

        private Categoria ObtenerCategoriaDesdeCamposSeleccionados()
        {
            return new Categoria
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Estado = chkEstado.Checked,
            };
        }

        private int ObtenerIdCategoriaSeleccionada()
        {
            return int.Parse(txtId.Text);
        }

        private void SeleccionarCategoriaEnGrilla(int idCategoria)
        {
            foreach (DataGridViewRow fila in dgvCategorias.Rows)
            {
                if (fila.Tag is Categoria categoria && categoria.Id == idCategoria)
                {
                    fila.Selected = true;
                    dgvCategorias.CurrentCell = fila.Cells[0];
                    this.MostrarCategoriaSeleccionada(categoria);
                    return;
                }
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            chkEstado.Checked = true;
        }

        private void LimpiarCamposAlta()
        {
            txtAltaNombre.Clear();
        }
    }
}
