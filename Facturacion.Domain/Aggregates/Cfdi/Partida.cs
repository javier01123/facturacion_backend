using Facturacion.Domain.Guards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Domain.Aggregates
{
    public class Partida
    {
        private Guid _Id;
        private decimal _cantidad;
        private decimal _valorUnitario;
        private decimal _importe;
        private string _descripcion;

        #region properties

        public Guid Id => _Id;
        public decimal Importe => _importe;

        #endregion

        private Partida()
        {
        }

        internal Partida(Guid id, decimal cantidad, decimal valorUnitario, string descripcion)
        {
            Guard.GuidNotEmpty(id, nameof(id));
            Guard.StringNotEmpty(descripcion, nameof(descripcion));
            Guard.ValueMustBeGreaterThanZero(cantidad, nameof(cantidad));
            Guard.ValueMustBeGreaterThanZero(valorUnitario, nameof(valorUnitario));

            _Id = id;
            _cantidad = cantidad;
            _valorUnitario = valorUnitario;
            _descripcion = descripcion;

            CalcularImporte();
        }

        internal static Partida CrearPartida(Guid id, decimal cantidad, decimal valorUnitario, string descripcion)
        {
            return new Partida(id, cantidad, valorUnitario, descripcion);
        }

        internal void ModificarDatos(decimal cantidad, decimal valorUnitario, string descripcion)
        { 
            Guard.StringNotEmpty(descripcion, nameof(descripcion));
            Guard.ValueMustBeGreaterThanZero(cantidad, nameof(cantidad));
            Guard.ValueMustBeGreaterThanZero(valorUnitario, nameof(valorUnitario));

            _cantidad = cantidad;
            _valorUnitario = valorUnitario;
            _descripcion = descripcion;
            CalcularImporte();
        }


        private void CalcularImporte()
        {
            _importe = Math.Round(_cantidad * _valorUnitario, 2);
        }
    }
}
