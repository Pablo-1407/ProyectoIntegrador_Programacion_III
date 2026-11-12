using RutaCampus.Domain;
using RutaCampus.Repositories;
using RutaCampus.Views;
using System.Globalization;

namespace RutaCampus
{
    public partial class FrmPrincipal : Form
    {
        private Repository<Contenedores, int> _repositorioContenedores;
        private string _rutaimagen;

        public FrmPrincipal()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            string carpeta = Path.Combine(Application.StartupPath, "Datos");
            string archivo = Path.Combine(carpeta, "Contenedores.csv");

            _repositorioContenedores = new Repository<Contenedores, int>(archivo);
            
        }

        private void comprobarimagenpanel2()
        {
            if (ContenedorPrimario.Panel2.BackgroundImage == null)
            {
                Label label = new Label
                {
                    Text = "Click aqui para seleccionar imagen",
                    AutoSize = true,
                };
                int x = (ContenedorPrimario.Panel2.Width - label.Width) / 2;
                int y = (ContenedorPrimario.Panel2.Height - label.Height) / 2;
                ContenedorPrimario.Panel2.BackColor = Color.LightGray;
                ContenedorPrimario.Panel2.Controls.Add(label);
                ContenedorPrimario.Panel2.Controls[0].Location = new Point(x, y);
            }
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Bienvenido al sistema de gestión de rutas de transporte de contenedores");
            comprobarimagenpanel2();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            //cerrar sesion
        }

        private void vehiculoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAgregarVehiculo frmAgregarVehiculo = FrmAgregarVehiculo.GetInstance();
            frmAgregarVehiculo.Show();
        }

        private void imagenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {

                openFileDialog.Title = "Seleccionar imagen del vehículo";


                openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";

                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string rutaArchivoSeleccionado = openFileDialog.FileName;
                    ContenedorPrimario.Panel2.BackgroundImage = Image.FromFile(rutaArchivoSeleccionado);
                    ContenedorPrimario.Panel2.BackgroundImageLayout = ImageLayout.Stretch;
                }
            }
        }


        private void verContenedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmToList formulario = FrmToList.GetInstance();

            formulario.CargarDatos(
                _repositorioContenedores.GetAll(),
                "Listado de contenedores"
            );
            formulario.Show();
        }

        private void ContenedorPrimario_Panel2_Click(object sender, EventArgs e)
        {
            if(ContenedorPrimario.Panel2.BackgroundImage == null)
            {
                imagenToolStripMenuItem_Click(sender, e);
            }
            else
            {
                FrmAgregarAcopio formulario = FrmAgregarAcopio.GetInstance();
                formulario.Show();
            }
        }

        private void agregarContenedor(object sender, EventArgs e)
        {
            
        }
    }
}
