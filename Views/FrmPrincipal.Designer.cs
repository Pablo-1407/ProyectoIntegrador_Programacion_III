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
            menuStrip1 = new MenuStrip();
            inicioToolStripMenuItem = new ToolStripMenuItem();
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
            splitContainer1 = new SplitContainer();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, archivoToolStripMenuItem, herramientosToolStripMenuItem, configuracionToolStripMenuItem, ayudaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { iniciarSesionToolStripMenuItem, cerrarToolStripMenuItem });
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(48, 20);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // iniciarSesionToolStripMenuItem
            // 
            iniciarSesionToolStripMenuItem.Name = "iniciarSesionToolStripMenuItem";
            iniciarSesionToolStripMenuItem.Size = new Size(180, 22);
            iniciarSesionToolStripMenuItem.Text = "Iniciar Sesion";
            // 
            // cerrarToolStripMenuItem
            // 
            cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            cerrarToolStripMenuItem.Size = new Size(180, 22);
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
            vehiculoToolStripMenuItem.Size = new Size(179, 22);
            vehiculoToolStripMenuItem.Text = "Vehiculo";
            // 
            // imagenToolStripMenuItem
            // 
            imagenToolStripMenuItem.Name = "imagenToolStripMenuItem";
            imagenToolStripMenuItem.Size = new Size(179, 22);
            imagenToolStripMenuItem.Text = "Imagen";
            // 
            // factoresDeEmisionToolStripMenuItem
            // 
            factoresDeEmisionToolStripMenuItem.Name = "factoresDeEmisionToolStripMenuItem";
            factoresDeEmisionToolStripMenuItem.Size = new Size(179, 22);
            factoresDeEmisionToolStripMenuItem.Text = "Factores de emision";
            // 
            // añadirUsuariosToolStripMenuItem
            // 
            añadirUsuariosToolStripMenuItem.Name = "añadirUsuariosToolStripMenuItem";
            añadirUsuariosToolStripMenuItem.Size = new Size(179, 22);
            añadirUsuariosToolStripMenuItem.Text = "Añadir Usuarios";
            // 
            // ayudaToolStripMenuItem
            // 
            ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            ayudaToolStripMenuItem.Size = new Size(53, 20);
            ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 24);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Size = new Size(800, 426);
            splitContainer1.SplitterDistance = 266;
            splitContainer1.TabIndex = 1;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmPrincipal";
            Text = "Gestion de Rutas";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
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
        private SplitContainer splitContainer1;
    }
}
