using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventi.Infrastructure.EfCore.Migrations
{
    public partial class AddImgAndSlugToDepartment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Departments",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoAlt",
                table: "Departments",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LogoTitle",
                table: "Departments",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Departments",
                type: "nvarchar(360)",
                maxLength: 360,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LogoAlt",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "LogoTitle",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Departments");
        }
    }
}
