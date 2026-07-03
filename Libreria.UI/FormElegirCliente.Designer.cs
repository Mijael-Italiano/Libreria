namespace Libreria.UI
{
    partial class FormElegirCliente
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
            dgvClientes = new DataGridView();
            colIdCliente = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colDocumento = new DataGridViewTextBoxColumn();
            grpBusqueda = new GroupBox();
            txtBuscarDocumento = new TextBox();
            lblBuscarDocumento = new Label();
            txtBuscarApellido = new TextBox();
            lblBuscarApellido = new Label();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            txtBuscarNombre = new TextBox();
            lblBuscarNombre = new Label();
            grpDatosCliente = new GroupBox();
            txtDocumento = new TextBox();
            lblDocumento = new Label();
            txtApellido = new TextBox();
            lblApellido = new Label();
            btnSeleccionar = new Button();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtId = new TextBox();
            lblId = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            grpBusqueda.SuspendLayout();
            grpDatosCliente.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(144, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Elegir cliente";
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.BackgroundColor = SystemColors.Window;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { colIdCliente, colNombre, colApellido, colDocumento });
            dgvClientes.Location = new Point(20, 72);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersVisible = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(520, 221);
            dgvClientes.TabIndex = 1;
            // 
            // colIdCliente
            // 
            colIdCliente.FillWeight = 35F;
            colIdCliente.HeaderText = "IdCliente";
            colIdCliente.Name = "colIdCliente";
            colIdCliente.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // colApellido
            // 
            colApellido.HeaderText = "Apellido";
            colApellido.Name = "colApellido";
            colApellido.ReadOnly = true;
            // 
            // colDocumento
            // 
            colDocumento.FillWeight = 70F;
            colDocumento.HeaderText = "DNI";
            colDocumento.Name = "colDocumento";
            colDocumento.ReadOnly = true;
            // 
            // grpBusqueda
            // 
            grpBusqueda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpBusqueda.Controls.Add(txtBuscarDocumento);
            grpBusqueda.Controls.Add(lblBuscarDocumento);
            grpBusqueda.Controls.Add(txtBuscarApellido);
            grpBusqueda.Controls.Add(lblBuscarApellido);
            grpBusqueda.Controls.Add(btnLimpiarBusqueda);
            grpBusqueda.Controls.Add(btnBuscar);
            grpBusqueda.Controls.Add(txtBuscarNombre);
            grpBusqueda.Controls.Add(lblBuscarNombre);
            grpBusqueda.Location = new Point(20, 310);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Size = new Size(520, 130);
            grpBusqueda.TabIndex = 2;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Buscar cliente";
            // 
            // txtBuscarDocumento
            // 
            txtBuscarDocumento.Location = new Point(105, 91);
            txtBuscarDocumento.Name = "txtBuscarDocumento";
            txtBuscarDocumento.Size = new Size(221, 23);
            txtBuscarDocumento.TabIndex = 5;
            // 
            // lblBuscarDocumento
            // 
            lblBuscarDocumento.AutoSize = true;
            lblBuscarDocumento.Location = new Point(18, 94);
            lblBuscarDocumento.Name = "lblBuscarDocumento";
            lblBuscarDocumento.Size = new Size(27, 15);
            lblBuscarDocumento.TabIndex = 4;
            lblBuscarDocumento.Text = "DNI";
            // 
            // txtBuscarApellido
            // 
            txtBuscarApellido.Location = new Point(105, 59);
            txtBuscarApellido.Name = "txtBuscarApellido";
            txtBuscarApellido.Size = new Size(221, 23);
            txtBuscarApellido.TabIndex = 3;
            // 
            // lblBuscarApellido
            // 
            lblBuscarApellido.AutoSize = true;
            lblBuscarApellido.Location = new Point(18, 62);
            lblBuscarApellido.Name = "lblBuscarApellido";
            lblBuscarApellido.Size = new Size(51, 15);
            lblBuscarApellido.TabIndex = 2;
            lblBuscarApellido.Text = "Apellido";
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLimpiarBusqueda.Location = new Point(372, 75);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(118, 27);
            btnLimpiarBusqueda.TabIndex = 7;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            btnLimpiarBusqueda.Click += btnLimpiarBusqueda_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnBuscar.Location = new Point(372, 37);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(118, 27);
            btnBuscar.TabIndex = 6;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.Location = new Point(105, 27);
            txtBuscarNombre.Name = "txtBuscarNombre";
            txtBuscarNombre.Size = new Size(221, 23);
            txtBuscarNombre.TabIndex = 1;
            // 
            // lblBuscarNombre
            // 
            lblBuscarNombre.AutoSize = true;
            lblBuscarNombre.Location = new Point(18, 30);
            lblBuscarNombre.Name = "lblBuscarNombre";
            lblBuscarNombre.Size = new Size(51, 15);
            lblBuscarNombre.TabIndex = 0;
            lblBuscarNombre.Text = "Nombre";
            // 
            // grpDatosCliente
            // 
            grpDatosCliente.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            grpDatosCliente.Controls.Add(txtDocumento);
            grpDatosCliente.Controls.Add(lblDocumento);
            grpDatosCliente.Controls.Add(txtApellido);
            grpDatosCliente.Controls.Add(lblApellido);
            grpDatosCliente.Controls.Add(btnSeleccionar);
            grpDatosCliente.Controls.Add(txtNombre);
            grpDatosCliente.Controls.Add(lblNombre);
            grpDatosCliente.Controls.Add(txtId);
            grpDatosCliente.Controls.Add(lblId);
            grpDatosCliente.Location = new Point(20, 455);
            grpDatosCliente.Name = "grpDatosCliente";
            grpDatosCliente.Size = new Size(520, 176);
            grpDatosCliente.TabIndex = 3;
            grpDatosCliente.TabStop = false;
            grpDatosCliente.Text = "Datos del cliente seleccionado";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(105, 133);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.ReadOnly = true;
            txtDocumento.Size = new Size(221, 23);
            txtDocumento.TabIndex = 7;
            // 
            // lblDocumento
            // 
            lblDocumento.AutoSize = true;
            lblDocumento.Location = new Point(18, 136);
            lblDocumento.Name = "lblDocumento";
            lblDocumento.Size = new Size(27, 15);
            lblDocumento.TabIndex = 6;
            lblDocumento.Text = "DNI";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(105, 100);
            txtApellido.Name = "txtApellido";
            txtApellido.ReadOnly = true;
            txtApellido.Size = new Size(221, 23);
            txtApellido.TabIndex = 5;
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(18, 103);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(51, 15);
            lblApellido.TabIndex = 4;
            lblApellido.Text = "Apellido";
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSeleccionar.Location = new Point(372, 129);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(118, 27);
            btnSeleccionar.TabIndex = 8;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(105, 67);
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(221, 23);
            txtNombre.TabIndex = 3;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(18, 70);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(51, 15);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // txtId
            // 
            txtId.BackColor = SystemColors.Control;
            txtId.ForeColor = SystemColors.ControlDark;
            txtId.Location = new Point(105, 31);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(221, 23);
            txtId.TabIndex = 1;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Location = new Point(18, 34);
            lblId.Name = "lblId";
            lblId.Size = new Size(18, 15);
            lblId.TabIndex = 0;
            lblId.Text = "ID";
            // 
            // FormElegirCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(564, 651);
            Controls.Add(grpDatosCliente);
            Controls.Add(grpBusqueda);
            Controls.Add(dgvClientes);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(580, 690);
            Name = "FormElegirCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Elegir cliente";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            grpDatosCliente.ResumeLayout(false);
            grpDatosCliente.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvClientes;
        private DataGridViewTextBoxColumn colIdCliente;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colDocumento;
        private GroupBox grpBusqueda;
        private TextBox txtBuscarDocumento;
        private Label lblBuscarDocumento;
        private TextBox txtBuscarApellido;
        private Label lblBuscarApellido;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
        private TextBox txtBuscarNombre;
        private Label lblBuscarNombre;
        private GroupBox grpDatosCliente;
        private TextBox txtDocumento;
        private Label lblDocumento;
        private TextBox txtApellido;
        private Label lblApellido;
        private Button btnSeleccionar;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtId;
        private Label lblId;
    }
}
