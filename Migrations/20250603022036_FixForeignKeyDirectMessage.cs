using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HookedUp.Migrations
{
    /// <inheritdoc />
    public partial class FixForeignKeyDirectMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectMessages_ArtistProfiles_ReceiverId",
                table: "DirectMessages");

            migrationBuilder.UpdateData(
                table: "ArtistProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 20, 36, 272, DateTimeKind.Local).AddTicks(5422), new DateTime(2025, 6, 2, 21, 20, 36, 272, DateTimeKind.Local).AddTicks(5538) });

            migrationBuilder.UpdateData(
                table: "DirectMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 6, 2, 21, 20, 36, 273, DateTimeKind.Local).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "ProjectRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 20, 36, 272, DateTimeKind.Local).AddTicks(8199), new DateTime(2025, 6, 7, 21, 20, 36, 272, DateTimeKind.Local).AddTicks(7772), new DateTime(2025, 6, 2, 21, 20, 36, 272, DateTimeKind.Local).AddTicks(8278) });

            migrationBuilder.UpdateData(
                table: "ReviewRatings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 20, 36, 273, DateTimeKind.Local).AddTicks(85), new DateTime(2025, 6, 2, 21, 20, 36, 273, DateTimeKind.Local).AddTicks(185) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 20, 36, 270, DateTimeKind.Local).AddTicks(4980), new DateTime(2025, 6, 2, 21, 20, 36, 272, DateTimeKind.Local).AddTicks(74) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 20, 36, 272, DateTimeKind.Local).AddTicks(252), new DateTime(2025, 6, 2, 21, 20, 36, 272, DateTimeKind.Local).AddTicks(257) });

            migrationBuilder.AddForeignKey(
                name: "FK_DirectMessages_Users_ReceiverId",
                table: "DirectMessages",
                column: "ReceiverId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DirectMessages_Users_ReceiverId",
                table: "DirectMessages");

            migrationBuilder.UpdateData(
                table: "ArtistProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 11, 53, 582, DateTimeKind.Local).AddTicks(7383), new DateTime(2025, 6, 2, 21, 11, 53, 582, DateTimeKind.Local).AddTicks(7496) });

            migrationBuilder.UpdateData(
                table: "DirectMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 6, 2, 21, 11, 53, 583, DateTimeKind.Local).AddTicks(3318));

            migrationBuilder.UpdateData(
                table: "ProjectRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 11, 53, 582, DateTimeKind.Local).AddTicks(9923), new DateTime(2025, 6, 7, 21, 11, 53, 582, DateTimeKind.Local).AddTicks(9543), new DateTime(2025, 6, 2, 21, 11, 53, 583, DateTimeKind.Local).AddTicks(4) });

            migrationBuilder.UpdateData(
                table: "ReviewRatings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 11, 53, 583, DateTimeKind.Local).AddTicks(1781), new DateTime(2025, 6, 2, 21, 11, 53, 583, DateTimeKind.Local).AddTicks(1876) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 11, 53, 580, DateTimeKind.Local).AddTicks(6255), new DateTime(2025, 6, 2, 21, 11, 53, 582, DateTimeKind.Local).AddTicks(1859) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 2, 21, 11, 53, 582, DateTimeKind.Local).AddTicks(2040), new DateTime(2025, 6, 2, 21, 11, 53, 582, DateTimeKind.Local).AddTicks(2044) });

            migrationBuilder.AddForeignKey(
                name: "FK_DirectMessages_ArtistProfiles_ReceiverId",
                table: "DirectMessages",
                column: "ReceiverId",
                principalTable: "ArtistProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
