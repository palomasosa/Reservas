﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Reservas.BD.Data;

#nullable disable

namespace Reservas.BD.Migrations
{
    [DbContext(typeof(BDContext))]
    partial class BDContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Reservas.BD.Data.Entidades.Huesped", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DNI")
                        .HasMaxLength(8)
                        .HasColumnType("int");

                    b.Property<string>("Domicilio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nacionalidad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "DNI" }, "HuespedDNI_UQ")
                        .IsUnique();

                    b.ToTable("Huespedes");
                });

            modelBuilder.Entity("Reservas.BD.Data.Entidades.Reserva", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("DireccionAlojamiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreAlojamiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaDeposito")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaEntrada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("fechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("horarioCheckIn")
                        .HasColumnType("int");

                    b.Property<int>("horarioCheckOut")
                        .HasColumnType("int");

                    b.Property<int>("montoDeposito")
                        .HasColumnType("int");

                    b.Property<int>("precioTotal")
                        .HasColumnType("int");

                    b.Property<int>("saldoRestante")
                        .HasColumnType("int");

                    b.Property<int>("totalNoches")
                        .HasColumnType("int");

                    b.Property<int>("totalPasajeros")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "ID" }, "ReservaID_UQ")
                        .IsUnique();

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Reservas.BD.Data.Entidades.RespReserva", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex(new[] { "ID" }, "RespReservaID_UQ")
                        .IsUnique();

                    b.ToTable("RespReservas");
                });
#pragma warning restore 612, 618
        }
    }
}
