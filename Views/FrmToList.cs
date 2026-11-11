
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RutaCampus.Views
{
    public partial class FrmToList : Form
    {
        private static FrmToList? _instance = null;
        private FrmToList()
        {
            InitializeComponent();
        }

        public static FrmToList GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmToList();
            }
            return _instance;
        }
        private void dgvLista_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Organizar las primeras columnas
            if (dgvLista.Columns.Contains("Id"))
                dgvLista.Columns["Id"].DisplayIndex = 0;

            if (dgvLista.Columns.Contains("Nombre"))
                dgvLista.Columns["Nombre"].DisplayIndex = 1;

            if (dgvLista.Columns.Contains("Coordenadas"))
                dgvLista.Columns["Coordenadas"].DisplayIndex = 2;
        }

        public void CargarDatos<T>(IEnumerable<T> datos, string titulo)
        {
            lblTitulo.Text = titulo;

            // Cargar los registros
            dgvLista.DataSource = null;
            dgvLista.DataSource = datos.ToList();

            // Ocultar la columna de encabezado de las filas
            dgvLista.RowHeadersVisible = false;

            // Distribuir las columnas en todo el ancho disponible
            dgvLista.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Ajustar los encabezados
            dgvLista.ColumnHeadersHeightSizeMode =
                DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            // Permitir desplazamiento horizontal y vertical
            dgvLista.ScrollBars = ScrollBars.Both;

            // Establecer proporciones de las primeras columnas
            if (dgvLista.Columns.Contains("Id"))
                dgvLista.Columns["Id"].FillWeight = 40;

            if (dgvLista.Columns.Contains("Nombre"))
                dgvLista.Columns["Nombre"].FillWeight = 100;

            if (dgvLista.Columns.Contains("Coordenadas"))
                dgvLista.Columns["Coordenadas"].FillWeight = 120;
        }
    }
}
