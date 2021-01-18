using Microsoft.EntityFrameworkCore.Migrations;

namespace wizlib_dataccess.Migrations
{
    public partial class updateColumnNameAuthor_IdOnAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Publisher_Id",
                table: "Authors",
                newName: "Author_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Author_Id",
                table: "Authors",
                newName: "Publisher_Id");
        }
    }
}
