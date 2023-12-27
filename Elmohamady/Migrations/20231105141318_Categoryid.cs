using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Elmohamady.Migrations
{
    public partial class Categoryid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "price",
                table: "items",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "items",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "items",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "items",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "items",
                newName: "id");
        }
    }
}
