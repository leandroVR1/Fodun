using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Fodun.Migrations
{
    /// <inheritdoc />
    public partial class LogicaNegocio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "TotalPagar",
                table: "Reservas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "TarifaPorNoche",
                table: "Reservas",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "DiasEspeciales",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiasOrdinarios",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "Lavanderia",
                table: "Reservas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "LavanderiaCosto",
                table: "Reservas",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Noches",
                table: "Reservas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Imagenes",
                columns: table => new
                {
                    ImagenId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SedeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagenes", x => x.ImagenId);
                    table.ForeignKey(
                        name: "FK_Imagenes_Sedes_SedeId",
                        column: x => x.SedeId,
                        principalTable: "Sedes",
                        principalColumn: "SedeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Imagenes_SedeId",
                table: "Imagenes",
                column: "SedeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Imagenes");

            migrationBuilder.DropColumn(
                name: "DiasEspeciales",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "DiasOrdinarios",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Lavanderia",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "LavanderiaCosto",
                table: "Reservas");

            migrationBuilder.DropColumn(
                name: "Noches",
                table: "Reservas");

            migrationBuilder.AlterColumn<double>(
                name: "TotalPagar",
                table: "Reservas",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "TarifaPorNoche",
                table: "Reservas",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }
    }
}
