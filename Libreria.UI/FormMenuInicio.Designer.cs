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
            cerrarSesionToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            gestionDeUsuariosToolStripMenuItem = new ToolStripMenuItem();
            aBMUsuariosToolStripMenuItem = new ToolStripMenuItem();
            permisosYRolesToolStripMenuItem = new ToolStripMenuItem();
            productosToolStripMenuItem = new ToolStripMenuItem();
            verInventarioToolStripMenuItem = new ToolStripMenuItem();
            administrarProductosToolStripMenuItem = new ToolStripMenuItem();
            caracteristicasProductoToolStripMenuItem = new ToolStripMenuItem();
            administrarMarcasToolStripMenuItem = new ToolStripMenuItem();
            administrarCategoriasToolStripMenuItem = new ToolStripMenuItem();
            administrarColoresToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            administrarClientesToolStripMenuItem = new ToolStripMenuItem();
            ventasToolStripMenuItem = new ToolStripMenuItem();
            registrarVentaToolStripMenuItem = new ToolStripMenuItem();
            consultarVentasToolStripMenuItem = new ToolStripMenuItem();
            administrarMetodosDePagoToolStripMenuItem = new ToolStripMenuItem();
            gestionDeBaseDeDatosToolStripMenuItem = new ToolStripMenuItem();
            backupToolStripMenuItem = new ToolStripMenuItem();
            restoreToolStripMenuItem = new ToolStripMenuItem();
            bitacoraToolStripMenuItem = new ToolStripMenuItem();
            analisisToolStripMenuItem = new ToolStripMenuItem();
            dashboardProductosToolStripMenuItem = new ToolStripMenuItem();
            dashboardDiarioToolStripMenuItem = new ToolStripMenuItem();
            dashboardSemanalToolStripMenuItem = new ToolStripMenuItem();
            dashboardMensualToolStripMenuItem = new ToolStripMenuItem();
            dashboardClientesToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, gestionDeUsuariosToolStripMenuItem, productosToolStripMenuItem, clientesToolStripMenuItem, ventasToolStripMenuItem, gestionDeBaseDeDatosToolStripMenuItem, analisisToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesionToolStripMenuItem, salirToolStripMenuItem });
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(48, 20);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            cerrarSesionToolStripMenuItem.Size = new Size(180, 22);
            cerrarSesionToolStripMenuItem.Tag = "Inicio";
            cerrarSesionToolStripMenuItem.Text = "Cerrar sesión";
            cerrarSesionToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(180, 22);
            salirToolStripMenuItem.Tag = "Inicio";
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
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
            aBMUsuariosToolStripMenuItem.Tag = "ABM usuarios";
            aBMUsuariosToolStripMenuItem.Text = "ABM usuarios";
            // 
            // permisosYRolesToolStripMenuItem
            // 
            permisosYRolesToolStripMenuItem.Name = "permisosYRolesToolStripMenuItem";
            permisosYRolesToolStripMenuItem.Size = new Size(180, 22);
            permisosYRolesToolStripMenuItem.Tag = "Gestion de roles y permisos";
            permisosYRolesToolStripMenuItem.Text = "Permisos y roles";
            // 
            // productosToolStripMenuItem
            // 
            productosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verInventarioToolStripMenuItem, administrarProductosToolStripMenuItem, caracteristicasProductoToolStripMenuItem });
            productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            productosToolStripMenuItem.Size = new Size(73, 20);
            productosToolStripMenuItem.Text = "Productos";
            // 
            // verInventarioToolStripMenuItem
            // 
            verInventarioToolStripMenuItem.Name = "verInventarioToolStripMenuItem";
            verInventarioToolStripMenuItem.Size = new Size(180, 22);
            verInventarioToolStripMenuItem.Tag = "Ver inventario";
            verInventarioToolStripMenuItem.Text = "Ver inventario";
            // 
            // administrarProductosToolStripMenuItem
            // 
            administrarProductosToolStripMenuItem.Name = "administrarProductosToolStripMenuItem";
            administrarProductosToolStripMenuItem.Size = new Size(180, 22);
            administrarProductosToolStripMenuItem.Tag = "Administrar productos";
            administrarProductosToolStripMenuItem.Text = "Administrar productos";
            // 
            // caracteristicasProductoToolStripMenuItem
            // 
            caracteristicasProductoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { administrarMarcasToolStripMenuItem, administrarCategoriasToolStripMenuItem, administrarColoresToolStripMenuItem });
            caracteristicasProductoToolStripMenuItem.Name = "caracteristicasProductoToolStripMenuItem";
            caracteristicasProductoToolStripMenuItem.Size = new Size(223, 22);
            caracteristicasProductoToolStripMenuItem.Text = "Características de producto";
            // 
            // administrarMarcasToolStripMenuItem
            // 
            administrarMarcasToolStripMenuItem.Name = "administrarMarcasToolStripMenuItem";
            administrarMarcasToolStripMenuItem.Size = new Size(180, 22);
            administrarMarcasToolStripMenuItem.Tag = "Administrar productos";
            administrarMarcasToolStripMenuItem.Text = "Administrar marcas";
            // 
            // administrarCategoriasToolStripMenuItem
            // 
            administrarCategoriasToolStripMenuItem.Name = "administrarCategoriasToolStripMenuItem";
            administrarCategoriasToolStripMenuItem.Size = new Size(180, 22);
            administrarCategoriasToolStripMenuItem.Tag = "Administrar productos";
            administrarCategoriasToolStripMenuItem.Text = "Administrar categorías";
            // 
            // administrarColoresToolStripMenuItem
            // 
            administrarColoresToolStripMenuItem.Name = "administrarColoresToolStripMenuItem";
            administrarColoresToolStripMenuItem.Size = new Size(180, 22);
            administrarColoresToolStripMenuItem.Tag = "Administrar productos";
            administrarColoresToolStripMenuItem.Text = "Administrar colores";
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { administrarClientesToolStripMenuItem });
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(61, 20);
            clientesToolStripMenuItem.Text = "Clientes";
            // 
            // administrarClientesToolStripMenuItem
            // 
            administrarClientesToolStripMenuItem.Name = "administrarClientesToolStripMenuItem";
            administrarClientesToolStripMenuItem.Size = new Size(180, 22);
            administrarClientesToolStripMenuItem.Tag = "Administrar clientes";
            administrarClientesToolStripMenuItem.Text = "Administrar clientes";
            // 
            // ventasToolStripMenuItem
            // 
            ventasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registrarVentaToolStripMenuItem, consultarVentasToolStripMenuItem, administrarMetodosDePagoToolStripMenuItem });
            ventasToolStripMenuItem.Name = "ventasToolStripMenuItem";
            ventasToolStripMenuItem.Size = new Size(53, 20);
            ventasToolStripMenuItem.Text = "Ventas";
            // 
            // registrarVentaToolStripMenuItem
            // 
            registrarVentaToolStripMenuItem.Name = "registrarVentaToolStripMenuItem";
            registrarVentaToolStripMenuItem.Size = new Size(218, 22);
            registrarVentaToolStripMenuItem.Tag = "Registrar ventas";
            registrarVentaToolStripMenuItem.Text = "Registrar venta";
            // 
            // consultarVentasToolStripMenuItem
            // 
            consultarVentasToolStripMenuItem.Name = "consultarVentasToolStripMenuItem";
            consultarVentasToolStripMenuItem.Size = new Size(218, 22);
            consultarVentasToolStripMenuItem.Tag = "Consultar ventas";
            consultarVentasToolStripMenuItem.Text = "Consultar ventas";
            // 
            // administrarMetodosDePagoToolStripMenuItem
            // 
            administrarMetodosDePagoToolStripMenuItem.Name = "administrarMetodosDePagoToolStripMenuItem";
            administrarMetodosDePagoToolStripMenuItem.Size = new Size(218, 22);
            administrarMetodosDePagoToolStripMenuItem.Tag = "Administrar metodos de pago";
            administrarMetodosDePagoToolStripMenuItem.Text = "Administrar métodos de pago";
            // 
            // gestionDeBaseDeDatosToolStripMenuItem
            // 
            gestionDeBaseDeDatosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { backupToolStripMenuItem, restoreToolStripMenuItem, bitacoraToolStripMenuItem });
            gestionDeBaseDeDatosToolStripMenuItem.Name = "gestionDeBaseDeDatosToolStripMenuItem";
            gestionDeBaseDeDatosToolStripMenuItem.Size = new Size(142, 20);
            gestionDeBaseDeDatosToolStripMenuItem.Text = "Gestión de base de datos";
            // 
            // backupToolStripMenuItem
            // 
            backupToolStripMenuItem.Name = "backupToolStripMenuItem";
            backupToolStripMenuItem.Size = new Size(180, 22);
            backupToolStripMenuItem.Tag = "Gestion de back up";
            backupToolStripMenuItem.Text = "Backup";
            // 
            // restoreToolStripMenuItem
            // 
            restoreToolStripMenuItem.Name = "restoreToolStripMenuItem";
            restoreToolStripMenuItem.Size = new Size(180, 22);
            restoreToolStripMenuItem.Tag = "Gestion de restore";
            restoreToolStripMenuItem.Text = "Restore";
            // 
            // bitacoraToolStripMenuItem
            // 
            bitacoraToolStripMenuItem.Name = "bitacoraToolStripMenuItem";
            bitacoraToolStripMenuItem.Size = new Size(180, 22);
            bitacoraToolStripMenuItem.Tag = "Ver bitacora";
            bitacoraToolStripMenuItem.Text = "Bitácora";
            // 
            // analisisToolStripMenuItem
            // 
            analisisToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dashboardProductosToolStripMenuItem });
            analisisToolStripMenuItem.Name = "analisisToolStripMenuItem";
            analisisToolStripMenuItem.Size = new Size(109, 20);
            analisisToolStripMenuItem.Text = "Análisis de ventas";
            // 
            // dashboardProductosToolStripMenuItem
            //
            dashboardProductosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { dashboardDiarioToolStripMenuItem, dashboardSemanalToolStripMenuItem, dashboardMensualToolStripMenuItem });
            dashboardProductosToolStripMenuItem.Name = "dashboardProductosToolStripMenuItem";
            dashboardProductosToolStripMenuItem.Size = new Size(186, 22);
            dashboardProductosToolStripMenuItem.Tag = "Analisis de ventas";
            dashboardProductosToolStripMenuItem.Text = "Dashboard ventas";
            //
            // dashboardDiarioToolStripMenuItem
            //
            dashboardDiarioToolStripMenuItem.Name = "dashboardDiarioToolStripMenuItem";
            dashboardDiarioToolStripMenuItem.Size = new Size(186, 22);
            dashboardDiarioToolStripMenuItem.Tag = "Analisis de ventas";
            dashboardDiarioToolStripMenuItem.Text = "Por día";
            //
            // dashboardSemanalToolStripMenuItem
            //
            dashboardSemanalToolStripMenuItem.Name = "dashboardSemanalToolStripMenuItem";
            dashboardSemanalToolStripMenuItem.Size = new Size(186, 22);
            dashboardSemanalToolStripMenuItem.Tag = "Analisis de ventas";
            dashboardSemanalToolStripMenuItem.Text = "Por semana";
            //
            // dashboardMensualToolStripMenuItem
            //
            dashboardMensualToolStripMenuItem.Name = "dashboardMensualToolStripMenuItem";
            dashboardMensualToolStripMenuItem.Size = new Size(186, 22);
            dashboardMensualToolStripMenuItem.Tag = "Analisis de ventas";
            dashboardMensualToolStripMenuItem.Text = "Por mes";
            // 
            // dashboardClientesToolStripMenuItem
            // 
            dashboardClientesToolStripMenuItem.Name = "dashboardClientesToolStripMenuItem";
            dashboardClientesToolStripMenuItem.Size = new Size(186, 22);
            dashboardClientesToolStripMenuItem.Tag = "Analisis de ventas";
            dashboardClientesToolStripMenuItem.Text = "Dashboard clientes";
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
            FormClosing += FormMenuInicio_FormClosing;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem gestionDeUsuariosToolStripMenuItem;
        private ToolStripMenuItem aBMUsuariosToolStripMenuItem;
        private ToolStripMenuItem permisosYRolesToolStripMenuItem;
        private ToolStripMenuItem productosToolStripMenuItem;
        private ToolStripMenuItem verInventarioToolStripMenuItem;
        private ToolStripMenuItem administrarProductosToolStripMenuItem;
        private ToolStripMenuItem caracteristicasProductoToolStripMenuItem;
        private ToolStripMenuItem administrarMarcasToolStripMenuItem;
        private ToolStripMenuItem administrarCategoriasToolStripMenuItem;
        private ToolStripMenuItem administrarColoresToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem administrarClientesToolStripMenuItem;
        private ToolStripMenuItem ventasToolStripMenuItem;
        private ToolStripMenuItem registrarVentaToolStripMenuItem;
        private ToolStripMenuItem consultarVentasToolStripMenuItem;
        private ToolStripMenuItem administrarMetodosDePagoToolStripMenuItem;
        private ToolStripMenuItem gestionDeBaseDeDatosToolStripMenuItem;
        private ToolStripMenuItem backupToolStripMenuItem;
        private ToolStripMenuItem restoreToolStripMenuItem;
        private ToolStripMenuItem bitacoraToolStripMenuItem;
        private ToolStripMenuItem analisisToolStripMenuItem;
        private ToolStripMenuItem dashboardProductosToolStripMenuItem;
        private ToolStripMenuItem dashboardDiarioToolStripMenuItem;
        private ToolStripMenuItem dashboardSemanalToolStripMenuItem;
        private ToolStripMenuItem dashboardMensualToolStripMenuItem;
        private ToolStripMenuItem dashboardClientesToolStripMenuItem;
    }
}


