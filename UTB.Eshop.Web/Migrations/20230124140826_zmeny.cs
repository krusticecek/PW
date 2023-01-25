using Microsoft.EntityFrameworkCore.Migrations;

namespace UTB.Eshop.Web.Migrations
{
    public partial class zmeny : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discount", "Status" },
                values: new object[] { 0, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Discount", "Status" },
                values: new object[] { 5, 0 });
        }
    }
}
