using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Contratos
{
    internal interface IUnidOfWork
    {
        void commit();
    }
}
