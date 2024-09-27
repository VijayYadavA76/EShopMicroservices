using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Discount.Grpc.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Coupons",
                columns: new[] { "Id", "Amount", "Description", "ProductName" },
                values: new object[,]
                {
                    { 1, 150, "Special discount on the sleek Apple MacBook Air, featuring a Retina display and M1 chip. Don’t miss this chance to save!", "Apple MacBook Air" },
                    { 2, 100, "Grab the Samsung Galaxy S21 at a discounted price! Enjoy top-tier features and performance while saving money.", "Samsung Galaxy S21" },
                    { 3, 120, "Take advantage of this discount on the LG UltraGear 27GN950-B, a premium 4K gaming monitor. Elevate your setup for less!", "LG UltraGear 27GN950-B" },
                    { 4, 70, "Get the Sony WH-1000XM4 headphones at a special discount! Experience unmatched sound quality and noise cancellation.", "Sony WH-1000XM4" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Coupons",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
