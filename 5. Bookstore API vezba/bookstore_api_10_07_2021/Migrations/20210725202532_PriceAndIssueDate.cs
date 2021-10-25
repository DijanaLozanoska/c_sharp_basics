using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace bookstore_api_10_07_2021.Migrations
{
    public partial class PriceAndIssueDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_BookID",
                table: "Books");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssueDate",
                table: "Books",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Books",
                maxLength: 10,
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Categories_CategoryID",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_CategoryID",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IssueDate",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Price",
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
