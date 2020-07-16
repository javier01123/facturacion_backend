using Facturacion.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Common.Contracts.Repositories
{
    public interface ISucursalRepository
    {
        Task<Sucursal> FindById(Guid id);
        void AddSucursal(Sucursal sucursal);
        void UpdateSucursal(Sucursal sucursal);
        Task<int> GetSiguienteFolioDisponible(Guid sucursalId);

    }
}
