using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class normalizacaoDoBanco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_infracoes_Jornada_JornadaQuilometragemId",
                table: "infracoes");

            migrationBuilder.RenameColumn(
                name: "MotoristaID",
                table: "Motoristas",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "QuilometragemId",
                table: "Jornada",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "JornadaQuilometragemId",
                table: "infracoes",
                newName: "JornadaId");

            migrationBuilder.RenameIndex(
                name: "IX_infracoes_JornadaQuilometragemId",
                table: "infracoes",
                newName: "IX_infracoes_JornadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_infracoes_Jornada_JornadaId",
                table: "infracoes",
                column: "JornadaId",
                principalTable: "Jornada",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_infracoes_Jornada_JornadaId",
                table: "infracoes");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Motoristas",
                newName: "MotoristaID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Jornada",
                newName: "QuilometragemId");

            migrationBuilder.RenameColumn(
                name: "JornadaId",
                table: "infracoes",
                newName: "JornadaQuilometragemId");

            migrationBuilder.RenameIndex(
                name: "IX_infracoes_JornadaId",
                table: "infracoes",
                newName: "IX_infracoes_JornadaQuilometragemId");

            migrationBuilder.AddForeignKey(
                name: "FK_infracoes_Jornada_JornadaQuilometragemId",
                table: "infracoes",
                column: "JornadaQuilometragemId",
                principalTable: "Jornada",
                principalColumn: "QuilometragemId");
        }
    }
}
