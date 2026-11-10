using RutaCampus.Common;
using RutaCampus.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Domain
{
    internal sealed class Vehiculo : Singleton<Vehiculo>, IDentity<string>, IFactory<Vehiculo>, ISerialize<Vehiculo>
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
            string[] parts = textCsv.Split(',');
            if (parts.Length != 8)
            {
                throw new ArgumentException("El texto CSV no tiene el formato correcto.");
            }
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
    }
}
