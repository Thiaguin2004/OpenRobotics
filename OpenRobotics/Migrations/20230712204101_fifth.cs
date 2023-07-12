using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OpenRobotics.Migrations
{
    /// <inheritdoc />
    public partial class fifth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_PerfilId",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "PerfilId",
                table: "Usuario",
                newName: "PerfilIdPerfil");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_PerfilId",
                table: "Usuario",
                newName: "IX_Usuario_PerfilIdPerfil");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Perfil",
                newName: "IdPerfil");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_PerfilIdPerfil",
                table: "Usuario",
                column: "PerfilIdPerfil",
                principalTable: "Perfil",
                principalColumn: "IdPerfil",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Perfil_PerfilIdPerfil",
                table: "Usuario");

            migrationBuilder.RenameColumn(
                name: "PerfilIdPerfil",
                table: "Usuario",
                newName: "PerfilId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_PerfilIdPerfil",
                table: "Usuario",
                newName: "IX_Usuario_PerfilId");

            migrationBuilder.RenameColumn(
                name: "IdPerfil",
                table: "Perfil",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_Perfil_PerfilId",
                table: "Usuario",
                column: "PerfilId",
                principalTable: "Perfil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
