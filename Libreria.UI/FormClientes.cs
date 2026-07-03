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
    public partial class FormClientes : Form
    {
        private readonly ClienteBusiness clienteBusiness;
        private int? idClienteForzarSeleccion;

        public FormClientes()
        {
            InitializeComponent();
            this.clienteBusiness = new ClienteBusiness();
            this.CargarClientes();
        }

        private void chkVerClientesNoActivos_CheckedChanged(object sender, EventArgs e)
        {
            this.CargarClientes(this.ObtenerClientesSegunBusqueda());
            dgvClientes.ClearSelection();
            this.LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarClientes(this.ObtenerClientesSegunBusqueda());
                dgvClientes.ClearSelection();
                this.LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Buscar cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiarBusqueda_Click(object sender, EventArgs e)
        {
            txtBuscarNombre.Clear();
            txtBuscarApellido.Clear();
            txtBuscarDocumento.Clear();
            this.CargarClientes();
            dgvClientes.ClearSelection();
            this.LimpiarCampos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = new Cliente(
                    int.Parse(txtAltaDocumento.Text),
                    txtAltaNombre.Text,
                    txtAltaApellido.Text,
                    string.IsNullOrWhiteSpace(txtAltaTelefono.Text) ? null : txtAltaTelefono.Text,
                    string.IsNullOrWhiteSpace(txtAltaMail.Text) ? null : txtAltaMail.Text,
                    string.IsNullOrWhiteSpace(txtAltaDireccion.Text) ? null : txtAltaDireccion.Text,
                    string.IsNullOrWhiteSpace(txtAltaDepartamento.Text) ? null : txtAltaDepartamento.Text,
                    this.ObtenerFechaSeleccionada(dtpAltaFechaNacimiento),
                    true
                );

                this.clienteBusiness.AltaCliente(cliente);
                this.CargarClientes();
                this.LimpiarCamposAlta();

                MessageBox.Show(
                    "Cliente agregado correctamente.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe ingresar un documento valido.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = this.ObtenerClienteDesdeCamposSeleccionados();
                this.idClienteForzarSeleccion = cliente.Id;

                this.clienteBusiness.ModificarCliente(cliente);
                this.CargarClientes();
                this.SeleccionarClienteEnGrilla(cliente.Id);

                MessageBox.Show(
                    "Cliente modificado correctamente.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe ingresar valores validos para modificar el cliente.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Clientes",
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
                    throw new Exception("Debe seleccionar un cliente.");
                }

                int idCliente = int.Parse(txtId.Text);

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Desea dar de baja el cliente {txtNombre.Text} {txtApellido.Text}?",
                    "Clientes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.clienteBusiness.EliminarCliente(idCliente);
                this.CargarClientes();
                dgvClientes.ClearSelection();
                this.LimpiarCampos();

                MessageBox.Show(
                    "Cliente dado de baja correctamente.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar un cliente valido.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnReactivarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    throw new Exception("Debe seleccionar un cliente.");
                }

                int idCliente = int.Parse(txtId.Text);

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Desea reactivar el cliente {txtNombre.Text} {txtApellido.Text}?",
                    "Clientes",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.idClienteForzarSeleccion = idCliente;
                this.clienteBusiness.ReactivarCliente(idCliente);
                this.CargarClientes();
                this.SeleccionarClienteEnGrilla(idCliente);

                MessageBox.Show(
                    "Cliente reactivado correctamente.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar un cliente valido.",
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dgvClientes.ClearSelection();
            this.LimpiarCampos();
        }

        private void CargarClientes(List<Cliente>? clientes = null)
        {
            try
            {
                dgvClientes.Rows.Clear();

                clientes ??= this.clienteBusiness.BuscarClientes(
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    chkVerClientesNoActivos.Checked
                );

                foreach (Cliente cliente in clientes)
                {
                    int indiceFila = dgvClientes.Rows.Add(
                        cliente.Id,
                        cliente.Documento,
                        cliente.Nombre,
                        cliente.Apellido,
                        cliente.Telefono,
                        cliente.Mail,
                        cliente.Direccion,
                        cliente.Departamento,
                        cliente.FechaNacimiento?.ToShortDateString() ?? string.Empty,
                        cliente.Edad?.ToString() ?? string.Empty,
                        cliente.FechaAlta.ToShortDateString(),
                        cliente.Estado
                    );

                    dgvClientes.Rows[indiceFila].Tag = cliente;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los clientes. " + ex.Message,
                    "Clientes",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private List<Cliente> ObtenerClientesSegunBusqueda()
        {
            return this.clienteBusiness.BuscarClientes(
                txtBuscarNombre.Text,
                txtBuscarApellido.Text,
                txtBuscarDocumento.Text,
                chkVerClientesNoActivos.Checked
            );
        }

        private void dgvClientes_SelectionChanged(object? sender, EventArgs e)
        {
            if (this.idClienteForzarSeleccion.HasValue
                && dgvClientes.CurrentRow?.Tag is Cliente clienteActual
                && clienteActual.Id != this.idClienteForzarSeleccion.Value)
            {
                this.SeleccionarClienteEnGrilla(this.idClienteForzarSeleccion.Value);
                return;
            }

            if (dgvClientes.CurrentRow?.Tag is Cliente cliente)
            {
                this.idClienteForzarSeleccion = null;
                this.MostrarClienteSeleccionado(cliente);
            }
        }

        private void MostrarClienteSeleccionado(Cliente cliente)
        {
            txtId.Text = cliente.Id.ToString();
            txtDocumento.Text = cliente.Documento.ToString();
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtTelefono.Text = cliente.Telefono ?? string.Empty;
            txtMail.Text = cliente.Mail ?? string.Empty;
            txtDireccion.Text = cliente.Direccion ?? string.Empty;
            txtDepartamento.Text = cliente.Departamento ?? string.Empty;
            this.AsignarFecha(dtpFechaNacimiento, cliente.FechaNacimiento);
            txtEdad.Text = cliente.Edad?.ToString() ?? string.Empty;
            txtFechaAlta.Text = cliente.FechaAlta.ToShortDateString();
            chkEstado.Checked = cliente.Estado;
        }

        private Cliente ObtenerClienteDesdeCamposSeleccionados()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                throw new Exception("Debe seleccionar un cliente.");
            }

            Cliente cliente = new Cliente(
                int.Parse(txtDocumento.Text),
                txtNombre.Text,
                txtApellido.Text,
                string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text,
                string.IsNullOrWhiteSpace(txtMail.Text) ? null : txtMail.Text,
                string.IsNullOrWhiteSpace(txtDireccion.Text) ? null : txtDireccion.Text,
                string.IsNullOrWhiteSpace(txtDepartamento.Text) ? null : txtDepartamento.Text,
                this.ObtenerFechaSeleccionada(dtpFechaNacimiento),
                chkEstado.Checked
            );

            cliente.Id = int.Parse(txtId.Text);
            cliente.FechaAlta = this.ObtenerFechaAltaSeleccionada();

            return cliente;
        }

        private DateTime ObtenerFechaAltaSeleccionada()
        {
            if (dgvClientes.CurrentRow?.Tag is Cliente cliente)
            {
                return cliente.FechaAlta;
            }

            if (DateTime.TryParse(txtFechaAlta.Text, out DateTime fechaAlta))
            {
                return fechaAlta;
            }

            throw new Exception("No se pudo obtener la fecha de alta del cliente.");
        }

        private void SeleccionarClienteEnGrilla(int idCliente)
        {
            foreach (DataGridViewRow fila in dgvClientes.Rows)
            {
                if (fila.Tag is Cliente cliente && cliente.Id == idCliente)
                {
                    fila.Selected = true;
                    dgvClientes.CurrentCell = fila.Cells[0];
                    this.MostrarClienteSeleccionado(cliente);
                    this.idClienteForzarSeleccion = null;
                    return;
                }
            }
        }

        private DateTime? ObtenerFechaSeleccionada(DateTimePicker dateTimePicker)
        {
            return dateTimePicker.Checked ? dateTimePicker.Value.Date : null;
        }

        private void AsignarFecha(DateTimePicker dateTimePicker, DateTime? fecha)
        {
            if (fecha.HasValue)
            {
                dateTimePicker.Value = fecha.Value;
                dateTimePicker.Checked = true;
                return;
            }

            dateTimePicker.Value = DateTime.Today;
            dateTimePicker.Checked = false;
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtDocumento.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtTelefono.Clear();
            txtMail.Clear();
            txtDireccion.Clear();
            txtDepartamento.Clear();
            this.AsignarFecha(dtpFechaNacimiento, null);
            txtEdad.Clear();
            txtFechaAlta.Clear();
            chkEstado.Checked = true;
        }

        private void LimpiarCamposAlta()
        {
            txtAltaDocumento.Clear();
            txtAltaNombre.Clear();
            txtAltaApellido.Clear();
            txtAltaTelefono.Clear();
            txtAltaMail.Clear();
            txtAltaDireccion.Clear();
            txtAltaDepartamento.Clear();
            this.AsignarFecha(dtpAltaFechaNacimiento, null);
        }
    }
}