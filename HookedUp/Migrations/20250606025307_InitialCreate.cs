﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HookedUp.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    ProjectType = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Claimed = table.Column<bool>(type: "boolean", nullable: false),
                    ClaimedByUserId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReviewRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProjectRequestId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ArtistId = table.Column<int>(type: "integer", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ReviewText = table.Column<string>(type: "text", nullable: false),
                    ReviewImage = table.Column<string[]>(type: "text[]", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReviewRatings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    ProfilePicture = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArtistProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Specialization = table.Column<string>(type: "text", nullable: false),
                    ProfilePicture = table.Column<string>(type: "text", nullable: false),
                    ExpertiseLevel = table.Column<string>(type: "text", nullable: false),
                    WorkImages = table.Column<List<string>>(type: "text[]", nullable: false),
                    WorkDescription = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistProfiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DirectMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SenderId = table.Column<int>(type: "integer", nullable: false),
                    ReceiverId = table.Column<int>(type: "integer", nullable: false),
                    ProjectRequestId = table.Column<int>(type: "integer", nullable: false),
                    MessageText = table.Column<string>(type: "text", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DirectMessages_ProjectRequests_ProjectRequestId",
                        column: x => x.ProjectRequestId,
                        principalTable: "ProjectRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectMessages_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectMessages_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProjectRequests",
                columns: new[] { "Id", "Claimed", "ClaimedByUserId", "CreatedAt", "Description", "DueDate", "Location", "ProjectType", "Status", "Title", "UpdatedAt", "UserId" },
                values: new object[] { 1, false, null, new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(8648), "Need a crocheted baby blanket.", new DateTime(2025, 6, 10, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(8296), "New York", "Crochet", "Open", "Create a Baby Blanket", new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(8724), 1 });

            migrationBuilder.InsertData(
                table: "ReviewRatings",
                columns: new[] { "Id", "ArtistId", "CreatedAt", "ProjectRequestId", "Rating", "ReviewImage", "ReviewText", "UpdatedAt", "UserId" },
                values: new object[] { 1, 2, new DateTime(2025, 6, 5, 21, 53, 7, 446, DateTimeKind.Local).AddTicks(398), 1, 5, new[] { "https://example.com/reviewimage1.jpg" }, "Amazing crochet work! Very satisfied.", new DateTime(2025, 6, 5, 21, 53, 7, 446, DateTimeKind.Local).AddTicks(497), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "Email", "Name", "Password", "ProfilePicture", "Role", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 6, 5, 21, 53, 7, 443, DateTimeKind.Local).AddTicks(8125), "sirenafoster@example.com", "Sirena Foster", "password123", "https://example.com/sirenafoster.jpg", "user", new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(1035) },
                    { 2, new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(1204), "jane.smith@example.com", "Jane Smith", "password456", "https://example.com/janesmith.jpg", "artist", new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(1208) }
                });

            migrationBuilder.InsertData(
                table: "ArtistProfiles",
                columns: new[] { "Id", "CreatedAt", "ExpertiseLevel", "ProfilePicture", "Specialization", "UpdatedAt", "UserId", "WorkDescription", "WorkImages" },
                values: new object[] { 1, new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(6250), "Advanced", "https://example.com/artist1.jpg", "Crochet", new DateTime(2025, 6, 5, 21, 53, 7, 445, DateTimeKind.Local).AddTicks(6360), 2, "Experienced in creating custom crochet items.", new List<string> { "https://example.com/work1.jpg", "https://example.com/work2.jpg" } });

            migrationBuilder.InsertData(
                table: "DirectMessages",
                columns: new[] { "Id", "MessageText", "ProjectRequestId", "ReceiverId", "SenderId", "Timestamp" },
                values: new object[] { 1, "Hi, I'd love to help with your baby blanket project!", 1, 2, 1, new DateTime(2025, 6, 5, 21, 53, 7, 446, DateTimeKind.Local).AddTicks(1786) });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistProfiles_UserId",
                table: "ArtistProfiles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectMessages_ProjectRequestId",
                table: "DirectMessages",
                column: "ProjectRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectMessages_ReceiverId",
                table: "DirectMessages",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_DirectMessages_SenderId",
                table: "DirectMessages",
                column: "SenderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistProfiles");

            migrationBuilder.DropTable(
                name: "DirectMessages");

            migrationBuilder.DropTable(
                name: "ReviewRatings");

            migrationBuilder.DropTable(
                name: "ProjectRequests");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
