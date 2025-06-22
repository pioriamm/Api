using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoCampoAdministrador : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_infracoes_Motoristas_MotoristaId",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "isAdim",
                table: "Motoristas");

            migrationBuilder.AddColumn<int>(
                name: "perfilAcesso",
                table: "Motoristas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "MotoristaId",
                table: "infracoes",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_infracoes_Motoristas_MotoristaId",
                table: "infracoes",
                column: "MotoristaId",
                principalTable: "Motoristas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_infracoes_Motoristas_MotoristaId",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "perfilAcesso",
                table: "Motoristas");

            migrationBuilder.AddColumn<bool>(
                name: "isAdim",
                table: "Motoristas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "MotoristaId",
                table: "infracoes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_infracoes_Motoristas_MotoristaId",
                table: "infracoes",
                column: "MotoristaId",
                principalTable: "Motoristas",
                principalColumn: "Id");
        }
    }
}
