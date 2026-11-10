using RutaCampus.Domain;
using System;
using System.Collections.Generic;
using RutaCampus.Common;

namespace RutaCampus.Algortimos
{
    internal class NodoGrafo
    {
        private readonly Lista<Arista> _vecinos = new Lista<Arista>();

        public Punto? Ubicacion { get; set; }
        public Contenedores? Contenedor
        {
            get => Ubicacion as Contenedores;
            set => Ubicacion = value;
        }
        public IReadOnlyList<Arista> Vecinos => _vecinos;

        internal void AgregarArista(NodoGrafo nodoDestino, double peso)
        {
            _vecinos.Add(new Arista(nodoDestino, peso));
        }
    }

    internal sealed class Arista
    {
        public NodoGrafo NodoDestino { get; }
        public double Peso { get; }

        public Arista(NodoGrafo nodoDestino, double peso)
        {
            ArgumentNullException.ThrowIfNull(nodoDestino);

            if (!double.IsFinite(peso) || peso < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(peso), peso, "El peso debe ser finito y no negativo.");
            }

            NodoDestino = nodoDestino;
            Peso = peso;
        }
    }
}
