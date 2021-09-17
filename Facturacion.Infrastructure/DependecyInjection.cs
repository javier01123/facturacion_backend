
using Facturacion.Application.Common.Contracts;
using Facturacion.Infrastructure.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Facturacion.Application.Common.Contracts.Hashing;
using Facturacion.Infrastructure.Hashing;
using Facturacion.Application.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Facturacion.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext<FacturacionContext>(options =>
            {
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Facturacion.API"));
                //options.ReplaceService<IValueConverterSelector, RfcValueConverterSelector>();
                //HAY UNO ESPECIAL PARA POSTGRES
            }); ;

            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>(provider => new SqlConnectionFactory(connectionString));
            //services.AddScoped<FacturacionContext, FacturacionContext>(provider => new FacturacionContext(connectionString));
            services.AddTransient<IPasswordHasher, PasswordHasher>(); ;            
            return services;
        }
    }
}
