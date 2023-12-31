﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MinimalApiPropiedades.Data;

#nullable disable

namespace MinimalApiPropiedades.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MinimalApiPropiedades.Models.Propiedad", b =>
                {
                    b.Property<int>("IdPropiedad")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPropiedad"));

                    b.Property<bool>("Activa")
                        .HasColumnType("bit");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("FechaCreacion")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPropiedad");

                    b.ToTable("Propiedad");

                    b.HasData(
                        new
                        {
                            IdPropiedad = 1,
                            Activa = true,
                            Descripcion = "Descripción test",
                            FechaCreacion = new DateTime(2023, 8, 3, 18, 31, 30, 832, DateTimeKind.Local).AddTicks(599),
                            Nombre = "Casa las palmas",
                            Ubicacion = "Cartagena"
                        },
                        new
                        {
                            IdPropiedad = 2,
                            Activa = true,
                            Descripcion = "Descripción test",
                            FechaCreacion = new DateTime(2023, 8, 3, 18, 31, 30, 832, DateTimeKind.Local).AddTicks(647),
                            Nombre = "Casa las flores",
                            Ubicacion = "Asturias"
                        },
                        new
                        {
                            IdPropiedad = 3,
                            Activa = false,
                            Descripcion = "Descripción test",
                            FechaCreacion = new DateTime(2023, 8, 3, 18, 31, 30, 832, DateTimeKind.Local).AddTicks(650),
                            Nombre = "Casa las castañas",
                            Ubicacion = "Galicia"
                        },
                        new
                        {
                            IdPropiedad = 4,
                            Activa = true,
                            Descripcion = "Descripción test",
                            FechaCreacion = new DateTime(2023, 8, 3, 18, 31, 30, 832, DateTimeKind.Local).AddTicks(652),
                            Nombre = "Casa las peras",
                            Ubicacion = "Madrid"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
