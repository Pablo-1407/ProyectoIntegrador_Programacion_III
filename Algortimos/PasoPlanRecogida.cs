using System;
using System.Collections.Generic;
using RutaCampus.Common;

namespace RutaCampus.Algortimos
{
    internal enum TipoPasoRecogida
    {
        Recogida,
        Descarga,
        RegresoAcopio
    }

    internal sealed class PasoPlanRecogida
    {
        public TipoPasoRecogida Tipo { get; }
        public NodoGrafo Nodo { get; }
        public IReadOnlyList<NodoGrafo> Trayecto { get; }
        public double Litros { get; }
        public double DistanciaKilometros { get; }

        public PasoPlanRecogida(
            TipoPasoRecogida tipo,
            NodoGrafo nodo,
            IEnumerable<NodoGrafo> trayecto,
            double litros,
            double distanciaKilometros)
        {
            ArgumentNullException.ThrowIfNull(nodo);
            ArgumentNullException.ThrowIfNull(trayecto);

            if (!double.IsFinite(litros) || litros < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(litros), litros, "Los litros deben ser finitos y no negativos.");
            }

            if (!double.IsFinite(distanciaKilometros) || distanciaKilometros < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(distanciaKilometros), distanciaKilometros, "La distancia debe ser finita y no negativa.");
            }

            Lista<NodoGrafo> trayectoCopia = new Lista<NodoGrafo>(trayecto);
            if (trayectoCopia.Count == 0 || !ReferenceEquals(trayectoCopia[trayectoCopia.Count - 1], nodo))
            {
                throw new ArgumentException("El trayecto debe terminar en el nodo del paso.", nameof(trayecto));
            }

            Tipo = tipo;
            Nodo = nodo;
            Trayecto = trayectoCopia.AsReadOnly();
            Litros = litros;
            DistanciaKilometros = distanciaKilometros;
        }
    }
}
