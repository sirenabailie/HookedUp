using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HookedUp.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoreData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ArtistProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt", "WorkImages" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(5306), new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(5415), new List<string> { "https://example.com/work1.jpg", "https://example.com/work2.jpg" } });

            migrationBuilder.UpdateData(
                table: "DirectMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 6, 6, 22, 14, 20, 512, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                table: "ProjectRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(8077), new DateTime(2025, 6, 11, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(7727), new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(8183) });

            migrationBuilder.InsertData(
                table: "ProjectRequests",
                columns: new[] { "Id", "Claimed", "ClaimedByUserId", "CreatedAt", "Description", "DueDate", "Location", "ProjectType", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[] { 2, false, null, new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(8268), "Looking for someone to finish my grandmother's knit scarf project.", new DateTime(2025, 6, 13, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(8265), "Chicago", "Knit", "Open", "Finish a Knit Scarf", new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(8269), 3 });

            migrationBuilder.UpdateData(
                table: "ReviewRatings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 6, 22, 14, 20, 512, DateTimeKind.Local).AddTicks(186), new DateTime(2025, 6, 6, 22, 14, 20, 512, DateTimeKind.Local).AddTicks(279) });

            migrationBuilder.InsertData(
                table: "ReviewRatings",
                columns: new[] { "Id", "ArtistId", "CreatedAt", "ProjectRequestId", "Rating", "ReviewImage", "ReviewText", "UpdatedAt", "UserId" },
                values: new object[] { 2, 4, new DateTime(2025, 6, 6, 22, 14, 20, 512, DateTimeKind.Local).AddTicks(364), 2, 4, new[] { "https://example.com/reviewimage2.jpg" }, "Sophia did a great job finishing my scarf—very happy with the result!", new DateTime(2025, 6, 6, 22, 14, 20, 512, DateTimeKind.Local).AddTicks(365), 3 });

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "ProfilePicture", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 3, new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(523), "sienna.delmar@example.com", "Sienna Delmar", "password789", "https://example.com/siennadelmar.jpg", "user", new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(525) },
                    { 4, new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(527), "sophia.garcia@example.com", "Sophia Garcia", "password000", "https://example.com/sophiagarcia.jpg", "artist", new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(528) },
                    { 5, new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(530), "iris.huxley@example.com", "Iris Huxley", "password321", "https://example.com/irishuxley.jpg", "artist", new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(531) }
                });

            migrationBuilder.InsertData(
                table: "ArtistProfiles",
                columns: new[] { "Id", "CreatedAt", "ExpertiseLevel", "ProfilePicture", "Specialization", "UpdatedAt", "UserId", "WorkDescription", "WorkImages" },
                values: new object[] { 2, new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(5509), "Intermediate", "https://example.com/sophiagarcia_art.jpg", "Knit", new DateTime(2025, 6, 6, 22, 14, 20, 511, DateTimeKind.Local).AddTicks(5511), 4, "Experienced in creating custom knit items.", new List<string> { "https://example.com/sophia_work1.jpg", "https://example.com/sophia_work2.jpg" } });

            migrationBuilder.InsertData(
                table: "DirectMessages",
                columns: new[] { "Id", "MessageText", "ProjectRequestId", "ReceiverId", "SenderId", "Timestamp" },
                values: new object[] { 2, "Hello Sienna, I’d be happy to finish your knit scarf project!", 2, 3, 4, new DateTime(2025, 6, 6, 22, 14, 20, 512, DateTimeKind.Local).AddTicks(1816) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtistProfiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DirectMessages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ReviewRatings",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProjectRequests",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "ArtistProfiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt", "WorkImages" },
                values: new object[] { new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(6250), new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(6360), new List<string> { "https://example.com/work1.jpg", "https://example.com/work2.jpg" } });

            migrationBuilder.UpdateData(
                table: "DirectMessages",
                keyColumn: "Id",
                keyValue: 1,
                column: "Timestamp",
                value: new DateTime(2025, 6, 5, 21, 53, 7, 446, DateTimeKind.Local).AddTicks(1786));

            migrationBuilder.UpdateData(
                table: "ProjectRequests",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "DueDate", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(8648), new DateTime(2025, 6, 10, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(8296), new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(8724) });

            migrationBuilder.UpdateData(
                table: "ReviewRatings",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 21, 53, 7, 446, DateTimeKind.Local).AddTicks(398), new DateTime(2025, 6, 5, 21, 53, 7, 446, DateTimeKind.Local).AddTicks(497) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 21, 53, 7, 443, DateTimeKind.Local).AddTicks(8125), new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(1035) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(1204), new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(1208) });
        }
    }
}
