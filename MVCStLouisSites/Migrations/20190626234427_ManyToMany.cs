using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCStLouisSites.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttractionId",
                table: "ParkingSite",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AttractionId",
                table: "AttractionFeature",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AttractionFeatureAttractions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AttractionFeatureId = table.Column<int>(nullable: false),
                    AttractionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionFeatureAttractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttractionFeatureAttractions_AttractionFeature_AttractionFeatureId",
                        column: x => x.AttractionFeatureId,
                        principalTable: "AttractionFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttractionFeatureAttractions_Attraction_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSiteAttractions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParkingSiteId = table.Column<int>(nullable: false),
                    AttractionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSiteAttractions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingSiteAttractions_Attraction_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParkingSiteAttractions_ParkingSite_ParkingSiteId",
                        column: x => x.ParkingSiteId,
                        principalTable: "ParkingSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSite_AttractionId",
                table: "ParkingSite",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttractionFeature_AttractionId",
                table: "AttractionFeature",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttractionFeatureAttractions_AttractionFeatureId",
                table: "AttractionFeatureAttractions",
                column: "AttractionFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_AttractionFeatureAttractions_AttractionId",
                table: "AttractionFeatureAttractions",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSiteAttractions_AttractionId",
                table: "ParkingSiteAttractions",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingSiteAttractions_ParkingSiteId",
                table: "ParkingSiteAttractions",
                column: "ParkingSiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_AttractionFeature_Attraction_AttractionId",
                table: "AttractionFeature",
                column: "AttractionId",
                principalTable: "Attraction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ParkingSite_Attraction_AttractionId",
                table: "ParkingSite",
                column: "AttractionId",
                principalTable: "Attraction",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AttractionFeature_Attraction_AttractionId",
                table: "AttractionFeature");

            migrationBuilder.DropForeignKey(
                name: "FK_ParkingSite_Attraction_AttractionId",
                table: "ParkingSite");

            migrationBuilder.DropTable(
                name: "AttractionFeatureAttractions");

            migrationBuilder.DropTable(
                name: "ParkingSiteAttractions");

            migrationBuilder.DropIndex(
                name: "IX_ParkingSite_AttractionId",
                table: "ParkingSite");

            migrationBuilder.DropIndex(
                name: "IX_AttractionFeature_AttractionId",
                table: "AttractionFeature");

            migrationBuilder.DropColumn(
                name: "AttractionId",
                table: "ParkingSite");

            migrationBuilder.DropColumn(
                name: "AttractionId",
                table: "AttractionFeature");
        }
    }
}
