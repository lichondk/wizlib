using Microsoft.EntityFrameworkCore.Migrations;

namespace wizlib_dataccess.Migrations
{
    public partial class addDataToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO categories VALUES('cat 1')");
            migrationBuilder.Sql("INSERT INTO categories VALUES('cat 2')");
            migrationBuilder.Sql("INSERT INTO categories VALUES('cat 3')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
