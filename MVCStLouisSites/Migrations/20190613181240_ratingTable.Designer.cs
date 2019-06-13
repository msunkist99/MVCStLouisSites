﻿// <auto-generated />
using System;
using MVCStLouisSites.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCStLouisSites.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190613181240_ratingTable")]
    partial class ratingTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MVCStLouisSites.Models.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.Attraction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BackgroundImageId");

                    b.Property<string>("Description");

                    b.Property<int>("IconImageId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Attraction");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.AttractionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("AttractionType");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.BackgroundImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BackgroundImageFileLocation");

                    b.HasKey("Id");

                    b.ToTable("BackgroundImage");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.CalenderOfEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description");

                    b.Property<string>("EndTime");

                    b.Property<string>("Name");

                    b.Property<string>("StartTime");

                    b.HasKey("Id");

                    b.ToTable("CalenderOfEvent");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailPrivate");

                    b.Property<string>("EmailPublic");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("PhonePrivate");

                    b.Property<string>("PhonePublic");

                    b.Property<string>("TitleName");

                    b.HasKey("Id");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.GeneralInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Information");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("GeneralInformation");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.HoursOfOperation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CloseTime1");

                    b.Property<string>("CloseTime2");

                    b.Property<string>("CloseTime3");

                    b.Property<string>("DayOfWeek");

                    b.Property<string>("OpenTime1");

                    b.Property<string>("OpenTime2");

                    b.Property<string>("OpenTime3");

                    b.HasKey("Id");

                    b.ToTable("HoursOfOperation");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.IconImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("IconImageFileLocation");

                    b.HasKey("Id");

                    b.ToTable("IconImage");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttractionId");

                    b.Property<string>("City");

                    b.Property<string>("County");

                    b.Property<string>("GPS");

                    b.Property<int>("NeighborhoodId");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.HasIndex("AttractionId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.Neighborhood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Neighborhood");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.ParkingType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("County");

                    b.Property<string>("GPS");

                    b.Property<int>("NeighborhoodId");

                    b.Property<string>("State");

                    b.Property<string>("StreetAddress");

                    b.Property<string>("Zip");

                    b.HasKey("Id");

                    b.ToTable("ParkingType");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttractionId");

                    b.Property<string>("Comments");

                    b.Property<DateTime>("DateTimeStamp");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("AttractionId");

                    b.ToTable("Rating");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.UserPrivilege", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("UserPrivileges");
                });

            modelBuilder.Entity("MVCStLouisSites.ViewModels.AttractionViewModels.AttractionUpdateViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BackgroundImageId");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("IconImageId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AttractionUpdateViewModel");
                });

            modelBuilder.Entity("MVCStLouisSites.ViewModels.LocationViewModels.LocationCreateViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttractionId");

                    b.Property<string>("AttractionName");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("County")
                        .IsRequired();

                    b.Property<string>("GPS")
                        .IsRequired();

                    b.Property<int>("NeighborhoodId");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("StreetAddress")
                        .IsRequired();

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("LocationCreateViewModel");
                });

            modelBuilder.Entity("MVCStLouisSites.ViewModels.LocationViewModels.LocationUpdateViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttractionId");

                    b.Property<string>("AttractionName");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("County")
                        .IsRequired();

                    b.Property<string>("GPS")
                        .IsRequired();

                    b.Property<int>("NeighborhoodId");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("StreetAddress")
                        .IsRequired();

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("LocationUpdateViewModel");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("MVCStLouisSites.Models.Location", b =>
                {
                    b.HasOne("MVCStLouisSites.Models.Attraction", "Attaction")
                        .WithMany("Locations")
                        .HasForeignKey("AttractionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MVCStLouisSites.Models.Rating", b =>
                {
                    b.HasOne("MVCStLouisSites.Models.Attraction", "Attaction")
                        .WithMany("Ratings")
                        .HasForeignKey("AttractionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
