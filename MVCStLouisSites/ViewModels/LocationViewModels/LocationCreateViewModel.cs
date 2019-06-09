using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels.AttractionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.LocationViewModels
{
    public class LocationCreateViewModel
    {
        public LocationCreateViewModel(ApplicationDbContext context, int attractionId)
        {
            AttractionUpdateViewModel attraction = AttractionUpdateViewModel.GetAttractionById(context, attractionId);

            this.AttractionId = attraction.Id;
            this.AttractionName = attraction.Name;
        }

        public static int CreateLocation(ApplicationDbContext context, LocationCreateViewModel locationViewModel)
        {
            Location location = new Location();

            location.StreetAddress = locationViewModel.StreetAddress;
            location.City = locationViewModel.City;
            location.State = locationViewModel.State;
            location.Zip = locationViewModel.Zip;

            location.AttractionId = locationViewModel.AttractionId;

            IModel model = (IModel)location;
            RepositoryFactory.GetLocationRepository(context)
                             .Save(model);

            return model.Id;
        }

        public int Id { set; get; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public int NeighborhoodId { get; set; }
        public string GPS { get; set; }

        // foreign key
        public int AttractionId { get; set; }
        public string AttractionName { get; set; }
    }
}
