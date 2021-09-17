using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Facturacion.API
{
    public class ConnectionStringProvider
    {
        private readonly IConfiguration _configuration;
 
        public ConnectionStringProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        private string GetConnectionFromConfig()
        {
            return _configuration.GetConnectionString("FacturacionDb");
           // return GetConnectionFromHeroku();
        }

        private string GetConnectionFromHeroku()
        {
            var databaseUrl = Environment.GetEnvironmentVariable("DATABASE_URL");
            var databaseUri = new Uri(databaseUrl);
            var userInfo = databaseUri.UserInfo.Split(':');

            var builder = new NpgsqlConnectionStringBuilder
            {
                Host = databaseUri.Host,
                Port = databaseUri.Port,
                Username = userInfo[0],
                Password = userInfo[1],
                Database = databaseUri.LocalPath.TrimStart('/'),
                SslMode= SslMode.Require,
                TrustServerCertificate=true,
            };

            return builder.ToString();
        }



        public string GetConnectionString(bool isHeroku)
        {
            if (isHeroku)
                return GetConnectionFromHeroku();
            else
                return GetConnectionFromConfig();

        }
    }
}
