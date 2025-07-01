using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class adicionandoforeingkey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Motorista",
                table: "Jornada");

            migrationBuilder.AddColumn<Guid>(
                name: "MotoristaID",
                table: "Jornada",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    MotoristaID = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    DisplayName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.MotoristaID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Jornada_MotoristaID",
                table: "Jornada",
                column: "MotoristaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Jornada_Motoristas_MotoristaID",
                table: "Jornada",
                column: "MotoristaID",
                principalTable: "Motoristas",
                principalColumn: "MotoristaID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jornada_Motoristas_MotoristaID",
                table: "Jornada");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropIndex(
                name: "IX_Jornada_MotoristaID",
                table: "Jornada");

            migrationBuilder.DropColumn(
                name: "MotoristaID",
                table: "Jornada");

            migrationBuilder.AddColumn<string>(
                name: "Motorista",
                table: "Jornada",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
