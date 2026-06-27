namespace Libreria.UI
{
    partial class FormElegirColor
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitulo = new Label();
            dgvColores = new DataGridView();
            colId = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            grpBusqueda = new GroupBox();
            btnLimpiarBusqueda = new Button();
            btnBuscar = new Button();
            txtBuscarNombre = new TextBox();
            lblBuscarNombre = new Label();
            grpDatosColor = new GroupBox();
            btnSeleccionar = new Button();
            chkSinColor = new CheckBox();
            txtNombre = new TextBox();
            lblNombre = new Label();
            txtId = new TextBox();
            lblId = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvColores).BeginInit();
            grpBusqueda.SuspendLayout();
            grpDatosColor.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitulo.Location = new Point(20, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(127, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Elegir color";
            // 
            // dgvColores
            // 
            dgvColores.AllowUserToAddRows = false;
            dgvColores.AllowUserToDeleteRows = false;
            dgvColores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvColores.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvColores.BackgroundColor = SystemColors.Window;
            dgvColores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvColores.Columns.AddRange(new DataGridViewColumn[] { colId, colNombre });
            dgvColores.Location = new Point(20, 72);
            dgvColores.MultiSelect = false;
            dgvColores.Name = "dgvColores";
            dgvColores.ReadOnly = true;
            dgvColores.RowHeadersVisible = false;
            dgvColores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvColores.Size = new Size(360, 235);
            dgvColores.TabIndex = 1;
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
            colNombre.HeaderText = "Color";
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
            grpBusqueda.Text = "Buscar color";
            // 
            // btnLimpiarBusqueda
            // 
            btnLimpiarBusqueda.Location = new Point(205, 58);
            btnLimpiarBusqueda.Name = "btnLimpiarBusqueda";
            btnLimpiarBusqueda.Size = new Size(118, 27);
            btnLimpiarBusqueda.TabIndex = 3;
            btnLimpiarBusqueda.Text = "Limpiar";
            btnLimpiarBusqueda.UseVisualStyleBackColor = true;
            btnLimpiarBusqueda.Click += btnLimpiarBusqueda_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(75, 58);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(118, 27);
            btnBuscar.TabIndex = 2;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
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
            // grpDatosColor
            // 
            grpDatosColor.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            grpDatosColor.Controls.Add(btnSeleccionar);
            grpDatosColor.Controls.Add(chkSinColor);
            grpDatosColor.Controls.Add(txtNombre);
            grpDatosColor.Controls.Add(lblNombre);
            grpDatosColor.Controls.Add(txtId);
            grpDatosColor.Controls.Add(lblId);
            grpDatosColor.Location = new Point(20, 430);
            grpDatosColor.Name = "grpDatosColor";
            grpDatosColor.Size = new Size(360, 139);
            grpDatosColor.TabIndex = 3;
            grpDatosColor.TabStop = false;
            grpDatosColor.Text = "Datos del color seleccionado";
            // 
            // chkSinColor
            // 
            chkSinColor.AutoSize = true;
            chkSinColor.Location = new Point(18, 101);
            chkSinColor.Name = "chkSinColor";
            chkSinColor.Size = new Size(100, 19);
            chkSinColor.TabIndex = 4;
            chkSinColor.Text = "Sin color";
            chkSinColor.UseVisualStyleBackColor = true;
            // 
            // btnSeleccionar
            // 
            btnSeleccionar.Location = new Point(205, 96);
            btnSeleccionar.Name = "btnSeleccionar";
            btnSeleccionar.Size = new Size(118, 27);
            btnSeleccionar.TabIndex = 5;
            btnSeleccionar.Text = "Seleccionar";
            btnSeleccionar.UseVisualStyleBackColor = true;
            btnSeleccionar.Click += btnSeleccionar_Click;
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
            // FormElegirColor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 581);
            Controls.Add(grpDatosColor);
            Controls.Add(grpBusqueda);
            Controls.Add(dgvColores);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(420, 620);
            Name = "FormElegirColor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Elegir color";
            ((System.ComponentModel.ISupportInitialize)dgvColores).EndInit();
            grpBusqueda.ResumeLayout(false);
            grpBusqueda.PerformLayout();
            grpDatosColor.ResumeLayout(false);
            grpDatosColor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private DataGridView dgvColores;
        private DataGridViewTextBoxColumn colId;
        private DataGridViewTextBoxColumn colNombre;
        private GroupBox grpBusqueda;
        private Button btnLimpiarBusqueda;
        private Button btnBuscar;
        private TextBox txtBuscarNombre;
        private Label lblBuscarNombre;
        private GroupBox grpDatosColor;
        private Button btnSeleccionar;
        private CheckBox chkSinColor;
        private TextBox txtNombre;
        private Label lblNombre;
        private TextBox txtId;
        private Label lblId;
    }
}
