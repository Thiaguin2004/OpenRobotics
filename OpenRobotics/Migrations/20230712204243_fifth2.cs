using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenRobotics.Migrations
{
    /// <inheritdoc />
    public partial class fifth2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_PerfilIdPerfil",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PerfilIdPerfil",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PerfilIdPerfil",
                table: "Usuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerfilIdPerfil",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.IdPerfil);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_PerfilIdPerfil",
                table: "Usuario",
                column: "PerfilIdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_PerfilIdPerfil",
                table: "Usuario",
                column: "PerfilIdPerfil",
                principalTable: "Perfil",
                principalColumn: "IdPerfil",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
