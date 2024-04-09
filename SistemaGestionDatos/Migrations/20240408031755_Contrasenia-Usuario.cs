using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaGestionDatos.Migrations
{
    /// <inheritdoc />
    public partial class ContraseniaUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contrasenia",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ContraseniaHasheada",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contrasenia",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ContraseniaHasheada",
                table: "Usuarios");
        }
    }
}
