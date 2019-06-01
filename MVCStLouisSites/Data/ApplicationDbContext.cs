using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCStLouisSites.ViewModels.StLouisSites;
using MVCStLouisSites.ViewModels.DisplayAttractions;

namespace MVCStLouisSites.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MVCStLouisSites.ViewModels.StLouisSites.StLouisSitesIndexViewModel> StLouisSitesIndexViewModel { get; set; }
        public DbSet<MVCStLouisSites.ViewModels.DisplayAttractions.AttractionSplashIndexViewModel> AttractionSplashIndexViewModel { get; set; }
    }
}
