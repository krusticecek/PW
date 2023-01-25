using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace UTB.Eshop.Web.Migrations
{
    public partial class fix_all : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Member",
                table: "Users",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImageAlt",
                table: "Product",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ImageSrc",
                table: "Product",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Membership",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Membership", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "CarouselItem",
                columns: new[] { "ID", "ImageAlt", "ImageSrc" },
                values: new object[] { 4, "Forth slide", "/img/carousel/talisman.jpg" });

            migrationBuilder.InsertData(
                table: "Membership",
                columns: new[] { "Id", "Discount", "Name" },
                values: new object[,]
                {
                    { 1, 5, "One year" },
                    { 2, 10, "Two years" },
                    { 3, 20, "5+ years" }
                });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "ImageAlt", "ImageSrc", "Name", "Price" },
                values: new object[] { "One piece manga", "/img/products/op.jpg", "One Piece Manga", 250.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "ImageAlt", "ImageSrc", "Name", "Price" },
                values: new object[] { "Naruto manga", "/img/products/naruto.jpg", "Naruto Manga", 225.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "ImageAlt", "ImageSrc", "Name", "Price" },
                values: new object[] { "Bleach manga", "/img/products/bleach.jpg", "Bleach Manga", 200.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "ImageAlt", "ImageSrc", "Name", "Price" },
                values: new object[] { "Blue Lock manga", "/img/products/blue_lock.jpg", "Blue Lock Manga", 230.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "ImageAlt", "ImageSrc", "Name", "Price" },
                values: new object[] { "Attack on titan manga", "/img/products/aot.jpg", "Attack on titan Manga", 350.0 });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 4, "29dafca7-cd20-4cd9-a3dd-477awdawdawd", "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Membership");

            migrationBuilder.DeleteData(
                table: "CarouselItem",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Member",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageAlt",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ImageSrc",
                table: "Product");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Chleba", 100.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Máslo", 75.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Perlivě neperlivá voda", 40.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Tácek", 10.0 });

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "ID",
                keyValue: 5,
                columns: new[] { "Name", "Price" },
                values: new object[] { "Ubrousky", 50.0 });
        }
    }
}
