using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RutaCampus.Common
{
    public enum TipoControl
    {
        Texto,
        Numero,
        Decimal,
        Fecha,
        Desplegable
    }

    public class CampoMetadata
    {
        public string NombrePropiedad { get; set; } = string.Empty;
        public string Etiqueta { get; set; } = string.Empty;
        public TipoControl Tipo { get; set; }
        public string[]? Opciones { get; set; } // Para ComboBox si no null
    }
}