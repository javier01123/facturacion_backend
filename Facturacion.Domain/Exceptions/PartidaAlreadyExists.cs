using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Domain.Exceptions
{
    public class PartidaAlreadyExists: DomainException
    {
        internal PartidaAlreadyExists(string partidaId) : base($"Partida con Id \"{partidaId}\" ya existe, no se puede duplicar.")
        {
        }
    }
}
