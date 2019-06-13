using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCStLouisSites.Migrations
{
    public partial class ratingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttractionId",
                table: "Rating",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateTimeStamp",
                table: "Rating",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AttractionUpdateViewModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AttractionUpdateViewModel",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "LocationCreateViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StreetAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    County = table.Column<string>(nullable: false),
                    NeighborhoodId = table.Column<int>(nullable: false),
                    GPS = table.Column<string>(nullable: false),
                    AttractionId = table.Column<int>(nullable: false),
                    AttractionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationCreateViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LocationUpdateViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StreetAddress = table.Column<string>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    Zip = table.Column<string>(nullable: false),
                    County = table.Column<string>(nullable: false),
                    NeighborhoodId = table.Column<int>(nullable: false),
                    GPS = table.Column<string>(nullable: false),
                    AttractionId = table.Column<int>(nullable: false),
                    AttractionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationUpdateViewModel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rating_AttractionId",
                table: "Rating",
                column: "AttractionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rating_Attraction_AttractionId",
                table: "Rating",
                column: "AttractionId",
                principalTable: "Attraction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Attraction_AttractionId",
                table: "Rating");

            migrationBuilder.DropTable(
                name: "LocationCreateViewModel");

            migrationBuilder.DropTable(
                name: "LocationUpdateViewModel");

            migrationBuilder.DropIndex(
                name: "IX_Rating_AttractionId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "AttractionId",
                table: "Rating");

            migrationBuilder.DropColumn(
                name: "DateTimeStamp",
                table: "Rating");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AttractionUpdateViewModel",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "AttractionUpdateViewModel",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
