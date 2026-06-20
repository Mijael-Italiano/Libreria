namespace Libreria.UI
{
    partial class FormRegistrarVenta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitulo = new Label();
            dgvFacturas = new DataGridView();
            colIdFactura = new DataGridViewTextBoxColumn();
            colIdCliente = new DataGridViewTextBoxColumn();
            colNombreCliente = new DataGridViewTextBoxColumn();
            colApellidoCliente = new DataGridViewTextBoxColumn();
            colDniCliente = new DataGridViewTextBoxColumn();
            colUsuario = new DataGridViewTextBoxColumn();
            colFechaEmision = new DataGridViewTextBoxColumn();
            colTotal = new DataGridViewTextBoxColumn();
            colEstado = new DataGridViewTextBoxColumn();
            grpBusqueda = new GroupBox();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            txtBuscarApellidoCliente = new TextBox();
            lblBuscarApellidoCliente = new Label();
            txtBuscarNombreCliente = new TextBox();
            lblBuscarNombreCliente = new Label();
            txtBuscarDocumentoCliente = new TextBox();
            lblBuscarDocumentoCliente = new Label();
            txtBuscarIdCliente = new TextBox();
            lblBuscarIdCliente = new Label();
            grpAltaFactura = new GroupBox();
            btnAltaSeleccionarCliente = new Button();
            btnCrearFactura = new Button();
            txtAltaDocumentoCliente = new TextBox();
            lblAltaDocumentoCliente = new Label();
            txtAltaApellidoCliente = new TextBox();
            lblAltaApellidoCliente = new Label();
            txtAltaNombreCliente = new TextBox();
            lblAltaNombreCliente = new Label();
            txtAltaIdCliente = new TextBox();
            lblAltaIdCliente = new Label();
            grpDatosFactura = new GroupBox();
            btnSeleccionadoSeleccionarCliente = new Button();
            pnlAcciones = new Panel();
            btnLimpiar = new Button();
            btnAnular = new Button();
            btnModificar = new Button();
            txtTotal = new TextBox();
            lblTotal = new Label();
            txtEstado = new TextBox();
            txtFechaEmision = new TextBox();
            txtUsuario = new TextBox();
            lblEstado = new Label();
            lblFechaEmision = new Label();
            lblUsuario = new Label();
            txtDniCliente = new TextBox();
            lblDniCliente = new Label();
            txtApellidoCliente = new TextBox();
            lblApellidoCliente = new Label();
            txtNombreCliente = new TextBox();
            lblNombreCliente = new Label();
            txtIdCliente = new TextBox();
            lblIdCliente = new Label();
            txtIdFactura = new TextBox();
            lblIdFactura = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).BeginInit();
            grpBusqueda.SuspendLayout();
            grpAltaFactura.SuspendLayout();
            grpDatosFactura.SuspendLayout();
            pnlAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(171, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Registrar venta";
            // 
            // dgvFacturas
            // 
            dgvFacturas.AllowUserToAddRows = false;
            dgvFacturas.AllowUserToDeleteRows = false;
            dgvFacturas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFacturas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFacturas.BackgroundColor = SystemColors.Window;
            dgvFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFacturas.Columns.AddRange(new DataGridViewColumn[] { colIdFactura, colIdCliente, colNombreCliente, colApellidoCliente, colDniCliente, colUsuario, colFechaEmision, colTotal, colEstado });
            dgvFacturas.Location = new Point(20, 72);
            dgvFacturas.MultiSelect = false;
            dgvFacturas.Name = "dgvFacturas";
            dgvFacturas.ReadOnly = true;
            dgvFacturas.RowHeadersVisible = false;
            dgvFacturas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFacturas.Size = new Size(778, 275);
            dgvFacturas.TabIndex = 1;
            // 
            // colIdFactura
            // 
            colIdFactura.FillWeight = 55F;
            colIdFactura.HeaderText = "Id factura";
            colIdFactura.Name = "colIdFactura";
            colIdFactura.ReadOnly = true;
            // 
            // colIdCliente
            // 
            colIdCliente.FillWeight = 55F;
            colIdCliente.HeaderText = "Id cliente";
            colIdCliente.Name = "colIdCliente";
            colIdCliente.ReadOnly = true;
            // 
            // colNombreCliente
            // 
            colNombreCliente.HeaderText = "Nombre cliente";
            colNombreCliente.Name = "colNombreCliente";
            colNombreCliente.ReadOnly = true;
            // 
            // colApellidoCliente
            // 
            colApellidoCliente.HeaderText = "Apellido cliente";
            colApellidoCliente.Name = "colApellidoCliente";
            colApellidoCliente.ReadOnly = true;
            // 
            // colDniCliente
            // 
            colDniCliente.FillWeight = 75F;
            colDniCliente.HeaderText = "DNI cliente";
            colDniCliente.Name = "colDniCliente";
            colDniCliente.ReadOnly = true;
            // 
            // colUsuario
            // 
            colUsuario.FillWeight = 85F;
            colUsuario.HeaderText = "Usuario";
            colUsuario.Name = "colUsuario";
            colUsuario.ReadOnly = true;
            // 
            // colFechaEmision
            // 
            colFechaEmision.FillWeight = 85F;
            colFechaEmision.HeaderText = "Fecha emisión";
            colFechaEmision.Name = "colFechaEmision";
            colFechaEmision.ReadOnly = true;
            // 
            // colTotal
            // 
            colTotal.FillWeight = 70F;
            colTotal.HeaderText = "Total";
            colTotal.Name = "colTotal";
            colTotal.ReadOnly = true;
            // 
            // colEstado
            // 
            colEstado.FillWeight = 70F;
            colEstado.HeaderText = "Estado";
            colEstado.Name = "colEstado";
            colEstado.ReadOnly = true;
            // 
            // grpBusqueda
            // 
            grpBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            grpBusqueda.Controls.Add(btnLimpiarBusqueda);
            grpBusqueda.Controls.Add(btnBuscar);
            grpBusqueda.Controls.Add(txtBuscarApellidoCliente);
            grpBusqueda.Controls.Add(lblBuscarApellidoCliente);
            grpBusqueda.Controls.Add(txtBuscarNombreCliente);
            grpBusqueda.Controls.Add(lblBuscarNombreCliente);
            grpBusqueda.Controls.Add(txtBuscarDocumentoCliente);
            grpBusqueda.Controls.Add(lblBuscarDocumentoCliente);
            grpBusqueda.Controls.Add(txtBuscarIdCliente);
            grpBusqueda.Controls.Add(lblBuscarIdCliente);
            grpBusqueda.Location = new Point(841, 72);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Size = new Size(456, 143);
            grpBusqueda.TabIndex = 2;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Buscar factura";
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Location = new Point(149, 96);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(118, 27);
            btnLimpiarBusqueda.TabIndex = 9;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(15, 96);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(118, 27);
            btnBuscar.TabIndex = 8;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscarApellidoCliente
            // 
            txtBuscarApellidoCliente.Location = new Point(308, 61);
            txtBuscarApellidoCliente.Name = "txtBuscarApellidoCliente";
            txtBuscarApellidoCliente.Size = new Size(110, 23);
            txtBuscarApellidoCliente.TabIndex = 7;
            // 
            // lblBuscarApellidoCliente
            // 
            lblBuscarApellidoCliente.AutoSize = true;
            lblBuscarApellidoCliente.Location = new Point(240, 64);
            lblBuscarApellidoCliente.Name = "lblBuscarApellidoCliente";
            lblBuscarApellidoCliente.Size = new Size(51, 15);
            lblBuscarApellidoCliente.TabIndex = 6;
            lblBuscarApellidoCliente.Text = "Apellido";
            // 
            // txtBuscarNombreCliente
            // 
            txtBuscarNombreCliente.Location = new Point(308, 31);
            txtBuscarNombreCliente.Name = "txtBuscarNombreCliente";
            txtBuscarNombreCliente.Size = new Size(110, 23);
            txtBuscarNombreCliente.TabIndex = 5;
            // 
            // lblBuscarNombreCliente
            // 
            lblBuscarNombreCliente.AutoSize = true;
            lblBuscarNombreCliente.Location = new Point(240, 34);
            lblBuscarNombreCliente.Name = "lblBuscarNombreCliente";
            lblBuscarNombreCliente.Size = new Size(51, 15);
            lblBuscarNombreCliente.TabIndex = 4;
            lblBuscarNombreCliente.Text = "Nombre";
            // 
            // txtBuscarDocumentoCliente
            // 
            txtBuscarDocumentoCliente.Location = new Point(105, 58);
            txtBuscarDocumentoCliente.Name = "txtBuscarDocumentoCliente";
            txtBuscarDocumentoCliente.Size = new Size(110, 23);
            txtBuscarDocumentoCliente.TabIndex = 3;
            // 
            // lblBuscarDocumentoCliente
            // 
            lblBuscarDocumentoCliente.AutoSize = true;
            lblBuscarDocumentoCliente.Location = new Point(15, 61);
            lblBuscarDocumentoCliente.Name = "lblBuscarDocumentoCliente";
            lblBuscarDocumentoCliente.Size = new Size(70, 15);
            lblBuscarDocumentoCliente.TabIndex = 2;
            lblBuscarDocumentoCliente.Text = "Documento";
            // 
            // txtBuscarIdCliente
            // 
            txtBuscarIdCliente.Location = new Point(105, 28);
            txtBuscarIdCliente.Name = "txtBuscarIdCliente";
            txtBuscarIdCliente.Size = new Size(70, 23);
            txtBuscarIdCliente.TabIndex = 1;
            // 
            // lblBuscarIdCliente
            // 
            lblBuscarIdCliente.AutoSize = true;
            lblBuscarIdCliente.Location = new Point(15, 31);
            lblBuscarIdCliente.Name = "lblBuscarIdCliente";
            lblBuscarIdCliente.Size = new Size(55, 15);
            lblBuscarIdCliente.TabIndex = 0;
            lblBuscarIdCliente.Text = "Id cliente";
            // 
            // grpAltaFactura
            // 
            grpAltaFactura.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpAltaFactura.Controls.Add(btnAltaSeleccionarCliente);
            grpAltaFactura.Controls.Add(btnCrearFactura);
            grpAltaFactura.Controls.Add(txtAltaDocumentoCliente);
            grpAltaFactura.Controls.Add(lblAltaDocumentoCliente);
            grpAltaFactura.Controls.Add(txtAltaApellidoCliente);
            grpAltaFactura.Controls.Add(lblAltaApellidoCliente);
            grpAltaFactura.Controls.Add(txtAltaNombreCliente);
            grpAltaFactura.Controls.Add(lblAltaNombreCliente);
            grpAltaFactura.Controls.Add(txtAltaIdCliente);
            grpAltaFactura.Controls.Add(lblAltaIdCliente);
            grpAltaFactura.Location = new Point(841, 235);
            grpAltaFactura.Name = "grpAltaFactura";
            grpAltaFactura.Size = new Size(456, 130);
            grpAltaFactura.TabIndex = 3;
            grpAltaFactura.TabStop = false;
            grpAltaFactura.Text = "Datos de alta factura";
            // 
            // btnAltaSeleccionarCliente
            // 
            btnAltaSeleccionarCliente.Location = new Point(170, 30);
            btnAltaSeleccionarCliente.Name = "btnAltaSeleccionarCliente";
            btnAltaSeleccionarCliente.Size = new Size(50, 27);
            btnAltaSeleccionarCliente.TabIndex = 4;
            btnAltaSeleccionarCliente.Text = "...";
            btnAltaSeleccionarCliente.UseVisualStyleBackColor = true;
            // 
            // btnCrearFactura
            // 
            btnCrearFactura.Location = new Point(84, 91);
            btnCrearFactura.Name = "btnCrearFactura";
            btnCrearFactura.Size = new Size(136, 27);
            btnCrearFactura.TabIndex = 13;
            btnCrearFactura.Text = "Crear factura";
            btnCrearFactura.UseVisualStyleBackColor = true;
            // 
            // txtAltaDocumentoCliente
            // 
            txtAltaDocumentoCliente.BackColor = SystemColors.Control;
            txtAltaDocumentoCliente.ForeColor = SystemColors.ControlDark;
            txtAltaDocumentoCliente.Location = new Point(332, 37);
            txtAltaDocumentoCliente.Name = "txtAltaDocumentoCliente";
            txtAltaDocumentoCliente.ReadOnly = true;
            txtAltaDocumentoCliente.Size = new Size(104, 23);
            txtAltaDocumentoCliente.TabIndex = 10;
            // 
            // lblAltaDocumentoCliente
            // 
            lblAltaDocumentoCliente.AutoSize = true;
            lblAltaDocumentoCliente.Location = new Point(256, 36);
            lblAltaDocumentoCliente.Name = "lblAltaDocumentoCliente";
            lblAltaDocumentoCliente.Size = new Size(70, 15);
            lblAltaDocumentoCliente.TabIndex = 9;
            lblAltaDocumentoCliente.Text = "Documento";
            // 
            // txtAltaApellidoCliente
            // 
            txtAltaApellidoCliente.BackColor = SystemColors.Control;
            txtAltaApellidoCliente.ForeColor = SystemColors.ControlDark;
            txtAltaApellidoCliente.Location = new Point(332, 66);
            txtAltaApellidoCliente.Name = "txtAltaApellidoCliente";
            txtAltaApellidoCliente.ReadOnly = true;
            txtAltaApellidoCliente.Size = new Size(104, 23);
            txtAltaApellidoCliente.TabIndex = 8;
            // 
            // lblAltaApellidoCliente
            // 
            lblAltaApellidoCliente.AutoSize = true;
            lblAltaApellidoCliente.Location = new Point(256, 70);
            lblAltaApellidoCliente.Name = "lblAltaApellidoCliente";
            lblAltaApellidoCliente.Size = new Size(51, 15);
            lblAltaApellidoCliente.TabIndex = 7;
            lblAltaApellidoCliente.Text = "Apellido";
            // 
            // txtAltaNombreCliente
            // 
            txtAltaNombreCliente.BackColor = SystemColors.Control;
            txtAltaNombreCliente.ForeColor = SystemColors.ControlDark;
            txtAltaNombreCliente.Location = new Point(88, 62);
            txtAltaNombreCliente.Name = "txtAltaNombreCliente";
            txtAltaNombreCliente.ReadOnly = true;
            txtAltaNombreCliente.Size = new Size(130, 23);
            txtAltaNombreCliente.TabIndex = 6;
            // 
            // lblAltaNombreCliente
            // 
            lblAltaNombreCliente.AutoSize = true;
            lblAltaNombreCliente.Location = new Point(18, 62);
            lblAltaNombreCliente.Name = "lblAltaNombreCliente";
            lblAltaNombreCliente.Size = new Size(51, 15);
            lblAltaNombreCliente.TabIndex = 5;
            lblAltaNombreCliente.Text = "Nombre";
            // 
            // txtAltaIdCliente
            // 
            txtAltaIdCliente.BackColor = SystemColors.Control;
            txtAltaIdCliente.ForeColor = SystemColors.ControlDark;
            txtAltaIdCliente.Location = new Point(88, 33);
            txtAltaIdCliente.Name = "txtAltaIdCliente";
            txtAltaIdCliente.ReadOnly = true;
            txtAltaIdCliente.Size = new Size(70, 23);
            txtAltaIdCliente.TabIndex = 3;
            // 
            // lblAltaIdCliente
            // 
            lblAltaIdCliente.AutoSize = true;
            lblAltaIdCliente.Location = new Point(18, 35);
            lblAltaIdCliente.Name = "lblAltaIdCliente";
            lblAltaIdCliente.Size = new Size(55, 15);
            lblAltaIdCliente.TabIndex = 2;
            lblAltaIdCliente.Text = "Id cliente";
            // 
            // grpDatosFactura
            // 
            grpDatosFactura.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDatosFactura.Controls.Add(btnSeleccionadoSeleccionarCliente);
            grpDatosFactura.Controls.Add(pnlAcciones);
            grpDatosFactura.Controls.Add(txtTotal);
            grpDatosFactura.Controls.Add(lblTotal);
            grpDatosFactura.Controls.Add(txtEstado);
            grpDatosFactura.Controls.Add(txtFechaEmision);
            grpDatosFactura.Controls.Add(txtUsuario);
            grpDatosFactura.Controls.Add(lblEstado);
            grpDatosFactura.Controls.Add(lblFechaEmision);
            grpDatosFactura.Controls.Add(lblUsuario);
            grpDatosFactura.Controls.Add(txtDniCliente);
            grpDatosFactura.Controls.Add(lblDniCliente);
            grpDatosFactura.Controls.Add(txtApellidoCliente);
            grpDatosFactura.Controls.Add(lblApellidoCliente);
            grpDatosFactura.Controls.Add(txtNombreCliente);
            grpDatosFactura.Controls.Add(lblNombreCliente);
            grpDatosFactura.Controls.Add(txtIdCliente);
            grpDatosFactura.Controls.Add(lblIdCliente);
            grpDatosFactura.Controls.Add(txtIdFactura);
            grpDatosFactura.Controls.Add(lblIdFactura);
            grpDatosFactura.Location = new Point(841, 388);
            grpDatosFactura.Name = "grpDatosFactura";
            grpDatosFactura.Size = new Size(454, 245);
            grpDatosFactura.TabIndex = 4;
            grpDatosFactura.TabStop = false;
            grpDatosFactura.Text = "Datos de la factura seleccionada";
            // 
            // btnSeleccionadoSeleccionarCliente
            // 
            btnSeleccionadoSeleccionarCliente.Location = new Point(165, 56);
            btnSeleccionadoSeleccionarCliente.Name = "btnSeleccionadoSeleccionarCliente";
            btnSeleccionadoSeleccionarCliente.Size = new Size(50, 27);
            btnSeleccionadoSeleccionarCliente.TabIndex = 4;
            btnSeleccionadoSeleccionarCliente.Text = "...";
            btnSeleccionadoSeleccionarCliente.UseVisualStyleBackColor = true;
            // 
            // pnlAcciones
            // 
            pnlAcciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlAcciones.Controls.Add(btnLimpiar);
            pnlAcciones.Controls.Add(btnAnular);
            pnlAcciones.Controls.Add(btnModificar);
            pnlAcciones.Location = new Point(6, 191);
            pnlAcciones.Name = "pnlAcciones";
            pnlAcciones.Size = new Size(442, 49);
            pnlAcciones.TabIndex = 14;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(294, 10);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(118, 27);
            btnLimpiar.TabIndex = 2;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnAnular
            // 
            btnAnular.Location = new Point(164, 10);
            btnAnular.Name = "btnAnular";
            btnAnular.Size = new Size(118, 27);
            btnAnular.TabIndex = 1;
            btnAnular.Text = "Anular";
            btnAnular.UseVisualStyleBackColor = true;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(14, 10);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(138, 27);
            btnModificar.TabIndex = 0;
            btnModificar.Text = "Modificar items";
            btnModificar.UseVisualStyleBackColor = true;
            // 
            // txtTotal
            // 
            txtTotal.BackColor = SystemColors.Control;
            txtTotal.ForeColor = SystemColors.ControlDark;
            txtTotal.Location = new Point(319, 117);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(117, 23);
            txtTotal.TabIndex = 13;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(271, 120);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(32, 15);
            lblTotal.TabIndex = 12;
            lblTotal.Text = "Total";
            // 
            // txtEstado
            // 
            txtEstado.BackColor = SystemColors.Control;
            txtEstado.ForeColor = SystemColors.ControlDark;
            txtEstado.Location = new Point(319, 88);
            txtEstado.Name = "txtEstado";
            txtEstado.ReadOnly = true;
            txtEstado.Size = new Size(117, 23);
            txtEstado.TabIndex = 11;
            // 
            // txtFechaEmision
            // 
            txtFechaEmision.BackColor = SystemColors.Control;
            txtFechaEmision.ForeColor = SystemColors.ControlDark;
            txtFechaEmision.Location = new Point(319, 59);
            txtFechaEmision.Name = "txtFechaEmision";
            txtFechaEmision.ReadOnly = true;
            txtFechaEmision.Size = new Size(117, 23);
            txtFechaEmision.TabIndex = 9;
            // 
            // txtUsuario
            // 
            txtUsuario.BackColor = SystemColors.Control;
            txtUsuario.ForeColor = SystemColors.ControlDark;
            txtUsuario.Location = new Point(319, 31);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.ReadOnly = true;
            txtUsuario.Size = new Size(117, 23);
            txtUsuario.TabIndex = 7;
            // 
            // lblEstado
            // 
            lblEstado.AutoSize = true;
            lblEstado.Location = new Point(265, 88);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(42, 15);
            lblEstado.TabIndex = 10;
            lblEstado.Text = "Estado";
            // 
            // lblFechaEmision
            // 
            lblFechaEmision.AutoSize = true;
            lblFechaEmision.Location = new Point(265, 62);
            lblFechaEmision.Name = "lblFechaEmision";
            lblFechaEmision.Size = new Size(38, 15);
            lblFechaEmision.TabIndex = 8;
            lblFechaEmision.Text = "Fecha";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(265, 31);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(47, 15);
            lblUsuario.TabIndex = 6;
            lblUsuario.Text = "Usuario";
            // 
            // txtDniCliente
            // 
            txtDniCliente.BackColor = SystemColors.Control;
            txtDniCliente.ForeColor = SystemColors.ControlDark;
            txtDniCliente.Location = new Point(105, 152);
            txtDniCliente.Name = "txtDniCliente";
            txtDniCliente.ReadOnly = true;
            txtDniCliente.Size = new Size(110, 23);
            txtDniCliente.TabIndex = 17;
            // 
            // lblDniCliente
            // 
            lblDniCliente.AutoSize = true;
            lblDniCliente.Location = new Point(18, 155);
            lblDniCliente.Name = "lblDniCliente";
            lblDniCliente.Size = new Size(27, 15);
            lblDniCliente.TabIndex = 16;
            lblDniCliente.Text = "DNI";
            // 
            // txtApellidoCliente
            // 
            txtApellidoCliente.BackColor = SystemColors.Control;
            txtApellidoCliente.ForeColor = SystemColors.ControlDark;
            txtApellidoCliente.Location = new Point(105, 123);
            txtApellidoCliente.Name = "txtApellidoCliente";
            txtApellidoCliente.ReadOnly = true;
            txtApellidoCliente.Size = new Size(110, 23);
            txtApellidoCliente.TabIndex = 15;
            // 
            // lblApellidoCliente
            // 
            lblApellidoCliente.AutoSize = true;
            lblApellidoCliente.Location = new Point(18, 126);
            lblApellidoCliente.Name = "lblApellidoCliente";
            lblApellidoCliente.Size = new Size(51, 15);
            lblApellidoCliente.TabIndex = 14;
            lblApellidoCliente.Text = "Apellido";
            // 
            // txtNombreCliente
            // 
            txtNombreCliente.BackColor = SystemColors.Control;
            txtNombreCliente.ForeColor = SystemColors.ControlDark;
            txtNombreCliente.Location = new Point(105, 94);
            txtNombreCliente.Name = "txtNombreCliente";
            txtNombreCliente.ReadOnly = true;
            txtNombreCliente.Size = new Size(110, 23);
            txtNombreCliente.TabIndex = 5;
            // 
            // lblNombreCliente
            // 
            lblNombreCliente.AutoSize = true;
            lblNombreCliente.Location = new Point(18, 97);
            lblNombreCliente.Name = "lblNombreCliente";
            lblNombreCliente.Size = new Size(51, 15);
            lblNombreCliente.TabIndex = 4;
            lblNombreCliente.Text = "Nombre";
            // 
            // txtIdCliente
            // 
            txtIdCliente.BackColor = SystemColors.Control;
            txtIdCliente.ForeColor = SystemColors.ControlDark;
            txtIdCliente.Location = new Point(105, 59);
            txtIdCliente.Name = "txtIdCliente";
            txtIdCliente.ReadOnly = true;
            txtIdCliente.Size = new Size(43, 23);
            txtIdCliente.TabIndex = 3;
            // 
            // lblIdCliente
            // 
            lblIdCliente.AutoSize = true;
            lblIdCliente.Location = new Point(20, 65);
            lblIdCliente.Name = "lblIdCliente";
            lblIdCliente.Size = new Size(55, 15);
            lblIdCliente.TabIndex = 2;
            lblIdCliente.Text = "Id cliente";
            // 
            // txtIdFactura
            // 
            txtIdFactura.BackColor = SystemColors.Control;
            txtIdFactura.ForeColor = SystemColors.ControlDark;
            txtIdFactura.Location = new Point(105, 30);
            txtIdFactura.Name = "txtIdFactura";
            txtIdFactura.ReadOnly = true;
            txtIdFactura.Size = new Size(43, 23);
            txtIdFactura.TabIndex = 1;
            // 
            // lblIdFactura
            // 
            lblIdFactura.AutoSize = true;
            lblIdFactura.Location = new Point(18, 33);
            lblIdFactura.Name = "lblIdFactura";
            lblIdFactura.Size = new Size(57, 15);
            lblIdFactura.TabIndex = 0;
            lblIdFactura.Text = "Id factura";
            // 
            // FormRegistrarVenta
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1307, 681);
            Controls.Add(grpDatosFactura);
            Controls.Add(grpAltaFactura);
            Controls.Add(grpBusqueda);
            Controls.Add(dgvFacturas);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(1256, 720);
            Name = "FormRegistrarVenta";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar venta";
            ((System.ComponentModel.ISupportInitialize)dgvFacturas).EndInit();
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            grpAltaFactura.ResumeLayout(false);
            grpAltaFactura.PerformLayout();
            grpDatosFactura.ResumeLayout(false);
            grpDatosFactura.PerformLayout();
            pnlAcciones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvFacturas;
        private DataGridViewTextBoxColumn colIdFactura;
        private DataGridViewTextBoxColumn colIdCliente;
        private DataGridViewTextBoxColumn colNombreCliente;
        private DataGridViewTextBoxColumn colApellidoCliente;
        private DataGridViewTextBoxColumn colDniCliente;
        private DataGridViewTextBoxColumn colUsuario;
        private DataGridViewTextBoxColumn colFechaEmision;
        private DataGridViewTextBoxColumn colTotal;
        private DataGridViewTextBoxColumn colEstado;
        private GroupBox grpBusqueda;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
        private TextBox txtBuscarApellidoCliente;
        private Label lblBuscarApellidoCliente;
        private TextBox txtBuscarNombreCliente;
        private Label lblBuscarNombreCliente;
        private TextBox txtBuscarDocumentoCliente;
        private Label lblBuscarDocumentoCliente;
        private TextBox txtBuscarIdCliente;
        private Label lblBuscarIdCliente;
        private GroupBox grpAltaFactura;
        private Button btnAltaSeleccionarCliente;
        private Button btnCrearFactura;
        private TextBox txtAltaDocumentoCliente;
        private Label lblAltaDocumentoCliente;
        private TextBox txtAltaApellidoCliente;
        private Label lblAltaApellidoCliente;
        private TextBox txtAltaNombreCliente;
        private Label lblAltaNombreCliente;
        private TextBox txtAltaIdCliente;
        private Label lblAltaIdCliente;
        private GroupBox grpDatosFactura;
        private Button btnSeleccionadoSeleccionarCliente;
        private Panel pnlAcciones;
        private Button btnLimpiar;
        private Button btnAnular;
        private Button btnModificar;
        private TextBox txtTotal;
        private Label lblTotal;
        private TextBox txtEstado;
        private Label lblEstado;
        private TextBox txtFechaEmision;
        private Label lblFechaEmision;
        private TextBox txtUsuario;
        private Label lblUsuario;
        private TextBox txtDniCliente;
        private Label lblDniCliente;
        private TextBox txtApellidoCliente;
        private Label lblApellidoCliente;
        private TextBox txtNombreCliente;
        private Label lblNombreCliente;
        private TextBox txtIdCliente;
        private Label lblIdCliente;
        private TextBox txtIdFactura;
        private Label lblIdFactura;
    }
}
