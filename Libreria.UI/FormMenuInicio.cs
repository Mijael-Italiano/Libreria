using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Libreria.Sesion;

namespace Libreria.UI
{
    public partial class FormMenuInicio : Form
    {
        private bool cerrandoSesion;

        public FormMenuInicio()
        {
            InitializeComponent();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.cerrandoSesion = true;
            SesionActual.Cerrar();

            FormIniciarSesion formIniciarSesion = new FormIniciarSesion();
            formIniciarSesion.Show();
            this.Close();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormMenuInicio_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.cerrandoSesion)
            {
                Application.Exit();
            }
        }

    }
}
