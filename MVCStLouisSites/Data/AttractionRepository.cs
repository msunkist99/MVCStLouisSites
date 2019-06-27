using Microsoft.EntityFrameworkCore;
using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Data
{
    public class AttractionRepository: BaseRepository  // BaseRepository is an IModelRepository
    {
        // using the constructor we pass in the ApplicationDBContect
        public AttractionRepository (ApplicationDbContext context)
        {
            base.context = context;
        }

        public override void Delete(int id)
        {
            IModel model = GetById(id);

            Attraction attraction = (Attraction)model;

            context.Attraction.Remove(attraction);
            context.SaveChanges();
        }

        public override IModel GetById(int id)
        {
            // IModel model = context.Attraction.Single(attraction => attraction.Id == id);
            // the following is called 'eager' loading
            // Eager loading is the process whereby a query for one type of entity also 
            // loads related entities as part of the query. 
            // Eager loading is achieved by the use of the Include method.
            IModel model = context.Attraction
                                  .Include(locations => locations.Locations)
                                  .Include("Ratings")
                                  .Include("BackgroundImage")
                                  .Include("IconImage")
                                  .Include(i => i.AttractionFeatureAttractions)
                                        .ThenInclude(i=> i.AttractionFeature)   // on the AttractionFeatureAttraction
                                  .Include(i=> i.ParkingSiteAttractions)        // on the ParkingSiteAttraction
                                        .ThenInclude(i=> i.ParkingSite)
                                  .Single(attraction => attraction.Id == id);
            return model;
        }

        public override List<IModel> GetModels()
        {
            //List<IModel> models = context.Attraction.Cast<IModel>().ToList();
            List<IModel> models = context.Attraction
                                         .Include(locations => locations.Locations)
                                         .Include("Ratings")
                                         .Include("BackgroundImage")
                                         .Include("IconImage")
                                         .Cast<IModel>()
                                         .ToList();

            return models;
        }
    }
}
