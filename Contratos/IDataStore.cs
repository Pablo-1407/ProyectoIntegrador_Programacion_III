using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Contratos
{
    internal interface IDataStore<T>
    {
        IEnumerable<T> LoadAll();
        void SaveAll(IEnumerable<T> DoubleLinkList);
    }
}
