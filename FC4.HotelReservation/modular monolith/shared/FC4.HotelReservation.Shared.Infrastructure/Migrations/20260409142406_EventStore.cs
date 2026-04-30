using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FC4.HotelReservation.Shared.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EventStore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "version",
                table: "reservations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "event_store",
                columns: table => new
                {
                    event_id = table.Column<Guid>(type: "uuid", nullable: false),
                    aggregate_id = table.Column<Guid>(type: "uuid", nullable: false),
                    aggregate_version = table.Column<int>(type: "integer", nullable: false),
                    event_type = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    event_data = table.Column<string>(type: "text", nullable: false),
                    occurred_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_store", x => x.event_id);
                });

            migrationBuilder.CreateIndex(
                name: "uix_event_store_aggregate_id_version",
                table: "event_store",
                columns: new[] { "aggregate_id", "aggregate_version" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "event_store");

            migrationBuilder.DropColumn(
                name: "version",
                table: "reservations");
        }
    }
}
