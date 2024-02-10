using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EventPad.Context.Migrations.PgSql.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "event_accounts",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountNumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_accounts", x => x.EventId);
                });

            migrationBuilder.CreateTable(
                name: "user_accounts",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AccountNumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    Balance = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_accounts", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "cashout_receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserAccountId = table.Column<int>(type: "integer", nullable: false),
                    BankAccount = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RKTransactionId = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashout_receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cashout_receipts_user_accounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "user_accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "deposit_receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserAccountId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RKTransactionId = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_deposit_receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_deposit_receipts_user_accounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "user_accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_users_user_accounts_Id",
                        column: x => x.Id,
                        principalTable: "user_accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cashout_event_receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventAccountId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    BankAccount = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RKTransactionId = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cashout_event_receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cashout_event_receipts_event_accounts_EventAccountId",
                        column: x => x.EventAccountId,
                        principalTable: "event_accounts",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_cashout_event_receipts_users_UserId",
                        column: x => x.UserId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Address = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Repeat = table.Column<int>(type: "integer", nullable: false),
                    MainPhoto = table.Column<string>(type: "text", nullable: true),
                    AdminId = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_events_event_accounts_Id",
                        column: x => x.Id,
                        principalTable: "event_accounts",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_events_users_AdminId",
                        column: x => x.AdminId,
                        principalTable: "users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event_photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Path = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_photos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_photos_events_EventId",
                        column: x => x.EventId,
                        principalTable: "events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "event_tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<float>(type: "real", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WeekDay = table.Column<int>(type: "integer", nullable: true),
                    Private = table.Column<bool>(type: "boolean", nullable: false),
                    ArticleNumber = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_event_tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_event_tickets_events_EventId",
                        column: x => x.EventId,
                        principalTable: "events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "event_visitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    EventTicketId = table.Column<int>(type: "integer", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "purchase_receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserAccountId = table.Column<int>(type: "integer", nullable: false),
                    EventTicketId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_purchase_receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_purchase_receipts_event_tickets_EventTicketId",
                        column: x => x.EventTicketId,
                        principalTable: "event_tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_purchase_receipts_user_accounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "user_accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "refund_receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserAccountId = table.Column<int>(type: "integer", nullable: false),
                    EventTicketId = table.Column<int>(type: "integer", nullable: false),
                    Amount = table.Column<float>(type: "real", nullable: false),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refund_receipts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_refund_receipts_event_tickets_EventTicketId",
                        column: x => x.EventTicketId,
                        principalTable: "event_tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_refund_receipts_user_accounts_UserAccountId",
                        column: x => x.UserAccountId,
                        principalTable: "user_accounts",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_cashout_event_receipts_EventAccountId",
                table: "cashout_event_receipts",
                column: "EventAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_cashout_event_receipts_Uid",
                table: "cashout_event_receipts",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cashout_event_receipts_UserId",
                table: "cashout_event_receipts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_cashout_receipts_Uid",
                table: "cashout_receipts",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_cashout_receipts_UserAccountId",
                table: "cashout_receipts",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_deposit_receipts_Uid",
                table: "deposit_receipts",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_deposit_receipts_UserAccountId",
                table: "deposit_receipts",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_event_accounts_AccountNumber",
                table: "event_accounts",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_event_photos_EventId",
                table: "event_photos",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_event_photos_Uid",
                table: "event_photos",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_event_tickets_EventId",
                table: "event_tickets",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_event_tickets_Uid",
                table: "event_tickets",
                column: "Uid",
                unique: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_events_AdminId",
                table: "events",
                column: "AdminId");

            migrationBuilder.CreateIndex(
                name: "IX_events_Uid",
                table: "events",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchase_receipts_EventTicketId",
                table: "purchase_receipts",
                column: "EventTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_purchase_receipts_Uid",
                table: "purchase_receipts",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_purchase_receipts_UserAccountId",
                table: "purchase_receipts",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_refund_receipts_EventTicketId",
                table: "refund_receipts",
                column: "EventTicketId");

            migrationBuilder.CreateIndex(
                name: "IX_refund_receipts_Uid",
                table: "refund_receipts",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_refund_receipts_UserAccountId",
                table: "refund_receipts",
                column: "UserAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_user_accounts_AccountNumber",
                table: "user_accounts",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Uid",
                table: "users",
                column: "Uid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cashout_event_receipts");

            migrationBuilder.DropTable(
                name: "cashout_receipts");

            migrationBuilder.DropTable(
                name: "deposit_receipts");

            migrationBuilder.DropTable(
                name: "event_photos");

            migrationBuilder.DropTable(
                name: "event_visitors");

            migrationBuilder.DropTable(
                name: "purchase_receipts");

            migrationBuilder.DropTable(
                name: "refund_receipts");

            migrationBuilder.DropTable(
                name: "event_tickets");

            migrationBuilder.DropTable(
                name: "events");

            migrationBuilder.DropTable(
                name: "event_accounts");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "user_accounts");
        }
    }
}
