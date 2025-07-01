using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class atualizacaoTabea : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quilotragem");

            migrationBuilder.CreateTable(
                name: "Jornada",
                columns: table => new
                {
                    QuilometragemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    JornadaDia = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Motorista = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Placa = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Km = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jornada", x => x.QuilometragemId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jornada");

            migrationBuilder.CreateTable(
                name: "Quilotragem",
                columns: table => new
                {
                    QuilometragemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DataEntrada = table.Column<DateOnly>(type: "date", nullable: false),
                    Jornada = table.Column<DateOnly>(type: "date", nullable: false),
                    Km = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Motorista = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quilotragem", x => x.QuilometragemId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }
    }
}
