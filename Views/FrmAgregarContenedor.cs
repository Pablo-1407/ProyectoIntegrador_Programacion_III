using RutaCampus.Domain;
using RutaCampus.Repositories;
using System.Globalization;

namespace RutaCampus.Views
{
    public partial class FrmAgregarContenedor : Form
    {
        private static FrmAgregarContenedor? _instance;
        private ContenedoresRepository _repositorioContenedores = null!;

        private FrmAgregarContenedor()
        {
            InitializeComponent();
            cmbTipoResiduo.Items.AddRange(Enum.GetNames(typeof(TipoResiduo)));
            if (cmbTipoResiduo.Items.Count > 0)
                cmbTipoResiduo.SelectedIndex = 0;

            Button agregar = new Button
            {
                Text = "Agregar contenedor",
                Location = new Point(242, 350),
                AutoSize = true
            };
            agregar.Click += AgregarContenedor_Click;
            Controls.Add(agregar);
        }

        internal static FrmAgregarContenedor GetInstance(Point coordenadas, ContenedoresRepository repositorioContenedores)
        {
            ArgumentNullException.ThrowIfNull(repositorioContenedores);

            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmAgregarContenedor();
            }

            _instance._repositorioContenedores = repositorioContenedores;
            _instance.txtX.Text = coordenadas.X.ToString(CultureInfo.InvariantCulture);
            _instance.txtY.Text = coordenadas.Y.ToString(CultureInfo.InvariantCulture);
            return _instance;
        }

        private void AgregarContenedor_Click(object? sender, EventArgs e)
        {
            try
            {
                Contenedores contenedor = new Contenedores
                {
                    Id = int.Parse(textBox1.Text, CultureInfo.CurrentCulture),
                    Nombre = txtNombre.Text.Trim(),
                    Coordenadas = (
                        double.Parse(txtX.Text, CultureInfo.CurrentCulture),
                        double.Parse(txtY.Text, CultureInfo.CurrentCulture)),
                    TipoResiduo = Enum.Parse<TipoResiduo>(cmbTipoResiduo.SelectedItem?.ToString() ?? string.Empty),
                    CapacidadLitros = double.Parse(txtCapacidad.Text, CultureInfo.CurrentCulture),
                    NivelActualLitros = double.Parse(txtNivelActual.Text, CultureInfo.CurrentCulture),
                    FechaUltimaRecoleccion = DTPRecoleccion.Value.Date,
                    LitrosGeneradosPorDia = double.Parse(txtLitrosGenerados.Text, CultureInfo.CurrentCulture)
                };

                _repositorioContenedores.Add(contenedor);
                _repositorioContenedores.commit();
                MessageBox.Show("Contenedor agregado correctamente.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el contenedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
