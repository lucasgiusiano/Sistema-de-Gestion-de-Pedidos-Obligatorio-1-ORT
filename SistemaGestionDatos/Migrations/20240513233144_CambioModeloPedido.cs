using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestionDatos.Migrations
{
    /// <inheritdoc />
    public partial class CambioModeloPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IVA",
                table: "Pedidos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "IVA",
                table: "Pedidos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
