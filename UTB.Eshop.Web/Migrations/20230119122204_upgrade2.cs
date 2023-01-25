using Microsoft.EntityFrameworkCore.Migrations;

namespace UTB.Eshop.Web.Migrations
{
    public partial class upgrade2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Status" },
                values: new object[] { "Customer", 0 });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Discount", "Name" },
                values: new object[] { 5, "Member" });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Discount", "Name" },
                values: new object[] { 15, "Manager" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Status" },
                values: new object[] { "One year", 1 });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Discount", "Name" },
                values: new object[] { 10, "Two years" });

            migrationBuilder.UpdateData(
                table: "Membership",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Discount", "Name" },
                values: new object[] { 20, "5+ years" });
        }
    }
}
