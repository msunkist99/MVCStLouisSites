using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCStLouisSites.Migrations
{
    public partial class fixBackgroundImageIconImageTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconImageFileLocation",
                table: "IconImage",
                newName: "IconImageFileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IconImageFileName",
                table: "IconImage",
                newName: "IconImageFileLocation");
        }
    }
}
