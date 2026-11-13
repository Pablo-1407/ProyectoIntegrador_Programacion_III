using RutaCampus.Common;
using RutaCampus.Contratos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace RutaCampus.Domain
{
    internal sealed class Vehiculo : Singleton<Vehiculo>, IIdentity<string>, IFactory<Vehiculo>, ISerialize<Vehiculo>
    {
        public string Id { get; set; } = string.Empty; // Placa del vehículo
        public double CapacidadMaximaLitros { get; set; } = 0.0;
        public double NivelActualLitros { get; set; } = 0.0;
        public double CostoPorKilometro { get; set; } = 0.0; // Gaslina, mantenimiento, etc.
        public double CostoPorHora { get; set; } = 0.0; //salarios o alquiler del vehículo

        public double tiempopromedio { get; set; } = 0.0; // Tiempo promedio de recolección por contenedor en minutos
        public double tiempodescarga { get; set; } = 0.0; // Tiempo promedio de descarga en minutos
        public double velocidadpromedio { get; set; } = 0.0; // Velocidad promedio del vehículo en km/h

        private Vehiculo() { }

        public static Vehiculo Create()
        {
            return new Vehiculo();
        }

        public static Vehiculo Create(string textCsv)
        {
            return Deserialize(textCsv);
        }

        public static Vehiculo Deserialize(string textCsv)
        {
            ValidarCsv(textCsv);
            string[] parts = textCsv.Split(',');
            
          

            return new Vehiculo
            {
                Id = parts[0],
                CapacidadMaximaLitros = double.Parse(parts[1]),
                NivelActualLitros = double.Parse(parts[2]),
                CostoPorKilometro = double.Parse(parts[3]),
                CostoPorHora = double.Parse(parts[4]),
                tiempopromedio = double.Parse(parts[5]),
                tiempodescarga = double.Parse(parts[6]),
                velocidadpromedio = double.Parse(parts[7])
            };
        }

        public static string Serialize(Vehiculo obj)
        {
            return $"{obj.Id},{obj.CapacidadMaximaLitros},{obj.NivelActualLitros},{obj.CostoPorKilometro},{obj.CostoPorHora},{obj.tiempopromedio},{obj.tiempodescarga},{obj.velocidadpromedio}";
        }
        private static void ValidarCsv(string textCsv)
        {
            if (string.IsNullOrWhiteSpace(textCsv))
                throw new ArgumentException("El texto CSV no puede estar vacío.");

            string[] parts = textCsv.Split(',');
            if (parts.Length != 8)
                throw new ArgumentException("El texto CSV no tiene las 8 columnas requeridas.");

            if (string.IsNullOrWhiteSpace(parts[0]))
                throw new ArgumentException("El campo Id no puede estar vacío.");

            // Validar que del índice 1 al 7 sean dobles válidos
            for (int i = 1; i <= 7; i++)
            {
                if (!double.TryParse(parts[i], NumberStyles.Any, CultureInfo.InvariantCulture, out _))
                {
                    throw new ArgumentException($"El campo en la posición {i} no es un número decimal válido.");
                }
            }
        }
    }
}
