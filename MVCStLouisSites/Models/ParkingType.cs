using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class ParkingType : IModel
    {
        // Id from the IModel interface
        public int Id { set; get; }

        public string StreetAddress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string County { get; set; }
        public int NeighborhoodId { get; set; }
        public string GPS { get; set; }

        // navigation property - many-to-many
        public IList<Attraction> Attractions { get; set; }
    }
}
