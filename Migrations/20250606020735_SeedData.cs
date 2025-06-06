using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HookedUp.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProjectRequests",
                columns: new[] { "Id", "Claimed", "ClaimedByUserId", "CreatedAt", "Description", "DueDate", "Location", "ProjectType", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[] { 1, false, null, new DateTime(2025, 6, 5, 21, 7, 35, 503, DateTimeKind.Local).AddTicks(7089), "Need a crocheted baby blanket.", new DateTime(2025, 6, 10, 21, 7, 35, 503, DateTimeKind.Local).AddTicks(6752), "New York", "Crochet", "Open", "Create a Baby Blanket", new DateTime(2025, 6, 5, 21, 7, 35, 503, DateTimeKind.Local).AddTicks(7164), 1 });

            migrationBuilder.InsertData(
                table: "ReviewRatings",
                columns: new[] { "Id", "ArtistId", "CreatedAt", "ProjectRequestId", "Rating", "ReviewImage", "ReviewText", "UpdatedAt", "UserId" },
                values: new object[] { 1, 2, new DateTime(2025, 6, 5, 21, 7, 35, 503, DateTimeKind.Local).AddTicks(8857), 1, 5, new[] { "https://example.com/reviewimage1.jpg" }, "Amazing crochet work! Very satisfied.", new DateTime(2025, 6, 5, 21, 7, 35, 503, DateTimeKind.Local).AddTicks(8951), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "ProfilePicture", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 5, 21, 7, 35, 501, DateTimeKind.Local).AddTicks(6825), "sirenafoster@example.com", "Sirena Foster", "password123", "https://example.com/sirenafoster.jpg", "user", new DateTime(2025, 6, 5, 21, 7, 35, 502, DateTimeKind.Local).AddTicks(9782) },
                    { 2, new DateTime(2025, 6, 5, 21, 7, 35, 503, DateTimeKind.Local).AddTicks(436), "jane.smith@example.com", "Jane Smith", "password456", "https://example.com/janesmith.jpg", "artist", new DateTime(2025, 6, 5, 21, 7, 35, 503, DateTimeKind.Local).AddTicks(441) }
                });

            migrationBuilder.InsertData(
                table: "ArtistProfiles",
                columns: new[] { "Id", "CreatedAt", "ExpertiseLevel", "ProfilePicture", "Specialization", "UpdatedAt", "UserId", "WorkDescription", "WorkImages" },
                values: new object[] { 1, new DateTime(2025, 6, 5, 21, 7, 35, 503, DateTimeKind.Local).AddTicks(4827), "Advanced", "https://example.com/artist1.jpg", "Crochet", new DateTime(2025, 6, 5, 21, 7, 35, 503, DateTimeKind.Local).AddTicks(4931), 2, "Experienced in creating custom crochet items.", new List<string> { "https://example.com/work1.jpg", "https://example.com/work2.jpg" } });

            migrationBuilder.InsertData(
                table: "DirectMessages",
                columns: new[] { "Id", "MessageText", "ProjectRequestId", "ReceiverId", "SenderId", "Timestamp" },
                values: new object[] { 1, "Hi, I'd love to help with your baby blanket project!", 1, 2, 1, new DateTime(2025, 6, 5, 21, 7, 35, 504, DateTimeKind.Local).AddTicks(239) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ArtistProfiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DirectMessages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ReviewRatings",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProjectRequests",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
