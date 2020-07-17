
using Facturacion.Application.Common.Contracts;
using Facturacion.Domain.Aggregates;
using Facturacion.Infrastructure.DataAccess;
using Facturacion.Infrastructure.Persistence.Context;
using Facturacion.Infrastructure.Persistence.UnitOfWork;
using Facturacion.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Facturacion.Application.Common.Contracts.Repositories;
using Facturacion.Application.Common.Contracts.Hashing;
using Facturacion.Infrastructure.Hashing;

namespace Facturacion.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {

            services.AddDbContext< FacturacionContext>(options =>
            {
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Facturacion.API"));
                //options.ReplaceService<IValueConverterSelector, RfcValueConverterSelector>();
                //HAY UNO ESPECIAL PARA POSTGRES
            }); ;

            services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>(provider => new SqlConnectionFactory(connectionString));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IEmpresaRepository, EmpresaRepository>();
            services.AddTransient<ISucursalRepository, SucursalRepository>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ICfdiRepository, CfdiRepository>();

            services.AddTransient<IPasswordHasher, PasswordHasher>(); ;
            

            return services;
        }
    }
}
