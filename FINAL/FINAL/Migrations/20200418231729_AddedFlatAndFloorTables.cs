using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class AddedFlatAndFloorTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlatSum",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropFloorNumber",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "PropFloorSum",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "FlatId",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorId",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FloorSum",
                table: "Properties",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    FlatID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.FlatID);
                });

            migrationBuilder.CreateTable(
                name: "Floors",
                columns: table => new
                {
                    FloorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FloorNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Floors", x => x.FloorID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_FlatId",
                table: "Properties",
                column: "FlatId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_FloorId",
                table: "Properties",
                column: "FloorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Flats_FlatId",
                table: "Properties",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "FlatID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Floors_FloorId",
                table: "Properties",
                column: "FloorId",
                principalTable: "Floors",
                principalColumn: "FloorID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Flats_FlatId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Floors_FloorId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Floors");

            migrationBuilder.DropIndex(
                name: "IX_Properties_FlatId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_FloorId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FlatId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FloorId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "FloorSum",
                table: "Properties");

            migrationBuilder.AddColumn<int>(
                name: "FlatSum",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropFloorNumber",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropFloorSum",
                table: "Properties",
                type: "int",
                nullable: true);
        }
    }
}
