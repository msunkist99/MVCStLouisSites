using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels.AttractionViewModels;

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
        public DbSet<AttractionType> AttractionType { get; set; }
        public DbSet<BackgroundImage> BackgroundImage { get; set; }
        public DbSet<CalenderOfEvent> CalenderOfEvent { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<GeneralInformation> GeneralInformation { get; set; }
        public DbSet<HoursOfOperation> HoursOfOperation { get; set; }
        public DbSet<IconImage> IconImage { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Neighborhood> Neighborhood { get; set; }
        public DbSet<ParkingType> ParkingType { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<UserPrivilege> UserPrivileges { get; set; }
        public DbSet<MVCStLouisSites.ViewModels.AttractionViewModels.AttractionUpdateViewModel> AttractionUpdateViewModel { get; set; }
    }
}
