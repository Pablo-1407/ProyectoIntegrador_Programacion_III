using RutaCampus.Common;
using RutaCampus.Domain;
using RutaCampus.Repositories;
using RutaCampus.Tools;
using System.Collections.Generic;
using System.Globalization;

namespace RutaCampus.Views
{
    public partial class FrmAgregarContenedor : Form
    {
        private static FrmAgregarContenedor? _instance;
        private ContenedoresRepository _repositorioContenedores = null!;
        private readonly Dictionary<string, Control> _mapaControles;
        private Point _coordenadas;

        private FrmAgregarContenedor()
        {
            InitializeComponent();

            Label titulo = new Label
            {
                Text = "Registrar Nuevo Contenedor",
                Font = new Font("Segoe UI", 16F),
                Location = new Point(20, 20),
                AutoSize = true
            };
            Controls.Add(titulo);

            _mapaControles = FormBuilder.GenerarFormulario(this, Esqueletos.ObtenerEsqueletoContenedor(), 70);
            ComboBox tipoResiduo = (ComboBox)_mapaControles["TipoResiduo"];
            if (tipoResiduo.Items.Count > 0)
                tipoResiduo.SelectedIndex = 0;

            int posicionY = 0;
            foreach (Control control in _mapaControles.Values)
                posicionY = Math.Max(posicionY, control.Bottom);

            Button agregar = new Button
            {
                Text = "Agregar contenedor",
                Location = new Point(20, posicionY + 20),
                AutoSize = true
            };
            agregar.Click += AgregarContenedor_Click;
            Controls.Add(agregar);
            this.AjustarTamanoAlContenido();
        }

        internal static FrmAgregarContenedor GetInstance(Point coordenadas, ContenedoresRepository repositorioContenedores)
        {
            ArgumentNullException.ThrowIfNull(repositorioContenedores);

            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmAgregarContenedor();
            }

            _instance._repositorioContenedores = repositorioContenedores;
            _instance._coordenadas = coordenadas;
            return _instance;
        }

        private void AgregarContenedor_Click(object? sender, EventArgs e)
        {
            try
            {
                ComboBox tipoResiduo = (ComboBox)_mapaControles["TipoResiduo"];
                DateTimePicker fechaRecoleccion = (DateTimePicker)_mapaControles["FechaUltimaRecoleccion"];
                Contenedores contenedor = new Contenedores
                {
                    Id = int.Parse(_mapaControles["Id"].Text, CultureInfo.CurrentCulture),
                    Nombre = _mapaControles["Nombre"].Text.Trim(),
                    Coordenadas = _coordenadas,
                    TipoResiduo = Enum.Parse<TipoResiduo>(tipoResiduo.SelectedItem?.ToString() ?? string.Empty),
                    CapacidadLitros = double.Parse(_mapaControles["CapacidadLitros"].Text, CultureInfo.CurrentCulture),
                    NivelActualLitros = double.Parse(_mapaControles["NivelActualLitros"].Text, CultureInfo.CurrentCulture),
                    FechaUltimaRecoleccion = fechaRecoleccion.Value.Date,
                    LitrosGeneradosPorDia = double.Parse(_mapaControles["LitrosGeneradosPorDia"].Text, CultureInfo.CurrentCulture)
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
