using Microsoft.EntityFrameworkCore.Migrations;

namespace FINAL.Migrations
{
    public partial class UserTypeKEYname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "UserTypes");

            migrationBuilder.RenameColumn(
                name: "UserTypeId",
                table: "Users",
                newName: "UserTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeId",
                table: "Users",
                newName: "IX_Users_UserTypeID");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserTypes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeID",
                table: "Users",
                column: "UserTypeID",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_UserTypes_UserTypeID",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserTypes");

            migrationBuilder.RenameColumn(
                name: "UserTypeID",
                table: "Users",
                newName: "UserTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_UserTypeID",
                table: "Users",
                newName: "IX_Users_UserTypeId");

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "UserTypes",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypes",
                table: "UserTypes",
                column: "UserTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_UserTypes_UserTypeId",
                table: "Users",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
