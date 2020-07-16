
using Facturacion.Domain.Aggregates;
using Facturacion.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Infrastructure.Persistence.EntitiesConfiguration
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property<string>("_razonSocial").HasMaxLength(50).HasColumnName("RazonSocial");
            builder.Property<Guid>("_empresaId").HasColumnName("EmpresaId");

            builder.OwnsOne<Rfc>("_rfc", b =>
            {
                b.Property(p => p.Value).HasMaxLength(13).HasColumnName("Rfc");
            });

            builder.OwnsOne<Domicilio>("_domicilio", b =>
            {
                b.ToTable("ClienteDomicilio");
                b.Property("_pais").HasMaxLength(25).HasColumnName("Pais");
                b.Property("_estado").HasMaxLength(25).HasColumnName("Estado");
                b.Property("_ciudad").HasMaxLength(25).HasColumnName("Ciudad");
                b.Property("_municipio").HasMaxLength(25).HasColumnName("Municipio");
                b.Property("_colonia").HasMaxLength(50).HasColumnName("Colonia");
                b.Property("_codigoPostal").HasMaxLength(10).HasColumnName("CodigoPostal");
                b.Property("_calle").HasMaxLength(50).HasColumnName("Calle");
                b.Property("_numeroInterior").HasMaxLength(10).HasColumnName("NumeroInterior");
                b.Property("_numeroExterior").HasMaxLength(10).HasColumnName("NumeroExterior");
                b.HasIndex("ClienteId").IsUnique();
            });

            builder.HasIndex("_empresaId");
            //builder.HasIndex("_rfc");
        }
    }
}
