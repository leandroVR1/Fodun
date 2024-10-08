﻿// <auto-generated />
using System;
using Fodun.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fodun.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240910003450_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fodun.Models.Alojamiento", b =>
                {
                    b.Property<int>("AlojamientoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AlojamientoId"));

                    b.Property<int>("CapacidadMaxima")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumeroHabitaciones")
                        .HasColumnType("int");

                    b.Property<int>("SedeId")
                        .HasColumnType("int");

                    b.Property<string>("TipoAlojamiento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AlojamientoId");

                    b.HasIndex("SedeId");

                    b.ToTable("Alojamiento");
                });

            modelBuilder.Entity("Fodun.Models.Disponivilidad", b =>
                {
                    b.Property<int>("DisponibilidadId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DisponibilidadId"));

                    b.Property<int>("AlojamientoId")
                        .HasColumnType("int");

                    b.Property<bool>("Disponible")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.HasKey("DisponibilidadId");

                    b.HasIndex("AlojamientoId");

                    b.ToTable("Disponivilidades");
                });

            modelBuilder.Entity("Fodun.Models.Reserva", b =>
                {
                    b.Property<int>("ReservaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservaId"));

                    b.Property<int>("AlojamientoId")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroPersonas")
                        .HasColumnType("int");

                    b.Property<double>("TotalPagar")
                        .HasColumnType("float");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("ReservaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Reservas");
                });

            modelBuilder.Entity("Fodun.Models.Sede", b =>
                {
                    b.Property<int>("SedeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SedeId"));

                    b.Property<int>("CapacidadTotal")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SedeId");

                    b.ToTable("Sedes");
                });

            modelBuilder.Entity("Fodun.Models.Tarifa", b =>
                {
                    b.Property<int>("TarifaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TarifaId"));

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("NumeroPersonas")
                        .HasColumnType("int");

                    b.Property<int>("SedeId")
                        .HasColumnType("int");

                    b.Property<double>("TarifaPorNoche")
                        .HasColumnType("float");

                    b.Property<string>("Temporada")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TarifaId");

                    b.HasIndex("SedeId");

                    b.ToTable("Tarifas");
                });

            modelBuilder.Entity("Fodun.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Barrio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Celular")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Clave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Departamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Municipio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NroDocumento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreguntaClave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Fodun.Models.Alojamiento", b =>
                {
                    b.HasOne("Fodun.Models.Sede", "Sede")
                        .WithMany()
                        .HasForeignKey("SedeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sede");
                });

            modelBuilder.Entity("Fodun.Models.Disponivilidad", b =>
                {
                    b.HasOne("Fodun.Models.Alojamiento", "Alojamiento")
                        .WithMany()
                        .HasForeignKey("AlojamientoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alojamiento");
                });

            modelBuilder.Entity("Fodun.Models.Reserva", b =>
                {
                    b.HasOne("Fodun.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Fodun.Models.Tarifa", b =>
                {
                    b.HasOne("Fodun.Models.Sede", "Sede")
                        .WithMany()
                        .HasForeignKey("SedeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sede");
                });
#pragma warning restore 612, 618
        }
    }
}
