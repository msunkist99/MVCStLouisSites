using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCStLouisSites.Migrations
{
    public partial class AttractionFeatureParkingSiteTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttractionType");

            migrationBuilder.DropTable(
                name: "ParkingType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPrivileges",
                table: "UserPrivileges");

            migrationBuilder.RenameTable(
                name: "UserPrivileges",
                newName: "UserPrivilege");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPrivilege",
                table: "UserPrivilege",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AttractionFeature",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionFeature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingSite",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ParkingType = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    NeighborhoodId = table.Column<int>(nullable: false),
                    GPS = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingSite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttractionAttractionFeatureJoin",
                columns: table => new
                {
                    AttractionId = table.Column<int>(nullable: false),
                    AttractionFeatureId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionAttractionFeatureJoin", x => new { x.AttractionId, x.AttractionFeatureId });
                    table.ForeignKey(
                        name: "FK_AttractionAttractionFeatureJoin_Attraction_AttractionFeatureId",
                        column: x => x.AttractionFeatureId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttractionAttractionFeatureJoin_AttractionFeature_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "AttractionFeature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttractionParkingSiteJoin",
                columns: table => new
                {
                    AttractionId = table.Column<int>(nullable: false),
                    ParkingSiteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionParkingSiteJoin", x => new { x.AttractionId, x.ParkingSiteId });
                    table.ForeignKey(
                        name: "FK_AttractionParkingSiteJoin_ParkingSite_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "ParkingSite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttractionParkingSiteJoin_Attraction_ParkingSiteId",
                        column: x => x.ParkingSiteId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AttractionAttractionFeatureJoin_AttractionFeatureId",
                table: "AttractionAttractionFeatureJoin",
                column: "AttractionFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_AttractionParkingSiteJoin_ParkingSiteId",
                table: "AttractionParkingSiteJoin",
                column: "ParkingSiteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AttractionAttractionFeatureJoin");

            migrationBuilder.DropTable(
                name: "AttractionParkingSiteJoin");

            migrationBuilder.DropTable(
                name: "AttractionFeature");

            migrationBuilder.DropTable(
                name: "ParkingSite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPrivilege",
                table: "UserPrivilege");

            migrationBuilder.RenameTable(
                name: "UserPrivilege",
                newName: "UserPrivileges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPrivileges",
                table: "UserPrivileges",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AttractionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ParkingType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    City = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    GPS = table.Column<string>(nullable: true),
                    NeighborhoodId = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingType", x => x.Id);
                });
        }
    }
}
