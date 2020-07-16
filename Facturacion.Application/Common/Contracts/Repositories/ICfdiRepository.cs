using Facturacion.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Facturacion.Application.Common.Contracts.Repositories
{
    public interface ICfdiRepository
    {
         Task<Cfdi> GetById(Guid id);
          Task AddCfdi(Cfdi cfdi);
        void UpdateCfdi(Cfdi cfdi);
       
          
    }
}
