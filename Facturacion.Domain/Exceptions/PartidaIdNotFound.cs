using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Domain.Exceptions
{
    public class PartidaIdNotFound: DomainException
    {
        internal PartidaIdNotFound(string partidaId) : base($"Partida con Id \"{partidaId}\" no encontrada")
        {
        }
    }
}
