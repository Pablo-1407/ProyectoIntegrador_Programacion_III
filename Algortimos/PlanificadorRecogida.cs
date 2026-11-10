using RutaCampus.Domain;
using RutaCampus.Common;
using System;
using System.Collections.Generic;

namespace RutaCampus.Algortimos
{
    internal static class PlanificadorRecogida
    {
        public static ResultadoPlanRecogida Planificar(
            Grafo grafo,
            NodoGrafo acopio,
            Vehiculo vehiculo,
            IEnumerable<NodoGrafo> paradasSolicitadas,
            double umbralUrgencia)
        {
            ArgumentNullException.ThrowIfNull(grafo);
            ArgumentNullException.ThrowIfNull(acopio);
            ArgumentNullException.ThrowIfNull(vehiculo);
            ArgumentNullException.ThrowIfNull(paradasSolicitadas);

            if (!double.IsFinite(umbralUrgencia) || umbralUrgencia < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(umbralUrgencia), umbralUrgencia, "El umbral debe ser finito y no negativo.");
            }

            ValidarVehiculo(vehiculo);

            HashSet<NodoGrafo> nodosRegistrados = new HashSet<NodoGrafo>(grafo.Nodos);
            if (!nodosRegistrados.Contains(acopio))
            {
                throw new ArgumentException("El acopio debe pertenecer al grafo.", nameof(acopio));
            }

            if (acopio.Ubicacion is not Acopio)
            {
                throw new ArgumentException("El nodo de salida debe representar un acopio.", nameof(acopio));
            }

            Lista<NodoGrafo> pendientes = new Lista<NodoGrafo>();
            HashSet<NodoGrafo> agregadas = new HashSet<NodoGrafo>();
            Dictionary<NodoGrafo, double> litrosPendientes = new Dictionary<NodoGrafo, double>();

            void AgregarParada(NodoGrafo parada)
            {
                if (parada is null || !nodosRegistrados.Contains(parada))
                {
                    throw new ArgumentException("Todas las paradas solicitadas deben pertenecer al grafo.", nameof(paradasSolicitadas));
                }

                Contenedores? contenedor = parada.Contenedor;
                if (contenedor is null)
                {
                    throw new ArgumentException("Las paradas de recogida deben representar contenedores.", nameof(paradasSolicitadas));
                }

                if (!double.IsFinite(contenedor.NivelActualLitros) || contenedor.NivelActualLitros < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(paradasSolicitadas), "El volumen de cada contenedor debe ser finito y no negativo.");
                }

                if (agregadas.Add(parada))
                {
                    pendientes.Add(parada);
                    litrosPendientes.Add(parada, contenedor.NivelActualLitros);
                }
            }

            foreach (NodoGrafo parada in paradasSolicitadas)
            {
                AgregarParada(parada);
            }

            foreach (NodoGrafo nodo in grafo.Nodos)
            {
                if (nodo.Contenedor != null && nodo.Contenedor.PesoDinamico >= umbralUrgencia)
                {
                    AgregarParada(nodo);
                }
            }

            Lista<PasoPlanRecogida> pasos = new Lista<PasoPlanRecogida>();
            NodoGrafo nodoActual = acopio;
            NodoGrafo? paradaForzada = null;
            double cargaActual = vehiculo.NivelActualLitros;
            double distanciaTotal = 0;
            int numeroRecogidas = 0;
            int numeroDescargas = 0;

            void AcumularDistancia(double distancia)
            {
                distanciaTotal += distancia;
                if (!double.IsFinite(distanciaTotal))
                {
                    throw new InvalidOperationException("La distancia total del recorrido no es finita.");
                }
            }

            void VolverAlAcopio()
            {
                (IReadOnlyList<NodoGrafo> Ruta, double Coste) tramo = Dijkstra.CalcularRutaMasCorta(nodoActual, acopio);
                if (!double.IsFinite(tramo.Coste) || tramo.Ruta.Count == 0)
                {
                    throw new InvalidOperationException("No existe una ruta de regreso al acopio.");
                }

                AcumularDistancia(tramo.Coste);
                TipoPasoRecogida tipo = cargaActual > 0
                    ? TipoPasoRecogida.Descarga
                    : TipoPasoRecogida.RegresoAcopio;
                pasos.Add(new PasoPlanRecogida(tipo, acopio, tramo.Ruta, cargaActual, tramo.Coste));
                nodoActual = acopio;

                if (tipo == TipoPasoRecogida.Descarga)
                {
                    cargaActual = 0;
                    numeroDescargas++;
                }
            }

            (NodoGrafo Nodo, IReadOnlyList<NodoGrafo> Ruta, double Distancia) SeleccionarSiguiente()
            {
                if (paradaForzada is not null)
                {
                    (IReadOnlyList<NodoGrafo> Ruta, double Coste) tramoForzado = Dijkstra.CalcularRutaMasCorta(nodoActual, paradaForzada);
                    if (!double.IsFinite(tramoForzado.Coste) || tramoForzado.Ruta.Count == 0)
                    {
                        throw new InvalidOperationException("No existe una ruta hacia un contenedor que requiere varias recogidas.");
                    }

                    return (paradaForzada, tramoForzado.Ruta, tramoForzado.Coste);
                }

                NodoGrafo? siguiente = null;
                IReadOnlyList<NodoGrafo>? mejorRuta = null;
                double menorDistancia = double.PositiveInfinity;
                double mayorUrgencia = double.NegativeInfinity;

                foreach (NodoGrafo candidata in pendientes)
                {
                    (IReadOnlyList<NodoGrafo> Ruta, double Coste) resultado = Dijkstra.CalcularRutaMasCorta(nodoActual, candidata);
                    if (!double.IsFinite(resultado.Coste) || resultado.Ruta.Count == 0)
                    {
                        continue;
                    }

                    double urgencia = candidata.Contenedor?.PesoDinamico ?? 0;
                    if (resultado.Coste < menorDistancia
                        || (resultado.Coste == menorDistancia && urgencia > mayorUrgencia))
                    {
                        siguiente = candidata;
                        mejorRuta = resultado.Ruta;
                        menorDistancia = resultado.Coste;
                        mayorUrgencia = urgencia;
                    }
                }

                if (siguiente is null || mejorRuta is null)
                {
                    throw new InvalidOperationException("No existe una ruta hacia una o más paradas obligatorias o solicitadas.");
                }

                return (siguiente, mejorRuta, menorDistancia);
            }

            while (pendientes.Count > 0)
            {
                if (cargaActual >= vehiculo.CapacidadMaximaLitros)
                {
                    VolverAlAcopio();
                }

                (NodoGrafo Nodo, IReadOnlyList<NodoGrafo> Ruta, double Distancia) siguiente = SeleccionarSiguiente();
                double litrosRestantes = litrosPendientes[siguiente.Nodo];
                double capacidadDisponible = vehiculo.CapacidadMaximaLitros - cargaActual;
                double litrosRecogidos = Math.Min(litrosRestantes, capacidadDisponible);

                AcumularDistancia(siguiente.Distancia);
                pasos.Add(new PasoPlanRecogida(
                    TipoPasoRecogida.Recogida,
                    siguiente.Nodo,
                    siguiente.Ruta,
                    litrosRecogidos,
                    siguiente.Distancia));
                numeroRecogidas++;
                cargaActual = Math.Min(vehiculo.CapacidadMaximaLitros, cargaActual + litrosRecogidos);
                nodoActual = siguiente.Nodo;

                if (litrosRecogidos >= litrosRestantes)
                {
                    pendientes.Remove(siguiente.Nodo);
                    litrosPendientes.Remove(siguiente.Nodo);
                    paradaForzada = null;
                }
                else
                {
                    litrosPendientes[siguiente.Nodo] = litrosRestantes - litrosRecogidos;
                    paradaForzada = siguiente.Nodo;
                    VolverAlAcopio();
                }
            }

            if (!ReferenceEquals(nodoActual, acopio) || cargaActual > 0)
            {
                VolverAlAcopio();
            }

            double tiempoConduccionHoras = distanciaTotal / vehiculo.velocidadpromedio;
            double tiempoRecogidaHoras = numeroRecogidas * vehiculo.tiempopromedio / 60.0;
            double tiempoDescargaHoras = numeroDescargas * vehiculo.tiempodescarga / 60.0;

            return new ResultadoPlanRecogida(
                pasos,
                distanciaTotal,
                tiempoConduccionHoras,
                tiempoRecogidaHoras,
                tiempoDescargaHoras,
                vehiculo.CostoPorKilometro,
                vehiculo.CostoPorHora);
        }

        private static void ValidarVehiculo(Vehiculo vehiculo)
        {
            ValidarNoNegativoFinito(vehiculo.CapacidadMaximaLitros, nameof(vehiculo.CapacidadMaximaLitros));
            if (vehiculo.CapacidadMaximaLitros == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vehiculo.CapacidadMaximaLitros), "La capacidad máxima debe ser mayor que cero.");
            }

            ValidarNoNegativoFinito(vehiculo.NivelActualLitros, nameof(vehiculo.NivelActualLitros));
            if (vehiculo.NivelActualLitros > vehiculo.CapacidadMaximaLitros)
            {
                throw new ArgumentOutOfRangeException(nameof(vehiculo.NivelActualLitros), "La carga actual no puede superar la capacidad máxima.");
            }

            ValidarNoNegativoFinito(vehiculo.CostoPorKilometro, nameof(vehiculo.CostoPorKilometro));
            ValidarNoNegativoFinito(vehiculo.CostoPorHora, nameof(vehiculo.CostoPorHora));
            ValidarNoNegativoFinito(vehiculo.tiempopromedio, nameof(vehiculo.tiempopromedio));
            ValidarNoNegativoFinito(vehiculo.tiempodescarga, nameof(vehiculo.tiempodescarga));

            if (!double.IsFinite(vehiculo.velocidadpromedio) || vehiculo.velocidadpromedio <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vehiculo.velocidadpromedio), "La velocidad promedio debe ser finita y mayor que cero.");
            }
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
