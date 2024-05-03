using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestionDatos.Migrations
{
    /// <inheritdoc />
    public partial class Configuracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PlazoMaximo",
                table: "Pedidos");

            migrationBuilder.AddColumn<double>(
                name: "IVA",
                table: "Pedidos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Configuraciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuraciones", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Configuraciones");

            migrationBuilder.DropColumn(
                name: "IVA",
                table: "Pedidos");

            migrationBuilder.AddColumn<int>(
                name: "PlazoMaximo",
                table: "Pedidos",
                type: "int",
                nullable: true);
        }
    }
}
