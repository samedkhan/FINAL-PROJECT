using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class CreatedPropertyProjectTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropProjectId",
                table: "Properties",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PropProjects",
                columns: table => new
                {
                    PropProjectID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropProjectName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropProjects", x => x.PropProjectID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropProjectId",
                table: "Properties",
                column: "PropProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropProjects_PropProjectId",
                table: "Properties",
                column: "PropProjectId",
                principalTable: "PropProjects",
                principalColumn: "PropProjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropProjects_PropProjectId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "PropProjects");

            migrationBuilder.DropIndex(
                name: "IX_Properties_PropProjectId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropProjectId",
                table: "Properties");
        }
    }
}
