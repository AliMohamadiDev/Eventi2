using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventi.Infrastructure.EfCore.Migrations
{
    public partial class AddTimeToEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PayByCustomer",
                table: "Events");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Events",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Events");

            migrationBuilder.AddColumn<bool>(
                name: "PayByCustomer",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
