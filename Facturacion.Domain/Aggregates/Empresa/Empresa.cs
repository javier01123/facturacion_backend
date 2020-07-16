using Facturacion.Domain.Exceptions;
using Facturacion.Domain.Guards;
using Facturacion.Domain.ValueObjects;
using System;

namespace Facturacion.Domain.Aggregates
{
    public class Empresa
    {
        private Guid _id;
        private string _razonSocial;
        private string _nombreComercial;
        private Rfc _rfc;

        private Empresa()
        {
            //para EF
        }
        private Empresa(Guid id, string rfc, string razonSocial, string nombreComercial)
        {
            Guard.GuidNotEmpty(id, nameof(id));
            Guard.StringNotEmpty(razonSocial, nameof(razonSocial));
            Guard.StringNotEmpty(nombreComercial, nameof(nombreComercial));

            _id = id;
            _razonSocial = razonSocial;
            _nombreComercial = nombreComercial;
            _rfc = Rfc.For(rfc);
        }
        public Guid Id { get => _id; }
        public Rfc Rfc { get => _rfc; }
        public static Empresa Create(Guid id, string rfc, string razonSocial, string nombreComercial)
        {
            return new Empresa(id, rfc, razonSocial, nombreComercial);
        }
        public void CorregirRfc(string rfc)
        {
            _rfc = Rfc.For(rfc);
        }
        public void ActualizarRazonSocial(string razonSocial)
        {
            Guard.StringNotEmpty(razonSocial, nameof(razonSocial));
            _razonSocial = razonSocial;
        }

        public void ActualizarNombreComercial(string nombreComercial)
        {
            Guard.StringNotEmpty(nombreComercial, nameof(nombreComercial));
            _nombreComercial = nombreComercial;
        }



    }
}
