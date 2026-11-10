using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Contratos
{
    internal interface IFactory<T>
    {
        static abstract T Create();
        static abstract T Create(string textCsv);

    }
}
