using Facturacion.Domain.Aggregates;
using Facturacion.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Infrastructure.Persistence.EntitiesConfiguration
{
    class EmpresaConfig : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(m => m.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();
          
            builder.Property<string>("_razonSocial")
                .HasMaxLength(100)
                .HasColumnName("RazonSocial");
            
            builder.Property<string>("_nombreComercial")
                .HasMaxLength(100)
                .HasColumnName("NombreComercial");

            builder
             .Property(b => b.Rfc)
             .HasColumnName("Rfc")
             .HasMaxLength(13)
             .HasConversion(v => v.Value, v => new Rfc(v));

            builder.HasIndex(b => b.Rfc).IsUnique();

        }
    }
}