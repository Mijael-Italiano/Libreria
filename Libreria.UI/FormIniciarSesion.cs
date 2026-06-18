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
using Libreria.Sesion;

namespace Libreria.UI
{
    public partial class FormIniciarSesion : Form
    {
        private readonly UsuarioBusiness usuarioBusiness;

        public FormIniciarSesion()
        {
            InitializeComponent();
            this.usuarioBusiness = new UsuarioBusiness();
        }

        private void chkMostrarContrasena_CheckedChanged(object sender, EventArgs e)
        {
            txtContrasena.PasswordChar = chkMostrarContrasena.Checked ? '\0' : '*';
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = this.usuarioBusiness.IniciarSesion(
                    txtNombreUsuario.Text,
                    txtContrasena.Text
                );

                SesionActual.Iniciar(usuario);

                MessageBox.Show(
                    $"Bienvenido {usuario.NombreUsuario}.",
                    "Iniciar sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                FormMenuInicio menuInicio = new FormMenuInicio();
                menuInicio.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Iniciar sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

    }
}
