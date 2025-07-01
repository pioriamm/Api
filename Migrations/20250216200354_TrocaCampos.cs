using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Api.Migrations
{
    /// <inheritdoc />
    public partial class TrocaCampos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Quilometragems",
                table: "Quilometragems");

            migrationBuilder.RenameTable(
                name: "Quilometragems",
                newName: "Quilotragem");

            migrationBuilder.AlterColumn<string>(
                name: "Motorista",
                table: "Quilotragem",
                type: "varchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<decimal>(
                name: "Km",
                table: "Quilotragem",
                type: "decimal(10,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quilotragem",
                table: "Quilotragem",
                column: "QuilometragemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Quilotragem",
                table: "Quilotragem");

            migrationBuilder.DropColumn(
                name: "Km",
                table: "Quilotragem");

            migrationBuilder.RenameTable(
                name: "Quilotragem",
                newName: "Quilometragems");

            migrationBuilder.AlterColumn<string>(
                name: "Motorista",
                table: "Quilometragems",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldMaxLength: 100)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Quilometragems",
                table: "Quilometragems",
                column: "QuilometragemId");
        }
    }
}
