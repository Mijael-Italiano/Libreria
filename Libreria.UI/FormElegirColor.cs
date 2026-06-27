using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Libreria.Business;
using Libreria.Entity;

namespace Libreria.UI
{
    public partial class FormElegirColor : Form
    {
        private readonly ColorBusiness colorBusiness;
        public ColorProducto? ColorSeleccionado { get; private set; }
        public bool SinColorSeleccionado { get; private set; }

        public FormElegirColor()
        {
            InitializeComponent();
            this.colorBusiness = new ColorBusiness();
            dgvColores.SelectionChanged += dgvColores_SelectionChanged;
            this.Load += FormElegirColor_Load;
            chkSinColor.CheckedChanged += chkSinColor_CheckedChanged;
        }

        private void FormElegirColor_Load(object? sender, EventArgs e)
        {
            this.CargarColores();
        }

        private void CargarColores(List<ColorProducto>? colores = null)
        {
            try
            {
                dgvColores.Rows.Clear();

                colores ??= this.colorBusiness.BuscarColores(string.Empty, false);

                foreach (ColorProducto color in colores)
                {
                    int indiceFila = dgvColores.Rows.Add(
                        color.Id,
                        color.Nombre
                    );

                    dgvColores.Rows[indiceFila].Tag = color;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los colores. " + ex.Message,
                    "Elegir color",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvColores_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvColores.SelectedRows.Count == 0)
            {
                return;
            }

            if (chkSinColor.Checked)
            {
                return;
            }

            if (dgvColores.SelectedRows[0].Tag is ColorProducto color)
            {
                this.MostrarColorSeleccionado(color);
            }
        }

        private void MostrarColorSeleccionado(ColorProducto color)
        {
            txtId.Text = color.Id.ToString();
            txtNombre.Text = color.Nombre;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                if (chkSinColor.Checked)
                {
                    this.SinColorSeleccionado = true;
                    this.ColorSeleccionado = null;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }

                ColorProducto color = this.ObtenerColorSeleccionado();

                this.SinColorSeleccionado = false;
                this.ColorSeleccionado = color;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Elegir color",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarColores(this.colorBusiness.BuscarColores(txtBuscarNombre.Text, false));
                dgvColores.ClearSelection();
                this.LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Buscar color",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            this.CargarColores();
            dgvColores.ClearSelection();
            this.LimpiarCampos();
        }

        private ColorProducto ObtenerColorSeleccionado()
        {
            if (dgvColores.SelectedRows.Count > 0
                && dgvColores.SelectedRows[0].Tag is ColorProducto color)
            {
                return color;
            }

            throw new Exception("Debe seleccionar un color.");
        }


        private void chkSinColor_CheckedChanged(object? sender, EventArgs e)
        {
            if (chkSinColor.Checked)
            {
                dgvColores.ClearSelection();
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
