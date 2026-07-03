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
    public partial class FormElegirCliente : Form
    {
        private readonly ClienteBusiness clienteBusiness;
        public Cliente? ClienteSeleccionado { get; private set; }

        public FormElegirCliente()
        {
            InitializeComponent();
            this.clienteBusiness = new ClienteBusiness();
            dgvClientes.SelectionChanged += dgvClientes_SelectionChanged;
            this.Load += FormElegirCliente_Load;
        }

        private void FormElegirCliente_Load(object? sender, EventArgs e)
        {
            this.CargarClientes();
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
                    false
                );

                foreach (Cliente cliente in clientes)
                {
                    int indiceFila = dgvClientes.Rows.Add(
                        cliente.Id,
                        cliente.Nombre,
                        cliente.Apellido,
                        cliente.Documento
                    );

                    dgvClientes.Rows[indiceFila].Tag = cliente;
                }

                this.SeleccionarPrimerCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los clientes. " + ex.Message,
                    "Elegir cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void dgvClientes_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0)
            {
                return;
            }

            if (dgvClientes.SelectedRows[0].Tag is Cliente cliente)
            {
                this.MostrarClienteSeleccionado(cliente);
            }
        }

        private void MostrarClienteSeleccionado(Cliente cliente)
        {
            txtId.Text = cliente.Id.ToString();
            txtNombre.Text = cliente.Nombre;
            txtApellido.Text = cliente.Apellido;
            txtDocumento.Text = cliente.Documento.ToString();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                this.ClienteSeleccionado = this.ObtenerClienteSeleccionado();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Elegir cliente",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarClientes(this.clienteBusiness.BuscarClientes(
                    txtBuscarNombre.Text,
                    txtBuscarApellido.Text,
                    txtBuscarDocumento.Text,
                    false
                ));
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
        }

        private void SeleccionarPrimerCliente()
        {
            if (dgvClientes.Rows.Count == 0)
            {
                this.LimpiarCampos();
                return;
            }

            dgvClientes.ClearSelection();
            dgvClientes.Rows[0].Selected = true;

            if (dgvClientes.Rows[0].Tag is Cliente cliente)
            {
                this.MostrarClienteSeleccionado(cliente);
            }
        }

        private Cliente ObtenerClienteSeleccionado()
        {
            if (dgvClientes.SelectedRows.Count > 0
                && dgvClientes.SelectedRows[0].Tag is Cliente cliente)
            {
                return cliente;
            }

            throw new Exception("Debe seleccionar un cliente.");
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtDocumento.Clear();
        }
    }
}


