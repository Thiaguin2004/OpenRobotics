using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenRobotics.Migrations
{
    /// <inheritdoc />
    public partial class sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_PerfilIdPerfil",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_PerfilIdPerfil",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PerfilIdPerfil",
                table: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdPerfil",
                table: "Usuario",
                column: "IdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_IdPerfil",
                table: "Usuario",
                column: "IdPerfil",
                principalTable: "Perfil",
                principalColumn: "IdPerfil",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_IdPerfil",
                table: "Usuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_IdPerfil",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "PerfilIdPerfil",
                table: "Usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
