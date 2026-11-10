using RutaCampus.Views;

namespace RutaCampus
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
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
    }
}
