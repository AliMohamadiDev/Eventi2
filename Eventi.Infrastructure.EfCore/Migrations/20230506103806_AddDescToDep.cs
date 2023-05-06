using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventi.Infrastructure.EfCore.Migrations
{
    public partial class AddDescToDep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(max)",
                maxLength: 20000,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");
        }
    }
}
