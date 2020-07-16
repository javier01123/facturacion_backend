using Facturacion.Domain.Aggregates;
using Facturacion.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Infrastructure.Persistence.EntitiesConfiguration
{
    public class SucursalConfig : IEntityTypeConfiguration<Sucursal>
    {
        public void Configure(EntityTypeBuilder<Sucursal> builder)
        {
            builder.ToTable("Sucursal");
            builder.HasKey(m => m.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();
            builder.Property("_empresaId").HasColumnName("EmpresaId");
          
            builder.Property<string>("_nombre")
                .HasMaxLength(50)
                .HasColumnName("Nombre");
  
            builder.OwnsOne<Domicilio>("_domicilio", b =>
            {
                b.ToTable("SucursalDomicilio");
                b.Property("_pais").HasMaxLength(25).HasColumnName("Pais");
                b.Property("_estado").HasMaxLength(25).HasColumnName("Estado");
                b.Property("_ciudad").HasMaxLength(25).HasColumnName("Ciudad");
                b.Property("_municipio").HasMaxLength(25).HasColumnName("Municipio");
                b.Property("_colonia").HasMaxLength(50).HasColumnName("Colonia");
                b.Property("_codigoPostal").HasMaxLength(10).HasColumnName("CodigoPostal");
                b.Property("_calle").HasMaxLength(50).HasColumnName("Calle");
                b.Property("_numeroInterior").HasMaxLength(10).HasColumnName("NumeroInterior");
                b.Property("_numeroExterior").HasMaxLength(10).HasColumnName("NumeroExterior");
                b.HasIndex("SucursalId").HasName("IX_SucursalId").IsUnique();
            });

            builder.HasIndex("_empresaId");
        }
    }
}
