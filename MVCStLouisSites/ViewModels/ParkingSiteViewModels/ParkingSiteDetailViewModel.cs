using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.ViewModels.ParkingSiteViewModels
{
    public class ParkingSiteDetailViewModel
    {
        public int Id { get; set; }
        public string ParkingType { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public string NeighborhoodId { get; set; }
        public string GPS { get; set; }
        
        public bool Selected { get; set; }

        // foreign key
        public int AttractionId { get; set; }
        public string AttractionName { get; set; }
    }
}
