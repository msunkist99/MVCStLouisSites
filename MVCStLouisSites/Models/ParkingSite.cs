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
        public string ParkingType { get; set; }     // free, valet, paid, assigned
        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public int NeighborhoodId { get; set; }
        public string GPS { get; set; }

        // navigation property - many parking sites to-many attractions
        public IList<AttractionParkingSiteJoin> AttractionParkingSiteJoins { get; set; }
        public IList<Attraction> Attractions { get; set; }
    }
}
