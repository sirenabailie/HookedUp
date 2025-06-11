using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HookedUp.Migrations
{
    /// <inheritdoc />
    public partial class SeedAllProjectRequests : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtistProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt", "WorkImages" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(5581), new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(5692), new List<string> { "https://example.com/work1.jpg", "https://example.com/work2.jpg" } });

            migrationBuilder.UpdateData(
                table: "ArtistProfiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt", "WorkImages" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(5792), new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(5793), new List<string> { "https://example.com/sophia_work1.jpg", "https://example.com/sophia_work2.jpg" } });

            migrationBuilder.UpdateData(
                table: "DirectMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 6, 10, 18, 48, 26, 857, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.UpdateData(
                table: "DirectMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 6, 10, 18, 48, 26, 857, DateTimeKind.Local).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "ProjectRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(8470), new DateTime(2025, 6, 15, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(8119), new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(8546) });

            migrationBuilder.UpdateData(
                table: "ProjectRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(8629), new DateTime(2025, 6, 17, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(8628), new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(8630) });

            migrationBuilder.UpdateData(
                table: "ReviewRatings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 48, 26, 857, DateTimeKind.Local).AddTicks(505), new DateTime(2025, 6, 10, 18, 48, 26, 857, DateTimeKind.Local).AddTicks(598) });

            migrationBuilder.UpdateData(
                table: "ReviewRatings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 48, 26, 857, DateTimeKind.Local).AddTicks(679), new DateTime(2025, 6, 10, 18, 48, 26, 857, DateTimeKind.Local).AddTicks(680) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 48, 26, 854, DateTimeKind.Local).AddTicks(8658), new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(641) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(799), new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(802) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(805), new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(806) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(808), new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(809) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(811), new DateTime(2025, 6, 10, 18, 48, 26, 856, DateTimeKind.Local).AddTicks(812) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtistProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt", "WorkImages" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(5306), new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(5415), new List<string> { "https://example.com/work1.jpg", "https://example.com/work2.jpg" } });

            migrationBuilder.UpdateData(
                table: "ArtistProfiles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt", "WorkImages" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(5509), new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(5511), new List<string> { "https://example.com/sophia_work1.jpg", "https://example.com/sophia_work2.jpg" } });

            migrationBuilder.UpdateData(
                table: "DirectMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 6, 6, 22, 14, 20, 512, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "DirectMessages",
                keyColumn: "Id",
                keyValue: 2,
                column: "Timestamp",
                value: new DateTime(2025, 6, 6, 22, 14, 20, 512, DateTimeKind.Local).AddTicks(1816));

            migrationBuilder.UpdateData(
                table: "ProjectRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(8077), new DateTime(2025, 6, 11, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(7727), new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(8183) });

            migrationBuilder.UpdateData(
                table: "ProjectRequests",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(8268), new DateTime(2025, 6, 13, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(8265), new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(8269) });

            migrationBuilder.UpdateData(
                table: "ReviewRatings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 512, DateTimeKind.Local).AddTicks(186), new DateTime(2025, 6, 6, 22, 14, 20, 512, DateTimeKind.Local).AddTicks(279) });

            migrationBuilder.UpdateData(
                table: "ReviewRatings",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 512, DateTimeKind.Local).AddTicks(364), new DateTime(2025, 6, 6, 22, 14, 20, 512, DateTimeKind.Local).AddTicks(365) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 509, DateTimeKind.Local).AddTicks(6786), new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(348) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(517), new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(521) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(523), new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(525) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(527), new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(528) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(530), new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(531) });
        }
    }
}
