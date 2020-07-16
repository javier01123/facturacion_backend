using Facturacion.Domain.Aggregates;
using Facturacion.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Facturacion.Infrastructure.Persistence.EntitiesConfiguration
{
    public class UsuarioUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey("_id");            
            builder.Property("_id").HasColumnName("Id").ValueGeneratedNever();
            builder.Property("_password").HasMaxLength(20).HasColumnName("Password");

            builder.OwnsOne<Email>("_email", b =>
            {
                b.Property("_value").HasMaxLength(30).HasColumnName("Email");
            });
        }
    }
}
