using RutaCampus.Contratos;
using System;
using System.Globalization;

namespace RutaCampus.Algortimos
{
    internal sealed class Conexion : IDentity<int>, IFactory<Conexion>, ISerialize<Conexion>
    {
        private NodoGrafo? _nodoOrigen;
        private NodoGrafo? _nodoDestino;
        private int _nodoOrigenId;
        private int _nodoDestinoId;

        public int Id { get; set; }
        public int NodoOrigenId => _nodoOrigen?.Ubicacion?.Id ?? _nodoOrigenId;
        public int NodoDestinoId => _nodoDestino?.Ubicacion?.Id ?? _nodoDestinoId;
        public NodoGrafo NodoOrigen => _nodoOrigen ?? throw new InvalidOperationException("La conexión todavía no está asociada a un grafo.");
        public NodoGrafo NodoDestino => _nodoDestino ?? throw new InvalidOperationException("La conexión todavía no está asociada a un grafo.");
        internal NodoGrafo? NodoOrigenEnlazado => _nodoOrigen;
        internal NodoGrafo? NodoDestinoEnlazado => _nodoDestino;
        public double DistanciaKilometros { get; private set; }
        public bool EsBidireccional { get; private set; }

        public Conexion()
        {
        }

        public Conexion(NodoGrafo nodoOrigen, NodoGrafo nodoDestino, double distanciaKilometros, bool esBidireccional)
        {
            ArgumentNullException.ThrowIfNull(nodoOrigen);
            ArgumentNullException.ThrowIfNull(nodoDestino);

            ValidarDistancia(distanciaKilometros);
            _nodoOrigen = nodoOrigen;
            _nodoDestino = nodoDestino;
            _nodoOrigenId = nodoOrigen.Ubicacion?.Id ?? 0;
            _nodoDestinoId = nodoDestino.Ubicacion?.Id ?? 0;
            DistanciaKilometros = distanciaKilometros;
            EsBidireccional = esBidireccional;
        }

        public Conexion(int id, int nodoOrigenId, int nodoDestinoId, double distanciaKilometros, bool esBidireccional)
        {
            ValidarDistancia(distanciaKilometros);
            Id = id;
            _nodoOrigenId = nodoOrigenId;
            _nodoDestinoId = nodoDestinoId;
            DistanciaKilometros = distanciaKilometros;
            EsBidireccional = esBidireccional;
        }

        public static Conexion Create()
        {
            return new Conexion();
        }

        public static Conexion Create(string textCsv)
        {
            return Deserialize(textCsv);
        }

        public static Conexion Deserialize(string textCsv)
        {
            ArgumentNullException.ThrowIfNull(textCsv);

            string[] partes = textCsv.Split(',');
            if (partes.Length != 5
                || !int.TryParse(partes[0], NumberStyles.Integer, CultureInfo.InvariantCulture, out int id)
                || !int.TryParse(partes[1], NumberStyles.Integer, CultureInfo.InvariantCulture, out int nodoOrigenId)
                || !int.TryParse(partes[2], NumberStyles.Integer, CultureInfo.InvariantCulture, out int nodoDestinoId)
                || !double.TryParse(partes[3], NumberStyles.Float, CultureInfo.InvariantCulture, out double distanciaKilometros)
                || !bool.TryParse(partes[4], out bool esBidireccional))
            {
                throw new ArgumentException("El texto CSV de la conexión no tiene el formato correcto.", nameof(textCsv));
            }

            return new Conexion(id, nodoOrigenId, nodoDestinoId, distanciaKilometros, esBidireccional);
        }

        public static string Serialize(Conexion obj)
        {
            ArgumentNullException.ThrowIfNull(obj);

            if ((obj._nodoOrigen is not null && obj._nodoOrigen.Ubicacion is null)
                || (obj._nodoDestino is not null && obj._nodoDestino.Ubicacion is null))
            {
                throw new InvalidOperationException("Los nodos de la conexión deben tener una ubicación para poder persistirse.");
            }

            return string.Join(",",
                obj.Id.ToString(CultureInfo.InvariantCulture),
                obj.NodoOrigenId.ToString(CultureInfo.InvariantCulture),
                obj.NodoDestinoId.ToString(CultureInfo.InvariantCulture),
                obj.DistanciaKilometros.ToString("R", CultureInfo.InvariantCulture),
                obj.EsBidireccional.ToString());
        }

        internal void EnlazarNodos(NodoGrafo nodoOrigen, NodoGrafo nodoDestino)
        {
            ArgumentNullException.ThrowIfNull(nodoOrigen);
            ArgumentNullException.ThrowIfNull(nodoDestino);

            if (nodoOrigen.Ubicacion?.Id != NodoOrigenId || nodoDestino.Ubicacion?.Id != NodoDestinoId)
            {
                throw new ArgumentException("Los nodos no coinciden con los identificadores de la conexión.");
            }

            _nodoOrigen = nodoOrigen;
            _nodoDestino = nodoDestino;
        }

        private static void ValidarDistancia(double distanciaKilometros)
        {
            if (!double.IsFinite(distanciaKilometros) || distanciaKilometros < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(distanciaKilometros), distanciaKilometros, "La distancia debe ser finita y no negativa.");
            }
        }
    }
}
