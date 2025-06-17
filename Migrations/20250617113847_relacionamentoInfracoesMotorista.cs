using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class relacionamentoInfracoesMotorista : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "descricaoInfracao",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "pontuacao",
                table: "infracoes");

            migrationBuilder.AddColumn<DateOnly>(
                name: "admissao",
                table: "Motoristas",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "IdMotorista",
                table: "infracoes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "MotoristaId",
                table: "infracoes",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<DateOnly>(
                name: "entradaInfracao",
                table: "infracoes",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "grandeMonta",
                table: "infracoes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "multa",
                table: "infracoes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "pequenaMonta",
                table: "infracoes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "reclamacao",
                table: "infracoes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateOnly>(
                name: "saidaInfracao",
                table: "infracoes",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddColumn<bool>(
                name: "velocidade",
                table: "infracoes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_infracoes_MotoristaId",
                table: "infracoes",
                column: "MotoristaId");

            migrationBuilder.AddForeignKey(
                name: "FK_infracoes_Motoristas_MotoristaId",
                table: "infracoes",
                column: "MotoristaId",
                principalTable: "Motoristas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_infracoes_Motoristas_MotoristaId",
                table: "infracoes");

            migrationBuilder.DropIndex(
                name: "IX_infracoes_MotoristaId",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "admissao",
                table: "Motoristas");

            migrationBuilder.DropColumn(
                name: "IdMotorista",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "MotoristaId",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "entradaInfracao",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "grandeMonta",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "multa",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "pequenaMonta",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "reclamacao",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "saidaInfracao",
                table: "infracoes");

            migrationBuilder.DropColumn(
                name: "velocidade",
                table: "infracoes");

            migrationBuilder.AddColumn<string>(
                name: "descricaoInfracao",
                table: "infracoes",
                type: "varchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "pontuacao",
                table: "infracoes",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
