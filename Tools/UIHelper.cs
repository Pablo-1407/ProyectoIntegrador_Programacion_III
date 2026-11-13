using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Tools
{
    public static class UIHelper
    {
        public static void LimpiarControles(this Control contenedor)
        {
            foreach (Control control in contenedor.Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.Clear();
                }
                else if (control is ComboBox comboBox)
                {
                    if (comboBox.Items.Count > 0) comboBox.SelectedIndex = -1;
                }
                else if (control is CheckBox checkBox)
                {
                    checkBox.Checked = false;
                }

                // Si el control tiene contenedores hijos (como un Panel o GroupBox), limpia recursivamente
                if (control.HasChildren)
                {
                    control.LimpiarControles();
                }
            }
        }

        public static void AjustarTamanoAlContenido(this Form formulario, int margen = 20)
        {
            ArgumentNullException.ThrowIfNull(formulario);
            if (margen < 0)
                throw new ArgumentOutOfRangeException(nameof(margen));

            formulario.PerformLayout();

            int ancho = 0;
            int alto = 0;
            foreach (Control control in formulario.Controls)
            {
                control.PerformLayout();
                ancho = Math.Max(ancho, control.Right);
                alto = Math.Max(alto, control.Bottom);
            }

            formulario.AutoSize = false;
            formulario.ClientSize = new Size(ancho + margen, alto + margen);
        }
    }
}
