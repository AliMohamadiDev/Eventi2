using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventi.Infrastructure.EfCore.Migrations
{
    public partial class RemoveCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventSubcategories_EventCategories_CategoryId",
                table: "EventSubcategories");

            migrationBuilder.DropTable(
                name: "EventCategories");

            migrationBuilder.DropIndex(
                name: "IX_EventSubcategories_CategoryId",
                table: "EventSubcategories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "EventSubcategories");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "CategoryId",
                table: "EventSubcategories",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "EventCategories",
                columns: table => new
                {
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(360)", maxLength: 360, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventCategories", x => x.CategoryId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventSubcategories_CategoryId",
                table: "EventSubcategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventSubcategories_EventCategories_CategoryId",
                table: "EventSubcategories",
                column: "CategoryId",
                principalTable: "EventCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
