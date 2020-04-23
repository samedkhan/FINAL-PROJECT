using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class AddedExpDateIntoAddvertisimentsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ExpDate",
                table: "Addvertisiments",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExpDate",
                table: "Addvertisiments");
        }
    }
}
