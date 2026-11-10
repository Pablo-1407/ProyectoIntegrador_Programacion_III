namespace RutaCampus.Views
{
    partial class FrmAgregarVehiculo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAgregarVehiculo));
            toolStrip1 = new ToolStrip();
            TSBAgregar = new ToolStripButton();
            TSBActualizar = new ToolStripButton();
            TSBEliminar = new ToolStripButton();
            TSBLimpiar = new ToolStripButton();
            TSBGuardar = new ToolStripButton();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { TSBAgregar, TSBActualizar, TSBEliminar, TSBLimpiar, TSBGuardar });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(800, 27);
            toolStrip1.TabIndex = 4;
            toolStrip1.Text = "toolStrip1";
            // 
            // TSBAgregar
            // 
            TSBAgregar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TSBAgregar.Image = (Image)resources.GetObject("TSBAgregar.Image");
            TSBAgregar.ImageTransparentColor = Color.Magenta;
            TSBAgregar.Name = "TSBAgregar";
            TSBAgregar.Size = new Size(24, 24);
            TSBAgregar.Text = "toolStripButton1";
            TSBAgregar.Click += TSBAgregar_Click;
            // 
            // TSBActualizar
            // 
            TSBActualizar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TSBActualizar.Image = (Image)resources.GetObject("TSBActualizar.Image");
            TSBActualizar.ImageTransparentColor = Color.Magenta;
            TSBActualizar.Name = "TSBActualizar";
            TSBActualizar.Size = new Size(24, 24);
            TSBActualizar.Text = "toolStripButton2";
            TSBActualizar.Click += TSBActualizar_Click;
            // 
            // TSBEliminar
            // 
            TSBEliminar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TSBEliminar.Image = (Image)resources.GetObject("TSBEliminar.Image");
            TSBEliminar.ImageTransparentColor = Color.Magenta;
            TSBEliminar.Name = "TSBEliminar";
            TSBEliminar.Size = new Size(24, 24);
            TSBEliminar.Text = "toolStripButton3";
            TSBEliminar.Click += TSBEliminar_Click;
            // 
            // TSBLimpiar
            // 
            TSBLimpiar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TSBLimpiar.Image = (Image)resources.GetObject("TSBLimpiar.Image");
            TSBLimpiar.ImageTransparentColor = Color.Magenta;
            TSBLimpiar.Name = "TSBLimpiar";
            TSBLimpiar.Size = new Size(24, 24);
            TSBLimpiar.Text = "toolStripButton4";
            TSBLimpiar.Click += TSBLimpiar_Click;
            // 
            // TSBGuardar
            // 
            TSBGuardar.DisplayStyle = ToolStripItemDisplayStyle.Image;
            TSBGuardar.Image = (Image)resources.GetObject("TSBGuardar.Image");
            TSBGuardar.ImageTransparentColor = Color.Magenta;
            TSBGuardar.Name = "TSBGuardar";
            TSBGuardar.Size = new Size(24, 24);
            TSBGuardar.Text = "toolStripButton5";
            TSBGuardar.Click += TSBGuardar_Click;
            // 
            // FrmAgregarVehiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(toolStrip1);
            Name = "FrmAgregarVehiculo";
            Text = "FrmAgregarVehiculo";
            Load += FrmAgregarVehiculo_Load;
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ToolStrip toolStrip1;
        private ToolStripButton TSBAgregar;
        private ToolStripButton TSBActualizar;
        private ToolStripButton TSBEliminar;
        private ToolStripButton TSBLimpiar;
        private ToolStripButton TSBGuardar;
    }
}