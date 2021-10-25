using Microsoft.EntityFrameworkCore.Migrations;

namespace bookstore_api_10_07_2021.Migrations
{
    public partial class PriceAndIssueDatev3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryID",
                table: "Books");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_BookID",
                table: "Books",
                column: "BookID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_BookID",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_CategoryID",
                table: "Books",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Categories_CategoryID",
                table: "Books",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
