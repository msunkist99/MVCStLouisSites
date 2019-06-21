using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCStLouisSites.Models
{
    public class AttractionParkingSiteJoin
    {
        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }
        public int ParkingSiteId { get; set; }
        public ParkingSite ParkingSite { get; set; }
    }
}
