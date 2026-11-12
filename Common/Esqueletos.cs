using RutaCampus.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Common
{
    internal class Esqueletos
    {
        public static Lista<CampoMetadata> ObtenerEsqueletoVehiculo()
        {
            return new Lista<CampoMetadata>
            {
                new CampoMetadata { NombrePropiedad = "Id", Etiqueta = "Placa del Vehículo", Tipo = TipoControl.Texto },
                new CampoMetadata { NombrePropiedad = "CapacidadMaximaLitros", Etiqueta = "Capacidad Máxima (L)", Tipo = TipoControl.Decimal },
                new CampoMetadata { NombrePropiedad = "NivelActualLitros", Etiqueta = "Nivel Actual (L)", Tipo = TipoControl.Decimal },
                new CampoMetadata { NombrePropiedad = "CostoPorKilometro", Etiqueta = "Costo por Kilómetro", Tipo = TipoControl.Decimal },
                new CampoMetadata { NombrePropiedad = "CostoPorHora", Etiqueta = "Costo por Hora", Tipo = TipoControl.Decimal },
                new CampoMetadata { NombrePropiedad = "tiempopromedio", Etiqueta = "Tiempo Prom. Recolección (min)", Tipo = TipoControl.Decimal },
                new CampoMetadata { NombrePropiedad = "tiempodescarga", Etiqueta = "Tiempo Prom. Descarga (min)", Tipo = TipoControl.Decimal },
                new CampoMetadata { NombrePropiedad = "velocidadpromedio", Etiqueta = "Velocidad Promedio (km/h)", Tipo = TipoControl.Decimal }
            };
        }

        public static Lista<CampoMetadata> ObtenerEsqueletoContenedor()
        {
            return new Lista<CampoMetadata>
            {
                new CampoMetadata { NombrePropiedad = "Id", Etiqueta = "ID del Contenedor", Tipo = TipoControl.Numero },
                new CampoMetadata { NombrePropiedad = "Nombre", Etiqueta = "Nombre / Ubicación", Tipo = TipoControl.Texto },
                new CampoMetadata { NombrePropiedad = "CoordenadaX", Etiqueta = "Coordenada X", Tipo = TipoControl.Decimal },
                new CampoMetadata { NombrePropiedad = "CoordenadaY", Etiqueta = "Coordenada Y", Tipo = TipoControl.Decimal },
                new CampoMetadata {
                    NombrePropiedad = "TipoResiduo",
                    Etiqueta = "Tipo de Residuo",
                    Tipo = TipoControl.Desplegable,
                    Opciones = Enum.GetNames(typeof(TipoResiduo))
                },
                new CampoMetadata { NombrePropiedad = "CapacidadLitros", Etiqueta = "Capacidad Máxima (L)", Tipo = TipoControl.Decimal },
                new CampoMetadata { NombrePropiedad = "NivelActualLitros", Etiqueta = "Nivel Actual (L)", Tipo = TipoControl.Decimal },
                new CampoMetadata { NombrePropiedad = "FechaUltimaRecoleccion", Etiqueta = "Última Recolección", Tipo = TipoControl.Fecha },
                new CampoMetadata { NombrePropiedad = "LitrosGeneradosPorDia", Etiqueta = "Litros Generados por Día", Tipo = TipoControl.Decimal }
            };
        }

        public static Lista<CampoMetadata> ObtenerEsqueletoAcopio()
        {
            return new Lista<CampoMetadata>
            {
                new CampoMetadata { NombrePropiedad = "Id", Etiqueta = "ID del Acopio", Tipo = TipoControl.Numero},
                new CampoMetadata { NombrePropiedad = "Nombre", Etiqueta = "Nombre del Acopio", Tipo = TipoControl.Texto },
            };
        }

        public static List<CampoMetadata> ObtenerEsqueletoConexion()
        {
            return new List<CampoMetadata>
            {
                new CampoMetadata { NombrePropiedad = "Id", Etiqueta = "ID de la Conexión", Tipo = TipoControl.Numero },
                new CampoMetadata { NombrePropiedad = "NodoOrigenId", Etiqueta = "ID Nodo Origen", Tipo = TipoControl.Numero },
                new CampoMetadata { NombrePropiedad = "NodoDestinoId", Etiqueta = "ID Nodo Destino", Tipo = TipoControl.Numero },
                new CampoMetadata { NombrePropiedad = "DistanciaKilometros", Etiqueta = "Distancia (Km)", Tipo = TipoControl.Decimal },
                new CampoMetadata {
                    NombrePropiedad = "EsBidireccional",
                    Etiqueta = "¿Es Doble Vía?",
                    Tipo = TipoControl.Desplegable,
                    Opciones = new[] { "True", "False" }
                    }
            };
        }

        public static Lista<CampoMetadata> ObtenerEsqueletoUsuario()
        {
            return new Lista<CampoMetadata>
            {
                new CampoMetadata { NombrePropiedad = "Id", Etiqueta = "ID del Usuario", Tipo = TipoControl.Numero},
                new CampoMetadata { NombrePropiedad = "Nombre", Etiqueta = "Nombre del Usuario", Tipo = TipoControl.Texto },
                new CampoMetadata { NombrePropiedad = "Rol", Etiqueta = "Rol del Usuario", Tipo = TipoControl.Desplegable, Opciones = Enum.GetNames(typeof(Roles)) },
            };
        }
    }
}
