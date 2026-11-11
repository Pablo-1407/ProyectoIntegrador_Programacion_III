using RutaCampus.Domain;
using RutaCampus.Repositories;
using RutaCampus.Views;
using System.Globalization;

namespace RutaCampus
{
    public partial class FrmPrincipal : Form
    {
        private Repository<Contenedores, int> repositorioContenedores;

        public FrmPrincipal()
        {
            InitializeComponent();

            string carpeta = Path.Combine(Application.StartupPath, "Datos");
            string archivo = Path.Combine(carpeta, "Contenedores.csv");

            repositorioContenedores = new Repository<Contenedores, int>(archivo);
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            // Code to execute when the form loads
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
                repositorioContenedores.GetAll(),
                "Listado de contenedores"
            );
            formulario.Show();
        }
    }
}
