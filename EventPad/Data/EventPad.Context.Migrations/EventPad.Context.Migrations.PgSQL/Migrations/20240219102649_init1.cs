using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EventPad.Context.Migrations.PgSql.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Repeat",
                table: "events",
                newName: "Type");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondName",
                table: "users",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "users");

            migrationBuilder.DropColumn(
                name: "SecondName",
                table: "users");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "events",
                newName: "Repeat");
        }
    }
}
