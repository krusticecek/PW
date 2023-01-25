using Microsoft.EntityFrameworkCore.Migrations;

namespace UTB.Eshop.Web.Migrations
{
    public partial class memberships : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "VIP");

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "Discount", "Name", "Status" },
                values: new object[] { 4, 25, "Better VIP", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Manager");
        }
    }
}
