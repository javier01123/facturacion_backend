
using Facturacion.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Facturacion.Application.Persistence.Context
{
    public class FacturacionContext : DbContext
    { 
        public FacturacionContext(DbContextOptions<FacturacionContext> options) : base(options)
        {
 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FacturacionContext).Assembly);

            //modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);

            //poner todos los campos a presicion 18,6 
            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //        .SelectMany(t => t.GetProperties())
            //        .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            //{
            //    property.Relational().ColumnType = "decimal(18, 6)";
            //}
        }


        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Cfdi> Documento { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cfdi> Cfdi { get; set; }

    }
}
