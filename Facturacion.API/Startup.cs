using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facturacion.Application.UseCases.Empresas.AltaEmpresa;
using Facturacion.Infrastructure.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Reflection;
using Facturacion.Application;
using Facturacion.Infrastructure;
using Facturacion.API.auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Facturacion.API.Config;
using Facturacion.API.Middleware;

namespace Facturacion.API
{
    public class Startup
    {
        private string _connectionString;
        public IConfiguration Configuration { get; }

        private readonly bool _isHeroku;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _isHeroku = !string.IsNullOrWhiteSpace(Environment.GetEnvironmentVariable("IS_HEROKU"));
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connProvider = new ConnectionStringProvider(Configuration);
            _connectionString = connProvider.GetConnectionString(_isHeroku);

            services.AddApplication();
            services.AddInfrastructure(_connectionString);

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddControllers();
            services.AddMvc()
            .AddHybridModelBinder();

            services.AddSwaggerGen(options =>
            {
                options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
                options.CustomSchemaIds(x => x.FullName);
            });

            services.AddAuthentication("Basic")
               .AddScheme<AuthenticationSchemeOptions, JwtAuthenticationHandler>("Basic", null);
            services.AddAuthorization();

            var jwtSecret = Configuration.GetSection("APP_SETTINGS:JwtSecret");
            services.Configure<AppSettings>(options => Configuration.GetSection("APP_SETTINGS").Bind(options));

            JwtManager._secret = jwtSecret.Value;

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, FacturacionContext context)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //no me permite withCredentials:true del lado del cliente.
            //.AllowAnyOrigin()
            string origin = "http://localhost:3000";

            if (env.IsProduction())
            {
                origin = "https://facturacion-frontend-dev.herokuapp.com";
                context.Database.Migrate();
            }


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Facturacion API");
                c.RoutePrefix = string.Empty;
            });

            app.UseCors(options => options
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials()
            .WithOrigins(origin, "10.0.0.21", "10.0.0.21:5000"));

            //.WithOrigins(origin));

            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
