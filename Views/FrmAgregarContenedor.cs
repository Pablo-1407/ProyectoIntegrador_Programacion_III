namespace FormContenedor
{
    public partial class FrmAgregarContenedor : Form
    {
        private static FrmAgregarContenedor? _instance;

        private FrmAgregarContenedor()
        {
            InitializeComponent();
        }

        public static FrmAgregarContenedor GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmAgregarContenedor();
            }
            return _instance;
        }
    }
}
