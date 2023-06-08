using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventi.Infrastructure.EfCore.Migrations
{
    public partial class EventInfoDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventInfos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventInfos",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", maxLength: 4096, nullable: true),
                    City = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", maxLength: 20000, nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HostingService = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsPersonalSystem = table.Column<bool>(type: "bit", nullable: false),
                    IsWebinar = table.Column<bool>(type: "bit", nullable: false),
                    Length = table.Column<float>(type: "real", nullable: false),
                    LoginLink = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    RoomCapacity = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    State = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TotalHours = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventInfos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventInfos_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventInfos_EventId",
                table: "EventInfos",
                column: "EventId",
                unique: true);
        }
    }
}
