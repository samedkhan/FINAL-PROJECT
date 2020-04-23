using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class PropDocTableCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropDoc",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "PropDocId",
                table: "Properties",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PropDocs",
                columns: table => new
                {
                    PropDocID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropDocName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropDocs", x => x.PropDocID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropDocId",
                table: "Properties",
                column: "PropDocId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropDocs_PropDocId",
                table: "Properties",
                column: "PropDocId",
                principalTable: "PropDocs",
                principalColumn: "PropDocID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropDocs_PropDocId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "PropDocs");

            migrationBuilder.DropIndex(
                name: "IX_Properties_PropDocId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropDocId",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "PropDoc",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
