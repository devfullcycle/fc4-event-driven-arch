using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FC4.HotelReservation.Shared.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "guests",
                columns: new[] { "id", "first_name", "last_name", "email" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "John", "Doe", "john.doe@example.com" });

            migrationBuilder.InsertData(
                table: "hotels",
                columns: new[] { "id", "name", "city", "country", "state", "street", "zip_code" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "Grand Hotel Plaza", "New York", "USA", "NY", "123 Main Street", "10001" });

            migrationBuilder.InsertData(
                table: "room_types",
                columns: new[] { "id", "description" },
                values: new object[] { new Guid("11111111-1111-1111-1111-111111111111"), "Standard Room" });

            migrationBuilder.InsertData(
                table: "room_type_inventory",
                columns: new[] { "id", "date", "hotel_id", "room_type_id", "total_inventory", "total_reserved", "version" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-000000000001"), new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000002"), new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000003"), new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000004"), new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000005"), new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000006"), new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000007"), new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000008"), new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000009"), new DateTime(2026, 3, 31, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000010"), new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000011"), new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000012"), new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000013"), new DateTime(2026, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000014"), new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000015"), new DateTime(2026, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000016"), new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000017"), new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000018"), new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000019"), new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000020"), new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000021"), new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000022"), new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000023"), new DateTime(2026, 4, 14, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000024"), new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000025"), new DateTime(2026, 4, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000026"), new DateTime(2026, 4, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000027"), new DateTime(2026, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000028"), new DateTime(2026, 4, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000029"), new DateTime(2026, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000030"), new DateTime(2026, 4, 21, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000031"), new DateTime(2026, 4, 22, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000032"), new DateTime(2026, 4, 23, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000033"), new DateTime(2026, 4, 24, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000034"), new DateTime(2026, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000035"), new DateTime(2026, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000036"), new DateTime(2026, 4, 27, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000037"), new DateTime(2026, 4, 28, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000038"), new DateTime(2026, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000039"), new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000040"), new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000041"), new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000042"), new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000043"), new DateTime(2026, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000044"), new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000045"), new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000046"), new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000047"), new DateTime(2026, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000048"), new DateTime(2026, 5, 9, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000049"), new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000050"), new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000051"), new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000052"), new DateTime(2026, 5, 13, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000053"), new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000054"), new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000055"), new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000056"), new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000057"), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000058"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000059"), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 },
                    { new Guid("44444444-4444-4444-4444-000000000060"), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), 10, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "room_type_rates",
                columns: new[] { "id", "date", "hotel_id", "room_type_id", "rate_currency", "rate_amount" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-000000000001"), new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000002"), new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000003"), new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000004"), new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000005"), new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000006"), new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000007"), new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000008"), new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000009"), new DateTime(2026, 3, 31, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000010"), new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000011"), new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000012"), new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000013"), new DateTime(2026, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000014"), new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000015"), new DateTime(2026, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000016"), new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000017"), new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000018"), new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000019"), new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000020"), new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000021"), new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000022"), new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000023"), new DateTime(2026, 4, 14, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000024"), new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000025"), new DateTime(2026, 4, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000026"), new DateTime(2026, 4, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000027"), new DateTime(2026, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000028"), new DateTime(2026, 4, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000029"), new DateTime(2026, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000030"), new DateTime(2026, 4, 21, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000031"), new DateTime(2026, 4, 22, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000032"), new DateTime(2026, 4, 23, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000033"), new DateTime(2026, 4, 24, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000034"), new DateTime(2026, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000035"), new DateTime(2026, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000036"), new DateTime(2026, 4, 27, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000037"), new DateTime(2026, 4, 28, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000038"), new DateTime(2026, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000039"), new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000040"), new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000041"), new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000042"), new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000043"), new DateTime(2026, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000044"), new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000045"), new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000046"), new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000047"), new DateTime(2026, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000048"), new DateTime(2026, 5, 9, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000049"), new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000050"), new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000051"), new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000052"), new DateTime(2026, 5, 13, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000053"), new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000054"), new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000055"), new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 195.000m },
                    { new Guid("11111111-1111-1111-1111-000000000056"), new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000057"), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000058"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000059"), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m },
                    { new Guid("11111111-1111-1111-1111-000000000060"), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111"), "USD", 150.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "guests",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000001"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000002"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000003"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000004"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000005"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000006"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000007"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000008"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000009"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000010"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000011"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000012"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000013"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000014"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000015"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000016"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000017"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000018"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000019"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000020"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000021"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000022"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000023"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000024"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000025"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000026"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000027"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000028"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000029"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000030"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000031"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000032"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000033"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000034"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000035"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000036"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000037"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000038"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000039"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000040"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000041"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000042"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000043"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000044"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000045"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000046"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000047"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000048"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000049"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000050"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000051"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000052"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000053"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000054"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000055"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000056"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000057"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000058"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000059"));

            migrationBuilder.DeleteData(
                table: "room_type_inventory",
                keyColumn: "id",
                keyValue: new Guid("44444444-4444-4444-4444-000000000060"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000001"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000002"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000003"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000004"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000005"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000006"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000007"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000008"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000009"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000010"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000011"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000012"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000013"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000014"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000015"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000016"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000017"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000018"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000019"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000020"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000021"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000022"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000023"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000024"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000025"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000026"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000027"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000028"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000029"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000030"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000031"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000032"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000033"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000034"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000035"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000036"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000037"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000038"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000039"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000040"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000041"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000042"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000043"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000044"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000045"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000046"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000047"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000048"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000049"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000050"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000051"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000052"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000053"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000054"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000055"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000056"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000057"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000058"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000059"));

            migrationBuilder.DeleteData(
                table: "room_type_rates",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-000000000060"));

            migrationBuilder.DeleteData(
                table: "hotels",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "room_types",
                keyColumn: "id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));
        }
    }
}
