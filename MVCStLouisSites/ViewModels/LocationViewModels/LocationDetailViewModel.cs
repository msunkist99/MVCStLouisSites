using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels.AttractionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.LocationViewModels
{
    public class LocationDetailViewModel
    {
        public static LocationDetailViewModel GetLocationByLocationId(ApplicationDbContext context, int locationId)
        {
            IModel model = RepositoryFactory.GetLocationRepository(context)
                                            .GetById(locationId);

            Location location = (Location)model;

            LocationDetailViewModel viewModel = SetLocationDetailViewModel(context, location);
            viewModel.AttractionName = SetLocationAttractionName(context, viewModel.AttractionId);
            return viewModel;
        }

        public static List<LocationDetailViewModel> GetLocationModels(ApplicationDbContext context)
        {
            List<Location> locationModels = RepositoryFactory.GetLocationRepository(context)
                                                             .GetModels()
                                                             .Cast<Location>()
                                                             .ToList();

            List<LocationDetailViewModel> locationViewModels = new List<LocationDetailViewModel>();

            foreach(Location location in locationModels)
            {
                LocationDetailViewModel viewModel = SetLocationDetailViewModel(context, location);
                viewModel.AttractionName = SetLocationAttractionName(context, viewModel.AttractionId);

                locationViewModels.Add(viewModel);
            }
            return locationViewModels;
        }

        public static List<LocationDetailViewModel> GetLocationModelsByAttractionId(ApplicationDbContext context, int attractionId)
        {
            // pull from the database here in LocationDetailViewModel instead of from LocationRepository because
            // GetLocationModelsByAttractionId is not in IModelRepository interface.
            List<Location> locations = context.Location
                                              .Where(location => location.AttractionId == attractionId)
                                              .ToList();

            List<LocationDetailViewModel> locationViewModels = new List<LocationDetailViewModel>();

            foreach (Location location in locations)
            {
                LocationDetailViewModel viewModel = SetLocationDetailViewModel(context, location);
                locationViewModels.Add(viewModel);
            }
            return locationViewModels;
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

        private static LocationDetailViewModel SetLocationDetailViewModel(ApplicationDbContext context, Location location)
        {
            LocationDetailViewModel viewModel = new LocationDetailViewModel();

            viewModel.Id = location.Id;
            viewModel.StreetAddress = location.StreetAddress;
            viewModel.City = location.City;
            viewModel.State = location.State;
            viewModel.Zip = location.Zip;
            viewModel.County = location.County;
            viewModel.NeighborhoodId = location.NeighborhoodId;
            viewModel.GPS = location.GPS;

            viewModel.AttractionId = location.AttractionId;

            return viewModel;                
        }

        //  break this out from SetLocationDetailViewModel because you can end up in a loop
        //  from GetLocationModelsByAttractionId
        private static string SetLocationAttractionName(ApplicationDbContext context, int attractionId)
        {
            AttractionUpdateViewModel attraction = AttractionUpdateViewModel.GetAttractionById(context, attractionId);
            return attraction.Name;
        }
    }
}
