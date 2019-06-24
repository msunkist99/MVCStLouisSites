using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels.LocationViewModels;
using MVCStLouisSites.ViewModels.AttractionViewModels;
using MVCStLouisSites.ViewModels.RatingViewModels;

namespace MVCStLouisSites.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Attraction> Attraction { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<AttractionFeature> AttractionFeature { get; set; }
        public DbSet<BackgroundImage> BackgroundImage { get; set; }
        public DbSet<CalenderOfEvent> CalenderOfEvent { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<GeneralInformation> GeneralInformation { get; set; }
        public DbSet<HoursOfOperation> HoursOfOperation { get; set; }
        public DbSet<IconImage> IconImage { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Neighborhood> Neighborhood { get; set; }
        public DbSet<ParkingSite> ParkingSite { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<UserPrivilege> UserPrivilege { get; set; }

        // many-to-many stuff
        public DbSet<AttractionAttractionFeatureJoin> AttractionAttractionFeatureJoin { get; set; }
        public DbSet<AttractionParkingSiteJoin> AttractionParkingSiteJoin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // to avoid this error when creating your migration
            // The entity type 'IdentityUserLogin<string>' requires a primary key to be defined.
            // include the line below ---- base.OnModelCreating(modelBuilder);
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<AttractionAttractionFeatureJoin>()
                .HasKey(bc => new { bc.AttractionId, bc.AttractionFeatureId });
            modelBuilder.Entity<AttractionAttractionFeatureJoin>()
                .HasOne(bc => bc.Attraction)
                .WithMany(b => b.AttractionAttractionFeatureJoins)
                .HasForeignKey(bc => bc.AttractionFeatureId);
            modelBuilder.Entity<AttractionAttractionFeatureJoin>()
                .HasOne(bc => bc.AttractionFeature)
                .WithMany(c => c.AttractionAttractionFeatureJoins)
                .HasForeignKey(bc => bc.AttractionId);

            modelBuilder.Entity<AttractionParkingSiteJoin>()
                .HasKey(bc => new { bc.AttractionId, bc.ParkingSiteId });
            modelBuilder.Entity<AttractionParkingSiteJoin>()
                .HasOne(bc => bc.Attraction)
                .WithMany(b => b.AttractionParkingSiteJoins)
                .HasForeignKey(bc => bc.ParkingSiteId);
            modelBuilder.Entity<AttractionParkingSiteJoin>()
                .HasOne(bc => bc.ParkingSite)
                .WithMany(c => c.AttractionParkingSiteJoins)
                .HasForeignKey(bc => bc.AttractionId);
        }
    }
}
