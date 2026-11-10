using RutaCampus.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Domain
{
    internal class Punto: IDentity<int>
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public (double x, double y) Coordenadas { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Nombre: {Nombre}, Coordenadas: ({Coordenadas.x}, {Coordenadas.y})";
        }
    }
}
