using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class criacaoTabelaInfracoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JornaLocalidade",
                table: "Jornada",
                newName: "JornadaLocalidade");

            migrationBuilder.CreateTable(
                name: "infracoes",
                columns: table => new
                {
                    infracaoId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    descricaoInfracao = table.Column<string>(type: "varchar(250)", maxLength: 250, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pontuacao = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    JornadaQuilometragemId = table.Column<Guid>(type: "char(36)", nullable: true, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_infracoes", x => x.infracaoId);
                    table.ForeignKey(
                        name: "FK_infracoes_Jornada_JornadaQuilometragemId",
                        column: x => x.JornadaQuilometragemId,
                        principalTable: "Jornada",
                        principalColumn: "QuilometragemId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_infracoes_JornadaQuilometragemId",
                table: "infracoes",
                column: "JornadaQuilometragemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "infracoes");

            migrationBuilder.RenameColumn(
                name: "JornadaLocalidade",
                table: "Jornada",
                newName: "JornaLocalidade");
        }
    }
}
