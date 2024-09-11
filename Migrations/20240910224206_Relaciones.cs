using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fodun.Migrations
{
    /// <inheritdoc />
    public partial class Relaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reservas_AlojamientoId",
                table: "Reservas",
                column: "AlojamientoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservas_Alojamiento_AlojamientoId",
                table: "Reservas",
                column: "AlojamientoId",
                principalTable: "Alojamiento",
                principalColumn: "AlojamientoId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservas_Alojamiento_AlojamientoId",
                table: "Reservas");

            migrationBuilder.DropIndex(
                name: "IX_Reservas_AlojamientoId",
                table: "Reservas");
        }
    }
}
