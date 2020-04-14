using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class RenewedAllTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropPhotos_PropAdds_PropAddId",
                table: "PropPhotos");

            migrationBuilder.DropTable(
                name: "PropertyCharacters");

            migrationBuilder.DropTable(
                name: "PropAdds");

            migrationBuilder.DropIndex(
                name: "IX_PropPhotos_PropAddId",
                table: "PropPhotos");

            migrationBuilder.DropColumn(
                name: "Photo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PropAddId",
                table: "PropPhotos");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Users",
                type: "ntext",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Users",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "PropPhotos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AddTypes",
                columns: table => new
                {
                    AddTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddTypes", x => x.AddTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    FeatureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.FeatureID);
                });

            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    PropertyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    CityId = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: true),
                    PropertySortId = table.Column<int>(nullable: false),
                    PropDoc = table.Column<int>(nullable: false),
                    PropFloorSum = table.Column<int>(nullable: true),
                    PropFloorNumber = table.Column<int>(nullable: true),
                    FlatSum = table.Column<int>(nullable: true),
                    Volume = table.Column<decimal>(type: "money", nullable: false),
                    FullAbout = table.Column<string>(type: "ntext", nullable: false),
                    MainPhoto = table.Column<string>(maxLength: 100, nullable: false),
                    FullAddress = table.Column<string>(type: "ntext", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.PropertyId);
                    table.ForeignKey(
                        name: "FK_Properties_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Properties_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Properties_PropertySorts_PropertySortId",
                        column: x => x.PropertySortId,
                        principalTable: "PropertySorts",
                        principalColumn: "PropertySortId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addvertisiments",
                columns: table => new
                {
                    AddvertisimentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    AddTypeID = table.Column<int>(nullable: false),
                    PropPrice = table.Column<decimal>(type: "money", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    AddStatus = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addvertisiments", x => x.AddvertisimentID);
                    table.ForeignKey(
                        name: "FK_Addvertisiments_AddTypes_AddTypeID",
                        column: x => x.AddTypeID,
                        principalTable: "AddTypes",
                        principalColumn: "AddTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addvertisiments_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Addvertisiments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropFeatures",
                columns: table => new
                {
                    PropFeatureID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertyID = table.Column<int>(nullable: false),
                    FeatureID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropFeatures", x => x.PropFeatureID);
                    table.ForeignKey(
                        name: "FK_PropFeatures_Features_FeatureID",
                        column: x => x.FeatureID,
                        principalTable: "Features",
                        principalColumn: "FeatureID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropFeatures_Properties_PropertyID",
                        column: x => x.PropertyID,
                        principalTable: "Properties",
                        principalColumn: "PropertyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropPhotos_PropertyId",
                table: "PropPhotos",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_Addvertisiments_AddTypeID",
                table: "Addvertisiments",
                column: "AddTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Addvertisiments_PropertyID",
                table: "Addvertisiments",
                column: "PropertyID");

            migrationBuilder.CreateIndex(
                name: "IX_Addvertisiments_UserId",
                table: "Addvertisiments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_CityId",
                table: "Properties",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_DistrictId",
                table: "Properties",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_PropertySortId",
                table: "Properties",
                column: "PropertySortId");

            migrationBuilder.CreateIndex(
                name: "IX_PropFeatures_FeatureID",
                table: "PropFeatures",
                column: "FeatureID");

            migrationBuilder.CreateIndex(
                name: "IX_PropFeatures_PropertyID",
                table: "PropFeatures",
                column: "PropertyID");

            migrationBuilder.AddForeignKey(
                name: "FK_PropPhotos_Properties_PropertyId",
                table: "PropPhotos",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "PropertyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropPhotos_Properties_PropertyId",
                table: "PropPhotos");

            migrationBuilder.DropTable(
                name: "Addvertisiments");

            migrationBuilder.DropTable(
                name: "PropFeatures");

            migrationBuilder.DropTable(
                name: "AddTypes");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_PropPhotos_PropertyId",
                table: "PropPhotos");

            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "PropPhotos");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Users",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "ntext",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Photo",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PropAddId",
                table: "PropPhotos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PropAdds",
                columns: table => new
                {
                    PropAddId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddStatus = table.Column<int>(type: "int", nullable: false),
                    AddType = table.Column<int>(type: "int", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    DistrictId = table.Column<int>(type: "int", nullable: true),
                    FullAbout = table.Column<string>(type: "ntext", nullable: false),
                    FullAddress = table.Column<string>(type: "ntext", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    MainPhoto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PropDoc = table.Column<int>(type: "int", nullable: false),
                    PropFlatSum = table.Column<int>(type: "int", nullable: false),
                    PropFloorNumber = table.Column<int>(type: "int", nullable: false),
                    PropFloorSum = table.Column<int>(type: "int", nullable: false),
                    PropPrice = table.Column<decimal>(type: "money", nullable: false),
                    PropVolume = table.Column<decimal>(type: "money", nullable: false),
                    PropertySortId = table.Column<int>(type: "int", nullable: false),
                    SaleType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropAdds", x => x.PropAddId);
                    table.ForeignKey(
                        name: "FK_PropAdds_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropAdds_Districts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "Districts",
                        principalColumn: "DistrictId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PropAdds_PropertySorts_PropertySortId",
                        column: x => x.PropertySortId,
                        principalTable: "PropertySorts",
                        principalColumn: "PropertySortId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PropAdds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PropertyCharacters",
                columns: table => new
                {
                    PCId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PCName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PropAddId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyCharacters", x => x.PCId);
                    table.ForeignKey(
                        name: "FK_PropertyCharacters_PropAdds_PropAddId",
                        column: x => x.PropAddId,
                        principalTable: "PropAdds",
                        principalColumn: "PropAddId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PropPhotos_PropAddId",
                table: "PropPhotos",
                column: "PropAddId");

            migrationBuilder.CreateIndex(
                name: "IX_PropAdds_CityId",
                table: "PropAdds",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PropAdds_DistrictId",
                table: "PropAdds",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_PropAdds_PropertySortId",
                table: "PropAdds",
                column: "PropertySortId");

            migrationBuilder.CreateIndex(
                name: "IX_PropAdds_UserId",
                table: "PropAdds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PropertyCharacters_PropAddId",
                table: "PropertyCharacters",
                column: "PropAddId");

            migrationBuilder.AddForeignKey(
                name: "FK_PropPhotos_PropAdds_PropAddId",
                table: "PropPhotos",
                column: "PropAddId",
                principalTable: "PropAdds",
                principalColumn: "PropAddId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
