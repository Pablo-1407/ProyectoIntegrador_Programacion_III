namespace RutaCampus
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            MenuPrincipal = new MenuStrip();
            InicioStripMenuItem = new ToolStripMenuItem();
            iniciarSesionToolStripMenuItem = new ToolStripMenuItem();
            cerrarToolStripMenuItem = new ToolStripMenuItem();
            archivoToolStripMenuItem = new ToolStripMenuItem();
            abrirArchivoToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            borrarTodoToolStripMenuItem = new ToolStripMenuItem();
            herramientosToolStripMenuItem = new ToolStripMenuItem();
            verAcopioToolStripMenuItem = new ToolStripMenuItem();
            verContenedoresToolStripMenuItem = new ToolStripMenuItem();
            verHistorialToolStripMenuItem = new ToolStripMenuItem();
            configuracionToolStripMenuItem = new ToolStripMenuItem();
            vehiculoToolStripMenuItem = new ToolStripMenuItem();
            imagenToolStripMenuItem = new ToolStripMenuItem();
            factoresDeEmisionToolStripMenuItem = new ToolStripMenuItem();
            añadirUsuariosToolStripMenuItem = new ToolStripMenuItem();
            ayudaToolStripMenuItem = new ToolStripMenuItem();
            ContenedorPrimario = new SplitContainer();
            MenuPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ContenedorPrimario).BeginInit();
            ContenedorPrimario.SuspendLayout();
            SuspendLayout();
            // 
            // MenuPrincipal
            // 
            MenuPrincipal.Items.AddRange(new ToolStripItem[] { InicioStripMenuItem, archivoToolStripMenuItem, herramientosToolStripMenuItem, configuracionToolStripMenuItem, ayudaToolStripMenuItem });
            MenuPrincipal.Location = new Point(0, 0);
            MenuPrincipal.Name = "MenuPrincipal";
            MenuPrincipal.Size = new Size(800, 24);
            MenuPrincipal.TabIndex = 0;
            MenuPrincipal.Text = "menuStrip1";
            // 
            // InicioStripMenuItem
            // 
            InicioStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { iniciarSesionToolStripMenuItem, cerrarToolStripMenuItem });
            InicioStripMenuItem.Name = "InicioStripMenuItem";
            InicioStripMenuItem.Size = new Size(48, 20);
            InicioStripMenuItem.Text = "Inicio";
            // 
            // iniciarSesionToolStripMenuItem
            // 
            iniciarSesionToolStripMenuItem.Name = "iniciarSesionToolStripMenuItem";
            iniciarSesionToolStripMenuItem.Size = new Size(143, 22);
            iniciarSesionToolStripMenuItem.Text = "Iniciar Sesion";
            // 
            // cerrarToolStripMenuItem
            // 
            cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            cerrarToolStripMenuItem.Size = new Size(143, 22);
            cerrarToolStripMenuItem.Text = "Cerrar";
            // 
            // archivoToolStripMenuItem
            // 
            archivoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { abrirArchivoToolStripMenuItem, toolStripMenuItem1, borrarTodoToolStripMenuItem });
            archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            archivoToolStripMenuItem.Size = new Size(60, 20);
            archivoToolStripMenuItem.Text = "Archivo";
            // 
            // abrirArchivoToolStripMenuItem
            // 
            abrirArchivoToolStripMenuItem.Name = "abrirArchivoToolStripMenuItem";
            abrirArchivoToolStripMenuItem.Size = new Size(162, 22);
            abrirArchivoToolStripMenuItem.Text = "Abrir archivo";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(162, 22);
            toolStripMenuItem1.Text = "Guadar Cambios";
            // 
            // borrarTodoToolStripMenuItem
            // 
            borrarTodoToolStripMenuItem.Name = "borrarTodoToolStripMenuItem";
            borrarTodoToolStripMenuItem.Size = new Size(162, 22);
            borrarTodoToolStripMenuItem.Text = "Borrar Todo";
            // 
            // herramientosToolStripMenuItem
            // 
            herramientosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verAcopioToolStripMenuItem, verContenedoresToolStripMenuItem, verHistorialToolStripMenuItem });
            herramientosToolStripMenuItem.Name = "herramientosToolStripMenuItem";
            herramientosToolStripMenuItem.Size = new Size(90, 20);
            herramientosToolStripMenuItem.Text = "Herramientas";
            // 
            // verAcopioToolStripMenuItem
            // 
            verAcopioToolStripMenuItem.Name = "verAcopioToolStripMenuItem";
            verAcopioToolStripMenuItem.Size = new Size(165, 22);
            verAcopioToolStripMenuItem.Text = "Ver acopio";
            // 
            // verContenedoresToolStripMenuItem
            // 
            verContenedoresToolStripMenuItem.Name = "verContenedoresToolStripMenuItem";
            verContenedoresToolStripMenuItem.Size = new Size(165, 22);
            verContenedoresToolStripMenuItem.Text = "Ver contenedores";
            // 
            // verHistorialToolStripMenuItem
            // 
            verHistorialToolStripMenuItem.Name = "verHistorialToolStripMenuItem";
            verHistorialToolStripMenuItem.Size = new Size(165, 22);
            verHistorialToolStripMenuItem.Text = "Ver historial";
            // 
            // configuracionToolStripMenuItem
            // 
            configuracionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { vehiculoToolStripMenuItem, imagenToolStripMenuItem, factoresDeEmisionToolStripMenuItem, añadirUsuariosToolStripMenuItem });
            configuracionToolStripMenuItem.Name = "configuracionToolStripMenuItem";
            configuracionToolStripMenuItem.Size = new Size(95, 20);
            configuracionToolStripMenuItem.Text = "Configuracion";
            // 
            // vehiculoToolStripMenuItem
            // 
            vehiculoToolStripMenuItem.Name = "vehiculoToolStripMenuItem";
            vehiculoToolStripMenuItem.Size = new Size(180, 22);
            vehiculoToolStripMenuItem.Text = "Vehiculo";
            vehiculoToolStripMenuItem.Click += vehiculoToolStripMenuItem_Click;
            // 
            // imagenToolStripMenuItem
            // 
            imagenToolStripMenuItem.Name = "imagenToolStripMenuItem";
            imagenToolStripMenuItem.Size = new Size(180, 22);
            imagenToolStripMenuItem.Text = "Imagen";
            // 
            // factoresDeEmisionToolStripMenuItem
            // 
            factoresDeEmisionToolStripMenuItem.Name = "factoresDeEmisionToolStripMenuItem";
            factoresDeEmisionToolStripMenuItem.Size = new Size(180, 22);
            factoresDeEmisionToolStripMenuItem.Text = "Factores de emision";
            // 
            // añadirUsuariosToolStripMenuItem
            // 
            añadirUsuariosToolStripMenuItem.Name = "añadirUsuariosToolStripMenuItem";
            añadirUsuariosToolStripMenuItem.Size = new Size(180, 22);
            añadirUsuariosToolStripMenuItem.Text = "Añadir Usuarios";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 20);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // ContenedorPrimario
            // 
            ContenedorPrimario.Dock = DockStyle.Fill;
            ContenedorPrimario.Location = new Point(0, 24);
            ContenedorPrimario.Name = "ContenedorPrimario";
            ContenedorPrimario.Size = new Size(800, 426);
            ContenedorPrimario.SplitterDistance = 266;
            ContenedorPrimario.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ContenedorPrimario);
            Controls.Add(MenuPrincipal);
            MainMenuStrip = MenuPrincipal;
            Name = "FrmPrincipal";
            Text = "Gestion de Rutas";
            MenuPrincipal.ResumeLayout(false);
            MenuPrincipal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ContenedorPrimario).EndInit();
            ContenedorPrimario.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip MenuPrincipal;
        private ToolStripMenuItem InicioStripMenuItem;
        private ToolStripMenuItem iniciarSesionToolStripMenuItem;
        private ToolStripMenuItem cerrarToolStripMenuItem;
        private ToolStripMenuItem archivoToolStripMenuItem;
        private ToolStripMenuItem abrirArchivoToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem borrarTodoToolStripMenuItem;
        private ToolStripMenuItem configuracionToolStripMenuItem;
        private ToolStripMenuItem vehiculoToolStripMenuItem;
        private ToolStripMenuItem imagenToolStripMenuItem;
        private ToolStripMenuItem factoresDeEmisionToolStripMenuItem;
        private ToolStripMenuItem añadirUsuariosToolStripMenuItem;
        private ToolStripMenuItem herramientosToolStripMenuItem;
        private ToolStripMenuItem verAcopioToolStripMenuItem;
        private ToolStripMenuItem verContenedoresToolStripMenuItem;
        private ToolStripMenuItem verHistorialToolStripMenuItem;
        private ToolStripMenuItem ayudaToolStripMenuItem;
        private SplitContainer ContenedorPrimario;
    }
}
