using Microsoft.EntityFrameworkCore.Migrations;

namespace UTB.Eshop.Web.Migrations
{
    public partial class memberid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "MemberId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "MemberId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_Users_MemberId",
                table: "Users",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Membership_MemberId",
                table: "Users",
                column: "MemberId",
                principalTable: "Membership",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Membership_MemberId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_MemberId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "Users");
        }
    }
}
