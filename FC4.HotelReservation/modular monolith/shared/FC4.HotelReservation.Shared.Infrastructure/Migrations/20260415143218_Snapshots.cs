using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FC4.HotelReservation.Shared.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Snapshots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "snapshots",
                columns: table => new
                {
                    aggregate_id = table.Column<Guid>(type: "uuid", nullable: false),
                    aggregate_version = table.Column<int>(type: "integer", nullable: false),
                    aggregate_type = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: false),
                    snapshot_data = table.Column<string>(type: "text", nullable: false),
                    created_on = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_snapshots", x => new { x.aggregate_id, x.aggregate_version });
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "snapshots");
        }
    }
}
