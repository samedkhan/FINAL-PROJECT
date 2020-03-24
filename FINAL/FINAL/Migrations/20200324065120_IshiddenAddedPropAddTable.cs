using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class IshiddenAddedPropAddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "PropAdds",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "PropAdds");
        }
    }
}
