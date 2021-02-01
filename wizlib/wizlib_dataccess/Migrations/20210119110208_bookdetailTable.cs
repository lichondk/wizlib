using Microsoft.EntityFrameworkCore.Migrations;

namespace wizlib_dataccess.Migrations
{
    public partial class bookdetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookDetail_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookDetail",
                table: "BookDetail");

            migrationBuilder.RenameTable(
                name: "BookDetail",
                newName: "bookDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookDetails",
                table: "bookDetails",
                column: "BookDetail_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_bookDetails_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                principalTable: "bookDetails",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_bookDetails_BookDetail_Id",
                table: "Books");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookDetails",
                table: "bookDetails");

            migrationBuilder.RenameTable(
                name: "bookDetails",
                newName: "BookDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookDetail",
                table: "BookDetail",
                column: "BookDetail_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookDetail_BookDetail_Id",
                table: "Books",
                column: "BookDetail_Id",
                principalTable: "BookDetail",
                principalColumn: "BookDetail_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
