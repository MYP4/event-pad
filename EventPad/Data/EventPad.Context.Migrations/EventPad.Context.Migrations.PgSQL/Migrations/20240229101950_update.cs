using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EventPad.Context.Migrations.PgSql.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_event_tickets_events_EventId",
                table: "event_tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_receipts_event_tickets_EventTicketId",
                table: "purchase_receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_refund_receipts_event_tickets_EventTicketId",
                table: "refund_receipts");

            migrationBuilder.DropTable(
                name: "event_visitors");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "events");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "event_tickets");

            migrationBuilder.DropColumn(
                name: "ArticleNumber",
                table: "event_tickets");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "event_tickets");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "event_tickets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "event_tickets");

            migrationBuilder.DropColumn(
                name: "Private",
                table: "event_tickets");

            migrationBuilder.DropColumn(
                name: "WeekDay",
                table: "event_tickets");

            migrationBuilder.RenameColumn(
                name: "EventTicketId",
                table: "refund_receipts",
                newName: "SpecificEventId");

            migrationBuilder.RenameIndex(
                name: "IX_refund_receipts_EventTicketId",
                table: "refund_receipts",
                newName: "IX_refund_receipts_SpecificEventId");

            migrationBuilder.RenameColumn(
                name: "EventTicketId",
                table: "purchase_receipts",
                newName: "SpecificEventId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_receipts_EventTicketId",
                table: "purchase_receipts",
                newName: "IX_purchase_receipts_SpecificEventId");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "event_tickets",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_event_tickets_EventId",
                table: "event_tickets",
                newName: "IX_event_tickets_UserId");

            migrationBuilder.AddColumn<int>(
                name: "EventTicketId",
                table: "event_tickets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "specific_events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DayOfWeek = table.Column<int>(type: "integer", nullable: true),
                    Private = table.Column<bool>(type: "boolean", nullable: false),
                    ArticleNumber = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specific_events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_specific_events_events_EventId",
                        column: x => x.EventId,
                        principalTable: "events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_event_tickets_EventTicketId",
                table: "event_tickets",
                column: "EventTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_specific_events_EventId",
                table: "specific_events",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_specific_events_Uid",
                table: "specific_events",
                column: "Uid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_event_tickets_specific_events_EventTicketId",
                table: "event_tickets",
                column: "EventTicketId",
                principalTable: "specific_events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_event_tickets_users_UserId",
                table: "event_tickets",
                column: "UserId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_receipts_specific_events_SpecificEventId",
                table: "purchase_receipts",
                column: "SpecificEventId",
                principalTable: "specific_events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_refund_receipts_specific_events_SpecificEventId",
                table: "refund_receipts",
                column: "SpecificEventId",
                principalTable: "specific_events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_event_tickets_specific_events_EventTicketId",
                table: "event_tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_event_tickets_users_UserId",
                table: "event_tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_purchase_receipts_specific_events_SpecificEventId",
                table: "purchase_receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_refund_receipts_specific_events_SpecificEventId",
                table: "refund_receipts");

            migrationBuilder.DropTable(
                name: "specific_events");

            migrationBuilder.DropIndex(
                name: "IX_event_tickets_EventTicketId",
                table: "event_tickets");

            migrationBuilder.DropColumn(
                name: "EventTicketId",
                table: "event_tickets");

            migrationBuilder.RenameColumn(
                name: "SpecificEventId",
                table: "refund_receipts",
                newName: "EventTicketId");

            migrationBuilder.RenameIndex(
                name: "IX_refund_receipts_SpecificEventId",
                table: "refund_receipts",
                newName: "IX_refund_receipts_EventTicketId");

            migrationBuilder.RenameColumn(
                name: "SpecificEventId",
                table: "purchase_receipts",
                newName: "EventTicketId");

            migrationBuilder.RenameIndex(
                name: "IX_purchase_receipts_SpecificEventId",
                table: "purchase_receipts",
                newName: "IX_purchase_receipts_EventTicketId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "event_tickets",
                newName: "EventId");

            migrationBuilder.RenameIndex(
                name: "IX_event_tickets_UserId",
                table: "event_tickets",
                newName: "IX_event_tickets_EventId");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "events",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "event_tickets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ArticleNumber",
                table: "event_tickets",
                type: "character varying(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "event_tickets",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "event_tickets",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "event_tickets",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Private",
                table: "event_tickets",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "WeekDay",
                table: "event_tickets",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "event_visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventTicketId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_visitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_visitors_event_tickets_EventTicketId",
                        column: x => x.EventTicketId,
                        principalTable: "event_tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_event_visitors_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_event_visitors_EventTicketId",
                table: "event_visitors",
                column: "EventTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_event_visitors_Uid",
                table: "event_visitors",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_event_visitors_UserId",
                table: "event_visitors",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_event_tickets_events_EventId",
                table: "event_tickets",
                column: "EventId",
                principalTable: "events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_purchase_receipts_event_tickets_EventTicketId",
                table: "purchase_receipts",
                column: "EventTicketId",
                principalTable: "event_tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_refund_receipts_event_tickets_EventTicketId",
                table: "refund_receipts",
                column: "EventTicketId",
                principalTable: "event_tickets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
