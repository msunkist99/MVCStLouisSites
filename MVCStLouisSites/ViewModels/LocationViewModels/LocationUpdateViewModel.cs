using MVCStLouisSites.Data;
using MVCStLouisSites.Models;
using MVCStLouisSites.ViewModels.AttractionViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.LocationViewModels
{
    public class LocationUpdateViewModel
    {
        public static LocationUpdateViewModel GetLocationById(ApplicationDbContext context, int id)
        {
            IModel model = RepositoryFactory.GetLocationRepository(context)
                                            .GetById(id);

            Location location = (Location)model;

            LocationUpdateViewModel locationViewModel = new LocationUpdateViewModel();

            locationViewModel.Id = location.Id;
            locationViewModel.StreetAddress = location.StreetAddress;
            locationViewModel.City = location.City;
            locationViewModel.State = location.State;
            locationViewModel.Zip = location.Zip;
            locationViewModel.County = location.County;
            locationViewModel.NeighborhoodId = location.NeighborhoodId;
            locationViewModel.GPS = location.GPS;
            locationViewModel.AttractionId = location.AttractionId;

            AttractionUpdateViewModel attraction = AttractionUpdateViewModel.GetAttractionById(context, location.AttractionId);

            locationViewModel.AttractionName = attraction.Name;

            return locationViewModel;
        }

        public static int UpdateLocation(ApplicationDbContext context, LocationUpdateViewModel locationViewModel)
        {
            Location location = new Location();

            location.Id = locationViewModel.Id;
            location.StreetAddress = locationViewModel.StreetAddress;
            location.City = locationViewModel.City;
            location.State = locationViewModel.State;
            location.Zip = locationViewModel.Zip;
            location.County = locationViewModel.County;
            location.NeighborhoodId = locationViewModel.NeighborhoodId;
            location.GPS = locationViewModel.GPS;
            location.AttractionId = locationViewModel.AttractionId;

            IModel model = (IModel)location;
            RepositoryFactory.GetLocationRepository(context)
                             .Update(model);

            return location.Id;
        }

        public static void DeleteLocationById(ApplicationDbContext context, int id)
        {
            RepositoryFactory.GetLocationRepository(context).Delete(id);
        }

        public int Id { set; get; }


        [Required]
        public string StreetAddress { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        public string Zip { get; set; }

        [Required]
        public string County { get; set; }

        [Required]
        public int NeighborhoodId { get; set; }

        [Required]
        public string GPS { get; set; }

        // foreign key
        public int AttractionId { get; set; }
        public string AttractionName { get; set; }
    }
}
