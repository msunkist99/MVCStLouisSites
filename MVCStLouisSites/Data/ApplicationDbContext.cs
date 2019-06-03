using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVCStLouisSites.ViewModels.AttractionViewModels;

namespace MVCStLouisSites.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MVCStLouisSites.ViewModels.AttractionViewModels.AttractionIndexViewModel> AttractionIndexViewModel { get; set; }
        public DbSet<MVCStLouisSites.ViewModels.AttractionSplashViewModels.AttractionSplashIndexViewModel> AttractionSplashIndexViewModel { get; set; }
    }
}
