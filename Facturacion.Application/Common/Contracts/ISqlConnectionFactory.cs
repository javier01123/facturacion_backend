using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Facturacion.Application.Common.Contracts
{
    public interface ISqlConnectionFactory
    {
        IDbConnection GetOpenConnection();
    }
}
