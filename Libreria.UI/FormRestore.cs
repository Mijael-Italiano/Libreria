using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Libreria.Business;
using Libreria.Sesion;

namespace Libreria.UI
{
    public partial class FormRestore : Form
    {
        private readonly BackUpRestoreBusiness backUpRestoreBusiness;

        public FormRestore()
        {
            InitializeComponent();
            this.backUpRestoreBusiness = new BackUpRestoreBusiness();
        }

        private void FormRestore_Load(object? sender, EventArgs e)
        {
            this.CargarBackUps();
        }

        private void btnRestaurar_Click(object? sender, EventArgs e)
        {
            try
            {
                if (SesionActual.Usuario == null)
                {
                    throw new Exception("Debe existir un usuario logueado.");
                }

                string nombreBackUp = this.ObtenerBackUpSeleccionado();

                DialogResult confirmacion = MessageBox.Show(
                    $"Se restaurara el back up {nombreBackUp}. Se reemplazara la base de datos actual. ¿Desea continuar?",
                    "Restore",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirmacion != DialogResult.Yes)
                {
                    return;
                }

                this.backUpRestoreBusiness.RestaurarBackUp(nombreBackUp, SesionActual.Usuario);
                MessageBox.Show("Se restauro el back up seleccionado.", "Restore", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                MessageBox.Show(ex.Message, "Restore", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string ObtenerBackUpSeleccionado()
        {
            if (dgvBackUps.CurrentRow == null)
            {
                throw new Exception("Debe seleccionar un back up.");
            }

            object? valor = dgvBackUps.CurrentRow.Cells["NombreBackUp"].Value;
            string? nombreBackUp = valor?.ToString();

            if (string.IsNullOrWhiteSpace(nombreBackUp))
            {
                throw new Exception("Debe seleccionar un back up valido.");
            }

            return nombreBackUp;
        }
    }
}


