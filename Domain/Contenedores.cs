using RutaCampus.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Domain
{
    internal sealed class Contenedores: Punto, IFactory<Contenedores>, ISerialize<Contenedores>
    {
        public TipoResiduo TipoResiduo { get; set; } = TipoResiduo.General;
        public double CapacidadLitros { get; set; } = 0.0;
        public double NivelActualLitros { get; set; } = 0.0;
        public DateTime FechaUltimaRecoleccion { get; set; } = DateTime.MinValue;
        public double LitrosGeneradosPorDia { get; set; } = 0.0;
        private double PorcentajeLlenado
        {
            get
            {
                if (!double.IsFinite(CapacidadLitros) || CapacidadLitros <= 0 || !double.IsFinite(NivelActualLitros))
                    return 0;

                double porcentaje = (NivelActualLitros / CapacidadLitros) * 100;
                return double.IsFinite(porcentaje) ? Math.Max(0, porcentaje) : 0;
            }
        }

        public double PesoDinamico
        {
            get
            {
                double puntajeUrgencia = 0;
                var diasSinRecoleccion = (DateTime.Now - FechaUltimaRecoleccion).TotalDays;

                // Regla 1: Si lleva más de 3 días sin recolección
                if (diasSinRecoleccion > 3)
                {
                    puntajeUrgencia += 50;
                }

                // Regla 2: Si su capacidad proyectada llega al máximo en 2 días o menos
                double capacidadRestante = CapacidadLitros - NivelActualLitros;
                if (double.IsFinite(CapacidadLitros) && CapacidadLitros > 0
                    && double.IsFinite(NivelActualLitros)
                    && double.IsFinite(LitrosGeneradosPorDia) && LitrosGeneradosPorDia > 0
                    && (capacidadRestante / LitrosGeneradosPorDia) <= 2)
                {
                    puntajeUrgencia += 50;
                }

                // Puedes sumar el porcentaje actual de llenado como base
                puntajeUrgencia += PorcentajeLlenado;

                return puntajeUrgencia;
            }
        }

        public static Contenedores Create()
        {
            return new Contenedores();
        }

        public static Contenedores Create(string textCsv)
        {
            return Deserialize(textCsv);
        }

        public static Contenedores Deserialize(string textCsv)
        {
            string[] parts = textCsv.Split(',');
            if (parts.Length != 9)
            {
                throw new ArgumentException("El texto CSV no tiene el formato correcto.");
            }

            int id = int.Parse(parts[0]);
            string nombre = parts[1];
            double x = double.Parse(parts[2]);
            double y = double.Parse(parts[3]);
            TipoResiduo tipoResiduo = Enum.Parse<TipoResiduo>(parts[4]);
            double capacidadLitros = double.Parse(parts[5]);
            double nivelActualLitros = double.Parse(parts[6]);
            DateTime fechaUltimaRecoleccion = DateTime.Parse(parts[7]);
            double litrosGeneradosPorDia = double.Parse(parts[8]);

            return new Contenedores
            {
                Id = id,
                Nombre = nombre,
                Coordenadas = (x, y),
                TipoResiduo = tipoResiduo,
                CapacidadLitros = capacidadLitros,
                NivelActualLitros = nivelActualLitros,
                FechaUltimaRecoleccion = fechaUltimaRecoleccion,
                LitrosGeneradosPorDia = litrosGeneradosPorDia
            };
        }

        public static string Serialize(Contenedores obj)
        {
            return $"{obj.Id},{obj.Nombre},{obj.Coordenadas.x},{obj.Coordenadas.y},{obj.TipoResiduo},{obj.CapacidadLitros},{obj.NivelActualLitros},{obj.FechaUltimaRecoleccion},{obj.LitrosGeneradosPorDia}";
        }

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Coordenadas: ({Coordenadas.x}, {Coordenadas.y}), TipoResiduo: {TipoResiduo}, CapacidadLitros: {CapacidadLitros}, NivelActualLitros: {NivelActualLitros}, FechaUltimaRecoleccion: {FechaUltimaRecoleccion}, LitrosGeneradosPorDia: {LitrosGeneradosPorDia}, PorcentajeLlenado: {PorcentajeLlenado}%";
        }
    }
}
