using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RutaCampus.Views
{
    public partial class FrmAgregarAcopio : Form
    {
        private static FrmAgregarAcopio? _instance;
        private FrmAgregarAcopio()
        {
            InitializeComponent();
        }

        public static FrmAgregarAcopio GetInstance()
        {
            if (_instance == null || _instance.IsDisposed)
            {
                _instance = new FrmAgregarAcopio();
            }
            return _instance;
        }
    }
}
