using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FC4.HotelReservation.Shared.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEventSourcedTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_payments_reservations",
                table: "payments");

            migrationBuilder.DropTable(
                name: "reservations");

            migrationBuilder.DropTable(
                name: "room_type_inventory");

            migrationBuilder.DropIndex(
                name: "IX_payments_reservation_id",
                table: "payments");

            migrationBuilder.CreateTable(
                name: "room_type_inventory_projections",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    hotel_id = table.Column<Guid>(type: "uuid", nullable: false),
                    room_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_type_inventory_projections", x => x.id);
                    table.ForeignKey(
                        name: "fk_room_type_inventories_hotels",
                        column: x => x.hotel_id,
                        principalTable: "hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_room_type_inventories_room_types",
                        column: x => x.room_type_id,
                        principalTable: "room_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "event_store",
                columns: new[] { "event_id", "aggregate_id", "aggregate_version", "event_data", "event_type", "occurred_on" },
                values: new object[,]
                {
                    { new Guid("55555555-5555-5555-5555-000000000001"), new Guid("44444444-4444-4444-4444-000000000001"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000001\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-03-23T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000001\",\"AggregateId\":\"44444444-4444-4444-4444-000000000001\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000002"), new Guid("44444444-4444-4444-4444-000000000002"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000002\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-03-24T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000002\",\"AggregateId\":\"44444444-4444-4444-4444-000000000002\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000003"), new Guid("44444444-4444-4444-4444-000000000003"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000003\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-03-25T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000003\",\"AggregateId\":\"44444444-4444-4444-4444-000000000003\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000004"), new Guid("44444444-4444-4444-4444-000000000004"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000004\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-03-26T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000004\",\"AggregateId\":\"44444444-4444-4444-4444-000000000004\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000005"), new Guid("44444444-4444-4444-4444-000000000005"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000005\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-03-27T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000005\",\"AggregateId\":\"44444444-4444-4444-4444-000000000005\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000006"), new Guid("44444444-4444-4444-4444-000000000006"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000006\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-03-28T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000006\",\"AggregateId\":\"44444444-4444-4444-4444-000000000006\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000007"), new Guid("44444444-4444-4444-4444-000000000007"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000007\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-03-29T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000007\",\"AggregateId\":\"44444444-4444-4444-4444-000000000007\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000008"), new Guid("44444444-4444-4444-4444-000000000008"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000008\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-03-30T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000008\",\"AggregateId\":\"44444444-4444-4444-4444-000000000008\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000009"), new Guid("44444444-4444-4444-4444-000000000009"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000009\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-03-31T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000009\",\"AggregateId\":\"44444444-4444-4444-4444-000000000009\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000010"), new Guid("44444444-4444-4444-4444-000000000010"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000010\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-01T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000010\",\"AggregateId\":\"44444444-4444-4444-4444-000000000010\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000011"), new Guid("44444444-4444-4444-4444-000000000011"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000011\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-02T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000011\",\"AggregateId\":\"44444444-4444-4444-4444-000000000011\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000012"), new Guid("44444444-4444-4444-4444-000000000012"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000012\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-03T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000012\",\"AggregateId\":\"44444444-4444-4444-4444-000000000012\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000013"), new Guid("44444444-4444-4444-4444-000000000013"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000013\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-04T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000013\",\"AggregateId\":\"44444444-4444-4444-4444-000000000013\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000014"), new Guid("44444444-4444-4444-4444-000000000014"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000014\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-05T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000014\",\"AggregateId\":\"44444444-4444-4444-4444-000000000014\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000015"), new Guid("44444444-4444-4444-4444-000000000015"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000015\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-06T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000015\",\"AggregateId\":\"44444444-4444-4444-4444-000000000015\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000016"), new Guid("44444444-4444-4444-4444-000000000016"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000016\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-07T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000016\",\"AggregateId\":\"44444444-4444-4444-4444-000000000016\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000017"), new Guid("44444444-4444-4444-4444-000000000017"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000017\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-08T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000017\",\"AggregateId\":\"44444444-4444-4444-4444-000000000017\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000018"), new Guid("44444444-4444-4444-4444-000000000018"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000018\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-09T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000018\",\"AggregateId\":\"44444444-4444-4444-4444-000000000018\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000019"), new Guid("44444444-4444-4444-4444-000000000019"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000019\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-10T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000019\",\"AggregateId\":\"44444444-4444-4444-4444-000000000019\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000020"), new Guid("44444444-4444-4444-4444-000000000020"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000020\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-11T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000020\",\"AggregateId\":\"44444444-4444-4444-4444-000000000020\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000021"), new Guid("44444444-4444-4444-4444-000000000021"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000021\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-12T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000021\",\"AggregateId\":\"44444444-4444-4444-4444-000000000021\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000022"), new Guid("44444444-4444-4444-4444-000000000022"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000022\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-13T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000022\",\"AggregateId\":\"44444444-4444-4444-4444-000000000022\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000023"), new Guid("44444444-4444-4444-4444-000000000023"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000023\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-14T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000023\",\"AggregateId\":\"44444444-4444-4444-4444-000000000023\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000024"), new Guid("44444444-4444-4444-4444-000000000024"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000024\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-15T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000024\",\"AggregateId\":\"44444444-4444-4444-4444-000000000024\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000025"), new Guid("44444444-4444-4444-4444-000000000025"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000025\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-16T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000025\",\"AggregateId\":\"44444444-4444-4444-4444-000000000025\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000026"), new Guid("44444444-4444-4444-4444-000000000026"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000026\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-17T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000026\",\"AggregateId\":\"44444444-4444-4444-4444-000000000026\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000027"), new Guid("44444444-4444-4444-4444-000000000027"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000027\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-18T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000027\",\"AggregateId\":\"44444444-4444-4444-4444-000000000027\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000028"), new Guid("44444444-4444-4444-4444-000000000028"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000028\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-19T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000028\",\"AggregateId\":\"44444444-4444-4444-4444-000000000028\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000029"), new Guid("44444444-4444-4444-4444-000000000029"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000029\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-20T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000029\",\"AggregateId\":\"44444444-4444-4444-4444-000000000029\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000030"), new Guid("44444444-4444-4444-4444-000000000030"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000030\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-21T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000030\",\"AggregateId\":\"44444444-4444-4444-4444-000000000030\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000031"), new Guid("44444444-4444-4444-4444-000000000031"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000031\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-22T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000031\",\"AggregateId\":\"44444444-4444-4444-4444-000000000031\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000032"), new Guid("44444444-4444-4444-4444-000000000032"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000032\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-23T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000032\",\"AggregateId\":\"44444444-4444-4444-4444-000000000032\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000033"), new Guid("44444444-4444-4444-4444-000000000033"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000033\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-24T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000033\",\"AggregateId\":\"44444444-4444-4444-4444-000000000033\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000034"), new Guid("44444444-4444-4444-4444-000000000034"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000034\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-25T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000034\",\"AggregateId\":\"44444444-4444-4444-4444-000000000034\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000035"), new Guid("44444444-4444-4444-4444-000000000035"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000035\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-26T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000035\",\"AggregateId\":\"44444444-4444-4444-4444-000000000035\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000036"), new Guid("44444444-4444-4444-4444-000000000036"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000036\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-27T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000036\",\"AggregateId\":\"44444444-4444-4444-4444-000000000036\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000037"), new Guid("44444444-4444-4444-4444-000000000037"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000037\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-28T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000037\",\"AggregateId\":\"44444444-4444-4444-4444-000000000037\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000038"), new Guid("44444444-4444-4444-4444-000000000038"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000038\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-29T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000038\",\"AggregateId\":\"44444444-4444-4444-4444-000000000038\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000039"), new Guid("44444444-4444-4444-4444-000000000039"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000039\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-04-30T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000039\",\"AggregateId\":\"44444444-4444-4444-4444-000000000039\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000040"), new Guid("44444444-4444-4444-4444-000000000040"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000040\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-01T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000040\",\"AggregateId\":\"44444444-4444-4444-4444-000000000040\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000041"), new Guid("44444444-4444-4444-4444-000000000041"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000041\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-02T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000041\",\"AggregateId\":\"44444444-4444-4444-4444-000000000041\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000042"), new Guid("44444444-4444-4444-4444-000000000042"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000042\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-03T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000042\",\"AggregateId\":\"44444444-4444-4444-4444-000000000042\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000043"), new Guid("44444444-4444-4444-4444-000000000043"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000043\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-04T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000043\",\"AggregateId\":\"44444444-4444-4444-4444-000000000043\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000044"), new Guid("44444444-4444-4444-4444-000000000044"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000044\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-05T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000044\",\"AggregateId\":\"44444444-4444-4444-4444-000000000044\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000045"), new Guid("44444444-4444-4444-4444-000000000045"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000045\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-06T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000045\",\"AggregateId\":\"44444444-4444-4444-4444-000000000045\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000046"), new Guid("44444444-4444-4444-4444-000000000046"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000046\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-07T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000046\",\"AggregateId\":\"44444444-4444-4444-4444-000000000046\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000047"), new Guid("44444444-4444-4444-4444-000000000047"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000047\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-08T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000047\",\"AggregateId\":\"44444444-4444-4444-4444-000000000047\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000048"), new Guid("44444444-4444-4444-4444-000000000048"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000048\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-09T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000048\",\"AggregateId\":\"44444444-4444-4444-4444-000000000048\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000049"), new Guid("44444444-4444-4444-4444-000000000049"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000049\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-10T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000049\",\"AggregateId\":\"44444444-4444-4444-4444-000000000049\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000050"), new Guid("44444444-4444-4444-4444-000000000050"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000050\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-11T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000050\",\"AggregateId\":\"44444444-4444-4444-4444-000000000050\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000051"), new Guid("44444444-4444-4444-4444-000000000051"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000051\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-12T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000051\",\"AggregateId\":\"44444444-4444-4444-4444-000000000051\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000052"), new Guid("44444444-4444-4444-4444-000000000052"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000052\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-13T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000052\",\"AggregateId\":\"44444444-4444-4444-4444-000000000052\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000053"), new Guid("44444444-4444-4444-4444-000000000053"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000053\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-14T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000053\",\"AggregateId\":\"44444444-4444-4444-4444-000000000053\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000054"), new Guid("44444444-4444-4444-4444-000000000054"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000054\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-15T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000054\",\"AggregateId\":\"44444444-4444-4444-4444-000000000054\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000055"), new Guid("44444444-4444-4444-4444-000000000055"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000055\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-16T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000055\",\"AggregateId\":\"44444444-4444-4444-4444-000000000055\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000056"), new Guid("44444444-4444-4444-4444-000000000056"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000056\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-17T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000056\",\"AggregateId\":\"44444444-4444-4444-4444-000000000056\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000057"), new Guid("44444444-4444-4444-4444-000000000057"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000057\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-18T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000057\",\"AggregateId\":\"44444444-4444-4444-4444-000000000057\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000058"), new Guid("44444444-4444-4444-4444-000000000058"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000058\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-19T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000058\",\"AggregateId\":\"44444444-4444-4444-4444-000000000058\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000059"), new Guid("44444444-4444-4444-4444-000000000059"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000059\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-20T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000059\",\"AggregateId\":\"44444444-4444-4444-4444-000000000059\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("55555555-5555-5555-5555-000000000060"), new Guid("44444444-4444-4444-4444-000000000060"), 0, "{\"InventoryId\":\"44444444-4444-4444-4444-000000000060\",\"HotelId\":\"11111111-1111-1111-1111-111111111111\",\"RoomTypeId\":\"11111111-1111-1111-1111-111111111111\",\"Date\":\"2026-05-21T00:00:00\",\"TotalInventory\":10,\"EventId\":\"55555555-5555-5555-5555-000000000060\",\"AggregateId\":\"44444444-4444-4444-4444-000000000060\",\"AggregateVersion\":0,\"OccuredOn\":\"2026-03-22T00:00:00Z\"}", "RoomTypeInventoryCreatedEvent", new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Utc) }
                });

            migrationBuilder.InsertData(
                table: "room_type_inventory_projections",
                columns: new[] { "id", "date", "hotel_id", "room_type_id" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-000000000001"), new DateTime(2026, 3, 23, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000002"), new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000003"), new DateTime(2026, 3, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000004"), new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000005"), new DateTime(2026, 3, 27, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000006"), new DateTime(2026, 3, 28, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000007"), new DateTime(2026, 3, 29, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000008"), new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000009"), new DateTime(2026, 3, 31, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000010"), new DateTime(2026, 4, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000011"), new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000012"), new DateTime(2026, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000013"), new DateTime(2026, 4, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000014"), new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000015"), new DateTime(2026, 4, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000016"), new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000017"), new DateTime(2026, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000018"), new DateTime(2026, 4, 9, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000019"), new DateTime(2026, 4, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000020"), new DateTime(2026, 4, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000021"), new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000022"), new DateTime(2026, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000023"), new DateTime(2026, 4, 14, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000024"), new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000025"), new DateTime(2026, 4, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000026"), new DateTime(2026, 4, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000027"), new DateTime(2026, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000028"), new DateTime(2026, 4, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000029"), new DateTime(2026, 4, 20, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000030"), new DateTime(2026, 4, 21, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000031"), new DateTime(2026, 4, 22, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000032"), new DateTime(2026, 4, 23, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000033"), new DateTime(2026, 4, 24, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000034"), new DateTime(2026, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000035"), new DateTime(2026, 4, 26, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000036"), new DateTime(2026, 4, 27, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000037"), new DateTime(2026, 4, 28, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000038"), new DateTime(2026, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000039"), new DateTime(2026, 4, 30, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000040"), new DateTime(2026, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000041"), new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000042"), new DateTime(2026, 5, 3, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000043"), new DateTime(2026, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000044"), new DateTime(2026, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000045"), new DateTime(2026, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000046"), new DateTime(2026, 5, 7, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000047"), new DateTime(2026, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000048"), new DateTime(2026, 5, 9, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000049"), new DateTime(2026, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000050"), new DateTime(2026, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000051"), new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000052"), new DateTime(2026, 5, 13, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000053"), new DateTime(2026, 5, 14, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000054"), new DateTime(2026, 5, 15, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000055"), new DateTime(2026, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000056"), new DateTime(2026, 5, 17, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000057"), new DateTime(2026, 5, 18, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000058"), new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000059"), new DateTime(2026, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") },
                    { new Guid("44444444-4444-4444-4444-000000000060"), new DateTime(2026, 5, 21, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new Guid("11111111-1111-1111-1111-111111111111") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_room_type_inventory_projections_hotel_id_room_type_id_date",
                table: "room_type_inventory_projections",
                columns: new[] { "hotel_id", "room_type_id", "date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_room_type_inventory_projections_room_type_id",
                table: "room_type_inventory_projections",
                column: "room_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "room_type_inventory_projections");

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000001"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000002"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000003"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000004"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000005"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000006"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000007"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000008"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000009"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000010"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000011"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000012"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000013"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000014"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000015"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000016"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000017"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000018"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000019"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000020"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000021"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000022"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000023"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000024"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000025"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000026"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000027"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000028"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000029"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000030"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000031"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000032"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000033"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000034"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000035"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000036"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000037"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000038"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000039"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000040"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000041"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000042"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000043"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000044"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000045"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000046"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000047"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000048"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000049"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000050"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000051"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000052"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000053"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000054"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000055"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000056"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000057"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000058"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000059"));

            migrationBuilder.DeleteData(
                table: "event_store",
                keyColumn: "event_id",
                keyValue: new Guid("55555555-5555-5555-5555-000000000060"));

            migrationBuilder.CreateTable(
                name: "reservations",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    guest_id = table.Column<Guid>(type: "uuid", nullable: false),
                    hotel_id = table.Column<Guid>(type: "uuid", nullable: false),
                    room_quantity = table.Column<int>(type: "integer", nullable: false),
                    room_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false),
                    version = table.Column<int>(type: "integer", nullable: false),
                    stay_end_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    stay_start_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    total_currency = table.Column<string>(type: "character varying(3)", maxLength: 3, nullable: false),
                    total_amount = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservations", x => x.id);
                    table.ForeignKey(
                        name: "fk_reservations_guests",
                        column: x => x.guest_id,
                        principalTable: "guests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reservations_hotels",
                        column: x => x.hotel_id,
                        principalTable: "hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_reservations_room_types",
                        column: x => x.room_type_id,
                        principalTable: "room_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "room_type_inventory",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    hotel_id = table.Column<Guid>(type: "uuid", nullable: false),
                    room_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    total_inventory = table.Column<int>(type: "integer", nullable: false),
                    total_reserved = table.Column<int>(type: "integer", nullable: false),
                    version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_type_inventory", x => x.id);
                    table.ForeignKey(
                        name: "fk_room_type_inventories_hotels",
                        column: x => x.hotel_id,
                        principalTable: "hotels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_room_type_inventories_room_types",
                        column: x => x.room_type_id,
                        principalTable: "room_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_payments_reservation_id",
                table: "payments",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_guest_id",
                table: "reservations",
                column: "guest_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_hotel_id",
                table: "reservations",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_reservations_room_type_id",
                table: "reservations",
                column: "room_type_id");

            migrationBuilder.CreateIndex(
                name: "IX_room_type_inventory_hotel_id_room_type_id_date",
                table: "room_type_inventory",
                columns: new[] { "hotel_id", "room_type_id", "date" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_room_type_inventory_room_type_id",
                table: "room_type_inventory",
                column: "room_type_id");

            migrationBuilder.AddForeignKey(
                name: "fk_payments_reservations",
                table: "payments",
                column: "reservation_id",
                principalTable: "reservations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
