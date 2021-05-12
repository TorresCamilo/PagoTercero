﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(PagoContext))]
    [Migration("20210509160658_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Pago", b =>
                {
                    b.Property<string>("PagoId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Iva")
                        .HasColumnType("decimal(15,2)");

                    b.Property<decimal>("PorcentajeIva")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("TerceroId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(15,2)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(15,2)");

                    b.HasKey("PagoId");

                    b.HasIndex("TerceroId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("Entity.Tercero", b =>
                {
                    b.Property<string>("TerceroId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TerceroId");

                    b.ToTable("Terceros");
                });

            modelBuilder.Entity("Entity.Pago", b =>
                {
                    b.HasOne("Entity.Tercero", "Tercero")
                        .WithMany("Pagos")
                        .HasForeignKey("TerceroId");

                    b.Navigation("Tercero");
                });

            modelBuilder.Entity("Entity.Tercero", b =>
                {
                    b.Navigation("Pagos");
                });
#pragma warning restore 612, 618
        }
    }
}
