using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class ajusteDeHoras : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JornadaDia",
                table: "Jornada",
                newName: "JornadaHora");

            migrationBuilder.AddColumn<DateOnly>(
                name: "JornadaData",
                table: "Jornada",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JornadaData",
                table: "Jornada");

            migrationBuilder.RenameColumn(
                name: "JornadaHora",
                table: "Jornada",
                newName: "JornadaDia");
        }
    }
}
