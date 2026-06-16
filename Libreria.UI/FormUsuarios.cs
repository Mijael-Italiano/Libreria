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
using Libreria.Seguridad;

namespace Libreria.UI
{
    public partial class FormUsuarios : Form
    {
        private readonly UsuarioBusiness usuarioBusiness;
        private int? idUsuarioForzarSeleccion;

        public FormUsuarios()
        {
            InitializeComponent();
            this.usuarioBusiness = new UsuarioBusiness();
            dgvUsuarios.SelectionChanged += dgvUsuarios_SelectionChanged;
            this.CargarUsuarios();
        }

        private void chkMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.PasswordChar = chkMostrarContrasena.Checked ? '\0' : '*';
        }

        private void chkAltaMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            txtAltaContrasena.PasswordChar = chkAltaMostrarContrasena.Checked ? '\0' : '*';
        }

        private void chkVerUsuariosNoActivos_CheckedChanged(object sender, EventArgs e)
        {
            this.CargarUsuarios(this.ObtenerUsuariosSegunBusqueda());
            dgvUsuarios.ClearSelection();
            this.LimpiarCampos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                this.CargarUsuarios(this.ObtenerUsuariosSegunBusqueda());
                dgvUsuarios.ClearSelection();
                this.LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Buscar usuario",
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
            this.CargarUsuarios();
            dgvUsuarios.ClearSelection();
            this.LimpiarCampos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario(
                    int.Parse(txtAltaDocumento.Text),
                    txtAltaNombreUsuario.Text,
                    txtAltaContrasena.Text,
                    txtAltaNombre.Text,
                    txtAltaApellido.Text,
                    txtAltaMail.Text,
                    txtAltaTelefono.Text,
                    dtpAltaFechaNacimiento.Value,
                    txtAltaDireccion.Text,
                    string.IsNullOrWhiteSpace(txtAltaDepartamento.Text) ? null : txtAltaDepartamento.Text,
                    true,
                    false
                );

                this.usuarioBusiness.AltaUsuario(usuario);
                this.CargarUsuarios();
                this.LimpiarCamposAlta();

                MessageBox.Show(
                    "Usuario agregado correctamente.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe ingresar un documento valido.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = this.ObtenerUsuarioDesdeCamposSeleccionados();
                this.idUsuarioForzarSeleccion = usuario.Id;

                this.usuarioBusiness.ModificarUsuario(usuario);
                this.CargarUsuarios();
                this.SeleccionarUsuarioEnGrilla(usuario.Id);

                MessageBox.Show(
                    "Usuario modificado correctamente.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe ingresar valores validos para modificar el usuario.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarUsuarios(List<Usuario>? usuarios = null)
        {
            try
            {
                dgvUsuarios.Rows.Clear();

                usuarios ??= this.usuarioBusiness.BuscarUsuarios(
                    string.Empty,
                    string.Empty,
                    string.Empty,
                    chkVerUsuariosNoActivos.Checked
                );

                foreach (Usuario usuario in usuarios)
                {
                    int indiceFila = dgvUsuarios.Rows.Add(
                        usuario.Id,
                        usuario.Documento,
                        usuario.NombreUsuario,
                        usuario.Contrasena,
                        usuario.Nombre,
                        usuario.Apellido,
                        usuario.Mail,
                        usuario.Telefono,
                        usuario.FechaNacimiento.ToShortDateString(),
                        usuario.Direccion,
                        usuario.Departamento,
                        usuario.FechaAlta.ToShortDateString(),
                        usuario.IntentosFallidos,
                        usuario.Estado,
                        usuario.Bloqueado
                    );

                    dgvUsuarios.Rows[indiceFila].Tag = usuario;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudieron cargar los usuarios. " + ex.Message,
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private List<Usuario> ObtenerUsuariosSegunBusqueda()
        {
            return this.usuarioBusiness.BuscarUsuarios(
                txtBuscarNombre.Text,
                txtBuscarApellido.Text,
                txtBuscarDocumento.Text,
                chkVerUsuariosNoActivos.Checked
            );
        }

        private void dgvUsuarios_SelectionChanged(object? sender, EventArgs e)
        {
            if (this.idUsuarioForzarSeleccion.HasValue
                && dgvUsuarios.CurrentRow?.Tag is Usuario usuarioActual
                && usuarioActual.Id != this.idUsuarioForzarSeleccion.Value)
            {
                this.SeleccionarUsuarioEnGrilla(this.idUsuarioForzarSeleccion.Value);
                return;
            }

            if (dgvUsuarios.CurrentRow?.Tag is Usuario usuario)
            {
                this.idUsuarioForzarSeleccion = null;
                this.MostrarUsuarioSeleccionado(usuario);
            }
        }

        private void MostrarUsuarioSeleccionado(Usuario usuario)
        {
            txtId.Text = usuario.Id.ToString();
            txtDocumento.Text = usuario.Documento.ToString();
            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtContrasenaEncriptada.Text = usuario.Contrasena;
            txtContrasena.Text = this.ObtenerContrasenaVisible(usuario.Contrasena);
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtMail.Text = usuario.Mail;
            txtTelefono.Text = usuario.Telefono;
            dtpFechaNacimiento.Value = usuario.FechaNacimiento;
            txtDireccion.Text = usuario.Direccion;
            txtDepartamento.Text = usuario.Departamento ?? string.Empty;
            chkEstado.Checked = usuario.Estado;
            chkBloqueado.Checked = usuario.Bloqueado;
            txtFechaAlta.Text = usuario.FechaAlta.ToShortDateString();
            txtIntentosFallidos.Text = usuario.IntentosFallidos.ToString();
        }

        private Usuario ObtenerUsuarioDesdeCamposSeleccionados()
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                throw new Exception("Debe seleccionar un usuario.");
            }

            Usuario usuario = new Usuario(
                int.Parse(txtDocumento.Text),
                txtNombreUsuario.Text,
                txtContrasena.Text,
                txtNombre.Text,
                txtApellido.Text,
                txtMail.Text,
                txtTelefono.Text,
                dtpFechaNacimiento.Value,
                txtDireccion.Text,
                string.IsNullOrWhiteSpace(txtDepartamento.Text) ? null : txtDepartamento.Text,
                chkEstado.Checked,
                chkBloqueado.Checked
            );

            usuario.Id = int.Parse(txtId.Text);
            usuario.FechaAlta = this.ObtenerFechaAltaSeleccionada();
            usuario.IntentosFallidos = int.Parse(txtIntentosFallidos.Text);

            return usuario;
        }

        private DateTime ObtenerFechaAltaSeleccionada()
        {
            if (dgvUsuarios.CurrentRow?.Tag is Usuario usuario)
            {
                return usuario.FechaAlta;
            }

            if (DateTime.TryParse(txtFechaAlta.Text, out DateTime fechaAlta))
            {
                return fechaAlta;
            }

            throw new Exception("No se pudo obtener la fecha de alta del usuario.");
        }

        private void SeleccionarUsuarioEnGrilla(int idUsuario)
        {
            foreach (DataGridViewRow fila in dgvUsuarios.Rows)
            {
                if (fila.Tag is Usuario usuario && usuario.Id == idUsuario)
                {
                    fila.Selected = true;
                    dgvUsuarios.CurrentCell = fila.Cells[0];
                    this.MostrarUsuarioSeleccionado(usuario);
                    this.idUsuarioForzarSeleccion = null;
                    return;
                }
            }
        }

        private string ObtenerContrasenaVisible(string contrasenaEncriptada)
        {
            try
            {
                return contrasenaEncriptada.DesencriptarPassword();
            }
            catch (Exception)
            {
                return contrasenaEncriptada;
            }
        }

        private void LimpiarCampos()
        {
            txtId.Clear();
            txtDocumento.Clear();
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            txtContrasenaEncriptada.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtMail.Clear();
            txtTelefono.Clear();
            dtpFechaNacimiento.Value = DateTime.Today;
            txtDireccion.Clear();
            txtDepartamento.Clear();
            chkEstado.Checked = true;
            chkBloqueado.Checked = false;
            txtFechaAlta.Clear();
            txtIntentosFallidos.Clear();
            chkMostrarContrasena.Checked = false;
        }

        private void LimpiarCamposAlta()
        {
            txtAltaDocumento.Clear();
            txtAltaNombreUsuario.Clear();
            txtAltaContrasena.Clear();
            chkAltaMostrarContrasena.Checked = false;
            txtAltaNombre.Clear();
            txtAltaApellido.Clear();
            txtAltaMail.Clear();
            txtAltaTelefono.Clear();
            dtpAltaFechaNacimiento.Value = DateTime.Today;
            txtAltaDireccion.Clear();
            txtAltaDepartamento.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    throw new Exception("Debe seleccionar un usuario.");
                }

                int idUsuario = int.Parse(txtId.Text);

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Desea dar de baja el usuario {txtNombreUsuario.Text}?",
                    "Usuarios",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.usuarioBusiness.EliminarUsuario(idUsuario);
                this.CargarUsuarios();
                dgvUsuarios.ClearSelection();
                this.LimpiarCampos();

                MessageBox.Show(
                    "Usuario dado de baja correctamente.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar un usuario valido.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }

        private void btnReactivarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtId.Text))
                {
                    throw new Exception("Debe seleccionar un usuario.");
                }

                int idUsuario = int.Parse(txtId.Text);

                DialogResult confirmacion = MessageBox.Show(
                    $"¿Desea reactivar el usuario {txtNombreUsuario.Text}?",
                    "Usuarios",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.idUsuarioForzarSeleccion = idUsuario;
                this.usuarioBusiness.ReactivarUsuario(idUsuario);
                this.CargarUsuarios();
                this.SeleccionarUsuarioEnGrilla(idUsuario);

                MessageBox.Show(
                    "Usuario reactivado correctamente.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (FormatException)
            {
                MessageBox.Show(
                    "Debe seleccionar un usuario valido.",
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Usuarios",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

        }
    }
}
