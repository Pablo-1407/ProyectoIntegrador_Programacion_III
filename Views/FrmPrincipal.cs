using RutaCampus.Domain;
using RutaCampus.Repositories;
using RutaCampus.Views;
using System.Drawing.Drawing2D;
using System.IO;

namespace RutaCampus
{
    public partial class FrmPrincipal : Form
    {
        private const string NombreArchivoImagenPanel2 = "imagen-panel2";
        private readonly ContenedoresRepository _repositorioContenedores;
        private readonly AcopioRepository _repositorioAcopios;
        private static string DirectorioDatos => Path.Combine(AppContext.BaseDirectory, "data");

        public FrmPrincipal()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            _repositorioContenedores = ContenedoresRepository.Instance;
            _repositorioAcopios = AcopioRepository.Instance;
            borrarTodoToolStripMenuItem.Click += borrarTodoToolStripMenuItem_Click;
            ContenedorPrimario.Panel2.Paint += ContenedorPrimario_Panel2_Paint;
        }

        private void borrarTodoToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            DialogResult confirmacion = MessageBox.Show(
                "Se eliminará la carpeta data completa y el programa se cerrará. ¿Desea continuar?",
                "Borrar todo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2);

            if (confirmacion != DialogResult.Yes)
                return;

            try
            {
                if (Directory.Exists(DirectorioDatos))
                    Directory.Delete(DirectorioDatos, true);

                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo eliminar la carpeta data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ContenedorPrimario_Panel2_Paint(object? sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using Pen borde = new Pen(Color.White, 2);
            using SolidBrush acopioBrush = new SolidBrush(Color.ForestGreen);
            using SolidBrush contenedorBrush = new SolidBrush(Color.OrangeRed);
            using SolidBrush fondoEtiqueta = new SolidBrush(Color.FromArgb(190, Color.Black));
            using SolidBrush textoEtiqueta = new SolidBrush(Color.White);

            foreach (Acopio acopio in _repositorioAcopios.GetAll())
            {
                DibujarPunto(e.Graphics, acopio.Coordenadas, $"A {acopio.Id}: {acopio.Nombre}", acopioBrush, borde, fondoEtiqueta, textoEtiqueta);
            }

            foreach (Contenedores contenedor in _repositorioContenedores.GetAll())
            {
                DibujarPunto(e.Graphics, contenedor.Coordenadas, $"C {contenedor.Id}: {contenedor.Nombre}", contenedorBrush, borde, fondoEtiqueta, textoEtiqueta);
            }
        }

        private static void DibujarPunto(Graphics graphics, Point punto, string etiqueta, Brush relleno, Pen borde, Brush fondoEtiqueta, Brush textoEtiqueta)
        {
            const int diametro = 14;
            Rectangle marcador = new Rectangle(punto.X - diametro / 2, punto.Y - diametro / 2, diametro, diametro);
            graphics.FillEllipse(relleno, marcador);
            graphics.DrawEllipse(borde, marcador);

            SizeF tamanoEtiqueta = graphics.MeasureString(etiqueta, SystemFonts.DefaultFont);
            RectangleF limites = graphics.VisibleClipBounds;
            float anchoFondo = tamanoEtiqueta.Width + 6;
            float altoFondo = tamanoEtiqueta.Height + 4;
            float x = punto.X + diametro / 2f + 4;
            if (x + anchoFondo > limites.Right)
                x = punto.X - diametro / 2f - tamanoEtiqueta.Width - 10;

            float minimoX = limites.Left + 2;
            float minimoY = limites.Top + 2;
            x = Math.Clamp(x, minimoX, Math.Max(minimoX, limites.Right - anchoFondo - 2));
            float y = Math.Clamp(punto.Y - altoFondo / 2, minimoY, Math.Max(minimoY, limites.Bottom - altoFondo - 2));

            RectangleF fondo = new RectangleF(x, y, anchoFondo, altoFondo);
            graphics.FillRectangle(fondoEtiqueta, fondo);
            graphics.DrawString(etiqueta, SystemFonts.DefaultFont, textoEtiqueta, new PointF(fondo.X + 3, fondo.Y + 2));
        }

        private void FormularioAgregar_FormClosed(object? sender, FormClosedEventArgs e)
        {
            ContenedorPrimario.Panel2.Invalidate();
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
            CargarImagenPanel2();
            comprobarimagenpanel2();
        }

        private void CargarImagenPanel2()
        {
            try
            {
                if (!Directory.Exists(DirectorioDatos))
                    return;

                string? rutaImagen = Directory.GetFiles(DirectorioDatos, $"{NombreArchivoImagenPanel2}.*")
                    .OrderByDescending(File.GetLastWriteTimeUtc)
                    .FirstOrDefault();

                if (rutaImagen != null)
                    MostrarImagenPanel2(CargarImagenSinBloquear(rutaImagen));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo cargar la imagen guardada: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static Image CargarImagenSinBloquear(string rutaImagen)
        {
            using Image imagen = Image.FromFile(rutaImagen);
            return new Bitmap(imagen);
        }

        private void MostrarImagenPanel2(Image imagen)
        {
            Image? imagenAnterior = ContenedorPrimario.Panel2.BackgroundImage;
            ContenedorPrimario.Panel2.Controls.Clear();
            ContenedorPrimario.Panel2.BackgroundImage = imagen;
            ContenedorPrimario.Panel2.BackgroundImageLayout = ImageLayout.Stretch;
            imagenAnterior?.Dispose();
            ContenedorPrimario.Panel2.Invalidate();
        }

        private static void GuardarImagenPanel2(string rutaOrigen)
        {
            Directory.CreateDirectory(DirectorioDatos);

            string extension = Path.GetExtension(rutaOrigen);
            if (string.IsNullOrWhiteSpace(extension))
                extension = ".img";

            string rutaDestino = Path.Combine(DirectorioDatos, $"{NombreArchivoImagenPanel2}{extension}");
            if (!string.Equals(Path.GetFullPath(rutaOrigen), Path.GetFullPath(rutaDestino), StringComparison.OrdinalIgnoreCase))
                File.Copy(rutaOrigen, rutaDestino, true);

            foreach (string rutaAnterior in Directory.GetFiles(DirectorioDatos, $"{NombreArchivoImagenPanel2}.*"))
            {
                if (!string.Equals(Path.GetFullPath(rutaAnterior), Path.GetFullPath(rutaDestino), StringComparison.OrdinalIgnoreCase))
                    File.Delete(rutaAnterior);
            }
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

                openFileDialog.Title = "Seleccionar imagen del mapa";


                openFileDialog.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos los archivos|*.*";

                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Image? nuevaImagen = null;
                    try
                    {
                        string rutaArchivoSeleccionado = openFileDialog.FileName;
                        nuevaImagen = CargarImagenSinBloquear(rutaArchivoSeleccionado);
                        GuardarImagenPanel2(rutaArchivoSeleccionado);
                        MostrarImagenPanel2(nuevaImagen);
                        nuevaImagen = null;
                    }
                    catch (Exception ex)
                    {
                        nuevaImagen?.Dispose();
                        MessageBox.Show($"No se pudo guardar la imagen en la carpeta data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                // Captura la posición del clic antes de mostrar diálogos modales,
                // que mueven el cursor fuera del mapa.
                Point clickLocation = ContenedorPrimario.Panel2.PointToClient(Cursor.Position);

                if (_repositorioAcopios.IsEmpty())
                {
                    if (MessageBox.Show("Desea agregar un acopio aqui?", "Agregar elemento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        FrmAgregarAcopio formulario = FrmAgregarAcopio.GetInstance(clickLocation, _repositorioAcopios);
                        formulario.FormClosed -= FormularioAgregar_FormClosed;
                        formulario.FormClosed += FormularioAgregar_FormClosed;
                        formulario.Show();
                    }
                }
                else
                {
                    if (MessageBox.Show("Desea agregar un contenedor aqui?", "Agregar elemento", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        FrmAgregarContenedor formulario = FrmAgregarContenedor.GetInstance(clickLocation, _repositorioContenedores);
                        formulario.FormClosed -= FormularioAgregar_FormClosed;
                        formulario.FormClosed += FormularioAgregar_FormClosed;
                        formulario.Show();
                    }
                }

            }
        }
    }
}
