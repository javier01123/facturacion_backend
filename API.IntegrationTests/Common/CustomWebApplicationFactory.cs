
using Facturacion.Application.Common.Contracts;
using Facturacion.Application.UseCases.Usuarios.Queries.ValidarCredenciales;
using Facturacion.Infrastructure.DataAccess;
using Facturacion.Infrastructure.Persistence.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;

namespace API.IntegrationTests.Common
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {

        public CustomWebApplicationFactory()
        {
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .ConfigureServices(services =>
                {
                    // quitar el registro del contexto de producción
                    var contextDescriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(DbContextOptions<FacturacionContext>));

                    if (contextDescriptor != null)
                        services.Remove(contextDescriptor);

                    //quitar el registro del dbconnection para los queries
                    var dbConectionDescriptor = services.SingleOrDefault(
                        d => d.ServiceType == typeof(ISqlConnectionFactory));

                    if (dbConectionDescriptor != null)
                        services.Remove(dbConectionDescriptor);


                    var configuration = ConfigurationHelper.GetTestConfiguration();
                    var _connectionString = configuration.GetConnectionString("TestDbConnection");

                    services.AddDbContext<FacturacionContext>(options =>
                   {
                       options.UseNpgsql(_connectionString, b => b.MigrationsAssembly("Facturacion.API"));
                   }); ;

                    services.AddScoped<ISqlConnectionFactory, SqlConnectionFactory>(
                        provider => new SqlConnectionFactory(_connectionString));

                    var sp = services.BuildServiceProvider();
                    var scope = sp.CreateScope();
                    var scopedServices = scope.ServiceProvider;
                    var context = scopedServices.GetRequiredService<FacturacionContext>() as FacturacionContext;
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    context.Database.EnsureDeleted();
                    context.Database.EnsureCreated();

                    try
                    {
                        //datos base para las pruebas
                        SeedData.InitializeDbForTests(context);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, $"error al inicializar la base de datos. Error: {ex.Message}");
                    }

                })
                .UseEnvironment("Test");
        }

        public HttpClient GetAnonymousClient()
        {
            return CreateClient();
        }

        internal HttpClient GetAuthenticatedClient()
        {
            var client = GetAnonymousClient();

            var command = new ValidarCredencialesCommand()
            {
                Email = "admin@noserver.com",
                Password = "mypass"
            };
            var content = Utilities.GetRequestContent(command);
            var task = client.PostAsync($"/api/usuarios/authenticate", content);
            var response = task.Result;
            response.EnsureSuccessStatusCode();
         
            return client;
        }

    }
}
