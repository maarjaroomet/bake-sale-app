using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BakeSale.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialItems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Items");

            migrationBuilder.AddColumn<bool>(
                name: "IsFixedStock",
                table: "Items",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "IsFixedStock", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, true, "Brownie", 0.65m, 48 },
                    { 2, true, "Muffin", 1.00m, 36 },
                    { 3, true, "Cake Pop", 1.35m, 24 },
                    { 4, true, "Apple Tart", 1.50m, 60 },
                    { 5, true, "Water", 1.50m, 30 },
                    { 6, false, "Shirt", 2.00m, 0 },
                    { 7, false, "Pants", 3.00m, 0 },
                    { 8, false, "Jacket", 4.00m, 0 },
                    { 9, false, "Toy", 1.00m, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "IsFixedStock",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Items",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
