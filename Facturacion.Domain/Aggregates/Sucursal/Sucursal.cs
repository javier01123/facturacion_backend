using Facturacion.Domain.Exceptions;
using Facturacion.Domain.Guards;
using Facturacion.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Domain.Aggregates
{
    public class Sucursal
    {
        private Guid _id;
        private Guid _empresaId;
        private string _nombre;
        private Domicilio _domicilio;

        #region properties
        public Guid Id => _id;
        public Guid EmpresaId => _empresaId;
        #endregion
        private Sucursal()
        {
        }

        private Sucursal(Guid id, Guid empresaId, string nombre)
        {
            Guard.GuidNotEmpty(id, nameof(id));
            Guard.GuidNotEmpty(empresaId, nameof(empresaId));
            Guard.StringNotEmpty(nombre, nameof(nombre));

            _id = id;
            _empresaId = empresaId;
            _nombre = nombre;
        }

        public static Sucursal Create(Guid id, Guid empresaId, string nombre)
        {
            return new Sucursal(id, empresaId, nombre);
        }

        public void CambiarNombre(string nuevoNombre)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre))
                throw new GenericDomainException("el nombre de la sucursal es obligatorio");

            _nombre = nuevoNombre.Trim();
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
