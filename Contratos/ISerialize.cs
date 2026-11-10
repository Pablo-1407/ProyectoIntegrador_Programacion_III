using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Contratos
{
    internal interface ISerialize<T>
    {
        static abstract string Serialize(T obj);
        static abstract T Deserialize(string textCsv);
    }
}
