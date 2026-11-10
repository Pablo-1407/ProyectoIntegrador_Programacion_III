using System;
using System.Collections.Generic;
using RutaCampus.Common;

namespace RutaCampus.Algortimos
{
    internal sealed class Grafo
    {
        private readonly Lista<NodoGrafo> _nodos = new Lista<NodoGrafo>();
        private readonly Lista<Conexion> _conexiones = new Lista<Conexion>();

        public IReadOnlyList<NodoGrafo> Nodos => _nodos.AsReadOnly();
        public IReadOnlyList<Conexion> Conexiones => _conexiones.AsReadOnly();

        public void AgregarNodo(NodoGrafo nodo)
        {
            ArgumentNullException.ThrowIfNull(nodo);

            if (_nodos.Contains(nodo))
            {
                throw new ArgumentException("El nodo ya está registrado en el grafo.", nameof(nodo));
            }

            _nodos.Add(nodo);
        }

        public void AgregarConexion(Conexion conexion)
        {
            ArgumentNullException.ThrowIfNull(conexion);

            NodoGrafo nodoOrigen = ResolverNodo(conexion.NodoOrigenId, nameof(conexion.NodoOrigenId));
            NodoGrafo nodoDestino = ResolverNodo(conexion.NodoDestinoId, nameof(conexion.NodoDestinoId));

            if ((conexion.NodoOrigenEnlazado is not null && !ReferenceEquals(conexion.NodoOrigenEnlazado, nodoOrigen))
                || (conexion.NodoDestinoEnlazado is not null && !ReferenceEquals(conexion.NodoDestinoEnlazado, nodoDestino)))
            {
                throw new ArgumentException("Los nodos de la conexión deben estar registrados en este grafo.", nameof(conexion));
            }

            conexion.EnlazarNodos(nodoOrigen, nodoDestino);
            nodoOrigen.AgregarArista(nodoDestino, conexion.DistanciaKilometros);
            if (conexion.EsBidireccional)
            {
                nodoDestino.AgregarArista(nodoOrigen, conexion.DistanciaKilometros);
            }

            _conexiones.Add(conexion);
        }

        private NodoGrafo ResolverNodo(int id, string nombreParametro)
        {
            NodoGrafo? encontrado = null;

            foreach (NodoGrafo nodo in _nodos)
            {
                if (nodo.Ubicacion?.Id != id)
                {
                    continue;
                }

                if (encontrado is not null)
                {
                    throw new InvalidOperationException($"El identificador {id} no es único en el grafo.");
                }

                encontrado = nodo;
            }

            return encontrado ?? throw new ArgumentException($"No existe en el grafo un nodo con el identificador {id}.", nombreParametro);
        }
    }
}
