using RutaCampus.Common;
using RutaCampus.Domain;
using RutaCampus.Repositories;
using RutaCampus.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RutaCampus.Views
{
    public partial class FrmAgregarVehiculo : Form
    {
        Repository<Vehiculo, string> repository = new Repository<Vehiculo, string>("Vehiculo.txt"); //temporal cambiar a ruta + vehiculo.txt
        private static FrmAgregarVehiculo? _instance = null;
        private Dictionary<string, Control> _mapaControles = new();
        private FrmAgregarVehiculo()
        {
            InitializeComponent();
        }

        public static FrmAgregarVehiculo GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmAgregarVehiculo();
            }
            return _instance;
        }

        private void FrmAgregarVehiculo_Load(object sender, EventArgs e)
        {
            Lista<CampoMetadata> esqueleto = Esqueletos.ObtenerEsqueletoVehiculo();
            _mapaControles = FormBuilder.GenerarFormulario(this, esqueleto);
            if (!repository.IsEmpty())
            {
                Vehiculo vehiculo = repository.GetAll().First();
                _mapaControles["Id"].Text = vehiculo.Id;
                _mapaControles["CapacidadMaximaLitros"].Text = vehiculo.CapacidadMaximaLitros.ToString();
                _mapaControles["NivelActualLitros"].Text = vehiculo.NivelActualLitros.ToString();
                _mapaControles["CostoPorKilometro"].Text = vehiculo.CostoPorKilometro.ToString();
                _mapaControles["CostoPorHora"].Text = vehiculo.CostoPorHora.ToString();
                _mapaControles["tiempopromedio"].Text = vehiculo.tiempopromedio.ToString();
                _mapaControles["tiempodescarga"].Text = vehiculo.tiempodescarga.ToString();
                _mapaControles["velocidadpromedio"].Text = vehiculo.velocidadpromedio.ToString();
                
            }   
        }

        private void TSBAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string line = FormBuilder.GenerarCsvDesdeFormulario(Esqueletos.ObtenerEsqueletoVehiculo(), _mapaControles);
                Vehiculo Recolector = Vehiculo.Create(line);
                repository.Add(Recolector);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el vehículo {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TSBActualizar_Click(object sender, EventArgs e)
        {
            try 
            {
                string line = FormBuilder.GenerarCsvDesdeFormulario(Esqueletos.ObtenerEsqueletoVehiculo(), _mapaControles);
                Vehiculo Recolector = Vehiculo.Create(line);
                repository.Update(Recolector);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el vehículo {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void TSBEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                string placa = _mapaControles["Id"].Text;
                repository.Delete(placa);
                UIHelper.LimpiarControles(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el vehículo {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void TSBLimpiar_Click(object sender, EventArgs e)
        {
            UIHelper.LimpiarControles(this);
        }

        private void TSBGuardar_Click(object sender, EventArgs e)
        {
            repository.commit();
        }
    }
}

