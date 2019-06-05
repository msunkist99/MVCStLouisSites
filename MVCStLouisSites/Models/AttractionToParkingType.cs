using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class AttractionToParkingType
    {
        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }

        // navigation property - many attractions to-many parking types
        public IList<AttractionToParkingType> AttractionsToParkingTypes { get; set; }
    }
}
