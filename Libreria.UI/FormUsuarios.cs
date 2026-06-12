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
    public partial class FormUsuarios : Form
    {
        private readonly UsuarioBusiness usuarioBusiness;

        public FormUsuarios()
        {
            InitializeComponent();
            this.usuarioBusiness = new UsuarioBusiness();
            this.CargarUsuarios();
        }

        private void chkMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.PasswordChar = chkMostrarContrasena.Checked ? '\0' : '*';
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
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

                this.usuarioBusiness.AltaUsuario(usuario);
                this.CargarUsuarios();
                this.LimpiarCampos();

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

        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.Rows.Clear();

                foreach (Usuario usuario in this.usuarioBusiness.ConsultarUsuarios())
                {
                    dgvUsuarios.Rows.Add(
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

    }
}
