namespace Libreria.UI
{
    partial class FormMenuInicio
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
            menuStrip1 = new MenuStrip();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            gestionDeUsuariosToolStripMenuItem = new ToolStripMenuItem();
            aBMUsuariosToolStripMenuItem = new ToolStripMenuItem();
            permisosYRolesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, gestionDeUsuariosToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(48, 20);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // gestionDeUsuariosToolStripMenuItem
            // 
            gestionDeUsuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aBMUsuariosToolStripMenuItem, permisosYRolesToolStripMenuItem });
            gestionDeUsuariosToolStripMenuItem.Name = "gestionDeUsuariosToolStripMenuItem";
            gestionDeUsuariosToolStripMenuItem.Size = new Size(64, 20);
            gestionDeUsuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // aBMUsuariosToolStripMenuItem
            // 
            aBMUsuariosToolStripMenuItem.Name = "aBMUsuariosToolStripMenuItem";
            aBMUsuariosToolStripMenuItem.Size = new Size(180, 22);
            aBMUsuariosToolStripMenuItem.Text = "ABM usuarios";
            // 
            // permisosYRolesToolStripMenuItem
            // 
            permisosYRolesToolStripMenuItem.Name = "permisosYRolesToolStripMenuItem";
            permisosYRolesToolStripMenuItem.Size = new Size(180, 22);
            permisosYRolesToolStripMenuItem.Text = "Permisos y roles";
            // 
            // FormMenuInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FormMenuInicio";
            Text = "FormMenuInicio";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem gestionDeUsuariosToolStripMenuItem;
        private ToolStripMenuItem aBMUsuariosToolStripMenuItem;
        private ToolStripMenuItem permisosYRolesToolStripMenuItem;
    }
}