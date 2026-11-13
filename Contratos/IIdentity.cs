using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Contratos
{
    internal interface IIdentity<TId>
    {
        TId Id { get;set; }
    }
}
