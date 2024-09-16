using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fodun.Migrations
{
    /// <inheritdoc />
    public partial class Tablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Fecha",
                table: "Disponibilidades",
                newName: "FechaInicio");

            migrationBuilder.AddColumn<int>(
                name: "AlojamientoId",
                table: "Tarifas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TarifaPorPersona",
                table: "Tarifas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "NumeroHabitaciones",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "TarifaPorNoche",
                table: "Reservas",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaFin",
                table: "Disponibilidades",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Tarifas_AlojamientoId",
                table: "Tarifas",
                column: "AlojamientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarifas_Alojamiento_AlojamientoId",
                table: "Tarifas",
                column: "AlojamientoId",
                principalTable: "Alojamiento",
                principalColumn: "AlojamientoId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarifas_Alojamiento_AlojamientoId",
                table: "Tarifas");

            migrationBuilder.DropIndex(
                name: "IX_Tarifas_AlojamientoId",
                table: "Tarifas");

            migrationBuilder.DropColumn(
                name: "AlojamientoId",
                table: "Tarifas");

            migrationBuilder.DropColumn(
                name: "TarifaPorPersona",
                table: "Tarifas");

            migrationBuilder.DropColumn(
                name: "NumeroHabitaciones",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "TarifaPorNoche",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "FechaFin",
                table: "Disponibilidades");

            migrationBuilder.RenameColumn(
                name: "FechaInicio",
                table: "Disponibilidades",
                newName: "Fecha");
        }
    }
}
