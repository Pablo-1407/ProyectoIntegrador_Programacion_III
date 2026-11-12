using RutaCampus.Repositories;
using RutaCampus.Views;

namespace RutaCampus
{
    public partial class FrmPrincipal : Form
    {
        private readonly ContenedoresRepository _repositorioContenedores;
        private readonly AcopioRepository _repositorioAcopios;

        public FrmPrincipal()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            _repositorioContenedores = ContenedoresRepository.Instance;
            _repositorioAcopios = AcopioRepository.Instance;
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
                    ContenedorPrimario.Panel2.Controls.Clear();
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
                if (_repositorioAcopios.IsEmpty())
                {
                    if (MessageBox.Show("Desea agregar un acopio aqui?", "Agregar elemento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Point clickLocation = ContenedorPrimario.Panel2.PointToClient(Cursor.Position);
                        FrmAgregarAcopio formulario = FrmAgregarAcopio.GetInstance(clickLocation, _repositorioAcopios);
                        formulario.Show();
                    }
                }
                else
                {
                    if (MessageBox.Show("Desea agregar un contenedor aqui?", "Agregar elemento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        Point clickLocation = ContenedorPrimario.Panel2.PointToClient(Cursor.Position);
                        FrmAgregarContenedor formulario = FrmAgregarContenedor.GetInstance(clickLocation, _repositorioContenedores);
                        formulario.Show();
                    }
                }

            }
        }
    }
}
