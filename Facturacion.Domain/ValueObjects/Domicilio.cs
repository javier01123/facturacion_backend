using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Facturacion.Domain.ValueObjects
{
    public class Domicilio : ValueObject
    {
        //private Guid _id;
        private string _pais, _estado, _ciudad, _municipio, _colonia, _codigoPostal, _calle, _numeroInterior, _numeroExterior;

        private Domicilio()
        {
            //para EF
        }

        private Domicilio(
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
            _pais = pais;
            _estado = estado;
            _ciudad = ciudad;
            _municipio = municipio;
            _colonia = colonia;
            _codigoPostal = codigoPostal;
            _calle = calle;
            _numeroExterior = numeroExterior;
            _numeroInterior = numeroInterior;

        }
 

        public static Domicilio Create(
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
            return new Domicilio(pais, estado, ciudad, municipio, colonia, codigoPostal, calle, numeroInterior, numeroExterior);
        }
        
    }
}
