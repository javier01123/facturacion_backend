﻿// <auto-generated />
using System;
using Facturacion.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Facturacion.API.Migrations
{
    [DbContext(typeof(FacturacionContext))]
    partial class FacturacionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Facturacion.Domain.Aggregates.Cfdi", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<int>("Folio")
                        .HasColumnName("Folio")
                        .HasColumnType("integer");

                    b.Property<Guid>("SucursalId")
                        .HasColumnName("SucursalId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("_clienteId")
                        .HasColumnName("ClienteId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("_fechaEmision")
                        .HasColumnName("FechaEmision")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("_iva")
                        .HasColumnName("Iva")
                        .HasColumnType("numeric");

                    b.Property<int>("_metodoDePago")
                        .HasColumnName("MetodoDePago")
                        .HasColumnType("integer");

                    b.Property<string>("_serie")
                        .HasColumnName("Serie")
                        .HasColumnType("character varying(10)")
                        .HasMaxLength(10);

                    b.Property<decimal>("_subtotal")
                        .HasColumnName("Subtotal")
                        .HasColumnType("numeric");

                    b.Property<int>("_tasaIva")
                        .HasColumnName("TasaIva")
                        .HasColumnType("integer");

                    b.Property<decimal>("_total")
                        .HasColumnName("Total")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("_clienteId");

                    b.ToTable("Cfdi");
                });

            modelBuilder.Entity("Facturacion.Domain.Aggregates.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("_empresaId")
                        .HasColumnName("EmpresaId")
                        .HasColumnType("uuid");

                    b.Property<string>("_razonSocial")
                        .HasColumnName("RazonSocial")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("_empresaId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Facturacion.Domain.Aggregates.Empresa", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Rfc")
                        .HasColumnName("Rfc")
                        .HasColumnType("character varying(13)")
                        .HasMaxLength(13);

                    b.Property<string>("_nombreComercial")
                        .HasColumnName("NombreComercial")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.Property<string>("_razonSocial")
                        .HasColumnName("RazonSocial")
                        .HasColumnType("character varying(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Rfc")
                        .IsUnique();

                    b.ToTable("Empresa");
                });

            modelBuilder.Entity("Facturacion.Domain.Aggregates.Sucursal", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("_empresaId")
                        .HasColumnName("EmpresaId")
                        .HasColumnType("uuid");

                    b.Property<string>("_nombre")
                        .HasColumnName("Nombre")
                        .HasColumnType("character varying(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("_empresaId");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("Facturacion.Domain.Aggregates.Usuario", b =>
                {
                    b.Property<Guid>("_id")
                        .HasColumnName("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("_password")
                        .HasColumnName("Password")
                        .HasColumnType("character varying(20)")
                        .HasMaxLength(20);

                    b.HasKey("_id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Facturacion.Domain.Aggregates.Cfdi", b =>
                {
                    b.OwnsMany("Facturacion.Domain.Aggregates.Partida", "_partidas", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid");

                            b1.Property<Guid>("CfdiId")
                                .HasColumnType("uuid");

                            b1.Property<decimal>("_cantidad")
                                .HasColumnName("Cantidad")
                                .HasColumnType("numeric");

                            b1.Property<string>("_descripcion")
                                .HasColumnName("Descripcion")
                                .HasColumnType("text");

                            b1.Property<decimal>("_importe")
                                .HasColumnName("Importe")
                                .HasColumnType("numeric");

                            b1.Property<decimal>("_valorUnitario")
                                .HasColumnName("ValorUnitario")
                                .HasColumnType("numeric");

                            b1.HasKey("Id");

                            b1.HasIndex("CfdiId");

                            b1.ToTable("Partida");

                            b1.WithOwner()
                                .HasForeignKey("CfdiId");
                        });
                });

            modelBuilder.Entity("Facturacion.Domain.Aggregates.Cliente", b =>
                {
                    b.OwnsOne("Facturacion.Domain.ValueObjects.Domicilio", "_domicilio", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("uuid");

                            b1.Property<string>("_calle")
                                .HasColumnName("Calle")
                                .HasColumnType("character varying(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("_ciudad")
                                .HasColumnName("Ciudad")
                                .HasColumnType("character varying(25)")
                                .HasMaxLength(25);

                            b1.Property<string>("_codigoPostal")
                                .HasColumnName("CodigoPostal")
                                .HasColumnType("character varying(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("_colonia")
                                .HasColumnName("Colonia")
                                .HasColumnType("character varying(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("_estado")
                                .HasColumnName("Estado")
                                .HasColumnType("character varying(25)")
                                .HasMaxLength(25);

                            b1.Property<string>("_municipio")
                                .HasColumnName("Municipio")
                                .HasColumnType("character varying(25)")
                                .HasMaxLength(25);

                            b1.Property<string>("_numeroExterior")
                                .HasColumnName("NumeroExterior")
                                .HasColumnType("character varying(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("_numeroInterior")
                                .HasColumnName("NumeroInterior")
                                .HasColumnType("character varying(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("_pais")
                                .HasColumnName("Pais")
                                .HasColumnType("character varying(25)")
                                .HasMaxLength(25);

                            b1.HasKey("ClienteId");

                            b1.HasIndex("ClienteId")
                                .IsUnique();

                            b1.ToTable("ClienteDomicilio");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.OwnsOne("Facturacion.Domain.ValueObjects.Rfc", "_rfc", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .HasColumnName("Rfc")
                                .HasColumnType("character varying(13)")
                                .HasMaxLength(13);

                            b1.HasKey("ClienteId");

                            b1.ToTable("Cliente");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });
                });

            modelBuilder.Entity("Facturacion.Domain.Aggregates.Sucursal", b =>
                {
                    b.OwnsOne("Facturacion.Domain.ValueObjects.Domicilio", "_domicilio", b1 =>
                        {
                            b1.Property<Guid>("SucursalId")
                                .HasColumnType("uuid");

                            b1.Property<string>("_calle")
                                .HasColumnName("Calle")
                                .HasColumnType("character varying(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("_ciudad")
                                .HasColumnName("Ciudad")
                                .HasColumnType("character varying(25)")
                                .HasMaxLength(25);

                            b1.Property<string>("_codigoPostal")
                                .HasColumnName("CodigoPostal")
                                .HasColumnType("character varying(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("_colonia")
                                .HasColumnName("Colonia")
                                .HasColumnType("character varying(50)")
                                .HasMaxLength(50);

                            b1.Property<string>("_estado")
                                .HasColumnName("Estado")
                                .HasColumnType("character varying(25)")
                                .HasMaxLength(25);

                            b1.Property<string>("_municipio")
                                .HasColumnName("Municipio")
                                .HasColumnType("character varying(25)")
                                .HasMaxLength(25);

                            b1.Property<string>("_numeroExterior")
                                .HasColumnName("NumeroExterior")
                                .HasColumnType("character varying(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("_numeroInterior")
                                .HasColumnName("NumeroInterior")
                                .HasColumnType("character varying(10)")
                                .HasMaxLength(10);

                            b1.Property<string>("_pais")
                                .HasColumnName("Pais")
                                .HasColumnType("character varying(25)")
                                .HasMaxLength(25);

                            b1.HasKey("SucursalId");

                            b1.HasIndex("SucursalId")
                                .IsUnique()
                                .HasName("IX_SucursalId");

                            b1.ToTable("SucursalDomicilio");

                            b1.WithOwner()
                                .HasForeignKey("SucursalId");
                        });
                });

            modelBuilder.Entity("Facturacion.Domain.Aggregates.Usuario", b =>
                {
                    b.OwnsOne("Facturacion.Domain.ValueObjects.Email", "_email", b1 =>
                        {
                            b1.Property<Guid>("Usuario_id")
                                .HasColumnType("uuid");

                            b1.Property<string>("_value")
                                .HasColumnName("Email")
                                .HasColumnType("character varying(30)")
                                .HasMaxLength(30);

                            b1.HasKey("Usuario_id");

                            b1.ToTable("Usuario");

                            b1.WithOwner()
                                .HasForeignKey("Usuario_id");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
