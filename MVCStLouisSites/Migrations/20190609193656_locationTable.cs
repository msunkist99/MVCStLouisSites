using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCStLouisSites.Migrations
{
    public partial class locationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttractionId",
                table: "Location",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AttractionUpdateViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BackgroundImageId = table.Column<int>(nullable: false),
                    IconImageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionUpdateViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Location_AttractionId",
                table: "Location",
                column: "AttractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Location_Attraction_AttractionId",
                table: "Location",
                column: "AttractionId",
                principalTable: "Attraction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Location_Attraction_AttractionId",
                table: "Location");

            migrationBuilder.DropTable(
                name: "AttractionUpdateViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Location_AttractionId",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "AttractionId",
                table: "Location");
        }
    }
}
