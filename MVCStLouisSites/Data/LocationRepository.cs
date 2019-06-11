using MVCStLouisSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Data
{
    public class LocationRepository : BaseRepository  // BaseRepository is an IModelRepository
    {
        //  override BaseRepository
        //  we override here until we get the database implemented in the BaseRepository.cs

        // using the constructor we pass in the ApplicationDBContect
        public LocationRepository(ApplicationDbContext context)
        {
            base.context = context;
        }

        /*
        public override List<IModel> GetModels()
        {
            List<Location> locations = new List<Location>();
            Location location = new Location();

            location.Id = 1;
            location.StreetAddress = "One Government Drive";
            location.City = "St. Louis";
            location.State = "Missouri";
            location.Zip = "63110";
            location.County = " St. Louis City";
            location.GPS = "unknown";
            locations.Add(location);

            base.models = locations.Cast<IModel>().ToList();

            return base.models;
        }
        */

        public override IModel GetById(int locationId)
        {
            IModel model = context.Location.Single(location => location.Id == locationId);
            return model;
        }

        public override List<IModel> GetModels()
        {
            List<IModel> models = context.Location
                                         .Cast<IModel>()
                                         .ToList();
            return models;
        }

        public override void Delete(int id)
        {
            IModel model = GetById(id);

            Location location = (Location)model;

            context.Location.Remove(location);
            context.SaveChanges();
        }
    }
}
