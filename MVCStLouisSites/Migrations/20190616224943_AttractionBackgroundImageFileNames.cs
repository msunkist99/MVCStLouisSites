using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCStLouisSites.Migrations
{
    public partial class AttractionBackgroundImageFileNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BackgroundImageFileName",
                table: "Attraction",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IconImageFileName",
                table: "Attraction",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BackgroundImageFileName",
                table: "Attraction");

            migrationBuilder.DropColumn(
                name: "IconImageFileName",
                table: "Attraction");
        }
    }
}
