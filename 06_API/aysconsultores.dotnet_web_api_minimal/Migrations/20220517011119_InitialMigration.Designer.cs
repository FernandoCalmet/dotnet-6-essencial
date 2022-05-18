﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using aysconsultores.dotnet_web_api_minimal.Persistencia;

#nullable disable

namespace aysconsultores.dotnet_web_api_minimal.Migrations
{
    [DbContext(typeof(ApiContexto))]
    [Migration("20220517011119_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("aysconsultores.dotnet_web_api_minimal.Entidades.Articulo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Contenido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaPublicacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Articulos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Contenido = "Contenido de Articulo 1",
                            FechaPublicacion = new DateTime(2022, 5, 17, 1, 11, 18, 870, DateTimeKind.Utc).AddTicks(8311),
                            Titulo = "Articulo 1"
                        },
                        new
                        {
                            Id = 2,
                            Contenido = "Contenido de Articulo 2",
                            FechaPublicacion = new DateTime(2022, 5, 17, 1, 11, 18, 870, DateTimeKind.Utc).AddTicks(8313),
                            Titulo = "Articulo 2"
                        },
                        new
                        {
                            Id = 3,
                            Contenido = "Contenido de Articulo 3",
                            FechaPublicacion = new DateTime(2022, 5, 17, 1, 11, 18, 870, DateTimeKind.Utc).AddTicks(8314),
                            Titulo = "Articulo 3"
                        },
                        new
                        {
                            Id = 4,
                            Contenido = "Contenido de Articulo 4",
                            FechaPublicacion = new DateTime(2022, 5, 17, 1, 11, 18, 870, DateTimeKind.Utc).AddTicks(8314),
                            Titulo = "Articulo 4"
                        },
                        new
                        {
                            Id = 5,
                            Contenido = "Contenido de Articulo 5",
                            FechaPublicacion = new DateTime(2022, 5, 17, 1, 11, 18, 870, DateTimeKind.Utc).AddTicks(8315),
                            Titulo = "Articulo 5"
                        },
                        new
                        {
                            Id = 6,
                            Contenido = "Contenido de Articulo 6",
                            FechaPublicacion = new DateTime(2022, 5, 17, 1, 11, 18, 870, DateTimeKind.Utc).AddTicks(8315),
                            Titulo = "Articulo 6"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}