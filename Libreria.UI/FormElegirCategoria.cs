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
    public partial class FormElegirCategoria : Form
    {
        private readonly CategoriaBusiness categoriaBusiness;
        public Categoria? CategoriaSeleccionada { get; private set; }
        public bool SinCategoriaSeleccionada { get; private set; }

        public FormElegirCategoria()
        {
            InitializeComponent();
            this.categoriaBusiness = new CategoriaBusiness();
            dgvCategorias.SelectionChanged += dgvCategorias_SelectionChanged;
            this.Load += FormElegirCategoria_Load;
            chkSinCategoria.CheckedChanged += chkSinCategoria_CheckedChanged;
        }

        private void FormElegirCategoria_Load(object? sender, EventArgs e)
        {
            this.CargarCategorias();
        }

        private void CargarCategorias(List<Categoria>? categorias = null)
        {
            try
            {
                dgvCategorias.Rows.Clear();

                categorias ??= this.categoriaBusiness.BuscarCategorias(string.Empty, false);

                foreach (Categoria categoria in categorias)
                {
                    int indiceFila = dgvCategorias.Rows.Add(
                        categoria.Id,
                        categoria.Nombre
                    );

                    dgvCategorias.Rows[indiceFila].Tag = categoria;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar las categorias. " + ex.Message,
                    "Elegir categoria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvCategorias_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count == 0)
            {
                return;
            }

            if (chkSinCategoria.Checked)
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
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkSinCategoria.Checked)
                {
                    this.SinCategoriaSeleccionada = true;
                    this.CategoriaSeleccionada = null;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                Categoria categoria = this.ObtenerCategoriaSeleccionada();

                this.SinCategoriaSeleccionada = false;
                this.CategoriaSeleccionada = categoria;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Elegir categoria",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarCategorias(this.categoriaBusiness.BuscarCategorias(txtBuscarNombre.Text, false));
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

        private Categoria ObtenerCategoriaSeleccionada()
        {
            if (dgvCategorias.SelectedRows.Count > 0
                && dgvCategorias.SelectedRows[0].Tag is Categoria categoria)
            {
                return categoria;
            }

            throw new Exception("Debe seleccionar una categoria.");
        }


        private void chkSinCategoria_CheckedChanged(object? sender, EventArgs e)
        {
            if (chkSinCategoria.Checked)
            {
                dgvCategorias.ClearSelection();
                this.LimpiarCampos();
            }
        }
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
        }
    }
}
