namespace Libreria.UI
{
    partial class FormElegirMarca
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
            dgvMarcas = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            grpBusqueda = new GroupBox();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            txtBuscarNombre = new TextBox();
            lblBuscarNombre = new Label();
            grpDatosMarca = new GroupBox();
            btnSeleccionar = new Button();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtId = new TextBox();
            lblId = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).BeginInit();
            grpBusqueda.SuspendLayout();
            grpDatosMarca.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(142, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Elegir marca";
            // 
            // dgvMarcas
            // 
            dgvMarcas.AllowUserToAddRows = false;
            dgvMarcas.AllowUserToDeleteRows = false;
            dgvMarcas.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMarcas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMarcas.BackgroundColor = SystemColors.Window;
            dgvMarcas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMarcas.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre });
            dgvMarcas.Location = new Point(20, 72);
            dgvMarcas.MultiSelect = false;
            dgvMarcas.Name = "dgvMarcas";
            dgvMarcas.ReadOnly = true;
            dgvMarcas.RowHeadersVisible = false;
            dgvMarcas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMarcas.Size = new Size(360, 235);
            dgvMarcas.TabIndex = 1;
            // 
            // colId
            // 
            colId.FillWeight = 35F;
            colId.HeaderText = "Id";
            colId.Name = "colId";
            colId.ReadOnly = true;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Marca";
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            // 
            // grpBusqueda
            // 
            grpBusqueda.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpBusqueda.Controls.Add(btnLimpiarBusqueda);
            grpBusqueda.Controls.Add(btnBuscar);
            grpBusqueda.Controls.Add(txtBuscarNombre);
            grpBusqueda.Controls.Add(lblBuscarNombre);
            grpBusqueda.Location = new Point(20, 324);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Size = new Size(360, 94);
            grpBusqueda.TabIndex = 2;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Buscar marca";
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Location = new Point(205, 58);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(118, 27);
            btnLimpiarBusqueda.TabIndex = 3;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(75, 58);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(118, 27);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscarNombre
            // 
            txtBuscarNombre.Location = new Point(102, 27);
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
            // grpDatosMarca
            // 
            grpDatosMarca.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpDatosMarca.Controls.Add(btnSeleccionar);
            grpDatosMarca.Controls.Add(txtNombre);
            grpDatosMarca.Controls.Add(lblNombre);
            grpDatosMarca.Controls.Add(txtId);
            grpDatosMarca.Controls.Add(lblId);
            grpDatosMarca.Location = new Point(20, 430);
            grpDatosMarca.Name = "grpDatosMarca";
            grpDatosMarca.Size = new Size(360, 139);
            grpDatosMarca.TabIndex = 3;
            grpDatosMarca.TabStop = false;
            grpDatosMarca.Text = "Datos de la marca seleccionada";
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(205, 96);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(118, 27);
            btnSeleccionar.TabIndex = 5;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(102, 67);
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
            txtId.Location = new Point(102, 31);
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
            // FormElegirMarca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 581);
            Controls.Add(grpDatosMarca);
            Controls.Add(grpBusqueda);
            Controls.Add(dgvMarcas);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(420, 620);
            Name = "FormElegirMarca";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Elegir marca";
            ((System.ComponentModel.ISupportInitialize)dgvMarcas).EndInit();
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            grpDatosMarca.ResumeLayout(false);
            grpDatosMarca.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvMarcas;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private GroupBox grpBusqueda;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
        private TextBox txtBuscarNombre;
        private Label lblBuscarNombre;
        private GroupBox grpDatosMarca;
        private Button btnSeleccionar;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtId;
        private Label lblId;
    }
}
