using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Libreria.Business;
using Libreria.Entity;

namespace Libreria.UI
{
    public partial class FormBitacora : Form
    {
        private readonly RegistroAuditoriaBusiness registroAuditoriaBusiness;
        private readonly TipoRegistroAuditoriaBusiness tipoRegistroAuditoriaBusiness;

        public FormBitacora()
        {
            InitializeComponent();
            this.registroAuditoriaBusiness = new RegistroAuditoriaBusiness();
            this.tipoRegistroAuditoriaBusiness = new TipoRegistroAuditoriaBusiness();
        }

        private void FormBitacora_Load(object? sender, EventArgs e)
        {
            this.CargarTipos();
            this.ConfigurarFechas();
            this.CargarRegistros();
        }

        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            this.CargarRegistros();
        }

        private void btnLimpiar_Click(object? sender, EventArgs e)
        {
            cboTipo.SelectedIndex = 0;
            this.ConfigurarFechas();
            this.CargarRegistros();
        }

        private void CargarTipos()
        {
            List<TipoRegistroAuditoria> tipos = this.tipoRegistroAuditoriaBusiness.ConsultarTiposRegistroAuditoria();
            tipos.Insert(0, new TipoRegistroAuditoria { Id = 0, Nombre = "Todos" });

            cboTipo.DisplayMember = "Nombre";
            cboTipo.ValueMember = "Id";
            cboTipo.DataSource = tipos;
        }

        private void ConfigurarFechas()
        {
            dtpDesde.Value = DateTime.Today.AddMonths(-1);
            dtpHasta.Value = DateTime.Today;
        }

        private void CargarRegistros()
        {
            try
            {
                IEnumerable<RegistroAuditoria> registros = this.registroAuditoriaBusiness.ConsultarRegistrosAuditoria();

                int idTipo = cboTipo.SelectedValue is int valor ? valor : 0;

                if (idTipo > 0)
                {
                    registros = registros.Where(registro => registro.Tipo.Id == idTipo);
                }

                registros = registros.Where(registro =>
                    registro.Fecha.Date >= dtpDesde.Value.Date && registro.Fecha.Date <= dtpHasta.Value.Date
                );

                dgvRegistros.DataSource = registros
                    .OrderByDescending(registro => registro.Fecha)
                    .Select(registro => new
                    {
                        registro.Id,
                        registro.Fecha,
                        Tipo = registro.Tipo.Nombre,
                        registro.NombreBackUp,
                        Dni = registro.UsuarioAuditoria.Dni,
                        Nombre = registro.UsuarioAuditoria.Nombre,
                        Apellido = registro.UsuarioAuditoria.Apellido,
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Bitacora", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

