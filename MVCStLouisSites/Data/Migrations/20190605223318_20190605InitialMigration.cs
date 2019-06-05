using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MVCStLouisSites.Data.Migrations
{
    public partial class _20190605InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AttractionIndexViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionIndexViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttractionSplashIndexViewModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BackgroundImage = table.Column<string>(nullable: true),
                    IconImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionSplashIndexViewModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttractionType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AttractionSplashIndexViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttractionType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttractionType_AttractionSplashIndexViewModel_AttractionSplashIndexViewModelId",
                        column: x => x.AttractionSplashIndexViewModelId,
                        principalTable: "AttractionSplashIndexViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParkingType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    NeighborhoodId = table.Column<int>(nullable: false),
                    GPS = table.Column<string>(nullable: true),
                    AttractionSplashIndexViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParkingType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ParkingType_AttractionSplashIndexViewModel_AttractionSplashIndexViewModelId",
                        column: x => x.AttractionSplashIndexViewModelId,
                        principalTable: "AttractionSplashIndexViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Attraction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    BackgroundImageId = table.Column<int>(nullable: false),
                    IconImageId = table.Column<int>(nullable: false),
                    AttractionTypeId = table.Column<int>(nullable: true),
                    ParkingTypeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attraction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attraction_AttractionType_AttractionTypeId",
                        column: x => x.AttractionTypeId,
                        principalTable: "AttractionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Attraction_ParkingType_ParkingTypeId",
                        column: x => x.ParkingTypeId,
                        principalTable: "ParkingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Activity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AttractionId = table.Column<int>(nullable: false),
                    AttractionSplashIndexViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activity_Attraction_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activity_AttractionSplashIndexViewModel_AttractionSplashIndexViewModelId",
                        column: x => x.AttractionSplashIndexViewModelId,
                        principalTable: "AttractionSplashIndexViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CalenderOfEvent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<string>(nullable: true),
                    EndTime = table.Column<string>(nullable: true),
                    AttractionId = table.Column<int>(nullable: false),
                    AttractionSplashIndexViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalenderOfEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalenderOfEvent_Attraction_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalenderOfEvent_AttractionSplashIndexViewModel_AttractionSplashIndexViewModelId",
                        column: x => x.AttractionSplashIndexViewModelId,
                        principalTable: "AttractionSplashIndexViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    TitleName = table.Column<string>(nullable: true),
                    PhonePublic = table.Column<string>(nullable: true),
                    PhonePrivate = table.Column<string>(nullable: true),
                    EmailPublic = table.Column<string>(nullable: true),
                    EmailPrivate = table.Column<string>(nullable: true),
                    AttractionId = table.Column<int>(nullable: false),
                    AttractionSplashIndexViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_Attraction_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contact_AttractionSplashIndexViewModel_AttractionSplashIndexViewModelId",
                        column: x => x.AttractionSplashIndexViewModelId,
                        principalTable: "AttractionSplashIndexViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GeneralInformation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Information = table.Column<string>(nullable: true),
                    AttractionId = table.Column<int>(nullable: false),
                    AttractionSplashIndexViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralInformation_Attraction_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralInformation_AttractionSplashIndexViewModel_AttractionSplashIndexViewModelId",
                        column: x => x.AttractionSplashIndexViewModelId,
                        principalTable: "AttractionSplashIndexViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HoursOfOperation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DayOfWeek = table.Column<string>(nullable: true),
                    OpenTime1 = table.Column<string>(nullable: true),
                    CloseTime1 = table.Column<string>(nullable: true),
                    OpenTime2 = table.Column<string>(nullable: true),
                    CloseTime2 = table.Column<string>(nullable: true),
                    OpenTime3 = table.Column<string>(nullable: true),
                    CloseTime3 = table.Column<string>(nullable: true),
                    AttractionId = table.Column<int>(nullable: false),
                    AttractionSplashIndexViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoursOfOperation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoursOfOperation_Attraction_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HoursOfOperation_AttractionSplashIndexViewModel_AttractionSplashIndexViewModelId",
                        column: x => x.AttractionSplashIndexViewModelId,
                        principalTable: "AttractionSplashIndexViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zip = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    NeighborhoodId = table.Column<int>(nullable: false),
                    GPS = table.Column<string>(nullable: true),
                    AttractionId = table.Column<int>(nullable: false),
                    AttractionSplashIndexViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Location_Attraction_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Location_AttractionSplashIndexViewModel_AttractionSplashIndexViewModelId",
                        column: x => x.AttractionSplashIndexViewModelId,
                        principalTable: "AttractionSplashIndexViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Neighborhood",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AttractionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Neighborhood", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Neighborhood_Attraction_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Number = table.Column<int>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    AttractionId = table.Column<int>(nullable: false),
                    AttractionSplashIndexViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rating_Attraction_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rating_AttractionSplashIndexViewModel_AttractionSplashIndexViewModelId",
                        column: x => x.AttractionSplashIndexViewModelId,
                        principalTable: "AttractionSplashIndexViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPrivilege",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AttractionId = table.Column<int>(nullable: false),
                    AttractionSplashIndexViewModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPrivilege", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserPrivilege_Attraction_AttractionId",
                        column: x => x.AttractionId,
                        principalTable: "Attraction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPrivilege_AttractionSplashIndexViewModel_AttractionSplashIndexViewModelId",
                        column: x => x.AttractionSplashIndexViewModelId,
                        principalTable: "AttractionSplashIndexViewModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activity_AttractionId",
                table: "Activity",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Activity_AttractionSplashIndexViewModelId",
                table: "Activity",
                column: "AttractionSplashIndexViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Attraction_AttractionTypeId",
                table: "Attraction",
                column: "AttractionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Attraction_ParkingTypeId",
                table: "Attraction",
                column: "ParkingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttractionType_AttractionSplashIndexViewModelId",
                table: "AttractionType",
                column: "AttractionSplashIndexViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CalenderOfEvent_AttractionId",
                table: "CalenderOfEvent",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_CalenderOfEvent_AttractionSplashIndexViewModelId",
                table: "CalenderOfEvent",
                column: "AttractionSplashIndexViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AttractionId",
                table: "Contact",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_AttractionSplashIndexViewModelId",
                table: "Contact",
                column: "AttractionSplashIndexViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralInformation_AttractionId",
                table: "GeneralInformation",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralInformation_AttractionSplashIndexViewModelId",
                table: "GeneralInformation",
                column: "AttractionSplashIndexViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_HoursOfOperation_AttractionId",
                table: "HoursOfOperation",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_HoursOfOperation_AttractionSplashIndexViewModelId",
                table: "HoursOfOperation",
                column: "AttractionSplashIndexViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_AttractionId",
                table: "Location",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Location_AttractionSplashIndexViewModelId",
                table: "Location",
                column: "AttractionSplashIndexViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Neighborhood_AttractionId",
                table: "Neighborhood",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_ParkingType_AttractionSplashIndexViewModelId",
                table: "ParkingType",
                column: "AttractionSplashIndexViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_AttractionId",
                table: "Rating",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_Rating_AttractionSplashIndexViewModelId",
                table: "Rating",
                column: "AttractionSplashIndexViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivilege_AttractionId",
                table: "UserPrivilege",
                column: "AttractionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPrivilege_AttractionSplashIndexViewModelId",
                table: "UserPrivilege",
                column: "AttractionSplashIndexViewModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activity");

            migrationBuilder.DropTable(
                name: "AttractionIndexViewModel");

            migrationBuilder.DropTable(
                name: "CalenderOfEvent");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "GeneralInformation");

            migrationBuilder.DropTable(
                name: "HoursOfOperation");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Neighborhood");

            migrationBuilder.DropTable(
                name: "Rating");

            migrationBuilder.DropTable(
                name: "UserPrivilege");

            migrationBuilder.DropTable(
                name: "Attraction");

            migrationBuilder.DropTable(
                name: "AttractionType");

            migrationBuilder.DropTable(
                name: "ParkingType");

            migrationBuilder.DropTable(
                name: "AttractionSplashIndexViewModel");
        }
    }
}
