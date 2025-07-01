using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class NomeDaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_infracoes_Jornada_JornadaId",
                table: "infracoes");

            migrationBuilder.DropIndex(
                name: "IX_infracoes_JornadaId",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "JornadaId",
                table: "infracoes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "JornadaId",
                table: "infracoes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_infracoes_JornadaId",
                table: "infracoes",
                column: "JornadaId");

            migrationBuilder.AddForeignKey(
                name: "FK_infracoes_Jornada_JornadaId",
                table: "infracoes",
                column: "JornadaId",
                principalTable: "Jornada",
                principalColumn: "Id");
        }
    }
}
