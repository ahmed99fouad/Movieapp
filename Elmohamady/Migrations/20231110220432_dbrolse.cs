using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Elmohamady.Migrations
{
    /// <inheritdoc />
    public partial class dbrolse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "85628c3d-b506-4015-9a03-eeaf1ea41e59", "96772da3-c6c9-42ba-8bad-b4e182992bb5", "User", "user" },
                    { "884f2954-52dc-4225-bcdb-cd099714c8a1", "3a28382f-975f-4e5d-818b-3dc3998536c0", "Admin", "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "85628c3d-b506-4015-9a03-eeaf1ea41e59");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "884f2954-52dc-4225-bcdb-cd099714c8a1");
        }
    }
}
