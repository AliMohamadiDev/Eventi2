using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eventi.Infrastructure.EfCore.Migrations
{
    public partial class RemoveAccountTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountTicket");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountTicket",
                columns: table => new
                {
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    TicketId = table.Column<long>(type: "bigint", nullable: false),
                    AccountId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTicket", x => new { x.EventId, x.TicketId, x.AccountId });
                    table.ForeignKey(
                        name: "FK_AccountTicket_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTicket_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountTicket_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountTicket_AccountId",
                table: "AccountTicket",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountTicket_TicketId",
                table: "AccountTicket",
                column: "TicketId");
        }
    }
}
