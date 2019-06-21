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
    public class LocationCreateViewModel
    {
        public LocationCreateViewModel() { }

        public LocationCreateViewModel(ApplicationDbContext context, int attractionId = 0)
        {
            if (attractionId > 0)
            {
                AttractionUpdateViewModel attraction = AttractionUpdateViewModel.GetAttractionById(context, attractionId);
                this.AttractionId = attraction.Id;
                this.AttractionName = attraction.Name;
            }

            CountyItems = new List<String>();
            CountyItems.Add("St Louis City");
            CountyItems.Add("South St Louis County");
            CountyItems.Add("West St Louis County");
            CountyItems.Add("North St Louis County");
            CountyItems.Add("St Charles County");
            CountyItems.Add("St Clair County");
            CountyItems.Add("Monroe County");
            CountyItems.Add("Madison County");
            CountyItems.Add("Jefferson County");
        }

        public static int CreateLocation(ApplicationDbContext context, LocationCreateViewModel locationViewModel)
        {
            Location location = new Location();

            location.StreetAddress = locationViewModel.StreetAddress;
            location.City = locationViewModel.City;
            location.State = locationViewModel.State;
            location.Zip = locationViewModel.Zip;
            location.County = locationViewModel.County;

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

        [Required]
        public string County { get; set; }

        [Required]
        public int NeighborhoodId { get; set; }

        [Required]
        public string GPS { get; set; }

        // foreign key
        public int AttractionId { get; set; }
        public string AttractionName { get; set; }

        public List<String> CountyItems { get; set; }

    }
}
