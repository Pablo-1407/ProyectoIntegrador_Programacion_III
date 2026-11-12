using RutaCampus.Common;
using RutaCampus.Domain;
using RutaCampus.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace RutaCampus.Views
{
    public partial class FrmAgregarAcopio : Form
    {
        private double _coordenadaX;
        private double _coordenadaY;
        private Dictionary<string, Control> _mapaControles;
        private AcopioRepository _repositorioAcopios = null!;
        private static FrmAgregarAcopio? _instance;
        private FrmAgregarAcopio()
        {
            InitializeComponent();
            this.FrmAgregarAcopio_Load(this, EventArgs.Empty);
        }

        internal static FrmAgregarAcopio GetInstance(Point coordenadas, AcopioRepository repositorioAcopios)
        {
            ArgumentNullException.ThrowIfNull(repositorioAcopios);

            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmAgregarAcopio();
            }

            _instance._coordenadaX = coordenadas.X;
            _instance._coordenadaY = coordenadas.Y;
            _instance._repositorioAcopios = repositorioAcopios;
            return _instance;
        }

        private void FrmAgregarAcopio_Load(object sender, EventArgs e)
        {
            Lista<CampoMetadata> esqueleto = Esqueletos.ObtenerEsqueletoAcopio();
            _mapaControles = FormBuilder.GenerarFormulario(this, esqueleto);
            CrearBotonAgregar();
        }

        private void CrearBotonAgregar()
        {
            int y = 0;
            foreach (var control in _mapaControles.Values)
            {
               y += control.Height + 10; // 10 es el espacio entre controles
            }
            Button agregar = new Button
            {
                Text = "Agregar Acopio",
                Location = new Point(20, y + 20),
                AutoSize = true
            };
            agregar.Click += button1_Click;
            this.Controls.Add(agregar);
            agregar.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string line = FormBuilder.GenerarCsvDesdeFormulario(Esqueletos.ObtenerEsqueletoAcopio(), _mapaControles);
                line += $",{_coordenadaX.ToString(CultureInfo.InvariantCulture)},{_coordenadaY.ToString(CultureInfo.InvariantCulture)}";
                Acopio acopio = Acopio.Create(line);
                _repositorioAcopios.Add(acopio);
                _repositorioAcopios.commit();
                MessageBox.Show("Acopio agregado: " + line);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el acopio: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
