using Facturacion.Domain.Exceptions;
using Facturacion.Domain.Guards;
using Facturacion.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Domain.Aggregates
{
    public class Cliente
    {
        private Guid _id;
        private Guid _empresaId;
        private string _razonSocial;
        private Rfc _rfc;
        private Domicilio _domicilio;

        #region properties
        public Guid Id { get => _id; }
        public Guid EmpresaId { get => _empresaId; }
        #endregion

        private Cliente()
        {
            //para EF
        }
        private Cliente(Guid id, Guid empresaId, string rfc, string razonSocial)
        {
            Guard.GuidNotEmpty(id,nameof(id));
            Guard.GuidNotEmpty(empresaId,nameof(id));
            Guard.StringNotEmpty(razonSocial,nameof(razonSocial));

            _id = id;
            _empresaId = empresaId;
            _razonSocial = razonSocial;
            _rfc = Rfc.For(rfc);
        }

        public static Cliente Create(Guid id, Guid empresaId, string rfc, string razonSocial)
        {
            return new Cliente(id, empresaId, rfc, razonSocial);
        }

        public void CorregirRfc(string rfc)
        {
            _rfc = Rfc.For(rfc);
        }

        public void CambiarRazonSocial(string razonSocial)
        {
            if (string.IsNullOrWhiteSpace(razonSocial))
                throw new GenericDomainException("la razón social es obligatoria.");

            _razonSocial = razonSocial.Trim();
        }


        public void ActualizarDomicilio(
         string pais,
         string estado,
         string ciudad,
         string municipio,
         string colonia,
         string codigoPostal,
         string calle,
         string numeroInterior,
         string numeroExterior)
        {
            _domicilio = Domicilio.Create(pais, estado, ciudad, municipio, colonia, codigoPostal, calle, numeroInterior, numeroExterior);
        }

    }
}

