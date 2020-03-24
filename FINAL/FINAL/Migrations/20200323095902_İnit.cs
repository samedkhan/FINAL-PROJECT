using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class İnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "PropertySorts",
                columns: table => new
                {
                    PropertySortId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropertySortName = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertySorts", x => x.PropertySortId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Surname = table.Column<string>(maxLength: 50, nullable: true),
                    Password = table.Column<string>(maxLength: 150, nullable: false),
                    Token = table.Column<string>(nullable: true),
                    UserType = table.Column<int>(nullable: false),
                    Photo = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "WebsiteSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainLogo = table.Column<string>(maxLength: 100, nullable: false),
                    FooterLogo = table.Column<string>(maxLength: 100, nullable: true),
                    FacebookAddress = table.Column<string>(maxLength: 100, nullable: false),
                    TwitterAdress = table.Column<string>(maxLength: 100, nullable: false),
                    LinkedinAddress = table.Column<string>(maxLength: 100, nullable: false),
                    LocalAddress = table.Column<string>(maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(maxLength: 15, nullable: false),
                    MobileNumber = table.Column<string>(maxLength: 15, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Districts",
                columns: table => new
                {
                    DistrictId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistrictName = table.Column<string>(maxLength: 50, nullable: false),
                    CityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Districts", x => x.DistrictId);
                    table.ForeignKey(
                        name: "FK_Districts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactNumbers",
                columns: table => new
                {
                    ContactNumberId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactName = table.Column<string>(maxLength: 50, nullable: false),
                    Number = table.Column<string>(maxLength: 10, nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactNumbers", x => x.ContactNumberId);
                    table.ForeignKey(
                        name: "FK_ContactNumbers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PropAdds",
                columns: table => new
                {
                    PropAddId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    MainPhoto = table.Column<string>(maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    PropertySortId = table.Column<int>(nullable: false),
                    CityId = table.Column<int>(nullable: false),
                    DistrictId = table.Column<int>(nullable: false),
                    FullAddress = table.Column<string>(type: "ntext", nullable: false),
                    AddType = table.Column<int>(nullable: false),
                    PropDoc = table.Column<int>(nullable: false),
                    SaleType = table.Column<int>(nullable: false),
                    PropFloorSum = table.Column<int>(nullable: false),
                    PropFloorNumber = table.Column<int>(nullable: false),
                    PropFlatSum = table.Column<int>(nullable: false),
                    PropVolume = table.Column<decimal>(type: "money", nullable: false),
                    PropPrice = table.Column<decimal>(type: "money", nullable: false),
                    FullAbout = table.Column<string>(type: "ntext", nullable: false),
                    AdminAgree = table.Column<bool>(nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
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
                    PCId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PCName = table.Column<string>(maxLength: 15, nullable: false),
                    PropAddId = table.Column<int>(nullable: true)
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

            migrationBuilder.CreateTable(
                name: "PropPhotos",
                columns: table => new
                {
                    PropPhotoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PropPhotoName = table.Column<string>(nullable: true),
                    PropAddId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropPhotos", x => x.PropPhotoId);
                    table.ForeignKey(
                        name: "FK_PropPhotos_PropAdds_PropAddId",
                        column: x => x.PropAddId,
                        principalTable: "PropAdds",
                        principalColumn: "PropAddId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactNumbers_UserId",
                table: "ContactNumbers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Districts_CityId",
                table: "Districts",
                column: "CityId");

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

            migrationBuilder.CreateIndex(
                name: "IX_PropPhotos_PropAddId",
                table: "PropPhotos",
                column: "PropAddId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactNumbers");

            migrationBuilder.DropTable(
                name: "PropertyCharacters");

            migrationBuilder.DropTable(
                name: "PropPhotos");

            migrationBuilder.DropTable(
                name: "WebsiteSettings");

            migrationBuilder.DropTable(
                name: "PropAdds");

            migrationBuilder.DropTable(
                name: "Districts");

            migrationBuilder.DropTable(
                name: "PropertySorts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
