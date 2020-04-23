using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class AddedDatafilterPropertyintoPropertySortTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataFilter",
                table: "PropertySorts",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFilter",
                table: "PropertySorts");
        }
    }
}
