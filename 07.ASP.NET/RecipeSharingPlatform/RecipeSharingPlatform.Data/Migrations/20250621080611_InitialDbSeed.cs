using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecipeSharingPlatform.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", 0, "c26d0a5f-a89e-4346-b0d2-933a5e4695a0", "admin@recipesharing.com", true, false, null, "ADMIN@RECIPESHARING.COM", "ADMIN@RECIPESHARING.COM", "AQAAAAIAAYagAAAAEN+1nUs3xlwvHz3l2yE8FAKspmongg62AaxUPFOd04ToZZTxOLBLj5L9fLKPzRP6Bw==", null, false, "e86f63ff-e3a8-48a3-b6f7-c1d07c8e4f8d", false, "admin@recipesharing.com" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Appetizer" },
                    { 2, "Main Dish" },
                    { 3, "Dessert" },
                    { 4, "Soup" },
                    { 5, "Salad" },
                    { 6, "Beverage" }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "AuthorId", "CategoryId", "CreatedOn", "ImageUrl", "Instructions", "Title" },
                values: new object[,]
                {
                    { 1, "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", 1, new DateTime(2025, 6, 21, 10, 6, 11, 215, DateTimeKind.Local).AddTicks(4030), "https://www.unicornsinthekitchen.com/wp-content/uploads/2024/04/Bruschetta-sq-500x500.jpg", "Chop tomatoes, mix with basil and garlic, then spoon onto toasted bread.", "Classic Bruschetta" },
                    { 2, "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", 2, new DateTime(2025, 6, 21, 10, 6, 11, 215, DateTimeKind.Local).AddTicks(4093), "https://feelgoodfoodie.net/wp-content/uploads/2025/04/Grilled-Salmon-09-500x500.jpg", "Season salmon with herbs and grill skin-side down for 6–8 minutes.", "Grilled Salmon" },
                    { 3, "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd", 3, new DateTime(2025, 6, 21, 10, 6, 11, 215, DateTimeKind.Local).AddTicks(4096), "https://www.cookingclassy.com/wp-content/uploads/2022/02/molten-lava-cake-17-500x500.jpg", "Prepare cake mix, bake at high heat for 12 min. Serve warm with ice cream.", "Chocolate Lava Cake" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "df1c3a0f-1234-4cde-bb55-d5f15a6aabcd");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
