using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Horizons.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenameUserDestinationsToUsersDestinations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserDestinations_AspNetUsers_UserId",
                table: "UserDestinations");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDestinations_Destinations_DestinationId",
                table: "UserDestinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDestinations",
                table: "UserDestinations");

            migrationBuilder.RenameTable(
                name: "UserDestinations",
                newName: "UsersDestinations");

            migrationBuilder.RenameIndex(
                name: "IX_UserDestinations_DestinationId",
                table: "UsersDestinations",
                newName: "IX_UsersDestinations_DestinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDestinations",
                table: "UsersDestinations",
                columns: new[] { "UserId", "DestinationId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ef88d0f-eff6-48c4-8e13-0e2c610f2ea4", "AQAAAAIAAYagAAAAEGxAtx2CYyMiFpP9tdJX3A5mnlJ4AS2v25h3ewnnJ4WtxLt/9YVzJFV7ys1mLFWjDw==", "d62344e4-2028-41c2-bfcb-37b33c26292a" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2025, 6, 25, 16, 42, 33, 170, DateTimeKind.Local).AddTicks(9323));

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2025, 6, 25, 16, 42, 33, 170, DateTimeKind.Local).AddTicks(9404));

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2025, 6, 25, 16, 42, 33, 170, DateTimeKind.Local).AddTicks(9411));

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDestinations_AspNetUsers_UserId",
                table: "UsersDestinations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDestinations_Destinations_DestinationId",
                table: "UsersDestinations",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersDestinations_AspNetUsers_UserId",
                table: "UsersDestinations");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDestinations_Destinations_DestinationId",
                table: "UsersDestinations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDestinations",
                table: "UsersDestinations");

            migrationBuilder.RenameTable(
                name: "UsersDestinations",
                newName: "UserDestinations");

            migrationBuilder.RenameIndex(
                name: "IX_UsersDestinations_DestinationId",
                table: "UserDestinations",
                newName: "IX_UserDestinations_DestinationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDestinations",
                table: "UserDestinations",
                columns: new[] { "UserId", "DestinationId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7699db7d-964f-4782-8209-d76562e0fece",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb940ddf-1a4d-45a0-a2ad-8eb18cd45ba5", "AQAAAAIAAYagAAAAEAoFvBZuGN0Wf2S30iQ13L3oXNhr84AIHnVJ5tS6/cWd5vu5cwRoNz9LK+m7bVLUwA==", "ef845546-9cdc-43ea-ae02-dd797c4ae576" });

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishedOn",
                value: new DateTime(2025, 6, 16, 17, 2, 21, 609, DateTimeKind.Local).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishedOn",
                value: new DateTime(2025, 6, 16, 17, 2, 21, 609, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "Destinations",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishedOn",
                value: new DateTime(2025, 6, 16, 17, 2, 21, 609, DateTimeKind.Local).AddTicks(6173));

            migrationBuilder.AddForeignKey(
                name: "FK_UserDestinations_AspNetUsers_UserId",
                table: "UserDestinations",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDestinations_Destinations_DestinationId",
                table: "UserDestinations",
                column: "DestinationId",
                principalTable: "Destinations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
