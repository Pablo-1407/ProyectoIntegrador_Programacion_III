using RutaCampus.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Domain
{
    internal sealed class Acopio : Punto, IFactory<Acopio>, ISerialize<Acopio>
    {
        private Acopio()
        {
            Id = 0;
            Nombre = string.Empty;
            Coordenadas = new Point(0, 0);
        }
        public static Acopio Create()
        {
            return new Acopio();
        }

        public static Acopio Create(string textCsv)
        {
            return Deserialize(textCsv);
        }

        //point para coordenadas
        //int
        public static Acopio Deserialize(string textCsv)
        {
            string[] parts = textCsv.Split(',');
            if (parts.Length != 4)
            {
                throw new ArgumentException("El texto CSV no tiene el formato correcto.");
            }

            int id = int.Parse(parts[0]);
            string nombre = parts[1];
            int x = int.Parse(parts[2]);
            int y = int.Parse(parts[3]);

            return new Acopio
            {
                Id = id,
                Nombre = nombre,
                Coordenadas = new Point((int)x, (int)y)
            };
        }

        public static string Serialize(Acopio obj)
        {
            return $"{obj.Id},{obj.Nombre},{obj.Coordenadas.X},{obj.Coordenadas.Y}";
        }
    }
}
