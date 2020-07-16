using Facturacion.Domain.Aggregates;
using Facturacion.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Common.Contracts.Repositories
{
    public interface IEmpresaRepository
    {
        Task<Empresa> FindById(Guid guid);
        Task<Empresa> FindByRfc(Rfc rfc);
        void AddEmpresa(Empresa empresa);
        void UpdateEmpresa(Empresa empresa);        
        Task<bool> TieneDocumentosTimbrados(Guid empresaId);
    }
}
