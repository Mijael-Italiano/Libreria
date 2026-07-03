using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Libreria.Business;
using Libreria.Sesion;

namespace Libreria.UI
{
    public partial class FormBackUp : Form
    {
        private readonly BackUpRestoreBusiness backUpRestoreBusiness;

        public FormBackUp()
        {
            InitializeComponent();
            this.backUpRestoreBusiness = new BackUpRestoreBusiness();
        }

        private void FormBackUp_Load(object? sender, EventArgs e)
        {
            this.CargarUsuarioActual();
            this.CargarBackUps();
        }

        private void btnCrearBackUp_Click(object? sender, EventArgs e)
        {
            try
            {
                if (SesionActual.Usuario == null)
                {
                    throw new Exception("Debe existir un usuario logueado.");
                }

                string nombreBackUp = this.backUpRestoreBusiness.CrearBackUp(SesionActual.Usuario);
                MessageBox.Show($"Se creo el back up {nombreBackUp}.", "Back up", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CargarBackUps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Back up", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void CargarUsuarioActual()
        {
            lblUsuarioActual.Text = SesionActual.Usuario == null
                ? "Usuario actual: sin sesion"
                : $"Usuario actual: {SesionActual.Usuario.Nombre} {SesionActual.Usuario.Apellido} - DNI {SesionActual.Usuario.Documento}";
        }

        private void CargarBackUps()
        {
            try
            {
                List<string> backUps = this.backUpRestoreBusiness.ListarBackUps();

                dgvBackUps.DataSource = backUps
                    .Select(nombre => new { NombreBackUp = nombre })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Back up", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


