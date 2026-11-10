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
    }
}
