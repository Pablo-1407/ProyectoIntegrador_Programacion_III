using RutaCampus.Common;
using System;
using System.Collections.Generic;

namespace RutaCampus.Algortimos
{
    internal static class Dijkstra
    {
        public static (IReadOnlyList<NodoGrafo> Ruta, double Coste) CalcularRutaMasCorta(NodoGrafo origen, NodoGrafo destino)
        {
            ArgumentNullException.ThrowIfNull(origen);
            ArgumentNullException.ThrowIfNull(destino);
            ValidarPesos(origen);

            Dictionary<NodoGrafo, double> distancias = new Dictionary<NodoGrafo, double>
            {
                [origen] = 0
            };
            Dictionary<NodoGrafo, NodoGrafo> predecesores = new Dictionary<NodoGrafo, NodoGrafo>();
            PriorityQueue<EntradaPrioridad> pendientes = new PriorityQueue<EntradaPrioridad>();
            pendientes.Enqueue(new EntradaPrioridad(origen, 0));

            while (pendientes.Count > 0)
            {
                EntradaPrioridad entrada = pendientes.Dequeue();
                if (!distancias.TryGetValue(entrada.Nodo, out double distanciaActual) || entrada.Coste > distanciaActual)
                {
                    continue;
                }

                if (ReferenceEquals(entrada.Nodo, destino))
                {
                    break;
                }

                foreach (Arista arista in entrada.Nodo.Vecinos)
                {
                    double nuevoCoste = distanciaActual + arista.Peso;
                    if (double.IsInfinity(nuevoCoste))
                    {
                        continue;
                    }

                    if (!distancias.TryGetValue(arista.NodoDestino, out double costeAnterior) || nuevoCoste < costeAnterior)
                    {
                        distancias[arista.NodoDestino] = nuevoCoste;
                        predecesores[arista.NodoDestino] = entrada.Nodo;
                        pendientes.Enqueue(new EntradaPrioridad(arista.NodoDestino, nuevoCoste));
                    }
                }
            }

            if (!distancias.TryGetValue(destino, out double costeTotal))
            {
                return (Array.Empty<NodoGrafo>(), double.PositiveInfinity);
            }

            Lista<NodoGrafo> ruta = new Lista<NodoGrafo> { destino };
            NodoGrafo actual = destino;
            while (!ReferenceEquals(actual, origen))
            {
                if (!predecesores.TryGetValue(actual, out NodoGrafo? predecesor))
                {
                    return (Array.Empty<NodoGrafo>(), double.PositiveInfinity);
                }

                actual = predecesor;
                ruta.Add(actual);
            }

            ruta.Reverse();
            return (ruta, costeTotal);
        }

        private static void ValidarPesos(NodoGrafo origen)
        {
            HashSet<NodoGrafo> visitados = new HashSet<NodoGrafo>();
            Pila<NodoGrafo> pendientes = new Pila<NodoGrafo>();
            pendientes.Push(origen);

            while (pendientes.Count > 0)
            {
                NodoGrafo actual = pendientes.Pop();
                if (!visitados.Add(actual))
                {
                    continue;
                }

                foreach (Arista arista in actual.Vecinos)
                {
                    if (!double.IsFinite(arista.Peso) || arista.Peso < 0)
                    {
                        throw new ArgumentOutOfRangeException(nameof(Arista.Peso), arista.Peso, "Dijkstra requiere pesos finitos y no negativos.");
                    }

                    pendientes.Push(arista.NodoDestino);
                }
            }
        }

        private readonly record struct EntradaPrioridad(NodoGrafo Nodo, double Coste) : IComparable<EntradaPrioridad>
        {
            public int CompareTo(EntradaPrioridad other)
            {
                return Coste.CompareTo(other.Coste);
            }
        }
    }
}
