using Microsoft.EntityFrameworkCore.Migrations;

namespace bookstore_api_10_07_2021.Migrations
{
    public partial class PriceAndIssueDatev8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_BookID",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_BookID",
                table: "Books",
                column: "BookID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_BookID",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_BookID",
                table: "Books",
                column: "BookID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
