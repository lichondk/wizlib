using Microsoft.EntityFrameworkCore.Migrations;

namespace wizlib_dataccess.Migrations
{
    public partial class changeNameOfCategoryIdOnCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "Category_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category_Id",
                table: "Categories",
                newName: "Id");
        }
    }
}
