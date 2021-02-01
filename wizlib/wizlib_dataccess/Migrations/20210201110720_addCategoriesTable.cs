using Microsoft.EntityFrameworkCore.Migrations;

namespace wizlib_dataccess.Migrations
{
    public partial class addCategoriesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Category_Id",
                table: "Books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Category_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Category_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_Category_Id",
                table: "Books",
                column: "Category_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_categories_Category_Id",
                table: "Books",
                column: "Category_Id",
                principalTable: "categories",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_categories_Category_Id",
                table: "Books");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropIndex(
                name: "IX_Books_Category_Id",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Category_Id",
                table: "Books");
        }
    }
}
