using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class ParkingSite : IModel
    {
        // Id from the IModel interface
        public int Id { set; get; }

        public string ParkingType { get; set; }
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public int NeighborhoodId { get; set; }
        public string GPS { get; set; }

        public IList<ParkingSiteAttraction> ParkingSiteAttractions { get; set; }

        // foreign key
        //public int AttractionId { get; set; }
        // navigation property
        //public Attraction Attaction { get; set; }
    }
}
