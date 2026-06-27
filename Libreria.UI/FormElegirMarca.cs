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
    public partial class FormElegirMarca : Form
    {
        private readonly MarcaBusiness marcaBusiness;
        public Marca? MarcaSeleccionada { get; private set; }
        public bool SinMarcaSeleccionada { get; private set; }

        public FormElegirMarca()
        {
            InitializeComponent();
            this.marcaBusiness = new MarcaBusiness();
            dgvMarcas.SelectionChanged += dgvMarcas_SelectionChanged;
            this.Load += FormElegirMarca_Load;
            chkSinMarca.CheckedChanged += chkSinMarca_CheckedChanged;
        }

        private void FormElegirMarca_Load(object? sender, EventArgs e)
        {
            this.CargarMarcas();
        }

        private void CargarMarcas(List<Marca>? marcas = null)
        {
            try
            {
                dgvMarcas.Rows.Clear();

                marcas ??= this.marcaBusiness.BuscarMarcas(string.Empty, false);

                foreach (Marca marca in marcas)
                {
                    int indiceFila = dgvMarcas.Rows.Add(
                        marca.Id,
                        marca.Nombre
                    );

                    dgvMarcas.Rows[indiceFila].Tag = marca;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar las marcas. " + ex.Message,
                    "Elegir marca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvMarcas_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvMarcas.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvMarcas.SelectedRows[0].Tag is Marca marca)
            {
                this.MostrarMarcaSeleccionada(marca);
            }
        }

        private void MostrarMarcaSeleccionada(Marca marca)
        {
            txtId.Text = marca.Id.ToString();
            txtNombre.Text = marca.Nombre;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkSinMarca.Checked)
                {
                    this.SinMarcaSeleccionada = true;
                    this.MarcaSeleccionada = null;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                Marca marca = this.ObtenerMarcaSeleccionada();

                this.SinMarcaSeleccionada = false;
                this.MarcaSeleccionada = marca;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Elegir marca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarMarcas(this.marcaBusiness.BuscarMarcas(txtBuscarNombre.Text, false));
                dgvMarcas.ClearSelection();
                this.LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Buscar marca",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            this.CargarMarcas();
            dgvMarcas.ClearSelection();
            this.LimpiarCampos();
        }

        private Marca ObtenerMarcaSeleccionada()
        {
            if (dgvMarcas.SelectedRows.Count > 0
                && dgvMarcas.SelectedRows[0].Tag is Marca marca)
            {
                return marca;
            }

            throw new Exception("Debe seleccionar una marca.");
        }


        private void chkSinMarca_CheckedChanged(object? sender, EventArgs e)
        {
            if (chkSinMarca.Checked)
            {
                dgvMarcas.ClearSelection();
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
