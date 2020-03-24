using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class DeletedSomePropsAndAddedAddStatusPropINTOPropAddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminAgree",
                table: "PropAdds");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "PropAdds");

            migrationBuilder.DropColumn(
                name: "IsHidden",
                table: "PropAdds");

            migrationBuilder.AddColumn<int>(
                name: "AddStatus",
                table: "PropAdds",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddStatus",
                table: "PropAdds");

            migrationBuilder.AddColumn<bool>(
                name: "AdminAgree",
                table: "PropAdds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "PropAdds",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHidden",
                table: "PropAdds",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
