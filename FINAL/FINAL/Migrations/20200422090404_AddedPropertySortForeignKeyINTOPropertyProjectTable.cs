using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class AddedPropertySortForeignKeyINTOPropertyProjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertySortId",
                table: "PropProjects",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PropProjects_PropertySortId",
                table: "PropProjects",
                column: "PropertySortId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropProjects_PropertySorts_PropertySortId",
                table: "PropProjects",
                column: "PropertySortId",
                principalTable: "PropertySorts",
                principalColumn: "PropertySortId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropProjects_PropertySorts_PropertySortId",
                table: "PropProjects");

            migrationBuilder.DropIndex(
                name: "IX_PropProjects_PropertySortId",
                table: "PropProjects");

            migrationBuilder.DropColumn(
                name: "PropertySortId",
                table: "PropProjects");
        }
    }
}
