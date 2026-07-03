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
    public partial class FormMetodosDePago : Form
    {
        private readonly MedioPagoBusiness medioPagoBusiness;
        private int? idMedioPagoForzarSeleccion;

        public FormMetodosDePago()
        {
            InitializeComponent();
            this.medioPagoBusiness = new MedioPagoBusiness();
            this.CargarMediosPago();
        }

        private void chkVerMediosPagoNoActivos_CheckedChanged(object sender, EventArgs e)
        {
            this.CargarMediosPago(this.ObtenerMediosPagoSegunBusqueda());
            dgvMediosPago.ClearSelection();
            this.LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarMediosPago(this.ObtenerMediosPagoSegunBusqueda());
                dgvMediosPago.ClearSelection();
                this.LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Buscar medio de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            this.CargarMediosPago();
            dgvMediosPago.ClearSelection();
            this.LimpiarCampos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                MedioPago medioPago = new MedioPago(txtAltaNombre.Text);

                this.medioPagoBusiness.AltaMedioPago(medioPago);
                this.CargarMediosPago();
                this.LimpiarCamposAlta();

                MessageBox.Show(
                    "Medio de pago agregado correctamente.",
                    "Medios de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Medios de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                MedioPago medioPago = this.ObtenerMedioPagoDesdeCamposSeleccionados();
                this.idMedioPagoForzarSeleccion = medioPago.IdMedioPago;

                this.medioPagoBusiness.ModificarMedioPago(medioPago);
                this.CargarMediosPago();
                this.SeleccionarMedioPagoEnGrilla(medioPago.IdMedioPago);

                MessageBox.Show(
                    "Medio de pago modificado correctamente.",
                    "Medios de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar un medio de pago valido.",
                    "Medios de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Medios de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    throw new Exception("Debe seleccionar un medio de pago.");
                }

                int idMedioPago = int.Parse(txtId.Text);

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Desea dar de baja el medio de pago {txtNombre.Text}?",
                    "Medios de pago",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.medioPagoBusiness.EliminarMedioPago(idMedioPago);
                this.CargarMediosPago();
                dgvMediosPago.ClearSelection();
                this.LimpiarCampos();

                MessageBox.Show(
                    "Medio de pago dado de baja correctamente.",
                    "Medios de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar un medio de pago valido.",
                    "Medios de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Medios de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnReactivarMedioPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    throw new Exception("Debe seleccionar un medio de pago.");
                }

                int idMedioPago = int.Parse(txtId.Text);

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Desea reactivar el medio de pago {txtNombre.Text}?",
                    "Medios de pago",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.idMedioPagoForzarSeleccion = idMedioPago;
                this.medioPagoBusiness.ReactivarMedioPago(idMedioPago);
                this.CargarMediosPago();
                this.SeleccionarMedioPagoEnGrilla(idMedioPago);

                MessageBox.Show(
                    "Medio de pago reactivado correctamente.",
                    "Medios de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar un medio de pago valido.",
                    "Medios de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Medios de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvMediosPago.ClearSelection();
            this.LimpiarCampos();
        }

        private void CargarMediosPago(List<MedioPago>? mediosPago = null)
        {
            try
            {
                dgvMediosPago.Rows.Clear();

                mediosPago ??= this.medioPagoBusiness.BuscarMediosPago(
                    string.Empty,
                    chkVerMediosPagoNoActivos.Checked
                );

                foreach (MedioPago medioPago in mediosPago)
                {
                    int indiceFila = dgvMediosPago.Rows.Add(
                        medioPago.IdMedioPago,
                        medioPago.Nombre,
                        medioPago.Estado
                    );

                    dgvMediosPago.Rows[indiceFila].Tag = medioPago;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los medios de pago. " + ex.Message,
                    "Medios de pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private List<MedioPago> ObtenerMediosPagoSegunBusqueda()
        {
            return this.medioPagoBusiness.BuscarMediosPago(
                txtBuscarNombre.Text,
                chkVerMediosPagoNoActivos.Checked
            );
        }

        private void dgvMediosPago_SelectionChanged(object? sender, EventArgs e)
        {
            if (this.idMedioPagoForzarSeleccion.HasValue
                && dgvMediosPago.CurrentRow?.Tag is MedioPago medioPagoActual
                && medioPagoActual.IdMedioPago != this.idMedioPagoForzarSeleccion.Value)
            {
                this.SeleccionarMedioPagoEnGrilla(this.idMedioPagoForzarSeleccion.Value);
                return;
            }

            if (dgvMediosPago.CurrentRow?.Tag is MedioPago medioPago)
            {
                this.idMedioPagoForzarSeleccion = null;
                this.MostrarMedioPagoSeleccionado(medioPago);
            }
        }

        private void MostrarMedioPagoSeleccionado(MedioPago medioPago)
        {
            txtId.Text = medioPago.IdMedioPago.ToString();
            txtNombre.Text = medioPago.Nombre;
            chkEstado.Checked = medioPago.Estado;
        }

        private MedioPago ObtenerMedioPagoDesdeCamposSeleccionados()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                throw new Exception("Debe seleccionar un medio de pago.");
            }

            MedioPago medioPago = new MedioPago(txtNombre.Text)
            {
                IdMedioPago = int.Parse(txtId.Text),
                Estado = chkEstado.Checked,
            };

            return medioPago;
        }

        private void SeleccionarMedioPagoEnGrilla(int idMedioPago)
        {
            foreach (DataGridViewRow fila in dgvMediosPago.Rows)
            {
                if (fila.Tag is MedioPago medioPago && medioPago.IdMedioPago == idMedioPago)
                {
                    fila.Selected = true;
                    dgvMediosPago.CurrentCell = fila.Cells[0];
                    this.MostrarMedioPagoSeleccionado(medioPago);
                    this.idMedioPagoForzarSeleccion = null;
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