﻿using Facturacion.Domain.Enums;
using Facturacion.Domain.Exceptions;
using Facturacion.Domain.Guards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Facturacion.Domain.Aggregates
{
    public class Cfdi
    {
        private Guid _id;
        private Guid _sucursalId;
        private Guid _clienteId;

        private DateTime _fechaEmision;


        private List<Partida> _partidas;

        private int _folio;
        private string _serie;
        private decimal _tasaIva;
        private decimal _subtotal;
        private decimal _iva;
        private decimal _total;

        private MetodoDePago _metodoDePago;

        #region getters
        public Guid Id { get => _id; }
        public Guid SucursalId { get => _sucursalId; }
        public int Folio { get => _folio; }
        public decimal Subtotal { get => _subtotal; }
        public decimal Iva { get => _iva; }
        public decimal Total { get => _total; }
        public ReadOnlyCollection<Partida> Partidas { get => _partidas.AsReadOnly(); }

        #endregion

        private Cfdi()
        {
        }

        private Cfdi(Guid id, Guid clienteId, Guid sucursalId, DateTime fechaEmision, string serie, int folio)
        {
            Guard.GuidNotEmpty(id, nameof(id));
            Guard.GuidNotEmpty(clienteId, nameof(clienteId));
            Guard.GuidNotEmpty(sucursalId, nameof(sucursalId));
            Guard.StringNotEmpty(serie, nameof(serie));
            Guard.ValueMustBeGreaterThanZero(folio, nameof(folio));

            _id = id;
            _clienteId = clienteId;
            _sucursalId = sucursalId;
            _fechaEmision = fechaEmision;
            _serie = serie;
            _folio = folio;
            _partidas = new List<Partida>();
        }

        public static Cfdi Create(Guid id, Guid clienteId, Guid sucursalId, DateTime fechaEmision, string serie, int folio)
        {
            return new Cfdi(id, clienteId, sucursalId, fechaEmision, serie, folio);
        }

        public void CambiarFechaEmision(DateTime nuevaFechaEmision)
        {
            _fechaEmision = nuevaFechaEmision;
        }
        public void CambiarCliente(Guid nuevoClienteId)
        {
            Guard.GuidNotEmpty(nuevoClienteId, nameof(nuevoClienteId));

            _clienteId = nuevoClienteId;
        }

        public void CambiarMetodoDePago(MetodoDePago metodoDePago)
        {
            _metodoDePago = metodoDePago;
        }

        public void AgregarPartida(Guid id, decimal cantidad, decimal valorUnitario, string descripcion)
        {
            var partida = _partidas.Where(m => m.Id == id).FirstOrDefault();

            if (partida != null)
                throw new PartidaAlreadyExists(id.ToString());

            partida = Partida.CrearPartida(id, cantidad, valorUnitario, descripcion);
            _partidas.Add(partida);
            Recalcular();
        }

        public void ModificarPartida(Guid id, decimal cantidad, decimal valorUnitario, string descripcion)
        {
            var partida = _partidas.Where(m => m.Id == id).FirstOrDefault();

            if (partida == null)
                throw new PartidaIdNotFound(id.ToString());

            partida.ModificarDatos(cantidad, valorUnitario, descripcion);
            Recalcular();
        }

        public void EliminarPartida(Guid id)
        {
            var partida = _partidas.Where(m => m.Id == id).FirstOrDefault();

            if (partida == null)
                throw new PartidaIdNotFound(id.ToString());

            _partidas.Remove(partida);
            Recalcular();
        }

        public void AsignarTasaIva(decimal tasaIva)
        {
            Guard.ValueCannotBeNegative(tasaIva, nameof(tasaIva));
            _tasaIva = tasaIva;
            Recalcular();
        }

        private void Recalcular()
        {
            _subtotal = Math.Round(_partidas.Sum(m => m.Importe), 2);
            _iva = Math.Round(_subtotal * (_tasaIva / 100m), 2);
            _total = _subtotal + _iva;
        }

        public void EliminarPartidas()
        {
            _partidas.Clear();
        }
    }
}
