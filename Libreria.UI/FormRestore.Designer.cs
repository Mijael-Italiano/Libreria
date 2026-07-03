namespace Libreria.UI
{
    partial class FormRestore
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
            lblDescripcion = new Label();
            dgvBackUps = new DataGridView();
            btnRestaurar = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBackUps).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(24, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(171, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Restore de sistema";
            // 
            // lblDescripcion
            // 
            lblDescripcion.AutoSize = true;
            lblDescripcion.Location = new Point(26, 62);
            lblDescripcion.Name = "lblDescripcion";
            lblDescripcion.Size = new Size(307, 15);
            lblDescripcion.TabIndex = 1;
            lblDescripcion.Text = "Seleccione el back up que desea restaurar.";
            // 
            // dgvBackUps
            // 
            dgvBackUps.AllowUserToAddRows = false;
            dgvBackUps.AllowUserToDeleteRows = false;
            dgvBackUps.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvBackUps.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBackUps.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBackUps.Location = new Point(26, 96);
            dgvBackUps.MultiSelect = false;
            dgvBackUps.Name = "dgvBackUps";
            dgvBackUps.ReadOnly = true;
            dgvBackUps.RowHeadersVisible = false;
            dgvBackUps.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBackUps.Size = new Size(746, 282);
            dgvBackUps.TabIndex = 2;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRestaurar.Location = new Point(629, 396);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(143, 32);
            btnRestaurar.TabIndex = 3;
            btnRestaurar.Text = "Restaurar";
            btnRestaurar.UseVisualStyleBackColor = true;
            btnRestaurar.Click += btnRestaurar_Click;
            // 
            // FormRestore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRestaurar);
            Controls.Add(dgvBackUps);
            Controls.Add(lblDescripcion);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(640, 420);
            Name = "FormRestore";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Restore";
            Load += FormRestore_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBackUps).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblDescripcion;
        private DataGridView dgvBackUps;
        private Button btnRestaurar;
    }
}



