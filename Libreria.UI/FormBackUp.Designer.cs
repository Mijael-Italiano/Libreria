namespace Libreria.UI
{
    partial class FormBackUp
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
            lblUsuarioActual = new Label();
            dgvBackUps = new DataGridView();
            btnCrearBackUp = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvBackUps).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(24, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(196, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Back up de sistema";
            // 
            // lblUsuarioActual
            // 
            lblUsuarioActual.AutoSize = true;
            lblUsuarioActual.Location = new Point(26, 62);
            lblUsuarioActual.Name = "lblUsuarioActual";
            lblUsuarioActual.Size = new Size(127, 15);
            lblUsuarioActual.TabIndex = 1;
            lblUsuarioActual.Text = "Usuario actual: -";
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
            // btnCrearBackUp
            // 
            btnCrearBackUp.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCrearBackUp.Location = new Point(629, 396);
            btnCrearBackUp.Name = "btnCrearBackUp";
            btnCrearBackUp.Size = new Size(143, 32);
            btnCrearBackUp.TabIndex = 3;
            btnCrearBackUp.Text = "Crear back up";
            btnCrearBackUp.UseVisualStyleBackColor = true;
            btnCrearBackUp.Click += btnCrearBackUp_Click;
            // 
            // FormBackUp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCrearBackUp);
            Controls.Add(dgvBackUps);
            Controls.Add(lblUsuarioActual);
            Controls.Add(lblTitulo);
            MinimumSize = new Size(640, 420);
            Name = "FormBackUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Back up";
            Load += FormBackUp_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBackUps).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsuarioActual;
        private DataGridView dgvBackUps;
        private Button btnCrearBackUp;
    }
}



