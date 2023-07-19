using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentStage = table.Column<int>(type: "int", nullable: false),
                    FlightCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Airline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsArriving = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FlightsHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    StageId = table.Column<int>(type: "int", nullable: false),
                    EntryDateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightsHistory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Stages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WaitTime_ms = table.Column<int>(type: "int", nullable: false),
                    NextDepartureStageId = table.Column<int>(type: "int", nullable: false),
                    NextArrivalStageId = table.Column<int>(type: "int", nullable: false),
                    IsTerminal = table.Column<bool>(type: "bit", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stages", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Stages",
                columns: new[] { "Id", "IsAvailable", "IsTerminal", "NextArrivalStageId", "NextDepartureStageId", "Title", "WaitTime_ms" },
                values: new object[,]
                {
                    { 1, false, false, 2, 0, "Landing Stage A", 3000 },
                    { 2, false, false, 3, 0, "Landing Stage B", 3000 },
                    { 3, false, false, 4, 0, "Landing Stage C", 3000 },
                    { 4, false, false, 5, 9, "Runaway", 3000 },
                    { 5, false, false, 51, 0, "Ready For Terminal", 3000 },
                    { 6, true, true, 0, 8, "Terminal A", 3000 },
                    { 7, true, true, 0, 8, "Terminal B", 3000 },
                    { 8, false, false, 0, 4, "Dispatching Ready", 3000 },
                    { 9, false, false, 0, 0, "Dispatched", 3000 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "FlightsHistory");

            migrationBuilder.DropTable(
                name: "Stages");
        }
    }
}
