using Facturacion.Domain.Aggregates;
using Facturacion.Domain.Enums;
using Facturacion.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Infrastructure.Persistence.EntitiesConfiguration
{
    class CfdiConfig : IEntityTypeConfiguration<Cfdi>
    {
        public void Configure(EntityTypeBuilder<Cfdi> builder)
        {
            builder.ToTable("Cfdi");
            builder.HasKey(m => m.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();
            builder.Property<Guid>("_clienteId").HasColumnName("ClienteId").ValueGeneratedNever();
            builder.Property(b => b.SucursalId).HasColumnName("SucursalId").ValueGeneratedNever();

            builder.Property<string>("_serie").HasColumnName("Serie").HasMaxLength(10);
            //builder.Property<int>("_folio").HasColumnName("Folio");
            builder.Property(m => m.Folio).HasColumnName("Folio");

            builder.Property<DateTime>("_fechaEmision").HasColumnName("FechaEmision");

            builder.Property<MetodoDePago>("_metodoDePago").HasColumnName("MetodoDePago");

            builder.Property<int>("_tasaIva").HasColumnName("TasaIva");
            builder.Property(b=>b.Subtotal).HasColumnName("Subtotal");
            builder.Property(b=>b.Iva).HasColumnName("Iva");
            builder.Property(b=>b.Total).HasColumnName("Total");

            builder.OwnsMany<Partida>("_partidas", b =>
            {
                b.ToTable("Partida");
                b.HasKey(m => m.Id);
                b.Property(b => b.Id).ValueGeneratedNever();
                b.Property<decimal>("_cantidad").HasColumnName("Cantidad");
                b.Property<decimal>("_valorUnitario").HasColumnName("ValorUnitario");
                b.Property<decimal>("_importe").HasColumnName("Importe");
                b.Property<string>("_descripcion").HasColumnName("Descripcion");
                //b.HasIndex("DocumentoId");
            });

            builder.HasIndex("_clienteId");
        }
    }
}
