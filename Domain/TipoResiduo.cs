using System;
using System.Collections.Generic;
using System.Text;

namespace RutaCampus.Domain
{
    public enum TipoResiduo: byte
    {
        Orgánico = (byte)'O',
        Reciclable = (byte)'R',
        Peligroso = (byte)'P',
        General = (byte)'G'
    }
}
