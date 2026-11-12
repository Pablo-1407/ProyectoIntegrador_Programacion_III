using RutaCampus.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Domain
{
    internal class Usuario : IDentity<long>, IFactory<Usuario>, ISerialize<Usuario>
    {
        public long Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public Roles Rol { get; set; }
        public string Contraseña { get; set; } = string.Empty;

 

        public static Usuario Create()
        {
            return new Usuario();
        }

        public static Usuario Create(string textCsv)
        {
            return Deserialize(textCsv);
        }

        public static Usuario Deserialize(string textCsv)
        {
            string[] parts = textCsv.Split(',');
            return new Usuario
            {
                Id = long.Parse(parts[0]),
                Nombre = parts[1],
                Rol = (Roles)Enum.Parse(typeof(Roles), parts[2]),
                Contraseña = parts[3]
            };
        }

        public static string Serialize(Usuario obj)
        {
            return $"{obj.Id},{obj.Nombre},{obj.Rol},{obj.Contraseña}";
        }
    }
}
