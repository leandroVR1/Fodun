using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fodun.Migrations
{
    /// <inheritdoc />
    public partial class Modelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disponivilidades");

            migrationBuilder.AddColumn<string>(
                name: "TipoTemporada",
                table: "Tarifas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Disponibilidades",
                columns: table => new
                {
                    DisponibilidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlojamientoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilidades", x => x.DisponibilidadId);
                    table.ForeignKey(
                        name: "FK_Disponibilidades_Alojamiento_AlojamientoId",
                        column: x => x.AlojamientoId,
                        principalTable: "Alojamiento",
                        principalColumn: "AlojamientoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilidades_AlojamientoId",
                table: "Disponibilidades",
                column: "AlojamientoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disponibilidades");

            migrationBuilder.DropColumn(
                name: "TipoTemporada",
                table: "Tarifas");

            migrationBuilder.CreateTable(
                name: "Disponivilidades",
                columns: table => new
                {
                    DisponibilidadId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlojamientoId = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponivilidades", x => x.DisponibilidadId);
                    table.ForeignKey(
                        name: "FK_Disponivilidades_Alojamiento_AlojamientoId",
                        column: x => x.AlojamientoId,
                        principalTable: "Alojamiento",
                        principalColumn: "AlojamientoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disponivilidades_AlojamientoId",
                table: "Disponivilidades",
                column: "AlojamientoId");
        }
    }
}
