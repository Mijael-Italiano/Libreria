using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Libreria.Business;
using Libreria.Entity;

namespace Libreria.UI
{
    public partial class FormColorProducto : Form
    {
        private readonly ColorBusiness colorBusiness;
        private int? idColorForzarSeleccion;

        public FormColorProducto()
        {
            InitializeComponent();
            this.colorBusiness = new ColorBusiness();
            this.ConfigurarEventos();
            this.CargarColores();
        }

        private void ConfigurarEventos()
        {
            dgvColores.SelectionChanged += dgvColores_SelectionChanged;
            chkVerColoresNoActivos.CheckedChanged += chkVerColoresNoActivos_CheckedChanged;
        }

        private void btnAgregarColor_Click(object? sender, EventArgs e)
        {
            try
            {
                ColorProducto color = new ColorProducto(txtAltaNombre.Text);

                this.colorBusiness.AltaColor(color);
                this.CargarColores();
                this.LimpiarCamposAlta();

                MessageBox.Show(
                    "Color agregado correctamente.",
                    "Colores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Colores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            try
            {
                this.CargarColores(this.ObtenerColoresSegunBusqueda());
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

        private void btnLimpiarBusqueda_Click(object? sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            this.CargarColores();
            dgvColores.ClearSelection();
            this.LimpiarCampos();
        }

        private void btnModificar_Click(object? sender, EventArgs e)
        {
            try
            {
                ColorProducto color = this.ObtenerColorDesdeCamposSeleccionados();
                this.idColorForzarSeleccion = color.Id;

                this.colorBusiness.ModificarColor(color);
                this.CargarColores();
                this.SeleccionarColorEnGrilla(color.Id);

                MessageBox.Show(
                    "Color modificado correctamente.",
                    "Colores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar un color valido.",
                    "Colores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Colores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminar_Click(object? sender, EventArgs e)
        {
            try
            {
                int idColor = this.ObtenerIdColorSeleccionado();

                DialogResult confirmacion = MessageBox.Show(
                    $"Desea dar de baja el color {txtNombre.Text}?",
                    "Colores",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.idColorForzarSeleccion = idColor;
                this.colorBusiness.EliminarColor(idColor);
                this.CargarColores();
                this.SeleccionarColorEnGrilla(idColor);

                MessageBox.Show(
                    "Color dado de baja correctamente.",
                    "Colores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar un color valido.",
                    "Colores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Colores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            dgvColores.ClearSelection();
            this.LimpiarCampos();
        }

        private void btnReactivarColor_Click(object? sender, EventArgs e)
        {
            try
            {
                int idColor = this.ObtenerIdColorSeleccionado();

                DialogResult confirmacion = MessageBox.Show(
                    $"Desea reactivar el color {txtNombre.Text}?",
                    "Colores",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.idColorForzarSeleccion = idColor;
                this.colorBusiness.ReactivarColor(idColor);
                this.CargarColores();
                this.SeleccionarColorEnGrilla(idColor);

                MessageBox.Show(
                    "Color reactivado correctamente.",
                    "Colores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar un color valido.",
                    "Colores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Colores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void chkVerColoresNoActivos_CheckedChanged(object? sender, EventArgs e)
        {
            this.CargarColores(this.ObtenerColoresSegunBusqueda());
            dgvColores.ClearSelection();
            this.LimpiarCampos();
        }

        private void CargarColores(List<ColorProducto>? colores = null)
        {
            try
            {
                dgvColores.Rows.Clear();

                colores ??= this.colorBusiness.BuscarColores(
                    string.Empty,
                    chkVerColoresNoActivos.Checked
                );

                foreach (ColorProducto color in colores)
                {
                    int indiceFila = dgvColores.Rows.Add(
                        color.Id,
                        color.Nombre,
                        color.Estado
                    );

                    dgvColores.Rows[indiceFila].Tag = color;
                }

                if (this.idColorForzarSeleccion.HasValue)
                {
                    this.SeleccionarColorEnGrilla(this.idColorForzarSeleccion.Value);
                    this.idColorForzarSeleccion = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los colores. " + ex.Message,
                    "Colores",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private List<ColorProducto> ObtenerColoresSegunBusqueda()
        {
            return this.colorBusiness.BuscarColores(
                txtBuscarNombre.Text,
                chkVerColoresNoActivos.Checked
            );
        }

        private void dgvColores_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvColores.SelectedRows.Count == 0)
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
            chkEstado.Checked = color.Estado;
        }

        private ColorProducto ObtenerColorDesdeCamposSeleccionados()
        {
            return new ColorProducto
            {
                Id = int.Parse(txtId.Text),
                Nombre = txtNombre.Text,
                Estado = chkEstado.Checked,
            };
        }

        private int ObtenerIdColorSeleccionado()
        {
            return int.Parse(txtId.Text);
        }

        private void SeleccionarColorEnGrilla(int idColor)
        {
            foreach (DataGridViewRow fila in dgvColores.Rows)
            {
                if (fila.Tag is ColorProducto color && color.Id == idColor)
                {
                    fila.Selected = true;
                    dgvColores.CurrentCell = fila.Cells[0];
                    this.MostrarColorSeleccionado(color);
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
