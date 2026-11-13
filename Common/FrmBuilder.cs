using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RutaCampus.Common
{
        public static class FormBuilder
        {
            public static Dictionary<string, Control> GenerarFormulario(Control contenedorPadre, Lista<CampoMetadata> esqueleto, int posicionInicialY = 20)
            {
                var controlesGenerados = new Dictionary<string, Control>();
                int posicionY = posicionInicialY;
                int espaciadoY = 40;

                foreach (var campo in esqueleto)
                {
                    // Etiqueta
                    contenedorPadre.Controls.Add(new Label
                    {
                        Text = campo.Etiqueta,
                        Location = new Point(20, posicionY + 4),
                        AutoSize = true,
                        BorderStyle = BorderStyle.Fixed3D
                    });

                    Control ctrl = campo.Tipo switch
                    {
                        TipoControl.Fecha => new DateTimePicker { Format = DateTimePickerFormat.Short, Width = 200 },
                        TipoControl.Desplegable => new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList, Width = 200 },
                        _ => new TextBox { Width = 200 }
                    };

                    if (ctrl is ComboBox cb && campo.Opciones != null)
                    {
                        cb.Items.AddRange(campo.Opciones);
                    }

                    ctrl.Name = $"ctrl_{campo.NombrePropiedad}";
                    ctrl.Location = new Point(220, posicionY);
                    contenedorPadre.Controls.Add(ctrl);

                    controlesGenerados.Add(campo.NombrePropiedad, ctrl);
                    posicionY += espaciadoY;
                }

                return controlesGenerados;
            }
        public static string GenerarCsvDesdeFormulario(Lista<CampoMetadata> esqueleto, Dictionary<string, Control> controles)
            {
                var valores = new Lista<string>();

                foreach (var campo in esqueleto)
                {
                    if (!controles.TryGetValue(campo.NombrePropiedad, out Control? control))
                    {
                        valores.Add(string.Empty);
                        continue;
                    }

                    if (control is TextBox txt)
                    {
                        valores.Add(txt.Text.Trim());
                    }
                    else if (control is DateTimePicker dtp)
                    {
                        valores.Add(dtp.Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
                    }
                    else if (control is ComboBox cb)
                    {
                        valores.Add(cb.SelectedItem?.ToString() ?? string.Empty);
                    }
                    else
                    {
                        valores.Add(string.Empty);
                    }
                }

                return string.Join(",", valores);
            }
        }
    }

