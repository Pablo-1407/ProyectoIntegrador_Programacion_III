using System;
using System.Collections.Generic;
using RutaCampus.Common;

namespace RutaCampus.Algortimos
{
    internal sealed class ResultadoPlanRecogida
    {
        public IReadOnlyList<PasoPlanRecogida> Pasos { get; }
        public double DistanciaTotalKilometros { get; }
        public double TiempoConduccionHoras { get; }
        public double TiempoRecogidaHoras { get; }
        public double TiempoDescargaHoras { get; }
        public double TiempoTotalHoras { get; }
        public double CostoDistancia { get; }
        public double CostoTiempo { get; }
        public double CostoTotal { get; }
        public double LitrosRecogidos { get; }
        public int NumeroRecogidas { get; }
        public int NumeroDescargas { get; }

        public ResultadoPlanRecogida(
            IEnumerable<PasoPlanRecogida> pasos,
            double distanciaTotalKilometros,
            double tiempoConduccionHoras,
            double tiempoRecogidaHoras,
            double tiempoDescargaHoras,
            double costoPorKilometro,
            double costoPorHora)
        {
            ArgumentNullException.ThrowIfNull(pasos);

            ValidarNoNegativoFinito(distanciaTotalKilometros, nameof(distanciaTotalKilometros));
            ValidarNoNegativoFinito(tiempoConduccionHoras, nameof(tiempoConduccionHoras));
            ValidarNoNegativoFinito(tiempoRecogidaHoras, nameof(tiempoRecogidaHoras));
            ValidarNoNegativoFinito(tiempoDescargaHoras, nameof(tiempoDescargaHoras));
            ValidarNoNegativoFinito(costoPorKilometro, nameof(costoPorKilometro));
            ValidarNoNegativoFinito(costoPorHora, nameof(costoPorHora));

            Lista<PasoPlanRecogida> pasosCopia = new Lista<PasoPlanRecogida>();
            double litrosRecogidos = 0;
            int numeroRecogidas = 0;
            int numeroDescargas = 0;

            foreach (PasoPlanRecogida paso in pasos)
            {
                if (paso is null)
                {
                    throw new ArgumentException("La lista de pasos no puede contener valores nulos.", nameof(pasos));
                }

                pasosCopia.Add(paso);
                if (paso.Tipo == TipoPasoRecogida.Recogida)
                {
                    litrosRecogidos += paso.Litros;
                    numeroRecogidas++;
                }
                else if (paso.Tipo == TipoPasoRecogida.Descarga)
                {
                    numeroDescargas++;
                }
            }

            TiempoTotalHoras = tiempoConduccionHoras + tiempoRecogidaHoras + tiempoDescargaHoras;
            CostoDistancia = distanciaTotalKilometros * costoPorKilometro;
            CostoTiempo = TiempoTotalHoras * costoPorHora;
            CostoTotal = CostoDistancia + CostoTiempo;

            ValidarNoNegativoFinito(TiempoTotalHoras, nameof(tiempoConduccionHoras));
            ValidarNoNegativoFinito(CostoDistancia, nameof(costoPorKilometro));
            ValidarNoNegativoFinito(CostoTiempo, nameof(costoPorHora));
            ValidarNoNegativoFinito(CostoTotal, nameof(CostoTotal));
            ValidarNoNegativoFinito(litrosRecogidos, nameof(litrosRecogidos));

            Pasos = pasosCopia.AsReadOnly();
            DistanciaTotalKilometros = distanciaTotalKilometros;
            TiempoConduccionHoras = tiempoConduccionHoras;
            TiempoRecogidaHoras = tiempoRecogidaHoras;
            TiempoDescargaHoras = tiempoDescargaHoras;
            LitrosRecogidos = litrosRecogidos;
            NumeroRecogidas = numeroRecogidas;
            NumeroDescargas = numeroDescargas;
        }

        private static void ValidarNoNegativoFinito(double valor, string nombre)
        {
            if (!double.IsFinite(valor) || valor < 0)
            {
                throw new ArgumentOutOfRangeException(nombre, valor, "El valor debe ser finito y no negativo.");
            }
        }
    }
}
