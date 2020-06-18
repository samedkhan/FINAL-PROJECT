using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class ChangedAPUserTablePRoperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "APusers");

            migrationBuilder.AddColumn<bool>(
                name: "isAdmin",
                table: "APusers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isAdmin",
                table: "APusers");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "APusers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
