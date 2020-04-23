using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class AddedLandVolumepropintoPropertyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Volume",
                table: "Properties",
                newName: "LandVolume");

            migrationBuilder.AddColumn<decimal>(
                name: "BuildingVolume",
                table: "Properties",
                type: "money",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuildingVolume",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "LandVolume",
                table: "Properties",
                newName: "Volume");
        }
    }
}
