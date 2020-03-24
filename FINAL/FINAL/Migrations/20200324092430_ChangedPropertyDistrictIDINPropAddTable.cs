using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class ChangedPropertyDistrictIDINPropAddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropAdds_Districts_DistrictId",
                table: "PropAdds");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "PropAdds",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PropAdds_Districts_DistrictId",
                table: "PropAdds",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropAdds_Districts_DistrictId",
                table: "PropAdds");

            migrationBuilder.AlterColumn<int>(
                name: "DistrictId",
                table: "PropAdds",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PropAdds_Districts_DistrictId",
                table: "PropAdds",
                column: "DistrictId",
                principalTable: "Districts",
                principalColumn: "DistrictId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
